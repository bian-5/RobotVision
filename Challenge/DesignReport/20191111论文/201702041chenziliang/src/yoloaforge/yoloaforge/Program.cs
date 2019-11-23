using AforgeDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yoloaforge
{
    
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Form1 f1 = new Form1();
           // Form2 f2 = new Form2();
            Form3 f3 = new Form3();
            //Form4 f4 = new Form4();
            //Form6 f6 = new Form6();
            Application.Run(f3);
        }
    }
}
