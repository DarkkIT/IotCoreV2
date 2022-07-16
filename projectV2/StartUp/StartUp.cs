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


            ////Dtos
            var menualMode = false;
            ConsoleKeyInfo key;
            ConsoleKeyInfo keyTemp = new ConsoleKeyInfo();


            ////Logic
            logic.StartLogic(controllers);       


            ////Console readinds
            while (true)
            {
                key = Console.ReadKey(false);
                Console.WriteLine();
                if (key != keyTemp)
                {
                    controllers.Lcd.Write("Key pressed", $"{key.Key.ToString()}", Color.White);
                }
                keyTemp = key;

                if (key.Key == ConsoleKey.F5)
                {
                    Console.WriteLine("Manually mode ON");
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
                        controllers.Lcd.Write("AM Key pressed", $"{key.Key.ToString()}", Color.White);
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
                        Console.WriteLine("Manually mode OFF");
                        menualMode = false;
                    }

                    await Task.Delay(10);
                }
            }
        }
    }
}
