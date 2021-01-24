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
        /// <summary>
        /// API lấy ra danh sách nhân viên theo tiêu chí(mã, tên), vị trí, phòng ban (dùng cho filter)
        /// </summary>
        /// <param name="spec">tiêu chí bất kỳ</param>
        /// <param name="positionId">vị trí</param>
        /// <param name="departmentId">phòng ban</param>
        /// <returns>object</returns>
        /// createdBy: giangdm (24/01/2021)
        [HttpGet("spec/position/department")]
        public IActionResult GetEmployeeByAnySpec(string spec = null, string positionId = null, string departmentId = null)
        {
            return Ok(_employeeService.GetEmployeeByAnySpec(spec, spec, positionId, departmentId));
        }
        /// <summary>
        /// API trả về mã nhân viên lớn nhất +1 trong csdl
        /// </summary>
        /// <returns>string</returns>
        /// createdBy: giangdm (24/01/2021)
        [HttpGet("employeecodemax")]
        public IActionResult GetEmployeeCodeMax()
        {
            return Ok(_employeeService.GetEmployeeCodeMax());
        }
    }

}
