using Demo.Service.Dtos.DepartmentsDTO;
using Demo.Service.Services.DepartmentsService;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MVC04.ViewModels.DepartmentViewModels;
using System.Threading.Tasks;

namespace MVC04.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _DepartmentService.GetAllDepartments();
            return View(model);
        }


        public async Task<IActionResult> Details(int id)
        {
            var model = await _DepartmentService.GetDepartmentById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }






        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _DepartmentService.AddDepartment(dto);
                    return RedirectToAction("Index");
                }
                return View(dto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "An error occurred while creating the department. Please try again.");
                return View(dto);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var d = await _DepartmentService.GetDepartmentById(id);

            if (d == null)
            {
                return NotFound();
            }

            var dept = new DepartmentViewModel
            {
               
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation =DateOnly.FromDateTime (d.DateOfCreation)
            };

            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute]int id,UpdateDepartmentDto Dept)
        {
            try
            {
                await _DepartmentService.UpdateDepartment(id, Dept);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the department. Please try again.");
                return View(Dept);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _DepartmentService.GetDepartmentById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if(! await _DepartmentService.DeleteDepartment(id))
                    return BadRequest();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the department. Please try again.");
                return RedirectToAction(nameof(Index));
            }
          
        }
    }
}
