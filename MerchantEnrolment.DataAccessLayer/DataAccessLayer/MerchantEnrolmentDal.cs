using MerchantEnrolment.DataAccessLayer.Interface;
using MerchantEnrolment.DataAccessLayer.MerchantEnrolment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.DataAccessLayer.DataAccessLayer
{
    public class MerchantEnrolmentDal : IMerchantEnrolmentDal
    {
        public IEnumerable<MerchantEnrolment.MerchantEnrolmentRow> GetMerchantEnrolmentDetails(MerchantEnrolmentRow merchantEnrolmentRow)
        {
            return MerchantEnrolmentGet.Execute(merchantEnrolmentRow);
        }

        public IEnumerable<MerchantEnrolment.MerchantEnrolmentRow> SaveMerchnatEnrolmentDetails(MerchantEnrolmentRow merchantEnrolmentRow)
        {
            return MerchantEnrolmentInsert.Execute(merchantEnrolmentRow);
        }

        public IEnumerable<MerchantEnrolment.MerchantEnrolmentRow> DeleteMerchantEnrollmentDetails(int merchantId)
        {
            return MerchantEnrolmentDelete.Execute(merchantId);
        }
    }
}
