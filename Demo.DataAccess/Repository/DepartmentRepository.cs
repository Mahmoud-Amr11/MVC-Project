using Demo.DataAccess.Data;
using Demo.DataAccess.Models;

namespace Demo.DataAccess.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
