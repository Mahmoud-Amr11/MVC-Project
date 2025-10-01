using Demo.DataAccess.Models.Identity_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC04.ViewModels.Account;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;

namespace MVC04.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _UserManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _UserManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =await _UserManager.FindByNameAsync(model.UserName);
                if(user is null)
                {
                    var newUser = new ApplicationUser
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.UserName,
                        Email = model.Email,
                      
                    };
                    var result = await _UserManager.CreateAsync(newUser, model.Password);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username already exists");
                }


            }
            return View(model);
        }
    }
}
