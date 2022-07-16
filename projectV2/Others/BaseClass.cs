using projectV2.Models;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace projectV2.Others
{
    public class BaseClass
    {
        public void Wait(int milliSeconds)
        {
            Thread.Sleep(milliSeconds);
        }

        public bool Action(SensCommands sensCommands, SensCommands sensCommandsTemp)
        {
            if (sensCommands.Equals(sensCommandsTemp))
            {
                return true;
            }

            return false;
        }
    }
}