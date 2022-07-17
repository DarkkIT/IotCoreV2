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
            var sensCommands = controllers.SensCommands;
            var lcd = controllers.Lcd;
            var servo = controllers.Servo;


            ////Calibrations
            Console.WriteLine("Calibrations");
            lcd.Write("Calibrations", "Working on", Color.White);
            await controllers.Servo.CalibrateSevos();

            ////Logic
            while (true)
            {
                if (Action(controllers))
                {
                    continue;
                }
                Console.WriteLine("test01");
                TempData(controllers);
                Console.WriteLine("test02");
                command = sensCommands.ManualServoControl;

                if (command == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("test1");
                    servo.Start(0, controllers.ServoPositions, FrontWheels.FullLeft);
                    lcdText = " Go Left";
                    Console.WriteLine("test2");
                }
                else if (command == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("test3");
                    servo.Start(0, controllers.ServoPositions, FrontWheels.FullRight);
                    lcdText = "Go Right";
                    Console.WriteLine("test4");
                }

                Console.WriteLine(lcdText);
            }
        }

        public void TempData(Initializations controllers)
        {
            controllers.SensCommandsTemp = controllers.SensCommands;
            Wait(100);
        }
    }
}
