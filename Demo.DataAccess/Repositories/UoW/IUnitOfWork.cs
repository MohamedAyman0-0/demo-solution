using DemoSession3.DataAccess.Repositories.Departments;
using DemoSession3.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession3.DataAccess.Repositories.UoW
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public int SaveChanges();
    }
}