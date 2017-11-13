using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SubImageRecorder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rect = RectDragCanvas.TakeRectSnap();
            var bmp = ScreenCaptureTools.GetSubScreenShot((int)rect.X - 7, (int)rect.Y - 7, (int)rect.Width, (int)rect.Height);
            img1.Source = imageSourceForImageControl(bmp);
            img1.Height = bmp.Height;
            img1.Width = bmp.Width;
            ScreenCaptureTools.CaptureScreen(rect.X - 7, rect.Y - 7, rect.Width, rect.Height, @"C:\subRecs\im.png");
        }

        public ImageSource imageSourceForImageControl(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            return bi;

        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var bmp = ScreenCaptureTools.GetSubScreenShot(10, 10, 100, 100);
            img1.Source = imageSourceForImageControl(bmp);
        }

    }
}
