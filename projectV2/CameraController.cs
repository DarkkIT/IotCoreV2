//using MMALSharp;
//using MMALSharp.Common;
//using MMALSharp.Common.Utility;
//using MMALSharp.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Unosquare.RaspberryIO;
//using Unosquare.RaspberryIO.Camera;
//using Unosquare.WiringPi;

namespace projectV2
{
    public class CameraController : BaseClass
    {
        ////public partial class Form1 : Form
        ////{
        ////    private bool DeviceExist = false;
        ////    private FilterInfoCollection videoDevices;
        ////    private VideoCaptureDevice videoSource = null;

        ////    public Form1()
        ////    {
        ////        InitializeComponent();
        ////    }

        ////    // get the devices name
        ////    private void getCamList()
        ////    {
        ////        try
        ////        {
        ////            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        ////            comboBox1.Items.Clear();
        ////            if (videoDevices.Count == 0)
        ////                throw new ApplicationException();

        ////            DeviceExist = true;
        ////            foreach (FilterInfo device in videoDevices)
        ////            {
        ////                comboBox1.Items.Add(device.Name);
        ////            }
        ////            comboBox1.SelectedIndex = 0; //make dafault to first cam
        ////        }
        ////        catch (ApplicationException)
        ////        {
        ////            DeviceExist = false;
        ////            comboBox1.Items.Add("No capture device on your system");
        ////        }
        ////    }

        ////    //refresh button
        ////    private void rfsh_Click(object sender, EventArgs e)
        ////    {
        ////        getCamList();
        ////    }

        ////    //toggle start and stop button
        ////    private void start_Click(object sender, EventArgs e)
        ////    {
        ////        if (start.Text == "&Start")
        ////        {
        ////            if (DeviceExist)
        ////            {
        ////                videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
        ////                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
        ////                CloseVideoSource();
        ////                videoSource.DesiredFrameSize = new Size(160, 120);
        ////                //videoSource.DesiredFrameRate = 10;
        ////                videoSource.Start();
        ////                label2.Text = "Device running...";
        ////                start.Text = "&Stop";
        ////                timer1.Enabled = true;
        ////            }
        ////            else
        ////            {
        ////                label2.Text = "Error: No Device selected.";
        ////            }
        ////        }
        ////        else
        ////        {
        ////            if (videoSource.IsRunning)
        ////            {
        ////                timer1.Enabled = false;
        ////                CloseVideoSource();
        ////                label2.Text = "Device stopped.";
        ////                start.Text = "&Start";
        ////            }
        ////        }
        ////    }

        ////    //eventhandler if new frame is ready
        ////    private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        ////    {
        ////        Bitmap img = (Bitmap)eventArgs.Frame.Clone();
        ////        //do processing here
        ////        pictureBox1.Image = img;
        ////    }

        ////    //close the device safely
        ////    private void CloseVideoSource()
        ////    {
        ////        if (!(videoSource == null))
        ////            if (videoSource.IsRunning)
        ////            {
        ////                videoSource.SignalToStop();
        ////                videoSource = null;
        ////            }
        ////    }

        ////    //get total received frame at 1 second tick
        ////    private void timer1_Tick(object sender, EventArgs e)
        ////    {
        ////        label2.Text = "Device running... " + videoSource.FramesReceived.ToString() + " FPS";
        ////    }

        ////    //prevent sudden close while device is running
        ////    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        ////    {
        ////        CloseVideoSource();
        ////    }
        ////}



        //public void TakeVideo()
        //{
        //    // Setup our working variables
        //    var videoByteCount = 0;
        //    var videoEventCount = 0;
        //    var startTime = DateTime.UtcNow;

        //    // Configure video settings
        //    var videoSettings = new CameraVideoSettings()
        //    {
        //        CaptureTimeoutMilliseconds = 0,
        //        CaptureDisplayPreview = false,
        //        ImageFlipVertically = true,
        //        CaptureExposure = CameraExposureMode.Night,
        //        CaptureWidth = 1920,
        //        CaptureHeight = 1080
        //    };

        //    try
        //    {
        //        // Start the video recording
        //        Pi.Camera.OpenVideoStream(videoSettings,
        //            onDataCallback: (data) => { videoByteCount += data.Length; videoEventCount++; },
        //            onExitCallback: null);

        //        // Wait for user interaction
        //        startTime = DateTime.UtcNow;
        //        Console.WriteLine("Press any key to stop reading the video stream . . .");
        //        Console.ReadKey(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"{ex.GetType()}: {ex.Message}");
        //    }
        //    finally
        //    {
        //        // Always close the video stream to ensure raspivid quits
        //        Pi.Camera.CloseVideoStream();

        //        // Output the stats
        //        var megaBytesReceived = (videoByteCount / (1024f * 1024f)).ToString("0.000");
        //        var recordedSeconds = DateTime.UtcNow.Subtract(startTime).TotalSeconds.ToString("0.000");
        //        Console.WriteLine($"Capture Stopped. Received {megaBytesReceived} Mbytes in {videoEventCount} callbacks in {recordedSeconds} seconds");
        //    }

        //}

        //public async Task TakePicture()
        //{
        //    // Singleton initialized lazily. Reference once in your application.
        //    MMALCamera cam = MMALCamera.Instance;

        //    using (var imgCaptureHandler = new ImageStreamCaptureHandler("/home/pi/images/", "jpg"))
        //    {
        //        await cam.TakePicture(imgCaptureHandler, MMALEncoding.JPEG, MMALEncoding.I420);
        //    }

        //    // Cleanup disposes all unmanaged resources and unloads Broadcom library. To be called when no more processing is to be done
        //    // on the camera.
        //    cam.Cleanup();
        //}

        //public async Task TakeVideoOld()
        //{
        //    // Singleton initialized lazily. Reference once in your application.
        //    MMALCamera cam = MMALCamera.Instance;

        //    using (var vidCaptureHandler = new VideoStreamCaptureHandler("/home/pi/Videos/", "mpeg"))
        //    {
        //        var cts = new CancellationTokenSource(TimeSpan.FromMinutes(3));

        //        await cam.TakeVideo(vidCaptureHandler, cts.Token);
        //    }

        //    // Cleanup disposes all unmanaged resources and unloads Broadcom library. To be called when no more processing is to be done
        //    // on the camera.
        //    cam.Cleanup();
        //}
    }
}
