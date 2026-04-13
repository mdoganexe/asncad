namespace ascad
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
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
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class productinfo : Form
    {
        private IContainer components = null;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridControl gridControl1;
        private GridControl gridControl2;
        private GridView gridView1;
        private GridView gridView2;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private PictureBox pictureBox1;
        private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private string secilengui = "";
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private TextEdit textEdit1;
        public string urunne = "";
        private abc1 xx = new abc1();

        public productinfo()
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

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            this.xx.oleupdate("update " + this.urunne + "marka set iskonto = " + this.gridView1.GetRowCellValue(e.RowHandle, "iskonto").ToString() + " where sno=" + this.gridView1.GetRowCellValue(e.RowHandle, "sno").ToString(), "");
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = (sender as GridView).CalcHitInfo(this.gridControl1.PointToClient(Control.MousePosition));
            if ((e.Button == MouseButtons.Left) && ((info.InRowCell && (info.RowHandle >= 0)) && (info.Column.FieldName == "marka")))
            {
                this.prdgetir(this.gridView1.GetRowCellValue(info.RowHandle, "guid").ToString());
                this.secilengui = this.gridView1.GetRowCellValue(info.RowHandle, "guid").ToString();
            }
        }

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            this.xx.oleupdate(this.xx.hucredeupdate("update " + this.urunne + " set  ", e.Column.ColumnType.ToString(), e.Column.FieldName, e.Value.ToString(), " where sno=" + this.gridView2.GetRowCellValue(e.RowHandle, "sno").ToString()), "");
        }

        private void InitializeComponent()
        {
            this.simpleButton1 = new SimpleButton();
            this.layoutControl1 = new LayoutControl();
            this.pictureBox1 = new PictureBox();
            this.simpleButton3 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.gridControl2 = new GridControl();
            this.gridView2 = new GridView();
            this.textEdit1 = new TextEdit();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn1 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.repositoryItemHyperLinkEdit1 = new RepositoryItemHyperLinkEdit();
            this.gridColumn3 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.layoutControlItem3 = new LayoutControlItem();
            this.layoutControlItem4 = new LayoutControlItem();
            this.layoutControlItem5 = new LayoutControlItem();
            this.layoutControlItem6 = new LayoutControlItem();
            this.layoutControlItem7 = new LayoutControlItem();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.gridControl2.BeginInit();
            this.gridView2.BeginInit();
            this.textEdit1.Properties.BeginInit();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            this.repositoryItemHyperLinkEdit1.BeginInit();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem2.BeginInit();
            this.layoutControlItem3.BeginInit();
            this.layoutControlItem4.BeginInit();
            this.layoutControlItem5.BeginInit();
            this.layoutControlItem6.BeginInit();
            this.layoutControlItem7.BeginInit();
            base.SuspendLayout();
            this.simpleButton1.Appearance.Font = new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new Point(0x382, 7);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x105, 0x18);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "YENİ MARKA EKLE";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.layoutControl1.Controls.Add(this.pictureBox1);
            this.layoutControl1.Controls.Add(this.simpleButton3);
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Dock = DockStyle.Fill;
            this.layoutControl1.Location = new Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(260, 0x98, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x48e, 0x2d2);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            this.pictureBox1.Location = new Point(7, 0x1c0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x12d, 0x10b);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.simpleButton3.Appearance.Font = new Font("Tahoma", 10.2f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new Point(0x2e1, 0x23);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(0x1a6, 0x18);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "\x00dcRETİCİYE YENİ \x00dcR\x00dcN EKLEME";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.simpleButton2.Appearance.Font = new Font("Tahoma", 10.2f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new Point(0x138, 0x23);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x1a5, 0x18);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "\x00dcRETİCİYE  ŞABLONDAN \x00dcR\x00dcNLER EKLEME";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl2.Location = new Point(0x138, 0x3f);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new Size(0x34f, 0x28c);
            this.gridControl2.TabIndex = 4;
            BaseView[] views = new BaseView[] { this.gridView2 };
            this.gridControl2.ViewCollection.AddRange(views);
            this.gridView2.Appearance.ColumnFilterButton.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gridView2.Appearance.CustomizationFormHint.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gridView2.Appearance.DetailTip.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.DetailTip.Options.UseFont = true;
            this.gridView2.Appearance.Empty.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FilterCloseButton.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView2.Appearance.FilterPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView2.Appearance.FixedLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FixedLine.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FooterPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView2.Appearance.GroupButton.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.GroupButton.Options.UseFont = true;
            this.gridView2.Appearance.GroupFooter.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView2.Appearance.GroupPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HorzLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.HorzLine.Options.UseFont = true;
            this.gridView2.Appearance.OddRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Preview.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.Preview.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.RowSeparator.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.TopNewRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.VertLine.Options.UseFont = true;
            this.gridView2.Appearance.ViewCaption.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CellValueChanged += new CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            this.textEdit1.Location = new Point(0x70, 7);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(2);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new Size(0x30e, 0x18);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 2;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new Point(7, 0x23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            RepositoryItem[] items = new RepositoryItem[] { this.repositoryItemHyperLinkEdit1 };
            this.gridControl1.RepositoryItems.AddRange(items);
            this.gridControl1.Size = new Size(0x12d, 0x199);
            this.gridControl1.TabIndex = 3;
            BaseView[] viewArray2 = new BaseView[] { this.gridView1 };
            this.gridControl1.ViewCollection.AddRange(viewArray2);
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
            this.gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(0xc0, 0xff, 0xc0);
            this.gridView1.Appearance.FocusedRow.BorderColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
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
            this.gridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(0x80, 0xff, 0x80);
            this.gridView1.Appearance.SelectedRow.BorderColor = Color.Black;
            this.gridView1.Appearance.SelectedRow.Font = new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
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
            this.gridView1.CellValueChanged += new CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.MouseDown += new MouseEventHandler(this.gridView1_MouseDown);
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "guid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn2.Caption = "Marka";
            this.gridColumn2.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn2.FieldName = "marka";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 0xcb;
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.gridColumn3.Caption = "İskonto";
            this.gridColumn3.FieldName = "iskonto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 0x84;
            this.gridColumn4.Caption = "Sno";
            this.gridColumn4.FieldName = "sno";
            this.gridColumn4.Name = "gridColumn4";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray2 = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7 };
            this.layoutControlGroup1.Items.AddRange(itemArray2);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x48e, 0x2d2);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x37b, 0x1c);
            this.layoutControlItem1.Text = "\x00dcRETİCİ İSMİ";
            this.layoutControlItem1.TextSize = new Size(0x65, 0x11);
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new Point(0x37b, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x109, 0x1c);
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.Location = new Point(0, 0x1c);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x131, 0x19d);
            this.layoutControlItem3.TextSize = new Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem4.Control = this.gridControl2;
            this.layoutControlItem4.Location = new Point(0x131, 0x38);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0x353, 0x290);
            this.layoutControlItem4.TextSize = new Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem5.Control = this.simpleButton2;
            this.layoutControlItem5.Location = new Point(0x131, 0x1c);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new Size(0x1a9, 0x1c);
            this.layoutControlItem5.TextSize = new Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControlItem6.Control = this.simpleButton3;
            this.layoutControlItem6.Location = new Point(730, 0x1c);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new Size(0x1aa, 0x1c);
            this.layoutControlItem6.TextSize = new Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.layoutControlItem7.Control = this.pictureBox1;
            this.layoutControlItem7.Location = new Point(0, 0x1b9);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x131, 0x10f);
            this.layoutControlItem7.TextSize = new Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x48e, 0x2d2);
            base.Controls.Add(this.layoutControl1);
            base.Margin = new System.Windows.Forms.Padding(2);
            base.Name = "productinfo";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "\x00dcRETİCİ BİLGİLERİ";
            base.Load += new EventHandler(this.raybilgileri_Load);
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.gridControl2.EndInit();
            this.gridView2.EndInit();
            this.textEdit1.Properties.EndInit();
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            this.repositoryItemHyperLinkEdit1.EndInit();
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem2.EndInit();
            this.layoutControlItem3.EndInit();
            this.layoutControlItem4.EndInit();
            this.layoutControlItem5.EndInit();
            this.layoutControlItem6.EndInit();
            this.layoutControlItem7.EndInit();
            base.ResumeLayout(false);
        }

        private void prdgetir(string guii)
        {
            this.gridControl2.DataSource = this.xx.dtta("SELECT rm.marka ,r.* from " + this.urunne + " r , " + this.urunne + "marka rm where r.markaguid = rm.guid and rm.guid='" + guii + "'", "");
            if (this.gridView2.RowCount > 0)
            {
                this.gridView2.Columns["sno"].Visible = false;
                this.gridView2.Columns["marka"].OptionsColumn.AllowEdit = false;
                this.gridView2.Columns["guid"].Visible = false;
                this.gridView2.Columns["markaguid"].Visible = false;
            }
        }

        private void raybilgileri_Load(object sender, EventArgs e)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.uretgetir();
            if (File.Exists(directoryName + @"\img\" + this.urunne + ".png"))
            {
                this.pictureBox1.ImageLocation = directoryName + @"\img\" + this.urunne + ".png";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.xx.oleupdate(string.Concat(new object[] { "insert into ", this.urunne, "marka(marka,iskonto,guid) values('", this.textEdit1.Text, "',20,'", Guid.NewGuid(), "') " }), "");
            this.uretgetir();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.secilengui))
            {
                MessageBox.Show("Bir \x00dcretici Se\x00e7emeniz gerekli!!!");
            }
            else if (MessageBox.Show("Ana Tablodan ekleme iste misiniz?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new masterproduct { 
                    urunne = this.urunne,
                    guidne = this.secilengui
                }.ShowDialog();
                this.prdgetir(this.secilengui);
            }
            else
            {
                this.xx.oleupdate("insert into " + this.urunne + "(guid,markaguid) select UUID(),'" + this.secilengui + "'", "");
                this.prdgetir(this.secilengui);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.xx.oleupdate("insert into " + this.urunne + "(guid,markaguid) select UUID(),'" + this.secilengui + "'", "");
            this.prdgetir(this.secilengui);
        }

        private void uretgetir()
        {
            this.gridControl1.DataSource = this.xx.dtta("select * from " + this.urunne + "marka", "");
        }
    }
}

