using MISA.ApplicationCore.Interfaces.IRepository;
using MISA.ApplicationCore.Interfaces.IService;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class CartDetailService : BaseService<CartDetail>, ICartDetailService
    {
        ICartDetailRepository _cartDetailRepository;
        public CartDetailService(ICartDetailRepository cartDetailRepository) : base(cartDetailRepository)
        {
            _cartDetailRepository = cartDetailRepository;
        }
    }
}
