using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantEnrolment.Common.Enums;

namespace MerchantEnrolment.Common.Interface
{
    public interface IMerchantEnrolmentIoC
    {
        void Inititalize();
        void Shutdown();

        Object GetInternalContainer();

        IMerchantEnrolmentIoC MapType<TFrom, TTo>(IoCObjectLifeCycle objectLifeCycle)
            where TFrom : class
            where TTo : TFrom;

        IMerchantEnrolmentIoC MapType<TFrom, TTo>()
            where TFrom : class
            where TTo : TFrom;

        bool IsMapped(Type isMapped);

        T GetInstance<T>();
        void DestoryInstance<T>(T toDesstory)
            where T : class;

    }
}
