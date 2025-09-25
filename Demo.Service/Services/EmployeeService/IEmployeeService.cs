using Demo.Service.Dtos.EmployeesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(string? value);
        Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id);
        Task<int> AddEmployeeAsync(CreateEmployeeDto dto);
        Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto dto);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
