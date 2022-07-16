using projectV2.Displays;
using projectV2.GlobalConstants;
using projectV2.Models;
using projectV2.Motions;
using SixLabors.ImageSharp;
using System;
using System.Threading.Tasks;

namespace projectV2.Others
{
    public class LogicController : BaseClass
    {
        public async Task StartLogic(Initializations controllers)
        {

            ////Dtos
            var lcdText = string.Empty;
            ConsoleKey command = ConsoleKey.Escape;
            var servoPositions = controllers.ServoPositions;
            var sensCommands = controllers.SensCommands;
            var sensCommandsTemp = controllers.SensCommandsTemp;
            var lcd = controllers.Lcd;
            var servo = controllers.Servo;

            ////Calibrations
            Console.WriteLine("Calibrations");
            controllers.Lcd.Write("Calibrations", "Working on", Color.White);
            await controllers.Servo.CalibrateSevos();
            await Task.Delay(1000);

            ////Logic
            while (true)
            {
                if (Action(sensCommands, sensCommandsTemp))
                {
                    Wait(100);
                    continue;
                }

                sensCommandsTemp = sensCommands;

                command = sensCommands.ManualServoControl;

                if (command == ConsoleKey.LeftArrow)
                {
                    await servo.Start(0, servoPositions, FrontWheels.FullLeft);
                    lcdText = " Go Left";
                    command = ConsoleKey.Escape;
                }
                else if (command == ConsoleKey.RightArrow)
                {
                    await servo.Start(0, servoPositions, FrontWheels.FullRight);
                    lcdText = "Go Right";
                    command = ConsoleKey.Escape;
                }

                lcd.Write($"Console - {sensCommands.ManualServoControl}", lcdText, Color.White);
            }
        }
    }
}
