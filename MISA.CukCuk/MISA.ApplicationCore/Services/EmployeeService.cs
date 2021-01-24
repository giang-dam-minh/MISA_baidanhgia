using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class EmployeeService : BaseService<Employee>,IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployeeByAnySpec(string employeeCode, string fullName, string positionId, string departmentId)
        {
           return _employeeRepository.GetEmployeeByAnySpec(employeeCode, fullName, positionId, departmentId);
        }
    }
}
