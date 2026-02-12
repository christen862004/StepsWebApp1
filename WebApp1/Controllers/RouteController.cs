using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Filtters;

namespace WebApp1.Controllers
{
    //r/mthod1
    //r/mthod2
    //[HandelError]//per all Actions inside this controller
    //[Authorize]//???Cookie
    public class RouteController : Controller//15  14 autho ,1 allow anonums
    {
        //[HandelError] //per action
       // [AllowAnonymous]
        public IActionResult m1() {
            throw new Exception("Error Happen");    
        }
        //[HandelError]
        //[Authorize]//
        public IActionResult m2()
        {
            throw new Exception("Error Happen");
        }
        #region Cusomt Route
        //R1?id=12&name=ahmed
        //R1/12/ahmed
        //R1/12

        //R1/22/chirtseb?age=22 [conotol action,id,name]
        //[Route("R1/{id:int}/{name?}")]
        [HttpGet("R1/{id}")]
        public IActionResult MEthod1(int id,string name,int age)
        {
            return Content("Method 1");
        }
        //R2
        public IActionResult MEthod2()
        {
            return Content("Method 2");
        }
        #endregion
    }
}
