using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces.IRepository
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        public object GetIdMax();
    }
}
