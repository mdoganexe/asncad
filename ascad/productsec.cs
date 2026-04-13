namespace ascad
{
    using DevExpress.Utils;
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

    public class productsec : Form
    {
        private string actfilterstr = "";
        private IContainer components = null;
        public myData FormMyData;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridControl gridControl1;
        private GridView gridView1;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private string tabloya = "";
        private TreeList treeList1;
        public string urunne = "";
        private VGridControl vGridControl1;
        private abc1 xx = new abc1();

        public productsec()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private string griddeger(string gelen)
        {
            try
            {
                return this.FormMyData.GetType().GetProperty(gelen).GetValue(this.FormMyData).ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.actfilterstr = "";
            if (e.Column.FieldName == "kullan")
            {
                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(this.gridView1.GetRowCellValue(i, "kullan")))
                        {
                            string[] textArray1 = new string[] { this.actfilterstr, this.gridView1.GetRowCellValue(i, "kisitad").ToString(), " ", this.gridView1.GetRowCellValue(i, "kisitturu").ToString(), this.gridView1.GetRowCellValue(i, "degerler").ToString(), " and " };
                            this.actfilterstr = string.Concat(textArray1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                this.actfilterstr = this.actfilterstr.Substring(0, this.actfilterstr.Length - 4);
                this.treeList1.ActiveFilterString = this.actfilterstr;
            }
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
            this.treeList1.Appearance.BandPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.BandPanel.Options.UseFont = true;
            this.treeList1.Appearance.Caption.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.Caption.Options.UseFont = true;
            this.treeList1.Appearance.CustomizationFormHint.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.treeList1.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.Empty.Options.UseFont = true;
            this.treeList1.Appearance.EvenRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.EvenRow.Options.UseFont = true;
            this.treeList1.Appearance.FilterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.FilterPanel.Options.UseFont = true;
            this.treeList1.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.FixedLine.Options.UseFont = true;
            this.treeList1.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList1.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList1.Appearance.FooterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.FooterPanel.Options.UseFont = true;
            this.treeList1.Appearance.GroupButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.GroupButton.Options.UseFont = true;
            this.treeList1.Appearance.GroupFooter.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.GroupFooter.Options.UseFont = true;
            this.treeList1.Appearance.HeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList1.Appearance.HeaderPanelBackground.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.HeaderPanelBackground.Options.UseFont = true;
            this.treeList1.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeList1.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.HorzLine.Options.UseFont = true;
            this.treeList1.Appearance.OddRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.OddRow.Options.UseFont = true;
            this.treeList1.Appearance.Preview.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.Preview.Options.UseFont = true;
            this.treeList1.Appearance.Row.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.Row.Options.UseFont = true;
            this.treeList1.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList1.Appearance.TreeLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.TreeLine.Options.UseFont = true;
            this.treeList1.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.treeList1.Appearance.VertLine.Options.UseFont = true;
            this.treeList1.Cursor = Cursors.Default;
            this.treeList1.KeyFieldName = "guid";
            this.treeList1.Location = new Point(12, 0xdf);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsFilter.FilterMode = FilterMode.Extended;
            this.treeList1.OptionsMenu.ShowConditionalFormattingItem = true;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
            this.treeList1.ParentFieldName = "markaguid";
            this.treeList1.Size = new Size(0x15d, 0x1d3);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.gridControl1.EmbeddedNavigator.Margin = new Padding(2);
            this.gridControl1.Location = new Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(0x15d, 0xcf);
            this.gridControl1.TabIndex = 1;
            BaseView[] views = new BaseView[] { this.gridView1 };
            this.gridControl1.ViewCollection.AddRange(views);
            this.gridView1.Appearance.ColumnFilterButton.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gridView1.Appearance.CustomizationFormHint.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gridView1.Appearance.DetailTip.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.DetailTip.Options.UseFont = true;
            this.gridView1.Appearance.Empty.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FilterCloseButton.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView1.Appearance.FilterPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FixedLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FixedLine.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupButton.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupButton.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.TopNewRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            GridColumn[] columns = new GridColumn[] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4 };
            this.gridView1.Columns.AddRange(columns);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridColumn1.Caption = "KISIT ADI";
            this.gridColumn1.FieldName = "kisitad";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn2.Caption = "KISIT T\x00dcR\x00dc";
            this.gridColumn2.FieldName = "kisitturu";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn3.Caption = "DEĞER";
            this.gridColumn3.FieldName = "degerler";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn4.Caption = "Kullan";
            this.gridColumn4.FieldName = "kullan";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.layoutControl1.Controls.Add(this.vGridControl1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.treeList1);
            this.layoutControl1.Dock = DockStyle.Left;
            this.layoutControl1.Location = new Point(0, 0);
            this.layoutControl1.Margin = new Padding(2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x2f1, 0x2be);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            this.vGridControl1.Appearance.BandBorder.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.BandBorder.Options.UseFont = true;
            this.vGridControl1.Appearance.Category.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.Category.Options.UseFont = true;
            this.vGridControl1.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.vGridControl1.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.vGridControl1.Appearance.DisabledRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.DisabledRow.Options.UseFont = true;
            this.vGridControl1.Appearance.Empty.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.Empty.Options.UseFont = true;
            this.vGridControl1.Appearance.ExpandButton.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.ExpandButton.Options.UseFont = true;
            this.vGridControl1.Appearance.FixedLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.FixedLine.Options.UseFont = true;
            this.vGridControl1.Appearance.FocusedCell.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.FocusedCell.Options.UseFont = true;
            this.vGridControl1.Appearance.FocusedRecord.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.FocusedRecord.Options.UseFont = true;
            this.vGridControl1.Appearance.FocusedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.FocusedRow.Options.UseFont = true;
            this.vGridControl1.Appearance.HideSelectionRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.vGridControl1.Appearance.HorzLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.HorzLine.Options.UseFont = true;
            this.vGridControl1.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.vGridControl1.Appearance.ModifiedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.ModifiedRow.Options.UseFont = true;
            this.vGridControl1.Appearance.PressedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.PressedRow.Options.UseFont = true;
            this.vGridControl1.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.vGridControl1.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.vGridControl1.Appearance.RecordValue.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.RecordValue.Options.UseFont = true;
            this.vGridControl1.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vGridControl1.Appearance.SelectedCell.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.SelectedCell.Options.UseFont = true;
            this.vGridControl1.Appearance.SelectedRecord.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.SelectedRecord.Options.UseFont = true;
            this.vGridControl1.Appearance.SelectedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.SelectedRow.Options.UseFont = true;
            this.vGridControl1.Appearance.VertLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.VertLine.Options.UseFont = true;
            this.vGridControl1.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.vGridControl1.Location = new Point(0x16d, 12);
            this.vGridControl1.Margin = new Padding(2);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.Size = new Size(0x178, 0x2a6);
            this.vGridControl1.TabIndex = 4;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new Size(0x2f1, 0x2be);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x161, 0xd3);
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem2.Control = this.treeList1;
            this.layoutControlItem2.Location = new Point(0, 0xd3);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x161, 0x1d7);
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem3.Control = this.vGridControl1;
            this.layoutControlItem3.Location = new Point(0x161, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(380, 0x2aa);
            this.layoutControlItem3.TextSize = new Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x47f, 0x2be);
            base.Controls.Add(this.layoutControl1);
            base.Name = "productsec";
            this.Text = "\x00dcR\x00dcN SE\x00c7İM EKRANI";
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

        private void kisityukle()
        {
            this.gridControl1.DataSource = this.xx.dtta("select uk.kisitad,uk.kisitturu,uk.kullan,'' as degerler from urunler u,urunkisit uk where u.urunno=urunid and urunad='" + this.urunne + "' ", "");
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                this.tabloya = this.tabloya + this.gridView1.GetRowCellValue(i, "kisitad").ToString() + ",";
                try
                {
                    this.gridView1.SetRowCellValue(i, "degerler", this.griddeger(this.gridView1.GetRowCellValue(i, "kisitad").ToString()));
                    string[] textArray1 = new string[] { this.actfilterstr, this.gridView1.GetRowCellValue(i, "kisitad").ToString(), " ", this.gridView1.GetRowCellValue(i, "kisitturu").ToString(), this.gridView1.GetRowCellValue(i, "degerler").ToString(), " and " };
                    this.actfilterstr = string.Concat(textArray1);
                }
                catch (Exception)
                {
                }
            }
            this.tabloya = this.tabloya.Substring(0, this.tabloya.Length - 1);
            this.actfilterstr = this.actfilterstr.Substring(0, this.actfilterstr.Length - 4);
            this.urunyukle();
            this.treeList1.ActiveFilterString = this.actfilterstr;
        }

        private void productsec_Load(object sender, EventArgs e)
        {
            this.kisityukle();
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (!e.Node.HasChildren)
            {
                TreeListColumn columnID = this.treeList1.Columns["sno"];
                this.vGridControl1.DataSource = this.xx.dtta("select * from " + this.urunne + " where sno =" + this.treeList1.FocusedNode.GetValue(columnID).ToString(), "");
            }
        }

        private void urunyukle()
        {
            try
            {
                DataTable table = this.xx.dtta("select sno,model,guid,markaguid," + this.tabloya + " from " + this.urunne, "");
                DataTable table2 = this.xx.dtta("select marka,guid from " + this.urunne + "marka", "");
                table2.Merge(table);
                this.treeList1.DataSource = table2;
                this.treeList1.ExpandAll();
                this.treeList1.Columns["sno"].Visible = false;
                this.treeList1.Columns["model"].AppearanceCell.Font = new Font("Tahoma", 10f, FontStyle.Underline);
                this.treeList1.Columns["model"].AppearanceCell.ForeColor = Color.Blue;
                this.treeList1.Columns["model"].AppearanceCell.Options.UseFont = true;
                this.treeList1.Columns["model"].AppearanceCell.Options.UseForeColor = true;
                for (int i = 0; i < this.treeList1.Columns.Count; i++)
                {
                    this.treeList1.Columns[i].OptionsColumn.AllowEdit = false;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

