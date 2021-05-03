using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class CategoryDetail
    {
        public int CategoryDetailID { get; set; }
        public string CategoryDetailCode { get; set; }
        public int CategoryID { get; set; }
        public string CategoryDetailName { get; set; }
    }
}
