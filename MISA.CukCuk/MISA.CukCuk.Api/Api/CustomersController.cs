using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;

namespace MISA.CukCuk.Api.Api
{
    public class CustomersController : EntityController<Customer>
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// API trả về danh sách khách hàng theo mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Json</returns>
        /// createdBy: giangdm (20/01/2021)
        [HttpGet("code")]
        public IActionResult GetCustomerByCode(string code)
        {
            return Ok(_customerService.GetCustomerByCode(code));
        }
        
    }
}
