using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : EntityController<Position>
    {
        IBaseServices<Position> _baseServices;
        public PositionController(IBaseServices<Position> baseServices) : base(baseServices)
        {
            _baseServices = baseServices;
        }
    }
}
