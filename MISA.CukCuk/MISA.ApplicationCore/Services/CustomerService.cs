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
        public IEnumerable<Customer> GetCustomerByCode(string code)
        {
           return _customerRepository.GetCustomerByCode(code);
        }
      
    }
}
