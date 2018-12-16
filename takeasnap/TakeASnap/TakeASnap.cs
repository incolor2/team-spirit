using Amazon.S3;
using Amazon.S3.Model;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TakeASnap
{
    public partial class TakeASnap : Form
    {
        Capture _capture;
        CascadeClassifier _cascadeClassifierFace;
        CascadeClassifier _cascadeClassifierEyes;
        int numberOfFaces = 0;
        int fps = 0;
        long tempSec = 0;
        int scanTime = 5;
        List<long> frameList = new List<long>(10);

        DateTime runtime = new DateTime();

        Stopwatch stopWatch = new Stopwatch();

        public TakeASnap()
        {
            InitializeComponent();
        }

        private void TakeASnap_Load(object sender, EventArgs e)
        {
            FindFacesViewPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            _capture = new Capture();
            _capture.SetCaptureProperty(CapProp.FrameWidth, 1280);
            _capture.SetCaptureProperty(CapProp.FrameHeight, 720);

            string path = Directory.GetCurrentDirectory();
            string fileFace = "haarcascade_frontalface_default.xml";
            string fileEyes = "haarcascade_eye.xml";

            _cascadeClassifierFace = new CascadeClassifier($"{path}\\data\\haarcascades\\{fileFace}");
            _cascadeClassifierEyes = new CascadeClassifier($"{path}\\data\\haarcascades\\{fileEyes}");
            
            runtime = DateTime.Now;
            stopWatch.Start();

        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            Stopwatch fr = new Stopwatch();
            fr.Start();

            var faces = FindFaces();

            //Calculate frame info
            long sec = stopWatch.ElapsedMilliseconds / 1000;

            if (chkSendToS3.Checked)
            {                
                if (DateTime.Now > runtime)
                {
                    if (faces != null)
                    {
                        Console.WriteLine("Send image to s3");

                        runtime.AddSeconds(10);                        

                        //Send frame to s3
                        UploadImageToS3Async(faces);
                    }

                }
            }
            fr.Stop();

            var avgFps = CalculateFps(fr.ElapsedMilliseconds);
            fps++;

            lblFps.Text = avgFps.ToString();
            lblTime.Text = sec.ToString();
            lblTotal.Text = fps.ToString();

        }

        private int CalculateFps(long elapsedMilliseconds)
        {
            var renderTime = 1000 / elapsedMilliseconds;
            frameList.Add(renderTime);

            return (int)frameList.Skip(Math.Max(0, frameList.Count() - 15)).Average();

        }

        private async void UploadImageToS3Async(Image<Bgr, Byte> image)
        {
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var path = $"{Directory.GetCurrentDirectory()}/image-cache/{fileName}";
            image.Save(path);

            IAmazonS3 client;

            client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = "cu-bucket-2",
                Key = $"detect/{fileName}",
                FilePath = path
            };

            PutObjectResponse response = await client.PutObjectAsync(request);

        }

        private Image<Bgr, Byte> FindFaces()
        {
            Image<Bgr, Byte> nextFrameCopy = null;

            using (Image<Bgr, Byte> nextFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (chkDetectedFaces.Checked)
                {
                    if (nextFrame != null)
                    {
                        nextFrameCopy = nextFrame.Copy();
                        var grayframe = nextFrame.Convert<Gray, byte>();

                        //Find faces
                        var faces = _cascadeClassifierFace.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
                        foreach (var face in faces)
                        {
                            nextFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them

                        }

                        //Find eyes
                        var eyes = _cascadeClassifierEyes.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual eyes detection happens here
                        foreach (var eye in eyes)
                        {
                            nextFrame.Draw(eye, new Bgr(Color.Yellow), 2); //the detected face(s) is highlighted here using a box that is drawn around it/them

                        }

                        if (faces.Length < 1)
                        {
                            nextFrameCopy = null;
                        }

                    }
                }

                FindFacesViewPictureBox.Image = nextFrame.ToBitmap();

            }

            return nextFrameCopy;
        }

    }
}
