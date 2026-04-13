using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class FirmaBilgileri : Form
	{
		private abc1 xx = new abc1();

		private IContainer components = null;

		public SimpleButton button1;

		public LabelControl label1;

		private LayoutControl layoutControl2;

		private TextEdit textEdit5;

		private TextEdit textBox3;

		private TextEdit textBox5;

		private TextEdit textBox4;

		private TextEdit textBox1;

		private LayoutControlGroup layoutControlGroup2;

		private TextEdit textEdit9;

		private TextEdit textEdit8;

		private TextEdit textBox2;

		private TextEdit textBox6;

		private TextEdit textEdit11;

		private DateEdit dateEdit2;

		private TextEdit textEdit10;

		private DateEdit dateEdit1;

		private LayoutControlItem layoutControlItem5;

		private LabelControl labelControl1;

		private LayoutControlItem layoutControlItem6;

		private LayoutControlItem layoutControlItem1;

		public LayoutControlItem layoutControlItem15;

		public LayoutControlItem layoutControlItem16;

		public LayoutControlItem layoutControlItem17;

		public LayoutControlItem layoutControlItem18;

		public LayoutControlItem layoutControlItem19;

		public LayoutControlItem layoutControlItem20;

		public LayoutControlItem layoutControlItem21;

		public LayoutControlItem layoutControlItem22;

		public LayoutControlItem layoutControlItem23;

		public LayoutControlItem layoutControlItem24;

		public LayoutControlItem layoutControlItem25;

		public LayoutControlItem layoutControlItem26;

		public LayoutControlItem layoutControlItem27;

		private TextEdit emsmm;

		private TextEdit embel;

		private TextEdit emoda;

		private TextEdit emad;

		private TextEdit mmsmm;

		private TextEdit mmbel;

		private TextEdit mmoda;

		private TextEdit mmad;

		private LabelControl labelControl9;

		private LabelControl labelControl8;

		private LabelControl labelControl7;

		private LabelControl labelControl6;

		private LabelControl labelControl5;

		private LabelControl labelControl4;

		private LabelControl labelControl3;

		private LabelControl labelControl2;

		private LayoutControlItem layoutControlItem2;

		private LayoutControlItem layoutControlItem3;

		private LayoutControlItem layoutControlItem4;

		private LayoutControlItem layoutControlItem7;

		private LayoutControlItem layoutControlItem8;

		private LayoutControlItem layoutControlItem9;

		private LayoutControlItem layoutControlItem10;

		private LayoutControlItem layoutControlItem11;

		private LayoutControlItem layoutControlItem12;

		private LayoutControlItem layoutControlItem13;

		private LayoutControlItem layoutControlItem14;

		private LayoutControlItem layoutControlItem28;

		private LayoutControlItem layoutControlItem29;

		private LayoutControlItem layoutControlItem30;

		private LayoutControlItem layoutControlItem31;

		private LayoutControlItem layoutControlItem32;

		public FirmaBilgileri()
		{
			this.InitializeComponent();
		}

		private void FirmaBilgileri_Load(object sender, EventArgs e)
		{
			try
			{
				DataTable dataTable = this.xx.dtta("select * from firmabilgi", "");
				this.textBox1.Text = dataTable.Rows[0]["ad"].ToString();
				this.textBox4.Text = dataTable.Rows[0]["tel"].ToString();
				this.textBox5.Text = dataTable.Rows[0]["fax"].ToString();
				this.textBox6.Text = dataTable.Rows[0]["mail"].ToString();
				this.textBox3.Text = dataTable.Rows[0]["yetkili"].ToString();
				this.textEdit5.Text = dataTable.Rows[0]["marka"].ToString();
				this.textBox2.Text = dataTable.Rows[0]["adres"].ToString();
				this.textEdit8.Text = dataTable.Rows[0]["onkurulusad"].ToString();
				this.textEdit9.Text = dataTable.Rows[0]["onkurulusno"].ToString();
				this.dateEdit1.Text = dataTable.Rows[0]["santar"].ToString();
				this.textEdit10.Text = dataTable.Rows[0]["sanno"].ToString();
				this.dateEdit2.Text = dataTable.Rows[0]["hybtar"].ToString();
				this.textEdit11.Text = dataTable.Rows[0]["hybno"].ToString();
				this.mmad.Text = dataTable.Rows[0]["mmad"].ToString();
				this.mmoda.Text = dataTable.Rows[0]["mmoda"].ToString();
				this.mmbel.Text = dataTable.Rows[0]["mmbel"].ToString();
				this.mmsmm.Text = dataTable.Rows[0]["mmsmm"].ToString();
				this.emad.Text = dataTable.Rows[0]["emad"].ToString();
				this.emoda.Text = dataTable.Rows[0]["emoda"].ToString();
				this.embel.Text = dataTable.Rows[0]["embel"].ToString();
				this.emsmm.Text = dataTable.Rows[0]["emsmm"].ToString();
				string text = dataTable.Rows[0]["dil"].ToString();
			}
			catch (Exception)
			{
				MessageBox.Show("İlk kez giriş yapıyosunuz bilgilerinizi doldurun...");
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			try
			{
				this.xx.oleupdate(string.Concat(new string[]
				{
					"update firmabilgi set ad='",
					this.textBox1.Text,
					"', tel='",
					this.textBox4.Text,
					"', fax='",
					this.textBox5.Text,
					"', mail='",
					this.textBox6.Text,
					"', yetkili='",
					this.textBox3.Text,
					"', marka='",
					this.textEdit5.Text,
					"', adres='",
					this.textBox2.Text,
					"', onkurulusad='",
					this.textEdit8.Text,
					"', onkurulusno='",
					this.textEdit9.Text,
					"', santar='",
					this.dateEdit1.Text,
					"', sanno='",
					this.textEdit10.Text,
					"', hybtar='",
					this.dateEdit2.Text,
					"', hybno='",
					this.textEdit11.Text,
					"', mmad='",
					this.mmad.Text,
					"', mmoda='",
					this.mmoda.Text,
					"', mmbel='",
					this.mmbel.Text,
					"', mmsmm='",
					this.mmsmm.Text,
					"', emad='",
					this.emad.Text,
					"', embel='",
					this.embel.Text,
					"', emoda='",
					this.emoda.Text,
					"', emsmm='",
					this.emsmm.Text,
					"' where id=1"
				}), "");
				base.Close();
			}
			catch (Exception)
			{
				throw;
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
			this.button1 = new SimpleButton();
			this.layoutControl2 = new LayoutControl();
			this.emsmm = new TextEdit();
			this.embel = new TextEdit();
			this.emoda = new TextEdit();
			this.emad = new TextEdit();
			this.mmsmm = new TextEdit();
			this.mmbel = new TextEdit();
			this.mmoda = new TextEdit();
			this.mmad = new TextEdit();
			this.labelControl9 = new LabelControl();
			this.labelControl8 = new LabelControl();
			this.labelControl7 = new LabelControl();
			this.labelControl6 = new LabelControl();
			this.labelControl5 = new LabelControl();
			this.labelControl4 = new LabelControl();
			this.labelControl3 = new LabelControl();
			this.labelControl2 = new LabelControl();
			this.labelControl1 = new LabelControl();
			this.textEdit11 = new TextEdit();
			this.dateEdit2 = new DateEdit();
			this.textEdit10 = new TextEdit();
			this.dateEdit1 = new DateEdit();
			this.textEdit9 = new TextEdit();
			this.textEdit8 = new TextEdit();
			this.textBox2 = new TextEdit();
			this.label1 = new LabelControl();
			this.textBox6 = new TextEdit();
			this.textEdit5 = new TextEdit();
			this.textBox3 = new TextEdit();
			this.textBox5 = new TextEdit();
			this.textBox4 = new TextEdit();
			this.textBox1 = new TextEdit();
			this.layoutControlGroup2 = new LayoutControlGroup();
			this.layoutControlItem15 = new LayoutControlItem();
			this.layoutControlItem25 = new LayoutControlItem();
			this.layoutControlItem26 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem22 = new LayoutControlItem();
			this.layoutControlItem23 = new LayoutControlItem();
			this.layoutControlItem18 = new LayoutControlItem();
			this.layoutControlItem24 = new LayoutControlItem();
			this.layoutControlItem27 = new LayoutControlItem();
			this.layoutControlItem21 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem19 = new LayoutControlItem();
			this.layoutControlItem16 = new LayoutControlItem();
			this.layoutControlItem20 = new LayoutControlItem();
			this.layoutControlItem17 = new LayoutControlItem();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem9 = new LayoutControlItem();
			this.layoutControlItem10 = new LayoutControlItem();
			this.layoutControlItem11 = new LayoutControlItem();
			this.layoutControlItem12 = new LayoutControlItem();
			this.layoutControlItem13 = new LayoutControlItem();
			this.layoutControlItem14 = new LayoutControlItem();
			this.layoutControlItem28 = new LayoutControlItem();
			this.layoutControlItem29 = new LayoutControlItem();
			this.layoutControlItem30 = new LayoutControlItem();
			this.layoutControlItem31 = new LayoutControlItem();
			this.layoutControlItem32 = new LayoutControlItem();
			this.layoutControl2.BeginInit();
			this.layoutControl2.SuspendLayout();
			this.emsmm.get_Properties().BeginInit();
			this.embel.get_Properties().BeginInit();
			this.emoda.get_Properties().BeginInit();
			this.emad.get_Properties().BeginInit();
			this.mmsmm.get_Properties().BeginInit();
			this.mmbel.get_Properties().BeginInit();
			this.mmoda.get_Properties().BeginInit();
			this.mmad.get_Properties().BeginInit();
			this.textEdit11.get_Properties().BeginInit();
			this.dateEdit2.get_Properties().get_CalendarTimeProperties().BeginInit();
			this.dateEdit2.get_Properties().BeginInit();
			this.textEdit10.get_Properties().BeginInit();
			this.dateEdit1.get_Properties().get_CalendarTimeProperties().BeginInit();
			this.dateEdit1.get_Properties().BeginInit();
			this.textEdit9.get_Properties().BeginInit();
			this.textEdit8.get_Properties().BeginInit();
			this.textBox2.get_Properties().BeginInit();
			this.textBox6.get_Properties().BeginInit();
			this.textEdit5.get_Properties().BeginInit();
			this.textBox3.get_Properties().BeginInit();
			this.textBox5.get_Properties().BeginInit();
			this.textBox4.get_Properties().BeginInit();
			this.textBox1.get_Properties().BeginInit();
			this.layoutControlGroup2.BeginInit();
			this.layoutControlItem15.BeginInit();
			this.layoutControlItem25.BeginInit();
			this.layoutControlItem26.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem22.BeginInit();
			this.layoutControlItem23.BeginInit();
			this.layoutControlItem18.BeginInit();
			this.layoutControlItem24.BeginInit();
			this.layoutControlItem27.BeginInit();
			this.layoutControlItem21.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem19.BeginInit();
			this.layoutControlItem16.BeginInit();
			this.layoutControlItem20.BeginInit();
			this.layoutControlItem17.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem9.BeginInit();
			this.layoutControlItem10.BeginInit();
			this.layoutControlItem11.BeginInit();
			this.layoutControlItem12.BeginInit();
			this.layoutControlItem13.BeginInit();
			this.layoutControlItem14.BeginInit();
			this.layoutControlItem28.BeginInit();
			this.layoutControlItem29.BeginInit();
			this.layoutControlItem30.BeginInit();
			this.layoutControlItem31.BeginInit();
			this.layoutControlItem32.BeginInit();
			base.SuspendLayout();
			this.button1.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.button1.get_Appearance().get_Options().set_UseFont(true);
			this.button1.Location = new Point(7, 389);
			this.button1.Name = "button1";
			this.button1.Size = new Size(649, 38);
			this.button1.set_StyleController(this.layoutControl2);
			this.button1.TabIndex = 17;
			this.button1.Text = "Kaydet / Güncelle";
			this.button1.Click += new EventHandler(this.button1_Click_1);
			this.layoutControl2.Controls.Add(this.emsmm);
			this.layoutControl2.Controls.Add(this.embel);
			this.layoutControl2.Controls.Add(this.emoda);
			this.layoutControl2.Controls.Add(this.emad);
			this.layoutControl2.Controls.Add(this.mmsmm);
			this.layoutControl2.Controls.Add(this.mmbel);
			this.layoutControl2.Controls.Add(this.mmoda);
			this.layoutControl2.Controls.Add(this.mmad);
			this.layoutControl2.Controls.Add(this.labelControl9);
			this.layoutControl2.Controls.Add(this.labelControl8);
			this.layoutControl2.Controls.Add(this.labelControl7);
			this.layoutControl2.Controls.Add(this.labelControl6);
			this.layoutControl2.Controls.Add(this.labelControl5);
			this.layoutControl2.Controls.Add(this.labelControl4);
			this.layoutControl2.Controls.Add(this.labelControl3);
			this.layoutControl2.Controls.Add(this.labelControl2);
			this.layoutControl2.Controls.Add(this.labelControl1);
			this.layoutControl2.Controls.Add(this.textEdit11);
			this.layoutControl2.Controls.Add(this.dateEdit2);
			this.layoutControl2.Controls.Add(this.textEdit10);
			this.layoutControl2.Controls.Add(this.button1);
			this.layoutControl2.Controls.Add(this.dateEdit1);
			this.layoutControl2.Controls.Add(this.textEdit9);
			this.layoutControl2.Controls.Add(this.textEdit8);
			this.layoutControl2.Controls.Add(this.textBox2);
			this.layoutControl2.Controls.Add(this.label1);
			this.layoutControl2.Controls.Add(this.textBox6);
			this.layoutControl2.Controls.Add(this.textEdit5);
			this.layoutControl2.Controls.Add(this.textBox3);
			this.layoutControl2.Controls.Add(this.textBox5);
			this.layoutControl2.Controls.Add(this.textBox4);
			this.layoutControl2.Controls.Add(this.textBox1);
			this.layoutControl2.Dock = DockStyle.Fill;
			this.layoutControl2.Location = new Point(0, 0);
			this.layoutControl2.Name = "layoutControl2";
			this.layoutControl2.set_Root(this.layoutControlGroup2);
			this.layoutControl2.Size = new Size(663, 434);
			this.layoutControl2.TabIndex = 17;
			this.layoutControl2.Text = "layoutControl2";
			this.emsmm.Location = new Point(531, 363);
			this.emsmm.Name = "emsmm";
			this.emsmm.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.emsmm.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.emsmm.Size = new Size(125, 22);
			this.emsmm.set_StyleController(this.layoutControl2);
			this.emsmm.TabIndex = 34;
			this.embel.Location = new Point(401, 363);
			this.embel.Name = "embel";
			this.embel.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.embel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.embel.Size = new Size(126, 22);
			this.embel.set_StyleController(this.layoutControl2);
			this.embel.TabIndex = 33;
			this.emoda.Location = new Point(272, 363);
			this.emoda.Name = "emoda";
			this.emoda.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.emoda.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.emoda.Size = new Size(125, 22);
			this.emoda.set_StyleController(this.layoutControl2);
			this.emoda.TabIndex = 32;
			this.emad.Location = new Point(127, 363);
			this.emad.Name = "emad";
			this.emad.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.emad.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.emad.Size = new Size(141, 22);
			this.emad.set_StyleController(this.layoutControl2);
			this.emad.TabIndex = 31;
			this.mmsmm.Location = new Point(531, 337);
			this.mmsmm.Name = "mmsmm";
			this.mmsmm.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mmsmm.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.mmsmm.Size = new Size(125, 22);
			this.mmsmm.set_StyleController(this.layoutControl2);
			this.mmsmm.TabIndex = 30;
			this.mmbel.Location = new Point(401, 337);
			this.mmbel.Name = "mmbel";
			this.mmbel.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mmbel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.mmbel.Size = new Size(126, 22);
			this.mmbel.set_StyleController(this.layoutControl2);
			this.mmbel.TabIndex = 29;
			this.mmoda.Location = new Point(272, 337);
			this.mmoda.Name = "mmoda";
			this.mmoda.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mmoda.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.mmoda.Size = new Size(125, 22);
			this.mmoda.set_StyleController(this.layoutControl2);
			this.mmoda.TabIndex = 28;
			this.mmad.Location = new Point(127, 337);
			this.mmad.Name = "mmad";
			this.mmad.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mmad.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.mmad.Size = new Size(141, 22);
			this.mmad.set_StyleController(this.layoutControl2);
			this.mmad.TabIndex = 27;
			this.labelControl9.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl9.Location = new Point(7, 363);
			this.labelControl9.Name = "labelControl9";
			this.labelControl9.Size = new Size(116, 22);
			this.labelControl9.set_StyleController(this.layoutControl2);
			this.labelControl9.TabIndex = 26;
			this.labelControl9.Text = "ELEKTRİK MÜH.";
			this.labelControl8.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl8.Location = new Point(7, 337);
			this.labelControl8.Name = "labelControl8";
			this.labelControl8.Size = new Size(116, 22);
			this.labelControl8.set_StyleController(this.layoutControl2);
			this.labelControl8.TabIndex = 25;
			this.labelControl8.Text = "MAKİNA MÜH.";
			this.labelControl7.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl7.Location = new Point(531, 318);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new Size(125, 15);
			this.labelControl7.set_StyleController(this.layoutControl2);
			this.labelControl7.TabIndex = 24;
			this.labelControl7.Text = "SMM BELGE NO";
			this.labelControl6.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl6.Location = new Point(401, 318);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new Size(126, 15);
			this.labelControl6.set_StyleController(this.layoutControl2);
			this.labelControl6.TabIndex = 23;
			this.labelControl6.Text = "BELGE SİC NO";
			this.labelControl5.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl5.Location = new Point(272, 318);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new Size(125, 15);
			this.labelControl5.set_StyleController(this.layoutControl2);
			this.labelControl5.TabIndex = 22;
			this.labelControl5.Text = "ODA SİCİL NO";
			this.labelControl4.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl4.Location = new Point(127, 318);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new Size(141, 15);
			this.labelControl4.set_StyleController(this.layoutControl2);
			this.labelControl4.TabIndex = 21;
			this.labelControl4.Text = "ADI SOYADI";
			this.labelControl3.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl3.Location = new Point(7, 318);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new Size(116, 15);
			this.labelControl3.set_StyleController(this.layoutControl2);
			this.labelControl3.TabIndex = 20;
			this.labelControl3.Text = "ÜNVAN";
			this.labelControl2.Location = new Point(7, 301);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new Size(649, 13);
			this.labelControl2.set_StyleController(this.layoutControl2);
			this.labelControl2.TabIndex = 19;
			this.labelControl1.Location = new Point(7, 206);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new Size(649, 13);
			this.labelControl1.set_StyleController(this.layoutControl2);
			this.labelControl1.TabIndex = 18;
			this.textEdit11.set_EnterMoveNextControl(true);
			this.textEdit11.Location = new Point(492, 275);
			this.textEdit11.Name = "textEdit11";
			this.textEdit11.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit11.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit11.Size = new Size(164, 22);
			this.textEdit11.set_StyleController(this.layoutControl2);
			this.textEdit11.TabIndex = 16;
			this.dateEdit2.set_EditValue(null);
			this.dateEdit2.set_EnterMoveNextControl(true);
			this.dateEdit2.Location = new Point(175, 275);
			this.dateEdit2.Name = "dateEdit2";
			this.dateEdit2.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dateEdit2.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dateEdit2.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.dateEdit2.get_Properties().get_CalendarTimeProperties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton()
			});
			this.dateEdit2.Size = new Size(145, 22);
			this.dateEdit2.set_StyleController(this.layoutControl2);
			this.dateEdit2.TabIndex = 15;
			this.textEdit10.set_EnterMoveNextControl(true);
			this.textEdit10.Location = new Point(492, 249);
			this.textEdit10.Name = "textEdit10";
			this.textEdit10.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit10.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit10.Size = new Size(164, 22);
			this.textEdit10.set_StyleController(this.layoutControl2);
			this.textEdit10.TabIndex = 14;
			this.dateEdit1.set_EditValue(null);
			this.dateEdit1.set_EnterMoveNextControl(true);
			this.dateEdit1.Location = new Point(175, 249);
			this.dateEdit1.Name = "dateEdit1";
			this.dateEdit1.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dateEdit1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dateEdit1.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.dateEdit1.get_Properties().get_CalendarTimeProperties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton()
			});
			this.dateEdit1.Size = new Size(145, 22);
			this.dateEdit1.set_StyleController(this.layoutControl2);
			this.dateEdit1.TabIndex = 13;
			this.textEdit9.set_EnterMoveNextControl(true);
			this.textEdit9.Location = new Point(492, 223);
			this.textEdit9.Name = "textEdit9";
			this.textEdit9.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit9.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit9.Size = new Size(164, 22);
			this.textEdit9.set_StyleController(this.layoutControl2);
			this.textEdit9.TabIndex = 12;
			this.textEdit8.set_EnterMoveNextControl(true);
			this.textEdit8.Location = new Point(175, 223);
			this.textEdit8.Name = "textEdit8";
			this.textEdit8.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit8.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit8.Size = new Size(145, 22);
			this.textEdit8.set_StyleController(this.layoutControl2);
			this.textEdit8.TabIndex = 11;
			this.textBox2.Enabled = false;
			this.textBox2.set_EnterMoveNextControl(true);
			this.textBox2.Location = new Point(177, 180);
			this.textBox2.Name = "textBox2";
			this.textBox2.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textBox2.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textBox2.Size = new Size(479, 22);
			this.textBox2.set_StyleController(this.layoutControl2);
			this.textBox2.TabIndex = 10;
			this.label1.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.label1.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.label1.Location = new Point(180, 7);
			this.label1.Name = "label1";
			this.label1.Size = new Size(302, 13);
			this.label1.set_StyleController(this.layoutControl2);
			this.label1.TabIndex = 4;
			this.label1.Text = "TEKNİK DOSYA İÇİN FİRMA BİLGİLERİNİ GİRİNİZ...";
			this.textBox6.Enabled = false;
			this.textBox6.set_EnterMoveNextControl(true);
			this.textBox6.Location = new Point(177, 76);
			this.textBox6.Name = "textBox6";
			this.textBox6.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textBox6.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textBox6.Size = new Size(479, 22);
			this.textBox6.set_StyleController(this.layoutControl2);
			this.textBox6.TabIndex = 9;
			this.textEdit5.Enabled = false;
			this.textEdit5.set_EnterMoveNextControl(true);
			this.textEdit5.Location = new Point(177, 102);
			this.textEdit5.Name = "textEdit5";
			this.textEdit5.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit5.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit5.Size = new Size(479, 22);
			this.textEdit5.set_StyleController(this.layoutControl2);
			this.textEdit5.TabIndex = 8;
			this.textBox3.Enabled = false;
			this.textBox3.set_EnterMoveNextControl(true);
			this.textBox3.Location = new Point(177, 154);
			this.textBox3.Name = "textBox3";
			this.textBox3.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textBox3.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textBox3.Size = new Size(479, 22);
			this.textBox3.set_StyleController(this.layoutControl2);
			this.textBox3.TabIndex = 7;
			this.textBox5.Enabled = false;
			this.textBox5.set_EnterMoveNextControl(true);
			this.textBox5.Location = new Point(177, 128);
			this.textBox5.Name = "textBox5";
			this.textBox5.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textBox5.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textBox5.get_Properties().get_Mask().set_EditMask("0(999)000-00 00");
			this.textBox5.get_Properties().get_Mask().set_MaskType(6);
			this.textBox5.Size = new Size(479, 22);
			this.textBox5.set_StyleController(this.layoutControl2);
			this.textBox5.TabIndex = 6;
			this.textBox4.Enabled = false;
			this.textBox4.set_EnterMoveNextControl(true);
			this.textBox4.Location = new Point(177, 50);
			this.textBox4.Name = "textBox4";
			this.textBox4.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textBox4.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textBox4.get_Properties().get_Mask().set_EditMask("0(999)000-00 00");
			this.textBox4.get_Properties().get_Mask().set_MaskType(6);
			this.textBox4.Size = new Size(479, 22);
			this.textBox4.set_StyleController(this.layoutControl2);
			this.textBox4.TabIndex = 5;
			this.textBox1.Enabled = false;
			this.textBox1.set_EnterMoveNextControl(true);
			this.textBox1.Location = new Point(177, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textBox1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textBox1.Size = new Size(479, 22);
			this.textBox1.set_StyleController(this.layoutControl2);
			this.textBox1.TabIndex = 4;
			this.layoutControlGroup2.set_CustomizationFormText("layoutControlGroup2");
			this.layoutControlGroup2.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup2.set_GroupBordersVisible(false);
			this.layoutControlGroup2.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem15,
				this.layoutControlItem25,
				this.layoutControlItem26,
				this.layoutControlItem5,
				this.layoutControlItem22,
				this.layoutControlItem23,
				this.layoutControlItem24,
				this.layoutControlItem27,
				this.layoutControlItem21,
				this.layoutControlItem6,
				this.layoutControlItem16,
				this.layoutControlItem20,
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem3,
				this.layoutControlItem4,
				this.layoutControlItem7,
				this.layoutControlItem8,
				this.layoutControlItem9,
				this.layoutControlItem10,
				this.layoutControlItem11,
				this.layoutControlItem12,
				this.layoutControlItem13,
				this.layoutControlItem14,
				this.layoutControlItem28,
				this.layoutControlItem29,
				this.layoutControlItem30,
				this.layoutControlItem31,
				this.layoutControlItem32,
				this.layoutControlItem19,
				this.layoutControlItem17,
				this.layoutControlItem18
			});
			this.layoutControlGroup2.set_Location(new Point(0, 0));
			this.layoutControlGroup2.set_Name("Root");
			this.layoutControlGroup2.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup2.set_Size(new Size(663, 434));
			this.layoutControlGroup2.set_TextVisible(false);
			this.layoutControlItem15.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem15.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem15.set_Control(this.textBox1);
			this.layoutControlItem15.set_CustomizationFormText("Firma Adı :");
			this.layoutControlItem15.set_Location(new Point(0, 17));
			this.layoutControlItem15.set_Name("layoutControlItem15");
			this.layoutControlItem15.set_Size(new Size(653, 26));
			this.layoutControlItem15.set_Text("Firma Adı :");
			this.layoutControlItem15.set_TextAlignMode(2);
			this.layoutControlItem15.set_TextSize(new Size(165, 0));
			this.layoutControlItem15.set_TextToControlDistance(5);
			this.layoutControlItem25.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem25.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem25.set_Control(this.textEdit10);
			this.layoutControlItem25.set_CustomizationFormText("Sanayi Sicil Belge No :");
			this.layoutControlItem25.set_Location(new Point(317, 242));
			this.layoutControlItem25.set_Name("layoutControlItem25");
			this.layoutControlItem25.set_Size(new Size(336, 26));
			this.layoutControlItem25.set_Text("Sanayi Sicil Belge No :");
			this.layoutControlItem25.set_TextSize(new Size(165, 15));
			this.layoutControlItem26.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem26.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem26.set_Control(this.dateEdit2);
			this.layoutControlItem26.set_CustomizationFormText("HYB Belge Tarihi :");
			this.layoutControlItem26.set_Location(new Point(0, 268));
			this.layoutControlItem26.set_Name("layoutControlItem26");
			this.layoutControlItem26.set_Size(new Size(317, 26));
			this.layoutControlItem26.set_Text("HYB Belge Tarihi :");
			this.layoutControlItem26.set_TextSize(new Size(165, 15));
			this.layoutControlItem5.set_Control(this.button1);
			this.layoutControlItem5.set_CustomizationFormText("layoutControlItem5");
			this.layoutControlItem5.set_Location(new Point(0, 382));
			this.layoutControlItem5.set_MaxSize(new Size(0, 42));
			this.layoutControlItem5.set_MinSize(new Size(54, 42));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(653, 42));
			this.layoutControlItem5.set_SizeConstraintsType(2);
			this.layoutControlItem5.set_TextSize(new Size(0, 0));
			this.layoutControlItem5.set_TextVisible(false);
			this.layoutControlItem22.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem22.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem22.set_Control(this.textEdit8);
			this.layoutControlItem22.set_CustomizationFormText("Onaylayan Kuruluş Adı :");
			this.layoutControlItem22.set_Location(new Point(0, 216));
			this.layoutControlItem22.set_Name("layoutControlItem22");
			this.layoutControlItem22.set_Size(new Size(317, 26));
			this.layoutControlItem22.set_Text("Onaylayan Kuruluş Adı :");
			this.layoutControlItem22.set_TextSize(new Size(165, 15));
			this.layoutControlItem23.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem23.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem23.set_Control(this.textEdit9);
			this.layoutControlItem23.set_CustomizationFormText("Onaylayan Kuruluş No :");
			this.layoutControlItem23.set_Location(new Point(317, 216));
			this.layoutControlItem23.set_Name("layoutControlItem23");
			this.layoutControlItem23.set_Size(new Size(336, 26));
			this.layoutControlItem23.set_Text("Onaylayan Kuruluş No :");
			this.layoutControlItem23.set_TextSize(new Size(165, 15));
			this.layoutControlItem18.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem18.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem18.set_Control(this.textBox3);
			this.layoutControlItem18.set_CustomizationFormText("Firma Yetkili :");
			this.layoutControlItem18.set_Location(new Point(0, 147));
			this.layoutControlItem18.set_Name("layoutControlItem18");
			this.layoutControlItem18.set_Size(new Size(653, 26));
			this.layoutControlItem18.set_Text("Firma Yetkili :");
			this.layoutControlItem18.set_TextAlignMode(2);
			this.layoutControlItem18.set_TextSize(new Size(165, 0));
			this.layoutControlItem18.set_TextToControlDistance(5);
			this.layoutControlItem24.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem24.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem24.set_Control(this.dateEdit1);
			this.layoutControlItem24.set_CustomizationFormText("Sanayi Sicil Belge Tarihi :");
			this.layoutControlItem24.set_Location(new Point(0, 242));
			this.layoutControlItem24.set_Name("layoutControlItem24");
			this.layoutControlItem24.set_Size(new Size(317, 26));
			this.layoutControlItem24.set_Text("Sanayi Sicil Belge Tarihi :");
			this.layoutControlItem24.set_TextSize(new Size(165, 15));
			this.layoutControlItem27.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem27.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem27.set_Control(this.textEdit11);
			this.layoutControlItem27.set_CustomizationFormText("HYB BELGE NO :");
			this.layoutControlItem27.set_Location(new Point(317, 268));
			this.layoutControlItem27.set_Name("layoutControlItem27");
			this.layoutControlItem27.set_Size(new Size(336, 26));
			this.layoutControlItem27.set_Text("HYB Belge No :");
			this.layoutControlItem27.set_TextSize(new Size(165, 15));
			this.layoutControlItem21.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem21.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem21.set_Control(this.textBox2);
			this.layoutControlItem21.set_CustomizationFormText("Firma Adresi :");
			this.layoutControlItem21.set_Location(new Point(0, 173));
			this.layoutControlItem21.set_Name("layoutControlItem21");
			this.layoutControlItem21.set_Size(new Size(653, 26));
			this.layoutControlItem21.set_Text("Firma Adresi :");
			this.layoutControlItem21.set_TextAlignMode(2);
			this.layoutControlItem21.set_TextSize(new Size(165, 0));
			this.layoutControlItem21.set_TextToControlDistance(5);
			this.layoutControlItem6.set_Control(this.labelControl1);
			this.layoutControlItem6.set_CustomizationFormText("layoutControlItem6");
			this.layoutControlItem6.set_Location(new Point(0, 199));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(653, 17));
			this.layoutControlItem6.set_TextSize(new Size(0, 0));
			this.layoutControlItem6.set_TextVisible(false);
			this.layoutControlItem19.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem19.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem19.set_Control(this.textEdit5);
			this.layoutControlItem19.set_CustomizationFormText("Firma Marka :");
			this.layoutControlItem19.set_Location(new Point(0, 95));
			this.layoutControlItem19.set_Name("layoutControlItem19");
			this.layoutControlItem19.set_Size(new Size(653, 26));
			this.layoutControlItem19.set_Text("Firma Marka :");
			this.layoutControlItem19.set_TextAlignMode(2);
			this.layoutControlItem19.set_TextSize(new Size(165, 15));
			this.layoutControlItem19.set_TextToControlDistance(5);
			this.layoutControlItem16.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem16.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem16.set_Control(this.textBox4);
			this.layoutControlItem16.set_CustomizationFormText("Firma Tel :");
			this.layoutControlItem16.set_Location(new Point(0, 43));
			this.layoutControlItem16.set_Name("layoutControlItem16");
			this.layoutControlItem16.set_Size(new Size(653, 26));
			this.layoutControlItem16.set_Text("Firma Tel :");
			this.layoutControlItem16.set_TextAlignMode(2);
			this.layoutControlItem16.set_TextSize(new Size(165, 15));
			this.layoutControlItem16.set_TextToControlDistance(5);
			this.layoutControlItem20.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem20.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem20.set_Control(this.textBox6);
			this.layoutControlItem20.set_CustomizationFormText("Firma Mail :");
			this.layoutControlItem20.set_Location(new Point(0, 69));
			this.layoutControlItem20.set_Name("layoutControlItem20");
			this.layoutControlItem20.set_Size(new Size(653, 26));
			this.layoutControlItem20.set_Text("Firma Mail :");
			this.layoutControlItem20.set_TextAlignMode(2);
			this.layoutControlItem20.set_TextSize(new Size(165, 15));
			this.layoutControlItem20.set_TextToControlDistance(5);
			this.layoutControlItem17.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem17.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem17.set_Control(this.textBox5);
			this.layoutControlItem17.set_CustomizationFormText("Firma Fax :");
			this.layoutControlItem17.set_Location(new Point(0, 121));
			this.layoutControlItem17.set_Name("layoutControlItem17");
			this.layoutControlItem17.set_Size(new Size(653, 26));
			this.layoutControlItem17.set_Text("Firma Fax :");
			this.layoutControlItem17.set_TextAlignMode(2);
			this.layoutControlItem17.set_TextSize(new Size(165, 0));
			this.layoutControlItem17.set_TextToControlDistance(5);
			this.layoutControlItem1.set_Control(this.label1);
			this.layoutControlItem1.set_ControlAlignment(ContentAlignment.TopCenter);
			this.layoutControlItem1.set_CustomizationFormText("layoutControlItem1");
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(653, 17));
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem2.set_Control(this.labelControl2);
			this.layoutControlItem2.set_CustomizationFormText("layoutControlItem2");
			this.layoutControlItem2.set_Location(new Point(0, 294));
			this.layoutControlItem2.set_MaxSize(new Size(0, 17));
			this.layoutControlItem2.set_MinSize(new Size(67, 17));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(653, 17));
			this.layoutControlItem2.set_SizeConstraintsType(2);
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			this.layoutControlItem3.set_Control(this.labelControl3);
			this.layoutControlItem3.set_CustomizationFormText("layoutControlItem3");
			this.layoutControlItem3.set_Location(new Point(0, 311));
			this.layoutControlItem3.set_MaxSize(new Size(120, 26));
			this.layoutControlItem3.set_MinSize(new Size(38, 17));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(120, 19));
			this.layoutControlItem3.set_SizeConstraintsType(2);
			this.layoutControlItem3.set_TextSize(new Size(0, 0));
			this.layoutControlItem3.set_TextVisible(false);
			this.layoutControlItem4.set_Control(this.labelControl4);
			this.layoutControlItem4.set_CustomizationFormText("layoutControlItem4");
			this.layoutControlItem4.set_Location(new Point(120, 311));
			this.layoutControlItem4.set_MaxSize(new Size(190, 26));
			this.layoutControlItem4.set_MinSize(new Size(63, 17));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(145, 19));
			this.layoutControlItem4.set_SizeConstraintsType(2);
			this.layoutControlItem4.set_TextSize(new Size(0, 0));
			this.layoutControlItem4.set_TextVisible(false);
			this.layoutControlItem7.set_Control(this.labelControl5);
			this.layoutControlItem7.set_CustomizationFormText("layoutControlItem7");
			this.layoutControlItem7.set_Location(new Point(265, 311));
			this.layoutControlItem7.set_MaxSize(new Size(150, 26));
			this.layoutControlItem7.set_MinSize(new Size(73, 17));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(129, 19));
			this.layoutControlItem7.set_SizeConstraintsType(2);
			this.layoutControlItem7.set_TextSize(new Size(0, 0));
			this.layoutControlItem7.set_TextVisible(false);
			this.layoutControlItem8.set_Control(this.labelControl6);
			this.layoutControlItem8.set_CustomizationFormText("layoutControlItem8");
			this.layoutControlItem8.set_Location(new Point(394, 311));
			this.layoutControlItem8.set_MaxSize(new Size(150, 26));
			this.layoutControlItem8.set_MinSize(new Size(63, 17));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(130, 19));
			this.layoutControlItem8.set_SizeConstraintsType(2);
			this.layoutControlItem8.set_TextSize(new Size(0, 0));
			this.layoutControlItem8.set_TextVisible(false);
			this.layoutControlItem9.set_Control(this.labelControl7);
			this.layoutControlItem9.set_CustomizationFormText("layoutControlItem9");
			this.layoutControlItem9.set_Location(new Point(524, 311));
			this.layoutControlItem9.set_MaxSize(new Size(150, 26));
			this.layoutControlItem9.set_MinSize(new Size(77, 17));
			this.layoutControlItem9.set_Name("layoutControlItem9");
			this.layoutControlItem9.set_Size(new Size(129, 19));
			this.layoutControlItem9.set_SizeConstraintsType(2);
			this.layoutControlItem9.set_TextSize(new Size(0, 0));
			this.layoutControlItem9.set_TextVisible(false);
			this.layoutControlItem10.set_Control(this.labelControl8);
			this.layoutControlItem10.set_CustomizationFormText("layoutControlItem10");
			this.layoutControlItem10.set_Location(new Point(0, 330));
			this.layoutControlItem10.set_MaxSize(new Size(120, 26));
			this.layoutControlItem10.set_MinSize(new Size(120, 17));
			this.layoutControlItem10.set_Name("layoutControlItem10");
			this.layoutControlItem10.set_Size(new Size(120, 26));
			this.layoutControlItem10.set_SizeConstraintsType(2);
			this.layoutControlItem10.set_TextSize(new Size(0, 0));
			this.layoutControlItem10.set_TextVisible(false);
			this.layoutControlItem11.set_Control(this.labelControl9);
			this.layoutControlItem11.set_CustomizationFormText("layoutControlItem11");
			this.layoutControlItem11.set_Location(new Point(0, 356));
			this.layoutControlItem11.set_MaxSize(new Size(120, 26));
			this.layoutControlItem11.set_MinSize(new Size(67, 17));
			this.layoutControlItem11.set_Name("layoutControlItem11");
			this.layoutControlItem11.set_Size(new Size(120, 26));
			this.layoutControlItem11.set_SizeConstraintsType(2);
			this.layoutControlItem11.set_TextSize(new Size(0, 0));
			this.layoutControlItem11.set_TextVisible(false);
			this.layoutControlItem12.set_Control(this.mmad);
			this.layoutControlItem12.set_CustomizationFormText("layoutControlItem12");
			this.layoutControlItem12.set_Location(new Point(120, 330));
			this.layoutControlItem12.set_MaxSize(new Size(190, 26));
			this.layoutControlItem12.set_MinSize(new Size(120, 24));
			this.layoutControlItem12.set_Name("layoutControlItem12");
			this.layoutControlItem12.set_Size(new Size(145, 26));
			this.layoutControlItem12.set_SizeConstraintsType(2);
			this.layoutControlItem12.set_TextSize(new Size(0, 0));
			this.layoutControlItem12.set_TextVisible(false);
			this.layoutControlItem13.set_Control(this.mmoda);
			this.layoutControlItem13.set_CustomizationFormText("layoutControlItem13");
			this.layoutControlItem13.set_Location(new Point(265, 330));
			this.layoutControlItem13.set_MaxSize(new Size(150, 26));
			this.layoutControlItem13.set_MinSize(new Size(120, 24));
			this.layoutControlItem13.set_Name("layoutControlItem13");
			this.layoutControlItem13.set_Size(new Size(129, 26));
			this.layoutControlItem13.set_SizeConstraintsType(2);
			this.layoutControlItem13.set_TextSize(new Size(0, 0));
			this.layoutControlItem13.set_TextVisible(false);
			this.layoutControlItem14.set_Control(this.mmbel);
			this.layoutControlItem14.set_CustomizationFormText("layoutControlItem14");
			this.layoutControlItem14.set_Location(new Point(394, 330));
			this.layoutControlItem14.set_MaxSize(new Size(150, 26));
			this.layoutControlItem14.set_MinSize(new Size(54, 26));
			this.layoutControlItem14.set_Name("layoutControlItem14");
			this.layoutControlItem14.set_Size(new Size(130, 26));
			this.layoutControlItem14.set_SizeConstraintsType(2);
			this.layoutControlItem14.set_TextSize(new Size(0, 0));
			this.layoutControlItem14.set_TextVisible(false);
			this.layoutControlItem28.set_Control(this.mmsmm);
			this.layoutControlItem28.set_CustomizationFormText("layoutControlItem28");
			this.layoutControlItem28.set_Location(new Point(524, 330));
			this.layoutControlItem28.set_MaxSize(new Size(150, 26));
			this.layoutControlItem28.set_MinSize(new Size(54, 24));
			this.layoutControlItem28.set_Name("layoutControlItem28");
			this.layoutControlItem28.set_Size(new Size(129, 26));
			this.layoutControlItem28.set_SizeConstraintsType(2);
			this.layoutControlItem28.set_TextSize(new Size(0, 0));
			this.layoutControlItem28.set_TextVisible(false);
			this.layoutControlItem29.set_Control(this.emad);
			this.layoutControlItem29.set_CustomizationFormText("layoutControlItem29");
			this.layoutControlItem29.set_Location(new Point(120, 356));
			this.layoutControlItem29.set_MaxSize(new Size(190, 26));
			this.layoutControlItem29.set_MinSize(new Size(54, 24));
			this.layoutControlItem29.set_Name("layoutControlItem29");
			this.layoutControlItem29.set_Size(new Size(145, 26));
			this.layoutControlItem29.set_SizeConstraintsType(2);
			this.layoutControlItem29.set_TextSize(new Size(0, 0));
			this.layoutControlItem29.set_TextVisible(false);
			this.layoutControlItem30.set_Control(this.emoda);
			this.layoutControlItem30.set_CustomizationFormText("layoutControlItem30");
			this.layoutControlItem30.set_Location(new Point(265, 356));
			this.layoutControlItem30.set_MaxSize(new Size(150, 26));
			this.layoutControlItem30.set_MinSize(new Size(120, 24));
			this.layoutControlItem30.set_Name("layoutControlItem30");
			this.layoutControlItem30.set_Size(new Size(129, 26));
			this.layoutControlItem30.set_SizeConstraintsType(2);
			this.layoutControlItem30.set_TextSize(new Size(0, 0));
			this.layoutControlItem30.set_TextVisible(false);
			this.layoutControlItem31.set_Control(this.embel);
			this.layoutControlItem31.set_CustomizationFormText("layoutControlItem31");
			this.layoutControlItem31.set_Location(new Point(394, 356));
			this.layoutControlItem31.set_MaxSize(new Size(150, 26));
			this.layoutControlItem31.set_MinSize(new Size(54, 24));
			this.layoutControlItem31.set_Name("layoutControlItem31");
			this.layoutControlItem31.set_Size(new Size(130, 26));
			this.layoutControlItem31.set_SizeConstraintsType(2);
			this.layoutControlItem31.set_TextSize(new Size(0, 0));
			this.layoutControlItem31.set_TextVisible(false);
			this.layoutControlItem32.set_Control(this.emsmm);
			this.layoutControlItem32.set_CustomizationFormText("layoutControlItem32");
			this.layoutControlItem32.set_Location(new Point(524, 356));
			this.layoutControlItem32.set_MaxSize(new Size(150, 26));
			this.layoutControlItem32.set_MinSize(new Size(120, 24));
			this.layoutControlItem32.set_Name("layoutControlItem32");
			this.layoutControlItem32.set_Size(new Size(129, 26));
			this.layoutControlItem32.set_SizeConstraintsType(2);
			this.layoutControlItem32.set_TextSize(new Size(0, 0));
			this.layoutControlItem32.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(663, 434);
			base.Controls.Add(this.layoutControl2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FirmaBilgileri";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "FİRMA GİRİŞİ";
			base.Load += new EventHandler(this.FirmaBilgileri_Load);
			this.layoutControl2.EndInit();
			this.layoutControl2.ResumeLayout(false);
			this.emsmm.get_Properties().EndInit();
			this.embel.get_Properties().EndInit();
			this.emoda.get_Properties().EndInit();
			this.emad.get_Properties().EndInit();
			this.mmsmm.get_Properties().EndInit();
			this.mmbel.get_Properties().EndInit();
			this.mmoda.get_Properties().EndInit();
			this.mmad.get_Properties().EndInit();
			this.textEdit11.get_Properties().EndInit();
			this.dateEdit2.get_Properties().get_CalendarTimeProperties().EndInit();
			this.dateEdit2.get_Properties().EndInit();
			this.textEdit10.get_Properties().EndInit();
			this.dateEdit1.get_Properties().get_CalendarTimeProperties().EndInit();
			this.dateEdit1.get_Properties().EndInit();
			this.textEdit9.get_Properties().EndInit();
			this.textEdit8.get_Properties().EndInit();
			this.textBox2.get_Properties().EndInit();
			this.textBox6.get_Properties().EndInit();
			this.textEdit5.get_Properties().EndInit();
			this.textBox3.get_Properties().EndInit();
			this.textBox5.get_Properties().EndInit();
			this.textBox4.get_Properties().EndInit();
			this.textBox1.get_Properties().EndInit();
			this.layoutControlGroup2.EndInit();
			this.layoutControlItem15.EndInit();
			this.layoutControlItem25.EndInit();
			this.layoutControlItem26.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem22.EndInit();
			this.layoutControlItem23.EndInit();
			this.layoutControlItem18.EndInit();
			this.layoutControlItem24.EndInit();
			this.layoutControlItem27.EndInit();
			this.layoutControlItem21.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem19.EndInit();
			this.layoutControlItem16.EndInit();
			this.layoutControlItem20.EndInit();
			this.layoutControlItem17.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem9.EndInit();
			this.layoutControlItem10.EndInit();
			this.layoutControlItem11.EndInit();
			this.layoutControlItem12.EndInit();
			this.layoutControlItem13.EndInit();
			this.layoutControlItem14.EndInit();
			this.layoutControlItem28.EndInit();
			this.layoutControlItem29.EndInit();
			this.layoutControlItem30.EndInit();
			this.layoutControlItem31.EndInit();
			this.layoutControlItem32.EndInit();
			base.ResumeLayout(false);
		}
	}
}
