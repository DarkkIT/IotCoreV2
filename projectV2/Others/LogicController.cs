using Iot.Device.MotorHat;
using projectV2.GlobalConstants;
using projectV2.Models;
using projectV2.Motions;
using SixLabors.ImageSharp;
using System;
using System.Device.I2c;
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


            ////
            var speed = 0d;
            var i2cConectionSeting = new I2cConnectionSettings(busId: 1, deviceAddress: 0x50);
            using var motorHat = new MotorHat(i2cConectionSeting, 1600d, MotorPinProvider.Waveshare);
            var motor = motorHat.CreateDCMotor(1);


            ////Calibrations
            Console.WriteLine("Calibrations");
            lcd.Write("Calibrations", "Working on", Color.White);
            await controllers.Servo.CalibrateSevos();

            ////Listening for commands
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
                else if (command == ConsoleKey.UpArrow)
                {
                    if (speed == 0)
                    {
                        motor.Speed = 0.2;
                        speed = 0.2;
                    }
                    else if (speed < 0) 
                    {
                        motor.Speed = 0d;
                        speed = 0d;
                    }

                    lcdText = "Forward";
                }
                else if (command == ConsoleKey.DownArrow)
                {
                    if (speed == 0)
                    {
                        motor.Speed = - 0.2;
                        speed = - 0.2;
                    }
                    else if (speed > 0)
                    {
                        motor.Speed = 0d;
                        speed = 0d;
                    }

                    lcdText = "Backward";
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
