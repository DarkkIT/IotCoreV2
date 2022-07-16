using Iot.Device.Pwm;
using projectV2.GlobalConstants;
using projectV2.Others;
using System;
using System.Collections.Generic;
using System.Device.I2c;
using System.Text;

namespace projectV2.Models
{
    public class TestServo : BaseClass
    {
        public void StartTest()
        {
            var i2cDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x40));

            using var servoControler = new Pca9685(i2cDevice, 50, 1);
            {
                var servoPwm = servoControler.CreatePwmChannel(0);
                servoPwm.Start();

                servoPwm.DutyCycle = 0.077;
                Wait(1000);
                servoPwm.DutyCycle = 0.090;
                Wait(1000);
                servoPwm.DutyCycle = 0.077;
                Wait(1000);
                servoPwm.DutyCycle = 0.067;
                Wait(1000);


                servoPwm.Stop();
            }

            servoControler.Dispose();
        }
    }
}
