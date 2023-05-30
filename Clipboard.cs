using System.Runtime.InteropServices;
using System.Text;

namespace EdHouse_Ukol_Vcely;

static class Clipboard
{
    [DllImport("user32.dll")]
    public static extern IntPtr GetClipboardData(uint uFormat);

    [DllImport("user32.dll")]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll")]
    public static extern bool CloseClipboard();

    [DllImport("user32.dll")]
    public static extern bool EmptyClipboard();

    [DllImport("user32.dll")]
    public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GlobalLock(IntPtr hMem);

    [DllImport("kernel32.dll")]
    public static extern bool GlobalUnlock(IntPtr hMem);

    public static void SetClipboardText(string text)
    {
        OpenClipboard(IntPtr.Zero);
        EmptyClipboard();

        IntPtr hMem = IntPtr.Zero;
        try
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text + "\0");

            hMem = Marshal.AllocHGlobal(bytes.Length);
            IntPtr pMem = GlobalLock(hMem);
            Marshal.Copy(bytes, 0, pMem, bytes.Length);
            GlobalUnlock(hMem);

            SetClipboardData(13 /* CF_UNICODETEXT */, hMem);
        }
        finally
        {
            if (hMem != IntPtr.Zero)
                Marshal.FreeHGlobal(hMem);

            CloseClipboard();
        }
    }
}