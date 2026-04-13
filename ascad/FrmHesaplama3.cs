namespace ascad
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmHesaplama3 : Form
    {
        private Button button1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private IContainer components = null;
        public DataGridView dataGridView1;

        public FrmHesaplama3()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
            new asnhesapfrm().Activate();
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
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            DataGridViewCellStyle style7 = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmHesaplama3));
            this.dataGridView1 = new DataGridView();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewCheckBoxColumn();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.button1 = new Button();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = style;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.Column3, this.Column1, this.Column2, this.Column4 };
            this.dataGridView1.Columns.AddRange(dataGridViewColumns);
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = SystemColors.Window;
            style2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            style2.ForeColor = SystemColors.ControlText;
            style2.SelectionBackColor = SystemColors.Highlight;
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = style2;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new Point(10, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style3.BackColor = SystemColors.Control;
            style3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            style3.ForeColor = SystemColors.WindowText;
            style3.SelectionBackColor = SystemColors.Highlight;
            style3.SelectionForeColor = SystemColors.HighlightText;
            style3.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = style3;
            this.dataGridView1.ScrollBars = ScrollBars.None;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new Size(0x494, 0x1d1);
            this.dataGridView1.TabIndex = 0xb2;
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.Column3.DefaultCellStyle = style4;
            this.Column3.FillWeight = 45.68528f;
            this.Column3.HeaderText = "Sıra No";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = DataGridViewTriState.False;
            this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 60;
            style5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.Column1.DefaultCellStyle = style5;
            this.Column1.FillWeight = 127.1574f;
            this.Column1.HeaderText = "Hesap İ\x00e7eriği";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = DataGridViewTriState.False;
            this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 0x21e;
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            style6.NullValue = false;
            this.Column2.DefaultCellStyle = style6;
            this.Column2.FillWeight = 127.1574f;
            this.Column2.HeaderText = "Durum";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = DataGridViewTriState.False;
            this.Column2.Width = 70;
            style7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.Column4.DefaultCellStyle = style7;
            this.Column4.HeaderText = "Hata Nedeni";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = DataGridViewTriState.False;
            this.Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 460;
            this.button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.button1.ImageAlign = ContentAlignment.MiddleLeft;
            this.button1.Location = new Point(0x21f, 0x1ec);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x6a, 0x27);
            this.button1.TabIndex = 0xb3;
            this.button1.Text = "Geri D\x00f6n";
            this.button1.TextAlign = ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            base.ClientSize = new Size(0x4a8, 0x221);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.dataGridView1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmHesaplama3";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HİDROLİK ASANS\x00d6R HESAP \x00d6ZETİ";
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                base.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

