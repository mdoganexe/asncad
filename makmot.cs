using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class makmot : Form
	{
		public asnhesapfrm frm1;

		private abc1 xx = new abc1();

		private int dis = 0;

		private string edit = "";

		private string ureticiiii = "";

		private ureticigos uret = new ureticigos();

		private DataTable ss;

		private IContainer components = null;

		private GroupControl groupControl1;

		private LayoutControl layoutControl1;

		private CheckEdit checkEdit1;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private CheckEdit checkEdit3;

		private CheckEdit checkEdit2;

		private LayoutControlItem layoutControlItem3;

		private LayoutControlItem layoutControlItem4;

		private LayoutControlItem layoutControlItem5;

		private LayoutControlItem layoutControlItem6;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private LayoutControlItem layoutControlItem7;

		private LayoutControlItem layoutControlItem8;

		public TextEdit textEdit1;

		public TextEdit textEdit2;

		public TextEdit textEdit3;

		private GridColumn gridColumn1;

		private GridColumn gridColumn2;

		private GridColumn gridColumn3;

		private GridColumn gridColumn4;

		private GridColumn gridColumn5;

		private GridColumn gridColumn6;

		private GridColumn gridColumn7;

		private GridColumn gridColumn8;

		private GridColumn gridColumn9;

		private GridColumn gridColumn10;

		private GridColumn gridColumn11;

		private GridColumn gridColumn12;

		private SimpleButton simpleButton1;

		private GridColumn gridColumn13;

		private SimpleButton simpleButton3;

		private SimpleButton simpleButton2;

		private LayoutControl layoutControl2;

		private LayoutControlGroup layoutControlGroup2;

		private LayoutControlItem layoutControlItem9;

		private LayoutControlItem layoutControlItem11;

		private LayoutControlItem layoutControlItem12;

		private LayoutControlItem layoutControlItem13;

		private LayoutControlItem layoutControlItem10;

		private GridColumn gridColumn14;

		private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;

		private GridControl gridControl1;

		private GridView gridView1;

		private GridColumn gridColumn15;

		private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;

		private GridColumn gridColumn16;

		public makmot()
		{
			this.InitializeComponent();
		}

		private void makmot_Load(object sender, EventArgs e)
		{
			try
			{
				this.yeni();
			}
			catch (Exception)
			{
			}
		}

		public void yeni()
		{
			try
			{
				this.gridControl1.set_DataSource(this.xx.dtta("select * from motormakine1 where silindi=false", ""));
			}
			catch (Exception)
			{
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
					this.gridView1.SetRowCellValue(-2147483646, "diskontrol", this.dis);
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
					this.gridView1.SetRowCellValue(-2147483646, "diskontrol", this.dis);
				}
			}
			catch (Exception)
			{
			}
		}

		private void textEdit1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.gridView1.SetRowCellValue(-2147483646, "kapasite", this.textEdit1.Text);
				this.checkEdit1.set_Checked(true);
			}
			catch (Exception)
			{
			}
		}

		private void textEdit2_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.gridView1.SetRowCellValue(-2147483646, "hiz", this.textEdit2.Text);
				this.checkEdit2.set_Checked(true);
			}
			catch (Exception)
			{
			}
		}

		private void textEdit3_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.gridView1.SetRowCellValue(-2147483646, "aski", this.textEdit3.Text);
				this.checkEdit3.set_Checked(true);
			}
			catch (Exception)
			{
			}
		}

		private void checkEdit1_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool @checked = this.checkEdit1.get_Checked();
				if (@checked)
				{
					this.gridView1.SetRowCellValue(-2147483646, "kapasite", this.textEdit1.Text);
				}
				else
				{
					this.gridView1.SetRowCellValue(-2147483646, "kapasite", "");
				}
			}
			catch (Exception)
			{
			}
		}

		private void checkEdit2_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool @checked = this.checkEdit2.get_Checked();
				if (@checked)
				{
					this.gridView1.SetRowCellValue(-2147483646, "hiz", this.textEdit2.Text);
				}
				else
				{
					this.gridView1.SetRowCellValue(-2147483646, "hiz", "");
				}
			}
			catch (Exception)
			{
			}
		}

		private void checkEdit3_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool @checked = this.checkEdit3.get_Checked();
				if (@checked)
				{
					this.gridView1.SetRowCellValue(-2147483646, "aski", this.textEdit3.Text);
				}
				else
				{
					this.gridView1.SetRowCellValue(-2147483646, "aski", "");
				}
			}
			catch (Exception)
			{
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.gridView1.GetFocusedRowCellValue("marka").ToString() != "";
				if (flag)
				{
					this.frm1.textBox12.Text = this.gridView1.GetFocusedRowCellValue("marka").ToString();
					this.frm1.textBox12.Text = this.gridView1.GetFocusedRowCellValue("marka").ToString();
				}
				bool flag2 = this.gridView1.GetFocusedRowCellValue("hiz").ToString() != "";
				if (flag2)
				{
					this.frm1.BeyanHiz.Text = this.gridView1.GetFocusedRowCellValue("hiz").ToString();
				}
				bool flag3 = this.gridView1.GetFocusedRowCellValue("motorkw").ToString() != "";
				if (flag3)
				{
					this.frm1.MotorKw.Text = this.gridView1.GetFocusedRowCellValue("motorkw").ToString();
				}
				bool flag4 = this.gridView1.GetFocusedRowCellValue("kasnakkanal").ToString() != "";
				if (flag4)
				{
					this.frm1.HalatAdet.Text = this.gridView1.GetFocusedRowCellValue("kasnakkanal").ToString();
				}
				bool flag5 = this.gridView1.GetFocusedRowCellValue("model").ToString() != "";
				if (flag5)
				{
					this.frm1.textEdit23.Text = this.gridView1.GetFocusedRowCellValue("model").ToString();
				}
				bool flag6 = this.gridView1.GetFocusedRowCellValue("verim").ToString() != "";
				if (flag6)
				{
					this.frm1.MotorVerim.Text = this.gridView1.GetFocusedRowCellValue("verim").ToString();
				}
				bool flag7 = this.gridView1.GetFocusedRowCellValue("kasnakcap").ToString() != "";
				if (flag7)
				{
					this.frm1.textBox42.Text = this.gridView1.GetFocusedRowCellValue("kasnakcap").ToString();
				}
				bool flag8 = this.gridView1.GetFocusedRowCellValue("halatcap").ToString() != "";
				if (flag8)
				{
					for (int i = 0; i < this.frm1.HalatCap.get_Properties().get_Items().Count; i++)
					{
						bool flag9 = this.frm1.HalatCap.get_Properties().get_Items().get_Item(i).ToString() == this.gridView1.GetFocusedRowCellValue("halatcap").ToString();
						if (flag9)
						{
							this.frm1.HalatCap.set_SelectedIndex(i);
						}
					}
				}
				bool flag10 = this.gridView1.GetFocusedRowCellValue("kapasite").ToString() != "";
				if (flag10)
				{
					this.frm1.degisken = true;
					this.frm1.sds = false;
					this.frm1.BeyanYuk.Text = this.gridView1.GetFocusedRowCellValue("kapasite").ToString();
				}
				base.Close();
			}
			catch (Exception)
			{
			}
			finally
			{
				this.frm1.degisken = false;
			}
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			try
			{
				object obj = this.gridView1.GetFocusedRowCellValue("edit").ToString();
				bool flag = Convert.ToBoolean(this.gridView1.GetFocusedRowCellValue("degisti"));
				this.edit = obj.ToString();
				bool flag2 = this.edit == "";
				if (flag2)
				{
					MessageBox.Show("Teknik Resim Bulunamadı");
				}
				bool flag3 = flag;
				string str;
				if (flag3)
				{
					str = Application.StartupPath;
				}
				else
				{
					this.edit = this.edit.Replace(".\\", "");
					this.edit = this.edit.Replace("\\", "/");
					this.edit = this.edit.Replace("//", "/");
					this.edit = this.edit.Replace("AKIŞ", "AKIS");
					str = "http://www.as-cad.net/fcert";
				}
				Process.Start(str + this.edit);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			new motor
			{
				mkmt = this
			}.ShowDialog();
		}

		private void gridView1_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				GridView gridView = sender as GridView;
				GridHitInfo gridHitInfo = gridView.CalcHitInfo(this.gridControl1.PointToClient(Control.MousePosition));
				bool flag = e.Button == MouseButtons.Left && gridHitInfo.get_InRowCell() && gridHitInfo.get_RowHandle() >= 0 && gridHitInfo.get_Column().get_FieldName() == "marka";
				if (flag)
				{
					this.uret.makmt = this;
					this.ureticiiii = this.gridView1.GetRowCellValue(gridHitInfo.get_RowHandle(), "marka").ToString();
					this.uret.uretici = this.ureticiiii;
					this.ss = this.xx.dtta("select * from uretici where marka='" + this.ureticiiii + "'", "");
					try
					{
						bool flag2 = this.ss.Rows[0]["marka"].ToString() != "";
						if (flag2)
						{
							this.uret.vGridControl1.set_DataSource(this.ss);
							this.uret.ShowDialog();
						}
					}
					catch
					{
						MessageBox.Show("SEÇTİĞİNİZ FİRMAYA AİT BİLGİ BULUNAMADI");
					}
				}
				bool flag3 = e.Button == MouseButtons.Left && gridHitInfo.get_InRowCell() && gridHitInfo.get_RowHandle() >= 0 && gridHitInfo.get_Column().get_FieldName() == "siliniz";
				if (flag3)
				{
					bool flag4 = MessageBox.Show("Bilgileri sileyimmi?", "Bilgiler Silinecek", MessageBoxButtons.YesNo) == DialogResult.Yes;
					if (flag4)
					{
						this.xx.oleupdate("update motormakine1 set silindi=true where id=" + this.gridView1.GetRowCellValue(gridHitInfo.get_RowHandle(), "id").ToString(), "");
						this.yeni();
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void gridControl1_MouseDown(object sender, MouseEventArgs e)
		{
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
			this.groupControl1 = new GroupControl();
			this.layoutControl1 = new LayoutControl();
			this.radioButton2 = new RadioButton();
			this.textEdit3 = new TextEdit();
			this.radioButton1 = new RadioButton();
			this.checkEdit3 = new CheckEdit();
			this.textEdit2 = new TextEdit();
			this.checkEdit2 = new CheckEdit();
			this.textEdit1 = new TextEdit();
			this.checkEdit1 = new CheckEdit();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.gridControl1 = new GridControl();
			this.gridView1 = new GridView();
			this.gridColumn1 = new GridColumn();
			this.repositoryItemHyperLinkEdit1 = new RepositoryItemHyperLinkEdit();
			this.gridColumn2 = new GridColumn();
			this.gridColumn3 = new GridColumn();
			this.gridColumn4 = new GridColumn();
			this.gridColumn5 = new GridColumn();
			this.gridColumn6 = new GridColumn();
			this.gridColumn7 = new GridColumn();
			this.gridColumn8 = new GridColumn();
			this.gridColumn9 = new GridColumn();
			this.gridColumn10 = new GridColumn();
			this.gridColumn11 = new GridColumn();
			this.gridColumn12 = new GridColumn();
			this.gridColumn13 = new GridColumn();
			this.gridColumn14 = new GridColumn();
			this.gridColumn15 = new GridColumn();
			this.repositoryItemHyperLinkEdit2 = new RepositoryItemHyperLinkEdit();
			this.gridColumn16 = new GridColumn();
			this.simpleButton1 = new SimpleButton();
			this.layoutControl2 = new LayoutControl();
			this.simpleButton2 = new SimpleButton();
			this.simpleButton3 = new SimpleButton();
			this.layoutControlGroup2 = new LayoutControlGroup();
			this.layoutControlItem9 = new LayoutControlItem();
			this.layoutControlItem11 = new LayoutControlItem();
			this.layoutControlItem10 = new LayoutControlItem();
			this.layoutControlItem12 = new LayoutControlItem();
			this.layoutControlItem13 = new LayoutControlItem();
			this.groupControl1.BeginInit();
			this.groupControl1.SuspendLayout();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.textEdit3.get_Properties().BeginInit();
			this.checkEdit3.get_Properties().BeginInit();
			this.textEdit2.get_Properties().BeginInit();
			this.checkEdit2.get_Properties().BeginInit();
			this.textEdit1.get_Properties().BeginInit();
			this.checkEdit1.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.gridControl1.BeginInit();
			this.gridView1.BeginInit();
			this.repositoryItemHyperLinkEdit1.BeginInit();
			this.repositoryItemHyperLinkEdit2.BeginInit();
			this.layoutControl2.BeginInit();
			this.layoutControl2.SuspendLayout();
			this.layoutControlGroup2.BeginInit();
			this.layoutControlItem9.BeginInit();
			this.layoutControlItem11.BeginInit();
			this.layoutControlItem10.BeginInit();
			this.layoutControlItem12.BeginInit();
			this.layoutControlItem13.BeginInit();
			base.SuspendLayout();
			this.groupControl1.Controls.Add(this.layoutControl1);
			this.groupControl1.Location = new Point(7, 7);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new Size(516, 86);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "ARAMA KRİTERLERİ";
			this.layoutControl1.Controls.Add(this.radioButton2);
			this.layoutControl1.Controls.Add(this.textEdit3);
			this.layoutControl1.Controls.Add(this.radioButton1);
			this.layoutControl1.Controls.Add(this.checkEdit3);
			this.layoutControl1.Controls.Add(this.textEdit2);
			this.layoutControl1.Controls.Add(this.checkEdit2);
			this.layoutControl1.Controls.Add(this.textEdit1);
			this.layoutControl1.Controls.Add(this.checkEdit1);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(2, 20);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(512, 64);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			this.radioButton2.Location = new Point(7, 33);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new Size(75, 22);
			this.radioButton2.TabIndex = 7;
			this.radioButton2.Text = "DİŞLİSİZ";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
			this.textEdit3.set_EnterMoveNextControl(true);
			this.textEdit3.Location = new Point(313, 33);
			this.textEdit3.Name = "textEdit3";
			this.textEdit3.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit3.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit3.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit3.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit3.RightToLeft = RightToLeft.No;
			this.textEdit3.Size = new Size(65, 22);
			this.textEdit3.set_StyleController(this.layoutControl1);
			this.textEdit3.TabIndex = 5;
			this.textEdit3.TextChanged += new EventHandler(this.textEdit3_TextChanged);
			this.radioButton1.Location = new Point(86, 33);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new Size(65, 22);
			this.radioButton1.TabIndex = 6;
			this.radioButton1.Text = "DİŞLİLİ";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
			this.checkEdit3.set_EditValue(true);
			this.checkEdit3.Location = new Point(215, 33);
			this.checkEdit3.Name = "checkEdit3";
			this.checkEdit3.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.checkEdit3.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.checkEdit3.get_Properties().set_Caption("ASKI TİPİ 1 /");
			this.checkEdit3.Size = new Size(94, 19);
			this.checkEdit3.set_StyleController(this.layoutControl1);
			this.checkEdit3.TabIndex = 4;
			this.checkEdit3.add_CheckedChanged(new EventHandler(this.checkEdit3_CheckedChanged));
			this.textEdit2.set_EnterMoveNextControl(true);
			this.textEdit2.Location = new Point(313, 7);
			this.textEdit2.Name = "textEdit2";
			this.textEdit2.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit2.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit2.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit2.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit2.RightToLeft = RightToLeft.No;
			this.textEdit2.Size = new Size(65, 22);
			this.textEdit2.set_StyleController(this.layoutControl1);
			this.textEdit2.TabIndex = 3;
			this.textEdit2.TextChanged += new EventHandler(this.textEdit2_TextChanged);
			this.checkEdit2.set_EditValue(true);
			this.checkEdit2.Location = new Point(215, 7);
			this.checkEdit2.Name = "checkEdit2";
			this.checkEdit2.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.checkEdit2.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.checkEdit2.get_Properties().set_Caption("HIZ :");
			this.checkEdit2.Size = new Size(94, 19);
			this.checkEdit2.set_StyleController(this.layoutControl1);
			this.checkEdit2.TabIndex = 2;
			this.checkEdit2.add_CheckedChanged(new EventHandler(this.checkEdit2_CheckedChanged));
			this.textEdit1.set_EnterMoveNextControl(true);
			this.textEdit1.Location = new Point(86, 7);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit1.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.textEdit1.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(3);
			this.textEdit1.RightToLeft = RightToLeft.No;
			this.textEdit1.Size = new Size(65, 22);
			this.textEdit1.set_StyleController(this.layoutControl1);
			this.textEdit1.TabIndex = 1;
			this.textEdit1.TextChanged += new EventHandler(this.textEdit1_TextChanged);
			this.checkEdit1.set_EditValue(true);
			this.checkEdit1.Location = new Point(7, 7);
			this.checkEdit1.Name = "checkEdit1";
			this.checkEdit1.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.checkEdit1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.checkEdit1.get_Properties().set_Caption("KAPASİTE");
			this.checkEdit1.Size = new Size(75, 19);
			this.checkEdit1.set_StyleController(this.layoutControl1);
			this.checkEdit1.TabIndex = 0;
			this.checkEdit1.add_CheckedChanged(new EventHandler(this.checkEdit1_CheckedChanged));
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem8,
				this.layoutControlItem3,
				this.layoutControlItem4,
				this.layoutControlItem7,
				this.layoutControlItem5,
				this.layoutControlItem6
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(512, 64));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.checkEdit1);
			this.layoutControlItem1.set_CustomizationFormText("layoutControlItem1");
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_MaxSize(new Size(79, 26));
			this.layoutControlItem1.set_MinSize(new Size(79, 26));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(79, 26));
			this.layoutControlItem1.set_SizeConstraintsType(2);
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem2.set_Control(this.textEdit1);
			this.layoutControlItem2.set_CustomizationFormText("layoutControlItem2");
			this.layoutControlItem2.set_Location(new Point(79, 0));
			this.layoutControlItem2.set_MaxSize(new Size(69, 26));
			this.layoutControlItem2.set_MinSize(new Size(69, 26));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(69, 26));
			this.layoutControlItem2.set_SizeConstraintsType(2);
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			this.layoutControlItem8.set_Control(this.radioButton2);
			this.layoutControlItem8.set_CustomizationFormText("layoutControlItem8");
			this.layoutControlItem8.set_Location(new Point(0, 26));
			this.layoutControlItem8.set_MaxSize(new Size(79, 26));
			this.layoutControlItem8.set_MinSize(new Size(79, 24));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(79, 28));
			this.layoutControlItem8.set_SizeConstraintsType(2);
			this.layoutControlItem8.set_TextSize(new Size(0, 0));
			this.layoutControlItem8.set_TextVisible(false);
			this.layoutControlItem3.set_Control(this.checkEdit2);
			this.layoutControlItem3.set_CustomizationFormText("layoutControlItem3");
			this.layoutControlItem3.set_Location(new Point(148, 0));
			this.layoutControlItem3.set_MaxSize(new Size(158, 26));
			this.layoutControlItem3.set_MinSize(new Size(158, 26));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(158, 26));
			this.layoutControlItem3.set_SizeConstraintsType(2);
			this.layoutControlItem3.set_Spacing(new Padding(60, 0, 0, 0));
			this.layoutControlItem3.set_TextSize(new Size(0, 0));
			this.layoutControlItem3.set_TextVisible(false);
			this.layoutControlItem4.set_Control(this.textEdit2);
			this.layoutControlItem4.set_CustomizationFormText("layoutControlItem4");
			this.layoutControlItem4.set_Location(new Point(306, 0));
			this.layoutControlItem4.set_MaxSize(new Size(69, 26));
			this.layoutControlItem4.set_MinSize(new Size(69, 26));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(196, 26));
			this.layoutControlItem4.set_SizeConstraintsType(2);
			this.layoutControlItem4.set_TextSize(new Size(0, 0));
			this.layoutControlItem4.set_TextVisible(false);
			this.layoutControlItem7.set_Control(this.radioButton1);
			this.layoutControlItem7.set_CustomizationFormText("layoutControlItem7");
			this.layoutControlItem7.set_Location(new Point(79, 26));
			this.layoutControlItem7.set_MaxSize(new Size(69, 26));
			this.layoutControlItem7.set_MinSize(new Size(69, 26));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(69, 28));
			this.layoutControlItem7.set_SizeConstraintsType(2);
			this.layoutControlItem7.set_TextSize(new Size(0, 0));
			this.layoutControlItem7.set_TextVisible(false);
			this.layoutControlItem5.set_Control(this.checkEdit3);
			this.layoutControlItem5.set_CustomizationFormText("layoutControlItem5");
			this.layoutControlItem5.set_Location(new Point(148, 26));
			this.layoutControlItem5.set_MaxSize(new Size(158, 26));
			this.layoutControlItem5.set_MinSize(new Size(158, 26));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(158, 28));
			this.layoutControlItem5.set_SizeConstraintsType(2);
			this.layoutControlItem5.set_Spacing(new Padding(60, 0, 0, 0));
			this.layoutControlItem5.set_TextSize(new Size(0, 0));
			this.layoutControlItem5.set_TextVisible(false);
			this.layoutControlItem6.set_Control(this.textEdit3);
			this.layoutControlItem6.set_CustomizationFormText("layoutControlItem6");
			this.layoutControlItem6.set_Location(new Point(306, 26));
			this.layoutControlItem6.set_MaxSize(new Size(69, 26));
			this.layoutControlItem6.set_MinSize(new Size(69, 26));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(196, 28));
			this.layoutControlItem6.set_SizeConstraintsType(2);
			this.layoutControlItem6.set_TextSize(new Size(0, 0));
			this.layoutControlItem6.set_TextVisible(false);
			this.gridControl1.Location = new Point(7, 97);
			this.gridControl1.set_MainView(this.gridView1);
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.get_RepositoryItems().AddRange(new RepositoryItem[]
			{
				this.repositoryItemHyperLinkEdit1,
				this.repositoryItemHyperLinkEdit2
			});
			this.gridControl1.Size = new Size(999, 450);
			this.gridControl1.TabIndex = 4;
			this.gridControl1.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView1
			});
			this.gridControl1.MouseDown += new MouseEventHandler(this.gridControl1_MouseDown);
			this.gridView1.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_DetailTip().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Empty().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_EvenRow().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterCloseButton().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterPanel().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FixedLine().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedCell().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedRow().set_BackColor(Color.FromArgb(128, 128, 255));
			this.gridView1.get_Appearance().get_FocusedRow().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedRow().get_Options().set_UseBackColor(true);
			this.gridView1.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FooterPanel().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupButton().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupFooter().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupPanel().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupRow().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HeaderPanel().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HideSelectionRow().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HorzLine().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_OddRow().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Preview().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Row().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_RowSeparator().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_SelectedRow().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_TopNewRow().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_VertLine().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ViewCaption().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView1.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn1,
				this.gridColumn2,
				this.gridColumn3,
				this.gridColumn4,
				this.gridColumn5,
				this.gridColumn6,
				this.gridColumn7,
				this.gridColumn8,
				this.gridColumn9,
				this.gridColumn10,
				this.gridColumn11,
				this.gridColumn12,
				this.gridColumn13,
				this.gridColumn14,
				this.gridColumn15,
				this.gridColumn16
			});
			this.gridView1.set_GridControl(this.gridControl1);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsView().set_ShowAutoFilterRow(true);
			this.gridView1.add_MouseDown(new MouseEventHandler(this.gridView1_MouseDown));
			this.gridColumn1.set_Caption("MARKA");
			this.gridColumn1.set_ColumnEdit(this.repositoryItemHyperLinkEdit1);
			this.gridColumn1.set_FieldName("marka");
			this.gridColumn1.set_Name("gridColumn1");
			this.gridColumn1.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn1.set_Visible(true);
			this.gridColumn1.set_VisibleIndex(0);
			this.gridColumn1.set_Width(114);
			this.repositoryItemHyperLinkEdit1.set_AutoHeight(false);
			this.repositoryItemHyperLinkEdit1.set_Name("repositoryItemHyperLinkEdit1");
			this.gridColumn2.set_Caption("MODEL");
			this.gridColumn2.set_FieldName("model");
			this.gridColumn2.set_Name("gridColumn2");
			this.gridColumn2.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn2.set_Visible(true);
			this.gridColumn2.set_VisibleIndex(1);
			this.gridColumn2.set_Width(117);
			this.gridColumn3.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn3.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn3.set_Caption("KAPASİTE");
			this.gridColumn3.set_FieldName("kapasite");
			this.gridColumn3.set_MaxWidth(90);
			this.gridColumn3.set_MinWidth(80);
			this.gridColumn3.set_Name("gridColumn3");
			this.gridColumn3.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn3.set_Visible(true);
			this.gridColumn3.set_VisibleIndex(2);
			this.gridColumn3.set_Width(80);
			this.gridColumn4.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn4.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn4.set_Caption("HIZ");
			this.gridColumn4.set_FieldName("hiz");
			this.gridColumn4.set_MaxWidth(35);
			this.gridColumn4.set_MinWidth(35);
			this.gridColumn4.set_Name("gridColumn4");
			this.gridColumn4.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn4.set_Visible(true);
			this.gridColumn4.set_VisibleIndex(3);
			this.gridColumn4.set_Width(35);
			this.gridColumn5.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn5.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn5.set_Caption("MOTOR KW");
			this.gridColumn5.set_FieldName("motorkw");
			this.gridColumn5.set_MaxWidth(70);
			this.gridColumn5.set_MinWidth(70);
			this.gridColumn5.set_Name("gridColumn5");
			this.gridColumn5.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn5.set_Visible(true);
			this.gridColumn5.set_VisibleIndex(4);
			this.gridColumn5.set_Width(70);
			this.gridColumn6.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn6.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn6.set_Caption("KASNAK ÇAPI");
			this.gridColumn6.set_FieldName("kasnakcap");
			this.gridColumn6.set_MaxWidth(75);
			this.gridColumn6.set_MinWidth(75);
			this.gridColumn6.set_Name("gridColumn6");
			this.gridColumn6.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn6.set_Visible(true);
			this.gridColumn6.set_VisibleIndex(5);
			this.gridColumn7.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn7.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn7.set_Caption("KASNAK KANAL");
			this.gridColumn7.set_FieldName("kasnakkanal");
			this.gridColumn7.set_MaxWidth(85);
			this.gridColumn7.set_MinWidth(85);
			this.gridColumn7.set_Name("gridColumn7");
			this.gridColumn7.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn7.set_Visible(true);
			this.gridColumn7.set_VisibleIndex(6);
			this.gridColumn7.set_Width(85);
			this.gridColumn8.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn8.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn8.set_Caption("HALAT ÇAP");
			this.gridColumn8.set_FieldName("halatcap");
			this.gridColumn8.set_MaxWidth(75);
			this.gridColumn8.set_MinWidth(75);
			this.gridColumn8.set_Name("gridColumn8");
			this.gridColumn8.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn8.set_Visible(true);
			this.gridColumn8.set_VisibleIndex(7);
			this.gridColumn9.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn9.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn9.set_Caption("ASKI");
			this.gridColumn9.set_FieldName("aski");
			this.gridColumn9.set_MaxWidth(50);
			this.gridColumn9.set_MinWidth(50);
			this.gridColumn9.set_Name("gridColumn9");
			this.gridColumn9.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn9.set_Visible(true);
			this.gridColumn9.set_VisibleIndex(8);
			this.gridColumn9.set_Width(50);
			this.gridColumn10.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn10.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn10.set_Caption("MAKS. YÜK");
			this.gridColumn10.set_FieldName("maksyuk");
			this.gridColumn10.set_MaxWidth(60);
			this.gridColumn10.set_MinWidth(60);
			this.gridColumn10.set_Name("gridColumn10");
			this.gridColumn10.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn10.set_Visible(true);
			this.gridColumn10.set_VisibleIndex(9);
			this.gridColumn10.set_Width(60);
			this.gridColumn11.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn11.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn11.set_Caption("DİŞ");
			this.gridColumn11.set_FieldName("diskontrol");
			this.gridColumn11.set_MaxWidth(40);
			this.gridColumn11.set_MinWidth(40);
			this.gridColumn11.set_Name("gridColumn11");
			this.gridColumn11.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn11.set_Visible(true);
			this.gridColumn11.set_VisibleIndex(11);
			this.gridColumn11.set_Width(40);
			this.gridColumn12.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn12.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn12.set_Caption("VERİM");
			this.gridColumn12.set_FieldName("verim");
			this.gridColumn12.set_MaxWidth(50);
			this.gridColumn12.set_MinWidth(50);
			this.gridColumn12.set_Name("gridColumn12");
			this.gridColumn12.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn12.set_Visible(true);
			this.gridColumn12.set_VisibleIndex(10);
			this.gridColumn12.set_Width(50);
			this.gridColumn13.set_Caption("gridColumn13");
			this.gridColumn13.set_FieldName("id");
			this.gridColumn13.set_Name("gridColumn13");
			this.gridColumn13.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn14.set_Caption("gridColumn14");
			this.gridColumn14.set_FieldName("edit");
			this.gridColumn14.set_Name("gridColumn14");
			this.gridColumn14.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn15.get_AppearanceCell().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridColumn15.get_AppearanceCell().get_Options().set_UseFont(true);
			this.gridColumn15.set_Caption("SİL");
			this.gridColumn15.set_ColumnEdit(this.repositoryItemHyperLinkEdit2);
			this.gridColumn15.set_FieldName("siliniz");
			this.gridColumn15.set_MaxWidth(32);
			this.gridColumn15.set_MinWidth(32);
			this.gridColumn15.set_Name("gridColumn15");
			this.gridColumn15.set_Visible(true);
			this.gridColumn15.set_VisibleIndex(12);
			this.gridColumn15.set_Width(32);
			this.repositoryItemHyperLinkEdit2.set_AutoHeight(false);
			this.repositoryItemHyperLinkEdit2.set_Name("repositoryItemHyperLinkEdit2");
			this.gridColumn16.set_Caption("gridColumn16");
			this.gridColumn16.set_FieldName("degisti");
			this.gridColumn16.set_Name("gridColumn16");
			this.simpleButton1.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.get_Appearance().get_Options().set_UseTextOptions(true);
			this.simpleButton1.get_Appearance().get_TextOptions().set_WordWrap(2);
			this.simpleButton1.Location = new Point(527, 7);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(157, 86);
			this.simpleButton1.set_StyleController(this.layoutControl2);
			this.simpleButton1.TabIndex = 1;
			this.simpleButton1.Text = "SEÇİLEN BİLGİLERİ AKTAR";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.layoutControl2.Controls.Add(this.gridControl1);
			this.layoutControl2.Controls.Add(this.simpleButton2);
			this.layoutControl2.Controls.Add(this.simpleButton1);
			this.layoutControl2.Controls.Add(this.simpleButton3);
			this.layoutControl2.Controls.Add(this.groupControl1);
			this.layoutControl2.Dock = DockStyle.Fill;
			this.layoutControl2.Location = new Point(0, 0);
			this.layoutControl2.Name = "layoutControl2";
			this.layoutControl2.set_Root(this.layoutControlGroup2);
			this.layoutControl2.Size = new Size(1013, 554);
			this.layoutControl2.TabIndex = 14;
			this.layoutControl2.Text = "layoutControl2";
			this.simpleButton2.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton2.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton2.get_Appearance().get_Options().set_UseTextOptions(true);
			this.simpleButton2.get_Appearance().get_TextOptions().set_WordWrap(2);
			this.simpleButton2.Location = new Point(849, 7);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(157, 86);
			this.simpleButton2.set_StyleController(this.layoutControl2);
			this.simpleButton2.TabIndex = 3;
			this.simpleButton2.Text = "LİSTEDE YOKSA EKLEYİNİZ";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			this.simpleButton3.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton3.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton3.get_Appearance().get_Options().set_UseTextOptions(true);
			this.simpleButton3.get_Appearance().get_TextOptions().set_WordWrap(2);
			this.simpleButton3.Location = new Point(688, 7);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new Size(157, 86);
			this.simpleButton3.set_StyleController(this.layoutControl2);
			this.simpleButton3.TabIndex = 2;
			this.simpleButton3.Text = "TEKNİK RESİM GÖR";
			this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
			this.layoutControlGroup2.set_CustomizationFormText("layoutControlGroup2");
			this.layoutControlGroup2.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup2.set_GroupBordersVisible(false);
			this.layoutControlGroup2.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem9,
				this.layoutControlItem11,
				this.layoutControlItem10,
				this.layoutControlItem12,
				this.layoutControlItem13
			});
			this.layoutControlGroup2.set_Location(new Point(0, 0));
			this.layoutControlGroup2.set_Name("layoutControlGroup2");
			this.layoutControlGroup2.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup2.set_Size(new Size(1013, 554));
			this.layoutControlGroup2.set_TextVisible(false);
			this.layoutControlItem9.set_Control(this.groupControl1);
			this.layoutControlItem9.set_CustomizationFormText("layoutControlItem9");
			this.layoutControlItem9.set_Location(new Point(0, 0));
			this.layoutControlItem9.set_MinSize(new Size(104, 90));
			this.layoutControlItem9.set_Name("layoutControlItem9");
			this.layoutControlItem9.set_Size(new Size(520, 90));
			this.layoutControlItem9.set_SizeConstraintsType(2);
			this.layoutControlItem9.set_TextSize(new Size(0, 0));
			this.layoutControlItem9.set_TextVisible(false);
			this.layoutControlItem11.set_Control(this.simpleButton1);
			this.layoutControlItem11.set_CustomizationFormText("layoutControlItem11");
			this.layoutControlItem11.set_Location(new Point(520, 0));
			this.layoutControlItem11.set_MaxSize(new Size(161, 0));
			this.layoutControlItem11.set_MinSize(new Size(143, 1));
			this.layoutControlItem11.set_Name("layoutControlItem11");
			this.layoutControlItem11.set_Size(new Size(161, 90));
			this.layoutControlItem11.set_SizeConstraintsType(2);
			this.layoutControlItem11.set_TextSize(new Size(0, 0));
			this.layoutControlItem11.set_TextVisible(false);
			this.layoutControlItem10.set_Control(this.gridControl1);
			this.layoutControlItem10.set_CustomizationFormText("layoutControlItem10");
			this.layoutControlItem10.set_Location(new Point(0, 90));
			this.layoutControlItem10.set_Name("layoutControlItem10");
			this.layoutControlItem10.set_Size(new Size(1003, 454));
			this.layoutControlItem10.set_TextSize(new Size(0, 0));
			this.layoutControlItem10.set_TextVisible(false);
			this.layoutControlItem12.set_Control(this.simpleButton3);
			this.layoutControlItem12.set_CustomizationFormText("layoutControlItem12");
			this.layoutControlItem12.set_Location(new Point(681, 0));
			this.layoutControlItem12.set_MaxSize(new Size(161, 0));
			this.layoutControlItem12.set_MinSize(new Size(146, 26));
			this.layoutControlItem12.set_Name("layoutControlItem12");
			this.layoutControlItem12.set_Size(new Size(161, 90));
			this.layoutControlItem12.set_SizeConstraintsType(2);
			this.layoutControlItem12.set_TextSize(new Size(0, 0));
			this.layoutControlItem12.set_TextVisible(false);
			this.layoutControlItem13.set_Control(this.simpleButton2);
			this.layoutControlItem13.set_CustomizationFormText("layoutControlItem13");
			this.layoutControlItem13.set_Location(new Point(842, 0));
			this.layoutControlItem13.set_MaxSize(new Size(161, 0));
			this.layoutControlItem13.set_MinSize(new Size(161, 26));
			this.layoutControlItem13.set_Name("layoutControlItem13");
			this.layoutControlItem13.set_Size(new Size(161, 90));
			this.layoutControlItem13.set_SizeConstraintsType(2);
			this.layoutControlItem13.set_TextSize(new Size(0, 0));
			this.layoutControlItem13.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1013, 554);
			base.Controls.Add(this.layoutControl2);
			this.MaximumSize = new Size(1029, 593);
			this.MinimumSize = new Size(1029, 593);
			base.Name = "makmot";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "MOTOR BİLGİSİ SEÇME, GÖRME VE EKLEME";
			base.Load += new EventHandler(this.makmot_Load);
			this.groupControl1.EndInit();
			this.groupControl1.ResumeLayout(false);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.textEdit3.get_Properties().EndInit();
			this.checkEdit3.get_Properties().EndInit();
			this.textEdit2.get_Properties().EndInit();
			this.checkEdit2.get_Properties().EndInit();
			this.textEdit1.get_Properties().EndInit();
			this.checkEdit1.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem6.EndInit();
			this.gridControl1.EndInit();
			this.gridView1.EndInit();
			this.repositoryItemHyperLinkEdit1.EndInit();
			this.repositoryItemHyperLinkEdit2.EndInit();
			this.layoutControl2.EndInit();
			this.layoutControl2.ResumeLayout(false);
			this.layoutControlGroup2.EndInit();
			this.layoutControlItem9.EndInit();
			this.layoutControlItem11.EndInit();
			this.layoutControlItem10.EndInit();
			this.layoutControlItem12.EndInit();
			this.layoutControlItem13.EndInit();
			base.ResumeLayout(false);
		}
	}
}
