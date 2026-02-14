using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp1.Controllers
{
    public class StateController : Controller
    {
        //auth welcom name | welomc Gust
        
        public IActionResult Welcome()
        {
            //request ==>cookie idenitity=>this.User.claim(id,name,email,roel) 
            if (User.Identity.IsAuthenticated)
            {
                bool found=User.IsInRole("Admin");
                Claim IdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                Claim AddressClaim= User.Claims.FirstOrDefault(c => c.Type == "Address");
                return Content($"welomce {User.Identity.Name} \t Id = {IdClaim.Value} \t Address={AddressClaim.Value}");
            }
            else
            {
                return Content("Welomce Gust");

            }
        }


        
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
