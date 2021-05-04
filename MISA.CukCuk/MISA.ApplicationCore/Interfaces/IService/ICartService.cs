using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces.IService
{
    public interface ICartService : IBaseServices<Cart>
    {
        public object GetIdMax();
    }
}
