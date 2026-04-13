namespace Etier.IconHelper
{
    using System;
    using System.Runtime.InteropServices;

    public class Shell32
    {
        public const uint BIF_BROWSEFORCOMPUTER = 0x1000;
        public const uint BIF_BROWSEFORPRINTER = 0x2000;
        public const uint BIF_BROWSEINCLUDEFILES = 0x4000;
        public const uint BIF_BROWSEINCLUDEURLS = 0x80;
        public const uint BIF_DONTGOBELOWDOMAIN = 2;
        public const uint BIF_EDITBOX = 0x10;
        public const uint BIF_NEWDIALOGSTYLE = 0x40;
        public const uint BIF_RETURNFSANCESTORS = 8;
        public const uint BIF_RETURNONLYFSDIRS = 1;
        public const uint BIF_SHAREABLE = 0x8000;
        public const uint BIF_STATUSTEXT = 4;
        public const uint BIF_USENEWUI = 80;
        public const uint BIF_VALIDATE = 0x20;
        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        public const int MAX_PATH = 0x100;
        public const uint SHGFI_ADDOVERLAYS = 0x20;
        public const uint SHGFI_ATTR_SPECIFIED = 0x20000;
        public const uint SHGFI_ATTRIBUTES = 0x800;
        public const uint SHGFI_DISPLAYNAME = 0x200;
        public const uint SHGFI_EXETYPE = 0x2000;
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_ICONLOCATION = 0x1000;
        public const uint SHGFI_LARGEICON = 0;
        public const uint SHGFI_LINKOVERLAY = 0x8000;
        public const uint SHGFI_OPENICON = 2;
        public const uint SHGFI_OVERLAYINDEX = 0x40;
        public const uint SHGFI_PIDL = 8;
        public const uint SHGFI_SELECTED = 0x10000;
        public const uint SHGFI_SHELLICONSIZE = 4;
        public const uint SHGFI_SMALLICON = 1;
        public const uint SHGFI_SYSICONINDEX = 0x4000;
        public const uint SHGFI_TYPENAME = 0x400;
        public const uint SHGFI_USEFILEATTRIBUTES = 0x10;

        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;
            public IntPtr pidlRoot;
            public IntPtr pszDisplayName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszTitle;
            public uint ulFlags;
            public IntPtr lpfn;
            public int lParam;
            public IntPtr iImage;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            public Shell32.SHITEMID mkid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x100)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
            public string szTypeName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHITEMID
        {
            public ushort cb;
            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] abID;
        }
    }
}

