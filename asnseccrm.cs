using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class asnseccrm : Form
	{
		private string dosyalamaali = "C:\\SZG\\FILES\\montaj";

		private abc1 xx = new abc1();

		public string asansorno = "";

		public string dwgid = "";

		private IContainer components = null;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private GridControl gridControl1;

		private GridView gridView1;

		private LayoutControlItem layoutControlItem3;

		private GridColumn gridColumn1;

		private GridColumn gridColumn2;

		private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;

		private GridColumn gridColumn3;

		private GridColumn gridColumn4;

		private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;

		public asnseccrm()
		{
			this.InitializeComponent();
		}

		private void asnneler()
		{
			bool @checked = this.radioButton1.Checked;
			string str;
			if (@checked)
			{
				str = " where onolcu=100 and cizim=0";
			}
			else
			{
				str = "";
			}
			this.gridControl1.set_DataSource(this.xx.crmdtta("select * from asnasnler " + str, ""));
		}

		private void asnseccrm_Load(object sender, EventArgs e)
		{
			this.asnneler();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			this.asnneler();
		}

		private void gridView1_MouseDown(object sender, MouseEventArgs e)
		{
			GridView gridView = sender as GridView;
			GridHitInfo gridHitInfo = gridView.CalcHitInfo(this.gridControl1.PointToClient(Control.MousePosition));
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				bool flag2 = gridHitInfo.get_InRowCell() && gridHitInfo.get_RowHandle() >= 0 && gridHitInfo.get_Column().get_FieldName() == "gridColumn3";
				if (flag2)
				{
					this.asansorno = this.gridView1.GetRowCellValue(gridHitInfo.get_RowHandle(), "sno").ToString();
					this.dwgid = this.gridView1.GetRowCellValue(gridHitInfo.get_RowHandle(), "dwgguid").ToString();
					bool flag3 = this.dwgid == "";
					if (flag3)
					{
						this.dwgid = default(Guid).ToString();
						this.xx.crmoleupdate("update asnasnler set dwgguid='" + this.dwgid + "' where sno=" + this.asansorno, "");
					}
					try
					{
						Process.Start(this.dosyalamaali + "\\" + this.asansorno + "\\onolcu\\");
					}
					catch (Exception var_6_130)
					{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(asnseccrm));
			this.layoutControl1 = new LayoutControl();
			this.gridControl1 = new GridControl();
			this.gridView1 = new GridView();
			this.gridColumn1 = new GridColumn();
			this.repositoryItemHyperLinkEdit1 = new RepositoryItemHyperLinkEdit();
			this.gridColumn2 = new GridColumn();
			this.gridColumn3 = new GridColumn();
			this.repositoryItemHyperLinkEdit2 = new RepositoryItemHyperLinkEdit();
			this.gridColumn4 = new GridColumn();
			this.radioButton2 = new RadioButton();
			this.radioButton1 = new RadioButton();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.gridControl1.BeginInit();
			this.gridView1.BeginInit();
			this.repositoryItemHyperLinkEdit1.BeginInit();
			this.repositoryItemHyperLinkEdit2.BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem3.BeginInit();
			base.SuspendLayout();
			this.layoutControl1.Controls.Add(this.gridControl1);
			this.layoutControl1.Controls.Add(this.radioButton2);
			this.layoutControl1.Controls.Add(this.radioButton1);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(384, 552);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			this.gridControl1.Location = new Point(7, 65);
			this.gridControl1.set_MainView(this.gridView1);
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.get_RepositoryItems().AddRange(new RepositoryItem[]
			{
				this.repositoryItemHyperLinkEdit1,
				this.repositoryItemHyperLinkEdit2
			});
			this.gridControl1.Size = new Size(370, 480);
			this.gridControl1.TabIndex = 6;
			this.gridControl1.get_ViewCollection().AddRange(new BaseView[]
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
				this.gridColumn3,
				this.gridColumn2,
				this.gridColumn4
			});
			this.gridView1.set_GridControl(this.gridControl1);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsView().set_ShowAutoFilterRow(true);
			this.gridView1.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView1.add_MouseDown(new MouseEventHandler(this.gridView1_MouseDown));
			this.gridColumn1.set_Caption("ASANSÖR ADI");
			this.gridColumn1.set_ColumnEdit(this.repositoryItemHyperLinkEdit1);
			this.gridColumn1.set_FieldName("asnaciklama");
			this.gridColumn1.set_Name("gridColumn1");
			this.gridColumn1.set_Visible(true);
			this.gridColumn1.set_VisibleIndex(0);
			this.gridColumn1.set_Width(297);
			this.repositoryItemHyperLinkEdit1.set_AutoHeight(false);
			this.repositoryItemHyperLinkEdit1.set_Name("repositoryItemHyperLinkEdit1");
			this.gridColumn2.set_Caption("asanno");
			this.gridColumn2.set_FieldName("sno");
			this.gridColumn2.set_Name("gridColumn2");
			this.gridColumn3.set_Caption("Aç");
			this.gridColumn3.set_ColumnEdit(this.repositoryItemHyperLinkEdit2);
			this.gridColumn3.set_FieldName("gridColumn3");
			this.gridColumn3.set_Name("gridColumn3");
			this.gridColumn3.set_UnboundType(4);
			this.gridColumn3.set_Visible(true);
			this.gridColumn3.set_VisibleIndex(1);
			this.gridColumn3.set_Width(55);
			this.repositoryItemHyperLinkEdit2.set_AutoHeight(false);
			this.repositoryItemHyperLinkEdit2.set_Image((Image)componentResourceManager.GetObject("repositoryItemHyperLinkEdit2.Image"));
			this.repositoryItemHyperLinkEdit2.set_Name("repositoryItemHyperLinkEdit2");
			this.gridColumn4.set_Caption("dwgid");
			this.gridColumn4.set_FieldName("dwgid");
			this.gridColumn4.set_Name("gridColumn4");
			this.radioButton2.Location = new Point(7, 36);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new Size(370, 25);
			this.radioButton2.TabIndex = 5;
			this.radioButton2.Text = "TÜM İŞLER";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new Point(7, 7);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new Size(370, 25);
			this.radioButton1.TabIndex = 4;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "SADECE BEKLEYEN İŞLER";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
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
			this.layoutControlGroup1.set_Size(new Size(384, 552));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.radioButton1);
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(374, 29));
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem2.set_Control(this.radioButton2);
			this.layoutControlItem2.set_Location(new Point(0, 29));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(374, 29));
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			this.layoutControlItem3.set_Control(this.gridControl1);
			this.layoutControlItem3.set_Location(new Point(0, 58));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(374, 484));
			this.layoutControlItem3.set_TextSize(new Size(0, 0));
			this.layoutControlItem3.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(384, 552);
			base.Controls.Add(this.layoutControl1);
			base.Name = "asnseccrm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ASANSÖR SEÇİM EKRANI";
			base.Load += new EventHandler(this.asnseccrm_Load);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.gridControl1.EndInit();
			this.gridView1.EndInit();
			this.repositoryItemHyperLinkEdit1.EndInit();
			this.repositoryItemHyperLinkEdit2.EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem3.EndInit();
			base.ResumeLayout(false);
		}
	}
}
