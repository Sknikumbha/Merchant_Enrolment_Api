﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantEnrolment.Common.Enums
{
   public enum IoCObjectLifeCycle
    {
       AlwaysInstantiate,
       OnePerApplicationInstance,//Singleton
       OnePerApplicationThread
    }
}
