
using DemoSession3.BuisnessLogic.DataTransferObjects.Employees;
using DemoSession3.BuisnessLogic.Services.Interfaces;
using DemoSession3.DataAccess.Models.Employees;
using DemoSession3.DataAccess.Repositories.Employees;
using DemoSession3.DataAccess.Repositories.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession3.BuisnessLogic.Services.Classes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAttachmentService _attachmentService;

        public EmployeeService(IUnitOfWork unitOfWork
            , IMapper mapper,
            IAttachmentService attachmentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _attachmentService = attachmentService;
        }
        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName, bool withTracking = false)
        {

            IEnumerable<Employee> employees;

            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                employees = _unitOfWork.EmployeeRepository.GetAll(withTracking);
            }
            else
            {
                employees = _unitOfWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            }

            //TSource=> Src =>Employee
            //TDistination => Dist => EmployeeDto
            var employeesToReturn = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            return employeesToReturn;


            ///var employeeToReturn = employees.Select(E => new EmployeeDto()
            ///{
            ///    Id = E.Id,
            ///    Name = E.Name,
            ///    Age = E.Age,
            ///    Salary = E.Salary,
            ///    IsActive = E.IsActive, 
            ///    Email = E.Email,
            ///    Gender = E.Gender.ToString(),
            ///    EmployeeType = E.EmployeeType.ToString()
            ///});
        }

        public EmployeeDetailsDto? GetEmployeeById(int Id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(Id);

            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);
            /// return employee is null? null : new EmployeeDetailsDto()
            ///{
            ///Id = employee.Id,
            /// Name = employee.Name,
            ///Age = employee.Age,
            ///Salary = employee.Salary,
            ///IsActive = employee.IsActive,
            ///Email = employee.Email,
            ///PhoneNumber = employee.PhoneNumber,
            ///HiringDate = DateOnly.FromDateTime(employee.HiringDate),
            ///Gender = employee.Gender.ToString(),
            ///EmployeeType = employee.EmployeeType.ToString(),
            ///CreatedBy = employee.CreatedBy,
            ///CreatedOn = employee.CreatedOn,
            ///LastModifiedBy = employee.LastModifiedBy,
            ///LastModifiedOn = employee.LastModifiedOn
            ///};
        }

        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);
            if (employeeDto.Image != null)
            {
                employee.ImageName = _attachmentService.Upload(employeeDto.Image, "Images");
            }
            _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.SaveChanges();
        }
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(employeeDto.Id);
            if (employee == null) return 0;

            _mapper.Map(employeeDto, employee);

            employee.LastModifiedOn = DateTime.Now;

            _unitOfWork.EmployeeRepository.Update(employee);
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteEmployee(int Id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(Id);
            if (employee is null)
            {
                return false;
            }
            employee.IsDeleted = true;
            _unitOfWork.EmployeeRepository.Update(employee);
            var result = _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else return false;
            ///Hard Delete
            ///var result =_employeeRepository.Remove(employee);
            ///if (result > 0)
            ///{
            ///   return true;
            ///}
            /// else return false;
        }




    }
}