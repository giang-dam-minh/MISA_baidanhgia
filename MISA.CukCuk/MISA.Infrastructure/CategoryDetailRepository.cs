using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces.IRepository;
using MISA.ApplicationCore.Models;
using MISA.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    public class CategoryDetailRepository : BaseRepository<CategoryDetail>, ICategoryDetailRepository
    {
        public CategoryDetailRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
