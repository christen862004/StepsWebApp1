using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class EmployeeController : Controller
    {
        StepsContext context=new StepsContext();

        //Employee/All
        public IActionResult All()
        {
            //Logic Ask Model From Data From DB
            List<Employee> EmpList = context.Employees.ToList();
            //Send To View
            return View("AllEmp",EmpList);
            //Load View with name AllEmp  ==> Employee Folder
            //Model with Typle List<Employee>
        }

        #region Edit
        public IActionResult Edit(int id)
        {
            //Collect
            Employee empFRomDb= context.Employees.FirstOrDefault(e=>e.Id==id);
            List<Department> DeptListLocal = context.Departments.ToList();
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
                //old object frmo db
                Employee empFromDB = context.Employees.FirstOrDefault(e => e.Id == EmpFromREq.Id);
                //map
                empFromDB.Name= EmpFromREq.Name;
                empFromDB.Salary= EmpFromREq.Salary;
                empFromDB.ImageURl= EmpFromREq.ImageURl;
                empFromDB.DepartmentId= EmpFromREq.DepartmentId;
                //save
                context.SaveChanges();
                //index
                return RedirectToAction("All", "Employee");
            }
            //refull list
            EmpFromREq.DeptList = context.Departments.ToList();
            return View("Edit", EmpFromREq);

        }
        #endregion


        //Employee/Details/1
        //Employee/Details/2
        //Employee/Details/3
        //Employee/Details?id=3

        public IActionResult Details(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e=>e.Id==id);
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
