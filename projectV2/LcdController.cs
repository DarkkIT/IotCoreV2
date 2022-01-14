//using Iot.Device.CharacterLcd;
//using System.Device.I2c;
using System.Device.I2c;
using System.Threading;
using Iot.Device.CharacterLcd;
using SixLabors.ImageSharp;

namespace projectV2
{
    public class LcdController : BaseClass
    {
        public void Write(string lineOne, string lineTwo, Color color, int delay, int loops)
        {
            var i2cLcdDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x3E));
            var i2cRgbDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x60));
            using LcdRgb lcd = new LcdRgb(new Size(16, 2), i2cLcdDevice, i2cRgbDevice);
            {
                int counter = 0;
                lcd.SetBacklightColor(color);
                while (counter < loops)
                {
                    lcd.SetCursorPosition(0, 0);
                    lcd.Write(lineOne);

                    lcd.SetCursorPosition(0, 1);
                    lcd.Write(lineTwo);


                    Thread.Sleep(delay);
                    lcd.Clear();

                    counter++;
                }
            }
        }

        public void SetBackground(Color color)
        {
            var i2cLcdDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x3E));
            var i2cRgbDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x60));
            using LcdRgb lcd = new LcdRgb(new Size(16, 2), i2cLcdDevice, i2cRgbDevice);
            {
                lcd.SetBacklightColor(color);
            }
        }
    }
}
