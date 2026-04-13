using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ascad
{
	public class motor : Form
	{
		public makmot mkmt;

		private abc1 xx = new abc1();

		private string edit = "";

		private int dis = 0;

		private string dosyayolu = "";

		private string editcik = "";

		private string extension = "";

		private bool nonNumberEntered = false;

		private IContainer components = null;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private SimpleButton simpleButton1;

		private TextEdit textEdit7;

		private TextEdit textEdit6;

		private TextEdit textEdit5;

		private TextEdit textEdit4;

		private TextEdit textEdit2;

		private LabelControl labelControl1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem3;

		private LayoutControlItem layoutControlItem5;

		private LayoutControlItem layoutControlItem6;

		private LayoutControlItem layoutControlItem7;

		private LayoutControlItem layoutControlItem8;

		private LayoutControlItem layoutControlItem9;

		private LabelControl labelControl3;

		private TextEdit textEdit8;

		private LabelControl labelControl2;

		private TextEdit textEdit3;

		private LayoutControlItem layoutControlItem11;

		private LayoutControlItem layoutControlItem12;

		private LayoutControlItem layoutControlItem13;

		private LayoutControlItem layoutControlItem14;

		private LabelControl labelControl4;

		private TextEdit textEdit10;

		private TextEdit textEdit9;

		private LayoutControlItem layoutControlItem15;

		private LayoutControlItem layoutControlItem16;

		private LayoutControlItem layoutControlItem18;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private LayoutControlItem layoutControlItem17;

		private LayoutControlItem layoutControlItem19;

		private LayoutControlItem layoutControlItem21;

		private SimpleButton simpleButton4;

		private LayoutControlItem layoutControlItem23;

		private OpenFileDialog openFileDialog1;

		private TextEdit textEdit11;

		private LayoutControlItem layoutControlItem24;

		private ComboBoxEdit comboBox2;

		private LayoutControlItem layoutControlItem4;

		private SimpleButton simpleButton2;

		private LayoutControlItem layoutControlItem2;

		public motor()
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

		private void motor_Load(object sender, EventArgs e)
		{
			this.yukle();
		}

		public void yukle()
		{
			try
			{
				this.comboBox2.get_Properties().get_Items().Clear();
				this.radioButton1.Checked = true;
				DataTable dataTable = this.xx.dtta("select distinct(marka) from uretici", "");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.comboBox2.get_Properties().get_Items().Add(dataTable.Rows[i][0].ToString());
				}
			}
			catch (Exception)
			{
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.comboBox2.get_SelectedIndex() == -1 || this.comboBox2.Text == "";
			if (flag)
			{
				MessageBox.Show("MARKAYI BOŞ GEÇEMEZSİNİZ");
			}
			else
			{
				bool flag2 = this.textEdit2.Text == "";
				if (flag2)
				{
					MessageBox.Show("MODELİ BOŞ GEÇEMEZSİNİZ");
				}
				else
				{
					string path = ".\\motor\\" + this.comboBox2.Text;
					bool flag3 = Directory.Exists(path);
					string text;
					if (flag3)
					{
						text = string.Concat(new string[]
						{
							".\\motor\\",
							this.comboBox2.Text,
							"\\",
							this.textEdit2.Text,
							this.extension
						});
					}
					else
					{
						Directory.CreateDirectory(".\\motor\\" + this.comboBox2.Text);
						text = string.Concat(new string[]
						{
							".\\motor\\",
							this.comboBox2.Text,
							"\\",
							this.textEdit2.Text,
							this.extension
						});
					}
					string text2 = text.Replace(".\\", "\\");
					this.xx.oleupdate(string.Concat(new object[]
					{
						"insert into motormakine1 (marka,model,hiz,motorkw,kasnakkanal,halatcap,kapasite,kasnakcap,aski,maksyuk,diskontrol,edit,verim,degisti) values ('",
						this.comboBox2.Text,
						"','",
						this.textEdit2.Text,
						"','",
						this.textEdit4.Text,
						"','",
						this.textEdit5.Text,
						"','",
						this.textEdit6.Text,
						"','",
						this.textEdit7.Text,
						"','",
						this.textEdit3.Text,
						"','",
						this.textEdit8.Text,
						"','",
						this.textEdit9.Text,
						"','",
						this.textEdit10.Text,
						"','",
						this.dis,
						"','",
						text2,
						"','",
						this.textEdit11.Text,
						"',true)"
					}), "");
					bool flag4 = this.dosyayolu != "";
					if (flag4)
					{
						File.Copy(this.dosyayolu, text);
					}
					MessageBox.Show("Motor Bilgileri Eklenmiştir");
					this.dosyayolu = "";
					this.mkmt.yeni();
				}
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool @checked = this.radioButton2.Checked;
				if (@checked)
				{
					this.dis = 0;
				}
			}
			catch (Exception)
			{
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool @checked = this.radioButton1.Checked;
				if (@checked)
				{
					this.dis = 1;
				}
			}
			catch (Exception)
			{
			}
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.edit == "";
				if (flag)
				{
					MessageBox.Show("Teknik Resim Bulunamadı");
				}
				else
				{
					try
					{
						string directoryName = Path.GetDirectoryName(Application.ExecutablePath);
						Process.Start(directoryName + this.edit);
					}
					catch
					{
						MessageBox.Show("Teknik Resim Bulunamadı");
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void simpleButton4_Click(object sender, EventArgs e)
		{
			try
			{
				this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
				this.openFileDialog1.FileName = "Teknik Resim Seçiniz...";
				bool flag = this.openFileDialog1.ShowDialog() == DialogResult.OK;
				if (flag)
				{
					this.dosyayolu = this.openFileDialog1.FileName;
					this.extension = Path.GetExtension(this.openFileDialog1.FileName);
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				this.openFileDialog1.FileName = "Teknik Resim Seçiniz...";
			}
		}

		private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = this.nonNumberEntered;
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			new ureticiekle
			{
				mtr = this
			}.ShowDialog();
		}

		private void textEdit3_KeyDown(object sender, KeyEventArgs e)
		{
			this.nonNumberEntered = false;
			bool flag = e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Oemcomma;
			if (flag)
			{
				this.nonNumberEntered = false;
			}
			else
			{
				bool flag2 = e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9;
				if (flag2)
				{
					bool flag3 = e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9;
					if (flag3)
					{
						bool flag4 = e.KeyCode != Keys.Back;
						if (flag4)
						{
							this.nonNumberEntered = true;
						}
					}
				}
			}
		}

		private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void textEdit2_EditValueChanged(object sender, EventArgs e)
		{
			this.textEdit2.Text = this.textEdit2.Text.ToUpper();
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
			this.layoutControl1 = new LayoutControl();
			this.simpleButton2 = new SimpleButton();
			this.comboBox2 = new ComboBoxEdit();
			this.textEdit11 = new TextEdit();
			this.simpleButton4 = new SimpleButton();
			this.radioButton2 = new RadioButton();
			this.radioButton1 = new RadioButton();
			this.labelControl4 = new LabelControl();
			this.textEdit10 = new TextEdit();
			this.textEdit9 = new TextEdit();
			this.labelControl3 = new LabelControl();
			this.textEdit8 = new TextEdit();
			this.labelControl2 = new LabelControl();
			this.textEdit3 = new TextEdit();
			this.simpleButton1 = new SimpleButton();
			this.textEdit7 = new TextEdit();
			this.textEdit6 = new TextEdit();
			this.textEdit5 = new TextEdit();
			this.textEdit4 = new TextEdit();
			this.textEdit2 = new TextEdit();
			this.labelControl1 = new LabelControl();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem9 = new LayoutControlItem();
			this.layoutControlItem11 = new LayoutControlItem();
			this.layoutControlItem12 = new LayoutControlItem();
			this.layoutControlItem13 = new LayoutControlItem();
			this.layoutControlItem14 = new LayoutControlItem();
			this.layoutControlItem15 = new LayoutControlItem();
			this.layoutControlItem16 = new LayoutControlItem();
			this.layoutControlItem18 = new LayoutControlItem();
			this.layoutControlItem17 = new LayoutControlItem();
			this.layoutControlItem19 = new LayoutControlItem();
			this.layoutControlItem23 = new LayoutControlItem();
			this.layoutControlItem24 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem21 = new LayoutControlItem();
			this.openFileDialog1 = new OpenFileDialog();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.comboBox2.get_Properties().BeginInit();
			this.textEdit11.get_Properties().BeginInit();
			this.textEdit10.get_Properties().BeginInit();
			this.textEdit9.get_Properties().BeginInit();
			this.textEdit8.get_Properties().BeginInit();
			this.textEdit3.get_Properties().BeginInit();
			this.textEdit7.get_Properties().BeginInit();
			this.textEdit6.get_Properties().BeginInit();
			this.textEdit5.get_Properties().BeginInit();
			this.textEdit4.get_Properties().BeginInit();
			this.textEdit2.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem9.BeginInit();
			this.layoutControlItem11.BeginInit();
			this.layoutControlItem12.BeginInit();
			this.layoutControlItem13.BeginInit();
			this.layoutControlItem14.BeginInit();
			this.layoutControlItem15.BeginInit();
			this.layoutControlItem16.BeginInit();
			this.layoutControlItem18.BeginInit();
			this.layoutControlItem17.BeginInit();
			this.layoutControlItem19.BeginInit();
			this.layoutControlItem23.BeginInit();
			this.layoutControlItem24.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem21.BeginInit();
			base.SuspendLayout();
			this.layoutControl1.Controls.Add(this.simpleButton2);
			this.layoutControl1.Controls.Add(this.comboBox2);
			this.layoutControl1.Controls.Add(this.textEdit11);
			this.layoutControl1.Controls.Add(this.simpleButton4);
			this.layoutControl1.Controls.Add(this.radioButton2);
			this.layoutControl1.Controls.Add(this.radioButton1);
			this.layoutControl1.Controls.Add(this.labelControl4);
			this.layoutControl1.Controls.Add(this.textEdit10);
			this.layoutControl1.Controls.Add(this.textEdit9);
			this.layoutControl1.Controls.Add(this.labelControl3);
			this.layoutControl1.Controls.Add(this.textEdit8);
			this.layoutControl1.Controls.Add(this.labelControl2);
			this.layoutControl1.Controls.Add(this.textEdit3);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.textEdit7);
			this.layoutControl1.Controls.Add(this.textEdit6);
			this.layoutControl1.Controls.Add(this.textEdit5);
			this.layoutControl1.Controls.Add(this.textEdit4);
			this.layoutControl1.Controls.Add(this.textEdit2);
			this.layoutControl1.Controls.Add(this.labelControl1);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(398, 411);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			this.simpleButton2.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.simpleButton2.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton2.Location = new Point(252, 34);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(138, 22);
			this.simpleButton2.set_StyleController(this.layoutControl1);
			this.simpleButton2.TabIndex = 24;
			this.simpleButton2.Text = "YOKSA EKLEYİNİZ";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			this.comboBox2.set_EnterMoveNextControl(true);
			this.comboBox2.Location = new Point(98, 34);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.comboBox2.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.comboBox2.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.comboBox2.Size = new Size(150, 22);
			this.comboBox2.set_StyleController(this.layoutControl1);
			this.comboBox2.TabIndex = 23;
			this.comboBox2.KeyPress += new KeyPressEventHandler(this.comboBox2_KeyPress);
			this.textEdit11.set_EditValue("0");
			this.textEdit11.set_EnterMoveNextControl(true);
			this.textEdit11.Location = new Point(98, 294);
			this.textEdit11.Name = "textEdit11";
			this.textEdit11.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit11.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit11.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit11.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit11.RightToLeft = RightToLeft.No;
			this.textEdit11.Size = new Size(150, 22);
			this.textEdit11.set_StyleController(this.layoutControl1);
			this.textEdit11.TabIndex = 22;
			this.textEdit11.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit11.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.simpleButton4.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold));
			this.simpleButton4.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton4.Location = new Point(8, 346);
			this.simpleButton4.Name = "simpleButton4";
			this.simpleButton4.Size = new Size(382, 26);
			this.simpleButton4.set_StyleController(this.layoutControl1);
			this.simpleButton4.TabIndex = 21;
			this.simpleButton4.Text = "TEKNİK RESİM EKLE";
			this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
			this.radioButton2.Location = new Point(110, 320);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new Size(280, 22);
			this.radioButton2.TabIndex = 5;
			this.radioButton2.Text = "DİŞLİSİZ";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.radioButton1.Location = new Point(8, 320);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new Size(98, 22);
			this.radioButton1.TabIndex = 4;
			this.radioButton1.Text = "DİŞLİLİ";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
			this.labelControl4.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.labelControl4.Location = new Point(252, 268);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new Size(138, 22);
			this.labelControl4.set_StyleController(this.layoutControl1);
			this.labelControl4.TabIndex = 20;
			this.labelControl4.Text = "kg";
			this.textEdit10.set_EditValue("0");
			this.textEdit10.set_EnterMoveNextControl(true);
			this.textEdit10.Location = new Point(98, 268);
			this.textEdit10.Name = "textEdit10";
			this.textEdit10.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit10.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit10.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit10.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit10.RightToLeft = RightToLeft.No;
			this.textEdit10.Size = new Size(150, 22);
			this.textEdit10.set_StyleController(this.layoutControl1);
			this.textEdit10.TabIndex = 18;
			this.textEdit10.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit10.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.textEdit9.set_EditValue("0");
			this.textEdit9.set_EnterMoveNextControl(true);
			this.textEdit9.Location = new Point(98, 242);
			this.textEdit9.Name = "textEdit9";
			this.textEdit9.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit9.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit9.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit9.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit9.RightToLeft = RightToLeft.No;
			this.textEdit9.Size = new Size(150, 22);
			this.textEdit9.set_StyleController(this.layoutControl1);
			this.textEdit9.TabIndex = 17;
			this.textEdit9.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit9.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.labelControl3.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.labelControl3.Location = new Point(252, 164);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new Size(138, 22);
			this.labelControl3.set_StyleController(this.layoutControl1);
			this.labelControl3.TabIndex = 16;
			this.labelControl3.Text = "mm";
			this.textEdit8.set_EditValue("0");
			this.textEdit8.set_EnterMoveNextControl(true);
			this.textEdit8.Location = new Point(98, 164);
			this.textEdit8.Name = "textEdit8";
			this.textEdit8.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit8.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit8.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit8.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit8.RightToLeft = RightToLeft.No;
			this.textEdit8.Size = new Size(150, 22);
			this.textEdit8.set_StyleController(this.layoutControl1);
			this.textEdit8.TabIndex = 15;
			this.textEdit8.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit8.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.labelControl2.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.labelControl2.Location = new Point(252, 86);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new Size(138, 22);
			this.labelControl2.set_StyleController(this.layoutControl1);
			this.labelControl2.TabIndex = 14;
			this.labelControl2.Text = "kg";
			this.textEdit3.set_EditValue("0");
			this.textEdit3.set_EnterMoveNextControl(true);
			this.textEdit3.Location = new Point(98, 86);
			this.textEdit3.Name = "textEdit3";
			this.textEdit3.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit3.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit3.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit3.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit3.RightToLeft = RightToLeft.No;
			this.textEdit3.Size = new Size(150, 22);
			this.textEdit3.set_StyleController(this.layoutControl1);
			this.textEdit3.TabIndex = 13;
			this.textEdit3.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit3.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.simpleButton1.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Location = new Point(8, 376);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(382, 26);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 12;
			this.simpleButton1.Text = "KAYDET";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.textEdit7.set_EditValue("0");
			this.textEdit7.set_EnterMoveNextControl(true);
			this.textEdit7.Location = new Point(98, 216);
			this.textEdit7.Name = "textEdit7";
			this.textEdit7.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit7.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit7.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit7.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit7.RightToLeft = RightToLeft.No;
			this.textEdit7.Size = new Size(150, 22);
			this.textEdit7.set_StyleController(this.layoutControl1);
			this.textEdit7.TabIndex = 11;
			this.textEdit7.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit7.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.textEdit6.set_EditValue("0");
			this.textEdit6.set_EnterMoveNextControl(true);
			this.textEdit6.Location = new Point(98, 190);
			this.textEdit6.Name = "textEdit6";
			this.textEdit6.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit6.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit6.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit6.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit6.RightToLeft = RightToLeft.No;
			this.textEdit6.Size = new Size(150, 22);
			this.textEdit6.set_StyleController(this.layoutControl1);
			this.textEdit6.TabIndex = 10;
			this.textEdit6.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit6.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.textEdit5.set_EditValue("0");
			this.textEdit5.set_EnterMoveNextControl(true);
			this.textEdit5.Location = new Point(98, 138);
			this.textEdit5.Name = "textEdit5";
			this.textEdit5.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit5.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit5.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit5.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit5.RightToLeft = RightToLeft.No;
			this.textEdit5.Size = new Size(150, 22);
			this.textEdit5.set_StyleController(this.layoutControl1);
			this.textEdit5.TabIndex = 9;
			this.textEdit5.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit5.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.textEdit4.set_EditValue("0");
			this.textEdit4.set_EnterMoveNextControl(true);
			this.textEdit4.Location = new Point(98, 112);
			this.textEdit4.Name = "textEdit4";
			this.textEdit4.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit4.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit4.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit4.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit4.RightToLeft = RightToLeft.No;
			this.textEdit4.Size = new Size(150, 22);
			this.textEdit4.set_StyleController(this.layoutControl1);
			this.textEdit4.TabIndex = 8;
			this.textEdit4.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
			this.textEdit4.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
			this.textEdit2.set_EnterMoveNextControl(true);
			this.textEdit2.Location = new Point(98, 60);
			this.textEdit2.Name = "textEdit2";
			this.textEdit2.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit2.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit2.Size = new Size(150, 22);
			this.textEdit2.set_StyleController(this.layoutControl1);
			this.textEdit2.TabIndex = 6;
			this.textEdit2.add_EditValueChanged(new EventHandler(this.textEdit2_EditValueChanged));
			this.labelControl1.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelControl1.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.labelControl1.Location = new Point(8, 8);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new Size(382, 22);
			this.labelControl1.set_StyleController(this.layoutControl1);
			this.labelControl1.TabIndex = 4;
			this.labelControl1.Text = "YENİ MOTOR EKLE";
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem3,
				this.layoutControlItem5,
				this.layoutControlItem6,
				this.layoutControlItem7,
				this.layoutControlItem8,
				this.layoutControlItem9,
				this.layoutControlItem11,
				this.layoutControlItem12,
				this.layoutControlItem13,
				this.layoutControlItem14,
				this.layoutControlItem15,
				this.layoutControlItem16,
				this.layoutControlItem18,
				this.layoutControlItem17,
				this.layoutControlItem19,
				this.layoutControlItem23,
				this.layoutControlItem24,
				this.layoutControlItem4,
				this.layoutControlItem2
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(398, 411));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.labelControl1);
			this.layoutControlItem1.set_CustomizationFormText("layoutControlItem1");
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_MaxSize(new Size(0, 26));
			this.layoutControlItem1.set_MinSize(new Size(1, 26));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(386, 26));
			this.layoutControlItem1.set_SizeConstraintsType(2);
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem3.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem3.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem3.set_Control(this.textEdit2);
			this.layoutControlItem3.set_CustomizationFormText("MODEL :");
			this.layoutControlItem3.set_Location(new Point(0, 52));
			this.layoutControlItem3.set_MaxSize(new Size(244, 26));
			this.layoutControlItem3.set_MinSize(new Size(1, 26));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(386, 26));
			this.layoutControlItem3.set_SizeConstraintsType(2);
			this.layoutControlItem3.set_Text("MODEL :");
			this.layoutControlItem3.set_TextSize(new Size(87, 13));
			this.layoutControlItem5.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem5.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem5.set_Control(this.textEdit4);
			this.layoutControlItem5.set_CustomizationFormText("HIZ :");
			this.layoutControlItem5.set_Location(new Point(0, 104));
			this.layoutControlItem5.set_MaxSize(new Size(244, 26));
			this.layoutControlItem5.set_MinSize(new Size(1, 26));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(386, 26));
			this.layoutControlItem5.set_SizeConstraintsType(2);
			this.layoutControlItem5.set_Text("HIZ :");
			this.layoutControlItem5.set_TextSize(new Size(87, 13));
			this.layoutControlItem6.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem6.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem6.set_Control(this.textEdit5);
			this.layoutControlItem6.set_CustomizationFormText("MOTOR KW :");
			this.layoutControlItem6.set_Location(new Point(0, 130));
			this.layoutControlItem6.set_MaxSize(new Size(244, 26));
			this.layoutControlItem6.set_MinSize(new Size(1, 26));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(386, 26));
			this.layoutControlItem6.set_SizeConstraintsType(2);
			this.layoutControlItem6.set_Text("MOTOR KW :");
			this.layoutControlItem6.set_TextSize(new Size(87, 13));
			this.layoutControlItem7.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem7.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem7.set_Control(this.textEdit6);
			this.layoutControlItem7.set_CustomizationFormText("KASNAK KANAL :");
			this.layoutControlItem7.set_Location(new Point(0, 182));
			this.layoutControlItem7.set_MaxSize(new Size(244, 26));
			this.layoutControlItem7.set_MinSize(new Size(1, 26));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(386, 26));
			this.layoutControlItem7.set_SizeConstraintsType(2);
			this.layoutControlItem7.set_Text("KASNAK KANAL :");
			this.layoutControlItem7.set_TextSize(new Size(87, 13));
			this.layoutControlItem8.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem8.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem8.set_Control(this.textEdit7);
			this.layoutControlItem8.set_CustomizationFormText("HALAT ÇAPI :");
			this.layoutControlItem8.set_Location(new Point(0, 208));
			this.layoutControlItem8.set_MaxSize(new Size(244, 26));
			this.layoutControlItem8.set_MinSize(new Size(1, 26));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(386, 26));
			this.layoutControlItem8.set_SizeConstraintsType(2);
			this.layoutControlItem8.set_Text("HALAT ÇAPI :");
			this.layoutControlItem8.set_TextSize(new Size(87, 13));
			this.layoutControlItem9.set_Control(this.simpleButton1);
			this.layoutControlItem9.set_CustomizationFormText("layoutControlItem9");
			this.layoutControlItem9.set_Location(new Point(0, 368));
			this.layoutControlItem9.set_MaxSize(new Size(0, 30));
			this.layoutControlItem9.set_MinSize(new Size(1, 30));
			this.layoutControlItem9.set_Name("layoutControlItem9");
			this.layoutControlItem9.set_Size(new Size(386, 31));
			this.layoutControlItem9.set_SizeConstraintsType(2);
			this.layoutControlItem9.set_TextSize(new Size(0, 0));
			this.layoutControlItem9.set_TextVisible(false);
			this.layoutControlItem11.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem11.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem11.set_Control(this.textEdit3);
			this.layoutControlItem11.set_CustomizationFormText("KAPASİTE :");
			this.layoutControlItem11.set_Location(new Point(0, 78));
			this.layoutControlItem11.set_MaxSize(new Size(244, 26));
			this.layoutControlItem11.set_MinSize(new Size(124, 26));
			this.layoutControlItem11.set_Name("layoutControlItem11");
			this.layoutControlItem11.set_Size(new Size(244, 26));
			this.layoutControlItem11.set_SizeConstraintsType(2);
			this.layoutControlItem11.set_Text("KAPASİTE :");
			this.layoutControlItem11.set_TextSize(new Size(87, 13));
			this.layoutControlItem12.set_Control(this.labelControl2);
			this.layoutControlItem12.set_CustomizationFormText("layoutControlItem12");
			this.layoutControlItem12.set_Location(new Point(244, 78));
			this.layoutControlItem12.set_MaxSize(new Size(0, 26));
			this.layoutControlItem12.set_MinSize(new Size(15, 17));
			this.layoutControlItem12.set_Name("layoutControlItem12");
			this.layoutControlItem12.set_Size(new Size(142, 26));
			this.layoutControlItem12.set_SizeConstraintsType(2);
			this.layoutControlItem12.set_TextSize(new Size(0, 0));
			this.layoutControlItem12.set_TextVisible(false);
			this.layoutControlItem13.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem13.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem13.set_Control(this.textEdit8);
			this.layoutControlItem13.set_CustomizationFormText("KASNAK ÇAPI :");
			this.layoutControlItem13.set_Location(new Point(0, 156));
			this.layoutControlItem13.set_MaxSize(new Size(244, 26));
			this.layoutControlItem13.set_MinSize(new Size(144, 26));
			this.layoutControlItem13.set_Name("layoutControlItem13");
			this.layoutControlItem13.set_Size(new Size(244, 26));
			this.layoutControlItem13.set_SizeConstraintsType(2);
			this.layoutControlItem13.set_Text("KASNAK ÇAPI :");
			this.layoutControlItem13.set_TextSize(new Size(87, 13));
			this.layoutControlItem14.set_Control(this.labelControl3);
			this.layoutControlItem14.set_CustomizationFormText("layoutControlItem14");
			this.layoutControlItem14.set_Location(new Point(244, 156));
			this.layoutControlItem14.set_MaxSize(new Size(0, 26));
			this.layoutControlItem14.set_MinSize(new Size(67, 17));
			this.layoutControlItem14.set_Name("layoutControlItem14");
			this.layoutControlItem14.set_Size(new Size(142, 26));
			this.layoutControlItem14.set_SizeConstraintsType(2);
			this.layoutControlItem14.set_TextSize(new Size(0, 0));
			this.layoutControlItem14.set_TextVisible(false);
			this.layoutControlItem15.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem15.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem15.set_Control(this.textEdit9);
			this.layoutControlItem15.set_CustomizationFormText("ASKİ :");
			this.layoutControlItem15.set_Location(new Point(0, 234));
			this.layoutControlItem15.set_MaxSize(new Size(244, 26));
			this.layoutControlItem15.set_MinSize(new Size(144, 26));
			this.layoutControlItem15.set_Name("layoutControlItem15");
			this.layoutControlItem15.set_Size(new Size(386, 26));
			this.layoutControlItem15.set_SizeConstraintsType(2);
			this.layoutControlItem15.set_Text("ASKİ :");
			this.layoutControlItem15.set_TextSize(new Size(87, 13));
			this.layoutControlItem16.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem16.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem16.set_Control(this.textEdit10);
			this.layoutControlItem16.set_CustomizationFormText("MAKS. YÜK :");
			this.layoutControlItem16.set_Location(new Point(0, 260));
			this.layoutControlItem16.set_MaxSize(new Size(244, 26));
			this.layoutControlItem16.set_MinSize(new Size(144, 26));
			this.layoutControlItem16.set_Name("layoutControlItem16");
			this.layoutControlItem16.set_Size(new Size(244, 26));
			this.layoutControlItem16.set_SizeConstraintsType(2);
			this.layoutControlItem16.set_Text("MAKS. YÜK :");
			this.layoutControlItem16.set_TextSize(new Size(87, 13));
			this.layoutControlItem18.set_Control(this.labelControl4);
			this.layoutControlItem18.set_CustomizationFormText("layoutControlItem18");
			this.layoutControlItem18.set_Location(new Point(244, 260));
			this.layoutControlItem18.set_MaxSize(new Size(0, 26));
			this.layoutControlItem18.set_MinSize(new Size(67, 17));
			this.layoutControlItem18.set_Name("layoutControlItem18");
			this.layoutControlItem18.set_Size(new Size(142, 26));
			this.layoutControlItem18.set_SizeConstraintsType(2);
			this.layoutControlItem18.set_TextSize(new Size(0, 0));
			this.layoutControlItem18.set_TextVisible(false);
			this.layoutControlItem17.set_Control(this.radioButton1);
			this.layoutControlItem17.set_CustomizationFormText("layoutControlItem17");
			this.layoutControlItem17.set_Location(new Point(0, 312));
			this.layoutControlItem17.set_MaxSize(new Size(0, 26));
			this.layoutControlItem17.set_MinSize(new Size(24, 26));
			this.layoutControlItem17.set_Name("layoutControlItem17");
			this.layoutControlItem17.set_Size(new Size(102, 26));
			this.layoutControlItem17.set_SizeConstraintsType(2);
			this.layoutControlItem17.set_TextSize(new Size(0, 0));
			this.layoutControlItem17.set_TextVisible(false);
			this.layoutControlItem19.set_Control(this.radioButton2);
			this.layoutControlItem19.set_CustomizationFormText("layoutControlItem19");
			this.layoutControlItem19.set_Location(new Point(102, 312));
			this.layoutControlItem19.set_MaxSize(new Size(0, 26));
			this.layoutControlItem19.set_MinSize(new Size(24, 26));
			this.layoutControlItem19.set_Name("layoutControlItem19");
			this.layoutControlItem19.set_Size(new Size(284, 26));
			this.layoutControlItem19.set_SizeConstraintsType(2);
			this.layoutControlItem19.set_TextSize(new Size(0, 0));
			this.layoutControlItem19.set_TextVisible(false);
			this.layoutControlItem23.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem23.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem23.set_Control(this.simpleButton4);
			this.layoutControlItem23.set_CustomizationFormText("layoutControlItem23");
			this.layoutControlItem23.set_Location(new Point(0, 338));
			this.layoutControlItem23.set_MaxSize(new Size(0, 30));
			this.layoutControlItem23.set_MinSize(new Size(82, 30));
			this.layoutControlItem23.set_Name("layoutControlItem23");
			this.layoutControlItem23.set_Size(new Size(386, 30));
			this.layoutControlItem23.set_SizeConstraintsType(2);
			this.layoutControlItem23.set_TextSize(new Size(0, 0));
			this.layoutControlItem23.set_TextVisible(false);
			this.layoutControlItem24.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem24.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem24.set_Control(this.textEdit11);
			this.layoutControlItem24.set_CustomizationFormText("VERİM :");
			this.layoutControlItem24.set_Location(new Point(0, 286));
			this.layoutControlItem24.set_MaxSize(new Size(244, 26));
			this.layoutControlItem24.set_MinSize(new Size(156, 26));
			this.layoutControlItem24.set_Name("layoutControlItem24");
			this.layoutControlItem24.set_Size(new Size(386, 26));
			this.layoutControlItem24.set_SizeConstraintsType(2);
			this.layoutControlItem24.set_Text("VERİM :");
			this.layoutControlItem24.set_TextSize(new Size(87, 13));
			this.layoutControlItem4.get_AppearanceItemCaption().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.layoutControlItem4.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem4.set_Control(this.comboBox2);
			this.layoutControlItem4.set_CustomizationFormText("layoutControlItem4");
			this.layoutControlItem4.set_Location(new Point(0, 26));
			this.layoutControlItem4.set_MaxSize(new Size(244, 26));
			this.layoutControlItem4.set_MinSize(new Size(144, 24));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(244, 26));
			this.layoutControlItem4.set_SizeConstraintsType(2);
			this.layoutControlItem4.set_Text("MARKA :");
			this.layoutControlItem4.set_TextSize(new Size(87, 13));
			this.layoutControlItem2.set_Control(this.simpleButton2);
			this.layoutControlItem2.set_CustomizationFormText("layoutControlItem2");
			this.layoutControlItem2.set_Location(new Point(244, 26));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(142, 26));
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			this.layoutControlItem21.set_Control(this.labelControl1);
			this.layoutControlItem21.set_CustomizationFormText("layoutControlItem1");
			this.layoutControlItem21.set_Location(new Point(0, 0));
			this.layoutControlItem21.set_MaxSize(new Size(0, 26));
			this.layoutControlItem21.set_MinSize(new Size(1, 26));
			this.layoutControlItem21.set_Name("layoutControlItem1");
			this.layoutControlItem21.set_Size(new Size(317, 26));
			this.layoutControlItem21.set_SizeConstraintsType(2);
			this.layoutControlItem21.set_TextSize(new Size(0, 0));
			this.layoutControlItem21.set_TextVisible(false);
			this.openFileDialog1.FileName = "openFileDialog1";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(398, 411);
			base.Controls.Add(this.layoutControl1);
			this.MaximumSize = new Size(414, 450);
			this.MinimumSize = new Size(414, 450);
			base.Name = "motor";
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Motor Seçme ve Ekleme Ekranı";
			base.Load += new EventHandler(this.motor_Load);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.comboBox2.get_Properties().EndInit();
			this.textEdit11.get_Properties().EndInit();
			this.textEdit10.get_Properties().EndInit();
			this.textEdit9.get_Properties().EndInit();
			this.textEdit8.get_Properties().EndInit();
			this.textEdit3.get_Properties().EndInit();
			this.textEdit7.get_Properties().EndInit();
			this.textEdit6.get_Properties().EndInit();
			this.textEdit5.get_Properties().EndInit();
			this.textEdit4.get_Properties().EndInit();
			this.textEdit2.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem9.EndInit();
			this.layoutControlItem11.EndInit();
			this.layoutControlItem12.EndInit();
			this.layoutControlItem13.EndInit();
			this.layoutControlItem14.EndInit();
			this.layoutControlItem15.EndInit();
			this.layoutControlItem16.EndInit();
			this.layoutControlItem18.EndInit();
			this.layoutControlItem17.EndInit();
			this.layoutControlItem19.EndInit();
			this.layoutControlItem23.EndInit();
			this.layoutControlItem24.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem21.EndInit();
			base.ResumeLayout(false);
		}
	}
}
