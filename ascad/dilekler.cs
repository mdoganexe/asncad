namespace ascad
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraLayout;
    using DevExpress.XtraLayout.Utils;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class dilekler : Form
    {
        private IContainer components = null;
        public DataTable dildata = new DataTable();
        private SimpleButton dileklemebutonu;
        private TextEdit gorunurad;
        private TextEdit kisaltma;
        private LayoutControlItem labeldilkisaltmasi;
        private LayoutControlItem labeldilyazisi;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem3;
        private abc1 xx = new abc1();

        public dilekler()
        {
            this.InitializeComponent();
        }

        private void dilekler_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = this.xx.dilci(0x73, this.dildata);
                this.labeldilyazisi.Text = this.xx.dilci(0x74, this.dildata);
                this.labeldilkisaltmasi.Text = this.xx.dilci(0x75, this.dildata);
                this.dileklemebutonu.Text = this.xx.dilci(0x76, this.dildata);
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(dilekler));
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
            this.kisaltma.Properties.BeginInit();
            this.gorunurad.Properties.BeginInit();
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
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x11c, 0x5b);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.dileklemebutonu.Appearance.Font = new Font("Tahoma", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dileklemebutonu.Appearance.Options.UseFont = true;
            this.dileklemebutonu.Location = new Point(7, 0x3b);
            this.dileklemebutonu.Name = "dileklemebutonu";
            this.dileklemebutonu.Size = new Size(270, 0x19);
            this.dileklemebutonu.StyleController = this.layoutControl1;
            this.dileklemebutonu.TabIndex = 6;
            this.dileklemebutonu.Text = "DİL EKLE";
            this.dileklemebutonu.Click += new EventHandler(this.simpleButton1_Click);
            this.kisaltma.Location = new Point(0x65, 0x21);
            this.kisaltma.Name = "kisaltma";
            this.kisaltma.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.kisaltma.Properties.Appearance.Options.UseFont = true;
            this.kisaltma.Size = new Size(0xb0, 0x16);
            this.kisaltma.StyleController = this.layoutControl1;
            this.kisaltma.TabIndex = 5;
            this.gorunurad.Location = new Point(0x65, 7);
            this.gorunurad.Name = "gorunurad";
            this.gorunurad.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gorunurad.Properties.Appearance.Options.UseFont = true;
            this.gorunurad.Size = new Size(0xb0, 0x16);
            this.gorunurad.StyleController = this.layoutControl1;
            this.gorunurad.TabIndex = 4;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.labeldilyazisi, this.labeldilkisaltmasi, this.layoutControlItem3 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x11c, 0x5b);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            this.labeldilyazisi.AppearanceItemCaption.Font = new Font("Tahoma", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labeldilyazisi.AppearanceItemCaption.Options.UseFont = true;
            this.labeldilyazisi.Control = this.gorunurad;
            this.labeldilyazisi.CustomizationFormText = "Dil  :  ";
            this.labeldilyazisi.Location = new Point(0, 0);
            this.labeldilyazisi.Name = "labeldilyazisi";
            this.labeldilyazisi.Size = new Size(0x112, 0x1a);
            this.labeldilyazisi.Text = "Dil  :  ";
            this.labeldilyazisi.TextSize = new Size(0x5b, 0x12);
            this.labeldilkisaltmasi.AppearanceItemCaption.Font = new Font("Tahoma", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labeldilkisaltmasi.AppearanceItemCaption.Options.UseFont = true;
            this.labeldilkisaltmasi.Control = this.kisaltma;
            this.labeldilkisaltmasi.CustomizationFormText = "Kısaltması : ";
            this.labeldilkisaltmasi.Location = new Point(0, 0x1a);
            this.labeldilkisaltmasi.Name = "labeldilkisaltmasi";
            this.labeldilkisaltmasi.Size = new Size(0x112, 0x1a);
            this.labeldilkisaltmasi.Text = "Kısaltması : ";
            this.labeldilkisaltmasi.TextSize = new Size(0x5b, 0x12);
            this.layoutControlItem3.Control = this.dileklemebutonu;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new Point(0, 0x34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x112, 0x1d);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 0x5b);
            base.Controls.Add(this.layoutControl1);
            this.MaximumSize = new Size(300, 130);
            this.MinimumSize = new Size(300, 130);
            base.Name = "dilekler";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "DİL EKLEME SAYFASI";
            base.Load += new EventHandler(this.dilekler_Load);
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.kisaltma.Properties.EndInit();
            this.gorunurad.Properties.EndInit();
            this.layoutControlGroup1.EndInit();
            this.labeldilyazisi.EndInit();
            this.labeldilkisaltmasi.EndInit();
            this.layoutControlItem3.EndInit();
            base.ResumeLayout(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.gorunurad.Text.Trim() != "") && (this.kisaltma.Text.Trim() != ""))
                {
                    if (!this.xx.oleupdate("select " + this.kisaltma.Text.Trim() + " from diller", ""))
                    {
                        if (this.xx.oleupdate("ALTER TABLE diller ADD COLUMN `" + this.kisaltma.Text.Trim().ToUpper() + "` TEXT", ""))
                        {
                            this.xx.oleupdate("insert into dilcesitleri (gorunurad,kisaad) values ('" + this.gorunurad.Text.Trim() + "','" + this.kisaltma.Text.Trim().ToUpper() + "')", "");
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
                    MessageBox.Show("Dil ve Kısaltması Boş Ge\x00e7ilemez.");
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

