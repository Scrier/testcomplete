using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;


class Screen
{
    static private string m_FullPath = "";
    static private int m_ImageCount = 0;

    private class User32
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hDC, uint nFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }

    private class GDI32
    {
        public const int SRCCOPY = 0x00CC0020;

        [DllImport("GDI32.dll")]
        public static extern void BitBlt(IntPtr hDCDest, int x, int y, int w, int h, IntPtr hDCSrc, int xSrc, int ySrc, int dwRop);

        [DllImport("GDI32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        [DllImport("GDI32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("GDI32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);

        [DllImport("GDI32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("GDI32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
    }

    static private void CropRect(ref User32.RECT windowRect, int x, int y, int w, int h)
    {
        windowRect.left = (x > 0) ? Math.Min(windowRect.right, windowRect.left + x) : windowRect.left;
        windowRect.right = (w > 0) ? Math.Min(windowRect.right, windowRect.left + w) : windowRect.right;
        windowRect.top = (y > 0) ? Math.Min(windowRect.bottom, windowRect.top + y) : windowRect.top;
        windowRect.bottom = (h > 0) ? Math.Min(windowRect.bottom, windowRect.top + h) : windowRect.bottom;
    }

    static private Image CaptureWindowRegion(IntPtr hWnd, int x, int y, int w, int h)
    {
        IntPtr hdcSrc = User32.GetWindowDC(hWnd);

        User32.RECT windowRect = new User32.RECT();
        User32.GetWindowRect(hWnd, ref windowRect);

        int originalwidth = windowRect.right - windowRect.left;
        int originalheight = windowRect.bottom - windowRect.top;

        CropRect(ref windowRect, x, y, w, h);

        int width = windowRect.right - windowRect.left;
        int height = windowRect.bottom - windowRect.top;

        IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
        IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, originalwidth, originalheight);

        IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
        
        User32.PrintWindow(hWnd, hdcDest, 0);

        IntPtr hdcDest2 = GDI32.CreateCompatibleDC(hdcDest);
        IntPtr hBitmap2 = GDI32.CreateCompatibleBitmap(hdcDest, width, height);
        IntPtr hOld2 = GDI32.SelectObject(hdcDest2, hBitmap2);

        GDI32.BitBlt(hdcDest2, 0, 0, width, height, hdcDest, x, y, GDI32.SRCCOPY);  
        
        GDI32.SelectObject(hdcDest, hOld);
        GDI32.SelectObject(hdcDest2, hOld2);
       
        GDI32.DeleteDC(hdcDest);
        GDI32.DeleteDC(hdcDest2);
        User32.ReleaseDC(hWnd, hdcSrc);

        Image img = Image.FromHbitmap(hBitmap2);
        
        GDI32.DeleteObject(hBitmap);
        GDI32.DeleteObject(hBitmap2);

        return img;
    }

    static private Image CaptureWindow(IntPtr hWnd)
    {
      IntPtr hdcSrc = User32.GetWindowDC(hWnd);

      User32.RECT windowRect = new User32.RECT();
      User32.GetWindowRect(hWnd, ref windowRect);

      int width = windowRect.right - windowRect.left;
      int height = windowRect.bottom - windowRect.top;

      IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
      IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);

      IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);

      User32.PrintWindow(hWnd, hdcDest, 0);
      GDI32.SelectObject(hdcDest, hOld);
      
      GDI32.DeleteDC(hdcDest);
      User32.ReleaseDC(hWnd, hdcSrc);
      Image img = Image.FromHbitmap(hBitmap);

      GDI32.DeleteObject(hBitmap);
      
      return img;
    }

    static public string LogWindowRegion(string windowClass, string windowName, int x, int y, int w, int h)
    {
      Image img = CaptureWindowRegion(User32.FindWindow(windowClass, windowName), x, y, w, h);
      String filename = Path.Combine(m_FullPath, "Screenshot_" + m_ImageCount + ".png");
      img.Save(filename, ImageFormat.Png);
      img.Dispose();
      ++m_ImageCount;
      return filename;
    }

    static public string LogWindow(string windowClass, string windowName)
    {
      Image img = CaptureWindow(User32.FindWindow(windowClass, windowName));
      String filename = Path.Combine(m_FullPath, "Screenshot_" + m_ImageCount + ".png");
      img.Save(filename, ImageFormat.Png);
      img.Dispose();
      ++m_ImageCount;
      return filename;
    }

    static public Image LogWindowToMemory(string windowClass, string windowName)
    {
      return CaptureWindow(User32.FindWindow(windowClass, windowName));
    }

    static public Image LogWindowRegionToMemory(string windowClass, string windowName, int x, int y, int w, int h)
    {
      return CaptureWindowRegion(User32.FindWindow(windowClass, windowName), x, y, w, h);
    }

    static public void Init(string fullpath)
    {
        m_FullPath = fullpath;
        Directory.CreateDirectory(m_FullPath);
        m_ImageCount = 0;
    }
}

