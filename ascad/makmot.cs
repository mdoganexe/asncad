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
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class makmot : Form
    {
        private CheckEdit checkEdit1;
        private CheckEdit checkEdit2;
        private CheckEdit checkEdit3;
        private IContainer components = null;
        private int dis = 0;
        private string edit = "";
        public asnhesapfrm frm1;
        private GridColumn gridColumn1;
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
        private GridColumn gridColumn12;
        private GridColumn gridColumn13;
        private GridColumn gridColumn14;
        private GridColumn gridColumn15;
        private GridColumn gridColumn16;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridColumn gridColumn8;
        private GridColumn gridColumn9;
        private GridControl gridControl1;
        private GridView gridView1;
        private GroupControl groupControl1;
        private LayoutControl layoutControl1;
        private LayoutControl layoutControl2;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlGroup layoutControlGroup2;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem11;
        private LayoutControlItem layoutControlItem12;
        private LayoutControlItem layoutControlItem13;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem layoutControlItem9;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private DataTable ss;
        public TextEdit textEdit1;
        public TextEdit textEdit2;
        public TextEdit textEdit3;
        private ureticigos uret = new ureticigos();
        private string ureticiiii = "";
        private abc1 xx = new abc1();

        public makmot()
        {
            this.InitializeComponent();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkEdit1.Checked)
                {
                    this.gridView1.SetRowCellValue(-2147483646, "kapasite", this.textEdit1.Text);
                }
                else
                {
                    this.gridView1.SetRowCellValue(-2147483646, "kapasite", "");
                }
            }
            catch (Exception)
            {
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkEdit2.Checked)
                {
                    this.gridView1.SetRowCellValue(-2147483646, "hiz", this.textEdit2.Text);
                }
                else
                {
                    this.gridView1.SetRowCellValue(-2147483646, "hiz", "");
                }
            }
            catch (Exception)
            {
            }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkEdit3.Checked)
                {
                    this.gridView1.SetRowCellValue(-2147483646, "aski", this.textEdit3.Text);
                }
                else
                {
                    this.gridView1.SetRowCellValue(-2147483646, "aski", "");
                }
            }
            catch (Exception)
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridHitInfo info = (sender as GridView).CalcHitInfo(this.gridControl1.PointToClient(Control.MousePosition));
                if ((((e.Button == MouseButtons.Left) && info.InRowCell) && (info.RowHandle >= 0)) && (info.Column.FieldName == "marka"))
                {
                    this.uret.makmt = this;
                    this.ureticiiii = this.gridView1.GetRowCellValue(info.RowHandle, "marka").ToString();
                    this.uret.uretici = this.ureticiiii;
                    this.ss = this.xx.dtta("select * from uretici where marka='" + this.ureticiiii + "'", "");
                    try
                    {
                        if (this.ss.Rows[0]["marka"].ToString() != "")
                        {
                            this.uret.vGridControl1.DataSource = this.ss;
                            this.uret.ShowDialog();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("SE\x00c7TİĞİNİZ FİRMAYA AİT BİLGİ BULUNAMADI");
                    }
                }
                if (((((e.Button == MouseButtons.Left) && info.InRowCell) && (info.RowHandle >= 0)) && (info.Column.FieldName == "siliniz")) && (MessageBox.Show("Bilgileri sileyimmi?", "Bilgiler Silinecek", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    this.xx.oleupdate("update motormakine1 set silindi=true where id=" + this.gridView1.GetRowCellValue(info.RowHandle, "id").ToString(), "");
                    this.yeni();
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitializeComponent()
        {
            this.groupControl1 = new GroupControl();
            this.layoutControl1 = new LayoutControl();
            this.radioButton2 = new RadioButton();
            this.textEdit3 = new TextEdit();
            this.radioButton1 = new RadioButton();
            this.checkEdit3 = new CheckEdit();
            this.textEdit2 = new TextEdit();
            this.checkEdit2 = new CheckEdit();
            this.textEdit1 = new TextEdit();
            this.checkEdit1 = new CheckEdit();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.layoutControlItem8 = new LayoutControlItem();
            this.layoutControlItem3 = new LayoutControlItem();
            this.layoutControlItem4 = new LayoutControlItem();
            this.layoutControlItem7 = new LayoutControlItem();
            this.layoutControlItem5 = new LayoutControlItem();
            this.layoutControlItem6 = new LayoutControlItem();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn1 = new GridColumn();
            this.repositoryItemHyperLinkEdit1 = new RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.gridColumn6 = new GridColumn();
            this.gridColumn7 = new GridColumn();
            this.gridColumn8 = new GridColumn();
            this.gridColumn9 = new GridColumn();
            this.gridColumn10 = new GridColumn();
            this.gridColumn11 = new GridColumn();
            this.gridColumn12 = new GridColumn();
            this.gridColumn13 = new GridColumn();
            this.gridColumn14 = new GridColumn();
            this.gridColumn15 = new GridColumn();
            this.repositoryItemHyperLinkEdit2 = new RepositoryItemHyperLinkEdit();
            this.gridColumn16 = new GridColumn();
            this.simpleButton1 = new SimpleButton();
            this.layoutControl2 = new LayoutControl();
            this.simpleButton2 = new SimpleButton();
            this.simpleButton3 = new SimpleButton();
            this.layoutControlGroup2 = new LayoutControlGroup();
            this.layoutControlItem9 = new LayoutControlItem();
            this.layoutControlItem11 = new LayoutControlItem();
            this.layoutControlItem10 = new LayoutControlItem();
            this.layoutControlItem12 = new LayoutControlItem();
            this.layoutControlItem13 = new LayoutControlItem();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            this.textEdit3.Properties.BeginInit();
            this.checkEdit3.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.checkEdit2.Properties.BeginInit();
            this.textEdit1.Properties.BeginInit();
            this.checkEdit1.Properties.BeginInit();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem2.BeginInit();
            this.layoutControlItem8.BeginInit();
            this.layoutControlItem3.BeginInit();
            this.layoutControlItem4.BeginInit();
            this.layoutControlItem7.BeginInit();
            this.layoutControlItem5.BeginInit();
            this.layoutControlItem6.BeginInit();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            this.repositoryItemHyperLinkEdit1.BeginInit();
            this.repositoryItemHyperLinkEdit2.BeginInit();
            this.layoutControl2.BeginInit();
            this.layoutControl2.SuspendLayout();
            this.layoutControlGroup2.BeginInit();
            this.layoutControlItem9.BeginInit();
            this.layoutControlItem11.BeginInit();
            this.layoutControlItem10.BeginInit();
            this.layoutControlItem12.BeginInit();
            this.layoutControlItem13.BeginInit();
            base.SuspendLayout();
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Location = new Point(7, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x204, 0x56);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "ARAMA KRİTERLERİ";
            this.layoutControl1.Controls.Add(this.radioButton2);
            this.layoutControl1.Controls.Add(this.textEdit3);
            this.layoutControl1.Controls.Add(this.radioButton1);
            this.layoutControl1.Controls.Add(this.checkEdit3);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.checkEdit2);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Dock = DockStyle.Fill;
            this.layoutControl1.Location = new Point(2, 20);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x200, 0x40);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.radioButton2.Location = new Point(7, 0x21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(0x4b, 0x16);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "DİŞLİSİZ";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.textEdit3.EnterMoveNextControl = true;
            this.textEdit3.Location = new Point(0x139, 0x21);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit3.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit3.RightToLeft = RightToLeft.No;
            this.textEdit3.Size = new Size(0x41, 0x16);
            this.textEdit3.StyleController = this.layoutControl1;
            this.textEdit3.TabIndex = 5;
            this.textEdit3.TextChanged += new EventHandler(this.textEdit3_TextChanged);
            this.radioButton1.Location = new Point(0x56, 0x21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x41, 0x16);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.Text = "DİŞLİLİ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
            this.checkEdit3.EditValue = true;
            this.checkEdit3.Location = new Point(0xd7, 0x21);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.checkEdit3.Properties.Appearance.Options.UseFont = true;
            this.checkEdit3.Properties.Caption = "ASKI TİPİ 1 /";
            this.checkEdit3.Size = new Size(0x5e, 0x13);
            this.checkEdit3.StyleController = this.layoutControl1;
            this.checkEdit3.TabIndex = 4;
            this.checkEdit3.CheckedChanged += new EventHandler(this.checkEdit3_CheckedChanged);
            this.textEdit2.EnterMoveNextControl = true;
            this.textEdit2.Location = new Point(0x139, 7);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit2.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit2.RightToLeft = RightToLeft.No;
            this.textEdit2.Size = new Size(0x41, 0x16);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 3;
            this.textEdit2.TextChanged += new EventHandler(this.textEdit2_TextChanged);
            this.checkEdit2.EditValue = true;
            this.checkEdit2.Location = new Point(0xd7, 7);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.checkEdit2.Properties.Appearance.Options.UseFont = true;
            this.checkEdit2.Properties.Caption = "HIZ :";
            this.checkEdit2.Size = new Size(0x5e, 0x13);
            this.checkEdit2.StyleController = this.layoutControl1;
            this.checkEdit2.TabIndex = 2;
            this.checkEdit2.CheckedChanged += new EventHandler(this.checkEdit2_CheckedChanged);
            this.textEdit1.EnterMoveNextControl = true;
            this.textEdit1.Location = new Point(0x56, 7);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit1.RightToLeft = RightToLeft.No;
            this.textEdit1.Size = new Size(0x41, 0x16);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 1;
            this.textEdit1.TextChanged += new EventHandler(this.textEdit1_TextChanged);
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new Point(7, 7);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "KAPASİTE";
            this.checkEdit1.Size = new Size(0x4b, 0x13);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 0;
            this.checkEdit1.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem8, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem7, this.layoutControlItem5, this.layoutControlItem6 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x200, 0x40);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.Control = this.checkEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.MaxSize = new Size(0x4f, 0x1a);
            this.layoutControlItem1.MinSize = new Size(0x4f, 0x1a);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x4f, 0x1a);
            this.layoutControlItem1.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem2.Control = this.textEdit1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new Point(0x4f, 0);
            this.layoutControlItem2.MaxSize = new Size(0x45, 0x1a);
            this.layoutControlItem2.MinSize = new Size(0x45, 0x1a);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x45, 0x1a);
            this.layoutControlItem2.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem8.Control = this.radioButton2;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new Point(0, 0x1a);
            this.layoutControlItem8.MaxSize = new Size(0x4f, 0x1a);
            this.layoutControlItem8.MinSize = new Size(0x4f, 0x18);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new Size(0x4f, 0x1c);
            this.layoutControlItem8.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem3.Control = this.checkEdit2;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new Point(0x94, 0);
            this.layoutControlItem3.MaxSize = new Size(0x9e, 0x1a);
            this.layoutControlItem3.MinSize = new Size(0x9e, 0x1a);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x9e, 0x1a);
            this.layoutControlItem3.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(60, 0, 0, 0);
            this.layoutControlItem3.TextSize = new Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem4.Control = this.textEdit2;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new Point(0x132, 0);
            this.layoutControlItem4.MaxSize = new Size(0x45, 0x1a);
            this.layoutControlItem4.MinSize = new Size(0x45, 0x1a);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0xc4, 0x1a);
            this.layoutControlItem4.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem7.Control = this.radioButton1;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new Point(0x4f, 0x1a);
            this.layoutControlItem7.MaxSize = new Size(0x45, 0x1a);
            this.layoutControlItem7.MinSize = new Size(0x45, 0x1a);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x45, 0x1c);
            this.layoutControlItem7.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            this.layoutControlItem5.Control = this.checkEdit3;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new Point(0x94, 0x1a);
            this.layoutControlItem5.MaxSize = new Size(0x9e, 0x1a);
            this.layoutControlItem5.MinSize = new Size(0x9e, 0x1a);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new Size(0x9e, 0x1c);
            this.layoutControlItem5.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(60, 0, 0, 0);
            this.layoutControlItem5.TextSize = new Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControlItem6.Control = this.textEdit3;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new Point(0x132, 0x1a);
            this.layoutControlItem6.MaxSize = new Size(0x45, 0x1a);
            this.layoutControlItem6.MinSize = new Size(0x45, 0x1a);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new Size(0xc4, 0x1c);
            this.layoutControlItem6.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.gridControl1.Location = new Point(7, 0x61);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            RepositoryItem[] itemArray2 = new RepositoryItem[] { this.repositoryItemHyperLinkEdit1, this.repositoryItemHyperLinkEdit2 };
            this.gridControl1.RepositoryItems.AddRange(itemArray2);
            this.gridControl1.Size = new Size(0x3e7, 450);
            this.gridControl1.TabIndex = 4;
            BaseView[] views = new BaseView[] { this.gridView1 };
            this.gridControl1.ViewCollection.AddRange(views);
            this.gridControl1.MouseDown += new MouseEventHandler(this.gridControl1_MouseDown);
            this.gridView1.Appearance.ColumnFilterButton.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gridView1.Appearance.CustomizationFormHint.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gridView1.Appearance.DetailTip.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.DetailTip.Options.UseFont = true;
            this.gridView1.Appearance.Empty.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FilterCloseButton.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView1.Appearance.FilterPanel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FixedLine.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FixedLine.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(0x80, 0x80, 0xff);
            this.gridView1.Appearance.FocusedRow.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupButton.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupButton.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.TopNewRow.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            GridColumn[] columns = new GridColumn[] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7, this.gridColumn8, this.gridColumn9, this.gridColumn10, this.gridColumn11, this.gridColumn12, this.gridColumn13, this.gridColumn14, this.gridColumn15, this.gridColumn16 };
            this.gridView1.Columns.AddRange(columns);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.MouseDown += new MouseEventHandler(this.gridView1_MouseDown);
            this.gridColumn1.Caption = "MARKA";
            this.gridColumn1.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn1.FieldName = "marka";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 0x72;
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.gridColumn2.Caption = "MODEL";
            this.gridColumn2.FieldName = "model";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 0x75;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn3.Caption = "KAPASİTE";
            this.gridColumn3.FieldName = "kapasite";
            this.gridColumn3.MaxWidth = 90;
            this.gridColumn3.MinWidth = 80;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 80;
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn4.Caption = "HIZ";
            this.gridColumn4.FieldName = "hiz";
            this.gridColumn4.MaxWidth = 0x23;
            this.gridColumn4.MinWidth = 0x23;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 0x23;
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn5.Caption = "MOTOR KW";
            this.gridColumn5.FieldName = "motorkw";
            this.gridColumn5.MaxWidth = 70;
            this.gridColumn5.MinWidth = 70;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 70;
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn6.Caption = "KASNAK \x00c7API";
            this.gridColumn6.FieldName = "kasnakcap";
            this.gridColumn6.MaxWidth = 0x4b;
            this.gridColumn6.MinWidth = 0x4b;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn7.Caption = "KASNAK KANAL";
            this.gridColumn7.FieldName = "kasnakkanal";
            this.gridColumn7.MaxWidth = 0x55;
            this.gridColumn7.MinWidth = 0x55;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 0x55;
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn8.Caption = "HALAT \x00c7AP";
            this.gridColumn8.FieldName = "halatcap";
            this.gridColumn8.MaxWidth = 0x4b;
            this.gridColumn8.MinWidth = 0x4b;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn9.Caption = "ASKI";
            this.gridColumn9.FieldName = "aski";
            this.gridColumn9.MaxWidth = 50;
            this.gridColumn9.MinWidth = 50;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 50;
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn10.Caption = "MAKS. Y\x00dcK";
            this.gridColumn10.FieldName = "maksyuk";
            this.gridColumn10.MaxWidth = 60;
            this.gridColumn10.MinWidth = 60;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 60;
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn11.Caption = "DİŞ";
            this.gridColumn11.FieldName = "diskontrol";
            this.gridColumn11.MaxWidth = 40;
            this.gridColumn11.MinWidth = 40;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            this.gridColumn11.Width = 40;
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridColumn12.Caption = "VERİM";
            this.gridColumn12.FieldName = "verim";
            this.gridColumn12.MaxWidth = 50;
            this.gridColumn12.MinWidth = 50;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 50;
            this.gridColumn13.Caption = "gridColumn13";
            this.gridColumn13.FieldName = "id";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Caption = "gridColumn14";
            this.gridColumn14.FieldName = "edit";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn15.AppearanceCell.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridColumn15.AppearanceCell.Options.UseFont = true;
            this.gridColumn15.Caption = "SİL";
            this.gridColumn15.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.gridColumn15.FieldName = "siliniz";
            this.gridColumn15.MaxWidth = 0x20;
            this.gridColumn15.MinWidth = 0x20;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 12;
            this.gridColumn15.Width = 0x20;
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.gridColumn16.Caption = "gridColumn16";
            this.gridColumn16.FieldName = "degisti";
            this.gridColumn16.Name = "gridColumn16";
            this.simpleButton1.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseTextOptions = true;
            this.simpleButton1.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.simpleButton1.Location = new Point(0x20f, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x9d, 0x56);
            this.simpleButton1.StyleController = this.layoutControl2;
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "SE\x00c7İLEN BİLGİLERİ AKTAR";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.simpleButton2);
            this.layoutControl2.Controls.Add(this.simpleButton1);
            this.layoutControl2.Controls.Add(this.simpleButton3);
            this.layoutControl2.Controls.Add(this.groupControl1);
            this.layoutControl2.Dock = DockStyle.Fill;
            this.layoutControl2.Location = new Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new Size(0x3f5, 0x22a);
            this.layoutControl2.TabIndex = 14;
            this.layoutControl2.Text = "layoutControl2";
            this.simpleButton2.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseTextOptions = true;
            this.simpleButton2.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.simpleButton2.Location = new Point(0x351, 7);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x9d, 0x56);
            this.simpleButton2.StyleController = this.layoutControl2;
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "LİSTEDE YOKSA EKLEYİNİZ";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton3.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Appearance.Options.UseTextOptions = true;
            this.simpleButton3.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.simpleButton3.Location = new Point(0x2b0, 7);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(0x9d, 0x56);
            this.simpleButton3.StyleController = this.layoutControl2;
            this.simpleButton3.TabIndex = 2;
            this.simpleButton3.Text = "TEKNİK RESİM G\x00d6R";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray3 = new BaseLayoutItem[] { this.layoutControlItem9, this.layoutControlItem11, this.layoutControlItem10, this.layoutControlItem12, this.layoutControlItem13 };
            this.layoutControlGroup2.Items.AddRange(itemArray3);
            this.layoutControlGroup2.Location = new Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup2.Size = new Size(0x3f5, 0x22a);
            this.layoutControlGroup2.TextVisible = false;
            this.layoutControlItem9.Control = this.groupControl1;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new Point(0, 0);
            this.layoutControlItem9.MinSize = new Size(0x68, 90);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new Size(520, 90);
            this.layoutControlItem9.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem11.Control = this.simpleButton1;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new Point(520, 0);
            this.layoutControlItem11.MaxSize = new Size(0xa1, 0);
            this.layoutControlItem11.MinSize = new Size(0x8f, 1);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new Size(0xa1, 90);
            this.layoutControlItem11.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem11.TextSize = new Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            this.layoutControlItem10.Control = this.gridControl1;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new Point(0, 90);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new Size(0x3eb, 0x1c6);
            this.layoutControlItem10.TextSize = new Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.layoutControlItem12.Control = this.simpleButton3;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new Point(0x2a9, 0);
            this.layoutControlItem12.MaxSize = new Size(0xa1, 0);
            this.layoutControlItem12.MinSize = new Size(0x92, 0x1a);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new Size(0xa1, 90);
            this.layoutControlItem12.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem12.TextSize = new Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            this.layoutControlItem13.Control = this.simpleButton2;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new Point(0x34a, 0);
            this.layoutControlItem13.MaxSize = new Size(0xa1, 0);
            this.layoutControlItem13.MinSize = new Size(0xa1, 0x1a);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new Size(0xa1, 90);
            this.layoutControlItem13.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem13.TextSize = new Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3f5, 0x22a);
            base.Controls.Add(this.layoutControl2);
            this.MaximumSize = new Size(0x405, 0x251);
            this.MinimumSize = new Size(0x405, 0x251);
            base.Name = "makmot";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MOTOR BİLGİSİ SE\x00c7ME, G\x00d6RME VE EKLEME";
            base.Load += new EventHandler(this.makmot_Load);
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.textEdit3.Properties.EndInit();
            this.checkEdit3.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.checkEdit2.Properties.EndInit();
            this.textEdit1.Properties.EndInit();
            this.checkEdit1.Properties.EndInit();
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem2.EndInit();
            this.layoutControlItem8.EndInit();
            this.layoutControlItem3.EndInit();
            this.layoutControlItem4.EndInit();
            this.layoutControlItem7.EndInit();
            this.layoutControlItem5.EndInit();
            this.layoutControlItem6.EndInit();
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            this.repositoryItemHyperLinkEdit1.EndInit();
            this.repositoryItemHyperLinkEdit2.EndInit();
            this.layoutControl2.EndInit();
            this.layoutControl2.ResumeLayout(false);
            this.layoutControlGroup2.EndInit();
            this.layoutControlItem9.EndInit();
            this.layoutControlItem11.EndInit();
            this.layoutControlItem10.EndInit();
            this.layoutControlItem12.EndInit();
            this.layoutControlItem13.EndInit();
            base.ResumeLayout(false);
        }

        private void makmot_Load(object sender, EventArgs e)
        {
            try
            {
                this.yeni();
            }
            catch (Exception)
            {
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioButton1.Checked)
                {
                    this.dis = 1;
                    this.gridView1.SetRowCellValue(-2147483646, "diskontrol", this.dis);
                }
            }
            catch (Exception)
            {
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioButton2.Checked)
                {
                    this.dis = 0;
                    this.gridView1.SetRowCellValue(-2147483646, "diskontrol", this.dis);
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.GetFocusedRowCellValue("marka").ToString() != "")
                {
                    this.frm1.textBox12.Text = this.gridView1.GetFocusedRowCellValue("marka").ToString();
                    this.frm1.textBox12.Text = this.gridView1.GetFocusedRowCellValue("marka").ToString();
                }
                if (this.gridView1.GetFocusedRowCellValue("hiz").ToString() != "")
                {
                    this.frm1.BeyanHiz.Text = this.gridView1.GetFocusedRowCellValue("hiz").ToString();
                }
                if (this.gridView1.GetFocusedRowCellValue("motorkw").ToString() != "")
                {
                    this.frm1.MotorKw.Text = this.gridView1.GetFocusedRowCellValue("motorkw").ToString();
                }
                if (this.gridView1.GetFocusedRowCellValue("kasnakkanal").ToString() != "")
                {
                    this.frm1.HalatAdet.Text = this.gridView1.GetFocusedRowCellValue("kasnakkanal").ToString();
                }
                if (this.gridView1.GetFocusedRowCellValue("model").ToString() != "")
                {
                    this.frm1.textEdit23.Text = this.gridView1.GetFocusedRowCellValue("model").ToString();
                }
                if (this.gridView1.GetFocusedRowCellValue("verim").ToString() != "")
                {
                    this.frm1.MotorVerim.Text = this.gridView1.GetFocusedRowCellValue("verim").ToString();
                }
                if (this.gridView1.GetFocusedRowCellValue("kasnakcap").ToString() != "")
                {
                    this.frm1.textBox42.Text = this.gridView1.GetFocusedRowCellValue("kasnakcap").ToString();
                }
                if (this.gridView1.GetFocusedRowCellValue("halatcap").ToString() != "")
                {
                    for (int i = 0; i < this.frm1.HalatCap.Properties.Items.Count; i++)
                    {
                        if (this.frm1.HalatCap.Properties.Items[i].ToString() == this.gridView1.GetFocusedRowCellValue("halatcap").ToString())
                        {
                            this.frm1.HalatCap.SelectedIndex = i;
                        }
                    }
                }
                if (this.gridView1.GetFocusedRowCellValue("kapasite").ToString() != "")
                {
                    this.frm1.degisken = true;
                    this.frm1.sds = false;
                    this.frm1.BeyanYuk.Text = this.gridView1.GetFocusedRowCellValue("kapasite").ToString();
                }
                base.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                this.frm1.degisken = false;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            new motor { mkmt = this }.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string startupPath;
                object obj2 = this.gridView1.GetFocusedRowCellValue("edit").ToString();
                bool flag = Convert.ToBoolean(this.gridView1.GetFocusedRowCellValue("degisti"));
                this.edit = obj2.ToString();
                if (this.edit == "")
                {
                    MessageBox.Show("Teknik Resim Bulunamadı");
                }
                if (flag)
                {
                    startupPath = Application.StartupPath;
                }
                else
                {
                    this.edit = this.edit.Replace(@".\", "");
                    this.edit = this.edit.Replace(@"\", "/");
                    this.edit = this.edit.Replace("//", "/");
                    this.edit = this.edit.Replace("AKIŞ", "AKIS");
                    startupPath = "http://www.as-cad.net/fcert";
                }
                Process.Start(startupPath + this.edit);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.gridView1.SetRowCellValue(-2147483646, "kapasite", this.textEdit1.Text);
                this.checkEdit1.Checked = true;
            }
            catch (Exception)
            {
            }
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.gridView1.SetRowCellValue(-2147483646, "hiz", this.textEdit2.Text);
                this.checkEdit2.Checked = true;
            }
            catch (Exception)
            {
            }
        }

        private void textEdit3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.gridView1.SetRowCellValue(-2147483646, "aski", this.textEdit3.Text);
                this.checkEdit3.Checked = true;
            }
            catch (Exception)
            {
            }
        }

        public void yeni()
        {
            try
            {
                this.gridControl1.DataSource = this.xx.dtta("select * from motormakine1 where silindi=false", "");
            }
            catch (Exception)
            {
            }
        }
    }
}

