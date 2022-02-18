using System;
using System.Threading;
using System.Device.Pwm;
using Iot.Device.ServoMotor;

namespace projectV2
{
    public class ServoController : BaseClass
    {
        public void GoLeft()
        {
            ServoMotor servoMotor = new ServoMotor(PwmChannel.Create(0, 0, 50));

            servoMotor.Start();

            servoMotor.WritePulseWidth(1000);

            servoMotor.Stop();
        }

    }
}