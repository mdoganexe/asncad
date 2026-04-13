using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class dilekler : Form
	{
		private abc1 xx = new abc1();

		public DataTable dildata = new DataTable();

		private IContainer components = null;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private SimpleButton dileklemebutonu;

		private TextEdit kisaltma;

		private TextEdit gorunurad;

		private LayoutControlItem labeldilyazisi;

		private LayoutControlItem labeldilkisaltmasi;

		private LayoutControlItem layoutControlItem3;

		public dilekler()
		{
			this.InitializeComponent();
		}

		private void dilekler_Load(object sender, EventArgs e)
		{
			try
			{
				this.Text = this.xx.dilci(115, this.dildata);
				this.labeldilyazisi.set_Text(this.xx.dilci(116, this.dildata));
				this.labeldilkisaltmasi.set_Text(this.xx.dilci(117, this.dildata));
				this.dileklemebutonu.Text = this.xx.dilci(118, this.dildata);
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
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.gorunurad.Text.Trim() != "" && this.kisaltma.Text.Trim() != "";
				if (flag)
				{
					bool flag2 = !this.xx.oleupdate("select " + this.kisaltma.Text.Trim() + " from diller", "");
					if (flag2)
					{
						bool flag3 = this.xx.oleupdate("ALTER TABLE diller ADD COLUMN `" + this.kisaltma.Text.Trim().ToUpper() + "` TEXT", "");
						if (flag3)
						{
							this.xx.oleupdate(string.Concat(new string[]
							{
								"insert into dilcesitleri (gorunurad,kisaad) values ('",
								this.gorunurad.Text.Trim(),
								"','",
								this.kisaltma.Text.Trim().ToUpper(),
								"')"
							}), "");
							base.Close();
						}
						else
						{
							MessageBox.Show("Kısaltma Oluşturulamadı");
						}
					}
					else
					{
						MessageBox.Show("Bu Kısaltma Kullanılamaz.");
					}
				}
				else
				{
					MessageBox.Show("Dil ve Kısaltması Boş Geçilemez.");
				}
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(dilekler));
			this.layoutControl1 = new LayoutControl();
			this.dileklemebutonu = new SimpleButton();
			this.kisaltma = new TextEdit();
			this.gorunurad = new TextEdit();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.labeldilyazisi = new LayoutControlItem();
			this.labeldilkisaltmasi = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.kisaltma.get_Properties().BeginInit();
			this.gorunurad.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.labeldilyazisi.BeginInit();
			this.labeldilkisaltmasi.BeginInit();
			this.layoutControlItem3.BeginInit();
			base.SuspendLayout();
			this.layoutControl1.Controls.Add(this.dileklemebutonu);
			this.layoutControl1.Controls.Add(this.kisaltma);
			this.layoutControl1.Controls.Add(this.gorunurad);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(284, 91);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			this.dileklemebutonu.get_Appearance().set_Font(new Font("Tahoma", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dileklemebutonu.get_Appearance().get_Options().set_UseFont(true);
			this.dileklemebutonu.Location = new Point(7, 59);
			this.dileklemebutonu.Name = "dileklemebutonu";
			this.dileklemebutonu.Size = new Size(270, 25);
			this.dileklemebutonu.set_StyleController(this.layoutControl1);
			this.dileklemebutonu.TabIndex = 6;
			this.dileklemebutonu.Text = "DİL EKLE";
			this.dileklemebutonu.Click += new EventHandler(this.simpleButton1_Click);
			this.kisaltma.Location = new Point(101, 33);
			this.kisaltma.Name = "kisaltma";
			this.kisaltma.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.kisaltma.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kisaltma.Size = new Size(176, 22);
			this.kisaltma.set_StyleController(this.layoutControl1);
			this.kisaltma.TabIndex = 5;
			this.gorunurad.Location = new Point(101, 7);
			this.gorunurad.Name = "gorunurad";
			this.gorunurad.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gorunurad.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.gorunurad.Size = new Size(176, 22);
			this.gorunurad.set_StyleController(this.layoutControl1);
			this.gorunurad.TabIndex = 4;
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.labeldilyazisi,
				this.labeldilkisaltmasi,
				this.layoutControlItem3
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(284, 91));
			this.layoutControlGroup1.set_Text("layoutControlGroup1");
			this.layoutControlGroup1.set_TextVisible(false);
			this.labeldilyazisi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeldilyazisi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labeldilyazisi.set_Control(this.gorunurad);
			this.labeldilyazisi.set_CustomizationFormText("Dil  :  ");
			this.labeldilyazisi.set_Location(new Point(0, 0));
			this.labeldilyazisi.set_Name("labeldilyazisi");
			this.labeldilyazisi.set_Size(new Size(274, 26));
			this.labeldilyazisi.set_Text("Dil  :  ");
			this.labeldilyazisi.set_TextSize(new Size(91, 18));
			this.labeldilkisaltmasi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeldilkisaltmasi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labeldilkisaltmasi.set_Control(this.kisaltma);
			this.labeldilkisaltmasi.set_CustomizationFormText("Kısaltması : ");
			this.labeldilkisaltmasi.set_Location(new Point(0, 26));
			this.labeldilkisaltmasi.set_Name("labeldilkisaltmasi");
			this.labeldilkisaltmasi.set_Size(new Size(274, 26));
			this.labeldilkisaltmasi.set_Text("Kısaltması : ");
			this.labeldilkisaltmasi.set_TextSize(new Size(91, 18));
			this.layoutControlItem3.set_Control(this.dileklemebutonu);
			this.layoutControlItem3.set_CustomizationFormText("layoutControlItem3");
			this.layoutControlItem3.set_Location(new Point(0, 52));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(274, 29));
			this.layoutControlItem3.set_Text("layoutControlItem3");
			this.layoutControlItem3.set_TextSize(new Size(0, 0));
			this.layoutControlItem3.set_TextToControlDistance(0);
			this.layoutControlItem3.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(284, 91);
			base.Controls.Add(this.layoutControl1);
			this.MaximumSize = new Size(300, 130);
			this.MinimumSize = new Size(300, 130);
			base.Name = "dilekler";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "DİL EKLEME SAYFASI";
			base.Load += new EventHandler(this.dilekler_Load);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.kisaltma.get_Properties().EndInit();
			this.gorunurad.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.labeldilyazisi.EndInit();
			this.labeldilkisaltmasi.EndInit();
			this.layoutControlItem3.EndInit();
			base.ResumeLayout(false);
		}
	}
}
