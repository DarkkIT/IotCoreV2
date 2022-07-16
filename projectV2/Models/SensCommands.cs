using System;
using System.Collections.Generic;
using System.Text;

namespace projectV2.Models
{
    public class SensCommands
    {
        public ConsoleKey ProximitySensorFront { get; set; }

        public ConsoleKey ProximitySensorBack { get; set; }


        public ConsoleKey ManualServoControl { get; set; } = ConsoleKey.Escape;
    }
}
