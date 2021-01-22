using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Models
{
	public class Employee
    {
		public Guid EmployeeId { get; set; }
		public string EmployeeCode { get; set; }
		public string FullName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public int Gender { get; set; }
		public string IdentificationNumber { get; set; }
		public DateTime? IdentifictionDate { get; set; }
		public string IdentifictionLocation { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public Guid? PositionId { get; set; }
		public Guid? DepartmentId { get; set; }
		public string PersonalTaxCode { get; set; }
        public double? BaseSalary { get; set; }
        public DateTime? JoiningDate { get; set; }
		public int Workstatus { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
	}
}
