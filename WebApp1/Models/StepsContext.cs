using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class StepsContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public StepsContext() : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AppStep3;Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 1, Name = "BackEnd1", ManagerName = "Ahmed" });
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 2, Name = "FrontEnd", ManagerName = "Mohamed" });
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 3, Name = "FullStack", ManagerName = "Ali" });

            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 1, Name = "Mary", Salary = 10000, ImageURl = "2.jpg", DepartmentId = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 2, Name = "Hussien", Salary = 10000, ImageURl = "m.png", DepartmentId = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 3, Name = "Mohsen", Salary = 10000, ImageURl = "m.png", DepartmentId = 3 });
        }
    }
}
