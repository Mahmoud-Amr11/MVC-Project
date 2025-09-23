using Demo.DataAccess.Migrations;
using Demo.DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repository.EmployeesRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
    }
}
