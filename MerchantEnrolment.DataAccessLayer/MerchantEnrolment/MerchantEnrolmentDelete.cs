using MerchantEnrolment.DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.DataAccessLayer.MerchantEnrolment
{
    class MerchantEnrolmentDelete
    {
        public static Collection<MerchantEnrolmentRow> Execute(int merchantId)
        {
            return MerchantEnrolmentRepository.Remove(merchantId);
        }
    }
}
