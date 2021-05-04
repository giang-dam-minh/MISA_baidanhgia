using MISA.ApplicationCore.Interfaces.IRepository;
using MISA.ApplicationCore.Interfaces.IService;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class CartService : BaseService<Cart>, ICartService
    {
        ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository) : base(cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public object GetIdMax()
        {
            return _cartRepository.GetIdMax();
        }
    }
}
