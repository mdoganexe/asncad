using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class ureticiekle : Form
	{
		public motor mtr;

		private abc1 xx = new abc1();

		private IContainer components = null;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private TextEdit urtadi;

		private LayoutControlItem layoutControlItem1;

		private TextEdit marka;

		private LayoutControlItem layoutControlItem2;

		private SimpleButton simpleButton1;

		private TextEdit email;

		private TextEdit web;

		private TextEdit fax;

		private TextEdit tel;

		private TextEdit vergino;

		private TextEdit vergida;

		private ComboBoxEdit ulke;

		private TextEdit adres;

		private LayoutControlItem layoutControlItem4;

		private LayoutControlItem layoutControlItem5;

		private LayoutControlItem layoutControlItem6;

		private LayoutControlItem layoutControlItem7;

		private LayoutControlItem layoutControlItem8;

		private LayoutControlItem layoutControlItem9;

		private LayoutControlItem layoutControlItem10;

		private LayoutControlItem layoutControlItem11;

		private LayoutControlItem layoutControlItem3;

		public ureticiekle()
		{
			this.InitializeComponent();
		}

		private void ureticiekle_Load(object sender, EventArgs e)
		{
			try
			{
				DataTable dataTable = this.xx.dtta("select ulke from iller", "");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.ulke.get_Properties().get_Items().Add(dataTable.Rows[i][0].ToString());
				}
			}
			catch (Exception)
			{
			}
			DataTable dataTable2 = this.xx.dtta("select dil from firmabilgi", "");
			string ney = dataTable2.Rows[0][0].ToString();
			this.dil(ney);
		}

		public void dil(string ney)
		{
			try
			{
				ArrayList arrayList = new ArrayList();
				OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Dil.mdb");
				OleDbCommand oleDbCommand = new OleDbCommand("select " + ney + " from diller", oleDbConnection);
				bool flag = oleDbCommand.Connection.State == ConnectionState.Closed;
				if (flag)
				{
					oleDbCommand.Connection.Open();
				}
				OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
				bool hasRows = oleDbDataReader.HasRows;
				if (hasRows)
				{
					while (oleDbDataReader.Read())
					{
						arrayList.Add(oleDbDataReader[0].ToString());
					}
				}
				oleDbConnection.Close();
				oleDbCommand.Connection.Close();
				this.layoutControlItem1.set_Text(arrayList[366].ToString());
				this.layoutControlItem3.set_Text(arrayList[367].ToString());
				this.layoutControlItem2.set_Text(arrayList[368].ToString());
				this.layoutControlItem4.set_Text(arrayList[369].ToString());
				this.layoutControlItem5.set_Text(arrayList[370].ToString());
				this.layoutControlItem6.set_Text(arrayList[371].ToString());
				this.layoutControlItem7.set_Text(arrayList[372].ToString());
				this.layoutControlItem8.set_Text(arrayList[373].ToString());
				this.layoutControlItem9.set_Text(arrayList[374].ToString());
				this.layoutControlItem10.set_Text(arrayList[375].ToString());
				this.simpleButton1.Text = arrayList[376].ToString();
			}
			catch (Exception)
			{
				MessageBox.Show("Hata Alındı...");
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.urtadi.Text == "";
				if (flag)
				{
					MessageBox.Show("Tam Üretici Adını Giriniz");
				}
				else
				{
					bool flag2 = this.marka.Text == "";
					if (flag2)
					{
						MessageBox.Show("Üretici Markasını Boş Geçmeyiniz");
					}
					else
					{
						this.xx.oleupdate(string.Concat(new string[]
						{
							"insert into uretici (urtadi,marka,adres,ulke,vergida,vergino,tel,fax,email,degisti) values ('",
							this.urtadi.Text,
							"','",
							this.marka.Text,
							"','",
							this.adres.Text,
							"','",
							this.ulke.Text,
							"','",
							this.vergida.Text,
							"','",
							this.vergino.Text,
							"','",
							this.tel.Text,
							"','",
							this.fax.Text,
							"','",
							this.email.Text,
							"',true)"
						}), "");
						this.mtr.yukle();
						MessageBox.Show("Veriler Başarıyla Eklenmiştir");
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Üretici Bilgisi Eklenemedi");
			}
		}

		private void vergino_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void marka_EditValueChanged(object sender, EventArgs e)
		{
			this.marka.Text = this.marka.Text.ToUpper();
		}

		private void urtadi_TextChanged(object sender, EventArgs e)
		{
			this.urtadi.Text = this.urtadi.Text.ToUpper();
		}

		private void adres_TextChanged(object sender, EventArgs e)
		{
			this.adres.Text = this.adres.Text.ToUpper();
		}

		private void marka_TextChanged(object sender, EventArgs e)
		{
			this.marka.Text = this.marka.Text.ToUpper();
		}

		private void vergida_TextChanged(object sender, EventArgs e)
		{
			this.vergida.Text = this.vergida.Text.ToUpper();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ureticiekle));
			this.layoutControl1 = new LayoutControl();
			this.simpleButton1 = new SimpleButton();
			this.email = new TextEdit();
			this.web = new TextEdit();
			this.fax = new TextEdit();
			this.tel = new TextEdit();
			this.vergino = new TextEdit();
			this.vergida = new TextEdit();
			this.ulke = new ComboBoxEdit();
			this.adres = new TextEdit();
			this.marka = new TextEdit();
			this.urtadi = new TextEdit();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem9 = new LayoutControlItem();
			this.layoutControlItem10 = new LayoutControlItem();
			this.layoutControlItem11 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.email.get_Properties().BeginInit();
			this.web.get_Properties().BeginInit();
			this.fax.get_Properties().BeginInit();
			this.tel.get_Properties().BeginInit();
			this.vergino.get_Properties().BeginInit();
			this.vergida.get_Properties().BeginInit();
			this.ulke.get_Properties().BeginInit();
			this.adres.get_Properties().BeginInit();
			this.marka.get_Properties().BeginInit();
			this.urtadi.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem9.BeginInit();
			this.layoutControlItem10.BeginInit();
			this.layoutControlItem11.BeginInit();
			this.layoutControlItem3.BeginInit();
			base.SuspendLayout();
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.email);
			this.layoutControl1.Controls.Add(this.web);
			this.layoutControl1.Controls.Add(this.fax);
			this.layoutControl1.Controls.Add(this.tel);
			this.layoutControl1.Controls.Add(this.vergino);
			this.layoutControl1.Controls.Add(this.vergida);
			this.layoutControl1.Controls.Add(this.ulke);
			this.layoutControl1.Controls.Add(this.adres);
			this.layoutControl1.Controls.Add(this.marka);
			this.layoutControl1.Controls.Add(this.urtadi);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(406, 298);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			this.simpleButton1.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Location = new Point(7, 267);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(392, 24);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 14;
			this.simpleButton1.Text = "KAYDET";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.email.set_EnterMoveNextControl(true);
			this.email.Location = new Point(95, 241);
			this.email.Name = "email";
			this.email.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.email.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.email.Size = new Size(304, 22);
			this.email.set_StyleController(this.layoutControl1);
			this.email.TabIndex = 13;
			this.web.set_EnterMoveNextControl(true);
			this.web.Location = new Point(95, 215);
			this.web.Name = "web";
			this.web.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.web.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.web.Size = new Size(304, 22);
			this.web.set_StyleController(this.layoutControl1);
			this.web.TabIndex = 12;
			this.fax.set_EnterMoveNextControl(true);
			this.fax.Location = new Point(95, 189);
			this.fax.Name = "fax";
			this.fax.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.fax.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.fax.Size = new Size(158, 22);
			this.fax.set_StyleController(this.layoutControl1);
			this.fax.TabIndex = 11;
			this.tel.set_EnterMoveNextControl(true);
			this.tel.Location = new Point(95, 163);
			this.tel.Name = "tel";
			this.tel.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.tel.Size = new Size(158, 22);
			this.tel.set_StyleController(this.layoutControl1);
			this.tel.TabIndex = 10;
			this.vergino.set_EnterMoveNextControl(true);
			this.vergino.Location = new Point(95, 137);
			this.vergino.Name = "vergino";
			this.vergino.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vergino.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.vergino.Size = new Size(158, 22);
			this.vergino.set_StyleController(this.layoutControl1);
			this.vergino.TabIndex = 9;
			this.vergino.KeyPress += new KeyPressEventHandler(this.vergino_KeyPress);
			this.vergida.set_EnterMoveNextControl(true);
			this.vergida.Location = new Point(95, 111);
			this.vergida.Name = "vergida";
			this.vergida.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vergida.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.vergida.Size = new Size(158, 22);
			this.vergida.set_StyleController(this.layoutControl1);
			this.vergida.TabIndex = 8;
			this.vergida.TextChanged += new EventHandler(this.vergida_TextChanged);
			this.ulke.set_EnterMoveNextControl(true);
			this.ulke.Location = new Point(95, 85);
			this.ulke.Name = "ulke";
			this.ulke.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ulke.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.ulke.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.ulke.Size = new Size(158, 22);
			this.ulke.set_StyleController(this.layoutControl1);
			this.ulke.TabIndex = 7;
			this.adres.set_EnterMoveNextControl(true);
			this.adres.Location = new Point(95, 33);
			this.adres.Name = "adres";
			this.adres.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.adres.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.adres.Size = new Size(304, 22);
			this.adres.set_StyleController(this.layoutControl1);
			this.adres.TabIndex = 6;
			this.adres.TextChanged += new EventHandler(this.adres_TextChanged);
			this.marka.set_EnterMoveNextControl(true);
			this.marka.Location = new Point(95, 59);
			this.marka.Name = "marka";
			this.marka.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.marka.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.marka.Size = new Size(158, 22);
			this.marka.set_StyleController(this.layoutControl1);
			this.marka.TabIndex = 5;
			this.marka.add_EditValueChanged(new EventHandler(this.marka_EditValueChanged));
			this.marka.TextChanged += new EventHandler(this.marka_TextChanged);
			this.urtadi.set_EnterMoveNextControl(true);
			this.urtadi.Location = new Point(95, 7);
			this.urtadi.Name = "urtadi";
			this.urtadi.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.urtadi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.urtadi.Size = new Size(304, 22);
			this.urtadi.set_StyleController(this.layoutControl1);
			this.urtadi.TabIndex = 4;
			this.urtadi.TextChanged += new EventHandler(this.urtadi_TextChanged);
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem4,
				this.layoutControlItem5,
				this.layoutControlItem6,
				this.layoutControlItem7,
				this.layoutControlItem8,
				this.layoutControlItem9,
				this.layoutControlItem10,
				this.layoutControlItem11,
				this.layoutControlItem3
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(406, 298));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem1.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem1.set_Control(this.urtadi);
			this.layoutControlItem1.set_CustomizationFormText("ÜRETİCİ :");
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_MaxSize(new Size(0, 26));
			this.layoutControlItem1.set_MinSize(new Size(139, 26));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(396, 26));
			this.layoutControlItem1.set_SizeConstraintsType(2);
			this.layoutControlItem1.set_Text("ÜRETİCİ :");
			this.layoutControlItem1.set_TextSize(new Size(85, 13));
			this.layoutControlItem2.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem2.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem2.set_Control(this.marka);
			this.layoutControlItem2.set_CustomizationFormText("MARKA :");
			this.layoutControlItem2.set_Location(new Point(0, 52));
			this.layoutControlItem2.set_MaxSize(new Size(250, 26));
			this.layoutControlItem2.set_MinSize(new Size(139, 26));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(396, 26));
			this.layoutControlItem2.set_SizeConstraintsType(2);
			this.layoutControlItem2.set_Text("MARKA :");
			this.layoutControlItem2.set_TextSize(new Size(85, 13));
			this.layoutControlItem4.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem4.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem4.set_Control(this.ulke);
			this.layoutControlItem4.set_CustomizationFormText("ÜLKE :");
			this.layoutControlItem4.set_Location(new Point(0, 78));
			this.layoutControlItem4.set_MaxSize(new Size(250, 26));
			this.layoutControlItem4.set_MinSize(new Size(139, 26));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(396, 26));
			this.layoutControlItem4.set_SizeConstraintsType(2);
			this.layoutControlItem4.set_Text("ÜLKE :");
			this.layoutControlItem4.set_TextSize(new Size(85, 13));
			this.layoutControlItem5.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem5.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem5.set_Control(this.vergida);
			this.layoutControlItem5.set_CustomizationFormText("VERGİ DAİRESİ :");
			this.layoutControlItem5.set_Location(new Point(0, 104));
			this.layoutControlItem5.set_MaxSize(new Size(250, 26));
			this.layoutControlItem5.set_MinSize(new Size(139, 26));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(396, 26));
			this.layoutControlItem5.set_SizeConstraintsType(2);
			this.layoutControlItem5.set_Text("VERGİ DAİRESİ :");
			this.layoutControlItem5.set_TextSize(new Size(85, 13));
			this.layoutControlItem6.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem6.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem6.set_Control(this.vergino);
			this.layoutControlItem6.set_CustomizationFormText("VERGİ NO :");
			this.layoutControlItem6.set_Location(new Point(0, 130));
			this.layoutControlItem6.set_MaxSize(new Size(250, 26));
			this.layoutControlItem6.set_MinSize(new Size(139, 26));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(396, 26));
			this.layoutControlItem6.set_SizeConstraintsType(2);
			this.layoutControlItem6.set_Text("VERGİ NO :");
			this.layoutControlItem6.set_TextSize(new Size(85, 13));
			this.layoutControlItem7.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem7.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem7.set_Control(this.tel);
			this.layoutControlItem7.set_CustomizationFormText("TEL :");
			this.layoutControlItem7.set_Location(new Point(0, 156));
			this.layoutControlItem7.set_MaxSize(new Size(250, 26));
			this.layoutControlItem7.set_MinSize(new Size(139, 26));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(396, 26));
			this.layoutControlItem7.set_SizeConstraintsType(2);
			this.layoutControlItem7.set_Text("TEL :");
			this.layoutControlItem7.set_TextSize(new Size(85, 13));
			this.layoutControlItem8.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem8.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem8.set_Control(this.fax);
			this.layoutControlItem8.set_CustomizationFormText("FAX :");
			this.layoutControlItem8.set_Location(new Point(0, 182));
			this.layoutControlItem8.set_MaxSize(new Size(250, 26));
			this.layoutControlItem8.set_MinSize(new Size(139, 26));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(396, 26));
			this.layoutControlItem8.set_SizeConstraintsType(2);
			this.layoutControlItem8.set_Text("FAX :");
			this.layoutControlItem8.set_TextSize(new Size(85, 13));
			this.layoutControlItem9.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem9.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem9.set_Control(this.web);
			this.layoutControlItem9.set_CustomizationFormText("WEB :");
			this.layoutControlItem9.set_Location(new Point(0, 208));
			this.layoutControlItem9.set_MaxSize(new Size(0, 26));
			this.layoutControlItem9.set_MinSize(new Size(139, 26));
			this.layoutControlItem9.set_Name("layoutControlItem9");
			this.layoutControlItem9.set_Size(new Size(396, 26));
			this.layoutControlItem9.set_SizeConstraintsType(2);
			this.layoutControlItem9.set_Text("WEB :");
			this.layoutControlItem9.set_TextSize(new Size(85, 13));
			this.layoutControlItem10.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem10.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem10.set_Control(this.email);
			this.layoutControlItem10.set_CustomizationFormText("E MAİL :");
			this.layoutControlItem10.set_Location(new Point(0, 234));
			this.layoutControlItem10.set_MaxSize(new Size(0, 26));
			this.layoutControlItem10.set_MinSize(new Size(139, 26));
			this.layoutControlItem10.set_Name("layoutControlItem10");
			this.layoutControlItem10.set_Size(new Size(396, 26));
			this.layoutControlItem10.set_SizeConstraintsType(2);
			this.layoutControlItem10.set_Text("E MAİL :");
			this.layoutControlItem10.set_TextSize(new Size(85, 13));
			this.layoutControlItem11.set_Control(this.simpleButton1);
			this.layoutControlItem11.set_CustomizationFormText("layoutControlItem11");
			this.layoutControlItem11.set_Location(new Point(0, 260));
			this.layoutControlItem11.set_MaxSize(new Size(0, 28));
			this.layoutControlItem11.set_MinSize(new Size(82, 26));
			this.layoutControlItem11.set_Name("layoutControlItem11");
			this.layoutControlItem11.set_Size(new Size(396, 28));
			this.layoutControlItem11.set_SizeConstraintsType(2);
			this.layoutControlItem11.set_TextSize(new Size(0, 0));
			this.layoutControlItem11.set_TextVisible(false);
			this.layoutControlItem3.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem3.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem3.set_Control(this.adres);
			this.layoutControlItem3.set_CustomizationFormText("ADRES :");
			this.layoutControlItem3.set_Location(new Point(0, 26));
			this.layoutControlItem3.set_MaxSize(new Size(0, 26));
			this.layoutControlItem3.set_MinSize(new Size(139, 26));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(396, 26));
			this.layoutControlItem3.set_SizeConstraintsType(2);
			this.layoutControlItem3.set_Text("ADRES :");
			this.layoutControlItem3.set_TextSize(new Size(85, 13));
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(406, 298);
			base.Controls.Add(this.layoutControl1);
			base.Name = "ureticiekle";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ÜRETİCİ EKLEME";
			base.Load += new EventHandler(this.ureticiekle_Load);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.email.get_Properties().EndInit();
			this.web.get_Properties().EndInit();
			this.fax.get_Properties().EndInit();
			this.tel.get_Properties().EndInit();
			this.vergino.get_Properties().EndInit();
			this.vergida.get_Properties().EndInit();
			this.ulke.get_Properties().EndInit();
			this.adres.get_Properties().EndInit();
			this.marka.get_Properties().EndInit();
			this.urtadi.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem9.EndInit();
			this.layoutControlItem10.EndInit();
			this.layoutControlItem11.EndInit();
			this.layoutControlItem3.EndInit();
			base.ResumeLayout(false);
		}
	}
}
