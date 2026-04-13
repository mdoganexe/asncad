using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraVerticalGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class productsec : Form
	{
		private abc1 xx = new abc1();

		public myData FormMyData;

		public string urunne = "";

		private string tabloya = "";

		private string actfilterstr = "";

		private IContainer components = null;

		private TreeList treeList1;

		private GridControl gridControl1;

		private GridView gridView1;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private GridColumn gridColumn1;

		private GridColumn gridColumn2;

		private GridColumn gridColumn3;

		private GridColumn gridColumn4;

		private VGridControl vGridControl1;

		private LayoutControlItem layoutControlItem3;

		public productsec()
		{
			this.InitializeComponent();
		}

		private void kisityukle()
		{
			this.gridControl1.set_DataSource(this.xx.dtta("select uk.kisitad,uk.kisitturu,uk.kullan,'' as degerler from urunler u,urunkisit uk where u.urunno=urunid and urunad='" + this.urunne + "' ", ""));
			for (int i = 0; i < this.gridView1.get_RowCount(); i++)
			{
				this.tabloya = this.tabloya + this.gridView1.GetRowCellValue(i, "kisitad").ToString() + ",";
				try
				{
					this.gridView1.SetRowCellValue(i, "degerler", this.griddeger(this.gridView1.GetRowCellValue(i, "kisitad").ToString()));
					this.actfilterstr = string.Concat(new string[]
					{
						this.actfilterstr,
						this.gridView1.GetRowCellValue(i, "kisitad").ToString(),
						" ",
						this.gridView1.GetRowCellValue(i, "kisitturu").ToString(),
						this.gridView1.GetRowCellValue(i, "degerler").ToString(),
						" and "
					});
				}
				catch (Exception)
				{
				}
			}
			this.tabloya = this.tabloya.Substring(0, this.tabloya.Length - 1);
			this.actfilterstr = this.actfilterstr.Substring(0, this.actfilterstr.Length - 4);
			this.urunyukle();
			this.treeList1.set_ActiveFilterString(this.actfilterstr);
		}

		private string griddeger(string gelen)
		{
			string result = "";
			try
			{
				result = this.FormMyData.GetType().GetProperty(gelen).GetValue(this.FormMyData).ToString();
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}

		private void urunyukle()
		{
			try
			{
				DataTable table = this.xx.dtta("select sno,model,guid,markaguid," + this.tabloya + " from " + this.urunne, "");
				DataTable dataTable = this.xx.dtta("select marka,guid from " + this.urunne + "marka", "");
				dataTable.Merge(table);
				this.treeList1.set_DataSource(dataTable);
				this.treeList1.ExpandAll();
				this.treeList1.get_Columns().get_Item("sno").set_Visible(false);
				this.treeList1.get_Columns().get_Item("model").get_AppearanceCell().set_Font(new Font("Tahoma", 10f, FontStyle.Underline));
				this.treeList1.get_Columns().get_Item("model").get_AppearanceCell().set_ForeColor(Color.Blue);
				this.treeList1.get_Columns().get_Item("model").get_AppearanceCell().get_Options().set_UseFont(true);
				this.treeList1.get_Columns().get_Item("model").get_AppearanceCell().get_Options().set_UseForeColor(true);
				for (int i = 0; i < this.treeList1.get_Columns().Count; i++)
				{
					this.treeList1.get_Columns().get_Item(i).get_OptionsColumn().set_AllowEdit(false);
				}
			}
			catch (Exception)
			{
			}
		}

		private void productsec_Load(object sender, EventArgs e)
		{
			this.kisityukle();
		}

		private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			this.actfilterstr = "";
			bool flag = e.get_Column().get_FieldName() == "kullan";
			if (flag)
			{
				for (int i = 0; i < this.gridView1.get_RowCount(); i++)
				{
					try
					{
						bool flag2 = Convert.ToBoolean(this.gridView1.GetRowCellValue(i, "kullan"));
						if (flag2)
						{
							this.actfilterstr = string.Concat(new string[]
							{
								this.actfilterstr,
								this.gridView1.GetRowCellValue(i, "kisitad").ToString(),
								" ",
								this.gridView1.GetRowCellValue(i, "kisitturu").ToString(),
								this.gridView1.GetRowCellValue(i, "degerler").ToString(),
								" and "
							});
						}
					}
					catch (Exception)
					{
					}
				}
				this.actfilterstr = this.actfilterstr.Substring(0, this.actfilterstr.Length - 4);
				this.treeList1.set_ActiveFilterString(this.actfilterstr);
			}
		}

		private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
		{
			bool hasChildren = e.get_Node().get_HasChildren();
			bool flag = !hasChildren;
			if (flag)
			{
				TreeListColumn treeListColumn = this.treeList1.get_Columns().get_Item("sno");
				string str = this.treeList1.get_FocusedNode().GetValue(treeListColumn).ToString();
				this.vGridControl1.set_DataSource(this.xx.dtta("select * from " + this.urunne + " where sno =" + str, ""));
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
			this.treeList1 = new TreeList();
			this.gridControl1 = new GridControl();
			this.gridView1 = new GridView();
			this.gridColumn1 = new GridColumn();
			this.gridColumn2 = new GridColumn();
			this.gridColumn3 = new GridColumn();
			this.gridColumn4 = new GridColumn();
			this.layoutControl1 = new LayoutControl();
			this.vGridControl1 = new VGridControl();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.treeList1.BeginInit();
			this.gridControl1.BeginInit();
			this.gridView1.BeginInit();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.vGridControl1.BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem3.BeginInit();
			base.SuspendLayout();
			this.treeList1.get_Appearance().get_BandPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_BandPanel().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_Caption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_Caption().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_HeaderPanelBackground().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_HeaderPanelBackground().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_Row().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_TreeLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_TreeLine().get_Options().set_UseFont(true);
			this.treeList1.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.treeList1.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.treeList1.Cursor = Cursors.Default;
			this.treeList1.set_KeyFieldName("guid");
			this.treeList1.Location = new Point(12, 223);
			this.treeList1.Name = "treeList1";
			this.treeList1.get_OptionsBehavior().set_EnableFiltering(true);
			this.treeList1.get_OptionsFilter().set_FilterMode(3);
			this.treeList1.get_OptionsMenu().set_ShowConditionalFormattingItem(true);
			this.treeList1.get_OptionsView().set_ShowAutoFilterRow(true);
			this.treeList1.get_OptionsView().set_ShowFilterPanelMode(1);
			this.treeList1.set_ParentFieldName("markaguid");
			this.treeList1.Size = new Size(349, 467);
			this.treeList1.TabIndex = 0;
			this.treeList1.add_FocusedNodeChanged(new FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged));
			this.gridControl1.get_EmbeddedNavigator().Margin = new Padding(2);
			this.gridControl1.Location = new Point(12, 12);
			this.gridControl1.set_MainView(this.gridView1);
			this.gridControl1.Margin = new Padding(2);
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new Size(349, 207);
			this.gridControl1.TabIndex = 1;
			this.gridControl1.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView1
			});
			this.gridView1.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Row().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView1.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn1,
				this.gridColumn2,
				this.gridColumn3,
				this.gridColumn4
			});
			this.gridView1.set_GridControl(this.gridControl1);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView1.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView1_CellValueChanged));
			this.gridColumn1.set_Caption("KISIT ADI");
			this.gridColumn1.set_FieldName("kisitad");
			this.gridColumn1.set_Name("gridColumn1");
			this.gridColumn1.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn1.set_Visible(true);
			this.gridColumn1.set_VisibleIndex(0);
			this.gridColumn2.set_Caption("KISIT TÜRÜ");
			this.gridColumn2.set_FieldName("kisitturu");
			this.gridColumn2.set_Name("gridColumn2");
			this.gridColumn2.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn2.set_Visible(true);
			this.gridColumn2.set_VisibleIndex(1);
			this.gridColumn3.set_Caption("DEĞER");
			this.gridColumn3.set_FieldName("degerler");
			this.gridColumn3.set_Name("gridColumn3");
			this.gridColumn3.set_Visible(true);
			this.gridColumn3.set_VisibleIndex(2);
			this.gridColumn4.set_Caption("Kullan");
			this.gridColumn4.set_FieldName("kullan");
			this.gridColumn4.set_Name("gridColumn4");
			this.gridColumn4.set_Visible(true);
			this.gridColumn4.set_VisibleIndex(3);
			this.layoutControl1.Controls.Add(this.vGridControl1);
			this.layoutControl1.Controls.Add(this.gridControl1);
			this.layoutControl1.Controls.Add(this.treeList1);
			this.layoutControl1.Dock = DockStyle.Left;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Margin = new Padding(2);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(753, 702);
			this.layoutControl1.TabIndex = 2;
			this.layoutControl1.Text = "layoutControl1";
			this.vGridControl1.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_Category().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.vGridControl1.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.vGridControl1.set_LayoutStyle(1);
			this.vGridControl1.Location = new Point(365, 12);
			this.vGridControl1.Margin = new Padding(2);
			this.vGridControl1.Name = "vGridControl1";
			this.vGridControl1.Size = new Size(376, 678);
			this.vGridControl1.TabIndex = 4;
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
			this.layoutControlGroup1.get_OptionsItemText().set_TextToControlDistance(4);
			this.layoutControlGroup1.set_Size(new Size(753, 702));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.gridControl1);
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(353, 211));
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem2.set_Control(this.treeList1);
			this.layoutControlItem2.set_Location(new Point(0, 211));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(353, 471));
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			this.layoutControlItem3.set_Control(this.vGridControl1);
			this.layoutControlItem3.set_Location(new Point(353, 0));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(380, 682));
			this.layoutControlItem3.set_TextSize(new Size(0, 0));
			this.layoutControlItem3.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1151, 702);
			base.Controls.Add(this.layoutControl1);
			base.Name = "productsec";
			this.Text = "ÜRÜN SEÇİM EKRANI";
			base.WindowState = FormWindowState.Maximized;
			base.Load += new EventHandler(this.productsec_Load);
			this.treeList1.EndInit();
			this.gridControl1.EndInit();
			this.gridView1.EndInit();
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.vGridControl1.EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem3.EndInit();
			base.ResumeLayout(false);
		}
	}
}
