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
