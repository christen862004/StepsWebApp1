using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class StateController : Controller
    {
        
        //Session store ==>get
        public IActionResult setSession(string name,int age)
        {
            //logic
            //store
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Store Success");
        }
        public IActionResult GetSession()
        {
            //logic
            //read info session
            string n=HttpContext.Session.GetString("Name");
            int? a =  HttpContext.Session.GetInt32("Age");
            return Content($"Name={n}\t Age={a}");
        }

        public IActionResult SetCookie(string name,int age)
        {
            //server =response=>client
            //session cookie expired with session
            HttpContext.Response.Cookies.Append("Name", name);
            //Presistent cookie "Expiration date"
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddHours(1);

            HttpContext.Response.Cookies.Append("Age", age.ToString(), options);
            return Content("Cookie sucess Added");
        }
        public IActionResult GetCookie() {
            //logic 
            //name from coooie
            string name=HttpContext.Request.Cookies["Name"];
            string age=HttpContext.Request.Cookies["Age"];
            return Content($"From Cookie name ={name}\t age={age}");
        }

    }
}
