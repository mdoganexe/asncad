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

namespace ascad
{
	public class ureticigos : Form
	{
		public makmot makmt;

		public string uretici = "";

		private abc1 xx = new abc1();

		private string id = "";

		private IContainer components = null;

		private EditorRow marka;

		private EditorRow adres;

		private EditorRow ulke;

		private EditorRow vergida;

		private EditorRow vergino;

		private EditorRow tel;

		private EditorRow fax;

		private EditorRow web;

		private EditorRow email;

		public VGridControl vGridControl1;

		private EditorRow urtid;

		private RepositoryItemTextEdit repositoryItemTextEdit1;

		public ureticigos()
		{
			this.InitializeComponent();
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
				this.marka.get_Properties().set_Caption(arrayList[348].ToString());
				this.adres.get_Properties().set_Caption(arrayList[349].ToString());
				this.ulke.get_Properties().set_Caption(arrayList[350].ToString());
				this.vergida.get_Properties().set_Caption(arrayList[351].ToString());
				this.vergino.get_Properties().set_Caption(arrayList[352].ToString());
				this.tel.get_Properties().set_Caption(arrayList[353].ToString());
				this.fax.get_Properties().set_Caption(arrayList[354].ToString());
				this.web.get_Properties().set_Caption(arrayList[355].ToString());
				this.email.get_Properties().set_Caption(arrayList[356].ToString());
			}
			catch (Exception)
			{
				MessageBox.Show("Hata Alındı...");
			}
		}

		private void vGridControl1_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				string text = this.vGridControl1.GetCellValue(this.vGridControl1.get_FocusedRow(), this.vGridControl1.get_FocusedRecord()).ToString();
				string text2 = this.vGridControl1.get_FocusedRow().get_Name().ToString();
				this.id = this.vGridControl1.GetCellValue(this.urtid, this.vGridControl1.get_FocusedRecord()).ToString();
				string komut = string.Concat(new string[]
				{
					"update uretici set ",
					text2,
					"='",
					text,
					"',degisti=true where urtid=",
					this.id
				});
				bool flag = MessageBox.Show("Güncellemek İstiyor musunuz", "Güncelleme", MessageBoxButtons.YesNo) == DialogResult.Yes;
				if (flag)
				{
					try
					{
						this.xx.oleupdate(komut, "");
						MessageBox.Show("Veriler Güncellenmiştir");
					}
					catch (Exception)
					{
						MessageBox.Show("Güncelleme Başarısız Oldu");
					}
				}
				else
				{
					DataTable dataSource = this.xx.dtta(("select * from uretici where urtid=" + this.id) ?? "", "");
					this.vGridControl1.set_DataSource(dataSource);
				}
			}
			catch (Exception var_5_125)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ureticigos));
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
			this.vGridControl1.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.vGridControl1.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.vGridControl1.Dock = DockStyle.Fill;
			this.vGridControl1.set_LayoutStyle(1);
			this.vGridControl1.Location = new Point(0, 0);
			this.vGridControl1.Name = "vGridControl1";
			this.vGridControl1.set_RecordWidth(168);
			this.vGridControl1.get_RepositoryItems().AddRange(new RepositoryItem[]
			{
				this.repositoryItemTextEdit1
			});
			this.vGridControl1.set_RowHeaderWidth(32);
			this.vGridControl1.get_Rows().AddRange(new BaseRow[]
			{
				this.marka,
				this.adres,
				this.ulke,
				this.vergida,
				this.vergino,
				this.tel,
				this.fax,
				this.web,
				this.email,
				this.urtid
			});
			this.vGridControl1.Size = new Size(715, 192);
			this.vGridControl1.TabIndex = 0;
			this.vGridControl1.add_CellValueChanged(new CellValueChangedEventHandler(this.vGridControl1_CellValueChanged));
			this.repositoryItemTextEdit1.set_AutoHeight(false);
			this.repositoryItemTextEdit1.set_Name("repositoryItemTextEdit1");
			this.marka.set_Height(20);
			this.marka.set_Name("marka");
			this.marka.get_Properties().set_Caption("MARKA");
			this.marka.get_Properties().set_FieldName("marka");
			this.adres.set_Height(20);
			this.adres.set_Name("adres");
			this.adres.get_Properties().set_Caption("ADRES");
			this.adres.get_Properties().set_FieldName("adres");
			this.ulke.set_Height(20);
			this.ulke.set_Name("ulke");
			this.ulke.get_Properties().set_Caption("ÜLKE");
			this.ulke.get_Properties().set_FieldName("ulke");
			this.vergida.set_Height(20);
			this.vergida.set_Name("vergida");
			this.vergida.get_Properties().set_Caption("VERGİ DAİRESİ");
			this.vergida.get_Properties().set_FieldName("vergida");
			this.vergino.set_Height(20);
			this.vergino.set_Name("vergino");
			this.vergino.get_Properties().set_Caption("VERGİ NO");
			this.vergino.get_Properties().set_FieldName("vergino");
			this.tel.set_Height(20);
			this.tel.set_Name("tel");
			this.tel.get_Properties().set_Caption("TEL");
			this.tel.get_Properties().set_FieldName("tel");
			this.fax.set_Height(20);
			this.fax.set_Name("fax");
			this.fax.get_Properties().set_Caption("FAX");
			this.fax.get_Properties().set_FieldName("fax");
			this.web.set_Height(20);
			this.web.set_Name("web");
			this.web.get_Properties().set_Caption("WEB");
			this.web.get_Properties().set_FieldName("web");
			this.email.set_Height(20);
			this.email.set_Name("email");
			this.email.get_Properties().set_Caption("EMAİL");
			this.email.get_Properties().set_FieldName("email");
			this.urtid.set_Name("urtid");
			this.urtid.get_Properties().set_FieldName("urtid");
			this.urtid.set_Visible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(715, 192);
			base.Controls.Add(this.vGridControl1);
			this.MinimumSize = new Size(731, 231);
			base.Name = "ureticigos";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ÜRETİCİ GÖR";
			base.Load += new EventHandler(this.ureticigos_Load);
			this.vGridControl1.EndInit();
			this.repositoryItemTextEdit1.EndInit();
			base.ResumeLayout(false);
		}
	}
}
