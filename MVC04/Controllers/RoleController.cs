using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC04.ViewModels.RoleViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MVC04.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

 
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

      
        public async Task<IActionResult> Index(string searchValue)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (!string.IsNullOrEmpty(searchValue))
            {
                roles = roles.Where(r => r.Name.ToLower().Contains(searchValue.ToLower())).ToList();
            }

            var mappedRoles = roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                RoleName = r.Name
            });

            return View(mappedRoles);
        }

        
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = model.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return BadRequest();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var mappedRole = new RoleViewModel { Id = role.Id, RoleName = role.Name };
            return View(mappedRole);
        }

       
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return BadRequest();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var mappedRole = new RoleViewModel { Id = role.Id, RoleName = role.Name };
            return View(mappedRole);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, RoleViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null) return NotFound();

                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var mappedRole = new RoleViewModel { Id = role.Id, RoleName = role.Name };
            return View(mappedRole);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}