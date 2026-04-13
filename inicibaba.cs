using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ascad
{
	internal class inicibaba
	{
		private string Path = string.Empty;

		public string Default
		{
			get;
			set;
		}

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		public inicibaba(string path)
		{
			this.Path = path;
		}

		public string Read(string section, string key)
		{
			this.Default = (this.Default ?? string.Empty);
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				inicibaba.GetPrivateProfileString(section, key, this.Default, stringBuilder, 255, this.Path);
			}
			catch (Exception)
			{
			}
			return stringBuilder.ToString();
		}

		public long Write(string section, string key, string value)
		{
			return inicibaba.WritePrivateProfileString(section, key, value, this.Path);
		}
	}
}
