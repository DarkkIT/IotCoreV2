using System;
using System.Device.I2c;
using System.Threading.Tasks;
using Iot.Device.MotorHat;
using projectV2.Models;
using projectV2.Others;

namespace projectV2.Motions
{
    public class DCMotorController : BaseClass
    {
        public void MoveFront(SensCommands sensCommands, double command)
        {
            double newPosition = 0d;
            var position = sensCommands.ManualDcMotorControl;

            using (var motorHat = new MotorHat(new I2cConnectionSettings(1, 0x50), 1000d, MotorPinProvider.Waveshare))
            {
                var motor = motorHat.CreateDCMotor(2);

                if (position == 0d)
                {
                    motor.Speed = command;
                    newPosition = command;
                }
                else if (position < 0d)
                {
                    motor.Speed = 0d;
                    newPosition = 0d;
                }
                else if (position > 0d)
                {
                    newPosition = command;
                }

                motor.Dispose();
            }

            sensCommands.ManualDcMotorControl = newPosition;
        }

        public async Task Start(double command)
        {
            using (var motorHat = new MotorHat(new I2cConnectionSettings(1, 0x50), 1000d, MotorPinProvider.Waveshare))
            {
                var motor = motorHat.CreateDCMotor(2);

                motor.Speed = command;
            }
        }

        public async Task StartMotor(double speed)
        {
            Console.WriteLine("Test00");
            var i2cConectionSeting = new I2cConnectionSettings(busId: 1, deviceAddress: 0x50);

            using (var motorHat = new MotorHat(i2cConectionSeting, 1600d, MotorPinProvider.Waveshare))
            {
                Console.WriteLine("Test01");

                var motor = motorHat.CreateDCMotor(1);

                Console.WriteLine("Test02");

                motor.Speed = speed;

                Console.WriteLine("Test03");
            }
        }
    }
}
