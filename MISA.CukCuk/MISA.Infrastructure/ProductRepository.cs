﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Interfaces.IRepository;
using MISA.ApplicationCore.Models;
using MISA.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<Product> getHotProduct()
        {
            return _dbConnection.Query<Product>("Proc_GetHotProduct",commandType: CommandType.StoredProcedure);
        }
    }
}
