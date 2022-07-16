using System;
using System.Device.I2c;
using System.Threading.Tasks;
using Iot.Device.MotorHat;
using projectV2.Others;

namespace projectV2.Motions
{
    public class DCMotorController
    {
        public void MoveDCMotor(double command)
        {
            using (var motorHat = new MotorHat(new I2cConnectionSettings(1, 0x55), 1000d, MotorPinProvider.Waveshare))
            {
                var motor = motorHat.CreateDCMotor(2);
                Console.WriteLine("Inside motor controller");
                motor.Speed = command;
            }
        }

        public async Task DisposeMotor()
        {
            using (var motorHat = new MotorHat(new I2cConnectionSettings(1, 0x55), 1000d, MotorPinProvider.Waveshare))
            {
                var motor = motorHat.CreateDCMotor(2);
                motor.Speed = 0;

                motor.Dispose();
            }
        }
    }
}
