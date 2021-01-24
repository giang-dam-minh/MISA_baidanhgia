using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using MISA.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Linq;
namespace MISA.Infrastructure
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        /// <summary>
        /// Lấy ra danh sách nhân viên theo mã, tên, vị trí, phòng bàn (dùng cho filter)
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <param name="fullName">họ tên</param>
        /// <param name="positionId">vị trí</param>
        /// <param name="departmentId">phòng ban</param>
        /// <returns>object</returns>
        /// createdBy: giangdm (24/01/2021)
        public IEnumerable<Employee> GetEmployeeByAnySpec(string employeeCode, string fullName, string positionId, string departmentId)
        {
            var param = new
            {
                EmployeeCode = employeeCode,
                FullName = fullName,
                PositionId = positionId,
                DepartmentId = departmentId
            };
            return _dbConnection.Query<Employee>("Proc_GetEmployeeByAnySpec", param: param, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Lấy ra mã nhân viên lớn nhất trong csdl
        /// </summary>
        /// <returns>string</returns>
        /// createdBy: giangdm (24/01/2021)
        public string GetEmployeeCodeMax()
        {
            var maxEmployeeCode = _dbConnection.Query<string>("Proc_GetEmployeeCodeMax", commandType: CommandType.StoredProcedure).FirstOrDefault();
            return maxEmployeeCode.ToString();
        }
    }
}
