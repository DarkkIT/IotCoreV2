using SixLabors.ImageSharp;
using System;

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
            Console.WriteLine("Start LCD");
            var lcd = new LcdController();            

            lcd.Write("Go Move", "...........", Color.DarkGreen, 100, 1);
            lcd.Wait(100);

            lcd.SetBackground(Color.Green);

            ////-----------------------------------------------------------------Camera
            //Console.WriteLine("Start Camera");
            //var camera = new CameraController();
            //await camera.TakePicture();

            ////-----------------------------------------------------------------Servo Motor

            Console.WriteLine("Start Servo");
            var servo = new ServoController();

            servo.StartServo();


            ////-----------------------------------------------------------------DC Morot
            //Console.WriteLine("Start DC Motor");
            //var motor = new DCMotorController();
            //motor.StartMotor();
            //motor.StopMotor();


            Console.WriteLine("Test End");
        }
    }
}
