using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics.Tensors;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace yoloaforge
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
        }
        private Bitmap digitImage;//用来保存手写数字
        private Point startPoint;//用于绘制线段，作为线段的初始端点坐标
        private const int MnistImageSize = 28;//Mnist模型所需的输入图片大小
        private Bitmap digitImage2;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = (e.Button == MouseButtons.Left) ? e.Location : startPoint;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(digitImage);
                Pen myPen = new Pen(Color.Black, 20);
                myPen.StartCap = LineCap.Round;
                myPen.EndCap = LineCap.Round;
                g.DrawLine(myPen, startPoint, e.Location);
                pictureBox1.Image = digitImage;
                g.Dispose();
                startPoint = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bitmap digitTmp = (Bitmap)digitImage.Clone();//复制digitImage
                                                             //调整图片大小为Mnist模型可接收的大小：28×28
                using (Graphics g = Graphics.FromImage(digitTmp))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(digitTmp, 0, 0, MnistImageSize, MnistImageSize);
                }

                //将图片转为灰阶图，并将图片的像素信息保存在list中
                float[] imageArray = new float[MnistImageSize * MnistImageSize];
                for (int y = 0; y < MnistImageSize; y++)
                {
                    for (int x = 0; x < MnistImageSize; x++)
                    {
                        var color = digitTmp.GetPixel(x, y);
                        var a = (float)(0.5 - (color.R + color.G + color.B) / (3.0 * 255));

                        imageArray[y * MnistImageSize + x] = a;

                    }
                }

                // 设置要加载的模型的路径，跟据需要改为你的模型名称
                string modelPath = AppDomain.CurrentDomain.BaseDirectory + "mnist.onnx";

                using (var session = new InferenceSession(modelPath))
                {
                    var inputMeta = session.InputMetadata;
                    var container = new List<NamedOnnxValue>();

                    // 用Netron看到需要的输入类型是float32[1, 1, 28, 28]
                    // 第一维None表示可以传入多张图片进行推理
                    // 这里只使用一张图片，所以使用的输入数据尺寸为[1, 1, 28, 28]
                    var shape = new int[] { 1, 1, MnistImageSize, MnistImageSize };
                    var tensor = new DenseTensor<float>(imageArray, shape);

                    // 支持多个输入，对于mnist模型，只需要一个输入，输入的名称是input3
                    container.Add(NamedOnnxValue.CreateFromTensor<float>("Input3", tensor));

                    // 推理
                    var results = session.Run(container);

                    // 输出结果: Plus214_Output_0
                    IList<float> imageList = results.FirstOrDefault(item => item.Name == "Plus214_Output_0").AsTensor<float>().ToList();

                    // Query to check for highest probability digit
                    var maxIndex = imageList.IndexOf(imageList.Max());

                    // Display the  results
                    label1.Text = maxIndex.ToString();


                }
            }
        }

       

        private void Form6_Load(object sender, EventArgs e)
        {
            digitImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(digitImage);
            g.Clear(Color.White);
            pictureBox1.Image = digitImage;
            digitImage2 = new Bitmap(pictureBox2.Width, pictureBox1.Height);
            Graphics g2 = Graphics.FromImage(digitImage2);
            g2.Clear(Color.White);
            pictureBox2.Image = digitImage2;
        }

        

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            digitImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(digitImage);
            g.Clear(Color.White);
            pictureBox1.Image = digitImage;
            label1.Text = "";
        }

        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            digitImage2 = new Bitmap(pictureBox2.Width, pictureBox1.Height);
            Graphics g2 = Graphics.FromImage(digitImage2);
            g2.Clear(Color.White);
            pictureBox2.Image = digitImage2;
            label2.Text = "";
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = (e.Button == MouseButtons.Left) ? e.Location : startPoint;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(digitImage2);
                Pen myPen = new Pen(Color.Black, 20);
                myPen.StartCap = LineCap.Round;
                myPen.EndCap = LineCap.Round;
                g.DrawLine(myPen, startPoint, e.Location);
                pictureBox2.Image = digitImage2;
                g.Dispose();
                startPoint = e.Location;
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bitmap digitTmp = (Bitmap)digitImage2.Clone();//复制digitImage
                                                             //调整图片大小为Mnist模型可接收的大小：28×28
                using (Graphics g = Graphics.FromImage(digitTmp))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(digitTmp, 0, 0, MnistImageSize, MnistImageSize);
                }

                //将图片转为灰阶图，并将图片的像素信息保存在list中
                float[] imageArray = new float[MnistImageSize * MnistImageSize];
                for (int y = 0; y < MnistImageSize; y++)
                {
                    for (int x = 0; x < MnistImageSize; x++)
                    {
                        var color = digitTmp.GetPixel(x, y);
                        var a = (float)(0.5 - (color.R + color.G + color.B) / (3.0 * 255));

                        imageArray[y * MnistImageSize + x] = a;

                    }
                }

                // 设置要加载的模型的路径，跟据需要改为你的模型名称
                string modelPath = AppDomain.CurrentDomain.BaseDirectory + "mnist.onnx";

                using (var session = new InferenceSession(modelPath))
                {
                    var inputMeta = session.InputMetadata;
                    var container = new List<NamedOnnxValue>();

                    // 用Netron看到需要的输入类型是float32[1, 1, 28, 28]
                    // 第一维None表示可以传入多张图片进行推理
                    // 这里只使用一张图片，所以使用的输入数据尺寸为[1, 1, 28, 28]
                    var shape = new int[] { 1, 1, MnistImageSize, MnistImageSize };
                    var tensor = new DenseTensor<float>(imageArray, shape);

                    // 支持多个输入，对于mnist模型，只需要一个输入，输入的名称是input3
                    container.Add(NamedOnnxValue.CreateFromTensor<float>("Input3", tensor));

                    // 推理
                    var results = session.Run(container);

                    // 输出结果: Plus214_Output_0
                    IList<float> imageList = results.FirstOrDefault(item => item.Name == "Plus214_Output_0").AsTensor<float>().ToList();

                    // Query to check for highest probability digit
                    var maxIndex = imageList.IndexOf(imageList.Max());

                    // Display the  results
                    label2.Text = maxIndex.ToString();


                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
         {
            label3.Text = "+";
            label4.Text = "=";
            label5.Text = (int.Parse(label1.Text) + int.Parse(label2.Text)).ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "-";
            label4.Text = "=";
            label5.Text = (int.Parse(label1.Text) - int.Parse(label2.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "*";
            label4.Text = "=";
            label5.Text = (int.Parse(label1.Text) * int.Parse(label2.Text)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "/";
            label4.Text = "=";
            label5.Text = (double.Parse(label1.Text) / double.Parse(label2.Text)).ToString();
        }
    }
}
