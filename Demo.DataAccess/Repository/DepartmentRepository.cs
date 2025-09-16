using Demo.DataAccess.Data;
using Demo.DataAccess.Models.Departments;

namespace Demo.DataAccess.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
