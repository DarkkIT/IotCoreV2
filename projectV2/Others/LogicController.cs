using projectV2.GlobalConstants;
using projectV2.Models;
using SixLabors.ImageSharp;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace projectV2.Others
{
    public class LogicController : BaseClass
    {
        public async Task StartLogic(Initializations controllers)
        {

            ////Dtos
            var lcdText = string.Empty;
            ConsoleKey command;
            var sensCommands = controllers.SensCommands;
            var lcd = controllers.Lcd;
            var servo = controllers.Servo;
            var sensCommandsTemp = ConsoleKey.Escape;


            ////Calibrations
            Console.WriteLine("Calibrations");
            lcd.Write("Calibrations", "Working on", Color.White);
            await controllers.Servo.CalibrateSevos();

            ////Logic
            while (true)
            {
                if (CheckStatusCommand(controllers, sensCommandsTemp))
                {
                    continue;
                }

                sensCommandsTemp = TempData(controllers, sensCommandsTemp);

                command = sensCommands.ManualServoControl;

                if (command == ConsoleKey.LeftArrow)
                {
                    await servo.Start(0, controllers.ServoPositions, FrontWheels.FullLeft);
                    lcdText = "Turn Left";
                }
                else if (command == ConsoleKey.RightArrow)
                {
                    await servo.Start(0, controllers.ServoPositions, FrontWheels.FullRight);
                    lcdText = "Turn Right";
                }
                else if (command == ConsoleKey.Spacebar)
                {
                    await servo.Start(0, controllers.ServoPositions, FrontWheels.Middle);
                    lcdText = "Center";
                }

                Console.WriteLine(lcdText);
            }
        }

        public ConsoleKey TempData(Initializations controllers, ConsoleKey sensCommandsTemp)
        {
            sensCommandsTemp = controllers.SensCommands.ManualServoControl;

            return sensCommandsTemp;
        }
    }
}
