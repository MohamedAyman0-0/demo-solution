using Demo.dal.Data.configurations;
using Demo.dal.module;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Demo.dal.Data.Context
{
    public class ApplicationDbContext :DbContext
    {
        //public ApplicationDbContext() : base()
        //{
            
        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options   ): base(Options) 
        
        {
        }
       
        public DbSet<DepartmentDTO> Departments { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("ConnectionString");
        //    //base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
