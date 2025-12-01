using Demo.businesslogic.datatransferObject.Departments;
using DemoSession3.BuisnessLogic.DataTransferObjects;

namespace Demo.businesslogic.Services.Interfaces
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int Id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DeparmentDetailsDto? GetDepartmentById(int Id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}