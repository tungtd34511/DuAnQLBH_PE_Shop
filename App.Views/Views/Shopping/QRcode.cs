using AForge.Video.DirectShow;
using AForge.Video;
using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;

namespace App.Views.Views.Shopping
{
    public partial class QRcode : Form
    {

        private FilterInfoCollection _filterInfoCollection;
        private VideoCaptureDevice _videoCaptureDevice;
        public QRcode()
        {
            InitializeComponent();
            
        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            picVideo.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        BarcodeReader Reader = new BarcodeReader();
        private Result result;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
                if (picVideo.Image != null)
                {
                    result = Reader.Decode((Bitmap)picVideo.Image);
                    if(result != null)
                    {
                        txtQR.Text = result.ToString();
                         _videoCaptureDevice.Start();
                        timer1.Stop();
                }
                }
        }

        private void QRcode_Load(object sender, EventArgs e)
        {
            _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in _filterInfoCollection)
            {
                combCam.Items.Add(Device.Name);
            }
            combCam.SelectedIndex = 0;
            timer1.Start();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[combCam.SelectedIndex].MonikerString);
            _videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
            _videoCaptureDevice.Start();
        }

        private void txtQR_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(txtQR.Text);
        }

        private void QRcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                timer1.Stop();
            _videoCaptureDevice.SignalToStop();
        }
    }
}
