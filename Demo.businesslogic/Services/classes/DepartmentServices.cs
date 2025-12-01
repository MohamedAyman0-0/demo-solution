using Demo.businesslogic.datatransferObject.Departments;
using Demo.businesslogic.Services.Interfaces;
using Demo.DataAccess.Repository.Department;
using DemoSession3.BuisnessLogic.DataTransferObjects;
using DemoSession3.BuisnessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.businesslogic.Services.classes
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            var departmentstoreturn = departments.Select(D => D.ToDeparrtmentDto());
            return departmentstoreturn;
        }

        public DeparmentDetailsDto? GetDepartmentById(int Id)
        {
            var department = _departmentRepository.GetById(Id);

            //if (department == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    return new DeparmentDetailsDto()
            //    {
            //        Id = department.Id,
            //        Name = department.Name,
            //        Code = department.Code,
            //        Description = department.Description,
            //        CreatedBy = department.CreatedBy,
            //        LastModifiedBy = department.LastModifiedBy,
            //        DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now),
            //        IsDeleted = department.IsDeleted

            //    };

            // Manual Mapping
            //Auto Mapper
            //Constructor Mapping
            // Extension Method 
            return department == null ? null : department.ToDeparmentDetailsDto();


        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Add(departmentDto.ToEntity());
        }
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());
        }
        public bool DeleteDepartment(int Id)
        {
            var department = _departmentRepository.GetById(Id);
            if (department == null)
            {
                return false;
            }
            else
            {
                var Result = _departmentRepository.Remove(department);
                return Result > 0 ? true : false;
            }


        }
    }
}
