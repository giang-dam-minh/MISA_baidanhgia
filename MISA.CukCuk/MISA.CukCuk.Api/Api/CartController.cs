using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces.IService;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    
    public class CartController : EntityController<Cart>
    {
        ICartService _cartService;

        public CartController(ICartService cartService) : base(cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("idmax")]
        public IActionResult getIdMax()
        {
            return Ok(_cartService .GetIdMax());
        }
    }
}
