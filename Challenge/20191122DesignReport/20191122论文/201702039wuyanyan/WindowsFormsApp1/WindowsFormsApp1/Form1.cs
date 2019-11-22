using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;//用于优化绘制的结果
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics.Tensors;
using Microsoft.ML.OnnxRuntime;
using System.Media;
using System.IO;

namespace Mnistwf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> listsongs = new List<string>();

        private Bitmap digitImage;//用来保存手写数字
        private Point startPoint;//用于绘制线段，作为线段的初始端点坐标
        //private Mnist model;//用于识别手写数字
        private const int MnistImageSize = 28;//Mnist模型所需的输入图片大小

        private void Form1_Load(object sender, EventArgs e)
        {
            //当窗口加载时，绘制一个白色方框
            //model = new Mnist();
            digitImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(digitImage);
            g.Clear(Color.White);
            pictureBox1.Image = digitImage;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //当鼠标左键被按下时，记录下需要绘制的线段的起始坐标
            startPoint = (e.Button == MouseButtons.Left) ? e.Location : startPoint;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //当鼠标在移动，且当前处于绘制状态时，根据鼠标的实时位置与记录的起始坐标绘制线段，同时更新需要绘制的线段的起始坐标
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(digitImage);
                Pen myPen = new Pen(Color.Pink, 20);
                myPen.StartCap = LineCap.Round;
                myPen.EndCap = LineCap.Round;
                g.DrawLine(myPen, startPoint, e.Location);
                pictureBox1.Image = digitImage;
                g.Dispose();
                startPoint = e.Location;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //当点击清除时，重新绘制一个白色方框，同时清除label1显示的文本
            digitImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(digitImage);
            g.Clear(Color.White);
            pictureBox1.Image = digitImage;
            label1.Text = "";
        }
        
        
        SoundPlayer sp = new SoundPlayer();
       
        

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = listsongs[listBox1.SelectedIndex];
            sp.Play();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //当鼠标左键释放时
            //开始处理图片进行推理
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

                    // Display the results
                    label1.Text = maxIndex.ToString();


                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "请选择音乐文件";      //打开对话框的标题
                ofd.InitialDirectory = @"C:\Users\HUAT_IAE\source\repos\WindowsFormsApp1\WindowsFormsApp1\1\music";    //设置打开对话框的初始设置目录
                ofd.Multiselect = true; //设置多选
                ofd.Filter = @"音乐文件|*.mp3||*.wav|所有文件|*.*";    //设置文件格式筛选
                ofd.ShowDialog();   //显示打开对话框
                string[] pa_th = ofd.FileNames;       //获得在文件夹中选择的所有文件的全路径
                for (int i = 0; i < pa_th.Length; i++)
                {
                    listBox1.Items.Add(Path.GetFileName(pa_th[i]));  //将音乐文件的文件名加载到listBox中
                    listsongs.Add(pa_th[i]);    //将音乐文件的全路径存储到泛型集合中
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                int index = listBox1.SelectedIndex; //获得当前选中歌曲的索引
                index++;

                if (index == listBox1.Items.Count)
                {
                    index = 0;
                }
                listBox1.SelectedIndex = index; //将改变后的索引重新赋值给我当前选中项的索引
                sp.SoundLocation = listsongs[index];
                sp.Play();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
                int index = listBox1.SelectedIndex; //获得当前选中歌曲的索引
                index--;

                if (index < 0)
                {
                    index = listBox1.Items.Count - 1;
                }
                listBox1.SelectedIndex = index; //将改变后的索引重新赋值给我当前选中项的索引
                sp.SoundLocation = listsongs[index];
                sp.Play();
            
        }
    }
}