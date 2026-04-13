namespace Etier.IconHelper
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class IconReader
    {
        public static Icon GetFileIcon(string name, IconSize size, bool linkOverlay)
        {
            Shell32.SHFILEINFO psfi = new Shell32.SHFILEINFO();
            uint uFlags = 0x110;
            if (linkOverlay)
            {
                uFlags += 0x8000;
            }
            if (IconSize.Small == size)
            {
                uFlags++;
            }
            else
            {
                uFlags = uFlags;
            }
            Shell32.SHGetFileInfo(name, 0x80, ref psfi, (uint) Marshal.SizeOf(psfi), uFlags);
            Icon icon = (Icon) Icon.FromHandle(psfi.hIcon).Clone();
            User32.DestroyIcon(psfi.hIcon);
            return icon;
        }

        public static Icon GetFolderIcon(IconSize size, FolderType folderType)
        {
            uint uFlags = 0x110;
            if (folderType == FolderType.Open)
            {
                uFlags += 2;
            }
            if (IconSize.Small == size)
            {
                uFlags++;
            }
            else
            {
                uFlags = uFlags;
            }
            Shell32.SHFILEINFO psfi = new Shell32.SHFILEINFO();
            Shell32.SHGetFileInfo(null, 0x10, ref psfi, (uint) Marshal.SizeOf(psfi), uFlags);
            Icon.FromHandle(psfi.hIcon);
            Icon icon = (Icon) Icon.FromHandle(psfi.hIcon).Clone();
            User32.DestroyIcon(psfi.hIcon);
            return icon;
        }

        public enum FolderType
        {
            Open,
            Closed
        }

        public enum IconSize
        {
            Large,
            Small
        }
    }
}

