using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SubImageRecorder
{
    /// <summary>
    /// Interaction logic for RectDragCanvas.xaml
    /// </summary>
    public partial class RectDragCanvas : Window
    {
        public double x = 0;
        public double y = 0;
        public double width;
        public double height;
        public bool isMouseDown = false;


        public RectDragCanvas()
        {
            InitializeComponent();
        }

        public static Rect TakeRectSnap()
        {
            RectDragCanvas win = new RectDragCanvas();
            win.WindowState = WindowState.Maximized;
            win.ShowDialog();
            return new Rect(win.x, win.y, win.width, win.height);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            x = e.GetPosition(null).X;
            y = e.GetPosition(null).Y;
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.isMouseDown)
            {
                double curx = e.GetPosition(null).X;
                double cury = e.GetPosition(null).Y;

                System.Windows.Shapes.Rectangle r = new System.Windows.Shapes.Rectangle();
                SolidColorBrush brush = new SolidColorBrush(Colors.White);
                r.Stroke = brush;
                r.Fill = brush;
                r.StrokeThickness = 1;
                r.Width = Math.Abs(curx - x);
                r.Height = Math.Abs(cury - y);
                cnv.Children.Clear();
                cnv.Children.Add(r);
                Canvas.SetLeft(r, x);
                Canvas.SetTop(r, y);
                if (e.LeftButton == MouseButtonState.Released)
                {
                    cnv.Children.Clear();
                    width = e.GetPosition(null).X - x;
                    height = e.GetPosition(null).Y - y;
                    //this.CaptureScreen(x, y, width, height);
                    //MessageBox.Show(string.Format("Captured: {0} x {1}", width, height));
                    //this.x = this.y = 0;
                    this.isMouseDown = false;
                    this.Close();
                }
            }
        }


    }
}
