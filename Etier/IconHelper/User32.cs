namespace Etier.IconHelper
{
    using System;
    using System.Runtime.InteropServices;

    public class User32
    {
        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
    }
}

