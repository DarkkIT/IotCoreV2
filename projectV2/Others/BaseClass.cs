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

        public bool CheckStatusCommand(Initializations controllers, ConsoleKey sensCommandsTemp)
        {
            if (controllers.SensCommands.ManualServoControl.Equals(sensCommandsTemp))
            {
                return true;
            }

            return false;
        }
    }
}