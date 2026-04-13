namespace ascad
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraLayout;
    using DevExpress.XtraLayout.Utils;
    using DevExpress.XtraTab;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class ascadpalet : UserControl
    {
        private TextEdit agrtaneagr;
        private GridControl antetgrid;
        public ascad.ascad AscadDLL;
        private CheckEdit beyamqpisuserdefined;
        private TextEdit BeyanHiz;
        private TextEdit BeyanKisi;
        private TextEdit BeyanYuk;
        private IContainer components = null;
        private TextEdit dengekatsay;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridView gridView1;
        private GroupControl groupControl13;
        private TextEdit HalatAdet;
        private TextEdit HalatCap;
        private double kabinalan = 0.0;
        public TextEdit kabinderx;
        public TextEdit kabingenx;
        private TextEdit KabinP;
        private TextEdit KapiH;
        private CheckEdit KapiKirisProfil;
        private CheckEdit KapiKorKasa;
        private TextEdit karkasagr;
        private TextEdit KasaDer;
        private TextEdit KasaGen;
        private TreeList kesitlayertree;
        private SearchLookUpEdit kesitlayeryapi;
        private TextEdit KizakKalin;
        private Label label1;
        private LabelControl labelControl1;
        private LabelControl labelControl11;
        private LabelControl labelControl12;
        private LabelControl labelControl13;
        private LabelControl labelControl14;
        private LabelControl labelControl15;
        private LabelControl labelControl17;
        private LabelControl labelControl2;
        private LabelControl labelControl24;
        private LabelControl labelControl25;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl7;
        private LabelControl labelControl8;
        private int layeracikcolumn;
        private int layeradcolumn;
        private LayoutControl layoutControl2;
        private LayoutControl layoutControl7;
        private LayoutControlGroup layoutControlGroup2;
        private LayoutControlGroup layoutControlGroup7;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem109;
        private LayoutControlItem layoutControlItem11;
        private LayoutControlItem layoutControlItem110;
        private LayoutControlItem layoutControlItem116;
        private LayoutControlItem layoutControlItem117;
        private LayoutControlItem layoutControlItem118;
        private LayoutControlItem layoutControlItem12;
        private LayoutControlItem layoutControlItem129;
        private LayoutControlItem layoutControlItem13;
        private LayoutControlItem layoutControlItem130;
        private LayoutControlItem layoutControlItem14;
        private LayoutControlItem layoutControlItem15;
        private LayoutControlItem layoutControlItem16;
        private LayoutControlItem layoutControlItem17;
        private LayoutControlItem layoutControlItem18;
        private LayoutControlItem layoutControlItem19;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem20;
        private LayoutControlItem layoutControlItem21;
        private LayoutControlItem layoutControlItem22;
        private LayoutControlItem layoutControlItem23;
        private LayoutControlItem layoutControlItem24;
        private LayoutControlItem layoutControlItem25;
        private LayoutControlItem layoutControlItem26;
        private LayoutControlItem layoutControlItem27;
        private LayoutControlItem layoutControlItem28;
        private LayoutControlItem layoutControlItem29;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem30;
        private LayoutControlItem layoutControlItem31;
        private LayoutControlItem layoutControlItem32;
        private LayoutControlItem layoutControlItem33;
        private LayoutControlItem layoutControlItem34;
        private LayoutControlItem layoutControlItem35;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem61;
        private LayoutControlItem layoutControlItem63;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem layoutControlItem9;
        private LinkLabel linkLabel1;
        private TextEdit MotorKw;
        private XtraTabControl ObjectDefine;
        private List<string> objelistesi = new List<string>();
        private TextEdit OtoKabinEsik;
        private LinkLabel pqtop;
        private TextEdit SapCap;
        private GridView searchLookUpEdit1View;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton18;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private SimpleButton submitbutton;
        private TextEdit TahCap;
        private TextEdit ToplamKalin;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;
        private XtraTabPage xtraTabPage5;
        private XtraTabPage xtraTabPage6;
        private XtraTabPage xtraTabPage7;
        private XtraTabPage xtraTabPage8;
        private abc1 xx2 = new abc1();

        public ascadpalet()
        {
            this.InitializeComponent();
        }

        private void agirlikhesapla()
        {
            try
            {
                decimal d = (Convert.ToDecimal(this.KabinP.Text) - Convert.ToDecimal(this.karkasagr.Text)) + (Convert.ToDecimal(this.BeyanYuk.Text) * Convert.ToDecimal(this.dengekatsay.Text));
                d /= Convert.ToDecimal(this.agrtaneagr.Text);
                d = Math.Round(d, 0, MidpointRounding.AwayFromZero);
                this.labelControl5.Text = "GEREKLİ AĞIRLIK ADEDİ : " + d;
            }
            catch (Exception)
            {
            }
        }

        private void ascadpalet_Load(object sender, EventArgs e)
        {
            this.kesitlayertree.DataSource = this.xx2.dtta("select * from kesitler", "");
            this.kesitlayertree.ExpandAll();
            this.antetgrid.DataSource = this.xx2.dtta("select * from Num1 where Comment='ANTET'", "");
            this.layeracikcolumn = this.kesitlayertree.Columns["aktifmi"].AbsoluteIndex;
            this.layeracikcolumn = this.kesitlayertree.Columns["layername"].AbsoluteIndex;
        }

        private void beyamqpisuserdefined_CheckedChanged(object sender, EventArgs e)
        {
            if (this.beyamqpisuserdefined.Checked)
            {
                this.BeyanYuk.Enabled = true;
                this.BeyanKisi.Enabled = true;
            }
        }

        private void BeyanYuk_EditValueChanged(object sender, EventArgs e)
        {
            this.agirlikhesapla();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private int dondurbana(string gelen)
        {
            int index = 0;
            if (this.objelistesi.Count == 0)
            {
                this.objelistesi.Add("Gorsel");
                this.objelistesi.Add("Ozellik");
                this.objelistesi.Add("CizimBilgi");
                this.objelistesi.Add("RegUst");
                this.objelistesi.Add("Suspansiyon");
                this.objelistesi.Add("KabinRay");
                this.objelistesi.Add("Kar");
                this.objelistesi.Add("KapiIc");
                this.objelistesi.Add("AgrUst");
                this.objelistesi.Add("Tampon");
            }
            if (this.objelistesi.Contains(gelen))
            {
                index = this.objelistesi.IndexOf(gelen);
            }
            return index;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.xx2.oleupdate("update Num1 set " + e.Column.FieldName + " ='" + e.Value.ToString() + "' where ParamName='" + this.gridView1.GetRowCellValue(e.RowHandle, "ParamName").ToString() + "'", "");
        }

        private void InitializeComponent()
        {
            this.submitbutton = new SimpleButton();
            this.ObjectDefine = new XtraTabControl();
            this.xtraTabPage1 = new XtraTabPage();
            this.antetgrid = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn1 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.xtraTabPage6 = new XtraTabPage();
            this.layoutControl2 = new LayoutControl();
            this.labelControl5 = new LabelControl();
            this.dengekatsay = new TextEdit();
            this.labelControl25 = new LabelControl();
            this.agrtaneagr = new TextEdit();
            this.labelControl24 = new LabelControl();
            this.simpleButton3 = new SimpleButton();
            this.karkasagr = new TextEdit();
            this.simpleButton18 = new SimpleButton();
            this.beyamqpisuserdefined = new CheckEdit();
            this.HalatCap = new TextEdit();
            this.labelControl17 = new LabelControl();
            this.labelControl15 = new LabelControl();
            this.labelControl14 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.labelControl13 = new LabelControl();
            this.pqtop = new LinkLabel();
            this.labelControl12 = new LabelControl();
            this.labelControl7 = new LabelControl();
            this.labelControl8 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.TahCap = new TextEdit();
            this.HalatAdet = new TextEdit();
            this.SapCap = new TextEdit();
            this.MotorKw = new TextEdit();
            this.labelControl11 = new LabelControl();
            this.KabinP = new TextEdit();
            this.kabingenx = new TextEdit();
            this.BeyanHiz = new TextEdit();
            this.BeyanYuk = new TextEdit();
            this.kabinderx = new TextEdit();
            this.linkLabel1 = new LinkLabel();
            this.BeyanKisi = new TextEdit();
            this.layoutControlGroup2 = new LayoutControlGroup();
            this.layoutControlItem3 = new LayoutControlItem();
            this.layoutControlItem8 = new LayoutControlItem();
            this.layoutControlItem10 = new LayoutControlItem();
            this.layoutControlItem12 = new LayoutControlItem();
            this.layoutControlItem16 = new LayoutControlItem();
            this.layoutControlItem18 = new LayoutControlItem();
            this.layoutControlItem20 = new LayoutControlItem();
            this.layoutControlItem21 = new LayoutControlItem();
            this.layoutControlItem4 = new LayoutControlItem();
            this.layoutControlItem5 = new LayoutControlItem();
            this.layoutControlItem13 = new LayoutControlItem();
            this.layoutControlItem14 = new LayoutControlItem();
            this.layoutControlItem15 = new LayoutControlItem();
            this.layoutControlItem17 = new LayoutControlItem();
            this.layoutControlItem19 = new LayoutControlItem();
            this.layoutControlItem11 = new LayoutControlItem();
            this.layoutControlItem22 = new LayoutControlItem();
            this.layoutControlItem23 = new LayoutControlItem();
            this.layoutControlItem25 = new LayoutControlItem();
            this.layoutControlItem27 = new LayoutControlItem();
            this.layoutControlItem28 = new LayoutControlItem();
            this.layoutControlItem29 = new LayoutControlItem();
            this.layoutControlItem30 = new LayoutControlItem();
            this.layoutControlItem32 = new LayoutControlItem();
            this.layoutControlItem116 = new LayoutControlItem();
            this.layoutControlItem6 = new LayoutControlItem();
            this.layoutControlItem34 = new LayoutControlItem();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem33 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.layoutControlItem7 = new LayoutControlItem();
            this.layoutControlItem9 = new LayoutControlItem();
            this.layoutControlItem31 = new LayoutControlItem();
            this.layoutControlItem24 = new LayoutControlItem();
            this.xtraTabPage2 = new XtraTabPage();
            this.kesitlayeryapi = new SearchLookUpEdit();
            this.searchLookUpEdit1View = new GridView();
            this.kesitlayertree = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn5 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.simpleButton2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.xtraTabPage3 = new XtraTabPage();
            this.xtraTabPage4 = new XtraTabPage();
            this.xtraTabPage5 = new XtraTabPage();
            this.xtraTabPage7 = new XtraTabPage();
            this.xtraTabPage8 = new XtraTabPage();
            this.groupControl13 = new GroupControl();
            this.layoutControl7 = new LayoutControl();
            this.KapiKirisProfil = new CheckEdit();
            this.KapiKorKasa = new CheckEdit();
            this.KasaDer = new TextEdit();
            this.KasaGen = new TextEdit();
            this.KapiH = new TextEdit();
            this.KizakKalin = new TextEdit();
            this.ToplamKalin = new TextEdit();
            this.OtoKabinEsik = new TextEdit();
            this.layoutControlGroup7 = new LayoutControlGroup();
            this.layoutControlItem61 = new LayoutControlItem();
            this.layoutControlItem63 = new LayoutControlItem();
            this.layoutControlItem109 = new LayoutControlItem();
            this.layoutControlItem110 = new LayoutControlItem();
            this.layoutControlItem117 = new LayoutControlItem();
            this.layoutControlItem118 = new LayoutControlItem();
            this.layoutControlItem129 = new LayoutControlItem();
            this.layoutControlItem130 = new LayoutControlItem();
            this.layoutControlItem26 = new LayoutControlItem();
            this.label1 = new Label();
            this.layoutControlItem35 = new LayoutControlItem();
            this.ObjectDefine.BeginInit();
            this.ObjectDefine.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.antetgrid.BeginInit();
            this.gridView1.BeginInit();
            this.xtraTabPage6.SuspendLayout();
            this.layoutControl2.BeginInit();
            this.layoutControl2.SuspendLayout();
            this.dengekatsay.Properties.BeginInit();
            this.agrtaneagr.Properties.BeginInit();
            this.karkasagr.Properties.BeginInit();
            this.beyamqpisuserdefined.Properties.BeginInit();
            this.HalatCap.Properties.BeginInit();
            this.TahCap.Properties.BeginInit();
            this.HalatAdet.Properties.BeginInit();
            this.SapCap.Properties.BeginInit();
            this.MotorKw.Properties.BeginInit();
            this.KabinP.Properties.BeginInit();
            this.kabingenx.Properties.BeginInit();
            this.BeyanHiz.Properties.BeginInit();
            this.BeyanYuk.Properties.BeginInit();
            this.kabinderx.Properties.BeginInit();
            this.BeyanKisi.Properties.BeginInit();
            this.layoutControlGroup2.BeginInit();
            this.layoutControlItem3.BeginInit();
            this.layoutControlItem8.BeginInit();
            this.layoutControlItem10.BeginInit();
            this.layoutControlItem12.BeginInit();
            this.layoutControlItem16.BeginInit();
            this.layoutControlItem18.BeginInit();
            this.layoutControlItem20.BeginInit();
            this.layoutControlItem21.BeginInit();
            this.layoutControlItem4.BeginInit();
            this.layoutControlItem5.BeginInit();
            this.layoutControlItem13.BeginInit();
            this.layoutControlItem14.BeginInit();
            this.layoutControlItem15.BeginInit();
            this.layoutControlItem17.BeginInit();
            this.layoutControlItem19.BeginInit();
            this.layoutControlItem11.BeginInit();
            this.layoutControlItem22.BeginInit();
            this.layoutControlItem23.BeginInit();
            this.layoutControlItem25.BeginInit();
            this.layoutControlItem27.BeginInit();
            this.layoutControlItem28.BeginInit();
            this.layoutControlItem29.BeginInit();
            this.layoutControlItem30.BeginInit();
            this.layoutControlItem32.BeginInit();
            this.layoutControlItem116.BeginInit();
            this.layoutControlItem6.BeginInit();
            this.layoutControlItem34.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem33.BeginInit();
            this.layoutControlItem2.BeginInit();
            this.layoutControlItem7.BeginInit();
            this.layoutControlItem9.BeginInit();
            this.layoutControlItem31.BeginInit();
            this.layoutControlItem24.BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.kesitlayeryapi.Properties.BeginInit();
            this.searchLookUpEdit1View.BeginInit();
            this.kesitlayertree.BeginInit();
            this.xtraTabPage8.SuspendLayout();
            this.groupControl13.BeginInit();
            this.groupControl13.SuspendLayout();
            this.layoutControl7.BeginInit();
            this.layoutControl7.SuspendLayout();
            this.KapiKirisProfil.Properties.BeginInit();
            this.KapiKorKasa.Properties.BeginInit();
            this.KasaDer.Properties.BeginInit();
            this.KasaGen.Properties.BeginInit();
            this.KapiH.Properties.BeginInit();
            this.KizakKalin.Properties.BeginInit();
            this.ToplamKalin.Properties.BeginInit();
            this.OtoKabinEsik.Properties.BeginInit();
            this.layoutControlGroup7.BeginInit();
            this.layoutControlItem61.BeginInit();
            this.layoutControlItem63.BeginInit();
            this.layoutControlItem109.BeginInit();
            this.layoutControlItem110.BeginInit();
            this.layoutControlItem117.BeginInit();
            this.layoutControlItem118.BeginInit();
            this.layoutControlItem129.BeginInit();
            this.layoutControlItem130.BeginInit();
            this.layoutControlItem26.BeginInit();
            this.layoutControlItem35.BeginInit();
            base.SuspendLayout();
            this.submitbutton.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.submitbutton.Appearance.Options.UseFont = true;
            this.submitbutton.Location = new Point(7, 0x2c1);
            this.submitbutton.Margin = new System.Windows.Forms.Padding(2);
            this.submitbutton.Name = "submitbutton";
            this.submitbutton.Size = new Size(0x129, 0x38);
            this.submitbutton.StyleController = this.layoutControl2;
            this.submitbutton.TabIndex = 0;
            this.submitbutton.Text = "KAYDET-UYGULA";
            this.submitbutton.Click += new EventHandler(this.simpleButton1_Click);
            this.ObjectDefine.AppearancePage.Header.Font = new Font("Tahoma", 10f);
            this.ObjectDefine.AppearancePage.Header.Options.UseFont = true;
            this.ObjectDefine.Dock = DockStyle.Fill;
            this.ObjectDefine.Location = new Point(0, 0);
            this.ObjectDefine.Name = "ObjectDefine";
            this.ObjectDefine.SelectedTabPage = this.xtraTabPage1;
            this.ObjectDefine.Size = new Size(0x13d, 0x31f);
            this.ObjectDefine.TabIndex = 5;
            XtraTabPage[] pages = new XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage6, this.xtraTabPage2, this.xtraTabPage3, this.xtraTabPage4, this.xtraTabPage5, this.xtraTabPage7, this.xtraTabPage8 };
            this.ObjectDefine.TabPages.AddRange(pages);
            this.xtraTabPage1.Controls.Add(this.antetgrid);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new Size(0x137, 0x300);
            this.xtraTabPage1.Text = "ANTET";
            this.antetgrid.Dock = DockStyle.Fill;
            this.antetgrid.Location = new Point(0, 0);
            this.antetgrid.MainView = this.gridView1;
            this.antetgrid.Name = "antetgrid";
            this.antetgrid.Size = new Size(0x137, 0x300);
            this.antetgrid.TabIndex = 2;
            BaseView[] views = new BaseView[] { this.gridView1 };
            this.antetgrid.ViewCollection.AddRange(views);
            this.gridView1.Appearance.ColumnFilterButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gridView1.Appearance.CustomizationFormHint.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gridView1.Appearance.DetailTip.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.DetailTip.Options.UseFont = true;
            this.gridView1.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FilterCloseButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView1.Appearance.FilterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FixedLine.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupButton.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.TopNewRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            GridColumn[] columns = new GridColumn[] { this.gridColumn1, this.gridColumn2, this.gridColumn3 };
            this.gridView1.Columns.AddRange(columns);
            this.gridView1.GridControl = this.antetgrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridColumn1.AppearanceCell.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "formvisual";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "ParamValue";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "ParamName";
            this.gridColumn3.Name = "gridColumn3";
            this.xtraTabPage6.Controls.Add(this.layoutControl2);
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new Size(0x137, 0x300);
            this.xtraTabPage6.Text = "\x00d6ZELLİKLER";
            this.layoutControl2.Controls.Add(this.label1);
            this.layoutControl2.Controls.Add(this.submitbutton);
            this.layoutControl2.Controls.Add(this.labelControl5);
            this.layoutControl2.Controls.Add(this.dengekatsay);
            this.layoutControl2.Controls.Add(this.labelControl25);
            this.layoutControl2.Controls.Add(this.agrtaneagr);
            this.layoutControl2.Controls.Add(this.labelControl24);
            this.layoutControl2.Controls.Add(this.simpleButton3);
            this.layoutControl2.Controls.Add(this.karkasagr);
            this.layoutControl2.Controls.Add(this.simpleButton18);
            this.layoutControl2.Controls.Add(this.beyamqpisuserdefined);
            this.layoutControl2.Controls.Add(this.HalatCap);
            this.layoutControl2.Controls.Add(this.labelControl17);
            this.layoutControl2.Controls.Add(this.labelControl15);
            this.layoutControl2.Controls.Add(this.labelControl14);
            this.layoutControl2.Controls.Add(this.labelControl4);
            this.layoutControl2.Controls.Add(this.labelControl13);
            this.layoutControl2.Controls.Add(this.pqtop);
            this.layoutControl2.Controls.Add(this.labelControl12);
            this.layoutControl2.Controls.Add(this.labelControl7);
            this.layoutControl2.Controls.Add(this.labelControl8);
            this.layoutControl2.Controls.Add(this.labelControl2);
            this.layoutControl2.Controls.Add(this.labelControl3);
            this.layoutControl2.Controls.Add(this.labelControl1);
            this.layoutControl2.Controls.Add(this.TahCap);
            this.layoutControl2.Controls.Add(this.HalatAdet);
            this.layoutControl2.Controls.Add(this.SapCap);
            this.layoutControl2.Controls.Add(this.MotorKw);
            this.layoutControl2.Controls.Add(this.labelControl11);
            this.layoutControl2.Controls.Add(this.KabinP);
            this.layoutControl2.Controls.Add(this.kabingenx);
            this.layoutControl2.Controls.Add(this.BeyanHiz);
            this.layoutControl2.Controls.Add(this.BeyanYuk);
            this.layoutControl2.Controls.Add(this.kabinderx);
            this.layoutControl2.Controls.Add(this.linkLabel1);
            this.layoutControl2.Controls.Add(this.BeyanKisi);
            this.layoutControl2.Dock = DockStyle.Fill;
            this.layoutControl2.Location = new Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new Size(0x137, 0x300);
            this.layoutControl2.TabIndex = 0x41;
            this.layoutControl2.Text = "layoutControl2";
            this.labelControl5.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.labelControl5.Location = new Point(7, 0x20a);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x88, 0x10);
            this.labelControl5.StyleController = this.layoutControl2;
            this.labelControl5.TabIndex = 0x3f0;
            this.labelControl5.Text = "GEREKLİ AĞIRLIK ADEDİ";
            this.dengekatsay.EditValue = "0,5";
            this.dengekatsay.Location = new Point(0x87, 0x1f0);
            this.dengekatsay.Name = "dengekatsay";
            this.dengekatsay.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dengekatsay.Properties.Appearance.Options.UseFont = true;
            this.dengekatsay.Size = new Size(0xa9, 0x16);
            this.dengekatsay.StyleController = this.layoutControl2;
            this.dengekatsay.TabIndex = 0x16;
            this.labelControl25.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl25.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelControl25.Location = new Point(0x101, 0x1bc);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new Size(0x2f, 14);
            this.labelControl25.StyleController = this.layoutControl2;
            this.labelControl25.TabIndex = 20;
            this.labelControl25.Text = "kg";
            this.agrtaneagr.EditValue = "35";
            this.agrtaneagr.Location = new Point(0x87, 470);
            this.agrtaneagr.Name = "agrtaneagr";
            this.agrtaneagr.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.agrtaneagr.Properties.Appearance.Options.UseFont = true;
            this.agrtaneagr.Size = new Size(0x76, 0x16);
            this.agrtaneagr.StyleController = this.layoutControl2;
            this.agrtaneagr.TabIndex = 0x12;
            this.agrtaneagr.EditValueChanged += new EventHandler(this.BeyanYuk_EditValueChanged);
            this.labelControl24.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl24.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelControl24.Location = new Point(0x101, 470);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new Size(0x2f, 14);
            this.labelControl24.StyleController = this.layoutControl2;
            this.labelControl24.TabIndex = 0x10;
            this.labelControl24.Text = "kg";
            this.simpleButton3.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton3.Appearance.ForeColor = Color.Red;
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Appearance.Options.UseForeColor = true;
            this.simpleButton3.Location = new Point(7, 0x19e);
            this.simpleButton3.MaximumSize = new Size(0, 0x1a);
            this.simpleButton3.MinimumSize = new Size(0, 0x1a);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(0x129, 0x1a);
            this.simpleButton3.StyleController = this.layoutControl2;
            this.simpleButton3.TabIndex = 0x3ef;
            this.simpleButton3.Text = "\x00c7İZİLECEK ASANS\x00d6R SE\x00c7";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.karkasagr.EditValue = "100";
            this.karkasagr.Location = new Point(0x87, 0x1bc);
            this.karkasagr.Name = "karkasagr";
            this.karkasagr.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.karkasagr.Properties.Appearance.Options.UseFont = true;
            this.karkasagr.Size = new Size(0x76, 0x16);
            this.karkasagr.StyleController = this.layoutControl2;
            this.karkasagr.TabIndex = 0x13;
            this.karkasagr.EditValueChanged += new EventHandler(this.BeyanYuk_EditValueChanged);
            this.simpleButton18.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton18.Appearance.ForeColor = Color.Red;
            this.simpleButton18.Appearance.Options.UseFont = true;
            this.simpleButton18.Appearance.Options.UseForeColor = true;
            this.simpleButton18.Location = new Point(7, 0xfe);
            this.simpleButton18.MaximumSize = new Size(0, 0x1a);
            this.simpleButton18.MinimumSize = new Size(0, 0x1a);
            this.simpleButton18.Name = "simpleButton18";
            this.simpleButton18.Size = new Size(0x129, 0x1a);
            this.simpleButton18.StyleController = this.layoutControl2;
            this.simpleButton18.TabIndex = 0x9c;
            this.simpleButton18.Text = "MOTOR BİLGİSİ SE\x00c7İNİZ";
            this.simpleButton18.Click += new EventHandler(this.simpleButton18_Click);
            this.beyamqpisuserdefined.Location = new Point(7, 0x67);
            this.beyamqpisuserdefined.Name = "beyamqpisuserdefined";
            this.beyamqpisuserdefined.Properties.Caption = "KULLANICI TANIMLI DEĞERLERİ KULLAN";
            this.beyamqpisuserdefined.Size = new Size(0x129, 0x13);
            this.beyamqpisuserdefined.StyleController = this.layoutControl2;
            this.beyamqpisuserdefined.TabIndex = 0x3ee;
            this.beyamqpisuserdefined.CheckedChanged += new EventHandler(this.beyamqpisuserdefined_CheckedChanged);
            this.HalatCap.EditValue = "10";
            this.HalatCap.Location = new Point(0x87, 0x184);
            this.HalatCap.Name = "HalatCap";
            this.HalatCap.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.HalatCap.Properties.Appearance.Options.UseFont = true;
            this.HalatCap.Size = new Size(0x7c, 0x16);
            this.HalatCap.StyleController = this.layoutControl2;
            this.HalatCap.TabIndex = 0x3ec;
            this.labelControl17.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl17.Location = new Point(0x107, 0x184);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new Size(0x29, 0x10);
            this.labelControl17.StyleController = this.layoutControl2;
            this.labelControl17.TabIndex = 0x3eb;
            this.labelControl17.Text = "mm";
            this.labelControl15.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl15.Location = new Point(0x107, 0x150);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new Size(0x29, 0x10);
            this.labelControl15.StyleController = this.layoutControl2;
            this.labelControl15.TabIndex = 0x3e9;
            this.labelControl15.Text = "KW";
            this.labelControl14.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl14.Location = new Point(0x107, 0x16a);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new Size(0x29, 0x10);
            this.labelControl14.StyleController = this.layoutControl2;
            this.labelControl14.TabIndex = 0x3e9;
            this.labelControl14.Text = "mm";
            this.labelControl4.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl4.Location = new Point(0x107, 310);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x29, 0x10);
            this.labelControl4.StyleController = this.layoutControl2;
            this.labelControl4.TabIndex = 0x3e8;
            this.labelControl4.Text = "mm";
            this.labelControl13.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl13.Location = new Point(0x107, 0x11c);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new Size(0x29, 0x10);
            this.labelControl13.StyleController = this.layoutControl2;
            this.labelControl13.TabIndex = 0x3e9;
            this.labelControl13.Text = "mm";
            this.pqtop.Font = new Font("Tahoma", 10f, FontStyle.Bold);
            this.pqtop.Location = new Point(7, 230);
            this.pqtop.Name = "pqtop";
            this.pqtop.Size = new Size(0x129, 20);
            this.pqtop.TabIndex = 0x47;
            this.pqtop.TabStop = true;
            this.pqtop.Text = "P+Q AĞIRLIK = 1100 KG";
            this.pqtop.TextAlign = ContentAlignment.MiddleCenter;
            this.labelControl12.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl12.Location = new Point(0x107, 0xb2);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new Size(0x29, 0x10);
            this.labelControl12.StyleController = this.layoutControl2;
            this.labelControl12.TabIndex = 0x4e;
            this.labelControl12.Text = "m/sn";
            this.labelControl7.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl7.Location = new Point(0x107, 0xcc);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(0x29, 0x10);
            this.labelControl7.StyleController = this.layoutControl2;
            this.labelControl7.TabIndex = 0x4c;
            this.labelControl7.Text = "kg";
            this.labelControl8.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl8.Location = new Point(0x107, 0x98);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new Size(0x29, 0x10);
            this.labelControl8.StyleController = this.layoutControl2;
            this.labelControl8.TabIndex = 0x4d;
            this.labelControl8.Text = "kişi";
            this.labelControl2.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl2.Location = new Point(0x107, 0x35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x29, 0x10);
            this.labelControl2.StyleController = this.layoutControl2;
            this.labelControl2.TabIndex = 0x42;
            this.labelControl2.Text = "mm";
            this.labelControl3.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl3.Location = new Point(0x107, 0x7e);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x29, 0x10);
            this.labelControl3.StyleController = this.layoutControl2;
            this.labelControl3.TabIndex = 0x4b;
            this.labelControl3.Text = "kg";
            this.labelControl1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl1.Location = new Point(0x107, 0x1b);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x29, 0x10);
            this.labelControl1.StyleController = this.layoutControl2;
            this.labelControl1.TabIndex = 0x41;
            this.labelControl1.Text = "mm";
            this.TahCap.EditValue = "450";
            this.TahCap.EnterMoveNextControl = true;
            this.TahCap.Location = new Point(0x87, 0x11c);
            this.TahCap.Name = "TahCap";
            this.TahCap.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.TahCap.Properties.Appearance.Options.UseFont = true;
            this.TahCap.Properties.Appearance.Options.UseTextOptions = true;
            this.TahCap.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.TahCap.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.TahCap.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.TahCap.Size = new Size(0x7c, 0x16);
            this.TahCap.StyleController = this.layoutControl2;
            this.TahCap.TabIndex = 7;
            this.HalatAdet.EditValue = "5";
            this.HalatAdet.EnterMoveNextControl = true;
            this.HalatAdet.Location = new Point(0x87, 0x16a);
            this.HalatAdet.Name = "HalatAdet";
            this.HalatAdet.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.HalatAdet.Properties.Appearance.Options.UseFont = true;
            this.HalatAdet.Properties.Appearance.Options.UseTextOptions = true;
            this.HalatAdet.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.HalatAdet.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.HalatAdet.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.HalatAdet.Size = new Size(0x7c, 0x16);
            this.HalatAdet.StyleController = this.layoutControl2;
            this.HalatAdet.TabIndex = 5;
            this.SapCap.EditValue = "400";
            this.SapCap.EnterMoveNextControl = true;
            this.SapCap.Location = new Point(0x87, 310);
            this.SapCap.Name = "SapCap";
            this.SapCap.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.SapCap.Properties.Appearance.Options.UseFont = true;
            this.SapCap.Properties.Appearance.Options.UseTextOptions = true;
            this.SapCap.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.SapCap.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.SapCap.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.SapCap.Size = new Size(0x7c, 0x16);
            this.SapCap.StyleController = this.layoutControl2;
            this.SapCap.TabIndex = 8;
            this.MotorKw.EditValue = "5,5";
            this.MotorKw.EnterMoveNextControl = true;
            this.MotorKw.Location = new Point(0x87, 0x150);
            this.MotorKw.Name = "MotorKw";
            this.MotorKw.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.MotorKw.Properties.Appearance.Options.UseFont = true;
            this.MotorKw.Properties.Appearance.Options.UseTextOptions = true;
            this.MotorKw.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.MotorKw.Size = new Size(0x7c, 0x16);
            this.MotorKw.StyleController = this.layoutControl2;
            this.MotorKw.TabIndex = 3;
            this.labelControl11.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl11.Location = new Point(7, 7);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new Size(0x69, 0x10);
            this.labelControl11.StyleController = this.layoutControl2;
            this.labelControl11.TabIndex = 0x4a;
            this.labelControl11.Text = "KABİN BİLGİLERİ";
            this.KabinP.EditValue = "500";
            this.KabinP.EnterMoveNextControl = true;
            this.KabinP.Location = new Point(0x87, 0xcc);
            this.KabinP.Name = "KabinP";
            this.KabinP.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KabinP.Properties.Appearance.Options.UseFont = true;
            this.KabinP.Properties.Appearance.Options.UseTextOptions = true;
            this.KabinP.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.KabinP.Size = new Size(0x7c, 0x16);
            this.KabinP.StyleController = this.layoutControl2;
            this.KabinP.TabIndex = 6;
            this.KabinP.EditValueChanged += new EventHandler(this.BeyanYuk_EditValueChanged);
            this.kabingenx.EditValue = "1200";
            this.kabingenx.Enabled = false;
            this.kabingenx.EnterMoveNextControl = true;
            this.kabingenx.Location = new Point(0x87, 0x1b);
            this.kabingenx.Name = "kabingenx";
            this.kabingenx.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kabingenx.Properties.Appearance.Options.UseFont = true;
            this.kabingenx.Properties.Appearance.Options.UseTextOptions = true;
            this.kabingenx.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.kabingenx.Properties.DisplayFormat.FormatString = "N";
            this.kabingenx.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.kabingenx.Properties.EditFormat.FormatString = "N";
            this.kabingenx.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.kabingenx.Size = new Size(0x7c, 0x16);
            this.kabingenx.StyleController = this.layoutControl2;
            this.kabingenx.TabIndex = 5;
            this.kabingenx.EditValueChanged += new EventHandler(this.kabingen_EditValueChanged);
            this.BeyanHiz.EditValue = "1";
            this.BeyanHiz.EnterMoveNextControl = true;
            this.BeyanHiz.Location = new Point(0x87, 0xb2);
            this.BeyanHiz.Name = "BeyanHiz";
            this.BeyanHiz.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.BeyanHiz.Properties.Appearance.Options.UseFont = true;
            this.BeyanHiz.Properties.Appearance.Options.UseTextOptions = true;
            this.BeyanHiz.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.BeyanHiz.Properties.DisplayFormat.FormatString = "n2";
            this.BeyanHiz.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.BeyanHiz.Properties.EditFormat.FormatString = "n2";
            this.BeyanHiz.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.BeyanHiz.Size = new Size(0x7c, 0x16);
            this.BeyanHiz.StyleController = this.layoutControl2;
            this.BeyanHiz.TabIndex = 4;
            this.BeyanYuk.EditValue = "750";
            this.BeyanYuk.Enabled = false;
            this.BeyanYuk.EnterMoveNextControl = true;
            this.BeyanYuk.Location = new Point(0x87, 0x7e);
            this.BeyanYuk.Name = "BeyanYuk";
            this.BeyanYuk.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.BeyanYuk.Properties.Appearance.Options.UseFont = true;
            this.BeyanYuk.Properties.Appearance.Options.UseTextOptions = true;
            this.BeyanYuk.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.BeyanYuk.Properties.DisplayFormat.FormatString = "N";
            this.BeyanYuk.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.BeyanYuk.Properties.EditFormat.FormatString = "N";
            this.BeyanYuk.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.BeyanYuk.Size = new Size(0x7c, 0x16);
            this.BeyanYuk.StyleController = this.layoutControl2;
            this.BeyanYuk.TabIndex = 0x45;
            this.BeyanYuk.EditValueChanged += new EventHandler(this.BeyanYuk_EditValueChanged);
            this.kabinderx.EditValue = "1500";
            this.kabinderx.Enabled = false;
            this.kabinderx.EnterMoveNextControl = true;
            this.kabinderx.Location = new Point(0x87, 0x35);
            this.kabinderx.Name = "kabinderx";
            this.kabinderx.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kabinderx.Properties.Appearance.Options.UseFont = true;
            this.kabinderx.Properties.Appearance.Options.UseTextOptions = true;
            this.kabinderx.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.kabinderx.Properties.DisplayFormat.FormatString = "N";
            this.kabinderx.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.kabinderx.Properties.EditFormat.FormatString = "N";
            this.kabinderx.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.kabinderx.Size = new Size(0x7c, 0x16);
            this.kabinderx.StyleController = this.layoutControl2;
            this.kabinderx.TabIndex = 0x44;
            this.kabinderx.EditValueChanged += new EventHandler(this.kabingen_EditValueChanged);
            this.linkLabel1.Font = new Font("Tahoma", 10f, FontStyle.Bold);
            this.linkLabel1.Location = new Point(7, 0x4f);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(0x129, 20);
            this.linkLabel1.TabIndex = 70;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "KABİN ALANI 1,80 m2";
            this.linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.BeyanKisi.EditValue = "10";
            this.BeyanKisi.Enabled = false;
            this.BeyanKisi.Location = new Point(0x87, 0x98);
            this.BeyanKisi.Name = "BeyanKisi";
            this.BeyanKisi.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.BeyanKisi.Properties.Appearance.Options.UseFont = true;
            this.BeyanKisi.Properties.Appearance.Options.UseTextOptions = true;
            this.BeyanKisi.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.BeyanKisi.Size = new Size(0x7c, 0x16);
            this.BeyanKisi.StyleController = this.layoutControl2;
            this.BeyanKisi.TabIndex = 0x41;
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { 
                this.layoutControlItem3, this.layoutControlItem8, this.layoutControlItem10, this.layoutControlItem12, this.layoutControlItem16, this.layoutControlItem18, this.layoutControlItem20, this.layoutControlItem21, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem13, this.layoutControlItem14, this.layoutControlItem15, this.layoutControlItem17, this.layoutControlItem19, this.layoutControlItem11,
                this.layoutControlItem22, this.layoutControlItem23, this.layoutControlItem25, this.layoutControlItem27, this.layoutControlItem28, this.layoutControlItem29, this.layoutControlItem30, this.layoutControlItem32, this.layoutControlItem116, this.layoutControlItem6, this.layoutControlItem34, this.layoutControlItem1, this.layoutControlItem33, this.layoutControlItem2, this.layoutControlItem7, this.layoutControlItem9,
                this.layoutControlItem31, this.layoutControlItem24, this.layoutControlItem26, this.layoutControlItem35
            };
            this.layoutControlGroup2.Items.AddRange(items);
            this.layoutControlGroup2.Location = new Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup2.Size = new Size(0x137, 0x300);
            this.layoutControlGroup2.TextVisible = false;
            this.layoutControlItem3.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.kabingenx;
            this.layoutControlItem3.CustomizationFormText = "KABİN GENİŞLİĞİ";
            this.layoutControlItem3.Location = new Point(0, 20);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x100, 0x1a);
            this.layoutControlItem3.Text = "KABİN GENİŞLİĞİ";
            this.layoutControlItem3.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem8.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.kabinderx;
            this.layoutControlItem8.CustomizationFormText = "KABİN DERİNİLİĞİ";
            this.layoutControlItem8.Location = new Point(0, 0x2e);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new Size(0x100, 0x1a);
            this.layoutControlItem8.Text = "KABİN DERİNİLİĞİ";
            this.layoutControlItem8.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem10.Control = this.linkLabel1;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new Point(0, 0x48);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new Size(0x12d, 0x18);
            this.layoutControlItem10.TextSize = new Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.layoutControlItem12.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem12.Control = this.BeyanYuk;
            this.layoutControlItem12.CustomizationFormText = "BEYAN Y\x00dcK\x00dc";
            this.layoutControlItem12.Location = new Point(0, 0x77);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new Size(0x100, 0x1a);
            this.layoutControlItem12.Text = "BEYAN Y\x00dcK\x00dc";
            this.layoutControlItem12.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem16.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem16.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem16.Control = this.BeyanHiz;
            this.layoutControlItem16.CustomizationFormText = "ASANS\x00d6R HIZI";
            this.layoutControlItem16.Location = new Point(0, 0xab);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new Size(0x100, 0x1a);
            this.layoutControlItem16.Text = "ASANS\x00d6R HIZI";
            this.layoutControlItem16.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem18.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem18.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem18.Control = this.KabinP;
            this.layoutControlItem18.CustomizationFormText = "KABİN AĞIRLIĞI";
            this.layoutControlItem18.Location = new Point(0, 0xc5);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new Size(0x100, 0x1a);
            this.layoutControlItem18.Text = "KABİN AĞIRLIĞI";
            this.layoutControlItem18.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem20.Control = this.labelControl11;
            this.layoutControlItem20.CustomizationFormText = "layoutControlItem20";
            this.layoutControlItem20.Location = new Point(0, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new Size(0x12d, 20);
            this.layoutControlItem20.TextSize = new Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            this.layoutControlItem21.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem21.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem21.Control = this.BeyanKisi;
            this.layoutControlItem21.CustomizationFormText = "BEYAN KİŞİ";
            this.layoutControlItem21.Location = new Point(0, 0x91);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new Size(0x100, 0x1a);
            this.layoutControlItem21.Text = "BEYAN KİŞİ";
            this.layoutControlItem21.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem4.Control = this.labelControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new Point(0x100, 20);
            this.layoutControlItem4.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem4.MinSize = new Size(0x2d, 20);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem4.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            this.layoutControlItem5.Control = this.labelControl2;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem5.Location = new Point(0x100, 0x2e);
            this.layoutControlItem5.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem5.MinSize = new Size(0x2d, 20);
            this.layoutControlItem5.Name = "layoutControlItem9";
            this.layoutControlItem5.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem5.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControlItem13.Control = this.labelControl3;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new Point(0x100, 0x77);
            this.layoutControlItem13.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem13.MinSize = new Size(0x2d, 20);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem13.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem13.TextSize = new Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            this.layoutControlItem14.Control = this.labelControl7;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new Point(0x100, 0xc5);
            this.layoutControlItem14.MaxSize = new Size(0, 20);
            this.layoutControlItem14.MinSize = new Size(0x2d, 20);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem14.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem14.TextSize = new Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            this.layoutControlItem15.Control = this.labelControl8;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new Point(0x100, 0x91);
            this.layoutControlItem15.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem15.MinSize = new Size(0x2d, 20);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem15.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem15.TextSize = new Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            this.layoutControlItem17.Control = this.labelControl12;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem17.Location = new Point(0x100, 0xab);
            this.layoutControlItem17.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem17.MinSize = new Size(0x2d, 20);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem17.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem17.TextSize = new Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            this.layoutControlItem19.Control = this.pqtop;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
            this.layoutControlItem19.Location = new Point(0, 0xdf);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new Size(0x12d, 0x18);
            this.layoutControlItem19.TextSize = new Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            this.layoutControlItem11.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem11.Control = this.TahCap;
            this.layoutControlItem11.CustomizationFormText = "MAK. KASNAK \x00c7API";
            this.layoutControlItem11.Location = new Point(0, 0x115);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new Size(0x100, 0x1a);
            this.layoutControlItem11.Text = "MAK. KASNAK \x00c7API";
            this.layoutControlItem11.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem22.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem22.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem22.Control = this.SapCap;
            this.layoutControlItem22.CustomizationFormText = "SAP. KASNAK \x00c7API";
            this.layoutControlItem22.Location = new Point(0, 0x12f);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new Size(0x100, 0x1a);
            this.layoutControlItem22.Text = "SAP. KASNAK \x00c7API";
            this.layoutControlItem22.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem23.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem23.Control = this.MotorKw;
            this.layoutControlItem23.CustomizationFormText = "MOTOR KW";
            this.layoutControlItem23.Location = new Point(0, 0x149);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new Size(0x100, 0x1a);
            this.layoutControlItem23.Text = "MOTOR KW";
            this.layoutControlItem23.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem25.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem25.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem25.Control = this.HalatAdet;
            this.layoutControlItem25.CustomizationFormText = "HALAT ADEDİ";
            this.layoutControlItem25.Location = new Point(0, 0x163);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new Size(0x100, 0x1a);
            this.layoutControlItem25.Text = "HALAT ADEDİ";
            this.layoutControlItem25.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem27.Control = this.labelControl13;
            this.layoutControlItem27.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem27.Location = new Point(0x100, 0x115);
            this.layoutControlItem27.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem27.MinSize = new Size(0x2d, 20);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem27.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem27.TextSize = new Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            this.layoutControlItem28.Control = this.labelControl4;
            this.layoutControlItem28.CustomizationFormText = "layoutControlItem28";
            this.layoutControlItem28.Location = new Point(0x100, 0x12f);
            this.layoutControlItem28.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem28.MinSize = new Size(0x2d, 20);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem28.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem28.TextSize = new Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            this.layoutControlItem29.Control = this.labelControl14;
            this.layoutControlItem29.CustomizationFormText = "layoutControlItem29";
            this.layoutControlItem29.Location = new Point(0x100, 0x163);
            this.layoutControlItem29.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem29.MinSize = new Size(0x2d, 20);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem29.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem29.TextSize = new Size(0, 0);
            this.layoutControlItem29.TextVisible = false;
            this.layoutControlItem30.Control = this.labelControl15;
            this.layoutControlItem30.CustomizationFormText = "layoutControlItem30";
            this.layoutControlItem30.Location = new Point(0x100, 0x149);
            this.layoutControlItem30.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem30.MinSize = new Size(0x2d, 20);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem30.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem30.TextSize = new Size(0, 0);
            this.layoutControlItem30.TextVisible = false;
            this.layoutControlItem32.Control = this.labelControl17;
            this.layoutControlItem32.CustomizationFormText = "layoutControlItem32";
            this.layoutControlItem32.Location = new Point(0x100, 0x17d);
            this.layoutControlItem32.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem32.MinSize = new Size(0x2d, 20);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem32.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem32.TextSize = new Size(0, 0);
            this.layoutControlItem32.TextVisible = false;
            this.layoutControlItem116.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem116.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem116.Control = this.HalatCap;
            this.layoutControlItem116.Location = new Point(0, 0x17d);
            this.layoutControlItem116.Name = "layoutControlItem116";
            this.layoutControlItem116.Size = new Size(0x100, 0x1a);
            this.layoutControlItem116.Text = "HALAT \x00c7API";
            this.layoutControlItem116.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem6.Control = this.beyamqpisuserdefined;
            this.layoutControlItem6.Location = new Point(0, 0x60);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new Size(0x12d, 0x17);
            this.layoutControlItem6.TextSize = new Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.layoutControlItem34.Control = this.simpleButton18;
            this.layoutControlItem34.Location = new Point(0, 0xf7);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new Size(0x12d, 30);
            this.layoutControlItem34.TextSize = new Size(0, 0);
            this.layoutControlItem34.TextVisible = false;
            this.layoutControlItem1.Control = this.simpleButton3;
            this.layoutControlItem1.Location = new Point(0, 0x197);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x12d, 30);
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem33.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem33.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem33.Control = this.dengekatsay;
            this.layoutControlItem33.Location = new Point(0, 0x1e9);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new Size(0x12d, 0x1a);
            this.layoutControlItem33.Text = "DENGE KAT SAYISI";
            this.layoutControlItem33.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem2.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.karkasagr;
            this.layoutControlItem2.Location = new Point(0, 0x1b5);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(250, 0x1a);
            this.layoutControlItem2.Text = "KARKAS AĞIRLIĞI";
            this.layoutControlItem2.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem7.Control = this.labelControl25;
            this.layoutControlItem7.Location = new Point(250, 0x1b5);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x33, 0x1a);
            this.layoutControlItem7.TextSize = new Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            this.layoutControlItem9.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.Control = this.agrtaneagr;
            this.layoutControlItem9.Location = new Point(0, 0x1cf);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new Size(250, 0x1a);
            this.layoutControlItem9.Text = "AĞIRLIK BİRİM K\x00dcT";
            this.layoutControlItem9.TextSize = new Size(0x7d, 0x10);
            this.layoutControlItem31.Control = this.labelControl24;
            this.layoutControlItem31.Location = new Point(250, 0x1cf);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new Size(0x33, 0x1a);
            this.layoutControlItem31.TextSize = new Size(0, 0);
            this.layoutControlItem31.TextVisible = false;
            this.layoutControlItem24.Control = this.labelControl5;
            this.layoutControlItem24.Location = new Point(0, 0x203);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new Size(0x12d, 20);
            this.layoutControlItem24.TextSize = new Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            this.xtraTabPage2.Controls.Add(this.kesitlayeryapi);
            this.xtraTabPage2.Controls.Add(this.kesitlayertree);
            this.xtraTabPage2.Controls.Add(this.simpleButton2);
            this.xtraTabPage2.Controls.Add(this.simpleButton1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new Size(0x137, 0x300);
            this.xtraTabPage2.Text = "\x00c7İZİM EKRANI";
            this.kesitlayeryapi.Dock = DockStyle.Top;
            this.kesitlayeryapi.Location = new Point(0, 0x2e);
            this.kesitlayeryapi.Name = "kesitlayeryapi";
            this.kesitlayeryapi.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.kesitlayeryapi.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttons = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.kesitlayeryapi.Properties.Buttons.AddRange(buttons);
            this.kesitlayeryapi.Properties.View = this.searchLookUpEdit1View;
            this.kesitlayeryapi.Size = new Size(0x137, 0x16);
            this.kesitlayeryapi.TabIndex = 5;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.kesitlayertree.Appearance.CustomizationFormHint.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.kesitlayertree.Appearance.Empty.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.Empty.Options.UseFont = true;
            this.kesitlayertree.Appearance.EvenRow.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.EvenRow.Options.UseFont = true;
            this.kesitlayertree.Appearance.FilterPanel.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.FilterPanel.Options.UseFont = true;
            this.kesitlayertree.Appearance.FilterPanel.Options.UseTextOptions = true;
            this.kesitlayertree.Appearance.FixedLine.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.FixedLine.Options.UseFont = true;
            this.kesitlayertree.Appearance.FocusedCell.BackColor = Color.FromArgb(0xff, 0xc0, 0xff);
            this.kesitlayertree.Appearance.FocusedCell.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.kesitlayertree.Appearance.FocusedCell.Options.UseFont = true;
            this.kesitlayertree.Appearance.FocusedRow.BackColor = Color.FromArgb(0xff, 0xc0, 0xff);
            this.kesitlayertree.Appearance.FocusedRow.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.FocusedRow.Options.UseBackColor = true;
            this.kesitlayertree.Appearance.FocusedRow.Options.UseFont = true;
            this.kesitlayertree.Appearance.FooterPanel.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.FooterPanel.Options.UseFont = true;
            this.kesitlayertree.Appearance.GroupButton.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.GroupButton.Options.UseFont = true;
            this.kesitlayertree.Appearance.GroupFooter.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.GroupFooter.Options.UseFont = true;
            this.kesitlayertree.Appearance.HeaderPanel.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.HeaderPanel.Options.UseFont = true;
            this.kesitlayertree.Appearance.HideSelectionRow.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.HideSelectionRow.Options.UseFont = true;
            this.kesitlayertree.Appearance.HorzLine.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.HorzLine.Options.UseFont = true;
            this.kesitlayertree.Appearance.OddRow.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.OddRow.Options.UseFont = true;
            this.kesitlayertree.Appearance.Preview.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.Preview.Options.UseFont = true;
            this.kesitlayertree.Appearance.Row.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.Row.Options.UseFont = true;
            this.kesitlayertree.Appearance.SelectedRow.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.SelectedRow.Options.UseFont = true;
            this.kesitlayertree.Appearance.TreeLine.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.TreeLine.Options.UseFont = true;
            this.kesitlayertree.Appearance.VertLine.Font = new Font("Tahoma", 10f);
            this.kesitlayertree.Appearance.VertLine.Options.UseFont = true;
            TreeListColumn[] columnArray2 = new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3, this.treeListColumn5, this.treeListColumn4 };
            this.kesitlayertree.Columns.AddRange(columnArray2);
            this.kesitlayertree.Dock = DockStyle.Bottom;
            this.kesitlayertree.Font = new Font("Microsoft Sans Serif", 10f);
            this.kesitlayertree.KeyFieldName = "kesitid";
            this.kesitlayertree.Location = new Point(0, 0x4a);
            this.kesitlayertree.Name = "kesitlayertree";
            this.kesitlayertree.OptionsBehavior.EnableFiltering = true;
            this.kesitlayertree.OptionsBehavior.PopulateServiceColumns = true;
            this.kesitlayertree.OptionsFilter.FilterMode = FilterMode.Extended;
            this.kesitlayertree.OptionsFilter.ShowAllValuesInFilterPopup = true;
            this.kesitlayertree.OptionsFind.AlwaysVisible = true;
            this.kesitlayertree.OptionsFind.ShowClearButton = false;
            this.kesitlayertree.OptionsFind.ShowCloseButton = false;
            this.kesitlayertree.OptionsFind.ShowFindButton = false;
            this.kesitlayertree.OptionsView.ShowAutoFilterRow = true;
            this.kesitlayertree.OptionsView.ShowColumns = false;
            this.kesitlayertree.ParentFieldName = "layerid";
            this.kesitlayertree.Size = new Size(0x137, 0x2b6);
            this.kesitlayertree.TabIndex = 1;
            this.treeListColumn1.AppearanceCell.Font = new Font("Tahoma", 9.75f, FontStyle.Underline, GraphicsUnit.Point, 0xa2);
            this.treeListColumn1.AppearanceCell.ForeColor = Color.Blue;
            this.treeListColumn1.AppearanceCell.Options.UseFont = true;
            this.treeListColumn1.AppearanceCell.Options.UseForeColor = true;
            this.treeListColumn1.Caption = "KESİT ADI";
            this.treeListColumn1.FieldName = "kesitad";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Like;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 0xc2;
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "kesitid";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Width = 0x69;
            this.treeListColumn3.Caption = "treeListColumn3";
            this.treeListColumn3.FieldName = "layerid";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn5.Caption = "Ekranda";
            this.treeListColumn5.FieldName = "aktifmi";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            this.treeListColumn5.Width = 50;
            this.treeListColumn4.Caption = "B\x00f6lge";
            this.treeListColumn4.FieldName = "layername";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Width = 0x3e;
            this.simpleButton2.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Dock = DockStyle.Top;
            this.simpleButton2.Location = new Point(0, 0x17);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x137, 0x17);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "SE\x00c7İMLERİ \x00c7İZİME UYGULA";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Dock = DockStyle.Top;
            this.simpleButton1.Location = new Point(0, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x137, 0x17);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "YAPIYI KAYDET";
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new Size(0x137, 0x300);
            this.xtraTabPage3.Text = "REG\x00dcLAT\x00d6R";
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new Size(0x137, 0x300);
            this.xtraTabPage4.Text = "S\x00dcSPANSİYON";
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new Size(0x137, 0x300);
            this.xtraTabPage5.Text = "RAY";
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new Size(0x137, 0x300);
            this.xtraTabPage7.Text = "Karşı Ağırlık";
            this.xtraTabPage8.Controls.Add(this.groupControl13);
            this.xtraTabPage8.Name = "xtraTabPage8";
            this.xtraTabPage8.Size = new Size(0x137, 0x300);
            this.xtraTabPage8.Text = "KAPI";
            this.groupControl13.AppearanceCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.groupControl13.AppearanceCaption.ForeColor = Color.FromArgb(0xc0, 0x40, 0);
            this.groupControl13.AppearanceCaption.Options.UseFont = true;
            this.groupControl13.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl13.Controls.Add(this.layoutControl7);
            this.groupControl13.Dock = DockStyle.Fill;
            this.groupControl13.Location = new Point(0, 0);
            this.groupControl13.Name = "groupControl13";
            this.groupControl13.Size = new Size(0x137, 0x300);
            this.groupControl13.TabIndex = 0x11;
            this.groupControl13.Text = "OTOMATİK KAPI PARAMETRELERİ";
            this.layoutControl7.Controls.Add(this.KapiKirisProfil);
            this.layoutControl7.Controls.Add(this.KapiKorKasa);
            this.layoutControl7.Controls.Add(this.KasaDer);
            this.layoutControl7.Controls.Add(this.KasaGen);
            this.layoutControl7.Controls.Add(this.KapiH);
            this.layoutControl7.Controls.Add(this.KizakKalin);
            this.layoutControl7.Controls.Add(this.ToplamKalin);
            this.layoutControl7.Controls.Add(this.OtoKabinEsik);
            this.layoutControl7.Dock = DockStyle.Fill;
            this.layoutControl7.Location = new Point(2, 0x17);
            this.layoutControl7.Name = "layoutControl7";
            this.layoutControl7.Root = this.layoutControlGroup7;
            this.layoutControl7.Size = new Size(0x133, 0x2e7);
            this.layoutControl7.TabIndex = 0;
            this.layoutControl7.Text = "layoutControl7";
            this.KapiKirisProfil.Location = new Point(7, 0xbb);
            this.KapiKirisProfil.Name = "KapiKirisProfil";
            this.KapiKirisProfil.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KapiKirisProfil.Properties.Appearance.Options.UseFont = true;
            this.KapiKirisProfil.Properties.Caption = "KAPIDA KİRİŞ PROFİLİ LAZIM";
            this.KapiKirisProfil.Size = new Size(0x126, 20);
            this.KapiKirisProfil.StyleController = this.layoutControl7;
            this.KapiKirisProfil.TabIndex = 14;
            this.KapiKorKasa.Location = new Point(7, 0xa3);
            this.KapiKorKasa.Name = "KapiKorKasa";
            this.KapiKorKasa.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KapiKorKasa.Properties.Appearance.Options.UseFont = true;
            this.KapiKorKasa.Properties.Caption = "KAPIDA K\x00d6R KASA VAR";
            this.KapiKorKasa.Size = new Size(0x126, 20);
            this.KapiKorKasa.StyleController = this.layoutControl7;
            this.KapiKorKasa.TabIndex = 13;
            this.KasaDer.EditValue = "60";
            this.KasaDer.Location = new Point(0xfb, 0x89);
            this.KasaDer.Name = "KasaDer";
            this.KasaDer.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KasaDer.Properties.Appearance.Options.UseFont = true;
            this.KasaDer.Size = new Size(50, 0x16);
            this.KasaDer.StyleController = this.layoutControl7;
            this.KasaDer.TabIndex = 10;
            this.KasaGen.EditValue = "120";
            this.KasaGen.Location = new Point(0xfb, 0x6f);
            this.KasaGen.Name = "KasaGen";
            this.KasaGen.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KasaGen.Properties.Appearance.Options.UseFont = true;
            this.KasaGen.Size = new Size(50, 0x16);
            this.KasaGen.StyleController = this.layoutControl7;
            this.KasaGen.TabIndex = 9;
            this.KapiH.EditValue = "2300";
            this.KapiH.Location = new Point(0xfb, 0x55);
            this.KapiH.Name = "KapiH";
            this.KapiH.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KapiH.Properties.Appearance.Options.UseFont = true;
            this.KapiH.Size = new Size(50, 0x16);
            this.KapiH.StyleController = this.layoutControl7;
            this.KapiH.TabIndex = 8;
            this.KizakKalin.EditValue = "90";
            this.KizakKalin.EnterMoveNextControl = true;
            this.KizakKalin.Location = new Point(0xfb, 0x21);
            this.KizakKalin.Name = "KizakKalin";
            this.KizakKalin.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KizakKalin.Properties.Appearance.Options.UseFont = true;
            this.KizakKalin.Size = new Size(50, 0x16);
            this.KizakKalin.StyleController = this.layoutControl7;
            this.KizakKalin.TabIndex = 7;
            this.ToplamKalin.EditValue = "500";
            this.ToplamKalin.EnterMoveNextControl = true;
            this.ToplamKalin.Location = new Point(0xfb, 0x3b);
            this.ToplamKalin.Name = "ToplamKalin";
            this.ToplamKalin.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ToplamKalin.Properties.Appearance.Options.UseFont = true;
            this.ToplamKalin.Size = new Size(50, 0x16);
            this.ToplamKalin.StyleController = this.layoutControl7;
            this.ToplamKalin.TabIndex = 6;
            this.OtoKabinEsik.EditValue = "50";
            this.OtoKabinEsik.EnterMoveNextControl = true;
            this.OtoKabinEsik.Location = new Point(0xfb, 7);
            this.OtoKabinEsik.Name = "OtoKabinEsik";
            this.OtoKabinEsik.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.OtoKabinEsik.Properties.Appearance.Options.UseFont = true;
            this.OtoKabinEsik.Size = new Size(50, 0x16);
            this.OtoKabinEsik.StyleController = this.layoutControl7;
            this.OtoKabinEsik.TabIndex = 4;
            this.layoutControlGroup7.CustomizationFormText = "layoutControlGroup6";
            this.layoutControlGroup7.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup7.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray2 = new BaseLayoutItem[] { this.layoutControlItem61, this.layoutControlItem63, this.layoutControlItem109, this.layoutControlItem110, this.layoutControlItem117, this.layoutControlItem118, this.layoutControlItem129, this.layoutControlItem130 };
            this.layoutControlGroup7.Items.AddRange(itemArray2);
            this.layoutControlGroup7.Location = new Point(0, 0);
            this.layoutControlGroup7.Name = "layoutControlGroup6";
            this.layoutControlGroup7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup7.Size = new Size(0x134, 0x2e7);
            this.layoutControlGroup7.TextVisible = false;
            this.layoutControlItem61.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem61.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem61.Control = this.OtoKabinEsik;
            this.layoutControlItem61.CustomizationFormText = "KONSOL MESAFESİ";
            this.layoutControlItem61.Location = new Point(0, 0);
            this.layoutControlItem61.Name = "layoutControlItem57";
            this.layoutControlItem61.Size = new Size(0x12a, 0x1a);
            this.layoutControlItem61.Text = "(1) EŞİK DEĞERİ";
            this.layoutControlItem61.TextSize = new Size(0xf1, 0x10);
            this.layoutControlItem63.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem63.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem63.Control = this.ToplamKalin;
            this.layoutControlItem63.CustomizationFormText = "RAY UCU TAVAN MRL";
            this.layoutControlItem63.Location = new Point(0, 0x34);
            this.layoutControlItem63.Name = "layoutControlItem59";
            this.layoutControlItem63.Size = new Size(0x12a, 0x1a);
            this.layoutControlItem63.Text = "(3) KUYU DUVARI-KABİN SINIRI DEĞERİ";
            this.layoutControlItem63.TextSize = new Size(0xf1, 14);
            this.layoutControlItem109.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem109.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem109.Control = this.KizakKalin;
            this.layoutControlItem109.Location = new Point(0, 0x1a);
            this.layoutControlItem109.Name = "layoutControlItem109";
            this.layoutControlItem109.Size = new Size(0x12a, 0x1a);
            this.layoutControlItem109.Text = "OTO KAPI KIZAĞI";
            this.layoutControlItem109.TextSize = new Size(0xf1, 0x10);
            this.layoutControlItem110.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem110.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem110.Control = this.KapiH;
            this.layoutControlItem110.Location = new Point(0, 0x4e);
            this.layoutControlItem110.Name = "layoutControlItem110";
            this.layoutControlItem110.Size = new Size(0x12a, 0x1a);
            this.layoutControlItem110.Text = "OTO KAPI Y\x00dcKSEKLİĞİ";
            this.layoutControlItem110.TextSize = new Size(0xf1, 0x10);
            this.layoutControlItem117.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem117.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem117.Control = this.KasaGen;
            this.layoutControlItem117.Location = new Point(0, 0x68);
            this.layoutControlItem117.Name = "layoutControlItem117";
            this.layoutControlItem117.Size = new Size(0x12a, 0x1a);
            this.layoutControlItem117.Text = "OTO KAPI KASA GENİŞLİĞİ";
            this.layoutControlItem117.TextSize = new Size(0xf1, 0x10);
            this.layoutControlItem118.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem118.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem118.Control = this.KasaDer;
            this.layoutControlItem118.Location = new Point(0, 130);
            this.layoutControlItem118.Name = "layoutControlItem118";
            this.layoutControlItem118.Size = new Size(0x12a, 0x1a);
            this.layoutControlItem118.Text = "OTO KAPI KASA DERİNLİĞİ";
            this.layoutControlItem118.TextSize = new Size(0xf1, 0x10);
            this.layoutControlItem129.Control = this.KapiKorKasa;
            this.layoutControlItem129.Location = new Point(0, 0x9c);
            this.layoutControlItem129.Name = "layoutControlItem129";
            this.layoutControlItem129.Size = new Size(0x12a, 0x18);
            this.layoutControlItem129.TextSize = new Size(0, 0);
            this.layoutControlItem129.TextVisible = false;
            this.layoutControlItem130.Control = this.KapiKirisProfil;
            this.layoutControlItem130.Location = new Point(0, 180);
            this.layoutControlItem130.Name = "layoutControlItem130";
            this.layoutControlItem130.Size = new Size(0x12a, 0x229);
            this.layoutControlItem130.TextSize = new Size(0, 0);
            this.layoutControlItem130.TextVisible = false;
            this.layoutControlItem26.Control = this.submitbutton;
            this.layoutControlItem26.Location = new Point(0, 0x2ba);
            this.layoutControlItem26.MaxSize = new Size(0, 60);
            this.layoutControlItem26.MinSize = new Size(120, 60);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new Size(0x12d, 60);
            this.layoutControlItem26.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem26.TextSize = new Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            this.label1.Location = new Point(7, 0x21e);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x129, 0x9f);
            this.label1.TabIndex = 0x3f1;
            this.layoutControlItem35.Control = this.label1;
            this.layoutControlItem35.Location = new Point(0, 0x217);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new Size(0x12d, 0xa3);
            this.layoutControlItem35.TextSize = new Size(0, 0);
            this.layoutControlItem35.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.ObjectDefine);
            base.Name = "ascadpalet";
            base.Size = new Size(0x13d, 0x31f);
            base.Load += new EventHandler(this.ascadpalet_Load);
            this.ObjectDefine.EndInit();
            this.ObjectDefine.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.antetgrid.EndInit();
            this.gridView1.EndInit();
            this.xtraTabPage6.ResumeLayout(false);
            this.layoutControl2.EndInit();
            this.layoutControl2.ResumeLayout(false);
            this.dengekatsay.Properties.EndInit();
            this.agrtaneagr.Properties.EndInit();
            this.karkasagr.Properties.EndInit();
            this.beyamqpisuserdefined.Properties.EndInit();
            this.HalatCap.Properties.EndInit();
            this.TahCap.Properties.EndInit();
            this.HalatAdet.Properties.EndInit();
            this.SapCap.Properties.EndInit();
            this.MotorKw.Properties.EndInit();
            this.KabinP.Properties.EndInit();
            this.kabingenx.Properties.EndInit();
            this.BeyanHiz.Properties.EndInit();
            this.BeyanYuk.Properties.EndInit();
            this.kabinderx.Properties.EndInit();
            this.BeyanKisi.Properties.EndInit();
            this.layoutControlGroup2.EndInit();
            this.layoutControlItem3.EndInit();
            this.layoutControlItem8.EndInit();
            this.layoutControlItem10.EndInit();
            this.layoutControlItem12.EndInit();
            this.layoutControlItem16.EndInit();
            this.layoutControlItem18.EndInit();
            this.layoutControlItem20.EndInit();
            this.layoutControlItem21.EndInit();
            this.layoutControlItem4.EndInit();
            this.layoutControlItem5.EndInit();
            this.layoutControlItem13.EndInit();
            this.layoutControlItem14.EndInit();
            this.layoutControlItem15.EndInit();
            this.layoutControlItem17.EndInit();
            this.layoutControlItem19.EndInit();
            this.layoutControlItem11.EndInit();
            this.layoutControlItem22.EndInit();
            this.layoutControlItem23.EndInit();
            this.layoutControlItem25.EndInit();
            this.layoutControlItem27.EndInit();
            this.layoutControlItem28.EndInit();
            this.layoutControlItem29.EndInit();
            this.layoutControlItem30.EndInit();
            this.layoutControlItem32.EndInit();
            this.layoutControlItem116.EndInit();
            this.layoutControlItem6.EndInit();
            this.layoutControlItem34.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem33.EndInit();
            this.layoutControlItem2.EndInit();
            this.layoutControlItem7.EndInit();
            this.layoutControlItem9.EndInit();
            this.layoutControlItem31.EndInit();
            this.layoutControlItem24.EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.kesitlayeryapi.Properties.EndInit();
            this.searchLookUpEdit1View.EndInit();
            this.kesitlayertree.EndInit();
            this.xtraTabPage8.ResumeLayout(false);
            this.groupControl13.EndInit();
            this.groupControl13.ResumeLayout(false);
            this.layoutControl7.EndInit();
            this.layoutControl7.ResumeLayout(false);
            this.KapiKirisProfil.Properties.EndInit();
            this.KapiKorKasa.Properties.EndInit();
            this.KasaDer.Properties.EndInit();
            this.KasaGen.Properties.EndInit();
            this.KapiH.Properties.EndInit();
            this.KizakKalin.Properties.EndInit();
            this.ToplamKalin.Properties.EndInit();
            this.OtoKabinEsik.Properties.EndInit();
            this.layoutControlGroup7.EndInit();
            this.layoutControlItem61.EndInit();
            this.layoutControlItem63.EndInit();
            this.layoutControlItem109.EndInit();
            this.layoutControlItem110.EndInit();
            this.layoutControlItem117.EndInit();
            this.layoutControlItem118.EndInit();
            this.layoutControlItem129.EndInit();
            this.layoutControlItem130.EndInit();
            this.layoutControlItem26.EndInit();
            this.layoutControlItem35.EndInit();
            base.ResumeLayout(false);
        }

        private void kabingen_EditValueChanged(object sender, EventArgs e)
        {
            this.kabinalan = (Convert.ToDouble(this.kabinderx.Text) * Convert.ToDouble(this.kabingenx.Text)) / 1000000.0;
            this.linkLabel1.Text = "KABİN ALANI : " + this.kabinalan.ToString("n2");
            if (!this.beyamqpisuserdefined.Checked)
            {
                int num;
                if ((0.49 <= this.kabinalan) && (this.kabinalan <= 0.58))
                {
                    num = 180;
                    this.BeyanYuk.Text = num.ToString();
                    num = 3;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((0.6 <= this.kabinalan) && (this.kabinalan <= 0.7))
                {
                    num = 0xe1;
                    this.BeyanYuk.Text = num.ToString();
                    num = 3;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((0.79 <= this.kabinalan) && (this.kabinalan <= 0.9))
                {
                    num = 300;
                    this.BeyanYuk.Text = num.ToString();
                    num = 4;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((0.9 <= this.kabinalan) && (this.kabinalan <= 0.98))
                {
                    num = 320;
                    this.BeyanYuk.Text = num.ToString();
                    num = 5;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((0.98 <= this.kabinalan) && (this.kabinalan <= 1.1))
                {
                    num = 0x177;
                    this.BeyanYuk.Text = num.ToString();
                    num = 5;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.1 <= this.kabinalan) && (this.kabinalan <= 1.17))
                {
                    num = 400;
                    this.BeyanYuk.Text = num.ToString();
                    num = 5;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.17 <= this.kabinalan) && (this.kabinalan <= 1.3))
                {
                    num = 450;
                    this.BeyanYuk.Text = num.ToString();
                    num = 6;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.31 <= this.kabinalan) && (this.kabinalan <= 1.45))
                {
                    num = 0x20d;
                    this.BeyanYuk.Text = num.ToString();
                    num = 7;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.45 <= this.kabinalan) && (this.kabinalan <= 1.6))
                {
                    num = 600;
                    this.BeyanYuk.Text = num.ToString();
                    num = 8;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.6 <= this.kabinalan) && (this.kabinalan <= 1.66))
                {
                    num = 630;
                    this.BeyanYuk.Text = num.ToString();
                    num = 8;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.59 <= this.kabinalan) && (this.kabinalan <= 1.75))
                {
                    num = 0x2a3;
                    this.BeyanYuk.Text = num.ToString();
                    num = 9;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.73 <= this.kabinalan) && (this.kabinalan <= 1.9))
                {
                    num = 750;
                    this.BeyanYuk.Text = num.ToString();
                    num = 10;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.9 <= this.kabinalan) && (this.kabinalan <= 2.0))
                {
                    num = 800;
                    this.BeyanYuk.Text = num.ToString();
                    num = 10;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((1.87 <= this.kabinalan) && (this.kabinalan <= 2.05))
                {
                    num = 0x339;
                    this.BeyanYuk.Text = num.ToString();
                    num = 11;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.01 <= this.kabinalan) && (this.kabinalan <= 2.2))
                {
                    num = 900;
                    this.BeyanYuk.Text = num.ToString();
                    num = 12;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.15 <= this.kabinalan) && (this.kabinalan <= 2.35))
                {
                    num = 0x3cf;
                    this.BeyanYuk.Text = num.ToString();
                    num = 13;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.35 <= this.kabinalan) && (this.kabinalan <= 2.4))
                {
                    num = 0x3e8;
                    this.BeyanYuk.Text = num.ToString();
                    num = 13;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.29 <= this.kabinalan) && (this.kabinalan <= 2.5))
                {
                    num = 0x41a;
                    this.BeyanYuk.Text = num.ToString();
                    num = 14;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.43 <= this.kabinalan) && (this.kabinalan <= 2.65))
                {
                    num = 0x465;
                    this.BeyanYuk.Text = num.ToString();
                    num = 15;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.57 <= this.kabinalan) && (this.kabinalan <= 2.8))
                {
                    num = 0x4b0;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x10;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.8 <= this.kabinalan) && (this.kabinalan <= 2.9))
                {
                    num = 0x4e2;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x10;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.71 <= this.kabinalan) && (this.kabinalan <= 2.95))
                {
                    num = 0x4fb;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x11;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.85 <= this.kabinalan) && (this.kabinalan <= 3.1))
                {
                    num = 0x546;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x12;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((2.99 <= this.kabinalan) && (this.kabinalan <= 3.25))
                {
                    num = 0x591;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x13;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.13 <= this.kabinalan) && (this.kabinalan <= 3.4))
                {
                    num = 0x5dc;
                    this.BeyanYuk.Text = num.ToString();
                    num = 20;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.24 <= this.kabinalan) && (this.kabinalan <= 3.45))
                {
                    num = 0x627;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x15;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.36 <= this.kabinalan) && (this.kabinalan <= 3.56))
                {
                    num = 0x640;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x16;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.36 <= this.kabinalan) && (this.kabinalan <= 3.68))
                {
                    num = 0x672;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x16;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.47 <= this.kabinalan) && (this.kabinalan <= 3.8))
                {
                    num = 0x6bd;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x17;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.59 <= this.kabinalan) && (this.kabinalan <= 3.92))
                {
                    num = 0x708;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x18;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.7 <= this.kabinalan) && (this.kabinalan <= 4.04))
                {
                    num = 0x753;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x19;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.82 <= this.kabinalan) && (this.kabinalan <= 4.16))
                {
                    num = 0x79e;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x1a;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.87 <= this.kabinalan) && (this.kabinalan <= 4.2))
                {
                    num = 0x7d0;
                    this.BeyanYuk.Text = num.ToString();
                    num = 0x1a;
                    this.BeyanKisi.Text = num.ToString();
                }
                if ((3.93 <= this.kabinalan) && (this.kabinalan <= 4.32))
                {
                    num = 0x7e9;
                    this.BeyanYuk.Text = num.ToString();
                    this.BeyanKisi.Text = 0x1b.ToString();
                }
                this.pqtop.Text = "P+Q AĞIRLIK = " + ((Convert.ToInt32(this.BeyanYuk.Text) + Convert.ToInt32(this.KabinP.Text))).ToString() + " KG";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new tsestandart { 
                kabinderstr = this.kabinderx.Text,
                kabingenstr = this.kabingenx.Text
            }.ShowDialog();
        }

        public void objedefiner(string gelen)
        {
            this.pageshow(this.dondurbana(gelen));
        }

        private void pageshow(int psgrindex)
        {
            if (psgrindex > 2)
            {
                for (int i = 2; i < this.ObjectDefine.TabPages.Count; i++)
                {
                    this.ObjectDefine.TabPages[i].PageVisible = false;
                }
                this.ObjectDefine.TabPages[psgrindex].PageVisible = true;
                this.ObjectDefine.SelectedTabPage = this.ObjectDefine.TabPages[psgrindex];
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.xx2.SetNumValue("TahCap", "", "1");
            this.xx2.SetNumValue("SapCap", "", "1");
            this.xx2.SetNumValue("MotorKw", "", "1");
            this.xx2.SetNumValue("HalatAdet", "", "1");
            this.xx2.SetNumValue("HalatCap", "", "1");
            this.xx2.SetNumValue("agrtaneagr", "", "1");
            this.xx2.SetNumValue("dengekatsay", "", "1");
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.kesitlayertree.Nodes.Count; i++)
            {
                if (this.kesitlayertree.Nodes.ParentNode != null)
                {
                    if ((bool) this.kesitlayertree.Nodes[i].GetValue(this.layeracikcolumn))
                    {
                        this.kesitlayertree.Nodes[i].GetValue(this.layeracikcolumn);
                    }
                    else
                    {
                        this.kesitlayertree.Nodes[i].GetValue(this.layeracikcolumn);
                    }
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            asnseccrm asnseccrm = new asnseccrm();
            asnseccrm.ShowDialog();
            string asansorno = asnseccrm.asansorno;
            string dwgid = asnseccrm.dwgid;
        }

        private void veriesit(DataTable gelentab, TextEdit tee)
        {
            for (int i = 0; i < gelentab.Rows.Count; i++)
            {
                if (gelentab.Rows[i][0].ToString() == tee.Name)
                {
                    tee.EditValue = gelentab.Rows[i][1];
                }
            }
        }
    }
}

