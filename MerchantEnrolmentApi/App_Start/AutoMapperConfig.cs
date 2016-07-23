using MerchantEnrolment.Common.DataTransferObjects;
using MerchantEnrolment.DataAccessLayer.MerchantEnrolment;
using MerchantEnrolmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantEnrolmentApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            AutoMapper.Mapper.CreateMap<MerchantEnrolmentModel, MerchantEnrolmentDto>();
            AutoMapper.Mapper.CreateMap<MerchantEnrolmentDto, MerchantEnrolmentModel>();
            AutoMapper.Mapper.CreateMap<MerchantEnrolmentRow, MerchantEnrolmentDto>();
            AutoMapper.Mapper.CreateMap<MerchantEnrolmentDto, MerchantEnrolmentRow>();
        }
    }
}