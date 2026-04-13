using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ascad
{
	public class sertifikaekler : Form
	{
		private abc1 xx = new abc1();

		public DataTable dildata = new DataTable();

		private string extensiiion = "";

		private string dosyayolu = "";

		private IContainer components = null;

		private SaveFileDialog saveFileDialog1;

		private LayoutControlItem layoutControlItem4;

		private TextEdit textEdit1;

		private LayoutControl layoutControl1;

		private ComboBoxEdit belgeveren;

		private SimpleButton simpleButton3;

		private SimpleButton simpleButton2;

		private ComboBoxEdit uretici;

		private TextEdit model;

		private SimpleButton simpleButton1;

		private TextEdit belgeno;

		private ComboBoxEdit malzeme;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem3;

		private LayoutControlItem layoutControlItem6;

		private LayoutControlItem layoutControlItem5;

		private LayoutControlItem layoutControlItem7;

		private LayoutControlItem layoutControlItem2;

		private LayoutControlItem asdg;

		private LayoutControlItem layoutControlItem8;

		private OpenFileDialog openFileDialog1;

		public sertifikaekler()
		{
			this.InitializeComponent();
		}

		private void eklemesayfasi_Load(object sender, EventArgs e)
		{
			try
			{
				this.layoutControlItem1.set_Text(this.xx.dilci(166, this.dildata));
				this.layoutControlItem7.set_Text(this.xx.dilci(167, this.dildata));
				this.layoutControlItem5.set_Text(this.xx.dilci(31, this.dildata).ToUpper());
				this.layoutControlItem3.set_Text(this.xx.dilci(169, this.dildata));
				this.asdg.set_Text(this.xx.dilci(181, this.dildata));
				this.layoutControlItem4.set_Text(this.xx.dilci(182, this.dildata));
				this.simpleButton1.Text = this.xx.dilci(183, this.dildata);
				this.simpleButton2.Text = this.xx.dilci(184, this.dildata);
				this.simpleButton3.Text = this.xx.dilci(185, this.dildata);
				this.Text = this.xx.dilci(180, this.dildata);
			}
			catch (Exception)
			{
				try
				{
					MessageBox.Show(this.xx.dilci(179, this.dildata));
				}
				catch (Exception)
				{
					MessageBox.Show("Dil Ayarları Yüklenemedi!");
				}
			}
			this.temizle();
		}

		public void temizle()
		{
			try
			{
				this.malzeme.Text = "";
				this.uretici.Text = "";
				this.model.Text = "";
				this.belgeno.Text = "";
				this.belgeveren.Text = "";
				this.uretici.get_Properties().get_Items().Clear();
				this.belgeveren.get_Properties().get_Items().Clear();
				this.yy();
				this.textEdit1.Text = "";
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string yy()
		{
			string result = "";
			try
			{
				DataTable dataTable = this.xx.dtta("select distinct uretici from tedarik", "distinct uretici");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.uretici.get_Properties().get_Items().Add(dataTable.Rows[i][0].ToString());
				}
				DataTable dataTable2 = this.xx.dtta("select distinct belgeveren from tedarik", "distinct belge");
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					this.belgeveren.get_Properties().get_Items().Add(dataTable2.Rows[j][0].ToString());
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		private void model_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '\\' || e.KeyChar == '/' || e.KeyChar == ':' || e.KeyChar == '*' || e.KeyChar == '?' || e.KeyChar == '"' || e.KeyChar == '<' || e.KeyChar == '>' || e.KeyChar == '|';
			if (flag)
			{
				e.Handled = true;
				MessageBox.Show("( \\ / : * ? ''  < > | ) bu karakterler kullanılamaz ( - ) kullanabilirsiniz.");
			}
		}

		private void malzeme_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.malzeme.Text == "";
				if (flag)
				{
					MessageBox.Show("Malzeme bilgisini giriniz");
				}
				else
				{
					bool flag2 = this.uretici.Text == "";
					if (flag2)
					{
						MessageBox.Show("Üretici bilgisini giriniz");
					}
					else
					{
						bool flag3 = this.model.Text == "";
						if (flag3)
						{
							MessageBox.Show("Model bilgisini giriniz");
						}
						else
						{
							bool flag4 = this.belgeno.Text == "";
							if (flag4)
							{
								MessageBox.Show("Sertifika No bilgisini giriniz");
							}
							else
							{
								bool flag5 = this.belgeveren.Text == "";
								if (flag5)
								{
									MessageBox.Show("Onaylayan Kuruluş bilgisini giriniz");
								}
								else
								{
									bool flag6 = false;
									bool flag7 = this.extensiiion != "";
									if (flag7)
									{
										flag6 = true;
									}
									else
									{
										bool flag8 = MessageBox.Show("Sertifika Seçmediniz. Yinede Bilgileri Eklemek İstermisiniz,", "Sertifika Seçilmedi", MessageBoxButtons.YesNo) == DialogResult.Yes;
										if (flag8)
										{
											flag6 = true;
										}
									}
									bool flag9 = flag6;
									if (flag9)
									{
										string text = this.model.Text + this.extensiiion;
										DataTable dataTable = this.xx.dtta("select max(tedarikid) from tedarik", "max tedarik");
										int num = Convert.ToInt32(dataTable.Rows[0][0]) + 1;
										this.xx.oleupdate(string.Concat(new object[]
										{
											"insert into tedarik (malzeme, uretici,model,serino,belgeveren,edit,gorunur,degisti,nobo,guid) values('",
											this.malzeme.Text,
											"','",
											this.uretici.Text,
											"','",
											this.model.Text,
											"','",
											this.belgeno.Text,
											"','",
											this.belgeveren.Text,
											"','",
											text,
											"',true,true,'",
											this.textEdit1.Text,
											"','",
											Guid.NewGuid(),
											"')"
										}), "ekleme");
										bool flag10 = this.dosyayolu != "";
										if (flag10)
										{
											string path = ".\\sertifika\\" + this.malzeme.Text + "\\" + num.ToString();
											Directory.CreateDirectory(path);
											File.Copy(this.dosyayolu, string.Concat(new object[]
											{
												".\\sertifika\\",
												this.malzeme.Text,
												"\\",
												num,
												"\\",
												this.model.Text,
												this.extensiiion
											}));
										}
										MessageBox.Show("Sertifika başarıyla eklenmiştir");
										this.temizle();
									}
								}
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.resim("RESİMİ SEÇTİR VE KAYDET");
		}

		public string resim(string ko)
		{
			string result = "";
			try
			{
				this.openFileDialog1.FileName = "Serifika Seçiniz...";
				bool flag = this.openFileDialog1.ShowDialog() == DialogResult.OK;
				if (flag)
				{
					this.dosyayolu = this.openFileDialog1.FileName;
					this.extensiiion = Path.GetExtension(this.openFileDialog1.FileName);
				}
				this.openFileDialog1.FileName = "Sertifika Seçiniz...";
			}
			catch (Exception)
			{
			}
			return result;
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			this.temizle();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(sertifikaekler));
			this.saveFileDialog1 = new SaveFileDialog();
			this.layoutControlItem4 = new LayoutControlItem();
			this.textEdit1 = new TextEdit();
			this.layoutControl1 = new LayoutControl();
			this.belgeveren = new ComboBoxEdit();
			this.simpleButton3 = new SimpleButton();
			this.simpleButton2 = new SimpleButton();
			this.uretici = new ComboBoxEdit();
			this.model = new TextEdit();
			this.simpleButton1 = new SimpleButton();
			this.belgeno = new TextEdit();
			this.malzeme = new ComboBoxEdit();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.asdg = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.openFileDialog1 = new OpenFileDialog();
			this.layoutControlItem4.BeginInit();
			this.textEdit1.get_Properties().BeginInit();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.belgeveren.get_Properties().BeginInit();
			this.uretici.get_Properties().BeginInit();
			this.model.get_Properties().BeginInit();
			this.belgeno.get_Properties().BeginInit();
			this.malzeme.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.asdg.BeginInit();
			this.layoutControlItem8.BeginInit();
			base.SuspendLayout();
			this.layoutControlItem4.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.layoutControlItem4.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem4.set_Control(this.textEdit1);
			this.layoutControlItem4.set_CustomizationFormText("NOTİFİY BODY :");
			this.layoutControlItem4.set_Location(new Point(0, 130));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(484, 26));
			this.layoutControlItem4.set_Text("NOTİFİY BODY :");
			this.layoutControlItem4.set_TextSize(new Size(97, 16));
			this.textEdit1.Location = new Point(107, 137);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.textEdit1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit1.Size = new Size(380, 22);
			this.textEdit1.set_StyleController(this.layoutControl1);
			this.textEdit1.TabIndex = 14;
			this.layoutControl1.Controls.Add(this.textEdit1);
			this.layoutControl1.Controls.Add(this.belgeveren);
			this.layoutControl1.Controls.Add(this.simpleButton3);
			this.layoutControl1.Controls.Add(this.simpleButton2);
			this.layoutControl1.Controls.Add(this.uretici);
			this.layoutControl1.Controls.Add(this.model);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.belgeno);
			this.layoutControl1.Controls.Add(this.malzeme);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(494, 296);
			this.layoutControl1.TabIndex = 1;
			this.layoutControl1.Text = "layoutControl1";
			this.belgeveren.Location = new Point(107, 111);
			this.belgeveren.Name = "belgeveren";
			this.belgeveren.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.belgeveren.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.belgeveren.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.belgeveren.Size = new Size(380, 22);
			this.belgeveren.set_StyleController(this.layoutControl1);
			this.belgeveren.TabIndex = 13;
			this.simpleButton3.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton3.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton3.Location = new Point(7, 265);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new Size(480, 23);
			this.simpleButton3.set_StyleController(this.layoutControl1);
			this.simpleButton3.TabIndex = 11;
			this.simpleButton3.Text = "TEMİZLE";
			this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
			this.simpleButton2.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton2.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton2.Location = new Point(7, 222);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(480, 23);
			this.simpleButton2.set_StyleController(this.layoutControl1);
			this.simpleButton2.TabIndex = 10;
			this.simpleButton2.Text = "KAYDET";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			this.uretici.Location = new Point(107, 33);
			this.uretici.Name = "uretici";
			this.uretici.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.uretici.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.uretici.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.uretici.Size = new Size(380, 22);
			this.uretici.set_StyleController(this.layoutControl1);
			this.uretici.TabIndex = 11;
			this.model.Location = new Point(107, 59);
			this.model.Name = "model";
			this.model.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.model.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.model.Size = new Size(380, 22);
			this.model.set_StyleController(this.layoutControl1);
			this.model.TabIndex = 10;
			this.model.KeyPress += new KeyPressEventHandler(this.model_KeyPress);
			this.simpleButton1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Location = new Point(7, 179);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(480, 23);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 9;
			this.simpleButton1.Text = "SERTİFİKA EKLE";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.belgeno.Location = new Point(107, 85);
			this.belgeno.Name = "belgeno";
			this.belgeno.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.belgeno.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.belgeno.Size = new Size(380, 22);
			this.belgeno.set_StyleController(this.layoutControl1);
			this.belgeno.TabIndex = 6;
			this.malzeme.Location = new Point(107, 7);
			this.malzeme.Name = "malzeme";
			this.malzeme.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.malzeme.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.malzeme.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.malzeme.get_Properties().get_Items().AddRange(new object[]
			{
				"KAPI KILIDI",
				"FREN BLOGU",
				"A3 EKIPMANI",
				"KUMANDA KARTI",
				"PANO",
				"PISTON VALFI",
				"REGULATOR",
				"TAMPON"
			});
			this.malzeme.Size = new Size(380, 22);
			this.malzeme.set_StyleController(this.layoutControl1);
			this.malzeme.TabIndex = 4;
			this.malzeme.KeyPress += new KeyPressEventHandler(this.malzeme_KeyPress);
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem3,
				this.layoutControlItem6,
				this.layoutControlItem5,
				this.layoutControlItem7,
				this.layoutControlItem2,
				this.asdg,
				this.layoutControlItem8,
				this.layoutControlItem4
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(494, 296));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem1.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem1.set_Control(this.malzeme);
			this.layoutControlItem1.set_CustomizationFormText("MALZEME:");
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(484, 26));
			this.layoutControlItem1.set_Text("MALZEME:");
			this.layoutControlItem1.set_TextSize(new Size(97, 16));
			this.layoutControlItem3.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem3.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem3.set_Control(this.belgeno);
			this.layoutControlItem3.set_CustomizationFormText("BELGE NO:");
			this.layoutControlItem3.set_Location(new Point(0, 78));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(484, 26));
			this.layoutControlItem3.set_Text("BELGE NO:");
			this.layoutControlItem3.set_TextSize(new Size(97, 16));
			this.layoutControlItem6.set_Control(this.simpleButton1);
			this.layoutControlItem6.set_CustomizationFormText("layoutControlItem6");
			this.layoutControlItem6.set_Location(new Point(0, 156));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(484, 43));
			this.layoutControlItem6.set_Text(" ");
			this.layoutControlItem6.set_TextLocation(3);
			this.layoutControlItem6.set_TextSize(new Size(97, 13));
			this.layoutControlItem5.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem5.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem5.set_Control(this.model);
			this.layoutControlItem5.set_CustomizationFormText("MODEL:");
			this.layoutControlItem5.set_Location(new Point(0, 52));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(484, 26));
			this.layoutControlItem5.set_Text("MODEL:");
			this.layoutControlItem5.set_TextSize(new Size(97, 16));
			this.layoutControlItem7.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem7.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem7.set_Control(this.uretici);
			this.layoutControlItem7.set_CustomizationFormText("ÜRETİCİ:");
			this.layoutControlItem7.set_Location(new Point(0, 26));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(484, 26));
			this.layoutControlItem7.set_Text("ÜRETİCİ:");
			this.layoutControlItem7.set_TextSize(new Size(97, 16));
			this.layoutControlItem2.set_Control(this.simpleButton2);
			this.layoutControlItem2.set_CustomizationFormText("layoutControlItem2");
			this.layoutControlItem2.set_Location(new Point(0, 199));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(484, 43));
			this.layoutControlItem2.set_Text(" ");
			this.layoutControlItem2.set_TextLocation(3);
			this.layoutControlItem2.set_TextSize(new Size(97, 13));
			this.asdg.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.asdg.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.asdg.set_Control(this.belgeveren);
			this.asdg.set_CustomizationFormText("belgeveren");
			this.asdg.set_Location(new Point(0, 104));
			this.asdg.set_Name("asdg");
			this.asdg.set_Size(new Size(484, 26));
			this.asdg.set_Text("BELGE VEREN:");
			this.asdg.set_TextSize(new Size(97, 16));
			this.layoutControlItem8.set_Control(this.simpleButton3);
			this.layoutControlItem8.set_CustomizationFormText("layoutControlItem8");
			this.layoutControlItem8.set_Location(new Point(0, 242));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(484, 44));
			this.layoutControlItem8.set_Text(" ");
			this.layoutControlItem8.set_TextLocation(3);
			this.layoutControlItem8.set_TextSize(new Size(97, 13));
			this.openFileDialog1.FileName = "openFileDialog1";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(494, 296);
			base.Controls.Add(this.layoutControl1);
			base.Name = "sertifikaekler";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Veri Ekleme";
			base.Load += new EventHandler(this.eklemesayfasi_Load);
			this.layoutControlItem4.EndInit();
			this.textEdit1.get_Properties().EndInit();
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.belgeveren.get_Properties().EndInit();
			this.uretici.get_Properties().EndInit();
			this.model.get_Properties().EndInit();
			this.belgeno.get_Properties().EndInit();
			this.malzeme.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem2.EndInit();
			this.asdg.EndInit();
			this.layoutControlItem8.EndInit();
			base.ResumeLayout(false);
		}
	}
}
