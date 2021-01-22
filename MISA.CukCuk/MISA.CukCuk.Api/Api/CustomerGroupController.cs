using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;

namespace MISA.CukCuk.Api.Api
{
    public class CustomerGroupController : EntityController<CustomerGroup>
    {
        public CustomerGroupController(IBaseServices<CustomerGroup> baseServices)
            :base(baseServices)
        {

        }
       
    }
}
