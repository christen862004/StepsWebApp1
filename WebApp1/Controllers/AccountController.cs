using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppliactionUser> userManager;
        private readonly SignInManager<AppliactionUser> signInManager;

        public AccountController(UserManager<AppliactionUser> userManager,SignInManager<AppliactionUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region     REgister
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userFRomReq)
        {
            if (ModelState.IsValid)
            {
                //get re ==>appliactionuser
                AppliactionUser appUser = new AppliactionUser() { 
                    Email=userFRomReq.Email,
                    UserName=userFRomReq.UserName,
                    PasswordHash=userFRomReq.Password
                };
                //create dbd
                IdentityResult result= await userManager.CreateAsync(appUser,userFRomReq.Password);   //stop 
                if (result.Succeeded)
                {
                    //assign to Role
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    //create cooike
                    await signInManager.SignInAsync(appUser,false);//id,name,email?,Role?
                    //go to index employee
                    return RedirectToAction("All", "Employee");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
            }
            return View("Register",userFRomReq);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userFRomReq)
        {
            if (ModelState.IsValid)
            {
                //check
                AppliactionUser appUser= await userManager.FindByNameAsync(userFRomReq.UserName);//<!--
                if (appUser != null)
                {
                    bool found= await userManager.CheckPasswordAsync(appUser, userFRomReq.Password);
                    if (found) {
                        //List<Claim> claims = new List<Claim>();
                       // claims.Add(new Claim("Address", appUser.Address));

                        //await signInManager.SignInWithClaimsAsync(appUser, userFRomReq.RememberMe, claims);
                        await signInManager.SignInAsync(appUser, userFRomReq.RememberMe);
                        return RedirectToAction("All", "Employee");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
               
            }
            return View("Login");
        }
        #endregion

        #region SignOut
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}
