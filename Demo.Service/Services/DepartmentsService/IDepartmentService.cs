using Demo.Service.Dtos.DepartmentsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Services.DepartmentsService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDetailsDto?> GetDepartmentById(int id);
        Task<int> AddDepartment(CreateDepartmentDto dto);
        Task<bool> UpdateDepartment( UpdateDepartmentDto dto);
        Task<bool> DeleteDepartment(int id);

    }
}
