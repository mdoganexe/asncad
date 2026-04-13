namespace ascad
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class inicibaba
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <Default>k__BackingField;
        private string Path = string.Empty;

        public inicibaba(string path)
        {
            this.Path = path;
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public string Read(string section, string key)
        {
            this.Default = this.Default ?? string.Empty;
            StringBuilder retVal = new StringBuilder();
            try
            {
                GetPrivateProfileString(section, key, this.Default, retVal, 0xff, this.Path);
            }
            catch (Exception)
            {
            }
            return retVal.ToString();
        }

        public long Write(string section, string key, string value) => 
            WritePrivateProfileString(section, key, value, this.Path);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        public string Default { get; set; }
    }
}

