using Demo.DataAccess.module.Department;

using DemoSession3.DataAccess.Repositories.Generics;

namespace DemoSession3.DataAccess.Repositories.Departments
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {

    }
}