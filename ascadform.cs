using ascad.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTab;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace ascad
{
	public class ascadform : Form
	{
		private abc1 xx = new abc1();

		public myData FormMyData;

		public int AsansorSayisi = 1;

		public string AsansorTipi = "EA";

		private DataTable katlar = new DataTable();

		private string FormOTOKapiTip = "";

		private string katyukdiyezlist = "";

		private string katrumuzlist = "";

		private srthepler shelper = new srthepler();

		private IContainer components = null;

		private RadioButton maksizlkarkas;

		private RadioButton maksiz1_2alttan;

		private RadioButton makli1_1;

		private RadioButton makli1_2;

		private RadioButton agrarka;

		private RadioButton agrsol;

		private RadioButton agrsag;

		private TableLayoutPanel tableLayoutPanel1;

		private RadioButton mdduz;

		private GroupControl groupControl3;

		private TextEdit SapCap;

		private TextEdit TahCap;

		private LabelControl labelControl10;

		private LabelControl labelControl9;

		private TextEdit KuyuDer;

		private TextEdit KuyuGen;

		private GroupControl groupControl6;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControl layoutControl2;

		private LayoutControlGroup layoutControlGroup2;

		private LayoutControlItem layoutControlItem11;

		private LayoutControlItem layoutControlItem22;

		private LabelControl labelControl4;

		private LabelControl labelControl13;

		private LayoutControlItem layoutControlItem27;

		private LayoutControlItem layoutControlItem28;

		private TableLayoutPanel tableLayoutPanel5;

		private RadioButton ha11;

		private RadioButton ha21;

		private Panel panel2;

		private Panel panel1;

		private GroupControl groupControl1;

		private RadioButton dokumagr;

		private RadioButton baritagr;

		private LayoutControl layoutControl5;

		private LayoutControlGroup layoutControlGroup5;

		private LayoutControlItem layoutControlItem45;

		private LayoutControlItem layoutControlItem46;

		private BackgroundWorker backgroundWorker1;

		private TextEdit txtHAMDDer;

		private TextEdit txtHAMDGen;

		private RadioButton radioHMSOL;

		private RadioButton radioHMSAG;

		private GroupControl HAMDControl;

		private LayoutControl layoutControl8;

		private LayoutControlGroup layoutControlGroup8;

		private LayoutControlItem layoutControlItem62;

		private LayoutControlItem layoutControlItem64;

		private LayoutControlItem layoutControlItem65;

		private LayoutControlItem layoutControlItem66;

		private LayoutControl layoutControl4;

		private SimpleButton simpleButton4;

		private SimpleButton simpleButton3;

		private GridControl gridControl1;

		private GridView gridView4;

		private GridColumn gridColumn10;

		private GridColumn gridColumn11;

		private GridColumn gridColumn12;

		private GridColumn gridColumn13;

		private SimpleButton simpleButton2;

		private SimpleButton simpleButton1;

		private TextEdit MdTabTavan;

		private TextEdit SonKat;

		private TextEdit AraKatSTR;

		private TextEdit TopKuyuKafa;

		private TextEdit KuyuDibi;

		private TextEdit DurakSayi;

		private TextEdit KatH;

		private TextEdit IlkDurakNo;

		private LayoutControlGroup layoutControlGroup4;

		private LayoutControlItem layoutControlItem36;

		private LayoutControlItem layoutControlItem37;

		private LayoutControlItem layoutControlItem38;

		private LayoutControlItem layoutControlItem42;

		private LayoutControlItem layoutControlItem43;

		private LayoutControlItem layoutControlItem44;

		private LayoutControlItem layoutControlItem68;

		private LayoutControl layoutControl9;

		private LayoutControlGroup layoutControlGroup9;

		private CheckBox sankod;

		private CheckBox panaromik;

		private PictureBox pictureBox2;

		private LayoutControlItem layoutControlItem82;

		private ComboBoxEdit KabinRayStr;

		private LayoutControlItem layoutControlItem111;

		private ComboBoxEdit AgrRayStr;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private LayoutControlItem layoutControlItem114;

		private LayoutControlItem layoutControlItem113;

		private LayoutControlItem layoutControlItem115;

		private TextEdit SeyirMesafesi;

		private LayoutControlItem layoutControlItem125;

		private TextEdit ToplamYuk;

		private CheckEdit DengeZinciri;

		private LayoutControlItem layoutControlItem40;

		private CheckEdit IskeleVar;

		private LayoutControlItem layoutControlItem41;

		private CheckEdit BesPanoVar;

		private CheckEdit AydinlatmaBizde;

		private VGridControl firmabilgigrid;

		private EditorRow row;

		private EditorRow row1;

		private EditorRow row2;

		private MultiEditorRow row4;

		private MultiEditorRowProperties multiEditorRowProperties5;

		private MultiEditorRowProperties multiEditorRowProperties6;

		private MultiEditorRow row3;

		private MultiEditorRowProperties multiEditorRowProperties1;

		private MultiEditorRowProperties multiEditorRowProperties2;

		private MultiEditorRowProperties multiEditorRowProperties3;

		private MultiEditorRowProperties multiEditorRowProperties4;

		private MultiEditorRow row5;

		private MultiEditorRowProperties multiEditorRowProperties7;

		private MultiEditorRowProperties multiEditorRowProperties8;

		private MultiEditorRow row8;

		private MultiEditorRowProperties multiEditorRowProperties9;

		private MultiEditorRowProperties multiEditorRowProperties10;

		private MultiEditorRow row6;

		private MultiEditorRowProperties multiEditorRowProperties11;

		private MultiEditorRowProperties multiEditorRowProperties12;

		private CategoryRow category;

		private EditorRow row7;

		private EditorRow row9;

		private EditorRow row10;

		private EditorRow row11;

		private CategoryRow category1;

		private EditorRow row12;

		private EditorRow row13;

		private EditorRow row14;

		private EditorRow row15;

		private ImageComboBoxEdit otokapitipi;

		private ImageComboBoxEdit asnkapitipi;

		private LayoutControlItem layoutControlItem4;

		private LayoutControlItem layoutControlItem3;

		private ImageList ımageList1;

		private TextEdit KapiGen;

		private LayoutControlItem layoutControlItem8;

		private ImageComboBoxEdit Mentese;

		private LayoutControlItem layoutControlItem9;

		private TableLayoutPanel tableLayoutPanel2;

		private LayoutControlItem layoutControlItem5;

		private XtraTabControl xtraTabControl1;

		private XtraTabPage xtraTabPage1;

		private XtraTabPage xtraTabPage2;

		private XtraTabPage xtraTabPage3;

		private XtraTabPage xtraTabPage4;

		private GroupControl groupControl2;

		private LabelControl labelControl1;

		private LayoutControlItem layoutControlItem6;

		private ImageComboBoxEdit RegYer;

		private LayoutControlItem layoutControlItem7;

		private LabelControl labelControl2;

		private CheckEdit checkEdit1;

		private TextEdit textEdit2;

		private LayoutControlItem layoutControlItem12;

		private LayoutControlItem layoutControlItem13;

		private LabelControl labelControl3;

		private LayoutControlItem layoutControlItem14;

		private GridControl ayargrid;

		private GridView gridView1;

		private GridColumn gridColumn79;

		private GridColumn gridColumn80;

		private GridColumn gridColumn81;

		private ImageList ımageList2;

		private ImageComboBoxEdit AgrTamponu;

		private ImageComboBoxEdit KabinTamponu;

		private LayoutControlItem layoutControlItem10;

		private LayoutControlItem layoutControlItem15;

		private LayoutControlItem layoutControlItem16;

		private LayoutControlItem layoutControlItem17;

		private LayoutControlItem layoutControlItem18;

		private LayoutControlItem layoutControlItem19;

		private LayoutControlItem layoutControlItem20;

		private LayoutControlItem layoutControlItem21;

		private LayoutControlItem layoutControlItem23;

		public ascadform()
		{
			this.InitializeComponent();
		}

		private void tipayarla()
		{
			bool flag = this.AsansorTipi == "HA";
			if (flag)
			{
				this.panel1.Visible = false;
				this.panel2.Location = this.panel1.Location;
				this.panel2.Size = this.panel1.Size;
				this.panel2.Visible = true;
				this.ha11.Visible = true;
				this.ha11.Checked = true;
				this.HAMDControl.Visible = true;
				this.radioHMSAG.Checked = true;
			}
			else
			{
				this.panel1.Visible = true;
				this.panel2.Visible = false;
				this.ha11.Checked = false;
				this.ha21.Checked = false;
				this.HAMDControl.Visible = false;
			}
			bool flag2 = this.AsansorTipi != "HA";
			if (flag2)
			{
				string tahrikKodu = this.FormMyData.TahrikKodu;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(tahrikKodu);
				if (num <= 936277782u)
				{
					if (num <= 362359204u)
					{
						if (num != 312014793u)
						{
							if (num == 362359204u)
							{
								if (tahrikKodu == "MDCAP")
								{
									this.maksiz1_2alttan.Checked = true;
								}
							}
						}
						else if (tahrikKodu == "HA1")
						{
							this.ha11.Checked = true;
						}
					}
					else if (num != 710960200u)
					{
						if (num == 936277782u)
						{
							if (tahrikKodu == "DA")
							{
								this.makli1_1.Checked = true;
							}
						}
					}
					else if (tahrikKodu == "MDL")
					{
						this.makli1_2.Checked = true;
					}
				}
				else if (num <= 1462804799u)
				{
					if (num != 1007772495u)
					{
						if (num == 1462804799u)
						{
							if (tahrikKodu == "MDDUZ")
							{
								this.mdduz.Checked = true;
							}
						}
					}
					else if (tahrikKodu == "YA")
					{
						this.makli1_2.Checked = true;
					}
				}
				else if (num != 1526892946u)
				{
					if (num == 2146134658u)
					{
						if (tahrikKodu == "HA")
						{
							this.ha21.Checked = true;
						}
					}
				}
				else if (tahrikKodu == "SD")
				{
					this.sankod.Checked = true;
				}
			}
			else
			{
				string tahrikKodu2 = this.FormMyData.TahrikKodu;
				if (!(tahrikKodu2 == "DA"))
				{
					if (tahrikKodu2 == "HY")
					{
						this.ha21.Checked = true;
					}
				}
				else
				{
					this.ha11.Checked = true;
				}
			}
			string yonKodu = this.FormMyData.YonKodu;
			if (!(yonKodu == "SAG"))
			{
				if (!(yonKodu == "SOL"))
				{
					if (yonKodu == "ARKA")
					{
						this.agrarka.Checked = true;
					}
				}
				else
				{
					this.agrsol.Checked = true;
				}
			}
			else
			{
				this.agrsag.Checked = true;
			}
			bool flag3 = this.FormMyData.AgrGir == "0";
			if (flag3)
			{
				this.dokumagr.Checked = true;
			}
			else
			{
				this.baritagr.Checked = true;
			}
		}

		private string donennumdeger(DataTable gelendata, string paramname)
		{
			string text = "0";
			string result;
			for (int i = 0; i < gelendata.Rows.Count; i++)
			{
				bool flag = gelendata.Rows[i]["ParamName"].ToString() == paramname;
				if (flag)
				{
					text = gelendata.Rows[i]["ParamValue"].ToString();
					result = text;
					return result;
				}
			}
			result = text;
			return result;
		}

		private void datalarload()
		{
			DataTable dataTable = this.xx.dtta("select distinct(model) from raymaster order by sno", "");
			DataTable dataTable2 = this.xx.dtta("select ParamName,ParamValue from Num" + this.AsansorSayisi, "");
			int count = dataTable2.Rows.Count;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.KabinRayStr.get_Properties().get_Items().Add(dataTable.Rows[i][0].ToString());
				this.AgrRayStr.get_Properties().get_Items().Add(dataTable.Rows[i][0].ToString());
			}
			this.KuyuGen.Text = this.donennumdeger(dataTable2, "KuyuGen");
			this.KuyuDer.Text = this.donennumdeger(dataTable2, "KuyuDer");
			this.KabinRayStr.Text = this.donennumdeger(dataTable2, "KabinRayStr");
			this.AgrRayStr.Text = this.donennumdeger(dataTable2, "AgrRayStr");
			this.asnkapitipi.set_EditValue(this.donennumdeger(dataTable2, "KapiTip").ToString().Substring(0, 2));
			this.otokapitipi.set_EditValue(this.donennumdeger(dataTable2, "KapiTip").ToString().Substring(3));
			this.Mentese.set_EditValue(this.donennumdeger(dataTable2, "Mentese").ToString());
			this.TahCap.Text = this.donennumdeger(dataTable2, "TahCap");
			this.SapCap.Text = this.donennumdeger(dataTable2, "SapCap");
			this.RegYer.set_EditValue(this.donennumdeger(dataTable2, "RegYer"));
			this.KabinTamponu.set_EditValue(this.donennumdeger(dataTable2, "KabinTamponu"));
			this.AgrTamponu.set_EditValue(this.donennumdeger(dataTable2, "AgrTamponu"));
			this.panaromik.Checked = Convert.ToBoolean(Convert.ToInt32(this.donennumdeger(dataTable2, "Pan")));
			this.sankod.Checked = Convert.ToBoolean(Convert.ToInt32(this.donennumdeger(dataTable2, "SD")));
			this.DurakSayi.Text = this.donennumdeger(dataTable2, "DurakSayi");
			this.IlkDurakNo.Text = this.donennumdeger(dataTable2, "IlkDurakNo");
			foreach (Control control in this.layoutControl4.Controls)
			{
				bool flag = !string.IsNullOrEmpty(control.Name);
				if (flag)
				{
					try
					{
						int num = 0;
						do
						{
							bool flag2 = control.GetType().ToString() != "DevExpress.XtraEditors.LabelControl" || control.GetType().ToString() != "DevExpress.XtraEditors.GroupControl" || control.GetType().ToString() != "DevExpress.XtraEditors.SimpleButton" || control.GetType().ToString() != "System.Windows.Forms.RadioButton";
							if (flag2)
							{
								num++;
							}
						}
						while (!string.Equals(dataTable2.Rows[num]["ParamName"].ToString(), control.Name) && num < count);
						bool flag3 = control.Name == "DengeZinciri";
						if (flag3)
						{
							this.DengeZinciri.set_EditValue(Convert.ToBoolean(Convert.ToInt32(dataTable2.Rows[num]["ParamValue"].ToString())));
						}
						else
						{
							bool flag4 = control.Name == "IskeleVar";
							if (flag4)
							{
								this.IskeleVar.set_EditValue(Convert.ToBoolean(Convert.ToInt32(dataTable2.Rows[num]["ParamValue"].ToString())));
							}
							else
							{
								control.Text = dataTable2.Rows[num]["ParamValue"].ToString();
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			this.tipayarla();
			bool flag5 = this.mdduz.Checked || this.maksiz1_2alttan.Checked || this.maksizlkarkas.Checked;
			if (flag5)
			{
				this.TahCap.Text = this.FormMyData.MDTahrikKas;
				this.SapCap.Text = this.FormMyData.MDSapKas;
			}
			else
			{
				this.TahCap.Text = this.FormMyData.TahrikKas;
				this.SapCap.Text = this.FormMyData.SapKas;
			}
		}

		private void ascadform_Load(object sender, EventArgs e)
		{
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			bool flag = this.katlar.Columns.Count == 0;
			if (flag)
			{
				this.katlar.Columns.Add("ktno", typeof(string));
				this.katlar.Columns.Add("krumz", typeof(string));
				this.katlar.Columns.Add("kath", typeof(int));
				this.katlar.Columns.Add("mimkot", typeof(string));
			}
			this.datalarload();
			bool flag2 = this.AsansorTipi == "HA";
			if (flag2)
			{
				this.panel1.Visible = false;
				this.panel2.Location = this.panel1.Location;
				this.panel2.Size = this.panel1.Size;
				this.panel2.Visible = true;
				this.ha21.Checked = true;
			}
			else
			{
				this.ha11.Checked = false;
				this.ha21.Checked = false;
			}
			this.gridControl1.set_DataSource(this.katlar);
			this.backgroundWorker1.RunWorkerAsync();
			this.katnolar();
			this.ayargrid.set_DataSource(this.xx.dtta("select * from Num" + this.AsansorSayisi + " where Comment='FRM1'", ""));
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = this.makli1_1.Checked && this.AsansorTipi == "EA";
			if (flag)
			{
				this.FormMyData.TipKodu = "EA";
				this.FormMyData.TahrikKodu = "DA";
				this.ha11.Checked = false;
				this.ha21.Checked = false;
			}
			bool flag2 = this.mdduz.Checked && this.AsansorTipi == "EA";
			if (flag2)
			{
				this.FormMyData.TipKodu = "EA";
				this.FormMyData.TahrikKodu = "MDDUZ";
				this.ha11.Checked = false;
				this.ha21.Checked = false;
			}
			bool flag3 = this.maksiz1_2alttan.Checked && this.AsansorTipi == "EA";
			if (flag3)
			{
				this.FormMyData.TipKodu = "EA";
				this.FormMyData.TahrikKodu = "MDCAP";
				this.ha11.Checked = false;
				this.ha21.Checked = false;
			}
			bool flag4 = this.makli1_2.Checked && this.AsansorTipi == "EA";
			if (flag4)
			{
				this.FormMyData.TipKodu = "EA";
				this.FormMyData.TahrikKodu = "YA";
				this.ha11.Checked = false;
				this.ha21.Checked = false;
			}
			bool flag5 = this.ha11.Checked && this.AsansorTipi == "HA";
			if (flag5)
			{
				this.FormMyData.TipKodu = "HA";
				this.FormMyData.TahrikKodu = "DA";
			}
			bool flag6 = this.ha21.Checked && this.AsansorTipi == "HA";
			if (flag6)
			{
				this.FormMyData.TipKodu = "HA";
				this.FormMyData.TahrikKodu = "HY";
			}
		}

		private void txtKontrols(TextEdit gt, string defauldeger, int buyukolmaz, int kucukolmaz)
		{
			bool flag = string.IsNullOrEmpty(gt.Text) || string.IsNullOrEmpty(gt.get_EditValue().ToString());
			if (flag)
			{
				MessageBox.Show(gt.Name + " değerini boş gönderiyorsunuz Varsayılan değere alındı :" + defauldeger);
				gt.set_EditValue(defauldeger);
			}
			bool flag2 = Convert.ToInt32(gt.get_EditValue().ToString()) > buyukolmaz;
			if (flag2)
			{
				MessageBox.Show(string.Concat(new object[]
				{
					gt.Name,
					" değeri ",
					buyukolmaz,
					" büyük olamaz Varsayılan değere alındı :",
					defauldeger
				}));
				gt.set_EditValue(defauldeger);
			}
			bool flag3 = Convert.ToInt32(gt.get_EditValue().ToString()) < kucukolmaz;
			if (flag3)
			{
				MessageBox.Show(string.Concat(new object[]
				{
					gt.Name,
					" değeri ",
					kucukolmaz,
					" küçük olamaz Varsayılan değere alındı :",
					defauldeger
				}));
				gt.set_EditValue(defauldeger);
			}
		}

		private void ascadform_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.txtKontrols(this.KuyuGen, "2000", 5000, 1000);
			this.txtKontrols(this.KuyuGen, "2000", 5000, 1000);
			this.txtKontrols(this.KapiGen, "900", 2600, 400);
			this.FormMyData.KuyuDer = this.KuyuDer.Text;
			this.FormMyData.KuyuGen = this.KuyuGen.Text;
			this.FormMyData.KapiGen = this.KapiGen.Text;
			this.FormMyData.KapiTip = this.asnkapitipi.get_EditValue().ToString() + "-" + this.otokapitipi.get_EditValue().ToString();
			this.FormMyData.Mentese = this.Mentese.get_EditValue().ToString();
			bool flag = this.AsansorTipi == "HA";
			if (flag)
			{
				this.HAMDSet();
				this.FormMyData.HAMDGen = this.txtHAMDGen.Text;
				this.FormMyData.HAMDDer = this.txtHAMDDer.Text;
			}
			else
			{
				string[] array = this.KabinTamponu.get_EditValue().ToString().Split(new char[]
				{
					'#'
				});
				this.xx.oleupdate("update BLK set BlkInsName='" + array[0] + "' where id=70", "");
				this.xx.oleupdate("update BLK set BlkInsName='" + array[1] + "' where id=73", "");
				this.xx.oleupdate("update BLK set BlkInsName='" + array[2] + "' where id=75", "");
				string[] array2 = this.AgrTamponu.get_EditValue().ToString().Split(new char[]
				{
					'#'
				});
				bool flag2 = this.FormMyData.YonKodu != "ARKA";
				if (flag2)
				{
					bool flag3 = array2[0] == "YTampon1" || array2[0] == "YTampon2" || array2[0] == "HTampon";
					if (flag3)
					{
						array2[0] = array2[0] + "-90";
					}
				}
				this.xx.oleupdate("update BLK set BlkInsName='" + array2[0] + "' where id=71", "");
				this.xx.oleupdate("update BLK set BlkInsName='" + array2[1] + "' where id=72", "");
				this.xx.oleupdate("update BLK set BlkInsName='" + array2[2] + "' where id=74", "");
			}
			this.xx.SetNumValue("RegYer", this.RegYer.get_EditValue().ToString(), this.AsansorSayisi.ToString());
			this.xx.SetNumValue("KabinRayStr", this.KabinRayStr.Text, this.AsansorSayisi.ToString());
			this.xx.SetNumValue("AgrRayStr", this.AgrRayStr.Text, this.AsansorSayisi.ToString());
			char[] array3 = this.KabinRayStr.Text.ToCharArray();
			int num = 0;
			string text = "";
			string text2 = "";
			string text3 = "";
			char[] array4 = this.AgrRayStr.Text.ToCharArray();
			int num2 = 0;
			string text4 = "";
			string text5 = "";
			string text6 = "";
			do
			{
				text += array3[num].ToString();
				num++;
			}
			while (char.IsDigit(array3[num]));
			num++;
			this.FormMyData.KRX = text;
			do
			{
				text2 += array3[num].ToString();
				num++;
			}
			while (char.IsDigit(array3[num]));
			this.FormMyData.KRY = text2;
			num++;
			do
			{
				text3 += array3[num].ToString();
				num++;
			}
			while (char.IsDigit(array3[num]));
			this.FormMyData.KRZ = text3;
			do
			{
				text4 += array4[num2].ToString();
				num2++;
			}
			while (char.IsDigit(array4[num2]));
			num2++;
			this.FormMyData.ARX = text4;
			do
			{
				text5 += array4[num2].ToString();
				num2++;
			}
			while (char.IsDigit(array4[num2]));
			this.FormMyData.ARY = text5;
			num2++;
			do
			{
				text6 += array4[num2].ToString();
				num2++;
			}
			while (char.IsDigit(array4[num2]));
			this.FormMyData.ARZ = text6;
			this.FormMyData.DurakSayi = this.DurakSayi.Text;
			this.FormMyData.KuyuKafa = this.gridView4.GetRowCellValue(this.gridView4.get_RowCount() - 1, "kath").ToString();
			this.FormMyData.KatRumuz = this.katrumuzlist.Substring(0, this.katrumuzlist.Length - 1);
			this.FormMyData.KatYukListe = this.katyukdiyezlist.Substring(0, this.katyukdiyezlist.Length - 1);
			this.FormMyData.AraKatSTR = this.AraKatSTR.Text;
			this.FormMyData.IlkDurakKot = this.gridView4.GetRowCellValue(1, "mimkot").ToString();
			this.FormMyData.SonDurakKot = this.gridView4.GetRowCellValue(this.gridView4.get_RowCount() - 2, "mimkot").ToString();
			this.FormMyData.KuyuDibi = this.KuyuDibi.Text;
			this.FormMyData.IlkKat = this.gridView4.GetRowCellValue(1, "kath").ToString();
			this.FormMyData.SonKat = this.gridView4.GetRowCellValue(this.gridView4.get_RowCount() - 2, "kath").ToString();
			this.FormMyData.MDaireH = this.gridView4.GetRowCellValue(this.gridView4.get_RowCount() - 1, "kath").ToString();
			this.FormMyData.CalisYuksek = this.MdTabTavan.Text;
			this.FormMyData.KabinRayStr = this.KabinRayStr.Text;
			this.FormMyData.AgrRayStr = this.AgrRayStr.Text;
			this.FormMyData.MDTahrikKas = this.TahCap.Text;
			this.FormMyData.MDSapKas = this.SapCap.Text;
			this.FormMyData.TahrikKas = this.TahCap.Text;
			this.FormMyData.SapKas = this.SapCap.Text;
			this.xx.SetNumValue("MDTahrikKas", this.TahCap.Text, this.AsansorSayisi.ToString());
			this.xx.SetNumValue("MDSapKas", this.SapCap.Text, this.AsansorSayisi.ToString());
			this.xx.SetNumValue("TahrikKas", this.TahCap.Text, this.AsansorSayisi.ToString());
			this.xx.SetNumValue("SapKas", this.SapCap.Text, this.AsansorSayisi.ToString());
			bool @checked = this.panaromik.Checked;
			if (@checked)
			{
				this.FormMyData.Pan = "1";
			}
			else
			{
				this.FormMyData.Pan = "0";
			}
			bool checked2 = this.sankod.Checked;
			if (checked2)
			{
				this.xx.SetNumValue("TahrikKodu", "SD", "1");
			}
			else
			{
				this.xx.SetNumValue("TahrikKodu", "SD", "0");
			}
			this.FormMyData.MdTabTavan = this.MdTabTavan.Text;
			this.xx.SetNumValue("RegYer", this.RegYer.get_EditValue().ToString(), this.AsansorSayisi.ToString());
			bool checked3 = this.agrarka.Checked;
			if (checked3)
			{
				this.FormMyData.YonKodu = "ARKA";
			}
			else
			{
				bool checked4 = this.agrsag.Checked;
				if (checked4)
				{
					this.FormMyData.YonKodu = "SAG";
				}
				else
				{
					bool checked5 = this.agrsol.Checked;
					if (checked5)
					{
						this.FormMyData.YonKodu = "SOL";
					}
					else
					{
						this.FormMyData.YonKodu = "SOL";
					}
				}
			}
			this.xx.SetNumValue("KabinTamponu", this.KabinTamponu.get_EditValue().ToString(), this.AsansorSayisi.ToString());
			this.xx.SetNumValue("AgrTamponu", this.AgrTamponu.get_EditValue().ToString(), this.AsansorSayisi.ToString());
			bool flag4 = this.FormMyData.TipKodu == "MDDUZ";
			if (flag4)
			{
				this.FormMyData.KabinRayFark = "250";
			}
			else
			{
				this.FormMyData.KabinRayFark = "100";
			}
		}

		private void gridkatHhesapla()
		{
			int num = 0;
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			bool flag = Convert.ToInt32(this.IlkDurakNo.Text) < 0;
			if (flag)
			{
				for (int i = 1; i < this.katlar.Rows.Count - 1; i++)
				{
					bool flag2 = Convert.ToInt32(this.katlar.Rows[i]["ktno"].ToString()) < 0;
					if (flag2)
					{
						num2 -= Convert.ToInt32(this.gridView4.GetRowCellValue(i, "kath").ToString());
						arrayList.Add(num2);
					}
				}
				arrayList.Reverse();
				for (int j = 0; j < arrayList.Count; j++)
				{
					this.katlar.Rows[j + 1]["mimkot"] = arrayList[j];
				}
				this.katlar.Rows[0]["mimkot"] = num2 - Convert.ToInt32(this.KuyuDibi.Text);
				for (int k = 1; k < this.katlar.Rows.Count; k++)
				{
					try
					{
						bool flag3 = k == this.katlar.Rows.Count - 1;
						if (flag3)
						{
							num = num + Convert.ToInt32(this.katlar.Rows[k - 1]["kath"]) + Convert.ToInt32(this.katlar.Rows[k]["kath"]);
							this.katlar.Rows[k]["mimkot"] = num;
						}
						else
						{
							bool flag4 = Convert.ToInt32(this.katlar.Rows[k]["ktno"].ToString()) == 0;
							if (flag4)
							{
								this.katlar.Rows[k]["mimkot"] = 0;
							}
							else
							{
								bool flag5 = Convert.ToInt32(this.katlar.Rows[k]["ktno"].ToString()) > 0 && k < this.katlar.Rows.Count - 1;
								if (flag5)
								{
									num += Convert.ToInt32(this.katlar.Rows[k - 1]["kath"].ToString());
									this.katlar.Rows[k]["mimkot"] = num;
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			else
			{
				this.katlar.Rows[0]["mimkot"] = Convert.ToInt32(this.FormMyData.KuyuDibi) * -1;
				for (int l = 1; l < this.katlar.Rows.Count; l++)
				{
					bool flag6 = l == 1;
					if (flag6)
					{
						this.katlar.Rows[l]["mimkot"] = 0;
					}
					else
					{
						bool flag7 = l == this.katlar.Rows.Count - 1;
						if (flag7)
						{
							num = num + Convert.ToInt32(this.katlar.Rows[l - 1]["kath"]) + Convert.ToInt32(this.katlar.Rows[l]["kath"]);
							this.katlar.Rows[l]["mimkot"] = num;
						}
						else
						{
							num += Convert.ToInt32(this.katlar.Rows[l - 1]["kath"]);
							this.katlar.Rows[l]["mimkot"] = num;
						}
					}
				}
			}
			this.gridControl1.set_DataSource(this.katlar);
			this.katlarclosing();
		}

		private void grhes2()
		{
			int num = 0;
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			bool flag = Convert.ToInt32(this.IlkDurakNo.Text) < 0;
			if (flag)
			{
				for (int i = 1; i < this.katlar.Rows.Count - 1; i++)
				{
					bool flag2 = Convert.ToInt32(this.gridView4.GetRowCellValue(i, "ktno").ToString()) < 0;
					if (flag2)
					{
						num2 -= Convert.ToInt32(this.gridView4.GetRowCellValue(i, "kath").ToString());
						arrayList.Add(num2);
					}
				}
				arrayList.Reverse();
				for (int j = 0; j < arrayList.Count; j++)
				{
					this.gridView4.SetRowCellValue(j + 1, "mimkot", arrayList[j]);
				}
				this.gridView4.SetRowCellValue(0, "mimkot", num2 - Convert.ToInt32(this.KuyuDibi.Text));
				for (int k = 1; k < this.katlar.Rows.Count; k++)
				{
					try
					{
						bool flag3 = Convert.ToInt32(this.gridView4.GetRowCellValue(k, "ktno").ToString()) == 0;
						if (flag3)
						{
							this.gridView4.SetRowCellValue(k, "mimkot", 0);
						}
						else
						{
							bool flag4 = Convert.ToInt32(this.gridView4.GetRowCellValue(k, "ktno").ToString()) > 0;
							if (flag4)
							{
								num += Convert.ToInt32(this.gridView4.GetRowCellValue(k, "kath").ToString());
								this.gridView4.SetRowCellValue(k, "mimkot", num);
							}
						}
					}
					catch (Exception)
					{
						num += Convert.ToInt32(this.gridView4.GetRowCellValue(k, "kath").ToString());
						this.gridView4.SetRowCellValue(k, "mimkot", num);
					}
				}
			}
			else
			{
				this.gridView4.SetRowCellValue(0, "mimkot", "-" + this.FormMyData.KuyuDibi);
				for (int l = 1; l < this.katlar.Rows.Count; l++)
				{
					bool flag5 = l == 1;
					if (flag5)
					{
						this.gridView4.SetRowCellValue(l, "mimkot", 0);
					}
					else
					{
						num += Convert.ToInt32(this.gridView4.GetRowCellValue(l - 1, "kath").ToString());
						this.gridView4.SetRowCellValue(l, "mimkot", num);
					}
				}
			}
		}

		private void katlarclosing()
		{
			this.katyukdiyezlist = "";
			this.katrumuzlist = "";
			int num = 0;
			for (int i = 1; i < this.gridView4.get_RowCount(); i++)
			{
				num += Convert.ToInt32(this.gridView4.GetRowCellValue(i, "kath").ToString());
				bool flag = i == this.gridView4.get_RowCount() - 1;
				if (!flag)
				{
					this.katyukdiyezlist = this.katyukdiyezlist + this.gridView4.GetRowCellValue(i, "kath").ToString() + "#";
				}
				bool flag2 = i < this.gridView4.get_RowCount() - 1;
				if (flag2)
				{
					bool flag3 = string.IsNullOrEmpty(this.gridView4.GetRowCellValue(i, "krumz").ToString());
					if (flag3)
					{
						this.katrumuzlist = this.katrumuzlist + this.gridView4.GetRowCellValue(i, "ktno").ToString() + "#";
					}
					else
					{
						this.katrumuzlist = string.Concat(new string[]
						{
							this.katrumuzlist,
							this.gridView4.GetRowCellValue(i, "ktno").ToString(),
							"(",
							this.gridView4.GetRowCellValue(i, "krumz").ToString(),
							")#"
						});
					}
				}
			}
			this.ToplamYuk.Text = (num + Convert.ToInt32(this.KuyuDibi.Text)).ToString();
			int num2 = 0;
			for (int j = 1; j < this.gridView4.get_RowCount() - 2; j++)
			{
				num2 += Convert.ToInt32(this.gridView4.GetRowCellValue(j, "kath").ToString());
			}
			this.SeyirMesafesi.Text = num2.ToString();
			string text = "";
			string[] array = this.katrumuzlist.Substring(0, this.katrumuzlist.Length - 1).Split(new char[]
			{
				'#'
			});
			for (int k = 1; k < array.Length - 1; k++)
			{
				text = text + array[k] + ".";
			}
			text += " KATLAR";
			this.AraKatSTR.Text = text;
		}

		private void baritagr_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.baritagr.Checked;
			if (@checked)
			{
				this.FormMyData.AgrGir = "60";
			}
			else
			{
				this.FormMyData.AgrGir = "0";
			}
		}

		private void AgrUZ_EditValueChanged(object sender, EventArgs e)
		{
		}

		private void AgrGen_EditValueChanged(object sender, EventArgs e)
		{
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			this.xx.oleupdate("Create schema IF NOT EXISTS ascad;Create schema IF NOT EXISTS stats;CREATE TABLE IF NOT EXISTS stats.firmabilgi(`id` int(11) NOT NULL auto_increment,  `ad` varchar(255) default NULL,  `adres` varchar(255) default NULL,  `tel` varchar(255) default NULL,  `fax` varchar(255) default NULL,  `mail` varchar(255) default NULL,  `yetkili` varchar(255) default NULL,  `marka` varchar(255) default NULL,  `onkurulusad` varchar(255) default NULL,  `onkurulusno` varchar(255) default NULL,  `santar` varchar(255) default NULL,  `sanno` varchar(255) default NULL,  `hybtar` varchar(255) default NULL,  `hybno` varchar(255) default NULL,  `mmad` varchar(255) default NULL,  `mmoda` varchar(255) default NULL,  `mmbel` varchar(255) default NULL,  `mmsmm` varchar(255) default NULL,  `emad` varchar(255) default NULL,  `emoda` varchar(255) default NULL,  `embel` varchar(255) default NULL,  `emsmm` varchar(255) default NULL,  `dil` varchar(255) default NULL,`VergiDair` varchar(255) default NULL  ,`VergiNo` varchar(255) default NULL , PRIMARY KEY(`id`)) ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;", "");
			bool flag = this.xx.dtta("select * from stats.firmabilgi where ID=1", "").Rows.Count == 0;
			if (flag)
			{
				this.xx.oleupdate("insert into stats.firmabilgi(ad,adres,tel,fax,mail,marka,VergiDair,VergiNo) values(' ',' ',' ',' ',' ',' ',' ',' ')", "");
			}
			this.firmabilgigrid.set_DataSource(this.xx.dtta("select * from stats.firmabilgi where id=1", ""));
			bool flag2 = this.shelper.intirnetvarmi();
			if (flag2)
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				DataTable dataTable = this.shelper.scrdtta("select versiyonno from ascadwhtisnew order by versiyonno desc limit 1", "");
				try
				{
					int num = Convert.ToInt32(dataTable.Rows[0][0]);
					FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(directoryName + "\\ascad.dll");
					char[] array = versionInfo.FileVersion.ToCharArray();
					int num2 = Convert.ToInt32(Convert.ToString(array[6].ToString() + array[7].ToString() + array[8].ToString()));
					bool flag3 = num2 < num;
					if (flag3)
					{
						bool flag4 = MessageBox.Show("ASCAD YENİ SÜRÜM YAYINLADI", "YENİ SÜRÜM BİLGİLENDİRME", MessageBoxButtons.YesNo) == DialogResult.Yes;
						if (flag4)
						{
							bool flag5 = File.Exists(directoryName + "\\ascadupdate.exe");
							if (flag5)
							{
								Process.Start(directoryName + "\\ascadupdate.exe");
							}
							else
							{
								try
								{
									WebClient webClient = new WebClient();
									webClient.DownloadFileAsync(new Uri("http://www.as-cad.net//ascadupdate.exe"), directoryName + "\\ascadupdate.exe");
									WebClient webClient2 = new WebClient();
									webClient2.DownloadFileAsync(new Uri("http://www.as-cad.net//DevExpress.Srt.v16.1.dll"), directoryName + "\\bin\\DevExpress.Srt.v16.1.dll");
								}
								catch (Exception)
								{
								}
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void radioHMSAG_CheckedChanged(object sender, EventArgs e)
		{
			this.HAMDSet();
		}

		private void HAMDSet()
		{
			bool @checked = this.radioHMSAG.Checked;
			if (@checked)
			{
				this.FormMyData.MakYon = "SAG";
			}
			else
			{
				this.FormMyData.MakYon = "SOL";
			}
			bool checked2 = this.agrarka.Checked;
			if (checked2)
			{
			}
			bool checked3 = this.agrsol.Checked;
			if (checked3)
			{
			}
			bool checked4 = this.agrsag.Checked;
			if (checked4)
			{
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.DurakSayi.Text = (Convert.ToInt32(this.DurakSayi.Text) + 1).ToString();
			this.katnolar();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.DurakSayi.Text = (Convert.ToInt32(this.DurakSayi.Text) - 1).ToString();
			this.katnolar();
		}

		private void katnolar()
		{
			int count = this.katlar.Rows.Count;
			bool flag = count < Convert.ToInt32(this.DurakSayi.Text) + 2;
			if (flag)
			{
				for (int i = 0; i < Convert.ToInt32(this.DurakSayi.Text) + 2 - count; i++)
				{
					this.katlar.Rows.Add(this.katlar.NewRow());
				}
			}
			else
			{
				bool flag2 = count > Convert.ToInt32(this.DurakSayi.Text) + 2;
				if (flag2)
				{
					for (int j = 0; j < count - Convert.ToInt32(this.DurakSayi.Text) - 2; j++)
					{
						this.katlar.Rows[count - 3].Delete();
					}
				}
			}
			this.katlar.Rows[0]["ktno"] = "KUYU DİBİ";
			for (int k = 1; k < this.katlar.Rows.Count - 1; k++)
			{
				this.katlar.Rows[k]["ktno"] = (Convert.ToInt32(this.IlkDurakNo.Text) + k - 1).ToString();
			}
			int count2 = this.katlar.Rows.Count;
			this.katlar.Rows[count2 - 1]["ktno"] = "KUYU TAVANI";
			this.katlar.Rows[count2 - 1]["kath"] = Convert.ToInt32(this.TopKuyuKafa.Text) - Convert.ToInt32(this.KatH.Text);
			string[] array = this.FormMyData.KatRumuz.Split(new char[]
			{
				'#'
			});
			string[] array2 = this.FormMyData.KatYukListe.Split(new char[]
			{
				'#'
			});
			List<string> list = new List<string>(array2);
			int count3 = this.katlar.Rows.Count;
			this.katlar.Rows[0]["kath"] = Convert.ToInt32(this.KuyuDibi.Text);
			bool flag3 = array2.Length + 2 > count3;
			if (flag3)
			{
				for (int l = 0; l < array2.Length + 2 - count3; l++)
				{
					list.RemoveAt(list.Count - 2);
				}
			}
			bool flag4 = array2.Length + 2 < count3;
			if (flag4)
			{
				for (int m = 0; m < count3 - array2.Length - 2; m++)
				{
					list.Insert(list.Count - 1, this.KatH.Text);
				}
			}
			for (int n = 0; n < list.Count; n++)
			{
				try
				{
					this.katlar.Rows[n + 1]["kath"] = Convert.ToInt32(list[n]);
				}
				catch (Exception)
				{
					this.gridView4.SetRowCellValue(n + 1, "kath", Convert.ToInt32(this.KatH.Text));
					this.katlar.Rows[n + 1]["kath"] = Convert.ToInt32(this.KatH.Text);
				}
				try
				{
					bool flag5 = array.Length - 1 < n;
					if (flag5)
					{
						bool flag6 = array[n].Contains('(');
						if (flag6)
						{
							this.katlar.Rows[n + 1]["krumz"] = array[n].Substring(array[n].IndexOf('('));
						}
					}
				}
				catch (Exception)
				{
					this.katlar.Rows[n + 1]["krumz"] = "";
				}
			}
			this.gridkatHhesapla();
		}

		private void gridView4_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			bool flag = e.get_Column().get_FieldName() == "kath" || e.get_Column().get_FieldName() == "krumz";
			if (flag)
			{
				this.grhes2();
				this.katlarclosing();
			}
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			this.IlkDurakNo.Text = (Convert.ToInt32(this.IlkDurakNo.Text) + 1).ToString();
			this.katnolar();
		}

		private void simpleButton4_Click(object sender, EventArgs e)
		{
			this.IlkDurakNo.Text = (Convert.ToInt32(this.IlkDurakNo.Text) - 1).ToString();
			this.katnolar();
		}

		private void sankod_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.sankod.Checked;
			if (@checked)
			{
				this.xx.SetNumValue("TahrikKodu", "SD", "1");
			}
		}

		private void agrtaneagr_EditValueChanged(object sender, EventArgs e)
		{
		}

		private void panaromik_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.panaromik.Checked;
			if (@checked)
			{
				this.xx.SetNumValue("Pan", "1", "1");
				bool checked2 = this.agrarka.Checked;
				if (checked2)
				{
					MessageBox.Show("ARKADAN AĞIRLIKTA PANORAMİK YAPAMAZSINIZ");
					this.agrarka.Enabled = false;
					this.agrsol.Checked = true;
				}
			}
			else
			{
				this.xx.SetNumValue("Pan", "0", "1");
				this.agrarka.Enabled = true;
			}
		}

		private void kabinray_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			bool flag = e.get_Button().get_Index() == 1;
			if (flag)
			{
				new productinfo
				{
					urunne = "ray"
				}.ShowDialog();
			}
		}

		private void agrray_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			bool flag = e.get_Button().get_Index() == 1;
			if (flag)
			{
				new productinfo
				{
					urunne = "ray"
				}.ShowDialog();
			}
		}

		private void vGridControl1_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			bool flag = e.get_Row().get_XtraRowTypeID() == 2;
			string komut;
			if (flag)
			{
				MultiEditorRow multiEditorRow = (MultiEditorRow)e.get_Row();
				komut = this.xx.hucredeupdate("update stats.firmabilgi Set ", multiEditorRow.get_PropertiesCollection().get_Item(e.get_CellIndex()).get_RowType().ToString(), multiEditorRow.get_PropertiesCollection().get_Item(e.get_CellIndex()).get_FieldName(), multiEditorRow.get_PropertiesCollection().get_Item(e.get_CellIndex()).get_Value().ToString(), " where id=1");
			}
			else
			{
				komut = this.xx.hucredeupdate("update stats.firmabilgi Set ", e.get_Row().get_Properties().get_RowType().ToString(), e.get_Row().get_Properties().get_FieldName(), this.firmabilgigrid.GetCellValue(e.get_Row(), 0).ToString(), " where id=1");
			}
			bool flag2 = this.xx.oleupdate(komut, "");
			if (!flag2)
			{
				MessageBox.Show("Başarısız");
			}
		}

		private void simpleButton5_Click(object sender, EventArgs e)
		{
		}

		private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			this.xx.oleupdate(string.Concat(new object[]
			{
				"update Num",
				this.AsansorSayisi,
				" set ",
				e.get_Column().get_FieldName(),
				" ='",
				e.get_Value().ToString(),
				"' where ParamName='",
				this.gridView1.GetRowCellValue(e.get_RowHandle(), "ParamName").ToString(),
				"'"
			}), "");
		}

		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ascadform));
			this.maksizlkarkas = new RadioButton();
			this.maksiz1_2alttan = new RadioButton();
			this.makli1_1 = new RadioButton();
			this.makli1_2 = new RadioButton();
			this.agrarka = new RadioButton();
			this.agrsol = new RadioButton();
			this.agrsag = new RadioButton();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.mdduz = new RadioButton();
			this.groupControl3 = new GroupControl();
			this.layoutControl9 = new LayoutControl();
			this.tableLayoutPanel2 = new TableLayoutPanel();
			this.panaromik = new CheckBox();
			this.sankod = new CheckBox();
			this.layoutControlGroup9 = new LayoutControlGroup();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControl5 = new LayoutControl();
			this.baritagr = new RadioButton();
			this.dokumagr = new RadioButton();
			this.layoutControlGroup5 = new LayoutControlGroup();
			this.layoutControlItem45 = new LayoutControlItem();
			this.layoutControlItem46 = new LayoutControlItem();
			this.layoutControl1 = new LayoutControl();
			this.AgrTamponu = new ImageComboBoxEdit();
			this.ımageList1 = new ImageList(this.components);
			this.KabinTamponu = new ImageComboBoxEdit();
			this.labelControl9 = new LabelControl();
			this.AgrRayStr = new ComboBoxEdit();
			this.KuyuDer = new TextEdit();
			this.labelControl10 = new LabelControl();
			this.KabinRayStr = new ComboBoxEdit();
			this.KuyuGen = new TextEdit();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem111 = new LayoutControlItem();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem114 = new LayoutControlItem();
			this.layoutControlItem113 = new LayoutControlItem();
			this.layoutControlItem115 = new LayoutControlItem();
			this.layoutControlItem10 = new LayoutControlItem();
			this.layoutControlItem15 = new LayoutControlItem();
			this.layoutControl2 = new LayoutControl();
			this.labelControl3 = new LabelControl();
			this.checkEdit1 = new CheckEdit();
			this.textEdit2 = new TextEdit();
			this.RegYer = new ImageComboBoxEdit();
			this.Mentese = new ImageComboBoxEdit();
			this.KapiGen = new TextEdit();
			this.otokapitipi = new ImageComboBoxEdit();
			this.asnkapitipi = new ImageComboBoxEdit();
			this.labelControl4 = new LabelControl();
			this.labelControl13 = new LabelControl();
			this.TahCap = new TextEdit();
			this.SapCap = new TextEdit();
			this.labelControl1 = new LabelControl();
			this.layoutControlGroup2 = new LayoutControlGroup();
			this.layoutControlItem11 = new LayoutControlItem();
			this.layoutControlItem22 = new LayoutControlItem();
			this.layoutControlItem27 = new LayoutControlItem();
			this.layoutControlItem28 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem9 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem12 = new LayoutControlItem();
			this.layoutControlItem13 = new LayoutControlItem();
			this.layoutControlItem14 = new LayoutControlItem();
			this.groupControl6 = new GroupControl();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.tableLayoutPanel5 = new TableLayoutPanel();
			this.HAMDControl = new GroupControl();
			this.layoutControl8 = new LayoutControl();
			this.txtHAMDDer = new TextEdit();
			this.radioHMSOL = new RadioButton();
			this.txtHAMDGen = new TextEdit();
			this.radioHMSAG = new RadioButton();
			this.layoutControlGroup8 = new LayoutControlGroup();
			this.layoutControlItem62 = new LayoutControlItem();
			this.layoutControlItem64 = new LayoutControlItem();
			this.layoutControlItem65 = new LayoutControlItem();
			this.layoutControlItem66 = new LayoutControlItem();
			this.ha11 = new RadioButton();
			this.ha21 = new RadioButton();
			this.layoutControl4 = new LayoutControl();
			this.IskeleVar = new CheckEdit();
			this.DengeZinciri = new CheckEdit();
			this.ToplamYuk = new TextEdit();
			this.SeyirMesafesi = new TextEdit();
			this.pictureBox2 = new PictureBox();
			this.simpleButton4 = new SimpleButton();
			this.simpleButton3 = new SimpleButton();
			this.gridControl1 = new GridControl();
			this.gridView4 = new GridView();
			this.gridColumn10 = new GridColumn();
			this.gridColumn11 = new GridColumn();
			this.gridColumn12 = new GridColumn();
			this.gridColumn13 = new GridColumn();
			this.simpleButton2 = new SimpleButton();
			this.simpleButton1 = new SimpleButton();
			this.MdTabTavan = new TextEdit();
			this.SonKat = new TextEdit();
			this.AraKatSTR = new TextEdit();
			this.TopKuyuKafa = new TextEdit();
			this.KuyuDibi = new TextEdit();
			this.DurakSayi = new TextEdit();
			this.KatH = new TextEdit();
			this.IlkDurakNo = new TextEdit();
			this.layoutControlGroup4 = new LayoutControlGroup();
			this.layoutControlItem36 = new LayoutControlItem();
			this.layoutControlItem37 = new LayoutControlItem();
			this.layoutControlItem38 = new LayoutControlItem();
			this.layoutControlItem42 = new LayoutControlItem();
			this.layoutControlItem43 = new LayoutControlItem();
			this.layoutControlItem44 = new LayoutControlItem();
			this.layoutControlItem68 = new LayoutControlItem();
			this.layoutControlItem82 = new LayoutControlItem();
			this.layoutControlItem125 = new LayoutControlItem();
			this.layoutControlItem40 = new LayoutControlItem();
			this.layoutControlItem41 = new LayoutControlItem();
			this.BesPanoVar = new CheckEdit();
			this.AydinlatmaBizde = new CheckEdit();
			this.groupControl1 = new GroupControl();
			this.firmabilgigrid = new VGridControl();
			this.row = new EditorRow();
			this.row1 = new EditorRow();
			this.row2 = new EditorRow();
			this.row4 = new MultiEditorRow();
			this.multiEditorRowProperties5 = new MultiEditorRowProperties();
			this.multiEditorRowProperties6 = new MultiEditorRowProperties();
			this.row3 = new MultiEditorRow();
			this.multiEditorRowProperties1 = new MultiEditorRowProperties();
			this.multiEditorRowProperties2 = new MultiEditorRowProperties();
			this.multiEditorRowProperties3 = new MultiEditorRowProperties();
			this.multiEditorRowProperties4 = new MultiEditorRowProperties();
			this.row5 = new MultiEditorRow();
			this.multiEditorRowProperties7 = new MultiEditorRowProperties();
			this.multiEditorRowProperties8 = new MultiEditorRowProperties();
			this.row8 = new MultiEditorRow();
			this.multiEditorRowProperties9 = new MultiEditorRowProperties();
			this.multiEditorRowProperties10 = new MultiEditorRowProperties();
			this.row6 = new MultiEditorRow();
			this.multiEditorRowProperties11 = new MultiEditorRowProperties();
			this.multiEditorRowProperties12 = new MultiEditorRowProperties();
			this.category = new CategoryRow();
			this.row7 = new EditorRow();
			this.row9 = new EditorRow();
			this.row10 = new EditorRow();
			this.row11 = new EditorRow();
			this.category1 = new CategoryRow();
			this.row12 = new EditorRow();
			this.row13 = new EditorRow();
			this.row14 = new EditorRow();
			this.row15 = new EditorRow();
			this.backgroundWorker1 = new BackgroundWorker();
			this.xtraTabControl1 = new XtraTabControl();
			this.xtraTabPage1 = new XtraTabPage();
			this.groupControl2 = new GroupControl();
			this.xtraTabPage2 = new XtraTabPage();
			this.xtraTabPage3 = new XtraTabPage();
			this.ayargrid = new GridControl();
			this.gridView1 = new GridView();
			this.gridColumn79 = new GridColumn();
			this.gridColumn80 = new GridColumn();
			this.gridColumn81 = new GridColumn();
			this.xtraTabPage4 = new XtraTabPage();
			this.labelControl2 = new LabelControl();
			this.ımageList2 = new ImageList(this.components);
			this.layoutControlItem16 = new LayoutControlItem();
			this.layoutControlItem17 = new LayoutControlItem();
			this.layoutControlItem18 = new LayoutControlItem();
			this.layoutControlItem19 = new LayoutControlItem();
			this.layoutControlItem20 = new LayoutControlItem();
			this.layoutControlItem21 = new LayoutControlItem();
			this.layoutControlItem23 = new LayoutControlItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupControl3.BeginInit();
			this.groupControl3.SuspendLayout();
			this.layoutControl9.BeginInit();
			this.layoutControl9.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.layoutControlGroup9.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControl5.BeginInit();
			this.layoutControl5.SuspendLayout();
			this.layoutControlGroup5.BeginInit();
			this.layoutControlItem45.BeginInit();
			this.layoutControlItem46.BeginInit();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.AgrTamponu.get_Properties().BeginInit();
			this.KabinTamponu.get_Properties().BeginInit();
			this.AgrRayStr.get_Properties().BeginInit();
			this.KuyuDer.get_Properties().BeginInit();
			this.KabinRayStr.get_Properties().BeginInit();
			this.KuyuGen.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem111.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem114.BeginInit();
			this.layoutControlItem113.BeginInit();
			this.layoutControlItem115.BeginInit();
			this.layoutControlItem10.BeginInit();
			this.layoutControlItem15.BeginInit();
			this.layoutControl2.BeginInit();
			this.layoutControl2.SuspendLayout();
			this.checkEdit1.get_Properties().BeginInit();
			this.textEdit2.get_Properties().BeginInit();
			this.RegYer.get_Properties().BeginInit();
			this.Mentese.get_Properties().BeginInit();
			this.KapiGen.get_Properties().BeginInit();
			this.otokapitipi.get_Properties().BeginInit();
			this.asnkapitipi.get_Properties().BeginInit();
			this.TahCap.get_Properties().BeginInit();
			this.SapCap.get_Properties().BeginInit();
			this.layoutControlGroup2.BeginInit();
			this.layoutControlItem11.BeginInit();
			this.layoutControlItem22.BeginInit();
			this.layoutControlItem27.BeginInit();
			this.layoutControlItem28.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem9.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem12.BeginInit();
			this.layoutControlItem13.BeginInit();
			this.layoutControlItem14.BeginInit();
			this.groupControl6.BeginInit();
			this.groupControl6.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.HAMDControl.BeginInit();
			this.HAMDControl.SuspendLayout();
			this.layoutControl8.BeginInit();
			this.layoutControl8.SuspendLayout();
			this.txtHAMDDer.get_Properties().BeginInit();
			this.txtHAMDGen.get_Properties().BeginInit();
			this.layoutControlGroup8.BeginInit();
			this.layoutControlItem62.BeginInit();
			this.layoutControlItem64.BeginInit();
			this.layoutControlItem65.BeginInit();
			this.layoutControlItem66.BeginInit();
			this.layoutControl4.BeginInit();
			this.layoutControl4.SuspendLayout();
			this.IskeleVar.get_Properties().BeginInit();
			this.DengeZinciri.get_Properties().BeginInit();
			this.ToplamYuk.get_Properties().BeginInit();
			this.SeyirMesafesi.get_Properties().BeginInit();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			this.gridControl1.BeginInit();
			this.gridView4.BeginInit();
			this.MdTabTavan.get_Properties().BeginInit();
			this.SonKat.get_Properties().BeginInit();
			this.AraKatSTR.get_Properties().BeginInit();
			this.TopKuyuKafa.get_Properties().BeginInit();
			this.KuyuDibi.get_Properties().BeginInit();
			this.DurakSayi.get_Properties().BeginInit();
			this.KatH.get_Properties().BeginInit();
			this.IlkDurakNo.get_Properties().BeginInit();
			this.layoutControlGroup4.BeginInit();
			this.layoutControlItem36.BeginInit();
			this.layoutControlItem37.BeginInit();
			this.layoutControlItem38.BeginInit();
			this.layoutControlItem42.BeginInit();
			this.layoutControlItem43.BeginInit();
			this.layoutControlItem44.BeginInit();
			this.layoutControlItem68.BeginInit();
			this.layoutControlItem82.BeginInit();
			this.layoutControlItem125.BeginInit();
			this.layoutControlItem40.BeginInit();
			this.layoutControlItem41.BeginInit();
			this.BesPanoVar.get_Properties().BeginInit();
			this.AydinlatmaBizde.get_Properties().BeginInit();
			this.groupControl1.BeginInit();
			this.groupControl1.SuspendLayout();
			this.firmabilgigrid.BeginInit();
			this.xtraTabControl1.BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			this.groupControl2.BeginInit();
			this.groupControl2.SuspendLayout();
			this.xtraTabPage2.SuspendLayout();
			this.xtraTabPage3.SuspendLayout();
			this.ayargrid.BeginInit();
			this.gridView1.BeginInit();
			this.xtraTabPage4.SuspendLayout();
			this.layoutControlItem16.BeginInit();
			this.layoutControlItem17.BeginInit();
			this.layoutControlItem18.BeginInit();
			this.layoutControlItem19.BeginInit();
			this.layoutControlItem20.BeginInit();
			this.layoutControlItem21.BeginInit();
			this.layoutControlItem23.BeginInit();
			base.SuspendLayout();
			this.maksizlkarkas.AccessibleDescription = "maksiz3";
			this.maksizlkarkas.BackColor = SystemColors.Control;
			this.maksizlkarkas.Dock = DockStyle.Fill;
			this.maksizlkarkas.Enabled = false;
			this.maksizlkarkas.FlatAppearance.BorderColor = Color.CadetBlue;
			this.maksizlkarkas.FlatAppearance.BorderSize = 2;
			this.maksizlkarkas.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			this.maksizlkarkas.Image = Resources.l_karkas1;
			this.maksizlkarkas.ImageAlign = ContentAlignment.MiddleLeft;
			this.maksizlkarkas.Location = new Point(3, 355);
			this.maksizlkarkas.Name = "maksizlkarkas";
			this.maksizlkarkas.Size = new Size(237, 82);
			this.maksizlkarkas.TabIndex = 3;
			this.maksizlkarkas.Text = "MRL L Karkas";
			this.maksizlkarkas.TextAlign = ContentAlignment.MiddleRight;
			this.maksizlkarkas.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.maksizlkarkas.UseVisualStyleBackColor = false;
			this.maksizlkarkas.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.maksiz1_2alttan.AccessibleDescription = "maksiz2";
			this.maksiz1_2alttan.Dock = DockStyle.Fill;
			this.maksiz1_2alttan.FlatAppearance.BorderColor = Color.CadetBlue;
			this.maksiz1_2alttan.FlatAppearance.BorderSize = 2;
			this.maksiz1_2alttan.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.maksiz1_2alttan.Image = (Image)componentResourceManager.GetObject("maksiz1_2alttan.Image");
			this.maksiz1_2alttan.ImageAlign = ContentAlignment.MiddleLeft;
			this.maksiz1_2alttan.Location = new Point(3, 179);
			this.maksiz1_2alttan.Name = "maksiz1_2alttan";
			this.maksiz1_2alttan.Size = new Size(237, 82);
			this.maksiz1_2alttan.TabIndex = 3;
			this.maksiz1_2alttan.Text = "MRL ÇAPRAZ PALANGA";
			this.maksiz1_2alttan.TextAlign = ContentAlignment.BottomCenter;
			this.maksiz1_2alttan.TextImageRelation = TextImageRelation.ImageAboveText;
			this.maksiz1_2alttan.UseVisualStyleBackColor = true;
			this.maksiz1_2alttan.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.makli1_1.AccessibleDescription = "mak1";
			this.makli1_1.Dock = DockStyle.Fill;
			this.makli1_1.FlatAppearance.BorderColor = Color.CadetBlue;
			this.makli1_1.FlatAppearance.BorderSize = 2;
			this.makli1_1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.makli1_1.Image = Resources.makdaireli1_1;
			this.makli1_1.ImageAlign = ContentAlignment.MiddleLeft;
			this.makli1_1.Location = new Point(3, 3);
			this.makli1_1.Name = "makli1_1";
			this.makli1_1.Size = new Size(237, 82);
			this.makli1_1.TabIndex = 2;
			this.makli1_1.Text = "1/1 DİREK ASKI";
			this.makli1_1.TextAlign = ContentAlignment.MiddleRight;
			this.makli1_1.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.makli1_1.UseVisualStyleBackColor = true;
			this.makli1_1.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.makli1_2.AccessibleDescription = "mak2";
			this.makli1_2.Dock = DockStyle.Fill;
			this.makli1_2.FlatAppearance.BorderColor = Color.CadetBlue;
			this.makli1_2.FlatAppearance.BorderSize = 2;
			this.makli1_2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.makli1_2.Image = Resources.makdaireli1_2;
			this.makli1_2.ImageAlign = ContentAlignment.MiddleLeft;
			this.makli1_2.Location = new Point(3, 91);
			this.makli1_2.Name = "makli1_2";
			this.makli1_2.Size = new Size(237, 82);
			this.makli1_2.TabIndex = 3;
			this.makli1_2.Text = "1/2 ENDİREK ASKI";
			this.makli1_2.TextAlign = ContentAlignment.MiddleRight;
			this.makli1_2.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.makli1_2.UseVisualStyleBackColor = true;
			this.makli1_2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.agrarka.AccessibleDescription = "agrarka";
			this.agrarka.Dock = DockStyle.Fill;
			this.agrarka.FlatAppearance.BorderColor = Color.CadetBlue;
			this.agrarka.FlatAppearance.BorderSize = 2;
			this.agrarka.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.agrarka.Image = (Image)componentResourceManager.GetObject("agrarka.Image");
			this.agrarka.Location = new Point(3, 3);
			this.agrarka.Name = "agrarka";
			this.agrarka.Size = new Size(141, 105);
			this.agrarka.TabIndex = 3;
			this.agrarka.Text = "ARKA";
			this.agrarka.TextAlign = ContentAlignment.TopCenter;
			this.agrarka.TextImageRelation = TextImageRelation.TextAboveImage;
			this.agrarka.UseVisualStyleBackColor = true;
			this.agrsol.AccessibleDescription = "agrsol";
			this.agrsol.Dock = DockStyle.Fill;
			this.agrsol.FlatAppearance.BorderColor = Color.CadetBlue;
			this.agrsol.FlatAppearance.BorderSize = 2;
			this.agrsol.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.agrsol.Image = (Image)componentResourceManager.GetObject("agrsol.Image");
			this.agrsol.Location = new Point(297, 3);
			this.agrsol.Name = "agrsol";
			this.agrsol.Size = new Size(141, 105);
			this.agrsol.TabIndex = 2;
			this.agrsol.Text = "SOL";
			this.agrsol.TextAlign = ContentAlignment.TopCenter;
			this.agrsol.TextImageRelation = TextImageRelation.TextAboveImage;
			this.agrsol.UseVisualStyleBackColor = true;
			this.agrsag.AccessibleDescription = "agrsag";
			this.agrsag.Dock = DockStyle.Fill;
			this.agrsag.FlatAppearance.BorderColor = Color.CadetBlue;
			this.agrsag.FlatAppearance.BorderSize = 2;
			this.agrsag.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.agrsag.Image = (Image)componentResourceManager.GetObject("agrsag.Image");
			this.agrsag.Location = new Point(150, 3);
			this.agrsag.Name = "agrsag";
			this.agrsag.Size = new Size(141, 105);
			this.agrsag.TabIndex = 3;
			this.agrsag.Text = "SAĞ";
			this.agrsag.TextAlign = ContentAlignment.TopCenter;
			this.agrsag.TextImageRelation = TextImageRelation.TextAboveImage;
			this.agrsag.UseVisualStyleBackColor = true;
			this.tableLayoutPanel1.BackColor = SystemColors.Control;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.Controls.Add(this.mdduz, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.maksizlkarkas, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.maksiz1_2alttan, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.makli1_2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.makli1_1, 0, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel1.Size = new Size(243, 440);
			this.tableLayoutPanel1.TabIndex = 0;
			this.mdduz.AccessibleDescription = "maksiz2";
			this.mdduz.Dock = DockStyle.Fill;
			this.mdduz.FlatAppearance.BorderColor = Color.CadetBlue;
			this.mdduz.FlatAppearance.BorderSize = 2;
			this.mdduz.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.mdduz.Image = (Image)componentResourceManager.GetObject("mdduz.Image");
			this.mdduz.ImageAlign = ContentAlignment.MiddleLeft;
			this.mdduz.Location = new Point(3, 267);
			this.mdduz.Name = "mdduz";
			this.mdduz.Size = new Size(237, 82);
			this.mdduz.TabIndex = 15;
			this.mdduz.Text = "MRL RAYLAR ÖNDE";
			this.mdduz.TextAlign = ContentAlignment.BottomCenter;
			this.mdduz.TextImageRelation = TextImageRelation.ImageAboveText;
			this.mdduz.UseVisualStyleBackColor = true;
			this.mdduz.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.groupControl3.get_AppearanceCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.groupControl3.get_AppearanceCaption().set_ForeColor(Color.FromArgb(192, 0, 0));
			this.groupControl3.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.groupControl3.get_AppearanceCaption().get_Options().set_UseForeColor(true);
			this.groupControl3.Controls.Add(this.layoutControl9);
			this.groupControl3.Location = new Point(249, 302);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new Size(746, 140);
			this.groupControl3.TabIndex = 16;
			this.groupControl3.Text = "TAHRİK YÖNÜ";
			this.layoutControl9.Controls.Add(this.tableLayoutPanel2);
			this.layoutControl9.Dock = DockStyle.Fill;
			this.layoutControl9.Location = new Point(2, 23);
			this.layoutControl9.Name = "layoutControl9";
			this.layoutControl9.get_OptionsCustomizationForm().set_DesignTimeCustomizationFormPositionAndSize(new Rectangle?(new Rectangle(1015, 29, 662, 435)));
			this.layoutControl9.set_Root(this.layoutControlGroup9);
			this.layoutControl9.Size = new Size(742, 115);
			this.layoutControl9.TabIndex = 0;
			this.layoutControl9.Text = "layoutControl9";
			this.tableLayoutPanel2.ColumnCount = 5;
			this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
			this.tableLayoutPanel2.Controls.Add(this.agrarka, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.agrsag, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.agrsol, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.panaromik, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.sankod, 4, 0);
			this.tableLayoutPanel2.Location = new Point(2, 2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel2.Size = new Size(738, 111);
			this.tableLayoutPanel2.TabIndex = 4;
			this.panaromik.Dock = DockStyle.Fill;
			this.panaromik.Enabled = false;
			this.panaromik.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.panaromik.Image = (Image)componentResourceManager.GetObject("panaromik.Image");
			this.panaromik.ImageAlign = ContentAlignment.BottomCenter;
			this.panaromik.Location = new Point(444, 3);
			this.panaromik.MinimumSize = new Size(0, 100);
			this.panaromik.Name = "panaromik";
			this.panaromik.Size = new Size(141, 105);
			this.panaromik.TabIndex = 1003;
			this.panaromik.Text = "PANOROMİK";
			this.panaromik.TextAlign = ContentAlignment.TopCenter;
			this.panaromik.UseVisualStyleBackColor = true;
			this.panaromik.CheckedChanged += new EventHandler(this.panaromik_CheckedChanged);
			this.sankod.Dock = DockStyle.Fill;
			this.sankod.Enabled = false;
			this.sankod.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.sankod.Image = (Image)componentResourceManager.GetObject("sankod.Image");
			this.sankod.ImageAlign = ContentAlignment.BottomCenter;
			this.sankod.Location = new Point(591, 3);
			this.sankod.MinimumSize = new Size(0, 100);
			this.sankod.Name = "sankod";
			this.sankod.Size = new Size(144, 105);
			this.sankod.TabIndex = 1004;
			this.sankod.Text = "ÇERÇEVESİZ AĞIRLIK";
			this.sankod.TextAlign = ContentAlignment.TopCenter;
			this.sankod.UseVisualStyleBackColor = true;
			this.sankod.CheckedChanged += new EventHandler(this.sankod_CheckedChanged);
			this.layoutControlGroup9.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup9.set_GroupBordersVisible(false);
			this.layoutControlGroup9.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem5
			});
			this.layoutControlGroup9.set_Location(new Point(0, 0));
			this.layoutControlGroup9.set_Name("Root");
			this.layoutControlGroup9.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlGroup9.set_Size(new Size(742, 115));
			this.layoutControlGroup9.set_TextVisible(false);
			this.layoutControlItem5.set_Control(this.tableLayoutPanel2);
			this.layoutControlItem5.set_Location(new Point(0, 0));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(742, 115));
			this.layoutControlItem5.set_TextSize(new Size(0, 0));
			this.layoutControlItem5.set_TextVisible(false);
			this.layoutControl5.Controls.Add(this.baritagr);
			this.layoutControl5.Controls.Add(this.dokumagr);
			this.layoutControl5.Dock = DockStyle.Fill;
			this.layoutControl5.Location = new Point(2, 23);
			this.layoutControl5.Name = "layoutControl5";
			this.layoutControl5.set_Root(this.layoutControlGroup5);
			this.layoutControl5.Size = new Size(267, 117);
			this.layoutControl5.TabIndex = 16;
			this.layoutControl5.Text = "layoutControl5";
			this.baritagr.AccessibleDescription = "mak2";
			this.baritagr.FlatAppearance.BorderColor = Color.CadetBlue;
			this.baritagr.FlatAppearance.BorderSize = 2;
			this.baritagr.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.baritagr.Image = (Image)componentResourceManager.GetObject("baritagr.Image");
			this.baritagr.ImageAlign = ContentAlignment.MiddleLeft;
			this.baritagr.Location = new Point(7, 7);
			this.baritagr.Name = "baritagr";
			this.baritagr.Size = new Size(253, 36);
			this.baritagr.TabIndex = 14;
			this.baritagr.Text = "BARİT AĞIRLIK";
			this.baritagr.TextAlign = ContentAlignment.MiddleRight;
			this.baritagr.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.baritagr.UseVisualStyleBackColor = true;
			this.baritagr.CheckedChanged += new EventHandler(this.baritagr_CheckedChanged);
			this.dokumagr.AccessibleDescription = "mak2";
			this.dokumagr.FlatAppearance.BorderColor = Color.CadetBlue;
			this.dokumagr.FlatAppearance.BorderSize = 2;
			this.dokumagr.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.dokumagr.Image = (Image)componentResourceManager.GetObject("dokumagr.Image");
			this.dokumagr.ImageAlign = ContentAlignment.MiddleLeft;
			this.dokumagr.Location = new Point(7, 47);
			this.dokumagr.Name = "dokumagr";
			this.dokumagr.Size = new Size(253, 36);
			this.dokumagr.TabIndex = 15;
			this.dokumagr.Text = "DÖKÜM AĞIRLIK";
			this.dokumagr.TextAlign = ContentAlignment.MiddleRight;
			this.dokumagr.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.dokumagr.UseVisualStyleBackColor = true;
			this.dokumagr.CheckedChanged += new EventHandler(this.baritagr_CheckedChanged);
			this.layoutControlGroup5.set_CustomizationFormText("layoutControlGroup5");
			this.layoutControlGroup5.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup5.set_GroupBordersVisible(false);
			this.layoutControlGroup5.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem45,
				this.layoutControlItem46
			});
			this.layoutControlGroup5.set_Location(new Point(0, 0));
			this.layoutControlGroup5.set_Name("layoutControlGroup5");
			this.layoutControlGroup5.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup5.set_Size(new Size(267, 117));
			this.layoutControlGroup5.set_TextVisible(false);
			this.layoutControlItem45.set_Control(this.baritagr);
			this.layoutControlItem45.set_CustomizationFormText("layoutControlItem45");
			this.layoutControlItem45.set_Location(new Point(0, 0));
			this.layoutControlItem45.set_MaxSize(new Size(0, 40));
			this.layoutControlItem45.set_MinSize(new Size(24, 40));
			this.layoutControlItem45.set_Name("layoutControlItem45");
			this.layoutControlItem45.set_Size(new Size(257, 40));
			this.layoutControlItem45.set_SizeConstraintsType(2);
			this.layoutControlItem45.set_TextSize(new Size(0, 0));
			this.layoutControlItem45.set_TextVisible(false);
			this.layoutControlItem46.set_Control(this.dokumagr);
			this.layoutControlItem46.set_CustomizationFormText("layoutControlItem46");
			this.layoutControlItem46.set_Location(new Point(0, 40));
			this.layoutControlItem46.set_MaxSize(new Size(0, 40));
			this.layoutControlItem46.set_MinSize(new Size(24, 40));
			this.layoutControlItem46.set_Name("layoutControlItem46");
			this.layoutControlItem46.set_Size(new Size(257, 67));
			this.layoutControlItem46.set_SizeConstraintsType(2);
			this.layoutControlItem46.set_TextSize(new Size(0, 0));
			this.layoutControlItem46.set_TextVisible(false);
			this.layoutControl1.Controls.Add(this.DurakSayi);
			this.layoutControl1.Controls.Add(this.ToplamYuk);
			this.layoutControl1.Controls.Add(this.simpleButton3);
			this.layoutControl1.Controls.Add(this.simpleButton4);
			this.layoutControl1.Controls.Add(this.IlkDurakNo);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.simpleButton2);
			this.layoutControl1.Controls.Add(this.AgrTamponu);
			this.layoutControl1.Controls.Add(this.KabinTamponu);
			this.layoutControl1.Controls.Add(this.labelControl9);
			this.layoutControl1.Controls.Add(this.AgrRayStr);
			this.layoutControl1.Controls.Add(this.KuyuDer);
			this.layoutControl1.Controls.Add(this.labelControl10);
			this.layoutControl1.Controls.Add(this.KabinRayStr);
			this.layoutControl1.Controls.Add(this.KuyuGen);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(2, 23);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(361, 268);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			this.AgrTamponu.set_EnterMoveNextControl(true);
			this.AgrTamponu.Location = new Point(141, 144);
			this.AgrTamponu.Name = "AgrTamponu";
			this.AgrTamponu.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.AgrTamponu.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.AgrTamponu.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.AgrTamponu.get_Properties().get_Items().AddRange(new ImageComboBoxItem[]
			{
				new ImageComboBoxItem("TEKLİ TAMPON", "YTampon1#AAYTampon1#AAYTampon1", -1),
				new ImageComboBoxItem("2 Lİ TAMPON", "YTampon2#AAYTampon2#AAYTampon1", -1),
				new ImageComboBoxItem("4 LÜ TAMPON", "YTampon4#AAYTampon2#AAYTampon2", -1),
				new ImageComboBoxItem("POLİÜRETAN TAMPON", "KSTampon#KSTampon1#KSTampon1", -1),
				new ImageComboBoxItem("HİDROİLK TAMPON", "HTampon#HTampon1#HTampon2", -1)
			});
			this.AgrTamponu.get_Properties().set_LargeImages(this.ımageList1);
			this.AgrTamponu.Size = new Size(218, 34);
			this.AgrTamponu.set_StyleController(this.layoutControl1);
			this.AgrTamponu.TabIndex = 1006;
			this.ımageList1.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("ımageList1.ImageStream");
			this.ımageList1.TransparentColor = Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "2pm.png");
			this.ımageList1.Images.SetKeyName(1, "2pt.png");
			this.ımageList1.Images.SetKeyName(2, "3pt.png");
			this.ımageList1.Images.SetKeyName(3, "4pm.png");
			this.ımageList1.Images.SetKeyName(4, "6pm.png");
			this.ımageList1.Images.SetKeyName(5, "cift.png");
			this.ımageList1.Images.SetKeyName(6, "ciftkrm.png");
			this.ımageList1.Images.SetKeyName(7, "ciftoto.png");
			this.ımageList1.Images.SetKeyName(8, "to.png");
			this.ımageList1.Images.SetKeyName(9, "yo.png");
			this.ımageList1.Images.SetKeyName(10, "yokrm.png");
			this.ımageList1.Images.SetKeyName(11, "2Pem.png");
			this.ımageList1.Images.SetKeyName(12, "sol.png");
			this.ımageList1.Images.SetKeyName(13, "mer.png");
			this.ımageList1.Images.SetKeyName(14, "sag.png");
			this.ımageList1.Images.SetKeyName(15, "reg1.png");
			this.ımageList1.Images.SetKeyName(16, "reg2.png");
			this.ımageList1.Images.SetKeyName(17, "reg3.png");
			this.ımageList1.Images.SetKeyName(18, "reg4.png");
			this.KabinTamponu.set_EnterMoveNextControl(true);
			this.KabinTamponu.Location = new Point(141, 106);
			this.KabinTamponu.Name = "KabinTamponu";
			this.KabinTamponu.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KabinTamponu.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KabinTamponu.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.KabinTamponu.get_Properties().get_Items().AddRange(new ImageComboBoxItem[]
			{
				new ImageComboBoxItem("TEKLİ TAMPON", "YTampon1#AAYTampon1#AAYTampon1", -1),
				new ImageComboBoxItem("2 Lİ TAMPON", "YTampon2#AAYTampon2#AAYTampon1", -1),
				new ImageComboBoxItem("4 LÜ TAMPON", "YTampon4#AAYTampon2#AAYTampon2", -1),
				new ImageComboBoxItem("POLİÜRETAN TAMPON", "KSTampon#KSTampon1#KSTampon1", -1),
				new ImageComboBoxItem("HİDROİLK TAMPON", "HTampon#HTampon1#HTampon2", -1)
			});
			this.KabinTamponu.get_Properties().set_LargeImages(this.ımageList1);
			this.KabinTamponu.Size = new Size(218, 34);
			this.KabinTamponu.set_StyleController(this.layoutControl1);
			this.KabinTamponu.TabIndex = 1005;
			this.labelControl9.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.labelControl9.set_AutoSizeMode(1);
			this.labelControl9.Location = new Point(322, 28);
			this.labelControl9.Name = "labelControl9";
			this.labelControl9.Size = new Size(37, 14);
			this.labelControl9.set_StyleController(this.layoutControl1);
			this.labelControl9.TabIndex = 10;
			this.labelControl9.Text = "mm";
			this.AgrRayStr.set_EnterMoveNextControl(true);
			this.AgrRayStr.Location = new Point(141, 80);
			this.AgrRayStr.Name = "AgrRayStr";
			this.AgrRayStr.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.AgrRayStr.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.AgrRayStr.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.AgrRayStr.get_Properties().add_ButtonClick(new ButtonPressedEventHandler(this.agrray_Properties_ButtonClick));
			this.AgrRayStr.Size = new Size(218, 22);
			this.AgrRayStr.set_StyleController(this.layoutControl1);
			this.AgrRayStr.TabIndex = 67;
			this.KuyuDer.set_EditValue("2000");
			this.KuyuDer.set_EnterMoveNextControl(true);
			this.KuyuDer.Location = new Point(141, 28);
			this.KuyuDer.Name = "KuyuDer";
			this.KuyuDer.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.KuyuDer.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KuyuDer.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.KuyuDer.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.KuyuDer.Size = new Size(177, 22);
			this.KuyuDer.set_StyleController(this.layoutControl1);
			this.KuyuDer.TabIndex = 5;
			this.labelControl10.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.labelControl10.set_AutoSizeMode(1);
			this.labelControl10.Location = new Point(322, 2);
			this.labelControl10.Name = "labelControl10";
			this.labelControl10.Size = new Size(37, 14);
			this.labelControl10.set_StyleController(this.layoutControl1);
			this.labelControl10.TabIndex = 11;
			this.labelControl10.Text = "mm";
			this.KabinRayStr.set_EnterMoveNextControl(true);
			this.KabinRayStr.Location = new Point(141, 54);
			this.KabinRayStr.Name = "KabinRayStr";
			this.KabinRayStr.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KabinRayStr.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KabinRayStr.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.KabinRayStr.get_Properties().add_ButtonClick(new ButtonPressedEventHandler(this.kabinray_Properties_ButtonClick));
			this.KabinRayStr.Size = new Size(218, 22);
			this.KabinRayStr.set_StyleController(this.layoutControl1);
			this.KabinRayStr.TabIndex = 66;
			this.KuyuGen.set_EditValue("1800");
			this.KuyuGen.set_EnterMoveNextControl(true);
			this.KuyuGen.Location = new Point(141, 2);
			this.KuyuGen.Name = "KuyuGen";
			this.KuyuGen.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.KuyuGen.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KuyuGen.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.KuyuGen.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.KuyuGen.get_Properties().get_DisplayFormat().set_FormatString("N");
			this.KuyuGen.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.KuyuGen.get_Properties().get_EditFormat().set_FormatString("N");
			this.KuyuGen.get_Properties().get_EditFormat().set_FormatType(1);
			this.KuyuGen.Size = new Size(177, 22);
			this.KuyuGen.set_StyleController(this.layoutControl1);
			this.KuyuGen.TabIndex = 4;
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem111,
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem114,
				this.layoutControlItem113,
				this.layoutControlItem115,
				this.layoutControlItem10,
				this.layoutControlItem15,
				this.layoutControlItem16,
				this.layoutControlItem17,
				this.layoutControlItem18,
				this.layoutControlItem19,
				this.layoutControlItem20,
				this.layoutControlItem21,
				this.layoutControlItem23
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlGroup1.set_Size(new Size(361, 268));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem111.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem111.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem111.set_Control(this.KabinRayStr);
			this.layoutControlItem111.set_Location(new Point(0, 52));
			this.layoutControlItem111.set_Name("layoutControlItem111");
			this.layoutControlItem111.set_Size(new Size(361, 26));
			this.layoutControlItem111.set_Text("KABİN RAYI");
			this.layoutControlItem111.set_TextSize(new Size(136, 16));
			this.layoutControlItem1.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem1.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem1.set_Control(this.AgrRayStr);
			this.layoutControlItem1.set_Location(new Point(0, 78));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(361, 26));
			this.layoutControlItem1.set_Text("AĞIRLIK RAYI");
			this.layoutControlItem1.set_TextSize(new Size(136, 16));
			this.layoutControlItem2.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem2.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem2.set_Control(this.KuyuGen);
			this.layoutControlItem2.set_Location(new Point(0, 0));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(320, 26));
			this.layoutControlItem2.set_Text("KUYU GENİŞLİĞİ");
			this.layoutControlItem2.set_TextSize(new Size(136, 16));
			this.layoutControlItem114.set_Control(this.labelControl10);
			this.layoutControlItem114.set_Location(new Point(320, 0));
			this.layoutControlItem114.set_Name("layoutControlItem114");
			this.layoutControlItem114.set_Size(new Size(41, 26));
			this.layoutControlItem114.set_TextSize(new Size(0, 0));
			this.layoutControlItem114.set_TextVisible(false);
			this.layoutControlItem113.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem113.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem113.set_Control(this.KuyuDer);
			this.layoutControlItem113.set_Location(new Point(0, 26));
			this.layoutControlItem113.set_Name("layoutControlItem113");
			this.layoutControlItem113.set_Size(new Size(320, 26));
			this.layoutControlItem113.set_Text("KUYU DERİNLİĞİ");
			this.layoutControlItem113.set_TextSize(new Size(136, 16));
			this.layoutControlItem115.set_Control(this.labelControl9);
			this.layoutControlItem115.set_Location(new Point(320, 26));
			this.layoutControlItem115.set_Name("layoutControlItem115");
			this.layoutControlItem115.set_Size(new Size(41, 26));
			this.layoutControlItem115.set_TextSize(new Size(0, 0));
			this.layoutControlItem115.set_TextVisible(false);
			this.layoutControlItem10.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem10.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem10.set_Control(this.KabinTamponu);
			this.layoutControlItem10.set_Location(new Point(0, 104));
			this.layoutControlItem10.set_Name("layoutControlItem10");
			this.layoutControlItem10.set_Size(new Size(361, 38));
			this.layoutControlItem10.set_Text("KABİN TAMPONU");
			this.layoutControlItem10.set_TextSize(new Size(136, 16));
			this.layoutControlItem15.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem15.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem15.set_Control(this.AgrTamponu);
			this.layoutControlItem15.set_Location(new Point(0, 142));
			this.layoutControlItem15.set_Name("layoutControlItem15");
			this.layoutControlItem15.set_Size(new Size(361, 38));
			this.layoutControlItem15.set_Text("AĞIRLIK TAMPONU");
			this.layoutControlItem15.set_TextSize(new Size(136, 16));
			this.layoutControl2.Controls.Add(this.labelControl3);
			this.layoutControl2.Controls.Add(this.checkEdit1);
			this.layoutControl2.Controls.Add(this.textEdit2);
			this.layoutControl2.Controls.Add(this.RegYer);
			this.layoutControl2.Controls.Add(this.Mentese);
			this.layoutControl2.Controls.Add(this.KapiGen);
			this.layoutControl2.Controls.Add(this.otokapitipi);
			this.layoutControl2.Controls.Add(this.asnkapitipi);
			this.layoutControl2.Controls.Add(this.labelControl4);
			this.layoutControl2.Controls.Add(this.labelControl13);
			this.layoutControl2.Controls.Add(this.TahCap);
			this.layoutControl2.Controls.Add(this.SapCap);
			this.layoutControl2.Controls.Add(this.labelControl1);
			this.layoutControl2.Dock = DockStyle.Fill;
			this.layoutControl2.Location = new Point(2, 23);
			this.layoutControl2.Name = "layoutControl2";
			this.layoutControl2.set_Root(this.layoutControlGroup2);
			this.layoutControl2.Size = new Size(372, 268);
			this.layoutControl2.TabIndex = 64;
			this.layoutControl2.Text = "layoutControl2";
			this.labelControl3.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl3.Location = new Point(329, 54);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new Size(22, 16);
			this.labelControl3.set_StyleController(this.layoutControl2);
			this.labelControl3.TabIndex = 1009;
			this.labelControl3.Text = "mm";
			this.checkEdit1.Location = new Point(2, 54);
			this.checkEdit1.Name = "checkEdit1";
			this.checkEdit1.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.checkEdit1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.checkEdit1.get_Properties().set_Caption("AĞR KASNAĞI");
			this.checkEdit1.Size = new Size(131, 19);
			this.checkEdit1.set_StyleController(this.layoutControl2);
			this.checkEdit1.TabIndex = 1008;
			this.textEdit2.set_EditValue("400");
			this.textEdit2.Enabled = false;
			this.textEdit2.set_EnterMoveNextControl(true);
			this.textEdit2.Location = new Point(137, 54);
			this.textEdit2.Name = "textEdit2";
			this.textEdit2.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit2.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit2.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit2.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.textEdit2.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.textEdit2.get_Properties().get_EditFormat().set_FormatType(1);
			this.textEdit2.Size = new Size(188, 22);
			this.textEdit2.set_StyleController(this.layoutControl2);
			this.textEdit2.TabIndex = 1007;
			this.RegYer.set_EnterMoveNextControl(true);
			this.RegYer.Location = new Point(132, 220);
			this.RegYer.Name = "RegYer";
			this.RegYer.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.RegYer.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.RegYer.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.RegYer.get_Properties().get_Items().AddRange(new ImageComboBoxItem[]
			{
				new ImageComboBoxItem("SOL ARKA", "2", 16),
				new ImageComboBoxItem("SAĞ ARKA", "3", 17),
				new ImageComboBoxItem("SOL ÖN", "1", 15),
				new ImageComboBoxItem("SAĞ ÖN", "4", 18)
			});
			this.RegYer.get_Properties().set_LargeImages(this.ımageList1);
			this.RegYer.Size = new Size(238, 34);
			this.RegYer.set_StyleController(this.layoutControl2);
			this.RegYer.TabIndex = 1006;
			this.Mentese.set_EnterMoveNextControl(true);
			this.Mentese.Location = new Point(132, 182);
			this.Mentese.Name = "Mentese";
			this.Mentese.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.Mentese.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.Mentese.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.Mentese.get_Properties().get_Items().AddRange(new ImageComboBoxItem[]
			{
				new ImageComboBoxItem("SOL", "SOL", 12),
				new ImageComboBoxItem("SAĞ", "SAG", 14),
				new ImageComboBoxItem("MERKEZİ", "MRK", 13)
			});
			this.Mentese.get_Properties().set_LargeImages(this.ımageList1);
			this.Mentese.Size = new Size(238, 34);
			this.Mentese.set_StyleController(this.layoutControl2);
			this.Mentese.TabIndex = 1005;
			this.KapiGen.set_EditValue("900");
			this.KapiGen.set_EnterMoveNextControl(true);
			this.KapiGen.Location = new Point(132, 80);
			this.KapiGen.Name = "KapiGen";
			this.KapiGen.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KapiGen.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KapiGen.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.KapiGen.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.KapiGen.Size = new Size(193, 22);
			this.KapiGen.set_StyleController(this.layoutControl2);
			this.KapiGen.TabIndex = 1003;
			this.otokapitipi.set_EnterMoveNextControl(true);
			this.otokapitipi.Location = new Point(132, 144);
			this.otokapitipi.Name = "otokapitipi";
			this.otokapitipi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.otokapitipi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.otokapitipi.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.otokapitipi.get_Properties().get_Items().AddRange(new ImageComboBoxItem[]
			{
				new ImageComboBoxItem("2P TELESKOPİK", "2TEL", 1),
				new ImageComboBoxItem("3P TELESKOPİK", "3TEL", 2),
				new ImageComboBoxItem("2P MERKEZİ", "2MER", 0),
				new ImageComboBoxItem("4P MERKEZİ", "4MER", 11),
				new ImageComboBoxItem("6P MERKEZİ", "6MER", 4),
				new ImageComboBoxItem("KRAMER", "KRMK", 10),
				new ImageComboBoxItem("İÇ KAPISIZ", "KPYK", 5)
			});
			this.otokapitipi.get_Properties().set_LargeImages(this.ımageList1);
			this.otokapitipi.Size = new Size(238, 34);
			this.otokapitipi.set_StyleController(this.layoutControl2);
			this.otokapitipi.TabIndex = 1004;
			this.asnkapitipi.set_EnterMoveNextControl(true);
			this.asnkapitipi.Location = new Point(132, 106);
			this.asnkapitipi.Name = "asnkapitipi";
			this.asnkapitipi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.asnkapitipi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.asnkapitipi.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.asnkapitipi.get_Properties().get_Items().AddRange(new ImageComboBoxItem[]
			{
				new ImageComboBoxItem("TAM OTOMATİK", "TO", 8),
				new ImageComboBoxItem("YARIM OTOMATİK", "YO", 9),
				new ImageComboBoxItem("Y.O. KRAMER KAPILI", "YK", 10),
				new ImageComboBoxItem("İÇ OTO DIŞ ÇİFT KAN", "CK", 7),
				new ImageComboBoxItem("İÇ KRAM DIŞ ÇİFT KAN", "CK", 6),
				new ImageComboBoxItem("ÇİFT KANAT ÇARPMA", "CK", 5)
			});
			this.asnkapitipi.get_Properties().set_LargeImages(this.ımageList1);
			this.asnkapitipi.Size = new Size(238, 34);
			this.asnkapitipi.set_StyleController(this.layoutControl2);
			this.asnkapitipi.TabIndex = 1003;
			this.labelControl4.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl4.Location = new Point(329, 28);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new Size(41, 16);
			this.labelControl4.set_StyleController(this.layoutControl2);
			this.labelControl4.TabIndex = 1000;
			this.labelControl4.Text = "mm";
			this.labelControl13.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl13.Location = new Point(329, 2);
			this.labelControl13.Name = "labelControl13";
			this.labelControl13.Size = new Size(41, 16);
			this.labelControl13.set_StyleController(this.layoutControl2);
			this.labelControl13.TabIndex = 1001;
			this.labelControl13.Text = "mm";
			this.TahCap.set_EditValue("450");
			this.TahCap.set_EnterMoveNextControl(true);
			this.TahCap.Location = new Point(132, 2);
			this.TahCap.Name = "TahCap";
			this.TahCap.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.TahCap.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.TahCap.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.TahCap.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.TahCap.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.TahCap.get_Properties().get_EditFormat().set_FormatType(1);
			this.TahCap.Size = new Size(193, 22);
			this.TahCap.set_StyleController(this.layoutControl2);
			this.TahCap.TabIndex = 7;
			this.SapCap.set_EditValue("400");
			this.SapCap.set_EnterMoveNextControl(true);
			this.SapCap.Location = new Point(132, 28);
			this.SapCap.Name = "SapCap";
			this.SapCap.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.SapCap.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.SapCap.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.SapCap.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.SapCap.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.SapCap.get_Properties().get_EditFormat().set_FormatType(1);
			this.SapCap.Size = new Size(193, 22);
			this.SapCap.set_StyleController(this.layoutControl2);
			this.SapCap.TabIndex = 8;
			this.labelControl1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl1.Location = new Point(329, 80);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new Size(41, 16);
			this.labelControl1.set_StyleController(this.layoutControl2);
			this.labelControl1.TabIndex = 1000;
			this.labelControl1.Text = "mm";
			this.layoutControlGroup2.set_CustomizationFormText("layoutControlGroup2");
			this.layoutControlGroup2.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup2.set_GroupBordersVisible(false);
			this.layoutControlGroup2.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem11,
				this.layoutControlItem22,
				this.layoutControlItem27,
				this.layoutControlItem28,
				this.layoutControlItem4,
				this.layoutControlItem3,
				this.layoutControlItem9,
				this.layoutControlItem8,
				this.layoutControlItem6,
				this.layoutControlItem7,
				this.layoutControlItem12,
				this.layoutControlItem13,
				this.layoutControlItem14
			});
			this.layoutControlGroup2.set_Location(new Point(0, 0));
			this.layoutControlGroup2.set_Name("Root");
			this.layoutControlGroup2.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlGroup2.set_Size(new Size(372, 268));
			this.layoutControlGroup2.set_TextVisible(false);
			this.layoutControlItem11.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem11.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem11.set_Control(this.TahCap);
			this.layoutControlItem11.set_CustomizationFormText("MAK. KASNAK ÇAPI");
			this.layoutControlItem11.set_Location(new Point(0, 0));
			this.layoutControlItem11.set_Name("layoutControlItem11");
			this.layoutControlItem11.set_Size(new Size(327, 26));
			this.layoutControlItem11.set_Text("MAK. KASNAK ÇAPI");
			this.layoutControlItem11.set_TextSize(new Size(127, 16));
			this.layoutControlItem22.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem22.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem22.set_Control(this.SapCap);
			this.layoutControlItem22.set_CustomizationFormText("SAP. KASNAK ÇAPI");
			this.layoutControlItem22.set_Location(new Point(0, 26));
			this.layoutControlItem22.set_Name("layoutControlItem22");
			this.layoutControlItem22.set_Size(new Size(327, 26));
			this.layoutControlItem22.set_Text("SAP. KASNAK ÇAPI");
			this.layoutControlItem22.set_TextSize(new Size(127, 16));
			this.layoutControlItem27.set_Control(this.labelControl13);
			this.layoutControlItem27.set_CustomizationFormText("layoutControlItem27");
			this.layoutControlItem27.set_Location(new Point(327, 0));
			this.layoutControlItem27.set_MaxSize(new Size(45, 20));
			this.layoutControlItem27.set_MinSize(new Size(45, 20));
			this.layoutControlItem27.set_Name("layoutControlItem27");
			this.layoutControlItem27.set_Size(new Size(45, 26));
			this.layoutControlItem27.set_SizeConstraintsType(2);
			this.layoutControlItem27.set_TextSize(new Size(0, 0));
			this.layoutControlItem27.set_TextVisible(false);
			this.layoutControlItem28.set_Control(this.labelControl4);
			this.layoutControlItem28.set_CustomizationFormText("layoutControlItem28");
			this.layoutControlItem28.set_Location(new Point(327, 26));
			this.layoutControlItem28.set_MaxSize(new Size(45, 20));
			this.layoutControlItem28.set_MinSize(new Size(45, 20));
			this.layoutControlItem28.set_Name("layoutControlItem28");
			this.layoutControlItem28.set_Size(new Size(45, 26));
			this.layoutControlItem28.set_SizeConstraintsType(2);
			this.layoutControlItem28.set_TextSize(new Size(0, 0));
			this.layoutControlItem28.set_TextVisible(false);
			this.layoutControlItem4.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem4.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem4.set_Control(this.otokapitipi);
			this.layoutControlItem4.set_Location(new Point(0, 142));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(372, 38));
			this.layoutControlItem4.set_Text("OTO KAPI TİPİ");
			this.layoutControlItem4.set_TextSize(new Size(127, 16));
			this.layoutControlItem3.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem3.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem3.set_Control(this.asnkapitipi);
			this.layoutControlItem3.set_Location(new Point(0, 104));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(372, 38));
			this.layoutControlItem3.set_Text("ASANSÖR KAPI TİPİ");
			this.layoutControlItem3.set_TextSize(new Size(127, 16));
			this.layoutControlItem9.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem9.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem9.set_Control(this.Mentese);
			this.layoutControlItem9.set_Location(new Point(0, 180));
			this.layoutControlItem9.set_Name("layoutControlItem9");
			this.layoutControlItem9.set_Size(new Size(372, 38));
			this.layoutControlItem9.set_Text("AÇILMA YÖNÜ");
			this.layoutControlItem9.set_TextSize(new Size(127, 16));
			this.layoutControlItem8.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem8.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem8.set_Control(this.KapiGen);
			this.layoutControlItem8.set_Location(new Point(0, 78));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(327, 26));
			this.layoutControlItem8.set_Text("KAPI GENİŞLİĞİ");
			this.layoutControlItem8.set_TextSize(new Size(127, 16));
			this.layoutControlItem6.set_Control(this.labelControl1);
			this.layoutControlItem6.set_CustomizationFormText("layoutControlItem28");
			this.layoutControlItem6.set_Location(new Point(327, 78));
			this.layoutControlItem6.set_MaxSize(new Size(45, 20));
			this.layoutControlItem6.set_MinSize(new Size(45, 20));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(45, 26));
			this.layoutControlItem6.set_SizeConstraintsType(2);
			this.layoutControlItem6.set_Text("layoutControlItem28");
			this.layoutControlItem6.set_TextSize(new Size(0, 0));
			this.layoutControlItem6.set_TextVisible(false);
			this.layoutControlItem7.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem7.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem7.set_Control(this.RegYer);
			this.layoutControlItem7.set_Location(new Point(0, 218));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(372, 50));
			this.layoutControlItem7.set_Text("REGÜLATÖR YERİ");
			this.layoutControlItem7.set_TextSize(new Size(127, 16));
			this.layoutControlItem12.set_Control(this.textEdit2);
			this.layoutControlItem12.set_Location(new Point(135, 52));
			this.layoutControlItem12.set_Name("layoutControlItem12");
			this.layoutControlItem12.set_Size(new Size(192, 26));
			this.layoutControlItem12.set_Text("Agırlık Üstü Kasnak");
			this.layoutControlItem12.set_TextSize(new Size(0, 0));
			this.layoutControlItem12.set_TextVisible(false);
			this.layoutControlItem13.set_Control(this.checkEdit1);
			this.layoutControlItem13.set_Location(new Point(0, 52));
			this.layoutControlItem13.set_Name("layoutControlItem13");
			this.layoutControlItem13.set_Size(new Size(135, 26));
			this.layoutControlItem13.set_TextSize(new Size(0, 0));
			this.layoutControlItem13.set_TextVisible(false);
			this.layoutControlItem14.set_Control(this.labelControl3);
			this.layoutControlItem14.set_Location(new Point(327, 52));
			this.layoutControlItem14.set_Name("layoutControlItem14");
			this.layoutControlItem14.set_Size(new Size(45, 26));
			this.layoutControlItem14.set_TextSize(new Size(0, 0));
			this.layoutControlItem14.set_TextVisible(false);
			this.groupControl6.get_AppearanceCaption().set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
			this.groupControl6.get_AppearanceCaption().set_ForeColor(Color.FromArgb(192, 0, 0));
			this.groupControl6.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.groupControl6.get_AppearanceCaption().get_Options().set_UseForeColor(true);
			this.groupControl6.Controls.Add(this.layoutControl1);
			this.groupControl6.Location = new Point(250, 3);
			this.groupControl6.Name = "groupControl6";
			this.groupControl6.Size = new Size(365, 293);
			this.groupControl6.TabIndex = 20;
			this.groupControl6.Text = "KUYU VE RAY BİLGİLERİ";
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Location = new Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(243, 440);
			this.panel1.TabIndex = 1002;
			this.panel2.Controls.Add(this.tableLayoutPanel5);
			this.panel2.Location = new Point(2, 61);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(246, 352);
			this.panel2.TabIndex = 1002;
			this.panel2.Visible = false;
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel5.Controls.Add(this.HAMDControl, 0, 2);
			this.tableLayoutPanel5.Controls.Add(this.ha11, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.ha21, 0, 1);
			this.tableLayoutPanel5.Dock = DockStyle.Fill;
			this.tableLayoutPanel5.Location = new Point(0, 0);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 3;
			this.tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
			this.tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
			this.tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
			this.tableLayoutPanel5.Size = new Size(246, 352);
			this.tableLayoutPanel5.TabIndex = 0;
			this.HAMDControl.get_AppearanceCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.HAMDControl.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.HAMDControl.Controls.Add(this.layoutControl8);
			this.HAMDControl.Dock = DockStyle.Fill;
			this.HAMDControl.Location = new Point(3, 237);
			this.HAMDControl.Name = "HAMDControl";
			this.HAMDControl.Size = new Size(240, 112);
			this.HAMDControl.TabIndex = 20;
			this.HAMDControl.Text = "HİDROLİK MAKİNE DAİRESİ";
			this.layoutControl8.Controls.Add(this.txtHAMDDer);
			this.layoutControl8.Controls.Add(this.radioHMSOL);
			this.layoutControl8.Controls.Add(this.txtHAMDGen);
			this.layoutControl8.Controls.Add(this.radioHMSAG);
			this.layoutControl8.Dock = DockStyle.Fill;
			this.layoutControl8.Location = new Point(2, 23);
			this.layoutControl8.Name = "layoutControl8";
			this.layoutControl8.set_Root(this.layoutControlGroup8);
			this.layoutControl8.Size = new Size(236, 87);
			this.layoutControl8.TabIndex = 0;
			this.layoutControl8.Text = "layoutControl8";
			this.txtHAMDDer.set_EditValue("3000");
			this.txtHAMDDer.set_EnterMoveNextControl(true);
			this.txtHAMDDer.Location = new Point(141, 89);
			this.txtHAMDDer.Name = "txtHAMDDer";
			this.txtHAMDDer.Size = new Size(71, 20);
			this.txtHAMDDer.set_StyleController(this.layoutControl8);
			this.txtHAMDDer.TabIndex = 19;
			this.radioHMSOL.Location = new Point(7, 36);
			this.radioHMSOL.Name = "radioHMSOL";
			this.radioHMSOL.Size = new Size(205, 25);
			this.radioHMSOL.TabIndex = 17;
			this.radioHMSOL.TabStop = true;
			this.radioHMSOL.Text = "SOL";
			this.radioHMSOL.UseVisualStyleBackColor = true;
			this.txtHAMDGen.set_EditValue("3000");
			this.txtHAMDGen.set_EnterMoveNextControl(true);
			this.txtHAMDGen.Location = new Point(141, 65);
			this.txtHAMDGen.Name = "txtHAMDGen";
			this.txtHAMDGen.Size = new Size(71, 20);
			this.txtHAMDGen.set_StyleController(this.layoutControl8);
			this.txtHAMDGen.TabIndex = 18;
			this.radioHMSAG.Location = new Point(7, 7);
			this.radioHMSAG.Name = "radioHMSAG";
			this.radioHMSAG.Size = new Size(205, 25);
			this.radioHMSAG.TabIndex = 16;
			this.radioHMSAG.TabStop = true;
			this.radioHMSAG.Text = "SAĞ";
			this.radioHMSAG.UseVisualStyleBackColor = true;
			this.layoutControlGroup8.set_CustomizationFormText("layoutControlGroup6");
			this.layoutControlGroup8.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup8.set_GroupBordersVisible(false);
			this.layoutControlGroup8.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem62,
				this.layoutControlItem64,
				this.layoutControlItem65,
				this.layoutControlItem66
			});
			this.layoutControlGroup8.set_Location(new Point(0, 0));
			this.layoutControlGroup8.set_Name("layoutControlGroup6");
			this.layoutControlGroup8.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup8.set_Size(new Size(219, 116));
			this.layoutControlGroup8.set_TextVisible(false);
			this.layoutControlItem62.set_Control(this.radioHMSAG);
			this.layoutControlItem62.set_CustomizationFormText("layoutControlItem62");
			this.layoutControlItem62.set_Location(new Point(0, 0));
			this.layoutControlItem62.set_Name("layoutControlItem62");
			this.layoutControlItem62.set_Size(new Size(209, 29));
			this.layoutControlItem62.set_TextSize(new Size(0, 0));
			this.layoutControlItem62.set_TextVisible(false);
			this.layoutControlItem64.set_Control(this.radioHMSOL);
			this.layoutControlItem64.set_CustomizationFormText("layoutControlItem64");
			this.layoutControlItem64.set_Location(new Point(0, 29));
			this.layoutControlItem64.set_Name("layoutControlItem64");
			this.layoutControlItem64.set_Size(new Size(209, 29));
			this.layoutControlItem64.set_TextSize(new Size(0, 0));
			this.layoutControlItem64.set_TextVisible(false);
			this.layoutControlItem65.set_Control(this.txtHAMDGen);
			this.layoutControlItem65.set_CustomizationFormText("MAKİNE DAİRESİ GENİŞLİK");
			this.layoutControlItem65.set_Location(new Point(0, 58));
			this.layoutControlItem65.set_Name("layoutControlItem65");
			this.layoutControlItem65.set_Size(new Size(209, 24));
			this.layoutControlItem65.set_Text("MAKİNE DAİRESİ GENİŞLİK");
			this.layoutControlItem65.set_TextSize(new Size(131, 13));
			this.layoutControlItem66.set_Control(this.txtHAMDDer);
			this.layoutControlItem66.set_CustomizationFormText("MAKİNE DAİRESİ DERİNLİK");
			this.layoutControlItem66.set_Location(new Point(0, 82));
			this.layoutControlItem66.set_Name("layoutControlItem66");
			this.layoutControlItem66.set_Size(new Size(209, 24));
			this.layoutControlItem66.set_Text("MAKİNE DAİRESİ DERİNLİK");
			this.layoutControlItem66.set_TextSize(new Size(131, 13));
			this.ha11.AccessibleDescription = "maksiz2";
			this.ha11.Dock = DockStyle.Fill;
			this.ha11.FlatAppearance.BorderColor = Color.CadetBlue;
			this.ha11.FlatAppearance.BorderSize = 2;
			this.ha11.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.ha11.Image = (Image)componentResourceManager.GetObject("ha11.Image");
			this.ha11.ImageAlign = ContentAlignment.MiddleLeft;
			this.ha11.Location = new Point(3, 3);
			this.ha11.Name = "ha11";
			this.ha11.Size = new Size(240, 111);
			this.ha11.TabIndex = 3;
			this.ha11.Text = "2/1 DİREK TAHRİK";
			this.ha11.TextAlign = ContentAlignment.BottomCenter;
			this.ha11.TextImageRelation = TextImageRelation.ImageAboveText;
			this.ha11.UseVisualStyleBackColor = true;
			this.ha11.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.ha21.AccessibleDescription = "maksiz2";
			this.ha21.Checked = true;
			this.ha21.Dock = DockStyle.Fill;
			this.ha21.FlatAppearance.BorderColor = Color.CadetBlue;
			this.ha21.FlatAppearance.BorderSize = 2;
			this.ha21.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.ha21.Image = (Image)componentResourceManager.GetObject("ha21.Image");
			this.ha21.ImageAlign = ContentAlignment.MiddleLeft;
			this.ha21.Location = new Point(3, 120);
			this.ha21.Name = "ha21";
			this.ha21.Size = new Size(240, 111);
			this.ha21.TabIndex = 15;
			this.ha21.TabStop = true;
			this.ha21.Text = "ÇAPRAZ PİSTON YÜK";
			this.ha21.TextAlign = ContentAlignment.BottomCenter;
			this.ha21.TextImageRelation = TextImageRelation.ImageAboveText;
			this.ha21.UseVisualStyleBackColor = true;
			this.ha21.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.layoutControl4.Controls.Add(this.IskeleVar);
			this.layoutControl4.Controls.Add(this.DengeZinciri);
			this.layoutControl4.Controls.Add(this.SeyirMesafesi);
			this.layoutControl4.Controls.Add(this.pictureBox2);
			this.layoutControl4.Controls.Add(this.gridControl1);
			this.layoutControl4.Controls.Add(this.MdTabTavan);
			this.layoutControl4.Controls.Add(this.SonKat);
			this.layoutControl4.Controls.Add(this.AraKatSTR);
			this.layoutControl4.Controls.Add(this.TopKuyuKafa);
			this.layoutControl4.Controls.Add(this.KuyuDibi);
			this.layoutControl4.Controls.Add(this.KatH);
			this.layoutControl4.Location = new Point(3, 5);
			this.layoutControl4.Name = "layoutControl4";
			this.layoutControl4.set_Root(this.layoutControlGroup4);
			this.layoutControl4.Size = new Size(988, 446);
			this.layoutControl4.TabIndex = 4;
			this.layoutControl4.Text = "layoutControl4";
			this.IskeleVar.Location = new Point(7, 211);
			this.IskeleVar.Name = "IskeleVar";
			this.IskeleVar.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.IskeleVar.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.IskeleVar.get_Properties().set_Caption("İskele KullanımıX");
			this.IskeleVar.Size = new Size(353, 20);
			this.IskeleVar.set_StyleController(this.layoutControl4);
			this.IskeleVar.TabIndex = 1004;
			this.DengeZinciri.Location = new Point(7, 187);
			this.DengeZinciri.Name = "DengeZinciri";
			this.DengeZinciri.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.DengeZinciri.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.DengeZinciri.get_Properties().set_Caption("Denge Zinciri");
			this.DengeZinciri.Size = new Size(353, 20);
			this.DengeZinciri.set_StyleController(this.layoutControl4);
			this.DengeZinciri.TabIndex = 1003;
			this.ToplamYuk.Location = new Point(141, 236);
			this.ToplamYuk.Name = "ToplamYuk";
			this.ToplamYuk.get_Properties().get_Appearance().set_BackColor(SystemColors.Control);
			this.ToplamYuk.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.ToplamYuk.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.ToplamYuk.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.ToplamYuk.get_Properties().set_BorderStyle(0);
			this.ToplamYuk.Size = new Size(218, 20);
			this.ToplamYuk.set_StyleController(this.layoutControl1);
			this.ToplamYuk.TabIndex = 1002;
			this.SeyirMesafesi.Location = new Point(219, 137);
			this.SeyirMesafesi.Name = "SeyirMesafesi";
			this.SeyirMesafesi.get_Properties().get_Appearance().set_BackColor(SystemColors.Control);
			this.SeyirMesafesi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.SeyirMesafesi.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.SeyirMesafesi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.SeyirMesafesi.get_Properties().set_BorderStyle(0);
			this.SeyirMesafesi.Size = new Size(141, 20);
			this.SeyirMesafesi.set_StyleController(this.layoutControl4);
			this.SeyirMesafesi.TabIndex = 14;
			this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new Point(741, 7);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(240, 432);
			this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 13;
			this.pictureBox2.TabStop = false;
			this.simpleButton4.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton4.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton4.Location = new Point(223, 209);
			this.simpleButton4.Name = "simpleButton4";
			this.simpleButton4.Size = new Size(64, 23);
			this.simpleButton4.set_StyleController(this.layoutControl1);
			this.simpleButton4.TabIndex = 12;
			this.simpleButton4.Text = "   -   ";
			this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
			this.simpleButton3.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton3.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton3.Location = new Point(291, 209);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new Size(68, 23);
			this.simpleButton3.set_StyleController(this.layoutControl1);
			this.simpleButton3.TabIndex = 12;
			this.simpleButton3.Text = "   +   ";
			this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
			this.gridControl1.Location = new Point(364, 7);
			this.gridControl1.set_MainView(this.gridView4);
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new Size(373, 432);
			this.gridControl1.TabIndex = 4;
			this.gridControl1.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView4
			});
			this.gridView4.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_Row().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView4.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView4.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView4.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn10,
				this.gridColumn11,
				this.gridColumn12,
				this.gridColumn13
			});
			this.gridView4.set_GridControl(this.gridControl1);
			this.gridView4.set_Name("gridView4");
			this.gridView4.get_OptionsCustomization().set_AllowGroup(false);
			this.gridView4.get_OptionsView().set_ShowFooter(true);
			this.gridView4.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView4.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView4_CellValueChanged));
			this.gridColumn10.set_Caption("KATNO");
			this.gridColumn10.set_FieldName("ktno");
			this.gridColumn10.set_MaxWidth(100);
			this.gridColumn10.set_MinWidth(55);
			this.gridColumn10.set_Name("gridColumn10");
			this.gridColumn10.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn10.set_Visible(true);
			this.gridColumn10.set_VisibleIndex(0);
			this.gridColumn10.set_Width(55);
			this.gridColumn11.set_Caption("KatAdı");
			this.gridColumn11.set_FieldName("krumz");
			this.gridColumn11.set_Name("gridColumn11");
			this.gridColumn11.set_Visible(true);
			this.gridColumn11.set_VisibleIndex(1);
			this.gridColumn11.set_Width(63);
			this.gridColumn12.set_Caption("KatH");
			this.gridColumn12.set_FieldName("kath");
			this.gridColumn12.set_MaxWidth(70);
			this.gridColumn12.set_MinWidth(50);
			this.gridColumn12.set_Name("gridColumn12");
			this.gridColumn12.get_Summary().AddRange(new GridSummaryItem[]
			{
				new GridColumnSummaryItem(0, "kath", "{0:0.##}")
			});
			this.gridColumn12.set_Visible(true);
			this.gridColumn12.set_VisibleIndex(2);
			this.gridColumn12.set_Width(50);
			this.gridColumn13.set_Caption("Mimari Kot");
			this.gridColumn13.set_FieldName("mimkot");
			this.gridColumn13.set_MaxWidth(90);
			this.gridColumn13.set_Name("gridColumn13");
			this.gridColumn13.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn13.set_Visible(true);
			this.gridColumn13.set_VisibleIndex(3);
			this.gridColumn13.set_Width(70);
			this.simpleButton2.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton2.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton2.Location = new Point(223, 182);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(64, 23);
			this.simpleButton2.set_StyleController(this.layoutControl1);
			this.simpleButton2.TabIndex = 11;
			this.simpleButton2.Text = "   -   ";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			this.simpleButton1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Location = new Point(291, 182);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(68, 23);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 10;
			this.simpleButton1.Text = "   +   ";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.MdTabTavan.set_EditValue("2100");
			this.MdTabTavan.set_EnterMoveNextControl(true);
			this.MdTabTavan.Location = new Point(219, 59);
			this.MdTabTavan.Name = "MdTabTavan";
			this.MdTabTavan.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.MdTabTavan.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.MdTabTavan.Size = new Size(141, 22);
			this.MdTabTavan.set_StyleController(this.layoutControl4);
			this.MdTabTavan.TabIndex = 7;
			this.SonKat.set_EditValue("3000");
			this.SonKat.Enabled = false;
			this.SonKat.set_EnterMoveNextControl(true);
			this.SonKat.Location = new Point(219, 33);
			this.SonKat.Name = "SonKat";
			this.SonKat.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.SonKat.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.SonKat.get_Properties().get_DisplayFormat().set_FormatString("n");
			this.SonKat.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.SonKat.Size = new Size(141, 22);
			this.SonKat.set_StyleController(this.layoutControl4);
			this.SonKat.TabIndex = 6;
			this.AraKatSTR.set_EnterMoveNextControl(true);
			this.AraKatSTR.Location = new Point(219, 161);
			this.AraKatSTR.Name = "AraKatSTR";
			this.AraKatSTR.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.AraKatSTR.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.AraKatSTR.Size = new Size(141, 22);
			this.AraKatSTR.set_StyleController(this.layoutControl4);
			this.AraKatSTR.TabIndex = 9;
			this.TopKuyuKafa.set_EditValue("3800");
			this.TopKuyuKafa.Enabled = false;
			this.TopKuyuKafa.set_EnterMoveNextControl(true);
			this.TopKuyuKafa.Location = new Point(219, 85);
			this.TopKuyuKafa.Name = "TopKuyuKafa";
			this.TopKuyuKafa.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.TopKuyuKafa.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.TopKuyuKafa.Size = new Size(141, 22);
			this.TopKuyuKafa.set_StyleController(this.layoutControl4);
			this.TopKuyuKafa.TabIndex = 5;
			this.KuyuDibi.set_EditValue("1500");
			this.KuyuDibi.set_EnterMoveNextControl(true);
			this.KuyuDibi.Location = new Point(219, 111);
			this.KuyuDibi.Name = "KuyuDibi";
			this.KuyuDibi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KuyuDibi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KuyuDibi.Size = new Size(141, 22);
			this.KuyuDibi.set_StyleController(this.layoutControl4);
			this.KuyuDibi.TabIndex = 4;
			this.DurakSayi.set_EditValue("1");
			this.DurakSayi.Enabled = false;
			this.DurakSayi.set_EnterMoveNextControl(true);
			this.DurakSayi.Location = new Point(141, 182);
			this.DurakSayi.Name = "DurakSayi";
			this.DurakSayi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.DurakSayi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.DurakSayi.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.DurakSayi.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.DurakSayi.Size = new Size(78, 22);
			this.DurakSayi.set_StyleController(this.layoutControl1);
			this.DurakSayi.TabIndex = 0;
			this.KatH.set_EditValue("3000");
			this.KatH.Enabled = false;
			this.KatH.set_EnterMoveNextControl(true);
			this.KatH.Location = new Point(219, 7);
			this.KatH.Name = "KatH";
			this.KatH.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KatH.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KatH.Size = new Size(141, 22);
			this.KatH.set_StyleController(this.layoutControl4);
			this.KatH.TabIndex = 2;
			this.IlkDurakNo.set_EditValue("0");
			this.IlkDurakNo.Enabled = false;
			this.IlkDurakNo.set_EnterMoveNextControl(true);
			this.IlkDurakNo.Location = new Point(141, 209);
			this.IlkDurakNo.Name = "IlkDurakNo";
			this.IlkDurakNo.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.IlkDurakNo.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.IlkDurakNo.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.IlkDurakNo.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.IlkDurakNo.Size = new Size(78, 22);
			this.IlkDurakNo.set_StyleController(this.layoutControl1);
			this.IlkDurakNo.TabIndex = 1;
			this.layoutControlGroup4.set_CustomizationFormText("layoutControlGroup4");
			this.layoutControlGroup4.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup4.set_GroupBordersVisible(false);
			this.layoutControlGroup4.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem36,
				this.layoutControlItem37,
				this.layoutControlItem38,
				this.layoutControlItem42,
				this.layoutControlItem43,
				this.layoutControlItem44,
				this.layoutControlItem68,
				this.layoutControlItem82,
				this.layoutControlItem125,
				this.layoutControlItem40,
				this.layoutControlItem41
			});
			this.layoutControlGroup4.set_Location(new Point(0, 0));
			this.layoutControlGroup4.set_Name("layoutControlGroup4");
			this.layoutControlGroup4.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup4.set_Size(new Size(988, 446));
			this.layoutControlGroup4.set_TextVisible(false);
			this.layoutControlItem36.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem36.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem36.set_Control(this.KatH);
			this.layoutControlItem36.set_CustomizationFormText("ORT. KAT YÜK");
			this.layoutControlItem36.set_Location(new Point(0, 0));
			this.layoutControlItem36.set_Name("layoutControlItem36");
			this.layoutControlItem36.set_Size(new Size(357, 26));
			this.layoutControlItem36.set_Text("ORT. KAT YÜK - d");
			this.layoutControlItem36.set_TextSize(new Size(209, 16));
			this.layoutControlItem37.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem37.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem37.set_Control(this.KuyuDibi);
			this.layoutControlItem37.set_CustomizationFormText("KUYU DİBİ ");
			this.layoutControlItem37.set_Location(new Point(0, 104));
			this.layoutControlItem37.set_Name("layoutControlItem37");
			this.layoutControlItem37.set_Size(new Size(357, 26));
			this.layoutControlItem37.set_Text("KUYU DİBİ - a");
			this.layoutControlItem37.set_TextSize(new Size(209, 16));
			this.layoutControlItem38.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem38.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem38.set_Control(this.TopKuyuKafa);
			this.layoutControlItem38.set_CustomizationFormText("KUYU KAFASI");
			this.layoutControlItem38.set_Location(new Point(0, 78));
			this.layoutControlItem38.set_Name("layoutControlItem38");
			this.layoutControlItem38.set_Size(new Size(357, 26));
			this.layoutControlItem38.set_Text("SON KAT ZEMİN-KUYU TAVANI - c");
			this.layoutControlItem38.set_TextSize(new Size(209, 16));
			this.layoutControlItem42.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem42.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem42.set_Control(this.AraKatSTR);
			this.layoutControlItem42.set_CustomizationFormText("ARAKATLAR YAZISI");
			this.layoutControlItem42.set_Location(new Point(0, 154));
			this.layoutControlItem42.set_Name("layoutControlItem42");
			this.layoutControlItem42.set_Size(new Size(357, 26));
			this.layoutControlItem42.set_Text("ARAKATLAR YAZISI");
			this.layoutControlItem42.set_TextSize(new Size(209, 16));
			this.layoutControlItem43.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem43.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem43.set_Control(this.SonKat);
			this.layoutControlItem43.set_CustomizationFormText("SON KAT YÜK");
			this.layoutControlItem43.set_Location(new Point(0, 26));
			this.layoutControlItem43.set_Name("layoutControlItem43");
			this.layoutControlItem43.set_Size(new Size(357, 26));
			this.layoutControlItem43.set_Text("SON KAT YÜK - b");
			this.layoutControlItem43.set_TextSize(new Size(209, 16));
			this.layoutControlItem44.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem44.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem44.set_Control(this.MdTabTavan);
			this.layoutControlItem44.set_CustomizationFormText("MAKİNE DAİRESİ ÇALIŞMA YÜKSEKLİĞİ");
			this.layoutControlItem44.set_Location(new Point(0, 52));
			this.layoutControlItem44.set_Name("layoutControlItem44");
			this.layoutControlItem44.set_Size(new Size(357, 26));
			this.layoutControlItem44.set_Text("ÇALIŞMA YÜKSEKLİĞİ - e");
			this.layoutControlItem44.set_TextSize(new Size(209, 16));
			this.layoutControlItem68.set_Control(this.gridControl1);
			this.layoutControlItem68.set_CustomizationFormText("layoutControlItem39");
			this.layoutControlItem68.set_Location(new Point(357, 0));
			this.layoutControlItem68.set_Name("layoutControlItem39");
			this.layoutControlItem68.set_Size(new Size(377, 436));
			this.layoutControlItem68.set_TextSize(new Size(0, 0));
			this.layoutControlItem68.set_TextVisible(false);
			this.layoutControlItem82.set_Control(this.pictureBox2);
			this.layoutControlItem82.set_Location(new Point(734, 0));
			this.layoutControlItem82.set_Name("layoutControlItem82");
			this.layoutControlItem82.set_Size(new Size(244, 436));
			this.layoutControlItem82.set_TextSize(new Size(0, 0));
			this.layoutControlItem82.set_TextVisible(false);
			this.layoutControlItem125.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem125.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem125.set_Control(this.SeyirMesafesi);
			this.layoutControlItem125.set_Location(new Point(0, 130));
			this.layoutControlItem125.set_Name("layoutControlItem125");
			this.layoutControlItem125.set_Size(new Size(357, 24));
			this.layoutControlItem125.set_Text("SEYİR MESAFESİ :");
			this.layoutControlItem125.set_TextSize(new Size(209, 16));
			this.layoutControlItem40.set_Control(this.DengeZinciri);
			this.layoutControlItem40.set_Location(new Point(0, 180));
			this.layoutControlItem40.set_Name("layoutControlItem40");
			this.layoutControlItem40.set_Size(new Size(357, 24));
			this.layoutControlItem40.set_TextSize(new Size(0, 0));
			this.layoutControlItem40.set_TextVisible(false);
			this.layoutControlItem41.set_Control(this.IskeleVar);
			this.layoutControlItem41.set_Location(new Point(0, 204));
			this.layoutControlItem41.set_Name("layoutControlItem41");
			this.layoutControlItem41.set_Size(new Size(357, 232));
			this.layoutControlItem41.set_TextSize(new Size(0, 0));
			this.layoutControlItem41.set_TextVisible(false);
			this.BesPanoVar.Location = new Point(339, 192);
			this.BesPanoVar.Name = "BesPanoVar";
			this.BesPanoVar.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.BesPanoVar.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.BesPanoVar.get_Properties().set_Caption("Besleme Panosu FİRMAMIZ Sorumluluğunda");
			this.BesPanoVar.Size = new Size(277, 20);
			this.BesPanoVar.TabIndex = 11;
			this.AydinlatmaBizde.Location = new Point(339, 166);
			this.AydinlatmaBizde.Name = "AydinlatmaBizde";
			this.AydinlatmaBizde.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.AydinlatmaBizde.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.AydinlatmaBizde.get_Properties().set_Caption("Aydınlatma FİRMAMIZ Sorumluluğunda");
			this.AydinlatmaBizde.Size = new Size(277, 20);
			this.AydinlatmaBizde.TabIndex = 10;
			this.groupControl1.get_AppearanceCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.groupControl1.get_AppearanceCaption().set_ForeColor(Color.FromArgb(192, 64, 0));
			this.groupControl1.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.groupControl1.get_AppearanceCaption().get_Options().set_UseForeColor(true);
			this.groupControl1.Controls.Add(this.layoutControl5);
			this.groupControl1.Location = new Point(337, 15);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new Size(271, 142);
			this.groupControl1.TabIndex = 13;
			this.groupControl1.Text = "AĞIRLIK TİPİ";
			this.firmabilgigrid.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_Category().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
			this.firmabilgigrid.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.firmabilgigrid.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 10f));
			this.firmabilgigrid.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.firmabilgigrid.Cursor = Cursors.SizeNS;
			this.firmabilgigrid.Dock = DockStyle.Top;
			this.firmabilgigrid.set_LayoutStyle(1);
			this.firmabilgigrid.Location = new Point(0, 0);
			this.firmabilgigrid.Name = "firmabilgigrid";
			this.firmabilgigrid.set_RecordWidth(110);
			this.firmabilgigrid.set_RowHeaderWidth(90);
			this.firmabilgigrid.get_Rows().AddRange(new BaseRow[]
			{
				this.row,
				this.row1,
				this.row2,
				this.row4,
				this.row3,
				this.row5,
				this.row8,
				this.row6,
				this.category,
				this.category1
			});
			this.firmabilgigrid.Size = new Size(990, 352);
			this.firmabilgigrid.TabIndex = 1002;
			this.firmabilgigrid.add_CellValueChanged(new CellValueChangedEventHandler(this.vGridControl1_CellValueChanged));
			this.row.set_Name("row");
			this.row.get_Properties().set_Caption("FİRMANIZIN ADI");
			this.row.get_Properties().set_FieldName("ad");
			this.row.get_Properties().set_Padding(new Padding(0));
			this.row1.set_Name("row1");
			this.row1.get_Properties().set_Caption("ADRES");
			this.row1.get_Properties().set_FieldName("adres");
			this.row1.get_Properties().set_Padding(new Padding(0));
			this.row2.set_Height(18);
			this.row2.set_Name("row2");
			this.row2.get_Properties().set_Caption("MARKA");
			this.row2.get_Properties().set_FieldName("marka");
			this.row2.get_Properties().set_Padding(new Padding(0));
			this.row4.set_Name("row4");
			this.row4.get_PropertiesCollection().AddRange(new MultiEditorRowProperties[]
			{
				this.multiEditorRowProperties5,
				this.multiEditorRowProperties6
			});
			this.multiEditorRowProperties5.set_Caption("VERGİ DAİRESİ");
			this.multiEditorRowProperties5.set_FieldName("VergiDair");
			this.multiEditorRowProperties5.set_Padding(new Padding(0));
			this.multiEditorRowProperties6.set_Caption("VERGİ NUMARASI");
			this.multiEditorRowProperties6.set_FieldName("VergiNo");
			this.multiEditorRowProperties6.set_Padding(new Padding(0));
			this.row3.set_Name("row3");
			this.row3.get_PropertiesCollection().AddRange(new MultiEditorRowProperties[]
			{
				this.multiEditorRowProperties1,
				this.multiEditorRowProperties2,
				this.multiEditorRowProperties3,
				this.multiEditorRowProperties4
			});
			this.multiEditorRowProperties1.set_Caption("YETKİLİ ADI");
			this.multiEditorRowProperties1.set_FieldName("Yad");
			this.multiEditorRowProperties1.set_Padding(new Padding(0));
			this.multiEditorRowProperties1.set_Width(100);
			this.multiEditorRowProperties2.set_Caption("CEP");
			this.multiEditorRowProperties2.set_FieldName("tel");
			this.multiEditorRowProperties2.set_Padding(new Padding(0));
			this.multiEditorRowProperties2.set_Width(94);
			this.multiEditorRowProperties3.set_Caption("FAX");
			this.multiEditorRowProperties3.set_FieldName("fax");
			this.multiEditorRowProperties3.set_Padding(new Padding(0));
			this.multiEditorRowProperties3.set_Width(97);
			this.multiEditorRowProperties4.set_Caption("EMAİL");
			this.multiEditorRowProperties4.set_FieldName("email");
			this.multiEditorRowProperties4.set_Padding(new Padding(0));
			this.multiEditorRowProperties4.set_Width(96);
			this.row5.set_Name("row5");
			this.row5.get_PropertiesCollection().AddRange(new MultiEditorRowProperties[]
			{
				this.multiEditorRowProperties7,
				this.multiEditorRowProperties8
			});
			this.multiEditorRowProperties7.set_Caption("HYB BELGE TARİHİ");
			this.multiEditorRowProperties7.set_FieldName("hybtar");
			this.multiEditorRowProperties7.set_Padding(new Padding(0));
			this.multiEditorRowProperties8.set_Caption("HYB BELGE NO");
			this.multiEditorRowProperties8.set_FieldName("hybno");
			this.multiEditorRowProperties8.set_Padding(new Padding(0));
			this.row8.set_Name("row8");
			this.row8.get_PropertiesCollection().AddRange(new MultiEditorRowProperties[]
			{
				this.multiEditorRowProperties9,
				this.multiEditorRowProperties10
			});
			this.multiEditorRowProperties9.set_Caption("SANAYİ SİCİL BEL. TAR.");
			this.multiEditorRowProperties9.set_FieldName("santar");
			this.multiEditorRowProperties9.set_Padding(new Padding(0));
			this.multiEditorRowProperties10.set_Caption("SANAYİ SİCİL BELGE NO");
			this.multiEditorRowProperties10.set_FieldName("sanno");
			this.multiEditorRowProperties10.set_Padding(new Padding(0));
			this.row6.set_Name("row6");
			this.row6.get_PropertiesCollection().AddRange(new MultiEditorRowProperties[]
			{
				this.multiEditorRowProperties11,
				this.multiEditorRowProperties12
			});
			this.multiEditorRowProperties11.set_Caption("CE ALDIĞINIZ FİRMANIN ADI");
			this.multiEditorRowProperties11.set_FieldName("onkurulusad");
			this.multiEditorRowProperties11.set_Padding(new Padding(0));
			this.multiEditorRowProperties12.set_Caption("CE ALD. FİRMA NO");
			this.multiEditorRowProperties12.set_FieldName("onkurulusno");
			this.multiEditorRowProperties12.set_Padding(new Padding(0));
			this.category.get_ChildRows().AddRange(new BaseRow[]
			{
				this.row7,
				this.row9,
				this.row10,
				this.row11
			});
			this.category.set_Name("category");
			this.category.get_Properties().set_Caption("MAKİNE MÜHENDİSİ BİLGİLERİ");
			this.category.get_Properties().set_Padding(new Padding(0));
			this.row7.set_Name("row7");
			this.row7.get_Properties().set_Caption("MAKİNE MÜH.ADI SOYADI");
			this.row7.get_Properties().set_FieldName("mmad");
			this.row7.get_Properties().set_Padding(new Padding(0));
			this.row9.set_Name("row9");
			this.row9.get_Properties().set_Caption("MAKİNE MÜH. ODA NO");
			this.row9.get_Properties().set_FieldName("mmoda");
			this.row9.get_Properties().set_Padding(new Padding(0));
			this.row10.set_Name("row10");
			this.row10.get_Properties().set_Caption("MAKİNE MÜH. BELGE NO");
			this.row10.get_Properties().set_FieldName("mmbel");
			this.row10.get_Properties().set_Padding(new Padding(0));
			this.row11.set_Name("row11");
			this.row11.get_Properties().set_Caption("MAKİNE MÜH. SMM NO");
			this.row11.get_Properties().set_FieldName("mmsmm");
			this.row11.get_Properties().set_Padding(new Padding(0));
			this.category1.get_ChildRows().AddRange(new BaseRow[]
			{
				this.row12,
				this.row13,
				this.row14,
				this.row15
			});
			this.category1.set_Name("category1");
			this.category1.get_Properties().set_Caption("ELEKTİRİK MÜHENDİSİ BİLGİLERİ");
			this.category1.get_Properties().set_Padding(new Padding(0));
			this.row12.set_Name("row12");
			this.row12.get_Properties().set_Caption("ELEKTİRİK MÜHENDİSİ ADI SOYADI");
			this.row12.get_Properties().set_FieldName("emad");
			this.row12.get_Properties().set_Padding(new Padding(0));
			this.row13.set_Name("row13");
			this.row13.get_Properties().set_Caption("ELEKTİRİK MÜHENDİSİ ODA NO");
			this.row13.get_Properties().set_FieldName("emoda");
			this.row13.get_Properties().set_Padding(new Padding(0));
			this.row14.set_Name("row14");
			this.row14.get_Properties().set_Caption("ELEKTİRİK MÜHENDİSİ BELGE NO");
			this.row14.get_Properties().set_FieldName("embel");
			this.row14.get_Properties().set_Padding(new Padding(0));
			this.row15.set_Name("row15");
			this.row15.get_Properties().set_Caption("ELEKTİRİK MÜHENDİSİ SMM NO");
			this.row15.get_Properties().set_FieldName("emsmm");
			this.row15.get_Properties().set_Padding(new Padding(0));
			this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			this.xtraTabControl1.get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.xtraTabControl1.get_Appearance().get_Options().set_UseFont(true);
			this.xtraTabControl1.get_AppearancePage().get_Header().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.xtraTabControl1.get_AppearancePage().get_Header().get_Options().set_UseFont(true);
			this.xtraTabControl1.Dock = DockStyle.Fill;
			this.xtraTabControl1.Location = new Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.set_SelectedTabPage(this.xtraTabPage1);
			this.xtraTabControl1.Size = new Size(1004, 473);
			this.xtraTabControl1.TabIndex = 1002;
			this.xtraTabControl1.get_TabPages().AddRange(new XtraTabPage[]
			{
				this.xtraTabPage1,
				this.xtraTabPage2,
				this.xtraTabPage3,
				this.xtraTabPage4
			});
			this.xtraTabPage1.get_Appearance().get_PageClient().set_BackColor(SystemColors.ControlDark);
			this.xtraTabPage1.get_Appearance().get_PageClient().get_Options().set_UseBackColor(true);
			this.xtraTabPage1.Controls.Add(this.groupControl2);
			this.xtraTabPage1.Controls.Add(this.groupControl3);
			this.xtraTabPage1.Controls.Add(this.groupControl6);
			this.xtraTabPage1.Controls.Add(this.panel1);
			this.xtraTabPage1.Controls.Add(this.panel2);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.set_Size(new Size(998, 442));
			this.xtraTabPage1.Text = "GENEL VERİLER";
			this.groupControl2.get_AppearanceCaption().set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
			this.groupControl2.get_AppearanceCaption().set_ForeColor(Color.FromArgb(192, 0, 0));
			this.groupControl2.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.groupControl2.get_AppearanceCaption().get_Options().set_UseForeColor(true);
			this.groupControl2.Controls.Add(this.layoutControl2);
			this.groupControl2.Location = new Point(619, 3);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new Size(376, 293);
			this.groupControl2.TabIndex = 1003;
			this.groupControl2.Text = "ASANSÖR GENEL BİLGİLERİ";
			this.xtraTabPage2.Controls.Add(this.layoutControl4);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.set_Size(new Size(998, 442));
			this.xtraTabPage2.Text = "KAT BİLGİLERİ";
			this.xtraTabPage3.Controls.Add(this.ayargrid);
			this.xtraTabPage3.Controls.Add(this.groupControl1);
			this.xtraTabPage3.Controls.Add(this.AydinlatmaBizde);
			this.xtraTabPage3.Controls.Add(this.BesPanoVar);
			this.xtraTabPage3.Name = "xtraTabPage3";
			this.xtraTabPage3.set_Size(new Size(998, 442));
			this.xtraTabPage3.Text = "AYARLAR";
			this.ayargrid.Dock = DockStyle.Left;
			this.ayargrid.Location = new Point(0, 0);
			this.ayargrid.set_MainView(this.gridView1);
			this.ayargrid.Name = "ayargrid";
			this.ayargrid.Size = new Size(331, 442);
			this.ayargrid.TabIndex = 158;
			this.ayargrid.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView1
			});
			this.gridView1.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Row().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView1.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn79,
				this.gridColumn80,
				this.gridColumn81
			});
			this.gridView1.set_GridControl(this.ayargrid);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsView().set_ShowColumnHeaders(false);
			this.gridView1.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView1.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView1_CellValueChanged));
			this.gridColumn79.get_AppearanceCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridColumn79.get_AppearanceCell().get_Options().set_UseFont(true);
			this.gridColumn79.set_Caption("gridColumn1");
			this.gridColumn79.set_FieldName("formvisual");
			this.gridColumn79.set_Name("gridColumn79");
			this.gridColumn79.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn79.set_Visible(true);
			this.gridColumn79.set_VisibleIndex(0);
			this.gridColumn80.set_Caption("gridColumn2");
			this.gridColumn80.set_FieldName("ParamValue");
			this.gridColumn80.set_Name("gridColumn80");
			this.gridColumn80.set_Visible(true);
			this.gridColumn80.set_VisibleIndex(1);
			this.gridColumn81.set_Caption("gridColumn3");
			this.gridColumn81.set_FieldName("ParamName");
			this.gridColumn81.set_Name("gridColumn81");
			this.xtraTabPage4.Controls.Add(this.labelControl2);
			this.xtraTabPage4.Controls.Add(this.firmabilgigrid);
			this.xtraTabPage4.Name = "xtraTabPage4";
			this.xtraTabPage4.set_Size(new Size(990, 442));
			this.xtraTabPage4.Text = "LİSANS BİLGİLERİ";
			this.labelControl2.Location = new Point(11, 358);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new Size(74, 13);
			this.labelControl2.TabIndex = 1003;
			this.labelControl2.Text = "LİSANS SÜRESİ";
			this.ımageList2.ColorDepth = ColorDepth.Depth8Bit;
			this.ımageList2.ImageSize = new Size(16, 16);
			this.ımageList2.TransparentColor = Color.Transparent;
			this.layoutControlItem16.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem16.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem16.set_Control(this.DurakSayi);
			this.layoutControlItem16.set_Location(new Point(0, 180));
			this.layoutControlItem16.set_Name("layoutControlItem16");
			this.layoutControlItem16.set_Size(new Size(221, 27));
			this.layoutControlItem16.set_Text("DURAK SAYISI");
			this.layoutControlItem16.set_TextSize(new Size(136, 16));
			this.layoutControlItem17.set_Control(this.simpleButton2);
			this.layoutControlItem17.set_Location(new Point(221, 180));
			this.layoutControlItem17.set_Name("layoutControlItem17");
			this.layoutControlItem17.set_Size(new Size(68, 27));
			this.layoutControlItem17.set_TextSize(new Size(0, 0));
			this.layoutControlItem17.set_TextVisible(false);
			this.layoutControlItem18.set_Control(this.simpleButton1);
			this.layoutControlItem18.set_Location(new Point(289, 180));
			this.layoutControlItem18.set_Name("layoutControlItem18");
			this.layoutControlItem18.set_Size(new Size(72, 27));
			this.layoutControlItem18.set_TextSize(new Size(0, 0));
			this.layoutControlItem18.set_TextVisible(false);
			this.layoutControlItem19.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem19.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem19.set_Control(this.IlkDurakNo);
			this.layoutControlItem19.set_Location(new Point(0, 207));
			this.layoutControlItem19.set_Name("layoutControlItem19");
			this.layoutControlItem19.set_Size(new Size(221, 27));
			this.layoutControlItem19.set_Text("İLK DURAK NO");
			this.layoutControlItem19.set_TextSize(new Size(136, 16));
			this.layoutControlItem20.set_Control(this.simpleButton4);
			this.layoutControlItem20.set_Location(new Point(221, 207));
			this.layoutControlItem20.set_Name("layoutControlItem20");
			this.layoutControlItem20.set_Size(new Size(68, 27));
			this.layoutControlItem20.set_TextSize(new Size(0, 0));
			this.layoutControlItem20.set_TextVisible(false);
			this.layoutControlItem21.set_Control(this.simpleButton3);
			this.layoutControlItem21.set_Location(new Point(289, 207));
			this.layoutControlItem21.set_Name("layoutControlItem21");
			this.layoutControlItem21.set_Size(new Size(72, 27));
			this.layoutControlItem21.set_TextSize(new Size(0, 0));
			this.layoutControlItem21.set_TextVisible(false);
			this.layoutControlItem23.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem23.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem23.set_Control(this.ToplamYuk);
			this.layoutControlItem23.set_Location(new Point(0, 234));
			this.layoutControlItem23.set_Name("layoutControlItem23");
			this.layoutControlItem23.set_Size(new Size(361, 34));
			this.layoutControlItem23.set_Text("TOPLAM KUYU BOYU :");
			this.layoutControlItem23.set_TextSize(new Size(136, 16));
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1004, 473);
			base.Controls.Add(this.xtraTabControl1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ascadform";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ASCAD FORM";
			base.FormClosing += new FormClosingEventHandler(this.ascadform_FormClosing);
			base.Load += new EventHandler(this.ascadform_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupControl3.EndInit();
			this.groupControl3.ResumeLayout(false);
			this.layoutControl9.EndInit();
			this.layoutControl9.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.layoutControlGroup9.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControl5.EndInit();
			this.layoutControl5.ResumeLayout(false);
			this.layoutControlGroup5.EndInit();
			this.layoutControlItem45.EndInit();
			this.layoutControlItem46.EndInit();
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.AgrTamponu.get_Properties().EndInit();
			this.KabinTamponu.get_Properties().EndInit();
			this.AgrRayStr.get_Properties().EndInit();
			this.KuyuDer.get_Properties().EndInit();
			this.KabinRayStr.get_Properties().EndInit();
			this.KuyuGen.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem111.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem114.EndInit();
			this.layoutControlItem113.EndInit();
			this.layoutControlItem115.EndInit();
			this.layoutControlItem10.EndInit();
			this.layoutControlItem15.EndInit();
			this.layoutControl2.EndInit();
			this.layoutControl2.ResumeLayout(false);
			this.checkEdit1.get_Properties().EndInit();
			this.textEdit2.get_Properties().EndInit();
			this.RegYer.get_Properties().EndInit();
			this.Mentese.get_Properties().EndInit();
			this.KapiGen.get_Properties().EndInit();
			this.otokapitipi.get_Properties().EndInit();
			this.asnkapitipi.get_Properties().EndInit();
			this.TahCap.get_Properties().EndInit();
			this.SapCap.get_Properties().EndInit();
			this.layoutControlGroup2.EndInit();
			this.layoutControlItem11.EndInit();
			this.layoutControlItem22.EndInit();
			this.layoutControlItem27.EndInit();
			this.layoutControlItem28.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem9.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem12.EndInit();
			this.layoutControlItem13.EndInit();
			this.layoutControlItem14.EndInit();
			this.groupControl6.EndInit();
			this.groupControl6.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.HAMDControl.EndInit();
			this.HAMDControl.ResumeLayout(false);
			this.layoutControl8.EndInit();
			this.layoutControl8.ResumeLayout(false);
			this.txtHAMDDer.get_Properties().EndInit();
			this.txtHAMDGen.get_Properties().EndInit();
			this.layoutControlGroup8.EndInit();
			this.layoutControlItem62.EndInit();
			this.layoutControlItem64.EndInit();
			this.layoutControlItem65.EndInit();
			this.layoutControlItem66.EndInit();
			this.layoutControl4.EndInit();
			this.layoutControl4.ResumeLayout(false);
			this.IskeleVar.get_Properties().EndInit();
			this.DengeZinciri.get_Properties().EndInit();
			this.ToplamYuk.get_Properties().EndInit();
			this.SeyirMesafesi.get_Properties().EndInit();
			((ISupportInitialize)this.pictureBox2).EndInit();
			this.gridControl1.EndInit();
			this.gridView4.EndInit();
			this.MdTabTavan.get_Properties().EndInit();
			this.SonKat.get_Properties().EndInit();
			this.AraKatSTR.get_Properties().EndInit();
			this.TopKuyuKafa.get_Properties().EndInit();
			this.KuyuDibi.get_Properties().EndInit();
			this.DurakSayi.get_Properties().EndInit();
			this.KatH.get_Properties().EndInit();
			this.IlkDurakNo.get_Properties().EndInit();
			this.layoutControlGroup4.EndInit();
			this.layoutControlItem36.EndInit();
			this.layoutControlItem37.EndInit();
			this.layoutControlItem38.EndInit();
			this.layoutControlItem42.EndInit();
			this.layoutControlItem43.EndInit();
			this.layoutControlItem44.EndInit();
			this.layoutControlItem68.EndInit();
			this.layoutControlItem82.EndInit();
			this.layoutControlItem125.EndInit();
			this.layoutControlItem40.EndInit();
			this.layoutControlItem41.EndInit();
			this.BesPanoVar.get_Properties().EndInit();
			this.AydinlatmaBizde.get_Properties().EndInit();
			this.groupControl1.EndInit();
			this.groupControl1.ResumeLayout(false);
			this.firmabilgigrid.EndInit();
			this.xtraTabControl1.EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.groupControl2.EndInit();
			this.groupControl2.ResumeLayout(false);
			this.xtraTabPage2.ResumeLayout(false);
			this.xtraTabPage3.ResumeLayout(false);
			this.ayargrid.EndInit();
			this.gridView1.EndInit();
			this.xtraTabPage4.ResumeLayout(false);
			this.xtraTabPage4.PerformLayout();
			this.layoutControlItem16.EndInit();
			this.layoutControlItem17.EndInit();
			this.layoutControlItem18.EndInit();
			this.layoutControlItem19.EndInit();
			this.layoutControlItem20.EndInit();
			this.layoutControlItem21.EndInit();
			this.layoutControlItem23.EndInit();
			base.ResumeLayout(false);
		}
	}
}
