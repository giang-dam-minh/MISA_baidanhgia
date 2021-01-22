using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
    public class ServiceResult
    {
        public bool success { get; set; }
        public object Data { get; set; }
        public object Message { get; set; }
    }
}
