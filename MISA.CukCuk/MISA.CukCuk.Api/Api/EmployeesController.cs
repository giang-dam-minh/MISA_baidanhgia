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
        public EmployeesController(IEmployeeService employeeService) :  base(employeeService)
        {
            _employeeService = employeeService;
        }
    }
    
}
