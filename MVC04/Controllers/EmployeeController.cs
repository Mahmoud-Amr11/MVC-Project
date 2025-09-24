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


        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return View(employee);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();
            var updateEmployeeDto = new UpdateEmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
               
            };
            return View(updateEmployeeDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _employeeService.UpdateEmployeeAsync(employee);
                    if (result)
                        return RedirectToAction(nameof(Index));
                    ModelState.AddModelError("", "Failed to update employee");
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
    }
}
