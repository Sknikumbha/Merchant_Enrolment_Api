using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;

namespace MerchantEnrolment.Common.ExceptionManagement
{
    public class GlobalExceptionHandler  : ExceptionHandler
    {
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return context.CatchBlock.IsTopLevel;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = context.Exception });
            response.Headers.Add("Error", "Error");
            context.Result = new ResponseMessageResult(response);
            //base.Handle(context);
        }
    }
}
