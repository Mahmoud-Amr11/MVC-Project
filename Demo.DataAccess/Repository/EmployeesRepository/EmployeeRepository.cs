using Demo.DataAccess.Data;
using Demo.DataAccess.Migrations;

namespace Demo.DataAccess.Repository.EmployeesRepository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
