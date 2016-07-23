using MerchantEnrolment.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MerchantEnrolment.Common.Interface
{
    public interface IMerchantEnrolment
    {
        IEnumerable<MerchantEnrolmentDto> GetMerchantEnrolmentDetails(MerchantEnrolmentDto merchantEnrolmentDto);

        IEnumerable<MerchantEnrolmentDto> SaveMerchantEnrolmentDetails(MerchantEnrolmentDto merchantEnrolmentDto);

        IEnumerable<MerchantEnrolmentDto> DeleteMerchantEnrolment(int merchantId);
      
    }
}
