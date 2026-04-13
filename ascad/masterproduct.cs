namespace ascad
{
    using DevExpress.Utils;
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

    public class masterproduct : Form
    {
        private IContainer components = null;
        private GridControl gridControl2;
        private GridView gridView2;
        public string guidne = "";
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        public string urunne = "";
        private abc1 xx = new abc1();

        public masterproduct()
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

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            this.xx.oleupdate(this.xx.hucredeupdate("update " + this.urunne + "master set ", e.Column.ColumnType.ToString(), e.Column.FieldName, e.Value.ToString(), " where sno=" + this.gridView2.GetRowCellValue(e.RowHandle, "sno").ToString()), "");
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
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl2.Location = new Point(7, 7);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new Size(0x353, 0x217);
            this.gridControl2.TabIndex = 5;
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
            this.simpleButton1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new Point(7, 0x23d);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x353, 0x17);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "TABLO SE\x00c7İMDE OLANLARI \x00dcR\x00dcN İLE BİRLEŞTİR";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Dock = DockStyle.Fill;
            this.layoutControl1.Location = new Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x361, 0x25b);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            this.simpleButton2.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new Point(7, 0x222);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x353, 0x17);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "ANA TABLOYA YENİ SATIR EKLE";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x361, 0x25b);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.Control = this.gridControl2;
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x357, 0x21b);
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new Point(0, 0x236);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x357, 0x1b);
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem3.Control = this.simpleButton2;
            this.layoutControlItem3.Location = new Point(0, 0x21b);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x357, 0x1b);
            this.layoutControlItem3.TextSize = new Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x361, 0x25b);
            base.Controls.Add(this.layoutControl1);
            base.Margin = new System.Windows.Forms.Padding(2);
            base.Name = "masterproduct";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "\x00dcR\x00dcN ANA TABLOLARI";
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

        private void masterproduct_Load(object sender, EventArgs e)
        {
            this.gridControl2.DataSource = this.xx.dtta("select * from " + this.urunne + "master", "");
            if (this.gridView2.RowCount > 0)
            {
                try
                {
                    this.gridView2.Columns["sno"].Visible = false;
                    this.gridView2.Columns["guid"].Visible = false;
                    this.gridView2.Columns["guid"].OptionsColumn.AllowEdit = false;
                }
                catch (Exception)
                {
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < this.gridView2.Columns.Count; i++)
            {
                if (this.gridView2.Columns[i].Visible && (this.gridView2.Columns[i].FieldName != "sec"))
                {
                    str = str + this.gridView2.Columns[i].FieldName + ",";
                }
            }
            str = str.Substring(0, str.Length - 1);
            for (int j = 0; j < this.gridView2.RowCount; j++)
            {
                if (Convert.ToBoolean(this.gridView2.GetRowCellValue(j, "sec").ToString()))
                {
                    this.xx.oleupdate("insert into " + this.urunne + "(" + str + ",markaguid) select  " + str + ",'" + this.guidne + "' from " + this.urunne + "master where sno =" + this.gridView2.GetRowCellValue(j, "sno").ToString(), "");
                }
            }
            base.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.xx.oleupdate("insert into " + this.urunne + "master (guid) values('" + Guid.NewGuid().ToString() + "')", "");
            this.gridControl2.DataSource = this.xx.dtta("select * from " + this.urunne + "master", "");
            if (this.gridView2.RowCount > 0)
            {
                try
                {
                    this.gridView2.Columns["sno"].Visible = false;
                    this.gridView2.Columns["guid"].OptionsColumn.AllowEdit = false;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

