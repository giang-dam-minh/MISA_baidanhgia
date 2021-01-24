using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using MISA.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
namespace MISA.Infrastructure
{
    public class EmployeeRepository : BaseRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }

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
    }
}
