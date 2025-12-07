using DemoSession3.DataAccess.Data.Configurations;
using DemoSession3.DataAccess.Models.Departments;
using DemoSession3.DataAccess.Models.Employees;
using DemoSession3.DataAccess.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession3.DataAccess.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Connection string");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
            //   modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
