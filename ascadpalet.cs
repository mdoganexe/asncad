using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class ascadpalet : UserControl
	{
		public ascad AscadDLL;

		private abc1 xx2 = new abc1();

		private List<string> objelistesi = new List<string>();

		private double kabinalan = 0.0;

		private int layeracikcolumn;

		private int layeradcolumn;

		private IContainer components = null;

		private SimpleButton submitbutton;

		private XtraTabControl ObjectDefine;

		private XtraTabPage xtraTabPage1;

		private XtraTabPage xtraTabPage2;

		private XtraTabPage xtraTabPage3;

		private XtraTabPage xtraTabPage4;

		private XtraTabPage xtraTabPage5;

		private XtraTabPage xtraTabPage6;

		private LayoutControl layoutControl2;

		private TextEdit HalatCap;

		private LabelControl labelControl17;

		private LabelControl labelControl15;

		private LabelControl labelControl14;

		private LabelControl labelControl4;

		private LabelControl labelControl13;

		private LinkLabel pqtop;

		private LabelControl labelControl12;

		private LabelControl labelControl7;

		private LabelControl labelControl8;

		private LabelControl labelControl2;

		private LabelControl labelControl3;

		private LabelControl labelControl1;

		private TextEdit TahCap;

		private TextEdit HalatAdet;

		private TextEdit SapCap;

		private TextEdit MotorKw;

		private LabelControl labelControl11;

		private TextEdit KabinP;

		private TextEdit BeyanHiz;

		private TextEdit BeyanYuk;

		private LinkLabel linkLabel1;

		private LayoutControlGroup layoutControlGroup2;

		private LayoutControlItem layoutControlItem3;

		private LayoutControlItem layoutControlItem8;

		private LayoutControlItem layoutControlItem10;

		private LayoutControlItem layoutControlItem12;

		private LayoutControlItem layoutControlItem16;

		private LayoutControlItem layoutControlItem18;

		private LayoutControlItem layoutControlItem20;

		private LayoutControlItem layoutControlItem21;

		private LayoutControlItem layoutControlItem4;

		private LayoutControlItem layoutControlItem5;

		private LayoutControlItem layoutControlItem13;

		private LayoutControlItem layoutControlItem14;

		private LayoutControlItem layoutControlItem15;

		private LayoutControlItem layoutControlItem17;

		private LayoutControlItem layoutControlItem19;

		private LayoutControlItem layoutControlItem11;

		private LayoutControlItem layoutControlItem22;

		private LayoutControlItem layoutControlItem23;

		private LayoutControlItem layoutControlItem25;

		private LayoutControlItem layoutControlItem27;

		private LayoutControlItem layoutControlItem28;

		private LayoutControlItem layoutControlItem29;

		private LayoutControlItem layoutControlItem30;

		private LayoutControlItem layoutControlItem32;

		private LayoutControlItem layoutControlItem116;

		private CheckEdit beyamqpisuserdefined;

		private LayoutControlItem layoutControlItem6;

		private XtraTabPage xtraTabPage7;

		private SimpleButton simpleButton1;

		private TreeList kesitlayertree;

		private TreeListColumn treeListColumn1;

		private TreeListColumn treeListColumn2;

		private TreeListColumn treeListColumn3;

		private TreeListColumn treeListColumn4;

		private SearchLookUpEdit kesitlayeryapi;

		private GridView searchLookUpEdit1View;

		private TreeListColumn treeListColumn5;

		private SimpleButton simpleButton2;

		public TextEdit kabinderx;

		public TextEdit kabingenx;

		private TextEdit BeyanKisi;

		private SimpleButton simpleButton18;

		private LayoutControlItem layoutControlItem34;

		private XtraTabPage xtraTabPage8;

		private GridControl antetgrid;

		private GridView gridView1;

		private GridColumn gridColumn1;

		private GridColumn gridColumn2;

		private GridColumn gridColumn3;

		private TextEdit dengekatsay;

		private LabelControl labelControl25;

		private LabelControl labelControl24;

		private TextEdit karkasagr;

		private TextEdit agrtaneagr;

		private SimpleButton simpleButton3;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem33;

		private LayoutControlItem layoutControlItem2;

		private LayoutControlItem layoutControlItem7;

		private LayoutControlItem layoutControlItem9;

		private LayoutControlItem layoutControlItem31;

		private GroupControl groupControl13;

		private LayoutControl layoutControl7;

		private CheckEdit KapiKirisProfil;

		private CheckEdit KapiKorKasa;

		private TextEdit KasaDer;

		private TextEdit KasaGen;

		private TextEdit KapiH;

		private TextEdit KizakKalin;

		private TextEdit ToplamKalin;

		private TextEdit OtoKabinEsik;

		private LayoutControlGroup layoutControlGroup7;

		private LayoutControlItem layoutControlItem61;

		private LayoutControlItem layoutControlItem63;

		private LayoutControlItem layoutControlItem109;

		private LayoutControlItem layoutControlItem110;

		private LayoutControlItem layoutControlItem117;

		private LayoutControlItem layoutControlItem118;

		private LayoutControlItem layoutControlItem129;

		private LayoutControlItem layoutControlItem130;

		private LabelControl labelControl5;

		private LayoutControlItem layoutControlItem24;

		private LayoutControlItem layoutControlItem26;

		private Label label1;

		private LayoutControlItem layoutControlItem35;

		public ascadpalet()
		{
			this.InitializeComponent();
		}

		private void veriesit(DataTable gelentab, TextEdit tee)
		{
			for (int i = 0; i < gelentab.Rows.Count; i++)
			{
				bool flag = gelentab.Rows[i][0].ToString() == tee.Name;
				if (flag)
				{
					tee.set_EditValue(gelentab.Rows[i][1]);
				}
			}
		}

		private int dondurbana(string gelen)
		{
			int result = 0;
			bool flag = this.objelistesi.Count == 0;
			if (flag)
			{
				this.objelistesi.Add("Gorsel");
				this.objelistesi.Add("Ozellik");
				this.objelistesi.Add("CizimBilgi");
				this.objelistesi.Add("RegUst");
				this.objelistesi.Add("Suspansiyon");
				this.objelistesi.Add("KabinRay");
				this.objelistesi.Add("Kar");
				this.objelistesi.Add("KapiIc");
				this.objelistesi.Add("AgrUst");
				this.objelistesi.Add("Tampon");
			}
			bool flag2 = this.objelistesi.Contains(gelen);
			if (flag2)
			{
				result = this.objelistesi.IndexOf(gelen);
			}
			return result;
		}

		public void objedefiner(string gelen)
		{
			this.pageshow(this.dondurbana(gelen));
		}

		private void pageshow(int psgrindex)
		{
			bool flag = psgrindex > 2;
			if (flag)
			{
				for (int i = 2; i < this.ObjectDefine.get_TabPages().Count; i++)
				{
					this.ObjectDefine.get_TabPages().get_Item(i).set_PageVisible(false);
				}
				this.ObjectDefine.get_TabPages().get_Item(psgrindex).set_PageVisible(true);
				this.ObjectDefine.set_SelectedTabPage(this.ObjectDefine.get_TabPages().get_Item(psgrindex));
			}
		}

		private void kabingen_EditValueChanged(object sender, EventArgs e)
		{
			this.kabinalan = Convert.ToDouble(this.kabinderx.Text) * Convert.ToDouble(this.kabingenx.Text) / 1000000.0;
			this.linkLabel1.Text = "KABİN ALANI : " + this.kabinalan.ToString("n2");
			bool flag = !this.beyamqpisuserdefined.get_Checked();
			if (flag)
			{
				bool flag2 = 0.49 <= this.kabinalan && this.kabinalan <= 0.58;
				if (flag2)
				{
					this.BeyanYuk.Text = 180.ToString();
					this.BeyanKisi.Text = 3.ToString();
				}
				bool flag3 = 0.6 <= this.kabinalan && this.kabinalan <= 0.7;
				if (flag3)
				{
					this.BeyanYuk.Text = 225.ToString();
					this.BeyanKisi.Text = 3.ToString();
				}
				bool flag4 = 0.79 <= this.kabinalan && this.kabinalan <= 0.9;
				if (flag4)
				{
					this.BeyanYuk.Text = 300.ToString();
					this.BeyanKisi.Text = 4.ToString();
				}
				bool flag5 = 0.9 <= this.kabinalan && this.kabinalan <= 0.98;
				if (flag5)
				{
					this.BeyanYuk.Text = 320.ToString();
					this.BeyanKisi.Text = 5.ToString();
				}
				bool flag6 = 0.98 <= this.kabinalan && this.kabinalan <= 1.1;
				if (flag6)
				{
					this.BeyanYuk.Text = 375.ToString();
					this.BeyanKisi.Text = 5.ToString();
				}
				bool flag7 = 1.1 <= this.kabinalan && this.kabinalan <= 1.17;
				if (flag7)
				{
					this.BeyanYuk.Text = 400.ToString();
					this.BeyanKisi.Text = 5.ToString();
				}
				bool flag8 = 1.17 <= this.kabinalan && this.kabinalan <= 1.3;
				if (flag8)
				{
					this.BeyanYuk.Text = 450.ToString();
					this.BeyanKisi.Text = 6.ToString();
				}
				bool flag9 = 1.31 <= this.kabinalan && this.kabinalan <= 1.45;
				if (flag9)
				{
					this.BeyanYuk.Text = 525.ToString();
					this.BeyanKisi.Text = 7.ToString();
				}
				bool flag10 = 1.45 <= this.kabinalan && this.kabinalan <= 1.6;
				if (flag10)
				{
					this.BeyanYuk.Text = 600.ToString();
					this.BeyanKisi.Text = 8.ToString();
				}
				bool flag11 = 1.6 <= this.kabinalan && this.kabinalan <= 1.66;
				if (flag11)
				{
					this.BeyanYuk.Text = 630.ToString();
					this.BeyanKisi.Text = 8.ToString();
				}
				bool flag12 = 1.59 <= this.kabinalan && this.kabinalan <= 1.75;
				if (flag12)
				{
					this.BeyanYuk.Text = 675.ToString();
					this.BeyanKisi.Text = 9.ToString();
				}
				bool flag13 = 1.73 <= this.kabinalan && this.kabinalan <= 1.9;
				if (flag13)
				{
					this.BeyanYuk.Text = 750.ToString();
					this.BeyanKisi.Text = 10.ToString();
				}
				bool flag14 = 1.9 <= this.kabinalan && this.kabinalan <= 2.0;
				if (flag14)
				{
					this.BeyanYuk.Text = 800.ToString();
					this.BeyanKisi.Text = 10.ToString();
				}
				bool flag15 = 1.87 <= this.kabinalan && this.kabinalan <= 2.05;
				if (flag15)
				{
					this.BeyanYuk.Text = 825.ToString();
					this.BeyanKisi.Text = 11.ToString();
				}
				bool flag16 = 2.01 <= this.kabinalan && this.kabinalan <= 2.2;
				if (flag16)
				{
					this.BeyanYuk.Text = 900.ToString();
					this.BeyanKisi.Text = 12.ToString();
				}
				bool flag17 = 2.15 <= this.kabinalan && this.kabinalan <= 2.35;
				if (flag17)
				{
					this.BeyanYuk.Text = 975.ToString();
					this.BeyanKisi.Text = 13.ToString();
				}
				bool flag18 = 2.35 <= this.kabinalan && this.kabinalan <= 2.4;
				if (flag18)
				{
					this.BeyanYuk.Text = 1000.ToString();
					this.BeyanKisi.Text = 13.ToString();
				}
				bool flag19 = 2.29 <= this.kabinalan && this.kabinalan <= 2.5;
				if (flag19)
				{
					this.BeyanYuk.Text = 1050.ToString();
					this.BeyanKisi.Text = 14.ToString();
				}
				bool flag20 = 2.43 <= this.kabinalan && this.kabinalan <= 2.65;
				if (flag20)
				{
					this.BeyanYuk.Text = 1125.ToString();
					this.BeyanKisi.Text = 15.ToString();
				}
				bool flag21 = 2.57 <= this.kabinalan && this.kabinalan <= 2.8;
				if (flag21)
				{
					this.BeyanYuk.Text = 1200.ToString();
					this.BeyanKisi.Text = 16.ToString();
				}
				bool flag22 = 2.8 <= this.kabinalan && this.kabinalan <= 2.9;
				if (flag22)
				{
					this.BeyanYuk.Text = 1250.ToString();
					this.BeyanKisi.Text = 16.ToString();
				}
				bool flag23 = 2.71 <= this.kabinalan && this.kabinalan <= 2.95;
				if (flag23)
				{
					this.BeyanYuk.Text = 1275.ToString();
					this.BeyanKisi.Text = 17.ToString();
				}
				bool flag24 = 2.85 <= this.kabinalan && this.kabinalan <= 3.1;
				if (flag24)
				{
					this.BeyanYuk.Text = 1350.ToString();
					this.BeyanKisi.Text = 18.ToString();
				}
				bool flag25 = 2.99 <= this.kabinalan && this.kabinalan <= 3.25;
				if (flag25)
				{
					this.BeyanYuk.Text = 1425.ToString();
					this.BeyanKisi.Text = 19.ToString();
				}
				bool flag26 = 3.13 <= this.kabinalan && this.kabinalan <= 3.4;
				if (flag26)
				{
					this.BeyanYuk.Text = 1500.ToString();
					this.BeyanKisi.Text = 20.ToString();
				}
				bool flag27 = 3.24 <= this.kabinalan && this.kabinalan <= 3.45;
				if (flag27)
				{
					this.BeyanYuk.Text = 1575.ToString();
					this.BeyanKisi.Text = 21.ToString();
				}
				bool flag28 = 3.36 <= this.kabinalan && this.kabinalan <= 3.56;
				if (flag28)
				{
					this.BeyanYuk.Text = 1600.ToString();
					this.BeyanKisi.Text = 22.ToString();
				}
				bool flag29 = 3.36 <= this.kabinalan && this.kabinalan <= 3.68;
				if (flag29)
				{
					this.BeyanYuk.Text = 1650.ToString();
					this.BeyanKisi.Text = 22.ToString();
				}
				bool flag30 = 3.47 <= this.kabinalan && this.kabinalan <= 3.8;
				if (flag30)
				{
					this.BeyanYuk.Text = 1725.ToString();
					this.BeyanKisi.Text = 23.ToString();
				}
				bool flag31 = 3.59 <= this.kabinalan && this.kabinalan <= 3.92;
				if (flag31)
				{
					this.BeyanYuk.Text = 1800.ToString();
					this.BeyanKisi.Text = 24.ToString();
				}
				bool flag32 = 3.7 <= this.kabinalan && this.kabinalan <= 4.04;
				if (flag32)
				{
					this.BeyanYuk.Text = 1875.ToString();
					this.BeyanKisi.Text = 25.ToString();
				}
				bool flag33 = 3.82 <= this.kabinalan && this.kabinalan <= 4.16;
				if (flag33)
				{
					this.BeyanYuk.Text = 1950.ToString();
					this.BeyanKisi.Text = 26.ToString();
				}
				bool flag34 = 3.87 <= this.kabinalan && this.kabinalan <= 4.2;
				if (flag34)
				{
					this.BeyanYuk.Text = 2000.ToString();
					this.BeyanKisi.Text = 26.ToString();
				}
				bool flag35 = 3.93 <= this.kabinalan && this.kabinalan <= 4.32;
				if (flag35)
				{
					this.BeyanYuk.Text = 2025.ToString();
					this.BeyanKisi.Text = 27.ToString();
				}
				this.pqtop.Text = "P+Q AĞIRLIK = " + (Convert.ToInt32(this.BeyanYuk.Text) + Convert.ToInt32(this.KabinP.Text)).ToString() + " KG";
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			new tsestandart
			{
				kabinderstr = this.kabinderx.Text,
				kabingenstr = this.kabingenx.Text
			}.ShowDialog();
		}

		private void ascadpalet_Load(object sender, EventArgs e)
		{
			this.kesitlayertree.set_DataSource(this.xx2.dtta("select * from kesitler", ""));
			this.kesitlayertree.ExpandAll();
			this.antetgrid.set_DataSource(this.xx2.dtta("select * from Num1 where Comment='ANTET'", ""));
			this.layeracikcolumn = this.kesitlayertree.get_Columns().get_Item("aktifmi").get_AbsoluteIndex();
			this.layeracikcolumn = this.kesitlayertree.get_Columns().get_Item("layername").get_AbsoluteIndex();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.xx2.SetNumValue("TahCap", "", "1");
			this.xx2.SetNumValue("SapCap", "", "1");
			this.xx2.SetNumValue("MotorKw", "", "1");
			this.xx2.SetNumValue("HalatAdet", "", "1");
			this.xx2.SetNumValue("HalatCap", "", "1");
			this.xx2.SetNumValue("agrtaneagr", "", "1");
			this.xx2.SetNumValue("dengekatsay", "", "1");
		}

		private void beyamqpisuserdefined_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.beyamqpisuserdefined.get_Checked();
			if (@checked)
			{
				this.BeyanYuk.Enabled = true;
				this.BeyanKisi.Enabled = true;
			}
		}

		private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			this.xx2.oleupdate(string.Concat(new string[]
			{
				"update Num1 set ",
				e.get_Column().get_FieldName(),
				" ='",
				e.get_Value().ToString(),
				"' where ParamName='",
				this.gridView1.GetRowCellValue(e.get_RowHandle(), "ParamName").ToString(),
				"'"
			}), "");
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			asnseccrm asnseccrm = new asnseccrm();
			asnseccrm.ShowDialog();
			string asansorno = asnseccrm.asansorno;
			string dwgid = asnseccrm.dwgid;
		}

		private void agirlikhesapla()
		{
			try
			{
				decimal num = Convert.ToDecimal(this.KabinP.Text) - Convert.ToDecimal(this.karkasagr.Text) + Convert.ToDecimal(this.BeyanYuk.Text) * Convert.ToDecimal(this.dengekatsay.Text);
				num /= Convert.ToDecimal(this.agrtaneagr.Text);
				num = Math.Round(num, 0, MidpointRounding.AwayFromZero);
				this.labelControl5.Text = "GEREKLİ AĞIRLIK ADEDİ : " + num;
			}
			catch (Exception)
			{
			}
		}

		private void simpleButton18_Click(object sender, EventArgs e)
		{
		}

		private void BeyanYuk_EditValueChanged(object sender, EventArgs e)
		{
			this.agirlikhesapla();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.kesitlayertree.get_Nodes().get_Count(); i++)
			{
				bool flag = this.kesitlayertree.get_Nodes().get_ParentNode() == null;
				if (!flag)
				{
					bool flag2 = (bool)this.kesitlayertree.get_Nodes().get_Item(i).GetValue(this.layeracikcolumn);
					if (flag2)
					{
						this.kesitlayertree.get_Nodes().get_Item(i).GetValue(this.layeracikcolumn);
					}
					else
					{
						this.kesitlayertree.get_Nodes().get_Item(i).GetValue(this.layeracikcolumn);
					}
				}
			}
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
			this.submitbutton = new SimpleButton();
			this.ObjectDefine = new XtraTabControl();
			this.xtraTabPage1 = new XtraTabPage();
			this.antetgrid = new GridControl();
			this.gridView1 = new GridView();
			this.gridColumn1 = new GridColumn();
			this.gridColumn2 = new GridColumn();
			this.gridColumn3 = new GridColumn();
			this.xtraTabPage6 = new XtraTabPage();
			this.layoutControl2 = new LayoutControl();
			this.labelControl5 = new LabelControl();
			this.dengekatsay = new TextEdit();
			this.labelControl25 = new LabelControl();
			this.agrtaneagr = new TextEdit();
			this.labelControl24 = new LabelControl();
			this.simpleButton3 = new SimpleButton();
			this.karkasagr = new TextEdit();
			this.simpleButton18 = new SimpleButton();
			this.beyamqpisuserdefined = new CheckEdit();
			this.HalatCap = new TextEdit();
			this.labelControl17 = new LabelControl();
			this.labelControl15 = new LabelControl();
			this.labelControl14 = new LabelControl();
			this.labelControl4 = new LabelControl();
			this.labelControl13 = new LabelControl();
			this.pqtop = new LinkLabel();
			this.labelControl12 = new LabelControl();
			this.labelControl7 = new LabelControl();
			this.labelControl8 = new LabelControl();
			this.labelControl2 = new LabelControl();
			this.labelControl3 = new LabelControl();
			this.labelControl1 = new LabelControl();
			this.TahCap = new TextEdit();
			this.HalatAdet = new TextEdit();
			this.SapCap = new TextEdit();
			this.MotorKw = new TextEdit();
			this.labelControl11 = new LabelControl();
			this.KabinP = new TextEdit();
			this.kabingenx = new TextEdit();
			this.BeyanHiz = new TextEdit();
			this.BeyanYuk = new TextEdit();
			this.kabinderx = new TextEdit();
			this.linkLabel1 = new LinkLabel();
			this.BeyanKisi = new TextEdit();
			this.layoutControlGroup2 = new LayoutControlGroup();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem10 = new LayoutControlItem();
			this.layoutControlItem12 = new LayoutControlItem();
			this.layoutControlItem16 = new LayoutControlItem();
			this.layoutControlItem18 = new LayoutControlItem();
			this.layoutControlItem20 = new LayoutControlItem();
			this.layoutControlItem21 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem13 = new LayoutControlItem();
			this.layoutControlItem14 = new LayoutControlItem();
			this.layoutControlItem15 = new LayoutControlItem();
			this.layoutControlItem17 = new LayoutControlItem();
			this.layoutControlItem19 = new LayoutControlItem();
			this.layoutControlItem11 = new LayoutControlItem();
			this.layoutControlItem22 = new LayoutControlItem();
			this.layoutControlItem23 = new LayoutControlItem();
			this.layoutControlItem25 = new LayoutControlItem();
			this.layoutControlItem27 = new LayoutControlItem();
			this.layoutControlItem28 = new LayoutControlItem();
			this.layoutControlItem29 = new LayoutControlItem();
			this.layoutControlItem30 = new LayoutControlItem();
			this.layoutControlItem32 = new LayoutControlItem();
			this.layoutControlItem116 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem34 = new LayoutControlItem();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem33 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem9 = new LayoutControlItem();
			this.layoutControlItem31 = new LayoutControlItem();
			this.layoutControlItem24 = new LayoutControlItem();
			this.xtraTabPage2 = new XtraTabPage();
			this.kesitlayeryapi = new SearchLookUpEdit();
			this.searchLookUpEdit1View = new GridView();
			this.kesitlayertree = new TreeList();
			this.treeListColumn1 = new TreeListColumn();
			this.treeListColumn2 = new TreeListColumn();
			this.treeListColumn3 = new TreeListColumn();
			this.treeListColumn5 = new TreeListColumn();
			this.treeListColumn4 = new TreeListColumn();
			this.simpleButton2 = new SimpleButton();
			this.simpleButton1 = new SimpleButton();
			this.xtraTabPage3 = new XtraTabPage();
			this.xtraTabPage4 = new XtraTabPage();
			this.xtraTabPage5 = new XtraTabPage();
			this.xtraTabPage7 = new XtraTabPage();
			this.xtraTabPage8 = new XtraTabPage();
			this.groupControl13 = new GroupControl();
			this.layoutControl7 = new LayoutControl();
			this.KapiKirisProfil = new CheckEdit();
			this.KapiKorKasa = new CheckEdit();
			this.KasaDer = new TextEdit();
			this.KasaGen = new TextEdit();
			this.KapiH = new TextEdit();
			this.KizakKalin = new TextEdit();
			this.ToplamKalin = new TextEdit();
			this.OtoKabinEsik = new TextEdit();
			this.layoutControlGroup7 = new LayoutControlGroup();
			this.layoutControlItem61 = new LayoutControlItem();
			this.layoutControlItem63 = new LayoutControlItem();
			this.layoutControlItem109 = new LayoutControlItem();
			this.layoutControlItem110 = new LayoutControlItem();
			this.layoutControlItem117 = new LayoutControlItem();
			this.layoutControlItem118 = new LayoutControlItem();
			this.layoutControlItem129 = new LayoutControlItem();
			this.layoutControlItem130 = new LayoutControlItem();
			this.layoutControlItem26 = new LayoutControlItem();
			this.label1 = new Label();
			this.layoutControlItem35 = new LayoutControlItem();
			this.ObjectDefine.BeginInit();
			this.ObjectDefine.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			this.antetgrid.BeginInit();
			this.gridView1.BeginInit();
			this.xtraTabPage6.SuspendLayout();
			this.layoutControl2.BeginInit();
			this.layoutControl2.SuspendLayout();
			this.dengekatsay.get_Properties().BeginInit();
			this.agrtaneagr.get_Properties().BeginInit();
			this.karkasagr.get_Properties().BeginInit();
			this.beyamqpisuserdefined.get_Properties().BeginInit();
			this.HalatCap.get_Properties().BeginInit();
			this.TahCap.get_Properties().BeginInit();
			this.HalatAdet.get_Properties().BeginInit();
			this.SapCap.get_Properties().BeginInit();
			this.MotorKw.get_Properties().BeginInit();
			this.KabinP.get_Properties().BeginInit();
			this.kabingenx.get_Properties().BeginInit();
			this.BeyanHiz.get_Properties().BeginInit();
			this.BeyanYuk.get_Properties().BeginInit();
			this.kabinderx.get_Properties().BeginInit();
			this.BeyanKisi.get_Properties().BeginInit();
			this.layoutControlGroup2.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem10.BeginInit();
			this.layoutControlItem12.BeginInit();
			this.layoutControlItem16.BeginInit();
			this.layoutControlItem18.BeginInit();
			this.layoutControlItem20.BeginInit();
			this.layoutControlItem21.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem13.BeginInit();
			this.layoutControlItem14.BeginInit();
			this.layoutControlItem15.BeginInit();
			this.layoutControlItem17.BeginInit();
			this.layoutControlItem19.BeginInit();
			this.layoutControlItem11.BeginInit();
			this.layoutControlItem22.BeginInit();
			this.layoutControlItem23.BeginInit();
			this.layoutControlItem25.BeginInit();
			this.layoutControlItem27.BeginInit();
			this.layoutControlItem28.BeginInit();
			this.layoutControlItem29.BeginInit();
			this.layoutControlItem30.BeginInit();
			this.layoutControlItem32.BeginInit();
			this.layoutControlItem116.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem34.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem33.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem9.BeginInit();
			this.layoutControlItem31.BeginInit();
			this.layoutControlItem24.BeginInit();
			this.xtraTabPage2.SuspendLayout();
			this.kesitlayeryapi.get_Properties().BeginInit();
			this.searchLookUpEdit1View.BeginInit();
			this.kesitlayertree.BeginInit();
			this.xtraTabPage8.SuspendLayout();
			this.groupControl13.BeginInit();
			this.groupControl13.SuspendLayout();
			this.layoutControl7.BeginInit();
			this.layoutControl7.SuspendLayout();
			this.KapiKirisProfil.get_Properties().BeginInit();
			this.KapiKorKasa.get_Properties().BeginInit();
			this.KasaDer.get_Properties().BeginInit();
			this.KasaGen.get_Properties().BeginInit();
			this.KapiH.get_Properties().BeginInit();
			this.KizakKalin.get_Properties().BeginInit();
			this.ToplamKalin.get_Properties().BeginInit();
			this.OtoKabinEsik.get_Properties().BeginInit();
			this.layoutControlGroup7.BeginInit();
			this.layoutControlItem61.BeginInit();
			this.layoutControlItem63.BeginInit();
			this.layoutControlItem109.BeginInit();
			this.layoutControlItem110.BeginInit();
			this.layoutControlItem117.BeginInit();
			this.layoutControlItem118.BeginInit();
			this.layoutControlItem129.BeginInit();
			this.layoutControlItem130.BeginInit();
			this.layoutControlItem26.BeginInit();
			this.layoutControlItem35.BeginInit();
			base.SuspendLayout();
			this.submitbutton.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.submitbutton.get_Appearance().get_Options().set_UseFont(true);
			this.submitbutton.Location = new Point(7, 705);
			this.submitbutton.Margin = new Padding(2);
			this.submitbutton.Name = "submitbutton";
			this.submitbutton.Size = new Size(297, 56);
			this.submitbutton.set_StyleController(this.layoutControl2);
			this.submitbutton.TabIndex = 0;
			this.submitbutton.Text = "KAYDET-UYGULA";
			this.submitbutton.Click += new EventHandler(this.simpleButton1_Click);
			this.ObjectDefine.get_AppearancePage().get_Header().set_Font(new Font("Tahoma", 10f));
			this.ObjectDefine.get_AppearancePage().get_Header().get_Options().set_UseFont(true);
			this.ObjectDefine.Dock = DockStyle.Fill;
			this.ObjectDefine.Location = new Point(0, 0);
			this.ObjectDefine.Name = "ObjectDefine";
			this.ObjectDefine.set_SelectedTabPage(this.xtraTabPage1);
			this.ObjectDefine.Size = new Size(317, 799);
			this.ObjectDefine.TabIndex = 5;
			this.ObjectDefine.get_TabPages().AddRange(new XtraTabPage[]
			{
				this.xtraTabPage1,
				this.xtraTabPage6,
				this.xtraTabPage2,
				this.xtraTabPage3,
				this.xtraTabPage4,
				this.xtraTabPage5,
				this.xtraTabPage7,
				this.xtraTabPage8
			});
			this.xtraTabPage1.Controls.Add(this.antetgrid);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.set_Size(new Size(311, 768));
			this.xtraTabPage1.Text = "ANTET";
			this.antetgrid.Dock = DockStyle.Fill;
			this.antetgrid.Location = new Point(0, 0);
			this.antetgrid.set_MainView(this.gridView1);
			this.antetgrid.Name = "antetgrid";
			this.antetgrid.Size = new Size(311, 768);
			this.antetgrid.TabIndex = 2;
			this.antetgrid.get_ViewCollection().AddRange(new BaseView[]
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
			this.gridView1.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
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
				this.gridColumn1,
				this.gridColumn2,
				this.gridColumn3
			});
			this.gridView1.set_GridControl(this.antetgrid);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsView().set_ShowColumnHeaders(false);
			this.gridView1.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView1.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView1_CellValueChanged));
			this.gridColumn1.get_AppearanceCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridColumn1.get_AppearanceCell().get_Options().set_UseFont(true);
			this.gridColumn1.set_Caption("gridColumn1");
			this.gridColumn1.set_FieldName("formvisual");
			this.gridColumn1.set_Name("gridColumn1");
			this.gridColumn1.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn1.set_Visible(true);
			this.gridColumn1.set_VisibleIndex(0);
			this.gridColumn2.set_Caption("gridColumn2");
			this.gridColumn2.set_FieldName("ParamValue");
			this.gridColumn2.set_Name("gridColumn2");
			this.gridColumn2.set_Visible(true);
			this.gridColumn2.set_VisibleIndex(1);
			this.gridColumn3.set_Caption("gridColumn3");
			this.gridColumn3.set_FieldName("ParamName");
			this.gridColumn3.set_Name("gridColumn3");
			this.xtraTabPage6.Controls.Add(this.layoutControl2);
			this.xtraTabPage6.Name = "xtraTabPage6";
			this.xtraTabPage6.set_Size(new Size(311, 768));
			this.xtraTabPage6.Text = "ÖZELLİKLER";
			this.layoutControl2.Controls.Add(this.label1);
			this.layoutControl2.Controls.Add(this.submitbutton);
			this.layoutControl2.Controls.Add(this.labelControl5);
			this.layoutControl2.Controls.Add(this.dengekatsay);
			this.layoutControl2.Controls.Add(this.labelControl25);
			this.layoutControl2.Controls.Add(this.agrtaneagr);
			this.layoutControl2.Controls.Add(this.labelControl24);
			this.layoutControl2.Controls.Add(this.simpleButton3);
			this.layoutControl2.Controls.Add(this.karkasagr);
			this.layoutControl2.Controls.Add(this.simpleButton18);
			this.layoutControl2.Controls.Add(this.beyamqpisuserdefined);
			this.layoutControl2.Controls.Add(this.HalatCap);
			this.layoutControl2.Controls.Add(this.labelControl17);
			this.layoutControl2.Controls.Add(this.labelControl15);
			this.layoutControl2.Controls.Add(this.labelControl14);
			this.layoutControl2.Controls.Add(this.labelControl4);
			this.layoutControl2.Controls.Add(this.labelControl13);
			this.layoutControl2.Controls.Add(this.pqtop);
			this.layoutControl2.Controls.Add(this.labelControl12);
			this.layoutControl2.Controls.Add(this.labelControl7);
			this.layoutControl2.Controls.Add(this.labelControl8);
			this.layoutControl2.Controls.Add(this.labelControl2);
			this.layoutControl2.Controls.Add(this.labelControl3);
			this.layoutControl2.Controls.Add(this.labelControl1);
			this.layoutControl2.Controls.Add(this.TahCap);
			this.layoutControl2.Controls.Add(this.HalatAdet);
			this.layoutControl2.Controls.Add(this.SapCap);
			this.layoutControl2.Controls.Add(this.MotorKw);
			this.layoutControl2.Controls.Add(this.labelControl11);
			this.layoutControl2.Controls.Add(this.KabinP);
			this.layoutControl2.Controls.Add(this.kabingenx);
			this.layoutControl2.Controls.Add(this.BeyanHiz);
			this.layoutControl2.Controls.Add(this.BeyanYuk);
			this.layoutControl2.Controls.Add(this.kabinderx);
			this.layoutControl2.Controls.Add(this.linkLabel1);
			this.layoutControl2.Controls.Add(this.BeyanKisi);
			this.layoutControl2.Dock = DockStyle.Fill;
			this.layoutControl2.Location = new Point(0, 0);
			this.layoutControl2.Name = "layoutControl2";
			this.layoutControl2.set_Root(this.layoutControlGroup2);
			this.layoutControl2.Size = new Size(311, 768);
			this.layoutControl2.TabIndex = 65;
			this.layoutControl2.Text = "layoutControl2";
			this.labelControl5.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.labelControl5.Location = new Point(7, 522);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new Size(136, 16);
			this.labelControl5.set_StyleController(this.layoutControl2);
			this.labelControl5.TabIndex = 1008;
			this.labelControl5.Text = "GEREKLİ AĞIRLIK ADEDİ";
			this.dengekatsay.set_EditValue("0,5");
			this.dengekatsay.Location = new Point(135, 496);
			this.dengekatsay.Name = "dengekatsay";
			this.dengekatsay.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dengekatsay.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dengekatsay.Size = new Size(169, 22);
			this.dengekatsay.set_StyleController(this.layoutControl2);
			this.dengekatsay.TabIndex = 22;
			this.labelControl25.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.labelControl25.set_AutoSizeMode(1);
			this.labelControl25.Location = new Point(257, 444);
			this.labelControl25.Name = "labelControl25";
			this.labelControl25.Size = new Size(47, 14);
			this.labelControl25.set_StyleController(this.layoutControl2);
			this.labelControl25.TabIndex = 20;
			this.labelControl25.Text = "kg";
			this.agrtaneagr.set_EditValue("35");
			this.agrtaneagr.Location = new Point(135, 470);
			this.agrtaneagr.Name = "agrtaneagr";
			this.agrtaneagr.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.agrtaneagr.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.agrtaneagr.Size = new Size(118, 22);
			this.agrtaneagr.set_StyleController(this.layoutControl2);
			this.agrtaneagr.TabIndex = 18;
			this.agrtaneagr.add_EditValueChanged(new EventHandler(this.BeyanYuk_EditValueChanged));
			this.labelControl24.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.labelControl24.set_AutoSizeMode(1);
			this.labelControl24.Location = new Point(257, 470);
			this.labelControl24.Name = "labelControl24";
			this.labelControl24.Size = new Size(47, 14);
			this.labelControl24.set_StyleController(this.layoutControl2);
			this.labelControl24.TabIndex = 16;
			this.labelControl24.Text = "kg";
			this.simpleButton3.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton3.get_Appearance().set_ForeColor(Color.Red);
			this.simpleButton3.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton3.get_Appearance().get_Options().set_UseForeColor(true);
			this.simpleButton3.Location = new Point(7, 414);
			this.simpleButton3.MaximumSize = new Size(0, 26);
			this.simpleButton3.MinimumSize = new Size(0, 26);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new Size(297, 26);
			this.simpleButton3.set_StyleController(this.layoutControl2);
			this.simpleButton3.TabIndex = 1007;
			this.simpleButton3.Text = "ÇİZİLECEK ASANSÖR SEÇ";
			this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
			this.karkasagr.set_EditValue("100");
			this.karkasagr.Location = new Point(135, 444);
			this.karkasagr.Name = "karkasagr";
			this.karkasagr.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.karkasagr.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.karkasagr.Size = new Size(118, 22);
			this.karkasagr.set_StyleController(this.layoutControl2);
			this.karkasagr.TabIndex = 19;
			this.karkasagr.add_EditValueChanged(new EventHandler(this.BeyanYuk_EditValueChanged));
			this.simpleButton18.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton18.get_Appearance().set_ForeColor(Color.Red);
			this.simpleButton18.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton18.get_Appearance().get_Options().set_UseForeColor(true);
			this.simpleButton18.Location = new Point(7, 254);
			this.simpleButton18.MaximumSize = new Size(0, 26);
			this.simpleButton18.MinimumSize = new Size(0, 26);
			this.simpleButton18.Name = "simpleButton18";
			this.simpleButton18.Size = new Size(297, 26);
			this.simpleButton18.set_StyleController(this.layoutControl2);
			this.simpleButton18.TabIndex = 156;
			this.simpleButton18.Text = "MOTOR BİLGİSİ SEÇİNİZ";
			this.simpleButton18.Click += new EventHandler(this.simpleButton18_Click);
			this.beyamqpisuserdefined.Location = new Point(7, 103);
			this.beyamqpisuserdefined.Name = "beyamqpisuserdefined";
			this.beyamqpisuserdefined.get_Properties().set_Caption("KULLANICI TANIMLI DEĞERLERİ KULLAN");
			this.beyamqpisuserdefined.Size = new Size(297, 19);
			this.beyamqpisuserdefined.set_StyleController(this.layoutControl2);
			this.beyamqpisuserdefined.TabIndex = 1006;
			this.beyamqpisuserdefined.add_CheckedChanged(new EventHandler(this.beyamqpisuserdefined_CheckedChanged));
			this.HalatCap.set_EditValue("10");
			this.HalatCap.Location = new Point(135, 388);
			this.HalatCap.Name = "HalatCap";
			this.HalatCap.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.HalatCap.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.HalatCap.Size = new Size(124, 22);
			this.HalatCap.set_StyleController(this.layoutControl2);
			this.HalatCap.TabIndex = 1004;
			this.labelControl17.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl17.Location = new Point(263, 388);
			this.labelControl17.Name = "labelControl17";
			this.labelControl17.Size = new Size(41, 16);
			this.labelControl17.set_StyleController(this.layoutControl2);
			this.labelControl17.TabIndex = 1003;
			this.labelControl17.Text = "mm";
			this.labelControl15.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl15.Location = new Point(263, 336);
			this.labelControl15.Name = "labelControl15";
			this.labelControl15.Size = new Size(41, 16);
			this.labelControl15.set_StyleController(this.layoutControl2);
			this.labelControl15.TabIndex = 1001;
			this.labelControl15.Text = "KW";
			this.labelControl14.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl14.Location = new Point(263, 362);
			this.labelControl14.Name = "labelControl14";
			this.labelControl14.Size = new Size(41, 16);
			this.labelControl14.set_StyleController(this.layoutControl2);
			this.labelControl14.TabIndex = 1001;
			this.labelControl14.Text = "mm";
			this.labelControl4.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl4.Location = new Point(263, 310);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new Size(41, 16);
			this.labelControl4.set_StyleController(this.layoutControl2);
			this.labelControl4.TabIndex = 1000;
			this.labelControl4.Text = "mm";
			this.labelControl13.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl13.Location = new Point(263, 284);
			this.labelControl13.Name = "labelControl13";
			this.labelControl13.Size = new Size(41, 16);
			this.labelControl13.set_StyleController(this.layoutControl2);
			this.labelControl13.TabIndex = 1001;
			this.labelControl13.Text = "mm";
			this.pqtop.Font = new Font("Tahoma", 10f, FontStyle.Bold);
			this.pqtop.Location = new Point(7, 230);
			this.pqtop.Name = "pqtop";
			this.pqtop.Size = new Size(297, 20);
			this.pqtop.TabIndex = 71;
			this.pqtop.TabStop = true;
			this.pqtop.Text = "P+Q AĞIRLIK = 1100 KG";
			this.pqtop.TextAlign = ContentAlignment.MiddleCenter;
			this.labelControl12.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl12.Location = new Point(263, 178);
			this.labelControl12.Name = "labelControl12";
			this.labelControl12.Size = new Size(41, 16);
			this.labelControl12.set_StyleController(this.layoutControl2);
			this.labelControl12.TabIndex = 78;
			this.labelControl12.Text = "m/sn";
			this.labelControl7.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl7.Location = new Point(263, 204);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new Size(41, 16);
			this.labelControl7.set_StyleController(this.layoutControl2);
			this.labelControl7.TabIndex = 76;
			this.labelControl7.Text = "kg";
			this.labelControl8.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl8.Location = new Point(263, 152);
			this.labelControl8.Name = "labelControl8";
			this.labelControl8.Size = new Size(41, 16);
			this.labelControl8.set_StyleController(this.layoutControl2);
			this.labelControl8.TabIndex = 77;
			this.labelControl8.Text = "kişi";
			this.labelControl2.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl2.Location = new Point(263, 53);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new Size(41, 16);
			this.labelControl2.set_StyleController(this.layoutControl2);
			this.labelControl2.TabIndex = 66;
			this.labelControl2.Text = "mm";
			this.labelControl3.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl3.Location = new Point(263, 126);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new Size(41, 16);
			this.labelControl3.set_StyleController(this.layoutControl2);
			this.labelControl3.TabIndex = 75;
			this.labelControl3.Text = "kg";
			this.labelControl1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl1.Location = new Point(263, 27);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new Size(41, 16);
			this.labelControl1.set_StyleController(this.layoutControl2);
			this.labelControl1.TabIndex = 65;
			this.labelControl1.Text = "mm";
			this.TahCap.set_EditValue("450");
			this.TahCap.set_EnterMoveNextControl(true);
			this.TahCap.Location = new Point(135, 284);
			this.TahCap.Name = "TahCap";
			this.TahCap.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.TahCap.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.TahCap.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.TahCap.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.TahCap.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.TahCap.get_Properties().get_EditFormat().set_FormatType(1);
			this.TahCap.Size = new Size(124, 22);
			this.TahCap.set_StyleController(this.layoutControl2);
			this.TahCap.TabIndex = 7;
			this.HalatAdet.set_EditValue("5");
			this.HalatAdet.set_EnterMoveNextControl(true);
			this.HalatAdet.Location = new Point(135, 362);
			this.HalatAdet.Name = "HalatAdet";
			this.HalatAdet.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.HalatAdet.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.HalatAdet.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.HalatAdet.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.HalatAdet.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.HalatAdet.get_Properties().get_EditFormat().set_FormatType(1);
			this.HalatAdet.Size = new Size(124, 22);
			this.HalatAdet.set_StyleController(this.layoutControl2);
			this.HalatAdet.TabIndex = 5;
			this.SapCap.set_EditValue("400");
			this.SapCap.set_EnterMoveNextControl(true);
			this.SapCap.Location = new Point(135, 310);
			this.SapCap.Name = "SapCap";
			this.SapCap.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.SapCap.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.SapCap.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.SapCap.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.SapCap.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.SapCap.get_Properties().get_EditFormat().set_FormatType(1);
			this.SapCap.Size = new Size(124, 22);
			this.SapCap.set_StyleController(this.layoutControl2);
			this.SapCap.TabIndex = 8;
			this.MotorKw.set_EditValue("5,5");
			this.MotorKw.set_EnterMoveNextControl(true);
			this.MotorKw.Location = new Point(135, 336);
			this.MotorKw.Name = "MotorKw";
			this.MotorKw.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.MotorKw.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.MotorKw.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.MotorKw.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.MotorKw.Size = new Size(124, 22);
			this.MotorKw.set_StyleController(this.layoutControl2);
			this.MotorKw.TabIndex = 3;
			this.labelControl11.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl11.Location = new Point(7, 7);
			this.labelControl11.Name = "labelControl11";
			this.labelControl11.Size = new Size(105, 16);
			this.labelControl11.set_StyleController(this.layoutControl2);
			this.labelControl11.TabIndex = 74;
			this.labelControl11.Text = "KABİN BİLGİLERİ";
			this.KabinP.set_EditValue("500");
			this.KabinP.set_EnterMoveNextControl(true);
			this.KabinP.Location = new Point(135, 204);
			this.KabinP.Name = "KabinP";
			this.KabinP.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KabinP.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KabinP.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.KabinP.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.KabinP.Size = new Size(124, 22);
			this.KabinP.set_StyleController(this.layoutControl2);
			this.KabinP.TabIndex = 6;
			this.KabinP.add_EditValueChanged(new EventHandler(this.BeyanYuk_EditValueChanged));
			this.kabingenx.set_EditValue("1200");
			this.kabingenx.Enabled = false;
			this.kabingenx.set_EnterMoveNextControl(true);
			this.kabingenx.Location = new Point(135, 27);
			this.kabingenx.Name = "kabingenx";
			this.kabingenx.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kabingenx.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kabingenx.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.kabingenx.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.kabingenx.get_Properties().get_DisplayFormat().set_FormatString("N");
			this.kabingenx.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.kabingenx.get_Properties().get_EditFormat().set_FormatString("N");
			this.kabingenx.get_Properties().get_EditFormat().set_FormatType(1);
			this.kabingenx.Size = new Size(124, 22);
			this.kabingenx.set_StyleController(this.layoutControl2);
			this.kabingenx.TabIndex = 5;
			this.kabingenx.add_EditValueChanged(new EventHandler(this.kabingen_EditValueChanged));
			this.BeyanHiz.set_EditValue("1");
			this.BeyanHiz.set_EnterMoveNextControl(true);
			this.BeyanHiz.Location = new Point(135, 178);
			this.BeyanHiz.Name = "BeyanHiz";
			this.BeyanHiz.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.BeyanHiz.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.BeyanHiz.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.BeyanHiz.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.BeyanHiz.get_Properties().get_DisplayFormat().set_FormatString("n2");
			this.BeyanHiz.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.BeyanHiz.get_Properties().get_EditFormat().set_FormatString("n2");
			this.BeyanHiz.get_Properties().get_EditFormat().set_FormatType(1);
			this.BeyanHiz.Size = new Size(124, 22);
			this.BeyanHiz.set_StyleController(this.layoutControl2);
			this.BeyanHiz.TabIndex = 4;
			this.BeyanYuk.set_EditValue("750");
			this.BeyanYuk.Enabled = false;
			this.BeyanYuk.set_EnterMoveNextControl(true);
			this.BeyanYuk.Location = new Point(135, 126);
			this.BeyanYuk.Name = "BeyanYuk";
			this.BeyanYuk.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.BeyanYuk.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.BeyanYuk.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.BeyanYuk.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.BeyanYuk.get_Properties().get_DisplayFormat().set_FormatString("N");
			this.BeyanYuk.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.BeyanYuk.get_Properties().get_EditFormat().set_FormatString("N");
			this.BeyanYuk.get_Properties().get_EditFormat().set_FormatType(1);
			this.BeyanYuk.Size = new Size(124, 22);
			this.BeyanYuk.set_StyleController(this.layoutControl2);
			this.BeyanYuk.TabIndex = 69;
			this.BeyanYuk.add_EditValueChanged(new EventHandler(this.BeyanYuk_EditValueChanged));
			this.kabinderx.set_EditValue("1500");
			this.kabinderx.Enabled = false;
			this.kabinderx.set_EnterMoveNextControl(true);
			this.kabinderx.Location = new Point(135, 53);
			this.kabinderx.Name = "kabinderx";
			this.kabinderx.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kabinderx.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kabinderx.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.kabinderx.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.kabinderx.get_Properties().get_DisplayFormat().set_FormatString("N");
			this.kabinderx.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.kabinderx.get_Properties().get_EditFormat().set_FormatString("N");
			this.kabinderx.get_Properties().get_EditFormat().set_FormatType(1);
			this.kabinderx.Size = new Size(124, 22);
			this.kabinderx.set_StyleController(this.layoutControl2);
			this.kabinderx.TabIndex = 68;
			this.kabinderx.add_EditValueChanged(new EventHandler(this.kabingen_EditValueChanged));
			this.linkLabel1.Font = new Font("Tahoma", 10f, FontStyle.Bold);
			this.linkLabel1.Location = new Point(7, 79);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new Size(297, 20);
			this.linkLabel1.TabIndex = 70;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "KABİN ALANI 1,80 m2";
			this.linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
			this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.BeyanKisi.set_EditValue("10");
			this.BeyanKisi.Enabled = false;
			this.BeyanKisi.Location = new Point(135, 152);
			this.BeyanKisi.Name = "BeyanKisi";
			this.BeyanKisi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.BeyanKisi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.BeyanKisi.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.BeyanKisi.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.BeyanKisi.Size = new Size(124, 22);
			this.BeyanKisi.set_StyleController(this.layoutControl2);
			this.BeyanKisi.TabIndex = 65;
			this.layoutControlGroup2.set_CustomizationFormText("layoutControlGroup2");
			this.layoutControlGroup2.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup2.set_GroupBordersVisible(false);
			this.layoutControlGroup2.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem3,
				this.layoutControlItem8,
				this.layoutControlItem10,
				this.layoutControlItem12,
				this.layoutControlItem16,
				this.layoutControlItem18,
				this.layoutControlItem20,
				this.layoutControlItem21,
				this.layoutControlItem4,
				this.layoutControlItem5,
				this.layoutControlItem13,
				this.layoutControlItem14,
				this.layoutControlItem15,
				this.layoutControlItem17,
				this.layoutControlItem19,
				this.layoutControlItem11,
				this.layoutControlItem22,
				this.layoutControlItem23,
				this.layoutControlItem25,
				this.layoutControlItem27,
				this.layoutControlItem28,
				this.layoutControlItem29,
				this.layoutControlItem30,
				this.layoutControlItem32,
				this.layoutControlItem116,
				this.layoutControlItem6,
				this.layoutControlItem34,
				this.layoutControlItem1,
				this.layoutControlItem33,
				this.layoutControlItem2,
				this.layoutControlItem7,
				this.layoutControlItem9,
				this.layoutControlItem31,
				this.layoutControlItem24,
				this.layoutControlItem26,
				this.layoutControlItem35
			});
			this.layoutControlGroup2.set_Location(new Point(0, 0));
			this.layoutControlGroup2.set_Name("layoutControlGroup2");
			this.layoutControlGroup2.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup2.set_Size(new Size(311, 768));
			this.layoutControlGroup2.set_TextVisible(false);
			this.layoutControlItem3.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem3.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem3.set_Control(this.kabingenx);
			this.layoutControlItem3.set_CustomizationFormText("KABİN GENİŞLİĞİ");
			this.layoutControlItem3.set_Location(new Point(0, 20));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(256, 26));
			this.layoutControlItem3.set_Text("KABİN GENİŞLİĞİ");
			this.layoutControlItem3.set_TextSize(new Size(125, 16));
			this.layoutControlItem8.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem8.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem8.set_Control(this.kabinderx);
			this.layoutControlItem8.set_CustomizationFormText("KABİN DERİNİLİĞİ");
			this.layoutControlItem8.set_Location(new Point(0, 46));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(256, 26));
			this.layoutControlItem8.set_Text("KABİN DERİNİLİĞİ");
			this.layoutControlItem8.set_TextSize(new Size(125, 16));
			this.layoutControlItem10.set_Control(this.linkLabel1);
			this.layoutControlItem10.set_CustomizationFormText("layoutControlItem10");
			this.layoutControlItem10.set_Location(new Point(0, 72));
			this.layoutControlItem10.set_Name("layoutControlItem10");
			this.layoutControlItem10.set_Size(new Size(301, 24));
			this.layoutControlItem10.set_TextSize(new Size(0, 0));
			this.layoutControlItem10.set_TextVisible(false);
			this.layoutControlItem12.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem12.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem12.set_Control(this.BeyanYuk);
			this.layoutControlItem12.set_CustomizationFormText("BEYAN YÜKÜ");
			this.layoutControlItem12.set_Location(new Point(0, 119));
			this.layoutControlItem12.set_Name("layoutControlItem12");
			this.layoutControlItem12.set_Size(new Size(256, 26));
			this.layoutControlItem12.set_Text("BEYAN YÜKÜ");
			this.layoutControlItem12.set_TextSize(new Size(125, 16));
			this.layoutControlItem16.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem16.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem16.set_Control(this.BeyanHiz);
			this.layoutControlItem16.set_CustomizationFormText("ASANSÖR HIZI");
			this.layoutControlItem16.set_Location(new Point(0, 171));
			this.layoutControlItem16.set_Name("layoutControlItem16");
			this.layoutControlItem16.set_Size(new Size(256, 26));
			this.layoutControlItem16.set_Text("ASANSÖR HIZI");
			this.layoutControlItem16.set_TextSize(new Size(125, 16));
			this.layoutControlItem18.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem18.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem18.set_Control(this.KabinP);
			this.layoutControlItem18.set_CustomizationFormText("KABİN AĞIRLIĞI");
			this.layoutControlItem18.set_Location(new Point(0, 197));
			this.layoutControlItem18.set_Name("layoutControlItem18");
			this.layoutControlItem18.set_Size(new Size(256, 26));
			this.layoutControlItem18.set_Text("KABİN AĞIRLIĞI");
			this.layoutControlItem18.set_TextSize(new Size(125, 16));
			this.layoutControlItem20.set_Control(this.labelControl11);
			this.layoutControlItem20.set_CustomizationFormText("layoutControlItem20");
			this.layoutControlItem20.set_Location(new Point(0, 0));
			this.layoutControlItem20.set_Name("layoutControlItem20");
			this.layoutControlItem20.set_Size(new Size(301, 20));
			this.layoutControlItem20.set_TextSize(new Size(0, 0));
			this.layoutControlItem20.set_TextVisible(false);
			this.layoutControlItem21.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem21.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem21.set_Control(this.BeyanKisi);
			this.layoutControlItem21.set_CustomizationFormText("BEYAN KİŞİ");
			this.layoutControlItem21.set_Location(new Point(0, 145));
			this.layoutControlItem21.set_Name("layoutControlItem21");
			this.layoutControlItem21.set_Size(new Size(256, 26));
			this.layoutControlItem21.set_Text("BEYAN KİŞİ");
			this.layoutControlItem21.set_TextSize(new Size(125, 16));
			this.layoutControlItem4.set_Control(this.labelControl1);
			this.layoutControlItem4.set_CustomizationFormText("layoutControlItem4");
			this.layoutControlItem4.set_Location(new Point(256, 20));
			this.layoutControlItem4.set_MaxSize(new Size(45, 20));
			this.layoutControlItem4.set_MinSize(new Size(45, 20));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(45, 26));
			this.layoutControlItem4.set_SizeConstraintsType(2);
			this.layoutControlItem4.set_TextSize(new Size(0, 0));
			this.layoutControlItem4.set_TextVisible(false);
			this.layoutControlItem5.set_Control(this.labelControl2);
			this.layoutControlItem5.set_CustomizationFormText("layoutControlItem9");
			this.layoutControlItem5.set_Location(new Point(256, 46));
			this.layoutControlItem5.set_MaxSize(new Size(45, 20));
			this.layoutControlItem5.set_MinSize(new Size(45, 20));
			this.layoutControlItem5.set_Name("layoutControlItem9");
			this.layoutControlItem5.set_Size(new Size(45, 26));
			this.layoutControlItem5.set_SizeConstraintsType(2);
			this.layoutControlItem5.set_TextSize(new Size(0, 0));
			this.layoutControlItem5.set_TextVisible(false);
			this.layoutControlItem13.set_Control(this.labelControl3);
			this.layoutControlItem13.set_CustomizationFormText("layoutControlItem13");
			this.layoutControlItem13.set_Location(new Point(256, 119));
			this.layoutControlItem13.set_MaxSize(new Size(45, 20));
			this.layoutControlItem13.set_MinSize(new Size(45, 20));
			this.layoutControlItem13.set_Name("layoutControlItem13");
			this.layoutControlItem13.set_Size(new Size(45, 26));
			this.layoutControlItem13.set_SizeConstraintsType(2);
			this.layoutControlItem13.set_TextSize(new Size(0, 0));
			this.layoutControlItem13.set_TextVisible(false);
			this.layoutControlItem14.set_Control(this.labelControl7);
			this.layoutControlItem14.set_CustomizationFormText("layoutControlItem14");
			this.layoutControlItem14.set_Location(new Point(256, 197));
			this.layoutControlItem14.set_MaxSize(new Size(0, 20));
			this.layoutControlItem14.set_MinSize(new Size(45, 20));
			this.layoutControlItem14.set_Name("layoutControlItem14");
			this.layoutControlItem14.set_Size(new Size(45, 26));
			this.layoutControlItem14.set_SizeConstraintsType(2);
			this.layoutControlItem14.set_TextSize(new Size(0, 0));
			this.layoutControlItem14.set_TextVisible(false);
			this.layoutControlItem15.set_Control(this.labelControl8);
			this.layoutControlItem15.set_CustomizationFormText("layoutControlItem15");
			this.layoutControlItem15.set_Location(new Point(256, 145));
			this.layoutControlItem15.set_MaxSize(new Size(45, 20));
			this.layoutControlItem15.set_MinSize(new Size(45, 20));
			this.layoutControlItem15.set_Name("layoutControlItem15");
			this.layoutControlItem15.set_Size(new Size(45, 26));
			this.layoutControlItem15.set_SizeConstraintsType(2);
			this.layoutControlItem15.set_TextSize(new Size(0, 0));
			this.layoutControlItem15.set_TextVisible(false);
			this.layoutControlItem17.set_Control(this.labelControl12);
			this.layoutControlItem17.set_CustomizationFormText("layoutControlItem17");
			this.layoutControlItem17.set_Location(new Point(256, 171));
			this.layoutControlItem17.set_MaxSize(new Size(45, 20));
			this.layoutControlItem17.set_MinSize(new Size(45, 20));
			this.layoutControlItem17.set_Name("layoutControlItem17");
			this.layoutControlItem17.set_Size(new Size(45, 26));
			this.layoutControlItem17.set_SizeConstraintsType(2);
			this.layoutControlItem17.set_TextSize(new Size(0, 0));
			this.layoutControlItem17.set_TextVisible(false);
			this.layoutControlItem19.set_Control(this.pqtop);
			this.layoutControlItem19.set_CustomizationFormText("layoutControlItem19");
			this.layoutControlItem19.set_Location(new Point(0, 223));
			this.layoutControlItem19.set_Name("layoutControlItem19");
			this.layoutControlItem19.set_Size(new Size(301, 24));
			this.layoutControlItem19.set_TextSize(new Size(0, 0));
			this.layoutControlItem19.set_TextVisible(false);
			this.layoutControlItem11.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem11.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem11.set_Control(this.TahCap);
			this.layoutControlItem11.set_CustomizationFormText("MAK. KASNAK ÇAPI");
			this.layoutControlItem11.set_Location(new Point(0, 277));
			this.layoutControlItem11.set_Name("layoutControlItem11");
			this.layoutControlItem11.set_Size(new Size(256, 26));
			this.layoutControlItem11.set_Text("MAK. KASNAK ÇAPI");
			this.layoutControlItem11.set_TextSize(new Size(125, 16));
			this.layoutControlItem22.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem22.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem22.set_Control(this.SapCap);
			this.layoutControlItem22.set_CustomizationFormText("SAP. KASNAK ÇAPI");
			this.layoutControlItem22.set_Location(new Point(0, 303));
			this.layoutControlItem22.set_Name("layoutControlItem22");
			this.layoutControlItem22.set_Size(new Size(256, 26));
			this.layoutControlItem22.set_Text("SAP. KASNAK ÇAPI");
			this.layoutControlItem22.set_TextSize(new Size(125, 16));
			this.layoutControlItem23.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem23.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem23.set_Control(this.MotorKw);
			this.layoutControlItem23.set_CustomizationFormText("MOTOR KW");
			this.layoutControlItem23.set_Location(new Point(0, 329));
			this.layoutControlItem23.set_Name("layoutControlItem23");
			this.layoutControlItem23.set_Size(new Size(256, 26));
			this.layoutControlItem23.set_Text("MOTOR KW");
			this.layoutControlItem23.set_TextSize(new Size(125, 16));
			this.layoutControlItem25.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem25.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem25.set_Control(this.HalatAdet);
			this.layoutControlItem25.set_CustomizationFormText("HALAT ADEDİ");
			this.layoutControlItem25.set_Location(new Point(0, 355));
			this.layoutControlItem25.set_Name("layoutControlItem25");
			this.layoutControlItem25.set_Size(new Size(256, 26));
			this.layoutControlItem25.set_Text("HALAT ADEDİ");
			this.layoutControlItem25.set_TextSize(new Size(125, 16));
			this.layoutControlItem27.set_Control(this.labelControl13);
			this.layoutControlItem27.set_CustomizationFormText("layoutControlItem27");
			this.layoutControlItem27.set_Location(new Point(256, 277));
			this.layoutControlItem27.set_MaxSize(new Size(45, 20));
			this.layoutControlItem27.set_MinSize(new Size(45, 20));
			this.layoutControlItem27.set_Name("layoutControlItem27");
			this.layoutControlItem27.set_Size(new Size(45, 26));
			this.layoutControlItem27.set_SizeConstraintsType(2);
			this.layoutControlItem27.set_TextSize(new Size(0, 0));
			this.layoutControlItem27.set_TextVisible(false);
			this.layoutControlItem28.set_Control(this.labelControl4);
			this.layoutControlItem28.set_CustomizationFormText("layoutControlItem28");
			this.layoutControlItem28.set_Location(new Point(256, 303));
			this.layoutControlItem28.set_MaxSize(new Size(45, 20));
			this.layoutControlItem28.set_MinSize(new Size(45, 20));
			this.layoutControlItem28.set_Name("layoutControlItem28");
			this.layoutControlItem28.set_Size(new Size(45, 26));
			this.layoutControlItem28.set_SizeConstraintsType(2);
			this.layoutControlItem28.set_TextSize(new Size(0, 0));
			this.layoutControlItem28.set_TextVisible(false);
			this.layoutControlItem29.set_Control(this.labelControl14);
			this.layoutControlItem29.set_CustomizationFormText("layoutControlItem29");
			this.layoutControlItem29.set_Location(new Point(256, 355));
			this.layoutControlItem29.set_MaxSize(new Size(45, 20));
			this.layoutControlItem29.set_MinSize(new Size(45, 20));
			this.layoutControlItem29.set_Name("layoutControlItem29");
			this.layoutControlItem29.set_Size(new Size(45, 26));
			this.layoutControlItem29.set_SizeConstraintsType(2);
			this.layoutControlItem29.set_TextSize(new Size(0, 0));
			this.layoutControlItem29.set_TextVisible(false);
			this.layoutControlItem30.set_Control(this.labelControl15);
			this.layoutControlItem30.set_CustomizationFormText("layoutControlItem30");
			this.layoutControlItem30.set_Location(new Point(256, 329));
			this.layoutControlItem30.set_MaxSize(new Size(45, 20));
			this.layoutControlItem30.set_MinSize(new Size(45, 20));
			this.layoutControlItem30.set_Name("layoutControlItem30");
			this.layoutControlItem30.set_Size(new Size(45, 26));
			this.layoutControlItem30.set_SizeConstraintsType(2);
			this.layoutControlItem30.set_TextSize(new Size(0, 0));
			this.layoutControlItem30.set_TextVisible(false);
			this.layoutControlItem32.set_Control(this.labelControl17);
			this.layoutControlItem32.set_CustomizationFormText("layoutControlItem32");
			this.layoutControlItem32.set_Location(new Point(256, 381));
			this.layoutControlItem32.set_MaxSize(new Size(45, 20));
			this.layoutControlItem32.set_MinSize(new Size(45, 20));
			this.layoutControlItem32.set_Name("layoutControlItem32");
			this.layoutControlItem32.set_Size(new Size(45, 26));
			this.layoutControlItem32.set_SizeConstraintsType(2);
			this.layoutControlItem32.set_TextSize(new Size(0, 0));
			this.layoutControlItem32.set_TextVisible(false);
			this.layoutControlItem116.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem116.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem116.set_Control(this.HalatCap);
			this.layoutControlItem116.set_Location(new Point(0, 381));
			this.layoutControlItem116.set_Name("layoutControlItem116");
			this.layoutControlItem116.set_Size(new Size(256, 26));
			this.layoutControlItem116.set_Text("HALAT ÇAPI");
			this.layoutControlItem116.set_TextSize(new Size(125, 16));
			this.layoutControlItem6.set_Control(this.beyamqpisuserdefined);
			this.layoutControlItem6.set_Location(new Point(0, 96));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(301, 23));
			this.layoutControlItem6.set_TextSize(new Size(0, 0));
			this.layoutControlItem6.set_TextVisible(false);
			this.layoutControlItem34.set_Control(this.simpleButton18);
			this.layoutControlItem34.set_Location(new Point(0, 247));
			this.layoutControlItem34.set_Name("layoutControlItem34");
			this.layoutControlItem34.set_Size(new Size(301, 30));
			this.layoutControlItem34.set_TextSize(new Size(0, 0));
			this.layoutControlItem34.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.simpleButton3);
			this.layoutControlItem1.set_Location(new Point(0, 407));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(301, 30));
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem33.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem33.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem33.set_Control(this.dengekatsay);
			this.layoutControlItem33.set_Location(new Point(0, 489));
			this.layoutControlItem33.set_Name("layoutControlItem33");
			this.layoutControlItem33.set_Size(new Size(301, 26));
			this.layoutControlItem33.set_Text("DENGE KAT SAYISI");
			this.layoutControlItem33.set_TextSize(new Size(125, 16));
			this.layoutControlItem2.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem2.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem2.set_Control(this.karkasagr);
			this.layoutControlItem2.set_Location(new Point(0, 437));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(250, 26));
			this.layoutControlItem2.set_Text("KARKAS AĞIRLIĞI");
			this.layoutControlItem2.set_TextSize(new Size(125, 16));
			this.layoutControlItem7.set_Control(this.labelControl25);
			this.layoutControlItem7.set_Location(new Point(250, 437));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(51, 26));
			this.layoutControlItem7.set_TextSize(new Size(0, 0));
			this.layoutControlItem7.set_TextVisible(false);
			this.layoutControlItem9.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem9.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem9.set_Control(this.agrtaneagr);
			this.layoutControlItem9.set_Location(new Point(0, 463));
			this.layoutControlItem9.set_Name("layoutControlItem9");
			this.layoutControlItem9.set_Size(new Size(250, 26));
			this.layoutControlItem9.set_Text("AĞIRLIK BİRİM KÜT");
			this.layoutControlItem9.set_TextSize(new Size(125, 16));
			this.layoutControlItem31.set_Control(this.labelControl24);
			this.layoutControlItem31.set_Location(new Point(250, 463));
			this.layoutControlItem31.set_Name("layoutControlItem31");
			this.layoutControlItem31.set_Size(new Size(51, 26));
			this.layoutControlItem31.set_TextSize(new Size(0, 0));
			this.layoutControlItem31.set_TextVisible(false);
			this.layoutControlItem24.set_Control(this.labelControl5);
			this.layoutControlItem24.set_Location(new Point(0, 515));
			this.layoutControlItem24.set_Name("layoutControlItem24");
			this.layoutControlItem24.set_Size(new Size(301, 20));
			this.layoutControlItem24.set_TextSize(new Size(0, 0));
			this.layoutControlItem24.set_TextVisible(false);
			this.xtraTabPage2.Controls.Add(this.kesitlayeryapi);
			this.xtraTabPage2.Controls.Add(this.kesitlayertree);
			this.xtraTabPage2.Controls.Add(this.simpleButton2);
			this.xtraTabPage2.Controls.Add(this.simpleButton1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.set_Size(new Size(311, 768));
			this.xtraTabPage2.Text = "ÇİZİM EKRANI";
			this.kesitlayeryapi.Dock = DockStyle.Top;
			this.kesitlayeryapi.Location = new Point(0, 46);
			this.kesitlayeryapi.Name = "kesitlayeryapi";
			this.kesitlayeryapi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.kesitlayeryapi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kesitlayeryapi.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.kesitlayeryapi.get_Properties().set_View(this.searchLookUpEdit1View);
			this.kesitlayeryapi.Size = new Size(311, 22);
			this.kesitlayeryapi.TabIndex = 5;
			this.searchLookUpEdit1View.set_FocusRectStyle(1);
			this.searchLookUpEdit1View.set_Name("searchLookUpEdit1View");
			this.searchLookUpEdit1View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit1View.get_OptionsView().set_ShowGroupPanel(false);
			this.kesitlayertree.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_FilterPanel().get_Options().set_UseTextOptions(true);
			this.kesitlayertree.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_FocusedCell().set_BackColor(Color.FromArgb(255, 192, 255));
			this.kesitlayertree.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_FocusedCell().get_Options().set_UseBackColor(true);
			this.kesitlayertree.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_FocusedRow().set_BackColor(Color.FromArgb(255, 192, 255));
			this.kesitlayertree.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_FocusedRow().get_Options().set_UseBackColor(true);
			this.kesitlayertree.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_Row().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_TreeLine().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_TreeLine().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 10f));
			this.kesitlayertree.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.kesitlayertree.get_Columns().AddRange(new TreeListColumn[]
			{
				this.treeListColumn1,
				this.treeListColumn2,
				this.treeListColumn3,
				this.treeListColumn5,
				this.treeListColumn4
			});
			this.kesitlayertree.Dock = DockStyle.Bottom;
			this.kesitlayertree.Font = new Font("Microsoft Sans Serif", 10f);
			this.kesitlayertree.set_KeyFieldName("kesitid");
			this.kesitlayertree.Location = new Point(0, 74);
			this.kesitlayertree.Name = "kesitlayertree";
			this.kesitlayertree.get_OptionsBehavior().set_EnableFiltering(true);
			this.kesitlayertree.get_OptionsBehavior().set_PopulateServiceColumns(true);
			this.kesitlayertree.get_OptionsFilter().set_FilterMode(3);
			this.kesitlayertree.get_OptionsFilter().set_ShowAllValuesInFilterPopup(true);
			this.kesitlayertree.get_OptionsFind().set_AlwaysVisible(true);
			this.kesitlayertree.get_OptionsFind().set_ShowClearButton(false);
			this.kesitlayertree.get_OptionsFind().set_ShowCloseButton(false);
			this.kesitlayertree.get_OptionsFind().set_ShowFindButton(false);
			this.kesitlayertree.get_OptionsView().set_ShowAutoFilterRow(true);
			this.kesitlayertree.get_OptionsView().set_ShowColumns(false);
			this.kesitlayertree.set_ParentFieldName("layerid");
			this.kesitlayertree.Size = new Size(311, 694);
			this.kesitlayertree.TabIndex = 1;
			this.treeListColumn1.get_AppearanceCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Underline, GraphicsUnit.Point, 162));
			this.treeListColumn1.get_AppearanceCell().set_ForeColor(Color.Blue);
			this.treeListColumn1.get_AppearanceCell().get_Options().set_UseFont(true);
			this.treeListColumn1.get_AppearanceCell().get_Options().set_UseForeColor(true);
			this.treeListColumn1.set_Caption("KESİT ADI");
			this.treeListColumn1.set_FieldName("kesitad");
			this.treeListColumn1.set_Name("treeListColumn1");
			this.treeListColumn1.get_OptionsColumn().set_AllowEdit(false);
			this.treeListColumn1.get_OptionsFilter().set_AutoFilterCondition(1);
			this.treeListColumn1.set_Visible(true);
			this.treeListColumn1.set_VisibleIndex(0);
			this.treeListColumn1.set_Width(194);
			this.treeListColumn2.set_Caption("treeListColumn2");
			this.treeListColumn2.set_FieldName("kesitid");
			this.treeListColumn2.set_Name("treeListColumn2");
			this.treeListColumn2.set_Width(105);
			this.treeListColumn3.set_Caption("treeListColumn3");
			this.treeListColumn3.set_FieldName("layerid");
			this.treeListColumn3.set_Name("treeListColumn3");
			this.treeListColumn5.set_Caption("Ekranda");
			this.treeListColumn5.set_FieldName("aktifmi");
			this.treeListColumn5.set_Name("treeListColumn5");
			this.treeListColumn5.set_Visible(true);
			this.treeListColumn5.set_VisibleIndex(1);
			this.treeListColumn5.set_Width(50);
			this.treeListColumn4.set_Caption("Bölge");
			this.treeListColumn4.set_FieldName("layername");
			this.treeListColumn4.set_Name("treeListColumn4");
			this.treeListColumn4.set_Width(62);
			this.simpleButton2.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton2.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton2.Dock = DockStyle.Top;
			this.simpleButton2.Location = new Point(0, 23);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(311, 23);
			this.simpleButton2.TabIndex = 6;
			this.simpleButton2.Text = "SEÇİMLERİ ÇİZİME UYGULA";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			this.simpleButton1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Dock = DockStyle.Top;
			this.simpleButton1.Location = new Point(0, 0);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(311, 23);
			this.simpleButton1.TabIndex = 4;
			this.simpleButton1.Text = "YAPIYI KAYDET";
			this.xtraTabPage3.Name = "xtraTabPage3";
			this.xtraTabPage3.set_Size(new Size(311, 768));
			this.xtraTabPage3.Text = "REGÜLATÖR";
			this.xtraTabPage4.Name = "xtraTabPage4";
			this.xtraTabPage4.set_Size(new Size(311, 768));
			this.xtraTabPage4.Text = "SÜSPANSİYON";
			this.xtraTabPage5.Name = "xtraTabPage5";
			this.xtraTabPage5.set_Size(new Size(311, 768));
			this.xtraTabPage5.Text = "RAY";
			this.xtraTabPage7.Name = "xtraTabPage7";
			this.xtraTabPage7.set_Size(new Size(311, 768));
			this.xtraTabPage7.Text = "Karşı Ağırlık";
			this.xtraTabPage8.Controls.Add(this.groupControl13);
			this.xtraTabPage8.Name = "xtraTabPage8";
			this.xtraTabPage8.set_Size(new Size(311, 768));
			this.xtraTabPage8.Text = "KAPI";
			this.groupControl13.get_AppearanceCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.groupControl13.get_AppearanceCaption().set_ForeColor(Color.FromArgb(192, 64, 0));
			this.groupControl13.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.groupControl13.get_AppearanceCaption().get_Options().set_UseForeColor(true);
			this.groupControl13.Controls.Add(this.layoutControl7);
			this.groupControl13.Dock = DockStyle.Fill;
			this.groupControl13.Location = new Point(0, 0);
			this.groupControl13.Name = "groupControl13";
			this.groupControl13.Size = new Size(311, 768);
			this.groupControl13.TabIndex = 17;
			this.groupControl13.Text = "OTOMATİK KAPI PARAMETRELERİ";
			this.layoutControl7.Controls.Add(this.KapiKirisProfil);
			this.layoutControl7.Controls.Add(this.KapiKorKasa);
			this.layoutControl7.Controls.Add(this.KasaDer);
			this.layoutControl7.Controls.Add(this.KasaGen);
			this.layoutControl7.Controls.Add(this.KapiH);
			this.layoutControl7.Controls.Add(this.KizakKalin);
			this.layoutControl7.Controls.Add(this.ToplamKalin);
			this.layoutControl7.Controls.Add(this.OtoKabinEsik);
			this.layoutControl7.Dock = DockStyle.Fill;
			this.layoutControl7.Location = new Point(2, 23);
			this.layoutControl7.Name = "layoutControl7";
			this.layoutControl7.set_Root(this.layoutControlGroup7);
			this.layoutControl7.Size = new Size(307, 743);
			this.layoutControl7.TabIndex = 0;
			this.layoutControl7.Text = "layoutControl7";
			this.KapiKirisProfil.Location = new Point(7, 187);
			this.KapiKirisProfil.Name = "KapiKirisProfil";
			this.KapiKirisProfil.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KapiKirisProfil.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KapiKirisProfil.get_Properties().set_Caption("KAPIDA KİRİŞ PROFİLİ LAZIM");
			this.KapiKirisProfil.Size = new Size(294, 20);
			this.KapiKirisProfil.set_StyleController(this.layoutControl7);
			this.KapiKirisProfil.TabIndex = 14;
			this.KapiKorKasa.Location = new Point(7, 163);
			this.KapiKorKasa.Name = "KapiKorKasa";
			this.KapiKorKasa.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KapiKorKasa.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KapiKorKasa.get_Properties().set_Caption("KAPIDA KÖR KASA VAR");
			this.KapiKorKasa.Size = new Size(294, 20);
			this.KapiKorKasa.set_StyleController(this.layoutControl7);
			this.KapiKorKasa.TabIndex = 13;
			this.KasaDer.set_EditValue("60");
			this.KasaDer.Location = new Point(251, 137);
			this.KasaDer.Name = "KasaDer";
			this.KasaDer.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KasaDer.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KasaDer.Size = new Size(50, 22);
			this.KasaDer.set_StyleController(this.layoutControl7);
			this.KasaDer.TabIndex = 10;
			this.KasaGen.set_EditValue("120");
			this.KasaGen.Location = new Point(251, 111);
			this.KasaGen.Name = "KasaGen";
			this.KasaGen.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KasaGen.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KasaGen.Size = new Size(50, 22);
			this.KasaGen.set_StyleController(this.layoutControl7);
			this.KasaGen.TabIndex = 9;
			this.KapiH.set_EditValue("2300");
			this.KapiH.Location = new Point(251, 85);
			this.KapiH.Name = "KapiH";
			this.KapiH.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KapiH.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KapiH.Size = new Size(50, 22);
			this.KapiH.set_StyleController(this.layoutControl7);
			this.KapiH.TabIndex = 8;
			this.KizakKalin.set_EditValue("90");
			this.KizakKalin.set_EnterMoveNextControl(true);
			this.KizakKalin.Location = new Point(251, 33);
			this.KizakKalin.Name = "KizakKalin";
			this.KizakKalin.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.KizakKalin.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.KizakKalin.Size = new Size(50, 22);
			this.KizakKalin.set_StyleController(this.layoutControl7);
			this.KizakKalin.TabIndex = 7;
			this.ToplamKalin.set_EditValue("500");
			this.ToplamKalin.set_EnterMoveNextControl(true);
			this.ToplamKalin.Location = new Point(251, 59);
			this.ToplamKalin.Name = "ToplamKalin";
			this.ToplamKalin.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ToplamKalin.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.ToplamKalin.Size = new Size(50, 22);
			this.ToplamKalin.set_StyleController(this.layoutControl7);
			this.ToplamKalin.TabIndex = 6;
			this.OtoKabinEsik.set_EditValue("50");
			this.OtoKabinEsik.set_EnterMoveNextControl(true);
			this.OtoKabinEsik.Location = new Point(251, 7);
			this.OtoKabinEsik.Name = "OtoKabinEsik";
			this.OtoKabinEsik.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.OtoKabinEsik.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.OtoKabinEsik.Size = new Size(50, 22);
			this.OtoKabinEsik.set_StyleController(this.layoutControl7);
			this.OtoKabinEsik.TabIndex = 4;
			this.layoutControlGroup7.set_CustomizationFormText("layoutControlGroup6");
			this.layoutControlGroup7.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup7.set_GroupBordersVisible(false);
			this.layoutControlGroup7.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem61,
				this.layoutControlItem63,
				this.layoutControlItem109,
				this.layoutControlItem110,
				this.layoutControlItem117,
				this.layoutControlItem118,
				this.layoutControlItem129,
				this.layoutControlItem130
			});
			this.layoutControlGroup7.set_Location(new Point(0, 0));
			this.layoutControlGroup7.set_Name("layoutControlGroup6");
			this.layoutControlGroup7.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup7.set_Size(new Size(308, 743));
			this.layoutControlGroup7.set_TextVisible(false);
			this.layoutControlItem61.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem61.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem61.set_Control(this.OtoKabinEsik);
			this.layoutControlItem61.set_CustomizationFormText("KONSOL MESAFESİ");
			this.layoutControlItem61.set_Location(new Point(0, 0));
			this.layoutControlItem61.set_Name("layoutControlItem57");
			this.layoutControlItem61.set_Size(new Size(298, 26));
			this.layoutControlItem61.set_Text("(1) EŞİK DEĞERİ");
			this.layoutControlItem61.set_TextSize(new Size(241, 16));
			this.layoutControlItem63.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem63.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem63.set_Control(this.ToplamKalin);
			this.layoutControlItem63.set_CustomizationFormText("RAY UCU TAVAN MRL");
			this.layoutControlItem63.set_Location(new Point(0, 52));
			this.layoutControlItem63.set_Name("layoutControlItem59");
			this.layoutControlItem63.set_Size(new Size(298, 26));
			this.layoutControlItem63.set_Text("(3) KUYU DUVARI-KABİN SINIRI DEĞERİ");
			this.layoutControlItem63.set_TextSize(new Size(241, 14));
			this.layoutControlItem109.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem109.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem109.set_Control(this.KizakKalin);
			this.layoutControlItem109.set_Location(new Point(0, 26));
			this.layoutControlItem109.set_Name("layoutControlItem109");
			this.layoutControlItem109.set_Size(new Size(298, 26));
			this.layoutControlItem109.set_Text("OTO KAPI KIZAĞI");
			this.layoutControlItem109.set_TextSize(new Size(241, 16));
			this.layoutControlItem110.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem110.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem110.set_Control(this.KapiH);
			this.layoutControlItem110.set_Location(new Point(0, 78));
			this.layoutControlItem110.set_Name("layoutControlItem110");
			this.layoutControlItem110.set_Size(new Size(298, 26));
			this.layoutControlItem110.set_Text("OTO KAPI YÜKSEKLİĞİ");
			this.layoutControlItem110.set_TextSize(new Size(241, 16));
			this.layoutControlItem117.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem117.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem117.set_Control(this.KasaGen);
			this.layoutControlItem117.set_Location(new Point(0, 104));
			this.layoutControlItem117.set_Name("layoutControlItem117");
			this.layoutControlItem117.set_Size(new Size(298, 26));
			this.layoutControlItem117.set_Text("OTO KAPI KASA GENİŞLİĞİ");
			this.layoutControlItem117.set_TextSize(new Size(241, 16));
			this.layoutControlItem118.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem118.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem118.set_Control(this.KasaDer);
			this.layoutControlItem118.set_Location(new Point(0, 130));
			this.layoutControlItem118.set_Name("layoutControlItem118");
			this.layoutControlItem118.set_Size(new Size(298, 26));
			this.layoutControlItem118.set_Text("OTO KAPI KASA DERİNLİĞİ");
			this.layoutControlItem118.set_TextSize(new Size(241, 16));
			this.layoutControlItem129.set_Control(this.KapiKorKasa);
			this.layoutControlItem129.set_Location(new Point(0, 156));
			this.layoutControlItem129.set_Name("layoutControlItem129");
			this.layoutControlItem129.set_Size(new Size(298, 24));
			this.layoutControlItem129.set_TextSize(new Size(0, 0));
			this.layoutControlItem129.set_TextVisible(false);
			this.layoutControlItem130.set_Control(this.KapiKirisProfil);
			this.layoutControlItem130.set_Location(new Point(0, 180));
			this.layoutControlItem130.set_Name("layoutControlItem130");
			this.layoutControlItem130.set_Size(new Size(298, 553));
			this.layoutControlItem130.set_TextSize(new Size(0, 0));
			this.layoutControlItem130.set_TextVisible(false);
			this.layoutControlItem26.set_Control(this.submitbutton);
			this.layoutControlItem26.set_Location(new Point(0, 698));
			this.layoutControlItem26.set_MaxSize(new Size(0, 60));
			this.layoutControlItem26.set_MinSize(new Size(120, 60));
			this.layoutControlItem26.set_Name("layoutControlItem26");
			this.layoutControlItem26.set_Size(new Size(301, 60));
			this.layoutControlItem26.set_SizeConstraintsType(2);
			this.layoutControlItem26.set_TextSize(new Size(0, 0));
			this.layoutControlItem26.set_TextVisible(false);
			this.label1.Location = new Point(7, 542);
			this.label1.Name = "label1";
			this.label1.Size = new Size(297, 159);
			this.label1.TabIndex = 1009;
			this.layoutControlItem35.set_Control(this.label1);
			this.layoutControlItem35.set_Location(new Point(0, 535));
			this.layoutControlItem35.set_Name("layoutControlItem35");
			this.layoutControlItem35.set_Size(new Size(301, 163));
			this.layoutControlItem35.set_TextSize(new Size(0, 0));
			this.layoutControlItem35.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.ObjectDefine);
			base.Name = "ascadpalet";
			base.Size = new Size(317, 799);
			base.Load += new EventHandler(this.ascadpalet_Load);
			this.ObjectDefine.EndInit();
			this.ObjectDefine.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.antetgrid.EndInit();
			this.gridView1.EndInit();
			this.xtraTabPage6.ResumeLayout(false);
			this.layoutControl2.EndInit();
			this.layoutControl2.ResumeLayout(false);
			this.dengekatsay.get_Properties().EndInit();
			this.agrtaneagr.get_Properties().EndInit();
			this.karkasagr.get_Properties().EndInit();
			this.beyamqpisuserdefined.get_Properties().EndInit();
			this.HalatCap.get_Properties().EndInit();
			this.TahCap.get_Properties().EndInit();
			this.HalatAdet.get_Properties().EndInit();
			this.SapCap.get_Properties().EndInit();
			this.MotorKw.get_Properties().EndInit();
			this.KabinP.get_Properties().EndInit();
			this.kabingenx.get_Properties().EndInit();
			this.BeyanHiz.get_Properties().EndInit();
			this.BeyanYuk.get_Properties().EndInit();
			this.kabinderx.get_Properties().EndInit();
			this.BeyanKisi.get_Properties().EndInit();
			this.layoutControlGroup2.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem10.EndInit();
			this.layoutControlItem12.EndInit();
			this.layoutControlItem16.EndInit();
			this.layoutControlItem18.EndInit();
			this.layoutControlItem20.EndInit();
			this.layoutControlItem21.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem13.EndInit();
			this.layoutControlItem14.EndInit();
			this.layoutControlItem15.EndInit();
			this.layoutControlItem17.EndInit();
			this.layoutControlItem19.EndInit();
			this.layoutControlItem11.EndInit();
			this.layoutControlItem22.EndInit();
			this.layoutControlItem23.EndInit();
			this.layoutControlItem25.EndInit();
			this.layoutControlItem27.EndInit();
			this.layoutControlItem28.EndInit();
			this.layoutControlItem29.EndInit();
			this.layoutControlItem30.EndInit();
			this.layoutControlItem32.EndInit();
			this.layoutControlItem116.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem34.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem33.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem9.EndInit();
			this.layoutControlItem31.EndInit();
			this.layoutControlItem24.EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			this.kesitlayeryapi.get_Properties().EndInit();
			this.searchLookUpEdit1View.EndInit();
			this.kesitlayertree.EndInit();
			this.xtraTabPage8.ResumeLayout(false);
			this.groupControl13.EndInit();
			this.groupControl13.ResumeLayout(false);
			this.layoutControl7.EndInit();
			this.layoutControl7.ResumeLayout(false);
			this.KapiKirisProfil.get_Properties().EndInit();
			this.KapiKorKasa.get_Properties().EndInit();
			this.KasaDer.get_Properties().EndInit();
			this.KasaGen.get_Properties().EndInit();
			this.KapiH.get_Properties().EndInit();
			this.KizakKalin.get_Properties().EndInit();
			this.ToplamKalin.get_Properties().EndInit();
			this.OtoKabinEsik.get_Properties().EndInit();
			this.layoutControlGroup7.EndInit();
			this.layoutControlItem61.EndInit();
			this.layoutControlItem63.EndInit();
			this.layoutControlItem109.EndInit();
			this.layoutControlItem110.EndInit();
			this.layoutControlItem117.EndInit();
			this.layoutControlItem118.EndInit();
			this.layoutControlItem129.EndInit();
			this.layoutControlItem130.EndInit();
			this.layoutControlItem26.EndInit();
			this.layoutControlItem35.EndInit();
			base.ResumeLayout(false);
		}
	}
}
