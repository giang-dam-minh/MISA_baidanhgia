using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IEmployeeService : IBaseServices<Employee>
    {
        /// <summary>
        /// Lấy ra mã nhân viên lớn nhất trong csdl
        /// </summary>
        /// <returns>string</returns>
        /// createdBy: giangdm (24/01/2021)
        string GetEmployeeCodeMax();
        // <summary>
        /// Interface Lấy ra danh sách nhân viên theo mã, tên, vị trí, phòng ban
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="fullName">Họ tên</param>
        /// <param name="PositionId">Vị trí(Chức vụ)</param>
        /// <param name="DepartmentId">Phòng bàn</param>
        /// <returns>Object</returns>
        /// createdBy: giangdm (24/01/2021)
        IEnumerable<Employee> GetEmployeeByAnySpec(string employeeCode, string fullName, string positionId, string departmentId);
    }
}
