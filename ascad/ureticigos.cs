namespace ascad
{
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraVerticalGrid;
    using DevExpress.XtraVerticalGrid.Events;
    using DevExpress.XtraVerticalGrid.Rows;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Drawing;
    using System.Windows.Forms;

    public class ureticigos : Form
    {
        private EditorRow adres;
        private IContainer components = null;
        private EditorRow email;
        private EditorRow fax;
        private string id = "";
        public makmot makmt;
        private EditorRow marka;
        private RepositoryItemTextEdit repositoryItemTextEdit1;
        private EditorRow tel;
        private EditorRow ulke;
        public string uretici = "";
        private EditorRow urtid;
        private EditorRow vergida;
        private EditorRow vergino;
        public VGridControl vGridControl1;
        private EditorRow web;
        private abc1 xx = new abc1();

        public ureticigos()
        {
            this.InitializeComponent();
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
                this.marka.Properties.Caption = list[0x15c].ToString();
                this.adres.Properties.Caption = list[0x15d].ToString();
                this.ulke.Properties.Caption = list[350].ToString();
                this.vergida.Properties.Caption = list[0x15f].ToString();
                this.vergino.Properties.Caption = list[0x160].ToString();
                this.tel.Properties.Caption = list[0x161].ToString();
                this.fax.Properties.Caption = list[0x162].ToString();
                this.web.Properties.Caption = list[0x163].ToString();
                this.email.Properties.Caption = list[0x164].ToString();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ureticigos));
            this.vGridControl1 = new VGridControl();
            this.repositoryItemTextEdit1 = new RepositoryItemTextEdit();
            this.marka = new EditorRow();
            this.adres = new EditorRow();
            this.ulke = new EditorRow();
            this.vergida = new EditorRow();
            this.vergino = new EditorRow();
            this.tel = new EditorRow();
            this.fax = new EditorRow();
            this.web = new EditorRow();
            this.email = new EditorRow();
            this.urtid = new EditorRow();
            this.vGridControl1.BeginInit();
            this.repositoryItemTextEdit1.BeginInit();
            base.SuspendLayout();
            this.vGridControl1.Appearance.RowHeaderPanel.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.vGridControl1.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vGridControl1.Dock = DockStyle.Fill;
            this.vGridControl1.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.vGridControl1.Location = new Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 0xa8;
            RepositoryItem[] items = new RepositoryItem[] { this.repositoryItemTextEdit1 };
            this.vGridControl1.RepositoryItems.AddRange(items);
            this.vGridControl1.RowHeaderWidth = 0x20;
            BaseRow[] rows = new BaseRow[] { this.marka, this.adres, this.ulke, this.vergida, this.vergino, this.tel, this.fax, this.web, this.email, this.urtid };
            this.vGridControl1.Rows.AddRange(rows);
            this.vGridControl1.Size = new Size(0x2cb, 0xc0);
            this.vGridControl1.TabIndex = 0;
            this.vGridControl1.CellValueChanged += new CellValueChangedEventHandler(this.vGridControl1_CellValueChanged);
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.marka.Height = 20;
            this.marka.Name = "marka";
            this.marka.Properties.Caption = "MARKA";
            this.marka.Properties.FieldName = "marka";
            this.adres.Height = 20;
            this.adres.Name = "adres";
            this.adres.Properties.Caption = "ADRES";
            this.adres.Properties.FieldName = "adres";
            this.ulke.Height = 20;
            this.ulke.Name = "ulke";
            this.ulke.Properties.Caption = "\x00dcLKE";
            this.ulke.Properties.FieldName = "ulke";
            this.vergida.Height = 20;
            this.vergida.Name = "vergida";
            this.vergida.Properties.Caption = "VERGİ DAİRESİ";
            this.vergida.Properties.FieldName = "vergida";
            this.vergino.Height = 20;
            this.vergino.Name = "vergino";
            this.vergino.Properties.Caption = "VERGİ NO";
            this.vergino.Properties.FieldName = "vergino";
            this.tel.Height = 20;
            this.tel.Name = "tel";
            this.tel.Properties.Caption = "TEL";
            this.tel.Properties.FieldName = "tel";
            this.fax.Height = 20;
            this.fax.Name = "fax";
            this.fax.Properties.Caption = "FAX";
            this.fax.Properties.FieldName = "fax";
            this.web.Height = 20;
            this.web.Name = "web";
            this.web.Properties.Caption = "WEB";
            this.web.Properties.FieldName = "web";
            this.email.Height = 20;
            this.email.Name = "email";
            this.email.Properties.Caption = "EMAİL";
            this.email.Properties.FieldName = "email";
            this.urtid.Name = "urtid";
            this.urtid.Properties.FieldName = "urtid";
            this.urtid.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2cb, 0xc0);
            base.Controls.Add(this.vGridControl1);
            this.MinimumSize = new Size(0x2db, 0xe7);
            base.Name = "ureticigos";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "\x00dcRETİCİ G\x00d6R";
            base.Load += new EventHandler(this.ureticigos_Load);
            this.vGridControl1.EndInit();
            this.repositoryItemTextEdit1.EndInit();
            base.ResumeLayout(false);
        }

        private void ureticigos_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {
            }
        }

        private void vGridControl1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                string str = this.vGridControl1.GetCellValue(this.vGridControl1.FocusedRow, this.vGridControl1.FocusedRecord).ToString();
                string str2 = this.vGridControl1.FocusedRow.Name.ToString();
                this.id = this.vGridControl1.GetCellValue(this.urtid, this.vGridControl1.FocusedRecord).ToString();
                string[] textArray1 = new string[] { "update uretici set ", str2, "='", str, "',degisti=true where urtid=", this.id };
                string komut = string.Concat(textArray1);
                if (MessageBox.Show("G\x00fcncellemek İstiyor musunuz", "G\x00fcncelleme", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        this.xx.oleupdate(komut, "");
                        MessageBox.Show("Veriler G\x00fcncellenmiştir");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("G\x00fcncelleme Başarısız Oldu");
                    }
                }
                else
                {
                    DataTable table = this.xx.dtta(("select * from uretici where urtid=" + this.id) ?? "", "");
                    this.vGridControl1.DataSource = table;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

