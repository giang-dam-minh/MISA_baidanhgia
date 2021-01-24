using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Interface lấy thông tin khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="code">Mã khách hàng</param>
        /// <returns>Object</returns>
        /// createdBy: giangdm (20/01/2021)
        IEnumerable<Customer> GetCustomerByCode(string code);
    }
}
