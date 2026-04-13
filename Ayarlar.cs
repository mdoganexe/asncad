using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ascad
{
	public class Ayarlar : Form
	{
		private abc1 xx = new abc1();

		private IContainer components = null;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private TextEdit textEdit4;

		private TextEdit textEdit3;

		private TextEdit textEdit2;

		private TextEdit textEdit1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private LayoutControlItem layoutControlItem3;

		private TextEdit textEdit5;

		private LayoutControlItem layoutControlItem4;

		private SimpleButton simpleButton3;

		private FolderBrowserDialog folderBrowserDialog1;

		private SimpleButton simpleButton4;

		private LayoutControlItem layoutControlItem5;

		private LayoutControlItem layoutControlItem8;

		private LayoutControlItem layoutControlItem9;

		private SimpleButton simpleButton1;

		private LayoutControlItem layoutControlItem10;

		private SimpleButton simpleButton2;

		private LayoutControlItem layoutControlItem7;

		public Ayarlar()
		{
			this.InitializeComponent();
		}

		private void Ayarlar_Load(object sender, EventArgs e)
		{
			try
			{
				bool flag = File.Exists(".\\firms.dat");
				if (flag)
				{
					FileStream fileStream = new FileStream(".\\firms.dat", FileMode.OpenOrCreate, FileAccess.Read);
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					abc1.bagbilgi bagbilgi = (abc1.bagbilgi)binaryFormatter.Deserialize(fileStream);
					fileStream.Close();
					this.textEdit1.Text = bagbilgi.icbag;
					this.textEdit2.Text = bagbilgi.databasead;
					this.textEdit3.Text = bagbilgi.dtbusrad;
					this.textEdit4.Text = bagbilgi.dtbusrpwd;
					this.textEdit5.Text = bagbilgi.dosyayol;
				}
			}
			catch (Exception)
			{
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			abc1.bagbilgi bagbilgi = new abc1.bagbilgi();
			bagbilgi.icbag = this.textEdit1.Text;
			bagbilgi.databasead = this.textEdit2.Text;
			bagbilgi.dtbusrad = this.textEdit3.Text;
			bagbilgi.dtbusrpwd = this.textEdit4.Text;
			bagbilgi.dosyayol = this.textEdit5.Text;
			bagbilgi.dtblocation = "";
			FileStream fileStream = new FileStream(".\\firms.dat", FileMode.OpenOrCreate, FileAccess.Write);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(fileStream, bagbilgi);
			fileStream.Close();
			bool flag = this.xx.oleupdate("select * from Kull", "");
			if (flag)
			{
				MessageBox.Show("BAŞARILI GİRİŞ");
			}
			else
			{
				MessageBox.Show("BİLGİLERDE HATA VAR");
				File.Delete(".\\firms.dat");
			}
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			bool flag = this.folderBrowserDialog1.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.textEdit5.Text = this.folderBrowserDialog1.SelectedPath;
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			try
			{
				abc1.bagbilgi bagbilgi = new abc1.bagbilgi();
				bagbilgi.icbag = this.textEdit1.Text;
				bagbilgi.databasead = this.textEdit2.Text;
				bagbilgi.dtbusrad = this.textEdit3.Text;
				bagbilgi.dtbusrpwd = this.textEdit4.Text;
				bagbilgi.dosyayol = this.textEdit5.Text;
				bagbilgi.dtblocation = "";
				FileStream fileStream = new FileStream(".\\firms.dat", FileMode.OpenOrCreate, FileAccess.Write);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(fileStream, bagbilgi);
				fileStream.Close();
				base.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("İşlem Başarısız" + ex.Message);
			}
		}

		private void simpleButton4_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = !Directory.Exists(this.textEdit5.Text);
				if (flag)
				{
					Directory.CreateDirectory(this.textEdit5.Text);
				}
				Process.Start(this.textEdit5.Text);
			}
			catch (Exception)
			{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Ayarlar));
			this.layoutControl1 = new LayoutControl();
			this.textEdit5 = new TextEdit();
			this.simpleButton4 = new SimpleButton();
			this.simpleButton3 = new SimpleButton();
			this.textEdit3 = new TextEdit();
			this.textEdit4 = new TextEdit();
			this.textEdit2 = new TextEdit();
			this.textEdit1 = new TextEdit();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem9 = new LayoutControlItem();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.simpleButton1 = new SimpleButton();
			this.layoutControlItem10 = new LayoutControlItem();
			this.simpleButton2 = new SimpleButton();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.textEdit5.get_Properties().BeginInit();
			this.textEdit3.get_Properties().BeginInit();
			this.textEdit4.get_Properties().BeginInit();
			this.textEdit2.get_Properties().BeginInit();
			this.textEdit1.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem9.BeginInit();
			this.layoutControlItem10.BeginInit();
			this.layoutControlItem7.BeginInit();
			base.SuspendLayout();
			this.layoutControl1.Controls.Add(this.simpleButton2);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.textEdit5);
			this.layoutControl1.Controls.Add(this.simpleButton4);
			this.layoutControl1.Controls.Add(this.simpleButton3);
			this.layoutControl1.Controls.Add(this.textEdit3);
			this.layoutControl1.Controls.Add(this.textEdit4);
			this.layoutControl1.Controls.Add(this.textEdit2);
			this.layoutControl1.Controls.Add(this.textEdit1);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.get_OptionsCustomizationForm().set_DesignTimeCustomizationFormPositionAndSize(new Rectangle?(new Rectangle(1192, 197, 462, 479)));
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(496, 226);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			this.textEdit5.Location = new Point(138, 111);
			this.textEdit5.Name = "textEdit5";
			this.textEdit5.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.textEdit5.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit5.Size = new Size(133, 22);
			this.textEdit5.set_StyleController(this.layoutControl1);
			this.textEdit5.TabIndex = 8;
			this.simpleButton4.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton4.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton4.Location = new Point(405, 111);
			this.simpleButton4.Margin = new Padding(2);
			this.simpleButton4.Name = "simpleButton4";
			this.simpleButton4.Size = new Size(84, 27);
			this.simpleButton4.set_StyleController(this.layoutControl1);
			this.simpleButton4.TabIndex = 10;
			this.simpleButton4.Text = "TEST";
			this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
			this.simpleButton3.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton3.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton3.Location = new Point(275, 111);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new Size(126, 27);
			this.simpleButton3.set_StyleController(this.layoutControl1);
			this.simpleButton3.TabIndex = 10;
			this.simpleButton3.Text = "YOL TANIMLA";
			this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
			this.textEdit3.Location = new Point(138, 59);
			this.textEdit3.Name = "textEdit3";
			this.textEdit3.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.textEdit3.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit3.Size = new Size(247, 22);
			this.textEdit3.set_StyleController(this.layoutControl1);
			this.textEdit3.TabIndex = 6;
			this.textEdit4.Location = new Point(138, 85);
			this.textEdit4.Name = "textEdit4";
			this.textEdit4.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.textEdit4.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit4.get_Properties().set_UseSystemPasswordChar(true);
			this.textEdit4.Size = new Size(247, 22);
			this.textEdit4.set_StyleController(this.layoutControl1);
			this.textEdit4.TabIndex = 7;
			this.textEdit2.Location = new Point(138, 33);
			this.textEdit2.Name = "textEdit2";
			this.textEdit2.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.textEdit2.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit2.Size = new Size(247, 22);
			this.textEdit2.set_StyleController(this.layoutControl1);
			this.textEdit2.TabIndex = 5;
			this.textEdit1.Location = new Point(138, 7);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.textEdit1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit1.Size = new Size(247, 22);
			this.textEdit1.set_StyleController(this.layoutControl1);
			this.textEdit1.TabIndex = 4;
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem3,
				this.layoutControlItem4,
				this.layoutControlItem5,
				this.layoutControlItem8,
				this.layoutControlItem9,
				this.layoutControlItem10,
				this.layoutControlItem7
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(496, 226));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem1.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem1.set_Control(this.textEdit1);
			this.layoutControlItem1.set_CustomizationFormText("Server Yolu :");
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(382, 26));
			this.layoutControlItem1.set_Text("Server Yolu :");
			this.layoutControlItem1.set_TextSize(new Size(128, 16));
			this.layoutControlItem2.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem2.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem2.set_Control(this.textEdit2);
			this.layoutControlItem2.set_CustomizationFormText("DATABASE ADI");
			this.layoutControlItem2.set_Location(new Point(0, 26));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(382, 26));
			this.layoutControlItem2.set_Text("DATABASE ADI");
			this.layoutControlItem2.set_TextSize(new Size(128, 16));
			this.layoutControlItem3.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem3.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem3.set_Control(this.textEdit3);
			this.layoutControlItem3.set_CustomizationFormText("DTB USER");
			this.layoutControlItem3.set_Location(new Point(0, 52));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(382, 26));
			this.layoutControlItem3.set_Text("DTB USER");
			this.layoutControlItem3.set_TextSize(new Size(128, 16));
			this.layoutControlItem4.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem4.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem4.set_Control(this.textEdit4);
			this.layoutControlItem4.set_CustomizationFormText("DTB PWD");
			this.layoutControlItem4.set_Location(new Point(0, 78));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(382, 26));
			this.layoutControlItem4.set_Text("DTB PWD");
			this.layoutControlItem4.set_TextSize(new Size(128, 16));
			this.layoutControlItem5.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem5.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem5.set_Control(this.textEdit5);
			this.layoutControlItem5.set_CustomizationFormText("DOSYALAMA ALANI");
			this.layoutControlItem5.set_Location(new Point(0, 104));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(268, 31));
			this.layoutControlItem5.set_Text("DOSYALAMA ALANI");
			this.layoutControlItem5.set_TextSize(new Size(128, 16));
			this.layoutControlItem8.set_Control(this.simpleButton3);
			this.layoutControlItem8.set_CustomizationFormText("layoutControlItem8");
			this.layoutControlItem8.set_Location(new Point(268, 104));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(130, 31));
			this.layoutControlItem8.set_TextSize(new Size(0, 0));
			this.layoutControlItem8.set_TextVisible(false);
			this.layoutControlItem9.set_Control(this.simpleButton4);
			this.layoutControlItem9.set_CustomizationFormText("layoutControlItem9");
			this.layoutControlItem9.set_Location(new Point(398, 104));
			this.layoutControlItem9.set_Name("layoutControlItem9");
			this.layoutControlItem9.set_Size(new Size(88, 31));
			this.layoutControlItem9.set_TextSize(new Size(0, 0));
			this.layoutControlItem9.set_TextVisible(false);
			this.simpleButton1.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.set_AutoWidthInLayoutControl(true);
			this.simpleButton1.Location = new Point(389, 7);
			this.simpleButton1.MinimumSize = new Size(100, 100);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(100, 100);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 14;
			this.simpleButton1.Text = "TEST";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.layoutControlItem10.set_Control(this.simpleButton1);
			this.layoutControlItem10.set_Location(new Point(382, 0));
			this.layoutControlItem10.set_Name("layoutControlItem10");
			this.layoutControlItem10.set_Size(new Size(104, 104));
			this.layoutControlItem10.set_TextSize(new Size(0, 0));
			this.layoutControlItem10.set_TextVisible(false);
			this.simpleButton2.get_Appearance().set_Font(new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton2.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton2.Location = new Point(7, 142);
			this.simpleButton2.MinimumSize = new Size(0, 77);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(482, 77);
			this.simpleButton2.set_StyleController(this.layoutControl1);
			this.simpleButton2.TabIndex = 15;
			this.simpleButton2.Text = "AYARLARI KAYDET";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			this.layoutControlItem7.set_Control(this.simpleButton2);
			this.layoutControlItem7.set_Location(new Point(0, 135));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(486, 81));
			this.layoutControlItem7.set_TextSize(new Size(0, 0));
			this.layoutControlItem7.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(496, 226);
			base.Controls.Add(this.layoutControl1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Ayarlar";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Ayarlar";
			base.Load += new EventHandler(this.Ayarlar_Load);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.textEdit5.get_Properties().EndInit();
			this.textEdit3.get_Properties().EndInit();
			this.textEdit4.get_Properties().EndInit();
			this.textEdit2.get_Properties().EndInit();
			this.textEdit1.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem9.EndInit();
			this.layoutControlItem10.EndInit();
			this.layoutControlItem7.EndInit();
			base.ResumeLayout(false);
		}
	}
}
