using MISA.ApplicationCore.Interfaces.IRepository;
using MISA.ApplicationCore.Interfaces.IService;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class CategoryDetailService : BaseService<CategoryDetail>, ICategoryDetailService
    {
        ICategoryDetailRepository _categoryDetailRepository;
        public CategoryDetailService(ICategoryDetailRepository categoryDetailRepository) : base(categoryDetailRepository)
        {
            _categoryDetailRepository = categoryDetailRepository;
        }
    }
}
