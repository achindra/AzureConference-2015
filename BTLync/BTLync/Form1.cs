using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Windows;
using InTheHand.Net.Sockets;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Extensibility;
using System.IO;
using WebCam_Capture;

namespace BTLync
{
    public partial class Form1 : Form
    {
        BluetoothClient btClient;
        BluetoothDeviceInfo[] btDevList;
        BluetoothDeviceInfo btSelectedDevice;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            btClient = new BluetoothClient();
            btDevList = btClient.DiscoverDevices();// (255, false, false, false, false);

            lstDevices.Items.Clear();
            foreach(BluetoothDeviceInfo device in btDevList)
            {
                lstDevices.Items.Add(device.DeviceName);
            }

            if (lstDevices.Items.Count > 0)
                btnConnect.Enabled = true;

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(lstDevices.SelectedItem != null)
            {
                btSelectedDevice = null;
                foreach(BluetoothDeviceInfo btDevice in btDevList)
                {
                    if (btDevice.DeviceName.Equals(lstDevices.SelectedItem.ToString()))
                    {
                        btSelectedDevice = btDevice;
                        break;
                    }
                }

                if(btSelectedDevice != null)
                {
                    if (!btSelectedDevice.Authenticated)
                    {
                        bool isPaired = BluetoothSecurity.PairRequest(btSelectedDevice.DeviceAddress, txtPin.Text);
                        if (!isPaired)
                        {
                            txtPin.Text = "PIN_ERROR";
                            return;
                        }
                    }
                    else
                    {
                        //btClient.SetPin(txtPin.Text);
                        btClient.BeginConnect(btSelectedDevice.DeviceAddress, BluetoothService.SerialPort, new AsyncCallback(Connect), btSelectedDevice);
                    }
                }
            }
        }

        private void Connect(IAsyncResult result)
        {
            if(result.IsCompleted)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        // Disable Connect button
                        btnScan.Enabled = false;
                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;
                        // Start Message Loop
                    }));
                    pollingLoop();
                }
            }
        }

        private async void pollingLoop()
        {
            System.Net.Sockets.NetworkStream Stream=null;
            int byteCount = 0;
            byte[] buffer = new byte[4096];

            while(btClient.Connected)
            {
                if(Stream == null)
                    Stream = btClient.GetStream();

                byteCount = await Stream.ReadAsync(buffer, 0, buffer.Length);
                String response = Encoding.UTF8.GetString(buffer, 0, byteCount);

                if (txtBTMsg.InvokeRequired == true)
                {
                    Invoke(new MethodInvoker(delegate()
                    {
                        txtBTMsg.AppendText(response);
                    }));
                }
                else
                {
                    txtBTMsg.AppendText(response);
                }

                if (response.Contains(txtTrigCode.Text)) //"VideoCall\r\n"))
                {
                    List<string> participantUri = new List<string>();
                    if (txtUserAlias.Text.Trim() != "")
                    {
                        participantUri.Add("sip:" + txtUserAlias.Text);
                        LyncClient.GetAutomation().BeginStartConversation(
                            AutomationModalities.Video,
                            //AutomationModalities.Audio,
                            participantUri,
                            null,
                            (ar) =>
                            {
                                try
                                {
                                    ConversationWindow newWindow = LyncClient.GetAutomation().EndStartConversation(ar);
                                    newWindow.ShowFullScreen(0);
                                }
                                catch (OperationException oe) { MessageBox.Show("Operation exception on start conversation " + oe.Message); };
                            },
                            null);
                    }
                }
                else if(response.Contains(txtCapCode.Text))
                {
                    if (webcam1.InvokeRequired == true)
                    {
                        Invoke(new MethodInvoker(delegate()
                        {
                            webcam1.TimeToCapture_milliseconds = FrameNumber;
                            webcam1.Start(0);
                            bCapture = true;
                        }));
                    }                    
                    
                    //imgCapture.Image = imgVideo.Image;
                }

            }

        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            btClient.Close();
            btnConnect.Enabled = false;
            btnScan.Enabled = true;
        }

        private void btnPostFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

           
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var ARGBBuffer = FileToByteArray(openFileDialog1.FileName);

            ImageService.ImageInfo imInfo = new ImageService.ImageInfo();
            imInfo.ARGBBuffer= ARGBBuffer;

            ImageService.ImageServiceClient client = new ImageService.ImageServiceClient();
            client.UploadImage(imInfo);
        }

        public static void UploadFileToAzure()
        {
            if (File.Exists(@"c:\Temp\Capture.jpg"))
            {
                try
                {
                    var ARGBBuffer = FileToByteArray(@"c:\Temp\Capture.jpg");

                    ImageService.ImageInfo imInfo = new ImageService.ImageInfo();
                    imInfo.ARGBBuffer = ARGBBuffer;

                    ImageService.ImageServiceClient client = new ImageService.ImageServiceClient();
                    client.UploadImage(imInfo);
                }
                catch(Exception e)
                {
                    ;
                }
            }
        }

        public static byte[] FileToByteArray(string _FileName)
        {
            byte[] _Buffer = null;

            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // attach filestream to binary reader
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

                // get total byte length of the file
                long _TotalBytes = new System.IO.FileInfo(_FileName).Length;

                // read entire file into buffer
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

                // close file reader
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            return _Buffer;
        }

        private void txtBTMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        //WebCam webcam;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\temp"))
                Directory.CreateDirectory("C:\\temp");
            //webcam = new WebCam();
            InitializeWebCam(ref imgVideo);
        }

        private WebCamCapture webcam1;
        private System.Windows.Forms.PictureBox _FrameImage;
        private int FrameNumber = 30;
        public static Boolean bCapture = false;
        public void InitializeWebCam(ref System.Windows.Forms.PictureBox ImageControl)
        {
            webcam1 = new WebCamCapture();
            webcam1.FrameNumber = ((ulong)(0ul));
            webcam1.TimeToCapture_milliseconds = FrameNumber;
            webcam1.ImageCaptured += webcam1_ImageCaptured;
            //webcam1.ImageCaptured += new WebCamCapture.WebCamEventHandler(webcam_ImageCaptured);
            _FrameImage = ImageControl;

            
            webcam1.TimeToCapture_milliseconds = FrameNumber;
            webcam1.Start(0);
            bCapture = true;
            
        }

        void webcam1_ImageCaptured(object source, WebcamEventArgs e)
        {
            _FrameImage.Image = e.WebCamImage;
            
            if (bCapture == true)
            {
                imgCapture.Image = imgVideo.Image;
                bCapture = false;
                SaveImageCapture(imgCapture.Image);
                webcam1.Stop();
                //Azure
                Form1.UploadFileToAzure();

            }
        }

        
        public static void SaveImageCapture(System.Drawing.Image image)
        {
            string filename = "c:\\temp\\capture.jpg";
            FileStream fstream = new FileStream(filename, FileMode.Create);
            image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            fstream.Close();
        }

        private void imgVideo_Click(object sender, EventArgs e)
        {

        }

        private void imgCapture_Click(object sender, EventArgs e)
        {

        }
    }

}
