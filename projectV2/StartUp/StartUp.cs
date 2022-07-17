using projectV2.GlobalConstants;
using projectV2.Models;
using System;
using System.Threading.Tasks;
using projectV2.Others;
using SixLabors.ImageSharp;

namespace projectV2.StartUp
{
    public class StartUp
    {
        public async Task Start()
        {
            ////-----------------------------------------------------------------Hat
            //var poeHatController = new PoeHatController();
            //poeHatController.StartHatLcd();

            ////-----------------------------------------------------------------Camera
            //Console.WriteLine("Start Camera");
            //var camera = new CameraController();
            //await camera.TakePicture();


            ////Initialization
            var logic = new LogicController();
            var controllers = new Initializations();
            var lcd = controllers.Lcd;

            ////Dtos
            var menualMode = false;
            ConsoleKeyInfo keyTemp = new ConsoleKeyInfo();
            ConsoleKeyInfo key;


            ////Logic
            logic.StartLogic(controllers);


            ////Console readinds
            lcd.Write("Write command", $"..............", Color.White);

            while (true)
            {
                key = Console.ReadKey(false);
                Console.WriteLine();
                if (key != keyTemp)
                {
                    lcd.Write("Key pressed", $"{key.Key}", Color.White);
                }
                keyTemp = key;

                if (key.Key == ConsoleKey.F5)
                {
                    Console.WriteLine("Manual mode ON");
                    lcd.Write("Manual mode ON", $"{key.Key}", Color.White);
                    menualMode = true;
                }
                else if (key.Key == ConsoleKey.F12)
                {
                    Console.WriteLine("End Program");

                    break;
                }

                while (menualMode == true)
                {
                    key = Console.ReadKey(false);
                    Console.WriteLine();
                    if (key != keyTemp)
                    {
                        lcd.Write("MM Key pressed", $"{key.Key}", Color.White);
                    }
                    keyTemp = key;


                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        controllers.SensCommands.ManualServoControl = ConsoleKey.LeftArrow;
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        controllers.SensCommands.ManualServoControl = ConsoleKey.RightArrow;
                    }
                    else if (key.Key == ConsoleKey.F5)
                    {
                        Console.WriteLine("Manual mode OFF");
                        lcd.Write("Manual mode OFF", $"{key.Key}", Color.White);
                        menualMode = false;
                    }
                }
            }

            await Task.Delay(2000);

            lcd.Write("Program End", $"{key.Key}", Color.White);

            await Task.Delay(2000);

            lcd.Clear();
        }
    }
}
