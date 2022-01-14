using Iot.Device.ServoMotor;
using SixLabors.ImageSharp;
using System;
using System.Device.Pwm;
using System.Threading;
using System.Threading.Tasks;

namespace projectV2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start test");
            ////-----------------------------------------------------------------Hat
            //var poeHatController = new PoeHatController();
            //poeHatController.StartHatLcd();

            ////-----------------------------------------------------------------LCD
            //Console.WriteLine("Start LCD");
            //var lcd = new LcdController();
            //lcd.SetBackground(Color.DarkGreen);
            //lcd.Wait(1000);
            //lcd.Write("Test One", "Test Two", Color.DarkCyan, 1000, 1);
            //lcd.Wait(1000);
            //lcd.Write("Test Tree", "Test Four", Color.DarkGreen, 1000, 1);
            //lcd.Wait(1000);
            //lcd.SetBackground(Color.Red);

            ////-----------------------------------------------------------------Camera
            //Console.WriteLine("Start Camera");
            //var camera = new CameraController();
            //await camera.TakePicture();

            ////-----------------------------------------------------------------Servo Motor
            Console.WriteLine("Start Servo");
            var servo = new ServoController();
            servo.GoLeft();
            //servo.GoRight();

            ////-----------------------------------------------------------------DC Morot
            //Console.WriteLine("Start DC Motor");
            //var motor = new DCMotorController();
            //motor.StartMotor();
            //motor.StopMotor();



            Console.WriteLine("Test End");
        }
    }
}
