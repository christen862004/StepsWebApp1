using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    //1) name Of Class end with Controller
    //2) class inherit form Controller Class (handel requ)
    //Home/Privacy
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Method Call Action
        //1) Method Must be Public 
        //2) MEthod Cant be Static 
        //3) MEthod Cant be OverLoad (in one Case)
        //url://Home/ShowText  "Endpoint"
        //public string ShowText()
        //{
        //    return "Hello";
        //}
        public ContentResult ShowText()
        {
            //logic
            //declare
            //ContentResult result= new ContentResult();
            ////set
            //result.Content = "Hi from my first endpoint";
            ////return
            //return result;
            return Content("Hi from C#");
            
        }

        //Home/ShowView
        public ViewResult ShowView()
        {
            //logic
            return View("View1");
            //NotFoundResult result= new NotFoundResult();
            //return result;
        }


        //public ViewResult View(string viewwName) {

        //    //declare
        //    ViewResult result = new ViewResult();
        //    //set
        //    result.ViewName = viewwName; ;
        //    //return
        //    return result;
        //}
        //Home/ShowMix?name=ahmed&NO=2&id=1               ==>qquery string
        //Home/ShowMix/1?name=ahmed&NO=2               ==>qquery string

        public IActionResult ShowMix(int no,string name,int id)
        {
            if (no % 2 == 0)
            {
                return View("View1");
            }
            else
            {
                
                //NotFoundResult result = new NotFoundResult();
                return NotFound();
            }
        }

        /*
         Action return 
        1) content  ContentResult  ==>Content
        2) view     ViewResult     ==>View
        3) json     JSonResult     ==>Json
        4) Notfound NotFoundResult  ==>NotFound
        .....
         
         */





        //Home/Index
        public IActionResult Index()
        {

            return View();
        }
        //Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
