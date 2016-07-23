using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MerchantEnrolment.Common.ExceptionManagement
{
    public class ExceptionFilterValidation : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            //Log exception ToString db, enterprise level logging service.
        }
    }
}
