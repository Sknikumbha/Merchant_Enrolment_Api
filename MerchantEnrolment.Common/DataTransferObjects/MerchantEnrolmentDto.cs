using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.Common.DataTransferObjects
{
    public class MerchantEnrolmentDto
    {
        public int? MerchantId { get; set; }
        public string MerchantName { get; set; }
        public string Country { get; set; }
        public decimal MerchantProfit { get; set; }
        public int? NumberOfOutlets { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
