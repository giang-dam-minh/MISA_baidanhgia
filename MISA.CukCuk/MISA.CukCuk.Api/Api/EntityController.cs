using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.Infrastructure;
using MISA.Infrastructure.Base;
using MISA.ApplicationCore.Services;
using MISA.ApplicationCore.Models;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/[controller]")]

    [ApiController]
    public class EntityController<MISAEntity> : ControllerBase
    {
        #region declare
        IBaseServices<MISAEntity> _baseServices;
        #endregion
        #region constructor
        public EntityController(IBaseServices<MISAEntity> baseServices)
        {
            _baseServices = baseServices;
        }
        #endregion
        /// <summary>
        /// API trả về tất cả thông tin 
        /// </summary>
        /// <returns>object</returns>
        /// createdBy: giangdm (20/01/2021)
        #region method
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseServices.GET());
        }
        /// <summary>
        /// API trả về thông tin theo id
        /// </summary>
        /// <param name="id">id cần tìm</param>
        /// <returns>object</returns>
        /// createdBy: giangdm (20/01/2021)
        [HttpGet("id")]
        public IActionResult GetById(string id)
        {
            return Ok(_baseServices.GetById(id));
        }
        [HttpPost("paging")]
        public IActionResult Paging([FromBody] PagingRequest pagingRequest)
        {
            return Ok(_baseServices.Paging(pagingRequest));
        }
        /// <summary>
        /// API thêm vào csdl
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Kết quả thực thi</returns>
        /// createdBy: giangdm (20/01/2021)
        [HttpPost]
        public virtual IActionResult Insert([FromBody] MISAEntity entity)
        {
            return Ok(_baseServices.Add(entity));
        }
        /// <summary>
        /// API sửa thông tin
        /// </summary>
        /// <param name="entity">Object cần sửa</param>
        /// <returns>Kết quả thực thi</returns>
        /// createdBy: giangdm (20/01/2021)
        [HttpPut]
        public virtual IActionResult Update(MISAEntity entity)
        {
            return Ok(_baseServices.Update(entity));
        }
        /// <summary>
        /// API xóa theo id
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>Kết quả thực thi</returns>
        /// createdBy: giangdm (20/01/2021)
        [HttpDelete]
        public virtual IActionResult Delete(int id)
        {
            return Ok(_baseServices.Delete(id));
        }
       
        
        #endregion
    }
}
