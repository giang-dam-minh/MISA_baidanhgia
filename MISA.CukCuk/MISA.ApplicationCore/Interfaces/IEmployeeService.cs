using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IEmployeeService : IBaseServices<Employee>
    {
        IEnumerable<Employee> GetEmployeeByAnySpec(string employeeCode, string fullName, string positionId, string departmentId);
    }
}
