using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces.IRepository;
using MISA.ApplicationCore.Models;
using MISA.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public object GetIdMax()
        {
            var sql = "SELECT c.CartID FROM carts  c ORDER BY c.CartID DESC LIMIT 1 OFFSET 0 ";
            var maxid = _dbConnection.Query<object>(sql);
            return maxid;
        }
    }
}
