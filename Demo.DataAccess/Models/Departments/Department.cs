using Demo.DataAccess.Models.Employees;

namespace Demo.DataAccess.Models.Departments
{
    public class Department:BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string? Description { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
