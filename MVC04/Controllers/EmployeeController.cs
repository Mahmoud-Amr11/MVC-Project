using Demo.Service.Dtos.EmployeesDTO;
using Demo.Service.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC04.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();

            return View(employees);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _employeeService.AddEmployeeAsync(employee);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    ModelState.AddModelError("", "Failed to add employee");
                    return View(employee);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(employee);
                }
            }
            return View(employee);
        }

        public async Task<IActionResult> Details(int id)
        {
             var employee = await  _employeeService.GetEmployeeByIdAsync(id);
            return View(employee);
        }
    }
}
