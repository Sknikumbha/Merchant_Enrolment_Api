using MerchantEnrolment.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MerchantEnrolment.Common.Common
{
    public class MappingService : IMappingService
    {
        public TDestination Map<TSource, TDestination>(TSource tSource) where TDestination : class
        {
            return Mapper.Map<TSource, TDestination>(tSource);
        }

        public TDestination Map<TDestination>(object tSource) where TDestination : class
        {
           return Mapper.Map<TDestination>(tSource);
        }
    }
}
