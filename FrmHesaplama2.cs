using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class FrmHesaplama2 : Form
	{
		private IContainer components = null;

		public DataGridView dataGridView1;

		private Button button1;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewCheckBoxColumn Column2;

		private DataGridViewTextBoxColumn Column4;

		public FrmHesaplama2()
		{
			this.InitializeComponent();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool flag = keyData == Keys.Escape;
			if (flag)
			{
				base.Close();
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
			asnhesapfrm asnhesapfrm = new asnhesapfrm();
			asnhesapfrm.Activate();
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
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmHesaplama2));
			this.dataGridView1 = new DataGridView();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewCheckBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.button1 = new Button();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column3,
				this.Column1,
				this.Column2,
				this.Column4
			});
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.Enabled = false;
			this.dataGridView1.Location = new Point(17, 12);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.ScrollBars = ScrollBars.None;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.dataGridView1.Size = new Size(1172, 204);
			this.dataGridView1.TabIndex = 177;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
			this.Column3.FillWeight = 45.68528f;
			this.Column3.HeaderText = "Sıra No";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Resizable = DataGridViewTriState.False;
			this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column3.Width = 60;
			dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column1.FillWeight = 127.1574f;
			this.Column1.HeaderText = "Hesap İçeriği";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = DataGridViewTriState.False;
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column1.Width = 542;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162);
			dataGridViewCellStyle6.NullValue = false;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
			this.Column2.FillWeight = 127.1574f;
			this.Column2.HeaderText = "Durum";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = DataGridViewTriState.False;
			this.Column2.Width = 70;
			dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.Column4.DefaultCellStyle = dataGridViewCellStyle7;
			this.Column4.HeaderText = "Hata Nedeni";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Resizable = DataGridViewTriState.False;
			this.Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column4.Width = 460;
			this.button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.button1.ImageAlign = ContentAlignment.MiddleLeft;
			this.button1.Location = new Point(556, 234);
			this.button1.Name = "button1";
			this.button1.Size = new Size(94, 38);
			this.button1.TabIndex = 178;
			this.button1.Text = "Geri Dön";
			this.button1.TextAlign = ContentAlignment.MiddleRight;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoScroll = true;
			base.ClientSize = new Size(1207, 295);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.dataGridView1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmHesaplama2";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "DİĞER HESAPLAR ÖZETİ";
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
