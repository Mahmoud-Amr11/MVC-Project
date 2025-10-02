using Demo.DataAccess.Models.Identity_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC04.ViewModels.UserViewModels; // تأكد من استدعاء الفولدر الجديد
using System.Linq;
using System.Threading.Tasks;

namespace MVC04.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

       
        public IActionResult Index(string searchValue)
        {
            var users = _userManager.Users.ToList();

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();
                users = users.Where(u => u.FirstName.ToLower().Contains(searchValue) || u.LastName.ToLower().Contains(searchValue)).ToList();
            }

        
            var mappedUsers = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                FName = u.FirstName,
                LName = u.LastName,
                Email = u.Email
            });

            return View(mappedUsers);
        }

  
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return BadRequest();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

     
            var userViewModel = new UserDetailsViewModel()
            {
                Id = user.Id,
                FName = user.FirstName,
                LName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(userViewModel);
        }

     
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return BadRequest();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

           
            var userViewModel = new UserEditViewModel()
            {
                Id = user.Id,
                FName = user.FirstName,
                LName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(userViewModel);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserEditViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return NotFound();

          
                user.FirstName = model.FName;
                user.LastName = model.LName;
                user.Email = model.Email;
                user.UserName = model.Email; 
                user.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

     
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return BadRequest();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

    
            var userViewModel = new UserDetailsViewModel()
            {
                Id = user.Id,
                FName = user.FirstName,
                LName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(userViewModel);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}