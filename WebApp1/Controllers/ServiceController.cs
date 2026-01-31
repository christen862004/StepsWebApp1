using Microsoft.AspNetCore.Mvc;
using WebApp1.Repository;

namespace WebApp1.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService service;

        public ServiceController(IService service)//inject
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            ViewData["Id"] = service.Id;
            return View("Index");
        }
    }
}
