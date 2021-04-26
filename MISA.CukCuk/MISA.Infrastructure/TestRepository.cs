using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using MISA.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    public class TestRepository : BaseRepository<test>, ITestRepository
    {
        public TestRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
