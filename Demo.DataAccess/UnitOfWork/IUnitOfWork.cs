using Demo.DataAccess.Repository.DepartmentsRepository;
using Demo.DataAccess.Repository.EmployeesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
         IEmployeeRepository EmployeeRepository { get;  }
         IDepartmentRepository DepartmentRepository { get;  }
         Task<int> SaveAsync();

    }
}
