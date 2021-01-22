using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        [CheckDuplicate()]
        [Required()]
        [DisplayName("Mã khách hàng")]
        public string CustomerCode { get; set; }

        [DisplayName("Họ và tên")]
        [Required()]
        [MaxLength(50)]
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? CustomerGroupId { 
            get; set; 
        }
        public double? DebitAmount { get; set; }
        public string MemberCardCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
