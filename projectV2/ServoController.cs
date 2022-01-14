using Iot.Device.ServoMotor;
using System;
using System.Device.Pwm;
using System.Threading;

namespace projectV2
{
    public class ServoController
    {
        public void GoLeft()
        {
            ServoMotor servoMotor = new ServoMotor(PwmChannel.Create(0, 0, 50), 0.5);

            servoMotor.Calibrate(360, 1000, 3000);

            Console.WriteLine("Start");

            servoMotor.Start();

            //servoMotor.WriteAngle(0);
            servoMotor.WritePulseWidth(1000);
            Thread.Sleep(300);

            servoMotor.Stop();
        }

        public void GoRight()
        {
            ServoMotor servoMotor = new ServoMotor(PwmChannel.Create(0, 0, 50), 0.5);

            servoMotor.Calibrate(360, 1000, 3000);

            Console.WriteLine("Start");

            servoMotor.Start();
            //servoMotor.WriteAngle(330);
            servoMotor.WritePulseWidth(1000);
            Thread.Sleep(300);

            servoMotor.Stop();
        }

    }
}