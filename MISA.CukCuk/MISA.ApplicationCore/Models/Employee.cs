using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
	public class Employee
    {
		public Guid EmployeeId { get; set; }
		
		[Required]
		[CheckDuplicate]
		[DisplayName("Mã nhân viên")]
		public string EmployeeCode { get; set; }

		[Required]
		public string FullName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public int Gender { get; set; }

		[Required]
		[CheckDuplicate]
		[DisplayName("Chứng minh thư")]
		public string IdentificationNumber { get; set; }

		public DateTime? IdentifictionDate { get; set; }

		public string IdentifictionLocation { get; set; }

		[Required]
		[CheckDuplicate]
		[DisplayName("Email")]
		public string Email { get; set; }

		[Required]
		[CheckDuplicate]
		[DisplayName("Số điện thoại")]
		public string PhoneNumber { get; set; }

		public Guid? PositionId { get; set; }
        public string PositionName { get; set; }
        public Guid? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string PersonalTaxCode { get; set; }
        public double? BaseSalary { get; set; }
        public DateTime? JoiningDate { get; set; }
		public int WorkStatus { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
	}
}
