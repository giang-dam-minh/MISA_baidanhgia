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
        public Double price { get; set; }
        public int sale { get; set; }
        public string image_content_type { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public int hot { get; set; }
		public int category_id { get; set; }
}
}
