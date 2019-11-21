using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_InkCanvas
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            DrawingAttributes drawingAttributes = new DrawingAttributes
            {
                Color = Colors.Red,
                Width = 2,
                Height = 2,
                StylusTip = StylusTip.Rectangle,
                FitToCurve = true,
                IsHighlighter = false,
                IgnorePressure = true,

            };
            inkCanvasMeasure.DefaultDrawingAttributes = drawingAttributes;

            viewModel = new ViewModel
            {
                MeaInfo = "测试······",
            };

            DataContext = viewModel;
        }

        private void InkCanvasMeasure_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void InkCanvasMeasure_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg)|*.jpg|Image Files (*.png)|*.png|Image Files (*.bmp)|*.bmp",
                Title = "Open Image File"
            };
            if (openDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(openDialog.FileName, UriKind.RelativeOrAbsolute);
                image.EndInit();
                imgMeasure.Source = image;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).Content.ToString() == "绘制墨迹")
            {
                inkCanvasMeasure.EditingMode = InkCanvasEditingMode.Ink;
            }

            else if ((sender as RadioButton).Content.ToString() == "按点擦除")
            {
                inkCanvasMeasure.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }

            else if ((sender as RadioButton).Content.ToString() == "按线擦除")
            {
                inkCanvasMeasure.EditingMode = InkCanvasEditingMode.EraseByStroke;
            }

            else if ((sender as RadioButton).Content.ToString() == "选中墨迹")
            {
                inkCanvasMeasure.EditingMode = InkCanvasEditingMode.Select;
            }

            else if ((sender as RadioButton).Content.ToString() == "停止操作")
            {
                inkCanvasMeasure.EditingMode = InkCanvasEditingMode.None;
            }
        }

        private void SaveInkCanvas_Click(object sender, RoutedEventArgs e)
        {
            FileStream fileStream = new FileStream("inkCanvas.isf", FileMode.Create, FileAccess.ReadWrite);
            inkCanvasMeasure.Strokes.Save(fileStream);
            fileStream.Close();
        }

        private void LoadInkCanvas_Click(object sender, RoutedEventArgs e)
        {
            FileStream fileStream = new FileStream("inkCanvas.isf", FileMode.Open, FileAccess.Read);
            inkCanvasMeasure.Strokes = new StrokeCollection(fileStream);
            fileStream.Close();
        }

        private void CopyInkCanvas_Click(object sender, RoutedEventArgs e)
        {
            inkCanvasMeasure.CopySelection();
        }
        private void PasteInkCanvas_Click(object sender, RoutedEventArgs e)
        {
            inkCanvasMeasure.Paste();
        }
    }
}