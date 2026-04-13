namespace ascad
{
    using DevExpress.XtraWaitForm;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class waitenform : Form
    {
        private IContainer components = null;
        private ProgressPanel progressPanel1;

        public waitenform()
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
            this.progressPanel1 = new ProgressPanel();
            base.SuspendLayout();
            this.progressPanel1.Appearance.BackColor = Color.Transparent;
            this.progressPanel1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Appearance.Options.UseFont = true;
            this.progressPanel1.AppearanceCaption.Font = new Font("Microsoft Sans Serif", 12f);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.Caption = "L\x00dcTFEN BEKLEYİNİZ";
            this.progressPanel1.Description = "AsCAD Veriler Y\x00fckleniyor ...";
            this.progressPanel1.Dock = DockStyle.Fill;
            this.progressPanel1.ImageHorzOffset = 20;
            this.progressPanel1.Location = new Point(0, 0);
            this.progressPanel1.Margin = new Padding(0, 3, 0, 3);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new Size(0x123, 0x45);
            this.progressPanel1.TabIndex = 1;
            this.progressPanel1.Text = "progressPanel1";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x123, 0x45);
            base.ControlBox = false;
            base.Controls.Add(this.progressPanel1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "waitenform";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ASCAD";
            base.TopMost = true;
            base.ResumeLayout(false);
        }
    }
}

