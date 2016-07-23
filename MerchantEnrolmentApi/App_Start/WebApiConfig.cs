using FluentValidation.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MerchantEnrolmentApi
{
    public static class WebApiConfig
    {
        
        /// <summary>
        /// Url Prefix
        /// </summary>
        public static string UrlPrefix { get { return "api"; } }

        /// <summary>
        /// Url Prefix Relative
        /// </summary>
        public static string UrlPrefixRelative { get { return "~/api"; } }
        
        /// <summary>
        /// Register method of WebApi config
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Add(typeof(System.Web.Http.Validation.ModelValidatorProvider),
                new FluentValidationModelValidatorProvider());

            // Web API routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
