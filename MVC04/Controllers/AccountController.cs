using Microsoft.AspNetCore.Mvc;

namespace MVC04.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
