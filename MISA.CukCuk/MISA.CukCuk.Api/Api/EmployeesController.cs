using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.ApplicationCore.Interfaces;
namespace MISA.CukCuk.Api.Api
{

    public class EmployeesController : EntityController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("code/fullname/position/department")]
        public IActionResult GetEmployeeByAnySpec(string employeeCode=null, string fullName=null, string positionId=null, string departmentId=null)
        {
            return Ok(_employeeService.GetEmployeeByAnySpec(employeeCode, fullName, positionId, departmentId));
        }
    }

}
