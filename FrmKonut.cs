using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class FrmKonut : Form
	{
		private abc1 xx = new abc1();

		private int tip1;

		private int tip2;

		private int tip3;

		private int tip4;

		private int toplam;

		private int tip5;

		private IContainer components = null;

		private Label label7;

		private TextBox textBox2;

		private Label label8;

		public Label label5;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private TextBox textBox11;

		public Label label19;

		private TextBox textBox1;

		private TextBox textBox9;

		private Label label14;

		private Label label15;

		private Label label12;

		private TextBox textBox10;

		private Label label13;

		private Label label6;

		public GroupBox groupBox3;

		public Button button1;

		public Label label16;

		public RichTextBox richTextBox1;

		public FrmKonut()
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
				this.tip1 = 0;
				this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
				this.label1.Text = this.tip1.ToString();
				this.label19.Text = this.toplam.ToString();
			}
			else
			{
				try
				{
					this.tip1 = int.Parse(this.textBox1.Text) * 2;
					this.label1.Text = this.tip1.ToString();
					this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
					this.label19.Text = this.toplam.ToString();
				}
				catch (Exception)
				{
				}
			}
		}

		private void textBox9_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.textBox9.Text == "";
			if (flag)
			{
				this.tip2 = 0;
				this.label2.Text = this.tip2.ToString();
				this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
				this.label19.Text = this.toplam.ToString();
			}
			else
			{
				try
				{
					this.tip2 = int.Parse(this.textBox9.Text) * 3;
					this.label2.Text = this.tip2.ToString();
					this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
					this.label19.Text = this.toplam.ToString();
				}
				catch (Exception)
				{
				}
			}
		}

		private void textBox10_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.textBox10.Text == "";
			if (flag)
			{
				this.tip3 = 0;
				this.label3.Text = this.tip3.ToString();
				this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
				this.label19.Text = this.toplam.ToString();
			}
			else
			{
				try
				{
					this.tip3 = int.Parse(this.textBox10.Text) * 4;
					this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
					this.label3.Text = this.tip3.ToString();
					this.label19.Text = this.toplam.ToString();
				}
				catch (Exception)
				{
				}
			}
		}

		private void textBox11_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.textBox11.Text == "";
			if (flag)
			{
				this.tip4 = 0;
				this.label4.Text = this.tip4.ToString();
				this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
				this.label19.Text = this.toplam.ToString();
			}
			try
			{
				this.tip4 = int.Parse(this.textBox11.Text) * 5;
				this.label4.Text = this.tip4.ToString();
				this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
				this.label19.Text = this.toplam.ToString();
			}
			catch (Exception)
			{
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void label19_TextChanged(object sender, EventArgs e)
		{
			int num = int.Parse(this.label19.Text);
			bool flag = num >= 200;
			if (flag)
			{
				this.label19.BackColor = Color.Red;
			}
			else
			{
				this.label19.BackColor = Color.Transparent;
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.textBox11.Text == "";
			if (flag)
			{
				this.tip5 = 0;
				this.label7.Text = this.tip5.ToString();
				this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
				this.label19.Text = this.toplam.ToString();
			}
			try
			{
				this.tip5 = int.Parse(this.textBox2.Text) * 6;
				this.label7.Text = this.tip5.ToString();
				this.toplam = this.tip1 + this.tip2 + this.tip3 + this.tip4 + this.tip5;
				this.label19.Text = this.toplam.ToString();
			}
			catch (Exception)
			{
			}
		}

		private void FrmKonut_Load(object sender, EventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmKonut));
			this.groupBox3 = new GroupBox();
			this.label7 = new Label();
			this.textBox2 = new TextBox();
			this.label8 = new Label();
			this.button1 = new Button();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.label16 = new Label();
			this.textBox11 = new TextBox();
			this.label19 = new Label();
			this.textBox1 = new TextBox();
			this.textBox9 = new TextBox();
			this.label14 = new Label();
			this.label15 = new Label();
			this.label12 = new Label();
			this.textBox10 = new TextBox();
			this.label13 = new Label();
			this.label6 = new Label();
			this.richTextBox1 = new RichTextBox();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.textBox11);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Controls.Add(this.textBox9);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.textBox10);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 162);
			this.groupBox3.Location = new Point(52, 96);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(236, 294);
			this.groupBox3.TabIndex = 65;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "KONUT";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(174, 180);
			this.label7.Name = "label7";
			this.label7.Size = new Size(18, 20);
			this.label7.TabIndex = 18;
			this.label7.Text = "0";
			this.textBox2.Location = new Point(108, 177);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new Size(41, 26);
			this.textBox2.TabIndex = 17;
			this.textBox2.Text = "0";
			this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);
			this.textBox2.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(56, 180);
			this.label8.Name = "label8";
			this.label8.Size = new Size(36, 20);
			this.label8.TabIndex = 16;
			this.label8.Text = "5+1";
			this.button1.Location = new Point(83, 257);
			this.button1.Name = "button1";
			this.button1.Size = new Size(92, 28);
			this.button1.TabIndex = 15;
			this.button1.Text = "ONAYLA";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(97, 221);
			this.label5.Name = "label5";
			this.label5.Size = new Size(61, 20);
			this.label5.TabIndex = 14;
			this.label5.Text = "Toplam";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(174, 148);
			this.label4.Name = "label4";
			this.label4.Size = new Size(18, 20);
			this.label4.TabIndex = 13;
			this.label4.Text = "0";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(174, 118);
			this.label3.Name = "label3";
			this.label3.Size = new Size(18, 20);
			this.label3.TabIndex = 12;
			this.label3.Text = "0";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(174, 86);
			this.label2.Name = "label2";
			this.label2.Size = new Size(18, 20);
			this.label2.TabIndex = 11;
			this.label2.Text = "0";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(174, 54);
			this.label1.Name = "label1";
			this.label1.Size = new Size(18, 20);
			this.label1.TabIndex = 10;
			this.label1.Text = "0";
			this.label16.AutoSize = true;
			this.label16.Location = new Point(79, 23);
			this.label16.Name = "label16";
			this.label16.Size = new Size(92, 20);
			this.label16.TabIndex = 8;
			this.label16.Text = "Daire Sayısı";
			this.textBox11.Location = new Point(108, 145);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new Size(41, 26);
			this.textBox11.TabIndex = 7;
			this.textBox11.Text = "0";
			this.textBox11.TextChanged += new EventHandler(this.textBox11_TextChanged);
			this.textBox11.KeyPress += new KeyPressEventHandler(this.textBox11_KeyPress);
			this.label19.AutoSize = true;
			this.label19.Location = new Point(180, 221);
			this.label19.Name = "label19";
			this.label19.Size = new Size(18, 20);
			this.label19.TabIndex = 9;
			this.label19.Text = "0";
			this.label19.TextChanged += new EventHandler(this.label19_TextChanged);
			this.textBox1.Location = new Point(108, 51);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(41, 26);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "0";
			this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
			this.textBox9.Location = new Point(108, 83);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new Size(41, 26);
			this.textBox9.TabIndex = 5;
			this.textBox9.Text = "0";
			this.textBox9.TextChanged += new EventHandler(this.textBox9_TextChanged);
			this.textBox9.KeyPress += new KeyPressEventHandler(this.textBox9_KeyPress);
			this.label14.AutoSize = true;
			this.label14.Location = new Point(56, 118);
			this.label14.Name = "label14";
			this.label14.Size = new Size(36, 20);
			this.label14.TabIndex = 2;
			this.label14.Text = "3+1";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(56, 148);
			this.label15.Name = "label15";
			this.label15.Size = new Size(36, 20);
			this.label15.TabIndex = 3;
			this.label15.Text = "4+1";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(56, 54);
			this.label12.Name = "label12";
			this.label12.Size = new Size(36, 20);
			this.label12.TabIndex = 0;
			this.label12.Text = "1+1";
			this.textBox10.Location = new Point(108, 115);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new Size(41, 26);
			this.textBox10.TabIndex = 6;
			this.textBox10.Text = "0";
			this.textBox10.TextChanged += new EventHandler(this.textBox10_TextChanged);
			this.textBox10.KeyPress += new KeyPressEventHandler(this.textBox10_KeyPress);
			this.label13.AutoSize = true;
			this.label13.Location = new Point(56, 86);
			this.label13.Name = "label13";
			this.label13.Size = new Size(36, 20);
			this.label13.TabIndex = 1;
			this.label13.Text = "2+1";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(7, 17);
			this.label6.Name = "label6";
			this.label6.Size = new Size(0, 13);
			this.label6.TabIndex = 66;
			this.richTextBox1.BackColor = SystemColors.Control;
			this.richTextBox1.BorderStyle = BorderStyle.None;
			this.richTextBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 162);
			this.richTextBox1.Location = new Point(29, 17);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new Size(283, 54);
			this.richTextBox1.TabIndex = 67;
			this.richTextBox1.Text = "ZEMİN KAT ÜZERİNDEKİ daire adetlerini yazınız..";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(341, 405);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.richTextBox1);
			base.MaximizeBox = false;
			this.MaximumSize = new Size(357, 444);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(357, 444);
			base.Name = "FrmKonut";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Load += new EventHandler(this.FrmKonut_Load);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
