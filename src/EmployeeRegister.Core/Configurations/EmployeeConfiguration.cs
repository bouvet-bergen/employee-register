using EmployeeRegister.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeRegister.Core.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Employee");
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(p => p.Birth).HasColumnName("Birth").IsRequired();
            builder.HasMany(x => x.Employees).WithOne(x => x.Manager).HasForeignKey(x => x.ManagerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
