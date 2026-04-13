using System;
using System.Collections.Generic;

namespace ascad
{
	public class vtLift
	{
		public string BlkName
		{
			get;
			set;
		}

		public string ParaName
		{
			get;
			set;
		}

		public string BlkInsName
		{
			get;
			set;
		}

		public string XData
		{
			get;
			set;
		}

		public List<BlkPar> BlkList
		{
			get;
			set;
		}

		public List<ParamList> BlkParamList
		{
			get;
			set;
		}

		public vtLift()
		{
			this.BlkList = new List<BlkPar>();
			this.BlkParamList = new List<ParamList>();
		}
	}
}
