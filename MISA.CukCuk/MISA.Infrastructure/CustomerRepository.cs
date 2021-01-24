using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using MISA.Infrastructure.Base;
using Dapper;
namespace MISA.Infrastructure
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration): base(configuration)
        {
                
        }
        /// <summary>
        /// Lấy ra thông tin khách hàng theo mã
        /// </summary>
        /// <param name="code">Mã khách hàng</param>
        /// <returns>object</returns>
        /// createdBy: giangdm (20/01/2021)
        public IEnumerable<Customer> GetCustomerByCode(string code)
        {
            return _dbConnection.Query<Customer>($"select * from Customer where CustomerCode = '{code}'");
        }
    }
}
