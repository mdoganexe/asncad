using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class masterproduct : Form
	{
		private abc1 xx = new abc1();

		public string urunne = "";

		public string guidne = "";

		private IContainer components = null;

		private GridControl gridControl2;

		private GridView gridView2;

		private SimpleButton simpleButton1;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private SimpleButton simpleButton2;

		private LayoutControlItem layoutControlItem3;

		public masterproduct()
		{
			this.InitializeComponent();
		}

		private void masterproduct_Load(object sender, EventArgs e)
		{
			this.gridControl2.set_DataSource(this.xx.dtta("select * from " + this.urunne + "master", ""));
			bool flag = this.gridView2.get_RowCount() > 0;
			if (flag)
			{
				try
				{
					this.gridView2.get_Columns().get_Item("sno").set_Visible(false);
					this.gridView2.get_Columns().get_Item("guid").set_Visible(false);
					this.gridView2.get_Columns().get_Item("guid").get_OptionsColumn().set_AllowEdit(false);
				}
				catch (Exception)
				{
				}
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			string text = "";
			for (int i = 0; i < this.gridView2.get_Columns().Count; i++)
			{
				bool flag = this.gridView2.get_Columns().get_Item(i).get_Visible() && this.gridView2.get_Columns().get_Item(i).get_FieldName() != "sec";
				if (flag)
				{
					text = text + this.gridView2.get_Columns().get_Item(i).get_FieldName() + ",";
				}
			}
			text = text.Substring(0, text.Length - 1);
			for (int j = 0; j < this.gridView2.get_RowCount(); j++)
			{
				bool flag2 = Convert.ToBoolean(this.gridView2.GetRowCellValue(j, "sec").ToString());
				if (flag2)
				{
					this.xx.oleupdate(string.Concat(new string[]
					{
						"insert into ",
						this.urunne,
						"(",
						text,
						",markaguid) select  ",
						text,
						",'",
						this.guidne,
						"' from ",
						this.urunne,
						"master where sno =",
						this.gridView2.GetRowCellValue(j, "sno").ToString()
					}), "");
				}
			}
			base.Close();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.xx.oleupdate(string.Concat(new string[]
			{
				"insert into ",
				this.urunne,
				"master (guid) values('",
				Guid.NewGuid().ToString(),
				"')"
			}), "");
			this.gridControl2.set_DataSource(this.xx.dtta("select * from " + this.urunne + "master", ""));
			bool flag = this.gridView2.get_RowCount() > 0;
			if (flag)
			{
				try
				{
					this.gridView2.get_Columns().get_Item("sno").set_Visible(false);
					this.gridView2.get_Columns().get_Item("guid").get_OptionsColumn().set_AllowEdit(false);
				}
				catch (Exception)
				{
				}
			}
		}

		private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			this.xx.oleupdate(this.xx.hucredeupdate("update " + this.urunne + "master set ", e.get_Column().get_ColumnType().ToString(), e.get_Column().get_FieldName(), e.get_Value().ToString(), " where sno=" + this.gridView2.GetRowCellValue(e.get_RowHandle(), "sno").ToString()), "");
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
			this.gridControl2 = new GridControl();
			this.gridView2 = new GridView();
			this.simpleButton1 = new SimpleButton();
			this.layoutControl1 = new LayoutControl();
			this.simpleButton2 = new SimpleButton();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.gridControl2.BeginInit();
			this.gridView2.BeginInit();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem3.BeginInit();
			base.SuspendLayout();
			this.gridControl2.get_EmbeddedNavigator().Margin = new Padding(2);
			this.gridControl2.Location = new Point(7, 7);
			this.gridControl2.set_MainView(this.gridView2);
			this.gridControl2.Margin = new Padding(2);
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new Size(851, 535);
			this.gridControl2.TabIndex = 5;
			this.gridControl2.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView2
			});
			this.gridView2.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Row().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView2.set_GridControl(this.gridControl2);
			this.gridView2.set_Name("gridView2");
			this.gridView2.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView2.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView2_CellValueChanged));
			this.simpleButton1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Location = new Point(7, 573);
			this.simpleButton1.Margin = new Padding(2);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(851, 23);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 6;
			this.simpleButton1.Text = "TABLO SEÇİMDE OLANLARI ÜRÜN İLE BİRLEŞTİR";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.layoutControl1.Controls.Add(this.simpleButton2);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.gridControl2);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(865, 603);
			this.layoutControl1.TabIndex = 7;
			this.layoutControl1.Text = "layoutControl1";
			this.simpleButton2.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162));
			this.simpleButton2.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton2.Location = new Point(7, 546);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(851, 23);
			this.simpleButton2.set_StyleController(this.layoutControl1);
			this.simpleButton2.TabIndex = 7;
			this.simpleButton2.Text = "ANA TABLOYA YENİ SATIR EKLE";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem3
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(865, 603));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.gridControl2);
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(855, 539));
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem2.set_Control(this.simpleButton1);
			this.layoutControlItem2.set_Location(new Point(0, 566));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(855, 27));
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			this.layoutControlItem3.set_Control(this.simpleButton2);
			this.layoutControlItem3.set_Location(new Point(0, 539));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(855, 27));
			this.layoutControlItem3.set_TextSize(new Size(0, 0));
			this.layoutControlItem3.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(865, 603);
			base.Controls.Add(this.layoutControl1);
			base.Margin = new Padding(2);
			base.Name = "masterproduct";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ÜRÜN ANA TABLOLARI";
			base.WindowState = FormWindowState.Maximized;
			base.Load += new EventHandler(this.masterproduct_Load);
			this.gridControl2.EndInit();
			this.gridView2.EndInit();
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem3.EndInit();
			base.ResumeLayout(false);
		}
	}
}
