using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class ascadcabin : Form
	{
		public ascad AscadDLL;

		private abc1 xx = new abc1();

		private DataTable yanpandata = new DataTable();

		private DataTable arkapandata = new DataTable();

		private IContainer components = null;

		private LayoutControl layoutControl1;

		private TextEdit textEdit3;

		private GroupControl groupControl2;

		private GridControl arkapangrd;

		private GridView gridView2;

		private SimpleButton simpleButton1;

		private GroupControl groupControl1;

		private GridControl yanpangrd;

		private GridView gridView1;

		private GridColumn gridColumn1;

		private GridColumn gridColumn2;

		private SimpleButton simpleButton4;

		private SimpleButton simpleButton3;

		private TextEdit tabderinlik;

		private TextEdit arkapanelsay;

		private TextEdit tabgenislik;

		private SimpleButton yanminus;

		private TextEdit yanpanelsay;

		private SimpleButton yanplus;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private LayoutControlItem layoutControlItem3;

		private LayoutControlItem layoutControlItem4;

		private LayoutControlItem layoutControlItem5;

		private LayoutControlItem layoutControlItem6;

		private LayoutControlItem layoutControlItem7;

		private LayoutControlItem layoutControlItem8;

		private LayoutControlItem layoutControlItem9;

		private LayoutControlItem layoutControlItem10;

		private LayoutControlItem layoutControlItem11;

		private LayoutControlItem layoutControlItem12;

		private GridColumn gridColumn3;

		private GridColumn gridColumn4;

		public ascadcabin()
		{
			this.InitializeComponent();
		}

		private void ascadcabin_Load(object sender, EventArgs e)
		{
			this.tabgenislik.Text = (Convert.ToInt32(this.AscadDLL.GetParamValue("L1KabinGen")) + 40).ToString();
			this.tabderinlik.Text = (Convert.ToInt32(this.AscadDLL.GetParamValue("L1KabinDer")) + 20).ToString();
			this.yanpandata = this.xx.dtta("select * from carpanel", "");
			this.arkapandata = this.xx.dtta("select * from carpanel", "");
			this.gridView1.set_ActiveFilterString("deger>0");
			this.gridView2.set_ActiveFilterString("deger>0");
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.tabgenislik.Text = (Convert.ToInt32(this.AscadDLL.GetParamValue("L1KabinGen")) + 40).ToString();
			this.tabderinlik.Text = (Convert.ToInt32(this.AscadDLL.GetParamValue("L1KabinDer")) + 20).ToString();
		}

		private void simpleButton5_Click(object sender, EventArgs e)
		{
			this.yanpanelsay.Text = (Convert.ToInt32(this.yanpanelsay.Text) + 1).ToString();
			decimal d = Convert.ToDecimal(this.tabderinlik.Text);
			int num = Convert.ToInt32(d / Convert.ToInt32(this.yanpanelsay.Text));
			this.yanpan0();
			for (int i = 0; i < Convert.ToInt32(this.yanpanelsay.Text); i++)
			{
				this.yanpandata.Rows[i]["deger"] = num;
			}
			this.yanpangrd.set_DataSource(this.yanpandata);
		}

		private void yanpan0()
		{
			for (int i = 0; i < this.yanpandata.Rows.Count; i++)
			{
				this.yanpandata.Rows[i]["deger"] = 0;
			}
		}

		private void arkapan0()
		{
			for (int i = 0; i < this.arkapandata.Rows.Count; i++)
			{
				this.arkapandata.Rows[i]["deger"] = 0;
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.yanpanelsay.Text = (Convert.ToInt32(this.yanpanelsay.Text) - 1).ToString();
			this.yanpan0();
			decimal d = Convert.ToDecimal(this.tabderinlik.Text);
			int num = Convert.ToInt32(d / Convert.ToInt32(this.yanpanelsay.Text));
			for (int i = 0; i < Convert.ToInt32(this.yanpanelsay.Text); i++)
			{
				this.yanpandata.Rows[i]["deger"] = num;
			}
			this.yanpangrd.set_DataSource(this.yanpandata);
		}

		private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			int num = Convert.ToInt32(this.tabderinlik.Text);
			int num2 = Convert.ToInt32(this.yanpanelsay.Text) - e.get_RowHandle() - 1;
			bool flag = num2 >= 1;
			if (flag)
			{
				int num3 = 0;
				for (int i = 0; i <= e.get_RowHandle(); i++)
				{
					num3 += Convert.ToInt32(this.gridView1.GetRowCellValue(i, "deger").ToString());
				}
				int num4 = num - num3;
				int num5 = Convert.ToInt32(num4 / num2);
				for (int j = e.get_RowHandle() + 1; j < Convert.ToInt32(this.yanpanelsay.Text); j++)
				{
					this.yanpandata.Rows[j]["deger"] = num5;
				}
				for (int k = Convert.ToInt32(this.yanpanelsay.Text); k < this.yanpandata.Rows.Count; k++)
				{
					this.yanpandata.Rows[k]["deger"] = 0;
				}
			}
			bool flag2 = num2 == 0;
			if (flag2)
			{
				MessageBox.Show("Bu panel uzunluğu önceki panellere bağlıdır");
			}
			this.yanpangrd.set_DataSource(this.yanpandata);
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			this.arkapanelsay.Text = (Convert.ToInt32(this.arkapanelsay.Text) + 1).ToString();
			decimal d = Convert.ToDecimal(this.tabgenislik.Text);
			int num = Convert.ToInt32(d / Convert.ToInt32(this.arkapanelsay.Text));
			this.arkapan0();
			for (int i = 0; i < Convert.ToInt32(this.arkapanelsay.Text); i++)
			{
				this.arkapandata.Rows[i]["deger"] = num;
			}
			this.arkapangrd.set_DataSource(this.arkapandata);
		}

		private void simpleButton4_Click(object sender, EventArgs e)
		{
			this.arkapanelsay.Text = (Convert.ToInt32(this.arkapanelsay.Text) - 1).ToString();
			decimal d = Convert.ToDecimal(this.tabgenislik.Text);
			int num = Convert.ToInt32(d / Convert.ToInt32(this.arkapanelsay.Text));
			this.arkapan0();
			for (int i = 0; i < Convert.ToInt32(this.arkapanelsay.Text); i++)
			{
				this.arkapandata.Rows[i]["deger"] = num;
			}
			this.arkapangrd.set_DataSource(this.arkapandata);
		}

		private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			int num = Convert.ToInt32(this.tabgenislik.Text);
			int num2 = Convert.ToInt32(this.arkapanelsay.Text) - e.get_RowHandle() - 1;
			bool flag = num2 >= 1;
			if (flag)
			{
				int num3 = 0;
				for (int i = 0; i <= e.get_RowHandle(); i++)
				{
					num3 += Convert.ToInt32(this.gridView2.GetRowCellValue(i, "deger").ToString());
				}
				int num4 = num - num3;
				int num5 = Convert.ToInt32(num4 / num2);
				for (int j = e.get_RowHandle() + 1; j < Convert.ToInt32(this.arkapanelsay.Text); j++)
				{
					this.arkapandata.Rows[j]["deger"] = num5;
				}
				for (int k = Convert.ToInt32(this.arkapanelsay.Text); k < this.yanpandata.Rows.Count; k++)
				{
					this.arkapandata.Rows[k]["deger"] = 0;
				}
			}
			bool flag2 = num2 == 0;
			if (flag2)
			{
				MessageBox.Show("Bu panel uzunluğu önceki panellere bağlıdır");
			}
			this.arkapangrd.set_DataSource(this.arkapandata);
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
			this.layoutControl1 = new LayoutControl();
			this.textEdit3 = new TextEdit();
			this.groupControl2 = new GroupControl();
			this.arkapangrd = new GridControl();
			this.gridView2 = new GridView();
			this.gridColumn3 = new GridColumn();
			this.gridColumn4 = new GridColumn();
			this.simpleButton1 = new SimpleButton();
			this.groupControl1 = new GroupControl();
			this.yanpangrd = new GridControl();
			this.gridView1 = new GridView();
			this.gridColumn1 = new GridColumn();
			this.gridColumn2 = new GridColumn();
			this.simpleButton4 = new SimpleButton();
			this.simpleButton3 = new SimpleButton();
			this.tabderinlik = new TextEdit();
			this.arkapanelsay = new TextEdit();
			this.tabgenislik = new TextEdit();
			this.yanminus = new SimpleButton();
			this.yanpanelsay = new TextEdit();
			this.yanplus = new SimpleButton();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem9 = new LayoutControlItem();
			this.layoutControlItem10 = new LayoutControlItem();
			this.layoutControlItem11 = new LayoutControlItem();
			this.layoutControlItem12 = new LayoutControlItem();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.textEdit3.get_Properties().BeginInit();
			this.groupControl2.BeginInit();
			this.groupControl2.SuspendLayout();
			this.arkapangrd.BeginInit();
			this.gridView2.BeginInit();
			this.groupControl1.BeginInit();
			this.groupControl1.SuspendLayout();
			this.yanpangrd.BeginInit();
			this.gridView1.BeginInit();
			this.tabderinlik.get_Properties().BeginInit();
			this.arkapanelsay.get_Properties().BeginInit();
			this.tabgenislik.get_Properties().BeginInit();
			this.yanpanelsay.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem9.BeginInit();
			this.layoutControlItem10.BeginInit();
			this.layoutControlItem11.BeginInit();
			this.layoutControlItem12.BeginInit();
			base.SuspendLayout();
			this.layoutControl1.Controls.Add(this.textEdit3);
			this.layoutControl1.Controls.Add(this.groupControl2);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.groupControl1);
			this.layoutControl1.Controls.Add(this.simpleButton4);
			this.layoutControl1.Controls.Add(this.simpleButton3);
			this.layoutControl1.Controls.Add(this.tabderinlik);
			this.layoutControl1.Controls.Add(this.arkapanelsay);
			this.layoutControl1.Controls.Add(this.tabgenislik);
			this.layoutControl1.Controls.Add(this.yanminus);
			this.layoutControl1.Controls.Add(this.yanpanelsay);
			this.layoutControl1.Controls.Add(this.yanplus);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(290, 608);
			this.layoutControl1.TabIndex = 2;
			this.layoutControl1.Text = "layoutControl1";
			this.textEdit3.Location = new Point(141, 579);
			this.textEdit3.Name = "textEdit3";
			this.textEdit3.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit3.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit3.Size = new Size(142, 22);
			this.textEdit3.set_StyleController(this.layoutControl1);
			this.textEdit3.TabIndex = 5;
			this.groupControl2.get_AppearanceCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.groupControl2.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.groupControl2.set_CaptionLocation(1);
			this.groupControl2.Controls.Add(this.arkapangrd);
			this.groupControl2.Location = new Point(7, 349);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new Size(276, 226);
			this.groupControl2.TabIndex = 3;
			this.groupControl2.Text = "ARKA PANELLER";
			this.arkapangrd.Dock = DockStyle.Fill;
			this.arkapangrd.Location = new Point(24, 1);
			this.arkapangrd.set_MainView(this.gridView2);
			this.arkapangrd.Name = "arkapangrd";
			this.arkapangrd.Size = new Size(250, 223);
			this.arkapangrd.TabIndex = 19;
			this.arkapangrd.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView2
			});
			this.gridView2.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Row().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView2.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn3,
				this.gridColumn4
			});
			this.gridView2.set_GridControl(this.arkapangrd);
			this.gridView2.set_Name("gridView2");
			this.gridView2.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView2.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView2_CellValueChanged));
			this.gridColumn3.set_Caption("PANELNO");
			this.gridColumn3.set_FieldName("panelno");
			this.gridColumn3.set_Name("gridColumn3");
			this.gridColumn3.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn3.set_Visible(true);
			this.gridColumn3.set_VisibleIndex(0);
			this.gridColumn3.set_Width(77);
			this.gridColumn4.set_Caption("ÖLÇÜ");
			this.gridColumn4.set_FieldName("deger");
			this.gridColumn4.set_Name("gridColumn4");
			this.gridColumn4.set_Visible(true);
			this.gridColumn4.set_VisibleIndex(1);
			this.gridColumn4.set_Width(133);
			this.simpleButton1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Location = new Point(7, 7);
			this.simpleButton1.Margin = new Padding(2);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(276, 23);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 0;
			this.simpleButton1.Text = "VERİLERİ GETİR";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.groupControl1.get_AppearanceCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.groupControl1.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.groupControl1.set_CaptionLocation(1);
			this.groupControl1.Controls.Add(this.yanpangrd);
			this.groupControl1.Location = new Point(7, 113);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new Size(276, 205);
			this.groupControl1.TabIndex = 2;
			this.groupControl1.Text = "YAN PANELLER";
			this.yanpangrd.Dock = DockStyle.Fill;
			this.yanpangrd.Location = new Point(24, 1);
			this.yanpangrd.set_MainView(this.gridView1);
			this.yanpangrd.Name = "yanpangrd";
			this.yanpangrd.Size = new Size(250, 202);
			this.yanpangrd.TabIndex = 19;
			this.yanpangrd.get_ViewCollection().AddRange(new BaseView[]
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
			this.gridView1.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
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
				this.gridColumn2
			});
			this.gridView1.set_GridControl(this.yanpangrd);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView1.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView1_CellValueChanged));
			this.gridColumn1.set_Caption("PANELNO");
			this.gridColumn1.set_FieldName("panelno");
			this.gridColumn1.set_Name("gridColumn1");
			this.gridColumn1.set_Visible(true);
			this.gridColumn1.set_VisibleIndex(0);
			this.gridColumn1.set_Width(68);
			this.gridColumn2.set_Caption("ÖLÇÜ");
			this.gridColumn2.set_FieldName("deger");
			this.gridColumn2.set_Name("gridColumn2");
			this.gridColumn2.set_Visible(true);
			this.gridColumn2.set_VisibleIndex(1);
			this.gridColumn2.set_Width(142);
			this.simpleButton4.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton4.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton4.Location = new Point(244, 322);
			this.simpleButton4.Name = "simpleButton4";
			this.simpleButton4.Size = new Size(39, 23);
			this.simpleButton4.set_StyleController(this.layoutControl1);
			this.simpleButton4.TabIndex = 17;
			this.simpleButton4.Text = "   -   ";
			this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
			this.simpleButton3.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton3.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton3.Location = new Point(195, 322);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new Size(45, 23);
			this.simpleButton3.set_StyleController(this.layoutControl1);
			this.simpleButton3.TabIndex = 18;
			this.simpleButton3.Text = "   +   ";
			this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
			this.tabderinlik.Location = new Point(141, 60);
			this.tabderinlik.Name = "tabderinlik";
			this.tabderinlik.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tabderinlik.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.tabderinlik.Size = new Size(142, 22);
			this.tabderinlik.set_StyleController(this.layoutControl1);
			this.tabderinlik.TabIndex = 5;
			this.arkapanelsay.set_EditValue("3");
			this.arkapanelsay.Enabled = false;
			this.arkapanelsay.set_EnterMoveNextControl(true);
			this.arkapanelsay.Location = new Point(141, 322);
			this.arkapanelsay.Name = "arkapanelsay";
			this.arkapanelsay.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.arkapanelsay.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.arkapanelsay.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.arkapanelsay.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.arkapanelsay.Size = new Size(50, 22);
			this.arkapanelsay.set_StyleController(this.layoutControl1);
			this.arkapanelsay.TabIndex = 14;
			this.tabgenislik.Location = new Point(141, 34);
			this.tabgenislik.Name = "tabgenislik";
			this.tabgenislik.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tabgenislik.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.tabgenislik.Size = new Size(142, 22);
			this.tabgenislik.set_StyleController(this.layoutControl1);
			this.tabgenislik.TabIndex = 4;
			this.yanminus.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.yanminus.get_Appearance().get_Options().set_UseFont(true);
			this.yanminus.Location = new Point(244, 86);
			this.yanminus.Name = "yanminus";
			this.yanminus.Size = new Size(39, 23);
			this.yanminus.set_StyleController(this.layoutControl1);
			this.yanminus.TabIndex = 16;
			this.yanminus.Text = "   -   ";
			this.yanminus.Click += new EventHandler(this.simpleButton2_Click);
			this.yanpanelsay.set_EditValue("3");
			this.yanpanelsay.Enabled = false;
			this.yanpanelsay.set_EnterMoveNextControl(true);
			this.yanpanelsay.Location = new Point(141, 86);
			this.yanpanelsay.Name = "yanpanelsay";
			this.yanpanelsay.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.yanpanelsay.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.yanpanelsay.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.yanpanelsay.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.yanpanelsay.Size = new Size(50, 22);
			this.yanpanelsay.set_StyleController(this.layoutControl1);
			this.yanpanelsay.TabIndex = 13;
			this.yanplus.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.yanplus.get_Appearance().get_Options().set_UseFont(true);
			this.yanplus.Location = new Point(195, 86);
			this.yanplus.Name = "yanplus";
			this.yanplus.Size = new Size(45, 23);
			this.yanplus.set_StyleController(this.layoutControl1);
			this.yanplus.TabIndex = 15;
			this.yanplus.Text = "   +   ";
			this.yanplus.Click += new EventHandler(this.simpleButton5_Click);
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem3,
				this.layoutControlItem4,
				this.layoutControlItem5,
				this.layoutControlItem6,
				this.layoutControlItem7,
				this.layoutControlItem8,
				this.layoutControlItem9,
				this.layoutControlItem10,
				this.layoutControlItem11,
				this.layoutControlItem12
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(290, 608));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem1.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem1.set_Control(this.tabgenislik);
			this.layoutControlItem1.set_Location(new Point(0, 27));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(280, 26));
			this.layoutControlItem1.set_Text("TABAN GENİŞLİĞİ");
			this.layoutControlItem1.set_TextSize(new Size(131, 16));
			this.layoutControlItem2.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem2.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem2.set_Control(this.tabderinlik);
			this.layoutControlItem2.set_Location(new Point(0, 53));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(280, 26));
			this.layoutControlItem2.set_Text("TABAN DERİNLİĞİ");
			this.layoutControlItem2.set_TextSize(new Size(131, 16));
			this.layoutControlItem3.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem3.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem3.set_Control(this.yanpanelsay);
			this.layoutControlItem3.set_Location(new Point(0, 79));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(188, 27));
			this.layoutControlItem3.set_Text("YAN PANEL SAYISI");
			this.layoutControlItem3.set_TextSize(new Size(131, 16));
			this.layoutControlItem4.set_Control(this.yanplus);
			this.layoutControlItem4.set_Location(new Point(188, 79));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(49, 27));
			this.layoutControlItem4.set_TextSize(new Size(0, 0));
			this.layoutControlItem4.set_TextVisible(false);
			this.layoutControlItem5.set_Control(this.yanminus);
			this.layoutControlItem5.set_Location(new Point(237, 79));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(43, 27));
			this.layoutControlItem5.set_TextSize(new Size(0, 0));
			this.layoutControlItem5.set_TextVisible(false);
			this.layoutControlItem6.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem6.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem6.set_Control(this.arkapanelsay);
			this.layoutControlItem6.set_Location(new Point(0, 315));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(188, 27));
			this.layoutControlItem6.set_Text("ARKA PANEL SAYISI");
			this.layoutControlItem6.set_TextSize(new Size(131, 16));
			this.layoutControlItem7.set_Control(this.simpleButton3);
			this.layoutControlItem7.set_Location(new Point(188, 315));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(49, 27));
			this.layoutControlItem7.set_TextSize(new Size(0, 0));
			this.layoutControlItem7.set_TextVisible(false);
			this.layoutControlItem8.set_Control(this.simpleButton4);
			this.layoutControlItem8.set_Location(new Point(237, 315));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(43, 27));
			this.layoutControlItem8.set_TextSize(new Size(0, 0));
			this.layoutControlItem8.set_TextVisible(false);
			this.layoutControlItem9.set_Control(this.simpleButton1);
			this.layoutControlItem9.set_Location(new Point(0, 0));
			this.layoutControlItem9.set_Name("layoutControlItem9");
			this.layoutControlItem9.set_Size(new Size(280, 27));
			this.layoutControlItem9.set_TextSize(new Size(0, 0));
			this.layoutControlItem9.set_TextVisible(false);
			this.layoutControlItem10.set_Control(this.groupControl1);
			this.layoutControlItem10.set_Location(new Point(0, 106));
			this.layoutControlItem10.set_Name("layoutControlItem10");
			this.layoutControlItem10.set_Size(new Size(280, 209));
			this.layoutControlItem10.set_TextSize(new Size(0, 0));
			this.layoutControlItem10.set_TextVisible(false);
			this.layoutControlItem11.set_Control(this.groupControl2);
			this.layoutControlItem11.set_Location(new Point(0, 342));
			this.layoutControlItem11.set_Name("layoutControlItem11");
			this.layoutControlItem11.set_Size(new Size(280, 230));
			this.layoutControlItem11.set_TextSize(new Size(0, 0));
			this.layoutControlItem11.set_TextVisible(false);
			this.layoutControlItem12.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem12.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem12.set_Control(this.textEdit3);
			this.layoutControlItem12.set_Location(new Point(0, 572));
			this.layoutControlItem12.set_Name("layoutControlItem12");
			this.layoutControlItem12.set_Size(new Size(280, 26));
			this.layoutControlItem12.set_Text("TABAN BÖLME SAY");
			this.layoutControlItem12.set_TextSize(new Size(131, 16));
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(290, 608);
			base.Controls.Add(this.layoutControl1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ascadcabin";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "CAR DESİGN";
			base.Load += new EventHandler(this.ascadcabin_Load);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.textEdit3.get_Properties().EndInit();
			this.groupControl2.EndInit();
			this.groupControl2.ResumeLayout(false);
			this.arkapangrd.EndInit();
			this.gridView2.EndInit();
			this.groupControl1.EndInit();
			this.groupControl1.ResumeLayout(false);
			this.yanpangrd.EndInit();
			this.gridView1.EndInit();
			this.tabderinlik.get_Properties().EndInit();
			this.arkapanelsay.get_Properties().EndInit();
			this.tabgenislik.get_Properties().EndInit();
			this.yanpanelsay.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem9.EndInit();
			this.layoutControlItem10.EndInit();
			this.layoutControlItem11.EndInit();
			this.layoutControlItem12.EndInit();
			base.ResumeLayout(false);
		}
	}
}
