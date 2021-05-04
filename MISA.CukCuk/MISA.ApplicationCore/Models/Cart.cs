using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class Cart
    {
		public int CartID { get; set; }
		public string CustomerName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Note { get; set; }
        public double Total { get; set; }
    }
}
