using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using MISA.ApplicationCore.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<MISAEntity> : IBaseServices<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        Common common;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            common = new Common();
        }
        /// <summary>
        /// Service thêm 1 bản ghi vào csdl
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Kết quả thực thi</returns>
        /// createdBy: giangdm (20/01/2021)
        public virtual ServiceResult Add(MISAEntity entity)
        {
            var res = Validate(entity,"add");
            if (!res.success)
            {
                return res;
            }
            res.Data = _baseRepository.Add(entity);
            return res;
        }
        /// <summary>
        /// Xóa 1 bản ghi theo id
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>Kết quả thực thi</returns>
        /// createdBy: giangdm (20/01/2021)
        public ServiceResult Delete(int id)
        {
            var res = new ServiceResult();
            res.success = true;
            res.Data = _baseRepository.DeleteById(id);
            res.Message = "Xóa thành công";
            return res;
        }
        /// <summary>
        /// Lấy tất cả thông tin từ repository
        /// </summary>
        /// <returns>Object</returns>
        /// createdBy: giangdm (20/01/2021)
        public IEnumerable<MISAEntity> GET()
        {
            return _baseRepository.Get();
        }
        /// <summary>
        /// Lấy thông tin theo id
        /// </summary>
        /// <param name="id">id cần lấy</param>
        /// <returns>Object</returns>
        /// createdBy: giangdm (20/01/2021)
        public IEnumerable<MISAEntity> GetById(string id)
        {
            return _baseRepository.GetById(id);
        }

        public IEnumerable<MISAEntity> GetByListID(String lstID)
        {
           
            return _baseRepository.GetByListID(lstID);
        }

        public IEnumerable<MISAEntity> GETByPropertyValue(string property, string value)
        {
            return _baseRepository.GetByPropertyValue(property, value);
        }

        public IEnumerable<MISAEntity> Paging(PagingRequest pagingRequest)
        {
            return _baseRepository.Paging(pagingRequest);
        }



        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="entity">Object cần cập nhật</param>
        /// <returns>Kết quả thực thi</returns>
        /// createdBy: giangdm (20/01/2021)
        public ServiceResult Update(MISAEntity entity)
        {
            var res = Validate(entity, "update");
            if (!res.success)
            {
                return res;
            }
            res.Data = _baseRepository.Update(entity);
            return res;
        }
        /// <summary>
        /// Kiếm tra dữ liệu hợp lệ
        /// </summary>
        /// <param name="entity">Object cần kiểm tra</param>
        /// <param name="actionType">Kiểu thực thi(Thêm, sửa)</param>
        /// <returns>Kết quả thực thi</returns>
        /// createdBy: giangdm (20/01/2021)
        private ServiceResult Validate(MISAEntity entity,string actionType)
        {
            var res = new ServiceResult();
            res.success = true;
            var listMessage = new List<string>();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var propertyName = property.Name;
                var displayName = "";
                if (property.IsDefined(typeof(DisplayName), false))
                {
                    var displayAttribute = property.GetCustomAttributes(typeof(DisplayName), true)[0];
                    displayName = (displayAttribute as DisplayName).PropertyName;
                }
                if (property.IsDefined(typeof(Required), false))
                {
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        res.success = false;
                        listMessage.Add($"{displayName} không được phép để trống");
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    if (!_baseRepository.CheckBySpec(entity,property,actionType))
                    {
                        res.success = false;
                        listMessage.Add($"Trùng {displayName} ");
                    }
                }
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    var maxLengthAttribute= property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var length = (maxLengthAttribute as MaxLength).Length;
                    if (propertyValue.ToString().Length > length)
                    {
                        res.success = false;
                        listMessage.Add($"{displayName} không được dài quá {length} ký tự");
                    }
                }
            }
            res.Message = listMessage;
            return res;
        }
    }
}
