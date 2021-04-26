using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class Product
    {
		public long id { get; set; }
		public string name { get; set; }
		public byte[] image { get; set;}

		public string image_content_type { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public bool hot { get; set; }
		public long category_id { get; set; }
}
}
