using MISA.Amis.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Amis.Core.Entities
{
    public class Employee : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [MISARequired] 
        [MISAUnique]
        [MISADisplayName("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên đệm
        /// </summary>
        [MISANotMap]
        public string FirstName { get; set; }


        /// <summary>
        /// Tên
        /// </summary>
        [MISANotMap] 
        public string LastName { get; set; }

        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        public string FullName { get; set; }


        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string LandlineNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số cmnd/căn cước
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string BankBranch { get; set; }

        /// <summary>
        /// Id Phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// id vị trí
        /// </summary>
        public Guid? PossitionId { get; set; }
        #endregion
    }
}
