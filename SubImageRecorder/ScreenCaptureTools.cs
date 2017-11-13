using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubImageRecorder
{
    class ScreenCaptureTools
    {
        internal static Bitmap GetSubScreenShot(int x, int y, int width, int height)
        {
            Screen scr = Screen.AllScreens[0];
            Bitmap printscreen = new Bitmap
            (width, height);

            Graphics graphics = Graphics.FromImage(printscreen as System.Drawing.Image);
            graphics.CopyFromScreen(x, y, 0, 0, printscreen.Size, CopyPixelOperation.SourceCopy);
            return printscreen;
        }

        public static void CaptureScreen(double x, double y, double width, double height, string fpath)
        {
            int ix, iy, iw, ih;
            ix = Convert.ToInt32(x);
            iy = Convert.ToInt32(y);
            iw = Convert.ToInt32(width);
            ih = Convert.ToInt32(height);
            Bitmap image = new Bitmap(iw, ih, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(ix, iy, 0, 0, new System.Drawing.Size(iw, ih), CopyPixelOperation.SourceCopy);
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.DefaultExt = "png";
            //dlg.Filter = "Png Files|*.png";
            //DialogResult res = dlg.ShowDialog();
            //if (res == System.Windows.Forms.DialogResult.OK)
            image.Save(fpath, ImageFormat.Png);
        }


    }
}
