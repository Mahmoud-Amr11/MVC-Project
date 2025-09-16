using Demo.DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DataAccess.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

           builder.Property(e=>e.Salary).HasColumnType("decimal(18,2)");
          builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Gender).
                HasConversion((g) => g.ToString(),
                (toGender) => (Gender)Enum.Parse(typeof(Gender), toGender));

            builder.Property(e => e.EmployeeType).HasConversion(et => et.ToString(), (toEmployeeType) => (EmployeeType)Enum.Parse(typeof(EmployeeType), toEmployeeType));
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GetDate()");


        }
    }
}
