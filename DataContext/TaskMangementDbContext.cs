using CQRS_and_MediatR.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_MediatR.DataContext
{
    public class TaskMangementDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public TaskMangementDbContext(DbContextOptions<TaskMangementDbContext> options) : base(options)
        {
        }
    }
}
