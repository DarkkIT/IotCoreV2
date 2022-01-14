using System;
//using System.Device.I2c;
//using Iot.Device.Ssd13xx;
using System.Net;
using System.Net.Sockets;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace projectV2
{
    public class PoeHatController : BaseClass
    {
        //public void StartHatLcd()
        //{
        //    ScriptEngine engine = Python.CreateEngine();
        //    engine.ExecuteFile(@"/home/pi/Downloads/PoE_HAT_B_code/python/examples/main.py");
        //}

        //public void GetIP()
        //{
        //    var i2cLcdDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x20));

        //    using Ssd1306 lcd = new Ssd1306(i2cLcdDevice);
        //    {
        //        string localIP;
        //        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
        //        {
        //            socket.Connect("8.8.8.8", 65530);
        //            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
        //            localIP = endPoint.Address.ToString();
        //            Console.WriteLine($"IP: {localIP}");
        //        }
        //    }



        //}
    }
}
