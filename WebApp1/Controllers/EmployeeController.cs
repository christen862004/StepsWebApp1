using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using WebApp1.Repository;

namespace WebApp1.Controllers
{
    //Solid Principle
    public class EmployeeController : Controller
    {
        //StepsContext context=new StepsContext();//deal db Bussiness Layer
        IEmployeeRepository EmpRepo;//depend on abstraction
        IDepartmentRepository deptRepo;
        public EmployeeController(IEmployeeRepository empRepo,IDepartmentRepository deptRepo)
        {
            EmpRepo = empRepo;
            this.deptRepo = deptRepo;
        }

        //Employee/All
        public IActionResult All()
        {
            //Logic Ask Model From Data From DB
            List<Employee> EmpList = EmpRepo.GetAll();
            //Send To View
            return View("AllEmp",EmpList);
            //Load View with name AllEmp  ==> Employee Folder
            //Model with Typle List<Employee>
        }
        #region CheckSalary

        //Get /Employee/CheckSalary?Salary=valu
        public IActionResult CheckSalary(int Salary,string Name)
        {
            if (Salary > 1000)
                return Json(true);
            return Json(false);
        }
        #endregion

        #region New
        [HttpGet]
        public IActionResult New()
        {

            ViewData["DeptList"] = deptRepo.GetAll();
            return View("New");//end request send response View()
        }
        //attribute ???????????
        [HttpPost]
        [ValidateAntiForgeryToken]//reque.form["_re.."]
        public IActionResult SaveNew(Employee EmpFromRequest)
        {
//            if (EmpFromRequest.Name != null)
            if(ModelState.IsValid)//Server Side Valiadtion
            {
                try
                {
                    EmpRepo.Add(EmpFromRequest);
                    EmpRepo.Save();
                    return RedirectToAction("All", "Employee");//cant end but all action can do it
                }catch (Exception ex)
                {
                    //select department
                    //ModelState.AddModelError("DepartmentId", "Plesae Select DEpartment");
                    ModelState.AddModelError("xyz", ex.InnerException.Message);//div only
                }
            }
            ViewData["DeptList"] = deptRepo.GetAll();

            return View("New",EmpFromRequest);//in case value wrong back to view
        }

        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            //Collect
            Employee empFRomDb= EmpRepo.GetById(id);
            if(empFRomDb == null)
            {
                return NotFound();
            }
            List<Department> DeptListLocal = deptRepo.GetAll(); ;
            //Declare VM &mapping
            EmpWithDeptListViewModel EmVM=  new EmpWithDeptListViewModel() { 
                Id=empFRomDb.Id,
                Name=empFRomDb.Name,
                ImageURl=empFRomDb.ImageURl,
                Salary=empFRomDb.Salary,
                DepartmentId=empFRomDb.DepartmentId,
                DeptList= DeptListLocal
            };
            //Send
            return View("Edit", EmVM);
        }
        //automapper <Employee,EMVM>()
        [HttpPost]
        public IActionResult SaveEdit(EmpWithDeptListViewModel EmpFromREq)//Create obj
        {
            if (EmpFromREq.Name != null &&EmpFromREq.Salary>8000)
            {
                
                Employee empFromDB =new Employee();
                empFromDB.Id = EmpFromREq.Id;
                //map
                empFromDB.Name= EmpFromREq.Name;
                empFromDB.Salary= EmpFromREq.Salary;
                empFromDB.ImageURl= EmpFromREq.ImageURl;
                empFromDB.DepartmentId= EmpFromREq.DepartmentId;
                EmpRepo.Update(empFromDB);
                //save
                EmpRepo.Save();
                //index
                return RedirectToAction("All", "Employee");
            }
            //refull list
            EmpFromREq.DeptList = deptRepo.GetAll();
            return View("Edit", EmpFromREq);

        }
        #endregion

        //Employee/Details/1
        //Employee/Details/2
        //Employee/Details/3?name=ahmed
        //Employee/Details?id=3

        public IActionResult Details(int id,string name)
        {
            Employee employee = EmpRepo.GetById(id);
            if(employee==null)
            {
                return NotFound();
            }
            return View("Details", employee);
            //View Details
            //Model Employee
        }

    }
}
