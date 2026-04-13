namespace ascad
{
    using ascad.Properties;
    using DevExpress.LookAndFeel;
    using DevExpress.Utils;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Localization;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraLayout;
    using DevExpress.XtraLayout.Utils;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Resources;
    using System.Windows.Forms;

    public class MainForm2 : Form
    {
        private RadioGroup acilmayon;
        private TextEdit arkaagirsayisi;
        public int AsansorSayisi = 1;
        public ascad.ascad asc;
        private BackstageViewButtonItem backstageViewButtonItem1;
        private BackstageViewClientControl backstageViewClientControl1;
        private BackstageViewClientControl backstageViewClientControl2;
        private BackstageViewClientControl backstageViewClientControl3;
        private BackstageViewClientControl backstageViewClientControl4;
        private BackstageViewClientControl backstageViewClientControl5;
        private BackstageViewClientControl backstageViewClientControl6;
        private BackstageViewControl backstageViewControl1;
        private BackstageViewTabItem backstageViewTabItem1;
        private BackstageViewTabItem backstageViewTabItem2;
        private BackstageViewTabItem backstageViewTabItem3;
        private BackstageViewTabItem backstageViewTabItem4;
        private BackstageViewTabItem backstageViewTabItem5;
        private BackstageViewTabItem backstageViewTabItem6;
        private IContainer components = null;
        private int dairesecim = 0;
        private DefaultLookAndFeel defaultLookAndFeel1;
        private TextEdit dengekatsayisi;
        private DataTable dildata = new DataTable();
        private SimpleButton dileklemebuton;
        private ComboBoxEdit dilsecimi;
        private SearchLookUpEdit dosyaa3ekipman;
        private SimpleButton dosyaa3ekipmangor;
        private LayoutControlItem dosyaa3ekipmanlbl;
        private TextEdit dosyaa3ekipmansn;
        private TextEdit dosyaada;
        private RichTextBox dosyaadres;
        private SearchLookUpEdit dosyaagrtampon;
        private SimpleButton dosyaagrtampongor;
        private LayoutControlItem dosyaagrtamponlbl;
        private TextEdit dosyaagrtamponsn;
        private TextEdit dosyaasansorno;
        private TextEdit dosyaasansorsahib;
        private TextEdit dosyabelediye;
        private ComboBoxEdit dosyabelgemodul;
        private TextEdit dosyabinasahip;
        private TextEdit dosyabinasahiptc;
        private TextEdit dosyabinasahipvd;
        private TextEdit dosyabinasahipvn;
        private TextEdit dosyablok;
        private TextEdit dosyabulvar;
        private TextEdit dosyacadde;
        private TextEdit dosyadebibelgeno;
        private TextEdit dosyadebimodel;
        private TextEdit dosyadebionaylayan;
        private TextEdit dosyadebiserino;
        private TextEdit dosyadebiuret;
        private SearchLookUpEdit dosyafrenblok;
        private SimpleButton dosyafrenblokgor;
        private LayoutControlItem dosyafrenbloklbl;
        private TextEdit dosyafrenbloksn;
        private GroupControl dosyahidasnicin;
        private TextEdit dosyahortumbelgeno;
        private TextEdit dosyahortummodel;
        private TextEdit dosyahortumonaylayan;
        private TextEdit dosyahortumserino;
        private TextEdit dosyahortumuretici;
        private TextEdit dosyail;
        private TextEdit dosyailce;
        private SearchLookUpEdit dosyakabintampon;
        private SimpleButton dosyakabintampongor;
        private LayoutControlItem dosyakabintamponlbl;
        private TextEdit dosyakabintamponsn;
        private SearchLookUpEdit dosyakapikilit;
        private SimpleButton dosyakapikilitgor;
        private LayoutControlItem dosyakapikilitlbl;
        private TextEdit dosyakapikilitsn;
        private SearchLookUpEdit dosyakumandakarti;
        private SimpleButton dosyakumandakartigor;
        private LayoutControlItem dosyakumandakartilbl;
        private TextEdit dosyakumandakartisn;
        private LayoutControlItem dosyalblada;
        private LayoutControlItem dosyalbladres;
        private LayoutControlItem dosyalblasansorsahip;
        private LayoutControlItem dosyalblasnno;
        private LayoutControlItem dosyalblbelediye;
        private LabelControl dosyalblbelgeno;
        private LabelControl dosyalblbelgeno2;
        private LayoutControlItem dosyalblbinasahip;
        private LayoutControlItem dosyalblbinasahiptc;
        private LayoutControlItem dosyalblbinasahipvd;
        private LayoutControlItem dosyalblbinasahipvn;
        private LayoutControlItem dosyalblblok;
        private LayoutControlItem dosyalblbulvar;
        private LayoutControlItem dosyalblcadde;
        private LabelControl dosyalbldebi;
        private GroupControl dosyalblelektrasnicin;
        private LabelControl dosyalblhortum;
        private LayoutControlItem dosyalblil;
        private LayoutControlItem dosyalblilce;
        private LayoutControlItem dosyalblmahalle;
        private LabelControl dosyalblmakine;
        private LabelControl dosyalblmalz;
        private LabelControl dosyalblmalz2;
        private LabelControl dosyalblmodel;
        private LabelControl dosyalblmodel2;
        private LayoutControlItem dosyalblmodul;
        private LabelControl dosyalblmotor;
        private LayoutControlItem dosyalblmuteaahhit;
        private LayoutControlItem dosyalblmuteaahhittc;
        private LayoutControlItem dosyalblmuteaahhitvd;
        private LayoutControlItem dosyalblmuteaahhitvn;
        private LayoutControlItem dosyalblno;
        private LabelControl dosyalblonaylayan;
        private LabelControl dosyalblonaylayan2;
        private LayoutControlItem dosyalblpafta;
        private LayoutControlItem dosyalblparsel;
        private LabelControl dosyalblserino;
        private LabelControl dosyalblserino2;
        private LabelControl dosyalblsertf;
        private LayoutControlItem dosyalblservistar;
        private LayoutControlItem dosyalblsinif;
        private LayoutControlItem dosyalblsokak;
        private LabelControl dosyalbluret;
        private LabelControl dosyalbluret2;
        private LabelControl dosyalblurserno;
        private TextEdit dosyamahalle;
        private TextEdit dosyamakinebelgeno;
        private TextEdit dosyamakinemodel;
        private TextEdit dosyamakineonaylayan;
        private TextEdit dosyamakineuret;
        private TextEdit dosyamakineurserno;
        private TextEdit dosyamotorbelgeno;
        public TextEdit dosyamotormodel;
        private TextEdit dosyamotoronaylayan;
        private TextEdit dosyamotorserino;
        public TextEdit dosyamotoruretici;
        private TextEdit dosyamutaahhit;
        private TextEdit dosyamutaahhittc;
        private TextEdit dosyamutaahhitvd;
        private TextEdit dosyamutaahhitvn;
        private TextEdit dosyano;
        private TextEdit dosyapafta;
        private SearchLookUpEdit dosyapano;
        private SimpleButton dosyapanogor;
        private LayoutControlItem dosyapanolbl;
        private TextEdit dosyapanosn;
        private TextEdit dosyaparsel;
        private SearchLookUpEdit dosyapistonvalfi;
        private SimpleButton dosyapistonvalfigor;
        private LayoutControlItem dosyapistonvalfilbl;
        private TextEdit dosyapistonvalfisn;
        private SearchLookUpEdit dosyaregulator;
        private SimpleButton dosyaregulatorgor;
        private LayoutControlItem dosyaregulatorlbl;
        private TextEdit dosyaregulatorsn;
        private TextEdit dosyaservistar;
        private TextEdit dosyasinif;
        private LabelControl dosyaslblertfsec;
        private TextEdit dosyasokak;
        private ComboBoxEdit gorunumayar;
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
        private GridColumn gridColumn12;
        private GridColumn gridColumn13;
        private GridColumn gridColumn14;
        private GridColumn gridColumn15;
        private GridColumn gridColumn16;
        private GridColumn gridColumn17;
        private GridColumn gridColumn18;
        private GridColumn gridColumn19;
        private GridColumn gridColumn20;
        private GridColumn gridColumn21;
        private GridColumn gridColumn22;
        private GridColumn gridColumn23;
        private GridColumn gridColumn24;
        private GridColumn gridColumn25;
        private GridColumn gridColumn26;
        private GridColumn gridColumn27;
        private GridColumn gridColumn28;
        private GridColumn gridColumn29;
        private GridColumn gridColumn30;
        private GridColumn gridColumn31;
        private GridColumn gridColumn32;
        private GridColumn gridColumn33;
        private GridColumn gridColumn34;
        private GridColumn gridColumn35;
        private GridColumn gridColumn36;
        private GridColumn gridColumn37;
        private GridColumn gridColumn38;
        private GridColumn gridColumn39;
        private GridColumn gridColumn40;
        private GridColumn gridColumn41;
        private GridColumn gridColumn42;
        private GridColumn gridColumn43;
        private GridColumn gridColumn44;
        private GridColumn gridColumn45;
        private GridColumn gridColumn46;
        private GridColumn gridColumn47;
        private GridColumn gridColumn48;
        private GridColumn gridColumn49;
        private GridColumn gridColumn50;
        private GridColumn gridColumn51;
        private GridColumn gridColumn52;
        private GridColumn gridColumn53;
        private GridColumn gridColumn54;
        private GridColumn gridColumn55;
        private GridColumn gridColumn56;
        private GridColumn gridColumn57;
        private GridColumn gridColumn64;
        private GridColumn gridColumn65;
        private GridColumn gridColumn66;
        private GridColumn gridColumn67;
        private GridColumn gridColumn68;
        private GridColumn gridColumn69;
        private GridColumn gridColumn70;
        private GridColumn gridColumn73;
        private GridColumn gridColumn74;
        private GridColumn gridColumn75;
        private GridColumn gridColumn76;
        private GridColumn gridColumn77;
        private GridColumn gridColumn78;
        private GridControl gridcontroldiller;
        private GridView gridView1;
        private GridView gridView3;
        private GridView gridviewdiller;
        private GroupBox groupBox2;
        private GroupControl groupControl5;
        private int ilklocationx = 0;
        private int ilklocationy = 0;
        private inicibaba incik = new inicibaba(@".\AYAR\ayars.ini");
        private CheckEdit kapiarkacheck;
        private PictureBox kapiarkaimage;
        private TextEdit kapigen;
        private PictureBox kapikabinimage;
        private LookUpEdit kapikaplama;
        private int kapikaplamaney = 0;
        private LookUpEdit kapimmarmodel;
        private PictureBox kapionimage;
        private CheckEdit kapisagcheck;
        private PictureBox kapisagimage;
        private CheckEdit kapisolcheck;
        private PictureBox kapisolimage;
        private RadioGroup kapitipi;
        private PictureEdit kapitippicture;
        private TextEdit karkasagirlik;
        private RadioGroup karkasgrup;
        private TextEdit karsiagrbirimagirlik;
        private TextEdit karsiagrboy;
        private TextEdit karsiagren;
        private LookUpEdit karsiagrmodel;
        private TextEdit karsiagrozgulkutle;
        private LookUpEdit karsiagrsecim;
        private TextEdit karsiagryukseklik;
        private RadioButton kataradio;
        private TextEdit katatext;
        private RadioButton kathizasiradio;
        private RadioButton kuyuyaradio;
        private TextEdit kuyuyatext;
        private LayoutControlItem label3arkaagr;
        private LayoutControlItem label3baritdokum;
        private LayoutControlItem label3birimagr;
        private LabelControl label3birimkg;
        private LayoutControlItem label3boybilgisi;
        private LabelControl label3boymm;
        private LayoutControlItem label3enbilgisi;
        private LabelControl label3enmm;
        private LayoutControlItem label3karkasagr;
        private LabelControl label3karsiagirlik;
        private LabelControl label3kutlekg;
        private LayoutControlItem label3modelsec;
        private LayoutControlItem label3ozgulkutle;
        private LayoutControlItem label3regmarka;
        private LabelControl label3regulatorbilgi;
        private LayoutControlItem label3yanagr;
        private LayoutControlItem label3yukseklikbilgisi;
        private LabelControl label3yuksekmm;
        private LabelControl labeldilaciklama;
        private LayoutControlItem labeldilsecimi;
        private LayoutControlItem labelgorunumayar;
        private LayoutControlItem labelkapigenisligi;
        private LayoutControlItem labelkapikaplamamarka;
        private LayoutControlItem labelkapikaplamasi;
        private GroupControl labelkapitipsecimi;
        private LabelControl labelversionbilgi;
        private LabelControl labelversiyonyazi;
        private LayoutControlItem labelyangindayanim;
        private LayoutControl layoutControl1;
        private LayoutControl layoutControl2;
        private LayoutControl layoutControl23;
        private LayoutControl layoutControl24;
        private LayoutControl layoutControl3;
        private LayoutControl layoutControl5;
        private LayoutControl layoutControl6;
        private LayoutControl layoutControl7;
        private LayoutControl layoutControl8;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlGroup layoutControlGroup10;
        private LayoutControlGroup layoutControlGroup2;
        private LayoutControlGroup layoutControlGroup23;
        private LayoutControlGroup layoutControlGroup24;
        private LayoutControlGroup layoutControlGroup3;
        private LayoutControlGroup layoutControlGroup6;
        private LayoutControlGroup layoutControlGroup7;
        private LayoutControlGroup layoutControlGroup9;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem103;
        private LayoutControlItem layoutControlItem104;
        private LayoutControlItem layoutControlItem105;
        private LayoutControlItem layoutControlItem106;
        private LayoutControlItem layoutControlItem107;
        private LayoutControlItem layoutControlItem108;
        private LayoutControlItem layoutControlItem109;
        private LayoutControlItem layoutControlItem110;
        private LayoutControlItem layoutControlItem12;
        private LayoutControlItem layoutControlItem127;
        private LayoutControlItem layoutControlItem128;
        private LayoutControlItem layoutControlItem129;
        private LayoutControlItem layoutControlItem13;
        private LayoutControlItem layoutControlItem130;
        private LayoutControlItem layoutControlItem131;
        private LayoutControlItem layoutControlItem132;
        private LayoutControlItem layoutControlItem133;
        private LayoutControlItem layoutControlItem134;
        private LayoutControlItem layoutControlItem138;
        private LayoutControlItem layoutControlItem139;
        private LayoutControlItem layoutControlItem140;
        private LayoutControlItem layoutControlItem141;
        private LayoutControlItem layoutControlItem142;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem24;
        private LayoutControlItem layoutControlItem25;
        private LayoutControlItem layoutControlItem26;
        private LayoutControlItem layoutControlItem29;
        private LayoutControlItem layoutControlItem30;
        private LayoutControlItem layoutControlItem31;
        private LayoutControlItem layoutControlItem32;
        private LayoutControlItem layoutControlItem33;
        private LayoutControlItem layoutControlItem34;
        private LayoutControlItem layoutControlItem345;
        private LayoutControlItem layoutControlItem346;
        private LayoutControlItem layoutControlItem347;
        private LayoutControlItem layoutControlItem348;
        private LayoutControlItem layoutControlItem349;
        private LayoutControlItem layoutControlItem35;
        private LayoutControlItem layoutControlItem350;
        private LayoutControlItem layoutControlItem351;
        private LayoutControlItem layoutControlItem352;
        private LayoutControlItem layoutControlItem353;
        private LayoutControlItem layoutControlItem354;
        private LayoutControlItem layoutControlItem355;
        private LayoutControlItem layoutControlItem356;
        private LayoutControlItem layoutControlItem357;
        private LayoutControlItem layoutControlItem358;
        private LayoutControlItem layoutControlItem359;
        private LayoutControlItem layoutControlItem36;
        private LayoutControlItem layoutControlItem360;
        private LayoutControlItem layoutControlItem361;
        private LayoutControlItem layoutControlItem362;
        private LayoutControlItem layoutControlItem363;
        private LayoutControlItem layoutControlItem364;
        private LayoutControlItem layoutControlItem365;
        private LayoutControlItem layoutControlItem366;
        private LayoutControlItem layoutControlItem367;
        private LayoutControlItem layoutControlItem368;
        private LayoutControlItem layoutControlItem369;
        private LayoutControlItem layoutControlItem37;
        private LayoutControlItem layoutControlItem370;
        private LayoutControlItem layoutControlItem371;
        private LayoutControlItem layoutControlItem372;
        private LayoutControlItem layoutControlItem373;
        private LayoutControlItem layoutControlItem374;
        private LayoutControlItem layoutControlItem375;
        private LayoutControlItem layoutControlItem376;
        private LayoutControlItem layoutControlItem377;
        private LayoutControlItem layoutControlItem378;
        private LayoutControlItem layoutControlItem379;
        private LayoutControlItem layoutControlItem380;
        private LayoutControlItem layoutControlItem42;
        private LayoutControlItem layoutControlItem43;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem lbldengekatsayi;
        public myData LiftDataform;
        private DataTable makinehalatcapisi = new DataTable();
        public string ney = "";
        private bool nonNumberEntered = false;
        private RadioGroup otokaptip;
        private PictureEdit otokaptippicture;
        private Panel panel1;
        private SearchLookUpEdit regulatormarka;
        private GridView searchLookUpEdit2View;
        private GridView searchLookUpEdit3View;
        private GridView searchLookUpEdit4View;
        private GridView searchLookUpEdit5View;
        private GridView searchLookUpEdit6View;
        private GridView searchLookUpEdit7View;
        private GridView searchLookUpEdit8View;
        private GridView searchLookUpEdit9View;
        private structTahrikTip sTT;
        private abc1 xx = new abc1();
        private TextEdit yanagirsayisi;
        private LookUpEdit yangindayanim;
        private int yangindayaniminey = 0;

        public MainForm2()
        {
            this.InitializeComponent();
        }

        private void acilmayon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.acilmayon.SelectedIndex == 0)
            {
                this.LiftDataform.Mentese = "SAG";
            }
            else
            {
                this.LiftDataform.Mentese = "SOL";
            }
        }

        private void adresiolustur(object sender, EventArgs e)
        {
            this.bacim();
        }

        private void agrmarka_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void aryz_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.defaultLookAndFeel1.LookAndFeel.SkinName = this.gorunumayar.Text;
            this.incik.Write("GenAyar", "sknname", this.gorunumayar.SelectedIndex.ToString());
        }

        public void bacim()
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string text = "";
            string str7 = "";
            string str8 = "";
            if (this.dosyamahalle.Text != "")
            {
                str = this.dosyamahalle.Text + " MAH. ";
            }
            if (this.dosyasokak.Text != "")
            {
                str2 = this.dosyasokak.Text + " SOK. ";
            }
            if (this.dosyacadde.Text != "")
            {
                str3 = this.dosyacadde.Text + " CAD. ";
            }
            if (this.dosyano.Text != "")
            {
                str4 = " NO:" + this.dosyano.Text + " ";
            }
            if (this.dosyailce.Text != "")
            {
                str5 = this.dosyailce.Text + " / ";
            }
            if (this.dosyail.Text != "")
            {
                text = this.dosyail.Text;
            }
            if (this.dosyablok.Text != "")
            {
                str8 = this.dosyablok.Text + " BLOK ";
            }
            if (this.dosyabulvar.Text != "")
            {
                str7 = this.dosyabulvar.Text + " BULVARI ";
            }
            string[] textArray1 = new string[] { str, str3, str7, str2, str4, str8, str5, text };
            this.dosyaadres.Text = string.Concat(textArray1);
        }

        private void backstageViewButtonItem1_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            this.LiftDataform = this.asc.KapiDegerSet(this.LiftDataform);
            this.asc.LiftDataYaz(this.LiftDataform, this.AsansorSayisi.ToString());
            base.Close();
        }

        private void backstageViewClientControl1_Load(object sender, EventArgs e)
        {
        }

        private void backstageViewClientControl2_Load(object sender, EventArgs e)
        {
        }

        private void baritdokumkendibilgisi_CheckedChanged(object sender, EventArgs e)
        {
            this.karsiagren.Enabled = true;
            this.karsiagrboy.Enabled = true;
            this.karsiagryukseklik.Enabled = true;
            this.karsiagrozgulkutle.Enabled = true;
            this.karsiagrbirimagirlik.Enabled = true;
            this.karsiagren.Properties.BorderStyle = BorderStyles.Default;
            this.karsiagrboy.Properties.BorderStyle = BorderStyles.Default;
            this.karsiagryukseklik.Properties.BorderStyle = BorderStyles.Default;
            this.karsiagrozgulkutle.Properties.BorderStyle = BorderStyles.Default;
            this.karsiagrbirimagirlik.Properties.BorderStyle = BorderStyles.Default;
            this.karsiagren.Enabled = false;
            this.karsiagrboy.Enabled = false;
            this.karsiagryukseklik.Enabled = false;
            this.karsiagrozgulkutle.Enabled = false;
            this.karsiagrbirimagirlik.Enabled = false;
            this.karsiagren.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagrboy.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagryukseklik.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagrozgulkutle.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagrbirimagirlik.Properties.BorderStyle = BorderStyles.NoBorder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.karkasyaziyazar();
        }

        private void buyutur(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.kapisolcheck.Checked)
            {
                this.kapisolimage.Image = resourceimage("sol");
            }
            else
            {
                this.kapisolimage.Image = null;
            }
            if (this.kapisagcheck.Checked)
            {
                this.kapisagimage.Image = resourceimage("sag");
            }
            else
            {
                this.kapisagimage.Image = null;
            }
            if (this.kapiarkacheck.Checked)
            {
                this.kapiarkaimage.Image = resourceimage("ust");
            }
            else
            {
                this.kapiarkaimage.Image = null;
            }
        }

        private void decimal_KeyDown(object sender, KeyEventArgs e)
        {
            this.nonNumberEntered = false;
            if ((e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Oemcomma))
            {
                this.nonNumberEntered = false;
            }
            else if ((((e.KeyCode < Keys.D0) || (e.KeyCode > Keys.D9)) && ((e.KeyCode < Keys.NumPad0) || (e.KeyCode > Keys.NumPad9))) && (e.KeyCode != Keys.Back))
            {
                this.nonNumberEntered = true;
            }
        }

        private void decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void dilayar()
        {
            this.dilsecimi.Properties.Items.Clear();
            DataTable table = this.xx.dtta("select gorunurad,kisaad from dilcesitleri", "");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                this.dilsecimi.Properties.Items.Add(table.Rows[i]["gorunurad"].ToString());
            }
            this.dildata = this.xx.dtta("select " + this.incik.Read("prgayar", "dil") + ",number from diller", "");
            if (this.incik.Read("prgayar", "dil") == "")
            {
                this.incik.Write("prgayar", "dil", "TR");
            }
            this.dilsecimi.Text = this.xx.dtta("select gorunurad from dilcesitleri where kisaad='" + this.incik.Read("prgayar", "dil") + "'", "").Rows[0][0].ToString();
            this.Text = this.xx.dilci(0x77, this.dildata);
            this.backstageViewTabItem1.Caption = this.xx.dilci(120, this.dildata);
            this.backstageViewTabItem2.Caption = this.xx.dilci(0x79, this.dildata);
            this.backstageViewTabItem3.Caption = this.xx.dilci(0x59, this.dildata);
            this.backstageViewTabItem4.Caption = this.xx.dilci(0x7b, this.dildata);
            this.backstageViewTabItem5.Caption = this.xx.dilci(0xb1, this.dildata);
            this.kapimmarmodel.Properties.Columns[0].Caption = this.xx.dilci(30, this.dildata);
            this.labelkapitipsecimi.Text = this.xx.dilci(0x27, this.dildata);
            this.labelkapigenisligi.Text = this.xx.dilci(40, this.dildata);
            this.labelkapikaplamasi.Text = this.xx.dilci(0x29, this.dildata);
            this.labelkapikaplamamarka.Text = this.xx.dilci(110, this.dildata);
            this.labelyangindayanim.Text = this.xx.dilci(0x2b, this.dildata);
            this.kuyuyaradio.Text = this.xx.dilci(0x2c, this.dildata);
            this.kathizasiradio.Text = this.xx.dilci(0x2d, this.dildata);
            this.kataradio.Text = this.xx.dilci(0x2e, this.dildata);
            this.kapitipi.Properties.Items[0].Description = this.xx.dilci(0x2f, this.dildata);
            this.kapitipi.Properties.Items[1].Description = this.xx.dilci(0x30, this.dildata);
            this.kapitipi.Properties.Items[2].Description = this.xx.dilci(0x31, this.dildata);
            this.kapitipi.Properties.Items[3].Description = this.xx.dilci(50, this.dildata);
            this.kapitipi.Properties.Items[4].Description = this.xx.dilci(0x33, this.dildata);
            this.otokaptip.Properties.Items[0].Description = this.xx.dilci(0x34, this.dildata);
            this.otokaptip.Properties.Items[1].Description = this.xx.dilci(0x35, this.dildata);
            this.otokaptip.Properties.Items[2].Description = this.xx.dilci(0x36, this.dildata);
            this.otokaptip.Properties.Items[3].Description = this.xx.dilci(0x37, this.dildata);
            this.otokaptip.Properties.Items[4].Description = this.xx.dilci(0x38, this.dildata);
            this.acilmayon.Properties.Items[0].Description = this.xx.dilci(0x39, this.dildata);
            this.acilmayon.Properties.Items[1].Description = this.xx.dilci(0x3a, this.dildata);
            this.acilmayon.Properties.Items[2].Description = this.xx.dilci(0x3b, this.dildata);
            this.kapikaplama.Properties.Columns[0].Caption = this.xx.dilci(60, this.dildata);
            this.yangindayanim.Properties.Columns[0].Caption = this.xx.dilci(0x3d, this.dildata);
            this.label3regmarka.Text = this.xx.dilci(0x47, this.dildata);
            this.label3baritdokum.Text = this.xx.dilci(0x4c, this.dildata);
            this.label3modelsec.Text = this.xx.dilci(0x4d, this.dildata);
            this.label3enbilgisi.Text = this.xx.dilci(0x4f, this.dildata);
            this.label3boybilgisi.Text = this.xx.dilci(80, this.dildata);
            this.label3yukseklikbilgisi.Text = this.xx.dilci(0x51, this.dildata);
            this.label3ozgulkutle.Text = this.xx.dilci(0x52, this.dildata);
            this.label3birimagr.Text = this.xx.dilci(0x53, this.dildata);
            this.label3karkasagr.Text = this.xx.dilci(0x54, this.dildata);
            this.label3yanagr.Text = this.xx.dilci(0x55, this.dildata);
            this.label3arkaagr.Text = this.xx.dilci(0x56, this.dildata);
            this.label3karsiagirlik.Text = this.xx.dilci(0x58, this.dildata);
            this.label3regulatorbilgi.Text = this.xx.dilci(90, this.dildata);
            this.label3enmm.Text = this.xx.dilci(13, this.dildata);
            this.label3boymm.Text = this.xx.dilci(13, this.dildata);
            this.label3yuksekmm.Text = this.xx.dilci(13, this.dildata);
            this.label3birimkg.Text = this.xx.dilci(0x1d, this.dildata);
            this.label3kutlekg.Text = this.xx.dilci(0x1d, this.dildata);
            this.karkasgrup.Properties.Items[0].Description = this.xx.dilci(0xba, this.dildata);
            this.karkasgrup.Properties.Items[1].Description = this.xx.dilci(0xbb, this.dildata);
            this.lbldengekatsayi.Text = this.xx.dilci(0xbc, this.dildata);
            this.dileklemebuton.Text = this.xx.dilci(0x5c, this.dildata);
            this.labeldilaciklama.Text = this.xx.dilci(0x5b, this.dildata);
            this.labeldilsecimi.Text = this.xx.dilci(0x70, this.dildata);
            this.labelgorunumayar.Text = this.xx.dilci(0x71, this.dildata);
            this.labelversiyonyazi.Text = this.xx.dilci(0x72, this.dildata);
            this.dosyalblmodul.Text = this.xx.dilci(0x7c, this.dildata);
            this.dosyalblasansorsahip.Text = this.xx.dilci(0x7d, this.dildata);
            this.dosyalblmahalle.Text = this.xx.dilci(0x7e, this.dildata);
            this.dosyalblsokak.Text = this.xx.dilci(0x7f, this.dildata);
            this.dosyalblcadde.Text = this.xx.dilci(0x80, this.dildata);
            this.dosyalblbulvar.Text = this.xx.dilci(0x81, this.dildata);
            this.dosyalblno.Text = this.xx.dilci(130, this.dildata);
            this.dosyalblblok.Text = this.xx.dilci(0x83, this.dildata);
            this.dosyalblil.Text = this.xx.dilci(0x84, this.dildata);
            this.dosyalblilce.Text = this.xx.dilci(0x85, this.dildata);
            this.dosyalbladres.Text = this.xx.dilci(0x86, this.dildata);
            this.dosyalblbelediye.Text = this.xx.dilci(0x87, this.dildata);
            this.dosyalblpafta.Text = this.xx.dilci(0x88, this.dildata);
            this.dosyalblada.Text = this.xx.dilci(0x89, this.dildata);
            this.dosyalblparsel.Text = this.xx.dilci(0x8a, this.dildata);
            this.dosyalblsinif.Text = this.xx.dilci(0x8b, this.dildata);
            this.dosyalblasnno.Text = this.xx.dilci(140, this.dildata);
            this.dosyalblservistar.Text = this.xx.dilci(0x8d, this.dildata);
            this.dosyalblbinasahip.Text = this.xx.dilci(0x8e, this.dildata);
            this.dosyalblbinasahiptc.Text = this.xx.dilci(0x8f, this.dildata);
            this.dosyalblbinasahipvn.Text = this.xx.dilci(0x90, this.dildata);
            this.dosyalblbinasahipvd.Text = this.xx.dilci(0x91, this.dildata);
            this.dosyalblmuteaahhit.Text = this.xx.dilci(0x92, this.dildata);
            this.dosyalblmuteaahhittc.Text = this.xx.dilci(0x93, this.dildata);
            this.dosyalblmuteaahhitvn.Text = this.xx.dilci(0x94, this.dildata);
            this.dosyalblmuteaahhitvd.Text = this.xx.dilci(0x95, this.dildata);
            this.dosyaslblertfsec.Text = this.xx.dilci(150, this.dildata);
            this.dosyalblurserno.Text = this.xx.dilci(0x97, this.dildata);
            this.dosyalblsertf.Text = this.xx.dilci(0x98, this.dildata);
            this.dosyakapikilitlbl.Text = this.xx.dilci(0x9a, this.dildata);
            this.dosyafrenbloklbl.Text = this.xx.dilci(0x9b, this.dildata);
            this.dosyaagrtamponlbl.Text = this.xx.dilci(0x9c, this.dildata);
            this.dosyakabintamponlbl.Text = this.xx.dilci(0x9d, this.dildata);
            this.dosyakumandakartilbl.Text = this.xx.dilci(0x9e, this.dildata);
            this.dosyapanolbl.Text = this.xx.dilci(0x9f, this.dildata);
            this.dosyaregulatorlbl.Text = this.xx.dilci(160, this.dildata);
            this.dosyaa3ekipmanlbl.Text = this.xx.dilci(0xa1, this.dildata);
            this.dosyapistonvalfilbl.Text = this.xx.dilci(0xa2, this.dildata);
            this.dosyakapikilitgor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyafrenblokgor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyaagrtampongor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyakabintampongor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyakumandakartigor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyapanogor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyaregulatorgor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyaa3ekipmangor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyapistonvalfigor.Text = this.xx.dilci(0xa3, this.dildata);
            this.dosyalblelektrasnicin.Text = this.xx.dilci(0xa5, this.dildata);
            this.dosyalblmalz.Text = this.xx.dilci(0xa6, this.dildata);
            this.dosyalblmalz2.Text = this.xx.dilci(0xa6, this.dildata);
            this.dosyalbluret.Text = this.xx.dilci(0xa7, this.dildata);
            this.dosyalbluret2.Text = this.xx.dilci(0xa7, this.dildata);
            this.dosyalblmodel.Text = this.xx.dilci(0x1f, this.dildata);
            this.dosyalblmodel2.Text = this.xx.dilci(0x1f, this.dildata);
            this.dosyalblbelgeno.Text = this.xx.dilci(0xa9, this.dildata);
            this.dosyalblbelgeno2.Text = this.xx.dilci(0xa9, this.dildata);
            this.dosyalblonaylayan.Text = this.xx.dilci(170, this.dildata);
            this.dosyalblonaylayan2.Text = this.xx.dilci(170, this.dildata);
            this.dosyalblserino.Text = this.xx.dilci(0x97, this.dildata);
            this.dosyalblserino2.Text = this.xx.dilci(0x97, this.dildata);
            this.dosyahidasnicin.Text = this.xx.dilci(0xac, this.dildata);
            this.dosyalbldebi.Text = this.xx.dilci(0xad, this.dildata);
            this.dosyalblhortum.Text = this.xx.dilci(0xae, this.dildata);
            this.dosyalblmakine.Text = this.xx.dilci(0xaf, this.dildata);
            this.dosyalblmotor.Text = this.xx.dilci(0xb0, this.dildata);
            this.regulatormarka.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyakapikilit.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyafrenblok.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyaagrtampon.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyakabintampon.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyakumandakarti.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyapano.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyaregulator.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyaa3ekipman.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
            this.dosyapistonvalfi.Properties.View.Columns["MARKA_MODEL"].Caption = this.xx.dilci(0xb2, this.dildata);
        }

        private void dileklemebuton_Click(object sender, EventArgs e)
        {
            new dilekler { dildata = this.dildata }.ShowDialog();
            this.gridviewdiller.Columns.Clear();
            DataTable table = this.xx.dtta("select gorunurad,kisaad from dilcesitleri", "");
            string str = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                str = str + table.Rows[i]["kisaad"].ToString() + ",";
            }
            this.gridcontroldiller.DataSource = this.xx.dtta("select number," + str.Substring(0, str.Length - 1) + " from diller", "");
            for (int j = 1; j < this.gridviewdiller.Columns.Count; j++)
            {
                this.gridviewdiller.Columns[j].Caption = table.Rows[j - 1]["gorunurad"].ToString();
            }
            this.gridviewdiller.Columns[0].Visible = false;
            this.gridviewdiller.Columns[0].OptionsColumn.AllowEdit = false;
            this.gridviewdiller.Columns[1].OptionsColumn.AllowEdit = false;
        }

        private void dilsecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.xx.dtta("select kisaad from dilcesitleri where gorunurad='" + this.dilsecimi.Text + "'", "").Rows[0][0].ToString();
            this.incik.Write("prgayar", "dil", str);
            this.dilayar();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dosyaa3ekipman_click(object sender, EventArgs e)
        {
            this.hangi(this.dosyaa3ekipman);
        }

        private void dosyaagrtampon_click(object sender, EventArgs e)
        {
            this.hangi(this.dosyaagrtampon);
        }

        private void dosyafrenblok_click(object sender, EventArgs e)
        {
            this.hangi(this.dosyafrenblok);
        }

        private void dosyafrenblok_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void dosyakabintampon_click(object sender, EventArgs e)
        {
            this.hangi(this.dosyakabintampon);
        }

        private void dosyakapikilitgor_Click(object sender, EventArgs e)
        {
            this.hangi(this.dosyakapikilit);
        }

        private void dosyakumandakarti_click(object sender, EventArgs e)
        {
            this.hangi(this.dosyakumandakarti);
        }

        private void dosyapano_click(object sender, EventArgs e)
        {
            this.hangi(this.dosyapano);
        }

        private void dosyapistonvalfi_click(object sender, EventArgs e)
        {
            this.hangi(this.dosyapistonvalfi);
        }

        private void dosyaregulator_click(object sender, EventArgs e)
        {
            this.hangi(this.dosyaregulator);
        }

        private void dosyaregulator_EditValueChanged(object sender, EventArgs e)
        {
            this.regulatormarka.EditValue = this.dosyaregulator.EditValue;
        }

        private void flatci(RadioButton radyo)
        {
            if (radyo.Checked)
            {
                radyo.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                radyo.FlatStyle = FlatStyle.Standard;
            }
        }

        private void gridviewdiller_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            this.xx.oleupdate("update diller set " + e.Column.FieldName + "='" + e.Value.ToString() + "' where number=" + this.gridviewdiller.GetRowCellValue(e.RowHandle, "number").ToString(), "");
        }

        public string hangi(SearchLookUpEdit s)
        {
            string str2 = "";
            string str3 = "";
            string str4 = "";
            if (((Convert.ToString(s.EditValue) != "0") && (Convert.ToString(s.EditValue) != "-1")) && (Convert.ToString(s.EditValue) != ""))
            {
                DataTable table = this.xx.dtta("select tedarikid,guid,edit,model,malzeme,degisti from tedarik where guid='" + s.EditValue + "'", "");
                string startupPath = "";
                str2 = table.Rows[0]["malzeme"].ToString();
                str3 = table.Rows[0]["tedarikid"].ToString();
                str4 = table.Rows[0]["edit"].ToString();
                if (Convert.ToBoolean(table.Rows[0]["degisti"]))
                {
                    startupPath = Application.StartupPath;
                }
                else
                {
                    startupPath = "http://www.misaasansor.com.tr/cert";
                }
                Process.Start(startupPath + @"\sertifika\" + str2 + @"\" + str3 + @"\" + str4);
            }
            return "";
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(MainForm2));
            this.backstageViewControl1 = new BackstageViewControl();
            this.backstageViewClientControl1 = new BackstageViewClientControl();
            this.backstageViewClientControl2 = new BackstageViewClientControl();
            this.groupBox2 = new GroupBox();
            this.kapitipi = new RadioGroup();
            this.layoutControl7 = new LayoutControl();
            this.kapiarkaimage = new PictureBox();
            this.kapionimage = new PictureBox();
            this.kapisagimage = new PictureBox();
            this.kapisolimage = new PictureBox();
            this.kapikabinimage = new PictureBox();
            this.layoutControlGroup2 = new LayoutControlGroup();
            this.layoutControlItem26 = new LayoutControlItem();
            this.layoutControlItem29 = new LayoutControlItem();
            this.layoutControlItem31 = new LayoutControlItem();
            this.layoutControlItem33 = new LayoutControlItem();
            this.layoutControlItem34 = new LayoutControlItem();
            this.groupControl5 = new GroupControl();
            this.kuyuyatext = new TextEdit();
            this.katatext = new TextEdit();
            this.kuyuyaradio = new RadioButton();
            this.kataradio = new RadioButton();
            this.kathizasiradio = new RadioButton();
            this.kapisagcheck = new CheckEdit();
            this.kapiarkacheck = new CheckEdit();
            this.kapisolcheck = new CheckEdit();
            this.labelkapitipsecimi = new GroupControl();
            this.layoutControl8 = new LayoutControl();
            this.acilmayon = new RadioGroup();
            this.kapigen = new TextEdit();
            this.kapimmarmodel = new LookUpEdit();
            this.yangindayanim = new LookUpEdit();
            this.kapikaplama = new LookUpEdit();
            this.layoutControlGroup3 = new LayoutControlGroup();
            this.labelkapigenisligi = new LayoutControlItem();
            this.labelkapikaplamasi = new LayoutControlItem();
            this.labelkapikaplamamarka = new LayoutControlItem();
            this.labelyangindayanim = new LayoutControlItem();
            this.layoutControlItem12 = new LayoutControlItem();
            this.otokaptippicture = new PictureEdit();
            this.kapitippicture = new PictureEdit();
            this.otokaptip = new RadioGroup();
            this.backstageViewClientControl6 = new BackstageViewClientControl();
            this.backstageViewClientControl3 = new BackstageViewClientControl();
            this.layoutControl3 = new LayoutControl();
            this.panel1 = new Panel();
            this.label3karsiagirlik = new LabelControl();
            this.dengekatsayisi = new TextEdit();
            this.karkasgrup = new RadioGroup();
            this.karsiagrozgulkutle = new TextEdit();
            this.label3regulatorbilgi = new LabelControl();
            this.label3birimkg = new LabelControl();
            this.label3kutlekg = new LabelControl();
            this.label3yuksekmm = new LabelControl();
            this.karsiagrbirimagirlik = new TextEdit();
            this.karkasagirlik = new TextEdit();
            this.arkaagirsayisi = new TextEdit();
            this.yanagirsayisi = new TextEdit();
            this.karsiagryukseklik = new TextEdit();
            this.label3boymm = new LabelControl();
            this.karsiagrboy = new TextEdit();
            this.label3enmm = new LabelControl();
            this.regulatormarka = new SearchLookUpEdit();
            this.gridView3 = new GridView();
            this.gridColumn65 = new GridColumn();
            this.gridColumn66 = new GridColumn();
            this.gridColumn67 = new GridColumn();
            this.gridColumn68 = new GridColumn();
            this.gridColumn69 = new GridColumn();
            this.gridColumn70 = new GridColumn();
            this.karsiagren = new TextEdit();
            this.karsiagrsecim = new LookUpEdit();
            this.karsiagrmodel = new LookUpEdit();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem13 = new LayoutControlItem();
            this.label3regmarka = new LayoutControlItem();
            this.layoutControlItem24 = new LayoutControlItem();
            this.label3baritdokum = new LayoutControlItem();
            this.label3modelsec = new LayoutControlItem();
            this.label3enbilgisi = new LayoutControlItem();
            this.layoutControlItem30 = new LayoutControlItem();
            this.label3boybilgisi = new LayoutControlItem();
            this.layoutControlItem32 = new LayoutControlItem();
            this.label3yukseklikbilgisi = new LayoutControlItem();
            this.layoutControlItem35 = new LayoutControlItem();
            this.layoutControlItem36 = new LayoutControlItem();
            this.layoutControlItem37 = new LayoutControlItem();
            this.lbldengekatsayi = new LayoutControlItem();
            this.label3karkasagr = new LayoutControlItem();
            this.label3yanagr = new LayoutControlItem();
            this.label3arkaagr = new LayoutControlItem();
            this.layoutControlItem42 = new LayoutControlItem();
            this.label3ozgulkutle = new LayoutControlItem();
            this.label3birimagr = new LayoutControlItem();
            this.layoutControlItem25 = new LayoutControlItem();
            this.backstageViewClientControl5 = new BackstageViewClientControl();
            this.dosyahidasnicin = new GroupControl();
            this.layoutControl23 = new LayoutControl();
            this.dosyahortumserino = new TextEdit();
            this.dosyahortumonaylayan = new TextEdit();
            this.dosyahortumbelgeno = new TextEdit();
            this.dosyahortummodel = new TextEdit();
            this.dosyahortumuretici = new TextEdit();
            this.dosyalblhortum = new LabelControl();
            this.dosyalblserino2 = new LabelControl();
            this.dosyalblonaylayan2 = new LabelControl();
            this.dosyalblbelgeno2 = new LabelControl();
            this.dosyalblmodel2 = new LabelControl();
            this.dosyalbldebi = new LabelControl();
            this.dosyalbluret2 = new LabelControl();
            this.dosyalblmalz2 = new LabelControl();
            this.dosyadebiserino = new TextEdit();
            this.dosyadebionaylayan = new TextEdit();
            this.dosyadebibelgeno = new TextEdit();
            this.dosyadebimodel = new TextEdit();
            this.dosyadebiuret = new TextEdit();
            this.layoutControlGroup23 = new LayoutControlGroup();
            this.layoutControlItem345 = new LayoutControlItem();
            this.layoutControlItem346 = new LayoutControlItem();
            this.layoutControlItem347 = new LayoutControlItem();
            this.layoutControlItem348 = new LayoutControlItem();
            this.layoutControlItem349 = new LayoutControlItem();
            this.layoutControlItem350 = new LayoutControlItem();
            this.layoutControlItem351 = new LayoutControlItem();
            this.layoutControlItem352 = new LayoutControlItem();
            this.layoutControlItem353 = new LayoutControlItem();
            this.layoutControlItem354 = new LayoutControlItem();
            this.layoutControlItem355 = new LayoutControlItem();
            this.layoutControlItem356 = new LayoutControlItem();
            this.layoutControlItem357 = new LayoutControlItem();
            this.layoutControlItem358 = new LayoutControlItem();
            this.layoutControlItem359 = new LayoutControlItem();
            this.layoutControlItem360 = new LayoutControlItem();
            this.layoutControlItem361 = new LayoutControlItem();
            this.layoutControlItem362 = new LayoutControlItem();
            this.dosyalblelektrasnicin = new GroupControl();
            this.layoutControl24 = new LayoutControl();
            this.dosyamotorserino = new TextEdit();
            this.dosyamotoronaylayan = new TextEdit();
            this.dosyamotorbelgeno = new TextEdit();
            this.dosyamotormodel = new TextEdit();
            this.dosyamotoruretici = new TextEdit();
            this.dosyalblmotor = new LabelControl();
            this.dosyalblserino = new LabelControl();
            this.dosyalblonaylayan = new LabelControl();
            this.dosyalblbelgeno = new LabelControl();
            this.dosyalblmodel = new LabelControl();
            this.dosyalblmakine = new LabelControl();
            this.dosyalbluret = new LabelControl();
            this.dosyalblmalz = new LabelControl();
            this.dosyamakineurserno = new TextEdit();
            this.dosyamakineonaylayan = new TextEdit();
            this.dosyamakinebelgeno = new TextEdit();
            this.dosyamakinemodel = new TextEdit();
            this.dosyamakineuret = new TextEdit();
            this.layoutControlGroup24 = new LayoutControlGroup();
            this.layoutControlItem363 = new LayoutControlItem();
            this.layoutControlItem364 = new LayoutControlItem();
            this.layoutControlItem365 = new LayoutControlItem();
            this.layoutControlItem366 = new LayoutControlItem();
            this.layoutControlItem367 = new LayoutControlItem();
            this.layoutControlItem368 = new LayoutControlItem();
            this.layoutControlItem369 = new LayoutControlItem();
            this.layoutControlItem370 = new LayoutControlItem();
            this.layoutControlItem371 = new LayoutControlItem();
            this.layoutControlItem372 = new LayoutControlItem();
            this.layoutControlItem373 = new LayoutControlItem();
            this.layoutControlItem374 = new LayoutControlItem();
            this.layoutControlItem375 = new LayoutControlItem();
            this.layoutControlItem376 = new LayoutControlItem();
            this.layoutControlItem377 = new LayoutControlItem();
            this.layoutControlItem378 = new LayoutControlItem();
            this.layoutControlItem379 = new LayoutControlItem();
            this.layoutControlItem380 = new LayoutControlItem();
            this.layoutControl6 = new LayoutControl();
            this.dosyakapikilit = new SearchLookUpEdit();
            this.gridView1 = new GridView();
            this.gridColumn64 = new GridColumn();
            this.gridColumn73 = new GridColumn();
            this.gridColumn74 = new GridColumn();
            this.gridColumn75 = new GridColumn();
            this.gridColumn76 = new GridColumn();
            this.gridColumn77 = new GridColumn();
            this.gridColumn78 = new GridColumn();
            this.dosyalblsertf = new LabelControl();
            this.dosyalblurserno = new LabelControl();
            this.dosyaslblertfsec = new LabelControl();
            this.dosyapanosn = new TextEdit();
            this.dosyapanogor = new SimpleButton();
            this.dosyapano = new SearchLookUpEdit();
            this.searchLookUpEdit6View = new GridView();
            this.gridColumn31 = new GridColumn();
            this.gridColumn32 = new GridColumn();
            this.gridColumn33 = new GridColumn();
            this.gridColumn34 = new GridColumn();
            this.gridColumn35 = new GridColumn();
            this.gridColumn36 = new GridColumn();
            this.dosyapistonvalfisn = new TextEdit();
            this.dosyaa3ekipmansn = new TextEdit();
            this.dosyaregulatorsn = new TextEdit();
            this.dosyakumandakartisn = new TextEdit();
            this.dosyakabintamponsn = new TextEdit();
            this.dosyaagrtamponsn = new TextEdit();
            this.dosyafrenbloksn = new TextEdit();
            this.dosyakapikilitsn = new TextEdit();
            this.dosyapistonvalfi = new SearchLookUpEdit();
            this.searchLookUpEdit9View = new GridView();
            this.gridColumn49 = new GridColumn();
            this.gridColumn50 = new GridColumn();
            this.gridColumn51 = new GridColumn();
            this.gridColumn52 = new GridColumn();
            this.gridColumn53 = new GridColumn();
            this.gridColumn54 = new GridColumn();
            this.dosyaa3ekipman = new SearchLookUpEdit();
            this.searchLookUpEdit8View = new GridView();
            this.gridColumn43 = new GridColumn();
            this.gridColumn44 = new GridColumn();
            this.gridColumn45 = new GridColumn();
            this.gridColumn46 = new GridColumn();
            this.gridColumn47 = new GridColumn();
            this.gridColumn48 = new GridColumn();
            this.dosyaregulator = new SearchLookUpEdit();
            this.searchLookUpEdit7View = new GridView();
            this.gridColumn37 = new GridColumn();
            this.gridColumn38 = new GridColumn();
            this.gridColumn39 = new GridColumn();
            this.gridColumn40 = new GridColumn();
            this.gridColumn41 = new GridColumn();
            this.gridColumn42 = new GridColumn();
            this.dosyakumandakarti = new SearchLookUpEdit();
            this.searchLookUpEdit5View = new GridView();
            this.gridColumn25 = new GridColumn();
            this.gridColumn26 = new GridColumn();
            this.gridColumn27 = new GridColumn();
            this.gridColumn28 = new GridColumn();
            this.gridColumn29 = new GridColumn();
            this.gridColumn30 = new GridColumn();
            this.dosyakabintampon = new SearchLookUpEdit();
            this.searchLookUpEdit4View = new GridView();
            this.gridColumn19 = new GridColumn();
            this.gridColumn20 = new GridColumn();
            this.gridColumn21 = new GridColumn();
            this.gridColumn22 = new GridColumn();
            this.gridColumn23 = new GridColumn();
            this.gridColumn24 = new GridColumn();
            this.dosyaagrtampon = new SearchLookUpEdit();
            this.searchLookUpEdit3View = new GridView();
            this.gridColumn13 = new GridColumn();
            this.gridColumn14 = new GridColumn();
            this.gridColumn15 = new GridColumn();
            this.gridColumn16 = new GridColumn();
            this.gridColumn17 = new GridColumn();
            this.gridColumn18 = new GridColumn();
            this.dosyafrenblok = new SearchLookUpEdit();
            this.searchLookUpEdit2View = new GridView();
            this.gridColumn10 = new GridColumn();
            this.gridColumn11 = new GridColumn();
            this.gridColumn12 = new GridColumn();
            this.gridColumn55 = new GridColumn();
            this.gridColumn56 = new GridColumn();
            this.gridColumn57 = new GridColumn();
            this.dosyaa3ekipmangor = new SimpleButton();
            this.dosyapistonvalfigor = new SimpleButton();
            this.dosyaregulatorgor = new SimpleButton();
            this.dosyakumandakartigor = new SimpleButton();
            this.dosyakabintampongor = new SimpleButton();
            this.dosyaagrtampongor = new SimpleButton();
            this.dosyafrenblokgor = new SimpleButton();
            this.dosyakapikilitgor = new SimpleButton();
            this.layoutControlGroup10 = new LayoutControlGroup();
            this.layoutControlItem103 = new LayoutControlItem();
            this.layoutControlItem104 = new LayoutControlItem();
            this.layoutControlItem105 = new LayoutControlItem();
            this.layoutControlItem106 = new LayoutControlItem();
            this.layoutControlItem107 = new LayoutControlItem();
            this.layoutControlItem108 = new LayoutControlItem();
            this.layoutControlItem109 = new LayoutControlItem();
            this.layoutControlItem110 = new LayoutControlItem();
            this.dosyafrenbloklbl = new LayoutControlItem();
            this.dosyaagrtamponlbl = new LayoutControlItem();
            this.dosyakabintamponlbl = new LayoutControlItem();
            this.dosyakumandakartilbl = new LayoutControlItem();
            this.dosyaregulatorlbl = new LayoutControlItem();
            this.dosyaa3ekipmanlbl = new LayoutControlItem();
            this.dosyapistonvalfilbl = new LayoutControlItem();
            this.layoutControlItem127 = new LayoutControlItem();
            this.layoutControlItem128 = new LayoutControlItem();
            this.layoutControlItem129 = new LayoutControlItem();
            this.layoutControlItem130 = new LayoutControlItem();
            this.layoutControlItem131 = new LayoutControlItem();
            this.layoutControlItem132 = new LayoutControlItem();
            this.layoutControlItem133 = new LayoutControlItem();
            this.layoutControlItem134 = new LayoutControlItem();
            this.dosyapanolbl = new LayoutControlItem();
            this.layoutControlItem138 = new LayoutControlItem();
            this.layoutControlItem139 = new LayoutControlItem();
            this.layoutControlItem140 = new LayoutControlItem();
            this.layoutControlItem141 = new LayoutControlItem();
            this.layoutControlItem142 = new LayoutControlItem();
            this.dosyakapikilitlbl = new LayoutControlItem();
            this.layoutControl5 = new LayoutControl();
            this.dosyaadres = new RichTextBox();
            this.dosyamutaahhitvd = new TextEdit();
            this.dosyamutaahhitvn = new TextEdit();
            this.dosyamutaahhittc = new TextEdit();
            this.dosyamutaahhit = new TextEdit();
            this.dosyabinasahipvd = new TextEdit();
            this.dosyabinasahipvn = new TextEdit();
            this.dosyabinasahiptc = new TextEdit();
            this.dosyabinasahip = new TextEdit();
            this.dosyaservistar = new TextEdit();
            this.dosyaasansorno = new TextEdit();
            this.dosyasinif = new TextEdit();
            this.dosyaparsel = new TextEdit();
            this.dosyaada = new TextEdit();
            this.dosyapafta = new TextEdit();
            this.dosyabelediye = new TextEdit();
            this.dosyailce = new TextEdit();
            this.dosyail = new TextEdit();
            this.dosyablok = new TextEdit();
            this.dosyano = new TextEdit();
            this.dosyabulvar = new TextEdit();
            this.dosyacadde = new TextEdit();
            this.dosyasokak = new TextEdit();
            this.dosyamahalle = new TextEdit();
            this.dosyaasansorsahib = new TextEdit();
            this.dosyabelgemodul = new ComboBoxEdit();
            this.layoutControlGroup9 = new LayoutControlGroup();
            this.dosyalblmodul = new LayoutControlItem();
            this.dosyalblno = new LayoutControlItem();
            this.dosyalblil = new LayoutControlItem();
            this.dosyalblilce = new LayoutControlItem();
            this.dosyalblbelediye = new LayoutControlItem();
            this.dosyalblpafta = new LayoutControlItem();
            this.dosyalblada = new LayoutControlItem();
            this.dosyalblparsel = new LayoutControlItem();
            this.dosyalblsinif = new LayoutControlItem();
            this.dosyalblasnno = new LayoutControlItem();
            this.dosyalblservistar = new LayoutControlItem();
            this.dosyalblbinasahip = new LayoutControlItem();
            this.dosyalblbinasahiptc = new LayoutControlItem();
            this.dosyalblbinasahipvn = new LayoutControlItem();
            this.dosyalblbinasahipvd = new LayoutControlItem();
            this.dosyalblmuteaahhit = new LayoutControlItem();
            this.dosyalblmuteaahhittc = new LayoutControlItem();
            this.dosyalblmuteaahhitvn = new LayoutControlItem();
            this.dosyalblmuteaahhitvd = new LayoutControlItem();
            this.dosyalblasansorsahip = new LayoutControlItem();
            this.dosyalblblok = new LayoutControlItem();
            this.dosyalblbulvar = new LayoutControlItem();
            this.dosyalblmahalle = new LayoutControlItem();
            this.dosyalblcadde = new LayoutControlItem();
            this.dosyalblsokak = new LayoutControlItem();
            this.dosyalbladres = new LayoutControlItem();
            this.backstageViewClientControl4 = new BackstageViewClientControl();
            this.layoutControl2 = new LayoutControl();
            this.dileklemebuton = new SimpleButton();
            this.labeldilaciklama = new LabelControl();
            this.gridcontroldiller = new GridControl();
            this.gridviewdiller = new GridView();
            this.layoutControlGroup7 = new LayoutControlGroup();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.layoutControlItem43 = new LayoutControlItem();
            this.layoutControl1 = new LayoutControl();
            this.labelversionbilgi = new LabelControl();
            this.labelversiyonyazi = new LabelControl();
            this.dilsecimi = new ComboBoxEdit();
            this.gorunumayar = new ComboBoxEdit();
            this.layoutControlGroup6 = new LayoutControlGroup();
            this.labelgorunumayar = new LayoutControlItem();
            this.labeldilsecimi = new LayoutControlItem();
            this.layoutControlItem8 = new LayoutControlItem();
            this.layoutControlItem10 = new LayoutControlItem();
            this.backstageViewTabItem1 = new BackstageViewTabItem();
            this.backstageViewTabItem2 = new BackstageViewTabItem();
            this.backstageViewTabItem6 = new BackstageViewTabItem();
            this.backstageViewTabItem3 = new BackstageViewTabItem();
            this.backstageViewTabItem5 = new BackstageViewTabItem();
            this.backstageViewTabItem4 = new BackstageViewTabItem();
            this.backstageViewButtonItem1 = new BackstageViewButtonItem();
            this.defaultLookAndFeel1 = new DefaultLookAndFeel(this.components);
            ((ISupportInitialize) this.backstageViewControl1).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            this.backstageViewClientControl2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.kapitipi.Properties.BeginInit();
            this.layoutControl7.BeginInit();
            this.layoutControl7.SuspendLayout();
            ((ISupportInitialize) this.kapiarkaimage).BeginInit();
            ((ISupportInitialize) this.kapionimage).BeginInit();
            ((ISupportInitialize) this.kapisagimage).BeginInit();
            ((ISupportInitialize) this.kapisolimage).BeginInit();
            ((ISupportInitialize) this.kapikabinimage).BeginInit();
            this.layoutControlGroup2.BeginInit();
            this.layoutControlItem26.BeginInit();
            this.layoutControlItem29.BeginInit();
            this.layoutControlItem31.BeginInit();
            this.layoutControlItem33.BeginInit();
            this.layoutControlItem34.BeginInit();
            this.groupControl5.BeginInit();
            this.groupControl5.SuspendLayout();
            this.kuyuyatext.Properties.BeginInit();
            this.katatext.Properties.BeginInit();
            this.kapisagcheck.Properties.BeginInit();
            this.kapiarkacheck.Properties.BeginInit();
            this.kapisolcheck.Properties.BeginInit();
            this.labelkapitipsecimi.BeginInit();
            this.labelkapitipsecimi.SuspendLayout();
            this.layoutControl8.BeginInit();
            this.layoutControl8.SuspendLayout();
            this.acilmayon.Properties.BeginInit();
            this.kapigen.Properties.BeginInit();
            this.kapimmarmodel.Properties.BeginInit();
            this.yangindayanim.Properties.BeginInit();
            this.kapikaplama.Properties.BeginInit();
            this.layoutControlGroup3.BeginInit();
            this.labelkapigenisligi.BeginInit();
            this.labelkapikaplamasi.BeginInit();
            this.labelkapikaplamamarka.BeginInit();
            this.labelyangindayanim.BeginInit();
            this.layoutControlItem12.BeginInit();
            this.otokaptippicture.Properties.BeginInit();
            this.kapitippicture.Properties.BeginInit();
            this.otokaptip.Properties.BeginInit();
            this.backstageViewClientControl3.SuspendLayout();
            this.layoutControl3.BeginInit();
            this.layoutControl3.SuspendLayout();
            this.dengekatsayisi.Properties.BeginInit();
            this.karkasgrup.Properties.BeginInit();
            this.karsiagrozgulkutle.Properties.BeginInit();
            this.karsiagrbirimagirlik.Properties.BeginInit();
            this.karkasagirlik.Properties.BeginInit();
            this.arkaagirsayisi.Properties.BeginInit();
            this.yanagirsayisi.Properties.BeginInit();
            this.karsiagryukseklik.Properties.BeginInit();
            this.karsiagrboy.Properties.BeginInit();
            this.regulatormarka.Properties.BeginInit();
            this.gridView3.BeginInit();
            this.karsiagren.Properties.BeginInit();
            this.karsiagrsecim.Properties.BeginInit();
            this.karsiagrmodel.Properties.BeginInit();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem13.BeginInit();
            this.label3regmarka.BeginInit();
            this.layoutControlItem24.BeginInit();
            this.label3baritdokum.BeginInit();
            this.label3modelsec.BeginInit();
            this.label3enbilgisi.BeginInit();
            this.layoutControlItem30.BeginInit();
            this.label3boybilgisi.BeginInit();
            this.layoutControlItem32.BeginInit();
            this.label3yukseklikbilgisi.BeginInit();
            this.layoutControlItem35.BeginInit();
            this.layoutControlItem36.BeginInit();
            this.layoutControlItem37.BeginInit();
            this.lbldengekatsayi.BeginInit();
            this.label3karkasagr.BeginInit();
            this.label3yanagr.BeginInit();
            this.label3arkaagr.BeginInit();
            this.layoutControlItem42.BeginInit();
            this.label3ozgulkutle.BeginInit();
            this.label3birimagr.BeginInit();
            this.layoutControlItem25.BeginInit();
            this.backstageViewClientControl5.SuspendLayout();
            this.dosyahidasnicin.BeginInit();
            this.dosyahidasnicin.SuspendLayout();
            this.layoutControl23.BeginInit();
            this.layoutControl23.SuspendLayout();
            this.dosyahortumserino.Properties.BeginInit();
            this.dosyahortumonaylayan.Properties.BeginInit();
            this.dosyahortumbelgeno.Properties.BeginInit();
            this.dosyahortummodel.Properties.BeginInit();
            this.dosyahortumuretici.Properties.BeginInit();
            this.dosyadebiserino.Properties.BeginInit();
            this.dosyadebionaylayan.Properties.BeginInit();
            this.dosyadebibelgeno.Properties.BeginInit();
            this.dosyadebimodel.Properties.BeginInit();
            this.dosyadebiuret.Properties.BeginInit();
            this.layoutControlGroup23.BeginInit();
            this.layoutControlItem345.BeginInit();
            this.layoutControlItem346.BeginInit();
            this.layoutControlItem347.BeginInit();
            this.layoutControlItem348.BeginInit();
            this.layoutControlItem349.BeginInit();
            this.layoutControlItem350.BeginInit();
            this.layoutControlItem351.BeginInit();
            this.layoutControlItem352.BeginInit();
            this.layoutControlItem353.BeginInit();
            this.layoutControlItem354.BeginInit();
            this.layoutControlItem355.BeginInit();
            this.layoutControlItem356.BeginInit();
            this.layoutControlItem357.BeginInit();
            this.layoutControlItem358.BeginInit();
            this.layoutControlItem359.BeginInit();
            this.layoutControlItem360.BeginInit();
            this.layoutControlItem361.BeginInit();
            this.layoutControlItem362.BeginInit();
            this.dosyalblelektrasnicin.BeginInit();
            this.dosyalblelektrasnicin.SuspendLayout();
            this.layoutControl24.BeginInit();
            this.layoutControl24.SuspendLayout();
            this.dosyamotorserino.Properties.BeginInit();
            this.dosyamotoronaylayan.Properties.BeginInit();
            this.dosyamotorbelgeno.Properties.BeginInit();
            this.dosyamotormodel.Properties.BeginInit();
            this.dosyamotoruretici.Properties.BeginInit();
            this.dosyamakineurserno.Properties.BeginInit();
            this.dosyamakineonaylayan.Properties.BeginInit();
            this.dosyamakinebelgeno.Properties.BeginInit();
            this.dosyamakinemodel.Properties.BeginInit();
            this.dosyamakineuret.Properties.BeginInit();
            this.layoutControlGroup24.BeginInit();
            this.layoutControlItem363.BeginInit();
            this.layoutControlItem364.BeginInit();
            this.layoutControlItem365.BeginInit();
            this.layoutControlItem366.BeginInit();
            this.layoutControlItem367.BeginInit();
            this.layoutControlItem368.BeginInit();
            this.layoutControlItem369.BeginInit();
            this.layoutControlItem370.BeginInit();
            this.layoutControlItem371.BeginInit();
            this.layoutControlItem372.BeginInit();
            this.layoutControlItem373.BeginInit();
            this.layoutControlItem374.BeginInit();
            this.layoutControlItem375.BeginInit();
            this.layoutControlItem376.BeginInit();
            this.layoutControlItem377.BeginInit();
            this.layoutControlItem378.BeginInit();
            this.layoutControlItem379.BeginInit();
            this.layoutControlItem380.BeginInit();
            this.layoutControl6.BeginInit();
            this.layoutControl6.SuspendLayout();
            this.dosyakapikilit.Properties.BeginInit();
            this.gridView1.BeginInit();
            this.dosyapanosn.Properties.BeginInit();
            this.dosyapano.Properties.BeginInit();
            this.searchLookUpEdit6View.BeginInit();
            this.dosyapistonvalfisn.Properties.BeginInit();
            this.dosyaa3ekipmansn.Properties.BeginInit();
            this.dosyaregulatorsn.Properties.BeginInit();
            this.dosyakumandakartisn.Properties.BeginInit();
            this.dosyakabintamponsn.Properties.BeginInit();
            this.dosyaagrtamponsn.Properties.BeginInit();
            this.dosyafrenbloksn.Properties.BeginInit();
            this.dosyakapikilitsn.Properties.BeginInit();
            this.dosyapistonvalfi.Properties.BeginInit();
            this.searchLookUpEdit9View.BeginInit();
            this.dosyaa3ekipman.Properties.BeginInit();
            this.searchLookUpEdit8View.BeginInit();
            this.dosyaregulator.Properties.BeginInit();
            this.searchLookUpEdit7View.BeginInit();
            this.dosyakumandakarti.Properties.BeginInit();
            this.searchLookUpEdit5View.BeginInit();
            this.dosyakabintampon.Properties.BeginInit();
            this.searchLookUpEdit4View.BeginInit();
            this.dosyaagrtampon.Properties.BeginInit();
            this.searchLookUpEdit3View.BeginInit();
            this.dosyafrenblok.Properties.BeginInit();
            this.searchLookUpEdit2View.BeginInit();
            this.layoutControlGroup10.BeginInit();
            this.layoutControlItem103.BeginInit();
            this.layoutControlItem104.BeginInit();
            this.layoutControlItem105.BeginInit();
            this.layoutControlItem106.BeginInit();
            this.layoutControlItem107.BeginInit();
            this.layoutControlItem108.BeginInit();
            this.layoutControlItem109.BeginInit();
            this.layoutControlItem110.BeginInit();
            this.dosyafrenbloklbl.BeginInit();
            this.dosyaagrtamponlbl.BeginInit();
            this.dosyakabintamponlbl.BeginInit();
            this.dosyakumandakartilbl.BeginInit();
            this.dosyaregulatorlbl.BeginInit();
            this.dosyaa3ekipmanlbl.BeginInit();
            this.dosyapistonvalfilbl.BeginInit();
            this.layoutControlItem127.BeginInit();
            this.layoutControlItem128.BeginInit();
            this.layoutControlItem129.BeginInit();
            this.layoutControlItem130.BeginInit();
            this.layoutControlItem131.BeginInit();
            this.layoutControlItem132.BeginInit();
            this.layoutControlItem133.BeginInit();
            this.layoutControlItem134.BeginInit();
            this.dosyapanolbl.BeginInit();
            this.layoutControlItem138.BeginInit();
            this.layoutControlItem139.BeginInit();
            this.layoutControlItem140.BeginInit();
            this.layoutControlItem141.BeginInit();
            this.layoutControlItem142.BeginInit();
            this.dosyakapikilitlbl.BeginInit();
            this.layoutControl5.BeginInit();
            this.layoutControl5.SuspendLayout();
            this.dosyamutaahhitvd.Properties.BeginInit();
            this.dosyamutaahhitvn.Properties.BeginInit();
            this.dosyamutaahhittc.Properties.BeginInit();
            this.dosyamutaahhit.Properties.BeginInit();
            this.dosyabinasahipvd.Properties.BeginInit();
            this.dosyabinasahipvn.Properties.BeginInit();
            this.dosyabinasahiptc.Properties.BeginInit();
            this.dosyabinasahip.Properties.BeginInit();
            this.dosyaservistar.Properties.BeginInit();
            this.dosyaasansorno.Properties.BeginInit();
            this.dosyasinif.Properties.BeginInit();
            this.dosyaparsel.Properties.BeginInit();
            this.dosyaada.Properties.BeginInit();
            this.dosyapafta.Properties.BeginInit();
            this.dosyabelediye.Properties.BeginInit();
            this.dosyailce.Properties.BeginInit();
            this.dosyail.Properties.BeginInit();
            this.dosyablok.Properties.BeginInit();
            this.dosyano.Properties.BeginInit();
            this.dosyabulvar.Properties.BeginInit();
            this.dosyacadde.Properties.BeginInit();
            this.dosyasokak.Properties.BeginInit();
            this.dosyamahalle.Properties.BeginInit();
            this.dosyaasansorsahib.Properties.BeginInit();
            this.dosyabelgemodul.Properties.BeginInit();
            this.layoutControlGroup9.BeginInit();
            this.dosyalblmodul.BeginInit();
            this.dosyalblno.BeginInit();
            this.dosyalblil.BeginInit();
            this.dosyalblilce.BeginInit();
            this.dosyalblbelediye.BeginInit();
            this.dosyalblpafta.BeginInit();
            this.dosyalblada.BeginInit();
            this.dosyalblparsel.BeginInit();
            this.dosyalblsinif.BeginInit();
            this.dosyalblasnno.BeginInit();
            this.dosyalblservistar.BeginInit();
            this.dosyalblbinasahip.BeginInit();
            this.dosyalblbinasahiptc.BeginInit();
            this.dosyalblbinasahipvn.BeginInit();
            this.dosyalblbinasahipvd.BeginInit();
            this.dosyalblmuteaahhit.BeginInit();
            this.dosyalblmuteaahhittc.BeginInit();
            this.dosyalblmuteaahhitvn.BeginInit();
            this.dosyalblmuteaahhitvd.BeginInit();
            this.dosyalblasansorsahip.BeginInit();
            this.dosyalblblok.BeginInit();
            this.dosyalblbulvar.BeginInit();
            this.dosyalblmahalle.BeginInit();
            this.dosyalblcadde.BeginInit();
            this.dosyalblsokak.BeginInit();
            this.dosyalbladres.BeginInit();
            this.backstageViewClientControl4.SuspendLayout();
            this.layoutControl2.BeginInit();
            this.layoutControl2.SuspendLayout();
            this.gridcontroldiller.BeginInit();
            this.gridviewdiller.BeginInit();
            this.layoutControlGroup7.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem2.BeginInit();
            this.layoutControlItem43.BeginInit();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            this.dilsecimi.Properties.BeginInit();
            this.gorunumayar.Properties.BeginInit();
            this.layoutControlGroup6.BeginInit();
            this.labelgorunumayar.BeginInit();
            this.labeldilsecimi.BeginInit();
            this.layoutControlItem8.BeginInit();
            this.layoutControlItem10.BeginInit();
            base.SuspendLayout();
            this.backstageViewControl1.ColorScheme = RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl2);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl6);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl3);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl5);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl4);
            this.backstageViewControl1.Dock = DockStyle.Fill;
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem1);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem2);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem6);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem3);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem5);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem4);
            this.backstageViewControl1.Items.Add(this.backstageViewButtonItem1);
            this.backstageViewControl1.Location = new Point(0, 0);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.SelectedTab = this.backstageViewTabItem2;
            this.backstageViewControl1.SelectedTabIndex = 1;
            this.backstageViewControl1.Size = new Size(0x51e, 0x331);
            this.backstageViewControl1.TabIndex = 0;
            this.backstageViewControl1.Text = "backstageViewControl1";
            this.backstageViewClientControl1.Location = new Point(0xa5, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new Size(0x479, 0x331);
            this.backstageViewClientControl1.TabIndex = 0;
            this.backstageViewClientControl1.Load += new EventHandler(this.backstageViewClientControl1_Load);
            this.backstageViewClientControl2.Controls.Add(this.groupBox2);
            this.backstageViewClientControl2.Controls.Add(this.layoutControl7);
            this.backstageViewClientControl2.Controls.Add(this.groupControl5);
            this.backstageViewClientControl2.Controls.Add(this.kapisagcheck);
            this.backstageViewClientControl2.Controls.Add(this.kapiarkacheck);
            this.backstageViewClientControl2.Controls.Add(this.kapisolcheck);
            this.backstageViewClientControl2.Controls.Add(this.labelkapitipsecimi);
            this.backstageViewClientControl2.Location = new Point(0xa5, 0);
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            this.backstageViewClientControl2.Size = new Size(0x479, 0x331);
            this.backstageViewClientControl2.TabIndex = 1;
            this.backstageViewClientControl2.Load += new EventHandler(this.backstageViewClientControl2_Load);
            this.groupBox2.Controls.Add(this.kapitipi);
            this.groupBox2.Location = new Point(0x12f, 0x236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x1ab, 110);
            this.groupBox2.TabIndex = 0x38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KABİN KAPSII";
            this.kapitipi.Location = new Point(6, 20);
            this.kapitipi.Name = "kapitipi";
            this.kapitipi.Properties.Appearance.BackColor = SystemColors.Control;
            this.kapitipi.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.kapitipi.Properties.Appearance.Options.UseBackColor = true;
            this.kapitipi.Properties.Appearance.Options.UseFont = true;
            RadioGroupItem[] items = new RadioGroupItem[] { new RadioGroupItem(1, "Tam Otomatik"), new RadioGroupItem(2, "Yarım Otomatik"), new RadioGroupItem(3, "Kramer Kapılı"), new RadioGroupItem(4, "Dikey Kapılı"), new RadioGroupItem(5, "İ\x00e7 Kapısız") };
            this.kapitipi.Properties.Items.AddRange(items);
            this.kapitipi.Size = new Size(0x18d, 0x52);
            this.kapitipi.TabIndex = 1;
            this.kapitipi.SelectedIndexChanged += new EventHandler(this.kapitipi_SelectedIndexChanged);
            this.layoutControl7.Controls.Add(this.kapiarkaimage);
            this.layoutControl7.Controls.Add(this.kapionimage);
            this.layoutControl7.Controls.Add(this.kapisagimage);
            this.layoutControl7.Controls.Add(this.kapisolimage);
            this.layoutControl7.Controls.Add(this.kapikabinimage);
            this.layoutControl7.Location = new Point(0x2a, 0x8f);
            this.layoutControl7.Name = "layoutControl7";
            this.layoutControl7.Root = this.layoutControlGroup2;
            this.layoutControl7.Size = new Size(200, 200);
            this.layoutControl7.TabIndex = 0x31;
            this.layoutControl7.Text = "layoutControl7";
            this.kapiarkaimage.Location = new Point(30, 0);
            this.kapiarkaimage.Name = "kapiarkaimage";
            this.kapiarkaimage.Size = new Size(140, 30);
            this.kapiarkaimage.TabIndex = 0x33;
            this.kapiarkaimage.TabStop = false;
            this.kapionimage.Image = (Image) manager.GetObject("kapionimage.Image");
            this.kapionimage.Location = new Point(30, 170);
            this.kapionimage.Name = "kapionimage";
            this.kapionimage.Size = new Size(140, 30);
            this.kapionimage.TabIndex = 50;
            this.kapionimage.TabStop = false;
            this.kapisagimage.Location = new Point(170, 0);
            this.kapisagimage.Name = "kapisagimage";
            this.kapisagimage.Size = new Size(30, 200);
            this.kapisagimage.TabIndex = 0x31;
            this.kapisagimage.TabStop = false;
            this.kapisolimage.Location = new Point(0, 0);
            this.kapisolimage.Name = "kapisolimage";
            this.kapisolimage.Size = new Size(30, 200);
            this.kapisolimage.TabIndex = 0x30;
            this.kapisolimage.TabStop = false;
            this.kapikabinimage.Image = (Image) manager.GetObject("kapikabinimage.Image");
            this.kapikabinimage.Location = new Point(30, 30);
            this.kapikabinimage.Name = "kapikabinimage";
            this.kapikabinimage.Size = new Size(140, 140);
            this.kapikabinimage.TabIndex = 0x27;
            this.kapikabinimage.TabStop = false;
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray2 = new BaseLayoutItem[] { this.layoutControlItem26, this.layoutControlItem29, this.layoutControlItem31, this.layoutControlItem33, this.layoutControlItem34 };
            this.layoutControlGroup2.Items.AddRange(itemArray2);
            this.layoutControlGroup2.Location = new Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new Size(200, 200);
            this.layoutControlGroup2.TextVisible = false;
            this.layoutControlItem26.Control = this.kapisolimage;
            this.layoutControlItem26.CustomizationFormText = "layoutControlItem26";
            this.layoutControlItem26.Location = new Point(0, 0);
            this.layoutControlItem26.MaxSize = new Size(30, 200);
            this.layoutControlItem26.MinSize = new Size(30, 200);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem26.Size = new Size(30, 200);
            this.layoutControlItem26.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem26.TextSize = new Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            this.layoutControlItem29.Control = this.kapikabinimage;
            this.layoutControlItem29.CustomizationFormText = "layoutControlItem29";
            this.layoutControlItem29.Location = new Point(30, 30);
            this.layoutControlItem29.MaxSize = new Size(140, 140);
            this.layoutControlItem29.MinSize = new Size(140, 140);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem29.Size = new Size(140, 140);
            this.layoutControlItem29.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem29.TextSize = new Size(0, 0);
            this.layoutControlItem29.TextVisible = false;
            this.layoutControlItem31.Control = this.kapisagimage;
            this.layoutControlItem31.CustomizationFormText = "layoutControlItem31";
            this.layoutControlItem31.Location = new Point(170, 0);
            this.layoutControlItem31.MaxSize = new Size(30, 200);
            this.layoutControlItem31.MinSize = new Size(30, 200);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem31.Size = new Size(30, 200);
            this.layoutControlItem31.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem31.TextSize = new Size(0, 0);
            this.layoutControlItem31.TextVisible = false;
            this.layoutControlItem33.Control = this.kapionimage;
            this.layoutControlItem33.CustomizationFormText = "layoutControlItem33";
            this.layoutControlItem33.Location = new Point(30, 170);
            this.layoutControlItem33.MaxSize = new Size(140, 30);
            this.layoutControlItem33.MinSize = new Size(140, 30);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem33.Size = new Size(140, 30);
            this.layoutControlItem33.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem33.TextSize = new Size(0, 0);
            this.layoutControlItem33.TextVisible = false;
            this.layoutControlItem34.Control = this.kapiarkaimage;
            this.layoutControlItem34.CustomizationFormText = "layoutControlItem34";
            this.layoutControlItem34.Location = new Point(30, 0);
            this.layoutControlItem34.MaxSize = new Size(140, 30);
            this.layoutControlItem34.MinSize = new Size(140, 30);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem34.Size = new Size(140, 30);
            this.layoutControlItem34.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem34.TextSize = new Size(0, 0);
            this.layoutControlItem34.TextVisible = false;
            this.groupControl5.Controls.Add(this.kuyuyatext);
            this.groupControl5.Controls.Add(this.katatext);
            this.groupControl5.Controls.Add(this.kuyuyaradio);
            this.groupControl5.Controls.Add(this.kataradio);
            this.groupControl5.Controls.Add(this.kathizasiradio);
            this.groupControl5.Location = new Point(0x1c, 0x191);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.ShowCaption = false;
            this.groupControl5.Size = new Size(0xc9, 0x53);
            this.groupControl5.TabIndex = 0x25;
            this.groupControl5.Text = "groupControl5";
            this.kuyuyatext.Enabled = false;
            this.kuyuyatext.Location = new Point(5, 5);
            this.kuyuyatext.Name = "kuyuyatext";
            this.kuyuyatext.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.kuyuyatext.Properties.Appearance.Options.UseFont = true;
            this.kuyuyatext.Properties.Appearance.Options.UseTextOptions = true;
            this.kuyuyatext.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.kuyuyatext.Properties.BorderStyle = BorderStyles.NoBorder;
            this.kuyuyatext.Size = new Size(0x55, 20);
            this.kuyuyatext.TabIndex = 15;
            this.kuyuyatext.TextChanged += new EventHandler(this.kuyuyatext_TextChanged);
            this.kuyuyatext.KeyDown += new KeyEventHandler(this.int_KeyDown);
            this.kuyuyatext.KeyPress += new KeyPressEventHandler(this.int_KeyPress);
            this.katatext.Enabled = false;
            this.katatext.Location = new Point(5, 0x34);
            this.katatext.Name = "katatext";
            this.katatext.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.katatext.Properties.Appearance.Options.UseFont = true;
            this.katatext.Properties.Appearance.Options.UseTextOptions = true;
            this.katatext.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.katatext.Properties.BorderStyle = BorderStyles.NoBorder;
            this.katatext.Size = new Size(0x55, 20);
            this.katatext.TabIndex = 0x11;
            this.katatext.TextChanged += new EventHandler(this.kuyuyatext_TextChanged);
            this.katatext.KeyDown += new KeyEventHandler(this.int_KeyDown);
            this.katatext.KeyPress += new KeyPressEventHandler(this.int_KeyPress);
            this.kuyuyaradio.CheckAlign = ContentAlignment.MiddleRight;
            this.kuyuyaradio.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kuyuyaradio.Location = new Point(0x60, 4);
            this.kuyuyaradio.Name = "kuyuyaradio";
            this.kuyuyaradio.Size = new Size(0x57, 0x19);
            this.kuyuyaradio.TabIndex = 0x12;
            this.kuyuyaradio.TabStop = true;
            this.kuyuyaradio.Text = "Kuyuya";
            this.kuyuyaradio.UseVisualStyleBackColor = true;
            this.kuyuyaradio.CheckedChanged += new EventHandler(this.kapiyeri);
            this.kataradio.CheckAlign = ContentAlignment.MiddleRight;
            this.kataradio.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kataradio.Location = new Point(0x60, 0x33);
            this.kataradio.Name = "kataradio";
            this.kataradio.RightToLeft = RightToLeft.No;
            this.kataradio.Size = new Size(0x57, 0x19);
            this.kataradio.TabIndex = 20;
            this.kataradio.TabStop = true;
            this.kataradio.Text = "Kata";
            this.kataradio.UseVisualStyleBackColor = true;
            this.kataradio.CheckedChanged += new EventHandler(this.kapiyeri);
            this.kathizasiradio.CheckAlign = ContentAlignment.MiddleRight;
            this.kathizasiradio.Checked = true;
            this.kathizasiradio.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kathizasiradio.Location = new Point(0x60, 0x1b);
            this.kathizasiradio.Name = "kathizasiradio";
            this.kathizasiradio.Size = new Size(0x57, 0x19);
            this.kathizasiradio.TabIndex = 0x13;
            this.kathizasiradio.TabStop = true;
            this.kathizasiradio.Text = "Kat Hizası";
            this.kathizasiradio.UseVisualStyleBackColor = true;
            this.kathizasiradio.CheckedChanged += new EventHandler(this.kapiyeri);
            this.kapisagcheck.Location = new Point(0xf8, 0xf1);
            this.kapisagcheck.Name = "kapisagcheck";
            this.kapisagcheck.Properties.Caption = "";
            this.kapisagcheck.Size = new Size(20, 0x13);
            this.kapisagcheck.TabIndex = 0x2a;
            this.kapisagcheck.CheckedChanged += new EventHandler(this.checkEdit2_CheckedChanged);
            this.kapiarkacheck.Location = new Point(0x88, 0x76);
            this.kapiarkacheck.Name = "kapiarkacheck";
            this.kapiarkacheck.Properties.Caption = "";
            this.kapiarkacheck.Size = new Size(20, 0x13);
            this.kapiarkacheck.TabIndex = 0x29;
            this.kapiarkacheck.CheckedChanged += new EventHandler(this.checkEdit2_CheckedChanged);
            this.kapisolcheck.Location = new Point(0x10, 0xf1);
            this.kapisolcheck.Name = "kapisolcheck";
            this.kapisolcheck.Properties.Caption = "";
            this.kapisolcheck.Size = new Size(20, 0x13);
            this.kapisolcheck.TabIndex = 40;
            this.kapisolcheck.CheckedChanged += new EventHandler(this.checkEdit2_CheckedChanged);
            this.labelkapitipsecimi.AppearanceCaption.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.labelkapitipsecimi.AppearanceCaption.Options.UseFont = true;
            this.labelkapitipsecimi.Controls.Add(this.layoutControl8);
            this.labelkapitipsecimi.Controls.Add(this.otokaptippicture);
            this.labelkapitipsecimi.Controls.Add(this.kapitippicture);
            this.labelkapitipsecimi.Controls.Add(this.otokaptip);
            this.labelkapitipsecimi.Location = new Point(0x127, 0x13);
            this.labelkapitipsecimi.Name = "labelkapitipsecimi";
            this.labelkapitipsecimi.ShowCaption = false;
            this.labelkapitipsecimi.Size = new Size(0x2b9, 0x1d1);
            this.labelkapitipsecimi.TabIndex = 0x22;
            this.labelkapitipsecimi.Text = "KAPI TİPİ SE\x00c7İMİ";
            this.layoutControl8.Controls.Add(this.acilmayon);
            this.layoutControl8.Controls.Add(this.kapigen);
            this.layoutControl8.Controls.Add(this.kapimmarmodel);
            this.layoutControl8.Controls.Add(this.yangindayanim);
            this.layoutControl8.Controls.Add(this.kapikaplama);
            this.layoutControl8.Location = new Point(5, 0xb0);
            this.layoutControl8.Name = "layoutControl8";
            this.layoutControl8.Root = this.layoutControlGroup3;
            this.layoutControl8.Size = new Size(0x19e, 0xc0);
            this.layoutControl8.TabIndex = 0x38;
            this.layoutControl8.Text = "layoutControl8";
            this.acilmayon.Location = new Point(0x81, 0x6f);
            this.acilmayon.Name = "acilmayon";
            this.acilmayon.Properties.Appearance.BackColor = SystemColors.Control;
            this.acilmayon.Properties.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.acilmayon.Properties.Appearance.Options.UseBackColor = true;
            this.acilmayon.Properties.Appearance.Options.UseFont = true;
            RadioGroupItem[] itemArray3 = new RadioGroupItem[] { new RadioGroupItem(1, "Sağ"), new RadioGroupItem(2, "Sol"), new RadioGroupItem(3, "Merkezi") };
            this.acilmayon.Properties.Items.AddRange(itemArray3);
            this.acilmayon.Size = new Size(0x116, 0x4a);
            this.acilmayon.StyleController = this.layoutControl8;
            this.acilmayon.TabIndex = 8;
            this.acilmayon.SelectedIndexChanged += new EventHandler(this.acilmayon_SelectedIndexChanged);
            this.kapigen.Location = new Point(0x81, 0x21);
            this.kapigen.Name = "kapigen";
            this.kapigen.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.kapigen.Properties.Appearance.Options.UseFont = true;
            this.kapigen.Properties.Appearance.Options.UseTextOptions = true;
            this.kapigen.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.kapigen.Size = new Size(0x116, 0x16);
            this.kapigen.StyleController = this.layoutControl8;
            this.kapigen.TabIndex = 5;
            this.kapigen.EditValueChanged += new EventHandler(this.kapigen_EditValueChanged);
            this.kapimmarmodel.Location = new Point(0x81, 7);
            this.kapimmarmodel.Name = "kapimmarmodel";
            this.kapimmarmodel.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.kapimmarmodel.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttons = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.kapimmarmodel.Properties.Buttons.AddRange(buttons);
            LookUpColumnInfo[] columns = new LookUpColumnInfo[] { new LookUpColumnInfo("marka", "Marka"), new LookUpColumnInfo("sno", "No", 20, FormatType.None, "", false, HorzAlignment.Default) };
            this.kapimmarmodel.Properties.Columns.AddRange(columns);
            this.kapimmarmodel.Properties.NullText = "";
            this.kapimmarmodel.Properties.PopupSizeable = false;
            this.kapimmarmodel.Properties.TextEditStyle = TextEditStyles.Standard;
            this.kapimmarmodel.Size = new Size(0x116, 0x16);
            this.kapimmarmodel.StyleController = this.layoutControl8;
            this.kapimmarmodel.TabIndex = 15;
            this.kapimmarmodel.EditValueChanged += new EventHandler(this.kapikaplamamarka_EditValueChanged);
            this.yangindayanim.Location = new Point(0x81, 0x3b);
            this.yangindayanim.Name = "yangindayanim";
            this.yangindayanim.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.yangindayanim.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray2 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.yangindayanim.Properties.Buttons.AddRange(buttonArray2);
            LookUpColumnInfo[] infoArray2 = new LookUpColumnInfo[] { new LookUpColumnInfo("yangin", "Yangın Dayanımı"), new LookUpColumnInfo("no", "No", 20, FormatType.None, "", false, HorzAlignment.Default) };
            this.yangindayanim.Properties.Columns.AddRange(infoArray2);
            this.yangindayanim.Properties.NullText = "";
            this.yangindayanim.Properties.PopupSizeable = false;
            this.yangindayanim.Properties.TextEditStyle = TextEditStyles.Standard;
            this.yangindayanim.Size = new Size(0x116, 0x16);
            this.yangindayanim.StyleController = this.layoutControl8;
            this.yangindayanim.TabIndex = 0;
            this.yangindayanim.EditValueChanged += new EventHandler(this.yangindayanim_EditValueChanged);
            this.kapikaplama.Location = new Point(0x81, 0x55);
            this.kapikaplama.Name = "kapikaplama";
            this.kapikaplama.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.kapikaplama.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray3 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.kapikaplama.Properties.Buttons.AddRange(buttonArray3);
            LookUpColumnInfo[] infoArray3 = new LookUpColumnInfo[] { new LookUpColumnInfo("kaplama", "Kapı Kaplaması"), new LookUpColumnInfo("no", "No", 20, FormatType.None, "", false, HorzAlignment.Default) };
            this.kapikaplama.Properties.Columns.AddRange(infoArray3);
            this.kapikaplama.Properties.NullText = "";
            this.kapikaplama.Properties.PopupSizeable = false;
            this.kapikaplama.Properties.TextEditStyle = TextEditStyles.Standard;
            this.kapikaplama.Size = new Size(0x116, 0x16);
            this.kapikaplama.StyleController = this.layoutControl8;
            this.kapikaplama.TabIndex = 13;
            this.kapikaplama.EditValueChanged += new EventHandler(this.kapikaplama_EditValueChanged);
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray4 = new BaseLayoutItem[] { this.labelkapigenisligi, this.labelkapikaplamasi, this.labelkapikaplamamarka, this.labelyangindayanim, this.layoutControlItem12 };
            this.layoutControlGroup3.Items.AddRange(itemArray4);
            this.layoutControlGroup3.Location = new Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup3.Size = new Size(0x19e, 0xc0);
            this.layoutControlGroup3.TextVisible = false;
            this.labelkapigenisligi.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelkapigenisligi.AppearanceItemCaption.Options.UseFont = true;
            this.labelkapigenisligi.Control = this.kapigen;
            this.labelkapigenisligi.CustomizationFormText = "Kapı Genişliği : ";
            this.labelkapigenisligi.Location = new Point(0, 0x1a);
            this.labelkapigenisligi.Name = "labelkapigenisligi";
            this.labelkapigenisligi.Size = new Size(0x194, 0x1a);
            this.labelkapigenisligi.Text = "Kapı Genişliği : ";
            this.labelkapigenisligi.TextSize = new Size(0x77, 0x10);
            this.labelkapikaplamasi.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.labelkapikaplamasi.AppearanceItemCaption.Options.UseFont = true;
            this.labelkapikaplamasi.Control = this.kapikaplama;
            this.labelkapikaplamasi.CustomizationFormText = "Kapı Kaplaması : ";
            this.labelkapikaplamasi.Location = new Point(0, 0x4e);
            this.labelkapikaplamasi.Name = "labelkapikaplamasi";
            this.labelkapikaplamasi.Size = new Size(0x194, 0x1a);
            this.labelkapikaplamasi.Text = "Kapı Kaplaması : ";
            this.labelkapikaplamasi.TextSize = new Size(0x77, 0x10);
            this.labelkapikaplamamarka.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.labelkapikaplamamarka.AppearanceItemCaption.Options.UseFont = true;
            this.labelkapikaplamamarka.Control = this.kapimmarmodel;
            this.labelkapikaplamamarka.CustomizationFormText = "Marka : ";
            this.labelkapikaplamamarka.Location = new Point(0, 0);
            this.labelkapikaplamamarka.Name = "labelkapikaplamamarka";
            this.labelkapikaplamamarka.Size = new Size(0x194, 0x1a);
            this.labelkapikaplamamarka.Text = "Marka : ";
            this.labelkapikaplamamarka.TextSize = new Size(0x77, 0x10);
            this.labelyangindayanim.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.labelyangindayanim.AppearanceItemCaption.Options.UseFont = true;
            this.labelyangindayanim.Control = this.yangindayanim;
            this.labelyangindayanim.CustomizationFormText = "Yangın Dayanımı : ";
            this.labelyangindayanim.Location = new Point(0, 0x34);
            this.labelyangindayanim.Name = "labelyangindayanim";
            this.labelyangindayanim.Size = new Size(0x194, 0x1a);
            this.labelyangindayanim.Text = "Yangın Dayanımı : ";
            this.labelyangindayanim.TextSize = new Size(0x77, 0x10);
            this.layoutControlItem12.Control = this.acilmayon;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new Point(0, 0x68);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new Size(0x194, 0x4e);
            this.layoutControlItem12.TextSize = new Size(0x77, 13);
            this.otokaptippicture.BackgroundImageLayout = ImageLayout.None;
            this.otokaptippicture.EditValue = manager.GetObject("otokaptippicture.EditValue");
            this.otokaptippicture.ImeMode = ImeMode.NoControl;
            this.otokaptippicture.Location = new Point(0x1e3, 0x10b);
            this.otokaptippicture.Name = "otokaptippicture";
            this.otokaptippicture.Properties.Appearance.BackColor = SystemColors.Control;
            this.otokaptippicture.Properties.Appearance.Options.UseBackColor = true;
            this.otokaptippicture.Properties.SizeMode = PictureSizeMode.Squeeze;
            this.otokaptippicture.Properties.ZoomAccelerationFactor = 1.0;
            this.otokaptippicture.Size = new Size(0x86, 0x70);
            this.otokaptippicture.TabIndex = 0x27;
            this.kapitippicture.EditValue = manager.GetObject("kapitippicture.EditValue");
            this.kapitippicture.Location = new Point(420, 0x93);
            this.kapitippicture.Name = "kapitippicture";
            this.kapitippicture.Properties.Appearance.BackColor = SystemColors.Control;
            this.kapitippicture.Properties.Appearance.Options.UseBackColor = true;
            this.kapitippicture.Properties.SizeMode = PictureSizeMode.Squeeze;
            this.kapitippicture.Properties.ZoomAccelerationFactor = 1.0;
            this.kapitippicture.Size = new Size(260, 0x11f);
            this.kapitippicture.TabIndex = 7;
            this.otokaptip.Location = new Point(0xac, 5);
            this.otokaptip.Name = "otokaptip";
            this.otokaptip.Properties.Appearance.BackColor = SystemColors.Control;
            this.otokaptip.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.otokaptip.Properties.Appearance.Options.UseBackColor = true;
            this.otokaptip.Properties.Appearance.Options.UseFont = true;
            RadioGroupItem[] itemArray5 = new RadioGroupItem[] { new RadioGroupItem(1, "2 Panel Merkezi"), new RadioGroupItem(2, "2 Panel Teleskopik"), new RadioGroupItem(3, "3 Panel Teleskopik"), new RadioGroupItem(4, "4 Panel Merkezi"), new RadioGroupItem(5, "6 Panel Merkezi") };
            this.otokaptip.Properties.Items.AddRange(itemArray5);
            this.otokaptip.Size = new Size(0x9c, 0xa5);
            this.otokaptip.TabIndex = 6;
            this.otokaptip.SelectedIndexChanged += new EventHandler(this.otokaptip_SelectedIndexChanged);
            this.backstageViewClientControl6.Location = new Point(0xa5, 0);
            this.backstageViewClientControl6.Name = "backstageViewClientControl6";
            this.backstageViewClientControl6.Size = new Size(0x479, 0x331);
            this.backstageViewClientControl6.TabIndex = 5;
            this.backstageViewClientControl3.Controls.Add(this.layoutControl3);
            this.backstageViewClientControl3.Location = new Point(0xa5, 0);
            this.backstageViewClientControl3.Name = "backstageViewClientControl3";
            this.backstageViewClientControl3.Size = new Size(0x479, 0x331);
            this.backstageViewClientControl3.TabIndex = 2;
            this.layoutControl3.Controls.Add(this.panel1);
            this.layoutControl3.Controls.Add(this.label3karsiagirlik);
            this.layoutControl3.Controls.Add(this.dengekatsayisi);
            this.layoutControl3.Controls.Add(this.karkasgrup);
            this.layoutControl3.Controls.Add(this.karsiagrozgulkutle);
            this.layoutControl3.Controls.Add(this.label3regulatorbilgi);
            this.layoutControl3.Controls.Add(this.label3birimkg);
            this.layoutControl3.Controls.Add(this.label3kutlekg);
            this.layoutControl3.Controls.Add(this.label3yuksekmm);
            this.layoutControl3.Controls.Add(this.karsiagrbirimagirlik);
            this.layoutControl3.Controls.Add(this.karkasagirlik);
            this.layoutControl3.Controls.Add(this.arkaagirsayisi);
            this.layoutControl3.Controls.Add(this.yanagirsayisi);
            this.layoutControl3.Controls.Add(this.karsiagryukseklik);
            this.layoutControl3.Controls.Add(this.label3boymm);
            this.layoutControl3.Controls.Add(this.karsiagrboy);
            this.layoutControl3.Controls.Add(this.label3enmm);
            this.layoutControl3.Controls.Add(this.regulatormarka);
            this.layoutControl3.Controls.Add(this.karsiagren);
            this.layoutControl3.Controls.Add(this.karsiagrsecim);
            this.layoutControl3.Controls.Add(this.karsiagrmodel);
            this.layoutControl3.Location = new Point(20, 12);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup1;
            this.layoutControl3.Size = new Size(0x3ab, 0x1d5);
            this.layoutControl3.TabIndex = 0x15;
            this.layoutControl3.Text = "layoutControl3";
            this.panel1.BackColor = Color.Transparent;
            this.panel1.Location = new Point(0x289, 2);
            this.panel1.MaximumSize = new Size(0x120, 0x1cf);
            this.panel1.MinimumSize = new Size(0x120, 0x1cf);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x120, 0x1cf);
            this.panel1.TabIndex = 20;
            this.label3karsiagirlik.Appearance.Font = new Font("Tahoma", 11.25f, FontStyle.Bold);
            this.label3karsiagirlik.Appearance.ForeColor = Color.Red;
            this.label3karsiagirlik.AutoSizeMode = LabelAutoSizeMode.None;
            this.label3karsiagirlik.Location = new Point(2, 2);
            this.label3karsiagirlik.Name = "label3karsiagirlik";
            this.label3karsiagirlik.Size = new Size(0x283, 0x12);
            this.label3karsiagirlik.StyleController = this.layoutControl3;
            this.label3karsiagirlik.TabIndex = 0x3ec;
            this.label3karsiagirlik.Text = "KARŞI AĞIRLIK";
            this.dengekatsayisi.EditValue = "0,5";
            this.dengekatsayisi.EnterMoveNextControl = true;
            this.dengekatsayisi.Location = new Point(0xb5, 0xb8);
            this.dengekatsayisi.Name = "dengekatsayisi";
            this.dengekatsayisi.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dengekatsayisi.Properties.Appearance.Options.UseFont = true;
            this.dengekatsayisi.Size = new Size(0x1d0, 20);
            this.dengekatsayisi.StyleController = this.layoutControl3;
            this.dengekatsayisi.TabIndex = 0x2f;
            this.dengekatsayisi.KeyDown += new KeyEventHandler(this.decimal_KeyDown);
            this.dengekatsayisi.KeyPress += new KeyPressEventHandler(this.decimal_KeyPress);
            this.karkasgrup.Location = new Point(2, 280);
            this.karkasgrup.Name = "karkasgrup";
            RadioGroupItem[] itemArray6 = new RadioGroupItem[] { new RadioGroupItem(null, "Tek Karkas"), new RadioGroupItem(null, "\x00c7ift Karkas") };
            this.karkasgrup.Properties.Items.AddRange(itemArray6);
            this.karkasgrup.Size = new Size(0x283, 0xbb);
            this.karkasgrup.StyleController = this.layoutControl3;
            this.karkasgrup.TabIndex = 0x2e;
            this.karkasgrup.SelectedIndexChanged += new EventHandler(this.karkascizerselectedindex);
            this.karkasgrup.Validated += new EventHandler(this.karkascizervalidated);
            this.karsiagrozgulkutle.Enabled = false;
            this.karsiagrozgulkutle.EnterMoveNextControl = true;
            this.karsiagrozgulkutle.Location = new Point(0x200, 0x8a);
            this.karsiagrozgulkutle.Name = "karsiagrozgulkutle";
            this.karsiagrozgulkutle.Properties.Appearance.BackColor = Color.Transparent;
            this.karsiagrozgulkutle.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.karsiagrozgulkutle.Properties.Appearance.Options.UseBackColor = true;
            this.karsiagrozgulkutle.Properties.Appearance.Options.UseFont = true;
            this.karsiagrozgulkutle.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagrozgulkutle.Size = new Size(0x59, 0x12);
            this.karsiagrozgulkutle.StyleController = this.layoutControl3;
            this.karsiagrozgulkutle.TabIndex = 4;
            this.label3regulatorbilgi.Appearance.Font = new Font("Tahoma", 11.25f, FontStyle.Bold);
            this.label3regulatorbilgi.Appearance.ForeColor = Color.Red;
            this.label3regulatorbilgi.AutoSizeMode = LabelAutoSizeMode.None;
            this.label3regulatorbilgi.Location = new Point(2, 0x5e);
            this.label3regulatorbilgi.Name = "label3regulatorbilgi";
            this.label3regulatorbilgi.Size = new Size(0x147, 0x12);
            this.label3regulatorbilgi.StyleController = this.layoutControl3;
            this.label3regulatorbilgi.TabIndex = 0x3eb;
            this.label3regulatorbilgi.Text = "REG\x00dcLAT\x00d6R BİLGİLERİ";
            this.label3birimkg.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3birimkg.AutoSizeMode = LabelAutoSizeMode.None;
            this.label3birimkg.Location = new Point(0x25d, 0x90);
            this.label3birimkg.Name = "label3birimkg";
            this.label3birimkg.Size = new Size(40, 14);
            this.label3birimkg.StyleController = this.layoutControl3;
            this.label3birimkg.TabIndex = 8;
            this.label3birimkg.Text = "Kg";
            this.label3kutlekg.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3kutlekg.AutoSizeMode = LabelAutoSizeMode.None;
            this.label3kutlekg.Location = new Point(0x25d, 0x7e);
            this.label3kutlekg.Name = "label3kutlekg";
            this.label3kutlekg.Size = new Size(40, 14);
            this.label3kutlekg.StyleController = this.layoutControl3;
            this.label3kutlekg.TabIndex = 8;
            this.label3kutlekg.Text = "Kg";
            this.label3yuksekmm.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3yuksekmm.AutoSizeMode = LabelAutoSizeMode.None;
            this.label3yuksekmm.Location = new Point(0x25d, 0x6c);
            this.label3yuksekmm.Name = "label3yuksekmm";
            this.label3yuksekmm.Size = new Size(40, 14);
            this.label3yuksekmm.StyleController = this.layoutControl3;
            this.label3yuksekmm.TabIndex = 0x2d;
            this.label3yuksekmm.Text = "mm";
            this.karsiagrbirimagirlik.Enabled = false;
            this.karsiagrbirimagirlik.EnterMoveNextControl = true;
            this.karsiagrbirimagirlik.Location = new Point(0xb5, 0xa2);
            this.karsiagrbirimagirlik.Name = "karsiagrbirimagirlik";
            this.karsiagrbirimagirlik.Properties.Appearance.BackColor = Color.Transparent;
            this.karsiagrbirimagirlik.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.karsiagrbirimagirlik.Properties.Appearance.Options.UseBackColor = true;
            this.karsiagrbirimagirlik.Properties.Appearance.Options.UseFont = true;
            this.karsiagrbirimagirlik.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagrbirimagirlik.Size = new Size(0x1d0, 0x12);
            this.karsiagrbirimagirlik.StyleController = this.layoutControl3;
            this.karsiagrbirimagirlik.TabIndex = 5;
            this.karkasagirlik.EnterMoveNextControl = true;
            this.karkasagirlik.Location = new Point(0xb5, 0xd0);
            this.karkasagirlik.Name = "karkasagirlik";
            this.karkasagirlik.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.karkasagirlik.Properties.Appearance.Options.UseFont = true;
            this.karkasagirlik.Size = new Size(0x1d0, 20);
            this.karkasagirlik.StyleController = this.layoutControl3;
            this.karkasagirlik.TabIndex = 11;
            this.arkaagirsayisi.EnterMoveNextControl = true;
            this.arkaagirsayisi.Location = new Point(0xb5, 0x100);
            this.arkaagirsayisi.Name = "arkaagirsayisi";
            this.arkaagirsayisi.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.arkaagirsayisi.Properties.Appearance.Options.UseFont = true;
            this.arkaagirsayisi.Size = new Size(0x1d0, 20);
            this.arkaagirsayisi.StyleController = this.layoutControl3;
            this.arkaagirsayisi.TabIndex = 13;
            this.arkaagirsayisi.TextChanged += new EventHandler(this.karkascizertextchanged);
            this.arkaagirsayisi.KeyDown += new KeyEventHandler(this.int_KeyDown);
            this.arkaagirsayisi.KeyPress += new KeyPressEventHandler(this.int_KeyPress);
            this.arkaagirsayisi.Validated += new EventHandler(this.karkascizervalidated);
            this.yanagirsayisi.EnterMoveNextControl = true;
            this.yanagirsayisi.Location = new Point(0xb5, 0xe8);
            this.yanagirsayisi.Name = "yanagirsayisi";
            this.yanagirsayisi.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.yanagirsayisi.Properties.Appearance.Options.UseFont = true;
            this.yanagirsayisi.Size = new Size(0x1d0, 20);
            this.yanagirsayisi.StyleController = this.layoutControl3;
            this.yanagirsayisi.TabIndex = 12;
            this.yanagirsayisi.TextChanged += new EventHandler(this.karkascizertextchanged);
            this.yanagirsayisi.KeyDown += new KeyEventHandler(this.int_KeyDown);
            this.yanagirsayisi.KeyPress += new KeyPressEventHandler(this.int_KeyPress);
            this.yanagirsayisi.Validated += new EventHandler(this.karkascizervalidated);
            this.karsiagryukseklik.Enabled = false;
            this.karsiagryukseklik.EnterMoveNextControl = true;
            this.karsiagryukseklik.Location = new Point(0x200, 0x74);
            this.karsiagryukseklik.Name = "karsiagryukseklik";
            this.karsiagryukseklik.Properties.Appearance.BackColor = Color.Transparent;
            this.karsiagryukseklik.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.karsiagryukseklik.Properties.Appearance.Options.UseBackColor = true;
            this.karsiagryukseklik.Properties.Appearance.Options.UseFont = true;
            this.karsiagryukseklik.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagryukseklik.Size = new Size(0x59, 0x12);
            this.karsiagryukseklik.StyleController = this.layoutControl3;
            this.karsiagryukseklik.TabIndex = 3;
            this.label3boymm.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3boymm.AutoSizeMode = LabelAutoSizeMode.None;
            this.label3boymm.Location = new Point(0x25d, 90);
            this.label3boymm.Name = "label3boymm";
            this.label3boymm.Size = new Size(40, 14);
            this.label3boymm.StyleController = this.layoutControl3;
            this.label3boymm.TabIndex = 8;
            this.label3boymm.Text = "mm";
            this.karsiagrboy.Enabled = false;
            this.karsiagrboy.EnterMoveNextControl = true;
            this.karsiagrboy.Location = new Point(0x200, 0x5e);
            this.karsiagrboy.Name = "karsiagrboy";
            this.karsiagrboy.Properties.Appearance.BackColor = Color.Transparent;
            this.karsiagrboy.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.karsiagrboy.Properties.Appearance.Options.UseBackColor = true;
            this.karsiagrboy.Properties.Appearance.Options.UseFont = true;
            this.karsiagrboy.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagrboy.Size = new Size(0x59, 0x12);
            this.karsiagrboy.StyleController = this.layoutControl3;
            this.karsiagrboy.TabIndex = 2;
            this.label3enmm.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3enmm.AutoSizeMode = LabelAutoSizeMode.None;
            this.label3enmm.Location = new Point(0x25d, 0x48);
            this.label3enmm.Name = "label3enmm";
            this.label3enmm.Size = new Size(40, 14);
            this.label3enmm.StyleController = this.layoutControl3;
            this.label3enmm.TabIndex = 7;
            this.label3enmm.Text = "mm";
            this.regulatormarka.Location = new Point(0x93, 0x74);
            this.regulatormarka.Name = "regulatormarka";
            this.regulatormarka.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.regulatormarka.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray4 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.regulatormarka.Properties.Buttons.AddRange(buttonArray4);
            this.regulatormarka.Properties.NullText = "";
            this.regulatormarka.Properties.View = this.gridView3;
            this.regulatormarka.Properties.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            this.regulatormarka.Size = new Size(0xb6, 20);
            this.regulatormarka.StyleController = this.layoutControl3;
            this.regulatormarka.TabIndex = 1;
            this.regulatormarka.EditValueChanged += new EventHandler(this.regulatormarka_EditValueChanged);
            GridColumn[] columnArray1 = new GridColumn[] { this.gridColumn65, this.gridColumn66, this.gridColumn67, this.gridColumn68, this.gridColumn69, this.gridColumn70 };
            this.gridView3.Columns.AddRange(columnArray1);
            this.gridView3.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridColumn65.Caption = "gridColumn37";
            this.gridColumn65.FieldName = "guid";
            this.gridColumn65.Name = "gridColumn65";
            this.gridColumn66.Caption = "gridColumn38";
            this.gridColumn66.FieldName = "uretici";
            this.gridColumn66.Name = "gridColumn66";
            this.gridColumn67.Caption = "gridColumn39";
            this.gridColumn67.FieldName = "model";
            this.gridColumn67.Name = "gridColumn67";
            this.gridColumn68.Caption = "MARKA VE MODEL";
            this.gridColumn68.FieldName = "MARKA_MODEL";
            this.gridColumn68.Name = "gridColumn68";
            this.gridColumn68.Visible = true;
            this.gridColumn68.VisibleIndex = 0;
            this.gridColumn69.Caption = "gridColumn41";
            this.gridColumn69.FieldName = "serino";
            this.gridColumn69.Name = "gridColumn69";
            this.gridColumn70.Caption = "gridColumn42";
            this.gridColumn70.FieldName = "belgeveren";
            this.gridColumn70.Name = "gridColumn70";
            this.karsiagren.Enabled = false;
            this.karsiagren.EnterMoveNextControl = true;
            this.karsiagren.Location = new Point(0xb5, 0x48);
            this.karsiagren.Name = "karsiagren";
            this.karsiagren.Properties.Appearance.BackColor = Color.Transparent;
            this.karsiagren.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.karsiagren.Properties.Appearance.Options.UseBackColor = true;
            this.karsiagren.Properties.Appearance.Options.UseFont = true;
            this.karsiagren.Properties.BorderStyle = BorderStyles.NoBorder;
            this.karsiagren.Size = new Size(420, 0x12);
            this.karsiagren.StyleController = this.layoutControl3;
            this.karsiagren.TabIndex = 1;
            this.karsiagrsecim.Location = new Point(0xb5, 0x18);
            this.karsiagrsecim.Name = "karsiagrsecim";
            EditorButton[] buttonArray5 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.karsiagrsecim.Properties.Buttons.AddRange(buttonArray5);
            LookUpColumnInfo[] infoArray4 = new LookUpColumnInfo[] { new LookUpColumnInfo("sno", "No", 20, FormatType.None, "", false, HorzAlignment.Default), new LookUpColumnInfo("cinsi", "Karşı Ağırlık Cinsi") };
            this.karsiagrsecim.Properties.Columns.AddRange(infoArray4);
            this.karsiagrsecim.Properties.NullText = "";
            this.karsiagrsecim.Size = new Size(0x1d0, 20);
            this.karsiagrsecim.StyleController = this.layoutControl3;
            this.karsiagrsecim.TabIndex = 0x2c;
            this.karsiagrsecim.EditValueChanged += new EventHandler(this.karsiagrsecim_EditValueChanged);
            this.karsiagrsecim.TextChanged += new EventHandler(this.karkascizertextchanged);
            this.karsiagrsecim.Validated += new EventHandler(this.karkascizervalidated);
            this.karsiagrmodel.EnterMoveNextControl = true;
            this.karsiagrmodel.Location = new Point(0xb5, 0x30);
            this.karsiagrmodel.Name = "karsiagrmodel";
            this.karsiagrmodel.Properties.Appearance.Font = new Font("Tahoma", 9f);
            this.karsiagrmodel.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray6 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.karsiagrmodel.Properties.Buttons.AddRange(buttonArray6);
            LookUpColumnInfo[] infoArray5 = new LookUpColumnInfo[] { new LookUpColumnInfo("sno", "No", 20, FormatType.None, "", false, HorzAlignment.Default), new LookUpColumnInfo("cinsi", "Cinsi", 20, FormatType.None, "", false, HorzAlignment.Default), new LookUpColumnInfo("model", "Model"), new LookUpColumnInfo("en", "En"), new LookUpColumnInfo("boy", "Boy"), new LookUpColumnInfo("yukseklik", "Y\x00fckseklik"), new LookUpColumnInfo("birimagirlik", "Birim Ağırlık"), new LookUpColumnInfo("ozgulkutle", "\x00d6zg\x00fcl K\x00fctle") };
            this.karsiagrmodel.Properties.Columns.AddRange(infoArray5);
            this.karsiagrmodel.Properties.NullText = "";
            this.karsiagrmodel.Size = new Size(0x1d0, 20);
            this.karsiagrmodel.StyleController = this.layoutControl3;
            this.karsiagrmodel.TabIndex = 0x29;
            this.karsiagrmodel.EditValueChanged += new EventHandler(this.karsiagrmodel_EditValueChanged);
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray7 = new BaseLayoutItem[] { 
                this.layoutControlItem13, this.label3regmarka, this.layoutControlItem24, this.label3baritdokum, this.label3modelsec, this.label3enbilgisi, this.layoutControlItem30, this.label3boybilgisi, this.layoutControlItem32, this.label3yukseklikbilgisi, this.layoutControlItem35, this.layoutControlItem36, this.layoutControlItem37, this.lbldengekatsayi, this.label3karkasagr, this.label3yanagr,
                this.label3arkaagr, this.layoutControlItem42, this.label3ozgulkutle, this.label3birimagr, this.layoutControlItem25
            };
            this.layoutControlGroup1.Items.AddRange(itemArray7);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x3ab, 0x1d5);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem13.Control = this.label3regulatorbilgi;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new Point(0, 0x5c);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new Size(0x14b, 0x16);
            this.layoutControlItem13.TextSize = new Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            this.label3regmarka.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3regmarka.AppearanceItemCaption.Options.UseFont = true;
            this.label3regmarka.Control = this.regulatormarka;
            this.label3regmarka.CustomizationFormText = "Reg\x00fclat\x00f6r Marka : ";
            this.label3regmarka.Location = new Point(0, 0x72);
            this.label3regmarka.Name = "label3regmarka";
            this.label3regmarka.Size = new Size(0x14b, 0x2e);
            this.label3regmarka.Text = "Reg\x00fclat\x00f6r Marka : ";
            this.label3regmarka.TextAlignMode = TextAlignModeItem.CustomSize;
            this.label3regmarka.TextSize = new Size(140, 0);
            this.label3regmarka.TextToControlDistance = 5;
            this.layoutControlItem24.Control = this.label3karsiagirlik;
            this.layoutControlItem24.CustomizationFormText = "layoutControlItem24";
            this.layoutControlItem24.Location = new Point(0, 0);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new Size(0x287, 0x16);
            this.layoutControlItem24.TextSize = new Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            this.label3baritdokum.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3baritdokum.AppearanceItemCaption.Options.UseFont = true;
            this.label3baritdokum.Control = this.karsiagrsecim;
            this.label3baritdokum.CustomizationFormText = "Barit && D\x00f6k\x00fcm Se\x00e7imi : ";
            this.label3baritdokum.Location = new Point(0, 0x16);
            this.label3baritdokum.Name = "label3baritdokum";
            this.label3baritdokum.Size = new Size(0x287, 0x18);
            this.label3baritdokum.Text = "Barit && D\x00f6k\x00fcm Se\x00e7imi : ";
            this.label3baritdokum.TextSize = new Size(0xb0, 14);
            this.label3modelsec.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3modelsec.AppearanceItemCaption.Options.UseFont = true;
            this.label3modelsec.Control = this.karsiagrmodel;
            this.label3modelsec.CustomizationFormText = "Model Se\x00e7iniz : ";
            this.label3modelsec.Location = new Point(0, 0x2e);
            this.label3modelsec.Name = "label3modelsec";
            this.label3modelsec.Size = new Size(0x287, 0x18);
            this.label3modelsec.Text = "Model Se\x00e7iniz : ";
            this.label3modelsec.TextSize = new Size(0xb0, 14);
            this.label3enbilgisi.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3enbilgisi.AppearanceItemCaption.Options.UseFont = true;
            this.label3enbilgisi.Control = this.karsiagren;
            this.label3enbilgisi.CustomizationFormText = "En : ";
            this.label3enbilgisi.Location = new Point(0, 70);
            this.label3enbilgisi.Name = "label3enbilgisi";
            this.label3enbilgisi.Size = new Size(0x25b, 0x16);
            this.label3enbilgisi.Text = "En : ";
            this.label3enbilgisi.TextSize = new Size(0xb0, 14);
            this.layoutControlItem30.Control = this.label3enmm;
            this.layoutControlItem30.CustomizationFormText = "layoutControlItem30";
            this.layoutControlItem30.Location = new Point(0x25b, 70);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new Size(0x2c, 0x12);
            this.layoutControlItem30.TextSize = new Size(0, 0);
            this.layoutControlItem30.TextVisible = false;
            this.label3boybilgisi.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3boybilgisi.AppearanceItemCaption.Options.UseFont = true;
            this.label3boybilgisi.Control = this.karsiagrboy;
            this.label3boybilgisi.CustomizationFormText = "Boy : ";
            this.label3boybilgisi.Location = new Point(0x14b, 0x5c);
            this.label3boybilgisi.Name = "label3boybilgisi";
            this.label3boybilgisi.Size = new Size(0x110, 0x16);
            this.label3boybilgisi.Text = "Boy : ";
            this.label3boybilgisi.TextSize = new Size(0xb0, 14);
            this.layoutControlItem32.Control = this.label3boymm;
            this.layoutControlItem32.CustomizationFormText = "layoutControlItem32";
            this.layoutControlItem32.Location = new Point(0x25b, 0x58);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new Size(0x2c, 0x12);
            this.layoutControlItem32.TextSize = new Size(0, 0);
            this.layoutControlItem32.TextVisible = false;
            this.label3yukseklikbilgisi.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3yukseklikbilgisi.AppearanceItemCaption.Options.UseFont = true;
            this.label3yukseklikbilgisi.Control = this.karsiagryukseklik;
            this.label3yukseklikbilgisi.CustomizationFormText = "Y\x00fckseklik : ";
            this.label3yukseklikbilgisi.Location = new Point(0x14b, 0x72);
            this.label3yukseklikbilgisi.Name = "label3yukseklikbilgisi";
            this.label3yukseklikbilgisi.Size = new Size(0x110, 0x16);
            this.label3yukseklikbilgisi.Text = "Y\x00fckseklik : ";
            this.label3yukseklikbilgisi.TextSize = new Size(0xb0, 14);
            this.layoutControlItem35.Control = this.label3yuksekmm;
            this.layoutControlItem35.CustomizationFormText = "layoutControlItem35";
            this.layoutControlItem35.Location = new Point(0x25b, 0x6a);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new Size(0x2c, 0x12);
            this.layoutControlItem35.TextSize = new Size(0, 0);
            this.layoutControlItem35.TextVisible = false;
            this.layoutControlItem36.Control = this.label3kutlekg;
            this.layoutControlItem36.CustomizationFormText = "layoutControlItem36";
            this.layoutControlItem36.Location = new Point(0x25b, 0x7c);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new Size(0x2c, 0x12);
            this.layoutControlItem36.TextSize = new Size(0, 0);
            this.layoutControlItem36.TextVisible = false;
            this.layoutControlItem37.Control = this.label3birimkg;
            this.layoutControlItem37.CustomizationFormText = "layoutControlItem37";
            this.layoutControlItem37.Location = new Point(0x25b, 0x8e);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new Size(0x2c, 0x12);
            this.layoutControlItem37.TextSize = new Size(0, 0);
            this.layoutControlItem37.TextVisible = false;
            this.lbldengekatsayi.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.lbldengekatsayi.AppearanceItemCaption.Options.UseFont = true;
            this.lbldengekatsayi.Control = this.dengekatsayisi;
            this.lbldengekatsayi.CustomizationFormText = "Denge Katsayısı : ";
            this.lbldengekatsayi.Location = new Point(0, 0xb6);
            this.lbldengekatsayi.Name = "lbldengekatsayi";
            this.lbldengekatsayi.Size = new Size(0x287, 0x18);
            this.lbldengekatsayi.Text = "Denge Katsayısı : ";
            this.lbldengekatsayi.TextSize = new Size(0xb0, 14);
            this.label3karkasagr.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3karkasagr.AppearanceItemCaption.Options.UseFont = true;
            this.label3karkasagr.Control = this.karkasagirlik;
            this.label3karkasagr.CustomizationFormText = "Karşı Ağırlık Karkası Ağırlığı : ";
            this.label3karkasagr.Location = new Point(0, 0xce);
            this.label3karkasagr.Name = "label3karkasagr";
            this.label3karkasagr.Size = new Size(0x287, 0x18);
            this.label3karkasagr.Text = "Karşı Ağırlık Karkası Ağırlığı : ";
            this.label3karkasagr.TextSize = new Size(0xb0, 14);
            this.label3yanagr.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3yanagr.AppearanceItemCaption.Options.UseFont = true;
            this.label3yanagr.Control = this.yanagirsayisi;
            this.label3yanagr.CustomizationFormText = "Alt Alta Ağırlık Adedi : ";
            this.label3yanagr.Location = new Point(0, 230);
            this.label3yanagr.Name = "label3yanagr";
            this.label3yanagr.Size = new Size(0x287, 0x18);
            this.label3yanagr.Text = "Alt Alta Ağırlık Adedi : ";
            this.label3yanagr.TextSize = new Size(0xb0, 14);
            this.label3arkaagr.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3arkaagr.AppearanceItemCaption.Options.UseFont = true;
            this.label3arkaagr.Control = this.arkaagirsayisi;
            this.label3arkaagr.CustomizationFormText = "Arka Arkaya Ağırlık Adedi : ";
            this.label3arkaagr.Location = new Point(0, 0xfe);
            this.label3arkaagr.Name = "label3arkaagr";
            this.label3arkaagr.Size = new Size(0x287, 0x18);
            this.label3arkaagr.Text = "Arka Arkaya Ağırlık Adedi : ";
            this.label3arkaagr.TextSize = new Size(0xb0, 14);
            this.layoutControlItem42.Control = this.karkasgrup;
            this.layoutControlItem42.CustomizationFormText = "layoutControlItem42";
            this.layoutControlItem42.Location = new Point(0, 0x116);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new Size(0x287, 0xbf);
            this.layoutControlItem42.TextSize = new Size(0, 0);
            this.layoutControlItem42.TextVisible = false;
            this.label3ozgulkutle.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3ozgulkutle.AppearanceItemCaption.Options.UseFont = true;
            this.label3ozgulkutle.Control = this.karsiagrozgulkutle;
            this.label3ozgulkutle.CustomizationFormText = "\x00d6zg\x00fcl K\x00fctle : ";
            this.label3ozgulkutle.Location = new Point(0x14b, 0x88);
            this.label3ozgulkutle.Name = "label3ozgulkutle";
            this.label3ozgulkutle.Size = new Size(0x110, 0x18);
            this.label3ozgulkutle.Text = "\x00d6zg\x00fcl K\x00fctle : ";
            this.label3ozgulkutle.TextSize = new Size(0xb0, 14);
            this.label3birimagr.AppearanceItemCaption.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label3birimagr.AppearanceItemCaption.Options.UseFont = true;
            this.label3birimagr.Control = this.karsiagrbirimagirlik;
            this.label3birimagr.CustomizationFormText = "Birim Ağırlık : ";
            this.label3birimagr.Location = new Point(0, 160);
            this.label3birimagr.Name = "label3birimagr";
            this.label3birimagr.Size = new Size(0x287, 0x16);
            this.label3birimagr.Text = "Birim Ağırlık : ";
            this.label3birimagr.TextSize = new Size(0xb0, 14);
            this.layoutControlItem25.Control = this.panel1;
            this.layoutControlItem25.CustomizationFormText = "layoutControlItem25";
            this.layoutControlItem25.Location = new Point(0x287, 0);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new Size(0x124, 0x1d5);
            this.layoutControlItem25.TextSize = new Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            this.backstageViewClientControl5.Controls.Add(this.dosyahidasnicin);
            this.backstageViewClientControl5.Controls.Add(this.dosyalblelektrasnicin);
            this.backstageViewClientControl5.Controls.Add(this.layoutControl6);
            this.backstageViewClientControl5.Controls.Add(this.layoutControl5);
            this.backstageViewClientControl5.Location = new Point(0xa5, 0);
            this.backstageViewClientControl5.Name = "backstageViewClientControl5";
            this.backstageViewClientControl5.Size = new Size(0x479, 0x331);
            this.backstageViewClientControl5.TabIndex = 4;
            this.dosyahidasnicin.AppearanceCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyahidasnicin.AppearanceCaption.Options.UseFont = true;
            this.dosyahidasnicin.Controls.Add(this.layoutControl23);
            this.dosyahidasnicin.Dock = DockStyle.Fill;
            this.dosyahidasnicin.Location = new Point(0x138, 370);
            this.dosyahidasnicin.Name = "dosyahidasnicin";
            this.dosyahidasnicin.Size = new Size(0x341, 0x1bf);
            this.dosyahidasnicin.TabIndex = 0xae;
            this.dosyahidasnicin.Text = "HİDROLİKLİ ASANS\x00d6R İ\x00c7İN GEREKEN BİLGİLERİ";
            this.layoutControl23.Controls.Add(this.dosyahortumserino);
            this.layoutControl23.Controls.Add(this.dosyahortumonaylayan);
            this.layoutControl23.Controls.Add(this.dosyahortumbelgeno);
            this.layoutControl23.Controls.Add(this.dosyahortummodel);
            this.layoutControl23.Controls.Add(this.dosyahortumuretici);
            this.layoutControl23.Controls.Add(this.dosyalblhortum);
            this.layoutControl23.Controls.Add(this.dosyalblserino2);
            this.layoutControl23.Controls.Add(this.dosyalblonaylayan2);
            this.layoutControl23.Controls.Add(this.dosyalblbelgeno2);
            this.layoutControl23.Controls.Add(this.dosyalblmodel2);
            this.layoutControl23.Controls.Add(this.dosyalbldebi);
            this.layoutControl23.Controls.Add(this.dosyalbluret2);
            this.layoutControl23.Controls.Add(this.dosyalblmalz2);
            this.layoutControl23.Controls.Add(this.dosyadebiserino);
            this.layoutControl23.Controls.Add(this.dosyadebionaylayan);
            this.layoutControl23.Controls.Add(this.dosyadebibelgeno);
            this.layoutControl23.Controls.Add(this.dosyadebimodel);
            this.layoutControl23.Controls.Add(this.dosyadebiuret);
            this.layoutControl23.Dock = DockStyle.Fill;
            this.layoutControl23.Location = new Point(2, 0x15);
            this.layoutControl23.Name = "layoutControl23";
            this.layoutControl23.Root = this.layoutControlGroup23;
            this.layoutControl23.Size = new Size(0x33d, 0x1a8);
            this.layoutControl23.TabIndex = 8;
            this.layoutControl23.Text = "layoutControl23";
            this.dosyahortumserino.EnterMoveNextControl = true;
            this.dosyahortumserino.Location = new Point(0x214, 60);
            this.dosyahortumserino.Name = "dosyahortumserino";
            this.dosyahortumserino.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyahortumserino.Properties.Appearance.Options.UseFont = true;
            this.dosyahortumserino.Size = new Size(0x121, 0x16);
            this.dosyahortumserino.StyleController = this.layoutControl23;
            this.dosyahortumserino.TabIndex = 10;
            this.dosyahortumonaylayan.EnterMoveNextControl = true;
            this.dosyahortumonaylayan.Location = new Point(440, 60);
            this.dosyahortumonaylayan.Name = "dosyahortumonaylayan";
            this.dosyahortumonaylayan.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyahortumonaylayan.Properties.Appearance.Options.UseFont = true;
            this.dosyahortumonaylayan.Size = new Size(0x58, 0x16);
            this.dosyahortumonaylayan.StyleController = this.layoutControl23;
            this.dosyahortumonaylayan.TabIndex = 9;
            this.dosyahortumbelgeno.EnterMoveNextControl = true;
            this.dosyahortumbelgeno.Location = new Point(350, 60);
            this.dosyahortumbelgeno.Name = "dosyahortumbelgeno";
            this.dosyahortumbelgeno.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyahortumbelgeno.Properties.Appearance.Options.UseFont = true;
            this.dosyahortumbelgeno.Size = new Size(0x56, 0x16);
            this.dosyahortumbelgeno.StyleController = this.layoutControl23;
            this.dosyahortumbelgeno.TabIndex = 8;
            this.dosyahortummodel.EnterMoveNextControl = true;
            this.dosyahortummodel.Location = new Point(0x103, 60);
            this.dosyahortummodel.Name = "dosyahortummodel";
            this.dosyahortummodel.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyahortummodel.Properties.Appearance.Options.UseFont = true;
            this.dosyahortummodel.Size = new Size(0x57, 0x16);
            this.dosyahortummodel.StyleController = this.layoutControl23;
            this.dosyahortummodel.TabIndex = 7;
            this.dosyahortumuretici.EnterMoveNextControl = true;
            this.dosyahortumuretici.Location = new Point(0xa8, 60);
            this.dosyahortumuretici.Name = "dosyahortumuretici";
            this.dosyahortumuretici.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyahortumuretici.Properties.Appearance.Options.UseFont = true;
            this.dosyahortumuretici.Size = new Size(0x57, 0x16);
            this.dosyahortumuretici.StyleController = this.layoutControl23;
            this.dosyahortumuretici.TabIndex = 6;
            this.dosyalblhortum.Appearance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblhortum.Location = new Point(8, 60);
            this.dosyalblhortum.Name = "dosyalblhortum";
            this.dosyalblhortum.Size = new Size(0x9c, 0x16);
            this.dosyalblhortum.StyleController = this.layoutControl23;
            this.dosyalblhortum.TabIndex = 1;
            this.dosyalblhortum.Text = "Hortum Patlama Valfi : ";
            this.dosyalblserino2.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblserino2.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblserino2.AutoSizeMode = LabelAutoSizeMode.None;
            this.dosyalblserino2.Location = new Point(0x214, 8);
            this.dosyalblserino2.Name = "dosyalblserino2";
            this.dosyalblserino2.Size = new Size(0x121, 0x16);
            this.dosyalblserino2.StyleController = this.layoutControl23;
            this.dosyalblserino2.TabIndex = 1;
            this.dosyalblserino2.Text = "\x00dcR. SERİ NO";
            this.dosyalblonaylayan2.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblonaylayan2.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblonaylayan2.Location = new Point(440, 8);
            this.dosyalblonaylayan2.Name = "dosyalblonaylayan2";
            this.dosyalblonaylayan2.Size = new Size(0x58, 0x16);
            this.dosyalblonaylayan2.StyleController = this.layoutControl23;
            this.dosyalblonaylayan2.TabIndex = 1;
            this.dosyalblonaylayan2.Text = "ONAYLAYAN";
            this.dosyalblbelgeno2.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblbelgeno2.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblbelgeno2.Location = new Point(350, 8);
            this.dosyalblbelgeno2.Name = "dosyalblbelgeno2";
            this.dosyalblbelgeno2.Size = new Size(0x56, 0x16);
            this.dosyalblbelgeno2.StyleController = this.layoutControl23;
            this.dosyalblbelgeno2.TabIndex = 1;
            this.dosyalblbelgeno2.Text = "BELGE NO";
            this.dosyalblmodel2.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblmodel2.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblmodel2.Location = new Point(0x103, 8);
            this.dosyalblmodel2.Name = "dosyalblmodel2";
            this.dosyalblmodel2.Size = new Size(0x57, 0x16);
            this.dosyalblmodel2.StyleController = this.layoutControl23;
            this.dosyalblmodel2.TabIndex = 1;
            this.dosyalblmodel2.Text = "MODEL";
            this.dosyalbldebi.Appearance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalbldebi.Location = new Point(8, 0x22);
            this.dosyalbldebi.Name = "dosyalbldebi";
            this.dosyalbldebi.Size = new Size(0x9c, 0x16);
            this.dosyalbldebi.StyleController = this.layoutControl23;
            this.dosyalbldebi.TabIndex = 1;
            this.dosyalbldebi.Text = "Deni Sınırlama Valfi : ";
            this.dosyalbluret2.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalbluret2.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalbluret2.Location = new Point(0xa8, 8);
            this.dosyalbluret2.Name = "dosyalbluret2";
            this.dosyalbluret2.Size = new Size(0x57, 0x16);
            this.dosyalbluret2.StyleController = this.layoutControl23;
            this.dosyalbluret2.TabIndex = 1;
            this.dosyalbluret2.Text = "\x00dcRETİCİ";
            this.dosyalblmalz2.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblmalz2.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblmalz2.Location = new Point(8, 8);
            this.dosyalblmalz2.Name = "dosyalblmalz2";
            this.dosyalblmalz2.Size = new Size(0x9c, 0x16);
            this.dosyalblmalz2.StyleController = this.layoutControl23;
            this.dosyalblmalz2.TabIndex = 1;
            this.dosyalblmalz2.Text = "MALZEME";
            this.dosyadebiserino.EnterMoveNextControl = true;
            this.dosyadebiserino.Location = new Point(0x214, 0x22);
            this.dosyadebiserino.Name = "dosyadebiserino";
            this.dosyadebiserino.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyadebiserino.Properties.Appearance.Options.UseFont = true;
            this.dosyadebiserino.Size = new Size(0x121, 0x16);
            this.dosyadebiserino.StyleController = this.layoutControl23;
            this.dosyadebiserino.TabIndex = 5;
            this.dosyadebionaylayan.EnterMoveNextControl = true;
            this.dosyadebionaylayan.Location = new Point(440, 0x22);
            this.dosyadebionaylayan.Name = "dosyadebionaylayan";
            this.dosyadebionaylayan.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyadebionaylayan.Properties.Appearance.Options.UseFont = true;
            this.dosyadebionaylayan.Size = new Size(0x58, 0x16);
            this.dosyadebionaylayan.StyleController = this.layoutControl23;
            this.dosyadebionaylayan.TabIndex = 4;
            this.dosyadebibelgeno.EnterMoveNextControl = true;
            this.dosyadebibelgeno.Location = new Point(350, 0x22);
            this.dosyadebibelgeno.Name = "dosyadebibelgeno";
            this.dosyadebibelgeno.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyadebibelgeno.Properties.Appearance.Options.UseFont = true;
            this.dosyadebibelgeno.Size = new Size(0x56, 0x16);
            this.dosyadebibelgeno.StyleController = this.layoutControl23;
            this.dosyadebibelgeno.TabIndex = 3;
            this.dosyadebimodel.EnterMoveNextControl = true;
            this.dosyadebimodel.Location = new Point(0x103, 0x22);
            this.dosyadebimodel.Name = "dosyadebimodel";
            this.dosyadebimodel.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyadebimodel.Properties.Appearance.Options.UseFont = true;
            this.dosyadebimodel.Size = new Size(0x57, 0x16);
            this.dosyadebimodel.StyleController = this.layoutControl23;
            this.dosyadebimodel.TabIndex = 2;
            this.dosyadebiuret.EnterMoveNextControl = true;
            this.dosyadebiuret.Location = new Point(0xa8, 0x22);
            this.dosyadebiuret.Name = "dosyadebiuret";
            this.dosyadebiuret.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyadebiuret.Properties.Appearance.Options.UseFont = true;
            this.dosyadebiuret.Size = new Size(0x57, 0x16);
            this.dosyadebiuret.StyleController = this.layoutControl23;
            this.dosyadebiuret.TabIndex = 1;
            this.layoutControlGroup23.CustomizationFormText = "layoutControlGroup23";
            this.layoutControlGroup23.EnableIndentsWithoutBorders = DefaultBoolean.True;
            BaseLayoutItem[] itemArray8 = new BaseLayoutItem[] { 
                this.layoutControlItem345, this.layoutControlItem346, this.layoutControlItem347, this.layoutControlItem348, this.layoutControlItem349, this.layoutControlItem350, this.layoutControlItem351, this.layoutControlItem352, this.layoutControlItem353, this.layoutControlItem354, this.layoutControlItem355, this.layoutControlItem356, this.layoutControlItem357, this.layoutControlItem358, this.layoutControlItem359, this.layoutControlItem360,
                this.layoutControlItem361, this.layoutControlItem362
            };
            this.layoutControlGroup23.Items.AddRange(itemArray8);
            this.layoutControlGroup23.Location = new Point(0, 0);
            this.layoutControlGroup23.Name = "layoutControlGroup23";
            this.layoutControlGroup23.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup23.Size = new Size(0x33d, 0x1a8);
            this.layoutControlGroup23.TextVisible = false;
            this.layoutControlItem345.Control = this.dosyadebiuret;
            this.layoutControlItem345.CustomizationFormText = "MARKA";
            this.layoutControlItem345.Location = new Point(160, 0x1a);
            this.layoutControlItem345.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem345.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem345.Name = "layoutControlItem345";
            this.layoutControlItem345.Size = new Size(0x5b, 0x1a);
            this.layoutControlItem345.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem345.Text = "MARKA";
            this.layoutControlItem345.TextLocation = Locations.Top;
            this.layoutControlItem345.TextSize = new Size(0, 0);
            this.layoutControlItem345.TextVisible = false;
            this.layoutControlItem346.Control = this.dosyadebimodel;
            this.layoutControlItem346.CustomizationFormText = "MODEL";
            this.layoutControlItem346.Location = new Point(0xfb, 0x1a);
            this.layoutControlItem346.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem346.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem346.Name = "layoutControlItem346";
            this.layoutControlItem346.Size = new Size(0x5b, 0x1a);
            this.layoutControlItem346.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem346.Text = "MODEL";
            this.layoutControlItem346.TextLocation = Locations.Top;
            this.layoutControlItem346.TextSize = new Size(0, 0);
            this.layoutControlItem346.TextVisible = false;
            this.layoutControlItem347.Control = this.dosyadebibelgeno;
            this.layoutControlItem347.CustomizationFormText = "SERİ NO";
            this.layoutControlItem347.Location = new Point(0x156, 0x1a);
            this.layoutControlItem347.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem347.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem347.Name = "layoutControlItem347";
            this.layoutControlItem347.Size = new Size(90, 0x1a);
            this.layoutControlItem347.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem347.Text = "SERİ NO";
            this.layoutControlItem347.TextLocation = Locations.Top;
            this.layoutControlItem347.TextSize = new Size(0, 0);
            this.layoutControlItem347.TextVisible = false;
            this.layoutControlItem348.Control = this.dosyadebionaylayan;
            this.layoutControlItem348.CustomizationFormText = "T";
            this.layoutControlItem348.Location = new Point(0x1b0, 0x1a);
            this.layoutControlItem348.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem348.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem348.Name = "layoutControlItem348";
            this.layoutControlItem348.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem348.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem348.Text = "T";
            this.layoutControlItem348.TextLocation = Locations.Top;
            this.layoutControlItem348.TextSize = new Size(0, 0);
            this.layoutControlItem348.TextVisible = false;
            this.layoutControlItem349.Control = this.dosyadebiserino;
            this.layoutControlItem349.CustomizationFormText = "layoutControlItem349";
            this.layoutControlItem349.Location = new Point(0x20c, 0x1a);
            this.layoutControlItem349.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem349.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem349.Name = "layoutControlItem349";
            this.layoutControlItem349.Size = new Size(0x125, 0x1a);
            this.layoutControlItem349.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem349.TextLocation = Locations.Top;
            this.layoutControlItem349.TextSize = new Size(0, 0);
            this.layoutControlItem349.TextVisible = false;
            this.layoutControlItem350.Control = this.dosyalblmalz2;
            this.layoutControlItem350.CustomizationFormText = "layoutControlItem350";
            this.layoutControlItem350.Location = new Point(0, 0);
            this.layoutControlItem350.MaxSize = new Size(160, 0x1a);
            this.layoutControlItem350.MinSize = new Size(160, 0x1a);
            this.layoutControlItem350.Name = "layoutControlItem350";
            this.layoutControlItem350.Size = new Size(160, 0x1a);
            this.layoutControlItem350.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem350.TextSize = new Size(0, 0);
            this.layoutControlItem350.TextVisible = false;
            this.layoutControlItem351.Control = this.dosyalbluret2;
            this.layoutControlItem351.CustomizationFormText = "layoutControlItem351";
            this.layoutControlItem351.Location = new Point(160, 0);
            this.layoutControlItem351.MaxSize = new Size(0x5d, 0x1a);
            this.layoutControlItem351.MinSize = new Size(1, 0x1a);
            this.layoutControlItem351.Name = "layoutControlItem351";
            this.layoutControlItem351.Size = new Size(0x5b, 0x1a);
            this.layoutControlItem351.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem351.TextSize = new Size(0, 0);
            this.layoutControlItem351.TextVisible = false;
            this.layoutControlItem352.Control = this.dosyalbldebi;
            this.layoutControlItem352.CustomizationFormText = "layoutControlItem352";
            this.layoutControlItem352.Location = new Point(0, 0x1a);
            this.layoutControlItem352.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem352.MinSize = new Size(1, 0x1a);
            this.layoutControlItem352.Name = "layoutControlItem352";
            this.layoutControlItem352.Size = new Size(160, 0x1a);
            this.layoutControlItem352.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem352.TextSize = new Size(0, 0);
            this.layoutControlItem352.TextVisible = false;
            this.layoutControlItem353.Control = this.dosyalblmodel2;
            this.layoutControlItem353.CustomizationFormText = "layoutControlItem353";
            this.layoutControlItem353.Location = new Point(0xfb, 0);
            this.layoutControlItem353.MaxSize = new Size(0x5d, 0x1a);
            this.layoutControlItem353.MinSize = new Size(1, 0x1a);
            this.layoutControlItem353.Name = "layoutControlItem353";
            this.layoutControlItem353.Size = new Size(0x5b, 0x1a);
            this.layoutControlItem353.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem353.TextSize = new Size(0, 0);
            this.layoutControlItem353.TextVisible = false;
            this.layoutControlItem354.Control = this.dosyalblbelgeno2;
            this.layoutControlItem354.CustomizationFormText = "layoutControlItem354";
            this.layoutControlItem354.Location = new Point(0x156, 0);
            this.layoutControlItem354.MaxSize = new Size(0x5d, 0x1a);
            this.layoutControlItem354.MinSize = new Size(1, 0x1a);
            this.layoutControlItem354.Name = "layoutControlItem354";
            this.layoutControlItem354.Size = new Size(90, 0x1a);
            this.layoutControlItem354.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem354.TextSize = new Size(0, 0);
            this.layoutControlItem354.TextVisible = false;
            this.layoutControlItem355.Control = this.dosyalblonaylayan2;
            this.layoutControlItem355.CustomizationFormText = "layoutControlItem355";
            this.layoutControlItem355.Location = new Point(0x1b0, 0);
            this.layoutControlItem355.MaxSize = new Size(0x5d, 0x1a);
            this.layoutControlItem355.MinSize = new Size(1, 0x1a);
            this.layoutControlItem355.Name = "layoutControlItem355";
            this.layoutControlItem355.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem355.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem355.TextSize = new Size(0, 0);
            this.layoutControlItem355.TextVisible = false;
            this.layoutControlItem356.Control = this.dosyalblserino2;
            this.layoutControlItem356.CustomizationFormText = "layoutControlItem356";
            this.layoutControlItem356.Location = new Point(0x20c, 0);
            this.layoutControlItem356.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem356.MinSize = new Size(1, 0x1a);
            this.layoutControlItem356.Name = "layoutControlItem356";
            this.layoutControlItem356.Size = new Size(0x125, 0x1a);
            this.layoutControlItem356.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem356.TextSize = new Size(0, 0);
            this.layoutControlItem356.TextVisible = false;
            this.layoutControlItem357.Control = this.dosyalblhortum;
            this.layoutControlItem357.CustomizationFormText = "layoutControlItem357";
            this.layoutControlItem357.Location = new Point(0, 0x34);
            this.layoutControlItem357.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem357.MinSize = new Size(1, 0x1a);
            this.layoutControlItem357.Name = "layoutControlItem357";
            this.layoutControlItem357.Size = new Size(160, 360);
            this.layoutControlItem357.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem357.TextSize = new Size(0, 0);
            this.layoutControlItem357.TextVisible = false;
            this.layoutControlItem358.Control = this.dosyahortumuretici;
            this.layoutControlItem358.CustomizationFormText = "layoutControlItem358";
            this.layoutControlItem358.Location = new Point(160, 0x34);
            this.layoutControlItem358.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem358.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem358.Name = "layoutControlItem358";
            this.layoutControlItem358.Size = new Size(0x5b, 360);
            this.layoutControlItem358.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem358.TextSize = new Size(0, 0);
            this.layoutControlItem358.TextVisible = false;
            this.layoutControlItem359.Control = this.dosyahortummodel;
            this.layoutControlItem359.CustomizationFormText = "layoutControlItem359";
            this.layoutControlItem359.Location = new Point(0xfb, 0x34);
            this.layoutControlItem359.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem359.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem359.Name = "layoutControlItem359";
            this.layoutControlItem359.Size = new Size(0x5b, 360);
            this.layoutControlItem359.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem359.TextSize = new Size(0, 0);
            this.layoutControlItem359.TextVisible = false;
            this.layoutControlItem360.Control = this.dosyahortumbelgeno;
            this.layoutControlItem360.CustomizationFormText = "layoutControlItem360";
            this.layoutControlItem360.Location = new Point(0x156, 0x34);
            this.layoutControlItem360.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem360.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem360.Name = "layoutControlItem360";
            this.layoutControlItem360.Size = new Size(90, 360);
            this.layoutControlItem360.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem360.TextSize = new Size(0, 0);
            this.layoutControlItem360.TextVisible = false;
            this.layoutControlItem361.Control = this.dosyahortumonaylayan;
            this.layoutControlItem361.CustomizationFormText = "layoutControlItem361";
            this.layoutControlItem361.Location = new Point(0x1b0, 0x34);
            this.layoutControlItem361.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem361.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem361.Name = "layoutControlItem361";
            this.layoutControlItem361.Size = new Size(0x5c, 360);
            this.layoutControlItem361.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem361.TextSize = new Size(0, 0);
            this.layoutControlItem361.TextVisible = false;
            this.layoutControlItem362.Control = this.dosyahortumserino;
            this.layoutControlItem362.CustomizationFormText = "layoutControlItem362";
            this.layoutControlItem362.Location = new Point(0x20c, 0x34);
            this.layoutControlItem362.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem362.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem362.Name = "layoutControlItem362";
            this.layoutControlItem362.Size = new Size(0x125, 360);
            this.layoutControlItem362.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem362.TextSize = new Size(0, 0);
            this.layoutControlItem362.TextVisible = false;
            this.dosyalblelektrasnicin.AppearanceCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblelektrasnicin.AppearanceCaption.Options.UseFont = true;
            this.dosyalblelektrasnicin.Controls.Add(this.layoutControl24);
            this.dosyalblelektrasnicin.Dock = DockStyle.Top;
            this.dosyalblelektrasnicin.Location = new Point(0x138, 0x101);
            this.dosyalblelektrasnicin.Name = "dosyalblelektrasnicin";
            this.dosyalblelektrasnicin.Size = new Size(0x341, 0x71);
            this.dosyalblelektrasnicin.TabIndex = 0xad;
            this.dosyalblelektrasnicin.Text = "ELEKTRİKLİ ASANS\x00d6R İ\x00c7İN GEREKEN BİLGİLERİ";
            this.layoutControl24.Controls.Add(this.dosyamotorserino);
            this.layoutControl24.Controls.Add(this.dosyamotoronaylayan);
            this.layoutControl24.Controls.Add(this.dosyamotorbelgeno);
            this.layoutControl24.Controls.Add(this.dosyamotormodel);
            this.layoutControl24.Controls.Add(this.dosyamotoruretici);
            this.layoutControl24.Controls.Add(this.dosyalblmotor);
            this.layoutControl24.Controls.Add(this.dosyalblserino);
            this.layoutControl24.Controls.Add(this.dosyalblonaylayan);
            this.layoutControl24.Controls.Add(this.dosyalblbelgeno);
            this.layoutControl24.Controls.Add(this.dosyalblmodel);
            this.layoutControl24.Controls.Add(this.dosyalblmakine);
            this.layoutControl24.Controls.Add(this.dosyalbluret);
            this.layoutControl24.Controls.Add(this.dosyalblmalz);
            this.layoutControl24.Controls.Add(this.dosyamakineurserno);
            this.layoutControl24.Controls.Add(this.dosyamakineonaylayan);
            this.layoutControl24.Controls.Add(this.dosyamakinebelgeno);
            this.layoutControl24.Controls.Add(this.dosyamakinemodel);
            this.layoutControl24.Controls.Add(this.dosyamakineuret);
            this.layoutControl24.Dock = DockStyle.Fill;
            this.layoutControl24.Location = new Point(2, 0x15);
            this.layoutControl24.Name = "layoutControl24";
            this.layoutControl24.Root = this.layoutControlGroup24;
            this.layoutControl24.Size = new Size(0x33d, 90);
            this.layoutControl24.TabIndex = 0xac;
            this.layoutControl24.Text = "layoutControl24";
            this.dosyamotorserino.EnterMoveNextControl = true;
            this.dosyamotorserino.Location = new Point(0x1e3, 60);
            this.dosyamotorserino.Name = "dosyamotorserino";
            this.dosyamotorserino.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamotorserino.Properties.Appearance.Options.UseFont = true;
            this.dosyamotorserino.Size = new Size(0x152, 0x16);
            this.dosyamotorserino.StyleController = this.layoutControl24;
            this.dosyamotorserino.TabIndex = 10;
            this.dosyamotoronaylayan.EnterMoveNextControl = true;
            this.dosyamotoronaylayan.Location = new Point(0x187, 60);
            this.dosyamotoronaylayan.Name = "dosyamotoronaylayan";
            this.dosyamotoronaylayan.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamotoronaylayan.Properties.Appearance.Options.UseFont = true;
            this.dosyamotoronaylayan.Size = new Size(0x58, 0x16);
            this.dosyamotoronaylayan.StyleController = this.layoutControl24;
            this.dosyamotoronaylayan.TabIndex = 9;
            this.dosyamotorbelgeno.EnterMoveNextControl = true;
            this.dosyamotorbelgeno.Location = new Point(0x12b, 60);
            this.dosyamotorbelgeno.Name = "dosyamotorbelgeno";
            this.dosyamotorbelgeno.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamotorbelgeno.Properties.Appearance.Options.UseFont = true;
            this.dosyamotorbelgeno.Size = new Size(0x58, 0x16);
            this.dosyamotorbelgeno.StyleController = this.layoutControl24;
            this.dosyamotorbelgeno.TabIndex = 8;
            this.dosyamotormodel.EnterMoveNextControl = true;
            this.dosyamotormodel.Location = new Point(0xcf, 60);
            this.dosyamotormodel.Name = "dosyamotormodel";
            this.dosyamotormodel.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamotormodel.Properties.Appearance.Options.UseFont = true;
            this.dosyamotormodel.Size = new Size(0x58, 0x16);
            this.dosyamotormodel.StyleController = this.layoutControl24;
            this.dosyamotormodel.TabIndex = 7;
            this.dosyamotoruretici.EnterMoveNextControl = true;
            this.dosyamotoruretici.Location = new Point(0x73, 60);
            this.dosyamotoruretici.Name = "dosyamotoruretici";
            this.dosyamotoruretici.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamotoruretici.Properties.Appearance.Options.UseFont = true;
            this.dosyamotoruretici.Size = new Size(0x58, 0x16);
            this.dosyamotoruretici.StyleController = this.layoutControl24;
            this.dosyamotoruretici.TabIndex = 6;
            this.dosyalblmotor.Appearance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblmotor.Location = new Point(8, 60);
            this.dosyalblmotor.Name = "dosyalblmotor";
            this.dosyalblmotor.Size = new Size(0x67, 0x16);
            this.dosyalblmotor.StyleController = this.layoutControl24;
            this.dosyalblmotor.TabIndex = 0x10;
            this.dosyalblmotor.Text = "Motor : ";
            this.dosyalblserino.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblserino.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblserino.AutoSizeMode = LabelAutoSizeMode.None;
            this.dosyalblserino.Location = new Point(0x1e3, 8);
            this.dosyalblserino.Name = "dosyalblserino";
            this.dosyalblserino.Size = new Size(0x152, 0x16);
            this.dosyalblserino.StyleController = this.layoutControl24;
            this.dosyalblserino.TabIndex = 15;
            this.dosyalblserino.Text = "\x00dcR. SERİ NO";
            this.dosyalblonaylayan.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblonaylayan.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblonaylayan.Location = new Point(0x187, 8);
            this.dosyalblonaylayan.Name = "dosyalblonaylayan";
            this.dosyalblonaylayan.Size = new Size(0x58, 0x16);
            this.dosyalblonaylayan.StyleController = this.layoutControl24;
            this.dosyalblonaylayan.TabIndex = 14;
            this.dosyalblonaylayan.Text = "ONAYLAYAN";
            this.dosyalblbelgeno.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblbelgeno.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblbelgeno.Location = new Point(0x12b, 8);
            this.dosyalblbelgeno.Name = "dosyalblbelgeno";
            this.dosyalblbelgeno.Size = new Size(0x58, 0x16);
            this.dosyalblbelgeno.StyleController = this.layoutControl24;
            this.dosyalblbelgeno.TabIndex = 13;
            this.dosyalblbelgeno.Text = "BELGE NO";
            this.dosyalblmodel.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblmodel.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblmodel.Location = new Point(0xcf, 8);
            this.dosyalblmodel.Name = "dosyalblmodel";
            this.dosyalblmodel.Size = new Size(0x58, 0x16);
            this.dosyalblmodel.StyleController = this.layoutControl24;
            this.dosyalblmodel.TabIndex = 12;
            this.dosyalblmodel.Text = "MODEL";
            this.dosyalblmakine.Appearance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblmakine.Location = new Point(8, 0x22);
            this.dosyalblmakine.Name = "dosyalblmakine";
            this.dosyalblmakine.Size = new Size(0x67, 0x16);
            this.dosyalblmakine.StyleController = this.layoutControl24;
            this.dosyalblmakine.TabIndex = 11;
            this.dosyalblmakine.Text = "Makine : ";
            this.dosyalbluret.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalbluret.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalbluret.Location = new Point(0x73, 8);
            this.dosyalbluret.Name = "dosyalbluret";
            this.dosyalbluret.Size = new Size(0x58, 0x16);
            this.dosyalbluret.StyleController = this.layoutControl24;
            this.dosyalbluret.TabIndex = 10;
            this.dosyalbluret.Text = "\x00dcRETİCİ";
            this.dosyalblmalz.Appearance.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
            this.dosyalblmalz.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblmalz.Location = new Point(8, 8);
            this.dosyalblmalz.Name = "dosyalblmalz";
            this.dosyalblmalz.Size = new Size(0x67, 0x16);
            this.dosyalblmalz.StyleController = this.layoutControl24;
            this.dosyalblmalz.TabIndex = 9;
            this.dosyalblmalz.Text = "MALZEME";
            this.dosyamakineurserno.EnterMoveNextControl = true;
            this.dosyamakineurserno.Location = new Point(0x1e3, 0x22);
            this.dosyamakineurserno.Name = "dosyamakineurserno";
            this.dosyamakineurserno.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamakineurserno.Properties.Appearance.Options.UseFont = true;
            this.dosyamakineurserno.Size = new Size(0x152, 0x16);
            this.dosyamakineurserno.StyleController = this.layoutControl24;
            this.dosyamakineurserno.TabIndex = 5;
            this.dosyamakineonaylayan.EnterMoveNextControl = true;
            this.dosyamakineonaylayan.Location = new Point(0x187, 0x22);
            this.dosyamakineonaylayan.Name = "dosyamakineonaylayan";
            this.dosyamakineonaylayan.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamakineonaylayan.Properties.Appearance.Options.UseFont = true;
            this.dosyamakineonaylayan.Size = new Size(0x58, 0x16);
            this.dosyamakineonaylayan.StyleController = this.layoutControl24;
            this.dosyamakineonaylayan.TabIndex = 4;
            this.dosyamakinebelgeno.EnterMoveNextControl = true;
            this.dosyamakinebelgeno.Location = new Point(0x12b, 0x22);
            this.dosyamakinebelgeno.Name = "dosyamakinebelgeno";
            this.dosyamakinebelgeno.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamakinebelgeno.Properties.Appearance.Options.UseFont = true;
            this.dosyamakinebelgeno.Size = new Size(0x58, 0x16);
            this.dosyamakinebelgeno.StyleController = this.layoutControl24;
            this.dosyamakinebelgeno.TabIndex = 3;
            this.dosyamakinemodel.EnterMoveNextControl = true;
            this.dosyamakinemodel.Location = new Point(0xcf, 0x22);
            this.dosyamakinemodel.Name = "dosyamakinemodel";
            this.dosyamakinemodel.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamakinemodel.Properties.Appearance.Options.UseFont = true;
            this.dosyamakinemodel.Size = new Size(0x58, 0x16);
            this.dosyamakinemodel.StyleController = this.layoutControl24;
            this.dosyamakinemodel.TabIndex = 2;
            this.dosyamakineuret.EnterMoveNextControl = true;
            this.dosyamakineuret.Location = new Point(0x73, 0x22);
            this.dosyamakineuret.Name = "dosyamakineuret";
            this.dosyamakineuret.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyamakineuret.Properties.Appearance.Options.UseFont = true;
            this.dosyamakineuret.Size = new Size(0x58, 0x16);
            this.dosyamakineuret.StyleController = this.layoutControl24;
            this.dosyamakineuret.TabIndex = 1;
            this.layoutControlGroup24.CustomizationFormText = "layoutControlGroup23";
            this.layoutControlGroup24.EnableIndentsWithoutBorders = DefaultBoolean.True;
            BaseLayoutItem[] itemArray9 = new BaseLayoutItem[] { 
                this.layoutControlItem363, this.layoutControlItem364, this.layoutControlItem365, this.layoutControlItem366, this.layoutControlItem367, this.layoutControlItem368, this.layoutControlItem369, this.layoutControlItem370, this.layoutControlItem371, this.layoutControlItem372, this.layoutControlItem373, this.layoutControlItem374, this.layoutControlItem375, this.layoutControlItem376, this.layoutControlItem377, this.layoutControlItem378,
                this.layoutControlItem379, this.layoutControlItem380
            };
            this.layoutControlGroup24.Items.AddRange(itemArray9);
            this.layoutControlGroup24.Location = new Point(0, 0);
            this.layoutControlGroup24.Name = "layoutControlGroup23";
            this.layoutControlGroup24.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup24.Size = new Size(0x33d, 90);
            this.layoutControlGroup24.TextVisible = false;
            this.layoutControlItem363.Control = this.dosyamakineuret;
            this.layoutControlItem363.CustomizationFormText = "MARKA";
            this.layoutControlItem363.Location = new Point(0x6b, 0x1a);
            this.layoutControlItem363.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem363.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem363.Name = "layoutControlItem345";
            this.layoutControlItem363.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem363.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem363.Text = "MARKA";
            this.layoutControlItem363.TextLocation = Locations.Top;
            this.layoutControlItem363.TextSize = new Size(0, 0);
            this.layoutControlItem363.TextVisible = false;
            this.layoutControlItem364.Control = this.dosyamakinemodel;
            this.layoutControlItem364.CustomizationFormText = "MODEL";
            this.layoutControlItem364.Location = new Point(0xc7, 0x1a);
            this.layoutControlItem364.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem364.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem364.Name = "layoutControlItem346";
            this.layoutControlItem364.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem364.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem364.Text = "MODEL";
            this.layoutControlItem364.TextLocation = Locations.Top;
            this.layoutControlItem364.TextSize = new Size(0, 0);
            this.layoutControlItem364.TextVisible = false;
            this.layoutControlItem365.Control = this.dosyamakinebelgeno;
            this.layoutControlItem365.CustomizationFormText = "SERİ NO";
            this.layoutControlItem365.Location = new Point(0x123, 0x1a);
            this.layoutControlItem365.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem365.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem365.Name = "layoutControlItem347";
            this.layoutControlItem365.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem365.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem365.Text = "SERİ NO";
            this.layoutControlItem365.TextLocation = Locations.Top;
            this.layoutControlItem365.TextSize = new Size(0, 0);
            this.layoutControlItem365.TextVisible = false;
            this.layoutControlItem366.Control = this.dosyamakineonaylayan;
            this.layoutControlItem366.CustomizationFormText = "T";
            this.layoutControlItem366.Location = new Point(0x17f, 0x1a);
            this.layoutControlItem366.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem366.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem366.Name = "layoutControlItem348";
            this.layoutControlItem366.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem366.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem366.Text = "T";
            this.layoutControlItem366.TextLocation = Locations.Top;
            this.layoutControlItem366.TextSize = new Size(0, 0);
            this.layoutControlItem366.TextVisible = false;
            this.layoutControlItem367.Control = this.dosyamakineurserno;
            this.layoutControlItem367.CustomizationFormText = "layoutControlItem349";
            this.layoutControlItem367.Location = new Point(0x1db, 0x1a);
            this.layoutControlItem367.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem367.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem367.Name = "layoutControlItem349";
            this.layoutControlItem367.Size = new Size(0x156, 0x1a);
            this.layoutControlItem367.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem367.TextLocation = Locations.Top;
            this.layoutControlItem367.TextSize = new Size(0, 0);
            this.layoutControlItem367.TextVisible = false;
            this.layoutControlItem368.Control = this.dosyalblmalz;
            this.layoutControlItem368.CustomizationFormText = "layoutControlItem350";
            this.layoutControlItem368.Location = new Point(0, 0);
            this.layoutControlItem368.MaxSize = new Size(160, 0x1a);
            this.layoutControlItem368.MinSize = new Size(40, 0x1a);
            this.layoutControlItem368.Name = "layoutControlItem350";
            this.layoutControlItem368.Size = new Size(0x6b, 0x1a);
            this.layoutControlItem368.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem368.TextSize = new Size(0, 0);
            this.layoutControlItem368.TextVisible = false;
            this.layoutControlItem369.Control = this.dosyalbluret;
            this.layoutControlItem369.CustomizationFormText = "layoutControlItem351";
            this.layoutControlItem369.Location = new Point(0x6b, 0);
            this.layoutControlItem369.MaxSize = new Size(0x5d, 0x1a);
            this.layoutControlItem369.MinSize = new Size(1, 0x1a);
            this.layoutControlItem369.Name = "layoutControlItem351";
            this.layoutControlItem369.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem369.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem369.TextSize = new Size(0, 0);
            this.layoutControlItem369.TextVisible = false;
            this.layoutControlItem370.Control = this.dosyalblmakine;
            this.layoutControlItem370.CustomizationFormText = "layoutControlItem352";
            this.layoutControlItem370.Location = new Point(0, 0x1a);
            this.layoutControlItem370.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem370.MinSize = new Size(1, 0x1a);
            this.layoutControlItem370.Name = "layoutControlItem352";
            this.layoutControlItem370.Size = new Size(0x6b, 0x1a);
            this.layoutControlItem370.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem370.TextSize = new Size(0, 0);
            this.layoutControlItem370.TextVisible = false;
            this.layoutControlItem371.Control = this.dosyalblmodel;
            this.layoutControlItem371.CustomizationFormText = "layoutControlItem353";
            this.layoutControlItem371.Location = new Point(0xc7, 0);
            this.layoutControlItem371.MaxSize = new Size(0x5d, 0x1a);
            this.layoutControlItem371.MinSize = new Size(1, 0x1a);
            this.layoutControlItem371.Name = "layoutControlItem353";
            this.layoutControlItem371.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem371.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem371.TextSize = new Size(0, 0);
            this.layoutControlItem371.TextVisible = false;
            this.layoutControlItem372.Control = this.dosyalblbelgeno;
            this.layoutControlItem372.CustomizationFormText = "layoutControlItem354";
            this.layoutControlItem372.Location = new Point(0x123, 0);
            this.layoutControlItem372.MaxSize = new Size(0x5d, 0x1a);
            this.layoutControlItem372.MinSize = new Size(1, 0x1a);
            this.layoutControlItem372.Name = "layoutControlItem354";
            this.layoutControlItem372.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem372.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem372.TextSize = new Size(0, 0);
            this.layoutControlItem372.TextVisible = false;
            this.layoutControlItem373.Control = this.dosyalblonaylayan;
            this.layoutControlItem373.CustomizationFormText = "layoutControlItem355";
            this.layoutControlItem373.Location = new Point(0x17f, 0);
            this.layoutControlItem373.MaxSize = new Size(0x5d, 0x1a);
            this.layoutControlItem373.MinSize = new Size(1, 0x1a);
            this.layoutControlItem373.Name = "layoutControlItem355";
            this.layoutControlItem373.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem373.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem373.TextSize = new Size(0, 0);
            this.layoutControlItem373.TextVisible = false;
            this.layoutControlItem374.Control = this.dosyalblserino;
            this.layoutControlItem374.CustomizationFormText = "layoutControlItem356";
            this.layoutControlItem374.Location = new Point(0x1db, 0);
            this.layoutControlItem374.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem374.MinSize = new Size(1, 0x1a);
            this.layoutControlItem374.Name = "layoutControlItem356";
            this.layoutControlItem374.Size = new Size(0x156, 0x1a);
            this.layoutControlItem374.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem374.TextSize = new Size(0, 0);
            this.layoutControlItem374.TextVisible = false;
            this.layoutControlItem375.Control = this.dosyalblmotor;
            this.layoutControlItem375.CustomizationFormText = "layoutControlItem357";
            this.layoutControlItem375.Location = new Point(0, 0x34);
            this.layoutControlItem375.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem375.MinSize = new Size(1, 0x1a);
            this.layoutControlItem375.Name = "layoutControlItem357";
            this.layoutControlItem375.Size = new Size(0x6b, 0x1a);
            this.layoutControlItem375.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem375.TextSize = new Size(0, 0);
            this.layoutControlItem375.TextVisible = false;
            this.layoutControlItem376.Control = this.dosyamotoruretici;
            this.layoutControlItem376.CustomizationFormText = "layoutControlItem358";
            this.layoutControlItem376.Location = new Point(0x6b, 0x34);
            this.layoutControlItem376.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem376.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem376.Name = "layoutControlItem358";
            this.layoutControlItem376.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem376.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem376.TextSize = new Size(0, 0);
            this.layoutControlItem376.TextVisible = false;
            this.layoutControlItem377.Control = this.dosyamotormodel;
            this.layoutControlItem377.CustomizationFormText = "layoutControlItem359";
            this.layoutControlItem377.Location = new Point(0xc7, 0x34);
            this.layoutControlItem377.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem377.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem377.Name = "layoutControlItem359";
            this.layoutControlItem377.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem377.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem377.TextSize = new Size(0, 0);
            this.layoutControlItem377.TextVisible = false;
            this.layoutControlItem378.Control = this.dosyamotorbelgeno;
            this.layoutControlItem378.CustomizationFormText = "layoutControlItem360";
            this.layoutControlItem378.Location = new Point(0x123, 0x34);
            this.layoutControlItem378.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem378.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem378.Name = "layoutControlItem360";
            this.layoutControlItem378.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem378.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem378.TextSize = new Size(0, 0);
            this.layoutControlItem378.TextVisible = false;
            this.layoutControlItem379.Control = this.dosyamotoronaylayan;
            this.layoutControlItem379.CustomizationFormText = "layoutControlItem361";
            this.layoutControlItem379.Location = new Point(0x17f, 0x34);
            this.layoutControlItem379.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem379.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem379.Name = "layoutControlItem361";
            this.layoutControlItem379.Size = new Size(0x5c, 0x1a);
            this.layoutControlItem379.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem379.TextSize = new Size(0, 0);
            this.layoutControlItem379.TextVisible = false;
            this.layoutControlItem380.Control = this.dosyamotorserino;
            this.layoutControlItem380.CustomizationFormText = "layoutControlItem362";
            this.layoutControlItem380.Location = new Point(0x1db, 0x34);
            this.layoutControlItem380.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem380.MinSize = new Size(0x36, 0x1a);
            this.layoutControlItem380.Name = "layoutControlItem362";
            this.layoutControlItem380.Size = new Size(0x156, 0x1a);
            this.layoutControlItem380.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem380.TextSize = new Size(0, 0);
            this.layoutControlItem380.TextVisible = false;
            this.layoutControl6.Controls.Add(this.dosyakapikilit);
            this.layoutControl6.Controls.Add(this.dosyalblsertf);
            this.layoutControl6.Controls.Add(this.dosyalblurserno);
            this.layoutControl6.Controls.Add(this.dosyaslblertfsec);
            this.layoutControl6.Controls.Add(this.dosyapanosn);
            this.layoutControl6.Controls.Add(this.dosyapanogor);
            this.layoutControl6.Controls.Add(this.dosyapano);
            this.layoutControl6.Controls.Add(this.dosyapistonvalfisn);
            this.layoutControl6.Controls.Add(this.dosyaa3ekipmansn);
            this.layoutControl6.Controls.Add(this.dosyaregulatorsn);
            this.layoutControl6.Controls.Add(this.dosyakumandakartisn);
            this.layoutControl6.Controls.Add(this.dosyakabintamponsn);
            this.layoutControl6.Controls.Add(this.dosyaagrtamponsn);
            this.layoutControl6.Controls.Add(this.dosyafrenbloksn);
            this.layoutControl6.Controls.Add(this.dosyakapikilitsn);
            this.layoutControl6.Controls.Add(this.dosyapistonvalfi);
            this.layoutControl6.Controls.Add(this.dosyaa3ekipman);
            this.layoutControl6.Controls.Add(this.dosyaregulator);
            this.layoutControl6.Controls.Add(this.dosyakumandakarti);
            this.layoutControl6.Controls.Add(this.dosyakabintampon);
            this.layoutControl6.Controls.Add(this.dosyaagrtampon);
            this.layoutControl6.Controls.Add(this.dosyafrenblok);
            this.layoutControl6.Controls.Add(this.dosyaa3ekipmangor);
            this.layoutControl6.Controls.Add(this.dosyapistonvalfigor);
            this.layoutControl6.Controls.Add(this.dosyaregulatorgor);
            this.layoutControl6.Controls.Add(this.dosyakumandakartigor);
            this.layoutControl6.Controls.Add(this.dosyakabintampongor);
            this.layoutControl6.Controls.Add(this.dosyaagrtampongor);
            this.layoutControl6.Controls.Add(this.dosyafrenblokgor);
            this.layoutControl6.Controls.Add(this.dosyakapikilitgor);
            this.layoutControl6.Dock = DockStyle.Top;
            this.layoutControl6.Location = new Point(0x138, 0);
            this.layoutControl6.Name = "layoutControl6";
            this.layoutControl6.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(0, -8, 0x566, 0x310);
            this.layoutControl6.Padding = new System.Windows.Forms.Padding(5);
            this.layoutControl6.Root = this.layoutControlGroup10;
            this.layoutControl6.Size = new Size(0x341, 0x101);
            this.layoutControl6.TabIndex = 2;
            this.layoutControl6.Text = "layoutControl6";
            this.dosyakapikilit.EnterMoveNextControl = true;
            this.dosyakapikilit.Location = new Point(0x6b, 0x18);
            this.dosyakapikilit.Name = "dosyakapikilit";
            this.dosyakapikilit.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f);
            this.dosyakapikilit.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray7 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyakapikilit.Properties.Buttons.AddRange(buttonArray7);
            this.dosyakapikilit.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyakapikilit.Properties.ShowAddNewButton = true;
            this.dosyakapikilit.Properties.View = this.gridView1;
            this.dosyakapikilit.Properties.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            this.dosyakapikilit.Size = new Size(0x187, 0x16);
            this.dosyakapikilit.StyleController = this.layoutControl6;
            this.dosyakapikilit.TabIndex = 1;
            GridColumn[] columnArray2 = new GridColumn[] { this.gridColumn64, this.gridColumn73, this.gridColumn74, this.gridColumn75, this.gridColumn76, this.gridColumn77, this.gridColumn78 };
            this.gridView1.Columns.AddRange(columnArray2);
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn64.Caption = "gridColumn64";
            this.gridColumn64.FieldName = "guid";
            this.gridColumn64.Name = "gridColumn64";
            this.gridColumn73.Caption = "gridColumn73";
            this.gridColumn73.FieldName = "uretici";
            this.gridColumn73.Name = "gridColumn73";
            this.gridColumn74.Caption = "gridColumn74";
            this.gridColumn74.FieldName = "model";
            this.gridColumn74.Name = "gridColumn74";
            this.gridColumn75.Caption = "MARKA VE MODEL";
            this.gridColumn75.FieldName = "MARKA_MODEL";
            this.gridColumn75.Name = "gridColumn75";
            this.gridColumn75.Visible = true;
            this.gridColumn75.VisibleIndex = 0;
            this.gridColumn76.Caption = "gridColumn76";
            this.gridColumn76.FieldName = "serino";
            this.gridColumn76.Name = "gridColumn76";
            this.gridColumn77.Caption = "gridColumn77";
            this.gridColumn77.FieldName = "belgeveren";
            this.gridColumn77.Name = "gridColumn77";
            this.gridColumn78.Caption = "gridColumn78";
            this.gridColumn78.FieldName = "nobo";
            this.gridColumn78.Name = "gridColumn78";
            this.dosyalblsertf.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblsertf.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblsertf.Location = new Point(0x2a1, 3);
            this.dosyalblsertf.Name = "dosyalblsertf";
            this.dosyalblsertf.Size = new Size(0x9d, 0x11);
            this.dosyalblsertf.StyleController = this.layoutControl6;
            this.dosyalblsertf.TabIndex = 0x99;
            this.dosyalblsertf.Text = "SERTİFİKA";
            this.dosyalblurserno.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblurserno.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyalblurserno.Location = new Point(0x1f6, 3);
            this.dosyalblurserno.Name = "dosyalblurserno";
            this.dosyalblurserno.Size = new Size(0xa7, 0x11);
            this.dosyalblurserno.StyleController = this.layoutControl6;
            this.dosyalblurserno.TabIndex = 0x98;
            this.dosyalblurserno.Text = "\x00dcR. SERİ NO";
            this.dosyaslblertfsec.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyaslblertfsec.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.dosyaslblertfsec.Location = new Point(3, 3);
            this.dosyaslblertfsec.Name = "dosyaslblertfsec";
            this.dosyaslblertfsec.Size = new Size(0x1ef, 0x11);
            this.dosyaslblertfsec.StyleController = this.layoutControl6;
            this.dosyaslblertfsec.TabIndex = 0x97;
            this.dosyaslblertfsec.Text = "SERTİFİKA SE\x00c7İNİZ";
            this.dosyapanosn.EnterMoveNextControl = true;
            this.dosyapanosn.Location = new Point(0x1f6, 0x9a);
            this.dosyapanosn.Name = "dosyapanosn";
            this.dosyapanosn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyapanosn.Properties.Appearance.Options.UseFont = true;
            this.dosyapanosn.Size = new Size(0xa7, 0x16);
            this.dosyapanosn.StyleController = this.layoutControl6;
            this.dosyapanosn.TabIndex = 12;
            this.dosyapanogor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyapanogor.Appearance.Options.UseFont = true;
            this.dosyapanogor.Location = new Point(0x2a4, 0x9a);
            this.dosyapanogor.Name = "dosyapanogor";
            this.dosyapanogor.Size = new Size(0x97, 0x16);
            this.dosyapanogor.StyleController = this.layoutControl6;
            this.dosyapanogor.TabIndex = 0x3e7;
            this.dosyapanogor.Text = "G\x00d6R";
            this.dosyapanogor.Click += new EventHandler(this.dosyapano_click);
            this.dosyapano.EnterMoveNextControl = true;
            this.dosyapano.Location = new Point(0x6b, 0x9a);
            this.dosyapano.Name = "dosyapano";
            this.dosyapano.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyapano.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray8 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyapano.Properties.Buttons.AddRange(buttonArray8);
            this.dosyapano.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyapano.Properties.View = this.searchLookUpEdit6View;
            this.dosyapano.Size = new Size(0x187, 0x16);
            this.dosyapano.StyleController = this.layoutControl6;
            this.dosyapano.TabIndex = 11;
            this.dosyapano.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            GridColumn[] columnArray3 = new GridColumn[] { this.gridColumn31, this.gridColumn32, this.gridColumn33, this.gridColumn34, this.gridColumn35, this.gridColumn36 };
            this.searchLookUpEdit6View.Columns.AddRange(columnArray3);
            this.searchLookUpEdit6View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit6View.Name = "searchLookUpEdit6View";
            this.searchLookUpEdit6View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit6View.OptionsView.ShowGroupPanel = false;
            this.gridColumn31.Caption = "gridColumn31";
            this.gridColumn31.FieldName = "guid";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn32.Caption = "gridColumn32";
            this.gridColumn32.FieldName = "uretici";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn33.Caption = "gridColumn33";
            this.gridColumn33.FieldName = "model";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn34.Caption = "MARKA VE MODEL";
            this.gridColumn34.FieldName = "MARKA_MODEL";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 0;
            this.gridColumn35.Caption = "gridColumn35";
            this.gridColumn35.FieldName = "serino";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn36.Caption = "gridColumn36";
            this.gridColumn36.FieldName = "belgeveren";
            this.gridColumn36.Name = "gridColumn36";
            this.dosyapistonvalfisn.EnterMoveNextControl = true;
            this.dosyapistonvalfisn.Location = new Point(0x1f6, 0xe8);
            this.dosyapistonvalfisn.Name = "dosyapistonvalfisn";
            this.dosyapistonvalfisn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyapistonvalfisn.Properties.Appearance.Options.UseFont = true;
            this.dosyapistonvalfisn.Size = new Size(0xa7, 0x16);
            this.dosyapistonvalfisn.StyleController = this.layoutControl6;
            this.dosyapistonvalfisn.TabIndex = 0x12;
            this.dosyaa3ekipmansn.EnterMoveNextControl = true;
            this.dosyaa3ekipmansn.Location = new Point(0x1f6, 0xce);
            this.dosyaa3ekipmansn.Name = "dosyaa3ekipmansn";
            this.dosyaa3ekipmansn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyaa3ekipmansn.Properties.Appearance.Options.UseFont = true;
            this.dosyaa3ekipmansn.Size = new Size(0xa7, 0x16);
            this.dosyaa3ekipmansn.StyleController = this.layoutControl6;
            this.dosyaa3ekipmansn.TabIndex = 0x10;
            this.dosyaregulatorsn.EnterMoveNextControl = true;
            this.dosyaregulatorsn.Location = new Point(0x1f6, 180);
            this.dosyaregulatorsn.Name = "dosyaregulatorsn";
            this.dosyaregulatorsn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyaregulatorsn.Properties.Appearance.Options.UseFont = true;
            this.dosyaregulatorsn.Size = new Size(0xa7, 0x16);
            this.dosyaregulatorsn.StyleController = this.layoutControl6;
            this.dosyaregulatorsn.TabIndex = 14;
            this.dosyakumandakartisn.EnterMoveNextControl = true;
            this.dosyakumandakartisn.Location = new Point(0x1f6, 0x80);
            this.dosyakumandakartisn.Name = "dosyakumandakartisn";
            this.dosyakumandakartisn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyakumandakartisn.Properties.Appearance.Options.UseFont = true;
            this.dosyakumandakartisn.Size = new Size(0xa7, 0x16);
            this.dosyakumandakartisn.StyleController = this.layoutControl6;
            this.dosyakumandakartisn.TabIndex = 10;
            this.dosyakabintamponsn.EnterMoveNextControl = true;
            this.dosyakabintamponsn.Location = new Point(0x1f6, 0x66);
            this.dosyakabintamponsn.Name = "dosyakabintamponsn";
            this.dosyakabintamponsn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyakabintamponsn.Properties.Appearance.Options.UseFont = true;
            this.dosyakabintamponsn.Size = new Size(0xa7, 0x16);
            this.dosyakabintamponsn.StyleController = this.layoutControl6;
            this.dosyakabintamponsn.TabIndex = 8;
            this.dosyaagrtamponsn.EnterMoveNextControl = true;
            this.dosyaagrtamponsn.Location = new Point(0x1f6, 0x4c);
            this.dosyaagrtamponsn.Name = "dosyaagrtamponsn";
            this.dosyaagrtamponsn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyaagrtamponsn.Properties.Appearance.Options.UseFont = true;
            this.dosyaagrtamponsn.Size = new Size(0xa7, 0x16);
            this.dosyaagrtamponsn.StyleController = this.layoutControl6;
            this.dosyaagrtamponsn.TabIndex = 6;
            this.dosyafrenbloksn.EnterMoveNextControl = true;
            this.dosyafrenbloksn.Location = new Point(0x1f6, 50);
            this.dosyafrenbloksn.Name = "dosyafrenbloksn";
            this.dosyafrenbloksn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyafrenbloksn.Properties.Appearance.Options.UseFont = true;
            this.dosyafrenbloksn.Size = new Size(0xa7, 0x16);
            this.dosyafrenbloksn.StyleController = this.layoutControl6;
            this.dosyafrenbloksn.TabIndex = 4;
            this.dosyakapikilitsn.EnterMoveNextControl = true;
            this.dosyakapikilitsn.Location = new Point(0x1f6, 0x18);
            this.dosyakapikilitsn.Name = "dosyakapikilitsn";
            this.dosyakapikilitsn.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyakapikilitsn.Properties.Appearance.Options.UseFont = true;
            this.dosyakapikilitsn.Size = new Size(0xa7, 0x16);
            this.dosyakapikilitsn.StyleController = this.layoutControl6;
            this.dosyakapikilitsn.TabIndex = 2;
            this.dosyapistonvalfi.EnterMoveNextControl = true;
            this.dosyapistonvalfi.Location = new Point(0x6b, 0xe8);
            this.dosyapistonvalfi.Name = "dosyapistonvalfi";
            this.dosyapistonvalfi.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyapistonvalfi.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray9 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyapistonvalfi.Properties.Buttons.AddRange(buttonArray9);
            this.dosyapistonvalfi.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyapistonvalfi.Properties.View = this.searchLookUpEdit9View;
            this.dosyapistonvalfi.Size = new Size(0x187, 0x16);
            this.dosyapistonvalfi.StyleController = this.layoutControl6;
            this.dosyapistonvalfi.TabIndex = 0x11;
            this.dosyapistonvalfi.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            GridColumn[] columnArray4 = new GridColumn[] { this.gridColumn49, this.gridColumn50, this.gridColumn51, this.gridColumn52, this.gridColumn53, this.gridColumn54 };
            this.searchLookUpEdit9View.Columns.AddRange(columnArray4);
            this.searchLookUpEdit9View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit9View.Name = "searchLookUpEdit9View";
            this.searchLookUpEdit9View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit9View.OptionsView.ShowGroupPanel = false;
            this.gridColumn49.Caption = "gridColumn49";
            this.gridColumn49.FieldName = "guid";
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn50.Caption = "gridColumn50";
            this.gridColumn50.FieldName = "uretici";
            this.gridColumn50.Name = "gridColumn50";
            this.gridColumn51.Caption = "gridColumn51";
            this.gridColumn51.FieldName = "model";
            this.gridColumn51.Name = "gridColumn51";
            this.gridColumn52.Caption = "MARKA VE MODEL";
            this.gridColumn52.FieldName = "MARKA_MODEL";
            this.gridColumn52.Name = "gridColumn52";
            this.gridColumn52.Visible = true;
            this.gridColumn52.VisibleIndex = 0;
            this.gridColumn53.Caption = "gridColumn53";
            this.gridColumn53.FieldName = "serino";
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn54.Caption = "gridColumn54";
            this.gridColumn54.FieldName = "belgeveren";
            this.gridColumn54.Name = "gridColumn54";
            this.dosyaa3ekipman.EnterMoveNextControl = true;
            this.dosyaa3ekipman.Location = new Point(0x6b, 0xce);
            this.dosyaa3ekipman.Name = "dosyaa3ekipman";
            this.dosyaa3ekipman.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyaa3ekipman.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray10 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyaa3ekipman.Properties.Buttons.AddRange(buttonArray10);
            this.dosyaa3ekipman.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyaa3ekipman.Properties.View = this.searchLookUpEdit8View;
            this.dosyaa3ekipman.Size = new Size(0x187, 0x16);
            this.dosyaa3ekipman.StyleController = this.layoutControl6;
            this.dosyaa3ekipman.TabIndex = 15;
            this.dosyaa3ekipman.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            GridColumn[] columnArray5 = new GridColumn[] { this.gridColumn43, this.gridColumn44, this.gridColumn45, this.gridColumn46, this.gridColumn47, this.gridColumn48 };
            this.searchLookUpEdit8View.Columns.AddRange(columnArray5);
            this.searchLookUpEdit8View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit8View.Name = "searchLookUpEdit8View";
            this.searchLookUpEdit8View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit8View.OptionsView.ShowGroupPanel = false;
            this.gridColumn43.Caption = "gridColumn43";
            this.gridColumn43.FieldName = "guid";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn44.Caption = "gridColumn44";
            this.gridColumn44.FieldName = "uretici";
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn45.Caption = "gridColumn45";
            this.gridColumn45.FieldName = "model";
            this.gridColumn45.Name = "gridColumn45";
            this.gridColumn46.Caption = "MARKA VE MODEL";
            this.gridColumn46.FieldName = "MARKA_MODEL";
            this.gridColumn46.Name = "gridColumn46";
            this.gridColumn46.Visible = true;
            this.gridColumn46.VisibleIndex = 0;
            this.gridColumn47.Caption = "gridColumn47";
            this.gridColumn47.FieldName = "serino";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn48.Caption = "gridColumn48";
            this.gridColumn48.FieldName = "belgeveren";
            this.gridColumn48.Name = "gridColumn48";
            this.dosyaregulator.Enabled = false;
            this.dosyaregulator.EnterMoveNextControl = true;
            this.dosyaregulator.Location = new Point(0x6b, 180);
            this.dosyaregulator.Name = "dosyaregulator";
            this.dosyaregulator.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyaregulator.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray11 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyaregulator.Properties.Buttons.AddRange(buttonArray11);
            this.dosyaregulator.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyaregulator.Properties.View = this.searchLookUpEdit7View;
            this.dosyaregulator.Size = new Size(0x187, 0x16);
            this.dosyaregulator.StyleController = this.layoutControl6;
            this.dosyaregulator.TabIndex = 13;
            this.dosyaregulator.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            this.dosyaregulator.EditValueChanged += new EventHandler(this.dosyaregulator_EditValueChanged);
            GridColumn[] columnArray6 = new GridColumn[] { this.gridColumn37, this.gridColumn38, this.gridColumn39, this.gridColumn40, this.gridColumn41, this.gridColumn42 };
            this.searchLookUpEdit7View.Columns.AddRange(columnArray6);
            this.searchLookUpEdit7View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit7View.Name = "searchLookUpEdit7View";
            this.searchLookUpEdit7View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit7View.OptionsView.ShowGroupPanel = false;
            this.gridColumn37.Caption = "gridColumn37";
            this.gridColumn37.FieldName = "guid";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn38.Caption = "gridColumn38";
            this.gridColumn38.FieldName = "uretici";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn39.Caption = "gridColumn39";
            this.gridColumn39.FieldName = "model";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn40.Caption = "MARKA VE MODEL";
            this.gridColumn40.FieldName = "MARKA_MODEL";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 0;
            this.gridColumn41.Caption = "gridColumn41";
            this.gridColumn41.FieldName = "serino";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn42.Caption = "gridColumn42";
            this.gridColumn42.FieldName = "belgeveren";
            this.gridColumn42.Name = "gridColumn42";
            this.dosyakumandakarti.EnterMoveNextControl = true;
            this.dosyakumandakarti.Location = new Point(0x6b, 0x80);
            this.dosyakumandakarti.Name = "dosyakumandakarti";
            this.dosyakumandakarti.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyakumandakarti.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray12 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyakumandakarti.Properties.Buttons.AddRange(buttonArray12);
            this.dosyakumandakarti.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyakumandakarti.Properties.View = this.searchLookUpEdit5View;
            this.dosyakumandakarti.Size = new Size(0x187, 0x16);
            this.dosyakumandakarti.StyleController = this.layoutControl6;
            this.dosyakumandakarti.TabIndex = 9;
            this.dosyakumandakarti.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            GridColumn[] columnArray7 = new GridColumn[] { this.gridColumn25, this.gridColumn26, this.gridColumn27, this.gridColumn28, this.gridColumn29, this.gridColumn30 };
            this.searchLookUpEdit5View.Columns.AddRange(columnArray7);
            this.searchLookUpEdit5View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit5View.Name = "searchLookUpEdit5View";
            this.searchLookUpEdit5View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit5View.OptionsView.ShowGroupPanel = false;
            this.gridColumn25.Caption = "gridColumn25";
            this.gridColumn25.FieldName = "guid";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn26.Caption = "gridColumn26";
            this.gridColumn26.FieldName = "uretici";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn27.Caption = "gridColumn27";
            this.gridColumn27.FieldName = "model";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn28.Caption = "MARKA VE MODEL";
            this.gridColumn28.FieldName = "MARKA_MODEL";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 0;
            this.gridColumn29.Caption = "gridColumn29";
            this.gridColumn29.FieldName = "serino";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn30.Caption = "gridColumn30";
            this.gridColumn30.FieldName = "belgeveren";
            this.gridColumn30.Name = "gridColumn30";
            this.dosyakabintampon.EnterMoveNextControl = true;
            this.dosyakabintampon.Location = new Point(0x6b, 0x66);
            this.dosyakabintampon.Name = "dosyakabintampon";
            this.dosyakabintampon.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyakabintampon.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray13 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyakabintampon.Properties.Buttons.AddRange(buttonArray13);
            this.dosyakabintampon.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyakabintampon.Properties.View = this.searchLookUpEdit4View;
            this.dosyakabintampon.Size = new Size(0x187, 0x16);
            this.dosyakabintampon.StyleController = this.layoutControl6;
            this.dosyakabintampon.TabIndex = 7;
            this.dosyakabintampon.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            GridColumn[] columnArray8 = new GridColumn[] { this.gridColumn19, this.gridColumn20, this.gridColumn21, this.gridColumn22, this.gridColumn23, this.gridColumn24 };
            this.searchLookUpEdit4View.Columns.AddRange(columnArray8);
            this.searchLookUpEdit4View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit4View.Name = "searchLookUpEdit4View";
            this.searchLookUpEdit4View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit4View.OptionsView.ShowGroupPanel = false;
            this.gridColumn19.Caption = "gridColumn19";
            this.gridColumn19.FieldName = "guid";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn20.Caption = "gridColumn20";
            this.gridColumn20.FieldName = "uretici";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn21.Caption = "gridColumn21";
            this.gridColumn21.FieldName = "model";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn22.Caption = "MARKA VE MODEL";
            this.gridColumn22.FieldName = "MARKA_MODEL";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            this.gridColumn23.Caption = "gridColumn23";
            this.gridColumn23.FieldName = "serino";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn24.Caption = "gridColumn24";
            this.gridColumn24.FieldName = "belgeveren";
            this.gridColumn24.Name = "gridColumn24";
            this.dosyaagrtampon.EnterMoveNextControl = true;
            this.dosyaagrtampon.Location = new Point(0x6b, 0x4c);
            this.dosyaagrtampon.Name = "dosyaagrtampon";
            this.dosyaagrtampon.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyaagrtampon.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray14 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyaagrtampon.Properties.Buttons.AddRange(buttonArray14);
            this.dosyaagrtampon.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyaagrtampon.Properties.View = this.searchLookUpEdit3View;
            this.dosyaagrtampon.Size = new Size(0x187, 0x16);
            this.dosyaagrtampon.StyleController = this.layoutControl6;
            this.dosyaagrtampon.TabIndex = 5;
            this.dosyaagrtampon.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            GridColumn[] columnArray9 = new GridColumn[] { this.gridColumn13, this.gridColumn14, this.gridColumn15, this.gridColumn16, this.gridColumn17, this.gridColumn18 };
            this.searchLookUpEdit3View.Columns.AddRange(columnArray9);
            this.searchLookUpEdit3View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit3View.Name = "searchLookUpEdit3View";
            this.searchLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            this.gridColumn13.Caption = "gridColumn13";
            this.gridColumn13.FieldName = "guid";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn14.Caption = "gridColumn14";
            this.gridColumn14.FieldName = "serino";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn15.Caption = "gridColumn15";
            this.gridColumn15.FieldName = "model";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn16.Caption = "MARKA VE MODEL";
            this.gridColumn16.FieldName = "MARKA_MODEL";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 0;
            this.gridColumn17.Caption = "gridColumn17";
            this.gridColumn17.FieldName = "serino";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn18.Caption = "gridColumn18";
            this.gridColumn18.FieldName = "belgeveren";
            this.gridColumn18.Name = "gridColumn18";
            this.dosyafrenblok.Enabled = false;
            this.dosyafrenblok.EnterMoveNextControl = true;
            this.dosyafrenblok.Location = new Point(0x6b, 50);
            this.dosyafrenblok.Name = "dosyafrenblok";
            this.dosyafrenblok.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.dosyafrenblok.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray15 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.dosyafrenblok.Properties.Buttons.AddRange(buttonArray15);
            this.dosyafrenblok.Properties.NullText = "SE\x00c7İNİZ";
            this.dosyafrenblok.Properties.View = this.searchLookUpEdit2View;
            this.dosyafrenblok.Size = new Size(0x187, 0x16);
            this.dosyafrenblok.StyleController = this.layoutControl6;
            this.dosyafrenblok.TabIndex = 3;
            this.dosyafrenblok.ButtonClick += new ButtonPressedEventHandler(this.sertifikaekler);
            this.dosyafrenblok.EditValueChanged += new EventHandler(this.dosyafrenblok_EditValueChanged);
            GridColumn[] columnArray10 = new GridColumn[] { this.gridColumn10, this.gridColumn11, this.gridColumn12, this.gridColumn55, this.gridColumn56, this.gridColumn57 };
            this.searchLookUpEdit2View.Columns.AddRange(columnArray10);
            this.searchLookUpEdit2View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            this.gridColumn10.Caption = "gridColumn7";
            this.gridColumn10.FieldName = "guid";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn11.Caption = "gridColumn8";
            this.gridColumn11.FieldName = "uretici";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn12.Caption = "gridColumn9";
            this.gridColumn12.FieldName = "model";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn55.Caption = "MARKA VE MODEL";
            this.gridColumn55.FieldName = "MARKA_MODEL";
            this.gridColumn55.Name = "gridColumn55";
            this.gridColumn55.Visible = true;
            this.gridColumn55.VisibleIndex = 0;
            this.gridColumn56.Caption = "gridColumn11";
            this.gridColumn56.FieldName = "serino";
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn57.Caption = "gridColumn12";
            this.gridColumn57.FieldName = "belgeveren";
            this.gridColumn57.Name = "gridColumn57";
            this.dosyaa3ekipmangor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyaa3ekipmangor.Appearance.Options.UseFont = true;
            this.dosyaa3ekipmangor.Location = new Point(0x2a4, 0xce);
            this.dosyaa3ekipmangor.Name = "dosyaa3ekipmangor";
            this.dosyaa3ekipmangor.Size = new Size(0x97, 0x16);
            this.dosyaa3ekipmangor.StyleController = this.layoutControl6;
            this.dosyaa3ekipmangor.TabIndex = 0x3e7;
            this.dosyaa3ekipmangor.Text = "G\x00d6R";
            this.dosyaa3ekipmangor.Click += new EventHandler(this.dosyaa3ekipman_click);
            this.dosyapistonvalfigor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyapistonvalfigor.Appearance.Options.UseFont = true;
            this.dosyapistonvalfigor.Location = new Point(0x2a4, 0xe8);
            this.dosyapistonvalfigor.Name = "dosyapistonvalfigor";
            this.dosyapistonvalfigor.Size = new Size(0x97, 0x16);
            this.dosyapistonvalfigor.StyleController = this.layoutControl6;
            this.dosyapistonvalfigor.TabIndex = 0x3e7;
            this.dosyapistonvalfigor.Text = "G\x00d6R";
            this.dosyapistonvalfigor.Click += new EventHandler(this.dosyapistonvalfi_click);
            this.dosyaregulatorgor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyaregulatorgor.Appearance.Options.UseFont = true;
            this.dosyaregulatorgor.Location = new Point(0x2a4, 180);
            this.dosyaregulatorgor.Name = "dosyaregulatorgor";
            this.dosyaregulatorgor.Size = new Size(0x97, 0x16);
            this.dosyaregulatorgor.StyleController = this.layoutControl6;
            this.dosyaregulatorgor.TabIndex = 0x3e7;
            this.dosyaregulatorgor.Text = "G\x00d6R";
            this.dosyaregulatorgor.Click += new EventHandler(this.dosyaregulator_click);
            this.dosyakumandakartigor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyakumandakartigor.Appearance.Options.UseFont = true;
            this.dosyakumandakartigor.Location = new Point(0x2a4, 0x80);
            this.dosyakumandakartigor.Name = "dosyakumandakartigor";
            this.dosyakumandakartigor.Size = new Size(0x97, 0x16);
            this.dosyakumandakartigor.StyleController = this.layoutControl6;
            this.dosyakumandakartigor.TabIndex = 0x3e7;
            this.dosyakumandakartigor.Text = "G\x00d6R";
            this.dosyakumandakartigor.Click += new EventHandler(this.dosyakumandakarti_click);
            this.dosyakabintampongor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyakabintampongor.Appearance.Options.UseFont = true;
            this.dosyakabintampongor.Location = new Point(0x2a4, 0x66);
            this.dosyakabintampongor.Name = "dosyakabintampongor";
            this.dosyakabintampongor.Size = new Size(0x97, 0x16);
            this.dosyakabintampongor.StyleController = this.layoutControl6;
            this.dosyakabintampongor.TabIndex = 0x3e7;
            this.dosyakabintampongor.Text = "G\x00d6R";
            this.dosyakabintampongor.Click += new EventHandler(this.dosyakabintampon_click);
            this.dosyaagrtampongor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyaagrtampongor.Appearance.Options.UseFont = true;
            this.dosyaagrtampongor.Location = new Point(0x2a4, 0x4c);
            this.dosyaagrtampongor.Name = "dosyaagrtampongor";
            this.dosyaagrtampongor.Size = new Size(0x97, 0x16);
            this.dosyaagrtampongor.StyleController = this.layoutControl6;
            this.dosyaagrtampongor.TabIndex = 0x3e7;
            this.dosyaagrtampongor.Text = "G\x00d6R";
            this.dosyaagrtampongor.Click += new EventHandler(this.dosyaagrtampon_click);
            this.dosyafrenblokgor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyafrenblokgor.Appearance.Options.UseFont = true;
            this.dosyafrenblokgor.Location = new Point(0x2a4, 50);
            this.dosyafrenblokgor.Name = "dosyafrenblokgor";
            this.dosyafrenblokgor.Size = new Size(0x97, 0x16);
            this.dosyafrenblokgor.StyleController = this.layoutControl6;
            this.dosyafrenblokgor.TabIndex = 0x3e7;
            this.dosyafrenblokgor.Text = "G\x00d6R";
            this.dosyafrenblokgor.Click += new EventHandler(this.dosyafrenblok_click);
            this.dosyakapikilitgor.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyakapikilitgor.Appearance.Options.UseFont = true;
            this.dosyakapikilitgor.Location = new Point(0x2a4, 0x18);
            this.dosyakapikilitgor.Name = "dosyakapikilitgor";
            this.dosyakapikilitgor.Size = new Size(0x97, 0x16);
            this.dosyakapikilitgor.StyleController = this.layoutControl6;
            this.dosyakapikilitgor.TabIndex = 0x3e7;
            this.dosyakapikilitgor.Text = "G\x00d6R";
            this.dosyakapikilitgor.Click += new EventHandler(this.dosyakapikilitgor_Click);
            this.layoutControlGroup10.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup10.EnableIndentsWithoutBorders = DefaultBoolean.True;
            BaseLayoutItem[] itemArray10 = new BaseLayoutItem[] { 
                this.layoutControlItem103, this.layoutControlItem104, this.layoutControlItem105, this.layoutControlItem106, this.layoutControlItem107, this.layoutControlItem108, this.layoutControlItem109, this.layoutControlItem110, this.dosyafrenbloklbl, this.dosyaagrtamponlbl, this.dosyakabintamponlbl, this.dosyakumandakartilbl, this.dosyaregulatorlbl, this.dosyaa3ekipmanlbl, this.dosyapistonvalfilbl, this.layoutControlItem127,
                this.layoutControlItem128, this.layoutControlItem129, this.layoutControlItem130, this.layoutControlItem131, this.layoutControlItem132, this.layoutControlItem133, this.layoutControlItem134, this.dosyapanolbl, this.layoutControlItem138, this.layoutControlItem139, this.layoutControlItem140, this.layoutControlItem141, this.layoutControlItem142, this.dosyakapikilitlbl
            };
            this.layoutControlGroup10.Items.AddRange(itemArray10);
            this.layoutControlGroup10.Location = new Point(0, 0);
            this.layoutControlGroup10.Name = "layoutControlGroup1";
            this.layoutControlGroup10.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup10.Size = new Size(0x341, 0x101);
            this.layoutControlGroup10.TextVisible = false;
            this.layoutControlItem103.Control = this.dosyakapikilitgor;
            this.layoutControlItem103.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem103.Location = new Point(670, 0x15);
            this.layoutControlItem103.Name = "layoutControlItem10";
            this.layoutControlItem103.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem103.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem103.TextSize = new Size(0, 0);
            this.layoutControlItem103.TextVisible = false;
            this.layoutControlItem104.Control = this.dosyafrenblokgor;
            this.layoutControlItem104.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem104.Location = new Point(670, 0x2f);
            this.layoutControlItem104.Name = "layoutControlItem11";
            this.layoutControlItem104.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem104.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem104.TextSize = new Size(0, 0);
            this.layoutControlItem104.TextVisible = false;
            this.layoutControlItem105.Control = this.dosyaagrtampongor;
            this.layoutControlItem105.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem105.Location = new Point(670, 0x49);
            this.layoutControlItem105.Name = "layoutControlItem12";
            this.layoutControlItem105.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem105.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem105.TextSize = new Size(0, 0);
            this.layoutControlItem105.TextVisible = false;
            this.layoutControlItem106.Control = this.dosyakabintampongor;
            this.layoutControlItem106.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem106.Location = new Point(670, 0x63);
            this.layoutControlItem106.Name = "layoutControlItem13";
            this.layoutControlItem106.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem106.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem106.TextSize = new Size(0, 0);
            this.layoutControlItem106.TextVisible = false;
            this.layoutControlItem107.Control = this.dosyakumandakartigor;
            this.layoutControlItem107.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem107.Location = new Point(670, 0x7d);
            this.layoutControlItem107.Name = "layoutControlItem14";
            this.layoutControlItem107.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem107.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem107.TextSize = new Size(0, 0);
            this.layoutControlItem107.TextVisible = false;
            this.layoutControlItem108.Control = this.dosyaregulatorgor;
            this.layoutControlItem108.CustomizationFormText = "layoutControlItem16";
            this.layoutControlItem108.Location = new Point(670, 0xb1);
            this.layoutControlItem108.Name = "layoutControlItem16";
            this.layoutControlItem108.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem108.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem108.TextSize = new Size(0, 0);
            this.layoutControlItem108.TextVisible = false;
            this.layoutControlItem109.Control = this.dosyapistonvalfigor;
            this.layoutControlItem109.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem109.Location = new Point(670, 0xe5);
            this.layoutControlItem109.Name = "layoutControlItem17";
            this.layoutControlItem109.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem109.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem109.TextSize = new Size(0, 0);
            this.layoutControlItem109.TextVisible = false;
            this.layoutControlItem110.Control = this.dosyaa3ekipmangor;
            this.layoutControlItem110.CustomizationFormText = "layoutControlItem38";
            this.layoutControlItem110.Location = new Point(670, 0xcb);
            this.layoutControlItem110.Name = "layoutControlItem38";
            this.layoutControlItem110.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem110.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem110.TextSize = new Size(0, 0);
            this.layoutControlItem110.TextVisible = false;
            this.dosyafrenbloklbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyafrenbloklbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyafrenbloklbl.Control = this.dosyafrenblok;
            this.dosyafrenbloklbl.CustomizationFormText = "FREN BLOĞU";
            this.dosyafrenbloklbl.Location = new Point(0, 0x2f);
            this.dosyafrenbloklbl.Name = "dosyafrenbloklbl";
            this.dosyafrenbloklbl.Size = new Size(0x1f3, 0x1a);
            this.dosyafrenbloklbl.Text = "Fren Bloğu : ";
            this.dosyafrenbloklbl.TextSize = new Size(0x65, 13);
            this.dosyaagrtamponlbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyaagrtamponlbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyaagrtamponlbl.Control = this.dosyaagrtampon;
            this.dosyaagrtamponlbl.CustomizationFormText = "AĞIRLIK TAMPONU";
            this.dosyaagrtamponlbl.Location = new Point(0, 0x49);
            this.dosyaagrtamponlbl.Name = "dosyaagrtamponlbl";
            this.dosyaagrtamponlbl.Size = new Size(0x1f3, 0x1a);
            this.dosyaagrtamponlbl.Text = "Ağırlık Tamponu : ";
            this.dosyaagrtamponlbl.TextSize = new Size(0x65, 13);
            this.dosyakabintamponlbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyakabintamponlbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyakabintamponlbl.Control = this.dosyakabintampon;
            this.dosyakabintamponlbl.CustomizationFormText = "KABİN TAMPONU";
            this.dosyakabintamponlbl.Location = new Point(0, 0x63);
            this.dosyakabintamponlbl.Name = "dosyakabintamponlbl";
            this.dosyakabintamponlbl.Size = new Size(0x1f3, 0x1a);
            this.dosyakabintamponlbl.Text = "Kabin Tamponu : ";
            this.dosyakabintamponlbl.TextSize = new Size(0x65, 13);
            this.dosyakumandakartilbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyakumandakartilbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyakumandakartilbl.Control = this.dosyakumandakarti;
            this.dosyakumandakartilbl.CustomizationFormText = "KUMANDA KARTI";
            this.dosyakumandakartilbl.Location = new Point(0, 0x7d);
            this.dosyakumandakartilbl.Name = "dosyakumandakartilbl";
            this.dosyakumandakartilbl.Size = new Size(0x1f3, 0x1a);
            this.dosyakumandakartilbl.Text = "Kumanda Kartı : ";
            this.dosyakumandakartilbl.TextSize = new Size(0x65, 13);
            this.dosyaregulatorlbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyaregulatorlbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyaregulatorlbl.Control = this.dosyaregulator;
            this.dosyaregulatorlbl.CustomizationFormText = "REG\x00dcLAT\x00d6R";
            this.dosyaregulatorlbl.Location = new Point(0, 0xb1);
            this.dosyaregulatorlbl.Name = "dosyaregulatorlbl";
            this.dosyaregulatorlbl.Size = new Size(0x1f3, 0x1a);
            this.dosyaregulatorlbl.Text = "Reg\x00fclat\x00f6r : ";
            this.dosyaregulatorlbl.TextSize = new Size(0x65, 13);
            this.dosyaa3ekipmanlbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyaa3ekipmanlbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyaa3ekipmanlbl.Control = this.dosyaa3ekipman;
            this.dosyaa3ekipmanlbl.CustomizationFormText = "A3 EKİPMANI";
            this.dosyaa3ekipmanlbl.Location = new Point(0, 0xcb);
            this.dosyaa3ekipmanlbl.Name = "dosyaa3ekipmanlbl";
            this.dosyaa3ekipmanlbl.Size = new Size(0x1f3, 0x1a);
            this.dosyaa3ekipmanlbl.Text = "A3 Ekipmanı : ";
            this.dosyaa3ekipmanlbl.TextSize = new Size(0x65, 13);
            this.dosyapistonvalfilbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyapistonvalfilbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyapistonvalfilbl.Control = this.dosyapistonvalfi;
            this.dosyapistonvalfilbl.CustomizationFormText = "PİSTON VALFİ";
            this.dosyapistonvalfilbl.Location = new Point(0, 0xe5);
            this.dosyapistonvalfilbl.Name = "dosyapistonvalfilbl";
            this.dosyapistonvalfilbl.Size = new Size(0x1f3, 0x1a);
            this.dosyapistonvalfilbl.Text = "Piston Valfi : ";
            this.dosyapistonvalfilbl.TextSize = new Size(0x65, 13);
            this.layoutControlItem127.Control = this.dosyakapikilitsn;
            this.layoutControlItem127.CustomizationFormText = "layoutControlItem52";
            this.layoutControlItem127.Location = new Point(0x1f3, 0x15);
            this.layoutControlItem127.Name = "layoutControlItem52";
            this.layoutControlItem127.Size = new Size(0xab, 0x1a);
            this.layoutControlItem127.TextSize = new Size(0, 0);
            this.layoutControlItem127.TextVisible = false;
            this.layoutControlItem128.Control = this.dosyafrenbloksn;
            this.layoutControlItem128.CustomizationFormText = "layoutControlItem60";
            this.layoutControlItem128.Location = new Point(0x1f3, 0x2f);
            this.layoutControlItem128.Name = "layoutControlItem60";
            this.layoutControlItem128.Size = new Size(0xab, 0x1a);
            this.layoutControlItem128.TextSize = new Size(0, 0);
            this.layoutControlItem128.TextVisible = false;
            this.layoutControlItem129.Control = this.dosyaagrtamponsn;
            this.layoutControlItem129.CustomizationFormText = "layoutControlItem71";
            this.layoutControlItem129.Location = new Point(0x1f3, 0x49);
            this.layoutControlItem129.Name = "layoutControlItem71";
            this.layoutControlItem129.Size = new Size(0xab, 0x1a);
            this.layoutControlItem129.TextSize = new Size(0, 0);
            this.layoutControlItem129.TextVisible = false;
            this.layoutControlItem130.Control = this.dosyakabintamponsn;
            this.layoutControlItem130.CustomizationFormText = "layoutControlItem78";
            this.layoutControlItem130.Location = new Point(0x1f3, 0x63);
            this.layoutControlItem130.Name = "layoutControlItem78";
            this.layoutControlItem130.Size = new Size(0xab, 0x1a);
            this.layoutControlItem130.TextSize = new Size(0, 0);
            this.layoutControlItem130.TextVisible = false;
            this.layoutControlItem131.Control = this.dosyakumandakartisn;
            this.layoutControlItem131.CustomizationFormText = "layoutControlItem84";
            this.layoutControlItem131.Location = new Point(0x1f3, 0x7d);
            this.layoutControlItem131.Name = "layoutControlItem84";
            this.layoutControlItem131.Size = new Size(0xab, 0x1a);
            this.layoutControlItem131.TextSize = new Size(0, 0);
            this.layoutControlItem131.TextVisible = false;
            this.layoutControlItem132.Control = this.dosyaregulatorsn;
            this.layoutControlItem132.CustomizationFormText = "layoutControlItem85";
            this.layoutControlItem132.Location = new Point(0x1f3, 0xb1);
            this.layoutControlItem132.Name = "layoutControlItem85";
            this.layoutControlItem132.Size = new Size(0xab, 0x1a);
            this.layoutControlItem132.TextSize = new Size(0, 0);
            this.layoutControlItem132.TextVisible = false;
            this.layoutControlItem133.Control = this.dosyaa3ekipmansn;
            this.layoutControlItem133.CustomizationFormText = "layoutControlItem86";
            this.layoutControlItem133.Location = new Point(0x1f3, 0xcb);
            this.layoutControlItem133.Name = "layoutControlItem86";
            this.layoutControlItem133.Size = new Size(0xab, 0x1a);
            this.layoutControlItem133.TextSize = new Size(0, 0);
            this.layoutControlItem133.TextVisible = false;
            this.layoutControlItem134.Control = this.dosyapistonvalfisn;
            this.layoutControlItem134.CustomizationFormText = "layoutControlItem87";
            this.layoutControlItem134.Location = new Point(0x1f3, 0xe5);
            this.layoutControlItem134.Name = "layoutControlItem87";
            this.layoutControlItem134.Size = new Size(0xab, 0x1a);
            this.layoutControlItem134.TextSize = new Size(0, 0);
            this.layoutControlItem134.TextVisible = false;
            this.dosyapanolbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyapanolbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyapanolbl.Control = this.dosyapano;
            this.dosyapanolbl.CustomizationFormText = "PANO";
            this.dosyapanolbl.Location = new Point(0, 0x97);
            this.dosyapanolbl.Name = "dosyapanolbl";
            this.dosyapanolbl.Size = new Size(0x1f3, 0x1a);
            this.dosyapanolbl.Text = "Pano : ";
            this.dosyapanolbl.TextSize = new Size(0x65, 13);
            this.layoutControlItem138.Control = this.dosyapanogor;
            this.layoutControlItem138.CustomizationFormText = "layoutControlItem91";
            this.layoutControlItem138.Location = new Point(670, 0x97);
            this.layoutControlItem138.Name = "layoutControlItem91";
            this.layoutControlItem138.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
            this.layoutControlItem138.Size = new Size(0xa1, 0x1a);
            this.layoutControlItem138.TextSize = new Size(0, 0);
            this.layoutControlItem138.TextVisible = false;
            this.layoutControlItem139.Control = this.dosyapanosn;
            this.layoutControlItem139.CustomizationFormText = "layoutControlItem92";
            this.layoutControlItem139.Location = new Point(0x1f3, 0x97);
            this.layoutControlItem139.Name = "layoutControlItem92";
            this.layoutControlItem139.Size = new Size(0xab, 0x1a);
            this.layoutControlItem139.TextSize = new Size(0, 0);
            this.layoutControlItem139.TextVisible = false;
            this.layoutControlItem140.Control = this.dosyaslblertfsec;
            this.layoutControlItem140.CustomizationFormText = "layoutControlItem93";
            this.layoutControlItem140.Location = new Point(0, 0);
            this.layoutControlItem140.MinSize = new Size(1, 0x12);
            this.layoutControlItem140.Name = "layoutControlItem93";
            this.layoutControlItem140.Size = new Size(0x1f3, 0x15);
            this.layoutControlItem140.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem140.TextAlignMode = TextAlignModeItem.AutoSize;
            this.layoutControlItem140.TextSize = new Size(0, 0);
            this.layoutControlItem140.TextToControlDistance = 0;
            this.layoutControlItem140.TextVisible = false;
            this.layoutControlItem141.Control = this.dosyalblurserno;
            this.layoutControlItem141.CustomizationFormText = "layoutControlItem94";
            this.layoutControlItem141.Location = new Point(0x1f3, 0);
            this.layoutControlItem141.MinSize = new Size(1, 1);
            this.layoutControlItem141.Name = "layoutControlItem94";
            this.layoutControlItem141.Size = new Size(0xab, 0x15);
            this.layoutControlItem141.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem141.TextAlignMode = TextAlignModeItem.AutoSize;
            this.layoutControlItem141.TextSize = new Size(0, 0);
            this.layoutControlItem141.TextToControlDistance = 0;
            this.layoutControlItem141.TextVisible = false;
            this.layoutControlItem142.Control = this.dosyalblsertf;
            this.layoutControlItem142.CustomizationFormText = "layoutControlItem95";
            this.layoutControlItem142.Location = new Point(670, 0);
            this.layoutControlItem142.MinSize = new Size(1, 1);
            this.layoutControlItem142.Name = "layoutControlItem95";
            this.layoutControlItem142.Size = new Size(0xa1, 0x15);
            this.layoutControlItem142.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem142.TextAlignMode = TextAlignModeItem.AutoSize;
            this.layoutControlItem142.TextSize = new Size(0, 0);
            this.layoutControlItem142.TextToControlDistance = 0;
            this.layoutControlItem142.TextVisible = false;
            this.dosyakapikilitlbl.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyakapikilitlbl.AppearanceItemCaption.Options.UseFont = true;
            this.dosyakapikilitlbl.Control = this.dosyakapikilit;
            this.dosyakapikilitlbl.CustomizationFormText = "KAPI KİLİDİ";
            this.dosyakapikilitlbl.Location = new Point(0, 0x15);
            this.dosyakapikilitlbl.Name = "dosyakapikilitlbl";
            this.dosyakapikilitlbl.Size = new Size(0x1f3, 0x1a);
            this.dosyakapikilitlbl.Text = "Kapı Kilidi : ";
            this.dosyakapikilitlbl.TextSize = new Size(0x65, 13);
            this.layoutControl5.Controls.Add(this.dosyaadres);
            this.layoutControl5.Controls.Add(this.dosyamutaahhitvd);
            this.layoutControl5.Controls.Add(this.dosyamutaahhitvn);
            this.layoutControl5.Controls.Add(this.dosyamutaahhittc);
            this.layoutControl5.Controls.Add(this.dosyamutaahhit);
            this.layoutControl5.Controls.Add(this.dosyabinasahipvd);
            this.layoutControl5.Controls.Add(this.dosyabinasahipvn);
            this.layoutControl5.Controls.Add(this.dosyabinasahiptc);
            this.layoutControl5.Controls.Add(this.dosyabinasahip);
            this.layoutControl5.Controls.Add(this.dosyaservistar);
            this.layoutControl5.Controls.Add(this.dosyaasansorno);
            this.layoutControl5.Controls.Add(this.dosyasinif);
            this.layoutControl5.Controls.Add(this.dosyaparsel);
            this.layoutControl5.Controls.Add(this.dosyaada);
            this.layoutControl5.Controls.Add(this.dosyapafta);
            this.layoutControl5.Controls.Add(this.dosyabelediye);
            this.layoutControl5.Controls.Add(this.dosyailce);
            this.layoutControl5.Controls.Add(this.dosyail);
            this.layoutControl5.Controls.Add(this.dosyablok);
            this.layoutControl5.Controls.Add(this.dosyano);
            this.layoutControl5.Controls.Add(this.dosyabulvar);
            this.layoutControl5.Controls.Add(this.dosyacadde);
            this.layoutControl5.Controls.Add(this.dosyasokak);
            this.layoutControl5.Controls.Add(this.dosyamahalle);
            this.layoutControl5.Controls.Add(this.dosyaasansorsahib);
            this.layoutControl5.Controls.Add(this.dosyabelgemodul);
            this.layoutControl5.Dock = DockStyle.Left;
            this.layoutControl5.Location = new Point(0, 0);
            this.layoutControl5.Name = "layoutControl5";
            this.layoutControl5.Root = this.layoutControlGroup9;
            this.layoutControl5.Size = new Size(0x138, 0x331);
            this.layoutControl5.TabIndex = 1;
            this.layoutControl5.Text = "layoutControl5";
            this.dosyaadres.Location = new Point(0x66, 0xf7);
            this.dosyaadres.Name = "dosyaadres";
            this.dosyaadres.Size = new Size(0xcb, 0xcb);
            this.dosyaadres.TabIndex = 30;
            this.dosyaadres.Text = "";
            this.dosyaadres.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyamutaahhitvd.EnterMoveNextControl = true;
            this.dosyamutaahhitvd.Location = new Point(0x66, 790);
            this.dosyamutaahhitvd.Name = "dosyamutaahhitvd";
            this.dosyamutaahhitvd.Size = new Size(0xcb, 20);
            this.dosyamutaahhitvd.StyleController = this.layoutControl5;
            this.dosyamutaahhitvd.TabIndex = 0x1d;
            this.dosyamutaahhitvd.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyamutaahhitvn.EnterMoveNextControl = true;
            this.dosyamutaahhitvn.Location = new Point(0x66, 0x2fe);
            this.dosyamutaahhitvn.Name = "dosyamutaahhitvn";
            this.dosyamutaahhitvn.Size = new Size(0xcb, 20);
            this.dosyamutaahhitvn.StyleController = this.layoutControl5;
            this.dosyamutaahhitvn.TabIndex = 0x1c;
            this.dosyamutaahhitvn.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyamutaahhittc.EnterMoveNextControl = true;
            this.dosyamutaahhittc.Location = new Point(0x66, 0x2e6);
            this.dosyamutaahhittc.Name = "dosyamutaahhittc";
            this.dosyamutaahhittc.Size = new Size(0xcb, 20);
            this.dosyamutaahhittc.StyleController = this.layoutControl5;
            this.dosyamutaahhittc.TabIndex = 0x1b;
            this.dosyamutaahhittc.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyamutaahhit.EnterMoveNextControl = true;
            this.dosyamutaahhit.Location = new Point(0x66, 0x2ce);
            this.dosyamutaahhit.Name = "dosyamutaahhit";
            this.dosyamutaahhit.Size = new Size(0xcb, 20);
            this.dosyamutaahhit.StyleController = this.layoutControl5;
            this.dosyamutaahhit.TabIndex = 0x1a;
            this.dosyamutaahhit.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyabinasahipvd.EnterMoveNextControl = true;
            this.dosyabinasahipvd.Location = new Point(0x66, 0x2b6);
            this.dosyabinasahipvd.Name = "dosyabinasahipvd";
            this.dosyabinasahipvd.Size = new Size(0xcb, 20);
            this.dosyabinasahipvd.StyleController = this.layoutControl5;
            this.dosyabinasahipvd.TabIndex = 0x19;
            this.dosyabinasahipvd.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyabinasahipvn.EnterMoveNextControl = true;
            this.dosyabinasahipvn.Location = new Point(0x66, 670);
            this.dosyabinasahipvn.Name = "dosyabinasahipvn";
            this.dosyabinasahipvn.Size = new Size(0xcb, 20);
            this.dosyabinasahipvn.StyleController = this.layoutControl5;
            this.dosyabinasahipvn.TabIndex = 0x18;
            this.dosyabinasahipvn.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyabinasahiptc.EnterMoveNextControl = true;
            this.dosyabinasahiptc.Location = new Point(0x66, 0x286);
            this.dosyabinasahiptc.Name = "dosyabinasahiptc";
            this.dosyabinasahiptc.Size = new Size(0xcb, 20);
            this.dosyabinasahiptc.StyleController = this.layoutControl5;
            this.dosyabinasahiptc.TabIndex = 0x17;
            this.dosyabinasahiptc.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyabinasahip.EnterMoveNextControl = true;
            this.dosyabinasahip.Location = new Point(0x66, 0x26e);
            this.dosyabinasahip.Name = "dosyabinasahip";
            this.dosyabinasahip.Size = new Size(0xcb, 20);
            this.dosyabinasahip.StyleController = this.layoutControl5;
            this.dosyabinasahip.TabIndex = 0x16;
            this.dosyabinasahip.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyaservistar.EnterMoveNextControl = true;
            this.dosyaservistar.Location = new Point(0x66, 0x256);
            this.dosyaservistar.Name = "dosyaservistar";
            this.dosyaservistar.Size = new Size(0xcb, 20);
            this.dosyaservistar.StyleController = this.layoutControl5;
            this.dosyaservistar.TabIndex = 0x15;
            this.dosyaservistar.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyaasansorno.EnterMoveNextControl = true;
            this.dosyaasansorno.Location = new Point(0x66, 0x23e);
            this.dosyaasansorno.Name = "dosyaasansorno";
            this.dosyaasansorno.Size = new Size(0xcb, 20);
            this.dosyaasansorno.StyleController = this.layoutControl5;
            this.dosyaasansorno.TabIndex = 20;
            this.dosyasinif.EnterMoveNextControl = true;
            this.dosyasinif.Location = new Point(0x66, 550);
            this.dosyasinif.Name = "dosyasinif";
            this.dosyasinif.Size = new Size(0xcb, 20);
            this.dosyasinif.StyleController = this.layoutControl5;
            this.dosyasinif.TabIndex = 0x13;
            this.dosyasinif.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyaparsel.EnterMoveNextControl = true;
            this.dosyaparsel.Location = new Point(0x66, 0x20e);
            this.dosyaparsel.Name = "dosyaparsel";
            this.dosyaparsel.Size = new Size(0xcb, 20);
            this.dosyaparsel.StyleController = this.layoutControl5;
            this.dosyaparsel.TabIndex = 0x12;
            this.dosyaada.EnterMoveNextControl = true;
            this.dosyaada.Location = new Point(0x66, 0x1f6);
            this.dosyaada.Name = "dosyaada";
            this.dosyaada.Size = new Size(0xcb, 20);
            this.dosyaada.StyleController = this.layoutControl5;
            this.dosyaada.TabIndex = 0x11;
            this.dosyapafta.EnterMoveNextControl = true;
            this.dosyapafta.Location = new Point(0x66, 0x1de);
            this.dosyapafta.Name = "dosyapafta";
            this.dosyapafta.Size = new Size(0xcb, 20);
            this.dosyapafta.StyleController = this.layoutControl5;
            this.dosyapafta.TabIndex = 0x10;
            this.dosyabelediye.EnterMoveNextControl = true;
            this.dosyabelediye.Location = new Point(0x66, 0x1c6);
            this.dosyabelediye.Name = "dosyabelediye";
            this.dosyabelediye.Size = new Size(0xcb, 20);
            this.dosyabelediye.StyleController = this.layoutControl5;
            this.dosyabelediye.TabIndex = 15;
            this.dosyabelediye.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyailce.EnterMoveNextControl = true;
            this.dosyailce.Location = new Point(0x66, 0xdf);
            this.dosyailce.Name = "dosyailce";
            this.dosyailce.Size = new Size(0xcb, 20);
            this.dosyailce.StyleController = this.layoutControl5;
            this.dosyailce.TabIndex = 13;
            this.dosyailce.TextChanged += new EventHandler(this.adresiolustur);
            this.dosyailce.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyail.EnterMoveNextControl = true;
            this.dosyail.Location = new Point(0x66, 0xc7);
            this.dosyail.Name = "dosyail";
            this.dosyail.Size = new Size(0xcb, 20);
            this.dosyail.StyleController = this.layoutControl5;
            this.dosyail.TabIndex = 12;
            this.dosyail.TextChanged += new EventHandler(this.adresiolustur);
            this.dosyail.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyablok.EnterMoveNextControl = true;
            this.dosyablok.Location = new Point(0x66, 0xaf);
            this.dosyablok.Name = "dosyablok";
            this.dosyablok.Size = new Size(0xcb, 20);
            this.dosyablok.StyleController = this.layoutControl5;
            this.dosyablok.TabIndex = 11;
            this.dosyablok.TextChanged += new EventHandler(this.adresiolustur);
            this.dosyablok.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyano.EnterMoveNextControl = true;
            this.dosyano.Location = new Point(0x66, 0x97);
            this.dosyano.Name = "dosyano";
            this.dosyano.Size = new Size(0xcb, 20);
            this.dosyano.StyleController = this.layoutControl5;
            this.dosyano.TabIndex = 10;
            this.dosyano.TextChanged += new EventHandler(this.adresiolustur);
            this.dosyano.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyabulvar.EnterMoveNextControl = true;
            this.dosyabulvar.Location = new Point(0x66, 0x7f);
            this.dosyabulvar.Name = "dosyabulvar";
            this.dosyabulvar.Size = new Size(0xcb, 20);
            this.dosyabulvar.StyleController = this.layoutControl5;
            this.dosyabulvar.TabIndex = 9;
            this.dosyabulvar.TextChanged += new EventHandler(this.adresiolustur);
            this.dosyabulvar.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyacadde.EnterMoveNextControl = true;
            this.dosyacadde.Location = new Point(0x66, 0x67);
            this.dosyacadde.Name = "dosyacadde";
            this.dosyacadde.Size = new Size(0xcb, 20);
            this.dosyacadde.StyleController = this.layoutControl5;
            this.dosyacadde.TabIndex = 8;
            this.dosyacadde.TextChanged += new EventHandler(this.adresiolustur);
            this.dosyacadde.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyasokak.EnterMoveNextControl = true;
            this.dosyasokak.Location = new Point(0x66, 0x4f);
            this.dosyasokak.Name = "dosyasokak";
            this.dosyasokak.Size = new Size(0xcb, 20);
            this.dosyasokak.StyleController = this.layoutControl5;
            this.dosyasokak.TabIndex = 7;
            this.dosyasokak.TextChanged += new EventHandler(this.adresiolustur);
            this.dosyasokak.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyamahalle.EnterMoveNextControl = true;
            this.dosyamahalle.Location = new Point(0x66, 0x37);
            this.dosyamahalle.Name = "dosyamahalle";
            this.dosyamahalle.Size = new Size(0xcb, 20);
            this.dosyamahalle.StyleController = this.layoutControl5;
            this.dosyamahalle.TabIndex = 6;
            this.dosyamahalle.TextChanged += new EventHandler(this.adresiolustur);
            this.dosyamahalle.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyaasansorsahib.EnterMoveNextControl = true;
            this.dosyaasansorsahib.Location = new Point(0x66, 0x1f);
            this.dosyaasansorsahib.Name = "dosyaasansorsahib";
            this.dosyaasansorsahib.Size = new Size(0xcb, 20);
            this.dosyaasansorsahib.StyleController = this.layoutControl5;
            this.dosyaasansorsahib.TabIndex = 2;
            this.dosyaasansorsahib.KeyPress += new KeyPressEventHandler(this.buyutur);
            this.dosyabelgemodul.EnterMoveNextControl = true;
            this.dosyabelgemodul.Location = new Point(0x66, 7);
            this.dosyabelgemodul.Name = "dosyabelgemodul";
            EditorButton[] buttonArray16 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.dosyabelgemodul.Properties.Buttons.AddRange(buttonArray16);
            object[] objArray1 = new object[] { "SE\x00c7İNİZ...", "95 / 16 / AT Ek ( MOD\x00dcL B – EK V (B BENDİ) + MOD\x00dcL E – EK XII )", "95 / 16 / AT Ek ( MOD\x00dcL H ANNEX XIII )", "95 / 16 / AT Ek ( X Mod\x00fcl G )" };
            this.dosyabelgemodul.Properties.Items.AddRange(objArray1);
            this.dosyabelgemodul.Size = new Size(0xcb, 20);
            this.dosyabelgemodul.StyleController = this.layoutControl5;
            this.dosyabelgemodul.TabIndex = 1;
            this.layoutControlGroup9.CustomizationFormText = "layoutControlGroup9";
            this.layoutControlGroup9.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup9.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray11 = new BaseLayoutItem[] { 
                this.dosyalblmodul, this.dosyalblno, this.dosyalblil, this.dosyalblilce, this.dosyalblbelediye, this.dosyalblpafta, this.dosyalblada, this.dosyalblparsel, this.dosyalblsinif, this.dosyalblasnno, this.dosyalblservistar, this.dosyalblbinasahip, this.dosyalblbinasahiptc, this.dosyalblbinasahipvn, this.dosyalblbinasahipvd, this.dosyalblmuteaahhit,
                this.dosyalblmuteaahhittc, this.dosyalblmuteaahhitvn, this.dosyalblmuteaahhitvd, this.dosyalblasansorsahip, this.dosyalblblok, this.dosyalblbulvar, this.dosyalblmahalle, this.dosyalblcadde, this.dosyalblsokak, this.dosyalbladres
            };
            this.layoutControlGroup9.Items.AddRange(itemArray11);
            this.layoutControlGroup9.Location = new Point(0, 0);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup9.Size = new Size(0x138, 0x331);
            this.layoutControlGroup9.TextVisible = false;
            this.dosyalblmodul.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblmodul.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblmodul.Control = this.dosyabelgemodul;
            this.dosyalblmodul.CustomizationFormText = "Belge Mod\x00fcl\x00fc : ";
            this.dosyalblmodul.Location = new Point(0, 0);
            this.dosyalblmodul.Name = "dosyalblmodul";
            this.dosyalblmodul.Size = new Size(0x12e, 0x18);
            this.dosyalblmodul.Text = "Belge Mod\x00fcl\x00fc : ";
            this.dosyalblmodul.TextSize = new Size(0x5c, 13);
            this.dosyalblno.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblno.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblno.Control = this.dosyano;
            this.dosyalblno.CustomizationFormText = "No : ";
            this.dosyalblno.Location = new Point(0, 0x90);
            this.dosyalblno.Name = "dosyalblno";
            this.dosyalblno.Size = new Size(0x12e, 0x18);
            this.dosyalblno.Text = "No : ";
            this.dosyalblno.TextSize = new Size(0x5c, 13);
            this.dosyalblil.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblil.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblil.Control = this.dosyail;
            this.dosyalblil.CustomizationFormText = "İl : ";
            this.dosyalblil.Location = new Point(0, 0xc0);
            this.dosyalblil.Name = "dosyalblil";
            this.dosyalblil.Size = new Size(0x12e, 0x18);
            this.dosyalblil.Text = "İl : ";
            this.dosyalblil.TextSize = new Size(0x5c, 13);
            this.dosyalblilce.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblilce.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblilce.Control = this.dosyailce;
            this.dosyalblilce.CustomizationFormText = "İl\x00e7e : ";
            this.dosyalblilce.Location = new Point(0, 0xd8);
            this.dosyalblilce.Name = "dosyalblilce";
            this.dosyalblilce.Size = new Size(0x12e, 0x18);
            this.dosyalblilce.Text = "İl\x00e7e : ";
            this.dosyalblilce.TextSize = new Size(0x5c, 13);
            this.dosyalblbelediye.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblbelediye.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblbelediye.Control = this.dosyabelediye;
            this.dosyalblbelediye.CustomizationFormText = "Belediye : ";
            this.dosyalblbelediye.Location = new Point(0, 0x1bf);
            this.dosyalblbelediye.Name = "dosyalblbelediye";
            this.dosyalblbelediye.Size = new Size(0x12e, 0x18);
            this.dosyalblbelediye.Text = "Belediye : ";
            this.dosyalblbelediye.TextSize = new Size(0x5c, 13);
            this.dosyalblpafta.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblpafta.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblpafta.Control = this.dosyapafta;
            this.dosyalblpafta.CustomizationFormText = "Pafta : ";
            this.dosyalblpafta.Location = new Point(0, 0x1d7);
            this.dosyalblpafta.Name = "dosyalblpafta";
            this.dosyalblpafta.Size = new Size(0x12e, 0x18);
            this.dosyalblpafta.Text = "Pafta : ";
            this.dosyalblpafta.TextSize = new Size(0x5c, 13);
            this.dosyalblada.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblada.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblada.Control = this.dosyaada;
            this.dosyalblada.CustomizationFormText = "Ada : ";
            this.dosyalblada.Location = new Point(0, 0x1ef);
            this.dosyalblada.Name = "dosyalblada";
            this.dosyalblada.Size = new Size(0x12e, 0x18);
            this.dosyalblada.Text = "Ada : ";
            this.dosyalblada.TextSize = new Size(0x5c, 13);
            this.dosyalblparsel.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblparsel.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblparsel.Control = this.dosyaparsel;
            this.dosyalblparsel.CustomizationFormText = "Parsel : ";
            this.dosyalblparsel.Location = new Point(0, 0x207);
            this.dosyalblparsel.Name = "dosyalblparsel";
            this.dosyalblparsel.Size = new Size(0x12e, 0x18);
            this.dosyalblparsel.Text = "Parsel : ";
            this.dosyalblparsel.TextSize = new Size(0x5c, 13);
            this.dosyalblsinif.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblsinif.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblsinif.Control = this.dosyasinif;
            this.dosyalblsinif.CustomizationFormText = "Sınıfı : ";
            this.dosyalblsinif.Location = new Point(0, 0x21f);
            this.dosyalblsinif.Name = "dosyalblsinif";
            this.dosyalblsinif.Size = new Size(0x12e, 0x18);
            this.dosyalblsinif.Text = "Sınıfı : ";
            this.dosyalblsinif.TextSize = new Size(0x5c, 13);
            this.dosyalblasnno.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblasnno.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblasnno.Control = this.dosyaasansorno;
            this.dosyalblasnno.CustomizationFormText = "Asans\x00f6r No : ";
            this.dosyalblasnno.Location = new Point(0, 0x237);
            this.dosyalblasnno.Name = "dosyalblasnno";
            this.dosyalblasnno.Size = new Size(0x12e, 0x18);
            this.dosyalblasnno.Text = "Asans\x00f6r No : ";
            this.dosyalblasnno.TextSize = new Size(0x5c, 13);
            this.dosyalblservistar.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblservistar.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblservistar.Control = this.dosyaservistar;
            this.dosyalblservistar.CustomizationFormText = "Servis Tarihi : ";
            this.dosyalblservistar.Location = new Point(0, 0x24f);
            this.dosyalblservistar.Name = "dosyalblservistar";
            this.dosyalblservistar.Size = new Size(0x12e, 0x18);
            this.dosyalblservistar.Text = "Servis Tarihi : ";
            this.dosyalblservistar.TextSize = new Size(0x5c, 13);
            this.dosyalblbinasahip.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblbinasahip.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblbinasahip.Control = this.dosyabinasahip;
            this.dosyalblbinasahip.CustomizationFormText = "Bina Sahibi : ";
            this.dosyalblbinasahip.Location = new Point(0, 0x267);
            this.dosyalblbinasahip.Name = "dosyalblbinasahip";
            this.dosyalblbinasahip.Size = new Size(0x12e, 0x18);
            this.dosyalblbinasahip.Text = "Bina Sahibi : ";
            this.dosyalblbinasahip.TextSize = new Size(0x5c, 13);
            this.dosyalblbinasahiptc.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblbinasahiptc.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblbinasahiptc.Control = this.dosyabinasahiptc;
            this.dosyalblbinasahiptc.CustomizationFormText = "Bina Sahibi TC : ";
            this.dosyalblbinasahiptc.Location = new Point(0, 0x27f);
            this.dosyalblbinasahiptc.Name = "dosyalblbinasahiptc";
            this.dosyalblbinasahiptc.Size = new Size(0x12e, 0x18);
            this.dosyalblbinasahiptc.Text = "Bina Sahibi TC : ";
            this.dosyalblbinasahiptc.TextSize = new Size(0x5c, 13);
            this.dosyalblbinasahipvn.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblbinasahipvn.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblbinasahipvn.Control = this.dosyabinasahipvn;
            this.dosyalblbinasahipvn.CustomizationFormText = "Bina Sahibi V.N : ";
            this.dosyalblbinasahipvn.Location = new Point(0, 0x297);
            this.dosyalblbinasahipvn.Name = "dosyalblbinasahipvn";
            this.dosyalblbinasahipvn.Size = new Size(0x12e, 0x18);
            this.dosyalblbinasahipvn.Text = "Bina Sahibi V.N : ";
            this.dosyalblbinasahipvn.TextSize = new Size(0x5c, 13);
            this.dosyalblbinasahipvd.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblbinasahipvd.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblbinasahipvd.Control = this.dosyabinasahipvd;
            this.dosyalblbinasahipvd.CustomizationFormText = "Bina Sahibi V.D : ";
            this.dosyalblbinasahipvd.Location = new Point(0, 0x2af);
            this.dosyalblbinasahipvd.Name = "dosyalblbinasahipvd";
            this.dosyalblbinasahipvd.Size = new Size(0x12e, 0x18);
            this.dosyalblbinasahipvd.Text = "Bina Sahibi V.D : ";
            this.dosyalblbinasahipvd.TextSize = new Size(0x5c, 13);
            this.dosyalblmuteaahhit.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblmuteaahhit.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblmuteaahhit.Control = this.dosyamutaahhit;
            this.dosyalblmuteaahhit.CustomizationFormText = "M\x00fctaahhit : ";
            this.dosyalblmuteaahhit.Location = new Point(0, 0x2c7);
            this.dosyalblmuteaahhit.Name = "dosyalblmuteaahhit";
            this.dosyalblmuteaahhit.Size = new Size(0x12e, 0x18);
            this.dosyalblmuteaahhit.Text = "M\x00fctaahhit : ";
            this.dosyalblmuteaahhit.TextSize = new Size(0x5c, 13);
            this.dosyalblmuteaahhittc.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblmuteaahhittc.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblmuteaahhittc.Control = this.dosyamutaahhittc;
            this.dosyalblmuteaahhittc.CustomizationFormText = "M\x00fctaahhit TC : ";
            this.dosyalblmuteaahhittc.Location = new Point(0, 0x2df);
            this.dosyalblmuteaahhittc.Name = "dosyalblmuteaahhittc";
            this.dosyalblmuteaahhittc.Size = new Size(0x12e, 0x18);
            this.dosyalblmuteaahhittc.Text = "M\x00fctaahhit TC : ";
            this.dosyalblmuteaahhittc.TextSize = new Size(0x5c, 13);
            this.dosyalblmuteaahhitvn.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblmuteaahhitvn.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblmuteaahhitvn.Control = this.dosyamutaahhitvn;
            this.dosyalblmuteaahhitvn.CustomizationFormText = "M\x00fctaahhit V.N : ";
            this.dosyalblmuteaahhitvn.Location = new Point(0, 0x2f7);
            this.dosyalblmuteaahhitvn.Name = "dosyalblmuteaahhitvn";
            this.dosyalblmuteaahhitvn.Size = new Size(0x12e, 0x18);
            this.dosyalblmuteaahhitvn.Text = "M\x00fctaahhit V.N : ";
            this.dosyalblmuteaahhitvn.TextSize = new Size(0x5c, 13);
            this.dosyalblmuteaahhitvd.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblmuteaahhitvd.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblmuteaahhitvd.Control = this.dosyamutaahhitvd;
            this.dosyalblmuteaahhitvd.CustomizationFormText = "M\x00fctaahhit V.D : ";
            this.dosyalblmuteaahhitvd.Location = new Point(0, 0x30f);
            this.dosyalblmuteaahhitvd.Name = "dosyalblmuteaahhitvd";
            this.dosyalblmuteaahhitvd.Size = new Size(0x12e, 0x18);
            this.dosyalblmuteaahhitvd.Text = "M\x00fctaahhit V.D : ";
            this.dosyalblmuteaahhitvd.TextSize = new Size(0x5c, 13);
            this.dosyalblasansorsahip.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblasansorsahip.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblasansorsahip.Control = this.dosyaasansorsahib;
            this.dosyalblasansorsahip.CustomizationFormText = "Asans\x00f6r Sahibi : ";
            this.dosyalblasansorsahip.Location = new Point(0, 0x18);
            this.dosyalblasansorsahip.Name = "dosyalblasansorsahip";
            this.dosyalblasansorsahip.Size = new Size(0x12e, 0x18);
            this.dosyalblasansorsahip.Text = "Asans\x00f6r Sahibi : ";
            this.dosyalblasansorsahip.TextSize = new Size(0x5c, 13);
            this.dosyalblblok.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblblok.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblblok.Control = this.dosyablok;
            this.dosyalblblok.CustomizationFormText = "Blok : ";
            this.dosyalblblok.Location = new Point(0, 0xa8);
            this.dosyalblblok.Name = "dosyalblblok";
            this.dosyalblblok.Size = new Size(0x12e, 0x18);
            this.dosyalblblok.Text = "Blok : ";
            this.dosyalblblok.TextSize = new Size(0x5c, 13);
            this.dosyalblbulvar.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblbulvar.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblbulvar.Control = this.dosyabulvar;
            this.dosyalblbulvar.CustomizationFormText = "Bulvar : ";
            this.dosyalblbulvar.Location = new Point(0, 120);
            this.dosyalblbulvar.Name = "dosyalblbulvar";
            this.dosyalblbulvar.Size = new Size(0x12e, 0x18);
            this.dosyalblbulvar.Text = "Bulvar : ";
            this.dosyalblbulvar.TextSize = new Size(0x5c, 13);
            this.dosyalblmahalle.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblmahalle.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblmahalle.Control = this.dosyamahalle;
            this.dosyalblmahalle.CustomizationFormText = "Mahalle : ";
            this.dosyalblmahalle.Location = new Point(0, 0x30);
            this.dosyalblmahalle.Name = "dosyalblmahalle";
            this.dosyalblmahalle.Size = new Size(0x12e, 0x18);
            this.dosyalblmahalle.Text = "Mahalle : ";
            this.dosyalblmahalle.TextSize = new Size(0x5c, 13);
            this.dosyalblcadde.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblcadde.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblcadde.Control = this.dosyacadde;
            this.dosyalblcadde.CustomizationFormText = "Cadde : ";
            this.dosyalblcadde.Location = new Point(0, 0x60);
            this.dosyalblcadde.Name = "dosyalblcadde";
            this.dosyalblcadde.Size = new Size(0x12e, 0x18);
            this.dosyalblcadde.Text = "Cadde : ";
            this.dosyalblcadde.TextSize = new Size(0x5c, 13);
            this.dosyalblsokak.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalblsokak.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalblsokak.Control = this.dosyasokak;
            this.dosyalblsokak.CustomizationFormText = "Sokak : ";
            this.dosyalblsokak.Location = new Point(0, 0x48);
            this.dosyalblsokak.Name = "dosyalblsokak";
            this.dosyalblsokak.Size = new Size(0x12e, 0x18);
            this.dosyalblsokak.Text = "Sokak : ";
            this.dosyalblsokak.TextSize = new Size(0x5c, 13);
            this.dosyalbladres.AppearanceItemCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dosyalbladres.AppearanceItemCaption.Options.UseFont = true;
            this.dosyalbladres.Control = this.dosyaadres;
            this.dosyalbladres.CustomizationFormText = "Tam Adres : ";
            this.dosyalbladres.Location = new Point(0, 240);
            this.dosyalbladres.MinSize = new Size(0x6d, 0x48);
            this.dosyalbladres.Name = "dosyalbladres";
            this.dosyalbladres.Size = new Size(0x12e, 0xcf);
            this.dosyalbladres.SizeConstraintsType = SizeConstraintsType.Custom;
            this.dosyalbladres.Text = "Tam Adres : ";
            this.dosyalbladres.TextSize = new Size(0x5c, 13);
            this.backstageViewClientControl4.Controls.Add(this.layoutControl2);
            this.backstageViewClientControl4.Controls.Add(this.layoutControl1);
            this.backstageViewClientControl4.Location = new Point(0x99, 0);
            this.backstageViewClientControl4.Name = "backstageViewClientControl4";
            this.backstageViewClientControl4.Size = new Size(0x485, 0x331);
            this.backstageViewClientControl4.TabIndex = 3;
            this.layoutControl2.Controls.Add(this.dileklemebuton);
            this.layoutControl2.Controls.Add(this.labeldilaciklama);
            this.layoutControl2.Controls.Add(this.gridcontroldiller);
            this.layoutControl2.Dock = DockStyle.Fill;
            this.layoutControl2.Location = new Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup7;
            this.layoutControl2.Size = new Size(0x485, 790);
            this.layoutControl2.TabIndex = 2;
            this.layoutControl2.Text = "layoutControl1";
            this.dileklemebuton.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dileklemebuton.Appearance.Options.UseFont = true;
            this.dileklemebuton.Location = new Point(0x374, 7);
            this.dileklemebuton.Name = "dileklemebuton";
            this.dileklemebuton.Size = new Size(0x10a, 0x2e);
            this.dileklemebuton.StyleController = this.layoutControl2;
            this.dileklemebuton.TabIndex = 5;
            this.dileklemebuton.Text = "YENİ BİR DİL EKLE";
            this.dileklemebuton.Click += new EventHandler(this.dileklemebuton_Click);
            this.labeldilaciklama.Appearance.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labeldilaciklama.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.labeldilaciklama.AutoSizeMode = LabelAutoSizeMode.None;
            this.labeldilaciklama.Location = new Point(7, 7);
            this.labeldilaciklama.Name = "labeldilaciklama";
            this.labeldilaciklama.Size = new Size(0x369, 0x2e);
            this.labeldilaciklama.StyleController = this.layoutControl2;
            this.labeldilaciklama.TabIndex = 4;
            this.labeldilaciklama.Text = "Sayın Kullanıcımız Yaptığınız Dil Değişiklikleri Siz Yazdığınız Anda Uygulanacaktır. L\x00fctfen Değişiklik Yaparken Dikkat Ediniz.";
            this.gridcontroldiller.Location = new Point(7, 0x39);
            this.gridcontroldiller.MainView = this.gridviewdiller;
            this.gridcontroldiller.Name = "gridcontroldiller";
            this.gridcontroldiller.Size = new Size(0x477, 0x2d6);
            this.gridcontroldiller.TabIndex = 0;
            BaseView[] views = new BaseView[] { this.gridviewdiller };
            this.gridcontroldiller.ViewCollection.AddRange(views);
            this.gridviewdiller.Appearance.HeaderPanel.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gridviewdiller.Appearance.HeaderPanel.ForeColor = Color.Red;
            this.gridviewdiller.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridviewdiller.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridviewdiller.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridviewdiller.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridviewdiller.Appearance.Row.Font = new Font("Tahoma", 12f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridviewdiller.Appearance.Row.Options.UseFont = true;
            this.gridviewdiller.GridControl = this.gridcontroldiller;
            this.gridviewdiller.Name = "gridviewdiller";
            this.gridviewdiller.OptionsView.ShowAutoFilterRow = true;
            this.gridviewdiller.OptionsView.ShowGroupPanel = false;
            this.gridviewdiller.CellValueChanged += new CellValueChangedEventHandler(this.gridviewdiller_CellValueChanged);
            this.layoutControlGroup7.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup7.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup7.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray12 = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem43 };
            this.layoutControlGroup7.Items.AddRange(itemArray12);
            this.layoutControlGroup7.Location = new Point(0, 0);
            this.layoutControlGroup7.Name = "layoutControlGroup1";
            this.layoutControlGroup7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup7.Size = new Size(0x485, 790);
            this.layoutControlGroup7.TextVisible = false;
            this.layoutControlItem1.Control = this.gridcontroldiller;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new Point(0, 50);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x47b, 730);
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem2.Control = this.labeldilaciklama;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new Point(0, 0);
            this.layoutControlItem2.MaxSize = new Size(0, 50);
            this.layoutControlItem2.MinSize = new Size(20, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x36d, 50);
            this.layoutControlItem2.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem43.Control = this.dileklemebuton;
            this.layoutControlItem43.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem43.Location = new Point(0x36d, 0);
            this.layoutControlItem43.MinSize = new Size(0x52, 0x1a);
            this.layoutControlItem43.Name = "layoutControlItem3";
            this.layoutControlItem43.Size = new Size(270, 50);
            this.layoutControlItem43.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem43.TextSize = new Size(0, 0);
            this.layoutControlItem43.TextVisible = false;
            this.layoutControl1.Controls.Add(this.labelversionbilgi);
            this.layoutControl1.Controls.Add(this.labelversiyonyazi);
            this.layoutControl1.Controls.Add(this.dilsecimi);
            this.layoutControl1.Controls.Add(this.gorunumayar);
            this.layoutControl1.Dock = DockStyle.Bottom;
            this.layoutControl1.Location = new Point(0, 790);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup6;
            this.layoutControl1.Size = new Size(0x485, 0x1b);
            this.layoutControl1.TabIndex = 0x27;
            this.layoutControl1.Text = "layoutControl1";
            this.labelversionbilgi.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelversionbilgi.Appearance.ForeColor = Color.Maroon;
            this.labelversionbilgi.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelversionbilgi.Location = new Point(0x43c, 2);
            this.labelversionbilgi.Name = "labelversionbilgi";
            this.labelversionbilgi.Size = new Size(0x47, 0x17);
            this.labelversionbilgi.StyleController = this.layoutControl1;
            this.labelversionbilgi.TabIndex = 13;
            this.labelversiyonyazi.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelversiyonyazi.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labelversiyonyazi.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelversiyonyazi.Location = new Point(0x3c2, 0);
            this.labelversiyonyazi.Name = "labelversiyonyazi";
            this.labelversiyonyazi.Size = new Size(120, 0x1b);
            this.labelversiyonyazi.StyleController = this.layoutControl1;
            this.labelversiyonyazi.TabIndex = 12;
            this.labelversiyonyazi.Text = "Versiyon : ";
            this.dilsecimi.Location = new Point(0xad, 2);
            this.dilsecimi.Name = "dilsecimi";
            this.dilsecimi.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.dilsecimi.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray17 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.dilsecimi.Properties.Buttons.AddRange(buttonArray17);
            this.dilsecimi.Size = new Size(0xc7, 0x16);
            this.dilsecimi.StyleController = this.layoutControl1;
            this.dilsecimi.TabIndex = 11;
            this.dilsecimi.SelectedIndexChanged += new EventHandler(this.dilsecimi_SelectedIndexChanged);
            this.gorunumayar.Location = new Point(0x223, 2);
            this.gorunumayar.Name = "gorunumayar";
            this.gorunumayar.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.gorunumayar.Properties.Appearance.Options.UseFont = true;
            this.gorunumayar.Properties.BorderStyle = BorderStyles.Office2003;
            EditorButton[] buttonArray18 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.gorunumayar.Properties.Buttons.AddRange(buttonArray18);
            object[] objArray2 = new object[] { "Office 2010 Black", "Office 2010 Blue", "Office 2010 Silver", "VS2010", "DevExpress Style", "DevExpress Dark Style", "Metropolis", "Coffee", "Luquid Sky", "London Luquid Sky", "Seven Classic", "Valentine", "XMAS 2008 Blue", "Foggy" };
            this.gorunumayar.Properties.Items.AddRange(objArray2);
            this.gorunumayar.Size = new Size(0x16b, 0x16);
            this.gorunumayar.StyleController = this.layoutControl1;
            this.gorunumayar.TabIndex = 6;
            this.gorunumayar.SelectedIndexChanged += new EventHandler(this.aryz_SelectedIndexChanged);
            this.layoutControlGroup6.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup6.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup6.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray13 = new BaseLayoutItem[] { this.labelgorunumayar, this.labeldilsecimi, this.layoutControlItem8, this.layoutControlItem10 };
            this.layoutControlGroup6.Items.AddRange(itemArray13);
            this.layoutControlGroup6.Location = new Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup1";
            this.layoutControlGroup6.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup6.Size = new Size(0x485, 0x1b);
            this.layoutControlGroup6.TextVisible = false;
            this.labelgorunumayar.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.labelgorunumayar.AppearanceItemCaption.Options.UseFont = true;
            this.labelgorunumayar.Control = this.gorunumayar;
            this.labelgorunumayar.CustomizationFormText = "Program G\x00f6r\x00fcn\x00fcm Ayarı : ";
            this.labelgorunumayar.Location = new Point(0x176, 0);
            this.labelgorunumayar.Name = "labelgorunumayar";
            this.labelgorunumayar.Size = new Size(0x21a, 0x1b);
            this.labelgorunumayar.Text = "Program G\x00f6r\x00fcn\x00fcm Ayarı : ";
            this.labelgorunumayar.TextSize = new Size(0xa8, 0x10);
            this.labeldilsecimi.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            this.labeldilsecimi.AppearanceItemCaption.Options.UseFont = true;
            this.labeldilsecimi.Control = this.dilsecimi;
            this.labeldilsecimi.CustomizationFormText = "Dil Se\x00e7imi : ";
            this.labeldilsecimi.Location = new Point(0, 0);
            this.labeldilsecimi.Name = "labeldilsecimi";
            this.labeldilsecimi.Size = new Size(0x176, 0x1b);
            this.labeldilsecimi.Text = "Dil Se\x00e7imi : ";
            this.labeldilsecimi.TextSize = new Size(0xa8, 0x10);
            this.layoutControlItem8.Control = this.labelversiyonyazi;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem8.Location = new Point(0x390, 0);
            this.layoutControlItem8.MaxSize = new Size(170, 0x1b);
            this.layoutControlItem8.MinSize = new Size(170, 0x1b);
            this.layoutControlItem8.Name = "layoutControlItem1";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(50, 0, 0, 0);
            this.layoutControlItem8.Size = new Size(170, 0x1b);
            this.layoutControlItem8.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            this.layoutControlItem10.Control = this.labelversionbilgi;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem10.Location = new Point(0x43a, 0);
            this.layoutControlItem10.MaxSize = new Size(0x4b, 0x1b);
            this.layoutControlItem10.MinSize = new Size(0x4b, 0x1b);
            this.layoutControlItem10.Name = "layoutControlItem3";
            this.layoutControlItem10.Size = new Size(0x4b, 0x1b);
            this.layoutControlItem10.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            this.backstageViewTabItem1.Caption = "GENEL VERİLER";
            this.backstageViewTabItem1.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItem1.Name = "backstageViewTabItem1";
            this.backstageViewTabItem1.Selected = false;
            this.backstageViewTabItem2.Caption = "KAPI BİLGİLERİ";
            this.backstageViewTabItem2.ContentControl = this.backstageViewClientControl2;
            this.backstageViewTabItem2.Name = "backstageViewTabItem2";
            this.backstageViewTabItem2.Selected = true;
            this.backstageViewTabItem6.Caption = "KUYU BİLGİLERİ";
            this.backstageViewTabItem6.ContentControl = this.backstageViewClientControl6;
            this.backstageViewTabItem6.Name = "backstageViewTabItem6";
            this.backstageViewTabItem6.Selected = false;
            this.backstageViewTabItem3.Appearance.Options.UseTextOptions = true;
            this.backstageViewTabItem3.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            this.backstageViewTabItem3.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.backstageViewTabItem3.Caption = "AĞIRLIK BİLGİLERİ";
            this.backstageViewTabItem3.ContentControl = this.backstageViewClientControl3;
            this.backstageViewTabItem3.Name = "backstageViewTabItem3";
            this.backstageViewTabItem3.Selected = false;
            this.backstageViewTabItem5.Caption = "DOSYA BİLGİLERİ";
            this.backstageViewTabItem5.ContentControl = this.backstageViewClientControl5;
            this.backstageViewTabItem5.Name = "backstageViewTabItem5";
            this.backstageViewTabItem5.Selected = false;
            this.backstageViewTabItem4.Caption = "AYARLAR";
            this.backstageViewTabItem4.ContentControl = this.backstageViewClientControl4;
            this.backstageViewTabItem4.Name = "backstageViewTabItem4";
            this.backstageViewTabItem4.Selected = false;
            this.backstageViewButtonItem1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.backstageViewButtonItem1.Appearance.ForeColor = Color.Red;
            this.backstageViewButtonItem1.Appearance.Options.UseFont = true;
            this.backstageViewButtonItem1.Appearance.Options.UseForeColor = true;
            this.backstageViewButtonItem1.Caption = "ASANS\x00d6R \x00c7İZ";
            this.backstageViewButtonItem1.Name = "backstageViewButtonItem1";
            this.backstageViewButtonItem1.ItemClick += new BackstageViewItemEventHandler(this.backstageViewButtonItem1_ItemClick);
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Silver";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x51e, 0x331);
            base.ControlBox = false;
            base.Controls.Add(this.backstageViewControl1);
            base.Name = "MainForm2";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ASCAD";
            base.FormClosing += new FormClosingEventHandler(this.MainForm2_FormClosing);
            base.Load += new EventHandler(this.MainForm2_Load);
            ((ISupportInitialize) this.backstageViewControl1).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            this.backstageViewClientControl2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.kapitipi.Properties.EndInit();
            this.layoutControl7.EndInit();
            this.layoutControl7.ResumeLayout(false);
            ((ISupportInitialize) this.kapiarkaimage).EndInit();
            ((ISupportInitialize) this.kapionimage).EndInit();
            ((ISupportInitialize) this.kapisagimage).EndInit();
            ((ISupportInitialize) this.kapisolimage).EndInit();
            ((ISupportInitialize) this.kapikabinimage).EndInit();
            this.layoutControlGroup2.EndInit();
            this.layoutControlItem26.EndInit();
            this.layoutControlItem29.EndInit();
            this.layoutControlItem31.EndInit();
            this.layoutControlItem33.EndInit();
            this.layoutControlItem34.EndInit();
            this.groupControl5.EndInit();
            this.groupControl5.ResumeLayout(false);
            this.kuyuyatext.Properties.EndInit();
            this.katatext.Properties.EndInit();
            this.kapisagcheck.Properties.EndInit();
            this.kapiarkacheck.Properties.EndInit();
            this.kapisolcheck.Properties.EndInit();
            this.labelkapitipsecimi.EndInit();
            this.labelkapitipsecimi.ResumeLayout(false);
            this.layoutControl8.EndInit();
            this.layoutControl8.ResumeLayout(false);
            this.acilmayon.Properties.EndInit();
            this.kapigen.Properties.EndInit();
            this.kapimmarmodel.Properties.EndInit();
            this.yangindayanim.Properties.EndInit();
            this.kapikaplama.Properties.EndInit();
            this.layoutControlGroup3.EndInit();
            this.labelkapigenisligi.EndInit();
            this.labelkapikaplamasi.EndInit();
            this.labelkapikaplamamarka.EndInit();
            this.labelyangindayanim.EndInit();
            this.layoutControlItem12.EndInit();
            this.otokaptippicture.Properties.EndInit();
            this.kapitippicture.Properties.EndInit();
            this.otokaptip.Properties.EndInit();
            this.backstageViewClientControl3.ResumeLayout(false);
            this.layoutControl3.EndInit();
            this.layoutControl3.ResumeLayout(false);
            this.dengekatsayisi.Properties.EndInit();
            this.karkasgrup.Properties.EndInit();
            this.karsiagrozgulkutle.Properties.EndInit();
            this.karsiagrbirimagirlik.Properties.EndInit();
            this.karkasagirlik.Properties.EndInit();
            this.arkaagirsayisi.Properties.EndInit();
            this.yanagirsayisi.Properties.EndInit();
            this.karsiagryukseklik.Properties.EndInit();
            this.karsiagrboy.Properties.EndInit();
            this.regulatormarka.Properties.EndInit();
            this.gridView3.EndInit();
            this.karsiagren.Properties.EndInit();
            this.karsiagrsecim.Properties.EndInit();
            this.karsiagrmodel.Properties.EndInit();
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem13.EndInit();
            this.label3regmarka.EndInit();
            this.layoutControlItem24.EndInit();
            this.label3baritdokum.EndInit();
            this.label3modelsec.EndInit();
            this.label3enbilgisi.EndInit();
            this.layoutControlItem30.EndInit();
            this.label3boybilgisi.EndInit();
            this.layoutControlItem32.EndInit();
            this.label3yukseklikbilgisi.EndInit();
            this.layoutControlItem35.EndInit();
            this.layoutControlItem36.EndInit();
            this.layoutControlItem37.EndInit();
            this.lbldengekatsayi.EndInit();
            this.label3karkasagr.EndInit();
            this.label3yanagr.EndInit();
            this.label3arkaagr.EndInit();
            this.layoutControlItem42.EndInit();
            this.label3ozgulkutle.EndInit();
            this.label3birimagr.EndInit();
            this.layoutControlItem25.EndInit();
            this.backstageViewClientControl5.ResumeLayout(false);
            this.dosyahidasnicin.EndInit();
            this.dosyahidasnicin.ResumeLayout(false);
            this.layoutControl23.EndInit();
            this.layoutControl23.ResumeLayout(false);
            this.dosyahortumserino.Properties.EndInit();
            this.dosyahortumonaylayan.Properties.EndInit();
            this.dosyahortumbelgeno.Properties.EndInit();
            this.dosyahortummodel.Properties.EndInit();
            this.dosyahortumuretici.Properties.EndInit();
            this.dosyadebiserino.Properties.EndInit();
            this.dosyadebionaylayan.Properties.EndInit();
            this.dosyadebibelgeno.Properties.EndInit();
            this.dosyadebimodel.Properties.EndInit();
            this.dosyadebiuret.Properties.EndInit();
            this.layoutControlGroup23.EndInit();
            this.layoutControlItem345.EndInit();
            this.layoutControlItem346.EndInit();
            this.layoutControlItem347.EndInit();
            this.layoutControlItem348.EndInit();
            this.layoutControlItem349.EndInit();
            this.layoutControlItem350.EndInit();
            this.layoutControlItem351.EndInit();
            this.layoutControlItem352.EndInit();
            this.layoutControlItem353.EndInit();
            this.layoutControlItem354.EndInit();
            this.layoutControlItem355.EndInit();
            this.layoutControlItem356.EndInit();
            this.layoutControlItem357.EndInit();
            this.layoutControlItem358.EndInit();
            this.layoutControlItem359.EndInit();
            this.layoutControlItem360.EndInit();
            this.layoutControlItem361.EndInit();
            this.layoutControlItem362.EndInit();
            this.dosyalblelektrasnicin.EndInit();
            this.dosyalblelektrasnicin.ResumeLayout(false);
            this.layoutControl24.EndInit();
            this.layoutControl24.ResumeLayout(false);
            this.dosyamotorserino.Properties.EndInit();
            this.dosyamotoronaylayan.Properties.EndInit();
            this.dosyamotorbelgeno.Properties.EndInit();
            this.dosyamotormodel.Properties.EndInit();
            this.dosyamotoruretici.Properties.EndInit();
            this.dosyamakineurserno.Properties.EndInit();
            this.dosyamakineonaylayan.Properties.EndInit();
            this.dosyamakinebelgeno.Properties.EndInit();
            this.dosyamakinemodel.Properties.EndInit();
            this.dosyamakineuret.Properties.EndInit();
            this.layoutControlGroup24.EndInit();
            this.layoutControlItem363.EndInit();
            this.layoutControlItem364.EndInit();
            this.layoutControlItem365.EndInit();
            this.layoutControlItem366.EndInit();
            this.layoutControlItem367.EndInit();
            this.layoutControlItem368.EndInit();
            this.layoutControlItem369.EndInit();
            this.layoutControlItem370.EndInit();
            this.layoutControlItem371.EndInit();
            this.layoutControlItem372.EndInit();
            this.layoutControlItem373.EndInit();
            this.layoutControlItem374.EndInit();
            this.layoutControlItem375.EndInit();
            this.layoutControlItem376.EndInit();
            this.layoutControlItem377.EndInit();
            this.layoutControlItem378.EndInit();
            this.layoutControlItem379.EndInit();
            this.layoutControlItem380.EndInit();
            this.layoutControl6.EndInit();
            this.layoutControl6.ResumeLayout(false);
            this.dosyakapikilit.Properties.EndInit();
            this.gridView1.EndInit();
            this.dosyapanosn.Properties.EndInit();
            this.dosyapano.Properties.EndInit();
            this.searchLookUpEdit6View.EndInit();
            this.dosyapistonvalfisn.Properties.EndInit();
            this.dosyaa3ekipmansn.Properties.EndInit();
            this.dosyaregulatorsn.Properties.EndInit();
            this.dosyakumandakartisn.Properties.EndInit();
            this.dosyakabintamponsn.Properties.EndInit();
            this.dosyaagrtamponsn.Properties.EndInit();
            this.dosyafrenbloksn.Properties.EndInit();
            this.dosyakapikilitsn.Properties.EndInit();
            this.dosyapistonvalfi.Properties.EndInit();
            this.searchLookUpEdit9View.EndInit();
            this.dosyaa3ekipman.Properties.EndInit();
            this.searchLookUpEdit8View.EndInit();
            this.dosyaregulator.Properties.EndInit();
            this.searchLookUpEdit7View.EndInit();
            this.dosyakumandakarti.Properties.EndInit();
            this.searchLookUpEdit5View.EndInit();
            this.dosyakabintampon.Properties.EndInit();
            this.searchLookUpEdit4View.EndInit();
            this.dosyaagrtampon.Properties.EndInit();
            this.searchLookUpEdit3View.EndInit();
            this.dosyafrenblok.Properties.EndInit();
            this.searchLookUpEdit2View.EndInit();
            this.layoutControlGroup10.EndInit();
            this.layoutControlItem103.EndInit();
            this.layoutControlItem104.EndInit();
            this.layoutControlItem105.EndInit();
            this.layoutControlItem106.EndInit();
            this.layoutControlItem107.EndInit();
            this.layoutControlItem108.EndInit();
            this.layoutControlItem109.EndInit();
            this.layoutControlItem110.EndInit();
            this.dosyafrenbloklbl.EndInit();
            this.dosyaagrtamponlbl.EndInit();
            this.dosyakabintamponlbl.EndInit();
            this.dosyakumandakartilbl.EndInit();
            this.dosyaregulatorlbl.EndInit();
            this.dosyaa3ekipmanlbl.EndInit();
            this.dosyapistonvalfilbl.EndInit();
            this.layoutControlItem127.EndInit();
            this.layoutControlItem128.EndInit();
            this.layoutControlItem129.EndInit();
            this.layoutControlItem130.EndInit();
            this.layoutControlItem131.EndInit();
            this.layoutControlItem132.EndInit();
            this.layoutControlItem133.EndInit();
            this.layoutControlItem134.EndInit();
            this.dosyapanolbl.EndInit();
            this.layoutControlItem138.EndInit();
            this.layoutControlItem139.EndInit();
            this.layoutControlItem140.EndInit();
            this.layoutControlItem141.EndInit();
            this.layoutControlItem142.EndInit();
            this.dosyakapikilitlbl.EndInit();
            this.layoutControl5.EndInit();
            this.layoutControl5.ResumeLayout(false);
            this.dosyamutaahhitvd.Properties.EndInit();
            this.dosyamutaahhitvn.Properties.EndInit();
            this.dosyamutaahhittc.Properties.EndInit();
            this.dosyamutaahhit.Properties.EndInit();
            this.dosyabinasahipvd.Properties.EndInit();
            this.dosyabinasahipvn.Properties.EndInit();
            this.dosyabinasahiptc.Properties.EndInit();
            this.dosyabinasahip.Properties.EndInit();
            this.dosyaservistar.Properties.EndInit();
            this.dosyaasansorno.Properties.EndInit();
            this.dosyasinif.Properties.EndInit();
            this.dosyaparsel.Properties.EndInit();
            this.dosyaada.Properties.EndInit();
            this.dosyapafta.Properties.EndInit();
            this.dosyabelediye.Properties.EndInit();
            this.dosyailce.Properties.EndInit();
            this.dosyail.Properties.EndInit();
            this.dosyablok.Properties.EndInit();
            this.dosyano.Properties.EndInit();
            this.dosyabulvar.Properties.EndInit();
            this.dosyacadde.Properties.EndInit();
            this.dosyasokak.Properties.EndInit();
            this.dosyamahalle.Properties.EndInit();
            this.dosyaasansorsahib.Properties.EndInit();
            this.dosyabelgemodul.Properties.EndInit();
            this.layoutControlGroup9.EndInit();
            this.dosyalblmodul.EndInit();
            this.dosyalblno.EndInit();
            this.dosyalblil.EndInit();
            this.dosyalblilce.EndInit();
            this.dosyalblbelediye.EndInit();
            this.dosyalblpafta.EndInit();
            this.dosyalblada.EndInit();
            this.dosyalblparsel.EndInit();
            this.dosyalblsinif.EndInit();
            this.dosyalblasnno.EndInit();
            this.dosyalblservistar.EndInit();
            this.dosyalblbinasahip.EndInit();
            this.dosyalblbinasahiptc.EndInit();
            this.dosyalblbinasahipvn.EndInit();
            this.dosyalblbinasahipvd.EndInit();
            this.dosyalblmuteaahhit.EndInit();
            this.dosyalblmuteaahhittc.EndInit();
            this.dosyalblmuteaahhitvn.EndInit();
            this.dosyalblmuteaahhitvd.EndInit();
            this.dosyalblasansorsahip.EndInit();
            this.dosyalblblok.EndInit();
            this.dosyalblbulvar.EndInit();
            this.dosyalblmahalle.EndInit();
            this.dosyalblcadde.EndInit();
            this.dosyalblsokak.EndInit();
            this.dosyalbladres.EndInit();
            this.backstageViewClientControl4.ResumeLayout(false);
            this.layoutControl2.EndInit();
            this.layoutControl2.ResumeLayout(false);
            this.gridcontroldiller.EndInit();
            this.gridviewdiller.EndInit();
            this.layoutControlGroup7.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem2.EndInit();
            this.layoutControlItem43.EndInit();
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.dilsecimi.Properties.EndInit();
            this.gorunumayar.Properties.EndInit();
            this.layoutControlGroup6.EndInit();
            this.labelgorunumayar.EndInit();
            this.labeldilsecimi.EndInit();
            this.layoutControlItem8.EndInit();
            this.layoutControlItem10.EndInit();
            base.ResumeLayout(false);
        }

        private void int_KeyDown(object sender, KeyEventArgs e)
        {
            this.nonNumberEntered = false;
            if ((e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Oemcomma))
            {
                this.nonNumberEntered = true;
            }
            else if ((((e.KeyCode < Keys.D0) || (e.KeyCode > Keys.D9)) && ((e.KeyCode < Keys.NumPad0) || (e.KeyCode > Keys.NumPad9))) && (e.KeyCode != Keys.Back))
            {
                this.nonNumberEntered = true;
            }
        }

        private void int_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        private void kabinmarka_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void kabinrayimarka_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void kapiarkasecenek_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void kapigen_EditValueChanged(object sender, EventArgs e)
        {
            this.LiftDataform.KapiGen = this.kapigen.Text;
        }

        private void kapikaplama_EditValueChanged(object sender, EventArgs e)
        {
            this.kapikaplamaney = Convert.ToInt32(this.kapikaplama.EditValue);
        }

        private void kapikaplamamarka_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void kapitipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.kapitipi.SelectedIndex != -1)
            {
                if ((this.kapitipi.SelectedIndex == 0) || (this.kapitipi.SelectedIndex == 1))
                {
                    this.otokaptip.Enabled = true;
                }
                else
                {
                    this.otokaptip.Enabled = false;
                    this.otokaptippicture.Image = Resources.SZG_SON_LOGO;
                    this.otokaptip.SelectedIndex = -1;
                }
                if (this.kapitipi.SelectedIndex == 0)
                {
                    this.otokaptippicture.Image = Resources._2_panel_merkezi;
                }
                else if (this.kapitipi.SelectedIndex == 1)
                {
                    this.otokaptippicture.Image = Resources.yarım_otomatik;
                }
                else if (this.kapitipi.SelectedIndex == 2)
                {
                    this.otokaptippicture.Image = Resources.kramer_kapılı;
                }
                else if (this.kapitipi.SelectedIndex == 3)
                {
                    this.otokaptippicture.Image = Resources.SZG_SON_LOGO;
                }
                else if (this.kapitipi.SelectedIndex == 4)
                {
                    this.otokaptippicture.Image = Resources.iç_kapısız;
                }
            }
        }

        private void kapiyeri(object sender, EventArgs e)
        {
            if (this.ilklocationx == 0)
            {
                this.ilklocationx = this.otokaptippicture.Location.X;
            }
            if (this.ilklocationy == 0)
            {
                this.ilklocationy = this.otokaptippicture.Location.Y;
            }
            if (this.kuyuyaradio.Checked)
            {
                this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy);
                this.kuyuyatext.Enabled = true;
                this.kuyuyatext.Properties.BorderStyle = BorderStyles.Default;
                this.katatext.Enabled = false;
                this.katatext.Properties.BorderStyle = BorderStyles.NoBorder;
            }
            else if (this.kataradio.Checked)
            {
                this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy);
                this.kuyuyatext.Enabled = false;
                this.kuyuyatext.Properties.BorderStyle = BorderStyles.NoBorder;
                this.katatext.Enabled = true;
                this.katatext.Properties.BorderStyle = BorderStyles.Default;
            }
            else if (this.kathizasiradio.Checked)
            {
                this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy);
                this.kuyuyatext.Enabled = false;
                this.kuyuyatext.Properties.BorderStyle = BorderStyles.NoBorder;
                this.katatext.Enabled = false;
                this.katatext.Properties.BorderStyle = BorderStyles.NoBorder;
            }
            this.kuyuyatext_TextChanged(sender, e);
        }

        private void karkascizer()
        {
            if ((this.yanagirsayisi.Text != "") && (this.karsiagrsecim.Text != ""))
            {
                string imageName = "";
                int width = 0;
                if (this.karkasgrup.SelectedIndex == 0)
                {
                    imageName = "tekli2";
                    width = 100;
                }
                else
                {
                    imageName = "ciftli";
                    width = 0xbc;
                }
                int height = 100;
                this.panel1.Controls.Clear();
                int x = 10;
                int y = 0;
                if (Convert.ToInt32(this.yanagirsayisi.Text) > 5)
                {
                    y = 40;
                }
                else
                {
                    y = 0x21;
                }
                for (int i = Convert.ToInt32(this.yanagirsayisi.Text); i > 0; i--)
                {
                    if (Convert.ToInt32(this.yanagirsayisi.Text) > 5)
                    {
                        if (i == 3)
                        {
                            PictureBox box2 = new PictureBox {
                                Name = "noktaname",
                                BackgroundImage = resourceimage(this.karsiagrsecim.Text + "_nokta"),
                                Padding = new System.Windows.Forms.Padding(0),
                                Size = new Size(80, 0x19)
                            };
                            y += 0x16;
                            box2.Location = new Point(x, y);
                            this.panel1.Controls.Add(box2);
                            height += 0x19;
                        }
                        else if (i < 4)
                        {
                            PictureBox box3 = new PictureBox {
                                Name = "name" + i,
                                BackgroundImage = resourceimage(this.karsiagrsecim.Text),
                                Padding = new System.Windows.Forms.Padding(0),
                                Size = new Size(80, 0x19)
                            };
                            y += 0x16;
                            box3.Location = new Point(x, y);
                            this.panel1.Controls.Add(box3);
                            height += 0x19;
                        }
                        else if (i == (Convert.ToInt32(this.yanagirsayisi.Text) - 1))
                        {
                            PictureBox box4 = new PictureBox {
                                Name = "name" + (Convert.ToInt32(this.yanagirsayisi.Text) - 1),
                                BackgroundImage = resourceimage(this.karsiagrsecim.Text),
                                Padding = new System.Windows.Forms.Padding(0),
                                Size = new Size(80, 0x19)
                            };
                            y += 0x16;
                            box4.Location = new Point(x, y);
                            this.panel1.Controls.Add(box4);
                            height += 0x19;
                        }
                        else if (i == Convert.ToInt32(this.yanagirsayisi.Text))
                        {
                            PictureBox box5 = new PictureBox {
                                Name = "name" + Convert.ToInt32(this.yanagirsayisi.Text),
                                BackgroundImage = resourceimage(this.karsiagrsecim.Text),
                                Padding = new System.Windows.Forms.Padding(0),
                                Size = new Size(80, 0x19)
                            };
                            y += 0x16;
                            box5.Location = new Point(x, y);
                            this.panel1.Controls.Add(box5);
                            height += 0x19;
                        }
                    }
                    else
                    {
                        PictureBox box6 = new PictureBox {
                            Name = "name" + i,
                            BackgroundImage = resourceimage(this.karsiagrsecim.Text),
                            Padding = new System.Windows.Forms.Padding(0),
                            Size = new Size(80, 0x19)
                        };
                        y += 0x16;
                        box6.Location = new Point(x, y);
                        this.panel1.Controls.Add(box6);
                        height += 0x16;
                    }
                }
                if (this.karkasgrup.SelectedIndex == 1)
                {
                    height = 110;
                    x = 0x61;
                    y = 0;
                    if (Convert.ToInt32(this.yanagirsayisi.Text) > 5)
                    {
                        y = 40;
                    }
                    else
                    {
                        y = 0x21;
                    }
                    for (int j = Convert.ToInt32(this.yanagirsayisi.Text); j > 0; j--)
                    {
                        if (Convert.ToInt32(this.yanagirsayisi.Text) > 5)
                        {
                            if (j == 3)
                            {
                                PictureBox box7 = new PictureBox {
                                    Name = "noktaneme",
                                    BackgroundImage = resourceimage(this.karsiagrsecim.Text + "_nokta"),
                                    Padding = new System.Windows.Forms.Padding(0),
                                    Size = new Size(80, 0x19)
                                };
                                y += 0x16;
                                box7.Location = new Point(x, y);
                                this.panel1.Controls.Add(box7);
                                height += 0x19;
                            }
                            else if (j < 4)
                            {
                                PictureBox box8 = new PictureBox {
                                    Name = "neme" + j,
                                    BackgroundImage = resourceimage(this.karsiagrsecim.Text),
                                    Padding = new System.Windows.Forms.Padding(0),
                                    Size = new Size(80, 0x19)
                                };
                                y += 0x16;
                                box8.Location = new Point(x, y);
                                this.panel1.Controls.Add(box8);
                                height += 0x19;
                            }
                            else if (j == (Convert.ToInt32(this.yanagirsayisi.Text) - 1))
                            {
                                PictureBox box9 = new PictureBox {
                                    Name = "neme" + (Convert.ToInt32(this.yanagirsayisi.Text) - 1),
                                    BackgroundImage = resourceimage(this.karsiagrsecim.Text),
                                    Padding = new System.Windows.Forms.Padding(0),
                                    Size = new Size(80, 0x19)
                                };
                                y += 0x16;
                                box9.Location = new Point(x, y);
                                this.panel1.Controls.Add(box9);
                                height += 0x19;
                            }
                            else if (j == Convert.ToInt32(this.yanagirsayisi.Text))
                            {
                                PictureBox box10 = new PictureBox {
                                    Name = "neme" + Convert.ToInt32(this.yanagirsayisi.Text),
                                    BackgroundImage = resourceimage(this.karsiagrsecim.Text),
                                    Padding = new System.Windows.Forms.Padding(0),
                                    Size = new Size(80, 0x19)
                                };
                                y += 0x16;
                                box10.Location = new Point(x, y);
                                this.panel1.Controls.Add(box10);
                                height += 0x19;
                            }
                        }
                        else
                        {
                            PictureBox box11 = new PictureBox {
                                Name = "neme" + j,
                                BackgroundImage = resourceimage(this.karsiagrsecim.Text),
                                Padding = new System.Windows.Forms.Padding(0),
                                Size = new Size(80, 0x19)
                            };
                            y += 0x16;
                            box11.Location = new Point(x, y);
                            this.panel1.Controls.Add(box11);
                            height += 0x16;
                        }
                    }
                }
                PictureBox box = new PictureBox {
                    Name = "unal",
                    Location = new Point(0, 0),
                    Padding = new System.Windows.Forms.Padding(0),
                    Size = new Size(width, height),
                    Image = resourceimage(imageName),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                this.panel1.Controls.Add(box);
            }
        }

        private void karkascizer2()
        {
            int width = 20;
            int height = 20;
            if (((this.yanagirsayisi.Text != "") && (this.karsiagrsecim.Text != "")) && (this.arkaagirsayisi.Text != ""))
            {
                int num3 = 15 + (Convert.ToInt32(this.arkaagirsayisi.Text) * 0x19);
                int num4 = 110;
                int x = 200;
                int y = 0;
                for (int i = 1; i <= Convert.ToInt32(this.arkaagirsayisi.Text); i++)
                {
                    num4 = 110;
                    x = 0xaf + (i * 0x19);
                    if (Convert.ToInt32(this.yanagirsayisi.Text) > 5)
                    {
                        y = 40;
                    }
                    else
                    {
                        y = 0x21;
                    }
                    for (int j = 0; j < Convert.ToInt32(this.yanagirsayisi.Text); j++)
                    {
                        if (Convert.ToInt32(this.yanagirsayisi.Text) > 5)
                        {
                            if (j < 3)
                            {
                                PictureBox box2 = new PictureBox();
                                object[] objArray1 = new object[] { "a", i, "yanname", j };
                                box2.Name = string.Concat(objArray1);
                                box2.BackgroundImage = resourceimage("yandan");
                                box2.Padding = new System.Windows.Forms.Padding(0);
                                box2.Size = new Size(width, height);
                                y += 0x16;
                                box2.Location = new Point(x, y);
                                box2.BackgroundImageLayout = ImageLayout.Stretch;
                                this.panel1.Controls.Add(box2);
                                num4 += 0x19;
                            }
                            else if (j == (Convert.ToInt32(this.yanagirsayisi.Text) - 2))
                            {
                                PictureBox box3 = new PictureBox();
                                object[] objArray2 = new object[] { "a", i, "yanname", Convert.ToInt32(this.yanagirsayisi.Text) - 2 };
                                box3.Name = string.Concat(objArray2);
                                box3.BackgroundImage = resourceimage("yandan");
                                box3.Padding = new System.Windows.Forms.Padding(0);
                                box3.Size = new Size(width, height);
                                y += 0x16;
                                box3.Location = new Point(x, y);
                                box3.BackgroundImageLayout = ImageLayout.Stretch;
                                this.panel1.Controls.Add(box3);
                                num4 += 0x19;
                            }
                            else if (j == (Convert.ToInt32(this.yanagirsayisi.Text) - 1))
                            {
                                PictureBox box4 = new PictureBox();
                                object[] objArray3 = new object[] { "a", i, "yanname", Convert.ToInt32(this.yanagirsayisi.Text) - 1 };
                                box4.Name = string.Concat(objArray3);
                                box4.BackgroundImage = resourceimage("yandan");
                                box4.Padding = new System.Windows.Forms.Padding(0);
                                box4.Size = new Size(width, height);
                                y += 0x16;
                                box4.Location = new Point(x, y);
                                box4.BackgroundImageLayout = ImageLayout.Stretch;
                                this.panel1.Controls.Add(box4);
                                num4 += 0x19;
                            }
                        }
                        else
                        {
                            PictureBox box5 = new PictureBox();
                            object[] objArray4 = new object[] { "a", i, "yanname", j };
                            box5.Name = string.Concat(objArray4);
                            box5.BackgroundImage = resourceimage("yandan");
                            box5.Padding = new System.Windows.Forms.Padding(0);
                            box5.Size = new Size(width, height);
                            y += 0x16;
                            box5.Location = new Point(x, y);
                            box5.BackgroundImageLayout = ImageLayout.Stretch;
                            this.panel1.Controls.Add(box5);
                            num4 += 0x16;
                        }
                    }
                }
                PictureBox box = new PictureBox {
                    Name = "yanunal",
                    Location = new Point(190, 0),
                    Padding = new System.Windows.Forms.Padding(0)
                };
                if (num4 > 0xeb)
                {
                    num4 = 0xeb;
                }
                box.Size = new Size(num3, num4);
                box.Image = resourceimage("a1");
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                this.panel1.Controls.Add(box);
            }
        }

        private void karkascizerselectedindex(object sender, EventArgs e)
        {
            this.karkascizer();
            this.karkascizer2();
        }

        private void karkascizertextchanged(object sender, EventArgs e)
        {
            this.karkascizer();
            this.karkascizer2();
        }

        private void karkascizervalidated(object sender, EventArgs e)
        {
            this.karkasyaziyazar();
        }

        private void karkasyaziyazar()
        {
            foreach (Control control in this.panel1.Controls)
            {
                if (control.GetType() == typeof(PictureBox))
                {
                    Graphics graphics = control.CreateGraphics();
                    if (control.Name.StartsWith("name"))
                    {
                        int num = 0x1b - (Convert.ToInt32(Convert.ToInt32(control.Name.Substring(4))).ToString().Length * 2);
                        graphics.DrawString(Convert.ToInt32(Convert.ToInt32(control.Name.Substring(4))).ToString(), new Font("Arial", 16f, FontStyle.Italic), new SolidBrush(Color.Black), (float) num, 0f);
                    }
                    if (control.Name.StartsWith("neme"))
                    {
                        int num3 = 0x1b - (Convert.ToInt32(Convert.ToInt32(control.Name.Substring(4))).ToString().Length * 2);
                        graphics.DrawString(Convert.ToInt32(Convert.ToInt32(control.Name.Substring(4))).ToString(), new Font("Arial", 16f, FontStyle.Italic), new SolidBrush(Color.Black), (float) num3, 0f);
                    }
                }
            }
        }

        private void karsiagrmodel_EditValueChanged(object sender, EventArgs e)
        {
            DataTable table = this.xx.dtta("select * from karsiagirlikbilgisi where sno=" + this.karsiagrmodel.EditValue, "");
            if (table.Rows.Count > 0)
            {
                this.karsiagren.Text = table.Rows[0]["en"].ToString();
                this.karsiagrboy.Text = table.Rows[0]["boy"].ToString();
                this.karsiagryukseklik.Text = table.Rows[0]["yukseklik"].ToString();
                this.karsiagrozgulkutle.Text = table.Rows[0]["ozgulkutle"].ToString();
                this.karsiagrbirimagirlik.Text = table.Rows[0]["birimagirlik"].ToString();
            }
        }

        private void karsiagrsecim_EditValueChanged(object sender, EventArgs e)
        {
            this.karsiagrmodel.Properties.DataSource = this.xx.dtta("select * from karsiagirlikbilgisi where cinsi=" + this.karsiagrsecim.EditValue, "");
            this.karsiagrmodel.Properties.DisplayMember = "model";
            this.karsiagrmodel.Properties.ValueMember = "sno";
        }

        private void kisivekapasite(TextEdit x, TextEdit y, TextEdit kisi, LinkLabel kapasite, TextEdit alan)
        {
            double num2;
            double num3;
            if (x.Text == "")
            {
                num3 = 0.0;
            }
            else
            {
                num3 = Convert.ToDouble(x.Text);
            }
            if (y.Text == "")
            {
                num2 = 0.0;
            }
            else
            {
                num2 = Convert.ToDouble(y.Text);
            }
            double num = (num3 * num2) / 1000000.0;
            if ((num > 0.28) && (num < 0.38))
            {
                kisi.Text = "1";
                kapasite.Text = "100";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 0.49) && (num < 0.58))
            {
                kisi.Text = "2";
                kapasite.Text = "180";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 0.6) && (num < 0.7))
            {
                kisi.Text = "3";
                kapasite.Text = "225";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 0.79) && (num < 0.9))
            {
                kisi.Text = "4";
                kapasite.Text = "300";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 0.98) && (num < 1.1))
            {
                kisi.Text = "5";
                kapasite.Text = "375";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.1) && (num < 1.17))
            {
                kisi.Text = "5";
                kapasite.Text = "400";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.17) && (num < 1.3))
            {
                kisi.Text = "6";
                kapasite.Text = "450";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.31) && (num < 1.45))
            {
                kisi.Text = "7";
                kapasite.Text = "525";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.45) && (num < 1.6))
            {
                kisi.Text = "8";
                kapasite.Text = "600";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.45) && (num < 1.66))
            {
                kisi.Text = "8";
                kapasite.Text = "630";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.59) && (num < 1.75))
            {
                kisi.Text = "9";
                kapasite.Text = "675";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.73) && (num < 1.9))
            {
                kisi.Text = "10";
                kapasite.Text = "750";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.73) && (num < 2.0))
            {
                kisi.Text = "10";
                kapasite.Text = "800";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 1.87) && (num < 2.05))
            {
                kisi.Text = "11";
                kapasite.Text = "825";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 2.01) && (num < 2.2))
            {
                kisi.Text = "12";
                kapasite.Text = "900";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 2.15) && (num < 2.4))
            {
                kisi.Text = "13";
                kapasite.Text = "1000";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 2.29) && (num < 2.5))
            {
                kisi.Text = "14";
                kapasite.Text = "1050";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 2.43) && (num < 2.65))
            {
                kisi.Text = "15";
                kapasite.Text = "1125";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 2.57) && (num < 2.8))
            {
                kisi.Text = "16";
                kapasite.Text = "1200";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 2.71) && (num < 2.95))
            {
                kisi.Text = "17";
                kapasite.Text = "1275";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 2.85) && (num < 3.1))
            {
                kisi.Text = "18";
                kapasite.Text = "1350";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 2.99) && (num < 3.25))
            {
                kisi.Text = "19";
                kapasite.Text = "1425";
                alan.Text = $"{num:#.00#}";
            }
            else if ((num > 3.13) && (num < 3.4))
            {
                kisi.Text = "20";
                kapasite.Text = "1500";
                alan.Text = $"{num:#.00#}";
            }
            else if (num == 3.56)
            {
                kisi.Text = "21";
                kapasite.Text = "1600";
                alan.Text = $"{num:#.00#}";
            }
            else if (num == 4.2)
            {
                kisi.Text = "26";
                kapasite.Text = "2000";
                alan.Text = $"{num:#.00#}";
            }
            else if (num == 5.0)
            {
                kisi.Text = "33";
                kapasite.Text = "2500";
                alan.Text = $"{num:#.00#}";
            }
            else
            {
                kisi.Text = "0";
                kapasite.Text = "";
                alan.Text = "";
            }
        }

        private void kuyuyatext_TextChanged(object sender, EventArgs e)
        {
            if (this.kuyuyaradio.Checked)
            {
                if (this.kuyuyatext.Text != "")
                {
                    this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy - Convert.ToInt32(this.kuyuyatext.Text));
                }
            }
            else if (this.kataradio.Checked && (this.katatext.Text != ""))
            {
                this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy + Convert.ToInt32(this.katatext.Text));
            }
        }

        private int lookupint(LookUpEdit search)
        {
            if (search.EditValue == null)
            {
                return -1;
            }
            if (Convert.ToInt32(search.EditValue) == -1)
            {
                return -1;
            }
            return Convert.ToInt32(search.EditValue);
        }

        private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {
            this.AsansorSayisi = this.asc.AsansorSayisi;
            GridLocalizer.Active = new szgturkce();
            Localizer.Active = new szgturkce2();
            this.dilayar();
            this.verilergeliyor();
        }

        private void otokaptip_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "";
            if (this.otokaptip.SelectedIndex != -1)
            {
                if (this.otokaptip.SelectedIndex == 0)
                {
                    this.otokaptippicture.Image = Resources._2_panel_merkezi;
                    str = "2MER";
                    this.LiftDataform = this.asc.KapiDegerSet(this.LiftDataform);
                }
                else if (this.otokaptip.SelectedIndex == 1)
                {
                    this.otokaptippicture.Image = Resources._2_panel_teleskopik;
                    str = "2TEL";
                }
                else if (this.otokaptip.SelectedIndex == 2)
                {
                    this.otokaptippicture.Image = Resources._3_panel_teleskopik;
                    str = "3TEL";
                }
                else if (this.otokaptip.SelectedIndex == 3)
                {
                    this.otokaptippicture.Image = Resources._4_panel_merkezi;
                    str = "4MER";
                }
                else if (this.otokaptip.SelectedIndex == 4)
                {
                    this.otokaptippicture.Image = Resources._6_panel_merkezi;
                    str = "6MER";
                }
                if (this.kapitipi.SelectedIndex == 0)
                {
                    str = str + "-DYN";
                }
                if (this.kapitipi.SelectedIndex == 1)
                {
                    str = "YO-" + str;
                }
                if (this.kapitipi.SelectedIndex == 2)
                {
                    str = "YO-KRM";
                }
                if (this.kapitipi.SelectedIndex == 4)
                {
                    str = "YO-CIFT";
                }
                this.LiftDataform.KapiTip = str;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.sTT.TipKodu = "HA";
            this.xx.oleupdate(string.Concat(new object[] { "update Tahrik set YonKodu='", this.sTT.YonKodu, "' ,TipKodu='", this.sTT.TipKodu, "' , TahrikKodu='", this.sTT.TahrikKodu, "' where LiftNumber='", this.AsansorSayisi, "'" }), "");
            this.asc.HAMDDegerSet("SAG", this.sTT.YonKodu, "3000", "KuyuDer", this.AsansorSayisi.ToString());
        }

        private void regulatormarka_EditValueChanged(object sender, EventArgs e)
        {
            this.dosyaregulator.EditValue = this.regulatormarka.EditValue;
        }

        public static Bitmap resourceimage(string imageName)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            ResourceManager manager = new ResourceManager(executingAssembly.GetName().Name + ".Properties.Resources", executingAssembly);
            return (Bitmap) manager.GetObject(imageName);
        }

        private void sertifikaekler(object sender, ButtonPressedEventArgs e)
        {
            if ((e.Button.Kind.ToString() == "Plus") && (e.Button.Index == 1))
            {
                new ascad.sertifikaekler { dildata = this.dildata }.ShowDialog();
                this.verilergeliyor();
            }
        }

        public void sertifikaiceriaktar(SearchLookUpEdit s, string malzeme)
        {
            s.Properties.DataSource = this.xx.dtta("select guid,nobo,tedarikid,uretici,model,concat(uretici , ' ' , model) as MARKA_MODEL, serino,belgeveren,degisti from tedarik where malzeme='" + malzeme + "' and gorunur=true", "");
            s.Properties.DisplayMember = "MARKA_MODEL";
            s.Properties.ValueMember = "guid";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void verilergeliyor()
        {
            this.kapikaplama.Properties.DataSource = this.xx.dtta("select * from kapikaplama", "");
            this.kapikaplama.Properties.DisplayMember = "kaplama";
            this.kapikaplama.Properties.ValueMember = "sno";
            this.yangindayanim.Properties.DataSource = this.xx.dtta("select * from yangindayanimi", "");
            this.yangindayanim.Properties.DisplayMember = "yangin";
            this.yangindayanim.Properties.ValueMember = "sno";
            this.kapimmarmodel.Properties.DataSource = this.xx.dtta("select * from kapikaplamamarka", "");
            this.kapimmarmodel.Properties.DisplayMember = "marka";
            this.kapimmarmodel.Properties.ValueMember = "guid";
            this.sertifikaiceriaktar(this.regulatormarka, "REGULATOR");
            this.karsiagrsecim.Properties.DataSource = this.xx.dtta("select * from karsiagirlikcins", "");
            this.karsiagrsecim.Properties.DisplayMember = "cinsi";
            this.karsiagrsecim.Properties.ValueMember = "sno";
            this.gridviewdiller.Columns.Clear();
            DataTable table = this.xx.dtta("select gorunurad,kisaad from dilcesitleri", "");
            string str = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                str = str + table.Rows[i]["kisaad"].ToString() + ",";
            }
            this.gridcontroldiller.DataSource = this.xx.dtta("select number," + str.Substring(0, str.Length - 1) + " from diller", "");
            for (int j = 1; j < this.gridviewdiller.Columns.Count; j++)
            {
                this.gridviewdiller.Columns[j].Caption = table.Rows[j - 1]["gorunurad"].ToString();
            }
            this.gridviewdiller.Columns[0].Visible = false;
            this.gridviewdiller.Columns[0].OptionsColumn.AllowEdit = false;
            this.gridviewdiller.Columns[1].OptionsColumn.AllowEdit = false;
            this.sertifikaiceriaktar(this.dosyakapikilit, "KAPI KILIDI");
            this.sertifikaiceriaktar(this.dosyafrenblok, "FREN BLOGU");
            this.sertifikaiceriaktar(this.dosyaagrtampon, "TAMPON");
            this.sertifikaiceriaktar(this.dosyakabintampon, "TAMPON");
            this.sertifikaiceriaktar(this.dosyakumandakarti, "KUMANDA KARTI");
            this.sertifikaiceriaktar(this.dosyapano, "PANO");
            this.sertifikaiceriaktar(this.dosyaregulator, "REGULATOR");
            this.sertifikaiceriaktar(this.dosyaa3ekipman, "A3 EKIPMANI");
            this.sertifikaiceriaktar(this.dosyapistonvalfi, "PISTON VALFI");
        }

        private void yangindayanim_EditValueChanged(object sender, EventArgs e)
        {
            this.yangindayaniminey = Convert.ToInt32(this.yangindayanim.EditValue);
        }
    }
}

