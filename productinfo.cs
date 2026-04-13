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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ascad
{
	public class productinfo : Form
	{
		public string urunne = "";

		private abc1 xx = new abc1();

		private string secilengui = "";

		private IContainer components = null;

		private SimpleButton simpleButton1;

		private TextEdit textEdit1;

		private GridControl gridControl1;

		private GridView gridView1;

		private GridColumn gridColumn1;

		private GridColumn gridColumn2;

		private GridColumn gridColumn3;

		private GridColumn gridColumn4;

		private GridControl gridControl2;

		private GridView gridView2;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private LayoutControlItem layoutControlItem3;

		private LayoutControlItem layoutControlItem4;

		private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;

		private SimpleButton simpleButton2;

		private LayoutControlItem layoutControlItem5;

		private SimpleButton simpleButton3;

		private LayoutControlItem layoutControlItem6;

		private PictureBox pictureBox1;

		private LayoutControlItem layoutControlItem7;

		public productinfo()
		{
			this.InitializeComponent();
		}

		private void uretgetir()
		{
			this.gridControl1.set_DataSource(this.xx.dtta("select * from " + this.urunne + "marka", ""));
		}

		private void raybilgileri_Load(object sender, EventArgs e)
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			this.uretgetir();
			bool flag = File.Exists(directoryName + "\\img\\" + this.urunne + ".png");
			if (flag)
			{
				this.pictureBox1.ImageLocation = directoryName + "\\img\\" + this.urunne + ".png";
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.xx.oleupdate(string.Concat(new object[]
			{
				"insert into ",
				this.urunne,
				"marka(marka,iskonto,guid) values('",
				this.textEdit1.Text,
				"',20,'",
				Guid.NewGuid(),
				"') "
			}), "");
			this.uretgetir();
		}

		private void prdgetir(string guii)
		{
			this.gridControl2.set_DataSource(this.xx.dtta(string.Concat(new string[]
			{
				"SELECT rm.marka ,r.* from ",
				this.urunne,
				" r , ",
				this.urunne,
				"marka rm where r.markaguid = rm.guid and rm.guid='",
				guii,
				"'"
			}), ""));
			bool flag = this.gridView2.get_RowCount() > 0;
			if (flag)
			{
				this.gridView2.get_Columns().get_Item("sno").set_Visible(false);
				this.gridView2.get_Columns().get_Item("marka").get_OptionsColumn().set_AllowEdit(false);
				this.gridView2.get_Columns().get_Item("guid").set_Visible(false);
				this.gridView2.get_Columns().get_Item("markaguid").set_Visible(false);
			}
		}

		private void gridView1_MouseDown(object sender, MouseEventArgs e)
		{
			GridView gridView = sender as GridView;
			GridHitInfo gridHitInfo = gridView.CalcHitInfo(this.gridControl1.PointToClient(Control.MousePosition));
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				bool flag2 = gridHitInfo.get_InRowCell() && gridHitInfo.get_RowHandle() >= 0 && gridHitInfo.get_Column().get_FieldName() == "marka";
				if (flag2)
				{
					this.prdgetir(this.gridView1.GetRowCellValue(gridHitInfo.get_RowHandle(), "guid").ToString());
					this.secilengui = this.gridView1.GetRowCellValue(gridHitInfo.get_RowHandle(), "guid").ToString();
				}
			}
		}

		private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			this.xx.oleupdate(string.Concat(new string[]
			{
				"update ",
				this.urunne,
				"marka set iskonto = ",
				this.gridView1.GetRowCellValue(e.get_RowHandle(), "iskonto").ToString(),
				" where sno=",
				this.gridView1.GetRowCellValue(e.get_RowHandle(), "sno").ToString()
			}), "");
		}

		private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			this.xx.oleupdate(this.xx.hucredeupdate("update " + this.urunne + " set  ", e.get_Column().get_ColumnType().ToString(), e.get_Column().get_FieldName(), e.get_Value().ToString(), " where sno=" + this.gridView2.GetRowCellValue(e.get_RowHandle(), "sno").ToString()), "");
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this.secilengui);
			if (flag)
			{
				MessageBox.Show("Bir Üretici Seçemeniz gerekli!!!");
			}
			else
			{
				bool flag2 = MessageBox.Show("Ana Tablodan ekleme iste misiniz?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
				if (flag2)
				{
					new masterproduct
					{
						urunne = this.urunne,
						guidne = this.secilengui
					}.ShowDialog();
					this.prdgetir(this.secilengui);
				}
				else
				{
					this.xx.oleupdate(string.Concat(new string[]
					{
						"insert into ",
						this.urunne,
						"(guid,markaguid) select UUID(),'",
						this.secilengui,
						"'"
					}), "");
					this.prdgetir(this.secilengui);
				}
			}
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			this.xx.oleupdate(string.Concat(new string[]
			{
				"insert into ",
				this.urunne,
				"(guid,markaguid) select UUID(),'",
				this.secilengui,
				"'"
			}), "");
			this.prdgetir(this.secilengui);
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
			this.simpleButton1 = new SimpleButton();
			this.layoutControl1 = new LayoutControl();
			this.pictureBox1 = new PictureBox();
			this.simpleButton3 = new SimpleButton();
			this.simpleButton2 = new SimpleButton();
			this.gridControl2 = new GridControl();
			this.gridView2 = new GridView();
			this.textEdit1 = new TextEdit();
			this.gridControl1 = new GridControl();
			this.gridView1 = new GridView();
			this.gridColumn1 = new GridColumn();
			this.gridColumn2 = new GridColumn();
			this.repositoryItemHyperLinkEdit1 = new RepositoryItemHyperLinkEdit();
			this.gridColumn3 = new GridColumn();
			this.gridColumn4 = new GridColumn();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.gridControl2.BeginInit();
			this.gridView2.BeginInit();
			this.textEdit1.get_Properties().BeginInit();
			this.gridControl1.BeginInit();
			this.gridView1.BeginInit();
			this.repositoryItemHyperLinkEdit1.BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem2.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem7.BeginInit();
			base.SuspendLayout();
			this.simpleButton1.get_Appearance().set_Font(new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton1.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton1.Location = new Point(898, 7);
			this.simpleButton1.Margin = new Padding(2);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(261, 24);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 1;
			this.simpleButton1.Text = "YENİ MARKA EKLE";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.layoutControl1.Controls.Add(this.pictureBox1);
			this.layoutControl1.Controls.Add(this.simpleButton3);
			this.layoutControl1.Controls.Add(this.simpleButton2);
			this.layoutControl1.Controls.Add(this.gridControl2);
			this.layoutControl1.Controls.Add(this.textEdit1);
			this.layoutControl1.Controls.Add(this.gridControl1);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Margin = new Padding(2);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.get_OptionsCustomizationForm().set_DesignTimeCustomizationFormPositionAndSize(new Rectangle?(new Rectangle(260, 152, 250, 350)));
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(1166, 722);
			this.layoutControl1.TabIndex = 5;
			this.layoutControl1.Text = "layoutControl1";
			this.pictureBox1.Location = new Point(7, 448);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(301, 267);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			this.simpleButton3.get_Appearance().set_Font(new Font("Tahoma", 10.2f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162));
			this.simpleButton3.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton3.Location = new Point(737, 35);
			this.simpleButton3.Margin = new Padding(2);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.Size = new Size(422, 24);
			this.simpleButton3.set_StyleController(this.layoutControl1);
			this.simpleButton3.TabIndex = 6;
			this.simpleButton3.Text = "ÜRETİCİYE YENİ ÜRÜN EKLEME";
			this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
			this.simpleButton2.get_Appearance().set_Font(new Font("Tahoma", 10.2f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162));
			this.simpleButton2.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton2.Location = new Point(312, 35);
			this.simpleButton2.Margin = new Padding(2);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(421, 24);
			this.simpleButton2.set_StyleController(this.layoutControl1);
			this.simpleButton2.TabIndex = 5;
			this.simpleButton2.Text = "ÜRETİCİYE  ŞABLONDAN ÜRÜNLER EKLEME";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			this.gridControl2.get_EmbeddedNavigator().Margin = new Padding(2);
			this.gridControl2.Location = new Point(312, 63);
			this.gridControl2.set_MainView(this.gridView2);
			this.gridControl2.Margin = new Padding(2);
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new Size(847, 652);
			this.gridControl2.TabIndex = 4;
			this.gridControl2.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView2
			});
			this.gridView2.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_Row().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView2.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView2.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView2.set_GridControl(this.gridControl2);
			this.gridView2.set_Name("gridView2");
			this.gridView2.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView2.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView2_CellValueChanged));
			this.textEdit1.Location = new Point(112, 7);
			this.textEdit1.Margin = new Padding(2);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.textEdit1.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.textEdit1.Size = new Size(782, 24);
			this.textEdit1.set_StyleController(this.layoutControl1);
			this.textEdit1.TabIndex = 2;
			this.gridControl1.get_EmbeddedNavigator().Margin = new Padding(2);
			this.gridControl1.Location = new Point(7, 35);
			this.gridControl1.set_MainView(this.gridView1);
			this.gridControl1.Margin = new Padding(2);
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.get_RepositoryItems().AddRange(new RepositoryItem[]
			{
				this.repositoryItemHyperLinkEdit1
			});
			this.gridControl1.Size = new Size(301, 409);
			this.gridControl1.TabIndex = 3;
			this.gridControl1.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView1
			});
			this.gridView1.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedRow().set_BackColor(Color.FromArgb(192, 255, 192));
			this.gridView1.get_Appearance().get_FocusedRow().set_BorderColor(Color.Black);
			this.gridView1.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedRow().get_Options().set_UseBackColor(true);
			this.gridView1.get_Appearance().get_FocusedRow().get_Options().set_UseBorderColor(true);
			this.gridView1.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Row().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_SelectedRow().set_BackColor(Color.FromArgb(128, 255, 128));
			this.gridView1.get_Appearance().get_SelectedRow().set_BorderColor(Color.Black);
			this.gridView1.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_SelectedRow().get_Options().set_UseBackColor(true);
			this.gridView1.get_Appearance().get_SelectedRow().get_Options().set_UseBorderColor(true);
			this.gridView1.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView1.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn1,
				this.gridColumn2,
				this.gridColumn3,
				this.gridColumn4
			});
			this.gridView1.set_GridControl(this.gridControl1);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsView().set_ShowGroupPanel(false);
			this.gridView1.add_CellValueChanged(new CellValueChangedEventHandler(this.gridView1_CellValueChanged));
			this.gridView1.add_MouseDown(new MouseEventHandler(this.gridView1_MouseDown));
			this.gridColumn1.set_Caption("gridColumn1");
			this.gridColumn1.set_FieldName("guid");
			this.gridColumn1.set_Name("gridColumn1");
			this.gridColumn2.set_Caption("Marka");
			this.gridColumn2.set_ColumnEdit(this.repositoryItemHyperLinkEdit1);
			this.gridColumn2.set_FieldName("marka");
			this.gridColumn2.set_Name("gridColumn2");
			this.gridColumn2.set_Visible(true);
			this.gridColumn2.set_VisibleIndex(0);
			this.gridColumn2.set_Width(203);
			this.repositoryItemHyperLinkEdit1.set_AutoHeight(false);
			this.repositoryItemHyperLinkEdit1.set_Name("repositoryItemHyperLinkEdit1");
			this.gridColumn3.set_Caption("İskonto");
			this.gridColumn3.set_FieldName("iskonto");
			this.gridColumn3.set_Name("gridColumn3");
			this.gridColumn3.set_Visible(true);
			this.gridColumn3.set_VisibleIndex(1);
			this.gridColumn3.set_Width(132);
			this.gridColumn4.set_Caption("Sno");
			this.gridColumn4.set_FieldName("sno");
			this.gridColumn4.set_Name("gridColumn4");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem3,
				this.layoutControlItem4,
				this.layoutControlItem5,
				this.layoutControlItem6,
				this.layoutControlItem7
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("Root");
			this.layoutControlGroup1.get_OptionsItemText().set_TextToControlDistance(4);
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(1166, 722));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.layoutControlItem1.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.layoutControlItem1.set_Control(this.textEdit1);
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(891, 28));
			this.layoutControlItem1.set_Text("ÜRETİCİ İSMİ");
			this.layoutControlItem1.set_TextSize(new Size(101, 17));
			this.layoutControlItem2.set_Control(this.simpleButton1);
			this.layoutControlItem2.set_Location(new Point(891, 0));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(265, 28));
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			this.layoutControlItem3.set_Control(this.gridControl1);
			this.layoutControlItem3.set_Location(new Point(0, 28));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(305, 413));
			this.layoutControlItem3.set_TextSize(new Size(0, 0));
			this.layoutControlItem3.set_TextVisible(false);
			this.layoutControlItem4.set_Control(this.gridControl2);
			this.layoutControlItem4.set_Location(new Point(305, 56));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(851, 656));
			this.layoutControlItem4.set_TextSize(new Size(0, 0));
			this.layoutControlItem4.set_TextVisible(false);
			this.layoutControlItem5.set_Control(this.simpleButton2);
			this.layoutControlItem5.set_Location(new Point(305, 28));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(425, 28));
			this.layoutControlItem5.set_TextSize(new Size(0, 0));
			this.layoutControlItem5.set_TextVisible(false);
			this.layoutControlItem6.set_Control(this.simpleButton3);
			this.layoutControlItem6.set_Location(new Point(730, 28));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(426, 28));
			this.layoutControlItem6.set_TextSize(new Size(0, 0));
			this.layoutControlItem6.set_TextVisible(false);
			this.layoutControlItem7.set_Control(this.pictureBox1);
			this.layoutControlItem7.set_Location(new Point(0, 441));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(305, 271));
			this.layoutControlItem7.set_TextSize(new Size(0, 0));
			this.layoutControlItem7.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1166, 722);
			base.Controls.Add(this.layoutControl1);
			base.Margin = new Padding(2);
			base.Name = "productinfo";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ÜRETİCİ BİLGİLERİ";
			base.Load += new EventHandler(this.raybilgileri_Load);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.gridControl2.EndInit();
			this.gridView2.EndInit();
			this.textEdit1.get_Properties().EndInit();
			this.gridControl1.EndInit();
			this.gridView1.EndInit();
			this.repositoryItemHyperLinkEdit1.EndInit();
			this.layoutControlGroup1.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem2.EndInit();
			this.layoutControlItem3.EndInit();
			this.layoutControlItem4.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem7.EndInit();
			base.ResumeLayout(false);
		}
	}
}
