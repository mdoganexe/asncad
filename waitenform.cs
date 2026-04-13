using DevExpress.XtraWaitForm;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
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
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.progressPanel1 = new ProgressPanel();
			base.SuspendLayout();
			this.progressPanel1.get_Appearance().set_BackColor(Color.Transparent);
			this.progressPanel1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.progressPanel1.get_Appearance().get_Options().set_UseBackColor(true);
			this.progressPanel1.get_Appearance().get_Options().set_UseFont(true);
			this.progressPanel1.get_AppearanceCaption().set_Font(new Font("Microsoft Sans Serif", 12f));
			this.progressPanel1.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.progressPanel1.get_AppearanceDescription().set_Font(new Font("Microsoft Sans Serif", 8.25f));
			this.progressPanel1.get_AppearanceDescription().get_Options().set_UseFont(true);
			this.progressPanel1.set_Caption("LÜTFEN BEKLEYİNİZ");
			this.progressPanel1.set_Description("AsCAD Veriler Yükleniyor ...");
			this.progressPanel1.Dock = DockStyle.Fill;
			this.progressPanel1.set_ImageHorzOffset(20);
			this.progressPanel1.Location = new Point(0, 0);
			this.progressPanel1.Margin = new Padding(0, 3, 0, 3);
			this.progressPanel1.Name = "progressPanel1";
			this.progressPanel1.Size = new Size(291, 69);
			this.progressPanel1.TabIndex = 1;
			this.progressPanel1.Text = "progressPanel1";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(291, 69);
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
