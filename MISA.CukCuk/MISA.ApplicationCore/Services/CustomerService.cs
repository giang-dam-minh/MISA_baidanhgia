using System;
using System.Collections.Generic;
using System.Text;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;

namespace MISA.ApplicationCore.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) :base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Lây ra thông tin khách hàng theo mã
        /// </summary>
        /// <param name="code">Mã khách hàng</param>
        /// <returns>Object</returns>
        /// createdBy: giangdm (20/01/2021)
        public IEnumerable<Customer> GetCustomerByCode(string code)
        {
           return _customerRepository.GetCustomerByCode(code);
        }
      
    }
}
