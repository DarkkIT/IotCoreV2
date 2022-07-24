using projectV2.GlobalConstants;
using projectV2.Models;
using System;
using System.Threading.Tasks;
using projectV2.Others;
using SixLabors.ImageSharp;
using System.Collections.Generic;
using projectV2.Motions;

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
            var python = controllers.PythonController;

            ////Dtos
            var menualMode = false;
            ConsoleKeyInfo keyTemp = new ConsoleKeyInfo();
            ConsoleKeyInfo key;


            ////Add manual commands
            var commands = new List<ConsoleKey>();
            commands.Add(ConsoleKey.LeftArrow);
            commands.Add(ConsoleKey.RightArrow);
            commands.Add(ConsoleKey.Spacebar);
            commands.Add(ConsoleKey.UpArrow);
            commands.Add(ConsoleKey.DownArrow);



            ////Start python scripts
            //await python.Start(); //Not working


            //Logic
            logic.StartLogic(controllers);


            ////Console readinds
            lcd.Write("Set Mode:", $"..............", Color.White);
            Console.WriteLine("Set Mode:");

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

                    if (commands.Contains(key.Key))
                    {
                        await AddCommand(controllers, key.Key, Mode.Manual);
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

            lcd.Write("End Program", $"{key.Key}", Color.White);

            //await Task.Delay(2000);

            //lcd.Clear();
        }

        public async Task AddCommand(Initializations controllers, ConsoleKey command, Mode mode)
        {
            if (mode == Mode.Manual)
            {
                controllers.SensCommands.ManualServoControl = command;
            }
            else if (mode == Mode.Auto)
            {
                ///Add auto
            }

        }
    }
}
