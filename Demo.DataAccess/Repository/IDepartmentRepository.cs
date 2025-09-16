using Demo.DataAccess.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repository
{
    public interface IDepartmentRepository :IRepository<Department>
    {
    }
}
