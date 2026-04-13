using System;
using System.Collections.Generic;

namespace ascad
{
	public class clsKatBilgi
	{
		public string KuyuDibi
		{
			get;
			set;
		}

		public List<string> KatYuk
		{
			get;
			set;
		}

		public List<string> KatKot
		{
			get;
			set;
		}

		public clsKatBilgi()
		{
			this.KatYuk = new List<string>();
			this.KatKot = new List<string>();
		}
	}
}
