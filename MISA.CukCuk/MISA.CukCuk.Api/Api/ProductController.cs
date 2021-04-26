using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    public class ProductController : EntityController<Product>
    {
        IBaseServices<Product> _baseServices;
        public ProductController(IBaseServices<Product> baseServices) : base(baseServices)
        {
            _baseServices = baseServices;
        }
    }
}
