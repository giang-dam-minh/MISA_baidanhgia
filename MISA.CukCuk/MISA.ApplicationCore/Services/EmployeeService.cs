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
        /// <summary>
        /// Lấy ra thông tin nhân viên theo mã, tên, vị trí, phòng ban
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="fullName">Họ tên</param>
        /// <param name="positionId">Vị trí</param>
        /// <param name="departmentId">Phòng ban</param>
        /// <returns>Object</returns>
        /// createdBy: giangdm (20/01/2021)
        public IEnumerable<Employee> GetEmployeeByAnySpec(string employeeCode, string fullName, string positionId, string departmentId)
        {
           return _employeeRepository.GetEmployeeByAnySpec(employeeCode, fullName, positionId, departmentId);
        }
        /// <summary>
        /// Lấy ra mã nhân viên lớn nhất +1
        /// </summary>
        /// <returns>string</returns>
        /// createdBy: giangdm (24/01/2021)
        public string GetEmployeeCodeMax()
        {
            var employeeCodeMax = _employeeRepository.GetEmployeeCodeMax();
            var codeLength = employeeCodeMax.Length - 2;
            var sub =int.Parse( employeeCodeMax.Substring(2, codeLength)) +1;
            var newCode = employeeCodeMax.Substring(0, 4) + sub;
            return newCode;
        }
    }
}
