using System.Device.I2c;
using System.Threading.Tasks;
using Iot.Device.CharacterLcd;
using projectV2.Others;
using SixLabors.ImageSharp;

namespace projectV2.Displays
{
    public class LcdController : BaseClass
    {
        public async Task Write(string lineOne, string lineTwo, Color color)
        {
            var i2cLcdDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x3E));
            var i2cRgbDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x60));
            using LcdRgb lcd = new LcdRgb(new Size(16, 2), i2cLcdDevice, i2cRgbDevice);
            {
                lcd.SetBacklightColor(color);

                lcd.SetCursorPosition(0, 0);
                lcd.Write(lineOne);

                lcd.SetCursorPosition(0, 1);
                lcd.Write(lineTwo);
            }
        }

        public async Task SetBackground(Color color)
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
