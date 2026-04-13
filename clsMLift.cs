using System;
using System.Collections.Generic;
using ZwSoft.ZwCAD.Geometry;

namespace ascad
{
	public class clsMLift
	{
		public string KesitKodu;

		public List<vtLift> BlokGrup = new List<vtLift>();

		public List<ParamList> VarGrup
		{
			get;
			set;
		}

		public List<ConsParList> DimGrup
		{
			get;
			set;
		}

		public List<structDimblk> DimBlkList
		{
			get;
			set;
		}

		public structTahrik Tahrik
		{
			get;
			set;
		}

		public structKatBilgileri KatBilgileri
		{
			get;
			set;
		}

		public Point3d BasePoint
		{
			get;
			set;
		}

		public int LiftNum
		{
			get;
			set;
		}

		public string[] KatYuk
		{
			get;
			set;
		}

		public string[] KatRumuz
		{
			get;
			set;
		}

		public List<string> KatKot
		{
			get;
			set;
		}

		public string Pan
		{
			get;
			set;
		}

		public double Olcek
		{
			get;
			set;
		}

		public clsMLift()
		{
			this.BlokGrup = new List<vtLift>();
			this.VarGrup = new List<ParamList>();
			this.DimGrup = new List<ConsParList>();
			this.DimBlkList = new List<structDimblk>();
			this.KatKot = new List<string>();
		}
	}
}
