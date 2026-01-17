using Microsoft.AspNetCore.Mvc;
using System.CodeDom;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class DepartmentController : Controller
    {
        StepsContext context=new StepsContext();
        public DepartmentController()
        {
            
        }

        public IActionResult Index()
        {
            List<Department> departmentList = context.Departments.ToList();
            return View("Index", departmentList);
        }
        #region New Department
        public IActionResult New()
        {
            return View("New");//Model null
        }
        //Department/SaveNew?Name=fsdf&ManagerName=Ahemd
        //Property with the same name of input name
        //Action can handel Req :get | Post 
        [HttpPost]
        public IActionResult SaveNew(Department DeptFromReq)//Stawbery 
        {
            //if(Request.Method== "POST") { }
            if (DeptFromReq.Name != null)
            {
                context.Departments.Add(DeptFromReq);
                context.SaveChanges();
                return RedirectToAction("Index", "Department");
            }
            return View("New", DeptFromReq);//Model DEpartmet
        }




        #endregion

        //Department/Details/1
        //Department/Details?id=1
        public IActionResult Details(int id)
        {
            //full ddata to view
            string message = "heelo";
            //ViewData["Msg"] = message;
            ViewBag.Msg = "hiiiiiiii";
            int temp = 20;
            ViewData["Temp"] = temp;
            List<string> Branches= new List<string>() { "Assiut","Alex","Cairo","Aswan"};
            ViewData["Branches"]= Branches;
            ViewBag.xyz = 12;
            ViewData["Color"] = "red";
            ViewBag.Color = "blue"; //run [red \ blue]\ thorw exception \ 


            //ask Model to detail sdb
            Department deptModel = context.Departments.FirstOrDefault(d => d.Id == id);
            //send to view
            return View("Details",deptModel);
            //go to view with name DEtails ==> insidde DEpartment Folder
            //Model with type Department
        }

        public IActionResult DetailsVM(int id)
        {
            //Collect Info
            string message = "heelo";
            int temp = 20;
            List<string> Branches = new List<string>() { "Assiut", "Alex", "Cairo", "Aswan" };
            //ask Model to detail sdb
            Department deptModel = context.Departments.FirstOrDefault(d => d.Id == id);

            //Delare ViewModel
            DeptDetailsWithMsgTempBranchesandColorViewModel DeptVM = new();
            //set (Mapping) to ViewModel
            DeptVM.DeptID = deptModel.Id;
            DeptVM.DeptName = deptModel.Name;
            DeptVM.Message = "hello"; ;
            DeptVM.Temp=temp;
            DeptVM.Branches = Branches;


                       
            //send viewModedl to view
            return View("DetailsVM", DeptVM);
            //View :DetailsVM
            //Model : with type DeptDetailsWithMsgTempBranchesandColorViewModel
        }
    }
}
