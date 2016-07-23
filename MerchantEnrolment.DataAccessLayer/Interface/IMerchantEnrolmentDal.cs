using MerchantEnrolment.DataAccessLayer.MerchantEnrolment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.DataAccessLayer.Interface
{
    public interface IMerchantEnrolmentDal
    {
        IEnumerable<MerchantEnrolmentRow> GetMerchantEnrolmentDetails(MerchantEnrolmentRow merchantEnrolmentRow);

        IEnumerable<MerchantEnrolmentRow> SaveMerchnatEnrolmentDetails(MerchantEnrolmentRow merchnatEnrolmentRow);

        IEnumerable<MerchantEnrolmentRow> DeleteMerchantEnrollmentDetails(int merchantId);

    }
}