using System;
using System.Collections.Generic;

namespace ascad
{
	public class clsCompleteLift
	{
		public int AsansorSayisi
		{
			get;
			set;
		}

		public int AraBolme
		{
			get;
			set;
		}

		public int ToplamKuyuGenislik
		{
			get;
			set;
		}

		public int ToplamKuyuDerinlik
		{
			get;
			set;
		}

		public List<clsMainLift> Lift
		{
			get;
			set;
		}

		public clsCompleteLift()
		{
			this.Lift = new List<clsMainLift>();
		}
	}
}
