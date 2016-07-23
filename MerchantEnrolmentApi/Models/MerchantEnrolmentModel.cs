using MerchantEnrolmentApi.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantEnrolmentApi.Models
{
    public class MerchantEnrolmentModel:BaseModel<MerchantEnrolmentValidator>
    {
        /// <summary>
        /// Merchant Id
        /// </summary>
        public int? MerchantId { get; set; }
        /// <summary>
        /// Merchant Name
        /// </summary>
        public string MerchantName { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Merchant profit
        /// </summary>
        public decimal MerchantProfit { get; set; }
        /// <summary>
        /// NumberOfOutlets
        /// </summary>
        public int? NumberOfOutlets { get; set; }
        /// <summary>
        /// Cretaed By/ Added By
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Cretaed On / Added On
        /// </summary>
        public DateTime? CreatedOn { get; set; }
    }
}