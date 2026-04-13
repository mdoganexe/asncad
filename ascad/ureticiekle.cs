namespace ascad
{
    using DevExpress.Utils;
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

    public class ureticiekle : Form
    {
        private TextEdit adres;
        private IContainer components = null;
        private TextEdit email;
        private TextEdit fax;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem11;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem layoutControlItem9;
        private TextEdit marka;
        public motor mtr;
        private SimpleButton simpleButton1;
        private TextEdit tel;
        private ComboBoxEdit ulke;
        private TextEdit urtadi;
        private TextEdit vergida;
        private TextEdit vergino;
        private TextEdit web;
        private abc1 xx = new abc1();

        public ureticiekle()
        {
            this.InitializeComponent();
        }

        private void adres_TextChanged(object sender, EventArgs e)
        {
            this.adres.Text = this.adres.Text.ToUpper();
        }

        public void dil(string ney)
        {
            try
            {
                ArrayList list = new ArrayList();
                OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Dil.mdb");
                OleDbCommand command = new OleDbCommand("select " + ney + " from diller", connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader[0].ToString());
                    }
                }
                connection.Close();
                command.Connection.Close();
                this.layoutControlItem1.Text = list[0x16e].ToString();
                this.layoutControlItem3.Text = list[0x16f].ToString();
                this.layoutControlItem2.Text = list[0x170].ToString();
                this.layoutControlItem4.Text = list[0x171].ToString();
                this.layoutControlItem5.Text = list[370].ToString();
                this.layoutControlItem6.Text = list[0x173].ToString();
                this.layoutControlItem7.Text = list[0x174].ToString();
                this.layoutControlItem8.Text = list[0x175].ToString();
                this.layoutControlItem9.Text = list[0x176].ToString();
                this.layoutControlItem10.Text = list[0x177].ToString();
                this.simpleButton1.Text = list[0x178].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Alındı...");
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ureticiekle));
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
            this.email.Properties.BeginInit();
            this.web.Properties.BeginInit();
            this.fax.Properties.BeginInit();
            this.tel.Properties.BeginInit();
            this.vergino.Properties.BeginInit();
            this.vergida.Properties.BeginInit();
            this.ulke.Properties.BeginInit();
            this.adres.Properties.BeginInit();
            this.marka.Properties.BeginInit();
            this.urtadi.Properties.BeginInit();
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
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x196, 0x12a);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.simpleButton1.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new Point(7, 0x10b);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x188, 0x18);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.Text = "KAYDET";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.email.EnterMoveNextControl = true;
            this.email.Location = new Point(0x5f, 0xf1);
            this.email.Name = "email";
            this.email.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.email.Properties.Appearance.Options.UseFont = true;
            this.email.Size = new Size(0x130, 0x16);
            this.email.StyleController = this.layoutControl1;
            this.email.TabIndex = 13;
            this.web.EnterMoveNextControl = true;
            this.web.Location = new Point(0x5f, 0xd7);
            this.web.Name = "web";
            this.web.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.web.Properties.Appearance.Options.UseFont = true;
            this.web.Size = new Size(0x130, 0x16);
            this.web.StyleController = this.layoutControl1;
            this.web.TabIndex = 12;
            this.fax.EnterMoveNextControl = true;
            this.fax.Location = new Point(0x5f, 0xbd);
            this.fax.Name = "fax";
            this.fax.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.fax.Properties.Appearance.Options.UseFont = true;
            this.fax.Size = new Size(0x9e, 0x16);
            this.fax.StyleController = this.layoutControl1;
            this.fax.TabIndex = 11;
            this.tel.EnterMoveNextControl = true;
            this.tel.Location = new Point(0x5f, 0xa3);
            this.tel.Name = "tel";
            this.tel.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tel.Properties.Appearance.Options.UseFont = true;
            this.tel.Size = new Size(0x9e, 0x16);
            this.tel.StyleController = this.layoutControl1;
            this.tel.TabIndex = 10;
            this.vergino.EnterMoveNextControl = true;
            this.vergino.Location = new Point(0x5f, 0x89);
            this.vergino.Name = "vergino";
            this.vergino.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vergino.Properties.Appearance.Options.UseFont = true;
            this.vergino.Size = new Size(0x9e, 0x16);
            this.vergino.StyleController = this.layoutControl1;
            this.vergino.TabIndex = 9;
            this.vergino.KeyPress += new KeyPressEventHandler(this.vergino_KeyPress);
            this.vergida.EnterMoveNextControl = true;
            this.vergida.Location = new Point(0x5f, 0x6f);
            this.vergida.Name = "vergida";
            this.vergida.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vergida.Properties.Appearance.Options.UseFont = true;
            this.vergida.Size = new Size(0x9e, 0x16);
            this.vergida.StyleController = this.layoutControl1;
            this.vergida.TabIndex = 8;
            this.vergida.TextChanged += new EventHandler(this.vergida_TextChanged);
            this.ulke.EnterMoveNextControl = true;
            this.ulke.Location = new Point(0x5f, 0x55);
            this.ulke.Name = "ulke";
            this.ulke.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ulke.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttons = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.ulke.Properties.Buttons.AddRange(buttons);
            this.ulke.Size = new Size(0x9e, 0x16);
            this.ulke.StyleController = this.layoutControl1;
            this.ulke.TabIndex = 7;
            this.adres.EnterMoveNextControl = true;
            this.adres.Location = new Point(0x5f, 0x21);
            this.adres.Name = "adres";
            this.adres.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.adres.Properties.Appearance.Options.UseFont = true;
            this.adres.Size = new Size(0x130, 0x16);
            this.adres.StyleController = this.layoutControl1;
            this.adres.TabIndex = 6;
            this.adres.TextChanged += new EventHandler(this.adres_TextChanged);
            this.marka.EnterMoveNextControl = true;
            this.marka.Location = new Point(0x5f, 0x3b);
            this.marka.Name = "marka";
            this.marka.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.marka.Properties.Appearance.Options.UseFont = true;
            this.marka.Size = new Size(0x9e, 0x16);
            this.marka.StyleController = this.layoutControl1;
            this.marka.TabIndex = 5;
            this.marka.EditValueChanged += new EventHandler(this.marka_EditValueChanged);
            this.marka.TextChanged += new EventHandler(this.marka_TextChanged);
            this.urtadi.EnterMoveNextControl = true;
            this.urtadi.Location = new Point(0x5f, 7);
            this.urtadi.Name = "urtadi";
            this.urtadi.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.urtadi.Properties.Appearance.Options.UseFont = true;
            this.urtadi.Size = new Size(0x130, 0x16);
            this.urtadi.StyleController = this.layoutControl1;
            this.urtadi.TabIndex = 4;
            this.urtadi.TextChanged += new EventHandler(this.urtadi_TextChanged);
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10, this.layoutControlItem11, this.layoutControlItem3 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x196, 0x12a);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.urtadi;
            this.layoutControlItem1.CustomizationFormText = "\x00dcRETİCİ :";
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem1.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem1.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "\x00dcRETİCİ :";
            this.layoutControlItem1.TextSize = new Size(0x55, 13);
            this.layoutControlItem2.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.marka;
            this.layoutControlItem2.CustomizationFormText = "MARKA :";
            this.layoutControlItem2.Location = new Point(0, 0x34);
            this.layoutControlItem2.MaxSize = new Size(250, 0x1a);
            this.layoutControlItem2.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem2.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "MARKA :";
            this.layoutControlItem2.TextSize = new Size(0x55, 13);
            this.layoutControlItem4.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.ulke;
            this.layoutControlItem4.CustomizationFormText = "\x00dcLKE :";
            this.layoutControlItem4.Location = new Point(0, 0x4e);
            this.layoutControlItem4.MaxSize = new Size(250, 0x1a);
            this.layoutControlItem4.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem4.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "\x00dcLKE :";
            this.layoutControlItem4.TextSize = new Size(0x55, 13);
            this.layoutControlItem5.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.vergida;
            this.layoutControlItem5.CustomizationFormText = "VERGİ DAİRESİ :";
            this.layoutControlItem5.Location = new Point(0, 0x68);
            this.layoutControlItem5.MaxSize = new Size(250, 0x1a);
            this.layoutControlItem5.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem5.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "VERGİ DAİRESİ :";
            this.layoutControlItem5.TextSize = new Size(0x55, 13);
            this.layoutControlItem6.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.vergino;
            this.layoutControlItem6.CustomizationFormText = "VERGİ NO :";
            this.layoutControlItem6.Location = new Point(0, 130);
            this.layoutControlItem6.MaxSize = new Size(250, 0x1a);
            this.layoutControlItem6.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem6.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "VERGİ NO :";
            this.layoutControlItem6.TextSize = new Size(0x55, 13);
            this.layoutControlItem7.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.tel;
            this.layoutControlItem7.CustomizationFormText = "TEL :";
            this.layoutControlItem7.Location = new Point(0, 0x9c);
            this.layoutControlItem7.MaxSize = new Size(250, 0x1a);
            this.layoutControlItem7.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem7.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "TEL :";
            this.layoutControlItem7.TextSize = new Size(0x55, 13);
            this.layoutControlItem8.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.fax;
            this.layoutControlItem8.CustomizationFormText = "FAX :";
            this.layoutControlItem8.Location = new Point(0, 0xb6);
            this.layoutControlItem8.MaxSize = new Size(250, 0x1a);
            this.layoutControlItem8.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem8.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "FAX :";
            this.layoutControlItem8.TextSize = new Size(0x55, 13);
            this.layoutControlItem9.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.Control = this.web;
            this.layoutControlItem9.CustomizationFormText = "WEB :";
            this.layoutControlItem9.Location = new Point(0, 0xd0);
            this.layoutControlItem9.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem9.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem9.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "WEB :";
            this.layoutControlItem9.TextSize = new Size(0x55, 13);
            this.layoutControlItem10.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.Control = this.email;
            this.layoutControlItem10.CustomizationFormText = "E MAİL :";
            this.layoutControlItem10.Location = new Point(0, 0xea);
            this.layoutControlItem10.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem10.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem10.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "E MAİL :";
            this.layoutControlItem10.TextSize = new Size(0x55, 13);
            this.layoutControlItem11.Control = this.simpleButton1;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new Point(0, 260);
            this.layoutControlItem11.MaxSize = new Size(0, 0x1c);
            this.layoutControlItem11.MinSize = new Size(0x52, 0x1a);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new Size(0x18c, 0x1c);
            this.layoutControlItem11.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem11.TextSize = new Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            this.layoutControlItem3.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.adres;
            this.layoutControlItem3.CustomizationFormText = "ADRES :";
            this.layoutControlItem3.Location = new Point(0, 0x1a);
            this.layoutControlItem3.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem3.MinSize = new Size(0x8b, 0x1a);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x18c, 0x1a);
            this.layoutControlItem3.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "ADRES :";
            this.layoutControlItem3.TextSize = new Size(0x55, 13);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x196, 0x12a);
            base.Controls.Add(this.layoutControl1);
            base.Name = "ureticiekle";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "\x00dcRETİCİ EKLEME";
            base.Load += new EventHandler(this.ureticiekle_Load);
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.email.Properties.EndInit();
            this.web.Properties.EndInit();
            this.fax.Properties.EndInit();
            this.tel.Properties.EndInit();
            this.vergino.Properties.EndInit();
            this.vergida.Properties.EndInit();
            this.ulke.Properties.EndInit();
            this.adres.Properties.EndInit();
            this.marka.Properties.EndInit();
            this.urtadi.Properties.EndInit();
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

        private void marka_EditValueChanged(object sender, EventArgs e)
        {
            this.marka.Text = this.marka.Text.ToUpper();
        }

        private void marka_TextChanged(object sender, EventArgs e)
        {
            this.marka.Text = this.marka.Text.ToUpper();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.urtadi.Text == "")
                {
                    MessageBox.Show("Tam \x00dcretici Adını Giriniz");
                }
                else if (this.marka.Text == "")
                {
                    MessageBox.Show("\x00dcretici Markasını Boş Ge\x00e7meyiniz");
                }
                else
                {
                    this.xx.oleupdate("insert into uretici (urtadi,marka,adres,ulke,vergida,vergino,tel,fax,email,degisti) values ('" + this.urtadi.Text + "','" + this.marka.Text + "','" + this.adres.Text + "','" + this.ulke.Text + "','" + this.vergida.Text + "','" + this.vergino.Text + "','" + this.tel.Text + "','" + this.fax.Text + "','" + this.email.Text + "',true)", "");
                    this.mtr.yukle();
                    MessageBox.Show("Veriler Başarıyla Eklenmiştir");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("\x00dcretici Bilgisi Eklenemedi");
            }
        }

        private void ureticiekle_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable table2 = this.xx.dtta("select ulke from iller", "");
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    this.ulke.Properties.Items.Add(table2.Rows[i][0].ToString());
                }
            }
            catch (Exception)
            {
            }
            string ney = this.xx.dtta("select dil from firmabilgi", "").Rows[0][0].ToString();
            this.dil(ney);
        }

        private void urtadi_TextChanged(object sender, EventArgs e)
        {
            this.urtadi.Text = this.urtadi.Text.ToUpper();
        }

        private void vergida_TextChanged(object sender, EventArgs e)
        {
            this.vergida.Text = this.vergida.Text.ToUpper();
        }

        private void vergino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

