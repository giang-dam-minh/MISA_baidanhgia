using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Interface lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        /// createdBy: giangdm (20/01/2021)
        IEnumerable<MISAEntity> Get();
        IEnumerable<MISAEntity> Paging(PagingRequest pagingRequest);
        /// <summary>
        /// Interface Lấy thông tin theo id
        /// </summary>
        /// <param name="id">id cần tìm</param>
        /// <returns></returns>
        /// createdBy: giangdm (20/01/2021)
        IEnumerable<MISAEntity> GetById(string id);
        /// <summary>
        /// Interface Thêm 1 bản ghi 
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Số bản ghi thêm được</returns>
        /// createdBy: giangdm (20/01/2021)
        int Add(MISAEntity entity);
        /// <summary>
        /// Interface Cập nhật thông tin 1 bản ghi
        /// </summary>
        /// <param name="entiy">Object cần sửa</param>
        /// <returns>Số bản ghi được sửa</returns>
        /// createdBy: giangdm (20/01/2021)
        int Update(MISAEntity entiy);
        /// <summary>
        /// Interface Xóa 1 bản ghi theo id
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>Số bản ghi xóa được</returns>
        /// createdBy: giangdm (20/01/2021)
        int DeleteById(int id);
        /// <summary>
        /// Interface Kiểm tra xem đã có bản ghi trong csdl chưa theo tiêu chí truyền vào
        /// </summary>
        /// <param name="entity">Tên bảng cần kiểm tra</param>
        /// <param name="property">Thông tin cần kiểm tra</param>
        /// <param name="actionType">Kiểu kiểm tra(Thêm mới hoặc cập nhât)</param>
        /// <returns>True nếu tồn tại, false ngược lại</returns>
        /// createdBy: giangdm (20/01/2021)
        bool CheckBySpec(MISAEntity entity,PropertyInfo property,string actionType);
    }
}
