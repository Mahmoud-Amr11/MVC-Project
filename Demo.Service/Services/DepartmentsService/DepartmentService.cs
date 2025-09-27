using Demo.DataAccess.Models;
using Demo.DataAccess.Models.Departments;
using Demo.DataAccess.Repository.DepartmentsRepository;
using Demo.DataAccess.UnitOfWork;
using Demo.Service.Dtos.DepartmentsDTO;
using Demo.Service.Services.DepartmentsService;
using Microsoft.EntityFrameworkCore;
using System;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentService(IUnitOfWork unitOfWork)
    {
       _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllDepartments( )
    {
        return await _unitOfWork.DepartmentRepository
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
        var d = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);

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

        await _unitOfWork.DepartmentRepository.Add(department);
        _unitOfWork.DepartmentRepository.SaveChanges();

        return department.Id;
    }

    public async Task<bool> UpdateDepartment(int id,UpdateDepartmentDto dto)
    {
        var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);

        if (department == null)
            return false;

        department.Name = dto.Name;
        department.Code = dto.Code;
        department.Description = dto.Description;
        department.CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly());

        _unitOfWork.DepartmentRepository.Update(department);
        return _unitOfWork.DepartmentRepository.SaveChanges() >0 ? true : false;

        
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);
        if (department == null)
            return false;
         _unitOfWork.DepartmentRepository.Remove(department);

        return _unitOfWork.DepartmentRepository.SaveChanges() > 0 ? true : false;
    }
}
