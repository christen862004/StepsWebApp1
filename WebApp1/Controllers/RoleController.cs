using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    [Authorize(Roles ="Admin")]//check cookie claim Role =Admin
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManage;

        public RoleController(RoleManager<IdentityRole> roleManage)
        {
            this.roleManage = roleManage;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleFromReq)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = roleFromReq.RoleName };
                IdentityResult result=  await roleManage.CreateAsync(role);
                //create
                if (result.Succeeded)
                {
                    return RedirectToAction("All","Employee");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Create");
        }
    }
}
