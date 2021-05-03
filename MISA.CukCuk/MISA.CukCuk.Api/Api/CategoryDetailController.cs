using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces.IService;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    
    public class CategoryDetailController : EntityController<CategoryDetail>
    {
        ICategoryDetailService _categoryDetailService;

        public CategoryDetailController(ICategoryDetailService categoryDetailService) : base(categoryDetailService)
        {
            _categoryDetailService = categoryDetailService;
        }
    }
}
