using Demo.DataAccess.Data;
using Demo.DataAccess.Repository.DepartmentsRepository;
using Demo.DataAccess.Repository.EmployeesRepository;

namespace Demo.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        

        public Lazy<IEmployeeRepository> employeeRepository;

        public Lazy<IDepartmentRepository> departmentRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_context));
            departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_context));
        }
        

        public IEmployeeRepository EmployeeRepository => employeeRepository.Value;
        public IDepartmentRepository DepartmentRepository => departmentRepository.Value;

      
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
