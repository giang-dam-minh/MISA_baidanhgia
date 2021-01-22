using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    public class CustomerGroup
    {
		[DisplayName("Id nhóm khách hàng")]
		[CheckDuplicate()]
		public Guid CustomerGroupId { get; set; }

		[DisplayName(("Tên nhóm khách hàng"))]
		[Required]
		public string CustomerGroupName { get; set; }
		public string Description { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
	}
}
