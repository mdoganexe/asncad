using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class olcudeis : Form
	{
		public string OldValue = "";

		public string NewValue = "";

		private IContainer components = null;

		private SimpleButton simpleButton1;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private TextEdit textEdit1;

		public olcudeis()
		{
			this.InitializeComponent();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this.textEdit1.Text);
			if (flag)
			{
				this.NewValue = this.OldValue;
				base.Close();
			}
			else
			{
				this.NewValue = this.textEdit1.get_EditValue().ToString();
				base.Close();
			}
		}

		private void olcudeis_Load(object sender, EventArgs e)
		{
			Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
			base.Top = point.Y;
			base.Left = point.X;
			this.textEdit1.Text = this.OldValue;
			this.textEdit1.SelectAll();
		}

		private void textEdit1_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Return;
			if (flag)
			{
				this.simpleButton1.PerformClick();
			}
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
			this.textEdit1 = new TextEdit();
			this.layoutControl1 = new LayoutControl();
			this.simpleButton1 = new SimpleButton();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.textEdit1.get_Properties().BeginInit();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			base.SuspendLayout();
			this.textEdit1.Location = new Point(139, 7);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit1.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit1.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.textEdit1.get_Properties().get_DisplayFormat().set_FormatString("n0");
			this.textEdit1.get_Properties().get_DisplayFormat().set_FormatType(1);
			this.textEdit1.get_Properties().get_EditFormat().set_FormatString("n0");
			this.textEdit1.get_Properties().get_EditFormat().set_FormatType(1);
			this.textEdit1.get_Properties().get_Mask().set_EditMask("n0");
			this.textEdit1.get_Properties().get_Mask().set_MaskType(3);
			this.textEdit1.Size = new Size(104, 22);
			this.textEdit1.set_StyleController(this.layoutControl1);
			this.textEdit1.TabIndex = 0;
			this.textEdit1.KeyDown += new KeyEventHandler(this.textEdit1_KeyDown);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.textEdit1);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(335, 41);
			this.layoutControl1.TabIndex = 2;
			this.layoutControl1.Text = "layoutControl1";
			this.simpleButton1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Location = new Point(247, 7);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(81, 23);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 1;
			this.simpleButton1.Text = "OK";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(335, 41));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem1.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem1.set_Control(this.textEdit1);
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(240, 31));
			this.layoutControlItem1.set_Text("YENİ DEĞERİ GİRİNİZ");
			this.layoutControlItem1.set_TextSize(new Size(129, 16));
			this.layoutControlItem2.set_Control(this.simpleButton1);
			this.layoutControlItem2.set_Location(new Point(240, 0));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(85, 31));
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(335, 41);
			base.Controls.Add(this.layoutControl1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "olcudeis";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "ASCAD ÖLÇÜ DEĞİŞTİR";
			base.Load += new EventHandler(this.olcudeis_Load);
			this.textEdit1.get_Properties().EndInit();
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			base.ResumeLayout(false);
		}
	}
}
