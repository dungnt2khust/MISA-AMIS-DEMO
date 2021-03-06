using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Amis.Core.Interfaces.Repositoties
{
    public interface IBaseRepository<MISAEntity>
    {
        #region Lấy dữ liệu 
        /// <summary>
        /// Lấy tất cả
        /// </summary>
        /// <returns>Danh sách thông tin entity</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        List<MISAEntity> Get();

        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns> Thông tin entity</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        MISAEntity GetById(Guid entityId);

        #endregion

        #region Tạo mới dữ liệu
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Số dòng bị ảnh hưởng khi thực hiện thêm</returns>       
        /// CreatedBy: NTDUNG (27/08/2021)
        int Add(MISAEntity entity);

        #endregion

        #region Cập nhật dữ liệu
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="entity">Data</param>
        /// <param name="entityId">Id</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        int Update(MISAEntity entity, Guid entityId);
        #endregion

        #region Xoá một bản ghi 
        /// <summary>
        /// Xóa một
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns> Số dòng bị ảnh hưởng khi thực hiện xoá 1 </returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        int DeleteOne(Guid entityId);

        #endregion

        #region Xoá nhiều bản ghi
        /// <summary>
        /// Xóa nhiều
        /// </summary>
        /// <param name="entityIds"></param>
        /// <returns> Số dòng bị ảnh hưởng khi thực hiện xoá nhiều</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        int DeleteMany(List<Guid> entityIds);

        #endregion

        #region Kiểm tra trùng thông tin
        /// <summary>
        /// Kiểm tra trùng thông tin
        /// </summary>
        /// <param name="entity"> Dứ liệu của entity</param>
        /// <param name="fieldName"> Tên trường dữ liệu muốn kiểm tra</param>
        /// <param name="mode"> Kiểu kiểm tra (ADD or UPDATE)</param>
        /// <returns> Trả về boolean: true - không trùng, false - trùng</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        /// ModifiedBy: NTDUNG (27/08/2021)
        bool CheckDuplicate(MISAEntity entity, string fieldName, string mode);

        #endregion
    }
}
