using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class FrmOtel : Form
	{
		private abc1 xx = new abc1();

		private IContainer components = null;

		public Label label3;

		private TextBox textBox1;

		public Label label2;

		public GroupBox groupBox1;

		public Button button1;

		public Label label1;

		public FrmOtel()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.textBox1.Text == "";
			if (flag)
			{
				this.label3.Text = "0";
			}
			else
			{
				try
				{
					this.label3.Text = int.Parse(this.textBox1.Text).ToString();
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void FrmOtel_Load(object sender, EventArgs e)
		{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmOtel));
			this.label3 = new Label();
			this.label2 = new Label();
			this.groupBox1 = new GroupBox();
			this.button1 = new Button();
			this.label1 = new Label();
			this.textBox1 = new TextBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.label3.AutoSize = true;
			this.label3.Location = new Point(142, 67);
			this.label3.Name = "label3";
			this.label3.Size = new Size(16, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "0";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(40, 67);
			this.label2.Name = "label2";
			this.label2.Size = new Size(58, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Toplam";
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 162);
			this.groupBox1.Location = new Point(69, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(210, 149);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "OTEL";
			this.button1.Location = new Point(74, 110);
			this.button1.Name = "button1";
			this.button1.Size = new Size(84, 29);
			this.button1.TabIndex = 1;
			this.button1.Text = "Onayla";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(28, 26);
			this.label1.Name = "label1";
			this.label1.Size = new Size(88, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Yatak Sayısı";
			this.textBox1.Location = new Point(127, 23);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(46, 24);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "0";
			this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(349, 217);
			base.Controls.Add(this.groupBox1);
			base.MaximizeBox = false;
			this.MaximumSize = new Size(365, 256);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(365, 256);
			base.Name = "FrmOtel";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Load += new EventHandler(this.FrmOtel_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
