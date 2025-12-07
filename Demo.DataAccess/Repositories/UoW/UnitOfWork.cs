using DemoSession3.DataAccess.Data.Contexts;
using DemoSession3.DataAccess.Repositories.Departments;
using DemoSession3.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession3.DataAccess.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private Lazy<IDepartmentRepository> _departmentRepository;
        private Lazy<IEmployeeRepository> _employeeRepository;
        private readonly ApplicationDbContext _dbcontext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_dbcontext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_dbcontext));


        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;
        public int SaveChanges()
        {
            return _dbcontext.SaveChanges();
        }
    }
}