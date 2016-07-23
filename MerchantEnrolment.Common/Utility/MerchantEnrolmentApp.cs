using MerchantEnrolment.Common.Interface;
using MerchantEnrolment.Common.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchantEnrolment.Common.Utility
{
    public static class MerchantEnrolmentApp
    {
        private static IMerchantEnrolmentIoC aDefaultIoC;
        public static bool IsDefaultIoCInit { get; private set; }

        /// <summary>
        /// Default IoC Object to use if no thread specific value set
        /// </summary>
        public static IMerchantEnrolmentIoC DefaultIoC
        {
            get { return aDefaultIoC; }
            set { aDefaultIoC = value ?? MerchantEnrolmentNullIoC.NullIoC; }
        }

        /// <summary>
        /// Create ThreadLocal copy of IoC container so each operation can 
        /// have seperate container as necessary
        /// Uses DefaultIoC to start with on each thread
        /// </summary>
        private static readonly ThreadLocal<IMerchantEnrolmentIoC> iMerchantEnrolmentIoC =
            new ThreadLocal<IMerchantEnrolmentIoC>(() => DefaultIoC);
        
        /// <summary>
        /// Set the IoC to be used for this thread
        /// Passing null will cause it to revert to the default
        /// </summary>
        /// <param name="newIoc">IoC for this thread</param>
        /// <returns>The replaced IH1IoC for the Op</returns>
        public static IMerchantEnrolmentIoC SetOpIoc(IMerchantEnrolmentIoC newIoc)
        {
            var toReturn = iMerchantEnrolmentIoC.Value;
            iMerchantEnrolmentIoC.Value = newIoc ?? DefaultIoC;
            return toReturn;
        }
        /// <summary>
        /// Set the IoC container to be default for future threads
        /// Passing null will cause it to revert to the null implementation 
        /// </summary>
        /// <param name="newDefaultIoC"></param>
        /// <returns></returns>
        public static IMerchantEnrolmentIoC SetDefaultIoC(IMerchantEnrolmentIoC newDefaultIoC)
        {
            var toReturn = DefaultIoC;
            DefaultIoC = newDefaultIoC;
            return toReturn;
        }
        
        /// <summary>
        /// Initialization routine that should be called Once per app instance (AppPool)
        /// Once the default is set it can be change through SetDefaultContext
        /// All service implementation should call this in their static initializer
        /// </summary>
        /// <param name="defIoC"> The default operation context</param>
        public static void  InititalizeDefIoC(MerchantEnrolmentIoC defIoC)
        {
            lock (MerchantEnrolmentNullIoC.NullIoC) // Just used to prevent multipl callers
            {
                if(IsDefaultIoCInit || defIoC==null)
                    return;

                SetDefaultIoC(defIoC);
                // Update the current thread to the default
                SetOpIoc(defIoC);
                defIoC.Inititalize();
                IsDefaultIoCInit = true;
            }
        }

        /// <summary>
        /// Returns the IoC for thread
        /// NullIoc if no value is set
        /// </summary>
        public static IMerchantEnrolmentIoC IoC
        {
            get { return iMerchantEnrolmentIoC.Value ?? MerchantEnrolmentNullIoC.NullIoC; }
        }

        /// <summary>
        /// Perform any cleanup for the application
        /// </summary>
        public static void UnloadApp()
        {
            iMerchantEnrolmentIoC.Value.Shutdown();
        }
    }
}
