using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Helper
{
    class ScreenshotHelper
    {
        public static Bitmap TakeScreenshot(int screen)
        {
            Rectangle totalSize = Rectangle.Empty;

            /*
            foreach (Screen s in Screen.AllScreens)
                totalSize = Rectangle.Union(totalSize, s.Bounds);
                */


            totalSize = Screen.AllScreens[screen].Bounds;

            Bitmap screenShotBMP = new Bitmap(totalSize.Width, totalSize.Height, PixelFormat.Format32bppArgb);

            Graphics screenShotGraphics = Graphics.FromImage(screenShotBMP);

            screenShotGraphics.CopyFromScreen(totalSize.X, totalSize.Y, 0, 0, totalSize.Size,
                CopyPixelOperation.SourceCopy);

            screenShotGraphics.Dispose();

            return screenShotBMP;
        }
    }
}
