namespace ascad
{
    using DevExpress.Utils;
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

    public class Ayarlar : Form
    {
        private IContainer components = null;
        private FolderBrowserDialog folderBrowserDialog1;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem layoutControlItem9;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private SimpleButton simpleButton4;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;
        private TextEdit textEdit5;
        private abc1 xx = new abc1();

        public Ayarlar()
        {
            this.InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@".\firms.dat"))
                {
                    FileStream serializationStream = new FileStream(@".\firms.dat", FileMode.OpenOrCreate, FileAccess.Read);
                    BinaryFormatter formatter = new BinaryFormatter();
                    abc1.bagbilgi bagbilgi = (abc1.bagbilgi) formatter.Deserialize(serializationStream);
                    serializationStream.Close();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Ayarlar));
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
            this.textEdit5.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit1.Properties.BeginInit();
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
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(0x4a8, 0xc5, 0x1ce, 0x1df);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x1f0, 0xe2);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.textEdit5.Location = new Point(0x8a, 0x6f);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.textEdit5.Properties.Appearance.Options.UseFont = true;
            this.textEdit5.Size = new Size(0x85, 0x16);
            this.textEdit5.StyleController = this.layoutControl1;
            this.textEdit5.TabIndex = 8;
            this.simpleButton4.Appearance.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new Point(0x195, 0x6f);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new Size(0x54, 0x1b);
            this.simpleButton4.StyleController = this.layoutControl1;
            this.simpleButton4.TabIndex = 10;
            this.simpleButton4.Text = "TEST";
            this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
            this.simpleButton3.Appearance.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new Point(0x113, 0x6f);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(0x7e, 0x1b);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 10;
            this.simpleButton3.Text = "YOL TANIMLA";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.textEdit3.Location = new Point(0x8a, 0x3b);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Size = new Size(0xf7, 0x16);
            this.textEdit3.StyleController = this.layoutControl1;
            this.textEdit3.TabIndex = 6;
            this.textEdit4.Location = new Point(0x8a, 0x55);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.textEdit4.Properties.Appearance.Options.UseFont = true;
            this.textEdit4.Properties.UseSystemPasswordChar = true;
            this.textEdit4.Size = new Size(0xf7, 0x16);
            this.textEdit4.StyleController = this.layoutControl1;
            this.textEdit4.TabIndex = 7;
            this.textEdit2.Location = new Point(0x8a, 0x21);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Size = new Size(0xf7, 0x16);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 5;
            this.textEdit1.Location = new Point(0x8a, 7);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new Size(0xf7, 0x16);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 4;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10, this.layoutControlItem7 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x1f0, 0xe2);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.CustomizationFormText = "Server Yolu :";
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x17e, 0x1a);
            this.layoutControlItem1.Text = "Server Yolu :";
            this.layoutControlItem1.TextSize = new Size(0x80, 0x10);
            this.layoutControlItem2.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.CustomizationFormText = "DATABASE ADI";
            this.layoutControlItem2.Location = new Point(0, 0x1a);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x17e, 0x1a);
            this.layoutControlItem2.Text = "DATABASE ADI";
            this.layoutControlItem2.TextSize = new Size(0x80, 0x10);
            this.layoutControlItem3.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.textEdit3;
            this.layoutControlItem3.CustomizationFormText = "DTB USER";
            this.layoutControlItem3.Location = new Point(0, 0x34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x17e, 0x1a);
            this.layoutControlItem3.Text = "DTB USER";
            this.layoutControlItem3.TextSize = new Size(0x80, 0x10);
            this.layoutControlItem4.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.textEdit4;
            this.layoutControlItem4.CustomizationFormText = "DTB PWD";
            this.layoutControlItem4.Location = new Point(0, 0x4e);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0x17e, 0x1a);
            this.layoutControlItem4.Text = "DTB PWD";
            this.layoutControlItem4.TextSize = new Size(0x80, 0x10);
            this.layoutControlItem5.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.textEdit5;
            this.layoutControlItem5.CustomizationFormText = "DOSYALAMA ALANI";
            this.layoutControlItem5.Location = new Point(0, 0x68);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new Size(0x10c, 0x1f);
            this.layoutControlItem5.Text = "DOSYALAMA ALANI";
            this.layoutControlItem5.TextSize = new Size(0x80, 0x10);
            this.layoutControlItem8.Control = this.simpleButton3;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new Point(0x10c, 0x68);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new Size(130, 0x1f);
            this.layoutControlItem8.TextSize = new Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem9.Control = this.simpleButton4;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new Point(0x18e, 0x68);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new Size(0x58, 0x1f);
            this.layoutControlItem9.TextSize = new Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.simpleButton1.Appearance.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.AutoWidthInLayoutControl = true;
            this.simpleButton1.Location = new Point(0x185, 7);
            this.simpleButton1.MinimumSize = new Size(100, 100);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(100, 100);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.Text = "TEST";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.layoutControlItem10.Control = this.simpleButton1;
            this.layoutControlItem10.Location = new Point(0x17e, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new Size(0x68, 0x68);
            this.layoutControlItem10.TextSize = new Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.simpleButton2.Appearance.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new Point(7, 0x8e);
            this.simpleButton2.MinimumSize = new Size(0, 0x4d);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x1e2, 0x4d);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 15;
            this.simpleButton2.Text = "AYARLARI KAYDET";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.layoutControlItem7.Control = this.simpleButton2;
            this.layoutControlItem7.Location = new Point(0, 0x87);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x1e6, 0x51);
            this.layoutControlItem7.TextSize = new Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1f0, 0xe2);
            base.Controls.Add(this.layoutControl1);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "Ayarlar";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            base.Load += new EventHandler(this.Ayarlar_Load);
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.textEdit5.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit1.Properties.EndInit();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            abc1.bagbilgi graph = new abc1.bagbilgi {
                icbag = this.textEdit1.Text,
                databasead = this.textEdit2.Text,
                dtbusrad = this.textEdit3.Text,
                dtbusrpwd = this.textEdit4.Text,
                dosyayol = this.textEdit5.Text,
                dtblocation = ""
            };
            FileStream serializationStream = new FileStream(@".\firms.dat", FileMode.OpenOrCreate, FileAccess.Write);
            new BinaryFormatter().Serialize(serializationStream, graph);
            serializationStream.Close();
            if (this.xx.oleupdate("select * from Kull", ""))
            {
                MessageBox.Show("BAŞARILI GİRİŞ");
            }
            else
            {
                MessageBox.Show("BİLGİLERDE HATA VAR");
                File.Delete(@".\firms.dat");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                abc1.bagbilgi graph = new abc1.bagbilgi {
                    icbag = this.textEdit1.Text,
                    databasead = this.textEdit2.Text,
                    dtbusrad = this.textEdit3.Text,
                    dtbusrpwd = this.textEdit4.Text,
                    dosyayol = this.textEdit5.Text,
                    dtblocation = ""
                };
                FileStream serializationStream = new FileStream(@".\firms.dat", FileMode.OpenOrCreate, FileAccess.Write);
                new BinaryFormatter().Serialize(serializationStream, graph);
                serializationStream.Close();
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("İşlem Başarısız" + exception.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textEdit5.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(this.textEdit5.Text))
                {
                    Directory.CreateDirectory(this.textEdit5.Text);
                }
                Process.Start(this.textEdit5.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}

