using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class CartDetail
    {
        public int CartDetailID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quanlity { get; set; }
    }
}
