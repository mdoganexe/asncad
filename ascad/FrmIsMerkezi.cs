namespace ascad
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmIsMerkezi : Form
    {
        public Button button1;
        private IContainer components = null;
        public GroupBox groupBox1;
        public Label label1;
        public Label label2;
        public Label label3;
        private TextBox textBox1;
        private abc1 xx = new abc1();

        public FrmIsMerkezi()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmIsMerkezi_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmIsMerkezi));
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.groupBox1 = new GroupBox();
            this.label1 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.button1.Location = new Point(0x4a, 110);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x52, 0x1a);
            this.button1.TabIndex = 5;
            this.button1.Text = "Onayla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox1.Location = new Point(0x98, 0x23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x3a, 0x18);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 0x26);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x83, 0x12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Toplam MetreKare";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x47, 0x4c);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3a, 0x12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Toplam";
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.groupBox1.Location = new Point(0x22, 0x17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xe3, 0x91);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İŞ MERKEZİ";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0xac, 0x4c);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x10, 0x12);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x126, 190);
            base.Controls.Add(this.groupBox1);
            base.MaximizeBox = false;
            this.MaximumSize = new Size(310, 0xe5);
            base.MinimizeBox = false;
            this.MinimumSize = new Size(310, 0xe5);
            base.Name = "FrmIsMerkezi";
            base.StartPosition = FormStartPosition.CenterScreen;
            base.Load += new EventHandler(this.FrmIsMerkezi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                this.label1.Text = "0";
            }
            else
            {
                double a = double.Parse(this.textBox1.Text) / 12.0;
                this.label1.Text = Math.Round(a).ToString();
                if (a >= 200.0)
                {
                    this.label1.BackColor = Color.Red;
                }
                else
                {
                    this.label1.BackColor = Color.Transparent;
                }
            }
        }
    }
}

