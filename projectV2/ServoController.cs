using Iot.Device.Pwm;
using Iot.Device.ServoMotor;
using System;
using System.Device.I2c;
using System.Device.Pwm;

namespace projectV2
{
    public class ServoController : BaseClass
    {
        public void StartServo()
        {
            var i2cDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x40));
            Console.WriteLine("Test 00");
            using var servoControler = new Pca9685(i2cDevice, 50, 1);
            {
                Console.WriteLine("Test 01");
                Console.WriteLine("Test 02");
                var Servo1 = servoControler.CreatePwmChannel(0);

                Servo1.Start();
                Console.WriteLine("Test 03");

                Servo1.DutyCycle = Constants.G180;
                Wait(1000);

                Servo1.DutyCycle = Constants.G157;
                Wait(1000);
                //45
                Servo1.DutyCycle = Constants.G135;
                Wait(1000);
                //22,5
                Servo1.DutyCycle = Constants.G112;
                Wait(1000);
                //0
                Servo1.DutyCycle = Constants.G90;
                Wait(1000);
                //-22.5
                Servo1.DutyCycle = Constants.G67;
                Wait(1000);
                //-45
                Servo1.DutyCycle = Constants.G45;
                Wait(1000);
                //-67.5
                Servo1.DutyCycle = Constants.G22;
                Wait(1000);
                //-90
                Servo1.DutyCycle = Constants.G0;
                Wait(1000);
                //0
                Servo1.DutyCycle = Constants.G90;
                Wait(1000);


                //from 0 to 180
                Servo1.DutyCycle = Constants.G0;
                Wait(1000);
                var counter = Constants.G0;
                while (counter <= Constants.G180)
                {
                    Servo1.DutyCycle = counter;
                    Wait(1);
                    counter += 0.0001;
                }
                Servo1.DutyCycle = Constants.G90;
                Wait(1000);

                Servo1.Stop();                
            }

        }

    }
}