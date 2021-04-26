using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Interfaces.IRepository;
using MISA.ApplicationCore.Interfaces.IService;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
