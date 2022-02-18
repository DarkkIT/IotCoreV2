using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace projectV2
{
    public class BaseClass
    {
        public void Wait(int waitTime)
        {
            Thread.Sleep(waitTime);
        }
    }
}