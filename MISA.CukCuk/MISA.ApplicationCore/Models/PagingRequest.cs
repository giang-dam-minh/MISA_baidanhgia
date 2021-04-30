using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class PagingRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        //public string CustomParam { get; set; }
        //public string Colums { get; set; }
        public string SearchValue { get; set; }
    }
}
