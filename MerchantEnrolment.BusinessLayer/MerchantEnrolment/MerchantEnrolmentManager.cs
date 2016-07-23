using MerchantEnrolment.Common.DataTransferObjects;
using MerchantEnrolment.Common.Interface;
using MerchantEnrolment.DataAccessLayer.Interface;
using MerchantEnrolment.DataAccessLayer.MerchantEnrolment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.BusinessLayer.MerchantEnrolment
{
    public class MerchantEnrolmentManager : IMerchantEnrolment
    {
        private readonly IMerchantEnrolmentDal iMerchantEnrolmentDal;
        private readonly IMappingService iMappingService;

        public MerchantEnrolmentManager(IMerchantEnrolmentDal iMerchantEnrolmentDal, IMappingService iMappingService)
        {
            if (iMerchantEnrolmentDal == null)
                throw new ArgumentNullException("iMerchantEnrolmentDal", @"iMerchantDal can not be null");
            this.iMerchantEnrolmentDal = iMerchantEnrolmentDal;

            if (iMappingService == null)
                throw new ArgumentNullException("iMappingService", @"iMerchantDal can not be null");
            this.iMappingService = iMappingService;
        }
        public IEnumerable<MerchantEnrolmentDto> GetMerchantEnrolmentDetails(MerchantEnrolmentDto merchantEnrolmentDto)
        {
            var merchantDetailsRow = iMappingService.Map<MerchantEnrolmentRow>(merchantEnrolmentDto);
            var result = iMerchantEnrolmentDal.GetMerchantEnrolmentDetails(merchantDetailsRow);
            var responseList = iMappingService.Map<List<MerchantEnrolmentDto>>(result);
            return responseList;
        }

        public IEnumerable<MerchantEnrolmentDto> SaveMerchantEnrolmentDetails(MerchantEnrolmentDto merchantEnrolmentDto)
        {
            var merchantDetailsRow = iMappingService.Map<MerchantEnrolmentRow>(merchantEnrolmentDto);
            var result = iMerchantEnrolmentDal.SaveMerchnatEnrolmentDetails(merchantDetailsRow);
            var responseList = iMappingService.Map<List<MerchantEnrolmentDto>>(result);
            return responseList;
        }

        public IEnumerable<MerchantEnrolmentDto> DeleteMerchantEnrolment(int merchantId)
        {
            var result = iMerchantEnrolmentDal.DeleteMerchantEnrollmentDetails(merchantId);
            var responseList = iMappingService.Map<List<MerchantEnrolmentDto>>(result);
            return responseList;
        }
    }
}
