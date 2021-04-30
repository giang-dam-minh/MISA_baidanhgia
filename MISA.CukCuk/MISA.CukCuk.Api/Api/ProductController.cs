using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Interfaces.IService;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    public class ProductController : EntityController<Product>
    {
        IProductService _productService;

        public ProductController(IProductService productService) : base(productService)
        {
            _productService = productService;
        }
        [HttpGet("/hot-product")]
        public IActionResult GetHotProduct()
        {
            return Ok(1);
        }
    }
}
