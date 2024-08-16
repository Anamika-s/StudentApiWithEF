using Microsoft.EntityFrameworkCore;
using StudentApiWithEF.Models;

namespace StudentApiWithEF.Context
{
    public class TaskDbContext:DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Dept> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        // this is fluent api used to override conventions of EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // how to provide some initial data
            modelBuilder.Entity<Role>().
   HasData(new Role
   {
      RoleId = 1,
      RoleName="Admin"
   }, new Role
   {
       RoleId = 2,
       RoleName = "Manager",
      },
      new Role
      {
           RoleId = 3,
           RoleName="Employee"
      }
   );
            modelBuilder.Entity<Dept>().HasData(
                new Dept()
                {
                    DeptId = 100,
                    DeptName = "Accts"
                },
                new Dept()
                {
                    DeptId = 101,
                    DeptName = "Sales"
                },
                new Dept()
                {
                    DeptId = 102,
                    DeptName = "IT"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                     UserId = 1,
                     UserName="user1",
                     EMail="user@gmail.com",
                     RoleId=1,
                     DeptId=100,
                     ManagerId=null,
                     Password="admin",
                     ReTypePassword="admin"


                }

                );
        }
    }
}
