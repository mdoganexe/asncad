namespace ascad
{
    using DevExpress.Utils;
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

    public class sertifikaekler : Form
    {
        private LayoutControlItem asdg;
        private TextEdit belgeno;
        private ComboBoxEdit belgeveren;
        private IContainer components = null;
        public DataTable dildata = new DataTable();
        private string dosyayolu = "";
        private string extensiiion = "";
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private ComboBoxEdit malzeme;
        private TextEdit model;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private TextEdit textEdit1;
        private ComboBoxEdit uretici;
        private abc1 xx = new abc1();

        public sertifikaekler()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void eklemesayfasi_Load(object sender, EventArgs e)
        {
            try
            {
                this.layoutControlItem1.Text = this.xx.dilci(0xa6, this.dildata);
                this.layoutControlItem7.Text = this.xx.dilci(0xa7, this.dildata);
                this.layoutControlItem5.Text = this.xx.dilci(0x1f, this.dildata).ToUpper();
                this.layoutControlItem3.Text = this.xx.dilci(0xa9, this.dildata);
                this.asdg.Text = this.xx.dilci(0xb5, this.dildata);
                this.layoutControlItem4.Text = this.xx.dilci(0xb6, this.dildata);
                this.simpleButton1.Text = this.xx.dilci(0xb7, this.dildata);
                this.simpleButton2.Text = this.xx.dilci(0xb8, this.dildata);
                this.simpleButton3.Text = this.xx.dilci(0xb9, this.dildata);
                this.Text = this.xx.dilci(180, this.dildata);
            }
            catch (Exception)
            {
                try
                {
                    MessageBox.Show(this.xx.dilci(0xb3, this.dildata));
                }
                catch (Exception)
                {
                    MessageBox.Show("Dil Ayarları Y\x00fcklenemedi!");
                }
            }
            this.temizle();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(sertifikaekler));
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
            this.textEdit1.Properties.BeginInit();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            this.belgeveren.Properties.BeginInit();
            this.uretici.Properties.BeginInit();
            this.model.Properties.BeginInit();
            this.belgeno.Properties.BeginInit();
            this.malzeme.Properties.BeginInit();
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
            this.layoutControlItem4.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.textEdit1;
            this.layoutControlItem4.CustomizationFormText = "NOTİFİY BODY :";
            this.layoutControlItem4.Location = new Point(0, 130);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0x1e4, 0x1a);
            this.layoutControlItem4.Text = "NOTİFİY BODY :";
            this.layoutControlItem4.TextSize = new Size(0x61, 0x10);
            this.textEdit1.Location = new Point(0x6b, 0x89);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new Size(380, 0x16);
            this.textEdit1.StyleController = this.layoutControl1;
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
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x1ee, 0x128);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            this.belgeveren.Location = new Point(0x6b, 0x6f);
            this.belgeveren.Name = "belgeveren";
            this.belgeveren.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.belgeveren.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttons = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.belgeveren.Properties.Buttons.AddRange(buttons);
            this.belgeveren.Size = new Size(380, 0x16);
            this.belgeveren.StyleController = this.layoutControl1;
            this.belgeveren.TabIndex = 13;
            this.simpleButton3.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new Point(7, 0x109);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(480, 0x17);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 11;
            this.simpleButton3.Text = "TEMİZLE";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.simpleButton2.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new Point(7, 0xde);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(480, 0x17);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Text = "KAYDET";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.uretici.Location = new Point(0x6b, 0x21);
            this.uretici.Name = "uretici";
            this.uretici.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.uretici.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray2 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.uretici.Properties.Buttons.AddRange(buttonArray2);
            this.uretici.Size = new Size(380, 0x16);
            this.uretici.StyleController = this.layoutControl1;
            this.uretici.TabIndex = 11;
            this.model.Location = new Point(0x6b, 0x3b);
            this.model.Name = "model";
            this.model.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.model.Properties.Appearance.Options.UseFont = true;
            this.model.Size = new Size(380, 0x16);
            this.model.StyleController = this.layoutControl1;
            this.model.TabIndex = 10;
            this.model.KeyPress += new KeyPressEventHandler(this.model_KeyPress);
            this.simpleButton1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new Point(7, 0xb3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(480, 0x17);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "SERTİFİKA EKLE";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.belgeno.Location = new Point(0x6b, 0x55);
            this.belgeno.Name = "belgeno";
            this.belgeno.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.belgeno.Properties.Appearance.Options.UseFont = true;
            this.belgeno.Size = new Size(380, 0x16);
            this.belgeno.StyleController = this.layoutControl1;
            this.belgeno.TabIndex = 6;
            this.malzeme.Location = new Point(0x6b, 7);
            this.malzeme.Name = "malzeme";
            this.malzeme.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.malzeme.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray3 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.malzeme.Properties.Buttons.AddRange(buttonArray3);
            object[] items = new object[] { "KAPI KILIDI", "FREN BLOGU", "A3 EKIPMANI", "KUMANDA KARTI", "PANO", "PISTON VALFI", "REGULATOR", "TAMPON" };
            this.malzeme.Properties.Items.AddRange(items);
            this.malzeme.Size = new Size(380, 0x16);
            this.malzeme.StyleController = this.layoutControl1;
            this.malzeme.TabIndex = 4;
            this.malzeme.KeyPress += new KeyPressEventHandler(this.malzeme_KeyPress);
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray1 = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem6, this.layoutControlItem5, this.layoutControlItem7, this.layoutControlItem2, this.asdg, this.layoutControlItem8, this.layoutControlItem4 };
            this.layoutControlGroup1.Items.AddRange(itemArray1);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x1ee, 0x128);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.malzeme;
            this.layoutControlItem1.CustomizationFormText = "MALZEME:";
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x1e4, 0x1a);
            this.layoutControlItem1.Text = "MALZEME:";
            this.layoutControlItem1.TextSize = new Size(0x61, 0x10);
            this.layoutControlItem3.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.belgeno;
            this.layoutControlItem3.CustomizationFormText = "BELGE NO:";
            this.layoutControlItem3.Location = new Point(0, 0x4e);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x1e4, 0x1a);
            this.layoutControlItem3.Text = "BELGE NO:";
            this.layoutControlItem3.TextSize = new Size(0x61, 0x10);
            this.layoutControlItem6.Control = this.simpleButton1;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new Point(0, 0x9c);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new Size(0x1e4, 0x2b);
            this.layoutControlItem6.Text = " ";
            this.layoutControlItem6.TextLocation = Locations.Top;
            this.layoutControlItem6.TextSize = new Size(0x61, 13);
            this.layoutControlItem5.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.model;
            this.layoutControlItem5.CustomizationFormText = "MODEL:";
            this.layoutControlItem5.Location = new Point(0, 0x34);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new Size(0x1e4, 0x1a);
            this.layoutControlItem5.Text = "MODEL:";
            this.layoutControlItem5.TextSize = new Size(0x61, 0x10);
            this.layoutControlItem7.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.uretici;
            this.layoutControlItem7.CustomizationFormText = "\x00dcRETİCİ:";
            this.layoutControlItem7.Location = new Point(0, 0x1a);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x1e4, 0x1a);
            this.layoutControlItem7.Text = "\x00dcRETİCİ:";
            this.layoutControlItem7.TextSize = new Size(0x61, 0x10);
            this.layoutControlItem2.Control = this.simpleButton2;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new Point(0, 0xc7);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x1e4, 0x2b);
            this.layoutControlItem2.Text = " ";
            this.layoutControlItem2.TextLocation = Locations.Top;
            this.layoutControlItem2.TextSize = new Size(0x61, 13);
            this.asdg.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.asdg.AppearanceItemCaption.Options.UseFont = true;
            this.asdg.Control = this.belgeveren;
            this.asdg.CustomizationFormText = "belgeveren";
            this.asdg.Location = new Point(0, 0x68);
            this.asdg.Name = "asdg";
            this.asdg.Size = new Size(0x1e4, 0x1a);
            this.asdg.Text = "BELGE VEREN:";
            this.asdg.TextSize = new Size(0x61, 0x10);
            this.layoutControlItem8.Control = this.simpleButton3;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new Point(0, 0xf2);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new Size(0x1e4, 0x2c);
            this.layoutControlItem8.Text = " ";
            this.layoutControlItem8.TextLocation = Locations.Top;
            this.layoutControlItem8.TextSize = new Size(0x61, 13);
            this.openFileDialog1.FileName = "openFileDialog1";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1ee, 0x128);
            base.Controls.Add(this.layoutControl1);
            base.Name = "sertifikaekler";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Veri Ekleme";
            base.Load += new EventHandler(this.eklemesayfasi_Load);
            this.layoutControlItem4.EndInit();
            this.textEdit1.Properties.EndInit();
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.belgeveren.Properties.EndInit();
            this.uretici.Properties.EndInit();
            this.model.Properties.EndInit();
            this.belgeno.Properties.EndInit();
            this.malzeme.Properties.EndInit();
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

        private void malzeme_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void model_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((((e.KeyChar == '\\') || (e.KeyChar == '/')) || ((e.KeyChar == ':') || (e.KeyChar == '*'))) || (((e.KeyChar == '?') || (e.KeyChar == '"')) || ((e.KeyChar == '<') || (e.KeyChar == '>')))) || (e.KeyChar == '|'))
            {
                e.Handled = true;
                MessageBox.Show(@"( \ / : * ? ''  < > | ) bu karakterler kullanılamaz ( - ) kullanabilirsiniz.");
            }
        }

        public string resim(string ko)
        {
            try
            {
                this.openFileDialog1.FileName = "Serifika Se\x00e7iniz...";
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.dosyayolu = this.openFileDialog1.FileName;
                    this.extensiiion = Path.GetExtension(this.openFileDialog1.FileName);
                }
                this.openFileDialog1.FileName = "Sertifika Se\x00e7iniz...";
            }
            catch (Exception)
            {
            }
            return "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.resim("RESİMİ SE\x00c7TİR VE KAYDET");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.malzeme.Text == "")
                {
                    MessageBox.Show("Malzeme bilgisini giriniz");
                }
                else if (this.uretici.Text == "")
                {
                    MessageBox.Show("\x00dcretici bilgisini giriniz");
                }
                else if (this.model.Text == "")
                {
                    MessageBox.Show("Model bilgisini giriniz");
                }
                else if (this.belgeno.Text == "")
                {
                    MessageBox.Show("Sertifika No bilgisini giriniz");
                }
                else if (this.belgeveren.Text == "")
                {
                    MessageBox.Show("Onaylayan Kuruluş bilgisini giriniz");
                }
                else
                {
                    bool flag6 = false;
                    if (this.extensiiion != "")
                    {
                        flag6 = true;
                    }
                    else if (MessageBox.Show("Sertifika Se\x00e7mediniz. Yinede Bilgileri Eklemek İstermisiniz,", "Sertifika Se\x00e7ilmedi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        flag6 = true;
                    }
                    if (flag6)
                    {
                        string str = this.model.Text + this.extensiiion;
                        DataTable table = this.xx.dtta("select max(tedarikid) from tedarik", "max tedarik");
                        int num = 0;
                        num = Convert.ToInt32(table.Rows[0][0]) + 1;
                        this.xx.oleupdate(string.Concat(new object[] { 
                            "insert into tedarik (malzeme, uretici,model,serino,belgeveren,edit,gorunur,degisti,nobo,guid) values('", this.malzeme.Text, "','", this.uretici.Text, "','", this.model.Text, "','", this.belgeno.Text, "','", this.belgeveren.Text, "','", str, "',true,true,'", this.textEdit1.Text, "','", Guid.NewGuid(),
                            "')"
                        }), "ekleme");
                        if (this.dosyayolu != "")
                        {
                            Directory.CreateDirectory(@".\sertifika\" + this.malzeme.Text + @"\" + num.ToString());
                            File.Copy(this.dosyayolu, string.Concat(new object[] { @".\sertifika\", this.malzeme.Text, @"\", num, @"\", this.model.Text, this.extensiiion }));
                        }
                        MessageBox.Show("Sertifika başarıyla eklenmiştir");
                        this.temizle();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
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
                this.uretici.Properties.Items.Clear();
                this.belgeveren.Properties.Items.Clear();
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
            try
            {
                DataTable table = this.xx.dtta("select distinct uretici from tedarik", "distinct uretici");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    this.uretici.Properties.Items.Add(table.Rows[i][0].ToString());
                }
                DataTable table2 = this.xx.dtta("select distinct belgeveren from tedarik", "distinct belge");
                for (int j = 0; j < table2.Rows.Count; j++)
                {
                    this.belgeveren.Properties.Items.Add(table2.Rows[j][0].ToString());
                }
            }
            catch (Exception)
            {
            }
            return "";
        }
    }
}

