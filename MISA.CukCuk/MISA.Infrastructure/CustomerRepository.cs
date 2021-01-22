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
        public IEnumerable<Customer> GetCustomerByCode(string code)
        {
            return _dbConnection.Query<Customer>($"select * from Customer where CustomerCode = '{code}'");
        }
    }
}
