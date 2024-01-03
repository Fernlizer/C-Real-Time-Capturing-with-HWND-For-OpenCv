using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

public class TextOverlay
{
    private const int WM_PAINT = 0xF;

    [DllImport("user32.dll")]
    private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll")]
    private static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int cchString);

    [DllImport("gdi32.dll")]
    private static extern int SetBkMode(IntPtr hdc, int iBkMode);

    [DllImport("gdi32.dll")]
    private static extern bool SetTextColor(IntPtr hdc, int crColor);

    public static void ShowTextOverlay(IntPtr hWnd, string text, int x, int y, Color color, Font font)
    {
        try
        {
            // Get the device context of the program's window
            IntPtr hDC = GetDC(hWnd);

            // Set the text color and background mode
            SetTextColor(hDC, ColorTranslator.ToWin32(color));
            SetBkMode(hDC, 1); // TRANSPARENT background mode

            // Create a font object
            IntPtr hFont = font.ToHfont();
            IntPtr prevFont = SelectObject(hDC, hFont);

            // Draw the text on the program's screen
            TextOut(hDC, x, y, text, text.Length);

            // Trigger a repaint of the program's window
            RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, WM_PAINT);

            // Cleanup resources
            SelectObject(hDC, prevFont);
            DeleteObject(hFont);
            ReleaseDC(hWnd, hDC);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to show text overlay: " + ex.Message);
        }
    }

    [DllImport("gdi32.dll")]
    private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

    [DllImport("gdi32.dll")]
    private static extern bool DeleteObject(IntPtr hObject);
}


