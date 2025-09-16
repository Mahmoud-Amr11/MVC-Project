using Demo.DataAccess.Models.Employees;
using Demo.DataAccess.Repository;
using Demo.Service.Dtos.EmployeesDTO;
using Microsoft.EntityFrameworkCore;

namespace Demo.Service.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.Get()
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    IsActive = e.IsActive,
                    Salary = e.Salary,
                    Email = e.Email,
                    Gender = e.Gender.ToString(),
                    EmployeeType = e.EmployeeType.ToString()
                }).ToListAsync();
        }

        public async Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id)
        {
            var e = await _employeeRepository.GetByIdAsync(id);
            if (e == null) return null;

            return new EmployeeDetailsDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Address = e.Address,
                IsActive = e.IsActive,
                Salary = e.Salary,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HiringDate = e.HiringDate,
                Gender = e.Gender.ToString(),
                EmployeeType = e.EmployeeType.ToString()
            };
        }

        public async Task<int> AddEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Age = dto.Age,
                Address = dto.Address,
                IsActive = dto.IsActive,
                Salary = dto.Salary,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                HiringDate = dto.HiringDate,
                Gender = Enum.Parse<Gender>(dto.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(dto.EmployeeType),
                
            };

            await _employeeRepository.Add(employee);
            _employeeRepository.SaveChanges();
            return employee.Id;
        }

        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(dto.Id);
            if (employee == null) return false;

            employee.Name = dto.Name;
            employee.Age = dto.Age;
            employee.Address = dto.Address;
            employee.IsActive = dto.IsActive;
            employee.Salary = dto.Salary;
            employee.Email = dto.Email;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.HiringDate = dto.HiringDate;
            employee.Gender = Enum.Parse<Gender>(dto.Gender);
            employee.EmployeeType = Enum.Parse<EmployeeType>(dto.EmployeeType);
            

            _employeeRepository.Update(employee);
            _employeeRepository.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return false;

            _employeeRepository.Remove(employee);
            _employeeRepository.SaveChanges();
            return true;
        }
    }
}
