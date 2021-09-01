using MISA.Amis.Core.Entities;
using MISA.Amis.Core.Resources;
using MISA.Amis.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Amis.Core.Interfaces.Repositoties
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        #region Phân trang và lọc dữ liệu nhân viên
        /// <summary>
        /// Phân trang nhân viên và lọc dữ liệu
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="filterString"></param>
        /// <returns> Trả về kết quả của filter</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        /// ModifiedBy: NTUDNG (01/09/2021)
        FilterResponse GetByFilter(int pageSize, int pageNumber, string filterString);

        #endregion

        #region Lấy mã nhân viên mới
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns> Trả về chuỗi là mã nhân viên mới</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        string GetNewCode();

        #endregion
    }
}
