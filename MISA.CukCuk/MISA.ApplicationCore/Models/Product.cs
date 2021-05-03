using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class Product
    {
		public int ProductID { get; set; }
		[CheckDuplicate]
		[DisplayName("Mã sản phẩm")]
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
        public double Price { get; set; }
        public double Sale { get; set; }
		public string Image { get;set;}
		public string Description { get; set; }
		public int CategoryDetailID { get; set; }
	}
}
