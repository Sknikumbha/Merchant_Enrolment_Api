using MerchantEnrolment.Common.Enums;
using MerchantEnrolment.Common.Interface;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.Common.IoC
{
    public class MerchantEnrolmentIoC : IMerchantEnrolmentIoC
    {
        private UnityContainer container;

        public MerchantEnrolmentIoC()
        {
            container = new UnityContainer();
        }
        public void Inititalize()
        {
            container = container ?? new UnityContainer();
            var section = ConfigurationManager.GetSection("Unity") as UnityConfigurationSection;

            if (section != null)
                section.Configure(container);
        }

        public void Shutdown()
        {
            container.Dispose();
        }

        public object GetInternalContainer()
        {
            return container;
        }

        public IMerchantEnrolmentIoC MapType<TFrom, TTo>(Enums.IoCObjectLifeCycle objectLifeCycle)
            where TFrom : class
            where TTo : TFrom
        {
            if (container == null)
                return this;

            LifetimeManager objectLifeTime;
            switch (objectLifeCycle)
            {
                case IoCObjectLifeCycle.AlwaysInstantiate:
                    objectLifeTime = new TransientLifetimeManager();
                    break;
                case IoCObjectLifeCycle.OnePerApplicationInstance:
                    objectLifeTime = new ContainerControlledLifetimeManager();
                    break;
                case IoCObjectLifeCycle.OnePerApplicationThread:
                default:
                    objectLifeTime = new PerThreadLifetimeManager();
                    break;
            }

            container.RegisterType<TFrom, TTo>(objectLifeTime);

            return this;
        }

        public IMerchantEnrolmentIoC MapType<TFrom, TTo>()
            where TFrom : class
            where TTo : TFrom
        {
            // Will need to be mindful of static objects that are not made threadsafe
            // also watch for objects that open resources that should be closed/reset before being used by new execution on same thread 
            return MapType<TFrom, TTo>(IoCObjectLifeCycle.OnePerApplicationThread);
        }

        public bool IsMapped(Type isMapped)
        {
            return container != null && container.IsRegistered(isMapped);
        }

        public T GetInstance<T>()
        {
            if (container == null || !container.IsRegistered(typeof(T)))
                return default(T);
            return container.Resolve<T>();
        }

        public void DestoryInstance<T>(T toDesstory) where T : class
        {
            if (container == null || !container.IsRegistered(typeof(T)))
                return;
            container.Teardown(toDesstory);
        }
    }
}
