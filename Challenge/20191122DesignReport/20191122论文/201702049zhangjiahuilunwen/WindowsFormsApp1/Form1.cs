using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /*
         *设置当前图片空间中显示的图片
         *如果是 timg.jpg   flag的值为FALSE
         *如果是 01.jpg   flag的值为true
         */
        bool flag = false;

        public Form1()
        {
            InitializeComponent();
        }

        //窗体加载事件，在图片空间中设置图片
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\\Users\\HUAT_IAE\\d.jpg");
            //图片在图片控件中被拉伸或收缩，适合图片的大小
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //设置每隔1秒调用一次定时器Tick事件
            timer1.Interval = 1000;
            //启动定时器
            timer1.Start();
        }

        //触发定时器的事件，在该事件中切换图片
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
             *当flag的值为TRUE时将图片控件的Image属性切换到timg.jpg
             *否则将图片的Image属性切换到01.jpg
             */
            if (flag)
            {
                pictureBox1.Image = Image.FromFile(@"C:\\Users\\HUAT_IAE\\d.jpg");
                flag = false;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"C:\\Users\\HUAT_IAE\\d.jpg");
                flag = true;
            }
        }

        //“启动定时器”按钮的单击事件
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //“停止定时器”按钮的单击事件
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }

}
