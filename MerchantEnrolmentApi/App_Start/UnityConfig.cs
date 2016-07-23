using MerchantEnrolment.BusinessLayer.MerchantEnrolment;
using MerchantEnrolment.Common.Common;
using MerchantEnrolment.Common.Interface;
using MerchantEnrolment.Common.Utility;
using MerchantEnrolment.DataAccessLayer.DataAccessLayer;
using MerchantEnrolment.DataAccessLayer.Interface;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.WebApi;

namespace MerchantEnrolmentApi.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            #region Business Manager Mapping
            MerchantEnrolmentApp.IoC.MapType<IMerchantEnrolment,MerchantEnrolmentManager>();
            #endregion

            #region DAL Mapping
            MerchantEnrolmentApp.IoC.MapType<IMerchantEnrolmentDal,MerchantEnrolmentDal>();
            #endregion

            #region Common Service Mapping
            MerchantEnrolmentApp.IoC.MapType<IMappingService,MappingService>();
            #endregion

            #region Container Instantiation
            var container = MerchantEnrolmentApp.IoC.GetInternalContainer() as IUnityContainer;

            //container.RegisterType<>(new InjectionConstructor(typeof());

            if (container != null)
                GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            #endregion
        }
    }
}