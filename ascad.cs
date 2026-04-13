using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using ZwSoft.ZwCAD.Windows;

namespace ascad
{
	public class ascad
	{
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			public static readonly ascad.<>c <>9 = new ascad.<>c();

			public static Func<ObjectId, bool> <>9__163_0;

			internal bool <denemerep>b__163_0(ObjectId id)
			{
				return id.get_ObjectClass().get_DxfName().ToUpper() == "TEXT";
			}
		}

		public int AsansorSayisi = 1;

		private ascadform mn2 = new ascadform();

		private ascadcabin ascar = new ascadcabin();

		private paramman prman = new paramman();

		private asnhesapfrm fr1 = new asnhesapfrm();

		private static short _colorIndex = 0;

		public PaletteSet myPaletteSet;

		public ascadpalet myPalette = new ascadpalet();

		private abc1 xx = new abc1();

		[CommandMethod("GetStringFromUser")]
		public static void GetStringFromUser()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			srthepler srthepler = new srthepler();
			PromptStringOptions promptStringOptions = new PromptStringOptions("\nEnter your name : ");
			promptStringOptions.set_AllowSpaces(true);
			PromptResult @string = mdiActiveDocument.get_Editor().GetString(promptStringOptions);
			PromptStringOptions promptStringOptions2 = new PromptStringOptions("\nCompany Name : ");
			promptStringOptions2.set_AllowSpaces(true);
			PromptResult string2 = mdiActiveDocument.get_Editor().GetString(promptStringOptions);
			bool flag = @string.get_StringResult() == "8920747942";
			if (flag)
			{
				bool flag2 = srthepler.intirnetvarmi();
				if (flag2)
				{
					srthepler.scroleupdate(string.Concat(new string[]
					{
						"insert into ascad2017scr (sno,uuid,crid,sonktar,ok,FirmaAdi) values ('','",
						srthepler.getuuid(),
						"','999',now(),'1','",
						string2.get_StringResult(),
						"')"
					}), "");
				}
				else
				{
					Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage("Internet not connected...");
				}
			}
			else
			{
				Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage("False value");
			}
		}

		public bool RegOk()
		{
			srthepler srthepler = new srthepler();
			bool flag = srthepler.intirnetvarmi();
			bool result;
			if (flag)
			{
				DataTable dataTable = srthepler.scrdtta("select * from ascad2017scr where uuid='" + srthepler.getuuid() + "'", "");
				bool flag2 = dataTable.Rows.Count > 0;
				if (flag2)
				{
					scrt scrt = srthepler.datdataoko();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		[CommandMethod("Capraz")]
		public void Capraz()
		{
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							Entity entity = ascad.FObject("Capraz", "1", "KK");
							bool flag2 = entity != null;
							if (flag2)
							{
								this.SetDynamicValue(database, transaction, entity, "dynRotAng", 0.78539816339744828);
							}
							double num = Math.Asin(0.5);
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception var_10_BE)
			{
			}
		}

		[CommandMethod("KK")]
		public void KK()
		{
			Application.SetSystemVariable("USERI1", 10);
			Application.SetSystemVariable("DIMSCALE", 3.0);
			Application.SetSystemVariable("DIMLFAC", 10.0);
			this.LD("KK", false, default(Point3d));
			this.LD("KD", false, default(Point3d));
			Application.SetSystemVariable("USERI1", 20);
			Application.SetSystemVariable("DIMLFAC", 20.0);
			this.LD("TK-AA", false, default(Point3d));
			this.LD("TK-BB", false, default(Point3d));
			this.LD("MD", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 0.0);
			Application.SetSystemVariable("USERI1", 0);
		}

		[CommandMethod("TKBB")]
		public void TKBB()
		{
			Application.SetSystemVariable("USERI1", 20);
			Application.SetSystemVariable("DIMLFAC", 20.0);
			this.LD("TK-BB", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		[CommandMethod("KVV")]
		public void KKK()
		{
			waitenform waitenform = new waitenform();
			waitenform.Show();
			this.prman.aadd = this;
			this.prman.destandcrash();
			waitenform.Close();
		}

		[CommandMethod("KKNew")]
		public void KKNew()
		{
			Point3d myBase = new Point3d(100.0, 100.0, 0.0);
			this.LD("KK", true, myBase);
		}

		[CommandMethod("KuyuKabin1")]
		public void KuyuKabin1()
		{
			Application.SetSystemVariable("USERI1", 1);
			Application.SetSystemVariable("DIMSCALE", 40.0);
			Application.SetSystemVariable("DIMLFAC", 1.0);
			this.LD("KK", false, default(Point3d));
		}

		[CommandMethod("KuyuKabinOlcekli")]
		public void KuyuKabinOlcekli()
		{
			this.LD("KK", true, default(Point3d));
			Point3d myBase = new Point3d(0.0, 500.0, 0.0);
			this.LD("KD", true, myBase);
		}

		[CommandMethod("LN")]
		public void LN()
		{
			bool flag = this.GetParamValue("LN") == null;
			if (flag)
			{
				this.NewParam("LN", "1");
			}
		}

		[CommandMethod("SOL")]
		public void SOL()
		{
			this.DALL();
			this.xx.SetNumValue("YonKodu", "SOL", "1");
		}

		[CommandMethod("SAG")]
		public void SAG()
		{
			this.DALL();
			this.xx.SetNumValue("YonKodu", "SAG", "1");
		}

		[CommandMethod("ARKA")]
		public void ARKA()
		{
			this.DALL();
			this.xx.SetNumValue("YonKodu", "ARKA", "1");
		}

		[CommandMethod("DA")]
		public void DA()
		{
			this.DALL();
			this.xx.SetNumValue("TahrikKodu", "DA", "1");
		}

		[CommandMethod("MDDUZ")]
		public void MD()
		{
			this.DALL();
			this.xx.SetNumValue("TahrikKodu", "MDDUZ", "1");
		}

		[CommandMethod("MDCAP")]
		public void MDCAP()
		{
			this.DALL();
			this.xx.SetNumValue("TahrikKodu", "MDCAP", "1");
		}

		[CommandMethod("YA")]
		public void YA()
		{
			this.DALL();
			this.xx.SetNumValue("TahrikKodu", "YA", "1");
		}

		[CommandMethod("HY")]
		public void HY()
		{
			this.DALL();
			this.xx.SetNumValue("TahrikKodu", "HY", "1");
		}

		[CommandMethod("SD")]
		public void SD()
		{
			this.DALL();
			this.xx.SetNumValue("TahrikKodu", "SD", "1");
		}

		[CommandMethod("RAMD")]
		public void RAMD()
		{
			this.DALL();
			this.xx.SetNumValue("TahrikKodu", "RAMD", "1");
		}

		[CommandMethod("EA")]
		public void EA()
		{
			this.DALL();
			this.xx.SetNumValue("TipKodu", "EA", "1");
		}

		[CommandMethod("HA")]
		public void HA()
		{
			this.DALL();
			this.xx.SetNumValue("TipKodu", "HA", "1");
			this.xx.SetNumValue("TahrikKodu", "DA", "1");
		}

		[CommandMethod("RD")]
		public void RD()
		{
			clsMLift clsMLift = new clsMLift();
			string kesitKodu = "KK";
			clsMLift = this.ReadAllData("1", kesitKodu);
		}

		[CommandMethod("LD")]
		public void LD()
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions("\nKesiti Sec :");
			promptKeywordOptions.set_AllowNone(false);
			promptKeywordOptions.get_Keywords().Add("KK");
			promptKeywordOptions.get_Keywords().Add("KD");
			promptKeywordOptions.get_Keywords().Add("MD");
			promptKeywordOptions.get_Keywords().Add("TK-AA");
			promptKeywordOptions.get_Keywords().Add("TK-BB");
			promptKeywordOptions.get_Keywords().Add("TTK-AA");
			promptKeywordOptions.get_Keywords().Add("TTK-BB");
			PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(promptKeywordOptions);
			bool flag = keywords.get_Status() != 5100;
			if (!flag)
			{
				string stringResult = keywords.get_StringResult();
				this.LD(stringResult, false, default(Point3d));
			}
		}

		public void YeniProje()
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions("\nKesiti Sec :");
			promptKeywordOptions.set_AllowNone(false);
			promptKeywordOptions.get_Keywords().Add("KK");
			promptKeywordOptions.get_Keywords().Add("KD");
			promptKeywordOptions.get_Keywords().Add("MD");
			promptKeywordOptions.get_Keywords().Add("TK-AA");
			promptKeywordOptions.get_Keywords().Add("TK-BB");
			promptKeywordOptions.get_Keywords().Add("TTK-AA");
			promptKeywordOptions.get_Keywords().Add("TTK-BB");
			PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(promptKeywordOptions);
			bool flag = keywords.get_Status() != 5100;
			if (!flag)
			{
				string stringResult = keywords.get_StringResult();
				bool flag2 = string.IsNullOrEmpty(this.GetParamValue("LN"));
				if (flag2)
				{
					this.NewParam("LN", "1");
				}
				else
				{
					this.chParamVal("LN", "1");
				}
				this.LD(stringResult, false, default(Point3d));
			}
		}

		public void AsansorEkle()
		{
			this.DALL();
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions("\nKesiti Sec :");
			promptKeywordOptions.set_AllowNone(false);
			promptKeywordOptions.get_Keywords().Add("KK");
			promptKeywordOptions.get_Keywords().Add("KD");
			promptKeywordOptions.get_Keywords().Add("MD");
			promptKeywordOptions.get_Keywords().Add("TK-AA");
			promptKeywordOptions.get_Keywords().Add("TK-BB");
			promptKeywordOptions.get_Keywords().Add("TTK-AA");
			promptKeywordOptions.get_Keywords().Add("TTK-BB");
			PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(promptKeywordOptions);
			bool flag = keywords.get_Status() != 5100;
			if (!flag)
			{
				string stringResult = keywords.get_StringResult();
				bool flag2 = string.IsNullOrEmpty(this.GetParamValue("LN"));
				if (flag2)
				{
					this.NewParam("LN", "2");
				}
				else
				{
					this.chParamVal("LN", "2");
				}
				this.LD(stringResult, false, default(Point3d));
			}
		}

		public void LD(string KesitKodu, bool ScaleNow = false, Point3d MyBase = default(Point3d))
		{
			int num = 0;
			int num2 = 0;
			int num3;
			try
			{
				num3 = Convert.ToInt32(this.GetNumValue("AraBolme", "1"));
			}
			catch (Exception)
			{
				num3 = 100;
			}
			int num4 = 200;
			clsMLift clsMLift = new clsMLift();
			List<ParamList> list = new List<ParamList>();
			List<int> list2 = new List<int>();
			list2.Add(0);
			clsMLift = this.ReadAllData("1", KesitKodu);
			clsMLift.BasePoint = MyBase;
			if (ScaleNow)
			{
				clsMLift.Olcek = Convert.ToDouble(this.GetNumValue(clsMLift.KesitKodu + "OLCEK", "1"));
				bool flag = clsMLift.Olcek == 0.0;
				if (flag)
				{
					clsMLift.Olcek = 1.0;
				}
				Application.SetSystemVariable("DIMLFAC", Convert.ToDouble(this.GetNumValue(clsMLift.KesitKodu + "OLCEK", "1")));
				Application.SetSystemVariable("DIMSCALE", 40.0 / clsMLift.Olcek);
			}
			else
			{
				clsMLift.Olcek = 1.0;
				Application.SetSystemVariable("DIMSCALE", 40.0 / clsMLift.Olcek);
				Application.SetSystemVariable("DIMLFAC", 1.0);
			}
			bool flag2 = string.IsNullOrEmpty(this.prman.GetParamValFRM("LN", "KK"));
			int num5;
			if (flag2)
			{
				num5 = 1;
			}
			else
			{
				string paramValFRM = this.prman.GetParamValFRM("LN", "KK");
				num5 = Convert.ToInt32(paramValFRM);
				bool flag3 = num5 == 1;
				if (flag3)
				{
					num5 = 2;
				}
				bool flag4 = num5 == 0;
				if (flag4)
				{
					num5 = 1;
				}
			}
			num5 = this.prman.asnadedi;
			for (int i = 0; i < num5; i++)
			{
				bool flag5 = i == 1;
				if (flag5)
				{
					this.xx.upexcel("KuyuDer", Convert.ToString(num2), Convert.ToString(i + 1));
				}
				list = this.ReadVarGrup(Convert.ToString(i + 1));
				foreach (ParamList current in list)
				{
					bool flag6 = current.ParamName == "KuyuGen";
					if (flag6)
					{
						num = num + Convert.ToInt32(current.ParamValue) + num3 * i;
						list2.Add(Convert.ToInt32(current.ParamValue));
					}
					bool flag7 = current.ParamName == "KuyuDer";
					if (flag7)
					{
						bool flag8 = num2 == 0;
						if (flag8)
						{
							num2 = Convert.ToInt32(current.ParamValue);
						}
					}
				}
			}
			this.xx.upexcel("ToplamKuyuGen", Convert.ToString(num), "1");
			bool flag9 = num5 > 1;
			if (flag9)
			{
				this.LayerOff("SOLDUBEL");
				this.LayerOff("SAGDUBEL");
			}
			bool flag10 = KesitKodu == "KK" || KesitKodu == "KD";
			if (flag10)
			{
				bool flag11 = clsMLift.Tahrik.YonKodu == "ARKA";
				if (flag11)
				{
					ascad.LayerOn("SOLDUBEL");
					ascad.LayerOn("SAGDUBEL");
				}
				bool flag12 = clsMLift.Tahrik.YonKodu == "SOL";
				if (flag12)
				{
					this.LayerOff("SOLDUBEL");
					ascad.LayerOn("SAGDUBEL");
				}
				bool flag13 = clsMLift.Tahrik.YonKodu == "SAG";
				if (flag13)
				{
					ascad.LayerOn("SOLDUBEL");
					this.LayerOff("SAGDUBEL");
				}
				bool flag14 = this.GetNumValue("chkKabinSusp", "1") == "1";
				if (flag14)
				{
					ascad.LayerOn("KabinSusp");
				}
				else
				{
					this.LayerOff("KabinSusp");
				}
				bool flag15 = clsMLift.Tahrik.TahrikKodu == "MDCAP";
				if (flag15)
				{
					this.LayerOff("11");
					ascad.LayerOn("12");
				}
				else
				{
					this.LayerOff("12");
					ascad.LayerOn("11");
				}
				bool flag16 = clsMLift.Tahrik.TahrikKodu == "DA";
				if (flag16)
				{
					ascad.LayerOn("HD");
				}
				else
				{
					this.LayerOff("HD");
				}
			}
			bool flag17 = KesitKodu == "TK-AA" || KesitKodu == "TK-BB" || KesitKodu == "TTK-AA" || KesitKodu == "TTK-BB";
			if (flag17)
			{
				decimal num6 = 0m;
				decimal value = 0m;
				decimal value2 = 0m;
				clsMLift.KatRumuz = this.GetNumValue("KatRumuz", "1").Split(new char[]
				{
					Convert.ToChar("#")
				});
				string[] array = this.GetNumValue("KatYukListe", "1").Split(new char[]
				{
					Convert.ToChar("#")
				});
				clsMLift.KatYuk = array;
				for (int j = 0; j < array.Length - 1; j++)
				{
					num6 += Convert.ToDecimal(array[j]);
				}
				this.xx.SetNumValue("SeyirMesafesi", Convert.ToString(num6), "1");
				value = num6 + Convert.ToDecimal(array[array.Length - 1]) + Convert.ToDecimal(this.GetNumValue("MDaireH", "1")) + Convert.ToDecimal(this.GetNumValue("KuyuDibi", "1")) - Convert.ToDecimal(this.GetNumValue("DuvarKal", "1"));
				this.xx.SetNumValue("KuyuMesafesi", Convert.ToString(value), "1");
				this.xx.SetNumValue("ToplamYuk", Convert.ToString(value), "1");
				value2 = Convert.ToDecimal(this.GetNumValue("SonDurakKot", "1")) + Convert.ToDecimal(array[array.Length - 1]) + Convert.ToDecimal(this.GetNumValue("MDaireH", "1"));
				this.xx.SetNumValue("MDKot", Convert.ToString(value2), "1");
			}
			if (!(KesitKodu == "TK-AA"))
			{
				if (!(KesitKodu == "TK-BB"))
				{
					if (!(KesitKodu == "TTK-AA"))
					{
						if (!(KesitKodu == "TTK-BB"))
						{
							if (!(KesitKodu == "MD"))
							{
							}
							bool flag18 = KesitKodu == "KD";
							if (flag18)
							{
							}
							this.KuyuCiz(num5, num, num2, list2, num3, KesitKodu, clsMLift);
						}
						else
						{
							this.TTKKuyuCiz(clsMLift, num, KesitKodu);
						}
					}
					else
					{
						this.TTKKuyuCiz(clsMLift, num, KesitKodu);
					}
				}
				else
				{
					this.TKBBKuyuCiz(clsMLift, num2);
				}
			}
			else
			{
				this.TKAAKuyuCiz(clsMLift, num);
			}
			for (int k = 0; k < num5; k++)
			{
				bool flag19 = k == 1;
				if (flag19)
				{
					clsMLift = this.ReadAllData("2", KesitKodu);
				}
				if (ScaleNow)
				{
					clsMLift.Olcek = Convert.ToDouble(this.GetNumValue(clsMLift.KesitKodu + "OLCEK", "1"));
					bool flag20 = clsMLift.Olcek == 0.0;
					if (flag20)
					{
						clsMLift.Olcek = 1.0;
					}
				}
				else
				{
					clsMLift.Olcek = 1.0;
				}
				clsMLift.BasePoint = MyBase;
				bool flag21 = k == 1;
				if (flag21)
				{
					clsMLift.BasePoint = new Point3d(MyBase.get_X() + (double)(list2[1] + num3) * (1.0 / clsMLift.Olcek), MyBase.get_Y(), 0.0);
				}
				clsMLift.LiftNum = k + 1;
				bool flag22 = clsMLift.LiftNum == 2 && clsMLift.KesitKodu == "TK-BB";
				if (!flag22)
				{
					this.LiftDraw2(clsMLift, true);
					bool flag23 = k == 0;
					if (!flag23)
					{
						string yonKodu = clsMLift.Tahrik.YonKodu;
						if (!(yonKodu == "ARKA") && !(yonKodu == "SAG"))
						{
							if (!(yonKodu == "SOL"))
							{
							}
						}
					}
					bool flag24 = k + 1 != 0 && k + 1 < num5;
					if (flag24)
					{
						string yonKodu2 = clsMLift.Tahrik.YonKodu;
						if (!(yonKodu2 == "SAG"))
						{
							if (!(yonKodu2 == "ARKA") && !(yonKodu2 == "SOL"))
							{
							}
						}
					}
					else
					{
						this.chParamVal("DimSagKac" + Convert.ToString(clsMLift.LiftNum), Convert.ToString(list2[k + 1] + num4 + 100));
					}
					bool flag25 = KesitKodu == "MD" && k == 0;
					if (flag25)
					{
						try
						{
							Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
							bool flag26 = mdiActiveDocument == null;
							if (flag26)
							{
								return;
							}
							Database database = mdiActiveDocument.get_Database();
							using (database)
							{
								using (Transaction transaction = database.get_TransactionManager().StartTransaction())
								{
									this.InsertBlock(database, transaction, new Point3d(clsMLift.BasePoint.get_X() + 0.0 * (1.0 / clsMLift.Olcek), clsMLift.BasePoint.get_Y() - 2000.0 * (1.0 / clsMLift.Olcek), 0.0), "Kumanda", true, "", "", "", 1.0 / clsMLift.Olcek);
									this.InsertBlock(database, transaction, new Point3d(clsMLift.BasePoint.get_X() + 1000.0 * (1.0 / clsMLift.Olcek), clsMLift.BasePoint.get_Y() - 2000.0 * (1.0 / clsMLift.Olcek), 0.0), "Kuvvet", true, "", "", "", 1.0 / clsMLift.Olcek);
									this.InsertBlock(database, transaction, new Point3d(clsMLift.BasePoint.get_X() + 1500.0 * (1.0 / clsMLift.Olcek), clsMLift.BasePoint.get_Y() - 2000.0 * (1.0 / clsMLift.Olcek), 0.0), "MDKapi", true, "", "", "", 1.0 / clsMLift.Olcek);
									this.InsertBlock(database, transaction, new Point3d(clsMLift.BasePoint.get_X() + 2000.0 * (1.0 / clsMLift.Olcek), clsMLift.BasePoint.get_Y() - 2000.0 * (1.0 / clsMLift.Olcek), 0.0), "Pencere", true, "", "", "", 1.0 / clsMLift.Olcek);
									this.InsertBlock(database, transaction, new Point3d(clsMLift.BasePoint.get_X() + 2500.0 * (1.0 / clsMLift.Olcek), clsMLift.BasePoint.get_Y() - 2000.0 * (1.0 / clsMLift.Olcek), 0.0), "Baca", true, "", "", "", 1.0 / clsMLift.Olcek);
									this.InsertBlock(database, transaction, new Point3d(clsMLift.BasePoint.get_X() + 3000.0 * (1.0 / clsMLift.Olcek), clsMLift.BasePoint.get_Y() - 2000.0 * (1.0 / clsMLift.Olcek), 0.0), "MDMerdiven", true, "", "", "", 1.0 / clsMLift.Olcek);
									transaction.Commit();
								}
							}
						}
						catch (Exception var_58_D95)
						{
						}
					}
				}
			}
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		public clsMainLift GetLiftData(int LiftNumber)
		{
			clsMainLift clsMainLift = new clsMainLift();
			structTablist tablist = default(structTablist);
			vtGroup vtGroup = new vtGroup();
			string liftNumber = Convert.ToString(LiftNumber);
			structTahrikTip tahrikTip = default(structTahrikTip);
			bool flag = LiftNumber == 1;
			if (flag)
			{
				tahrikTip.TipKodu = "EA";
				tahrikTip.TahrikKodu = "DA";
				tahrikTip.YonKodu = "SAG";
			}
			bool flag2 = LiftNumber == 2;
			if (flag2)
			{
				tahrikTip.TipKodu = "EA";
				tahrikTip.TahrikKodu = "DA";
				tahrikTip.YonKodu = "SOL";
			}
			clsMainLift.LiftNum = LiftNumber;
			tablist.TipKodu = tahrikTip.TipKodu;
			tablist.TahrikKodu = tahrikTip.TahrikKodu;
			tablist.YonKodu = tahrikTip.YonKodu;
			clsMainLift.Tablist = tablist;
			clsMainLift.TahrikYonu = tahrikTip.YonKodu;
			string tipKodu = tahrikTip.TipKodu;
			if (!(tipKodu == "EA"))
			{
				if (tipKodu == "HA")
				{
					vtGroup.KabinBlok = this.ReadData("Kabin", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.KapiBlok = this.ReadData("Kapi", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.HASemerBlok = this.ReadData("HidrolikSemer", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.HAEksenBlok = this.ReadData("HidrolikEksen", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				}
			}
			else
			{
				vtGroup.KabinBlok = this.ReadData("Kabin", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.KabinRayBlok = this.ReadData("KabinRay", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.KapiBlok = this.ReadData("Kapi", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.SinirBlok = this.ReadData("KabinBase", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.AgirlikBlok = this.ReadData("AgrButun", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.AgrUstBlok = this.ReadData("AgrUst", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.AgrRayBlok = this.ReadData("AgrRay", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				string tahrikKodu = tahrikTip.TahrikKodu;
				if (!(tahrikKodu == "MDDUZ"))
				{
					if (tahrikKodu == "MDCAP")
					{
						vtGroup.AgrUstKasnak = this.ReadData("AgrUstKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
						vtGroup.CaprazBlok = this.ReadData("Capraz", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					}
				}
				else
				{
					vtGroup.AgrUstKasnak = this.ReadData("AgrUstKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.KabinAltKasnakBlok = this.ReadData("KabinAltKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				}
				string yonKodu = tahrikTip.YonKodu;
				if (yonKodu == "SOL" || yonKodu == "SAG")
				{
					string tahrikKodu2 = tahrikTip.TahrikKodu;
					if (!(tahrikKodu2 == "DA"))
					{
						if (!(tahrikKodu2 == "MDDUZ"))
						{
						}
					}
				}
			}
			clsMainLift.BasePoint = new Point3d(0.0, 0.0, 0.0);
			clsMainLift.BlokGrup = vtGroup;
			clsMainLift.VarGrup = this.ReadVarGrup(tahrikTip, Convert.ToString(clsMainLift.LiftNum));
			clsMainLift.DimGrup = this.ReadDimGrup(tahrikTip, Convert.ToString(clsMainLift.LiftNum));
			return clsMainLift;
		}

		public void KuyuCiz(int LN, int ToplamKuyuGen, int KuyuDer, List<int> KuyuGenList, int AraBolme, string KesitKodu, clsMLift MainLift)
		{
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							double num = MainLift.Olcek;
							bool flag2 = num == 0.0;
							if (flag2)
							{
								num = 1.0;
							}
							bool flag3 = (KesitKodu == "KK" || KesitKodu == "KD") && MainLift.Pan == "0";
							if (flag3)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "ButunKuyu", false, "BUTUNKUYU", "1", MainLift.KesitKodu, 1.0 / num);
								Entity entity = ascad.FObject("BUTUNKUYU", "1", MainLift.KesitKodu);
								bool flag4 = entity != null;
								if (flag4)
								{
									this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynKuyuDer", (double)KuyuDer * (1.0 / num));
									bool flag5 = num > 1.0;
									if (flag5)
									{
										bool flag6 = KesitKodu == "KK";
										if (flag6)
										{
											this.ChTag(entity.get_ObjectId(), "KUYU", "KUYU YATAY KESİTİ Ö:1/" + this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
										}
										else
										{
											this.ChTag(entity.get_ObjectId(), "KUYU", "KUYU DİBİ YATAY KESİTİ Ö:1/" + this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
										}
									}
									else
									{
										bool flag7 = KesitKodu == "KK";
										if (flag7)
										{
											this.ChTag(entity.get_ObjectId(), "KUYU", "KUYU YATAY KESİTİ");
										}
										else
										{
											this.ChTag(entity.get_ObjectId(), "KUYU", "KUYU DİBİ YATAY KESİTİ");
										}
									}
								}
								bool flag8 = LN > 1;
								if (flag8)
								{
									blockReference = this.InsertBlock(database, transaction, new Point3d(0.0, 0.0, 0.0), "AraBolme", false, "AraBolme", "1", "0", 1.0);
									entity = ascad.FObject("AraBolme", "1", "0");
									bool flag9 = entity != null;
									if (flag9)
									{
										this.SetDynamicValue(database, transaction, entity, "AraBolmeX", (double)KuyuGenList[1] * (1.0 / num));
										this.SetDynamicValue(database, transaction, entity, "AraBolmeH", (double)KuyuDer * (1.0 / num));
										this.SetDynamicValue(database, transaction, entity, "AraBolmeGen", (double)AraBolme * (1.0 / num));
									}
								}
							}
							bool flag10 = (KesitKodu == "KK" || KesitKodu == "KD") && MainLift.Pan == "1";
							if (flag10)
							{
								Point3d insertPoint = new Point3d(0.0, 0.0, 0.0);
								BlockReference blockReference2 = this.InsertBlock(database, transaction, insertPoint, "PanKuyu", false, "BUTUNKUYU", "1", null, 1.0);
								Entity entity = ascad.FObject("BUTUNKUYU", "1", "0");
								bool flag11 = entity != null;
								if (flag11)
								{
									this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynKuyuDer", (double)KuyuDer * (1.0 / num));
									bool flag12 = KesitKodu == "KK";
									if (flag12)
									{
										bool flag13 = num > 1.0;
										if (flag13)
										{
											this.ChTag(entity.get_ObjectId(), "KUYU", "KUYU YATAY KESİTİ Ö:1/" + this.GetNumValue("KKOLCEK", "1"));
										}
										else
										{
											this.ChTag(entity.get_ObjectId(), "KUYU", "KUYU YATAY KESİTİ");
										}
									}
									else
									{
										bool flag14 = num > 1.0;
										if (flag14)
										{
											this.ChTag(entity.get_ObjectId(), "KUYU", "KUYU ALTI YATAY KESİTİ Ö:1/" + this.GetNumValue("KDOLCEK", "1"));
										}
										else
										{
											this.ChTag(entity.get_ObjectId(), "KUYU", "KUYU ALTI YATAY KESİTİ");
										}
									}
								}
							}
							bool flag15 = KesitKodu == "MDD";
							if (flag15)
							{
								Point3d insertPoint2 = new Point3d(0.0, 0.0, 0.0);
								BlockReference blockReference3 = this.InsertBlock(database, transaction, insertPoint2, "MD", false, "BUTUNKUYU", "1", null, 1.0);
								Entity entity = ascad.FObject("BUTUNKUYU", "1", "0");
								bool flag16 = entity != null;
								if (flag16)
								{
									this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynKuyuDer", (double)KuyuDer * (1.0 / num));
									bool flag17 = num > 1.0;
									if (flag17)
									{
										this.ChTag(entity.get_ObjectId(), "KUYU", "MAKİNE DAİRESİ ÜST GÖRÜNÜŞ Ö:1/" + this.GetNumValue("MDOLCEK", "1"));
									}
									else
									{
										this.ChTag(entity.get_ObjectId(), "KUYU", "MAKİNE DAİRESİ ÜST GÖRÜNÜŞ");
									}
								}
							}
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception var_30_618)
			{
			}
			catch (Exception var_31_61E)
			{
			}
		}

		public void MDCiz(int ToplamKuyuGen, int KuyuDer)
		{
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							Point3d insertPoint = new Point3d(0.0, 0.0, 0.0);
							BlockReference blockReference = this.InsertBlock(database, transaction, insertPoint, "MD", false, "MD", "1", "0", 1.0);
							Entity entity = ascad.FObject("MD", "1", "0");
							bool flag2 = entity != null;
							if (flag2)
							{
								this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen);
								this.SetDynamicValue(database, transaction, entity, "dynKuyuDer", (double)KuyuDer);
								this.SetDynamicValue(database, transaction, entity, "dynAASol", Convert.ToDouble(this.GetNumValue("AASol", "1")));
								this.SetDynamicValue(database, transaction, entity, "dynBBSol", Convert.ToDouble(this.GetNumValue("BBSol", "1")));
								this.SetDynamicValue(database, transaction, entity, "dynAASag", Convert.ToDouble(this.GetNumValue("AASag", "1")));
								this.SetDynamicValue(database, transaction, entity, "dynBBSag", Convert.ToDouble(this.GetNumValue("BBSag", "1")));
								this.ChTag(entity.get_ObjectId(), "KUYU", "MAKINE DAIRESI KESITI O:1/" + this.GetNumValue("MDOLCEK", "1"));
							}
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception var_11_1CB)
			{
			}
			catch (Exception var_12_1D1)
			{
			}
		}

		public void TTKKuyuCiz(clsMLift MainLift, int ToplamKuyuGen, string KesitKodu)
		{
			structTahrik structTahrik = default(structTahrik);
			structTahrik = this.ReadTahrikData("1");
			decimal num = 0m;
			decimal value = 0m;
			decimal num2 = 0m;
			decimal d = 0m;
			decimal num3 = 0m;
			double num4 = Convert.ToDouble(this.GetNumValue("KuyuDer", "1"));
			d = Convert.ToDecimal(this.GetNumValue("KuyuDibi", "1"));
			value = Convert.ToDecimal(this.GetNumValue("SeyirMesafesi", "1"));
			num = Convert.ToDecimal(this.GetNumValue("KuyuMesafesi", "1"));
			num3 = num + 200m - Convert.ToDecimal(this.GetNumValue("MDaireH", "1")) - Convert.ToDecimal(MainLift.KatYuk[MainLift.KatYuk.Count<string>() - 1]);
			decimal num5 = Convert.ToDecimal(this.GetNumValue("IlkDurakKot", "1"));
			this.xx.SetNumValue("IlkKat", MainLift.KatYuk[0], "1");
			this.xx.SetNumValue("SonKat", MainLift.KatYuk[MainLift.KatYuk.Count<string>() - 1], "1");
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							Point3d point3d = new Point3d(0.0, 0.0, 0.0);
							BlockReference blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "TTK", false, MainLift.KesitKodu, "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
							Entity entity = ascad.FObject(MainLift.KesitKodu, "1", MainLift.KesitKodu);
							bool flag2 = entity != null;
							if (flag2)
							{
								bool flag3 = KesitKodu == "TTK-AA";
								if (flag3)
								{
									this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen * (1.0 / MainLift.Olcek));
								}
								else
								{
									this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", num4 * (1.0 / MainLift.Olcek));
									this.ChTag(entity.get_ObjectId(), "ILKDURAKNO", MainLift.KatRumuz[0] + ".KAT");
									this.ChTag(entity.get_ObjectId(), "SONDURAKNO", MainLift.KatRumuz[MainLift.KatRumuz.Length - 1] + ".KAT");
									this.ChTag(entity.get_ObjectId(), "ILKDURAKKOT", this.GetNumValue("IlkDurakKot", "1"));
									this.ChTag(entity.get_ObjectId(), "SONDURAKKOT", this.GetNumValue("SonDurakKot", "1"));
									this.ChTag(entity.get_ObjectId(), "MDKOT", this.GetNumValue("MDKot", "1"));
								}
								this.SetDynamicValue(database, transaction, entity, "dynKuyuDibi", 1.0 / MainLift.Olcek * Convert.ToDouble(this.GetNumValue("KuyuDibi", "1")));
								this.SetDynamicValue(database, transaction, entity, "dynIlkKat", 1.0 / MainLift.Olcek * Convert.ToDouble(MainLift.KatYuk[0]));
								this.SetDynamicValue(database, transaction, entity, "dynSonKat", 1.0 / MainLift.Olcek * Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Count<string>() - 1]));
								this.SetDynamicValue(database, transaction, entity, "dynKuyuKafa", 1.0 / MainLift.Olcek * (Convert.ToDouble(this.GetNumValue("MDaireH", "1")) - 200.0));
								this.SetDynamicValue(database, transaction, entity, "dynToplamYuk", 1.0 / MainLift.Olcek * Convert.ToDouble(num));
								this.ChTag(entity.get_ObjectId(), "SEYIRDIM", "SEYİR MESAFESİ = " + Convert.ToString(value) + " mm");
								this.ChTag(entity.get_ObjectId(), "KUYUDIM", "KUYU MESAFESİ = " + Convert.ToString(num) + " mm");
								bool flag4 = KesitKodu == "TTK-AA";
								if (flag4)
								{
									this.ChTag(entity.get_ObjectId(), "KESITADI", "TÜM KUYU AA KESİTİ Ö:1/" + this.GetNumValue("TKKOLCEK", "1"));
								}
								else
								{
									this.ChTag(entity.get_ObjectId(), "KESITADI", "TÜM KUYU BB KESİTİ Ö:1/" + this.GetNumValue("TKKOLCEK", "1"));
								}
							}
							bool flag5 = MainLift.KatYuk.Count<string>() >= 3;
							if (flag5)
							{
								num2 = d + Convert.ToDecimal(MainLift.KatYuk[0]);
								for (int i = 0; i < MainLift.KatYuk.Count<string>() - 2; i++)
								{
									bool flag6 = KesitKodu == "TTK-AA";
									if (flag6)
									{
										blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "KatCik", false, "KatCik" + Convert.ToString(i), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
										entity = ascad.FObject("KatCik" + Convert.ToString(i), "1", MainLift.KesitKodu);
									}
									else
									{
										blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "KatCikBB", false, "KatCik" + Convert.ToString(i), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
										entity = ascad.FObject("KatCik" + Convert.ToString(i), "1", MainLift.KesitKodu);
										this.ChTag(entity.get_ObjectId(), "DURAKNO", MainLift.KatRumuz[i + 1] + ".KAT");
										num5 += Convert.ToDecimal(MainLift.KatYuk[i]);
										this.ChTag(entity.get_ObjectId(), "DURAKKOT", Convert.ToString(num5));
									}
									bool flag7 = entity != null;
									if (flag7)
									{
										bool flag8 = KesitKodu == "TTK-AA";
										if (flag8)
										{
											this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen * (1.0 / MainLift.Olcek));
										}
										else
										{
											this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", num4 * (1.0 / MainLift.Olcek));
										}
										this.SetDynamicValue(database, transaction, entity, "dynKatYuk", 1.0 / MainLift.Olcek * Convert.ToDouble(Convert.ToDecimal(MainLift.KatYuk[i + 1])));
										this.SetDynamicValue(database, transaction, entity, "dynKatYukY", Convert.ToDouble(num2) * (1.0 / MainLift.Olcek));
										num2 += Convert.ToDecimal(MainLift.KatYuk[i + 1]);
										num2 *= (decimal)(1.0 / MainLift.Olcek);
									}
								}
							}
							bool flag9 = KesitKodu == "TTK-AA";
							if (flag9)
							{
								int num6 = Convert.ToInt32(this.GetNumValue("KonsolMesafe", "1"));
								int num7 = Convert.ToInt32(this.GetNumValue("AydinMesafe", "1"));
								double num8 = 500.0;
								int num9 = (int)Math.Ceiling((double)((float)(num - 500m) / (float)num6));
								num9--;
								for (int j = 0; j < num9; j++)
								{
									blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "RayTespit", false, "RayTespit" + Convert.ToString(j + 1), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
									entity = ascad.FObject("RayTespit" + Convert.ToString(j + 1), "1", MainLift.KesitKodu);
									bool flag10 = entity != null;
									if (flag10)
									{
										this.SetDynamicValue(database, transaction, entity, "dynRayTespitX", ((double)ToplamKuyuGen + 3000.0) * (1.0 / MainLift.Olcek));
										this.SetDynamicValue(database, transaction, entity, "dynRayTespitY", num8 * (1.0 / MainLift.Olcek));
										this.SetDynamicValue(database, transaction, entity, "dynKonsolAra", Convert.ToDouble(num6) * (1.0 / MainLift.Olcek));
										this.ChTag(entity.get_ObjectId(), "KONSOLNO", Convert.ToString(j + 1));
									}
									num8 += (double)num6;
								}
								blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "RayTespit", false, "RayTespit0", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
								entity = ascad.FObject("RayTespit0", "1", MainLift.KesitKodu);
								bool flag11 = entity != null;
								if (flag11)
								{
									this.SetDynamicValue(database, transaction, entity, "dynRayTespitX", ((double)ToplamKuyuGen + 3000.0) * (1.0 / MainLift.Olcek));
									this.SetDynamicValue(database, transaction, entity, "dynRayTespitY", num8 * (1.0 / MainLift.Olcek));
									this.SetDynamicValue(database, transaction, entity, "dynKonsolAra", 1.0 / MainLift.Olcek * Convert.ToDouble((double)num - num8));
									this.ChTag(entity.get_ObjectId(), "KONSOLNO", Convert.ToString(num9 + 1));
								}
								num9 = (int)Math.Ceiling((double)((float)(num / 5000m)));
								num8 = 0.0;
								num9--;
								for (int k = 0; k < num9; k++)
								{
									blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "RayTespit", false, "RayEkyer" + Convert.ToString(k + 1), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
									entity = ascad.FObject("RayEkyer" + Convert.ToString(k + 1), "1", MainLift.KesitKodu);
									bool flag12 = entity != null;
									if (flag12)
									{
										this.SetDynamicValue(database, transaction, entity, "dynRayTespitX", ((double)ToplamKuyuGen + 4000.0) * (1.0 / MainLift.Olcek));
										this.SetDynamicValue(database, transaction, entity, "dynRayTespitY", num8 * (1.0 / MainLift.Olcek));
										this.SetDynamicValue(database, transaction, entity, "dynKonsolAra", Convert.ToDouble(5000) * (1.0 / MainLift.Olcek));
										this.ChTag(entity.get_ObjectId(), "KONSOLNO", Convert.ToString(k + 1));
									}
									num8 += 5000.0;
								}
								blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "RayTespit", false, "RayEkyer0", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
								entity = ascad.FObject("RayEkyer0", "1", MainLift.KesitKodu);
								bool flag13 = entity != null;
								if (flag13)
								{
									this.SetDynamicValue(database, transaction, entity, "dynRayTespitX", ((double)ToplamKuyuGen + 4000.0) * (1.0 / MainLift.Olcek));
									this.SetDynamicValue(database, transaction, entity, "dynRayTespitY", num8 * (1.0 / MainLift.Olcek));
									bool flag14 = (double)num < num8;
									if (flag14)
									{
										num8 -= 5000.0;
									}
									this.SetDynamicValue(database, transaction, entity, "dynKonsolAra", Convert.ToDouble(1.0 / MainLift.Olcek * (double)num - num8));
									this.ChTag(entity.get_ObjectId(), "KONSOLNO", Convert.ToString(num9 + 1));
								}
								num8 = 500.0;
								num9 = (int)Math.Ceiling((double)((float)(num - 1000m) / (float)num7));
								num9--;
								for (int l = 0; l < num9; l++)
								{
									blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "RayTespit", false, "Aydinlatma" + Convert.ToString(l + 1), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
									entity = ascad.FObject("Aydinlatma" + Convert.ToString(l + 1), "1", MainLift.KesitKodu);
									bool flag15 = entity != null;
									if (flag15)
									{
										this.SetDynamicValue(database, transaction, entity, "dynRayTespitX", ((double)ToplamKuyuGen + 5000.0) * (1.0 / MainLift.Olcek));
										this.SetDynamicValue(database, transaction, entity, "dynRayTespitY", num8 * (1.0 / MainLift.Olcek));
										this.SetDynamicValue(database, transaction, entity, "dynKonsolAra", Convert.ToDouble(num7) * (1.0 / MainLift.Olcek));
										this.ChTag(entity.get_ObjectId(), "KONSOLNO", Convert.ToString(l + 1));
									}
									num8 += (double)num7;
								}
								blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "RayTespit", false, "Aydinlatma0", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
								entity = ascad.FObject("Aydinlatma0", "1", MainLift.KesitKodu);
								bool flag16 = entity != null;
								if (flag16)
								{
									this.SetDynamicValue(database, transaction, entity, "dynRayTespitX", ((double)ToplamKuyuGen + 5000.0) * (1.0 / MainLift.Olcek));
									this.SetDynamicValue(database, transaction, entity, "dynRayTespitY", num8 * (1.0 / MainLift.Olcek));
									this.SetDynamicValue(database, transaction, entity, "dynKonsolAra", Convert.ToDouble((double)num - 500.0 - num8) * (1.0 / MainLift.Olcek));
									this.ChTag(entity.get_ObjectId(), "KONSOLNO", Convert.ToString(num9 + 1));
								}
								blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "RayTespit", false, "AydinlatmaSon", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
								entity = ascad.FObject("AydinlatmaSon", "1", MainLift.KesitKodu);
								bool flag17 = entity != null;
								if (flag17)
								{
									this.SetDynamicValue(database, transaction, entity, "dynRayTespitX", ((double)ToplamKuyuGen + 5000.0) * (1.0 / MainLift.Olcek));
									this.SetDynamicValue(database, transaction, entity, "dynRayTespitY", (double)(num - 500m) * (1.0 / MainLift.Olcek));
									this.SetDynamicValue(database, transaction, entity, "dynKonsolAra", Convert.ToDouble(500.0) * (1.0 / MainLift.Olcek));
									this.ChTag(entity.get_ObjectId(), "KONSOLNO", Convert.ToString(num9 + 2));
								}
							}
							bool flag18 = structTahrik.TipKodu == "EA" && (structTahrik.TahrikKodu == "DA" || structTahrik.TahrikKodu == "YA" || structTahrik.TahrikKodu == "SD");
							if (flag18)
							{
								blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "TK-AA-MD", false, "TK-AA-MD", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
								entity = ascad.FObject("TK-AA-MD", "1", MainLift.KesitKodu);
								bool flag19 = entity != null;
								if (flag19)
								{
									bool flag20 = KesitKodu == "TTK-AA";
									if (flag20)
									{
										this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen * (1.0 / MainLift.Olcek));
									}
									else
									{
										this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", num4 * (1.0 / MainLift.Olcek));
									}
									this.SetDynamicValue(database, transaction, entity, "dynMDH", 1.0 / MainLift.Olcek * Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))));
									this.SetDynamicValue(database, transaction, entity, "dynCalisYuksek", 1.0 / MainLift.Olcek * Math.Abs(Convert.ToDouble(this.GetNumValue("CalisYuksek", "1"))));
									this.SetDynamicValue(database, transaction, entity, "dynAASOL", 1.0 / MainLift.Olcek * Math.Abs(Convert.ToDouble(this.GetNumValue("AASOL", "1"))));
									this.SetDynamicValue(database, transaction, entity, "dynAASAG", 1.0 / MainLift.Olcek * Math.Abs(Convert.ToDouble(this.GetNumValue("AASAG", "1"))));
									this.SetDynamicValue(database, transaction, entity, "dynMDY", 1.0 / MainLift.Olcek * Math.Abs(Convert.ToDouble(num)));
								}
							}
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception var_49_12CA)
			{
			}
			catch (Exception var_50_12D0)
			{
			}
		}

		public void TKAAKuyuCiz(clsMLift MainLift, int ToplamKuyuGen)
		{
			structTahrik structTahrik = default(structTahrik);
			structTahrik = this.ReadTahrikData("1");
			double num = MainLift.Olcek;
			bool flag = num == 0.0;
			if (flag)
			{
				num = 1.0;
			}
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag2 = mdiActiveDocument == null;
				if (!flag2)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							BlockReference blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "TK-AA", false, "TK-AA", "1", MainLift.KesitKodu, 1.0 / num);
							Entity entity = ascad.FObject("TK-AA", "1", MainLift.KesitKodu);
							bool flag3 = entity != null;
							if (flag3)
							{
								this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen * (1.0 / num));
								this.SetDynamicValue(database, transaction, entity, "dynKuyuDibi", Math.Abs(Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))) * (1.0 / num));
								this.SetDynamicValue(database, transaction, entity, "dynIlkKat", Math.Abs(Convert.ToDouble(this.GetNumValue("IlkKat", "1"))) * (1.0 / num));
								this.SetDynamicValue(database, transaction, entity, "dynSonKat", Math.Abs(Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Length - 1])) * (1.0 / num));
								this.SetDynamicValue(database, transaction, entity, "dynKuyuKafa", Math.Abs(Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1")))) * (1.0 / num));
								this.ChTag(entity.get_ObjectId(), "SEYIRDIM", "SEYİR MESAFESİ = " + this.GetNumValue("SeyirMesafesi", "1") + " mm");
								this.ChTag(entity.get_ObjectId(), "KUYUDIM", "KUYU MESAFESİ = " + this.GetNumValue("KuyuMesafesi", "1") + " mm");
								this.ChTag(entity.get_ObjectId(), "KESITADI", "TÜM KUYU AA KESİTİ Ö:1/" + this.GetNumValue("TK-AAOLCEK", "1"));
							}
							bool flag4 = structTahrik.TipKodu == "EA" && (structTahrik.TahrikKodu == "DA" || structTahrik.TahrikKodu == "YA" || structTahrik.TahrikKodu == "SD");
							if (flag4)
							{
								blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "TK-AA-MD", false, "TK-AA-MD", "1", MainLift.KesitKodu, 1.0 / num);
								entity = ascad.FObject("TK-AA-MD", "1", MainLift.KesitKodu);
								bool flag5 = entity != null;
								if (flag5)
								{
									this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)ToplamKuyuGen * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynMDH", Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))) * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynCalisYuksek", Math.Abs(Convert.ToDouble(this.GetNumValue("CalisYuksek", "1"))) * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynAASOL", Math.Abs(Convert.ToDouble(this.GetNumValue("AASOL", "1"))) * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynAASAG", Math.Abs(Convert.ToDouble(this.GetNumValue("AASAG", "1"))) * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynMDY", (Math.Abs(Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))) + Math.Abs(Convert.ToDouble(this.GetNumValue("IlkKat", "1"))) + Math.Abs(Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Length - 1])) + Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))) + Convert.ToDouble(1550)) * (1.0 / num));
								}
							}
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception var_15_4E6)
			{
			}
			catch (Exception var_16_4EC)
			{
			}
		}

		public void TKBBKuyuCiz(clsMLift MainLift, int KuyuDer)
		{
			structTahrik structTahrik = default(structTahrik);
			structTahrik = this.ReadTahrikData("1");
			double num = MainLift.Olcek;
			bool flag = num == 0.0;
			if (flag)
			{
				num = 1.0;
			}
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag2 = mdiActiveDocument == null;
				if (!flag2)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							BlockReference blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "TK-BB", false, "TK-BB", "1", MainLift.KesitKodu, 1.0 / num);
							Entity entity = ascad.FObject("TK-BB", "1", MainLift.KesitKodu);
							bool flag3 = entity != null;
							if (flag3)
							{
								this.SetDynamicValue(database, transaction, entity, "dynKuyuDer", (double)KuyuDer * (1.0 / num));
								double myvalue = Math.Abs(Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))) * (1.0 / num);
								this.SetDynamicValue(database, transaction, entity, "dynKuyuDibi", myvalue);
								this.SetDynamicValue(database, transaction, entity, "dynIlkKat", Math.Abs(Convert.ToDouble(this.GetNumValue("IlkKat", "1"))) * (1.0 / num));
								this.SetDynamicValue(database, transaction, entity, "dynSonKat", Math.Abs(Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Length - 1])) * (1.0 / num));
								this.SetDynamicValue(database, transaction, entity, "dynKuyuKafa", Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))) * (1.0 / num));
								this.SetDynamicValue(database, transaction, entity, "dynKapiH", Math.Abs(Convert.ToDouble(this.GetNumValue("KapiH", "1"))) * (1.0 / num));
								this.ChTag(entity.get_ObjectId(), "ILKDURAKNO", MainLift.KatRumuz[0] + ".KAT");
								this.ChTag(entity.get_ObjectId(), "ARAKATLARNO", this.GetNumValue("AraKatSTR", "1"));
								this.ChTag(entity.get_ObjectId(), "SONDURAKNO", MainLift.KatRumuz[MainLift.KatRumuz.Length - 1] + ".KAT");
								this.ChTag(entity.get_ObjectId(), "ILKDURAKKOT", this.GetNumValue("IlkDurakKot", "1"));
								this.ChTag(entity.get_ObjectId(), "SONDURAKKOT", this.GetNumValue("SonDurakKot", "1"));
								this.ChTag(entity.get_ObjectId(), "MDKOT", this.GetNumValue("MDKot", "1"));
								this.ChTag(entity.get_ObjectId(), "KESITADI", "TÜM KUYU BB KESİTİ Ö:1/" + this.GetNumValue("TK-BBOLCEK", "1"));
							}
							bool flag4 = structTahrik.TipKodu == "EA" && (structTahrik.TahrikKodu == "DA" || structTahrik.TahrikKodu == "YA" || structTahrik.TahrikKodu == "SD");
							if (flag4)
							{
								blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "TK-AA-MD", false, "TK-AA-MD", "1", MainLift.KesitKodu, 1.0 / num);
								entity = ascad.FObject("TK-AA-MD", "1", MainLift.KesitKodu);
								bool flag5 = entity != null;
								if (flag5)
								{
									this.SetDynamicValue(database, transaction, entity, "dynKuyuGen", (double)KuyuDer * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynMDH", Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))) * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynCalisYuksek", Math.Abs(Convert.ToDouble(this.GetNumValue("CalisYuksek", "1"))) * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynAASOL", Math.Abs(Convert.ToDouble(this.GetNumValue("BBSOL", "1"))) * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynAASAG", Math.Abs(Convert.ToDouble(this.GetNumValue("BBSAG", "1"))) * (1.0 / num));
									this.SetDynamicValue(database, transaction, entity, "dynMDY", (Math.Abs(Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))) + Math.Abs(Convert.ToDouble(this.GetNumValue("IlkKat", "1"))) + Math.Abs(Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Length - 1])) + Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))) + Convert.ToDouble(1550)) * (1.0 / num));
								}
							}
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception var_16_593)
			{
			}
			catch (Exception var_17_599)
			{
			}
		}

		private string Donennumdeger(string paramname, DataTable gelendata)
		{
			string result = "0";
			for (int i = 0; i < gelendata.Rows.Count; i++)
			{
				bool flag = gelendata.Rows[i]["ParamName"].ToString() == paramname;
				if (flag)
				{
					result = gelendata.Rows[i]["ParamValue"].ToString();
					break;
				}
			}
			return result;
		}

		public myData LiftDataOku(string LiftNumber)
		{
			myData myData = new myData();
			DataTable gelendata = this.xx.dtta("select ParamName,ParamValue from Num" + LiftNumber, "");
			DataTable gelendata2 = this.xx.dtta("select ParamName,ParamValue from Num1", "");
			myData.KapiTip = this.GetGirisValue("KapiTip", LiftNumber);
			myData.Mentese = this.GetGirisValue("Mentese", LiftNumber);
			myData.BlkInsName = this.GetGirisValue("BlkInsName", LiftNumber);
			myData.KuyuGen = this.Donennumdeger("KuyuGen", gelendata);
			myData.KuyuDer = this.Donennumdeger("KuyuDer", gelendata);
			myData.DuvarKal = this.Donennumdeger("DuvarKal", gelendata);
			myData.AgrGen = this.Donennumdeger("AgrGen", gelendata);
			myData.AgrU = this.Donennumdeger("AgrU", gelendata);
			myData.AgrDuv = this.Donennumdeger("AgrDuv", gelendata);
			myData.AgrUz = this.Donennumdeger("AgrUz", gelendata);
			myData.KabinRayUcu = this.Donennumdeger("KabinRayUcu", gelendata);
			myData.AgirRayUcu = this.Donennumdeger("AgirRayUcu", gelendata);
			myData.RK = this.Donennumdeger("RK", gelendata);
			myData.SagKac = this.Donennumdeger("SagKac", gelendata);
			myData.SagGirX = this.Donennumdeger("SagGirX", gelendata);
			myData.SagGirY = this.Donennumdeger("SagGirY", gelendata);
			myData.SolGirX = this.Donennumdeger("SolGirX", gelendata);
			myData.SolGirY = this.Donennumdeger("SolGirY", gelendata);
			myData.SolKasa = this.Donennumdeger("SolKasa", gelendata);
			myData.SagKasa = this.Donennumdeger("SagKasa", gelendata);
			myData.KapiFlip = this.Donennumdeger("KapiFlip", gelendata);
			myData.AgrKasnakX = this.Donennumdeger("AgrKasnakX", gelendata);
			myData.AgrKasnakY = this.Donennumdeger("AgrKasnakY", gelendata);
			myData.TahrikKas = this.Donennumdeger("TahrikKas", gelendata);
			myData.SapKas = this.Donennumdeger("SapKas", gelendata);
			myData.AgrKasGen = this.Donennumdeger("AgrKasGen", gelendata);
			myData.MDSapKas = this.Donennumdeger("MDSapKas", gelendata);
			myData.MDTahrikKas = this.Donennumdeger("MDTahrikKas", gelendata);
			myData.KapiYEksen = this.Donennumdeger("KapiYEksen", gelendata);
			myData.KabinYEksen = this.Donennumdeger("KabinYEksen", gelendata);
			myData.KKapiYEksen = this.Donennumdeger("KKapiYEksen", gelendata);
			myData.DKapiYEksen = this.Donennumdeger("DKapiYEksen", gelendata);
			myData.DKapiYEksen = this.Donennumdeger("EsikKalin", gelendata);
			myData.KasaGen = this.Donennumdeger("KasaGen", gelendata);
			myData.KasaDer = this.Donennumdeger("KasaDer", gelendata);
			myData.KizakKalin = this.Donennumdeger("KizakKalin", gelendata);
			myData.HidrolikGen = this.Donennumdeger("HidrolikGen", gelendata);
			myData.PistonMer = this.Donennumdeger("PistonMer", gelendata);
			myData.PistonKab = this.Donennumdeger("PistonKab", gelendata);
			myData.HRA = this.Donennumdeger("HRA", gelendata);
			myData.KabinHidrolikFark = this.Donennumdeger("KabinHidrolikFark", gelendata);
			myData.SagKonsolLIM = this.Donennumdeger("SagKonsolLIM", gelendata);
			myData.KabArkaDuvLIM = this.Donennumdeger("KabArkaDuvLIM", gelendata);
			myData.AgrKabin = this.Donennumdeger("AgrKabin", gelendata);
			myData.KabinDuvar = this.Donennumdeger("KabinDuvar", gelendata);
			myData.SagRayDuv = this.Donennumdeger("SagRayDuv", gelendata);
			myData.KabinRayFark = this.Donennumdeger("KabinRayFark", gelendata);
			myData.AASol = this.Donennumdeger("AASol", gelendata);
			myData.AASag = this.Donennumdeger("AASag", gelendata);
			myData.BBSol = this.Donennumdeger("BBSol", gelendata);
			myData.BBSag = this.Donennumdeger("BBSag", gelendata);
			myData.MDaireH = this.Donennumdeger("MDaireH", gelendata);
			myData.KapiGen = this.Donennumdeger("KapiGen", gelendata);
			myData.AgrAnarayFark = this.Donennumdeger("AgrAnarayFark", gelendata);
			myData.KabinAgrEksenFark = this.Donennumdeger("KabinAgrEksenFark", gelendata);
			myData.SolKonsol = this.Donennumdeger("SolKonsol", gelendata);
			myData.SagKonsol = this.Donennumdeger("SagKonsol", gelendata);
			myData.KabinYanDuv = this.Donennumdeger("KabinYanDuv", gelendata);
			myData.RayTavan = this.Donennumdeger("RayTavan", gelendata);
			myData.KuyuDibi = this.Donennumdeger("KuyuDibi", gelendata2);
			myData.IlkKat = this.Donennumdeger("IlkKat", gelendata2);
			myData.SonKat = this.Donennumdeger("SonKat", gelendata2);
			myData.KuyuKafa = this.Donennumdeger("KuyuKafa", gelendata2);
			myData.DurakSayi = this.Donennumdeger("DurakSayi", gelendata2);
			myData.IlkDurakNo = this.Donennumdeger("IlkDurakNo", gelendata2);
			myData.SeyirMesafesi = this.Donennumdeger("SeyirMesafesi", gelendata2);
			myData.KuyuMesafesi = this.Donennumdeger("KuyuMesafesi", gelendata2);
			myData.IlkDurakKot = this.Donennumdeger("IlkDurakKot", gelendata2);
			myData.SonDurakKot = this.Donennumdeger("SonDurakKot", gelendata2);
			myData.MDKot = this.Donennumdeger("MDKot", gelendata2);
			myData.TopKuyuKafa = this.Donennumdeger("TopKuyuKafa", gelendata2);
			myData.CalisYuksek = this.Donennumdeger("CalisYuksek", gelendata2);
			myData.KRX = this.Donennumdeger("KRX", gelendata);
			myData.KRY = this.Donennumdeger("KRY", gelendata);
			myData.KRZ = this.Donennumdeger("KRZ", gelendata);
			myData.ARX = this.Donennumdeger("ARX", gelendata);
			myData.ARY = this.Donennumdeger("ARY", gelendata);
			myData.ARZ = this.Donennumdeger("ARZ", gelendata);
			myData.KapiH = this.Donennumdeger("KapiH", gelendata);
			myData.BeyanYuk = this.Donennumdeger("BeyanYuk", gelendata);
			myData.KabinP = this.Donennumdeger("KabinP", gelendata);
			myData.TahrikKodu = this.Donennumdeger("TahrikKodu", gelendata);
			myData.YonKodu = this.Donennumdeger("YonKodu", gelendata);
			myData.TipKodu = this.Donennumdeger("TipKodu", gelendata);
			myData.KatYukListe = this.Donennumdeger("KatYukListe", gelendata2);
			myData.TopKuyuKafa = this.Donennumdeger("TopKuyuKafa", gelendata2);
			myData.AraKatSTR = this.Donennumdeger("AraKatSTR", gelendata2);
			myData.KatRumuz = this.Donennumdeger("KatRumuz", gelendata2);
			myData.MdTabTavan = this.Donennumdeger("MdTabTavan", gelendata2);
			myData.AgrGir = this.Donennumdeger("AgrGir", gelendata);
			myData.AydinMesafe = this.Donennumdeger("AydinMesafe", gelendata2);
			myData.KonsolMesafe = this.Donennumdeger("KonsolMesafe", gelendata2);
			myData.OtoKabinEsik = this.Donennumdeger("OtoKabinEsik", gelendata);
			myData.ToplamKalin = this.Donennumdeger("ToplamKalin", gelendata);
			myData.SagRayDuv = this.Donennumdeger("SagRayDuv", gelendata);
			return myData;
		}

		public void LiftDataYaz(myData LiftData, string LiftNumber)
		{
			this.xx.SetGirisValue("KapiTip", LiftData.KapiTip, LiftNumber);
			this.xx.SetGirisValue("Mentese", LiftData.Mentese, LiftNumber);
			this.xx.SetGirisValue("BlkInsName", LiftData.KapiTip, LiftNumber);
			bool flag = LiftData.Mentese == "SAG";
			if (flag)
			{
				LiftData.KapiFlip = "1";
			}
			else
			{
				LiftData.KapiFlip = "0";
			}
			bool flag2 = LiftData.KapiTip != null;
			if (flag2)
			{
				this.xx.SetNumValue("KapiTip", LiftData.KapiTip, LiftNumber);
			}
			bool flag3 = LiftData.TipKodu != null;
			if (flag3)
			{
				this.xx.SetNumValue("TipKodu", LiftData.TipKodu, LiftNumber);
			}
			bool flag4 = LiftData.TahrikKodu != null;
			if (flag4)
			{
				this.xx.SetNumValue("TahrikKodu", LiftData.TahrikKodu, LiftNumber);
			}
			bool flag5 = LiftData.OtoKabinEsik != null;
			if (flag5)
			{
				this.xx.SetNumValue("OtoKabinEsik", LiftData.OtoKabinEsik, LiftNumber);
			}
			bool flag6 = LiftData.ToplamKalin != null;
			if (flag6)
			{
				this.xx.SetNumValue("ToplamKalin", LiftData.ToplamKalin, LiftNumber);
			}
			bool flag7 = LiftData.KuyuGen != null;
			if (flag7)
			{
				this.xx.SetNumValue("KuyuGen", LiftData.KuyuGen, LiftNumber);
			}
			bool flag8 = LiftData.KuyuDer != null;
			if (flag8)
			{
				this.xx.SetNumValue("KuyuDer", LiftData.KuyuDer, LiftNumber);
			}
			bool flag9 = LiftData.DuvarKal != null;
			if (flag9)
			{
				this.xx.SetNumValue("DuvarKal", LiftData.DuvarKal, LiftNumber);
			}
			bool flag10 = LiftData.AgrGen != null;
			if (flag10)
			{
				this.xx.SetNumValue("AgrGen", LiftData.AgrGen, LiftNumber);
			}
			bool flag11 = LiftData.AgrDuv != null;
			if (flag11)
			{
				this.xx.SetNumValue("AgrDuv", LiftData.AgrDuv, LiftNumber);
			}
			bool flag12 = LiftData.AgrU != null;
			if (flag12)
			{
				this.xx.SetNumValue("AgrU", LiftData.AgrU, LiftNumber);
			}
			bool flag13 = LiftData.AgrUz != null;
			if (flag13)
			{
				this.xx.SetNumValue("AgrUz", LiftData.AgrUz, LiftNumber);
			}
			bool flag14 = LiftData.KabinRayUcu != null;
			if (flag14)
			{
				this.xx.SetNumValue("KabinRayUcu", LiftData.KabinRayUcu, LiftNumber);
			}
			bool flag15 = LiftData.AgirRayUcu != null;
			if (flag15)
			{
				this.xx.SetNumValue("AgirRayUcu", LiftData.AgirRayUcu, LiftNumber);
			}
			bool flag16 = LiftData.RK != null;
			if (flag16)
			{
				this.xx.SetNumValue("RK", LiftData.RK, LiftNumber);
			}
			bool flag17 = !string.IsNullOrEmpty(LiftData.SagKac);
			if (flag17)
			{
				this.xx.SetNumValue("SagKac", LiftData.SagKac, LiftNumber);
			}
			bool flag18 = LiftData.SagGirX != null;
			if (flag18)
			{
				this.xx.SetNumValue("SagGirX", LiftData.SagGirX, LiftNumber);
			}
			bool flag19 = LiftData.SagGirY != null;
			if (flag19)
			{
				this.xx.SetNumValue("SagGirY", LiftData.SagGirY, LiftNumber);
			}
			bool flag20 = LiftData.SolGirX != null;
			if (flag20)
			{
				this.xx.SetNumValue("SolGirX", LiftData.SolGirX, LiftNumber);
			}
			bool flag21 = LiftData.SolGirY != null;
			if (flag21)
			{
				this.xx.SetNumValue("SolGirY", LiftData.SolGirY, LiftNumber);
			}
			bool flag22 = LiftData.SolKasa != null;
			if (flag22)
			{
				this.xx.SetNumValue("SolKasa", LiftData.SolKasa, LiftNumber);
			}
			bool flag23 = LiftData.SagKasa != null;
			if (flag23)
			{
				this.xx.SetNumValue("SagKasa", LiftData.SagKasa, LiftNumber);
			}
			bool flag24 = LiftData.KapiFlip != null;
			if (flag24)
			{
				this.xx.SetNumValue("KapiFlip", LiftData.KapiFlip, LiftNumber);
			}
			bool flag25 = LiftData.KizakKalin != null;
			if (flag25)
			{
				this.xx.SetNumValue("KizakKalin", LiftData.KizakKalin, LiftNumber);
			}
			bool flag26 = LiftData.KasaGen != null;
			if (flag26)
			{
				this.xx.SetNumValue("KasaGen", LiftData.KasaGen, LiftNumber);
			}
			bool flag27 = LiftData.KasaDer != null;
			if (flag27)
			{
				this.xx.SetNumValue("KasaDer", LiftData.KasaDer, LiftNumber);
			}
			bool flag28 = LiftData.AgrKasnakX != null;
			if (flag28)
			{
				this.xx.SetNumValue("AgrKasnakX", LiftData.AgrKasnakX, LiftNumber);
			}
			bool flag29 = LiftData.AgrKasnakY != null;
			if (flag29)
			{
				this.xx.SetNumValue("AgrKasnakY", LiftData.AgrKasnakY, LiftNumber);
			}
			bool flag30 = LiftData.TahrikKas != null;
			if (flag30)
			{
				this.xx.SetNumValue("TahrikKas", LiftData.TahrikKas, LiftNumber);
			}
			bool flag31 = LiftData.SapKas != null;
			if (flag31)
			{
				this.xx.SetNumValue("SapKas", LiftData.SapKas, LiftNumber);
			}
			bool flag32 = LiftData.AgrKasGen != null;
			if (flag32)
			{
				this.xx.SetNumValue("AgrKasGen", LiftData.AgrKasGen, LiftNumber);
			}
			bool flag33 = LiftData.MDSapKas != null;
			if (flag33)
			{
				this.xx.SetNumValue("MDSapKas", LiftData.MDSapKas, LiftNumber);
			}
			bool flag34 = LiftData.MDTahrikKas != null;
			if (flag34)
			{
				this.xx.SetNumValue("MDTahrikKas", LiftData.MDTahrikKas, LiftNumber);
			}
			bool flag35 = LiftData.KapiYEksen != null;
			if (flag35)
			{
				this.xx.SetNumValue("KapiYEksen", LiftData.KapiYEksen, LiftNumber);
			}
			bool flag36 = LiftData.KabinYEksen != null;
			if (flag36)
			{
				this.xx.SetNumValue("KabinYEksen", LiftData.KabinYEksen, LiftNumber);
			}
			bool flag37 = LiftData.KKapiYEksen != null;
			if (flag37)
			{
				this.xx.SetNumValue("KKapiYEksen", LiftData.KKapiYEksen, LiftNumber);
			}
			bool flag38 = LiftData.DKapiYEksen != null;
			if (flag38)
			{
				this.xx.SetNumValue("DKapiYEksen", LiftData.DKapiYEksen, LiftNumber);
			}
			bool flag39 = LiftData.HidrolikGen != null;
			if (flag39)
			{
				this.xx.SetNumValue("HidrolikGen", LiftData.HidrolikGen, LiftNumber);
			}
			bool flag40 = LiftData.PistonMer != null;
			if (flag40)
			{
				this.xx.SetNumValue("PistonMer", LiftData.PistonMer, LiftNumber);
			}
			bool flag41 = LiftData.PistonKab != null;
			if (flag41)
			{
				this.xx.SetNumValue("PistonKab", LiftData.PistonKab, LiftNumber);
			}
			bool flag42 = LiftData.HRA != null;
			if (flag42)
			{
				this.xx.SetNumValue("HRA", LiftData.HRA, LiftNumber);
			}
			bool flag43 = LiftData.KabinHidrolikFark != null;
			if (flag43)
			{
				this.xx.SetNumValue("KabinHidrolikFark", LiftData.KabinHidrolikFark, LiftNumber);
			}
			bool flag44 = LiftData.SagKonsolLIM != null;
			if (flag44)
			{
				this.xx.SetNumValue("SagKonsolLIM", LiftData.SagKonsolLIM, LiftNumber);
			}
			bool flag45 = LiftData.KabArkaDuvLIM != null;
			if (flag45)
			{
				this.xx.SetNumValue("KabArkaDuvLIM", LiftData.KabArkaDuvLIM, LiftNumber);
			}
			bool flag46 = LiftData.AgrKabin != null;
			if (flag46)
			{
				this.xx.SetNumValue("AgrKabin", LiftData.AgrKabin, LiftNumber);
			}
			bool flag47 = LiftData.KabinDuvar != null;
			if (flag47)
			{
				this.xx.SetNumValue("KabinDuvar", LiftData.KabinDuvar, LiftNumber);
			}
			bool flag48 = LiftData.SagRayDuv != null;
			if (flag48)
			{
				this.xx.SetNumValue("SagRayDuv", LiftData.SagRayDuv, LiftNumber);
			}
			bool flag49 = LiftData.KabinRayFark != null;
			if (flag49)
			{
				this.xx.SetNumValue("KabinRayFark", LiftData.KabinRayFark, LiftNumber);
			}
			bool flag50 = LiftData.AASol != null;
			if (flag50)
			{
				this.xx.SetNumValue("AASol", LiftData.AASol, LiftNumber);
			}
			bool flag51 = LiftData.AASag != null;
			if (flag51)
			{
				this.xx.SetNumValue("AASag", LiftData.AASag, LiftNumber);
			}
			bool flag52 = LiftData.BBSol != null;
			if (flag52)
			{
				this.xx.SetNumValue("BBSol", LiftData.BBSol, LiftNumber);
			}
			bool flag53 = LiftData.BBSag != null;
			if (flag53)
			{
				this.xx.SetNumValue("BBSag", LiftData.BBSag, LiftNumber);
			}
			bool flag54 = LiftData.MDaireH != null;
			if (flag54)
			{
				this.xx.SetNumValue("MDaireH", LiftData.MDaireH, LiftNumber);
			}
			bool flag55 = LiftData.KapiGen != null;
			if (flag55)
			{
				this.xx.SetNumValue("KapiGen", LiftData.KapiGen, LiftNumber);
			}
			bool flag56 = LiftData.AgrAnarayFark != null;
			if (flag56)
			{
				this.xx.SetNumValue("AgrAnarayFark", LiftData.AgrAnarayFark, LiftNumber);
			}
			bool flag57 = LiftData.KabinAgrEksenFark != null;
			if (flag57)
			{
				this.xx.SetNumValue("KabinAgrEksenFark", LiftData.KabinAgrEksenFark, LiftNumber);
			}
			bool flag58 = LiftData.SolKonsol != null;
			if (flag58)
			{
				this.xx.SetNumValue("SolKonsol", LiftData.SolKonsol, LiftNumber);
			}
			bool flag59 = LiftData.SagKonsol != null;
			if (flag59)
			{
				this.xx.SetNumValue("SagKonsol", LiftData.SagKonsol, LiftNumber);
			}
			bool flag60 = LiftData.KabinYanDuv != null;
			if (flag60)
			{
				this.xx.SetNumValue("KabinYanDuv", LiftData.KabinYanDuv, LiftNumber);
			}
			bool flag61 = LiftData.RayTavan != null;
			if (flag61)
			{
				this.xx.SetNumValue("RayTavan", LiftData.RayTavan, LiftNumber);
			}
			bool flag62 = LiftData.KuyuDibi != null;
			if (flag62)
			{
				this.xx.SetNumValue("KuyuDibi", LiftData.KuyuDibi, "1");
			}
			bool flag63 = LiftData.IlkKat != null;
			if (flag63)
			{
				this.xx.SetNumValue("IlkKat", LiftData.IlkKat, "1");
			}
			bool flag64 = LiftData.SonKat != null;
			if (flag64)
			{
				this.xx.SetNumValue("SonKat", LiftData.SonKat, "1");
			}
			bool flag65 = LiftData.KuyuKafa != null;
			if (flag65)
			{
				this.xx.SetNumValue("KuyuKafa", LiftData.KuyuKafa, "1");
			}
			bool flag66 = LiftData.DurakSayi != null;
			if (flag66)
			{
				this.xx.SetNumValue("DurakSayi", LiftData.DurakSayi, "1");
			}
			bool flag67 = LiftData.IlkDurakNo != null;
			if (flag67)
			{
				this.xx.SetNumValue("IlkDurakNo", LiftData.IlkDurakNo, "1");
			}
			bool flag68 = LiftData.SeyirMesafesi != null;
			if (flag68)
			{
				this.xx.SetNumValue("SeyirMesafesi", LiftData.SeyirMesafesi, "1");
			}
			bool flag69 = LiftData.KuyuMesafesi != null;
			if (flag69)
			{
				this.xx.SetNumValue("KuyuMesafesi", LiftData.KuyuMesafesi, "1");
			}
			bool flag70 = LiftData.IlkDurakKot != null;
			if (flag70)
			{
				this.xx.SetNumValue("IlkDurakKot", LiftData.IlkDurakKot, "1");
			}
			bool flag71 = LiftData.SonDurakKot != null;
			if (flag71)
			{
				this.xx.SetNumValue("SonDurakKot", LiftData.SonDurakKot, "1");
			}
			bool flag72 = LiftData.MDKot != null;
			if (flag72)
			{
				this.xx.SetNumValue("MDKot", LiftData.MDKot, "1");
			}
			bool flag73 = LiftData.CalisYuksek != null;
			if (flag73)
			{
				this.xx.SetNumValue("CalisYuksek", LiftData.CalisYuksek, "1");
			}
			bool flag74 = LiftData.KRX != null;
			if (flag74)
			{
				this.xx.SetNumValue("KRX", LiftData.KRX, LiftNumber);
			}
			bool flag75 = LiftData.KRY != null;
			if (flag75)
			{
				this.xx.SetNumValue("KRY", LiftData.KRY, LiftNumber);
			}
			bool flag76 = LiftData.KRZ != null;
			if (flag76)
			{
				this.xx.SetNumValue("KRZ", LiftData.KRZ, LiftNumber);
			}
			bool flag77 = LiftData.ARX != null;
			if (flag77)
			{
				this.xx.SetNumValue("ARX", LiftData.ARX, LiftNumber);
			}
			bool flag78 = LiftData.ARY != null;
			if (flag78)
			{
				this.xx.SetNumValue("ARY", LiftData.ARY, LiftNumber);
			}
			bool flag79 = LiftData.ARZ != null;
			if (flag79)
			{
				this.xx.SetNumValue("ARZ", LiftData.ARZ, LiftNumber);
			}
			bool flag80 = LiftData.KapiH != null;
			if (flag80)
			{
				this.xx.SetNumValue("KapiH", LiftData.KapiH, LiftNumber);
			}
			bool flag81 = LiftData.BeyanYuk != null;
			if (flag81)
			{
				this.xx.SetNumValue("BeyanYuk", LiftData.BeyanYuk, LiftNumber);
			}
			bool flag82 = LiftData.KabinP != null;
			if (flag82)
			{
				this.xx.SetNumValue("KabinP", LiftData.KabinP, LiftNumber);
			}
			bool flag83 = LiftData.TipKodu != null;
			if (flag83)
			{
				this.xx.SetNumValue("TipKodu", LiftData.TipKodu, LiftNumber);
			}
			bool flag84 = LiftData.TahrikKodu != null;
			if (flag84)
			{
				this.xx.SetNumValue("TahrikKodu", LiftData.TahrikKodu, LiftNumber);
			}
			bool flag85 = LiftData.YonKodu != null;
			if (flag85)
			{
				this.xx.SetNumValue("YonKodu", LiftData.YonKodu, LiftNumber);
			}
			bool flag86 = LiftData.KatYukListe != null;
			if (flag86)
			{
				this.xx.SetNumValue("KatYukListe", LiftData.KatYukListe, "1");
			}
			bool flag87 = LiftData.TopKuyuKafa != null;
			if (flag87)
			{
				this.xx.SetNumValue("TopKuyuKafa", LiftData.TopKuyuKafa, "1");
			}
			bool flag88 = LiftData.AraKatSTR != null;
			if (flag88)
			{
				this.xx.SetNumValue("AraKatSTR", LiftData.AraKatSTR, "1");
			}
			bool flag89 = LiftData.KatRumuz != null;
			if (flag89)
			{
				this.xx.SetNumValue("KatRumuz", LiftData.KatRumuz, "1");
			}
			bool flag90 = LiftData.MdTabTavan != null;
			if (flag90)
			{
				this.xx.SetNumValue("MdTabTavan", LiftData.MdTabTavan, "1");
			}
			bool flag91 = LiftData.AgrGir != null;
			if (flag91)
			{
				this.xx.SetNumValue("AgrGir", LiftData.AgrGir, "1");
			}
			bool flag92 = LiftData.KonsolMesafe != null;
			if (flag92)
			{
				this.xx.SetNumValue("KonsolMesafe", LiftData.KonsolMesafe, "1");
			}
			bool flag93 = LiftData.AydinMesafe != null;
			if (flag93)
			{
				this.xx.SetNumValue("AydinMesafe", LiftData.AydinMesafe, "1");
			}
			bool flag94 = LiftData.MerdivenX != null;
			if (flag94)
			{
				this.xx.SetNumValue("MerdivenX", LiftData.MerdivenX, LiftNumber);
			}
			bool flag95 = LiftData.MerdivenFlip != null;
			if (flag95)
			{
				this.xx.SetNumValue("MerdivenFlip", LiftData.MerdivenFlip, LiftNumber);
			}
			bool flag96 = LiftData.ButonX != null;
			if (flag96)
			{
				this.xx.SetNumValue("ButonX", LiftData.ButonX, LiftNumber);
			}
			bool flag97 = LiftData.KabinRayStr != null;
			if (flag97)
			{
				this.xx.SetNumValue("KabinRayStr", LiftData.KabinRayStr, LiftNumber);
			}
			bool flag98 = LiftData.AgrRayStr != null;
			if (flag98)
			{
				this.xx.SetNumValue("AgrRayStr", LiftData.AgrRayStr, LiftNumber);
			}
			this.KapiDegerSet(LiftData);
		}

		[CommandMethod("KapiDegerSet")]
		public void KapiDegerSet()
		{
			myData myData = new myData();
			myData = this.LiftDataOku("1");
			myData.KapiTip = "2TEL";
			myData.Mentese = "SOL";
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions("\nKAPI TİPİNİ SEÇİN :");
			promptKeywordOptions.set_AllowNone(false);
			promptKeywordOptions.get_Keywords().Add("TO-2TEL");
			promptKeywordOptions.get_Keywords().Add("TO-3TEL");
			promptKeywordOptions.get_Keywords().Add("TO-2MER");
			promptKeywordOptions.get_Keywords().Add("TO-4MER");
			promptKeywordOptions.get_Keywords().Add("YK-KRMK");
			promptKeywordOptions.get_Keywords().Add("CK-KPYK");
			promptKeywordOptions.get_Keywords().Add("YO-2TEL");
			promptKeywordOptions.get_Keywords().Add("YO-3TEL");
			promptKeywordOptions.get_Keywords().Add("YO-2MER");
			promptKeywordOptions.get_Keywords().Add("YO-4MER");
			promptKeywordOptions.get_Keywords().Add("CK-4MER");
			promptKeywordOptions.get_Keywords().Add("CK-2MER");
			PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(promptKeywordOptions);
			bool flag = keywords.get_Status() != 5100;
			if (!flag)
			{
				myData.KapiTip = keywords.get_StringResult();
				PromptKeywordOptions promptKeywordOptions2 = new PromptKeywordOptions("\nKAPI TİPİNİ SEÇİN :");
				promptKeywordOptions2.set_AllowNone(false);
				promptKeywordOptions2.get_Keywords().Add("SOL");
				promptKeywordOptions2.get_Keywords().Add("SAG");
				PromptResult keywords2 = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(promptKeywordOptions2);
				bool flag2 = keywords2.get_Status() != 5100;
				if (!flag2)
				{
					myData.Mentese = keywords2.get_StringResult();
					myData = this.KapiDegerSet(myData);
					this.LiftDataYaz(myData, "1");
				}
			}
		}

		public myData KapiDegerSet(myData LiftData)
		{
			decimal d = Convert.ToDecimal(LiftData.ToplamKalin);
			decimal num = Convert.ToDecimal(LiftData.OtoKabinEsik);
			decimal num2 = Convert.ToDecimal(LiftData.KizakKalin);
			decimal num3 = Convert.ToDecimal(LiftData.KasaDer);
			bool flag = LiftData.Mentese == "SAG";
			if (flag)
			{
				LiftData.MerdivenX = "0";
				LiftData.MerdivenFlip = "0";
				LiftData.KapiFlip = "1";
				LiftData.ButonX = "KapiXSOL+(KapiGen/2)+250";
			}
			else
			{
				LiftData.MerdivenX = "KuyuGen";
				LiftData.MerdivenFlip = "1";
				LiftData.KapiFlip = "0";
				LiftData.ButonX = "KapiXSOL-(KapiGen/2)-250";
			}
			string kapiTip = LiftData.KapiTip;
			uint num4 = <PrivateImplementationDetails>.ComputeStringHash(kapiTip);
			if (num4 <= 2528303865u)
			{
				if (num4 <= 1467219868u)
				{
					if (num4 != 204733707u)
					{
						if (num4 != 1012079765u)
						{
							if (num4 == 1467219868u)
							{
								if (kapiTip == "CK-2MER")
								{
									LiftData.SagGirX = "0";
									LiftData.SagGirY = "0";
									LiftData.SolGirX = "0";
									LiftData.SolGirY = "0";
									LiftData.SolKasa = Convert.ToString(num);
									LiftData.SagKasa = Convert.ToString(num);
									LiftData.DKapiYEksen = Convert.ToString(d - num);
									LiftData.KabinYEksen = d.ToString();
									LiftData.BlkInsName = "CK-2MER";
								}
							}
						}
						else if (kapiTip == "YK-KRMK")
						{
							LiftData.SagGirX = "0";
							LiftData.SagGirY = "0";
							LiftData.SolGirX = "0";
							LiftData.SolGirY = "0";
							LiftData.SolKasa = Convert.ToString(num);
							LiftData.SagKasa = Convert.ToString(num);
							LiftData.KizakKalin = "0";
							bool flag2 = LiftData.Mentese == "SOL";
							if (flag2)
							{
								LiftData.DKapiYEksen = Convert.ToString(d - num);
							}
							LiftData.KabinYEksen = d.ToString();
							LiftData.BlkInsName = "YK-KRMK";
							this.xx.oleupdate("UPDATE BLK SET BlkInsName='YOKRM-BB' WHERE id='252'", "");
						}
					}
					else if (kapiTip == "YO-2TEL")
					{
						bool flag3 = LiftData.Mentese == "SOL";
						if (flag3)
						{
							LiftData.SagGirX = "20";
							LiftData.SagGirY = "45";
							LiftData.SolGirX = "0";
							LiftData.SolGirY = "0";
							LiftData.SagKasa = (num2 + num).ToString();
							LiftData.SolKasa = num.ToString();
						}
						else
						{
							LiftData.SagGirX = "0";
							LiftData.SagGirY = "0";
							LiftData.SolGirX = "20";
							LiftData.SolGirY = "45";
							LiftData.SolKasa = (num2 + num).ToString();
							LiftData.SagKasa = num.ToString();
						}
						LiftData.DKapiYEksen = Convert.ToString(d - num);
						LiftData.KabinYEksen = d.ToString();
						LiftData.BlkInsName = "YO-2TEL";
					}
				}
				else if (num4 != 2160307388u)
				{
					if (num4 != 2222623773u)
					{
						if (num4 == 2528303865u)
						{
							if (kapiTip == "CK-KPYK")
							{
								LiftData.SagGirX = "0";
								LiftData.SagGirY = "0";
								LiftData.SolGirX = "0";
								LiftData.SolGirY = "0";
								LiftData.SolKasa = Convert.ToString(num);
								LiftData.SagKasa = Convert.ToString(num);
								LiftData.DKapiYEksen = Convert.ToString(d - num);
								LiftData.KabinYEksen = d.ToString();
								LiftData.BlkInsName = "YO-CIFT";
							}
						}
					}
					else if (kapiTip == "TO-3TEL")
					{
						bool flag4 = LiftData.Mentese == "SOL";
						if (flag4)
						{
							LiftData.SagGirX = "20";
							LiftData.SagGirY = "45";
							LiftData.SolGirX = "0";
							LiftData.SolGirY = "0";
							LiftData.SagKasa = Convert.ToString(num2 + num);
							LiftData.SolKasa = num.ToString();
						}
						else
						{
							LiftData.SagGirX = "0";
							LiftData.SagGirY = "0";
							LiftData.SolGirX = "20";
							LiftData.SolGirY = "45";
							LiftData.SagKasa = num.ToString();
							LiftData.SolKasa = Convert.ToString(num2 + num);
						}
						this.xx.oleupdate("UPDATE BLK SET BlkInsName='3TEL-BB' WHERE id='252'", "");
						LiftData.EsikKalin = num.ToString();
						LiftData.KabinYEksen = d.ToString();
						LiftData.DKapiYEksen = Convert.ToString(d - num - 2m * num2 - 30m);
						LiftData.BlkInsName = "TO-3TEL";
					}
				}
				else if (kapiTip == "YO-4MER")
				{
					LiftData.SagGirX = "0";
					LiftData.SagGirY = "0";
					LiftData.SolGirX = "0";
					LiftData.SolGirY = "0";
					LiftData.SolKasa = Convert.ToString(num);
					LiftData.SagKasa = Convert.ToString(num);
					LiftData.DKapiYEksen = Convert.ToString(d - num);
					LiftData.KabinYEksen = d.ToString();
					LiftData.BlkInsName = "YO-4MER";
				}
			}
			else if (num4 <= 3183078222u)
			{
				if (num4 != 2613793740u)
				{
					if (num4 != 2886126839u)
					{
						if (num4 == 3183078222u)
						{
							if (kapiTip == "CK-4MER")
							{
								LiftData.SagGirX = "0";
								LiftData.SagGirY = "0";
								LiftData.SolGirX = "0";
								LiftData.SolGirY = "0";
								LiftData.SolKasa = Convert.ToString(num);
								LiftData.SagKasa = Convert.ToString(num);
								LiftData.DKapiYEksen = Convert.ToString(d - num);
								LiftData.KabinYEksen = d.ToString();
								LiftData.BlkInsName = "CK-4MER";
							}
						}
					}
					else if (kapiTip == "TO-4MER")
					{
						LiftData.SagGirX = "0";
						LiftData.SagGirY = "0";
						LiftData.SolGirX = "0";
						LiftData.SolGirY = "0";
						LiftData.SagKasa = num.ToString();
						LiftData.SolKasa = num.ToString();
						LiftData.EsikKalin = num.ToString();
						LiftData.DKapiYEksen = Convert.ToString(d - num - 2m * num2 - 30m);
						LiftData.KabinYEksen = d.ToString();
						LiftData.BlkInsName = "TO-4MER";
						this.xx.oleupdate("UPDATE BLK SET BlkInsName='2TEL-BB' WHERE id='252'", "");
					}
				}
				else if (kapiTip == "TO-2TEL")
				{
					bool flag5 = LiftData.Mentese == "SOL";
					if (flag5)
					{
						LiftData.SagGirX = "20";
						LiftData.SagGirY = "45";
						LiftData.SolGirX = "0";
						LiftData.SolGirY = "0";
						LiftData.SagKasa = Convert.ToString(num2 + num);
						LiftData.SolKasa = num.ToString();
					}
					else
					{
						LiftData.SagGirX = "0";
						LiftData.SagGirY = "0";
						LiftData.SolGirX = "20";
						LiftData.SolGirY = "45";
						LiftData.SagKasa = num.ToString();
						LiftData.SolKasa = Convert.ToString(num2 + num);
					}
					LiftData.EsikKalin = num.ToString();
					LiftData.DKapiYEksen = Convert.ToString(d - num - 2m * num2 - 30m);
					LiftData.KabinYEksen = d.ToString();
					LiftData.BlkInsName = "TO-2TEL";
					LiftData.KapiH = "2300";
					this.xx.oleupdate("UPDATE BLK SET BlkInsName='2TEL-BB' WHERE id='252'", "");
				}
			}
			else if (num4 != 3293583786u)
			{
				if (num4 != 3855377390u)
				{
					if (num4 == 3862111637u)
					{
						if (kapiTip == "TO-2MER")
						{
							LiftData.SagGirX = "0";
							LiftData.SagGirY = "0";
							LiftData.SolGirX = "0";
							LiftData.SolGirY = "0";
							LiftData.SagKasa = num.ToString();
							LiftData.SolKasa = num.ToString();
							LiftData.EsikKalin = num.ToString();
							LiftData.DKapiYEksen = Convert.ToString(d - num - 2m * num2 - 30m);
							LiftData.KabinYEksen = d.ToString();
							LiftData.BlkInsName = "TO-2MER";
							LiftData.KapiH = "2300";
							this.xx.oleupdate("UPDATE BLK SET BlkInsName='2MER-BB' WHERE id='252'", "");
						}
					}
				}
				else if (kapiTip == "YO-2MER")
				{
					LiftData.SagGirX = "0";
					LiftData.SagGirY = "0";
					LiftData.SolGirX = "0";
					LiftData.SolGirY = "0";
					LiftData.SolKasa = Convert.ToString(num);
					LiftData.SagKasa = Convert.ToString(num);
					LiftData.DKapiYEksen = Convert.ToString(d - num);
					LiftData.KabinYEksen = d.ToString();
					LiftData.BlkInsName = "YO-2MER";
				}
			}
			else if (kapiTip == "YO-3TEL")
			{
				bool flag6 = LiftData.Mentese == "SOL";
				if (flag6)
				{
					LiftData.SagGirX = "20";
					LiftData.SagGirY = "45";
					LiftData.SolGirX = "0";
					LiftData.SolGirY = "0";
					LiftData.SagKasa = (num2 + num).ToString();
					LiftData.SolKasa = num.ToString();
				}
				else
				{
					LiftData.SagGirX = "0";
					LiftData.SagGirY = "0";
					LiftData.SolGirX = "20";
					LiftData.SolGirY = "45";
					LiftData.SolKasa = (num2 + num).ToString();
					LiftData.SagKasa = num.ToString();
				}
				LiftData.DKapiYEksen = Convert.ToString(d - num);
				LiftData.KabinYEksen = d.ToString();
				LiftData.BlkInsName = "YO-3TEL";
			}
			return LiftData;
		}

		[CommandMethod("sase")]
		public void sase()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			bool flag = mdiActiveDocument == null;
			if (!flag)
			{
				Database database = mdiActiveDocument.get_Database();
				Editor editor = mdiActiveDocument.get_Editor();
				DBObjectCollection dBObjectCollection = new DBObjectCollection();
				using (database)
				{
					using (Transaction transaction = database.get_TransactionManager().StartTransaction())
					{
						this.InsertBlock(database, transaction, new Point3d(0.0, 0.0, 0.0), "SASEYAN", true, "sase", "1", "0", 1.0);
						Entity entity = ascad.FObject("sase", "1", "0");
						bool flag2 = entity != null;
						if (flag2)
						{
							this.SetDynamicValue(database, transaction, entity, "dynTahKas", 250.0);
							this.SetDynamicValue(database, transaction, entity, "dynSapKas", 200.0);
							this.SetDynamicValue(database, transaction, entity, "dynTahKas1", 500.0);
							this.SetDynamicValue(database, transaction, entity, "dynSapKas1", 400.0);
							this.SetDynamicValue(database, transaction, entity, "dynDD1", 0.0);
							this.SetDynamicValue(database, transaction, entity, "dynDD2", 0.0);
						}
						transaction.Commit();
					}
				}
			}
		}

		[CommandMethod("HAMDDegerSet")]
		public void funcHAMDDegerSet()
		{
			string liftNumber = "1";
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions("\nTAHRİK YÖNÜNÜ SEÇİN :");
			promptKeywordOptions.set_AllowNone(false);
			promptKeywordOptions.get_Keywords().Add("SOL");
			promptKeywordOptions.get_Keywords().Add("SAG");
			promptKeywordOptions.get_Keywords().Add("ARKA");
			PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(promptKeywordOptions);
			bool flag = keywords.get_Status() != 5100;
			if (!flag)
			{
				PromptKeywordOptions promptKeywordOptions2 = new PromptKeywordOptions("\nMAKİNE DAİRESİ YERİNİ SEÇİN :");
				promptKeywordOptions2.set_AllowNone(false);
				promptKeywordOptions2.get_Keywords().Add("SOL");
				promptKeywordOptions2.get_Keywords().Add("SAG");
				PromptResult keywords2 = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(promptKeywordOptions2);
				bool flag2 = keywords2.get_Status() != 5100;
				if (!flag2)
				{
					this.HAMDDegerSet(keywords2.get_StringResult(), keywords.get_StringResult(), "3000", "KuyuDer", liftNumber);
				}
			}
		}

		public void HAMDDegerSet(string MakYerSec, string TahrikYonSec, string HAMDGen, string HAMDDer, string LiftNumber)
		{
			if (!(MakYerSec == "SOL"))
			{
				if (MakYerSec == "SAG")
				{
					this.xx.SetNumValue("HAMDFlip", "0", LiftNumber);
					this.xx.SetNumValue("HAMDX", "KuyuGen+DuvarKal", LiftNumber);
					this.xx.SetNumValue("HAMDY", "0", LiftNumber);
					this.xx.SetNumValue("HAMDDer", HAMDDer, LiftNumber);
					this.xx.SetNumValue("HAMDGen", HAMDGen, LiftNumber);
					if (!(TahrikYonSec == "SOL"))
					{
						if (!(TahrikYonSec == "SAG"))
						{
							if (TahrikYonSec == "ARKA")
							{
								this.xx.SetNumValue("HUniteFlip", "1", LiftNumber);
								this.xx.SetNumValue("MDHidrolikX", "KuyuGen", LiftNumber);
								this.xx.SetNumValue("MDHidrolikY", "MDArkaY", LiftNumber);
								this.xx.SetNumValue("PistonDuvar", "PistonDuvII", LiftNumber);
							}
						}
						else
						{
							this.xx.SetNumValue("HUniteFlip", "1", LiftNumber);
							this.xx.SetNumValue("MDHidrolikX", "KuyuGen", LiftNumber);
							this.xx.SetNumValue("MDHidrolikY", "HidrolikY", LiftNumber);
							this.xx.SetNumValue("PistonDuvar", "PistonMer", LiftNumber);
						}
					}
					else
					{
						this.xx.SetNumValue("HUniteFlip", "1", LiftNumber);
						this.xx.SetNumValue("MDHidrolikX", "KuyuGen", LiftNumber);
						this.xx.SetNumValue("MDHidrolikY", "HidrolikY", LiftNumber);
						this.xx.SetNumValue("PistonDuvar", "PistonDuvI", LiftNumber);
					}
				}
			}
			else
			{
				this.xx.SetNumValue("HAMDFlip", "1", LiftNumber);
				this.xx.SetNumValue("HAMDX", "0", LiftNumber);
				this.xx.SetNumValue("HAMDY", "0", LiftNumber);
				this.xx.SetNumValue("HAMDDer", HAMDDer, LiftNumber);
				this.xx.SetNumValue("HAMDGen", HAMDGen, LiftNumber);
				if (!(TahrikYonSec == "SOL"))
				{
					if (!(TahrikYonSec == "SAG"))
					{
						if (TahrikYonSec == "ARKA")
						{
							this.xx.SetNumValue("HUniteFlip", "0", LiftNumber);
							this.xx.SetNumValue("MDHidrolikX", "0", LiftNumber);
							this.xx.SetNumValue("MDHidrolikY", "MDArkaY", LiftNumber);
							this.xx.SetNumValue("PistonDuvar", "HidrolikX", LiftNumber);
						}
					}
					else
					{
						this.xx.SetNumValue("HUniteFlip", "0", LiftNumber);
						this.xx.SetNumValue("MDHidrolikX", "0", LiftNumber);
						this.xx.SetNumValue("MDHidrolikY", "HidrolikY", LiftNumber);
						this.xx.SetNumValue("PistonDuvar", "PistonDuvI", LiftNumber);
					}
				}
				else
				{
					this.xx.SetNumValue("HUniteFlip", "0", LiftNumber);
					this.xx.SetNumValue("MDHidrolikX", "0", LiftNumber);
					this.xx.SetNumValue("MDHidrolikY", "HidrolikY", LiftNumber);
					this.xx.SetNumValue("PistonDuvar", "PistonMer", LiftNumber);
				}
			}
		}

		[CommandMethod("AsCad")]
		public void AsCad()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			clsCompleteLift clsCompleteLift = new clsCompleteLift();
			vtGroup vtGroup = new vtGroup();
			Giris giris = new Giris();
			clsMainLift clsMainLift = new clsMainLift
			{
				LiftNum = 1,
				KuyuGen = 2200,
				KuyuDer = 2500,
				TahrikYonu = "SAG"
			};
			List<structAnaTip> list = new List<structAnaTip>();
			List<structTahrikTip> list2 = new List<structTahrikTip>();
			List<structTahrikYon> list3 = new List<structTahrikYon>();
			structAnaTip anaTip = default(structAnaTip);
			structTahrikTip tahrikTip = default(structTahrikTip);
			structTahrikYon structTahrikYon = default(structTahrikYon);
			list = this.ReadAnaTip();
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions("\nTahrik Cinsini Seçiniz :");
			promptKeywordOptions.set_AllowNone(false);
			foreach (structAnaTip current in list)
			{
				promptKeywordOptions.get_Keywords().Add(current.TipAdi);
			}
			PromptResult keywords = editor.GetKeywords(promptKeywordOptions);
			bool flag = keywords.get_Status() != 5100;
			if (flag)
			{
				clsMainLift.AnaTahrik = "Elektrikli";
			}
			clsMainLift.AnaTahrik = keywords.get_StringResult();
			foreach (structAnaTip current2 in list)
			{
				bool flag2 = current2.TipAdi == keywords.get_StringResult();
				if (flag2)
				{
					anaTip.TipAdi = current2.TipAdi;
					anaTip.TipKodu = current2.TipKodu;
				}
			}
			list2 = this.ReadTahrikTip(anaTip);
			PromptKeywordOptions promptKeywordOptions2 = new PromptKeywordOptions("\nTahrik Tipini Seçiniz :");
			promptKeywordOptions2.set_AllowNone(false);
			foreach (structTahrikTip current3 in list2)
			{
				promptKeywordOptions2.get_Keywords().Add(current3.TipAdi);
			}
			PromptResult keywords2 = editor.GetKeywords(promptKeywordOptions2);
			bool flag3 = keywords2.get_Status() != 5100;
			if (flag3)
			{
				clsMainLift.TahrikTipi = "DirekAski";
			}
			clsMainLift.TahrikTipi = keywords2.get_StringResult();
			foreach (structTahrikTip current4 in list2)
			{
				bool flag4 = current4.TipAdi == keywords2.get_StringResult();
				if (flag4)
				{
					tahrikTip.TipAdi = current4.TipAdi;
					tahrikTip.TipKodu = current4.TipKodu;
					tahrikTip.TahrikKodu = current4.TahrikKodu;
					tahrikTip.TipIndex = current4.TipIndex;
				}
			}
			list3 = this.ReadTahrikYon(anaTip);
			PromptKeywordOptions promptKeywordOptions3 = new PromptKeywordOptions("\nTahrik Yönünü Seçiniz :");
			promptKeywordOptions3.set_AllowNone(false);
			foreach (structTahrikYon current5 in list3)
			{
				promptKeywordOptions3.get_Keywords().Add(current5.TipAdi);
			}
			PromptResult keywords3 = editor.GetKeywords(promptKeywordOptions3);
			bool flag5 = keywords3.get_Status() != 5100;
			if (flag5)
			{
				clsMainLift.TahrikTipi = "SOL";
			}
			clsMainLift.TahrikYonu = keywords3.get_StringResult();
			foreach (structTahrikYon current6 in list3)
			{
				bool flag6 = current6.TipAdi == keywords3.get_StringResult();
				if (flag6)
				{
					structTahrikYon.TipAdi = current6.TipAdi;
					structTahrikYon.TipKodu = current6.TipKodu;
					structTahrikYon.YonKodu = current6.YonKodu;
				}
			}
			tahrikTip.YonKodu = structTahrikYon.YonKodu;
			string liftNumber = Convert.ToString(clsMainLift.LiftNum);
			string text = tahrikTip.TipKodu + "-" + tahrikTip.TahrikKodu + "-BLK";
			string text2 = string.Concat(new string[]
			{
				tahrikTip.TipKodu,
				"-",
				tahrikTip.TahrikKodu,
				"-",
				structTahrikYon.YonKodu,
				"-PARAM"
			});
			text2 = tahrikTip.TipKodu + "-PARAM";
			string text3 = string.Concat(new string[]
			{
				tahrikTip.TipKodu,
				"-",
				tahrikTip.TahrikKodu,
				"-",
				structTahrikYon.YonKodu,
				"-VAR"
			});
			string text4 = string.Concat(new string[]
			{
				tahrikTip.TipKodu,
				"-",
				tahrikTip.TahrikKodu,
				"-",
				structTahrikYon.YonKodu,
				"-DIM"
			});
			clsMainLift.Tablist = new structTablist
			{
				TipKodu = tahrikTip.TipKodu,
				TahrikKodu = tahrikTip.TahrikKodu,
				YonKodu = structTahrikYon.YonKodu
			};
			this.xx.oleupdate("update TabList set TabValue='" + tahrikTip.TipKodu + "' where TabName='TipKodu'", "");
			this.xx.oleupdate("update TabList set TabValue='" + tahrikTip.TahrikKodu + "' where TabName='TahrikKodu'", "");
			this.xx.oleupdate("update TabList set TabValue='" + tahrikTip.YonKodu + "' where TabName='YonKodu'", "");
			string tipKodu = tahrikTip.TipKodu;
			if (!(tipKodu == "EA"))
			{
				if (tipKodu == "HA")
				{
					vtGroup.KabinBlok = this.ReadData("Kabin", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.KapiBlok = this.ReadData("Kapi", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.KuyuBlok = this.ReadData("Kuyu", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.SinirBlok = this.ReadData("KabinBase", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.HASemerBlok = this.ReadData("HidrolikSemer", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.HAEksenBlok = this.ReadData("HidrolikEksen", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				}
			}
			else
			{
				vtGroup.KabinBlok = this.ReadData("Kabin", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.KabinRayBlok = this.ReadData("KabinRay", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.KapiBlok = this.ReadData("Kapi", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.KuyuBlok = this.ReadData("Kuyu", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.SinirBlok = this.ReadData("KabinBase", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.AgirlikBlok = this.ReadData("AgrButun", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.AgrUstBlok = this.ReadData("AgrUst", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				vtGroup.AgrRayBlok = this.ReadData("AgrRay", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				string tahrikKodu = tahrikTip.TahrikKodu;
				if (!(tahrikKodu == "MDDUZ"))
				{
					if (tahrikKodu == "MDCAP")
					{
						vtGroup.AgrUstKasnak = this.ReadData("AgrUstKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
						vtGroup.CaprazBlok = this.ReadData("Capraz", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					}
				}
				else
				{
					vtGroup.AgrUstKasnak = this.ReadData("AgrUstKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
					vtGroup.KabinAltKasnakBlok = this.ReadData("KabinAltKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
				}
				string yonKodu = tahrikTip.YonKodu;
				if (yonKodu == "SOL" || yonKodu == "SAG")
				{
					this.xx.oleupdate("update Num1 set ParamValue='KuyuDer-KabinYEksen-100' where ParamName='KabinDer'", "");
					this.xx.oleupdate("update Num1 set ParamValue='KuyuGen-(AgrDuv+AgrGen+AgrU+70+200)-((KRX+KabinRayUcu)*2)' where ParamName='KabinGen'", "");
					this.xx.oleupdate("update Num1 set ParamValue='(KabinDer/2)+KizakKalin' where ParamName='RK'", "");
					string tahrikKodu2 = tahrikTip.TahrikKodu;
					if (!(tahrikKodu2 == "DA"))
					{
						if (tahrikKodu2 == "MDDUZ")
						{
							this.xx.oleupdate("update Num1 set ParamValue='KabinYEksen+(KabinDer/2)+(SapKas/2)' where ParamName='AgrYEksen'", "");
						}
					}
					else
					{
						this.xx.oleupdate("update Num1 set ParamValue='KabinRayYEksen' where ParamName='AgrYEksen'", "");
					}
				}
			}
			clsMainLift.BasePoint = new Point3d(0.0, 0.0, 0.0);
			clsMainLift.BlokGrup = vtGroup;
			clsMainLift.VarGrup = this.ReadVarGrup(tahrikTip, Convert.ToString(clsMainLift.LiftNum));
			bool flag7 = tahrikTip.TipKodu == "EA";
			if (flag7)
			{
				clsMainLift.DimGrup = this.ReadDimGrup(tahrikTip, Convert.ToString(clsMainLift.LiftNum));
			}
			clsCompleteLift.Lift.Add(clsMainLift);
			string param = this.GetParam(clsMainLift.VarGrup, "KuyuDer");
		}

		public string GetParam(List<ParamList> vtParamList, string FindParamName)
		{
			string result;
			foreach (ParamList current in vtParamList)
			{
				bool flag = current.ParamName == FindParamName;
				if (flag)
				{
					result = current.ParamValue;
					return result;
				}
			}
			result = null;
			return result;
		}

		[CommandMethod("LiftDraw")]
		public void LiftDraw(clsMLift MainLift)
		{
			string str = "PL" + Convert.ToString(MainLift.LiftNum);
			string text = "L" + Convert.ToString(MainLift.LiftNum);
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							foreach (vtLift current in MainLift.BlokGrup)
							{
								this.InsertBlock(database, transaction, MainLift.BasePoint, current.BlkInsName, false, current.XData, Convert.ToString(MainLift.LiftNum), null, 1.0);
							}
							Point3d insertPoint = new Point3d(0.0, 0.0, 0.0);
							foreach (structDimblk current2 in MainLift.DimBlkList)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction, insertPoint, current2.DimBlk, false, "DIMBLK", "LN", null, 1.0);
								blockReference.ExplodeToOwnerSpace();
								blockReference.Erase();
								this.vtCHXdata(MainLift.LiftNum);
								this.chParamVal("DimAnaX" + Convert.ToString(MainLift.LiftNum), Convert.ToString(MainLift.BasePoint.get_X()));
							}
							foreach (ConsParList current3 in MainLift.DimGrup)
							{
								this.RenameParam(current3.ConsName, str + current3.ConsName);
							}
							foreach (ParamList current4 in MainLift.VarGrup)
							{
								this.NewParam(current4.ParamName, "1");
							}
							foreach (ParamList current5 in MainLift.VarGrup)
							{
								this.chParamVal(current5.ParamName, current5.ParamValue);
							}
							foreach (vtLift current6 in MainLift.BlokGrup)
							{
								foreach (ParamList current7 in current6.BlkParamList)
								{
									bool flag2 = current7.ParamName != null || current7.ParamValue != null;
									if (flag2)
									{
										this.NewParam(text + current7.ParamName, current7.ParamValue);
									}
								}
							}
							foreach (ConsParList current8 in MainLift.DimGrup)
							{
								string text2 = current8.ConsValue.ToString();
								while (text2.IndexOf("LLNUM") != -1)
								{
									text2 = text2.Replace("LLNUM", text);
								}
								this.chParamVal(str + current8.ConsName, text2);
							}
							foreach (ParamList current9 in MainLift.VarGrup)
							{
								this.RenameParam(current9.ParamName, text + current9.ParamName);
							}
							transaction.Commit();
						}
					}
					Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("DIMREGEN ", true, false, false);
					Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("REGENALL ", true, false, false);
					Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("CONSTRAINTBAR\nALL\n\nHIDE\n", true, false, false);
				}
			}
			catch (Exception var_33_482)
			{
			}
			catch (Exception var_34_488)
			{
			}
		}

		[CommandMethod("setdy")]
		public void setdy()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			bool flag = mdiActiveDocument == null;
			if (!flag)
			{
				Database database = mdiActiveDocument.get_Database();
				Editor editor = mdiActiveDocument.get_Editor();
				using (database)
				{
					using (Transaction transaction = database.get_TransactionManager().StartTransaction())
					{
						PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\nSelect entity: ");
						PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
						BlockReference blockReference = (BlockReference)transaction.GetObject(entity.get_ObjectId(), 0);
						blockReference.UpgradeOpen();
						bool flag2 = blockReference == null;
						if (!flag2)
						{
							DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
							foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
							{
								bool readOnly = dynamicBlockReferenceProperty.get_ReadOnly();
								if (!readOnly)
								{
									bool flag3 = dynamicBlockReferenceProperty.get_PropertyName() == "dynKapiFlip";
									if (flag3)
									{
										short propertyTypeCode = dynamicBlockReferenceProperty.get_PropertyTypeCode();
										if (propertyTypeCode != 3)
										{
											dynamicBlockReferenceProperty.set_Value(900);
										}
										else
										{
											object[] allowedValues = dynamicBlockReferenceProperty.GetAllowedValues();
											for (int i = 0; i < allowedValues.Length; i++)
											{
											}
											dynamicBlockReferenceProperty.set_Value(1);
										}
									}
								}
							}
							transaction.Commit();
						}
					}
				}
			}
		}

		public void LiftDraw2(clsMLift MainLift, bool OldNew = true)
		{
			string lLNum = "PL" + Convert.ToString(MainLift.LiftNum);
			string text = "L" + Convert.ToString(MainLift.LiftNum);
			bool flag = !OldNew;
			if (flag)
			{
				MainLift.Olcek = Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
			}
			bool flag2 = MainLift.Olcek == 1.0 || MainLift.Olcek == 0.0;
			double scale;
			if (flag2)
			{
				scale = 1.0;
				Application.SetSystemVariable("DIMSCALE", 40.0);
				Application.SetSystemVariable("DIMLFAC", 1.0);
			}
			else
			{
				scale = 1.0 / Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
				Application.SetSystemVariable("DIMLFAC", Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1")));
			}
			Scale3d scale3d = default(Scale3d);
			this.prman.aadd = this;
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag3 = mdiActiveDocument == null;
				if (!flag3)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						if (OldNew)
						{
							using (Transaction transaction = database.get_TransactionManager().StartTransaction())
							{
								foreach (vtLift current in MainLift.BlokGrup)
								{
									bool flag4 = MainLift.KesitKodu == "MD" && MainLift.LiftNum == 2 && current.XData == "MDaire";
									if (!flag4)
									{
										this.InsertBlock(database, transaction, MainLift.BasePoint, current.BlkInsName, false, current.XData, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu, scale);
									}
								}
								bool flag5 = MainLift.KesitKodu == "KK" || MainLift.KesitKodu == "KD";
								if (flag5)
								{
									BlockReference blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, MainLift.DimBlkList[0].DimBlk, false, "DIMBLK", "LN", MainLift.KesitKodu, 1.0);
									blockReference.ExplodeToOwnerSpace();
									blockReference.Erase();
									this.vtCHXdataDIM(MainLift.LiftNum, MainLift.KesitKodu);
									this.vtCHXdata(MainLift.LiftNum);
								}
								bool flag6 = MainLift.LiftNum == 1;
								if (flag6)
								{
									bool flag7 = MainLift.Tahrik.TahrikKodu == "EA" || MainLift.KesitKodu == "MD";
									if (flag7)
									{
										BlockReference blockReference2 = this.InsertBlock(database, transaction, MainLift.BasePoint, MainLift.DimBlkList[0].DimBlk, false, "DIMBLKMD", "LN", MainLift.KesitKodu, 1.0);
										blockReference2.ExplodeToOwnerSpace();
										blockReference2.Erase();
										this.vtCHXdataDIM(MainLift.LiftNum, MainLift.KesitKodu);
										this.vtCHXdata(MainLift.LiftNum);
									}
								}
								transaction.Commit();
							}
						}
						foreach (vtLift current2 in MainLift.BlokGrup)
						{
							using (Transaction transaction2 = database.get_TransactionManager().StartTransaction())
							{
								Entity entity = ascad.FObject(current2.XData, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag8 = entity != null;
								if (flag8)
								{
									BlockReference blockReference3 = (BlockReference)transaction2.GetObject(entity.get_ObjectId(), 0);
									blockReference3.UpgradeOpen();
									blockReference3.set_Position(MainLift.BasePoint);
									this.SetDynamicValue(database, transaction2, entity, current2, text, blockReference3.get_ScaleFactors().get_X(), MainLift.KesitKodu);
								}
								transaction2.Commit();
							}
						}
						bool flag9 = MainLift.KesitKodu == "KK" || MainLift.KesitKodu == "KD" || (MainLift.Tahrik.TipKodu == "EA" && MainLift.KesitKodu == "MD");
						if (flag9)
						{
							Entity entity = ascad.FObject("DIMDYN" + MainLift.KesitKodu, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
							bool flag10 = entity != null;
							if (flag10)
							{
								using (Transaction transaction3 = database.get_TransactionManager().StartTransaction())
								{
									BlockReference blockReference4 = (BlockReference)transaction3.GetObject(entity.get_ObjectId(), 0);
									blockReference4.UpgradeOpen();
									blockReference4.set_Position(MainLift.BasePoint);
									this.SetDynamicValue(database, transaction3, entity, MainLift, lLNum, blockReference4.get_ScaleFactors().get_X(), MainLift.KesitKodu);
									transaction3.Commit();
								}
							}
							this.dimdene2(Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu, MainLift.BasePoint, OldNew);
							bool flag11 = MainLift.Tahrik.TahrikKodu == "MDCAP" || MainLift.Tahrik.TahrikKodu == "SD";
							if (flag11)
							{
								entity = ascad.FObject("Capraz", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag12 = entity != null;
								if (flag12)
								{
									using (Transaction transaction4 = database.get_TransactionManager().StartTransaction())
									{
										double num = Convert.ToDouble(this.prman.GetParamValFRM(text + "AKenar", MainLift.KesitKodu));
										double num2 = Convert.ToDouble(this.prman.GetParamValFRM(text + "BKenar", MainLift.KesitKodu));
										double num3 = Math.Sqrt(num * num + num2 * num2);
										double num4 = num / num3;
										bool flag13 = MainLift.Tahrik.YonKodu == "SAG";
										if (flag13)
										{
											this.SetDynamicValue(database, transaction4, entity, "dynRotAng", Math.Asin(num4));
										}
										else
										{
											this.SetDynamicValue(database, transaction4, entity, "dynRotAng", 3.1415926535897931 - Math.Asin(Math.Abs(num4)));
										}
										BlockReference blockReference5 = (BlockReference)transaction4.GetObject(entity.get_ObjectId(), 0);
										blockReference5.UpgradeOpen();
										blockReference5.set_Position(MainLift.BasePoint);
										scale3d = blockReference5.get_ScaleFactors();
										this.SetDynamicValue(database, transaction4, entity, "Distance1", (double)Convert.ToInt32(num3) * scale3d.get_X());
										transaction4.Commit();
									}
								}
							}
							bool flag14 = (MainLift.KesitKodu == "KK" || MainLift.KesitKodu == "KD") && MainLift.Tahrik.TipKodu == "EA";
							if (flag14)
							{
								entity = ascad.FObject("RegUst", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag15 = entity != null;
								if (flag15)
								{
									using (Transaction transaction5 = database.get_TransactionManager().StartTransaction())
									{
										string numValue = this.GetNumValue("RegYer", Convert.ToString(MainLift.LiftNum));
										bool flag16 = numValue == "1";
										if (flag16)
										{
											this.SetDynamicValue(database, transaction5, entity, "dynRegFlipX", 1.0);
											this.SetDynamicValue(database, transaction5, entity, "dynRegFlipY", 1.0);
										}
										bool flag17 = numValue == "2";
										if (flag17)
										{
											this.SetDynamicValue(database, transaction5, entity, "dynRegFlipX", 0.0);
											this.SetDynamicValue(database, transaction5, entity, "dynRegFlipY", 1.0);
										}
										bool flag18 = numValue == "3";
										if (flag18)
										{
											this.SetDynamicValue(database, transaction5, entity, "dynRegFlipX", 0.0);
											this.SetDynamicValue(database, transaction5, entity, "dynRegFlipY", 0.0);
										}
										bool flag19 = numValue == "4";
										if (flag19)
										{
											this.SetDynamicValue(database, transaction5, entity, "dynRegFlipX", 1.0);
											this.SetDynamicValue(database, transaction5, entity, "dynRegFlipY", 0.0);
										}
										transaction5.Commit();
									}
								}
							}
							bool flag20 = MainLift.KesitKodu == "MD";
							if (flag20)
							{
								entity = ascad.FObject("MDEksenYan", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag21 = entity == null;
								if (flag21)
								{
									entity = ascad.FObject("MDEksenSag", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								}
								bool flag22 = entity == null;
								if (flag22)
								{
									entity = ascad.FObject("MDEksenArka", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								}
								bool flag23 = entity != null;
								if (flag23)
								{
									double num5 = 2.0 * Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + 1.5 * Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
									num5 = num5 + 300.0 + 100.0;
									num5 += Convert.ToDouble(this.GetNumValue("FMakine", Convert.ToString(MainLift.LiftNum)));
									num5 *= 9.81;
									this.ChTag(entity.get_ObjectId(), "TAGPS", string.Format("PS {0:0}N", num5));
								}
								entity = ascad.FObject("MDaire", "1", MainLift.KesitKodu);
								bool flag24 = entity != null;
								if (flag24)
								{
									this.ChTag(entity.get_ObjectId(), "KUYU", "MAKINE DAIRESI KESITI O:1/" + this.GetNumValue("MDOLCEK", "1"));
								}
							}
							bool flag25 = MainLift.KesitKodu == "KD";
							if (flag25)
							{
								entity = ascad.FObject("KotSembolUst", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag26 = entity != null;
								if (flag26)
								{
									this.ChTag(entity.get_ObjectId(), "KOT", this.GetNumValue("KuyuDibi", Convert.ToString(MainLift.LiftNum)));
								}
								entity = ascad.FObject("KabinRay", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag27 = entity != null;
								if (flag27)
								{
									double num6 = Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
									num6 = 39.24 * num6;
									this.ChTag(entity.get_ObjectId(), "TAGP1", string.Format("{0:0}N", num6));
									num6 = Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
									num6 = 19.62 * num6 / 2.0;
									this.ChTag(entity.get_ObjectId(), "TAGPR1", string.Format("{0:0}N", num6) + " - " + this.GetNumValue("KabinRayStr", Convert.ToString(MainLift.LiftNum)));
									this.ChTag(entity.get_ObjectId(), "TAGPR2", string.Format("{0:0}N", num6));
								}
								entity = ascad.FObject("AgrRay", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag28 = entity != null;
								if (flag28)
								{
									double num6 = 0.5 * Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinAgir", Convert.ToString(MainLift.LiftNum)));
									num6 = 39.24 * num6;
									this.ChTag(entity.get_ObjectId(), "TAGP2", string.Format("P2 {0:0}N", num6) + " - " + this.GetNumValue("AgrRayStr", Convert.ToString(MainLift.LiftNum)));
								}
							}
							bool flag29 = MainLift.KesitKodu == "KK";
							if (flag29)
							{
								entity = ascad.FObject("Kabin", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag30 = entity != null;
								if (flag30)
								{
									this.ChTag(entity.get_ObjectId(), "KABINALAN", "KABiN:" + string.Format("{0:0.##}", Convert.ToDecimal(this.prman.GetParamValFRM(text + "KabinGen", MainLift.KesitKodu)) * Convert.ToDecimal(this.prman.GetParamValFRM(text + "KabinDer", MainLift.KesitKodu)) / 1000000m) + "m2");
									this.beyanqbul(Convert.ToString(MainLift.LiftNum));
								}
								entity = ascad.FObject("AgrRay", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag31 = entity != null;
								if (flag31)
								{
									this.ChTag(entity.get_ObjectId(), "TAGP2", " ");
								}
							}
							bool flag32 = (MainLift.KesitKodu == "KK" || MainLift.KesitKodu == "KD") && MainLift.Tahrik.TipKodu == "HA";
							if (flag32)
							{
								entity = ascad.FObject("HidrolikSemer", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
								bool flag33 = entity != null;
								if (flag33)
								{
									using (Transaction transaction6 = database.get_TransactionManager().StartTransaction())
									{
										bool flag34 = MainLift.Tahrik.YonKodu == "SOL";
										if (flag34)
										{
											this.SetDynamicValue(database, transaction6, entity, "Angle1", 0.0);
										}
										bool flag35 = MainLift.Tahrik.YonKodu == "SAG";
										if (flag35)
										{
											this.SetDynamicValue(database, transaction6, entity, "Angle1", 3.14159265);
										}
										bool flag36 = MainLift.Tahrik.YonKodu == "ARKA";
										if (flag36)
										{
											this.SetDynamicValue(database, transaction6, entity, "Angle1", 4.7123889750000005);
										}
										transaction6.Commit();
									}
								}
							}
						}
					}
				}
			}
			catch (Exception var_71_1024)
			{
			}
			catch (Exception var_72_102A)
			{
			}
		}

		public void dimdene(string KesitKodu = "KK", string LiftNumber = "1")
		{
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					Point3d xLine1Point = default(Point3d);
					Point3d xLine2Point = default(Point3d);
					Point3d textPosition = default(Point3d);
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							Entity entity = ascad.FObject("DIMDYN", LiftNumber, KesitKodu);
							bool flag2 = entity != null;
							if (flag2)
							{
								BlockReference blockReference = (BlockReference)transaction.GetObject(entity.get_ObjectId(), 0);
								DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
								foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
								{
									string propertyName = dynamicBlockReferenceProperty.get_PropertyName();
									bool flag3 = propertyName == "Origin" || propertyName.LastIndexOf("P1X") != -1 || propertyName.LastIndexOf("P1Y") != -1 || propertyName.LastIndexOf("P2X") != -1 || propertyName.LastIndexOf("P2Y") != -1 || propertyName.LastIndexOf("XLX") != -1 || propertyName.LastIndexOf("XLY") != -1;
									Entity entity2;
									if (flag3)
									{
										entity2 = null;
									}
									else
									{
										entity2 = ascad.FObjectDIM(propertyName, LiftNumber, KesitKodu);
									}
									bool flag4 = entity2 != null;
									if (flag4)
									{
										Entity entity3 = (Entity)transaction.GetObject(entity2.get_ObjectId(), 1, false, true);
										entity3.UpgradeOpen();
										AlignedDimension alignedDimension = (AlignedDimension)entity3;
										xLine1Point = new Point3d(Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P1X")), Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P1Y")), 0.0);
										xLine2Point = new Point3d(Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P2X")), Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P2Y")), 0.0);
										textPosition = default(Point3d);
										alignedDimension.set_Dimscale(Convert.ToDouble(Application.GetSystemVariable("DIMSCALE")));
										alignedDimension.set_Dimlfac(Convert.ToDouble(Application.GetSystemVariable("DIMLFAC")));
										alignedDimension.set_XLine1Point(xLine1Point);
										alignedDimension.set_XLine2Point(xLine2Point);
										bool flag5 = xLine1Point.get_X() == xLine2Point.get_X();
										if (flag5)
										{
											bool flag6 = xLine1Point.get_Y() > xLine2Point.get_Y();
											if (flag6)
											{
												textPosition = new Point3d(Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLX")), xLine1Point.get_Y() - Math.Abs((xLine2Point.get_Y() - xLine1Point.get_Y()) / 2.0), 0.0);
											}
											else
											{
												textPosition = new Point3d(Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLX")), xLine1Point.get_Y() + Math.Abs((xLine2Point.get_Y() - xLine1Point.get_Y()) / 2.0), 0.0);
											}
										}
										else
										{
											bool flag7 = xLine1Point.get_X() > xLine2Point.get_X();
											if (flag7)
											{
												textPosition = new Point3d(xLine1Point.get_X() - Math.Abs((xLine2Point.get_X() - xLine1Point.get_X()) / 2.0), Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLY")), 0.0);
											}
											else
											{
												textPosition = new Point3d(xLine1Point.get_X() + Math.Abs((xLine2Point.get_X() - xLine1Point.get_X()) / 2.0), Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLY")), 0.0);
											}
										}
										alignedDimension.set_TextPosition(textPosition);
									}
								}
							}
						}
					}
				}
			}
			catch (Exception var_26_482)
			{
			}
		}

		private List<ConsParList> ReadDimGrup(structTahrikTip TahrikTip, string LiftNumber)
		{
			List<ConsParList> list = new List<ConsParList>();
			vtLift vtLift = new vtLift();
			string text = "KabinBase";
			vtLift.BlkName = text;
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta("select [id],[bmblockname],[BlkInsName],[XData] from [mainblocks$] where [bmblockname]='" + text + "'", "");
				vtLift.BlkInsName = dataTable.Rows[0]["BlkInsName"].ToString();
				vtLift.XData = dataTable.Rows[0]["XData"].ToString();
				DataTable dataTable2 = new DataTable();
				dataTable2 = this.xx.dtta("select [ison],[BlkName],[BlkString] from [BlkPar$] where [ison]=" + dataTable.Rows[0]["id"].ToString(), "");
				bool flag = dataTable2.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						BlkPar item = new BlkPar
						{
							BlkName = dataTable2.Rows[i]["BlkName"].ToString(),
							BlkString = dataTable2.Rows[i]["BlkString"].ToString()
						};
						vtLift.BlkList.Add(item);
					}
					DataTable dataTable3 = new DataTable();
					dataTable3 = this.xx.dtta("select [ParamName],[ParamValue] from [Paramlist$] where [ison]=" + dataTable2.Rows[0]["ison"].ToString(), "");
					bool flag2 = dataTable3.Rows.Count > 0;
					if (flag2)
					{
						for (int j = 0; j < dataTable3.Rows.Count; j++)
						{
							List<ParamList> list2 = new List<ParamList>();
							ParamList item2 = new ParamList
							{
								ParamName = dataTable3.Rows[j]["ParamName"].ToString(),
								ParamValue = dataTable3.Rows[j]["ParamValue"].ToString(),
								plRename = true
							};
							vtLift.BlkParamList.Add(item2);
						}
					}
					DataTable dataTable4 = new DataTable();
					dataTable4 = this.xx.dtta(string.Concat(new string[]
					{
						"select [ParamName],[ParamValue] from `DIM` where TipKodu='",
						TahrikTip.TipKodu,
						"' and (TahrikKodu='TEMEL' or TahrikKodu='",
						TahrikTip.TahrikKodu,
						"') and (YonKodu='TEMEL' or YonKodu='",
						TahrikTip.YonKodu,
						"') and [ison]=",
						dataTable2.Rows[0]["ison"].ToString()
					}), "");
					bool flag3 = dataTable4.Rows.Count > 0;
					if (flag3)
					{
						for (int k = 0; k < dataTable4.Rows.Count; k++)
						{
							ConsParList item3 = new ConsParList
							{
								ConsName = dataTable4.Rows[k]["ParamName"].ToString(),
								ConsValue = dataTable4.Rows[k]["ParamValue"].ToString()
							};
							list.Add(item3);
						}
					}
				}
			}
			catch (Exception var_23_37C)
			{
			}
			finally
			{
			}
			return list;
		}

		private List<ParamList> ReadVarGrup(structTahrikTip TahrikTip, string LiftNumber)
		{
			DataTable dataTable = new DataTable();
			List<ParamList> list = new List<ParamList>();
			vtLift vtLift = new vtLift();
			string text = "KabinBase";
			vtLift.BlkName = text;
			DataTable dataTable2 = new DataTable();
			try
			{
				dataTable2 = this.xx.dtta("select [id],[bmblockname],[BlkInsName],[XData] from [mainblocks$] where [bmblockname]='" + text + "'", "");
				vtLift.BlkInsName = dataTable2.Rows[0]["BlkInsName"].ToString();
				vtLift.XData = dataTable2.Rows[0]["XData"].ToString();
				DataTable dataTable3 = new DataTable();
				dataTable3 = this.xx.dtta("select [ison],[BlkName],[BlkString] from [BlkPar$] where [ison]=" + dataTable2.Rows[0]["id"].ToString(), "");
				bool flag = dataTable3.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable3.Rows.Count; i++)
					{
						BlkPar item = new BlkPar
						{
							BlkName = dataTable3.Rows[i]["BlkName"].ToString(),
							BlkString = dataTable3.Rows[i]["BlkString"].ToString()
						};
						vtLift.BlkList.Add(item);
					}
					DataTable dataTable4 = new DataTable();
					dataTable4 = this.xx.dtta("select [ParamName],[ParamValue] from `Paramlist` where [ison]=" + dataTable3.Rows[0]["ison"].ToString(), "");
					bool flag2 = dataTable4.Rows.Count > 0;
					if (flag2)
					{
						for (int j = 0; j < dataTable4.Rows.Count; j++)
						{
							List<ParamList> list2 = new List<ParamList>();
							ParamList item2 = new ParamList
							{
								ParamName = dataTable4.Rows[j]["ParamName"].ToString(),
								ParamValue = dataTable4.Rows[j]["ParamValue"].ToString(),
								plRename = true
							};
							vtLift.BlkParamList.Add(item2);
						}
					}
					dataTable = this.xx.dtta("select [ParamName],[ParamValue] from `Num" + LiftNumber + "` where [ison]=" + dataTable3.Rows[0]["ison"].ToString(), "");
					bool flag3 = dataTable.Rows.Count > 0;
					if (flag3)
					{
						for (int k = 0; k < dataTable.Rows.Count; k++)
						{
							ParamList item3 = new ParamList
							{
								ParamName = dataTable.Rows[k]["ParamName"].ToString(),
								ParamValue = dataTable.Rows[k]["ParamValue"].ToString(),
								plRename = true
							};
							list.Add(item3);
						}
					}
					DataTable dataTable5 = new DataTable();
					dataTable5 = this.xx.dtta(string.Concat(new string[]
					{
						"select [ParamName],[ParamValue] from `VAR` where TipKodu='",
						TahrikTip.TipKodu,
						"' and (TahrikKodu='TEMEL' or TahrikKodu='",
						TahrikTip.TahrikKodu,
						"') and (YonKodu='TEMEL' or YonKodu='",
						TahrikTip.YonKodu,
						"') and [ison]=",
						dataTable3.Rows[0]["ison"].ToString()
					}), "");
					bool flag4 = dataTable5.Rows.Count > 0;
					if (flag4)
					{
						for (int l = 0; l < dataTable5.Rows.Count; l++)
						{
							ParamList item4 = new ParamList
							{
								ParamName = dataTable5.Rows[l]["ParamName"].ToString(),
								ParamValue = dataTable5.Rows[l]["ParamValue"].ToString(),
								plRename = true
							};
							list.Add(item4);
						}
					}
				}
			}
			catch (Exception var_27_474)
			{
			}
			finally
			{
			}
			return list;
		}

		private List<ParamList> ReadVarGrup(string LiftNumber)
		{
			DataTable dataTable = new DataTable();
			List<ParamList> list = new List<ParamList>();
			vtLift vtLift = new vtLift();
			string text = "KabinBase";
			vtLift.BlkName = text;
			DataTable dataTable2 = new DataTable();
			try
			{
				dataTable2 = this.xx.dtta("select [id],[bmblockname],[BlkInsName],[XData] from [mainblocks$] where [bmblockname]='" + text + "'", "");
				vtLift.BlkInsName = dataTable2.Rows[0]["BlkInsName"].ToString();
				vtLift.XData = dataTable2.Rows[0]["XData"].ToString();
				DataTable dataTable3 = new DataTable();
				dataTable3 = this.xx.dtta("select [ison],[BlkName],[BlkString] from [BlkPar$] where [ison]=" + dataTable2.Rows[0]["id"].ToString(), "");
				bool flag = dataTable3.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable3.Rows.Count; i++)
					{
						BlkPar item = new BlkPar
						{
							BlkName = dataTable3.Rows[i]["BlkName"].ToString(),
							BlkString = dataTable3.Rows[i]["BlkString"].ToString()
						};
						vtLift.BlkList.Add(item);
					}
					dataTable = this.xx.dtta("select [ParamName],[ParamValue] from `Num" + LiftNumber + "` where [ison]=" + dataTable3.Rows[0]["ison"].ToString(), "");
					bool flag2 = dataTable.Rows.Count > 0;
					if (flag2)
					{
						for (int j = 0; j < dataTable.Rows.Count; j++)
						{
							ParamList item2 = new ParamList
							{
								ParamName = dataTable.Rows[j]["ParamName"].ToString(),
								ParamValue = dataTable.Rows[j]["ParamValue"].ToString(),
								plRename = true
							};
							list.Add(item2);
						}
					}
				}
			}
			catch (Exception var_16_258)
			{
			}
			finally
			{
			}
			return list;
		}

		private List<structAnaTip> ReadAnaTip()
		{
			List<structAnaTip> list = new List<structAnaTip>();
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta("select [TipKodu],[TipAdi] from [AnaTip$]", "");
				bool flag = dataTable.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						structAnaTip item = new structAnaTip
						{
							TipKodu = dataTable.Rows[i]["TipKodu"].ToString(),
							TipAdi = dataTable.Rows[i]["TipAdi"].ToString()
						};
						list.Add(item);
					}
				}
			}
			catch (Exception var_8_C3)
			{
			}
			finally
			{
			}
			return list;
		}

		private List<structTahrikTip> ReadTahrikTip(structAnaTip AnaTip)
		{
			List<structTahrikTip> list = new List<structTahrikTip>();
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta("select [TipKodu],[TipAdi],[TahrikKodu],[TipIndex] from [TahrikTip$] where [TipKodu]='" + AnaTip.TipKodu + "'", "");
				bool flag = dataTable.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						structTahrikTip item = new structTahrikTip
						{
							TipKodu = dataTable.Rows[i]["TipKodu"].ToString(),
							TipAdi = dataTable.Rows[i]["TipAdi"].ToString(),
							TahrikKodu = dataTable.Rows[i]["TahrikKodu"].ToString(),
							TipIndex = dataTable.Rows[i]["TipIndex"].ToString()
						};
						list.Add(item);
					}
				}
			}
			catch (Exception var_8_122)
			{
			}
			finally
			{
			}
			return list;
		}

		private List<structTahrikYon> ReadTahrikYon(structAnaTip AnaTip)
		{
			List<structTahrikYon> list = new List<structTahrikYon>();
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta("select [TipKodu],[TipAdi],[TahrikYonKodu] from [TahrikYon$] where [TipKodu]='" + AnaTip.TipKodu + "'", "");
				bool flag = dataTable.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						structTahrikYon item = new structTahrikYon
						{
							TipKodu = dataTable.Rows[i]["TipKodu"].ToString(),
							TipAdi = dataTable.Rows[i]["TipAdi"].ToString(),
							YonKodu = dataTable.Rows[i]["TahrikYonKodu"].ToString()
						};
						list.Add(item);
					}
				}
			}
			catch (Exception var_8_FE)
			{
			}
			finally
			{
			}
			return list;
		}

		private vtLift dtta(string blockadi, string LiftNumber)
		{
			vtLift vtLift = new vtLift();
			vtLift.BlkName = blockadi;
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta("select [id],[bmblockname],[BlkInsName],[XData] from [mainblocks$] where [bmblockname]='" + blockadi + "'", "");
				vtLift.BlkInsName = dataTable.Rows[0]["BlkInsName"].ToString();
				vtLift.XData = dataTable.Rows[0]["XData"].ToString();
				DataTable dataTable2 = new DataTable();
				dataTable2 = this.xx.dtta("select [ison],[BlkName],[BlkString] from [BlkPar$] where [ison]=" + dataTable.Rows[0]["id"].ToString(), "");
				bool flag = dataTable2.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						BlkPar item = new BlkPar
						{
							BlkName = dataTable2.Rows[i]["BlkName"].ToString(),
							BlkString = dataTable2.Rows[i]["BlkString"].ToString()
						};
						vtLift.BlkList.Add(item);
					}
					DataTable dataTable3 = new DataTable();
					dataTable3 = this.xx.dtta("select [ParamName],[ParamValue] from Paramlist where [ison]=" + dataTable2.Rows[0]["ison"].ToString(), "");
					bool flag2 = dataTable3.Rows.Count > 0;
					if (flag2)
					{
						for (int j = 0; j < dataTable3.Rows.Count; j++)
						{
							List<ParamList> list = new List<ParamList>();
							ParamList item2 = new ParamList
							{
								ParamName = dataTable3.Rows[j]["ParamName"].ToString(),
								ParamValue = dataTable3.Rows[j]["ParamValue"].ToString(),
								plRename = true
							};
							vtLift.BlkParamList.Add(item2);
						}
					}
				}
			}
			catch (Exception var_15_247)
			{
			}
			finally
			{
			}
			return vtLift;
		}

		public structTahrik ReadTahrikData(string LiftNumber)
		{
			return new structTahrik
			{
				TipKodu = this.GetNumValue("TipKodu", LiftNumber),
				TahrikKodu = this.GetNumValue("TahrikKodu", LiftNumber),
				YonKodu = this.GetNumValue("YonKodu", LiftNumber)
			};
		}

		public clsMLift ReadAllData(string LiftNumber, string KesitKodu)
		{
			clsMLift clsMLift = new clsMLift();
			clsMLift.KesitKodu = KesitKodu;
			clsMLift.KatBilgileri = new structKatBilgileri
			{
				DurakSayi = "5",
				IlkDurakNo = "0",
				KuyuMesafesi = "15.000",
				SeyirMesafesi = "10.250"
			};
			clsMLift.Pan = this.GetNumValue("Pan", LiftNumber);
			structTahrik tahrik = default(structTahrik);
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			try
			{
				tahrik.TipKodu = this.GetNumValue("TipKodu", LiftNumber);
				tahrik.TahrikKodu = this.GetNumValue("TahrikKodu", LiftNumber);
				tahrik.YonKodu = this.GetNumValue("YonKodu", LiftNumber);
				bool flag = tahrik.YonKodu == "ARKA";
				if (flag)
				{
					clsMLift.Pan = "0";
				}
				clsMLift.Tahrik = tahrik;
				DataTable dataTable3 = new DataTable();
				dataTable3 = this.xx.dtta(string.Concat(new string[]
				{
					"select id,bmblockname,BlkInsName,XData from `BLK` WHERE (TipKodu LIKE '%",
					tahrik.TipKodu,
					"%' or TipKodu='TEMEL') and (TahrikKodu LIKE'%",
					tahrik.TahrikKodu,
					"%' or TahrikKodu='TEMEL')  and (YonKodu LIKE '%",
					tahrik.YonKodu,
					"%' or YonKodu='TEMEL') and KesitKodu='",
					clsMLift.KesitKodu,
					"' ORDER BY sno"
				}), "");
				bool flag2 = dataTable3.Rows.Count > 0;
				if (flag2)
				{
					int i = 0;
					while (i < dataTable3.Rows.Count)
					{
						vtLift vtLift = new vtLift();
						vtLift.BlkName = dataTable3.Rows[i]["bmblockname"].ToString();
						vtLift.BlkInsName = dataTable3.Rows[i]["BlkInsName"].ToString();
						bool flag3 = tahrik.TahrikKodu == "HY";
						if (!flag3)
						{
							goto IL_21E;
						}
						bool flag4 = vtLift.BlkInsName == "HSSol";
						if (!flag4)
						{
							bool flag5 = vtLift.BlkInsName == "HidrolikEksen";
							if (!flag5)
							{
								goto IL_21E;
							}
						}
						IL_525:
						i++;
						continue;
						IL_21E:
						bool flag6 = KesitKodu == "KK" && clsMLift.Pan == "1" && vtLift.BlkInsName == "Kabin1-DYN";
						if (flag6)
						{
							vtLift.BlkInsName = "KabinPan";
							vtLift vtLift2 = new vtLift();
							vtLift2.BlkName = "PanBLK";
							vtLift2.BlkInsName = "PanBLK";
							vtLift2.XData = "PanBLK";
							ParamList item = default(ParamList);
							item.ParamName = "dynPanX";
							item.ParamValue = "KabinXEksen";
							item.plRename = true;
							vtLift2.BlkParamList.Add(item);
							item.ParamName = "dynPanY";
							item.ParamValue = "KabinYEksen+KabinDer";
							item.plRename = true;
							vtLift2.BlkParamList.Add(item);
							item.ParamName = "dynPanKabinGen";
							item.ParamValue = "KabinGen";
							item.plRename = true;
							vtLift2.BlkParamList.Add(item);
							clsMLift.BlokGrup.Add(vtLift2);
						}
						vtLift.XData = dataTable3.Rows[i]["XData"].ToString();
						bool flag7 = vtLift.BlkInsName.IndexOf("COMP:") != -1;
						if (flag7)
						{
							string[] array = vtLift.BlkInsName.Split(new char[]
							{
								Convert.ToChar(":")
							});
							array[1] = array[1].Replace("%", LiftNumber);
							dataTable2 = this.xx.dtta("select ParamName,ParamValue from `" + array[1] + "` where ParamName='BlkInsName'", "");
							bool flag8 = dataTable2.Rows.Count > 0;
							if (flag8)
							{
								vtLift.BlkInsName = dataTable2.Rows[0]["ParamValue"].ToString();
							}
						}
						DataTable dataTable4 = new DataTable();
						string str = dataTable3.Rows[i]["id"].ToString();
						dataTable4 = this.xx.dtta("select ison,ParamName,ParamValue from `PARAM` where ison='" + str + "'", "");
						bool flag9 = dataTable4.Rows.Count > 0;
						if (flag9)
						{
							for (int j = 0; j < dataTable4.Rows.Count; j++)
							{
								List<ParamList> list = new List<ParamList>();
								ParamList item2 = new ParamList
								{
									ParamName = dataTable4.Rows[j]["ParamName"].ToString(),
									ParamValue = dataTable4.Rows[j]["ParamValue"].ToString(),
									plRename = true
								};
								vtLift.BlkParamList.Add(item2);
							}
						}
						clsMLift.BlokGrup.Add(vtLift);
						goto IL_525;
					}
				}
				DataTable dataTable5 = new DataTable();
				dataTable5 = this.xx.dtta(string.Concat(new string[]
				{
					"select ParamName,ParamValue from `Num",
					LiftNumber,
					"` where (TipKodu LIKE '%",
					tahrik.TipKodu,
					"%' or TipKodu='TEMEL') and (TahrikKodu LIKE '%",
					tahrik.TahrikKodu,
					"%' or TahrikKodu='TEMEL')  and (YonKodu LIKE '%",
					tahrik.YonKodu,
					"%' or YonKodu='TEMEL')"
				}), "");
				bool flag10 = dataTable5.Rows.Count > 0;
				if (flag10)
				{
					for (int k = 0; k < dataTable5.Rows.Count; k++)
					{
						ParamList item3 = default(ParamList);
						item3.ParamName = dataTable5.Rows[k]["ParamName"].ToString();
						bool flag11 = item3.ParamName == "KabinRayFark" || item3.ParamName == "KabinAgrEksenFark";
						if (flag11)
						{
							item3.ParamValue = dataTable5.Rows[k]["ParamValue"].ToString();
						}
						else
						{
							item3.ParamValue = dataTable5.Rows[k]["ParamValue"].ToString().Replace("-", "");
						}
						item3.plRename = true;
						clsMLift.VarGrup.Add(item3);
					}
				}
				DataTable dataTable6 = new DataTable();
				dataTable6 = this.xx.dtta(string.Concat(new string[]
				{
					"select ParamName,ParamValue from `VAR` where TipKodu LIKE '%",
					clsMLift.Tahrik.TipKodu,
					"%' and (TahrikKodu='TEMEL' or TahrikKodu LIKE '%",
					clsMLift.Tahrik.TahrikKodu,
					"%') and (YonKodu='TEMEL' or YonKodu LIKE '%",
					clsMLift.Tahrik.YonKodu,
					"%')"
				}), "");
				bool flag12 = dataTable6.Rows.Count > 0;
				if (flag12)
				{
					for (int l = 0; l < dataTable6.Rows.Count; l++)
					{
						ParamList item4 = new ParamList
						{
							ParamName = dataTable6.Rows[l]["ParamName"].ToString(),
							ParamValue = dataTable6.Rows[l]["ParamValue"].ToString(),
							plRename = true
						};
						clsMLift.VarGrup.Add(item4);
						bool flag13 = tahrik.TahrikKodu == "SD";
						if (flag13)
						{
						}
					}
				}
				DataTable dataTable7 = new DataTable();
				dataTable7 = this.xx.dtta(string.Concat(new string[]
				{
					"select ParamName,ParamValue from `DIM` where TipKodu LIKE '%",
					clsMLift.Tahrik.TipKodu,
					"%' and (TahrikKodu='TEMEL' or TahrikKodu LIKE '%",
					clsMLift.Tahrik.TahrikKodu,
					"%') and (YonKodu='TEMEL' or YonKodu LIKE '%",
					clsMLift.Tahrik.YonKodu,
					"%') and KesitKodu LIKE '%",
					clsMLift.KesitKodu,
					"%'"
				}), "");
				bool flag14 = dataTable7.Rows.Count > 0;
				if (flag14)
				{
					for (int m = 0; m < dataTable7.Rows.Count; m++)
					{
						ConsParList item5 = new ConsParList
						{
							ConsName = dataTable7.Rows[m]["ParamName"].ToString(),
							ConsValue = dataTable7.Rows[m]["ParamValue"].ToString()
						};
						bool flag15 = tahrik.TahrikKodu == "HY" && item5.ConsName == "consAgrSag";
						if (flag15)
						{
							item5.ConsValue = "KabinYEksen+(KabinDer/2)+HYFARK";
						}
						bool flag16 = tahrik.TahrikKodu == "HY" && item5.ConsName == "consAgrSol";
						if (flag16)
						{
							item5.ConsValue = "KuyuDer-(KabinYEksen+(KabinDer/2)+HYFARK+HRA)";
						}
						clsMLift.DimGrup.Add(item5);
					}
				}
				DataTable dataTable8 = new DataTable();
				dataTable8 = this.xx.dtta(string.Concat(new string[]
				{
					"select DimBlk,SolKac,SagKac from `DimBlok` where TipKodu='",
					clsMLift.Tahrik.TipKodu,
					"' and (TahrikKodu='TEMEL' or TahrikKodu LIKE '%",
					clsMLift.Tahrik.TahrikKodu,
					"%') and (YonKodu='TEMEL' or YonKodu='",
					clsMLift.Tahrik.YonKodu,
					"') and KesitKodu='",
					clsMLift.KesitKodu,
					"'"
				}), "");
				bool flag17 = dataTable8.Rows.Count > 0;
				if (flag17)
				{
					for (int n = 0; n < dataTable8.Rows.Count; n++)
					{
						structDimblk item6 = new structDimblk
						{
							DimBlk = dataTable8.Rows[n]["DimBlk"].ToString(),
							SolKac = dataTable8.Rows[n]["SolKac"].ToString(),
							SagKac = dataTable8.Rows[n]["SagKac"].ToString()
						};
						clsMLift.DimBlkList.Add(item6);
					}
				}
			}
			catch (Exception var_55_B10)
			{
			}
			finally
			{
			}
			return clsMLift;
		}

		private vtLift ReadData(string blockadi, string LiftNumber, string TipKodu, string TahrikKodu, string YonKodu)
		{
			vtLift vtLift = new vtLift();
			vtLift.BlkName = blockadi;
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta(string.Concat(new string[]
				{
					"select id,bmblockname,BlkInsName,XData from `BLK` where bmblockname='",
					blockadi,
					"' and TipKodu='",
					TipKodu,
					"' and (TahrikKodu='",
					TahrikKodu,
					"' or TahrikKodu='TEMEL') and (YonKodu='",
					YonKodu,
					"' or YonKodu='TEMEL') and KesitKodu='KK'"
				}), "");
				vtLift.BlkInsName = dataTable.Rows[0]["BlkInsName"].ToString();
				vtLift.XData = dataTable.Rows[0]["XData"].ToString();
				DataTable dataTable2 = new DataTable();
				dataTable2 = this.xx.dtta("select ison,BlkName,BlkString from BlkPar where ison=" + dataTable.Rows[0]["id"].ToString(), "");
				bool flag = dataTable2.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						BlkPar item = new BlkPar
						{
							BlkName = dataTable2.Rows[i]["BlkName"].ToString(),
							BlkString = dataTable2.Rows[i]["BlkString"].ToString()
						};
						vtLift.BlkList.Add(item);
					}
					DataTable dataTable3 = new DataTable();
					dataTable3 = this.xx.dtta("select [ParamName],[ParamValue] from `PARAM` where [ison]=" + dataTable2.Rows[0]["ison"].ToString(), "");
					bool flag2 = dataTable3.Rows.Count > 0;
					if (flag2)
					{
						for (int j = 0; j < dataTable3.Rows.Count; j++)
						{
							List<ParamList> list = new List<ParamList>();
							ParamList item2 = new ParamList
							{
								ParamName = dataTable3.Rows[j]["ParamName"].ToString(),
								ParamValue = dataTable3.Rows[j]["ParamValue"].ToString(),
								plRename = true
							};
							vtLift.BlkParamList.Add(item2);
						}
					}
				}
			}
			catch (Exception var_15_27D)
			{
			}
			finally
			{
			}
			return vtLift;
		}

		private vtLift ReadData2(string blockadi, string LiftNumber, string BlkTab, string ParamTab)
		{
			vtLift vtLift = new vtLift();
			vtLift.BlkName = blockadi;
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta(string.Concat(new string[]
				{
					"select id,bmblockname,BlkInsName,XData from `",
					BlkTab,
					"` where bmblockname='",
					blockadi,
					"'"
				}), "");
				vtLift.BlkInsName = dataTable.Rows[0]["BlkInsName"].ToString();
				vtLift.XData = dataTable.Rows[0]["XData"].ToString();
				DataTable dataTable2 = new DataTable();
				dataTable2 = this.xx.dtta("select ison,BlkName,BlkString from BlkPar where ison=" + dataTable.Rows[0]["id"].ToString(), "");
				bool flag = dataTable2.Rows.Count > 0;
				if (flag)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						BlkPar item = new BlkPar
						{
							BlkName = dataTable2.Rows[i]["BlkName"].ToString(),
							BlkString = dataTable2.Rows[i]["BlkString"].ToString()
						};
						vtLift.BlkList.Add(item);
					}
					DataTable dataTable3 = new DataTable();
					dataTable3 = this.xx.dtta("select [ParamName],[ParamValue] from `" + ParamTab + "` where [ison]=" + dataTable2.Rows[0]["ison"].ToString(), "");
					bool flag2 = dataTable3.Rows.Count > 0;
					if (flag2)
					{
						for (int j = 0; j < dataTable3.Rows.Count; j++)
						{
							List<ParamList> list = new List<ParamList>();
							ParamList item2 = new ParamList
							{
								ParamName = dataTable3.Rows[j]["ParamName"].ToString(),
								ParamValue = dataTable3.Rows[j]["ParamValue"].ToString(),
								plRename = true
							};
							vtLift.BlkParamList.Add(item2);
						}
					}
				}
			}
			catch (Exception var_15_269)
			{
			}
			finally
			{
			}
			return vtLift;
		}

		private string GetTabValue(string TabName)
		{
			string result = null;
			List<structTahrikYon> list = new List<structTahrikYon>();
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta("select [TabName],[TabValue] from `TabList` where [TabName]='" + TabName + "'", "");
				bool flag = dataTable.Rows.Count > 0;
				if (flag)
				{
					result = dataTable.Rows[0]["TabValue"].ToString();
				}
			}
			catch (Exception var_4_64)
			{
			}
			finally
			{
			}
			return result;
		}

		public string GetNumValue(string ParamName, string LiftNumber)
		{
			string result = null;
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta(string.Concat(new string[]
				{
					"select ParamName,ParamValue from `Num",
					LiftNumber,
					"` where ParamName='",
					ParamName,
					"'"
				}), "");
				bool flag = dataTable.Rows.Count > 0;
				if (flag)
				{
					result = dataTable.Rows[0]["ParamValue"].ToString();
				}
			}
			catch (Exception var_3_79)
			{
			}
			finally
			{
			}
			return result;
		}

		private string GetGirisValue(string ParamName, string LiftNumber)
		{
			string result = null;
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = this.xx.dtta(string.Concat(new string[]
				{
					"select ParamName,ParamValue from `Giris",
					LiftNumber,
					"` where ParamName='",
					ParamName,
					"'"
				}), "");
				bool flag = dataTable.Rows.Count > 0;
				if (flag)
				{
					result = dataTable.Rows[0]["ParamValue"].ToString();
				}
			}
			catch (Exception var_3_79)
			{
			}
			finally
			{
			}
			return result;
		}

		public void RefreshDrawing(clsMLift MainLift)
		{
			this.prman.aadd = this;
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					string lLNum = "PL" + Convert.ToString(MainLift.LiftNum);
					string lLNum2 = "L" + Convert.ToString(MainLift.LiftNum);
					double num = MainLift.Olcek;
					bool flag2 = num == 1.0 || num == 0.0;
					if (flag2)
					{
						Application.SetSystemVariable("DIMSCALE", 40.0);
						Application.SetSystemVariable("DIMLFAC", 1.0);
					}
					else
					{
						num = 1.0 / Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
						Application.SetSystemVariable("DIMLFAC", Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1")));
					}
					Scale3d scale3d = default(Scale3d);
					foreach (vtLift current in MainLift.BlokGrup)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							Entity entity = ascad.FObject(current.XData, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
							bool flag3 = entity != null;
							if (flag3)
							{
								BlockReference blockReference = (BlockReference)transaction.GetObject(entity.get_ObjectId(), 0);
								blockReference.UpgradeOpen();
								blockReference.set_Position(MainLift.BasePoint);
								this.SetDynamicValue(database, transaction, entity, current, lLNum2, blockReference.get_ScaleFactors().get_X(), MainLift.KesitKodu);
							}
							transaction.Commit();
						}
					}
					bool flag4 = MainLift.KesitKodu == "KK" || MainLift.KesitKodu == "KD";
					if (flag4)
					{
						Entity entity = ascad.FObject("DIMDYN" + MainLift.KesitKodu, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
						bool flag5 = entity != null;
						if (flag5)
						{
							using (Transaction transaction2 = database.get_TransactionManager().StartTransaction())
							{
								BlockReference blockReference2 = (BlockReference)transaction2.GetObject(entity.get_ObjectId(), 0);
								blockReference2.UpgradeOpen();
								blockReference2.set_Position(MainLift.BasePoint);
								this.SetDynamicValue(database, transaction2, entity, MainLift, lLNum, blockReference2.get_ScaleFactors().get_X(), MainLift.KesitKodu);
								transaction2.Commit();
							}
						}
						this.dimdene2(Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu, MainLift.BasePoint, false);
					}
				}
			}
			catch (Exception var_53_322)
			{
			}
			catch (Exception var_54_328)
			{
			}
		}

		[CommandMethod("PDrawing")]
		public void PDrawing()
		{
			clsMLift clsMLift = new clsMLift();
			clsMLift = this.ReadAllData("1", "KK");
			clsMLift.LiftNum = Convert.ToInt32("1");
			this.PDrawing(clsMLift);
		}

		public void PDrawing(clsMLift MainLift)
		{
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							string text = "PL" + Convert.ToString(MainLift.LiftNum);
							string str = "L" + Convert.ToString(MainLift.LiftNum);
							Entity entity;
							foreach (vtLift current in MainLift.BlokGrup)
							{
								entity = ascad.FObject(current.XData, Convert.ToString(MainLift.LiftNum), "0");
								bool flag2 = entity != null;
								if (flag2)
								{
									foreach (ParamList current2 in current.BlkParamList)
									{
										double value = Convert.ToDouble(this.GetParamValue(str + current2.ParamName));
										this.SetDynamicValue(database, transaction, entity, current2.ParamName, Math.Abs(value));
									}
								}
							}
							bool flag3 = MainLift.Tahrik.TahrikKodu == "MDCAP" || MainLift.Tahrik.TahrikKodu == "SD";
							if (flag3)
							{
								entity = ascad.FObject("Capraz", Convert.ToString(MainLift.LiftNum), "0");
								bool flag4 = entity != null;
								if (flag4)
								{
									double num = Convert.ToDouble(this.GetParamValue(str + "AKenar"));
									double num2 = Convert.ToDouble(this.GetParamValue(str + "BKenar"));
									double num3 = Math.Sqrt(num * num + num2 * num2);
									double num4 = num / num3;
									bool flag5 = MainLift.Tahrik.YonKodu == "SAG";
									if (flag5)
									{
										this.SetDynamicValue(database, transaction, entity, "dynRotAng", Math.Asin(num4));
									}
									else
									{
										this.SetDynamicValue(database, transaction, entity, "dynRotAng", 3.1415926535897931 - Math.Asin(Math.Abs(num4)));
									}
									this.SetDynamicValue(database, transaction, entity, "Distance1", (double)Convert.ToInt32(num3));
								}
							}
							bool flag6 = (MainLift.KesitKodu == "KK" || MainLift.KesitKodu == "KD") && MainLift.Tahrik.TipKodu == "EA";
							if (flag6)
							{
								entity = ascad.FObject("RegUst", Convert.ToString(MainLift.LiftNum), "0");
								bool flag7 = entity != null;
								if (flag7)
								{
									string numValue = this.GetNumValue("RegYer", Convert.ToString(MainLift.LiftNum));
									if (!(numValue == "1"))
									{
										if (!(numValue == "2"))
										{
											if (!(numValue == "3"))
											{
												if (numValue == "4")
												{
													this.SetDynamicValue(database, transaction, entity, "dynRegFlipX", 1.0);
													this.SetDynamicValue(database, transaction, entity, "dynRegFlipY", 0.0);
												}
											}
											else
											{
												this.SetDynamicValue(database, transaction, entity, "dynRegFlipX", 0.0);
												this.SetDynamicValue(database, transaction, entity, "dynRegFlipY", 0.0);
											}
										}
										else
										{
											this.SetDynamicValue(database, transaction, entity, "dynRegFlipX", 0.0);
											this.SetDynamicValue(database, transaction, entity, "dynRegFlipY", 1.0);
										}
									}
									else
									{
										this.SetDynamicValue(database, transaction, entity, "dynRegFlipX", 1.0);
										this.SetDynamicValue(database, transaction, entity, "dynRegFlipY", 1.0);
									}
								}
							}
							bool flag8 = MainLift.KesitKodu == "MD";
							if (flag8)
							{
								entity = ascad.FObject("MDEksenYan", Convert.ToString(MainLift.LiftNum), "0");
								bool flag9 = entity == null;
								if (flag9)
								{
									entity = ascad.FObject("MDEksenSag", Convert.ToString(MainLift.LiftNum), "0");
								}
								bool flag10 = entity == null;
								if (flag10)
								{
									entity = ascad.FObject("MDEksenArka", Convert.ToString(MainLift.LiftNum), "0");
								}
								bool flag11 = entity != null;
								if (flag11)
								{
									double num5 = 2.0 * Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + 1.5 * Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
									num5 = num5 + 300.0 + 100.0;
									num5 += Convert.ToDouble(this.GetNumValue("FMakine", Convert.ToString(MainLift.LiftNum)));
									num5 *= 9.81;
									this.ChTag(entity.get_ObjectId(), "TAGPS", string.Format("PS {0:0}N", num5));
								}
								entity = ascad.FObject("MDaire", "1", "0");
								bool flag12 = entity != null;
								if (flag12)
								{
									this.ChTag(entity.get_ObjectId(), "KUYU", "MAKINE DAIRESI KESITI O:1/" + this.GetNumValue("MDOLCEK", "1"));
								}
							}
							bool flag13 = MainLift.KesitKodu == "KD";
							if (flag13)
							{
								this.beyanqbul(Convert.ToString(MainLift.LiftNum));
								entity = ascad.FObject("KotSembolUst", Convert.ToString(MainLift.LiftNum), "0");
								bool flag14 = entity != null;
								if (flag14)
								{
									this.ChTag(entity.get_ObjectId(), "KOT", "-1500");
								}
								entity = ascad.FObject("KabinRay", Convert.ToString(MainLift.LiftNum), "0");
								bool flag15 = entity != null;
								if (flag15)
								{
									double num6 = Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
									num6 = 39.24 * num6;
									this.ChTag(entity.get_ObjectId(), "TAGP1", string.Format("{0:0}N", num6));
									num6 = Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
									num6 = 19.62 * num6 / 2.0;
									this.ChTag(entity.get_ObjectId(), "TAGPR1", string.Format("{0:0}N", num6) + " - " + this.GetNumValue("KabinRayStr", Convert.ToString(MainLift.LiftNum)));
									this.ChTag(entity.get_ObjectId(), "TAGPR2", string.Format("{0:0}N", num6));
								}
								entity = ascad.FObject("AgrRay", Convert.ToString(MainLift.LiftNum), "0");
								bool flag16 = entity != null;
								if (flag16)
								{
									double num6 = 0.5 * Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinAgir", Convert.ToString(MainLift.LiftNum)));
									num6 = 39.24 * num6;
									this.ChTag(entity.get_ObjectId(), "TAGP2", string.Format("P2 {0:0}N", num6) + " - " + this.GetNumValue("AgrRayStr", Convert.ToString(MainLift.LiftNum)));
								}
							}
							bool flag17 = MainLift.KesitKodu == "KK";
							if (flag17)
							{
								entity = ascad.FObject("Kabin", Convert.ToString(MainLift.LiftNum), "0");
								bool flag18 = entity != null;
								if (flag18)
								{
									this.ChTag(entity.get_ObjectId(), "KABINALAN", "KABiN:" + string.Format("{0:0.##}", Convert.ToDecimal(this.GetParamValue(str + "KabinGen")) * Convert.ToDecimal(this.GetParamValue(str + "KabinDer")) / 1000000m) + "m2");
								}
								entity = ascad.FObject("AgrRay", Convert.ToString(MainLift.LiftNum), "0");
								bool flag19 = entity != null;
								if (flag19)
								{
									this.ChTag(entity.get_ObjectId(), "TAGP2", " ");
								}
							}
							string text2 = "EmKork";
							entity = ascad.FObject("KabinBase", Convert.ToString(MainLift.LiftNum), "0");
							bool flag20 = entity != null;
							if (flag20)
							{
								string dynamicValue = this.GetDynamicValue(database, transaction, entity, "dynSolKD");
								bool flag21 = Convert.ToDouble(dynamicValue) > 300.0;
								if (flag21)
								{
									text2 += "1";
								}
								else
								{
									text2 += "0";
								}
								dynamicValue = this.GetDynamicValue(database, transaction, entity, "dynArkaKD");
								bool flag22 = Convert.ToDouble(dynamicValue) > 300.0;
								if (flag22)
								{
									text2 += "1";
								}
								else
								{
									text2 += "0";
								}
								dynamicValue = this.GetDynamicValue(database, transaction, entity, "dynSagKD");
								bool flag23 = Convert.ToDouble(dynamicValue) > 300.0;
								if (flag23)
								{
									text2 += "1";
								}
								else
								{
									text2 += "0";
								}
							}
							entity = ascad.FObject("EmniyetKorkuluk", Convert.ToString(MainLift.LiftNum), "0");
							bool flag24 = entity != null;
							if (flag24)
							{
								this.SetDynamicValue(database, transaction, entity, "Visibility1", text2);
							}
							Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("DIMREGEN ", true, false, false);
							Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("REGENALL ", true, false, false);
							Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("CONSTRAINTBAR\nALL\n\nHIDE\n", true, false, false);
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception var_48_B0A)
			{
			}
			catch (Exception var_49_B10)
			{
			}
		}

		private double RadianToDegree(double angle)
		{
			return angle * 57.295779513082323;
		}

		private double DegreeToRadian(double angle)
		{
			return 3.1415926535897931 * angle / 180.0;
		}

		[CommandMethod("blockattdeis2")]
		public void EditBlockTag2()
		{
			string value = "A";
			string textString = "ONSPRDCTN";
			Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
			ObjectId objectId = ascad.FObject("Kabin", "1", "0").get_ObjectId();
			using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
			{
				BlockReference blockReference = (BlockReference)transaction.GetObject(objectId, 1);
				BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockReference.get_BlockTableRecord(), 1);
				foreach (ObjectId objectId2 in blockReference.get_AttributeCollection())
				{
					AttributeReference attributeReference = transaction.GetObject(objectId2, 0) as AttributeReference;
					bool flag = attributeReference == null;
					if (!flag)
					{
						bool flag2 = !attributeReference.get_Tag().Equals(value, StringComparison.CurrentCultureIgnoreCase);
						if (!flag2)
						{
							attributeReference.UpgradeOpen();
							attributeReference.set_TextString(textString);
						}
					}
				}
				transaction.Commit();
			}
		}

		public void ChTag(ObjectId brId, string attName, string newValue)
		{
			Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
			using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
			{
				BlockReference blockReference = (BlockReference)transaction.GetObject(brId, 1);
				BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockReference.get_BlockTableRecord(), 1);
				foreach (ObjectId objectId in blockReference.get_AttributeCollection())
				{
					AttributeReference attributeReference = transaction.GetObject(objectId, 0) as AttributeReference;
					bool flag = attributeReference == null;
					if (!flag)
					{
						bool flag2 = !attributeReference.get_Tag().Equals(attName, StringComparison.CurrentCultureIgnoreCase);
						if (!flag2)
						{
							attributeReference.UpgradeOpen();
							attributeReference.set_TextString(newValue);
						}
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("DALL")]
		public void DALL()
		{
			this.DelAllObject();
		}

		public void DelAllObject()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
			using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
				using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						Entity entity = (Entity)transaction.GetObject(current, 1, false, true);
						entity.UpgradeOpen();
						entity.Erase();
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("DetachBadXrefs")]
		public void detachXREFs()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = (BlockTable)database.get_BlockTableId().GetObject(0);
				using (SymbolTableEnumerator enumerator = blockTable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						BlockTableRecord blockTableRecord = (BlockTableRecord)current.GetObject(0);
						bool ısFromExternalReference = blockTableRecord.get_IsFromExternalReference();
						if (ısFromExternalReference)
						{
							database.DetachXref(current);
						}
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("wblockEntity")]
		public void wblockEntity()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			ObjectIdCollection objectIdCollection = new ObjectIdCollection();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
				using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						objectIdCollection.Add(current);
					}
				}
				transaction.Commit();
			}
			using (Database database2 = new Database(true, false))
			{
				database.Wblock(database2, objectIdCollection, Point3d.get_Origin(), 2);
				bool flag = Directory.Exists("C:\\asnproje");
				if (flag)
				{
					string text = "C:\\asnproje\\wblock.dwg";
					database2.SaveAs(text, 31);
				}
				else
				{
					Directory.CreateDirectory("C:\\asnproje");
					string text2 = "C:\\asnproje\\wblock.dwg";
					database2.SaveAs(text2, 31);
				}
			}
		}

		public void wblockEntity(string FileName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			ObjectIdCollection objectIdCollection = new ObjectIdCollection();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
				using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						objectIdCollection.Add(current);
					}
				}
				transaction.Commit();
			}
			using (Database database2 = new Database(true, false))
			{
				bool flag = Directory.Exists("c:\\asnproje");
				if (flag)
				{
					database.Wblock(database2, objectIdCollection, Point3d.get_Origin(), 2);
					FileName = "c:\\asnproje\\" + FileName + ".dwg";
					database2.SaveAs(FileName, 31);
				}
				else
				{
					Directory.CreateDirectory("c:\\asnproje");
					database.Wblock(database2, objectIdCollection, Point3d.get_Origin(), 2);
					FileName = "c:\\asnproje\\" + FileName + ".dwg";
					database2.SaveAs(FileName, 31);
				}
			}
		}

		public void zoomExtent()
		{
			object zcadApplication = Application.get_ZcadApplication();
			zcadApplication.GetType().InvokeMember("ZoomExtents", BindingFlags.InvokeMethod, null, zcadApplication, null);
		}

		[CommandMethod("ProjeKaydet")]
		public void ProjeKaydet()
		{
			bool flag = !Directory.Exists("c:\\SZG\\Proje");
			if (flag)
			{
				Directory.CreateDirectory("c:\\SZG\\Proje");
			}
			bool flag2 = !Directory.Exists("c:\\asnproje");
			if (flag2)
			{
				Directory.CreateDirectory("c:\\asnproje");
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Proje Dosyası|*.prj";
			saveFileDialog.InitialDirectory = "c:\\SZG\\Proje";
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.CreatePrompt = false;
			bool flag3 = saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag3)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
				streamWriter.WriteLine(saveFileDialog.FileName);
				streamWriter.Close();
				Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage("Girilen dosya adı: " + saveFileDialog.FileName);
				FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
				string text = fileInfo.Name.Substring(0, fileInfo.Name.Length - 4);
				bool flag4 = !Directory.Exists("c:\\asnproje\\" + text);
				if (flag4)
				{
					Directory.CreateDirectory("c:\\asnproje\\" + text);
					bool flag5 = File.Exists("c:\\asnproje\\KuyuKabin.dwg");
					if (flag5)
					{
						File.Move("c:\\asnproje\\KuyuKabin.dwg", "c:\\asnproje\\" + text + "\\KuyuKabin.dwg");
					}
					bool flag6 = File.Exists("c:\\asnproje\\KuyuDibi.dwg");
					if (flag6)
					{
						File.Move("c:\\asnproje\\KuyuDibi.dwg", "c:\\asnproje\\" + text + "\\KuyuDibi.dwg");
					}
					bool flag7 = File.Exists("c:\\asnproje\\MakDaire.dwg");
					if (flag7)
					{
						File.Move("c:\\asnproje\\MakDaire.dwg", "c:\\asnproje\\" + text + "\\MakDaire.dwg");
					}
					bool flag8 = File.Exists("c:\\asnproje\\TKAA.dwg");
					if (flag8)
					{
						File.Move("c:\\asnproje\\TKAA.dwg", "c:\\asnproje\\" + text + "\\TKAA.dwg");
					}
					bool flag9 = File.Exists("c:\\asnproje\\TKBB.dwg");
					if (flag9)
					{
						File.Move("c:\\asnproje\\TKBB.dwg", "c:\\asnproje\\" + text + "\\TKBB.dwg");
					}
					bool flag10 = File.Exists("c:\\asnproje\\TUMTKAA.dwg");
					if (flag10)
					{
						File.Move("c:\\asnproje\\TUMTKAA.dwg", "c:\\asnproje\\" + text + "\\TUMTKAA.dwg");
					}
					bool flag11 = File.Exists("c:\\asnproje\\TUMTKBB.dwg");
					if (flag11)
					{
						File.Move("c:\\asnproje\\TUMTKBB.dwg", "c:\\asnproje\\" + text + "\\TUMTKBB.dwg");
					}
					Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
					string text2 = string.Concat(new string[]
					{
						"c:\\asnproje\\",
						text,
						"\\",
						text,
						".dwg"
					});
					mdiActiveDocument.get_Database().SaveAs(text2, true, 31, mdiActiveDocument.get_Database().get_SecurityParameters());
					Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage(text + " PROJESİ KAYDEDİLDİ..");
				}
			}
		}

		[CommandMethod("ProjeAc")]
		public void ProjeAc()
		{
			bool flag = !Directory.Exists("c:\\SZG\\Proje");
			if (flag)
			{
				Directory.CreateDirectory("c:\\SZG\\Proje");
			}
			bool flag2 = !Directory.Exists("c:\\asnproje");
			if (flag2)
			{
				Directory.CreateDirectory("c:\\asnproje");
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Proje Dosyası|*.prj";
			saveFileDialog.InitialDirectory = "c:\\SZG\\Proje";
			saveFileDialog.OverwritePrompt = false;
			saveFileDialog.CreatePrompt = false;
			bool flag3 = saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag3)
			{
				FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
				string text = fileInfo.Name.Substring(0, fileInfo.Name.Length - 4);
				bool flag4 = Directory.Exists("c:\\asnproje\\" + text);
				if (flag4)
				{
					Directory.CreateDirectory("c:\\asnproje\\" + text);
					bool flag5 = File.Exists("c:\\asnproje\\KuyuKabin.dwg");
					if (flag5)
					{
						File.Delete("c:\\asnproje\\KuyuKabin.dwg");
					}
					bool flag6 = File.Exists("c:\\asnproje\\KuyuDibi.dwg");
					if (flag6)
					{
						File.Delete("c:\\asnproje\\KuyuDibi.dwg");
					}
					bool flag7 = File.Exists("c:\\asnproje\\MakDaire.dwg");
					if (flag7)
					{
						File.Delete("c:\\asnproje\\MakDaire.dwg");
					}
					bool flag8 = File.Exists("c:\\asnproje\\TKAA.dwg");
					if (flag8)
					{
						File.Delete("c:\\asnproje\\TKAA.dwg");
					}
					bool flag9 = File.Exists("c:\\asnproje\\TKBB.dwg");
					if (flag9)
					{
						File.Delete("c:\\asnproje\\TKBB.dwg");
					}
					bool flag10 = File.Exists("c:\\asnproje\\TUMTKAA.dwg");
					if (flag10)
					{
						File.Delete("c:\\asnproje\\TUMTKAA.dwg");
					}
					bool flag11 = File.Exists("c:\\asnproje\\TUMTKBB.dwg");
					if (flag11)
					{
						File.Delete("c:\\asnproje\\TUMTKBB.dwg");
					}
					bool flag12 = File.Exists("c:\\asnproje\\" + text + "\\KuyuKabin.dwg");
					if (flag12)
					{
						File.Copy("c:\\asnproje\\" + text + "\\KuyuKabin.dwg", "c:\\asnproje\\KuyuKabin.dwg");
					}
					bool flag13 = File.Exists("c:\\asnproje\\" + text + "\\KuyuDibi.dwg");
					if (flag13)
					{
						File.Copy("c:\\asnproje\\" + text + "\\KuyuDibi.dwg", "c:\\asnproje\\KuyuDibi.dwg");
					}
					bool flag14 = File.Exists("c:\\asnproje\\" + text + "\\MakDaire.dwg");
					if (flag14)
					{
						File.Copy("c:\\asnproje\\" + text + "\\MakDaire.dwg", "c:\\asnproje\\MakDaire.dwg");
					}
					bool flag15 = File.Exists("c:\\asnproje\\" + text + "\\TKAA.dwg");
					if (flag15)
					{
						File.Copy("c:\\asnproje\\" + text + "\\TKAA.dwg", "c:\\asnproje\\TKAA.dwg");
					}
					bool flag16 = File.Exists("c:\\asnproje\\" + text + "\\TKBB.dwg");
					if (flag16)
					{
						File.Copy("c:\\asnproje\\" + text + "\\TKBB.dwg", "c:\\asnproje\\TKBB.dwg");
					}
					bool flag17 = File.Exists("c:\\asnproje\\" + text + "\\TUMTKAA.dwg");
					if (flag17)
					{
						File.Copy("c:\\asnproje\\" + text + "\\TUMTKAA.dwg", "c:\\asnproje\\TUMTKAA.dwg");
					}
					bool flag18 = File.Exists("c:\\asnproje\\" + text + "\\TUMTKBB.dwg");
					if (flag18)
					{
						File.Copy("c:\\asnproje\\" + text + "\\TUMTKBB.dwg", "c:\\asnproje\\TUMTKBB.dwg");
					}
					bool flag19 = File.Exists(string.Concat(new string[]
					{
						"c:\\asnproje\\",
						text,
						"\\",
						text,
						".dwg"
					}));
					if (flag19)
					{
						File.Copy(string.Concat(new string[]
						{
							"c:\\asnproje\\",
							text,
							"\\",
							text,
							".dwg"
						}), "c:\\asnproje\\" + text + ".dwg");
					}
					string text2 = "c:\\asnproje\\" + text + ".dwg";
					DocumentCollection documentManager = Application.get_DocumentManager();
					documentManager.Open(text2, false);
				}
			}
		}

		[CommandMethod("ProjeSil")]
		public void ProjeSil()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Proje Dosyası|*.prj";
			saveFileDialog.InitialDirectory = "c:\\SZG\\Proje";
			saveFileDialog.OverwritePrompt = false;
			saveFileDialog.CreatePrompt = false;
			bool flag = saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
				File.Delete(saveFileDialog.FileName);
				string str = fileInfo.Name.Substring(0, fileInfo.Name.Length - 4);
				bool flag2 = Directory.Exists("c:\\asnproje\\" + str);
				if (flag2)
				{
					Directory.Delete("c:\\asnproje\\" + str, true);
				}
			}
		}

		[CommandMethod("ClearUnrefedBlocks")]
		public void ClearUnrefedBlocks()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = transaction.GetObject(database.get_BlockTableId(), 1) as BlockTable;
				using (SymbolTableEnumerator enumerator = blockTable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						BlockTableRecord blockTableRecord = transaction.GetObject(current, 1) as BlockTableRecord;
						bool flag = blockTableRecord.GetBlockReferenceIds(false, false).get_Count() == 0 && !blockTableRecord.get_IsLayout();
						if (flag)
						{
							blockTableRecord.Erase();
						}
					}
				}
				transaction.Commit();
			}
		}

		public void gecikme(int saniye)
		{
			saniye = (saniye + Convert.ToInt32(DateTime.Now.Second)) % 60;
			bool flag;
			do
			{
				flag = (saniye == DateTime.Now.Second);
			}
			while (!flag);
		}

		[CommandMethod("TumProje")]
		public void TumProje()
		{
			bool flag = !this.prman.Created;
			if (flag)
			{
				this.prman.aadd = this;
				this.prman.destandcrash();
			}
			structTahrik structTahrik = default(structTahrik);
			structTahrik = this.ReadTahrikData("1");
			this.DALL();
			double num = 1.0 / Convert.ToDouble(this.GetNumValue("KKOLCEK", "1"));
			double num2 = 1.0 / Convert.ToDouble(this.GetNumValue("KDOLCEK", "1"));
			double num3 = 1.0 / Convert.ToDouble(this.GetNumValue("MDOLCEK", "1"));
			double num4 = 1.0 / Convert.ToDouble(this.GetNumValue("TK-AAOLCEK", "1"));
			double num5 = 1.0 / Convert.ToDouble(this.GetNumValue("TKKOLCEK", "1"));
			int num6 = Convert.ToInt32(this.GetNumValue("ToplamKuyuGen", "1"));
			int num7 = Convert.ToInt32(this.GetNumValue("KuyuDer", "1"));
			int num8 = Convert.ToInt32(this.GetNumValue("DuvarKal", "1"));
			int num9 = Convert.ToInt32(this.GetNumValue("KuyuDibi", "1"));
			int num10 = Convert.ToInt32(this.GetNumValue("SonKat", "1")) + Convert.ToInt32(this.GetNumValue("KuyuKafa", "1")) - 200;
			int num11 = Convert.ToInt32(this.GetNumValue("KabinTamponAra", "1"));
			int num12 = Convert.ToInt32(this.GetNumValue("KabinStrok", "1"));
			int num13 = Convert.ToInt32(this.GetNumValue("AgrTamponAra", "1"));
			int num14 = Convert.ToInt32(this.GetNumValue("AgrStrok", "1"));
			int num15 = Convert.ToInt32(this.GetNumValue("KAltPaten", "1"));
			int num16 = Convert.ToInt32(this.GetNumValue("KUstPaten", "1"));
			int num17 = Convert.ToInt32(this.GetNumValue("BeyanHiz", "1"));
			int num18 = Convert.ToInt32(this.GetNumValue("AASol", "1"));
			int num19 = Convert.ToInt32(this.GetNumValue("AASag", "1"));
			int num20 = Convert.ToInt32(this.GetNumValue("BBSol", "1"));
			int num21 = Convert.ToInt32(this.GetNumValue("BBSag", "1"));
			double num22 = 0.0;
			double num23 = num2 * (double)num7 + 150.0;
			double num24 = 150.0;
			double num25 = -1.0 * num3 * (double)(num6 + num19) - num24;
			double num26 = num3 * (double)num20 + 50.0;
			double num27 = 0.0;
			double num28 = 0.0;
			double num29 = num * (double)(num6 + num18 + num19 + 2 * num8);
			double num30 = num * (double)(num7 + num21 + num8);
			double num31 = num * (double)(num6 + 4 * num8);
			bool flag2 = (structTahrik.TahrikKodu == "DA" || structTahrik.TahrikKodu == "YA") && structTahrik.TipKodu == "EA";
			if (flag2)
			{
				double num32 = -1.0 * num3 * (double)(num6 + num18 + num19) + -1.0 * num5 * (double)(num6 + num21) - 150.0 - num5 * (double)(num6 + num21) - 400.0;
				double num33 = -1.0 * num3 * (double)(num6 + num18 + num19) + -1.0 * num5 * (double)(num6 + num21) - 300.0;
				bool flag3 = num18 == 0;
				if (flag3)
				{
					num27 = num * (double)(num6 + num18 + 700) + 50.0;
				}
				else
				{
					num27 = num * (double)(num6 + num18 + 700);
				}
				num28 = num27 + num4 * (double)(num6 + num19 + num20) + num4 * 2000.0;
			}
			bool flag4 = structTahrik.TahrikKodu == "MDDUZ" || structTahrik.TahrikKodu == "MDCAP";
			if (flag4)
			{
				double num32 = -1.0 * num5 * (double)(num6 + num7) - 550.0;
				double num33 = -1.0 * num5 * (double)num7 - 200.0;
				num27 = num4 * (double)num6 + 200.0;
				num28 = num27 + num4 * (double)num6 + num4 * 4000.0;
			}
			bool flag5 = structTahrik.TipKodu == "HA";
			if (flag5)
			{
				bool flag6 = this.GetNumValue("HAMDFlip", "1") == "1";
				if (flag6)
				{
					double num32 = -1.0 * num5 * (double)(num6 + num7) - 650.0 - num3 * (double)Convert.ToInt32(this.GetNumValue("HAMDGen", "1"));
					double num33 = -1.0 * num5 * (double)num7 - 200.0 - num3 * (double)Convert.ToInt32(this.GetNumValue("HAMDGen", "1"));
					num27 = num * (double)num6 + 200.0;
					num28 = num27 + num4 * (double)num6 + num4 * 3000.0;
				}
				else
				{
					double num32 = -1.0 * num5 * (double)(num6 + num7) - 650.0;
					double num33 = -1.0 * num5 * (double)num7 - 200.0;
					num27 = num * (double)num6 + 200.0 + num2 * (double)Convert.ToInt32(this.GetNumValue("HAMDGen", "1"));
					num28 = num27 + num * (double)num6 + num4 * 3000.0;
				}
			}
			double num34 = 0.0;
			double num35 = 0.0;
			double num36 = 0.0;
			string text = "DiyagramDA";
			bool flag7 = (structTahrik.TahrikKodu == "DA" || structTahrik.TahrikKodu == "YA") && structTahrik.TipKodu == "EA";
			if (flag7)
			{
				num34 = num25 - (double)num18 * num3 - 250.0;
				num35 = 350.0;
				text = "DiyagramDA";
				num36 = num34;
			}
			bool flag8 = structTahrik.TahrikKodu == "MDDUZ" || structTahrik.TahrikKodu == "MDCAP";
			if (flag8)
			{
				num34 = num22 - 250.0;
				num35 = 350.0;
				text = "DiyagramMD";
				num36 = num34;
			}
			double num37 = 0.0;
			bool flag9 = (structTahrik.TahrikKodu == "DA" || structTahrik.TahrikKodu == "YA") && structTahrik.TipKodu == "EA";
			if (flag9)
			{
				num37 = num28 + num4 * (double)(num7 + num21 + 2 * num8);
			}
			bool flag10 = (structTahrik.TahrikKodu == "MDDUZ" || structTahrik.TahrikKodu == "MDCAP") && structTahrik.TipKodu == "EA";
			if (flag10)
			{
				num37 = num28 + num4 * (double)(num7 + 2 * num8);
			}
			bool flag11 = structTahrik.TipKodu == "HA";
			if (flag11)
			{
				num37 = num28 + num4 * (double)num7 + 100.0;
			}
			double num38 = 0.0;
			bool flag12 = structTahrik.TahrikKodu == "MDCAP";
			if (flag12)
			{
				num38 = num * (double)num6 + num4 * (double)(num6 + num7) + 500.0 + 100.0 + 400.0;
				num38 = num37 + 200.0;
			}
			bool flag13 = structTahrik.TahrikKodu == "MDDUZ";
			if (flag13)
			{
				num38 = num * (double)num6 + num4 * (double)(num6 + num7) + 500.0 + 100.0 + 400.0;
				num38 = num37 + 200.0;
			}
			bool flag14 = (structTahrik.TahrikKodu == "DA" || structTahrik.TahrikKodu == "YA") && structTahrik.TipKodu == "EA";
			if (flag14)
			{
				num38 = num * (double)num6 + num4 * (double)(num6 + num7 + num18 + num19 + num20 + num21) + 350.0;
				num38 = num37 + 0.1 * Convert.ToDouble(this.GetNumValue("KapiGen", "1")) + 300.0;
			}
			double num39 = 0.0;
			bool flag15 = structTahrik.TipKodu == "HA";
			if (flag15)
			{
				num39 = num37 + 0.1 * Convert.ToDouble(this.GetNumValue("KapiGen", "1")) + 300.0;
			}
			this.LD("KK", true, new Point3d(num22, 0.0, 0.0));
			this.LD("KD", true, new Point3d(0.0, num23, 0.0));
			bool flag16 = structTahrik.TahrikKodu != "MDDUZ" && structTahrik.TahrikKodu != "MDCAP" && structTahrik.TipKodu != "HA";
			if (flag16)
			{
				this.LD("MD", true, new Point3d(num25, num26, 0.0));
			}
			this.LD("TK-AA", true, new Point3d(num27, -50.0, 0.0));
			this.LD("TK-BB", true, new Point3d(num28, -50.0, 0.0));
			Application.SetSystemVariable("DIMLFAC", 0.0);
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag17 = mdiActiveDocument == null;
				if (flag17)
				{
					return;
				}
				Database database = mdiActiveDocument.get_Database();
				Editor editor = mdiActiveDocument.get_Editor();
				DBObjectCollection dBObjectCollection = new DBObjectCollection();
				string text2 = this.GetNumValue("KapiTip", "1");
				string numValue = this.GetNumValue("Mentese", "1");
				using (database)
				{
					using (Transaction transaction = database.get_TransactionManager().StartTransaction())
					{
						bool flag18 = structTahrik.TipKodu == "EA";
						if (flag18)
						{
							BlockReference blockReference = this.InsertBlock(database, transaction, new Point3d(num34, num35, 0.0), text, 0.5, text, "1", "0");
							this.InsertBlock(database, transaction, new Point3d(num36, -100.0, 0.0), "HesapBase", 1.0, "HesapBase", "1", "0");
							blockReference = this.InsertBlock(database, transaction, new Point3d(num36, 0.0, 0.0), "Check", 0.5, "Check", "1", "0");
							Entity entity = ascad.FObject("Check", "1", "0");
							bool flag19 = entity != null;
							if (flag19)
							{
								double num40 = (double)(num9 - 750 - num11 - num12);
								bool flag20 = num40 > 100.0;
								if (flag20)
								{
									this.ChTag(entity.get_ObjectId(), "15733B1", Convert.ToString(num40) + " > 100  EN81-1 5.7.3.3.b");
								}
								else
								{
									this.ChTag(entity.get_ObjectId(), "15733B1", Convert.ToString(num40) + " < 100  EN81-1 5.7.3.3.b");
								}
								num40 = (double)(num9 - num15 - num11 - num12);
								bool flag21 = num40 > 500.0;
								if (flag21)
								{
									this.ChTag(entity.get_ObjectId(), "15733B2", Convert.ToString(num40) + " > 500  EN81-1 5.7.3.3.b");
								}
								else
								{
									this.ChTag(entity.get_ObjectId(), "15733B2", Convert.ToString(num40) + " < 500  EN81-1 5.7.3.3.b");
								}
								double num41 = (double)(num10 - num16 - num13 - num14);
								num40 = 1000.0 * (0.1 + 0.035 * (double)num17 * (double)num17);
								bool flag22 = num41 > num40;
								if (flag22)
								{
									this.ChTag(entity.get_ObjectId(), "15711A", Convert.ToString(num41) + " > " + Convert.ToString(num40) + " EN81-1 5.7.1.1.a");
								}
								else
								{
									this.ChTag(entity.get_ObjectId(), "15711A", Convert.ToString(num41) + " < " + Convert.ToString(num40) + " EN81-1 5.7.1.1.a");
								}
								num41 = (double)(num10 - num16 - num13 - num14 + 600);
								num40 = 1000.0 * (1.0 + 0.035 * (double)num17 * (double)num17);
								bool flag23 = num41 > num40;
								if (flag23)
								{
									this.ChTag(entity.get_ObjectId(), "15711B", Convert.ToString(num41) + " > " + Convert.ToString(num40) + " EN81-1 5.7.1.1.b");
								}
								else
								{
									this.ChTag(entity.get_ObjectId(), "15711B", Convert.ToString(num41) + " < " + Convert.ToString(num40) + " EN81-1 5.7.1.1.b");
								}
								num41 = (double)(num10 - (num16 + 100) - num13 - num14);
								num40 = 1000.0 * (0.1 + 0.035 * (double)num17 * (double)num17);
								bool flag24 = num41 > num40;
								if (flag24)
								{
									this.ChTag(entity.get_ObjectId(), "5711C2", Convert.ToString(num41) + " > " + Convert.ToString(num40) + " EN81-1 5.7.1.1.c.2");
								}
								else
								{
									this.ChTag(entity.get_ObjectId(), "5711C2", Convert.ToString(num41) + " < " + Convert.ToString(num40) + " EN81-1 5.7.1.1.c.2");
								}
								num41 = (double)(num10 - num16 - num13 - num14);
								num40 = 1000.0 * (0.3 + 0.035 * (double)num17 * (double)num17);
								bool flag25 = num41 > num40;
								if (flag25)
								{
									this.ChTag(entity.get_ObjectId(), "5711C1", Convert.ToString(num41) + " > " + Convert.ToString(num40) + " EN81-1 5.7.1.1.c.1");
								}
								else
								{
									this.ChTag(entity.get_ObjectId(), "5711C1", Convert.ToString(num41) + " < " + Convert.ToString(num40) + " EN81-1 5.7.1.1.c.1");
								}
							}
						}
						transaction.Commit();
						using (Transaction transaction2 = database.get_TransactionManager().StartTransaction())
						{
							bool flag26 = text2 == "YO-CIFT" || text2 == "CK-4MER" || text2 == "CK-2MER";
							if (flag26)
							{
								text2 = "YOCIFT";
							}
							bool flag27 = text2 == "YK-KRMK" || text2 == "YO-2TEL" || text2 == "YO-3TEL" || text2 == "YO-2MER" || text2 == "YO-4MER";
							if (flag27)
							{
								text2 = "YO";
							}
							bool flag28 = structTahrik.TahrikKodu == "DA" && structTahrik.TipKodu == "EA";
							if (flag28)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction2, new Point3d(num37, 0.0, 0.0), "KD-" + text2, 0.1, "KDETAY", "1", "0");
							}
							bool flag29 = (structTahrik.TahrikKodu == "MDDUZ" || structTahrik.TahrikKodu == "MDCAP") && structTahrik.TipKodu == "EA";
							if (flag29)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction2, new Point3d(num37, 0.0, 0.0), "KD-MD-" + text2, 0.05, "KDETAY", "1", "0");
							}
							bool flag30 = structTahrik.TipKodu == "HA";
							if (flag30)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction2, new Point3d(num37, 0.0, 0.0), "KD-" + text2, 0.1, "KDETAY", "1", "0");
							}
							Entity entity = ascad.FObject("KDETAY", "1", "0");
							bool flag31 = entity != null;
							if (flag31)
							{
								bool flag32 = structTahrik.TahrikKodu == "MDDUZ" || structTahrik.TahrikKodu == "MDCAP";
								if (flag32)
								{
									this.SetDynamicValue(database, transaction2, entity, "dynKapiGen", 0.05 * Convert.ToDouble(this.GetNumValue("KapiGen", "1")));
									this.SetDynamicValue(database, transaction2, entity, "dynKasaGen", 0.05 * Convert.ToDouble(this.GetNumValue("KasaGen", "1")));
								}
								else
								{
									this.SetDynamicValue(database, transaction2, entity, "dynKapiGen", 0.1 * Convert.ToDouble(this.GetNumValue("KapiGen", "1")));
									this.SetDynamicValue(database, transaction2, entity, "dynKasaGen", 0.1 * Convert.ToDouble(this.GetNumValue("KasaGen", "1")));
								}
								bool flag33 = numValue == "SAG";
								if (flag33)
								{
									this.SetDynamicValue(database, transaction2, entity, "dynKapiFlip", 1.0);
								}
							}
							bool flag34 = structTahrik.TahrikKodu == "MDCAP";
							if (flag34)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction2, new Point3d(num38, 0.0, 0.0), "SUSPMDCAP", 0.1, "SUSP", "1", "0");
								entity = ascad.FObject("SUSP", "1", "0");
								bool flag35 = entity != null;
								if (flag35)
								{
									this.SetDynamicValue(database, transaction2, entity, "dynAgrRA", 0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1AgrRA", "KK")));
								}
							}
							bool flag36 = structTahrik.TahrikKodu == "MDDUZ";
							if (flag36)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction2, new Point3d(num38, 0.0, 0.0), "SUSPMD", 0.1, "SUSP", "1", "0");
								entity = ascad.FObject("SUSP", "1", "0");
								bool flag37 = entity != null;
								if (flag37)
								{
									this.SetDynamicValue(database, transaction2, entity, "dynAgrRA", 0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1AgrRA", "KK")));
								}
							}
							bool flag38 = structTahrik.TahrikKodu == "DA" && structTahrik.TipKodu == "EA";
							if (flag38)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction2, new Point3d(num38, 0.0, 0.0), "SUSPDA", 0.1, "SUSP", "1", "0");
								entity = ascad.FObject("SUSP", "1", "0");
								this.ChTag(entity.get_ObjectId(), "AGRADET", "HESAPLANAN AĞIRLIK ADEDİ :");
								bool flag39 = entity != null;
								if (flag39)
								{
									this.SetDynamicValue(database, transaction2, entity, "dynKabinRA", 0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1KabinRA", "KK")));
									this.SetDynamicValue(database, transaction2, entity, "dynAgrRA", 0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1AgrRA", "KK")));
									this.SetDynamicValue(database, transaction2, entity, "AgrUzAdet", 250.0);
								}
							}
							bool flag40 = structTahrik.TipKodu == "HA";
							if (flag40)
							{
								BlockReference blockReference = this.InsertBlock(database, transaction2, new Point3d(num39, 0.0, 0.0), "LKarkas", 0.1, "LKarkas", "1", "0");
								entity = ascad.FObject("LKarkas", "1", "0");
								bool flag41 = entity != null;
								if (flag41)
								{
									this.SetDynamicValue(database, transaction2, entity, "dynHRA", 0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1HRA", "KK")));
									this.SetDynamicValue(database, transaction2, entity, "dynPistonKab", 0.1 * (0.75 * Convert.ToDouble(this.prman.GetParamValFRM("L1KabinGen", "KK")) + Convert.ToDouble(this.prman.GetParamValFRM("L1PistonKab", "KK"))));
								}
							}
							transaction2.Commit();
						}
					}
				}
			}
			catch (Exception var_95_171B)
			{
				Application.SetSystemVariable("DIMLFAC", 1.0);
			}
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		public void TumProje2()
		{
			this.LD("KK", false, default(Point3d));
		}

		[CommandMethod("InsertBlock")]
		public void InsertBlock()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			Database database = editor.get_Document().get_Database();
			Transaction transaction = database.get_TransactionManager().StartTransaction();
			DocumentLock documentLock = mdiActiveDocument.LockDocument();
			using (transaction)
			{
				using (documentLock)
				{
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(database.get_CurrentSpaceId(), 1);
					BlockTableRecord blockTableRecord2 = new BlockTableRecord();
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.get_BlockTableId(), 1);
					blockTableRecord2.set_Name("KuyuKabin");
					blockTableRecord2.set_PathName("c:\\asnproje\\wblock.dwg");
					blockTable.Add(blockTableRecord2);
					BlockReference blockReference = new BlockReference(new Point3d(0.0, 0.0, 0.0), blockTableRecord2.get_ObjectId());
					blockTableRecord.AppendEntity(blockReference);
					transaction.AddNewlyCreatedDBObject(blockTableRecord2, true);
					transaction.AddNewlyCreatedDBObject(blockReference, true);
					transaction.Commit();
					transaction.Dispose();
				}
			}
		}

		public void InsertBlock(string FileName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			Database database = editor.get_Document().get_Database();
			Transaction transaction = database.get_TransactionManager().StartTransaction();
			DocumentLock documentLock = mdiActiveDocument.LockDocument();
			using (transaction)
			{
				using (documentLock)
				{
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(database.get_CurrentSpaceId(), 1);
					BlockTableRecord blockTableRecord2 = new BlockTableRecord();
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.get_BlockTableId(), 1);
					blockTableRecord2.set_Name(FileName);
					blockTableRecord2.set_PathName("c:\\asnproje\\" + FileName + ".dwg");
					blockTable.Add(blockTableRecord2);
					BlockReference blockReference = new BlockReference(new Point3d(0.0, 0.0, 0.0), blockTableRecord2.get_ObjectId());
					blockTableRecord.AppendEntity(blockReference);
					transaction.AddNewlyCreatedDBObject(blockTableRecord2, true);
					transaction.AddNewlyCreatedDBObject(blockReference, true);
					transaction.Commit();
					transaction.Dispose();
				}
			}
		}

		[CommandMethod("AttachingExternalReference")]
		public void AttachingExternalReference(string FileName, Point3d insPt, double BlkScale)
		{
			Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				string text = "c:\\asnproje\\" + FileName + ".dwg";
				ObjectId objectId = database.AttachXref(text, FileName);
				bool flag = !objectId.get_IsNull();
				if (flag)
				{
					using (BlockReference blockReference = new BlockReference(insPt, objectId))
					{
						blockReference.set_ScaleFactors(new Scale3d(BlkScale));
						BlockTableRecord blockTableRecord = transaction.GetObject(database.get_CurrentSpaceId(), 1) as BlockTableRecord;
						blockTableRecord.AppendEntity(blockReference);
						transaction.AddNewlyCreatedDBObject(blockReference, true);
					}
				}
				transaction.Commit();
			}
		}

		public void KuyuCiz2(clsMainLift MainLift)
		{
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (database)
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							BlockReference blockReference = this.InsertBlock(database, transaction, MainLift.BasePoint, "Kuyu", false, "KUYU", "1", null, 1.0);
							blockReference.ExplodeToOwnerSpace();
							blockReference.Erase();
						}
					}
				}
			}
			catch (Exception var_8_A3)
			{
			}
			catch (Exception var_9_A9)
			{
			}
		}

		[CommandMethod("explodeRef")]
		public static void explodeRef(BlockReference blockRef)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				DBObjectCollection dBObjectCollection = new DBObjectCollection();
				blockRef.Explode(dBObjectCollection);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(database.get_CurrentSpaceId(), 1);
				foreach (DBObject dBObject in dBObjectCollection)
				{
					bool flag = dBObject is Entity;
					if (flag)
					{
						blockTableRecord.AppendEntity((Entity)dBObject);
						transaction.AddNewlyCreatedDBObject(dBObject, true);
					}
				}
				transaction.Commit();
			}
		}

		public bool ExplodeBlockByNameCommand(string blockToExplode)
		{
			bool result = true;
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			Database database = mdiActiveDocument.get_Database();
			TransactionManager transactionManager = mdiActiveDocument.get_TransactionManager();
			using (Transaction transaction = transactionManager.StartTransaction())
			{
				try
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.get_BlockTableId(), 0);
					editor.WriteMessage("\nProcessing {0}", new object[]
					{
						blockToExplode
					});
					bool flag = blockTable.Has(blockToExplode);
					if (flag)
					{
						ObjectId objectId = blockTable.get_Item(blockToExplode);
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(objectId, 0);
						ObjectIdCollection blockReferenceIds = blockTableRecord.GetBlockReferenceIds(true, true);
						foreach (ObjectId objectId2 in blockReferenceIds)
						{
							DBObjectCollection dBObjectCollection = new DBObjectCollection();
							Entity entity = (Entity)transaction.GetObject(objectId2, 0);
							entity.Explode(dBObjectCollection);
							editor.WriteMessage("\nExploded an Instance of {0}", new object[]
							{
								blockToExplode
							});
							entity.UpgradeOpen();
							entity.Erase();
							BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(database.get_CurrentSpaceId(), 1);
							foreach (DBObject dBObject in dBObjectCollection)
							{
								Entity entity2 = (Entity)dBObject;
								blockTableRecord2.AppendEntity(entity2);
								transaction.AddNewlyCreatedDBObject(entity2, true);
							}
						}
					}
					transaction.Commit();
				}
				catch
				{
					editor.WriteMessage("\nSomething went wrong");
					result = false;
				}
				finally
				{
				}
				editor.WriteMessage("\n");
				transaction.Dispose();
				transactionManager.Dispose();
			}
			return result;
		}

		public void MoveLiftBlock(double ValueFark)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
			string text = "I";
			string b = "2";
			TypedValue[] expr_24 = new TypedValue[]
			{
				new TypedValue(1001, text)
			};
			using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
				using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						Entity entity = (Entity)transaction.GetObject(current, 1, false, true);
						ResultBuffer xDataForApplication = entity.GetXDataForApplication(text);
						bool flag = xDataForApplication == null;
						if (!flag)
						{
							TypedValue[] array = xDataForApplication.AsArray();
							for (int i = 0; i < array.Length; i++)
							{
								TypedValue typedValue = array[i];
								bool flag2 = typedValue.get_TypeCode() == 1000 && (string)typedValue.get_Value() == b;
								if (flag2)
								{
									bool flag3 = entity.get_ObjectId().get_ObjectClass().get_DxfName() == "INSERT";
									if (flag3)
									{
										DBObject @object = transaction.GetObject(entity.get_ObjectId(), 0);
										bool flag4 = @object is BlockReference;
										if (flag4)
										{
											BlockReference blockReference = @object as BlockReference;
											blockReference.set_Position(new Point3d(blockReference.get_Position().get_X() + ValueFark, 0.0, 0.0));
										}
									}
								}
							}
						}
					}
				}
				transaction.Commit();
			}
		}

		private void vtCHXdataDIM(int LiftNumber, string KesitKodu)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
			string text = "DIM";
			string text2 = "MD";
			string b = "LN";
			using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
				using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						Entity entity = (Entity)transaction.GetObject(current, 1, false, true);
						ResultBuffer resultBuffer = entity.GetXDataForApplication(text);
						bool flag = resultBuffer == null;
						if (flag)
						{
							resultBuffer = entity.GetXDataForApplication(text2);
						}
						bool flag2 = resultBuffer == null;
						if (!flag2)
						{
							TypedValue[] array = resultBuffer.AsArray();
							for (int i = 0; i < array.Length; i++)
							{
								TypedValue typedValue = array[i];
								bool flag3 = typedValue.get_TypeCode() == 1000 && (string)typedValue.get_Value() == b;
								if (flag3)
								{
									array[i] = new TypedValue(1000, Convert.ToString(LiftNumber));
								}
								bool flag4 = typedValue.get_TypeCode() == 1000 && (string)typedValue.get_Value() == "KESKOD";
								if (flag4)
								{
									array[i] = new TypedValue(1000, KesitKodu);
								}
							}
							resultBuffer = new ResultBuffer(array);
							entity.set_XData(resultBuffer);
						}
					}
				}
				transaction.Commit();
			}
		}

		private void vtCHXdata(int LiftNumber)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
			string text = "I";
			string text2 = "MD";
			string b = "LN";
			using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
				using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						Entity entity = (Entity)transaction.GetObject(current, 1, false, true);
						ResultBuffer resultBuffer = entity.GetXDataForApplication(text);
						bool flag = resultBuffer == null;
						if (flag)
						{
							resultBuffer = entity.GetXDataForApplication(text2);
						}
						bool flag2 = resultBuffer == null;
						if (!flag2)
						{
							TypedValue[] array = resultBuffer.AsArray();
							for (int i = 0; i < array.Length; i++)
							{
								TypedValue typedValue = array[i];
								bool flag3 = typedValue.get_TypeCode() == 1000 && (string)typedValue.get_Value() == b;
								if (flag3)
								{
									array[i] = new TypedValue(1000, Convert.ToString(LiftNumber));
								}
							}
							resultBuffer = new ResultBuffer(array);
							entity.set_XData(resultBuffer);
						}
					}
				}
				transaction.Commit();
			}
		}

		private void SetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, string propname, double myvalue)
		{
			BlockReference blockReference = (BlockReference)tr.GetObject(vtEnt.get_ObjectId(), 0);
			blockReference.UpgradeOpen();
			bool flag = blockReference == null;
			if (!flag)
			{
				DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
				foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
				{
					bool readOnly = dynamicBlockReferenceProperty.get_ReadOnly();
					if (!readOnly)
					{
						bool flag2 = dynamicBlockReferenceProperty.get_PropertyName() == propname;
						if (flag2)
						{
							short propertyTypeCode = dynamicBlockReferenceProperty.get_PropertyTypeCode();
							if (propertyTypeCode != 40)
							{
								if (propertyTypeCode == 70)
								{
									dynamicBlockReferenceProperty.set_Value((short)myvalue);
								}
							}
							else
							{
								dynamicBlockReferenceProperty.set_Value(myvalue);
							}
							break;
						}
					}
				}
			}
		}

		private void SetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, vtLift BlokGrup, string LLNum, double Scale = 1.0, string KesitKODU = "KK")
		{
			BlockReference blockReference = (BlockReference)tr.GetObject(vtEnt.get_ObjectId(), 0);
			blockReference.UpgradeOpen();
			bool flag = blockReference == null;
			if (!flag)
			{
				DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
				foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
				{
					bool readOnly = dynamicBlockReferenceProperty.get_ReadOnly();
					if (!readOnly)
					{
						foreach (ParamList current in BlokGrup.BlkParamList)
						{
							bool flag2 = dynamicBlockReferenceProperty.get_PropertyName() == current.ParamName;
							if (flag2)
							{
								double num = Convert.ToDouble(this.prman.GetParamValFRM(LLNum + current.ParamName, KesitKODU));
								short propertyTypeCode = dynamicBlockReferenceProperty.get_PropertyTypeCode();
								if (propertyTypeCode != 40)
								{
									if (propertyTypeCode == 70)
									{
										dynamicBlockReferenceProperty.set_Value((short)num);
									}
								}
								else
								{
									num *= Scale;
									dynamicBlockReferenceProperty.set_Value(num);
								}
								break;
							}
						}
					}
				}
			}
		}

		private void SetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, clsMLift DimGrup, string LLNum, double Scale = 1.0, string KesitKODU = "KK")
		{
			BlockReference blockReference = (BlockReference)tr.GetObject(vtEnt.get_ObjectId(), 0);
			blockReference.UpgradeOpen();
			bool flag = blockReference == null;
			if (!flag)
			{
				DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
				foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
				{
					bool readOnly = dynamicBlockReferenceProperty.get_ReadOnly();
					if (!readOnly)
					{
						foreach (ConsParList current in DimGrup.DimGrup)
						{
							bool flag2 = dynamicBlockReferenceProperty.get_PropertyName() == current.ConsName;
							if (flag2)
							{
								double num = Convert.ToDouble(this.prman.GetParamValFRM(LLNum + current.ConsName, KesitKODU));
								short propertyTypeCode = dynamicBlockReferenceProperty.get_PropertyTypeCode();
								if (propertyTypeCode != 40)
								{
									if (propertyTypeCode == 70)
									{
										dynamicBlockReferenceProperty.set_Value((short)num);
									}
								}
								else
								{
									dynamicBlockReferenceProperty.set_Value(num * Scale);
								}
								break;
							}
						}
					}
				}
			}
		}

		private void SetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, string propname, string myvalue)
		{
			BlockReference blockReference = (BlockReference)tr.GetObject(vtEnt.get_ObjectId(), 0);
			bool flag = blockReference == null;
			if (!flag)
			{
				DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
				foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
				{
					bool readOnly = dynamicBlockReferenceProperty.get_ReadOnly();
					if (!readOnly)
					{
						bool flag2 = dynamicBlockReferenceProperty.get_PropertyName() == propname;
						if (flag2)
						{
							dynamicBlockReferenceProperty.set_Value(myvalue);
						}
					}
				}
			}
		}

		public string GetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, string propname)
		{
			BlockReference blockReference = (BlockReference)tr.GetObject(vtEnt.get_ObjectId(), 0);
			bool flag = blockReference == null;
			string result;
			if (flag)
			{
				result = "0";
			}
			else
			{
				DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
				foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
				{
					bool flag2 = dynamicBlockReferenceProperty.get_PropertyName() == propname;
					if (flag2)
					{
						result = Convert.ToString(dynamicBlockReferenceProperty.get_Value());
						return result;
					}
				}
				result = "0";
			}
			return result;
		}

		public static Entity FObject(string xdata1, string xdata2, string xdata3)
		{
			Entity entity = null;
			Entity result;
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
				using (workingDatabase)
				{
					using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
					{
						BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
						BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
						using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.get_Current();
								Entity entity2 = (Entity)transaction.GetObject(current, 0);
								bool flag = entity2.get_ObjectId().get_ObjectClass().get_DxfName() != "INSERT";
								if (!flag)
								{
									ResultBuffer xDataForApplication = entity2.GetXDataForApplication("I");
									bool flag2 = xDataForApplication != null;
									if (flag2)
									{
										TypedValue[] array = xDataForApplication.AsArray();
										bool flag3 = array[0].get_Value().ToString() == "I" && array[1].get_Value().ToString() == xdata1 && array[2].get_Value().ToString() == xdata2 && array[3].get_Value().ToString() == xdata3;
										if (flag3)
										{
											result = entity2;
											return result;
										}
										xDataForApplication.Dispose();
									}
								}
							}
						}
						transaction.Commit();
					}
				}
			}
			catch (Exception var_17_19C)
			{
			}
			catch (Exception var_18_1A2)
			{
			}
			result = entity;
			return result;
		}

		public static Entity FObjectDIM(string xdata1, string xdata2, string xdata3)
		{
			Entity entity = null;
			Entity result;
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
				using (workingDatabase)
				{
					using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
					{
						BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
						BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
						using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.get_Current();
								Entity entity2 = (Entity)transaction.GetObject(current, 0);
								bool flag = entity2.get_ObjectId().get_ObjectClass().get_DxfName() != "DIMENSION";
								if (!flag)
								{
									ResultBuffer xDataForApplication = entity2.GetXDataForApplication("DIM");
									bool flag2 = xDataForApplication != null;
									if (flag2)
									{
										TypedValue[] array = xDataForApplication.AsArray();
										bool flag3 = array.Count<TypedValue>() == 4;
										if (flag3)
										{
											bool flag4 = array[0].get_Value().ToString() == "DIM" && array[1].get_Value().ToString() == xdata1 && array[2].get_Value().ToString() == xdata2 && array[3].get_Value().ToString() == xdata3;
											if (flag4)
											{
												result = entity2;
												return result;
											}
										}
										xDataForApplication.Dispose();
									}
								}
							}
						}
						transaction.Commit();
					}
				}
			}
			catch (Exception var_18_1AE)
			{
			}
			catch (Exception var_19_1B4)
			{
			}
			result = entity;
			return result;
		}

		[CommandMethod("SobjOnSCR")]
		public static void SobjOnSCR()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				Entity entity = transaction.GetObject(mdiActiveDocument.get_Editor().GetEntity("DÜZELTİLECEK NESNEYİ SEÇİNİZ...").get_ObjectId(), 1) as Entity;
				bool flag = entity != null;
				if (flag)
				{
					bool flag2 = entity.get_ObjectId().get_ObjectClass().get_DxfName() == "DIMENSION";
					if (flag2)
					{
						AlignedDimension alignedDimension = (AlignedDimension)entity;
					}
					transaction.Commit();
				}
			}
		}

		private BlockReference InsertBlock(Database db, Transaction tr, Point3d insertPoint, string blockName, bool isUpdateProeprty, string xData1 = null, string xData2 = null, string xData3 = null, double Scale = 1.0)
		{
			ObjectId objectId = ObjectId.get_Null();
			BlockTable blockTable = tr.GetObject(db.get_BlockTableId(), 0) as BlockTable;
			bool flag = !blockTable.Has(blockName);
			BlockReference result;
			if (flag)
			{
				Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage("\n" + blockName + " BLOK BULUNAMADI..");
				result = null;
			}
			else
			{
				BlockTableRecord blockTableRecord = tr.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
				BlockReference blockReference = new BlockReference(insertPoint, blockTable.get_Item(blockName));
				blockReference.set_ScaleFactors(new Scale3d(Scale));
				objectId = blockTableRecord.AppendEntity(blockReference);
				tr.AddNewlyCreatedDBObject(blockReference, true);
				BlockTableRecord blockTableRecord2 = (BlockTableRecord)tr.GetObject(blockReference.get_BlockTableRecord(), 0);
				bool hasAttributeDefinitions = blockTableRecord2.get_HasAttributeDefinitions();
				if (hasAttributeDefinitions)
				{
					using (BlockTableRecordEnumerator enumerator = blockTableRecord2.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.get_Current();
							Entity entity = (Entity)tr.GetObject(current, 0);
							bool flag2 = entity is AttributeDefinition;
							if (flag2)
							{
								AttributeDefinition attributeDefinition = (AttributeDefinition)entity;
								AttributeReference attributeReference = new AttributeReference();
								attributeReference.SetAttributeFromBlock(attributeDefinition, blockReference.get_BlockTransform());
								blockReference.get_AttributeCollection().AppendAttribute(attributeReference);
								tr.AddNewlyCreatedDBObject(attributeReference, true);
								attributeReference.set_TextString(attributeDefinition.get_Tag());
							}
						}
					}
				}
				bool flag3 = xData1 != null;
				if (flag3)
				{
					ascad.SetXData(blockReference, xData1, xData2, xData3);
				}
				result = blockReference;
			}
			return result;
		}

		private static void ApplyAttibutes(Database acDB, Transaction acTrans, BlockReference acBlkRef, List<string> listTags, List<string> listValues)
		{
			BlockTableRecord blockTableRecord = (BlockTableRecord)acTrans.GetObject(acBlkRef.get_BlockTableRecord(), 0);
			using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.get_Current();
					Entity entity = (Entity)acTrans.GetObject(current, 0);
					bool flag = entity is AttributeDefinition;
					if (flag)
					{
						AttributeDefinition attributeDefinition = (AttributeDefinition)entity;
						AttributeReference attributeReference = new AttributeReference();
						attributeReference.SetAttributeFromBlock(attributeDefinition, acBlkRef.get_BlockTransform());
						acBlkRef.get_AttributeCollection().AppendAttribute(attributeReference);
						acTrans.AddNewlyCreatedDBObject(attributeReference, true);
						bool flag2 = listTags.Contains(attributeDefinition.get_Tag());
						if (flag2)
						{
							int num = listTags.IndexOf(attributeDefinition.get_Tag().ToUpper());
							bool flag3 = num >= 0;
							if (flag3)
							{
								attributeReference.set_TextString(listValues[num]);
								attributeReference.AdjustAlignment(acDB);
							}
						}
					}
				}
			}
		}

		private BlockReference InsertBlock(Database db, Transaction tr, Point3d insertPoint, string blockName, double BlkScale, string xData1 = null, string xData2 = null, string xData3 = null)
		{
			ObjectId objectId = ObjectId.get_Null();
			BlockTable blockTable = tr.GetObject(db.get_BlockTableId(), 0) as BlockTable;
			BlockTableRecord blockTableRecord = tr.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
			BlockReference blockReference = new BlockReference(insertPoint, blockTable.get_Item(blockName));
			blockReference.set_ScaleFactors(new Scale3d(BlkScale));
			objectId = blockTableRecord.AppendEntity(blockReference);
			tr.AddNewlyCreatedDBObject(blockReference, true);
			ascad.ApplyAttibutes(db, tr, blockReference, new List<string>(new string[]
			{
				"TAG1",
				"TAG2",
				"TAG3",
				"TAG4"
			}), new List<string>(new string[]
			{
				"Value #1",
				"Value #2",
				"Value #3",
				"Value #4"
			}));
			bool flag = xData1 != null;
			if (flag)
			{
				ascad.SetXData(blockReference, xData1, xData2, xData3);
			}
			return blockReference;
		}

		[CommandMethod("AddBlockTest")]
		public void AddBlockTest()
		{
			Point3d insertPoint = new Point3d(0.0, 0.0, 0.0);
			Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				this.InsertBlock2(database, transaction, insertPoint, "en81-1", new List<string>(new string[]
				{
					"#SAHİP#",
					"#MAHALLE",
					"#İL#",
					"#CADDE#"
				}), new List<string>(new string[]
				{
					"Value #1",
					"Value #2",
					"Value #3",
					"Value #4"
				}), null, null, null);
				transaction.Commit();
			}
		}

		public BlockReference InsertBlock2(Database db, Transaction tr, Point3d insertPoint, string blockName, List<string> Gelen, List<string> Donen, string xData1 = null, string xData2 = null, string xData3 = null)
		{
			ObjectId objectId = ObjectId.get_Null();
			BlockTable blockTable = tr.GetObject(db.get_BlockTableId(), 0) as BlockTable;
			BlockTableRecord blockTableRecord = tr.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
			BlockReference blockReference = new BlockReference(insertPoint, blockTable.get_Item(blockName));
			objectId = blockTableRecord.AppendEntity(blockReference);
			tr.AddNewlyCreatedDBObject(blockReference, true);
			ascad.ApplyAttibutes(db, tr, blockReference, Gelen, Donen);
			bool flag = xData1 != null;
			if (flag)
			{
				ascad.SetXData(blockReference, xData1, xData2, xData3);
			}
			return blockReference;
		}

		[CommandMethod("AppendAttribute")]
		public void AppendAttribute()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			Database database = mdiActiveDocument.get_Database();
			PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\nSelect attribute to add");
			promptEntityOptions.SetRejectMessage("\nNot an AttributeDefinition");
			promptEntityOptions.AddAllowedClass(typeof(AttributeDefinition), true);
			PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
			bool flag = entity.get_Status() != 5100;
			if (!flag)
			{
				ObjectId objectId = entity.get_ObjectId();
				promptEntityOptions = new PromptEntityOptions("\nSelect block to append attribute");
				promptEntityOptions.SetRejectMessage("\nNot a BlockReference");
				promptEntityOptions.AddAllowedClass(typeof(BlockReference), true);
				entity = editor.GetEntity(promptEntityOptions);
				bool flag2 = entity.get_Status() != 5100;
				if (!flag2)
				{
					ObjectId objectId2 = entity.get_ObjectId();
					using (Transaction transaction = database.get_TransactionManager().StartTransaction())
					{
						try
						{
							AttributeDefinition attributeDefinition = (AttributeDefinition)transaction.GetObject(objectId, 1);
							BlockReference blockReference = (BlockReference)transaction.GetObject(objectId2, 0);
							BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockReference.get_BlockTableRecord(), 1);
							AttributeDefinition attributeDefinition2 = (AttributeDefinition)attributeDefinition.Clone();
							attributeDefinition2.TransformBy(blockReference.get_BlockTransform().Inverse());
							ObjectId objectId3 = blockTableRecord.AppendEntity(attributeDefinition2);
							transaction.AddNewlyCreatedDBObject(attributeDefinition2, true);
							ObjectIdCollection blockReferenceIds = blockTableRecord.GetBlockReferenceIds(true, true);
							foreach (ObjectId objectId4 in blockReferenceIds)
							{
								blockReference = (BlockReference)transaction.GetObject(objectId4, 1);
								AttributeReference attributeReference = new AttributeReference();
								attributeReference.SetAttributeFromBlock(attributeDefinition2, blockReference.get_BlockTransform());
								attributeReference.set_TextString(attributeDefinition.get_TextString());
								blockReference.get_AttributeCollection().AppendAttribute(attributeReference);
								transaction.AddNewlyCreatedDBObject(attributeReference, true);
							}
							attributeDefinition.Erase();
							transaction.Commit();
						}
						catch (Exception ex)
						{
							editor.WriteMessage("\nError: {0}\n{1}", new object[]
							{
								ex.Message,
								ex.StackTrace
							});
						}
					}
				}
			}
		}

		public static void SetXData(Entity bref, string xData1, string xData2, string xData3)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Transaction transaction = mdiActiveDocument.get_TransactionManager().StartTransaction();
			using (transaction)
			{
				ascad.AddRegAppTableRecord("I");
				ResultBuffer resultBuffer = new ResultBuffer(new TypedValue[]
				{
					new TypedValue(1001, "I"),
					new TypedValue(1000, xData1),
					new TypedValue(1000, xData2),
					new TypedValue(1000, xData3)
				});
				bref.set_XData(resultBuffer);
				resultBuffer.Dispose();
				transaction.Commit();
			}
		}

		[CommandMethod("GetXData")]
		public static void GetXData(Entity obj)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\nSelect entity: ");
			PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
			Transaction transaction = mdiActiveDocument.get_TransactionManager().StartTransaction();
			using (transaction)
			{
				DBObject @object = transaction.GetObject(entity.get_ObjectId(), 0);
				ResultBuffer xData = obj.get_XData();
				bool flag = xData == null;
				if (!flag)
				{
					TypedValue[] array = xData.AsArray();
					xData.Dispose();
				}
			}
		}

		[CommandMethod("kabqphes")]
		public void kabqphes()
		{
			new tsestandart
			{
				kabingenstr = this.prman.GetParamValFRM("L1KabinGen", "KK"),
				kabinderstr = this.prman.GetParamValFRM("L1KabinDer", "KK")
			}.Show();
		}

		[CommandMethod("WNOD")]
		public void nodayaz()
		{
			string text = "";
			DataTable dataTable = this.xx.dtta("select * from Num1", "");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
			}
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			try
			{
				using (Transaction transaction = database.get_TransactionManager().StartTransaction())
				{
					DBDictionary dBDictionary = (DBDictionary)transaction.GetObject(database.get_NamedObjectsDictionaryId(), 1);
					Xrecord xrecord = new Xrecord();
					xrecord.set_Data(new ResultBuffer(new TypedValue[]
					{
						new TypedValue(1, text)
					}));
					dBDictionary.SetAt("ASCADDATA", xrecord);
					transaction.AddNewlyCreatedDBObject(xrecord, true);
					transaction.Commit();
				}
			}
			catch (Exception var_9_D2)
			{
			}
			finally
			{
				database.Dispose();
			}
		}

		[CommandMethod("nodoku")]
		public void nodoku()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			try
			{
				using (Transaction transaction = database.get_TransactionManager().StartTransaction())
				{
					DBDictionary dBDictionary = (DBDictionary)transaction.GetObject(database.get_NamedObjectsDictionaryId(), 1);
					Xrecord xrecord = new Xrecord();
					ObjectId at = dBDictionary.GetAt("ASCADDATA");
					Xrecord xrecord2 = (Xrecord)transaction.GetObject(at, 0);
					ResultBufferEnumerator enumerator = xrecord2.get_Data().GetEnumerator();
					while (enumerator.MoveNext())
					{
						TypedValue current = enumerator.get_Current();
						Debug.Print("===== OUR DATA: " + current.get_TypeCode().ToString() + ". " + current.get_Value().ToString());
					}
				}
			}
			catch
			{
			}
		}

		[CommandMethod("shfrm")]
		public void shwpar()
		{
			this.prman.WindowState = FormWindowState.Normal;
			this.prman.Show();
		}

		[CommandMethod("LDEA")]
		public void YeniAsansorELK()
		{
			this.mn2.AsansorSayisi = 1;
			this.mn2.AsansorTipi = "EA";
			this.mn2.FormMyData = this.LiftDataOku("1");
			this.mn2.FormMyData.AASag = "1000";
			this.mn2.FormMyData.AASol = "1000";
			this.mn2.FormMyData.BBSag = "1000";
			this.mn2.FormMyData.BBSol = "1000";
			this.mn2.FormMyData.AgrDuv = "50";
			this.mn2.FormMyData.AgrGen = "150";
			this.mn2.FormMyData.AgrKabin = "120";
			this.mn2.FormMyData.KabinAgrEksenFark = "0";
			this.mn2.FormMyData.KabinDuvar = "100";
			this.mn2.FormMyData.KabinRayFark = "100";
			this.mn2.FormMyData.KabinRayUcu = "30";
			this.mn2.FormMyData.AgirRayUcu = "30";
			this.mn2.FormMyData.KabinYanDuv = "100";
			this.mn2.FormMyData.RayTavan = "100";
			this.mn2.FormMyData.SagKac = "100";
			this.xx.SetRayFark("1");
			this.mn2.ShowDialog();
			this.KapiDegerSet(this.mn2.FormMyData);
			this.LiftDataYaz(this.mn2.FormMyData, "1");
			bool flag = !this.prman.Created;
			if (flag)
			{
				this.prman.aadd = this;
				this.prman.asnadedi = 1;
				this.prman.destandcrash();
			}
			this.DALL();
			this.LD("KK", false, default(Point3d));
		}

		[CommandMethod("LDHA")]
		public void YeniAsansorHA()
		{
			this.xx.SetNumValue("TipKodu", "HA", "1");
			this.xx.SetNumValue("TahrikKodu", "DA", "1");
			bool flag = string.IsNullOrEmpty(this.GetParamValue("LN"));
			if (flag)
			{
				this.NewParam("LN", "1");
			}
			else
			{
				this.chParamVal("LN", "1");
			}
			this.mn2.AsansorSayisi = 1;
			this.mn2.AsansorTipi = "HA";
			this.mn2.FormMyData = this.LiftDataOku("1");
			this.mn2.FormMyData.TipKodu = "HA";
			this.mn2.FormMyData.TahrikKodu = "DA";
			this.mn2.FormMyData.PistonKab = "250";
			this.mn2.FormMyData.PistonMer = "250";
			this.mn2.FormMyData.KabinYanDuv = "100";
			this.mn2.FormMyData.KabinRayFark = "100";
			this.mn2.FormMyData.HRA = "800";
			this.mn2.FormMyData.KabinYanDuv = "150";
			this.mn2.ShowDialog();
			this.KapiDegerSet(this.mn2.FormMyData);
			this.LiftDataYaz(this.mn2.FormMyData, "1");
			this.HAMDDegerSet(this.mn2.FormMyData.MakYon, this.mn2.FormMyData.YonKodu, this.mn2.FormMyData.HAMDGen, this.mn2.FormMyData.HAMDDer, "1");
			bool flag2 = !this.prman.Created;
			if (flag2)
			{
				this.prman.aadd = this;
				this.prman.asnadedi = 1;
				this.prman.destandcrash();
			}
			this.DALL();
			this.LD("KK", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		[CommandMethod("EAEK")]
		public void ElkAnsEkle()
		{
			this.prman.aadd = this;
			this.prman.asnadedi = 2;
			this.prman.destandcrash();
			this.mn2.AsansorSayisi = 2;
			this.mn2.AsansorTipi = "EA";
			this.mn2.FormMyData = this.LiftDataOku("2");
			this.mn2.ShowDialog();
			this.LiftDataYaz(this.mn2.FormMyData, "2");
			this.DALL();
			this.prman.aadd = this;
			this.prman.asnadedi = 2;
			this.prman.destandcrash();
			this.LD("KK", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		[CommandMethod("detaykk")]
		public void detaykk()
		{
			this.DALL();
			bool flag = !this.prman.Created;
			if (flag)
			{
				this.prman.aadd = this;
				this.prman.destandcrash();
			}
			this.LD("KK", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		[CommandMethod("hesa3")]
		public void asnhesap()
		{
			this.fr1.ShowDialog();
			bool hesapiklendi = this.fr1.hesapiklendi;
			if (hesapiklendi)
			{
				this.denemerep(this.fr1.gelen, this.fr1.donen, this.fr1.hesaplamavekagit);
			}
		}

		[CommandMethod("detaykd")]
		public void detaykd()
		{
			this.DALL();
			bool flag = !this.prman.Created;
			if (flag)
			{
				this.prman.aadd = this;
				this.prman.destandcrash();
			}
			this.LD("KD", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		[CommandMethod("detaymd")]
		public void detaymd()
		{
			this.DALL();
			bool flag = !this.prman.Created;
			if (flag)
			{
				this.prman.aadd = this;
				this.prman.destandcrash();
			}
			this.LD("MD", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		[CommandMethod("detayaa")]
		public void detayaa()
		{
			this.DALL();
			bool flag = !this.prman.Created;
			if (flag)
			{
				this.prman.aadd = this;
				this.prman.destandcrash();
			}
			this.LD("TK-AA", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		[CommandMethod("detaybb")]
		public void detaybb()
		{
			this.DALL();
			bool flag = !this.prman.Created;
			if (flag)
			{
				this.prman.aadd = this;
				this.prman.destandcrash();
			}
			this.LD("TK-BB", false, default(Point3d));
			Application.SetSystemVariable("DIMLFAC", 1.0);
		}

		[CommandMethod("Q")]
		public void QGetXData()
		{
			this.DD();
		}

		[CommandMethod("DD")]
		public void DD()
		{
			string text = null;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			string text5 = "I";
			string text6 = "KK";
			TypedValue[] expr_38 = new TypedValue[]
			{
				new TypedValue(1001, text5)
			};
			PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\nSelect entity: ");
			PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
			bool flag = entity.get_Status() == 5100;
			if (flag)
			{
				Transaction transaction = mdiActiveDocument.get_TransactionManager().StartTransaction();
				using (transaction)
				{
					DBObject @object = transaction.GetObject(entity.get_ObjectId(), 0);
					string dxfName = @object.get_ObjectId().get_ObjectClass().get_DxfName();
					ResultBuffer xData = @object.get_XData();
					ResultBufferEnumerator enumerator = xData.GetEnumerator();
					while (enumerator.MoveNext())
					{
						TypedValue current = enumerator.get_Current();
						bool flag2 = current.get_Value().GetType().FullName == "System.String";
						if (flag2)
						{
							bool flag3 = (string)current.get_Value() == "I";
							if (flag3)
							{
								text6 = "KK";
								text5 = "I";
							}
							bool flag4 = (string)current.get_Value() == "MD";
							if (flag4)
							{
								text6 = "MD";
								text5 = "MD";
							}
						}
					}
					ResultBuffer xDataForApplication = @object.GetXDataForApplication(text5);
					bool flag5 = xDataForApplication == null;
					if (flag5)
					{
						editor.WriteMessage("\nEntity does not have XData attached.");
					}
					else
					{
						int num = 0;
						ResultBufferEnumerator enumerator2 = xDataForApplication.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							TypedValue current2 = enumerator2.get_Current();
							num++;
							bool flag6 = num == 3;
							if (flag6)
							{
								text3 = (string)current2.get_Value();
							}
							bool flag7 = num == 2;
							if (flag7)
							{
								bool flag8 = @object.get_ObjectId().get_ObjectClass().get_DxfName() == "DIMENSION";
								if (flag8)
								{
									Dimension dimension = (Dimension)@object;
									text4 = Convert.ToString((int)dimension.get_Measurement());
									olcudeis olcudeis = new olcudeis();
									olcudeis.OldValue = text4;
									olcudeis.ShowDialog();
									text2 = olcudeis.NewValue.Replace("-", "");
								}
								else
								{
									bool flag9 = @object.get_ObjectId().get_ObjectClass().get_DxfName() == "INSERT";
									if (flag9)
									{
										string gelen = (string)current2.get_Value();
										bool flag10 = this.myPaletteSet != null && this.myPalette.Visible;
										if (flag10)
										{
											this.myPalette.objedefiner(gelen);
										}
									}
								}
								text = (string)current2.get_Value();
							}
						}
						xDataForApplication.Dispose();
					}
				}
			}
			bool flag11 = text == null;
			if (!flag11)
			{
				bool flag12 = text2 == null || text2 == "";
				if (!flag12)
				{
					int num2 = Convert.ToInt32(text2) - Convert.ToInt32(text4);
					bool flag13 = num2 == 0;
					if (!flag13)
					{
						structTahrik tahrik = this.ReadTahrikData(text3);
						string[] array = text.Split(new char[]
						{
							Convert.ToChar(",")
						});
						for (int i = 1; i <= array.Length; i++)
						{
							bool flag14 = array[i - 1].IndexOf("#") == -1;
							if (flag14)
							{
								text = "L" + text3 + array[i - 1];
								string text7 = this.prman.GetParamValFRM(text, text6);
								text7 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(text7)) + num2);
								this.prman.chParamVal(text, text7);
								this.xx.upexcel(array[i - 1], text7, text3, tahrik);
							}
							else
							{
								string[] array2 = array[i - 1].Split(new char[]
								{
									Convert.ToChar("#")
								});
								text = "L" + text3 + array2[0];
								string text7 = this.prman.GetParamValFRM(text, text6);
								text7 = Convert.ToString((double)Convert.ToInt32(Convert.ToDouble(text7)) + (double)num2 * Convert.ToDouble(array2[1].Replace(".", ",")));
								this.prman.chParamVal(text, text7);
								this.xx.upexcel(array2[0], text7, text3, tahrik);
							}
						}
						clsMLift clsMLift = new clsMLift();
						clsMLift = this.ReadAllData(text3, text6);
						clsMLift.LiftNum = Convert.ToInt32(text3);
						Entity entity2 = ascad.FObject("Kabin", text3, "KK");
						bool flag15 = entity2 != null;
						if (flag15)
						{
							clsMLift = null;
							clsMLift = this.ReadAllData(text3, "KK");
							clsMLift.KesitKodu = "KK";
							clsMLift.LiftNum = Convert.ToInt32(text3);
							Transaction transaction3 = mdiActiveDocument.get_TransactionManager().StartTransaction();
							using (transaction3)
							{
								BlockReference blockReference = (BlockReference)transaction3.GetObject(entity2.get_ObjectId(), 0);
								clsMLift.BasePoint = blockReference.get_Position();
								transaction3.Commit();
							}
							this.LiftDraw2(clsMLift, false);
						}
						entity2 = ascad.FObject("BUTUNKUYU", "1", "KD");
						bool flag16 = entity2 != null;
						if (flag16)
						{
							clsMLift = null;
							clsMLift = this.ReadAllData(text3, "KD");
							clsMLift.KesitKodu = "KD";
							clsMLift.LiftNum = Convert.ToInt32(text3);
							Transaction transaction5 = mdiActiveDocument.get_TransactionManager().StartTransaction();
							using (transaction5)
							{
								BlockReference blockReference2 = (BlockReference)transaction5.GetObject(entity2.get_ObjectId(), 0);
								clsMLift.BasePoint = blockReference2.get_Position();
								transaction5.Commit();
							}
							this.LiftDraw2(clsMLift, false);
						}
						entity2 = ascad.FObject("TK-AA", "1", "TK-AA");
						bool flag17 = entity2 != null;
						if (flag17)
						{
							clsMLift = null;
							clsMLift = this.ReadAllData(text3, "TK-AA");
							clsMLift.KesitKodu = "TK-AA";
							clsMLift.LiftNum = Convert.ToInt32(text3);
							Transaction transaction7 = mdiActiveDocument.get_TransactionManager().StartTransaction();
							using (transaction7)
							{
								BlockReference blockReference3 = (BlockReference)transaction7.GetObject(entity2.get_ObjectId(), 0);
								clsMLift.BasePoint = blockReference3.get_Position();
								transaction7.Commit();
							}
							this.LiftDraw2(clsMLift, false);
						}
						entity2 = ascad.FObject("TK-BB", "1", "TK-BB");
						bool flag18 = entity2 != null;
						if (flag18)
						{
							clsMLift = null;
							clsMLift = this.ReadAllData(text3, "TK-BB");
							clsMLift.KesitKodu = "TK-BB";
							clsMLift.LiftNum = Convert.ToInt32(text3);
							Transaction transaction9 = mdiActiveDocument.get_TransactionManager().StartTransaction();
							using (transaction9)
							{
								BlockReference blockReference4 = (BlockReference)transaction9.GetObject(entity2.get_ObjectId(), 0);
								clsMLift.BasePoint = blockReference4.get_Position();
								transaction9.Commit();
							}
							this.LiftDraw2(clsMLift, false);
						}
						entity2 = ascad.FObject("MDEksenYan", "1", "MD");
						bool flag19 = entity2 == null;
						if (flag19)
						{
							entity2 = ascad.FObject("MDEksenSag", "1", "MD");
						}
						bool flag20 = entity2 == null;
						if (flag20)
						{
							entity2 = ascad.FObject("MDEksenArka", "1", "MD");
						}
						bool flag21 = entity2 != null;
						if (flag21)
						{
							clsMLift = null;
							clsMLift = this.ReadAllData(text3, "MD");
							clsMLift.KesitKodu = "MD";
							clsMLift.LiftNum = Convert.ToInt32(text3);
							Transaction transaction11 = mdiActiveDocument.get_TransactionManager().StartTransaction();
							using (transaction11)
							{
								BlockReference blockReference5 = (BlockReference)transaction11.GetObject(entity2.get_ObjectId(), 0);
								clsMLift.BasePoint = blockReference5.get_Position();
								transaction11.Commit();
							}
							this.LiftDraw2(clsMLift, false);
						}
						Application.SetSystemVariable("DIMLFAC", 1.0);
					}
				}
			}
		}

		[CommandMethod("GXD")]
		public void GetXData()
		{
			this.DD();
		}

		public void ChObj(int LiftNum, string BlockXData)
		{
			vtLift vtLift = new vtLift();
			vtLift = this.dtta(BlockXData, Convert.ToString(LiftNum));
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions("\nYeni Blok Adını Seçiniz :");
			promptKeywordOptions.set_AllowNone(false);
			foreach (BlkPar current in vtLift.BlkList)
			{
				promptKeywordOptions.get_Keywords().Add(current.BlkName);
			}
			PromptResult keywords = editor.GetKeywords(promptKeywordOptions);
			bool flag = keywords.get_Status() != 5100;
			if (!flag)
			{
				this.xx.UpExcelBlockName(BlockXData, keywords.get_StringResult(), Convert.ToString(LiftNum));
				this.DALL();
				this.AsCad();
			}
		}

		private static void AddRegAppTableRecord(string regAppName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			Database database = mdiActiveDocument.get_Database();
			Transaction transaction = mdiActiveDocument.get_TransactionManager().StartTransaction();
			using (transaction)
			{
				RegAppTable regAppTable = (RegAppTable)transaction.GetObject(database.get_RegAppTableId(), 0, false);
				bool flag = !regAppTable.Has(regAppName);
				if (flag)
				{
					regAppTable.UpgradeOpen();
					RegAppTableRecord regAppTableRecord = new RegAppTableRecord();
					regAppTableRecord.set_Name(regAppName);
					regAppTable.Add(regAppTableRecord);
					transaction.AddNewlyCreatedDBObject(regAppTableRecord, true);
				}
				transaction.Commit();
			}
		}

		public void DeleteParam(string vtParName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
		}

		public string GetParamValue(string vtParName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			return "";
		}

		public void RenameParam(string vtParName, string newName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
		}

		public void chParamVal(string vtParName, string newName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
		}

		public void NewParam(string vtParName, string newValue)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
		}

		[CommandMethod("ADDXDATA")]
		public static void AddXdata()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Transaction transaction = database.get_TransactionManager().StartTransaction();
			using (transaction)
			{
				Editor editor = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor();
				PromptEntityResult entity = editor.GetEntity("Pick entity ");
				Entity entity2 = (Entity)transaction.GetObject(entity.get_ObjectId(), 1);
				RegAppTable regAppTable = (RegAppTable)transaction.GetObject(database.get_RegAppTableId(), 0);
				bool flag = !regAppTable.Has("ADS");
				if (flag)
				{
					regAppTable.UpgradeOpen();
					RegAppTableRecord regAppTableRecord = new RegAppTableRecord();
					regAppTableRecord.set_Name("ADS");
					regAppTable.Add(regAppTableRecord);
					transaction.AddNewlyCreatedDBObject(regAppTableRecord, true);
				}
				entity2.set_XData(new ResultBuffer(new TypedValue[]
				{
					new TypedValue(1001, "ADS"),
					new TypedValue(1070, 100)
				}));
				transaction.Commit();
			}
		}

		[CommandMethod("REMXDATA")]
		public static void RemoveXdata()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Transaction transaction = database.get_TransactionManager().StartTransaction();
			using (transaction)
			{
				Editor editor = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor();
				try
				{
					PromptEntityResult entity = editor.GetEntity("Pick entity ");
					Entity entity2 = (Entity)transaction.GetObject(entity.get_ObjectId(), 0);
					ResultBuffer xDataForApplication = entity2.GetXDataForApplication("ADS");
					bool flag = xDataForApplication != null;
					if (flag)
					{
						entity2.UpgradeOpen();
						entity2.set_XData(new ResultBuffer(new TypedValue[]
						{
							new TypedValue(1001, "ADS")
						}));
						xDataForApplication.Dispose();
					}
					transaction.Commit();
				}
				catch
				{
					transaction.Abort();
				}
			}
		}

		public void LayerOff(string sLayerName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				bool flag = !layerTable.Has(sLayerName);
				if (flag)
				{
					using (LayerTableRecord layerTableRecord = new LayerTableRecord())
					{
						layerTableRecord.set_Name(sLayerName);
						layerTable.UpgradeOpen();
						layerTable.Add(layerTableRecord);
						transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
						layerTableRecord.set_IsOff(true);
					}
				}
				else
				{
					LayerTableRecord layerTableRecord2 = transaction.GetObject(layerTable.get_Item(sLayerName), 1) as LayerTableRecord;
					layerTableRecord2.set_IsOff(true);
				}
				transaction.Commit();
			}
		}

		public static void LayerOff(Document acDoc, Transaction acTrans, string sLayerName)
		{
			Database database = acDoc.get_Database();
			LayerTable layerTable = acTrans.GetObject(database.get_LayerTableId(), 0) as LayerTable;
			bool flag = !layerTable.Has(sLayerName);
			if (flag)
			{
				using (LayerTableRecord layerTableRecord = new LayerTableRecord())
				{
					layerTableRecord.set_Name(sLayerName);
					layerTable.UpgradeOpen();
					layerTable.Add(layerTableRecord);
					acTrans.AddNewlyCreatedDBObject(layerTableRecord, true);
					layerTableRecord.set_IsOff(true);
				}
			}
			else
			{
				LayerTableRecord layerTableRecord2 = acTrans.GetObject(layerTable.get_Item(sLayerName), 1) as LayerTableRecord;
				layerTableRecord2.set_IsOff(true);
			}
		}

		public static void LayerOn(Document acDoc, Transaction acTrans, string sLayerName)
		{
			Database database = acDoc.get_Database();
			LayerTable layerTable = acTrans.GetObject(database.get_LayerTableId(), 0) as LayerTable;
			bool flag = layerTable.Has(sLayerName);
			if (flag)
			{
				LayerTableRecord layerTableRecord = acTrans.GetObject(layerTable.get_Item(sLayerName), 1) as LayerTableRecord;
				layerTableRecord.set_IsOff(false);
			}
		}

		[CommandMethod("TurnLayerOff")]
		public static void TurnLayerOff()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				string text = "ABC";
				bool flag = !layerTable.Has(text);
				if (flag)
				{
					using (LayerTableRecord layerTableRecord = new LayerTableRecord())
					{
						layerTableRecord.set_Name(text);
						layerTable.UpgradeOpen();
						layerTable.Add(layerTableRecord);
						transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
						layerTableRecord.set_IsOff(true);
					}
				}
				else
				{
					LayerTableRecord layerTableRecord2 = transaction.GetObject(layerTable.get_Item(text), 1) as LayerTableRecord;
					layerTableRecord2.set_IsOff(true);
				}
				BlockTable blockTable = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
				using (Circle circle = new Circle())
				{
					circle.set_Center(new Point3d(2.0, 2.0, 0.0));
					circle.set_Radius(1.0);
					circle.set_Layer(text);
					blockTableRecord.AppendEntity(circle);
					transaction.AddNewlyCreatedDBObject(circle, true);
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TurnLayerOn")]
		public static void TurnLayerOn()
		{
			ascad.LayerOn("SOLDUBEL");
		}

		public static void LayerOn(string sLayerName)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				bool flag = layerTable.Has(sLayerName);
				if (flag)
				{
					LayerTableRecord layerTableRecord = transaction.GetObject(layerTable.get_Item(sLayerName), 1) as LayerTableRecord;
					layerTableRecord.set_IsOff(false);
				}
				transaction.Commit();
			}
		}

		[CommandMethod("LockLayer")]
		public static void LockLayer()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				string text = "ABC";
				bool flag = !layerTable.Has(text);
				if (flag)
				{
					using (LayerTableRecord layerTableRecord = new LayerTableRecord())
					{
						layerTableRecord.set_Name(text);
						layerTable.UpgradeOpen();
						layerTable.Add(layerTableRecord);
						transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
						layerTableRecord.set_IsLocked(true);
					}
				}
				else
				{
					LayerTableRecord layerTableRecord2 = transaction.GetObject(layerTable.get_Item(text), 1) as LayerTableRecord;
					layerTableRecord2.set_IsLocked(true);
				}
				transaction.Commit();
			}
		}

		[CommandMethod("SetLayerCurrent")]
		public static void SetLayerCurrent()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				string text = "Center";
				bool flag = layerTable.Has(text);
				if (flag)
				{
					database.set_Clayer(layerTable.get_Item(text));
					transaction.Commit();
				}
			}
		}

		[CommandMethod("IterateLayers")]
		public static void IterateLayers()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				using (SymbolTableEnumerator enumerator = layerTable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						LayerTableRecord layerTableRecord = transaction.GetObject(current, 0) as LayerTableRecord;
						mdiActiveDocument.get_Editor().WriteMessage("\n" + layerTableRecord.get_Name());
					}
				}
			}
		}

		[CommandMethod("FindMyLayer")]
		public static void FindMyLayer()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				bool flag = !layerTable.Has("MyLayer");
				if (flag)
				{
					mdiActiveDocument.get_Editor().WriteMessage("\n'MyLayer' does not exist");
				}
				else
				{
					mdiActiveDocument.get_Editor().WriteMessage("\n'MyLayer' exists");
				}
			}
		}

		[CommandMethod("CL")]
		public void CreateLayer()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			Transaction transaction = database.get_TransactionManager().StartTransaction();
			using (transaction)
			{
				LayerTable layerTable = (LayerTable)transaction.GetObject(database.get_LayerTableId(), 0);
				PromptStringOptions promptStringOptions = new PromptStringOptions("\nEnter new layer name: ");
				promptStringOptions.set_AllowSpaces(true);
				string text = "";
				while (true)
				{
					PromptResult @string = editor.GetString(promptStringOptions);
					bool flag = @string.get_Status() != 5100;
					if (flag)
					{
						break;
					}
					try
					{
						SymbolUtilityServices.ValidateSymbolName(@string.get_StringResult(), false);
						bool flag2 = layerTable.Has(@string.get_StringResult());
						if (flag2)
						{
							editor.WriteMessage("\nA layer with this name already exists.");
						}
						else
						{
							text = @string.get_StringResult();
						}
					}
					catch
					{
						editor.WriteMessage("\nInvalid layer name.");
					}
					if (!(text == ""))
					{
						goto Block_5;
					}
				}
				return;
				Block_5:
				LayerTableRecord layerTableRecord = new LayerTableRecord();
				layerTableRecord.set_Name(text);
				layerTableRecord.set_Color(Color.FromColorIndex(195, ascad._colorIndex));
				layerTable.UpgradeOpen();
				ObjectId clayer = layerTable.Add(layerTableRecord);
				transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
				database.set_Clayer(clayer);
				transaction.Commit();
				Editor arg_162_0 = editor;
				string arg_162_1 = "\nCreated layer named \"{0}\" with a color index of {1}.";
				object[] expr_147 = new object[2];
				expr_147[0] = text;
				int arg_161_1 = 1;
				short expr_153 = ascad._colorIndex;
				ascad._colorIndex = expr_153 + 1;
				expr_147[arg_161_1] = expr_153;
				arg_162_0.WriteMessage(arg_162_1, expr_147);
			}
		}

		[CommandMethod("EraseLayer")]
		public static void EraseLayer()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				string text = "ABC";
				bool flag = layerTable.Has(text);
				if (flag)
				{
					ObjectIdCollection objectIdCollection = new ObjectIdCollection();
					objectIdCollection.Add(layerTable.get_Item(text));
					database.Purge(objectIdCollection);
					bool flag2 = objectIdCollection.get_Count() > 0;
					if (flag2)
					{
						LayerTableRecord layerTableRecord = transaction.GetObject(objectIdCollection.get_Item(0), 1) as LayerTableRecord;
						try
						{
							layerTableRecord.Erase(true);
							transaction.Commit();
						}
						catch (Exception ex)
						{
							Application.ShowAlertDialog("Error:\n" + ex.Message);
						}
					}
				}
			}
		}

		[CommandMethod("CreateAndAssignALayer")]
		public static void CreateAndAssignALayer()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				string text = "Center";
				bool flag = !layerTable.Has(text);
				if (flag)
				{
					using (LayerTableRecord layerTableRecord = new LayerTableRecord())
					{
						layerTableRecord.set_Color(Color.FromColorIndex(195, 3));
						layerTableRecord.set_Name(text);
						layerTable.UpgradeOpen();
						layerTable.Add(layerTableRecord);
						transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
					}
				}
				BlockTable blockTable = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
				BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
				using (Circle circle = new Circle())
				{
					circle.set_Center(new Point3d(2.0, 2.0, 0.0));
					circle.set_Radius(1.0);
					circle.set_Layer(text);
					blockTableRecord.AppendEntity(circle);
					transaction.AddNewlyCreatedDBObject(circle, true);
				}
				transaction.Commit();
			}
		}

		[CommandMethod("FreezeLayer")]
		public static void FreezeLayer()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				string text = "ABC";
				bool flag = !layerTable.Has(text);
				if (flag)
				{
					using (LayerTableRecord layerTableRecord = new LayerTableRecord())
					{
						layerTableRecord.set_Name(text);
						layerTable.UpgradeOpen();
						layerTable.Add(layerTableRecord);
						transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
						layerTableRecord.set_IsFrozen(true);
					}
				}
				else
				{
					LayerTableRecord layerTableRecord2 = transaction.GetObject(layerTable.get_Item(text), 1) as LayerTableRecord;
					layerTableRecord2.set_IsFrozen(true);
				}
				transaction.Commit();
			}
		}

		[CommandMethod("SetLayerColor")]
		public static void SetLayerColor()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				string[] array = new string[]
				{
					"ACIRed",
					"TrueBlue",
					"ColorBookYellow"
				};
				Color[] array2 = new Color[]
				{
					Color.FromColorIndex(195, 1),
					Color.FromRgb(23, 54, 232),
					Color.FromNames("PANTONE Yellow 0131 C", "PANTONE(R) pastel coated")
				};
				int num = 0;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					string text = array3[i];
					bool flag = !layerTable.Has(text);
					if (flag)
					{
						using (LayerTableRecord layerTableRecord = new LayerTableRecord())
						{
							layerTableRecord.set_Name(text);
							bool flag2 = !layerTable.get_IsWriteEnabled();
							if (flag2)
							{
								layerTable.UpgradeOpen();
							}
							layerTable.Add(layerTableRecord);
							transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
							layerTableRecord.set_Color(array2[num]);
						}
					}
					else
					{
						LayerTableRecord layerTableRecord2 = transaction.GetObject(layerTable.get_Item(text), 1) as LayerTableRecord;
						layerTableRecord2.set_Color(array2[num]);
					}
					num++;
				}
				transaction.Commit();
			}
		}

		[CommandMethod("SetLayerLinetype")]
		public static void SetLayerLinetype()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				LayerTable layerTable = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
				string text = "ABC";
				bool flag = !layerTable.Has(text);
				if (flag)
				{
					using (LayerTableRecord layerTableRecord = new LayerTableRecord())
					{
						layerTableRecord.set_Name(text);
						layerTable.UpgradeOpen();
						layerTable.Add(layerTableRecord);
						transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
						LinetypeTable linetypeTable = transaction.GetObject(database.get_LinetypeTableId(), 0) as LinetypeTable;
						bool flag2 = linetypeTable.Has("Center");
						if (flag2)
						{
							layerTableRecord.UpgradeOpen();
							layerTableRecord.set_LinetypeObjectId(linetypeTable.get_Item("Center"));
						}
					}
				}
				else
				{
					LayerTableRecord layerTableRecord2 = transaction.GetObject(layerTable.get_Item(text), 0) as LayerTableRecord;
					LinetypeTable linetypeTable2 = transaction.GetObject(database.get_LinetypeTableId(), 0) as LinetypeTable;
					bool flag3 = linetypeTable2.Has("Center");
					if (flag3)
					{
						layerTableRecord2.UpgradeOpen();
						layerTableRecord2.set_LinetypeObjectId(linetypeTable2.get_Item("Center"));
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("UA")]
		public void UpdateAttribute()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			PromptResult @string = editor.GetString("\nEnter name of block to search for: ");
			bool flag = @string.get_Status() != 5100;
			if (!flag)
			{
				string blockName = @string.get_StringResult().ToUpper();
				@string = editor.GetString("\nEnter tag of attribute to update: ");
				bool flag2 = @string.get_Status() != 5100;
				if (!flag2)
				{
					string attbName = @string.get_StringResult().ToUpper();
					@string = editor.GetString("\nEnter new value for attribute: ");
					bool flag3 = @string.get_Status() != 5100;
					if (!flag3)
					{
						string stringResult = @string.get_StringResult();
						this.UpdateAttributesInDatabase(database, blockName, attbName, stringResult);
					}
				}
			}
		}

		private void UpdateAttributesInDatabase(Database db, string blockName, string attbName, string attbValue)
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Editor editor = mdiActiveDocument.get_Editor();
			Transaction transaction = db.get_TransactionManager().StartTransaction();
			ObjectId btrId;
			ObjectId btrId2;
			using (transaction)
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(db.get_BlockTableId(), 0);
				btrId = blockTable.get_Item(BlockTableRecord.ModelSpace);
				btrId2 = blockTable.get_Item(BlockTableRecord.PaperSpace);
				transaction.Commit();
			}
			int num = this.UpdateAttributesInBlock(btrId, blockName, attbName, attbValue);
			int num2 = this.UpdateAttributesInBlock(btrId2, blockName, attbName, attbValue);
			editor.Regen();
			editor.WriteMessage("\nProcessing file: " + db.get_Filename());
			editor.WriteMessage("\nUpdated {0} instance{1} of attribute {2} in the modelspace.", new object[]
			{
				num,
				(num == 1) ? "" : "s",
				attbName
			});
			editor.WriteMessage("\nUpdated {0} instance{1} of attribute {2} in the default paperspace.", new object[]
			{
				num2,
				(num2 == 1) ? "" : "s",
				attbName
			});
		}

		private int UpdateAttributesInBlock(ObjectId btrId, string blockName, string attbName, string attbValue)
		{
			int num = 0;
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			Transaction transaction = mdiActiveDocument.get_TransactionManager().StartTransaction();
			using (transaction)
			{
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(btrId, 0);
				using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.get_Current();
						Entity entity = transaction.GetObject(current, 0) as Entity;
						bool flag = entity != null;
						if (flag)
						{
							BlockReference blockReference = entity as BlockReference;
							bool flag2 = blockReference != null;
							if (flag2)
							{
								BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(blockReference.get_BlockTableRecord(), 0);
								bool flag3 = blockTableRecord2.get_Name().ToUpper() == blockName;
								if (flag3)
								{
									foreach (ObjectId objectId in blockReference.get_AttributeCollection())
									{
										DBObject @object = transaction.GetObject(objectId, 0);
										AttributeReference attributeReference = @object as AttributeReference;
										bool flag4 = attributeReference != null;
										if (flag4)
										{
											bool flag5 = attributeReference.get_Tag().ToUpper() == attbName;
											if (flag5)
											{
												attributeReference.UpgradeOpen();
												attributeReference.set_TextString(attbValue);
												attributeReference.DowngradeOpen();
												num++;
											}
										}
									}
								}
								num += this.UpdateAttributesInBlock(blockReference.get_BlockTableRecord(), blockName, attbName, attbValue);
							}
						}
					}
				}
				transaction.Commit();
			}
			return num;
		}

		[CommandMethod("ANTETINFO")]
		public void palette()
		{
			bool flag = this.myPaletteSet == null;
			if (flag)
			{
				this.myPaletteSet = new PaletteSet("As-CAD", Guid.NewGuid());
				this.myPalette.AscadDLL = this;
				this.myPaletteSet.Add("As-CAD", this.myPalette);
				this.myPalette.kabinderx.Text = this.prman.GetParamValFRM("L1KabinGen", "KK");
				this.myPalette.kabingenx.Text = this.prman.GetParamValFRM("L1KabinDer", "KK");
			}
			this.myPaletteSet.set_Visible(true);
		}

		[CommandMethod("dimdene")]
		public void dimdene2x()
		{
			Point3d point3d = new Point3d(0.0, 0.0, 0.0);
			string xdata = "1";
			string xdata2 = "KK";
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					Point3d xLine1Point = default(Point3d);
					Point3d xLine2Point = default(Point3d);
					Point3d textPosition = default(Point3d);
					using (database)
					{
						using (Transaction transaction = mdiActiveDocument.get_TransactionManager().StartTransaction())
						{
							Entity entity = ascad.FObject("DIMDYN", xdata, xdata2);
							bool flag2 = entity != null;
							if (flag2)
							{
								BlockReference blockReference = (BlockReference)transaction.GetObject(entity.get_ObjectId(), 0);
								DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
								foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
								{
									string text = dynamicBlockReferenceProperty.get_PropertyName().Trim();
									bool flag3 = text == "Origin" || text.LastIndexOf("P1X") != -1 || text.LastIndexOf("P1Y") != -1 || text.LastIndexOf("P2X") != -1 || text.LastIndexOf("P2Y") != -1 || text.LastIndexOf("XLX") != -1 || text.LastIndexOf("XLY") != -1;
									if (!flag3)
									{
										Entity entity2 = ascad.FObjectDIM(text, xdata, xdata2);
										bool flag4 = entity2 != null;
										if (flag4)
										{
											Entity entity3 = (Entity)transaction.GetObject(entity2.get_ObjectId(), 0, false, true);
											AlignedDimension alignedDimension = (AlignedDimension)entity3;
											xLine1Point = new Point3d(point3d.get_X() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P1X")), point3d.get_Y() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P1Y")), 0.0);
											xLine2Point = new Point3d(point3d.get_X() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P2X")), point3d.get_Y() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P2Y")), 0.0);
											textPosition = default(Point3d);
											alignedDimension.UpgradeOpen();
											alignedDimension.set_XLine1Point(xLine1Point);
											alignedDimension.set_XLine2Point(xLine2Point);
											alignedDimension.set_Dimscale(Convert.ToDouble(Application.GetSystemVariable("DIMSCALE")));
											alignedDimension.set_Dimlfac(Convert.ToDouble(Application.GetSystemVariable("DIMLFAC")));
											bool flag5 = xLine1Point.get_X() == xLine2Point.get_X();
											if (flag5)
											{
												bool flag6 = xLine1Point.get_Y() > xLine2Point.get_Y();
												if (flag6)
												{
													textPosition = new Point3d(Convert.ToDouble(point3d.get_X() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLX"))), point3d.get_Y() + xLine1Point.get_Y() - Math.Abs((xLine2Point.get_Y() - xLine1Point.get_Y()) / 2.0), 0.0);
												}
												else
												{
													textPosition = new Point3d(Convert.ToDouble(point3d.get_X() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLX"))), point3d.get_Y() + xLine1Point.get_Y() + Math.Abs((xLine2Point.get_Y() - xLine1Point.get_Y()) / 2.0), 0.0);
												}
											}
											else
											{
												bool flag7 = xLine1Point.get_X() > xLine2Point.get_X();
												if (flag7)
												{
													textPosition = new Point3d(point3d.get_X() + xLine1Point.get_X() - Math.Abs((xLine2Point.get_X() - xLine1Point.get_X()) / 2.0), point3d.get_Y() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLY")), 0.0);
												}
												else
												{
													textPosition = new Point3d(point3d.get_X() + xLine1Point.get_X() + Math.Abs((xLine2Point.get_X() - xLine1Point.get_X()) / 2.0), point3d.get_Y() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLY")), 0.0);
												}
											}
											alignedDimension.set_TextPosition(textPosition);
										}
									}
								}
							}
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception var_29_539)
			{
			}
		}

		public void dimdene2(string LiftNumber, string KesitKodu, Point3d BasePoint, bool OldNew)
		{
			try
			{
				Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
				bool flag = mdiActiveDocument == null;
				if (!flag)
				{
					Database database = mdiActiveDocument.get_Database();
					Editor editor = mdiActiveDocument.get_Editor();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					Point3d xLine1Point = default(Point3d);
					Point3d xLine2Point = default(Point3d);
					Point3d textPosition = default(Point3d);
					using (mdiActiveDocument.LockDocument())
					{
						using (Transaction transaction = database.get_TransactionManager().StartTransaction())
						{
							Entity entity = ascad.FObject("DIMDYN" + KesitKodu, LiftNumber, KesitKodu);
							bool flag2 = entity != null;
							if (flag2)
							{
								BlockReference blockReference = (BlockReference)transaction.GetObject(entity.get_ObjectId(), 0);
								DynamicBlockReferencePropertyCollection dynamicBlockReferencePropertyCollection = blockReference.get_DynamicBlockReferencePropertyCollection();
								foreach (DynamicBlockReferenceProperty dynamicBlockReferenceProperty in dynamicBlockReferencePropertyCollection)
								{
									string text = dynamicBlockReferenceProperty.get_PropertyName().Trim();
									bool flag3 = text == "Origin" || text.LastIndexOf("P1X") != -1 || text.LastIndexOf("P1Y") != -1 || text.LastIndexOf("P2X") != -1 || text.LastIndexOf("P2Y") != -1 || text.LastIndexOf("XLX") != -1 || text.LastIndexOf("XLY") != -1;
									if (!flag3)
									{
										Entity entity2 = ascad.FObjectDIM(text, LiftNumber.Trim(), KesitKodu.Trim());
										bool flag4 = entity2 != null;
										if (flag4)
										{
											Entity entity3 = (Entity)transaction.GetObject(entity2.get_ObjectId(), 0, false, true);
											AlignedDimension alignedDimension = (AlignedDimension)entity3;
											xLine1Point = new Point3d(BasePoint.get_X() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P1X")), BasePoint.get_Y() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P1Y")), 0.0);
											xLine2Point = new Point3d(BasePoint.get_X() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P2X")), BasePoint.get_Y() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "P2Y")), 0.0);
											textPosition = default(Point3d);
											alignedDimension.UpgradeOpen();
											alignedDimension.set_XLine1Point(xLine1Point);
											alignedDimension.set_XLine2Point(xLine2Point);
											if (OldNew)
											{
												alignedDimension.set_Dimscale(Convert.ToDouble(Application.GetSystemVariable("DIMSCALE")));
												alignedDimension.set_Dimlfac(Convert.ToDouble(Application.GetSystemVariable("DIMLFAC")));
											}
											bool flag5 = alignedDimension.get_Measurement() == 0.0;
											if (flag5)
											{
												alignedDimension.Erase();
											}
											else
											{
												bool flag6 = xLine1Point.get_X() == xLine2Point.get_X();
												if (flag6)
												{
													bool flag7 = xLine1Point.get_Y() > xLine2Point.get_Y();
													if (flag7)
													{
														textPosition = new Point3d(Convert.ToDouble(BasePoint.get_X() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLX"))), xLine2Point.get_Y() + Math.Abs((xLine2Point.get_Y() - xLine1Point.get_Y()) / 2.0), 0.0);
													}
													else
													{
														textPosition = new Point3d(Convert.ToDouble(BasePoint.get_X() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLX"))), xLine1Point.get_Y() + (xLine2Point.get_Y() - xLine1Point.get_Y()) / 2.0, 0.0);
													}
												}
												else
												{
													bool flag8 = xLine1Point.get_X() > xLine2Point.get_X();
													if (flag8)
													{
														textPosition = new Point3d(xLine2Point.get_X() + Math.Abs((xLine2Point.get_X() - xLine1Point.get_X()) / 2.0), BasePoint.get_Y() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLY")), 0.0);
													}
													else
													{
														textPosition = new Point3d(xLine1Point.get_X() + Math.Abs((xLine2Point.get_X() - xLine1Point.get_X()) / 2.0), BasePoint.get_Y() + Convert.ToDouble(this.GetDynamicValue(database, transaction, entity, dynamicBlockReferenceProperty.get_PropertyName() + "XLY")), 0.0);
													}
												}
												alignedDimension.set_TextPosition(textPosition);
												alignedDimension.RecomputeDimensionBlock(true);
											}
										}
									}
								}
							}
							transaction.Commit();
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(string.Concat(new string[]
				{
					LiftNumber,
					"-",
					KesitKodu,
					"-> CATCH HATA ->",
					ex.ToString()
				}));
			}
		}

		private static void EditBlockTag(string blockName, string attName, string newValue)
		{
			Database workingDatabase = HostApplicationServices.get_WorkingDatabase();
			Editor editor = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor();
			using (Transaction transaction = workingDatabase.get_TransactionManager().StartTransaction())
			{
				BlockTable blockTable = transaction.GetObject(workingDatabase.get_BlockTableId(), 0) as BlockTable;
				bool flag = blockTable == null;
				if (!flag)
				{
					BlockTableRecord blockTableRecord = transaction.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
					bool flag2 = blockTableRecord == null;
					if (!flag2)
					{
						using (BlockTableRecordEnumerator enumerator = blockTableRecord.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.get_Current();
								BlockReference blockReference = transaction.GetObject(current, 0) as BlockReference;
								bool flag3 = blockReference == null;
								if (!flag3)
								{
									bool flag4 = !blockReference.get_Name().Equals(blockName, StringComparison.CurrentCultureIgnoreCase);
									if (!flag4)
									{
										foreach (ObjectId objectId in blockReference.get_AttributeCollection())
										{
											AttributeReference attributeReference = transaction.GetObject(objectId, 0) as AttributeReference;
											bool flag5 = attributeReference == null;
											if (!flag5)
											{
												bool flag6 = !attributeReference.get_Tag().Equals(attName, StringComparison.CurrentCultureIgnoreCase);
												if (!flag6)
												{
													attributeReference.UpgradeOpen();
													attributeReference.set_TextString(newValue);
												}
											}
										}
									}
								}
							}
						}
						transaction.Commit();
					}
				}
			}
		}

		private void beyanqbul(string liftnumber)
		{
			decimal d = 0m;
			decimal d2 = 0m;
			d2 = Convert.ToDecimal(this.prman.GetParamValFRM("L" + liftnumber + "KabinGen", "KK"));
			d = Convert.ToDecimal(this.prman.GetParamValFRM("L" + liftnumber + "KabinDer", "KK"));
			decimal value = decimal.Round(d2 * d / 1000000m, 2);
			double num = Convert.ToDouble(value);
			bool flag = this.myPaletteSet != null && this.myPalette.Visible;
			if (flag)
			{
				this.myPalette.kabinderx.Text = d.ToString();
				this.myPalette.kabingenx.Text = d2.ToString();
			}
			bool flag2 = 0.49 <= num && num <= 0.58;
			if (flag2)
			{
				this.xx.SetNumValue("BeyanYuk", "180", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "3", liftnumber);
			}
			bool flag3 = 0.6 <= num && num <= 0.7;
			if (flag3)
			{
				this.xx.SetNumValue("BeyanYuk", "225", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "3", liftnumber);
			}
			bool flag4 = 0.79 <= num && num <= 0.9;
			if (flag4)
			{
				this.xx.SetNumValue("BeyanYuk", "300", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "4", liftnumber);
			}
			bool flag5 = 0.9 <= num && num <= 0.98;
			if (flag5)
			{
				this.xx.SetNumValue("BeyanYuk", "320", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "5", liftnumber);
			}
			bool flag6 = 0.98 <= num && num <= 1.1;
			if (flag6)
			{
				this.xx.SetNumValue("BeyanYuk", "375", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "5", liftnumber);
			}
			bool flag7 = 1.1 <= num && num <= 1.17;
			if (flag7)
			{
				this.xx.SetNumValue("BeyanYuk", "400", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "5", liftnumber);
			}
			bool flag8 = 1.17 <= num && num <= 1.3;
			if (flag8)
			{
				this.xx.SetNumValue("BeyanYuk", "450", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "6", liftnumber);
			}
			bool flag9 = 1.31 <= num && num <= 1.45;
			if (flag9)
			{
				this.xx.SetNumValue("BeyanYuk", "525", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "7", liftnumber);
			}
			bool flag10 = 1.45 <= num && num <= 1.6;
			if (flag10)
			{
				this.xx.SetNumValue("BeyanYuk", "600", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "8", liftnumber);
			}
			bool flag11 = 1.6 <= num && num <= 1.66;
			if (flag11)
			{
				this.xx.SetNumValue("BeyanYuk", "630", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "8", liftnumber);
			}
			bool flag12 = 1.59 <= num && num <= 1.75;
			if (flag12)
			{
				this.xx.SetNumValue("BeyanYuk", "675", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "9", liftnumber);
			}
			bool flag13 = 1.73 <= num && num <= 1.9;
			if (flag13)
			{
				this.xx.SetNumValue("BeyanYuk", "750", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "10", liftnumber);
			}
			bool flag14 = 1.9 <= num && num <= 2.0;
			if (flag14)
			{
				this.xx.SetNumValue("BeyanYuk", "800", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "10", liftnumber);
			}
			bool flag15 = 1.87 <= num && num <= 2.05;
			if (flag15)
			{
				this.xx.SetNumValue("BeyanYuk", "825", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "11", liftnumber);
			}
			bool flag16 = 2.01 <= num && num <= 2.2;
			if (flag16)
			{
				this.xx.SetNumValue("BeyanYuk", "900", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "12", liftnumber);
			}
			bool flag17 = 2.15 <= num && num <= 2.35;
			if (flag17)
			{
				this.xx.SetNumValue("BeyanYuk", " 975", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "13", liftnumber);
			}
			bool flag18 = 2.35 <= num && num <= 2.4;
			if (flag18)
			{
				this.xx.SetNumValue("BeyanYuk", "1000", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "13", liftnumber);
			}
			bool flag19 = 2.29 <= num && num <= 2.5;
			if (flag19)
			{
				this.xx.SetNumValue("BeyanYuk", "1050", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "14", liftnumber);
			}
			bool flag20 = 2.43 <= num && num <= 2.65;
			if (flag20)
			{
				this.xx.SetNumValue("BeyanYuk", "1125", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "15", liftnumber);
			}
			bool flag21 = 2.57 <= num && num <= 2.8;
			if (flag21)
			{
				this.xx.SetNumValue("BeyanYuk", "1200", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "16", liftnumber);
			}
			bool flag22 = 2.8 <= num && num <= 2.9;
			if (flag22)
			{
				this.xx.SetNumValue("BeyanYuk", "1250", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "16", liftnumber);
			}
			bool flag23 = 2.71 <= num && num <= 2.95;
			if (flag23)
			{
				this.xx.SetNumValue("BeyanYuk", "1275", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "17", liftnumber);
			}
			bool flag24 = 2.85 <= num && num <= 3.1;
			if (flag24)
			{
				this.xx.SetNumValue("BeyanYuk", "1350", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "18", liftnumber);
			}
			bool flag25 = 2.99 <= num && num <= 3.25;
			if (flag25)
			{
				this.xx.SetNumValue("BeyanYuk", "1425", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "19", liftnumber);
			}
			bool flag26 = 3.13 <= num && num <= 3.4;
			if (flag26)
			{
				this.xx.SetNumValue("BeyanYuk", "1500", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "20", liftnumber);
			}
			bool flag27 = 3.24 <= num && num <= 3.45;
			if (flag27)
			{
				this.xx.SetNumValue("BeyanYuk", "1575", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "21", liftnumber);
			}
			bool flag28 = 3.36 <= num && num <= 3.56;
			if (flag28)
			{
				this.xx.SetNumValue("BeyanYuk", "1600", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "22", liftnumber);
			}
			bool flag29 = 3.36 <= num && num <= 3.68;
			if (flag29)
			{
				this.xx.SetNumValue("BeyanYuk", "1650", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "22", liftnumber);
			}
			bool flag30 = 3.47 <= num && num <= 3.8;
			if (flag30)
			{
				this.xx.SetNumValue("BeyanYuk", "1725", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "23", liftnumber);
			}
			bool flag31 = 3.59 <= num && num <= 3.92;
			if (flag31)
			{
				this.xx.SetNumValue("BeyanYuk", "1800", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "24", liftnumber);
			}
			bool flag32 = 3.7 <= num && num <= 4.04;
			if (flag32)
			{
				this.xx.SetNumValue("BeyanYuk", "1875", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "25", liftnumber);
			}
			bool flag33 = 3.82 <= num && num <= 4.16;
			if (flag33)
			{
				this.xx.SetNumValue("BeyanYuk", "1950", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "26", liftnumber);
			}
			bool flag34 = 3.87 <= num && num <= 4.2;
			if (flag34)
			{
				this.xx.SetNumValue("BeyanYuk", "2000", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "26", liftnumber);
			}
			bool flag35 = 3.93 <= num && num <= 4.32;
			if (flag35)
			{
				this.xx.SetNumValue("BeyanYuk", "2025", liftnumber);
				this.xx.SetNumValue("BeyanKisi", "27", liftnumber);
			}
		}

		public void denemerep(ArrayList gelen, ArrayList donen, string hesaptip = "Hesap811-90")
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			Editor editor = mdiActiveDocument.get_Editor();
			string text = "";
			Point3d insertPoint = default(Point3d);
			using (Transaction tr = database.get_TransactionManager().StartTransaction())
			{
				Entity entity = ascad.FObject("Check", "1", "0");
				bool flag = entity != null;
				if (flag)
				{
					BlockReference blockReference = (BlockReference)tr.GetObject(entity.get_ObjectId(), 0);
					insertPoint = new Point3d(blockReference.get_Position().get_X(), -100.0, 0.0);
				}
				else
				{
					insertPoint = new Point3d(0.0, 0.0, 0.0);
				}
				BlockReference blockReference2 = this.InsertBlock(database, tr, insertPoint, hesaptip, 1.0, null, null, null);
				blockReference2.ExplodeToOwnerSpace();
				blockReference2.Erase();
				Func<ObjectId, DBText> <>9__1;
				for (int i = 0; i < gelen.Count; i++)
				{
					mdiActiveDocument.get_TransactionManager().EnableGraphicsFlush(true);
					BlockTable blockTable = (BlockTable)tr.GetObject(database.get_BlockTableId(), 0);
					blockTable.UpgradeOpen();
					string textPattern = gelen[i].ToString();
					BlockTableRecord blockTableRecord = (BlockTableRecord)tr.GetObject(blockTable.get_Item(BlockTableRecord.ModelSpace), 1);
					blockTableRecord.UpgradeOpen();
					IEnumerable<ObjectId> arg_1A8_0 = blockTableRecord.Cast<ObjectId>();
					Func<ObjectId, bool> arg_1A8_1;
					if ((arg_1A8_1 = ascad.<>c.<>9__163_0) == null)
					{
						arg_1A8_1 = (ascad.<>c.<>9__163_0 = new Func<ObjectId, bool>(ascad.<>c.<>9.<denemerep>b__163_0));
					}
					IEnumerable<ObjectId> arg_1D1_0 = arg_1A8_0.Where(arg_1A8_1);
					Func<ObjectId, DBText> arg_1D1_1;
					if ((arg_1D1_1 = <>9__1) == null)
					{
						arg_1D1_1 = (<>9__1 = ((ObjectId id) => (DBText)tr.GetObject(id, 0)));
					}
					List<DBText> list = (from txt in arg_1D1_0.Select(arg_1D1_1)
					where Regex.IsMatch(txt.get_TextString(), textPattern, RegexOptions.IgnoreCase)
					select txt).ToList<DBText>();
					int j = 0;
					while (j < list.Count)
					{
						try
						{
							BlockTableRecord blockTableRecord2 = tr.GetObject(list[j].get_ObjectId(), 1) as BlockTableRecord;
							text = list[j].get_TextString();
							string textString = text.Replace(gelen[i].ToString(), donen[i].ToString());
							bool flag2 = !list[j].get_ObjectId().get_ObjectClass().IsDerivedFrom(RXObject.GetClass(typeof(DBText)));
							if (!flag2)
							{
								DBObject @object = tr.GetObject(list[j].get_ObjectId(), 0);
								DBText dBText = @object as DBText;
								bool flag3 = dBText.get_TextString() != text;
								if (!flag3)
								{
									dBText.UpgradeOpen();
									dBText.set_TextString(textString);
								}
							}
						}
						catch (Exception ex)
						{
							Debug.WriteLine(ex.ToString() + "----> " + text);
						}
						IL_2F1:
						j++;
						continue;
						goto IL_2F1;
					}
				}
				tr.get_TransactionManager().QueueForGraphicsFlush();
				mdiActiveDocument.get_TransactionManager().FlushGraphics();
				editor.Regen();
				tr.Commit();
			}
		}

		[CommandMethod("OnsCaprazEkransec")]
		public static void SelectObjectsByCrossingWindow()
		{
			Document mdiActiveDocument = Application.get_DocumentManager().get_MdiActiveDocument();
			Database database = mdiActiveDocument.get_Database();
			using (Transaction transaction = database.get_TransactionManager().StartTransaction())
			{
				Editor editor = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor();
				PromptSelectionResult promptSelectionResult = editor.SelectCrossingWindow(new Point3d(-1000.0, -1000.0, 0.0), new Point3d(3000.0, 3000.0, 0.0));
				bool flag = promptSelectionResult.get_Status() == 5100;
				if (flag)
				{
					DBDictionary dBDictionary = (DBDictionary)transaction.GetObject(database.get_GroupDictionaryId(), 0);
					string text = "KKGROUP";
					try
					{
						SymbolUtilityServices.ValidateSymbolName(text, false);
						bool flag2 = dBDictionary.Contains(text);
						if (flag2)
						{
							text += "uu";
						}
						else
						{
							text = text;
						}
					}
					catch
					{
						editor.WriteMessage("\nInvalid group name.");
					}
					Group group = new Group("Test group", true);
					dBDictionary.UpgradeOpen();
					ObjectId objectId = dBDictionary.SetAt(text, group);
					transaction.AddNewlyCreatedDBObject(group, true);
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.get_BlockTableId(), 0);
					ObjectIdCollection objectIdCollection = new ObjectIdCollection();
					SelectionSet value = promptSelectionResult.get_Value();
					foreach (SelectedObject selectedObject in value)
					{
						bool flag3 = selectedObject != null;
						if (flag3)
						{
							objectIdCollection.Add(selectedObject.get_ObjectId());
						}
					}
					editor.WriteMessage("obje sayısı" + value.get_Count());
					group.Append(objectIdCollection);
				}
				transaction.Commit();
			}
		}
	}
}
