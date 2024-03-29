﻿using Iot.Device.Pwm;
using Iot.Device.ServoMotor;
using projectV2.GlobalConstants;
using projectV2.Models;
using projectV2.Others;
using System;
using System.Device.I2c;
using System.Device.Pwm;
using System.Diagnostics;
using System.Threading.Tasks;

namespace projectV2.Motions
{
    public class ServoController : BaseClass
    {
        public async Task Start(int servo, ServoPositions servoPositions, double endPosition)
        {
            var i2cDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x40));

            using var servoControler = new Pca9685(i2cDevice, 50, 1);
            {
                var servoPwm = servoControler.CreatePwmChannel(servo);
                servoPwm.Start();

                if (servo == 0)
                {
                    servoPositions.FrontWheelsPosition = await Servo0(servoPwm, endPosition, servoPositions.FrontWheelsPosition);
                }

                servoPwm.Stop();
            }
        }

        public async Task<double> Servo0(PwmChannel servoPwm, double endPosition, double currentPosition)
        {
            Console.WriteLine("Start servo");

            var sw = new Stopwatch();
            sw.Start();

            while (true)
            {
                servoPwm.DutyCycle = currentPosition;

                if (sw.ElapsedMilliseconds % 2 == 0)
                {
                    if (currentPosition < endPosition)
                    {
                        currentPosition += 0.0006;

                        if (currentPosition >= endPosition)
                        {
                            if (endPosition == FrontWheels.Middle)
                            {
                                currentPosition += 0.0006;
                                servoPwm.DutyCycle = currentPosition;
                            }

                            sw.Stop();
                            break;
                        }
                    }
                    else if (currentPosition > endPosition)
                    {
                        currentPosition -= 0.0006;

                        if (currentPosition <= endPosition)
                        {
                            if (endPosition == FrontWheels.Middle)
                            {
                                currentPosition -= 0.0006;
                                servoPwm.DutyCycle = currentPosition;
                            }

                            sw.Stop();
                            break;
                        }
                    }
                }
            }

            return currentPosition;
        }

        ////Calibrate servos to the middle position before start operationg
        public async Task CalibrateSevos()
        {
            var i2cDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x40));

            using var servoControler = new Pca9685(i2cDevice, 50, 1);
            {
                //Calibrate front wheels
                var servo = servoControler.CreatePwmChannel(0);
                servo.Start();
                servo.DutyCycle = FrontWheels.Middle;
                await Task.Delay(1000);
                servo.Stop();
            }
            servoControler.Dispose();
        }
    }
}