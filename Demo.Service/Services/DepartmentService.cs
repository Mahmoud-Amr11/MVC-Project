using Demo.DataAccess.Models;
using Demo.DataAccess.Repository;
using Demo.Service.Dtos;
using Demo.Service.Services;
using Microsoft.EntityFrameworkCore;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
    {
        return await _departmentRepository
            .Get()
            .Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = d.CreatedOn
            })
            .ToListAsync(); 
    }

    public async Task<DepartmentDetailsDto?> GetDepartmentById(int id)
    {
        var d = await _departmentRepository.GetByIdAsync(id);

        if (d == null) return null;

        return new DepartmentDetailsDto
        {
            Id = d.Id,
            Name = d.Name,
            Code = d.Code,
            Description = d.Description,
            DateOfCreation = d.CreatedOn,
            LastModifiedBy = d.LastModifiedBy,
            LastModifiedOn = d.LastModifiedOn,
            IsDeleted = d.IsDeleted,


        };
    }

    public async Task<int> AddDepartment(CreateDepartmentDto dto)
    {
        var department = new Department
        {
            Name = dto.Name,
            Code = dto.Code,
            Description = dto.Description,
            CreatedOn = dto.DateOfCreation,
            IsDeleted = false
        };

        await _departmentRepository.Add(department);
        _departmentRepository.SaveChanges();

        return department.Id;
    }

    public async Task<bool> UpdateDepartment(UpdateDepartmentDto dto)
    {
        var department = await _departmentRepository.GetByIdAsync(dto.Id);

        if (department == null)
            return false;

        department.Name = dto.Name;
        department.Code = dto.Code;
        department.Description = dto.Description;
        department.CreatedOn = dto.DateOfCreation;

        _departmentRepository.Update(department);
        return _departmentRepository.SaveChanges() >0 ? true : false;

        
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department == null)
            return false;
         _departmentRepository.Remove(department);

        return _departmentRepository.SaveChanges() > 0 ? true : false;
    }
}
