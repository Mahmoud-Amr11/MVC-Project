using Demo.Service.Dtos;
using Demo.Service.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
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

            var dept = new UpdateDepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = d.DateOfCreation
            };

            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDepartmentDto dto)
        {
            try
            {
               await _DepartmentService.UpdateDepartment(dto);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the department. Please try again.");
                return View(dto);
            }

        }
    }
}
