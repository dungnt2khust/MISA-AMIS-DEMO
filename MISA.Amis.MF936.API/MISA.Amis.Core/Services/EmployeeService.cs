using MISA.Amis.Core.Entities;
using MISA.Amis.Core.Interfaces.Repositoties;
using MISA.Amis.Core.Interfaces.Services;
using MISA.Amis.Core.Responses; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Amis.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Fields

        IEmployeeRepository _employeeRepository;
        ServiceResult _serviceResult;

        #endregion

        #region Constructors

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Lấy mã nhân viên mới 

        /// <summary>
        /// Lấy mã nv mới
        /// </summary>
        /// <returns>Kết quả nghiệp vụ lấy mã mới</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        public ServiceResult GetNewCode()
        {
            _serviceResult.Data = _employeeRepository.GetNewCode();
            _serviceResult.IsValid = _serviceResult.Data != null;
            return _serviceResult;
        }

        #endregion

        #region Phân trang và lọc dữ liệu nhân viên
        /// <summary>
        /// Tìm kiếm và phân trang
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="filterString"></param>
        /// <returns> Kết quả nghiệp vụ phân trang và lọc dữ liệu</returns>
        /// CreatedBy: NTDUNG (27/08/2021)
        /// ModifiedBy: NTDUNG (01/09/2021)
        public ServiceResult GetByFilter(int pageSize, int pageNumber, string filterString)
        {
            _serviceResult.Data = _employeeRepository.GetByFilter(pageSize, pageNumber, filterString);
            _serviceResult.IsValid = _serviceResult.Data != null;
            return _serviceResult;
        }

        #endregion
    }
}
