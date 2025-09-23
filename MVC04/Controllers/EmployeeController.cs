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
           var employees= await _employeeService.GetAllEmployeesAsync();

            return View(employees);
        }
    }
}
