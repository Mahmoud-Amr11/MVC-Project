using AutoMapper;
using Demo.DataAccess.Models.Employees;
using Demo.DataAccess.Repository;
using Demo.Service.Dtos.EmployeesDTO;
using Microsoft.EntityFrameworkCore;

namespace Demo.Service.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {

           var employees =  _employeeRepository.Get();
          return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            ///return await _employeeRepository.Get()
            ///    .Select(e => new EmployeeDto
            ///    {
            ///        Id = e.Id,
            ///        Name = e.Name,
            ///        Age = e.Age,
            ///        IsActive = e.IsActive,
            ///        Salary = e.Salary,
            ///        Email = e.Email,
            ///        Gender = e.Gender.ToString(),
            ///        EmployeeType = e.EmployeeType.ToString()
            ///    }).ToListAsync();
        }

        public async Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id)
        {
            var e = await _employeeRepository.GetByIdAsync(id);
            if (e == null) return null;

            return _mapper.Map<EmployeeDetailsDto>(e);

            //return new EmployeeDetailsDto
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Age = e.Age,
            //    Address = e.Address,
            //    IsActive = e.IsActive,
            //    Salary = e.Salary,
            //    Email = e.Email,
            //    PhoneNumber = e.PhoneNumber,
            //    HiringDate = e.HiringDate,
            //    Gender = e.Gender.ToString(),
            //    EmployeeType = e.EmployeeType.ToString()
            //};
        }

        public async Task<int> AddEmployeeAsync(CreateEmployeeDto dto)
        {
            //var employee = new Employee
            //{
            //    Name = dto.Name,
            //    Age = dto.Age,
            //    Address = dto.Address,
            //    IsActive = dto.IsActive,
            //    Salary = dto.Salary,
            //    Email = dto.Email,
            //    PhoneNumber = dto.PhoneNumber,
            //    HiringDate = dto.HiringDate,
            //    Gender = Enum.Parse<Gender>(dto.Gender),
            //    EmployeeType = Enum.Parse<EmployeeType>(dto.EmployeeType),
                
            //};
            var employee = _mapper.Map<Employee>(dto);

            await _employeeRepository.Add(employee);
            _employeeRepository.SaveChanges();
            return employee.Id;
        }

        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(dto.Id);
            if (employee == null) return false;

           var updatedEmployee = _mapper.Map(dto, employee);


            _employeeRepository.Update(updatedEmployee);
            _employeeRepository.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return false;

             employee.IsDeleted = true;
            _employeeRepository.Update(employee);

            return _employeeRepository.SaveChanges() > 0;


        }
    }
}
