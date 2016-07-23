using MerchantEnrolment.DataAccessLayer.MerchantEnrolment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.DataAccessLayer.Common
{
    public static class MerchantEnrolmentRepository
    {
        static Collection<MerchantEnrolmentRow> enrolments;
        private static int _nextId = 7;

        static MerchantEnrolmentRepository()
        {
            enrolments = new Collection<MerchantEnrolmentRow>();
            enrolments.Add(new MerchantEnrolmentRow { MerchantId = 1, MerchantName = "Bank-E", Country = "England", MerchantProfit = Convert.ToDecimal("10,000"), NumberOfOutlets = 15, CreatedBy = "Joe bloggs", CreatedOn = Convert.ToDateTime("01/01/2016") });
            enrolments.Add(new MerchantEnrolmentRow { MerchantId = 2, MerchantName = "Member-A", Country = "Italy", MerchantProfit = Convert.ToDecimal("243,789"), NumberOfOutlets = 1300, CreatedBy = "Ray Brando", CreatedOn = Convert.ToDateTime("11/01/2016") });
            enrolments.Add(new MerchantEnrolmentRow { MerchantId = 3, MerchantName = "Member-F", Country = "Germany", MerchantProfit = Convert.ToDecimal("24,000"), NumberOfOutlets = 500, CreatedBy = "Roy Hills", CreatedOn = Convert.ToDateTime("12/02/2016") });
            enrolments.Add(new MerchantEnrolmentRow { MerchantId = 4, MerchantName = "Bank-A", Country = "USA", MerchantProfit = Convert.ToDecimal("500,000"), NumberOfOutlets = 2000, CreatedBy = "George Mason", CreatedOn = Convert.ToDateTime("12/02/2016") });
            enrolments.Add(new MerchantEnrolmentRow { MerchantId = 5, MerchantName = "Bank-B", Country = "India", MerchantProfit = Convert.ToDecimal("20,000"), NumberOfOutlets = 230, CreatedBy = "Alex Tory", CreatedOn = Convert.ToDateTime("15/04/2016") });
            enrolments.Add(new MerchantEnrolmentRow { MerchantId = 6, MerchantName = "Bank-C", Country = "Portugal", MerchantProfit = Convert.ToDecimal("13,000"), NumberOfOutlets = 400, CreatedBy = "Malcolm Davies", CreatedOn = Convert.ToDateTime("15/04/2016") });
        }

        public static Collection<MerchantEnrolmentRow> Save(MerchantEnrolmentRow merchantEnrolmentRow)
        {
            if (enrolments == null)
                enrolments = new Collection<MerchantEnrolmentRow>();
            if (merchantEnrolmentRow.MerchantId == null || merchantEnrolmentRow.MerchantId == 0)
            {
                merchantEnrolmentRow.MerchantId = _nextId++;
                enrolments.Add(merchantEnrolmentRow);
            }
            else
            {
                //Update operation
                var found = enrolments.FirstOrDefault(x => x.MerchantId == merchantEnrolmentRow.MerchantId);
                int i = enrolments.IndexOf(found);
                enrolments[i] = merchantEnrolmentRow;
            }

            return enrolments;
        }
        public static Collection<MerchantEnrolmentRow> Remove(int merchantId)
        {
            if (enrolments != null && enrolments.Count > 0)
            {
                var found = enrolments.FirstOrDefault(x => x.MerchantId == merchantId);
                int i = enrolments.IndexOf(found);
                enrolments.Remove(found);
            }
            return enrolments;
        }
        public static List<MerchantEnrolmentRow> Get(string merchantName, string country, string userId)
        {
            List<MerchantEnrolmentRow> tempEnrolmentList = null;
            if (enrolments != null && enrolments.Count > 0)
            {
                tempEnrolmentList = enrolments.ToList();

                if (!string.IsNullOrEmpty(merchantName) && !string.IsNullOrEmpty(country))
                    tempEnrolmentList = tempEnrolmentList.Where(x => (!string.IsNullOrEmpty(x.MerchantName) && string.Equals(x.MerchantName, merchantName, StringComparison.OrdinalIgnoreCase)) &&
                        (!string.IsNullOrEmpty(x.Country) && string.Equals(x.Country, country, StringComparison.OrdinalIgnoreCase))).ToList<MerchantEnrolmentRow>();
                //tempEnrolmentList = tempEnrolmentList.Where(x => x.MerchantName.Equals(merchantName)).ToList<MerchantEnrolmentRow>();
                else if (!string.IsNullOrEmpty(merchantName))
                    tempEnrolmentList = tempEnrolmentList.Where(x => (!string.IsNullOrEmpty(x.MerchantName) && string.Equals(x.MerchantName, merchantName, StringComparison.OrdinalIgnoreCase))).ToList<MerchantEnrolmentRow>();
                else if (!string.IsNullOrEmpty(country))
                    tempEnrolmentList = tempEnrolmentList.Where(x => (!string.IsNullOrEmpty(x.Country) && string.Equals(x.Country, country, StringComparison.OrdinalIgnoreCase))).ToList<MerchantEnrolmentRow>();
                else
                    tempEnrolmentList = tempEnrolmentList.ToList<MerchantEnrolmentRow>();
            }
            return tempEnrolmentList;
        }
    }
}