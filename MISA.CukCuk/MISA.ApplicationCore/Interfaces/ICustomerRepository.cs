using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IEnumerable<Customer> GetCustomerByCode(string code);
    }
}
