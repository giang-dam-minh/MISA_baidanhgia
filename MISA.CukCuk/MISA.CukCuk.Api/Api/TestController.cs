using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    public class TestController : EntityController<test>
    {
        IBaseServices<test> _baseServices;
        public TestController(IBaseServices<test> baseServices) : base(baseServices)
        {
            _baseServices = baseServices;
        }
    }
}
