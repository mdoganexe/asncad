namespace ascad
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraLayout;
    using DevExpress.XtraLayout.Utils;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class yardimvideo : Form
    {
        private IContainer components = null;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private SimpleButton simpleButton1;
        public string videone = "";
        private WebBrowser webBrowser1;

        public yardimvideo()
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
            this.webBrowser1 = new WebBrowser();
            this.simpleButton1 = new SimpleButton();
            this.layoutControl1 = new LayoutControl();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem2.BeginInit();
            base.SuspendLayout();
            this.webBrowser1.Location = new Point(7, 0x21);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new Size(0x409, 600);
            this.webBrowser1.TabIndex = 0;
            this.simpleButton1.Location = new Point(7, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x409, 0x16);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "TARAYICI DA A\x00c7";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.webBrowser1);
            this.layoutControl1.Dock = DockStyle.Fill;
            this.layoutControl1.Location = new Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x417, 640);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x417, 640);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.Control = this.simpleButton1;
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x40d, 0x1a);
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem2.Control = this.webBrowser1;
            this.layoutControlItem2.Location = new Point(0, 0x1a);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x40d, 0x25c);
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x417, 640);
            base.Controls.Add(this.layoutControl1);
            base.Name = "yardimvideo";
            this.Text = "YARDIM VİDEOLARI";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.yardimvideo_Load);
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem2.EndInit();
            base.ResumeLayout(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://ascad.com.tr/yardim.php?vi=" + this.videone);
        }

        private void yardimvideo_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("https://ascad.com.tr/yardim.php?vi=" + this.videone);
        }
    }
}

