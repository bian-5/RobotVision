using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace yoloaforge
{
    public partial class Form4 : Form
    {
            Mat srcImage = Cv2.ImRead("F:\\Microsoft Visual Studio\\project\\yoloaforge\\yoloaforge\\a.jpg");
        public Form4()
        {
            InitializeComponent();
            
            Bitmap bit = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(srcImage);
            pictureBox1.Image = bit;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Mat src_Mat = new Mat("F:\\Microsoft Visual Studio\\project\\yoloaforge\\yoloaforge\\a.jpg", ImreadModes.AnyColor | ImreadModes.AnyDepth);
            Mat dst_Mat = new Mat();

            #region 边缘处理四个类型
            //定义四个方向像素,边缘宽度相对于源图像的 0.05
            int top = (int)(0.05 * src_Mat.Rows);
            int botton = (int)(0.05 * src_Mat.Rows);
            int left = (int)(0.05 * src_Mat.Cols);
            int right = (int)(0.05 * src_Mat.Cols);

            //定义随机数
            RNG r = new RNG(12345);
            //int borderType =(int) BorderTypes.Default;
            BorderTypes borderType = new BorderTypes();
            borderType = BorderTypes.Default;
            //Cv2.ImShow("src", src);
            int ch = 0;
            while (true)
            {
                ch = Cv2.WaitKey(500);
                if ((char)ch == 27)// ESC建退出
                {
                    break;
                }
                else if ((char)ch == 'r')
                {
                    borderType = BorderTypes.Replicate;//填充边缘像素用已知的边缘像素值
                }
                else if ((char)ch == 'w')
                {
                    borderType = BorderTypes.Wrap;//用另外一边的像素来补偿填充
                }
                else if ((char)ch == 'c')
                {
                    borderType = BorderTypes.Constant;//填充边缘用指定像素值
                }

                else if ((char)ch == 'd')
                {
                    borderType = BorderTypes.Default;//默认边缘处理
                }

                Scalar color = new Scalar(r.Uniform(0, 255), r.Uniform(0, 255), r.Uniform(0, 255));

                Cv2.CopyMakeBorder(src_Mat, dst_Mat, top, botton, left, right, borderType, color);
                Window w = new Window("dst", WindowMode.Normal);
                Cv2.ImShow("dst", dst_Mat);
            }
            #endregion
            //Cv2.GaussianBlur(src, dst, new Size(5, 5), 5, 5, BorderTypes.Wrap);

            //using (new Window("dst", WindowMode.Normal, dst_Mat))
            //{
            //    Cv2.WaitKey(0);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Mat src = new Mat("F:\\Microsoft Visual Studio\\project\\yoloaforge\\yoloaforge\\a.jpg", ImreadModes.AnyColor | ImreadModes.AnyDepth))
            {
                //转为灰度图像
                Mat dst = new Mat();
                Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);

                //转为二值图像
                /*
                 * API AdaptiveThreshold:
                 * 参数：1：输入的灰度图像  '~' 符号是背景色取反
                 *      2：输出的二值化图像
                 *      3：二值化的最大值
                 *      4：自适应的方法（枚举类型，目前只有两个算法）
                 *      5：阀值类型（枚举类型，这里选择二进制）
                 *      6: 块大小
                 *      7: 常量 （可以是正数 0 负数）
                 */
                Mat binImage = new Mat();
                Cv2.AdaptiveThreshold(~dst, binImage, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 15, -2);

                int xSize = dst.Cols / 16; //宽
                int ySize = dst.Rows / 16; //高

                //定义结构元素 new Size(xSize, 1) 相当于横着的一条线:水平结构体 new Size(1, ySize) 相当于竖着的一条线：垂直结构体
                InputArray kernelX = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(xSize, 1), new OpenCvSharp.Point(-1, -1));
                InputArray kernelY = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(1, ySize), new OpenCvSharp.Point(-1, -1));

                Mat result = new Mat();
                ////腐蚀
                //Cv2.Erode(binImage, result, kernelY);
                ////膨胀
                //Cv2.Dilate(result, result, kernelY);

                //开操作代替 腐蚀和膨胀
                Cv2.MorphologyEx(binImage, result, MorphTypes.Open, kernelY);
                Cv2.Blur(result, result, new OpenCvSharp.Size(3, 3), new OpenCvSharp.Point(-1, -1)); //使用归一化框过滤器平滑图像
                Cv2.BitwiseNot(result, result); //背景变成白色（背景值取反）


                using (new Window("result", WindowMode.Normal, result))
                using (new Window("binImage", WindowMode.Normal, binImage))
                using (new Window("dst", WindowMode.Normal, dst))
                using (new Window("SRC", WindowMode.Normal, src))
                {
                    Cv2.WaitKey(0);
                }
            }
        }
    }
}
