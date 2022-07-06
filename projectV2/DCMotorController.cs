using System;
using System.Device.I2c;
using Iot.Device.MotorHat;

namespace projectV2
{
    public class DCMotorController : BaseClass
    {
        public void StartMotor()
        {
            Console.WriteLine("Test00");
            var i2cConectionSeting = new I2cConnectionSettings(busId: 1, deviceAddress: 0x5f);

            using (var motorHat = new MotorHat(i2cConectionSeting, 1600d))
            {
                Console.WriteLine("Test01");

                var motor = motorHat.CreateDCMotor(1);

                Console.WriteLine("Test02");

                motor.Speed = 1;

                Wait(1500);

                motor.Speed = 0;

                Console.WriteLine("Test03");
            }

        }

        public void StartMotor1()
        {

        }
    }
}
