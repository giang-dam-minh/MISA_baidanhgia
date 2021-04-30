using Dapper;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.NewFolder
{
    public class Common
    {
        /// <summary>
        /// Mapping data đầu vào cho thủ tục sql
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>object đã map dữ liệu</returns>
        /// createdBy: giangdm (20/02/2021)
        public DynamicParameters GetParam(object entity)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = propertyValue.ToString();
                }
                if (property.PropertyType == typeof(string) && propertyValue != null)
                    if (propertyValue.ToString() == "")
                        propertyValue = null;
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            return dynamicParameters;
        }

        public string getParamPaging(object entity,PagingRequest pagingRequest)
        {
           
            return "";
        }
    }
}
