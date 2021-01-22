using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerService : IBaseServices<Customer>
    {
        IEnumerable<Customer> GetCustomerByCode(string code);
    }
}
