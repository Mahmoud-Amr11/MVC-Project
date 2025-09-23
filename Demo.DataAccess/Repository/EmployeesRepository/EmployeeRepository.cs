

using Demo.DataAccess.Data;
using Demo.DataAccess.Models.Employees;

namespace Demo.DataAccess.Repository.EmployeesRepository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
