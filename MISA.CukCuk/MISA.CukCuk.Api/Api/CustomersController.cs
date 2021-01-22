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

        [HttpGet("code")]
        public IActionResult GetCustomerByCode(string code)
        {
            return Ok(_customerService.GetCustomerByCode(code));
        }
        
        //[HttpPost]
        //public override IActionResult Insert(Customer customer)
        //{
        //    var customerCheck = _dbConnection.Query<Customer>($"select CustomerCode from Customer where CustomerCode='{customer.CustomerCode}'");
        //    if (customerCheck.Count() > 0)
        //    {
        //        return BadRequest("Trùng mã khách hàng");
        //    }
        //    return base.Insert(customer);
        //}

        //[HttpPut]
        //public IActionResult updateCustomer([FromBody] Customer customer)
        //{
        //    string customerId = customer.CustomerId.ToString();
        //    string customerGroupId = customer.CustomerGroupId.ToString();
        //    var res = _dbConnection.Execute($"Proc_UpdateCustomer", param: common.GetParam(customer), commandType: CommandType.StoredProcedure);
        //    return Ok(res);
        //}
    }
}
