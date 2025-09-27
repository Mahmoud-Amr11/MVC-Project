using AutoMapper;
using Demo.DataAccess.Models.Employees;
using Demo.DataAccess.Repository;
using Demo.DataAccess.Repository.EmployeesRepository;
using Demo.DataAccess.UnitOfWork;
using Demo.Service.AttachmentService;
using Demo.Service.Dtos.EmployeesDTO;
using Microsoft.EntityFrameworkCore;

namespace Demo.Service.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(string? value )
        {
            var Employees = _unitOfWork.EmployeeRepository.Get(e => e.IsDeleted == false);
            if (!string.IsNullOrEmpty(value))
            {
               Employees = Employees.Where(e => e.Name.ToLower().Contains(value) );

            }

           
          return _mapper.Map<IEnumerable<EmployeeDto>>(Employees);
            ///return await _unitOfWork.EmployeeRepository.Get()
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
            var e = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
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
            ///var employee = new Employee
            ///{
            ///    Name = dto.Name,
            ///    Age = dto.Age,
            ///    Address = dto.Address,
            ///    IsActive = dto.IsActive,
            ///    Salary = dto.Salary,
            ///    Email = dto.Email,
            ///    PhoneNumber = dto.PhoneNumber,
            ///    HiringDate = dto.HiringDate,
            ///    Gender = Enum.Parse<Gender>(dto.Gender),
            ///    EmployeeType = Enum.Parse<EmployeeType>(dto.EmployeeType),
            ///};
           
            var employee = _mapper.Map<Employee>(dto);
            if (dto.Image != null)
            {
                var imagePath = await _fileService.SaveImageAsync(dto.Image,"employees");
                employee.Image = imagePath;
            }


            await _unitOfWork.EmployeeRepository.Add(employee);
            
            return _unitOfWork.EmployeeRepository.SaveChanges(); 
        }

        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(dto.Id);
            if (employee == null) return false;

           var updatedEmployee = _mapper.Map(dto, employee);


            _unitOfWork.EmployeeRepository.Update(updatedEmployee);
            _unitOfWork.EmployeeRepository.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null) return false;

             employee.IsDeleted = true;
            _unitOfWork.EmployeeRepository.Update(employee);

            return _unitOfWork.EmployeeRepository.SaveChanges() > 0;


        }
    }
}
