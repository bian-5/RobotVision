using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics.Tensors;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ML.OnnxRuntime;
using OpenCvSharp;

namespace yoloaforge
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private const int imageSize = 224;

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            pictureBox1.Image = null;
            pictureBox1.Refresh();
            string Img_Name = "F:\\Microsoft Visual Studio\\project\\yoloaforge\\yoloaforge\\"  +"a.jpg";
            Mat source = new Mat(Img_Name);
            Bitmap bit = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(source);
            pictureBox1.Image = bit;
            Bitmap bitmap = new Bitmap(pictureBox1.Image, imageSize, imageSize);

            float[] imageArray = new float[imageSize * imageSize * 3];

            // 按照先行后列的方式依次取出图片的每个像素值
            for (int y = 0; y < imageSize; y++)
            {
                for (int x = 0; x < imageSize; x++)
                {
                    var color = bitmap.GetPixel(x, y);

                    // 使用Netron查看模型的输入发现
                    // 需要依次放置224 *224的蓝色分量、224*224的绿色分量、224*224的红色分量
                    imageArray[y * imageSize + x] = color.B;
                    imageArray[y * imageSize + x + 1 * imageSize * imageSize] = color.G;
                    imageArray[y * imageSize + x + 2 * imageSize * imageSize] = color.R;
                }
            }

            string modelPath = AppDomain.CurrentDomain.BaseDirectory + "BearModel.onnx";

            using (var session = new InferenceSession(modelPath))
            {
                var container = new List<NamedOnnxValue>();

                // 用Netron看到需要的输入类型是float32[None,3,224,224]
                // 第一维None表示可以传入多张图片进行推理
                // 这里只使用一张图片，所以使用的输入数据尺寸为[1, 3, 224, 224]
                var shape = new int[] { 1, 3, imageSize, imageSize };
                var tensor = new DenseTensor<float>(imageArray, shape);

                // 支持多个输入，对于mnist模型，只需要一个输入，输入的名称是data
                container.Add(NamedOnnxValue.CreateFromTensor<float>("data", tensor));

                // 推理
                var results = session.Run(container);

                // 输出结果有两个，classLabel和loss，这里只关心classLabel
                var label = results.FirstOrDefault(item => item.Name == "classLabel")? // 取出名为classLabel的输出
                    .AsTensor<string>()?
                    .FirstOrDefault(); // 支持多张图片同时推理，这里只推理了一张，取第一个结果值

                // 显示在控件中
                label1.Text = label;
            }
        }
    }
}
