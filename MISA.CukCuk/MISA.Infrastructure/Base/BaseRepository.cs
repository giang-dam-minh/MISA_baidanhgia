using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using MISA.ApplicationCore.NewFolder;
using System.Linq;
using System.Reflection;
using MISA.ApplicationCore.Models;

namespace MISA.Infrastructure.Base
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>, IDisposable
    {
        protected IConfiguration _configuration;
        protected IDbConnection _dbConnection;
        Common common;
        string _tableName = typeof(MISAEntity).Name;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new MySqlConnection(_configuration.GetConnectionString("MISAConnectionString"));
            common = new Common();
        }
        /// <summary>
        /// Thêm object vào csdl tương ứng
        /// </summary>
        /// <param name="entity">object cần thêm</param>
        /// <returns>số bản ghi thêm được</returns>
        /// createdBy: giangdm (20/01/2021)
        public virtual int Add(MISAEntity entity)
        {
            var rowEffect = 0;
            _dbConnection.Open();
            using(var transection = _dbConnection.BeginTransaction())
            {
                var param = common.GetParam(entity);
                rowEffect = _dbConnection.Execute($"Proc_Insert{_tableName}", param: param, commandType: CommandType.StoredProcedure);
                transection.Commit();
            }
           return rowEffect;
        }
        /// <summary>
        /// Kiểm tra có hay ko theo tiêu chí truyển vào
        /// </summary>
        /// <param name="entity">bảng cần kiểm tra</param>
        /// <param name="property">thông tin cần kiểm tra</param>
        /// <param name="actionType">kiểu kiểm tra</param>
        /// <returns>true nếu chưa có, false ngược lại</returns>
        /// createdBy: giangdm (20/01/2021)
        public bool CheckBySpec(MISAEntity entity,PropertyInfo property,string actionType="add")
        {
            var sql = "";
            var spec = property.Name;
            var value = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}ID").GetValue(entity);
            if (actionType == "add")
                sql = $"select * from {_tableName}s where {spec} = '{value}'";
            else if(actionType=="update")
                sql = $"select * from {_tableName}s where {spec} = '{value}' and {_tableName}Id <> '{keyValue}'";
            var entityCheck = _dbConnection.Query<MISAEntity>(sql).FirstOrDefault();
            return entityCheck == null ? true : false;
        }
        /// <summary>
        /// Xóa theo id
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>số bản ghi xóa được</returns>
        /// createdBy: giangdm (20/01/2021)
        public int DeleteById(int id)
        {
            return _dbConnection.Execute($"delete from {_tableName}s where {_tableName}Id = '{id.ToString()}'");
        }
        /// <summary>
        /// đóng kết nối khi ko sử dụng
        /// </summary>
        /// createdBy: giangdm (21/01/2021)
        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
        /// <summary>
        /// lấy ra tất cả thông tin
        /// </summary>
        /// <returns>object</returns>
        /// createdBy: giangdm (20/01/2021)
        public IEnumerable<MISAEntity> Get()
        {
            return _dbConnection.Query<MISAEntity>($"select * from {_tableName}s",commandType:CommandType.Text);
        }
        /// <summary>
        /// Lấy thông tin theo id
        /// </summary>
        /// <param name="id">id cần lấy</param>
        /// <returns>object</returns>
        /// createdBy: giangdm (20/01/2021)
        public IEnumerable<MISAEntity> GetById(string id)
        {
            return _dbConnection.Query<MISAEntity>($"select * from {_tableName}s where {_tableName}Id= '{id}'");
        }

        public IEnumerable<MISAEntity> GetByListID(string lstID)
        {
            var sql = $"select * from {_tableName}s where {_tableName}ID in ({lstID})";
            return _dbConnection.Query<MISAEntity>(sql);
        }

        public IEnumerable<MISAEntity> Paging(PagingRequest pagingRequest)
        {
            var param = new DynamicParameters();
            int index = pagingRequest.PageIndex;
            int pageSize = pagingRequest.PageSize;
            int indexSearch = pageSize * (index - 1);
            param.Add("@pageIndex", indexSearch);
            param.Add("@pageSize", pageSize);
            param.Add("@searchValue", pagingRequest.SearchValue);
            return _dbConnection.Query<MISAEntity>($"Proc_Paging{_tableName}", param: param, commandType:CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="entiy">object cần cập nhật</param>
        /// <returns>số bản ghi được cập nhật</returns>
        /// createdBy: giangdm (20/01/2021)
        public int Update(MISAEntity entiy)
        {
            return _dbConnection.Execute($"Proc_Update{_tableName}", param: common.GetParam(entiy),commandType:CommandType.StoredProcedure);
        }
    }
}
