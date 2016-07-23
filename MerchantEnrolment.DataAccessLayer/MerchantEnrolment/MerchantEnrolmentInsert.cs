using MerchantEnrolment.DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.DataAccessLayer.MerchantEnrolment
{
    public class MerchantEnrolmentInsert
    {
        public static Collection<MerchantEnrolmentRow> Execute(MerchantEnrolmentRow merchantEnrolmentRow)
        {
            return MerchantEnrolmentRepository.Save(merchantEnrolmentRow); 
        }
    }
}
