using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseServices<MISAEntity>
    {
        /// <summary>
        /// Interface lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        /// createdBy: giangdm (20/01/2021)
        IEnumerable<MISAEntity> GET();
        /// <summary>
        /// Interface Lấy thông tin theo id
        /// </summary>
        /// <param name="id">id cần tìm</param>
        /// <returns></returns>
        /// createdBy: giangdm (20/01/2021)
        IEnumerable<MISAEntity> GetById(string id);
        IEnumerable<MISAEntity> Paging(PagingRequest pagingRequest);
        /// <summary>
        /// Interface Thêm 1 bản ghi 
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Số bản ghi thêm được</returns>
        /// createdBy: giangdm (20/01/2021)
        ServiceResult Add(MISAEntity entity);

        /// <summary>
        /// Interface Cập nhật thông tin 1 bản ghi
        /// </summary>
        /// <param name="entiy">Object cần sửa</param>
        /// <returns>Số bản ghi được sửa</returns>
        /// createdBy: giangdm (20/01/2021)
        ServiceResult Update(MISAEntity entity);
        /// <summary>
        /// Interface Xóa 1 bản ghi theo id
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>Số bản ghi xóa được</returns>
        /// createdBy: giangdm (20/01/2021)
        ServiceResult Delete(Guid id);
    }
}
