using Demo.businesslogic.datatransferObject.Departments;
using Demo.businesslogic.Services.Interfaces;
using DemoSession3.BuisnessLogic.DataTransferObjects;

using DemoSession3.BuisnessLogic.Factories;
using DemoSession3.BuisnessLogic.Services.Interfaces;
using DemoSession3.DataAccess.Repositories.Departments;
using DemoSession3.DataAccess.Repositories.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoSession3.BuisnessLogic.Services.Classes
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentstoreturn = departments.Select(D => D.ToDeparrtmentDto());
            return departmentstoreturn;
        }

        public DeparmentDetailsDto? GetDepartmentById(int Id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(Id);


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
            _unitOfWork.DepartmentRepository.Add(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteDepartment(int Id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(Id);
            if (department == null)
            {
                return false;
            }
            else
            {
                _unitOfWork.DepartmentRepository.Remove(department);
                var Result = _unitOfWork.SaveChanges();
                return Result > 0 ? true : false;
            }


        }
    }
}