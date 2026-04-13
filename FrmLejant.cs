using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class FrmLejant : Form
	{
		private IContainer components = null;

		private ListBox listBox1;

		public FrmLejant()
		{
			this.InitializeComponent();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			yazilar yazilar = this.listBox1.SelectedItem as yazilar;
			string nedurki = yazilar.nedurki;
			Clipboard.SetDataObject(nedurki, false);
		}

		private void FrmLejant_Load(object sender, EventArgs e)
		{
			yazilar.listele(this.listBox1.Items);
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
			this.listBox1 = new ListBox();
			base.SuspendLayout();
			this.listBox1.Dock = DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new Size(142, 261);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(142, 261);
			base.Controls.Add(this.listBox1);
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "FrmLejant";
			base.TopMost = true;
			base.Load += new EventHandler(this.FrmLejant_Load);
			base.ResumeLayout(false);
		}
	}
}
