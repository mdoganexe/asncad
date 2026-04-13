namespace ascad
{
    using DevExpress.Utils;
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

    public class ascadcabin : Form
    {
        private DataTable arkapandata = new DataTable();
        private TextEdit arkapanelsay;
        private GridControl arkapangrd;
        public ascad.ascad AscadDLL;
        private IContainer components = null;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridView gridView1;
        private GridView gridView2;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem11;
        private LayoutControlItem layoutControlItem12;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem layoutControlItem9;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton3;
        private SimpleButton simpleButton4;
        private TextEdit tabderinlik;
        private TextEdit tabgenislik;
        private TextEdit textEdit3;
        private abc1 xx = new abc1();
        private SimpleButton yanminus;
        private DataTable yanpandata = new DataTable();
        private TextEdit yanpanelsay;
        private GridControl yanpangrd;
        private SimpleButton yanplus;

        public ascadcabin()
        {
            this.InitializeComponent();
        }

        private void arkapan0()
        {
            for (int i = 0; i < this.arkapandata.Rows.Count; i++)
            {
                this.arkapandata.Rows[i]["deger"] = 0;
            }
        }

        private void ascadcabin_Load(object sender, EventArgs e)
        {
            this.tabgenislik.Text = (Convert.ToInt32(this.AscadDLL.GetParamValue("L1KabinGen")) + 40).ToString();
            this.tabderinlik.Text = (Convert.ToInt32(this.AscadDLL.GetParamValue("L1KabinDer")) + 20).ToString();
            this.yanpandata = this.xx.dtta("select * from carpanel", "");
            this.arkapandata = this.xx.dtta("select * from carpanel", "");
            this.gridView1.ActiveFilterString = "deger>0";
            this.gridView2.ActiveFilterString = "deger>0";
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
            int num = Convert.ToInt32(this.tabderinlik.Text);
            int num2 = (Convert.ToInt32(this.yanpanelsay.Text) - e.RowHandle) - 1;
            if (num2 >= 1)
            {
                int num3 = 0;
                for (int i = 0; i <= e.RowHandle; i++)
                {
                    num3 += Convert.ToInt32(this.gridView1.GetRowCellValue(i, "deger").ToString());
                }
                int num4 = num - num3;
                int num5 = Convert.ToInt32((int) (num4 / num2));
                for (int j = e.RowHandle + 1; j < Convert.ToInt32(this.yanpanelsay.Text); j++)
                {
                    this.yanpandata.Rows[j]["deger"] = num5;
                }
                for (int k = Convert.ToInt32(this.yanpanelsay.Text); k < this.yanpandata.Rows.Count; k++)
                {
                    this.yanpandata.Rows[k]["deger"] = 0;
                }
            }
            if (num2 == 0)
            {
                MessageBox.Show("Bu panel uzunluğu \x00f6nceki panellere bağlıdır");
            }
            this.yanpangrd.DataSource = this.yanpandata;
        }

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            int num = Convert.ToInt32(this.tabgenislik.Text);
            int num2 = (Convert.ToInt32(this.arkapanelsay.Text) - e.RowHandle) - 1;
            if (num2 >= 1)
            {
                int num3 = 0;
                for (int i = 0; i <= e.RowHandle; i++)
                {
                    num3 += Convert.ToInt32(this.gridView2.GetRowCellValue(i, "deger").ToString());
                }
                int num4 = num - num3;
                int num5 = Convert.ToInt32((int) (num4 / num2));
                for (int j = e.RowHandle + 1; j < Convert.ToInt32(this.arkapanelsay.Text); j++)
                {
                    this.arkapandata.Rows[j]["deger"] = num5;
                }
                for (int k = Convert.ToInt32(this.arkapanelsay.Text); k < this.yanpandata.Rows.Count; k++)
                {
                    this.arkapandata.Rows[k]["deger"] = 0;
                }
            }
            if (num2 == 0)
            {
                MessageBox.Show("Bu panel uzunluğu \x00f6nceki panellere bağlıdır");
            }
            this.arkapangrd.DataSource = this.arkapandata;
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
            this.textEdit3.Properties.BeginInit();
            this.groupControl2.BeginInit();
            this.groupControl2.SuspendLayout();
            this.arkapangrd.BeginInit();
            this.gridView2.BeginInit();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.yanpangrd.BeginInit();
            this.gridView1.BeginInit();
            this.tabderinlik.Properties.BeginInit();
            this.arkapanelsay.Properties.BeginInit();
            this.tabgenislik.Properties.BeginInit();
            this.yanpanelsay.Properties.BeginInit();
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
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(290, 0x260);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            this.textEdit3.Location = new Point(0x8d, 0x243);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Size = new Size(0x8e, 0x16);
            this.textEdit3.StyleController = this.layoutControl1;
            this.textEdit3.TabIndex = 5;
            this.groupControl2.AppearanceCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.CaptionLocation = Locations.Left;
            this.groupControl2.Controls.Add(this.arkapangrd);
            this.groupControl2.Location = new Point(7, 0x15d);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(0x114, 0xe2);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "ARKA PANELLER";
            this.arkapangrd.Dock = DockStyle.Fill;
            this.arkapangrd.Location = new Point(0x18, 1);
            this.arkapangrd.MainView = this.gridView2;
            this.arkapangrd.Name = "arkapangrd";
            this.arkapangrd.Size = new Size(250, 0xdf);
            this.arkapangrd.TabIndex = 0x13;
            BaseView[] views = new BaseView[] { this.gridView2 };
            this.arkapangrd.ViewCollection.AddRange(views);
            this.gridView2.Appearance.ColumnFilterButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gridView2.Appearance.CustomizationFormHint.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gridView2.Appearance.DetailTip.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.DetailTip.Options.UseFont = true;
            this.gridView2.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FilterCloseButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView2.Appearance.FilterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView2.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FixedLine.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FooterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView2.Appearance.GroupButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.GroupButton.Options.UseFont = true;
            this.gridView2.Appearance.GroupFooter.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView2.Appearance.GroupPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.HorzLine.Options.UseFont = true;
            this.gridView2.Appearance.OddRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Preview.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.Preview.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.RowSeparator.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.TopNewRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.VertLine.Options.UseFont = true;
            this.gridView2.Appearance.ViewCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
            GridColumn[] columns = new GridColumn[] { this.gridColumn3, this.gridColumn4 };
            this.gridView2.Columns.AddRange(columns);
            this.gridView2.GridControl = this.arkapangrd;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CellValueChanged += new CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            this.gridColumn3.Caption = "PANELNO";
            this.gridColumn3.FieldName = "panelno";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 0x4d;
            this.gridColumn4.Caption = "\x00d6L\x00c7\x00dc";
            this.gridColumn4.FieldName = "deger";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 0x85;
            this.simpleButton1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new Point(7, 7);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x114, 0x17);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "VERİLERİ GETİR";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.groupControl1.AppearanceCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionLocation = Locations.Left;
            this.groupControl1.Controls.Add(this.yanpangrd);
            this.groupControl1.Location = new Point(7, 0x71);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x114, 0xcd);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "YAN PANELLER";
            this.yanpangrd.Dock = DockStyle.Fill;
            this.yanpangrd.Location = new Point(0x18, 1);
            this.yanpangrd.MainView = this.gridView1;
            this.yanpangrd.Name = "yanpangrd";
            this.yanpangrd.Size = new Size(250, 0xca);
            this.yanpangrd.TabIndex = 0x13;
            BaseView[] viewArray2 = new BaseView[] { this.gridView1 };
            this.yanpangrd.ViewCollection.AddRange(viewArray2);
            this.gridView1.Appearance.ColumnFilterButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gridView1.Appearance.CustomizationFormHint.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gridView1.Appearance.DetailTip.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.DetailTip.Options.UseFont = true;
            this.gridView1.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FilterCloseButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView1.Appearance.FilterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FixedLine.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupButton.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.TopNewRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            GridColumn[] columnArray2 = new GridColumn[] { this.gridColumn1, this.gridColumn2 };
            this.gridView1.Columns.AddRange(columnArray2);
            this.gridView1.GridControl = this.yanpangrd;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridColumn1.Caption = "PANELNO";
            this.gridColumn1.FieldName = "panelno";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 0x44;
            this.gridColumn2.Caption = "\x00d6L\x00c7\x00dc";
            this.gridColumn2.FieldName = "deger";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 0x8e;
            this.simpleButton4.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new Point(0xf4, 0x142);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new Size(0x27, 0x17);
            this.simpleButton4.StyleController = this.layoutControl1;
            this.simpleButton4.TabIndex = 0x11;
            this.simpleButton4.Text = "   -   ";
            this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
            this.simpleButton3.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new Point(0xc3, 0x142);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(0x2d, 0x17);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 0x12;
            this.simpleButton3.Text = "   +   ";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.tabderinlik.Location = new Point(0x8d, 60);
            this.tabderinlik.Name = "tabderinlik";
            this.tabderinlik.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tabderinlik.Properties.Appearance.Options.UseFont = true;
            this.tabderinlik.Size = new Size(0x8e, 0x16);
            this.tabderinlik.StyleController = this.layoutControl1;
            this.tabderinlik.TabIndex = 5;
            this.arkapanelsay.EditValue = "3";
            this.arkapanelsay.Enabled = false;
            this.arkapanelsay.EnterMoveNextControl = true;
            this.arkapanelsay.Location = new Point(0x8d, 0x142);
            this.arkapanelsay.Name = "arkapanelsay";
            this.arkapanelsay.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.arkapanelsay.Properties.Appearance.Options.UseFont = true;
            this.arkapanelsay.Properties.Appearance.Options.UseTextOptions = true;
            this.arkapanelsay.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.arkapanelsay.Size = new Size(50, 0x16);
            this.arkapanelsay.StyleController = this.layoutControl1;
            this.arkapanelsay.TabIndex = 14;
            this.tabgenislik.Location = new Point(0x8d, 0x22);
            this.tabgenislik.Name = "tabgenislik";
            this.tabgenislik.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tabgenislik.Properties.Appearance.Options.UseFont = true;
            this.tabgenislik.Size = new Size(0x8e, 0x16);
            this.tabgenislik.StyleController = this.layoutControl1;
            this.tabgenislik.TabIndex = 4;
            this.yanminus.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.yanminus.Appearance.Options.UseFont = true;
            this.yanminus.Location = new Point(0xf4, 0x56);
            this.yanminus.Name = "yanminus";
            this.yanminus.Size = new Size(0x27, 0x17);
            this.yanminus.StyleController = this.layoutControl1;
            this.yanminus.TabIndex = 0x10;
            this.yanminus.Text = "   -   ";
            this.yanminus.Click += new EventHandler(this.simpleButton2_Click);
            this.yanpanelsay.EditValue = "3";
            this.yanpanelsay.Enabled = false;
            this.yanpanelsay.EnterMoveNextControl = true;
            this.yanpanelsay.Location = new Point(0x8d, 0x56);
            this.yanpanelsay.Name = "yanpanelsay";
            this.yanpanelsay.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.yanpanelsay.Properties.Appearance.Options.UseFont = true;
            this.yanpanelsay.Properties.Appearance.Options.UseTextOptions = true;
            this.yanpanelsay.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.yanpanelsay.Size = new Size(50, 0x16);
            this.yanpanelsay.StyleController = this.layoutControl1;
            this.yanpanelsay.TabIndex = 13;
            this.yanplus.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.yanplus.Appearance.Options.UseFont = true;
            this.yanplus.Location = new Point(0xc3, 0x56);
            this.yanplus.Name = "yanplus";
            this.yanplus.Size = new Size(0x2d, 0x17);
            this.yanplus.StyleController = this.layoutControl1;
            this.yanplus.TabIndex = 15;
            this.yanplus.Text = "   +   ";
            this.yanplus.Click += new EventHandler(this.simpleButton5_Click);
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10, this.layoutControlItem11, this.layoutControlItem12 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(290, 0x260);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.tabgenislik;
            this.layoutControlItem1.Location = new Point(0, 0x1b);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(280, 0x1a);
            this.layoutControlItem1.Text = "TABAN GENİŞLİĞİ";
            this.layoutControlItem1.TextSize = new Size(0x83, 0x10);
            this.layoutControlItem2.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.tabderinlik;
            this.layoutControlItem2.Location = new Point(0, 0x35);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(280, 0x1a);
            this.layoutControlItem2.Text = "TABAN DERİNLİĞİ";
            this.layoutControlItem2.TextSize = new Size(0x83, 0x10);
            this.layoutControlItem3.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.yanpanelsay;
            this.layoutControlItem3.Location = new Point(0, 0x4f);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0xbc, 0x1b);
            this.layoutControlItem3.Text = "YAN PANEL SAYISI";
            this.layoutControlItem3.TextSize = new Size(0x83, 0x10);
            this.layoutControlItem4.Control = this.yanplus;
            this.layoutControlItem4.Location = new Point(0xbc, 0x4f);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0x31, 0x1b);
            this.layoutControlItem4.TextSize = new Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem5.Control = this.yanminus;
            this.layoutControlItem5.Location = new Point(0xed, 0x4f);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new Size(0x2b, 0x1b);
            this.layoutControlItem5.TextSize = new Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControlItem6.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.arkapanelsay;
            this.layoutControlItem6.Location = new Point(0, 0x13b);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new Size(0xbc, 0x1b);
            this.layoutControlItem6.Text = "ARKA PANEL SAYISI";
            this.layoutControlItem6.TextSize = new Size(0x83, 0x10);
            this.layoutControlItem7.Control = this.simpleButton3;
            this.layoutControlItem7.Location = new Point(0xbc, 0x13b);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x31, 0x1b);
            this.layoutControlItem7.TextSize = new Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            this.layoutControlItem8.Control = this.simpleButton4;
            this.layoutControlItem8.Location = new Point(0xed, 0x13b);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new Size(0x2b, 0x1b);
            this.layoutControlItem8.TextSize = new Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem9.Control = this.simpleButton1;
            this.layoutControlItem9.Location = new Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new Size(280, 0x1b);
            this.layoutControlItem9.TextSize = new Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem10.Control = this.groupControl1;
            this.layoutControlItem10.Location = new Point(0, 0x6a);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new Size(280, 0xd1);
            this.layoutControlItem10.TextSize = new Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.layoutControlItem11.Control = this.groupControl2;
            this.layoutControlItem11.Location = new Point(0, 0x156);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new Size(280, 230);
            this.layoutControlItem11.TextSize = new Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            this.layoutControlItem12.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem12.Control = this.textEdit3;
            this.layoutControlItem12.Location = new Point(0, 0x23c);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new Size(280, 0x1a);
            this.layoutControlItem12.Text = "TABAN B\x00d6LME SAY";
            this.layoutControlItem12.TextSize = new Size(0x83, 0x10);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(290, 0x260);
            base.Controls.Add(this.layoutControl1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ascadcabin";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "CAR DESİGN";
            base.Load += new EventHandler(this.ascadcabin_Load);
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.textEdit3.Properties.EndInit();
            this.groupControl2.EndInit();
            this.groupControl2.ResumeLayout(false);
            this.arkapangrd.EndInit();
            this.gridView2.EndInit();
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.yanpangrd.EndInit();
            this.gridView1.EndInit();
            this.tabderinlik.Properties.EndInit();
            this.arkapanelsay.Properties.EndInit();
            this.tabgenislik.Properties.EndInit();
            this.yanpanelsay.Properties.EndInit();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.tabgenislik.Text = (Convert.ToInt32(this.AscadDLL.GetParamValue("L1KabinGen")) + 40).ToString();
            this.tabderinlik.Text = (Convert.ToInt32(this.AscadDLL.GetParamValue("L1KabinDer")) + 20).ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.yanpanelsay.Text = (Convert.ToInt32(this.yanpanelsay.Text) - 1).ToString();
            this.yanpan0();
            int num2 = Convert.ToInt32((decimal) (Convert.ToDecimal(this.tabderinlik.Text) / Convert.ToInt32(this.yanpanelsay.Text)));
            for (int i = 0; i < Convert.ToInt32(this.yanpanelsay.Text); i++)
            {
                this.yanpandata.Rows[i]["deger"] = num2;
            }
            this.yanpangrd.DataSource = this.yanpandata;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.arkapanelsay.Text = (Convert.ToInt32(this.arkapanelsay.Text) + 1).ToString();
            int num2 = Convert.ToInt32((decimal) (Convert.ToDecimal(this.tabgenislik.Text) / Convert.ToInt32(this.arkapanelsay.Text)));
            this.arkapan0();
            for (int i = 0; i < Convert.ToInt32(this.arkapanelsay.Text); i++)
            {
                this.arkapandata.Rows[i]["deger"] = num2;
            }
            this.arkapangrd.DataSource = this.arkapandata;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.arkapanelsay.Text = (Convert.ToInt32(this.arkapanelsay.Text) - 1).ToString();
            int num2 = Convert.ToInt32((decimal) (Convert.ToDecimal(this.tabgenislik.Text) / Convert.ToInt32(this.arkapanelsay.Text)));
            this.arkapan0();
            for (int i = 0; i < Convert.ToInt32(this.arkapanelsay.Text); i++)
            {
                this.arkapandata.Rows[i]["deger"] = num2;
            }
            this.arkapangrd.DataSource = this.arkapandata;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.yanpanelsay.Text = (Convert.ToInt32(this.yanpanelsay.Text) + 1).ToString();
            int num2 = Convert.ToInt32((decimal) (Convert.ToDecimal(this.tabderinlik.Text) / Convert.ToInt32(this.yanpanelsay.Text)));
            this.yanpan0();
            for (int i = 0; i < Convert.ToInt32(this.yanpanelsay.Text); i++)
            {
                this.yanpandata.Rows[i]["deger"] = num2;
            }
            this.yanpangrd.DataSource = this.yanpandata;
        }

        private void yanpan0()
        {
            for (int i = 0; i < this.yanpandata.Rows.Count; i++)
            {
                this.yanpandata.Rows[i]["deger"] = 0;
            }
        }
    }
}

