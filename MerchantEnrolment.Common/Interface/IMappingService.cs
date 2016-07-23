using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.Common.Interface
{
    public interface IMappingService
    {
        TDestination Map<TSource, TDestination>(TSource tSource) where TDestination : class;
        TDestination Map<TDestination>(object tSource) where TDestination : class;
    }
}
