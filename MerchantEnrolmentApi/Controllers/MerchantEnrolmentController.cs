using MerchantEnrolment.Common.DataTransferObjects;
using MerchantEnrolment.Common.ExceptionManagement;
using MerchantEnrolment.Common.Interface;
using MerchantEnrolmentApi.ConstantHelpers;
using MerchantEnrolmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MerchantEnrolmentApi.Controllers
{
    public class MerchantEnrolmentController : ApiController
    {
        private readonly IMerchantEnrolment iMerchantEnrolment;
        private readonly IMappingService iMappingService;
        public MerchantEnrolmentController(IMappingService iMappingService, IMerchantEnrolment iMerchantEnrolment)
        {
            if (iMerchantEnrolment == null)
                throw new ArgumentNullException("iMerchantEnrolment", @"iMerchantEnrolment can not be null");
            this.iMerchantEnrolment = iMerchantEnrolment;

            if (iMappingService == null)
                throw new ArgumentNullException("iMappingService", @"iMerchantDal can not be null");
            this.iMappingService = iMappingService;
        }

        /// <summary>
        /// Get enrollment details based on merchant name, country or user id
        /// </summary>
        /// <param name="merchantName"></param>
        /// <param name="country"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route(RouteNames.GetMerchantEnrolment)]
        [ExceptionFilterValidation]
        [ResponseType(typeof(IEnumerable<MerchantEnrolmentModel>))]
        public IHttpActionResult Get([FromUri] string merchantName = null, string country = null, string userId = null)
        {
            if (string.IsNullOrEmpty(merchantName) && string.IsNullOrEmpty(country) && string.IsNullOrEmpty(userId)) return BadRequest(ModelState);
            var merchantEnrolmentDetails = new MerchantEnrolmentModel
            {
                MerchantName = merchantName,
                Country = country,
                CreatedBy = userId
            };
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            var reqquest = iMappingService.Map<MerchantEnrolmentDto>(merchantEnrolmentDetails);
            var response = iMerchantEnrolment.GetMerchantEnrolmentDetails(reqquest);
            if (response == null)
                return NotFound();
            return Ok(response);

        }

        /// <summary>
        /// Save Merchant enrolment details
        /// </summary>
        /// <param name="merchantEnrolmentDetails"></param>
        /// <returns></returns>
        [Route(RouteNames.SaveMerchantEnrolment)]
        [ExceptionFilterValidation]
        public IHttpActionResult Post([FromBody] MerchantEnrolmentModel merchantEnrolmentDetails)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var reqquest = iMappingService.Map<MerchantEnrolmentDto>(merchantEnrolmentDetails);
            var response = iMerchantEnrolment.SaveMerchantEnrolmentDetails(reqquest);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        /// Delete Merchant enrolment details
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(RouteNames.DeleteMerchantEnrolment)]
        [ExceptionFilterValidation]
        public IHttpActionResult Delete([FromUri]int merchantId)
        {
            var response = iMerchantEnrolment.DeleteMerchantEnrolment(merchantId);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

    }
}