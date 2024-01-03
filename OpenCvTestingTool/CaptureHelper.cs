using System.Runtime.InteropServices;

namespace OpenCvTestingTool
{
    class CaptureHelper
    {
        private Image GetScreenShot(Point location, Size size)
        {
            IntPtr windowHandle = Win32API.GetDesktopWindow();
            Image myImage = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(myImage);
            IntPtr destDeviceContext = g.GetHdc();
            IntPtr srcDeviceContext = Win32API.GetWindowDC(windowHandle);
            Win32API.BitBlt(destDeviceContext, 0, 0, size.Width, size.Height, srcDeviceContext, location.X, location.Y, Win32API.SRCCOPY);
            Win32API.ReleaseDC(windowHandle, srcDeviceContext);
            g.ReleaseHdc(destDeviceContext);
            return myImage;
        }
        public static Bitmap MakeSnapshot(IntPtr AppWndHandle, bool IsClientWnd, Win32API.WindowShowStyle nCmdShow)
        {
            if (AppWndHandle == IntPtr.Zero)
                return null;

            RECT appRect;
            if (IsClientWnd)
            {
                if (!Win32API.GetClientRect(AppWndHandle, out appRect))
                    return null;

                Point lt = new Point(appRect.Left, appRect.Top);
                Point rb = new Point(appRect.Right, appRect.Bottom);
                Win32API.ClientToScreen(AppWndHandle, ref lt);
                Win32API.ClientToScreen(AppWndHandle, ref rb);
                appRect.Left = lt.X;
                appRect.Top = lt.Y;
                appRect.Right = rb.X;
                appRect.Bottom = rb.Y;
            }
            else
            {
                if (!Win32API.GetWindowRect(AppWndHandle, out appRect))
                    return null;
            }

            // Intersect with the Desktop rectangle and get what's visible
            IntPtr DesktopHandle = Win32API.GetDesktopWindow();
            RECT desktopRect;
            Win32API.GetWindowRect(DesktopHandle, out desktopRect);
            RECT visibleRect;
            if (!Win32API.IntersectRect(out visibleRect, ref desktopRect, ref appRect))
                return null;

            int Width = visibleRect.Width;
            int Height = visibleRect.Height;

            IntPtr hdcFrom = IntPtr.Zero;
            IntPtr hdcTo = IntPtr.Zero;
            IntPtr hBitmap = IntPtr.Zero;

            try
            {
                hdcFrom = IsClientWnd ? Win32API.GetDC(AppWndHandle) : Win32API.GetWindowDC(AppWndHandle);
                hdcTo = Win32API.CreateCompatibleDC(hdcFrom);
                hBitmap = Win32API.CreateCompatibleBitmap(hdcFrom, Width, Height);

                if (hBitmap == IntPtr.Zero)
                    return null;

                int x = appRect.Left < 0 ? -appRect.Left : 0;
                int y = appRect.Top < 0 ? -appRect.Top : 0;

                IntPtr hLocalBitmap = Win32API.SelectObject(hdcTo, hBitmap);
                Win32API.BitBlt(hdcTo, 0, 0, Width, Height, hdcFrom, x, y, Win32API.SRCCOPY);
                Win32API.SelectObject(hdcTo, hLocalBitmap);

                return System.Drawing.Image.FromHbitmap(hBitmap);
            }
            finally
            {
                if (hdcFrom != IntPtr.Zero)
                    Win32API.ReleaseDC(AppWndHandle, hdcFrom);
                if (hdcTo != IntPtr.Zero)
                    Win32API.DeleteDC(hdcTo);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32API.DeleteObject(hBitmap);
                    GC.Collect();
                }
            }
        }


    }
}
