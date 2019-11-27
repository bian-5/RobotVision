using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace 手写识别
{
    public partial class Form1 : Form
    {
        InkCollector ic;
        RecognizerContext rct;
        string FullCACText;

        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        
        private void Form1_Load(object sender, EventArgs e)
        {
            ic = new InkCollector(ink_here.Handle);
            ic.Stroke += new InkCollectorStrokeEventHandler(ic_Stroke);
            ic.Enabled = true; 
            ink_();
            this.rct.RecognitionWithAlternates += new RecognizerContextRecognitionWithAlternatesEventHandler(rct_RecognitionWithAlternates);
            
            rct.Strokes = ic.Ink.Strokes;




           
        }

        void rct_RecognitionWithAlternates(object sender, RecognizerContextRecognitionWithAlternatesEventArgs e)
        {
            string ResultString = "";
            RecognitionAlternates alts;
            if (e.RecognitionStatus == RecognitionStatus.NoError)
            {
                alts = e.Result.GetAlternatesFromSelection();
                foreach (RecognitionAlternate alt in alts)
                {
                    ResultString = ResultString + alt.ToString() + " ";
                }
            }
            FullCACText = ResultString.Trim();
            Control.CheckForIllegalCrossThreadCalls = false;
            textBox1.Text = FullCACText;
            Control.CheckForIllegalCrossThreadCalls = true;
        }

        void ic_Stroke(object sender, InkCollectorStrokeEventArgs e)
        {
            rct.StopBackgroundRecognition();
            rct.Strokes.Add(e.Stroke);
            rct.CharacterAutoCompletion = RecognizerCharacterAutoCompletionMode.Full;
            rct.BackgroundRecognizeWithAlternates(0);
           
        }

        private void ink_()
        {
            Recognizers recos = new Recognizers();
            Recognizer chineseReco = recos.GetDefaultRecognizer();
            rct = chineseReco.CreateRecognizerContext();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.ShowDialog();
            ic.DefaultDrawingAttributes.Color = colorDialog1.Color;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ic.CollectingInk)
            {
                Strokes strokesToDelete = ic.Ink.Strokes;                
                rct.StopBackgroundRecognition();
                ic.Ink.DeleteStrokes(strokesToDelete);
                rct.Strokes = ic.Ink.Strokes;
                ic.Ink.DeleteStrokes();//清除手写区域笔画;
                ink_here.Refresh();//刷新手写区域
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ink ink = ic.Ink;
            string str = ic.Ink.Strokes.ToString();
          
            textBox1.SelectedText = ic.Ink.Strokes.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.SendWait("{s}{h}{i}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.SendKeys.SendWait("{" + e.KeyChar + "}");
        }
    }
}