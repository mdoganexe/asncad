namespace ascad
{
    using DevExpress.Data;
    using DevExpress.Utils;
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

    public class asnseccrm : Form
    {
        public string asansorno = "";
        private IContainer components = null;
        private string dosyalamaali = @"C:\SZG\FILES\montaj";
        public string dwgid = "";
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
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private abc1 xx = new abc1();

        public asnseccrm()
        {
            this.InitializeComponent();
        }

        private void asnneler()
        {
            string str = "";
            if (this.radioButton1.Checked)
            {
                str = " where onolcu=100 and cizim=0";
            }
            else
            {
                str = "";
            }
            this.gridControl1.DataSource = this.xx.crmdtta("select * from asnasnler " + str, "");
        }

        private void asnseccrm_Load(object sender, EventArgs e)
        {
            this.asnneler();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = (sender as GridView).CalcHitInfo(this.gridControl1.PointToClient(Control.MousePosition));
            if ((e.Button == MouseButtons.Left) && ((info.InRowCell && (info.RowHandle >= 0)) && (info.Column.FieldName == "gridColumn3")))
            {
                this.asansorno = this.gridView1.GetRowCellValue(info.RowHandle, "sno").ToString();
                this.dwgid = this.gridView1.GetRowCellValue(info.RowHandle, "dwgguid").ToString();
                if (this.dwgid == "")
                {
                    Guid guid = new Guid();
                    this.dwgid = guid.ToString();
                    this.xx.crmoleupdate("update asnasnler set dwgguid='" + this.dwgid + "' where sno=" + this.asansorno, "");
                }
                try
                {
                    Process.Start(this.dosyalamaali + @"\" + this.asansorno + @"\onolcu\");
                }
                catch (Exception)
                {
                }
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(asnseccrm));
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
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x180, 0x228);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.gridControl1.Location = new Point(7, 0x41);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            RepositoryItem[] items = new RepositoryItem[] { this.repositoryItemHyperLinkEdit1, this.repositoryItemHyperLinkEdit2 };
            this.gridControl1.RepositoryItems.AddRange(items);
            this.gridControl1.Size = new Size(370, 480);
            this.gridControl1.TabIndex = 6;
            BaseView[] views = new BaseView[] { this.gridView1 };
            this.gridControl1.ViewCollection.AddRange(views);
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
            GridColumn[] columns = new GridColumn[] { this.gridColumn1, this.gridColumn3, this.gridColumn2, this.gridColumn4 };
            this.gridView1.Columns.AddRange(columns);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.MouseDown += new MouseEventHandler(this.gridView1_MouseDown);
            this.gridColumn1.Caption = "ASANS\x00d6R ADI";
            this.gridColumn1.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn1.FieldName = "asnaciklama";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 0x129;
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.gridColumn2.Caption = "asanno";
            this.gridColumn2.FieldName = "sno";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn3.Caption = "A\x00e7";
            this.gridColumn3.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.gridColumn3.FieldName = "gridColumn3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundType = UnboundColumnType.String;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 0x37;
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Image = (Image) manager.GetObject("repositoryItemHyperLinkEdit2.Image");
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.gridColumn4.Caption = "dwgid";
            this.gridColumn4.FieldName = "dwgid";
            this.gridColumn4.Name = "gridColumn4";
            this.radioButton2.Location = new Point(7, 0x24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(370, 0x19);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "T\x00dcM İŞLER";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new Point(7, 7);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(370, 0x19);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SADECE BEKLEYEN İŞLER";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray2 = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 };
            this.layoutControlGroup1.Items.AddRange(itemArray2);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x180, 0x228);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.Control = this.radioButton1;
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x176, 0x1d);
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem2.Control = this.radioButton2;
            this.layoutControlItem2.Location = new Point(0, 0x1d);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x176, 0x1d);
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.Location = new Point(0, 0x3a);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x176, 0x1e4);
            this.layoutControlItem3.TextSize = new Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x180, 0x228);
            base.Controls.Add(this.layoutControl1);
            base.Name = "asnseccrm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ASANS\x00d6R SE\x00c7İM EKRANI";
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.asnneler();
        }
    }
}

