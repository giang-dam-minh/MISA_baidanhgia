using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class User
    {
		public long id { get; set; }
		public string login { get; set; }
		public string password_hash { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public string phone_number { get; set; }
		public string address { get; set; }
		public string image_url { get; set; }
		public bool activated { get; set; }
		public string lang_key { get; set; }
		public string activation_key { get; set; }
		public string reset_key { get; set; }
		public string created_by { get; set; }
		public byte[] created_date { get; set; }
		public byte[] reset_date { get; set; }
		public string last_modified_by { get; set; }
		public byte[] last_modified_date { get; set; }
	}
}
