using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [CheckDuplicate]
        [DisplayName("Mã danh mục")]
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string SubCategory { get; set; }
    }
}
