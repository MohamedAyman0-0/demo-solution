using DemoSession3.BuisnessLogic.DataTransferObjects;

namespace DemoSession3.BuisnessLogic.Services
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