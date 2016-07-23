using MerchantEnrolment.DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.DataAccessLayer.MerchantEnrolment
{
    public class MerchantEnrolmentGet
    {
        public static ICollection<MerchantEnrolmentRow> Execute(MerchantEnrolmentRow merchantEnrolmentRow)
        {
            return MerchantEnrolmentRepository.Get(merchantEnrolmentRow.MerchantName,merchantEnrolmentRow.Country, merchantEnrolmentRow.CreatedBy) ;
        }
    }
}
