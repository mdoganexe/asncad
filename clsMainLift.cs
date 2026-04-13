using System;
using System.Collections.Generic;
using ZwSoft.ZwCAD.Geometry;

namespace ascad
{
	public class clsMainLift : clsCompleteLift
	{
		public int LiftNum
		{
			get;
			set;
		}

		public int KuyuGen
		{
			get;
			set;
		}

		public int KuyuDer
		{
			get;
			set;
		}

		public string AnaTahrik
		{
			get;
			set;
		}

		public string TahrikTipi
		{
			get;
			set;
		}

		public string TahrikYonu
		{
			get;
			set;
		}

		public structTablist Tablist
		{
			get;
			set;
		}

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

		public vtGroup BlokGrup
		{
			get;
			set;
		}

		public Point3d BasePoint
		{
			get;
			set;
		}

		public Giris Giris1
		{
			get;
			set;
		}

		public clsMainLift()
		{
			this.VarGrup = new List<ParamList>();
			this.DimGrup = new List<ConsParList>();
			this.BasePoint = default(Point3d);
		}

		public clsMainLift(int LiftNum, int KuyuGen, int KuyuDer, string TahrikYonu)
		{
			this.VarGrup = new List<ParamList>();
			this.DimGrup = new List<ConsParList>();
			this.LiftNum = LiftNum;
			this.KuyuGen = KuyuGen;
			this.KuyuDer = KuyuDer;
			this.TahrikYonu = TahrikYonu;
		}

		~clsMainLift()
		{
			this.BasePoint = default(Point3d);
		}
	}
}
