using MerchantEnrolment.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.Common.IoC
{
    class MerchantEnrolmentNullIoC :IMerchantEnrolmentIoC
    {

        internal static readonly MerchantEnrolmentNullIoC NullIoC = new MerchantEnrolmentNullIoC();
        public void Inititalize()
        {
            //throw new NotImplementedException();
        }

        public void Shutdown()
        {
            //throw new NotImplementedException();
        }

        public object GetInternalContainer()
        {
            //throw new NotImplementedException();
            return null;
        }

        public IMerchantEnrolmentIoC MapType<TFrom, TTo>(Enums.IoCObjectLifeCycle objectLifeCycle)
            where TFrom : class
            where TTo : TFrom
        {
            //throw new NotImplementedException();
            return this;
        }

        public IMerchantEnrolmentIoC MapType<TFrom, TTo>()
            where TFrom : class
            where TTo : TFrom
        {
            //throw new NotImplementedException();
            return this;
        }

        public bool IsMapped(Type isMapped)
        {
            //throw new NotImplementedException();
            return false;
        }

        public T GetInstance<T>()
        {
            //throw new NotImplementedException();
            return default(T);
        }

        public void DestoryInstance<T>(T toDesstory) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
