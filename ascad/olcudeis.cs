namespace ascad
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Mask;
    using DevExpress.XtraLayout;
    using DevExpress.XtraLayout.Utils;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class olcudeis : Form
    {
        private IContainer components = null;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        public string NewValue = "";
        public string OldValue = "";
        private SimpleButton simpleButton1;
        private TextEdit textEdit1;

        public olcudeis()
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

        private void InitializeComponent()
        {
            this.textEdit1 = new TextEdit();
            this.layoutControl1 = new LayoutControl();
            this.simpleButton1 = new SimpleButton();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.textEdit1.Properties.BeginInit();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem2.BeginInit();
            base.SuspendLayout();
            this.textEdit1.Location = new Point(0x8b, 7);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.textEdit1.Properties.DisplayFormat.FormatString = "n0";
            this.textEdit1.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.textEdit1.Properties.EditFormat.FormatString = "n0";
            this.textEdit1.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.textEdit1.Properties.Mask.EditMask = "n0";
            this.textEdit1.Properties.Mask.MaskType = MaskType.Numeric;
            this.textEdit1.Size = new Size(0x68, 0x16);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 0;
            this.textEdit1.KeyDown += new KeyEventHandler(this.textEdit1_KeyDown);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Dock = DockStyle.Fill;
            this.layoutControl1.Location = new Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x14f, 0x29);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            this.simpleButton1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new Point(0xf7, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x51, 0x17);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x14f, 0x29);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(240, 0x1f);
            this.layoutControlItem1.Text = "YENİ DEĞERİ GİRİNİZ";
            this.layoutControlItem1.TextSize = new Size(0x81, 0x10);
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new Point(240, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x55, 0x1f);
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x14f, 0x29);
            base.Controls.Add(this.layoutControl1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "olcudeis";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            this.Text = "ASCAD \x00d6L\x00c7\x00dc DEĞİŞTİR";
            base.Load += new EventHandler(this.olcudeis_Load);
            this.textEdit1.Properties.EndInit();
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem2.EndInit();
            base.ResumeLayout(false);
        }

        private void olcudeis_Load(object sender, EventArgs e)
        {
            Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
            base.Top = point.Y;
            base.Left = point.X;
            this.textEdit1.Text = this.OldValue;
            this.textEdit1.SelectAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEdit1.Text))
            {
                this.NewValue = this.OldValue;
                base.Close();
            }
            else
            {
                this.NewValue = this.textEdit1.EditValue.ToString();
                base.Close();
            }
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.simpleButton1.PerformClick();
            }
        }
    }
}

