using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class FrmOkul : Form
	{
		private abc1 xx = new abc1();

		private IContainer components = null;

		private TextBox textBox1;

		public Label label4;

		public Label label3;

		private TextBox textBox2;

		public Label label2;

		public Label label1;

		public GroupBox groupBox1;

		public Button button1;

		public FrmOkul()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.textBox2.Text == "" || this.textBox1.Text == "";
			if (flag)
			{
				this.label1.Text = "0";
			}
			else
			{
				int num = int.Parse(this.textBox1.Text) * int.Parse(this.textBox2.Text);
				double a = (double)(num * 8 / 10);
				this.label1.Text = Math.Round(a).ToString();
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.textBox2.Text == "";
			if (flag)
			{
				this.label1.Text = "0";
			}
			else
			{
				int num = int.Parse(this.textBox1.Text) * int.Parse(this.textBox2.Text);
				double num2 = (double)(num * 8 / 10);
				this.label1.Text = Math.Round(num2).ToString();
				bool flag2 = num2 >= 200.0;
				if (flag2)
				{
					this.label1.BackColor = Color.Red;
				}
				else
				{
					this.label1.BackColor = Color.Transparent;
				}
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
			if (flag)
			{
				e.Handled = true;
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

		private void FrmOkul_Load(object sender, EventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmOkul));
			this.textBox1 = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.groupBox1 = new GroupBox();
			this.button1 = new Button();
			this.textBox2 = new TextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.textBox1.Location = new Point(181, 39);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(61, 24);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "0";
			this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(47, 136);
			this.label4.Name = "label4";
			this.label4.Size = new Size(58, 18);
			this.label4.TabIndex = 3;
			this.label4.Text = "Toplam";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(21, 85);
			this.label3.Name = "label3";
			this.label3.Size = new Size(147, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "Sınıfların MetreKaresi";
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 162);
			this.groupBox1.Location = new Point(31, 29);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(256, 209);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "OKUL";
			this.button1.Location = new Point(103, 168);
			this.button1.Name = "button1";
			this.button1.Size = new Size(82, 26);
			this.button1.TabIndex = 6;
			this.button1.Text = "Onayla";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.textBox2.Location = new Point(181, 82);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new Size(61, 24);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "0";
			this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);
			this.textBox2.KeyPress += new KeyPressEventHandler(this.textBox2_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(21, 45);
			this.label2.Name = "label2";
			this.label2.Size = new Size(79, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Sınıf Sayısı";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(189, 136);
			this.label1.Name = "label1";
			this.label1.Size = new Size(16, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "0";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(318, 266);
			base.Controls.Add(this.groupBox1);
			base.MaximizeBox = false;
			this.MaximumSize = new Size(334, 305);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(334, 305);
			base.Name = "FrmOkul";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Load += new EventHandler(this.FrmOkul_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
