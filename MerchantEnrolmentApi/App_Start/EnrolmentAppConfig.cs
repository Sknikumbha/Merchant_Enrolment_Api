using MerchantEnrolment.Common.IoC;
using MerchantEnrolment.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantEnrolmentApi.App_Start
{
    public class EnrolmentAppConfig
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        public static void Register()
        {
            if(!MerchantEnrolmentApp.IsDefaultIoCInit)
            {
                MerchantEnrolmentApp.InititalizeDefIoC(new MerchantEnrolmentIoC());
                TemporaryIoCBootstrap();
            }

            //When the AppDomain is unloaded or default domain exists, make sure to do some cleanup
            AppDomain.CurrentDomain.DomainUnload+= UnloadServiceApp;
            AppDomain.CurrentDomain.ProcessExit  += UnloadServiceApp;
        }

        /// <summary>
        /// Event handler to catch the unload of the Appdomain
        /// </summary>
        /// <param name="prmSender"></param>
        /// <param name="eventArgs"></param>
        private static void UnloadServiceApp(object prmSender, EventArgs eventArgs)
        {
            //throw new NotImplementedException();
            // cleanup any application wide objects
            MerchantEnrolmentApp.UnloadApp();
        }

        private static void TemporaryIoCBootstrap()
        {
            //throw new NotImplementedException();
        }
    }
}