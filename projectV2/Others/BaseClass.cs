using projectV2.Models;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace projectV2.Others
{
    public class BaseClass
    {
        public void Wait(int milliSeconds)
        {
            Task.Delay(milliSeconds);
        }

        public bool Action(Initializations controllers)
        {
            if (controllers.SensCommands.Equals(controllers.SensCommandsTemp))
            {
                return true;
            }

            Wait(100);
            return false;
        }
    }
}