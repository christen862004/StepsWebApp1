using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class BindController : Controller
    {
        /*
            <form action="Bind/TestPrmitive" method=get>
                <input name="age">    
                <input name="name">    
                <input name="color[1]">    
                <input name="color[0]">    
                <input type="sumit">    

            </form>
         */
        //Bind/TestPrmitive?age=12&name=Ahemd&id=9999
        //Bind/TestPrmitive/99999?age=12&name=Ahemd&color=red&color=blue
        public IActionResult TestPrmitive(int id,int age,string name,string[] color)
        {
            return Content("OK");
        }

        //Test  Collection(list -dic -stack)
        //Bind/TestDic?name=chris&PhoneBook[ahmed]=123&PhoneBook[mohamed]=456
        public IActionResult TestDic(Dictionary<string, string> PhoneBook,string name) 
        {
            
            return Content("OK");

        }

        //Test Custom Object
        //Bind/TestObj?Id=1&Name=SD&ManagerName=Ahmed
        //public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee> Employees)
        public IActionResult TestObj(Department dept)
        {
            return Content("OK");
        }
    }
}
