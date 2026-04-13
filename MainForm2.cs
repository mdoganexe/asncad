using ascad.Properties;
using DevExpress.LookAndFeel;
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

namespace ascad
{
	public class MainForm2 : Form
	{
		public ascad asc;

		private DataTable dildata = new DataTable();

		private abc1 xx = new abc1();

		private inicibaba incik = new inicibaba(".\\AYAR\\ayars.ini");

		public int AsansorSayisi = 1;

		public myData LiftDataform;

		private int dairesecim = 0;

		private bool nonNumberEntered = false;

		public string ney = "";

		private int kapikaplamaney = 0;

		private int yangindayaniminey = 0;

		private DataTable makinehalatcapisi = new DataTable();

		private int ilklocationx = 0;

		private int ilklocationy = 0;

		private structTahrikTip sTT;

		private IContainer components = null;

		private BackstageViewControl backstageViewControl1;

		private BackstageViewClientControl backstageViewClientControl1;

		private BackstageViewClientControl backstageViewClientControl2;

		private BackstageViewClientControl backstageViewClientControl3;

		private BackstageViewClientControl backstageViewClientControl4;

		private BackstageViewTabItem backstageViewTabItem1;

		private BackstageViewTabItem backstageViewTabItem2;

		private BackstageViewTabItem backstageViewTabItem3;

		private BackstageViewTabItem backstageViewTabItem4;

		private LayoutControl layoutControl1;

		private LabelControl labelversionbilgi;

		private LabelControl labelversiyonyazi;

		private ComboBoxEdit dilsecimi;

		private ComboBoxEdit gorunumayar;

		private LayoutControlGroup layoutControlGroup6;

		private LayoutControlItem labelgorunumayar;

		private LayoutControlItem labeldilsecimi;

		private LayoutControlItem layoutControlItem8;

		private LayoutControlItem layoutControlItem10;

		private DefaultLookAndFeel defaultLookAndFeel1;

		private LookUpEdit kapimmarmodel;

		private LookUpEdit kapikaplama;

		private GroupControl labelkapitipsecimi;

		private PictureEdit kapitippicture;

		private RadioGroup otokaptip;

		private TextEdit kapigen;

		private RadioGroup kapitipi;

		private GroupControl groupControl5;

		private TextEdit kuyuyatext;

		private TextEdit katatext;

		private RadioButton kuyuyaradio;

		private RadioButton kataradio;

		private RadioButton kathizasiradio;

		private LookUpEdit yangindayanim;

		private RadioGroup acilmayon;

		private LookUpEdit karsiagrsecim;

		private LookUpEdit karsiagrmodel;

		private TextEdit arkaagirsayisi;

		private TextEdit yanagirsayisi;

		private TextEdit karkasagirlik;

		private TextEdit karsiagren;

		private TextEdit karsiagrboy;

		private TextEdit karsiagryukseklik;

		private TextEdit karsiagrozgulkutle;

		private TextEdit karsiagrbirimagirlik;

		private LayoutControl layoutControl2;

		private SimpleButton dileklemebuton;

		private LabelControl labeldilaciklama;

		private GridControl gridcontroldiller;

		private GridView gridviewdiller;

		private LayoutControlGroup layoutControlGroup7;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		private LayoutControlItem layoutControlItem43;

		private LabelControl label3birimkg;

		private LabelControl label3kutlekg;

		private LabelControl label3yuksekmm;

		private LabelControl label3boymm;

		private LabelControl label3enmm;

		private PictureEdit otokaptippicture;

		private BackstageViewClientControl backstageViewClientControl5;

		private GroupControl dosyahidasnicin;

		private LayoutControl layoutControl23;

		private TextEdit dosyahortumserino;

		private TextEdit dosyahortumonaylayan;

		private TextEdit dosyahortumbelgeno;

		private TextEdit dosyahortummodel;

		private TextEdit dosyahortumuretici;

		private LabelControl dosyalblhortum;

		private LabelControl dosyalblserino2;

		private LabelControl dosyalblonaylayan2;

		private LabelControl dosyalblbelgeno2;

		private LabelControl dosyalblmodel2;

		private LabelControl dosyalbldebi;

		private LabelControl dosyalbluret2;

		private LabelControl dosyalblmalz2;

		private TextEdit dosyadebiserino;

		private TextEdit dosyadebionaylayan;

		private TextEdit dosyadebibelgeno;

		private TextEdit dosyadebimodel;

		private TextEdit dosyadebiuret;

		private LayoutControlGroup layoutControlGroup23;

		private LayoutControlItem layoutControlItem345;

		private LayoutControlItem layoutControlItem346;

		private LayoutControlItem layoutControlItem347;

		private LayoutControlItem layoutControlItem348;

		private LayoutControlItem layoutControlItem349;

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

		private LayoutControlItem layoutControlItem360;

		private LayoutControlItem layoutControlItem361;

		private LayoutControlItem layoutControlItem362;

		private GroupControl dosyalblelektrasnicin;

		private LayoutControl layoutControl24;

		private TextEdit dosyamotorserino;

		private TextEdit dosyamotoronaylayan;

		private TextEdit dosyamotorbelgeno;

		public TextEdit dosyamotormodel;

		public TextEdit dosyamotoruretici;

		private LabelControl dosyalblmotor;

		private LabelControl dosyalblserino;

		private LabelControl dosyalblonaylayan;

		private LabelControl dosyalblbelgeno;

		private LabelControl dosyalblmodel;

		private LabelControl dosyalblmakine;

		private LabelControl dosyalbluret;

		private LabelControl dosyalblmalz;

		private TextEdit dosyamakineurserno;

		private TextEdit dosyamakineonaylayan;

		private TextEdit dosyamakinebelgeno;

		private TextEdit dosyamakinemodel;

		private TextEdit dosyamakineuret;

		private LayoutControlGroup layoutControlGroup24;

		private LayoutControlItem layoutControlItem363;

		private LayoutControlItem layoutControlItem364;

		private LayoutControlItem layoutControlItem365;

		private LayoutControlItem layoutControlItem366;

		private LayoutControlItem layoutControlItem367;

		private LayoutControlItem layoutControlItem368;

		private LayoutControlItem layoutControlItem369;

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

		private LayoutControl layoutControl6;

		private SearchLookUpEdit dosyakapikilit;

		private GridView gridView1;

		private GridColumn gridColumn64;

		private GridColumn gridColumn73;

		private GridColumn gridColumn74;

		private GridColumn gridColumn75;

		private GridColumn gridColumn76;

		private GridColumn gridColumn77;

		private GridColumn gridColumn78;

		private LabelControl dosyalblsertf;

		private LabelControl dosyalblurserno;

		private LabelControl dosyaslblertfsec;

		private TextEdit dosyapanosn;

		private SimpleButton dosyapanogor;

		private SearchLookUpEdit dosyapano;

		private GridView searchLookUpEdit6View;

		private GridColumn gridColumn31;

		private GridColumn gridColumn32;

		private GridColumn gridColumn33;

		private GridColumn gridColumn34;

		private GridColumn gridColumn35;

		private GridColumn gridColumn36;

		private TextEdit dosyapistonvalfisn;

		private TextEdit dosyaa3ekipmansn;

		private TextEdit dosyaregulatorsn;

		private TextEdit dosyakumandakartisn;

		private TextEdit dosyakabintamponsn;

		private TextEdit dosyaagrtamponsn;

		private TextEdit dosyafrenbloksn;

		private TextEdit dosyakapikilitsn;

		private SearchLookUpEdit dosyapistonvalfi;

		private GridView searchLookUpEdit9View;

		private GridColumn gridColumn49;

		private GridColumn gridColumn50;

		private GridColumn gridColumn51;

		private GridColumn gridColumn52;

		private GridColumn gridColumn53;

		private GridColumn gridColumn54;

		private SearchLookUpEdit dosyaa3ekipman;

		private GridView searchLookUpEdit8View;

		private GridColumn gridColumn43;

		private GridColumn gridColumn44;

		private GridColumn gridColumn45;

		private GridColumn gridColumn46;

		private GridColumn gridColumn47;

		private GridColumn gridColumn48;

		private SearchLookUpEdit dosyaregulator;

		private GridView searchLookUpEdit7View;

		private GridColumn gridColumn37;

		private GridColumn gridColumn38;

		private GridColumn gridColumn39;

		private GridColumn gridColumn40;

		private GridColumn gridColumn41;

		private GridColumn gridColumn42;

		private SearchLookUpEdit dosyakumandakarti;

		private GridView searchLookUpEdit5View;

		private GridColumn gridColumn25;

		private GridColumn gridColumn26;

		private GridColumn gridColumn27;

		private GridColumn gridColumn28;

		private GridColumn gridColumn29;

		private GridColumn gridColumn30;

		private SearchLookUpEdit dosyakabintampon;

		private GridView searchLookUpEdit4View;

		private GridColumn gridColumn19;

		private GridColumn gridColumn20;

		private GridColumn gridColumn21;

		private GridColumn gridColumn22;

		private GridColumn gridColumn23;

		private GridColumn gridColumn24;

		private SearchLookUpEdit dosyaagrtampon;

		private GridView searchLookUpEdit3View;

		private GridColumn gridColumn13;

		private GridColumn gridColumn14;

		private GridColumn gridColumn15;

		private GridColumn gridColumn16;

		private GridColumn gridColumn17;

		private GridColumn gridColumn18;

		private SearchLookUpEdit dosyafrenblok;

		private GridView searchLookUpEdit2View;

		private GridColumn gridColumn10;

		private GridColumn gridColumn11;

		private GridColumn gridColumn12;

		private GridColumn gridColumn55;

		private GridColumn gridColumn56;

		private GridColumn gridColumn57;

		private SimpleButton dosyaa3ekipmangor;

		private SimpleButton dosyapistonvalfigor;

		private SimpleButton dosyaregulatorgor;

		private SimpleButton dosyakumandakartigor;

		private SimpleButton dosyakabintampongor;

		private SimpleButton dosyaagrtampongor;

		private SimpleButton dosyafrenblokgor;

		private SimpleButton dosyakapikilitgor;

		private LayoutControlGroup layoutControlGroup10;

		private LayoutControlItem layoutControlItem103;

		private LayoutControlItem layoutControlItem104;

		private LayoutControlItem layoutControlItem105;

		private LayoutControlItem layoutControlItem106;

		private LayoutControlItem layoutControlItem107;

		private LayoutControlItem layoutControlItem108;

		private LayoutControlItem layoutControlItem109;

		private LayoutControlItem layoutControlItem110;

		private LayoutControlItem dosyafrenbloklbl;

		private LayoutControlItem dosyaagrtamponlbl;

		private LayoutControlItem dosyakabintamponlbl;

		private LayoutControlItem dosyakumandakartilbl;

		private LayoutControlItem dosyaregulatorlbl;

		private LayoutControlItem dosyaa3ekipmanlbl;

		private LayoutControlItem dosyapistonvalfilbl;

		private LayoutControlItem layoutControlItem127;

		private LayoutControlItem layoutControlItem128;

		private LayoutControlItem layoutControlItem129;

		private LayoutControlItem layoutControlItem130;

		private LayoutControlItem layoutControlItem131;

		private LayoutControlItem layoutControlItem132;

		private LayoutControlItem layoutControlItem133;

		private LayoutControlItem layoutControlItem134;

		private LayoutControlItem dosyapanolbl;

		private LayoutControlItem layoutControlItem138;

		private LayoutControlItem layoutControlItem139;

		private LayoutControlItem layoutControlItem140;

		private LayoutControlItem layoutControlItem141;

		private LayoutControlItem layoutControlItem142;

		private LayoutControlItem dosyakapikilitlbl;

		private LayoutControl layoutControl5;

		private RichTextBox dosyaadres;

		private TextEdit dosyamutaahhitvd;

		private TextEdit dosyamutaahhitvn;

		private TextEdit dosyamutaahhittc;

		private TextEdit dosyamutaahhit;

		private TextEdit dosyabinasahipvd;

		private TextEdit dosyabinasahipvn;

		private TextEdit dosyabinasahiptc;

		private TextEdit dosyabinasahip;

		private TextEdit dosyaservistar;

		private TextEdit dosyaasansorno;

		private TextEdit dosyasinif;

		private TextEdit dosyaparsel;

		private TextEdit dosyaada;

		private TextEdit dosyapafta;

		private TextEdit dosyabelediye;

		private TextEdit dosyailce;

		private TextEdit dosyail;

		private TextEdit dosyablok;

		private TextEdit dosyano;

		private TextEdit dosyabulvar;

		private TextEdit dosyacadde;

		private TextEdit dosyasokak;

		private TextEdit dosyamahalle;

		private TextEdit dosyaasansorsahib;

		private ComboBoxEdit dosyabelgemodul;

		private LayoutControlGroup layoutControlGroup9;

		private LayoutControlItem dosyalblmodul;

		private LayoutControlItem dosyalblno;

		private LayoutControlItem dosyalblil;

		private LayoutControlItem dosyalblilce;

		private LayoutControlItem dosyalblbelediye;

		private LayoutControlItem dosyalblpafta;

		private LayoutControlItem dosyalblada;

		private LayoutControlItem dosyalblparsel;

		private LayoutControlItem dosyalblsinif;

		private LayoutControlItem dosyalblasnno;

		private LayoutControlItem dosyalblservistar;

		private LayoutControlItem dosyalblbinasahip;

		private LayoutControlItem dosyalblbinasahiptc;

		private LayoutControlItem dosyalblbinasahipvn;

		private LayoutControlItem dosyalblbinasahipvd;

		private LayoutControlItem dosyalblmuteaahhit;

		private LayoutControlItem dosyalblmuteaahhittc;

		private LayoutControlItem dosyalblmuteaahhitvn;

		private LayoutControlItem dosyalblmuteaahhitvd;

		private LayoutControlItem dosyalblasansorsahip;

		private LayoutControlItem dosyalblblok;

		private LayoutControlItem dosyalblbulvar;

		private LayoutControlItem dosyalblmahalle;

		private LayoutControlItem dosyalblcadde;

		private LayoutControlItem dosyalblsokak;

		private LayoutControlItem dosyalbladres;

		private BackstageViewTabItem backstageViewTabItem5;

		private SearchLookUpEdit regulatormarka;

		private GridView gridView3;

		private GridColumn gridColumn65;

		private GridColumn gridColumn66;

		private GridColumn gridColumn67;

		private GridColumn gridColumn68;

		private GridColumn gridColumn69;

		private GridColumn gridColumn70;

		private Panel panel1;

		private RadioGroup karkasgrup;

		private TextEdit dengekatsayisi;

		private BackstageViewButtonItem backstageViewButtonItem1;

		private LayoutControl layoutControl3;

		private LayoutControlGroup layoutControlGroup1;

		private LabelControl label3karsiagirlik;

		private LabelControl label3regulatorbilgi;

		private LayoutControlItem layoutControlItem13;

		private LayoutControlItem label3regmarka;

		private LayoutControlItem layoutControlItem24;

		private LayoutControlItem label3baritdokum;

		private LayoutControlItem label3modelsec;

		private LayoutControlItem label3enbilgisi;

		private LayoutControlItem layoutControlItem30;

		private LayoutControlItem label3boybilgisi;

		private LayoutControlItem layoutControlItem32;

		private LayoutControlItem label3yukseklikbilgisi;

		private LayoutControlItem layoutControlItem35;

		private LayoutControlItem layoutControlItem36;

		private LayoutControlItem layoutControlItem37;

		private LayoutControlItem lbldengekatsayi;

		private LayoutControlItem label3karkasagr;

		private LayoutControlItem label3yanagr;

		private LayoutControlItem label3arkaagr;

		private LayoutControlItem layoutControlItem42;

		private LayoutControlItem label3ozgulkutle;

		private LayoutControlItem label3birimagr;

		private LayoutControlItem layoutControlItem25;

		private CheckEdit kapisagcheck;

		private CheckEdit kapiarkacheck;

		private CheckEdit kapisolcheck;

		private PictureBox kapikabinimage;

		private LayoutControl layoutControl7;

		private PictureBox kapiarkaimage;

		private PictureBox kapionimage;

		private PictureBox kapisagimage;

		private PictureBox kapisolimage;

		private LayoutControlGroup layoutControlGroup2;

		private LayoutControlItem layoutControlItem26;

		private LayoutControlItem layoutControlItem29;

		private LayoutControlItem layoutControlItem31;

		private LayoutControlItem layoutControlItem33;

		private LayoutControlItem layoutControlItem34;

		private LayoutControl layoutControl8;

		private LayoutControlGroup layoutControlGroup3;

		private LayoutControlItem labelkapigenisligi;

		private LayoutControlItem labelkapikaplamasi;

		private LayoutControlItem labelkapikaplamamarka;

		private LayoutControlItem labelyangindayanim;

		private BackstageViewClientControl backstageViewClientControl6;

		private BackstageViewTabItem backstageViewTabItem6;

		private LayoutControlItem layoutControlItem12;

		private GroupBox groupBox2;

		public MainForm2()
		{
			this.InitializeComponent();
		}

		private void MainForm2_Load(object sender, EventArgs e)
		{
			this.AsansorSayisi = this.asc.AsansorSayisi;
			GridLocalizer.set_Active(new szgturkce());
			Localizer.set_Active(new szgturkce2());
			this.dilayar();
			this.verilergeliyor();
		}

		private int lookupint(LookUpEdit search)
		{
			bool flag = search.get_EditValue() == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = Convert.ToInt32(search.get_EditValue()) == -1;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					result = Convert.ToInt32(search.get_EditValue());
				}
			}
			return result;
		}

		private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void aryz_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.defaultLookAndFeel1.get_LookAndFeel().set_SkinName(this.gorunumayar.Text);
			this.incik.Write("GenAyar", "sknname", this.gorunumayar.get_SelectedIndex().ToString());
		}

		private void verilergeliyor()
		{
			this.kapikaplama.get_Properties().set_DataSource(this.xx.dtta("select * from kapikaplama", ""));
			this.kapikaplama.get_Properties().set_DisplayMember("kaplama");
			this.kapikaplama.get_Properties().set_ValueMember("sno");
			this.yangindayanim.get_Properties().set_DataSource(this.xx.dtta("select * from yangindayanimi", ""));
			this.yangindayanim.get_Properties().set_DisplayMember("yangin");
			this.yangindayanim.get_Properties().set_ValueMember("sno");
			this.kapimmarmodel.get_Properties().set_DataSource(this.xx.dtta("select * from kapikaplamamarka", ""));
			this.kapimmarmodel.get_Properties().set_DisplayMember("marka");
			this.kapimmarmodel.get_Properties().set_ValueMember("guid");
			this.sertifikaiceriaktar(this.regulatormarka, "REGULATOR");
			this.karsiagrsecim.get_Properties().set_DataSource(this.xx.dtta("select * from karsiagirlikcins", ""));
			this.karsiagrsecim.get_Properties().set_DisplayMember("cinsi");
			this.karsiagrsecim.get_Properties().set_ValueMember("sno");
			this.gridviewdiller.get_Columns().Clear();
			DataTable dataTable = this.xx.dtta("select gorunurad,kisaad from dilcesitleri", "");
			string text = "";
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				text = text + dataTable.Rows[i]["kisaad"].ToString() + ",";
			}
			this.gridcontroldiller.set_DataSource(this.xx.dtta("select number," + text.Substring(0, text.Length - 1) + " from diller", ""));
			for (int j = 1; j < this.gridviewdiller.get_Columns().Count; j++)
			{
				this.gridviewdiller.get_Columns().get_Item(j).set_Caption(dataTable.Rows[j - 1]["gorunurad"].ToString());
			}
			this.gridviewdiller.get_Columns().get_Item(0).set_Visible(false);
			this.gridviewdiller.get_Columns().get_Item(0).get_OptionsColumn().set_AllowEdit(false);
			this.gridviewdiller.get_Columns().get_Item(1).get_OptionsColumn().set_AllowEdit(false);
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

		private void dilayar()
		{
			this.dilsecimi.get_Properties().get_Items().Clear();
			DataTable dataTable = this.xx.dtta("select gorunurad,kisaad from dilcesitleri", "");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.dilsecimi.get_Properties().get_Items().Add(dataTable.Rows[i]["gorunurad"].ToString());
			}
			this.dildata = this.xx.dtta("select " + this.incik.Read("prgayar", "dil") + ",number from diller", "");
			bool flag = this.incik.Read("prgayar", "dil") == "";
			if (flag)
			{
				this.incik.Write("prgayar", "dil", "TR");
			}
			this.dilsecimi.Text = this.xx.dtta("select gorunurad from dilcesitleri where kisaad='" + this.incik.Read("prgayar", "dil") + "'", "").Rows[0][0].ToString();
			this.Text = this.xx.dilci(119, this.dildata);
			this.backstageViewTabItem1.set_Caption(this.xx.dilci(120, this.dildata));
			this.backstageViewTabItem2.set_Caption(this.xx.dilci(121, this.dildata));
			this.backstageViewTabItem3.set_Caption(this.xx.dilci(89, this.dildata));
			this.backstageViewTabItem4.set_Caption(this.xx.dilci(123, this.dildata));
			this.backstageViewTabItem5.set_Caption(this.xx.dilci(177, this.dildata));
			this.kapimmarmodel.get_Properties().get_Columns().get_Item(0).set_Caption(this.xx.dilci(30, this.dildata));
			this.labelkapitipsecimi.Text = this.xx.dilci(39, this.dildata);
			this.labelkapigenisligi.set_Text(this.xx.dilci(40, this.dildata));
			this.labelkapikaplamasi.set_Text(this.xx.dilci(41, this.dildata));
			this.labelkapikaplamamarka.set_Text(this.xx.dilci(110, this.dildata));
			this.labelyangindayanim.set_Text(this.xx.dilci(43, this.dildata));
			this.kuyuyaradio.Text = this.xx.dilci(44, this.dildata);
			this.kathizasiradio.Text = this.xx.dilci(45, this.dildata);
			this.kataradio.Text = this.xx.dilci(46, this.dildata);
			this.kapitipi.get_Properties().get_Items().get_Item(0).set_Description(this.xx.dilci(47, this.dildata));
			this.kapitipi.get_Properties().get_Items().get_Item(1).set_Description(this.xx.dilci(48, this.dildata));
			this.kapitipi.get_Properties().get_Items().get_Item(2).set_Description(this.xx.dilci(49, this.dildata));
			this.kapitipi.get_Properties().get_Items().get_Item(3).set_Description(this.xx.dilci(50, this.dildata));
			this.kapitipi.get_Properties().get_Items().get_Item(4).set_Description(this.xx.dilci(51, this.dildata));
			this.otokaptip.get_Properties().get_Items().get_Item(0).set_Description(this.xx.dilci(52, this.dildata));
			this.otokaptip.get_Properties().get_Items().get_Item(1).set_Description(this.xx.dilci(53, this.dildata));
			this.otokaptip.get_Properties().get_Items().get_Item(2).set_Description(this.xx.dilci(54, this.dildata));
			this.otokaptip.get_Properties().get_Items().get_Item(3).set_Description(this.xx.dilci(55, this.dildata));
			this.otokaptip.get_Properties().get_Items().get_Item(4).set_Description(this.xx.dilci(56, this.dildata));
			this.acilmayon.get_Properties().get_Items().get_Item(0).set_Description(this.xx.dilci(57, this.dildata));
			this.acilmayon.get_Properties().get_Items().get_Item(1).set_Description(this.xx.dilci(58, this.dildata));
			this.acilmayon.get_Properties().get_Items().get_Item(2).set_Description(this.xx.dilci(59, this.dildata));
			this.kapikaplama.get_Properties().get_Columns().get_Item(0).set_Caption(this.xx.dilci(60, this.dildata));
			this.yangindayanim.get_Properties().get_Columns().get_Item(0).set_Caption(this.xx.dilci(61, this.dildata));
			this.label3regmarka.set_Text(this.xx.dilci(71, this.dildata));
			this.label3baritdokum.set_Text(this.xx.dilci(76, this.dildata));
			this.label3modelsec.set_Text(this.xx.dilci(77, this.dildata));
			this.label3enbilgisi.set_Text(this.xx.dilci(79, this.dildata));
			this.label3boybilgisi.set_Text(this.xx.dilci(80, this.dildata));
			this.label3yukseklikbilgisi.set_Text(this.xx.dilci(81, this.dildata));
			this.label3ozgulkutle.set_Text(this.xx.dilci(82, this.dildata));
			this.label3birimagr.set_Text(this.xx.dilci(83, this.dildata));
			this.label3karkasagr.set_Text(this.xx.dilci(84, this.dildata));
			this.label3yanagr.set_Text(this.xx.dilci(85, this.dildata));
			this.label3arkaagr.set_Text(this.xx.dilci(86, this.dildata));
			this.label3karsiagirlik.Text = this.xx.dilci(88, this.dildata);
			this.label3regulatorbilgi.Text = this.xx.dilci(90, this.dildata);
			this.label3enmm.Text = this.xx.dilci(13, this.dildata);
			this.label3boymm.Text = this.xx.dilci(13, this.dildata);
			this.label3yuksekmm.Text = this.xx.dilci(13, this.dildata);
			this.label3birimkg.Text = this.xx.dilci(29, this.dildata);
			this.label3kutlekg.Text = this.xx.dilci(29, this.dildata);
			this.karkasgrup.get_Properties().get_Items().get_Item(0).set_Description(this.xx.dilci(186, this.dildata));
			this.karkasgrup.get_Properties().get_Items().get_Item(1).set_Description(this.xx.dilci(187, this.dildata));
			this.lbldengekatsayi.set_Text(this.xx.dilci(188, this.dildata));
			this.dileklemebuton.Text = this.xx.dilci(92, this.dildata);
			this.labeldilaciklama.Text = this.xx.dilci(91, this.dildata);
			this.labeldilsecimi.set_Text(this.xx.dilci(112, this.dildata));
			this.labelgorunumayar.set_Text(this.xx.dilci(113, this.dildata));
			this.labelversiyonyazi.Text = this.xx.dilci(114, this.dildata);
			this.dosyalblmodul.set_Text(this.xx.dilci(124, this.dildata));
			this.dosyalblasansorsahip.set_Text(this.xx.dilci(125, this.dildata));
			this.dosyalblmahalle.set_Text(this.xx.dilci(126, this.dildata));
			this.dosyalblsokak.set_Text(this.xx.dilci(127, this.dildata));
			this.dosyalblcadde.set_Text(this.xx.dilci(128, this.dildata));
			this.dosyalblbulvar.set_Text(this.xx.dilci(129, this.dildata));
			this.dosyalblno.set_Text(this.xx.dilci(130, this.dildata));
			this.dosyalblblok.set_Text(this.xx.dilci(131, this.dildata));
			this.dosyalblil.set_Text(this.xx.dilci(132, this.dildata));
			this.dosyalblilce.set_Text(this.xx.dilci(133, this.dildata));
			this.dosyalbladres.set_Text(this.xx.dilci(134, this.dildata));
			this.dosyalblbelediye.set_Text(this.xx.dilci(135, this.dildata));
			this.dosyalblpafta.set_Text(this.xx.dilci(136, this.dildata));
			this.dosyalblada.set_Text(this.xx.dilci(137, this.dildata));
			this.dosyalblparsel.set_Text(this.xx.dilci(138, this.dildata));
			this.dosyalblsinif.set_Text(this.xx.dilci(139, this.dildata));
			this.dosyalblasnno.set_Text(this.xx.dilci(140, this.dildata));
			this.dosyalblservistar.set_Text(this.xx.dilci(141, this.dildata));
			this.dosyalblbinasahip.set_Text(this.xx.dilci(142, this.dildata));
			this.dosyalblbinasahiptc.set_Text(this.xx.dilci(143, this.dildata));
			this.dosyalblbinasahipvn.set_Text(this.xx.dilci(144, this.dildata));
			this.dosyalblbinasahipvd.set_Text(this.xx.dilci(145, this.dildata));
			this.dosyalblmuteaahhit.set_Text(this.xx.dilci(146, this.dildata));
			this.dosyalblmuteaahhittc.set_Text(this.xx.dilci(147, this.dildata));
			this.dosyalblmuteaahhitvn.set_Text(this.xx.dilci(148, this.dildata));
			this.dosyalblmuteaahhitvd.set_Text(this.xx.dilci(149, this.dildata));
			this.dosyaslblertfsec.Text = this.xx.dilci(150, this.dildata);
			this.dosyalblurserno.Text = this.xx.dilci(151, this.dildata);
			this.dosyalblsertf.Text = this.xx.dilci(152, this.dildata);
			this.dosyakapikilitlbl.set_Text(this.xx.dilci(154, this.dildata));
			this.dosyafrenbloklbl.set_Text(this.xx.dilci(155, this.dildata));
			this.dosyaagrtamponlbl.set_Text(this.xx.dilci(156, this.dildata));
			this.dosyakabintamponlbl.set_Text(this.xx.dilci(157, this.dildata));
			this.dosyakumandakartilbl.set_Text(this.xx.dilci(158, this.dildata));
			this.dosyapanolbl.set_Text(this.xx.dilci(159, this.dildata));
			this.dosyaregulatorlbl.set_Text(this.xx.dilci(160, this.dildata));
			this.dosyaa3ekipmanlbl.set_Text(this.xx.dilci(161, this.dildata));
			this.dosyapistonvalfilbl.set_Text(this.xx.dilci(162, this.dildata));
			this.dosyakapikilitgor.Text = this.xx.dilci(163, this.dildata);
			this.dosyafrenblokgor.Text = this.xx.dilci(163, this.dildata);
			this.dosyaagrtampongor.Text = this.xx.dilci(163, this.dildata);
			this.dosyakabintampongor.Text = this.xx.dilci(163, this.dildata);
			this.dosyakumandakartigor.Text = this.xx.dilci(163, this.dildata);
			this.dosyapanogor.Text = this.xx.dilci(163, this.dildata);
			this.dosyaregulatorgor.Text = this.xx.dilci(163, this.dildata);
			this.dosyaa3ekipmangor.Text = this.xx.dilci(163, this.dildata);
			this.dosyapistonvalfigor.Text = this.xx.dilci(163, this.dildata);
			this.dosyalblelektrasnicin.Text = this.xx.dilci(165, this.dildata);
			this.dosyalblmalz.Text = this.xx.dilci(166, this.dildata);
			this.dosyalblmalz2.Text = this.xx.dilci(166, this.dildata);
			this.dosyalbluret.Text = this.xx.dilci(167, this.dildata);
			this.dosyalbluret2.Text = this.xx.dilci(167, this.dildata);
			this.dosyalblmodel.Text = this.xx.dilci(31, this.dildata);
			this.dosyalblmodel2.Text = this.xx.dilci(31, this.dildata);
			this.dosyalblbelgeno.Text = this.xx.dilci(169, this.dildata);
			this.dosyalblbelgeno2.Text = this.xx.dilci(169, this.dildata);
			this.dosyalblonaylayan.Text = this.xx.dilci(170, this.dildata);
			this.dosyalblonaylayan2.Text = this.xx.dilci(170, this.dildata);
			this.dosyalblserino.Text = this.xx.dilci(151, this.dildata);
			this.dosyalblserino2.Text = this.xx.dilci(151, this.dildata);
			this.dosyahidasnicin.Text = this.xx.dilci(172, this.dildata);
			this.dosyalbldebi.Text = this.xx.dilci(173, this.dildata);
			this.dosyalblhortum.Text = this.xx.dilci(174, this.dildata);
			this.dosyalblmakine.Text = this.xx.dilci(175, this.dildata);
			this.dosyalblmotor.Text = this.xx.dilci(176, this.dildata);
			this.regulatormarka.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyakapikilit.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyafrenblok.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyaagrtampon.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyakabintampon.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyakumandakarti.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyapano.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyaregulator.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyaa3ekipman.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
			this.dosyapistonvalfi.get_Properties().get_View().get_Columns().get_Item("MARKA_MODEL").set_Caption(this.xx.dilci(178, this.dildata));
		}

		private void dilsecimi_SelectedIndexChanged(object sender, EventArgs e)
		{
			string value = this.xx.dtta("select kisaad from dilcesitleri where gorunurad='" + this.dilsecimi.Text + "'", "").Rows[0][0].ToString();
			this.incik.Write("prgayar", "dil", value);
			this.dilayar();
		}

		private void flatci(RadioButton radyo)
		{
			bool @checked = radyo.Checked;
			if (@checked)
			{
				radyo.FlatStyle = FlatStyle.Flat;
			}
			else
			{
				radyo.FlatStyle = FlatStyle.Standard;
			}
		}

		private void kisivekapasite(TextEdit x, TextEdit y, TextEdit kisi, LinkLabel kapasite, TextEdit alan)
		{
			bool flag = x.Text == "";
			double num;
			if (flag)
			{
				num = 0.0;
			}
			else
			{
				num = Convert.ToDouble(x.Text);
			}
			bool flag2 = y.Text == "";
			double num2;
			if (flag2)
			{
				num2 = 0.0;
			}
			else
			{
				num2 = Convert.ToDouble(y.Text);
			}
			double num3 = num * num2 / 1000000.0;
			bool flag3 = num3 > 0.28 && num3 < 0.38;
			if (flag3)
			{
				kisi.Text = "1";
				kapasite.Text = "100";
				alan.Text = string.Format("{0:#.00#}", num3);
			}
			else
			{
				bool flag4 = num3 > 0.49 && num3 < 0.58;
				if (flag4)
				{
					kisi.Text = "2";
					kapasite.Text = "180";
					alan.Text = string.Format("{0:#.00#}", num3);
				}
				else
				{
					bool flag5 = num3 > 0.6 && num3 < 0.7;
					if (flag5)
					{
						kisi.Text = "3";
						kapasite.Text = "225";
						alan.Text = string.Format("{0:#.00#}", num3);
					}
					else
					{
						bool flag6 = num3 > 0.79 && num3 < 0.9;
						if (flag6)
						{
							kisi.Text = "4";
							kapasite.Text = "300";
							alan.Text = string.Format("{0:#.00#}", num3);
						}
						else
						{
							bool flag7 = num3 > 0.98 && num3 < 1.1;
							if (flag7)
							{
								kisi.Text = "5";
								kapasite.Text = "375";
								alan.Text = string.Format("{0:#.00#}", num3);
							}
							else
							{
								bool flag8 = num3 > 1.1 && num3 < 1.17;
								if (flag8)
								{
									kisi.Text = "5";
									kapasite.Text = "400";
									alan.Text = string.Format("{0:#.00#}", num3);
								}
								else
								{
									bool flag9 = num3 > 1.17 && num3 < 1.3;
									if (flag9)
									{
										kisi.Text = "6";
										kapasite.Text = "450";
										alan.Text = string.Format("{0:#.00#}", num3);
									}
									else
									{
										bool flag10 = num3 > 1.31 && num3 < 1.45;
										if (flag10)
										{
											kisi.Text = "7";
											kapasite.Text = "525";
											alan.Text = string.Format("{0:#.00#}", num3);
										}
										else
										{
											bool flag11 = num3 > 1.45 && num3 < 1.6;
											if (flag11)
											{
												kisi.Text = "8";
												kapasite.Text = "600";
												alan.Text = string.Format("{0:#.00#}", num3);
											}
											else
											{
												bool flag12 = num3 > 1.45 && num3 < 1.66;
												if (flag12)
												{
													kisi.Text = "8";
													kapasite.Text = "630";
													alan.Text = string.Format("{0:#.00#}", num3);
												}
												else
												{
													bool flag13 = num3 > 1.59 && num3 < 1.75;
													if (flag13)
													{
														kisi.Text = "9";
														kapasite.Text = "675";
														alan.Text = string.Format("{0:#.00#}", num3);
													}
													else
													{
														bool flag14 = num3 > 1.73 && num3 < 1.9;
														if (flag14)
														{
															kisi.Text = "10";
															kapasite.Text = "750";
															alan.Text = string.Format("{0:#.00#}", num3);
														}
														else
														{
															bool flag15 = num3 > 1.73 && num3 < 2.0;
															if (flag15)
															{
																kisi.Text = "10";
																kapasite.Text = "800";
																alan.Text = string.Format("{0:#.00#}", num3);
															}
															else
															{
																bool flag16 = num3 > 1.87 && num3 < 2.05;
																if (flag16)
																{
																	kisi.Text = "11";
																	kapasite.Text = "825";
																	alan.Text = string.Format("{0:#.00#}", num3);
																}
																else
																{
																	bool flag17 = num3 > 2.01 && num3 < 2.2;
																	if (flag17)
																	{
																		kisi.Text = "12";
																		kapasite.Text = "900";
																		alan.Text = string.Format("{0:#.00#}", num3);
																	}
																	else
																	{
																		bool flag18 = num3 > 2.15 && num3 < 2.4;
																		if (flag18)
																		{
																			kisi.Text = "13";
																			kapasite.Text = "1000";
																			alan.Text = string.Format("{0:#.00#}", num3);
																		}
																		else
																		{
																			bool flag19 = num3 > 2.29 && num3 < 2.5;
																			if (flag19)
																			{
																				kisi.Text = "14";
																				kapasite.Text = "1050";
																				alan.Text = string.Format("{0:#.00#}", num3);
																			}
																			else
																			{
																				bool flag20 = num3 > 2.43 && num3 < 2.65;
																				if (flag20)
																				{
																					kisi.Text = "15";
																					kapasite.Text = "1125";
																					alan.Text = string.Format("{0:#.00#}", num3);
																				}
																				else
																				{
																					bool flag21 = num3 > 2.57 && num3 < 2.8;
																					if (flag21)
																					{
																						kisi.Text = "16";
																						kapasite.Text = "1200";
																						alan.Text = string.Format("{0:#.00#}", num3);
																					}
																					else
																					{
																						bool flag22 = num3 > 2.71 && num3 < 2.95;
																						if (flag22)
																						{
																							kisi.Text = "17";
																							kapasite.Text = "1275";
																							alan.Text = string.Format("{0:#.00#}", num3);
																						}
																						else
																						{
																							bool flag23 = num3 > 2.85 && num3 < 3.1;
																							if (flag23)
																							{
																								kisi.Text = "18";
																								kapasite.Text = "1350";
																								alan.Text = string.Format("{0:#.00#}", num3);
																							}
																							else
																							{
																								bool flag24 = num3 > 2.99 && num3 < 3.25;
																								if (flag24)
																								{
																									kisi.Text = "19";
																									kapasite.Text = "1425";
																									alan.Text = string.Format("{0:#.00#}", num3);
																								}
																								else
																								{
																									bool flag25 = num3 > 3.13 && num3 < 3.4;
																									if (flag25)
																									{
																										kisi.Text = "20";
																										kapasite.Text = "1500";
																										alan.Text = string.Format("{0:#.00#}", num3);
																									}
																									else
																									{
																										bool flag26 = num3 == 3.56;
																										if (flag26)
																										{
																											kisi.Text = "21";
																											kapasite.Text = "1600";
																											alan.Text = string.Format("{0:#.00#}", num3);
																										}
																										else
																										{
																											bool flag27 = num3 == 4.2;
																											if (flag27)
																											{
																												kisi.Text = "26";
																												kapasite.Text = "2000";
																												alan.Text = string.Format("{0:#.00#}", num3);
																											}
																											else
																											{
																												bool flag28 = num3 == 5.0;
																												if (flag28)
																												{
																													kisi.Text = "33";
																													kapasite.Text = "2500";
																													alan.Text = string.Format("{0:#.00#}", num3);
																												}
																												else
																												{
																													kisi.Text = "0";
																													kapasite.Text = "";
																													alan.Text = "";
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void decimal_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = this.nonNumberEntered;
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void decimal_KeyDown(object sender, KeyEventArgs e)
		{
			this.nonNumberEntered = false;
			bool flag = e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Oemcomma;
			if (flag)
			{
				this.nonNumberEntered = false;
			}
			else
			{
				bool flag2 = e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9;
				if (flag2)
				{
					bool flag3 = e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9;
					if (flag3)
					{
						bool flag4 = e.KeyCode != Keys.Back;
						if (flag4)
						{
							this.nonNumberEntered = true;
						}
					}
				}
			}
		}

		private void int_KeyDown(object sender, KeyEventArgs e)
		{
			this.nonNumberEntered = false;
			bool flag = e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Oemcomma;
			if (flag)
			{
				this.nonNumberEntered = true;
			}
			else
			{
				bool flag2 = e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9;
				if (flag2)
				{
					bool flag3 = e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9;
					if (flag3)
					{
						bool flag4 = e.KeyCode != Keys.Back;
						if (flag4)
						{
							this.nonNumberEntered = true;
						}
					}
				}
			}
		}

		private void int_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = this.nonNumberEntered;
			if (flag)
			{
				e.Handled = true;
			}
		}

		private void kabinrayimarka_EditValueChanged(object sender, EventArgs e)
		{
		}

		private void kabinmarka_EditValueChanged(object sender, EventArgs e)
		{
		}

		private void agrmarka_EditValueChanged(object sender, EventArgs e)
		{
		}

		private void otokaptip_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = "";
			bool flag = this.otokaptip.get_SelectedIndex() != -1;
			if (flag)
			{
				bool flag2 = this.otokaptip.get_SelectedIndex() == 0;
				if (flag2)
				{
					this.otokaptippicture.set_Image(Resources._2_panel_merkezi);
					text = "2MER";
					this.LiftDataform = this.asc.KapiDegerSet(this.LiftDataform);
				}
				else
				{
					bool flag3 = this.otokaptip.get_SelectedIndex() == 1;
					if (flag3)
					{
						this.otokaptippicture.set_Image(Resources._2_panel_teleskopik);
						text = "2TEL";
					}
					else
					{
						bool flag4 = this.otokaptip.get_SelectedIndex() == 2;
						if (flag4)
						{
							this.otokaptippicture.set_Image(Resources._3_panel_teleskopik);
							text = "3TEL";
						}
						else
						{
							bool flag5 = this.otokaptip.get_SelectedIndex() == 3;
							if (flag5)
							{
								this.otokaptippicture.set_Image(Resources._4_panel_merkezi);
								text = "4MER";
							}
							else
							{
								bool flag6 = this.otokaptip.get_SelectedIndex() == 4;
								if (flag6)
								{
									this.otokaptippicture.set_Image(Resources._6_panel_merkezi);
									text = "6MER";
								}
							}
						}
					}
				}
				bool flag7 = this.kapitipi.get_SelectedIndex() == 0;
				if (flag7)
				{
					text += "-DYN";
				}
				bool flag8 = this.kapitipi.get_SelectedIndex() == 1;
				if (flag8)
				{
					text = "YO-" + text;
				}
				bool flag9 = this.kapitipi.get_SelectedIndex() == 2;
				if (flag9)
				{
					text = "YO-KRM";
				}
				bool flag10 = this.kapitipi.get_SelectedIndex() == 4;
				if (flag10)
				{
					text = "YO-CIFT";
				}
				this.LiftDataform.KapiTip = text;
			}
		}

		private void kapitipi_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.kapitipi.get_SelectedIndex() != -1;
			if (flag)
			{
				bool flag2 = this.kapitipi.get_SelectedIndex() == 0 || this.kapitipi.get_SelectedIndex() == 1;
				if (flag2)
				{
					this.otokaptip.Enabled = true;
				}
				else
				{
					this.otokaptip.Enabled = false;
					this.otokaptippicture.set_Image(Resources.SZG_SON_LOGO);
					this.otokaptip.set_SelectedIndex(-1);
				}
				bool flag3 = this.kapitipi.get_SelectedIndex() == 0;
				if (flag3)
				{
					this.otokaptippicture.set_Image(Resources._2_panel_merkezi);
				}
				else
				{
					bool flag4 = this.kapitipi.get_SelectedIndex() == 1;
					if (flag4)
					{
						this.otokaptippicture.set_Image(Resources.yarım_otomatik);
					}
					else
					{
						bool flag5 = this.kapitipi.get_SelectedIndex() == 2;
						if (flag5)
						{
							this.otokaptippicture.set_Image(Resources.kramer_kapılı);
						}
						else
						{
							bool flag6 = this.kapitipi.get_SelectedIndex() == 3;
							if (flag6)
							{
								this.otokaptippicture.set_Image(Resources.SZG_SON_LOGO);
							}
							else
							{
								bool flag7 = this.kapitipi.get_SelectedIndex() == 4;
								if (flag7)
								{
									this.otokaptippicture.set_Image(Resources.iç_kapısız);
								}
							}
						}
					}
				}
			}
		}

		private void kapikaplama_EditValueChanged(object sender, EventArgs e)
		{
			this.kapikaplamaney = Convert.ToInt32(this.kapikaplama.get_EditValue());
		}

		private void yangindayanim_EditValueChanged(object sender, EventArgs e)
		{
			this.yangindayaniminey = Convert.ToInt32(this.yangindayanim.get_EditValue());
		}

		private void kapikaplamamarka_EditValueChanged(object sender, EventArgs e)
		{
		}

		private void karkascizer()
		{
			bool flag = this.yanagirsayisi.Text == "";
			if (!flag)
			{
				bool flag2 = this.karsiagrsecim.Text == "";
				if (!flag2)
				{
					bool flag3 = this.karkasgrup.get_SelectedIndex() == 0;
					string imageName;
					int width;
					if (flag3)
					{
						imageName = "tekli2";
						width = 100;
					}
					else
					{
						imageName = "ciftli";
						width = 188;
					}
					int num = 100;
					this.panel1.Controls.Clear();
					int x = 10;
					bool flag4 = Convert.ToInt32(this.yanagirsayisi.Text) > 5;
					int num2;
					if (flag4)
					{
						num2 = 40;
					}
					else
					{
						num2 = 33;
					}
					for (int i = Convert.ToInt32(this.yanagirsayisi.Text); i > 0; i--)
					{
						bool flag5 = Convert.ToInt32(this.yanagirsayisi.Text) > 5;
						if (flag5)
						{
							bool flag6 = i == 3;
							if (flag6)
							{
								PictureBox pictureBox = new PictureBox();
								pictureBox.Name = "noktaname";
								pictureBox.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text + "_nokta");
								pictureBox.Padding = new Padding(0);
								pictureBox.Size = new Size(80, 25);
								num2 += 22;
								pictureBox.Location = new Point(x, num2);
								this.panel1.Controls.Add(pictureBox);
								num += 25;
							}
							else
							{
								bool flag7 = i < 4;
								if (flag7)
								{
									PictureBox pictureBox2 = new PictureBox();
									pictureBox2.Name = "name" + i;
									pictureBox2.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text);
									pictureBox2.Padding = new Padding(0);
									pictureBox2.Size = new Size(80, 25);
									num2 += 22;
									pictureBox2.Location = new Point(x, num2);
									this.panel1.Controls.Add(pictureBox2);
									num += 25;
								}
								else
								{
									bool flag8 = i == Convert.ToInt32(this.yanagirsayisi.Text) - 1;
									if (flag8)
									{
										PictureBox pictureBox3 = new PictureBox();
										pictureBox3.Name = "name" + (Convert.ToInt32(this.yanagirsayisi.Text) - 1);
										pictureBox3.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text);
										pictureBox3.Padding = new Padding(0);
										pictureBox3.Size = new Size(80, 25);
										num2 += 22;
										pictureBox3.Location = new Point(x, num2);
										this.panel1.Controls.Add(pictureBox3);
										num += 25;
									}
									else
									{
										bool flag9 = i == Convert.ToInt32(this.yanagirsayisi.Text);
										if (flag9)
										{
											PictureBox pictureBox4 = new PictureBox();
											pictureBox4.Name = "name" + Convert.ToInt32(this.yanagirsayisi.Text);
											pictureBox4.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text);
											pictureBox4.Padding = new Padding(0);
											pictureBox4.Size = new Size(80, 25);
											num2 += 22;
											pictureBox4.Location = new Point(x, num2);
											this.panel1.Controls.Add(pictureBox4);
											num += 25;
										}
									}
								}
							}
						}
						else
						{
							PictureBox pictureBox5 = new PictureBox();
							pictureBox5.Name = "name" + i;
							pictureBox5.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text);
							pictureBox5.Padding = new Padding(0);
							pictureBox5.Size = new Size(80, 25);
							num2 += 22;
							pictureBox5.Location = new Point(x, num2);
							this.panel1.Controls.Add(pictureBox5);
							num += 22;
						}
					}
					bool flag10 = this.karkasgrup.get_SelectedIndex() == 1;
					if (flag10)
					{
						num = 110;
						x = 97;
						bool flag11 = Convert.ToInt32(this.yanagirsayisi.Text) > 5;
						if (flag11)
						{
							num2 = 40;
						}
						else
						{
							num2 = 33;
						}
						for (int j = Convert.ToInt32(this.yanagirsayisi.Text); j > 0; j--)
						{
							bool flag12 = Convert.ToInt32(this.yanagirsayisi.Text) > 5;
							if (flag12)
							{
								bool flag13 = j == 3;
								if (flag13)
								{
									PictureBox pictureBox6 = new PictureBox();
									pictureBox6.Name = "noktaneme";
									pictureBox6.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text + "_nokta");
									pictureBox6.Padding = new Padding(0);
									pictureBox6.Size = new Size(80, 25);
									num2 += 22;
									pictureBox6.Location = new Point(x, num2);
									this.panel1.Controls.Add(pictureBox6);
									num += 25;
								}
								else
								{
									bool flag14 = j < 4;
									if (flag14)
									{
										PictureBox pictureBox7 = new PictureBox();
										pictureBox7.Name = "neme" + j;
										pictureBox7.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text);
										pictureBox7.Padding = new Padding(0);
										pictureBox7.Size = new Size(80, 25);
										num2 += 22;
										pictureBox7.Location = new Point(x, num2);
										this.panel1.Controls.Add(pictureBox7);
										num += 25;
									}
									else
									{
										bool flag15 = j == Convert.ToInt32(this.yanagirsayisi.Text) - 1;
										if (flag15)
										{
											PictureBox pictureBox8 = new PictureBox();
											pictureBox8.Name = "neme" + (Convert.ToInt32(this.yanagirsayisi.Text) - 1);
											pictureBox8.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text);
											pictureBox8.Padding = new Padding(0);
											pictureBox8.Size = new Size(80, 25);
											num2 += 22;
											pictureBox8.Location = new Point(x, num2);
											this.panel1.Controls.Add(pictureBox8);
											num += 25;
										}
										else
										{
											bool flag16 = j == Convert.ToInt32(this.yanagirsayisi.Text);
											if (flag16)
											{
												PictureBox pictureBox9 = new PictureBox();
												pictureBox9.Name = "neme" + Convert.ToInt32(this.yanagirsayisi.Text);
												pictureBox9.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text);
												pictureBox9.Padding = new Padding(0);
												pictureBox9.Size = new Size(80, 25);
												num2 += 22;
												pictureBox9.Location = new Point(x, num2);
												this.panel1.Controls.Add(pictureBox9);
												num += 25;
											}
										}
									}
								}
							}
							else
							{
								PictureBox pictureBox10 = new PictureBox();
								pictureBox10.Name = "neme" + j;
								pictureBox10.BackgroundImage = MainForm2.resourceimage(this.karsiagrsecim.Text);
								pictureBox10.Padding = new Padding(0);
								pictureBox10.Size = new Size(80, 25);
								num2 += 22;
								pictureBox10.Location = new Point(x, num2);
								this.panel1.Controls.Add(pictureBox10);
								num += 22;
							}
						}
					}
					PictureBox pictureBox11 = new PictureBox();
					pictureBox11.Name = "unal";
					pictureBox11.Location = new Point(0, 0);
					pictureBox11.Padding = new Padding(0);
					pictureBox11.Size = new Size(width, num);
					pictureBox11.Image = MainForm2.resourceimage(imageName);
					pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
					this.panel1.Controls.Add(pictureBox11);
				}
			}
		}

		private void karkasyaziyazar()
		{
			foreach (Control control in this.panel1.Controls)
			{
				bool flag = control.GetType() == typeof(PictureBox);
				if (flag)
				{
					Graphics graphics = control.CreateGraphics();
					bool flag2 = control.Name.StartsWith("name");
					if (flag2)
					{
						int num = 27 - Convert.ToInt32(Convert.ToInt32(control.Name.Substring(4))).ToString().Length * 2;
						graphics.DrawString(Convert.ToInt32(Convert.ToInt32(control.Name.Substring(4))).ToString(), new Font("Arial", 16f, FontStyle.Italic), new SolidBrush(Color.Black), (float)num, 0f);
					}
					bool flag3 = control.Name.StartsWith("neme");
					if (flag3)
					{
						int num2 = 27 - Convert.ToInt32(Convert.ToInt32(control.Name.Substring(4))).ToString().Length * 2;
						graphics.DrawString(Convert.ToInt32(Convert.ToInt32(control.Name.Substring(4))).ToString(), new Font("Arial", 16f, FontStyle.Italic), new SolidBrush(Color.Black), (float)num2, 0f);
					}
				}
			}
		}

		private void karkascizer2()
		{
			int width = 20;
			int height = 20;
			bool flag = this.yanagirsayisi.Text == "";
			if (!flag)
			{
				bool flag2 = this.karsiagrsecim.Text == "";
				if (!flag2)
				{
					bool flag3 = this.arkaagirsayisi.Text == "";
					if (!flag3)
					{
						int width2 = 15 + Convert.ToInt32(this.arkaagirsayisi.Text) * 25;
						int num = 110;
						for (int i = 1; i <= Convert.ToInt32(this.arkaagirsayisi.Text); i++)
						{
							num = 110;
							int x = 175 + i * 25;
							bool flag4 = Convert.ToInt32(this.yanagirsayisi.Text) > 5;
							int num2;
							if (flag4)
							{
								num2 = 40;
							}
							else
							{
								num2 = 33;
							}
							for (int j = 0; j < Convert.ToInt32(this.yanagirsayisi.Text); j++)
							{
								bool flag5 = Convert.ToInt32(this.yanagirsayisi.Text) > 5;
								if (flag5)
								{
									bool flag6 = j < 3;
									if (flag6)
									{
										PictureBox pictureBox = new PictureBox();
										pictureBox.Name = string.Concat(new object[]
										{
											"a",
											i,
											"yanname",
											j
										});
										pictureBox.BackgroundImage = MainForm2.resourceimage("yandan");
										pictureBox.Padding = new Padding(0);
										pictureBox.Size = new Size(width, height);
										num2 += 22;
										pictureBox.Location = new Point(x, num2);
										pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
										this.panel1.Controls.Add(pictureBox);
										num += 25;
									}
									else
									{
										bool flag7 = j == Convert.ToInt32(this.yanagirsayisi.Text) - 2;
										if (flag7)
										{
											PictureBox pictureBox2 = new PictureBox();
											pictureBox2.Name = string.Concat(new object[]
											{
												"a",
												i,
												"yanname",
												Convert.ToInt32(this.yanagirsayisi.Text) - 2
											});
											pictureBox2.BackgroundImage = MainForm2.resourceimage("yandan");
											pictureBox2.Padding = new Padding(0);
											pictureBox2.Size = new Size(width, height);
											num2 += 22;
											pictureBox2.Location = new Point(x, num2);
											pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
											this.panel1.Controls.Add(pictureBox2);
											num += 25;
										}
										else
										{
											bool flag8 = j == Convert.ToInt32(this.yanagirsayisi.Text) - 1;
											if (flag8)
											{
												PictureBox pictureBox3 = new PictureBox();
												pictureBox3.Name = string.Concat(new object[]
												{
													"a",
													i,
													"yanname",
													Convert.ToInt32(this.yanagirsayisi.Text) - 1
												});
												pictureBox3.BackgroundImage = MainForm2.resourceimage("yandan");
												pictureBox3.Padding = new Padding(0);
												pictureBox3.Size = new Size(width, height);
												num2 += 22;
												pictureBox3.Location = new Point(x, num2);
												pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
												this.panel1.Controls.Add(pictureBox3);
												num += 25;
											}
										}
									}
								}
								else
								{
									PictureBox pictureBox4 = new PictureBox();
									pictureBox4.Name = string.Concat(new object[]
									{
										"a",
										i,
										"yanname",
										j
									});
									pictureBox4.BackgroundImage = MainForm2.resourceimage("yandan");
									pictureBox4.Padding = new Padding(0);
									pictureBox4.Size = new Size(width, height);
									num2 += 22;
									pictureBox4.Location = new Point(x, num2);
									pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
									this.panel1.Controls.Add(pictureBox4);
									num += 22;
								}
							}
						}
						PictureBox pictureBox5 = new PictureBox();
						pictureBox5.Name = "yanunal";
						pictureBox5.Location = new Point(190, 0);
						pictureBox5.Padding = new Padding(0);
						bool flag9 = num > 235;
						if (flag9)
						{
							num = 235;
						}
						pictureBox5.Size = new Size(width2, num);
						pictureBox5.Image = MainForm2.resourceimage("a1");
						pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
						this.panel1.Controls.Add(pictureBox5);
					}
				}
			}
		}

		public static Bitmap resourceimage(string imageName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string baseName = executingAssembly.GetName().Name + ".Properties.Resources";
			ResourceManager resourceManager = new ResourceManager(baseName, executingAssembly);
			return (Bitmap)resourceManager.GetObject(imageName);
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

		private void karkascizerselectedindex(object sender, EventArgs e)
		{
			this.karkascizer();
			this.karkascizer2();
		}

		private void dosyaregulator_EditValueChanged(object sender, EventArgs e)
		{
			this.regulatormarka.set_EditValue(this.dosyaregulator.get_EditValue());
		}

		private void regulatormarka_EditValueChanged(object sender, EventArgs e)
		{
			this.dosyaregulator.set_EditValue(this.regulatormarka.get_EditValue());
		}

		private void baritdokumkendibilgisi_CheckedChanged(object sender, EventArgs e)
		{
			this.karsiagren.Enabled = true;
			this.karsiagrboy.Enabled = true;
			this.karsiagryukseklik.Enabled = true;
			this.karsiagrozgulkutle.Enabled = true;
			this.karsiagrbirimagirlik.Enabled = true;
			this.karsiagren.get_Properties().set_BorderStyle(7);
			this.karsiagrboy.get_Properties().set_BorderStyle(7);
			this.karsiagryukseklik.get_Properties().set_BorderStyle(7);
			this.karsiagrozgulkutle.get_Properties().set_BorderStyle(7);
			this.karsiagrbirimagirlik.get_Properties().set_BorderStyle(7);
			this.karsiagren.Enabled = false;
			this.karsiagrboy.Enabled = false;
			this.karsiagryukseklik.Enabled = false;
			this.karsiagrozgulkutle.Enabled = false;
			this.karsiagrbirimagirlik.Enabled = false;
			this.karsiagren.get_Properties().set_BorderStyle(0);
			this.karsiagrboy.get_Properties().set_BorderStyle(0);
			this.karsiagryukseklik.get_Properties().set_BorderStyle(0);
			this.karsiagrozgulkutle.get_Properties().set_BorderStyle(0);
			this.karsiagrbirimagirlik.get_Properties().set_BorderStyle(0);
		}

		private void karsiagrsecim_EditValueChanged(object sender, EventArgs e)
		{
			this.karsiagrmodel.get_Properties().set_DataSource(this.xx.dtta("select * from karsiagirlikbilgisi where cinsi=" + this.karsiagrsecim.get_EditValue(), ""));
			this.karsiagrmodel.get_Properties().set_DisplayMember("model");
			this.karsiagrmodel.get_Properties().set_ValueMember("sno");
		}

		private void karsiagrmodel_EditValueChanged(object sender, EventArgs e)
		{
			DataTable dataTable = this.xx.dtta("select * from karsiagirlikbilgisi where sno=" + this.karsiagrmodel.get_EditValue(), "");
			bool flag = dataTable.Rows.Count > 0;
			if (flag)
			{
				this.karsiagren.Text = dataTable.Rows[0]["en"].ToString();
				this.karsiagrboy.Text = dataTable.Rows[0]["boy"].ToString();
				this.karsiagryukseklik.Text = dataTable.Rows[0]["yukseklik"].ToString();
				this.karsiagrozgulkutle.Text = dataTable.Rows[0]["ozgulkutle"].ToString();
				this.karsiagrbirimagirlik.Text = dataTable.Rows[0]["birimagirlik"].ToString();
			}
		}

		private void gridviewdiller_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			this.xx.oleupdate(string.Concat(new string[]
			{
				"update diller set ",
				e.get_Column().get_FieldName(),
				"='",
				e.get_Value().ToString(),
				"' where number=",
				this.gridviewdiller.GetRowCellValue(e.get_RowHandle(), "number").ToString()
			}), "");
		}

		private void dileklemebuton_Click(object sender, EventArgs e)
		{
			new dilekler
			{
				dildata = this.dildata
			}.ShowDialog();
			this.gridviewdiller.get_Columns().Clear();
			DataTable dataTable = this.xx.dtta("select gorunurad,kisaad from dilcesitleri", "");
			string text = "";
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				text = text + dataTable.Rows[i]["kisaad"].ToString() + ",";
			}
			this.gridcontroldiller.set_DataSource(this.xx.dtta("select number," + text.Substring(0, text.Length - 1) + " from diller", ""));
			for (int j = 1; j < this.gridviewdiller.get_Columns().Count; j++)
			{
				this.gridviewdiller.get_Columns().get_Item(j).set_Caption(dataTable.Rows[j - 1]["gorunurad"].ToString());
			}
			this.gridviewdiller.get_Columns().get_Item(0).set_Visible(false);
			this.gridviewdiller.get_Columns().get_Item(0).get_OptionsColumn().set_AllowEdit(false);
			this.gridviewdiller.get_Columns().get_Item(1).get_OptionsColumn().set_AllowEdit(false);
		}

		public string hangi(SearchLookUpEdit s)
		{
			string result = "";
			bool flag = Convert.ToString(s.get_EditValue()) != "0" && Convert.ToString(s.get_EditValue()) != "-1" && Convert.ToString(s.get_EditValue()) != "";
			if (flag)
			{
				DataTable dataTable = this.xx.dtta("select tedarikid,guid,edit,model,malzeme,degisti from tedarik where guid='" + s.get_EditValue() + "'", "");
				string text = dataTable.Rows[0]["malzeme"].ToString();
				string text2 = dataTable.Rows[0]["tedarikid"].ToString();
				string text3 = dataTable.Rows[0]["edit"].ToString();
				bool flag2 = Convert.ToBoolean(dataTable.Rows[0]["degisti"]);
				string text4;
				if (flag2)
				{
					text4 = Application.StartupPath;
				}
				else
				{
					text4 = "http://www.misaasansor.com.tr/cert";
				}
				Process.Start(string.Concat(new string[]
				{
					text4,
					"\\sertifika\\",
					text,
					"\\",
					text2,
					"\\",
					text3
				}));
			}
			return result;
		}

		private void dosyapano_click(object sender, EventArgs e)
		{
			this.hangi(this.dosyapano);
		}

		private void dosyafrenblok_click(object sender, EventArgs e)
		{
			this.hangi(this.dosyafrenblok);
		}

		private void dosyaagrtampon_click(object sender, EventArgs e)
		{
			this.hangi(this.dosyaagrtampon);
		}

		private void dosyakabintampon_click(object sender, EventArgs e)
		{
			this.hangi(this.dosyakabintampon);
		}

		private void dosyakumandakarti_click(object sender, EventArgs e)
		{
			this.hangi(this.dosyakumandakarti);
		}

		private void dosyaregulator_click(object sender, EventArgs e)
		{
			this.hangi(this.dosyaregulator);
		}

		private void dosyaa3ekipman_click(object sender, EventArgs e)
		{
			this.hangi(this.dosyaa3ekipman);
		}

		private void dosyapistonvalfi_click(object sender, EventArgs e)
		{
			this.hangi(this.dosyapistonvalfi);
		}

		private void dosyakapikilitgor_Click(object sender, EventArgs e)
		{
			this.hangi(this.dosyakapikilit);
		}

		private void dosyafrenblok_EditValueChanged(object sender, EventArgs e)
		{
		}

		public void sertifikaiceriaktar(SearchLookUpEdit s, string malzeme)
		{
			s.get_Properties().set_DataSource(this.xx.dtta("select guid,nobo,tedarikid,uretici,model,concat(uretici , ' ' , model) as MARKA_MODEL, serino,belgeveren,degisti from tedarik where malzeme='" + malzeme + "' and gorunur=true", ""));
			s.get_Properties().set_DisplayMember("MARKA_MODEL");
			s.get_Properties().set_ValueMember("guid");
		}

		public void bacim()
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			bool flag = this.dosyamahalle.Text != "";
			if (flag)
			{
				text = this.dosyamahalle.Text + " MAH. ";
			}
			bool flag2 = this.dosyasokak.Text != "";
			if (flag2)
			{
				text2 = this.dosyasokak.Text + " SOK. ";
			}
			bool flag3 = this.dosyacadde.Text != "";
			if (flag3)
			{
				text3 = this.dosyacadde.Text + " CAD. ";
			}
			bool flag4 = this.dosyano.Text != "";
			if (flag4)
			{
				text4 = " NO:" + this.dosyano.Text + " ";
			}
			bool flag5 = this.dosyailce.Text != "";
			if (flag5)
			{
				text5 = this.dosyailce.Text + " / ";
			}
			bool flag6 = this.dosyail.Text != "";
			if (flag6)
			{
				text6 = this.dosyail.Text;
			}
			bool flag7 = this.dosyablok.Text != "";
			if (flag7)
			{
				text8 = this.dosyablok.Text + " BLOK ";
			}
			bool flag8 = this.dosyabulvar.Text != "";
			if (flag8)
			{
				text7 = this.dosyabulvar.Text + " BULVARI ";
			}
			this.dosyaadres.Text = string.Concat(new string[]
			{
				text,
				text3,
				text7,
				text2,
				text4,
				text8,
				text5,
				text6
			});
		}

		private void adresiolustur(object sender, EventArgs e)
		{
			this.bacim();
		}

		private void buyutur(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void kapiyeri(object sender, EventArgs e)
		{
			bool flag = this.ilklocationx == 0;
			if (flag)
			{
				this.ilklocationx = this.otokaptippicture.Location.X;
			}
			bool flag2 = this.ilklocationy == 0;
			if (flag2)
			{
				this.ilklocationy = this.otokaptippicture.Location.Y;
			}
			bool @checked = this.kuyuyaradio.Checked;
			if (@checked)
			{
				this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy);
				this.kuyuyatext.Enabled = true;
				this.kuyuyatext.get_Properties().set_BorderStyle(7);
				this.katatext.Enabled = false;
				this.katatext.get_Properties().set_BorderStyle(0);
			}
			else
			{
				bool checked2 = this.kataradio.Checked;
				if (checked2)
				{
					this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy);
					this.kuyuyatext.Enabled = false;
					this.kuyuyatext.get_Properties().set_BorderStyle(0);
					this.katatext.Enabled = true;
					this.katatext.get_Properties().set_BorderStyle(7);
				}
				else
				{
					bool checked3 = this.kathizasiradio.Checked;
					if (checked3)
					{
						this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy);
						this.kuyuyatext.Enabled = false;
						this.kuyuyatext.get_Properties().set_BorderStyle(0);
						this.katatext.Enabled = false;
						this.katatext.get_Properties().set_BorderStyle(0);
					}
				}
			}
			this.kuyuyatext_TextChanged(sender, e);
		}

		private void kuyuyatext_TextChanged(object sender, EventArgs e)
		{
			bool @checked = this.kuyuyaradio.Checked;
			if (@checked)
			{
				bool flag = this.kuyuyatext.Text != "";
				if (flag)
				{
					this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy - Convert.ToInt32(this.kuyuyatext.Text));
				}
			}
			else
			{
				bool checked2 = this.kataradio.Checked;
				if (checked2)
				{
					bool flag2 = this.katatext.Text != "";
					if (flag2)
					{
						this.otokaptippicture.Location = new Point(this.ilklocationx, this.ilklocationy + Convert.ToInt32(this.katatext.Text));
					}
				}
			}
		}

		private void sertifikaekler(object sender, ButtonPressedEventArgs e)
		{
			bool flag = e.get_Button().get_Kind().ToString() == "Plus" && e.get_Button().get_Index() == 1;
			if (flag)
			{
				new sertifikaekler
				{
					dildata = this.dildata
				}.ShowDialog();
				this.verilergeliyor();
			}
		}

		private void backstageViewButtonItem1_ItemClick(object sender, BackstageViewItemEventArgs e)
		{
			this.LiftDataform = this.asc.KapiDegerSet(this.LiftDataform);
			this.asc.LiftDataYaz(this.LiftDataform, this.AsansorSayisi.ToString());
			base.Close();
		}

		private void acilmayon_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.acilmayon.get_SelectedIndex() == 0;
			if (flag)
			{
				this.LiftDataform.Mentese = "SAG";
			}
			else
			{
				this.LiftDataform.Mentese = "SOL";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.karkasyaziyazar();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
		}

		private void checkEdit2_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.kapisolcheck.get_Checked();
			if (@checked)
			{
				this.kapisolimage.Image = MainForm2.resourceimage("sol");
			}
			else
			{
				this.kapisolimage.Image = null;
			}
			bool checked2 = this.kapisagcheck.get_Checked();
			if (checked2)
			{
				this.kapisagimage.Image = MainForm2.resourceimage("sag");
			}
			else
			{
				this.kapisagimage.Image = null;
			}
			bool checked3 = this.kapiarkacheck.get_Checked();
			if (checked3)
			{
				this.kapiarkaimage.Image = MainForm2.resourceimage("ust");
			}
			else
			{
				this.kapiarkaimage.Image = null;
			}
		}

		private void kapiarkasecenek_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void kapigen_EditValueChanged(object sender, EventArgs e)
		{
			this.LiftDataform.KapiGen = this.kapigen.Text;
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			this.sTT.TipKodu = "HA";
			this.xx.oleupdate(string.Concat(new object[]
			{
				"update Tahrik set YonKodu='",
				this.sTT.YonKodu,
				"' ,TipKodu='",
				this.sTT.TipKodu,
				"' , TahrikKodu='",
				this.sTT.TahrikKodu,
				"' where LiftNumber='",
				this.AsansorSayisi,
				"'"
			}), "");
			this.asc.HAMDDegerSet("SAG", this.sTT.YonKodu, "3000", "KuyuDer", this.AsansorSayisi.ToString());
		}

		private void backstageViewClientControl1_Load(object sender, EventArgs e)
		{
		}

		private void backstageViewClientControl2_Load(object sender, EventArgs e)
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
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm2));
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
			this.backstageViewControl1.BeginInit();
			this.backstageViewControl1.SuspendLayout();
			this.backstageViewClientControl2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.kapitipi.get_Properties().BeginInit();
			this.layoutControl7.BeginInit();
			this.layoutControl7.SuspendLayout();
			((ISupportInitialize)this.kapiarkaimage).BeginInit();
			((ISupportInitialize)this.kapionimage).BeginInit();
			((ISupportInitialize)this.kapisagimage).BeginInit();
			((ISupportInitialize)this.kapisolimage).BeginInit();
			((ISupportInitialize)this.kapikabinimage).BeginInit();
			this.layoutControlGroup2.BeginInit();
			this.layoutControlItem26.BeginInit();
			this.layoutControlItem29.BeginInit();
			this.layoutControlItem31.BeginInit();
			this.layoutControlItem33.BeginInit();
			this.layoutControlItem34.BeginInit();
			this.groupControl5.BeginInit();
			this.groupControl5.SuspendLayout();
			this.kuyuyatext.get_Properties().BeginInit();
			this.katatext.get_Properties().BeginInit();
			this.kapisagcheck.get_Properties().BeginInit();
			this.kapiarkacheck.get_Properties().BeginInit();
			this.kapisolcheck.get_Properties().BeginInit();
			this.labelkapitipsecimi.BeginInit();
			this.labelkapitipsecimi.SuspendLayout();
			this.layoutControl8.BeginInit();
			this.layoutControl8.SuspendLayout();
			this.acilmayon.get_Properties().BeginInit();
			this.kapigen.get_Properties().BeginInit();
			this.kapimmarmodel.get_Properties().BeginInit();
			this.yangindayanim.get_Properties().BeginInit();
			this.kapikaplama.get_Properties().BeginInit();
			this.layoutControlGroup3.BeginInit();
			this.labelkapigenisligi.BeginInit();
			this.labelkapikaplamasi.BeginInit();
			this.labelkapikaplamamarka.BeginInit();
			this.labelyangindayanim.BeginInit();
			this.layoutControlItem12.BeginInit();
			this.otokaptippicture.get_Properties().BeginInit();
			this.kapitippicture.get_Properties().BeginInit();
			this.otokaptip.get_Properties().BeginInit();
			this.backstageViewClientControl3.SuspendLayout();
			this.layoutControl3.BeginInit();
			this.layoutControl3.SuspendLayout();
			this.dengekatsayisi.get_Properties().BeginInit();
			this.karkasgrup.get_Properties().BeginInit();
			this.karsiagrozgulkutle.get_Properties().BeginInit();
			this.karsiagrbirimagirlik.get_Properties().BeginInit();
			this.karkasagirlik.get_Properties().BeginInit();
			this.arkaagirsayisi.get_Properties().BeginInit();
			this.yanagirsayisi.get_Properties().BeginInit();
			this.karsiagryukseklik.get_Properties().BeginInit();
			this.karsiagrboy.get_Properties().BeginInit();
			this.regulatormarka.get_Properties().BeginInit();
			this.gridView3.BeginInit();
			this.karsiagren.get_Properties().BeginInit();
			this.karsiagrsecim.get_Properties().BeginInit();
			this.karsiagrmodel.get_Properties().BeginInit();
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
			this.dosyahortumserino.get_Properties().BeginInit();
			this.dosyahortumonaylayan.get_Properties().BeginInit();
			this.dosyahortumbelgeno.get_Properties().BeginInit();
			this.dosyahortummodel.get_Properties().BeginInit();
			this.dosyahortumuretici.get_Properties().BeginInit();
			this.dosyadebiserino.get_Properties().BeginInit();
			this.dosyadebionaylayan.get_Properties().BeginInit();
			this.dosyadebibelgeno.get_Properties().BeginInit();
			this.dosyadebimodel.get_Properties().BeginInit();
			this.dosyadebiuret.get_Properties().BeginInit();
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
			this.dosyamotorserino.get_Properties().BeginInit();
			this.dosyamotoronaylayan.get_Properties().BeginInit();
			this.dosyamotorbelgeno.get_Properties().BeginInit();
			this.dosyamotormodel.get_Properties().BeginInit();
			this.dosyamotoruretici.get_Properties().BeginInit();
			this.dosyamakineurserno.get_Properties().BeginInit();
			this.dosyamakineonaylayan.get_Properties().BeginInit();
			this.dosyamakinebelgeno.get_Properties().BeginInit();
			this.dosyamakinemodel.get_Properties().BeginInit();
			this.dosyamakineuret.get_Properties().BeginInit();
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
			this.dosyakapikilit.get_Properties().BeginInit();
			this.gridView1.BeginInit();
			this.dosyapanosn.get_Properties().BeginInit();
			this.dosyapano.get_Properties().BeginInit();
			this.searchLookUpEdit6View.BeginInit();
			this.dosyapistonvalfisn.get_Properties().BeginInit();
			this.dosyaa3ekipmansn.get_Properties().BeginInit();
			this.dosyaregulatorsn.get_Properties().BeginInit();
			this.dosyakumandakartisn.get_Properties().BeginInit();
			this.dosyakabintamponsn.get_Properties().BeginInit();
			this.dosyaagrtamponsn.get_Properties().BeginInit();
			this.dosyafrenbloksn.get_Properties().BeginInit();
			this.dosyakapikilitsn.get_Properties().BeginInit();
			this.dosyapistonvalfi.get_Properties().BeginInit();
			this.searchLookUpEdit9View.BeginInit();
			this.dosyaa3ekipman.get_Properties().BeginInit();
			this.searchLookUpEdit8View.BeginInit();
			this.dosyaregulator.get_Properties().BeginInit();
			this.searchLookUpEdit7View.BeginInit();
			this.dosyakumandakarti.get_Properties().BeginInit();
			this.searchLookUpEdit5View.BeginInit();
			this.dosyakabintampon.get_Properties().BeginInit();
			this.searchLookUpEdit4View.BeginInit();
			this.dosyaagrtampon.get_Properties().BeginInit();
			this.searchLookUpEdit3View.BeginInit();
			this.dosyafrenblok.get_Properties().BeginInit();
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
			this.dosyamutaahhitvd.get_Properties().BeginInit();
			this.dosyamutaahhitvn.get_Properties().BeginInit();
			this.dosyamutaahhittc.get_Properties().BeginInit();
			this.dosyamutaahhit.get_Properties().BeginInit();
			this.dosyabinasahipvd.get_Properties().BeginInit();
			this.dosyabinasahipvn.get_Properties().BeginInit();
			this.dosyabinasahiptc.get_Properties().BeginInit();
			this.dosyabinasahip.get_Properties().BeginInit();
			this.dosyaservistar.get_Properties().BeginInit();
			this.dosyaasansorno.get_Properties().BeginInit();
			this.dosyasinif.get_Properties().BeginInit();
			this.dosyaparsel.get_Properties().BeginInit();
			this.dosyaada.get_Properties().BeginInit();
			this.dosyapafta.get_Properties().BeginInit();
			this.dosyabelediye.get_Properties().BeginInit();
			this.dosyailce.get_Properties().BeginInit();
			this.dosyail.get_Properties().BeginInit();
			this.dosyablok.get_Properties().BeginInit();
			this.dosyano.get_Properties().BeginInit();
			this.dosyabulvar.get_Properties().BeginInit();
			this.dosyacadde.get_Properties().BeginInit();
			this.dosyasokak.get_Properties().BeginInit();
			this.dosyamahalle.get_Properties().BeginInit();
			this.dosyaasansorsahib.get_Properties().BeginInit();
			this.dosyabelgemodul.get_Properties().BeginInit();
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
			this.dilsecimi.get_Properties().BeginInit();
			this.gorunumayar.get_Properties().BeginInit();
			this.layoutControlGroup6.BeginInit();
			this.labelgorunumayar.BeginInit();
			this.labeldilsecimi.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem10.BeginInit();
			base.SuspendLayout();
			this.backstageViewControl1.set_ColorScheme(0);
			this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
			this.backstageViewControl1.Controls.Add(this.backstageViewClientControl2);
			this.backstageViewControl1.Controls.Add(this.backstageViewClientControl6);
			this.backstageViewControl1.Controls.Add(this.backstageViewClientControl3);
			this.backstageViewControl1.Controls.Add(this.backstageViewClientControl5);
			this.backstageViewControl1.Controls.Add(this.backstageViewClientControl4);
			this.backstageViewControl1.Dock = DockStyle.Fill;
			this.backstageViewControl1.get_Items().Add(this.backstageViewTabItem1);
			this.backstageViewControl1.get_Items().Add(this.backstageViewTabItem2);
			this.backstageViewControl1.get_Items().Add(this.backstageViewTabItem6);
			this.backstageViewControl1.get_Items().Add(this.backstageViewTabItem3);
			this.backstageViewControl1.get_Items().Add(this.backstageViewTabItem5);
			this.backstageViewControl1.get_Items().Add(this.backstageViewTabItem4);
			this.backstageViewControl1.get_Items().Add(this.backstageViewButtonItem1);
			this.backstageViewControl1.Location = new Point(0, 0);
			this.backstageViewControl1.Name = "backstageViewControl1";
			this.backstageViewControl1.set_SelectedTab(this.backstageViewTabItem2);
			this.backstageViewControl1.set_SelectedTabIndex(1);
			this.backstageViewControl1.Size = new Size(1310, 817);
			this.backstageViewControl1.TabIndex = 0;
			this.backstageViewControl1.Text = "backstageViewControl1";
			this.backstageViewClientControl1.set_Location(new Point(165, 0));
			this.backstageViewClientControl1.Name = "backstageViewClientControl1";
			this.backstageViewClientControl1.set_Size(new Size(1145, 817));
			this.backstageViewClientControl1.TabIndex = 0;
			this.backstageViewClientControl1.Load += new EventHandler(this.backstageViewClientControl1_Load);
			this.backstageViewClientControl2.Controls.Add(this.groupBox2);
			this.backstageViewClientControl2.Controls.Add(this.layoutControl7);
			this.backstageViewClientControl2.Controls.Add(this.groupControl5);
			this.backstageViewClientControl2.Controls.Add(this.kapisagcheck);
			this.backstageViewClientControl2.Controls.Add(this.kapiarkacheck);
			this.backstageViewClientControl2.Controls.Add(this.kapisolcheck);
			this.backstageViewClientControl2.Controls.Add(this.labelkapitipsecimi);
			this.backstageViewClientControl2.set_Location(new Point(165, 0));
			this.backstageViewClientControl2.Name = "backstageViewClientControl2";
			this.backstageViewClientControl2.set_Size(new Size(1145, 817));
			this.backstageViewClientControl2.TabIndex = 1;
			this.backstageViewClientControl2.Load += new EventHandler(this.backstageViewClientControl2_Load);
			this.groupBox2.Controls.Add(this.kapitipi);
			this.groupBox2.Location = new Point(303, 566);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(427, 110);
			this.groupBox2.TabIndex = 56;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "KABİN KAPSII";
			this.kapitipi.Location = new Point(6, 20);
			this.kapitipi.Name = "kapitipi";
			this.kapitipi.get_Properties().get_Appearance().set_BackColor(SystemColors.Control);
			this.kapitipi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.kapitipi.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.kapitipi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kapitipi.get_Properties().get_Items().AddRange(new RadioGroupItem[]
			{
				new RadioGroupItem(1, "Tam Otomatik"),
				new RadioGroupItem(2, "Yarım Otomatik"),
				new RadioGroupItem(3, "Kramer Kapılı"),
				new RadioGroupItem(4, "Dikey Kapılı"),
				new RadioGroupItem(5, "İç Kapısız")
			});
			this.kapitipi.Size = new Size(397, 82);
			this.kapitipi.TabIndex = 1;
			this.kapitipi.add_SelectedIndexChanged(new EventHandler(this.kapitipi_SelectedIndexChanged));
			this.layoutControl7.Controls.Add(this.kapiarkaimage);
			this.layoutControl7.Controls.Add(this.kapionimage);
			this.layoutControl7.Controls.Add(this.kapisagimage);
			this.layoutControl7.Controls.Add(this.kapisolimage);
			this.layoutControl7.Controls.Add(this.kapikabinimage);
			this.layoutControl7.Location = new Point(42, 143);
			this.layoutControl7.Name = "layoutControl7";
			this.layoutControl7.set_Root(this.layoutControlGroup2);
			this.layoutControl7.Size = new Size(200, 200);
			this.layoutControl7.TabIndex = 49;
			this.layoutControl7.Text = "layoutControl7";
			this.kapiarkaimage.Location = new Point(30, 0);
			this.kapiarkaimage.Name = "kapiarkaimage";
			this.kapiarkaimage.Size = new Size(140, 30);
			this.kapiarkaimage.TabIndex = 51;
			this.kapiarkaimage.TabStop = false;
			this.kapionimage.Image = (Image)componentResourceManager.GetObject("kapionimage.Image");
			this.kapionimage.Location = new Point(30, 170);
			this.kapionimage.Name = "kapionimage";
			this.kapionimage.Size = new Size(140, 30);
			this.kapionimage.TabIndex = 50;
			this.kapionimage.TabStop = false;
			this.kapisagimage.Location = new Point(170, 0);
			this.kapisagimage.Name = "kapisagimage";
			this.kapisagimage.Size = new Size(30, 200);
			this.kapisagimage.TabIndex = 49;
			this.kapisagimage.TabStop = false;
			this.kapisolimage.Location = new Point(0, 0);
			this.kapisolimage.Name = "kapisolimage";
			this.kapisolimage.Size = new Size(30, 200);
			this.kapisolimage.TabIndex = 48;
			this.kapisolimage.TabStop = false;
			this.kapikabinimage.Image = (Image)componentResourceManager.GetObject("kapikabinimage.Image");
			this.kapikabinimage.Location = new Point(30, 30);
			this.kapikabinimage.Name = "kapikabinimage";
			this.kapikabinimage.Size = new Size(140, 140);
			this.kapikabinimage.TabIndex = 39;
			this.kapikabinimage.TabStop = false;
			this.layoutControlGroup2.set_CustomizationFormText("layoutControlGroup2");
			this.layoutControlGroup2.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup2.set_GroupBordersVisible(false);
			this.layoutControlGroup2.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem26,
				this.layoutControlItem29,
				this.layoutControlItem31,
				this.layoutControlItem33,
				this.layoutControlItem34
			});
			this.layoutControlGroup2.set_Location(new Point(0, 0));
			this.layoutControlGroup2.set_Name("layoutControlGroup2");
			this.layoutControlGroup2.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlGroup2.set_Size(new Size(200, 200));
			this.layoutControlGroup2.set_TextVisible(false);
			this.layoutControlItem26.set_Control(this.kapisolimage);
			this.layoutControlItem26.set_CustomizationFormText("layoutControlItem26");
			this.layoutControlItem26.set_Location(new Point(0, 0));
			this.layoutControlItem26.set_MaxSize(new Size(30, 200));
			this.layoutControlItem26.set_MinSize(new Size(30, 200));
			this.layoutControlItem26.set_Name("layoutControlItem26");
			this.layoutControlItem26.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlItem26.set_Size(new Size(30, 200));
			this.layoutControlItem26.set_SizeConstraintsType(2);
			this.layoutControlItem26.set_TextSize(new Size(0, 0));
			this.layoutControlItem26.set_TextVisible(false);
			this.layoutControlItem29.set_Control(this.kapikabinimage);
			this.layoutControlItem29.set_CustomizationFormText("layoutControlItem29");
			this.layoutControlItem29.set_Location(new Point(30, 30));
			this.layoutControlItem29.set_MaxSize(new Size(140, 140));
			this.layoutControlItem29.set_MinSize(new Size(140, 140));
			this.layoutControlItem29.set_Name("layoutControlItem29");
			this.layoutControlItem29.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlItem29.set_Size(new Size(140, 140));
			this.layoutControlItem29.set_SizeConstraintsType(2);
			this.layoutControlItem29.set_TextSize(new Size(0, 0));
			this.layoutControlItem29.set_TextVisible(false);
			this.layoutControlItem31.set_Control(this.kapisagimage);
			this.layoutControlItem31.set_CustomizationFormText("layoutControlItem31");
			this.layoutControlItem31.set_Location(new Point(170, 0));
			this.layoutControlItem31.set_MaxSize(new Size(30, 200));
			this.layoutControlItem31.set_MinSize(new Size(30, 200));
			this.layoutControlItem31.set_Name("layoutControlItem31");
			this.layoutControlItem31.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlItem31.set_Size(new Size(30, 200));
			this.layoutControlItem31.set_SizeConstraintsType(2);
			this.layoutControlItem31.set_TextSize(new Size(0, 0));
			this.layoutControlItem31.set_TextVisible(false);
			this.layoutControlItem33.set_Control(this.kapionimage);
			this.layoutControlItem33.set_CustomizationFormText("layoutControlItem33");
			this.layoutControlItem33.set_Location(new Point(30, 170));
			this.layoutControlItem33.set_MaxSize(new Size(140, 30));
			this.layoutControlItem33.set_MinSize(new Size(140, 30));
			this.layoutControlItem33.set_Name("layoutControlItem33");
			this.layoutControlItem33.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlItem33.set_Size(new Size(140, 30));
			this.layoutControlItem33.set_SizeConstraintsType(2);
			this.layoutControlItem33.set_TextSize(new Size(0, 0));
			this.layoutControlItem33.set_TextVisible(false);
			this.layoutControlItem34.set_Control(this.kapiarkaimage);
			this.layoutControlItem34.set_CustomizationFormText("layoutControlItem34");
			this.layoutControlItem34.set_Location(new Point(30, 0));
			this.layoutControlItem34.set_MaxSize(new Size(140, 30));
			this.layoutControlItem34.set_MinSize(new Size(140, 30));
			this.layoutControlItem34.set_Name("layoutControlItem34");
			this.layoutControlItem34.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlItem34.set_Size(new Size(140, 30));
			this.layoutControlItem34.set_SizeConstraintsType(2);
			this.layoutControlItem34.set_TextSize(new Size(0, 0));
			this.layoutControlItem34.set_TextVisible(false);
			this.groupControl5.Controls.Add(this.kuyuyatext);
			this.groupControl5.Controls.Add(this.katatext);
			this.groupControl5.Controls.Add(this.kuyuyaradio);
			this.groupControl5.Controls.Add(this.kataradio);
			this.groupControl5.Controls.Add(this.kathizasiradio);
			this.groupControl5.Location = new Point(28, 401);
			this.groupControl5.Name = "groupControl5";
			this.groupControl5.set_ShowCaption(false);
			this.groupControl5.Size = new Size(201, 83);
			this.groupControl5.TabIndex = 37;
			this.groupControl5.Text = "groupControl5";
			this.kuyuyatext.Enabled = false;
			this.kuyuyatext.Location = new Point(5, 5);
			this.kuyuyatext.Name = "kuyuyatext";
			this.kuyuyatext.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.kuyuyatext.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kuyuyatext.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.kuyuyatext.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.kuyuyatext.get_Properties().set_BorderStyle(0);
			this.kuyuyatext.Size = new Size(85, 20);
			this.kuyuyatext.TabIndex = 15;
			this.kuyuyatext.TextChanged += new EventHandler(this.kuyuyatext_TextChanged);
			this.kuyuyatext.KeyDown += new KeyEventHandler(this.int_KeyDown);
			this.kuyuyatext.KeyPress += new KeyPressEventHandler(this.int_KeyPress);
			this.katatext.Enabled = false;
			this.katatext.Location = new Point(5, 52);
			this.katatext.Name = "katatext";
			this.katatext.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.katatext.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.katatext.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.katatext.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.katatext.get_Properties().set_BorderStyle(0);
			this.katatext.Size = new Size(85, 20);
			this.katatext.TabIndex = 17;
			this.katatext.TextChanged += new EventHandler(this.kuyuyatext_TextChanged);
			this.katatext.KeyDown += new KeyEventHandler(this.int_KeyDown);
			this.katatext.KeyPress += new KeyPressEventHandler(this.int_KeyPress);
			this.kuyuyaradio.CheckAlign = ContentAlignment.MiddleRight;
			this.kuyuyaradio.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162);
			this.kuyuyaradio.Location = new Point(96, 4);
			this.kuyuyaradio.Name = "kuyuyaradio";
			this.kuyuyaradio.Size = new Size(87, 25);
			this.kuyuyaradio.TabIndex = 18;
			this.kuyuyaradio.TabStop = true;
			this.kuyuyaradio.Text = "Kuyuya";
			this.kuyuyaradio.UseVisualStyleBackColor = true;
			this.kuyuyaradio.CheckedChanged += new EventHandler(this.kapiyeri);
			this.kataradio.CheckAlign = ContentAlignment.MiddleRight;
			this.kataradio.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162);
			this.kataradio.Location = new Point(96, 51);
			this.kataradio.Name = "kataradio";
			this.kataradio.RightToLeft = RightToLeft.No;
			this.kataradio.Size = new Size(87, 25);
			this.kataradio.TabIndex = 20;
			this.kataradio.TabStop = true;
			this.kataradio.Text = "Kata";
			this.kataradio.UseVisualStyleBackColor = true;
			this.kataradio.CheckedChanged += new EventHandler(this.kapiyeri);
			this.kathizasiradio.CheckAlign = ContentAlignment.MiddleRight;
			this.kathizasiradio.Checked = true;
			this.kathizasiradio.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162);
			this.kathizasiradio.Location = new Point(96, 27);
			this.kathizasiradio.Name = "kathizasiradio";
			this.kathizasiradio.Size = new Size(87, 25);
			this.kathizasiradio.TabIndex = 19;
			this.kathizasiradio.TabStop = true;
			this.kathizasiradio.Text = "Kat Hizası";
			this.kathizasiradio.UseVisualStyleBackColor = true;
			this.kathizasiradio.CheckedChanged += new EventHandler(this.kapiyeri);
			this.kapisagcheck.Location = new Point(248, 241);
			this.kapisagcheck.Name = "kapisagcheck";
			this.kapisagcheck.get_Properties().set_Caption("");
			this.kapisagcheck.Size = new Size(20, 19);
			this.kapisagcheck.TabIndex = 42;
			this.kapisagcheck.add_CheckedChanged(new EventHandler(this.checkEdit2_CheckedChanged));
			this.kapiarkacheck.Location = new Point(136, 118);
			this.kapiarkacheck.Name = "kapiarkacheck";
			this.kapiarkacheck.get_Properties().set_Caption("");
			this.kapiarkacheck.Size = new Size(20, 19);
			this.kapiarkacheck.TabIndex = 41;
			this.kapiarkacheck.add_CheckedChanged(new EventHandler(this.checkEdit2_CheckedChanged));
			this.kapisolcheck.Location = new Point(16, 241);
			this.kapisolcheck.Name = "kapisolcheck";
			this.kapisolcheck.get_Properties().set_Caption("");
			this.kapisolcheck.Size = new Size(20, 19);
			this.kapisolcheck.TabIndex = 40;
			this.kapisolcheck.add_CheckedChanged(new EventHandler(this.checkEdit2_CheckedChanged));
			this.labelkapitipsecimi.get_AppearanceCaption().set_Font(new Font("Tahoma", 12f, FontStyle.Bold));
			this.labelkapitipsecimi.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.labelkapitipsecimi.Controls.Add(this.layoutControl8);
			this.labelkapitipsecimi.Controls.Add(this.otokaptippicture);
			this.labelkapitipsecimi.Controls.Add(this.kapitippicture);
			this.labelkapitipsecimi.Controls.Add(this.otokaptip);
			this.labelkapitipsecimi.Location = new Point(295, 19);
			this.labelkapitipsecimi.Name = "labelkapitipsecimi";
			this.labelkapitipsecimi.set_ShowCaption(false);
			this.labelkapitipsecimi.Size = new Size(697, 465);
			this.labelkapitipsecimi.TabIndex = 34;
			this.labelkapitipsecimi.Text = "KAPI TİPİ SEÇİMİ";
			this.layoutControl8.Controls.Add(this.acilmayon);
			this.layoutControl8.Controls.Add(this.kapigen);
			this.layoutControl8.Controls.Add(this.kapimmarmodel);
			this.layoutControl8.Controls.Add(this.yangindayanim);
			this.layoutControl8.Controls.Add(this.kapikaplama);
			this.layoutControl8.Location = new Point(5, 176);
			this.layoutControl8.Name = "layoutControl8";
			this.layoutControl8.set_Root(this.layoutControlGroup3);
			this.layoutControl8.Size = new Size(414, 192);
			this.layoutControl8.TabIndex = 56;
			this.layoutControl8.Text = "layoutControl8";
			this.acilmayon.Location = new Point(129, 111);
			this.acilmayon.Name = "acilmayon";
			this.acilmayon.get_Properties().get_Appearance().set_BackColor(SystemColors.Control);
			this.acilmayon.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.acilmayon.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.acilmayon.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.acilmayon.get_Properties().get_Items().AddRange(new RadioGroupItem[]
			{
				new RadioGroupItem(1, "Sağ"),
				new RadioGroupItem(2, "Sol"),
				new RadioGroupItem(3, "Merkezi")
			});
			this.acilmayon.Size = new Size(278, 74);
			this.acilmayon.set_StyleController(this.layoutControl8);
			this.acilmayon.TabIndex = 8;
			this.acilmayon.add_SelectedIndexChanged(new EventHandler(this.acilmayon_SelectedIndexChanged));
			this.kapigen.Location = new Point(129, 33);
			this.kapigen.Name = "kapigen";
			this.kapigen.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.kapigen.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kapigen.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.kapigen.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.kapigen.Size = new Size(278, 22);
			this.kapigen.set_StyleController(this.layoutControl8);
			this.kapigen.TabIndex = 5;
			this.kapigen.add_EditValueChanged(new EventHandler(this.kapigen_EditValueChanged));
			this.kapimmarmodel.Location = new Point(129, 7);
			this.kapimmarmodel.Name = "kapimmarmodel";
			this.kapimmarmodel.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.kapimmarmodel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kapimmarmodel.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.kapimmarmodel.get_Properties().get_Columns().AddRange(new LookUpColumnInfo[]
			{
				new LookUpColumnInfo("marka", "Marka"),
				new LookUpColumnInfo("sno", "No", 20, 0, "", false, 0)
			});
			this.kapimmarmodel.get_Properties().set_NullText("");
			this.kapimmarmodel.get_Properties().set_PopupSizeable(false);
			this.kapimmarmodel.get_Properties().set_TextEditStyle(0);
			this.kapimmarmodel.Size = new Size(278, 22);
			this.kapimmarmodel.set_StyleController(this.layoutControl8);
			this.kapimmarmodel.TabIndex = 15;
			this.kapimmarmodel.add_EditValueChanged(new EventHandler(this.kapikaplamamarka_EditValueChanged));
			this.yangindayanim.Location = new Point(129, 59);
			this.yangindayanim.Name = "yangindayanim";
			this.yangindayanim.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.yangindayanim.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.yangindayanim.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.yangindayanim.get_Properties().get_Columns().AddRange(new LookUpColumnInfo[]
			{
				new LookUpColumnInfo("yangin", "Yangın Dayanımı"),
				new LookUpColumnInfo("no", "No", 20, 0, "", false, 0)
			});
			this.yangindayanim.get_Properties().set_NullText("");
			this.yangindayanim.get_Properties().set_PopupSizeable(false);
			this.yangindayanim.get_Properties().set_TextEditStyle(0);
			this.yangindayanim.Size = new Size(278, 22);
			this.yangindayanim.set_StyleController(this.layoutControl8);
			this.yangindayanim.TabIndex = 0;
			this.yangindayanim.add_EditValueChanged(new EventHandler(this.yangindayanim_EditValueChanged));
			this.kapikaplama.Location = new Point(129, 85);
			this.kapikaplama.Name = "kapikaplama";
			this.kapikaplama.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 10f));
			this.kapikaplama.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kapikaplama.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.kapikaplama.get_Properties().get_Columns().AddRange(new LookUpColumnInfo[]
			{
				new LookUpColumnInfo("kaplama", "Kapı Kaplaması"),
				new LookUpColumnInfo("no", "No", 20, 0, "", false, 0)
			});
			this.kapikaplama.get_Properties().set_NullText("");
			this.kapikaplama.get_Properties().set_PopupSizeable(false);
			this.kapikaplama.get_Properties().set_TextEditStyle(0);
			this.kapikaplama.Size = new Size(278, 22);
			this.kapikaplama.set_StyleController(this.layoutControl8);
			this.kapikaplama.TabIndex = 13;
			this.kapikaplama.add_EditValueChanged(new EventHandler(this.kapikaplama_EditValueChanged));
			this.layoutControlGroup3.set_CustomizationFormText("layoutControlGroup3");
			this.layoutControlGroup3.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup3.set_GroupBordersVisible(false);
			this.layoutControlGroup3.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.labelkapigenisligi,
				this.labelkapikaplamasi,
				this.labelkapikaplamamarka,
				this.labelyangindayanim,
				this.layoutControlItem12
			});
			this.layoutControlGroup3.set_Location(new Point(0, 0));
			this.layoutControlGroup3.set_Name("layoutControlGroup3");
			this.layoutControlGroup3.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup3.set_Size(new Size(414, 192));
			this.layoutControlGroup3.set_TextVisible(false);
			this.labelkapigenisligi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelkapigenisligi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labelkapigenisligi.set_Control(this.kapigen);
			this.labelkapigenisligi.set_CustomizationFormText("Kapı Genişliği : ");
			this.labelkapigenisligi.set_Location(new Point(0, 26));
			this.labelkapigenisligi.set_Name("labelkapigenisligi");
			this.labelkapigenisligi.set_Size(new Size(404, 26));
			this.labelkapigenisligi.set_Text("Kapı Genişliği : ");
			this.labelkapigenisligi.set_TextSize(new Size(119, 16));
			this.labelkapikaplamasi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.labelkapikaplamasi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labelkapikaplamasi.set_Control(this.kapikaplama);
			this.labelkapikaplamasi.set_CustomizationFormText("Kapı Kaplaması : ");
			this.labelkapikaplamasi.set_Location(new Point(0, 78));
			this.labelkapikaplamasi.set_Name("labelkapikaplamasi");
			this.labelkapikaplamasi.set_Size(new Size(404, 26));
			this.labelkapikaplamasi.set_Text("Kapı Kaplaması : ");
			this.labelkapikaplamasi.set_TextSize(new Size(119, 16));
			this.labelkapikaplamamarka.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.labelkapikaplamamarka.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labelkapikaplamamarka.set_Control(this.kapimmarmodel);
			this.labelkapikaplamamarka.set_CustomizationFormText("Marka : ");
			this.labelkapikaplamamarka.set_Location(new Point(0, 0));
			this.labelkapikaplamamarka.set_Name("labelkapikaplamamarka");
			this.labelkapikaplamamarka.set_Size(new Size(404, 26));
			this.labelkapikaplamamarka.set_Text("Marka : ");
			this.labelkapikaplamamarka.set_TextSize(new Size(119, 16));
			this.labelyangindayanim.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.labelyangindayanim.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labelyangindayanim.set_Control(this.yangindayanim);
			this.labelyangindayanim.set_CustomizationFormText("Yangın Dayanımı : ");
			this.labelyangindayanim.set_Location(new Point(0, 52));
			this.labelyangindayanim.set_Name("labelyangindayanim");
			this.labelyangindayanim.set_Size(new Size(404, 26));
			this.labelyangindayanim.set_Text("Yangın Dayanımı : ");
			this.labelyangindayanim.set_TextSize(new Size(119, 16));
			this.layoutControlItem12.set_Control(this.acilmayon);
			this.layoutControlItem12.set_CustomizationFormText("layoutControlItem12");
			this.layoutControlItem12.set_Location(new Point(0, 104));
			this.layoutControlItem12.set_Name("layoutControlItem12");
			this.layoutControlItem12.set_Size(new Size(404, 78));
			this.layoutControlItem12.set_TextSize(new Size(119, 13));
			this.otokaptippicture.BackgroundImageLayout = ImageLayout.None;
			this.otokaptippicture.set_EditValue(componentResourceManager.GetObject("otokaptippicture.EditValue"));
			this.otokaptippicture.ImeMode = ImeMode.NoControl;
			this.otokaptippicture.Location = new Point(483, 267);
			this.otokaptippicture.Name = "otokaptippicture";
			this.otokaptippicture.get_Properties().get_Appearance().set_BackColor(SystemColors.Control);
			this.otokaptippicture.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.otokaptippicture.get_Properties().set_SizeMode(5);
			this.otokaptippicture.get_Properties().set_ZoomAccelerationFactor(1.0);
			this.otokaptippicture.Size = new Size(134, 112);
			this.otokaptippicture.TabIndex = 39;
			this.kapitippicture.set_EditValue(componentResourceManager.GetObject("kapitippicture.EditValue"));
			this.kapitippicture.Location = new Point(420, 147);
			this.kapitippicture.Name = "kapitippicture";
			this.kapitippicture.get_Properties().get_Appearance().set_BackColor(SystemColors.Control);
			this.kapitippicture.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.kapitippicture.get_Properties().set_SizeMode(5);
			this.kapitippicture.get_Properties().set_ZoomAccelerationFactor(1.0);
			this.kapitippicture.Size = new Size(260, 287);
			this.kapitippicture.TabIndex = 7;
			this.otokaptip.Location = new Point(172, 5);
			this.otokaptip.Name = "otokaptip";
			this.otokaptip.get_Properties().get_Appearance().set_BackColor(SystemColors.Control);
			this.otokaptip.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.otokaptip.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.otokaptip.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.otokaptip.get_Properties().get_Items().AddRange(new RadioGroupItem[]
			{
				new RadioGroupItem(1, "2 Panel Merkezi"),
				new RadioGroupItem(2, "2 Panel Teleskopik"),
				new RadioGroupItem(3, "3 Panel Teleskopik"),
				new RadioGroupItem(4, "4 Panel Merkezi"),
				new RadioGroupItem(5, "6 Panel Merkezi")
			});
			this.otokaptip.Size = new Size(156, 165);
			this.otokaptip.TabIndex = 6;
			this.otokaptip.add_SelectedIndexChanged(new EventHandler(this.otokaptip_SelectedIndexChanged));
			this.backstageViewClientControl6.set_Location(new Point(165, 0));
			this.backstageViewClientControl6.Name = "backstageViewClientControl6";
			this.backstageViewClientControl6.set_Size(new Size(1145, 817));
			this.backstageViewClientControl6.TabIndex = 5;
			this.backstageViewClientControl3.Controls.Add(this.layoutControl3);
			this.backstageViewClientControl3.set_Location(new Point(165, 0));
			this.backstageViewClientControl3.Name = "backstageViewClientControl3";
			this.backstageViewClientControl3.set_Size(new Size(1145, 817));
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
			this.layoutControl3.set_Root(this.layoutControlGroup1);
			this.layoutControl3.Size = new Size(939, 469);
			this.layoutControl3.TabIndex = 21;
			this.layoutControl3.Text = "layoutControl3";
			this.panel1.BackColor = Color.Transparent;
			this.panel1.Location = new Point(649, 2);
			this.panel1.MaximumSize = new Size(288, 463);
			this.panel1.MinimumSize = new Size(288, 463);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(288, 463);
			this.panel1.TabIndex = 20;
			this.label3karsiagirlik.get_Appearance().set_Font(new Font("Tahoma", 11.25f, FontStyle.Bold));
			this.label3karsiagirlik.get_Appearance().set_ForeColor(Color.Red);
			this.label3karsiagirlik.set_AutoSizeMode(1);
			this.label3karsiagirlik.Location = new Point(2, 2);
			this.label3karsiagirlik.Name = "label3karsiagirlik";
			this.label3karsiagirlik.Size = new Size(643, 18);
			this.label3karsiagirlik.set_StyleController(this.layoutControl3);
			this.label3karsiagirlik.TabIndex = 1004;
			this.label3karsiagirlik.Text = "KARŞI AĞIRLIK";
			this.dengekatsayisi.set_EditValue("0,5");
			this.dengekatsayisi.set_EnterMoveNextControl(true);
			this.dengekatsayisi.Location = new Point(181, 184);
			this.dengekatsayisi.Name = "dengekatsayisi";
			this.dengekatsayisi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dengekatsayisi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dengekatsayisi.Size = new Size(464, 20);
			this.dengekatsayisi.set_StyleController(this.layoutControl3);
			this.dengekatsayisi.TabIndex = 47;
			this.dengekatsayisi.KeyDown += new KeyEventHandler(this.decimal_KeyDown);
			this.dengekatsayisi.KeyPress += new KeyPressEventHandler(this.decimal_KeyPress);
			this.karkasgrup.Location = new Point(2, 280);
			this.karkasgrup.Name = "karkasgrup";
			this.karkasgrup.get_Properties().get_Items().AddRange(new RadioGroupItem[]
			{
				new RadioGroupItem(null, "Tek Karkas"),
				new RadioGroupItem(null, "Çift Karkas")
			});
			this.karkasgrup.Size = new Size(643, 187);
			this.karkasgrup.set_StyleController(this.layoutControl3);
			this.karkasgrup.TabIndex = 46;
			this.karkasgrup.add_SelectedIndexChanged(new EventHandler(this.karkascizerselectedindex));
			this.karkasgrup.Validated += new EventHandler(this.karkascizervalidated);
			this.karsiagrozgulkutle.Enabled = false;
			this.karsiagrozgulkutle.set_EnterMoveNextControl(true);
			this.karsiagrozgulkutle.Location = new Point(512, 138);
			this.karsiagrozgulkutle.Name = "karsiagrozgulkutle";
			this.karsiagrozgulkutle.get_Properties().get_Appearance().set_BackColor(Color.Transparent);
			this.karsiagrozgulkutle.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.karsiagrozgulkutle.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.karsiagrozgulkutle.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.karsiagrozgulkutle.get_Properties().set_BorderStyle(0);
			this.karsiagrozgulkutle.Size = new Size(89, 18);
			this.karsiagrozgulkutle.set_StyleController(this.layoutControl3);
			this.karsiagrozgulkutle.TabIndex = 4;
			this.label3regulatorbilgi.get_Appearance().set_Font(new Font("Tahoma", 11.25f, FontStyle.Bold));
			this.label3regulatorbilgi.get_Appearance().set_ForeColor(Color.Red);
			this.label3regulatorbilgi.set_AutoSizeMode(1);
			this.label3regulatorbilgi.Location = new Point(2, 94);
			this.label3regulatorbilgi.Name = "label3regulatorbilgi";
			this.label3regulatorbilgi.Size = new Size(327, 18);
			this.label3regulatorbilgi.set_StyleController(this.layoutControl3);
			this.label3regulatorbilgi.TabIndex = 1003;
			this.label3regulatorbilgi.Text = "REGÜLATÖR BİLGİLERİ";
			this.label3birimkg.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3birimkg.set_AutoSizeMode(1);
			this.label3birimkg.Location = new Point(605, 144);
			this.label3birimkg.Name = "label3birimkg";
			this.label3birimkg.Size = new Size(40, 14);
			this.label3birimkg.set_StyleController(this.layoutControl3);
			this.label3birimkg.TabIndex = 8;
			this.label3birimkg.Text = "Kg";
			this.label3kutlekg.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3kutlekg.set_AutoSizeMode(1);
			this.label3kutlekg.Location = new Point(605, 126);
			this.label3kutlekg.Name = "label3kutlekg";
			this.label3kutlekg.Size = new Size(40, 14);
			this.label3kutlekg.set_StyleController(this.layoutControl3);
			this.label3kutlekg.TabIndex = 8;
			this.label3kutlekg.Text = "Kg";
			this.label3yuksekmm.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3yuksekmm.set_AutoSizeMode(1);
			this.label3yuksekmm.Location = new Point(605, 108);
			this.label3yuksekmm.Name = "label3yuksekmm";
			this.label3yuksekmm.Size = new Size(40, 14);
			this.label3yuksekmm.set_StyleController(this.layoutControl3);
			this.label3yuksekmm.TabIndex = 45;
			this.label3yuksekmm.Text = "mm";
			this.karsiagrbirimagirlik.Enabled = false;
			this.karsiagrbirimagirlik.set_EnterMoveNextControl(true);
			this.karsiagrbirimagirlik.Location = new Point(181, 162);
			this.karsiagrbirimagirlik.Name = "karsiagrbirimagirlik";
			this.karsiagrbirimagirlik.get_Properties().get_Appearance().set_BackColor(Color.Transparent);
			this.karsiagrbirimagirlik.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.karsiagrbirimagirlik.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.karsiagrbirimagirlik.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.karsiagrbirimagirlik.get_Properties().set_BorderStyle(0);
			this.karsiagrbirimagirlik.Size = new Size(464, 18);
			this.karsiagrbirimagirlik.set_StyleController(this.layoutControl3);
			this.karsiagrbirimagirlik.TabIndex = 5;
			this.karkasagirlik.set_EnterMoveNextControl(true);
			this.karkasagirlik.Location = new Point(181, 208);
			this.karkasagirlik.Name = "karkasagirlik";
			this.karkasagirlik.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.karkasagirlik.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.karkasagirlik.Size = new Size(464, 20);
			this.karkasagirlik.set_StyleController(this.layoutControl3);
			this.karkasagirlik.TabIndex = 11;
			this.arkaagirsayisi.set_EnterMoveNextControl(true);
			this.arkaagirsayisi.Location = new Point(181, 256);
			this.arkaagirsayisi.Name = "arkaagirsayisi";
			this.arkaagirsayisi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.arkaagirsayisi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.arkaagirsayisi.Size = new Size(464, 20);
			this.arkaagirsayisi.set_StyleController(this.layoutControl3);
			this.arkaagirsayisi.TabIndex = 13;
			this.arkaagirsayisi.TextChanged += new EventHandler(this.karkascizertextchanged);
			this.arkaagirsayisi.KeyDown += new KeyEventHandler(this.int_KeyDown);
			this.arkaagirsayisi.KeyPress += new KeyPressEventHandler(this.int_KeyPress);
			this.arkaagirsayisi.Validated += new EventHandler(this.karkascizervalidated);
			this.yanagirsayisi.set_EnterMoveNextControl(true);
			this.yanagirsayisi.Location = new Point(181, 232);
			this.yanagirsayisi.Name = "yanagirsayisi";
			this.yanagirsayisi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.yanagirsayisi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.yanagirsayisi.Size = new Size(464, 20);
			this.yanagirsayisi.set_StyleController(this.layoutControl3);
			this.yanagirsayisi.TabIndex = 12;
			this.yanagirsayisi.TextChanged += new EventHandler(this.karkascizertextchanged);
			this.yanagirsayisi.KeyDown += new KeyEventHandler(this.int_KeyDown);
			this.yanagirsayisi.KeyPress += new KeyPressEventHandler(this.int_KeyPress);
			this.yanagirsayisi.Validated += new EventHandler(this.karkascizervalidated);
			this.karsiagryukseklik.Enabled = false;
			this.karsiagryukseklik.set_EnterMoveNextControl(true);
			this.karsiagryukseklik.Location = new Point(512, 116);
			this.karsiagryukseklik.Name = "karsiagryukseklik";
			this.karsiagryukseklik.get_Properties().get_Appearance().set_BackColor(Color.Transparent);
			this.karsiagryukseklik.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.karsiagryukseklik.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.karsiagryukseklik.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.karsiagryukseklik.get_Properties().set_BorderStyle(0);
			this.karsiagryukseklik.Size = new Size(89, 18);
			this.karsiagryukseklik.set_StyleController(this.layoutControl3);
			this.karsiagryukseklik.TabIndex = 3;
			this.label3boymm.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3boymm.set_AutoSizeMode(1);
			this.label3boymm.Location = new Point(605, 90);
			this.label3boymm.Name = "label3boymm";
			this.label3boymm.Size = new Size(40, 14);
			this.label3boymm.set_StyleController(this.layoutControl3);
			this.label3boymm.TabIndex = 8;
			this.label3boymm.Text = "mm";
			this.karsiagrboy.Enabled = false;
			this.karsiagrboy.set_EnterMoveNextControl(true);
			this.karsiagrboy.Location = new Point(512, 94);
			this.karsiagrboy.Name = "karsiagrboy";
			this.karsiagrboy.get_Properties().get_Appearance().set_BackColor(Color.Transparent);
			this.karsiagrboy.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.karsiagrboy.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.karsiagrboy.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.karsiagrboy.get_Properties().set_BorderStyle(0);
			this.karsiagrboy.Size = new Size(89, 18);
			this.karsiagrboy.set_StyleController(this.layoutControl3);
			this.karsiagrboy.TabIndex = 2;
			this.label3enmm.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3enmm.set_AutoSizeMode(1);
			this.label3enmm.Location = new Point(605, 72);
			this.label3enmm.Name = "label3enmm";
			this.label3enmm.Size = new Size(40, 14);
			this.label3enmm.set_StyleController(this.layoutControl3);
			this.label3enmm.TabIndex = 7;
			this.label3enmm.Text = "mm";
			this.regulatormarka.Location = new Point(147, 116);
			this.regulatormarka.Name = "regulatormarka";
			this.regulatormarka.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.regulatormarka.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.regulatormarka.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.regulatormarka.get_Properties().set_NullText("");
			this.regulatormarka.get_Properties().set_View(this.gridView3);
			this.regulatormarka.get_Properties().add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.regulatormarka.Size = new Size(182, 20);
			this.regulatormarka.set_StyleController(this.layoutControl3);
			this.regulatormarka.TabIndex = 1;
			this.regulatormarka.add_EditValueChanged(new EventHandler(this.regulatormarka_EditValueChanged));
			this.gridView3.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn65,
				this.gridColumn66,
				this.gridColumn67,
				this.gridColumn68,
				this.gridColumn69,
				this.gridColumn70
			});
			this.gridView3.set_FocusRectStyle(1);
			this.gridView3.set_Name("gridView3");
			this.gridView3.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.gridView3.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn65.set_Caption("gridColumn37");
			this.gridColumn65.set_FieldName("guid");
			this.gridColumn65.set_Name("gridColumn65");
			this.gridColumn66.set_Caption("gridColumn38");
			this.gridColumn66.set_FieldName("uretici");
			this.gridColumn66.set_Name("gridColumn66");
			this.gridColumn67.set_Caption("gridColumn39");
			this.gridColumn67.set_FieldName("model");
			this.gridColumn67.set_Name("gridColumn67");
			this.gridColumn68.set_Caption("MARKA VE MODEL");
			this.gridColumn68.set_FieldName("MARKA_MODEL");
			this.gridColumn68.set_Name("gridColumn68");
			this.gridColumn68.set_Visible(true);
			this.gridColumn68.set_VisibleIndex(0);
			this.gridColumn69.set_Caption("gridColumn41");
			this.gridColumn69.set_FieldName("serino");
			this.gridColumn69.set_Name("gridColumn69");
			this.gridColumn70.set_Caption("gridColumn42");
			this.gridColumn70.set_FieldName("belgeveren");
			this.gridColumn70.set_Name("gridColumn70");
			this.karsiagren.Enabled = false;
			this.karsiagren.set_EnterMoveNextControl(true);
			this.karsiagren.Location = new Point(181, 72);
			this.karsiagren.Name = "karsiagren";
			this.karsiagren.get_Properties().get_Appearance().set_BackColor(Color.Transparent);
			this.karsiagren.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.karsiagren.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.karsiagren.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.karsiagren.get_Properties().set_BorderStyle(0);
			this.karsiagren.Size = new Size(420, 18);
			this.karsiagren.set_StyleController(this.layoutControl3);
			this.karsiagren.TabIndex = 1;
			this.karsiagrsecim.Location = new Point(181, 24);
			this.karsiagrsecim.Name = "karsiagrsecim";
			this.karsiagrsecim.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.karsiagrsecim.get_Properties().get_Columns().AddRange(new LookUpColumnInfo[]
			{
				new LookUpColumnInfo("sno", "No", 20, 0, "", false, 0),
				new LookUpColumnInfo("cinsi", "Karşı Ağırlık Cinsi")
			});
			this.karsiagrsecim.get_Properties().set_NullText("");
			this.karsiagrsecim.Size = new Size(464, 20);
			this.karsiagrsecim.set_StyleController(this.layoutControl3);
			this.karsiagrsecim.TabIndex = 44;
			this.karsiagrsecim.add_EditValueChanged(new EventHandler(this.karsiagrsecim_EditValueChanged));
			this.karsiagrsecim.TextChanged += new EventHandler(this.karkascizertextchanged);
			this.karsiagrsecim.Validated += new EventHandler(this.karkascizervalidated);
			this.karsiagrmodel.set_EnterMoveNextControl(true);
			this.karsiagrmodel.Location = new Point(181, 48);
			this.karsiagrmodel.Name = "karsiagrmodel";
			this.karsiagrmodel.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f));
			this.karsiagrmodel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.karsiagrmodel.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.karsiagrmodel.get_Properties().get_Columns().AddRange(new LookUpColumnInfo[]
			{
				new LookUpColumnInfo("sno", "No", 20, 0, "", false, 0),
				new LookUpColumnInfo("cinsi", "Cinsi", 20, 0, "", false, 0),
				new LookUpColumnInfo("model", "Model"),
				new LookUpColumnInfo("en", "En"),
				new LookUpColumnInfo("boy", "Boy"),
				new LookUpColumnInfo("yukseklik", "Yükseklik"),
				new LookUpColumnInfo("birimagirlik", "Birim Ağırlık"),
				new LookUpColumnInfo("ozgulkutle", "Özgül Kütle")
			});
			this.karsiagrmodel.get_Properties().set_NullText("");
			this.karsiagrmodel.Size = new Size(464, 20);
			this.karsiagrmodel.set_StyleController(this.layoutControl3);
			this.karsiagrmodel.TabIndex = 41;
			this.karsiagrmodel.add_EditValueChanged(new EventHandler(this.karsiagrmodel_EditValueChanged));
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem13,
				this.label3regmarka,
				this.layoutControlItem24,
				this.label3baritdokum,
				this.label3modelsec,
				this.label3enbilgisi,
				this.layoutControlItem30,
				this.label3boybilgisi,
				this.layoutControlItem32,
				this.label3yukseklikbilgisi,
				this.layoutControlItem35,
				this.layoutControlItem36,
				this.layoutControlItem37,
				this.lbldengekatsayi,
				this.label3karkasagr,
				this.label3yanagr,
				this.label3arkaagr,
				this.layoutControlItem42,
				this.label3ozgulkutle,
				this.label3birimagr,
				this.layoutControlItem25
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(939, 469));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem13.set_Control(this.label3regulatorbilgi);
			this.layoutControlItem13.set_CustomizationFormText("layoutControlItem13");
			this.layoutControlItem13.set_Location(new Point(0, 92));
			this.layoutControlItem13.set_Name("layoutControlItem13");
			this.layoutControlItem13.set_Size(new Size(331, 22));
			this.layoutControlItem13.set_TextSize(new Size(0, 0));
			this.layoutControlItem13.set_TextVisible(false);
			this.label3regmarka.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3regmarka.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3regmarka.set_Control(this.regulatormarka);
			this.label3regmarka.set_CustomizationFormText("Regülatör Marka : ");
			this.label3regmarka.set_Location(new Point(0, 114));
			this.label3regmarka.set_Name("label3regmarka");
			this.label3regmarka.set_Size(new Size(331, 46));
			this.label3regmarka.set_Text("Regülatör Marka : ");
			this.label3regmarka.set_TextAlignMode(2);
			this.label3regmarka.set_TextSize(new Size(140, 0));
			this.label3regmarka.set_TextToControlDistance(5);
			this.layoutControlItem24.set_Control(this.label3karsiagirlik);
			this.layoutControlItem24.set_CustomizationFormText("layoutControlItem24");
			this.layoutControlItem24.set_Location(new Point(0, 0));
			this.layoutControlItem24.set_Name("layoutControlItem24");
			this.layoutControlItem24.set_Size(new Size(647, 22));
			this.layoutControlItem24.set_TextSize(new Size(0, 0));
			this.layoutControlItem24.set_TextVisible(false);
			this.label3baritdokum.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3baritdokum.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3baritdokum.set_Control(this.karsiagrsecim);
			this.label3baritdokum.set_CustomizationFormText("Barit && Döküm Seçimi : ");
			this.label3baritdokum.set_Location(new Point(0, 22));
			this.label3baritdokum.set_Name("label3baritdokum");
			this.label3baritdokum.set_Size(new Size(647, 24));
			this.label3baritdokum.set_Text("Barit && Döküm Seçimi : ");
			this.label3baritdokum.set_TextSize(new Size(176, 14));
			this.label3modelsec.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3modelsec.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3modelsec.set_Control(this.karsiagrmodel);
			this.label3modelsec.set_CustomizationFormText("Model Seçiniz : ");
			this.label3modelsec.set_Location(new Point(0, 46));
			this.label3modelsec.set_Name("label3modelsec");
			this.label3modelsec.set_Size(new Size(647, 24));
			this.label3modelsec.set_Text("Model Seçiniz : ");
			this.label3modelsec.set_TextSize(new Size(176, 14));
			this.label3enbilgisi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3enbilgisi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3enbilgisi.set_Control(this.karsiagren);
			this.label3enbilgisi.set_CustomizationFormText("En : ");
			this.label3enbilgisi.set_Location(new Point(0, 70));
			this.label3enbilgisi.set_Name("label3enbilgisi");
			this.label3enbilgisi.set_Size(new Size(603, 22));
			this.label3enbilgisi.set_Text("En : ");
			this.label3enbilgisi.set_TextSize(new Size(176, 14));
			this.layoutControlItem30.set_Control(this.label3enmm);
			this.layoutControlItem30.set_CustomizationFormText("layoutControlItem30");
			this.layoutControlItem30.set_Location(new Point(603, 70));
			this.layoutControlItem30.set_Name("layoutControlItem30");
			this.layoutControlItem30.set_Size(new Size(44, 18));
			this.layoutControlItem30.set_TextSize(new Size(0, 0));
			this.layoutControlItem30.set_TextVisible(false);
			this.label3boybilgisi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3boybilgisi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3boybilgisi.set_Control(this.karsiagrboy);
			this.label3boybilgisi.set_CustomizationFormText("Boy : ");
			this.label3boybilgisi.set_Location(new Point(331, 92));
			this.label3boybilgisi.set_Name("label3boybilgisi");
			this.label3boybilgisi.set_Size(new Size(272, 22));
			this.label3boybilgisi.set_Text("Boy : ");
			this.label3boybilgisi.set_TextSize(new Size(176, 14));
			this.layoutControlItem32.set_Control(this.label3boymm);
			this.layoutControlItem32.set_CustomizationFormText("layoutControlItem32");
			this.layoutControlItem32.set_Location(new Point(603, 88));
			this.layoutControlItem32.set_Name("layoutControlItem32");
			this.layoutControlItem32.set_Size(new Size(44, 18));
			this.layoutControlItem32.set_TextSize(new Size(0, 0));
			this.layoutControlItem32.set_TextVisible(false);
			this.label3yukseklikbilgisi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3yukseklikbilgisi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3yukseklikbilgisi.set_Control(this.karsiagryukseklik);
			this.label3yukseklikbilgisi.set_CustomizationFormText("Yükseklik : ");
			this.label3yukseklikbilgisi.set_Location(new Point(331, 114));
			this.label3yukseklikbilgisi.set_Name("label3yukseklikbilgisi");
			this.label3yukseklikbilgisi.set_Size(new Size(272, 22));
			this.label3yukseklikbilgisi.set_Text("Yükseklik : ");
			this.label3yukseklikbilgisi.set_TextSize(new Size(176, 14));
			this.layoutControlItem35.set_Control(this.label3yuksekmm);
			this.layoutControlItem35.set_CustomizationFormText("layoutControlItem35");
			this.layoutControlItem35.set_Location(new Point(603, 106));
			this.layoutControlItem35.set_Name("layoutControlItem35");
			this.layoutControlItem35.set_Size(new Size(44, 18));
			this.layoutControlItem35.set_TextSize(new Size(0, 0));
			this.layoutControlItem35.set_TextVisible(false);
			this.layoutControlItem36.set_Control(this.label3kutlekg);
			this.layoutControlItem36.set_CustomizationFormText("layoutControlItem36");
			this.layoutControlItem36.set_Location(new Point(603, 124));
			this.layoutControlItem36.set_Name("layoutControlItem36");
			this.layoutControlItem36.set_Size(new Size(44, 18));
			this.layoutControlItem36.set_TextSize(new Size(0, 0));
			this.layoutControlItem36.set_TextVisible(false);
			this.layoutControlItem37.set_Control(this.label3birimkg);
			this.layoutControlItem37.set_CustomizationFormText("layoutControlItem37");
			this.layoutControlItem37.set_Location(new Point(603, 142));
			this.layoutControlItem37.set_Name("layoutControlItem37");
			this.layoutControlItem37.set_Size(new Size(44, 18));
			this.layoutControlItem37.set_TextSize(new Size(0, 0));
			this.layoutControlItem37.set_TextVisible(false);
			this.lbldengekatsayi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.lbldengekatsayi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.lbldengekatsayi.set_Control(this.dengekatsayisi);
			this.lbldengekatsayi.set_CustomizationFormText("Denge Katsayısı : ");
			this.lbldengekatsayi.set_Location(new Point(0, 182));
			this.lbldengekatsayi.set_Name("lbldengekatsayi");
			this.lbldengekatsayi.set_Size(new Size(647, 24));
			this.lbldengekatsayi.set_Text("Denge Katsayısı : ");
			this.lbldengekatsayi.set_TextSize(new Size(176, 14));
			this.label3karkasagr.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3karkasagr.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3karkasagr.set_Control(this.karkasagirlik);
			this.label3karkasagr.set_CustomizationFormText("Karşı Ağırlık Karkası Ağırlığı : ");
			this.label3karkasagr.set_Location(new Point(0, 206));
			this.label3karkasagr.set_Name("label3karkasagr");
			this.label3karkasagr.set_Size(new Size(647, 24));
			this.label3karkasagr.set_Text("Karşı Ağırlık Karkası Ağırlığı : ");
			this.label3karkasagr.set_TextSize(new Size(176, 14));
			this.label3yanagr.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3yanagr.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3yanagr.set_Control(this.yanagirsayisi);
			this.label3yanagr.set_CustomizationFormText("Alt Alta Ağırlık Adedi : ");
			this.label3yanagr.set_Location(new Point(0, 230));
			this.label3yanagr.set_Name("label3yanagr");
			this.label3yanagr.set_Size(new Size(647, 24));
			this.label3yanagr.set_Text("Alt Alta Ağırlık Adedi : ");
			this.label3yanagr.set_TextSize(new Size(176, 14));
			this.label3arkaagr.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3arkaagr.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3arkaagr.set_Control(this.arkaagirsayisi);
			this.label3arkaagr.set_CustomizationFormText("Arka Arkaya Ağırlık Adedi : ");
			this.label3arkaagr.set_Location(new Point(0, 254));
			this.label3arkaagr.set_Name("label3arkaagr");
			this.label3arkaagr.set_Size(new Size(647, 24));
			this.label3arkaagr.set_Text("Arka Arkaya Ağırlık Adedi : ");
			this.label3arkaagr.set_TextSize(new Size(176, 14));
			this.layoutControlItem42.set_Control(this.karkasgrup);
			this.layoutControlItem42.set_CustomizationFormText("layoutControlItem42");
			this.layoutControlItem42.set_Location(new Point(0, 278));
			this.layoutControlItem42.set_Name("layoutControlItem42");
			this.layoutControlItem42.set_Size(new Size(647, 191));
			this.layoutControlItem42.set_TextSize(new Size(0, 0));
			this.layoutControlItem42.set_TextVisible(false);
			this.label3ozgulkutle.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3ozgulkutle.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3ozgulkutle.set_Control(this.karsiagrozgulkutle);
			this.label3ozgulkutle.set_CustomizationFormText("Özgül Kütle : ");
			this.label3ozgulkutle.set_Location(new Point(331, 136));
			this.label3ozgulkutle.set_Name("label3ozgulkutle");
			this.label3ozgulkutle.set_Size(new Size(272, 24));
			this.label3ozgulkutle.set_Text("Özgül Kütle : ");
			this.label3ozgulkutle.set_TextSize(new Size(176, 14));
			this.label3birimagr.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.label3birimagr.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.label3birimagr.set_Control(this.karsiagrbirimagirlik);
			this.label3birimagr.set_CustomizationFormText("Birim Ağırlık : ");
			this.label3birimagr.set_Location(new Point(0, 160));
			this.label3birimagr.set_Name("label3birimagr");
			this.label3birimagr.set_Size(new Size(647, 22));
			this.label3birimagr.set_Text("Birim Ağırlık : ");
			this.label3birimagr.set_TextSize(new Size(176, 14));
			this.layoutControlItem25.set_Control(this.panel1);
			this.layoutControlItem25.set_CustomizationFormText("layoutControlItem25");
			this.layoutControlItem25.set_Location(new Point(647, 0));
			this.layoutControlItem25.set_Name("layoutControlItem25");
			this.layoutControlItem25.set_Size(new Size(292, 469));
			this.layoutControlItem25.set_TextSize(new Size(0, 0));
			this.layoutControlItem25.set_TextVisible(false);
			this.backstageViewClientControl5.Controls.Add(this.dosyahidasnicin);
			this.backstageViewClientControl5.Controls.Add(this.dosyalblelektrasnicin);
			this.backstageViewClientControl5.Controls.Add(this.layoutControl6);
			this.backstageViewClientControl5.Controls.Add(this.layoutControl5);
			this.backstageViewClientControl5.set_Location(new Point(165, 0));
			this.backstageViewClientControl5.Name = "backstageViewClientControl5";
			this.backstageViewClientControl5.set_Size(new Size(1145, 817));
			this.backstageViewClientControl5.TabIndex = 4;
			this.dosyahidasnicin.get_AppearanceCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyahidasnicin.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.dosyahidasnicin.Controls.Add(this.layoutControl23);
			this.dosyahidasnicin.Dock = DockStyle.Fill;
			this.dosyahidasnicin.Location = new Point(312, 370);
			this.dosyahidasnicin.Name = "dosyahidasnicin";
			this.dosyahidasnicin.Size = new Size(833, 447);
			this.dosyahidasnicin.TabIndex = 174;
			this.dosyahidasnicin.Text = "HİDROLİKLİ ASANSÖR İÇİN GEREKEN BİLGİLERİ";
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
			this.layoutControl23.Location = new Point(2, 21);
			this.layoutControl23.Name = "layoutControl23";
			this.layoutControl23.set_Root(this.layoutControlGroup23);
			this.layoutControl23.Size = new Size(829, 424);
			this.layoutControl23.TabIndex = 8;
			this.layoutControl23.Text = "layoutControl23";
			this.dosyahortumserino.set_EnterMoveNextControl(true);
			this.dosyahortumserino.Location = new Point(532, 60);
			this.dosyahortumserino.Name = "dosyahortumserino";
			this.dosyahortumserino.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyahortumserino.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyahortumserino.Size = new Size(289, 22);
			this.dosyahortumserino.set_StyleController(this.layoutControl23);
			this.dosyahortumserino.TabIndex = 10;
			this.dosyahortumonaylayan.set_EnterMoveNextControl(true);
			this.dosyahortumonaylayan.Location = new Point(440, 60);
			this.dosyahortumonaylayan.Name = "dosyahortumonaylayan";
			this.dosyahortumonaylayan.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyahortumonaylayan.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyahortumonaylayan.Size = new Size(88, 22);
			this.dosyahortumonaylayan.set_StyleController(this.layoutControl23);
			this.dosyahortumonaylayan.TabIndex = 9;
			this.dosyahortumbelgeno.set_EnterMoveNextControl(true);
			this.dosyahortumbelgeno.Location = new Point(350, 60);
			this.dosyahortumbelgeno.Name = "dosyahortumbelgeno";
			this.dosyahortumbelgeno.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyahortumbelgeno.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyahortumbelgeno.Size = new Size(86, 22);
			this.dosyahortumbelgeno.set_StyleController(this.layoutControl23);
			this.dosyahortumbelgeno.TabIndex = 8;
			this.dosyahortummodel.set_EnterMoveNextControl(true);
			this.dosyahortummodel.Location = new Point(259, 60);
			this.dosyahortummodel.Name = "dosyahortummodel";
			this.dosyahortummodel.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyahortummodel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyahortummodel.Size = new Size(87, 22);
			this.dosyahortummodel.set_StyleController(this.layoutControl23);
			this.dosyahortummodel.TabIndex = 7;
			this.dosyahortumuretici.set_EnterMoveNextControl(true);
			this.dosyahortumuretici.Location = new Point(168, 60);
			this.dosyahortumuretici.Name = "dosyahortumuretici";
			this.dosyahortumuretici.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyahortumuretici.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyahortumuretici.Size = new Size(87, 22);
			this.dosyahortumuretici.set_StyleController(this.layoutControl23);
			this.dosyahortumuretici.TabIndex = 6;
			this.dosyalblhortum.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblhortum.Location = new Point(8, 60);
			this.dosyalblhortum.Name = "dosyalblhortum";
			this.dosyalblhortum.Size = new Size(156, 22);
			this.dosyalblhortum.set_StyleController(this.layoutControl23);
			this.dosyalblhortum.TabIndex = 1;
			this.dosyalblhortum.Text = "Hortum Patlama Valfi : ";
			this.dosyalblserino2.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblserino2.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblserino2.set_AutoSizeMode(1);
			this.dosyalblserino2.Location = new Point(532, 8);
			this.dosyalblserino2.Name = "dosyalblserino2";
			this.dosyalblserino2.Size = new Size(289, 22);
			this.dosyalblserino2.set_StyleController(this.layoutControl23);
			this.dosyalblserino2.TabIndex = 1;
			this.dosyalblserino2.Text = "ÜR. SERİ NO";
			this.dosyalblonaylayan2.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblonaylayan2.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblonaylayan2.Location = new Point(440, 8);
			this.dosyalblonaylayan2.Name = "dosyalblonaylayan2";
			this.dosyalblonaylayan2.Size = new Size(88, 22);
			this.dosyalblonaylayan2.set_StyleController(this.layoutControl23);
			this.dosyalblonaylayan2.TabIndex = 1;
			this.dosyalblonaylayan2.Text = "ONAYLAYAN";
			this.dosyalblbelgeno2.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblbelgeno2.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblbelgeno2.Location = new Point(350, 8);
			this.dosyalblbelgeno2.Name = "dosyalblbelgeno2";
			this.dosyalblbelgeno2.Size = new Size(86, 22);
			this.dosyalblbelgeno2.set_StyleController(this.layoutControl23);
			this.dosyalblbelgeno2.TabIndex = 1;
			this.dosyalblbelgeno2.Text = "BELGE NO";
			this.dosyalblmodel2.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblmodel2.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblmodel2.Location = new Point(259, 8);
			this.dosyalblmodel2.Name = "dosyalblmodel2";
			this.dosyalblmodel2.Size = new Size(87, 22);
			this.dosyalblmodel2.set_StyleController(this.layoutControl23);
			this.dosyalblmodel2.TabIndex = 1;
			this.dosyalblmodel2.Text = "MODEL";
			this.dosyalbldebi.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalbldebi.Location = new Point(8, 34);
			this.dosyalbldebi.Name = "dosyalbldebi";
			this.dosyalbldebi.Size = new Size(156, 22);
			this.dosyalbldebi.set_StyleController(this.layoutControl23);
			this.dosyalbldebi.TabIndex = 1;
			this.dosyalbldebi.Text = "Deni Sınırlama Valfi : ";
			this.dosyalbluret2.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalbluret2.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalbluret2.Location = new Point(168, 8);
			this.dosyalbluret2.Name = "dosyalbluret2";
			this.dosyalbluret2.Size = new Size(87, 22);
			this.dosyalbluret2.set_StyleController(this.layoutControl23);
			this.dosyalbluret2.TabIndex = 1;
			this.dosyalbluret2.Text = "ÜRETİCİ";
			this.dosyalblmalz2.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblmalz2.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblmalz2.Location = new Point(8, 8);
			this.dosyalblmalz2.Name = "dosyalblmalz2";
			this.dosyalblmalz2.Size = new Size(156, 22);
			this.dosyalblmalz2.set_StyleController(this.layoutControl23);
			this.dosyalblmalz2.TabIndex = 1;
			this.dosyalblmalz2.Text = "MALZEME";
			this.dosyadebiserino.set_EnterMoveNextControl(true);
			this.dosyadebiserino.Location = new Point(532, 34);
			this.dosyadebiserino.Name = "dosyadebiserino";
			this.dosyadebiserino.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyadebiserino.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyadebiserino.Size = new Size(289, 22);
			this.dosyadebiserino.set_StyleController(this.layoutControl23);
			this.dosyadebiserino.TabIndex = 5;
			this.dosyadebionaylayan.set_EnterMoveNextControl(true);
			this.dosyadebionaylayan.Location = new Point(440, 34);
			this.dosyadebionaylayan.Name = "dosyadebionaylayan";
			this.dosyadebionaylayan.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyadebionaylayan.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyadebionaylayan.Size = new Size(88, 22);
			this.dosyadebionaylayan.set_StyleController(this.layoutControl23);
			this.dosyadebionaylayan.TabIndex = 4;
			this.dosyadebibelgeno.set_EnterMoveNextControl(true);
			this.dosyadebibelgeno.Location = new Point(350, 34);
			this.dosyadebibelgeno.Name = "dosyadebibelgeno";
			this.dosyadebibelgeno.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyadebibelgeno.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyadebibelgeno.Size = new Size(86, 22);
			this.dosyadebibelgeno.set_StyleController(this.layoutControl23);
			this.dosyadebibelgeno.TabIndex = 3;
			this.dosyadebimodel.set_EnterMoveNextControl(true);
			this.dosyadebimodel.Location = new Point(259, 34);
			this.dosyadebimodel.Name = "dosyadebimodel";
			this.dosyadebimodel.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyadebimodel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyadebimodel.Size = new Size(87, 22);
			this.dosyadebimodel.set_StyleController(this.layoutControl23);
			this.dosyadebimodel.TabIndex = 2;
			this.dosyadebiuret.set_EnterMoveNextControl(true);
			this.dosyadebiuret.Location = new Point(168, 34);
			this.dosyadebiuret.Name = "dosyadebiuret";
			this.dosyadebiuret.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyadebiuret.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyadebiuret.Size = new Size(87, 22);
			this.dosyadebiuret.set_StyleController(this.layoutControl23);
			this.dosyadebiuret.TabIndex = 1;
			this.layoutControlGroup23.set_CustomizationFormText("layoutControlGroup23");
			this.layoutControlGroup23.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup23.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem345,
				this.layoutControlItem346,
				this.layoutControlItem347,
				this.layoutControlItem348,
				this.layoutControlItem349,
				this.layoutControlItem350,
				this.layoutControlItem351,
				this.layoutControlItem352,
				this.layoutControlItem353,
				this.layoutControlItem354,
				this.layoutControlItem355,
				this.layoutControlItem356,
				this.layoutControlItem357,
				this.layoutControlItem358,
				this.layoutControlItem359,
				this.layoutControlItem360,
				this.layoutControlItem361,
				this.layoutControlItem362
			});
			this.layoutControlGroup23.set_Location(new Point(0, 0));
			this.layoutControlGroup23.set_Name("layoutControlGroup23");
			this.layoutControlGroup23.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup23.set_Size(new Size(829, 424));
			this.layoutControlGroup23.set_TextVisible(false);
			this.layoutControlItem345.set_Control(this.dosyadebiuret);
			this.layoutControlItem345.set_CustomizationFormText("MARKA");
			this.layoutControlItem345.set_Location(new Point(160, 26));
			this.layoutControlItem345.set_MaxSize(new Size(0, 26));
			this.layoutControlItem345.set_MinSize(new Size(54, 26));
			this.layoutControlItem345.set_Name("layoutControlItem345");
			this.layoutControlItem345.set_Size(new Size(91, 26));
			this.layoutControlItem345.set_SizeConstraintsType(2);
			this.layoutControlItem345.set_Text("MARKA");
			this.layoutControlItem345.set_TextLocation(3);
			this.layoutControlItem345.set_TextSize(new Size(0, 0));
			this.layoutControlItem345.set_TextVisible(false);
			this.layoutControlItem346.set_Control(this.dosyadebimodel);
			this.layoutControlItem346.set_CustomizationFormText("MODEL");
			this.layoutControlItem346.set_Location(new Point(251, 26));
			this.layoutControlItem346.set_MaxSize(new Size(0, 26));
			this.layoutControlItem346.set_MinSize(new Size(54, 26));
			this.layoutControlItem346.set_Name("layoutControlItem346");
			this.layoutControlItem346.set_Size(new Size(91, 26));
			this.layoutControlItem346.set_SizeConstraintsType(2);
			this.layoutControlItem346.set_Text("MODEL");
			this.layoutControlItem346.set_TextLocation(3);
			this.layoutControlItem346.set_TextSize(new Size(0, 0));
			this.layoutControlItem346.set_TextVisible(false);
			this.layoutControlItem347.set_Control(this.dosyadebibelgeno);
			this.layoutControlItem347.set_CustomizationFormText("SERİ NO");
			this.layoutControlItem347.set_Location(new Point(342, 26));
			this.layoutControlItem347.set_MaxSize(new Size(0, 26));
			this.layoutControlItem347.set_MinSize(new Size(54, 26));
			this.layoutControlItem347.set_Name("layoutControlItem347");
			this.layoutControlItem347.set_Size(new Size(90, 26));
			this.layoutControlItem347.set_SizeConstraintsType(2);
			this.layoutControlItem347.set_Text("SERİ NO");
			this.layoutControlItem347.set_TextLocation(3);
			this.layoutControlItem347.set_TextSize(new Size(0, 0));
			this.layoutControlItem347.set_TextVisible(false);
			this.layoutControlItem348.set_Control(this.dosyadebionaylayan);
			this.layoutControlItem348.set_CustomizationFormText("T");
			this.layoutControlItem348.set_Location(new Point(432, 26));
			this.layoutControlItem348.set_MaxSize(new Size(0, 26));
			this.layoutControlItem348.set_MinSize(new Size(54, 26));
			this.layoutControlItem348.set_Name("layoutControlItem348");
			this.layoutControlItem348.set_Size(new Size(92, 26));
			this.layoutControlItem348.set_SizeConstraintsType(2);
			this.layoutControlItem348.set_Text("T");
			this.layoutControlItem348.set_TextLocation(3);
			this.layoutControlItem348.set_TextSize(new Size(0, 0));
			this.layoutControlItem348.set_TextVisible(false);
			this.layoutControlItem349.set_Control(this.dosyadebiserino);
			this.layoutControlItem349.set_CustomizationFormText("layoutControlItem349");
			this.layoutControlItem349.set_Location(new Point(524, 26));
			this.layoutControlItem349.set_MaxSize(new Size(0, 26));
			this.layoutControlItem349.set_MinSize(new Size(54, 26));
			this.layoutControlItem349.set_Name("layoutControlItem349");
			this.layoutControlItem349.set_Size(new Size(293, 26));
			this.layoutControlItem349.set_SizeConstraintsType(2);
			this.layoutControlItem349.set_TextLocation(3);
			this.layoutControlItem349.set_TextSize(new Size(0, 0));
			this.layoutControlItem349.set_TextVisible(false);
			this.layoutControlItem350.set_Control(this.dosyalblmalz2);
			this.layoutControlItem350.set_CustomizationFormText("layoutControlItem350");
			this.layoutControlItem350.set_Location(new Point(0, 0));
			this.layoutControlItem350.set_MaxSize(new Size(160, 26));
			this.layoutControlItem350.set_MinSize(new Size(160, 26));
			this.layoutControlItem350.set_Name("layoutControlItem350");
			this.layoutControlItem350.set_Size(new Size(160, 26));
			this.layoutControlItem350.set_SizeConstraintsType(2);
			this.layoutControlItem350.set_TextSize(new Size(0, 0));
			this.layoutControlItem350.set_TextVisible(false);
			this.layoutControlItem351.set_Control(this.dosyalbluret2);
			this.layoutControlItem351.set_CustomizationFormText("layoutControlItem351");
			this.layoutControlItem351.set_Location(new Point(160, 0));
			this.layoutControlItem351.set_MaxSize(new Size(93, 26));
			this.layoutControlItem351.set_MinSize(new Size(1, 26));
			this.layoutControlItem351.set_Name("layoutControlItem351");
			this.layoutControlItem351.set_Size(new Size(91, 26));
			this.layoutControlItem351.set_SizeConstraintsType(2);
			this.layoutControlItem351.set_TextSize(new Size(0, 0));
			this.layoutControlItem351.set_TextVisible(false);
			this.layoutControlItem352.set_Control(this.dosyalbldebi);
			this.layoutControlItem352.set_CustomizationFormText("layoutControlItem352");
			this.layoutControlItem352.set_Location(new Point(0, 26));
			this.layoutControlItem352.set_MaxSize(new Size(0, 26));
			this.layoutControlItem352.set_MinSize(new Size(1, 26));
			this.layoutControlItem352.set_Name("layoutControlItem352");
			this.layoutControlItem352.set_Size(new Size(160, 26));
			this.layoutControlItem352.set_SizeConstraintsType(2);
			this.layoutControlItem352.set_TextSize(new Size(0, 0));
			this.layoutControlItem352.set_TextVisible(false);
			this.layoutControlItem353.set_Control(this.dosyalblmodel2);
			this.layoutControlItem353.set_CustomizationFormText("layoutControlItem353");
			this.layoutControlItem353.set_Location(new Point(251, 0));
			this.layoutControlItem353.set_MaxSize(new Size(93, 26));
			this.layoutControlItem353.set_MinSize(new Size(1, 26));
			this.layoutControlItem353.set_Name("layoutControlItem353");
			this.layoutControlItem353.set_Size(new Size(91, 26));
			this.layoutControlItem353.set_SizeConstraintsType(2);
			this.layoutControlItem353.set_TextSize(new Size(0, 0));
			this.layoutControlItem353.set_TextVisible(false);
			this.layoutControlItem354.set_Control(this.dosyalblbelgeno2);
			this.layoutControlItem354.set_CustomizationFormText("layoutControlItem354");
			this.layoutControlItem354.set_Location(new Point(342, 0));
			this.layoutControlItem354.set_MaxSize(new Size(93, 26));
			this.layoutControlItem354.set_MinSize(new Size(1, 26));
			this.layoutControlItem354.set_Name("layoutControlItem354");
			this.layoutControlItem354.set_Size(new Size(90, 26));
			this.layoutControlItem354.set_SizeConstraintsType(2);
			this.layoutControlItem354.set_TextSize(new Size(0, 0));
			this.layoutControlItem354.set_TextVisible(false);
			this.layoutControlItem355.set_Control(this.dosyalblonaylayan2);
			this.layoutControlItem355.set_CustomizationFormText("layoutControlItem355");
			this.layoutControlItem355.set_Location(new Point(432, 0));
			this.layoutControlItem355.set_MaxSize(new Size(93, 26));
			this.layoutControlItem355.set_MinSize(new Size(1, 26));
			this.layoutControlItem355.set_Name("layoutControlItem355");
			this.layoutControlItem355.set_Size(new Size(92, 26));
			this.layoutControlItem355.set_SizeConstraintsType(2);
			this.layoutControlItem355.set_TextSize(new Size(0, 0));
			this.layoutControlItem355.set_TextVisible(false);
			this.layoutControlItem356.set_Control(this.dosyalblserino2);
			this.layoutControlItem356.set_CustomizationFormText("layoutControlItem356");
			this.layoutControlItem356.set_Location(new Point(524, 0));
			this.layoutControlItem356.set_MaxSize(new Size(0, 26));
			this.layoutControlItem356.set_MinSize(new Size(1, 26));
			this.layoutControlItem356.set_Name("layoutControlItem356");
			this.layoutControlItem356.set_Size(new Size(293, 26));
			this.layoutControlItem356.set_SizeConstraintsType(2);
			this.layoutControlItem356.set_TextSize(new Size(0, 0));
			this.layoutControlItem356.set_TextVisible(false);
			this.layoutControlItem357.set_Control(this.dosyalblhortum);
			this.layoutControlItem357.set_CustomizationFormText("layoutControlItem357");
			this.layoutControlItem357.set_Location(new Point(0, 52));
			this.layoutControlItem357.set_MaxSize(new Size(0, 26));
			this.layoutControlItem357.set_MinSize(new Size(1, 26));
			this.layoutControlItem357.set_Name("layoutControlItem357");
			this.layoutControlItem357.set_Size(new Size(160, 360));
			this.layoutControlItem357.set_SizeConstraintsType(2);
			this.layoutControlItem357.set_TextSize(new Size(0, 0));
			this.layoutControlItem357.set_TextVisible(false);
			this.layoutControlItem358.set_Control(this.dosyahortumuretici);
			this.layoutControlItem358.set_CustomizationFormText("layoutControlItem358");
			this.layoutControlItem358.set_Location(new Point(160, 52));
			this.layoutControlItem358.set_MaxSize(new Size(0, 26));
			this.layoutControlItem358.set_MinSize(new Size(54, 26));
			this.layoutControlItem358.set_Name("layoutControlItem358");
			this.layoutControlItem358.set_Size(new Size(91, 360));
			this.layoutControlItem358.set_SizeConstraintsType(2);
			this.layoutControlItem358.set_TextSize(new Size(0, 0));
			this.layoutControlItem358.set_TextVisible(false);
			this.layoutControlItem359.set_Control(this.dosyahortummodel);
			this.layoutControlItem359.set_CustomizationFormText("layoutControlItem359");
			this.layoutControlItem359.set_Location(new Point(251, 52));
			this.layoutControlItem359.set_MaxSize(new Size(0, 26));
			this.layoutControlItem359.set_MinSize(new Size(54, 26));
			this.layoutControlItem359.set_Name("layoutControlItem359");
			this.layoutControlItem359.set_Size(new Size(91, 360));
			this.layoutControlItem359.set_SizeConstraintsType(2);
			this.layoutControlItem359.set_TextSize(new Size(0, 0));
			this.layoutControlItem359.set_TextVisible(false);
			this.layoutControlItem360.set_Control(this.dosyahortumbelgeno);
			this.layoutControlItem360.set_CustomizationFormText("layoutControlItem360");
			this.layoutControlItem360.set_Location(new Point(342, 52));
			this.layoutControlItem360.set_MaxSize(new Size(0, 26));
			this.layoutControlItem360.set_MinSize(new Size(54, 26));
			this.layoutControlItem360.set_Name("layoutControlItem360");
			this.layoutControlItem360.set_Size(new Size(90, 360));
			this.layoutControlItem360.set_SizeConstraintsType(2);
			this.layoutControlItem360.set_TextSize(new Size(0, 0));
			this.layoutControlItem360.set_TextVisible(false);
			this.layoutControlItem361.set_Control(this.dosyahortumonaylayan);
			this.layoutControlItem361.set_CustomizationFormText("layoutControlItem361");
			this.layoutControlItem361.set_Location(new Point(432, 52));
			this.layoutControlItem361.set_MaxSize(new Size(0, 26));
			this.layoutControlItem361.set_MinSize(new Size(54, 26));
			this.layoutControlItem361.set_Name("layoutControlItem361");
			this.layoutControlItem361.set_Size(new Size(92, 360));
			this.layoutControlItem361.set_SizeConstraintsType(2);
			this.layoutControlItem361.set_TextSize(new Size(0, 0));
			this.layoutControlItem361.set_TextVisible(false);
			this.layoutControlItem362.set_Control(this.dosyahortumserino);
			this.layoutControlItem362.set_CustomizationFormText("layoutControlItem362");
			this.layoutControlItem362.set_Location(new Point(524, 52));
			this.layoutControlItem362.set_MaxSize(new Size(0, 26));
			this.layoutControlItem362.set_MinSize(new Size(54, 26));
			this.layoutControlItem362.set_Name("layoutControlItem362");
			this.layoutControlItem362.set_Size(new Size(293, 360));
			this.layoutControlItem362.set_SizeConstraintsType(2);
			this.layoutControlItem362.set_TextSize(new Size(0, 0));
			this.layoutControlItem362.set_TextVisible(false);
			this.dosyalblelektrasnicin.get_AppearanceCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblelektrasnicin.get_AppearanceCaption().get_Options().set_UseFont(true);
			this.dosyalblelektrasnicin.Controls.Add(this.layoutControl24);
			this.dosyalblelektrasnicin.Dock = DockStyle.Top;
			this.dosyalblelektrasnicin.Location = new Point(312, 257);
			this.dosyalblelektrasnicin.Name = "dosyalblelektrasnicin";
			this.dosyalblelektrasnicin.Size = new Size(833, 113);
			this.dosyalblelektrasnicin.TabIndex = 173;
			this.dosyalblelektrasnicin.Text = "ELEKTRİKLİ ASANSÖR İÇİN GEREKEN BİLGİLERİ";
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
			this.layoutControl24.Location = new Point(2, 21);
			this.layoutControl24.Name = "layoutControl24";
			this.layoutControl24.set_Root(this.layoutControlGroup24);
			this.layoutControl24.Size = new Size(829, 90);
			this.layoutControl24.TabIndex = 172;
			this.layoutControl24.Text = "layoutControl24";
			this.dosyamotorserino.set_EnterMoveNextControl(true);
			this.dosyamotorserino.Location = new Point(483, 60);
			this.dosyamotorserino.Name = "dosyamotorserino";
			this.dosyamotorserino.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamotorserino.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamotorserino.Size = new Size(338, 22);
			this.dosyamotorserino.set_StyleController(this.layoutControl24);
			this.dosyamotorserino.TabIndex = 10;
			this.dosyamotoronaylayan.set_EnterMoveNextControl(true);
			this.dosyamotoronaylayan.Location = new Point(391, 60);
			this.dosyamotoronaylayan.Name = "dosyamotoronaylayan";
			this.dosyamotoronaylayan.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamotoronaylayan.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamotoronaylayan.Size = new Size(88, 22);
			this.dosyamotoronaylayan.set_StyleController(this.layoutControl24);
			this.dosyamotoronaylayan.TabIndex = 9;
			this.dosyamotorbelgeno.set_EnterMoveNextControl(true);
			this.dosyamotorbelgeno.Location = new Point(299, 60);
			this.dosyamotorbelgeno.Name = "dosyamotorbelgeno";
			this.dosyamotorbelgeno.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamotorbelgeno.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamotorbelgeno.Size = new Size(88, 22);
			this.dosyamotorbelgeno.set_StyleController(this.layoutControl24);
			this.dosyamotorbelgeno.TabIndex = 8;
			this.dosyamotormodel.set_EnterMoveNextControl(true);
			this.dosyamotormodel.Location = new Point(207, 60);
			this.dosyamotormodel.Name = "dosyamotormodel";
			this.dosyamotormodel.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamotormodel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamotormodel.Size = new Size(88, 22);
			this.dosyamotormodel.set_StyleController(this.layoutControl24);
			this.dosyamotormodel.TabIndex = 7;
			this.dosyamotoruretici.set_EnterMoveNextControl(true);
			this.dosyamotoruretici.Location = new Point(115, 60);
			this.dosyamotoruretici.Name = "dosyamotoruretici";
			this.dosyamotoruretici.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamotoruretici.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamotoruretici.Size = new Size(88, 22);
			this.dosyamotoruretici.set_StyleController(this.layoutControl24);
			this.dosyamotoruretici.TabIndex = 6;
			this.dosyalblmotor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblmotor.Location = new Point(8, 60);
			this.dosyalblmotor.Name = "dosyalblmotor";
			this.dosyalblmotor.Size = new Size(103, 22);
			this.dosyalblmotor.set_StyleController(this.layoutControl24);
			this.dosyalblmotor.TabIndex = 16;
			this.dosyalblmotor.Text = "Motor : ";
			this.dosyalblserino.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblserino.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblserino.set_AutoSizeMode(1);
			this.dosyalblserino.Location = new Point(483, 8);
			this.dosyalblserino.Name = "dosyalblserino";
			this.dosyalblserino.Size = new Size(338, 22);
			this.dosyalblserino.set_StyleController(this.layoutControl24);
			this.dosyalblserino.TabIndex = 15;
			this.dosyalblserino.Text = "ÜR. SERİ NO";
			this.dosyalblonaylayan.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblonaylayan.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblonaylayan.Location = new Point(391, 8);
			this.dosyalblonaylayan.Name = "dosyalblonaylayan";
			this.dosyalblonaylayan.Size = new Size(88, 22);
			this.dosyalblonaylayan.set_StyleController(this.layoutControl24);
			this.dosyalblonaylayan.TabIndex = 14;
			this.dosyalblonaylayan.Text = "ONAYLAYAN";
			this.dosyalblbelgeno.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblbelgeno.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblbelgeno.Location = new Point(299, 8);
			this.dosyalblbelgeno.Name = "dosyalblbelgeno";
			this.dosyalblbelgeno.Size = new Size(88, 22);
			this.dosyalblbelgeno.set_StyleController(this.layoutControl24);
			this.dosyalblbelgeno.TabIndex = 13;
			this.dosyalblbelgeno.Text = "BELGE NO";
			this.dosyalblmodel.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblmodel.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblmodel.Location = new Point(207, 8);
			this.dosyalblmodel.Name = "dosyalblmodel";
			this.dosyalblmodel.Size = new Size(88, 22);
			this.dosyalblmodel.set_StyleController(this.layoutControl24);
			this.dosyalblmodel.TabIndex = 12;
			this.dosyalblmodel.Text = "MODEL";
			this.dosyalblmakine.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblmakine.Location = new Point(8, 34);
			this.dosyalblmakine.Name = "dosyalblmakine";
			this.dosyalblmakine.Size = new Size(103, 22);
			this.dosyalblmakine.set_StyleController(this.layoutControl24);
			this.dosyalblmakine.TabIndex = 11;
			this.dosyalblmakine.Text = "Makine : ";
			this.dosyalbluret.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalbluret.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalbluret.Location = new Point(115, 8);
			this.dosyalbluret.Name = "dosyalbluret";
			this.dosyalbluret.Size = new Size(88, 22);
			this.dosyalbluret.set_StyleController(this.layoutControl24);
			this.dosyalbluret.TabIndex = 10;
			this.dosyalbluret.Text = "ÜRETİCİ";
			this.dosyalblmalz.get_Appearance().set_Font(new Font("Times New Roman", 9f, FontStyle.Bold));
			this.dosyalblmalz.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblmalz.Location = new Point(8, 8);
			this.dosyalblmalz.Name = "dosyalblmalz";
			this.dosyalblmalz.Size = new Size(103, 22);
			this.dosyalblmalz.set_StyleController(this.layoutControl24);
			this.dosyalblmalz.TabIndex = 9;
			this.dosyalblmalz.Text = "MALZEME";
			this.dosyamakineurserno.set_EnterMoveNextControl(true);
			this.dosyamakineurserno.Location = new Point(483, 34);
			this.dosyamakineurserno.Name = "dosyamakineurserno";
			this.dosyamakineurserno.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamakineurserno.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamakineurserno.Size = new Size(338, 22);
			this.dosyamakineurserno.set_StyleController(this.layoutControl24);
			this.dosyamakineurserno.TabIndex = 5;
			this.dosyamakineonaylayan.set_EnterMoveNextControl(true);
			this.dosyamakineonaylayan.Location = new Point(391, 34);
			this.dosyamakineonaylayan.Name = "dosyamakineonaylayan";
			this.dosyamakineonaylayan.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamakineonaylayan.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamakineonaylayan.Size = new Size(88, 22);
			this.dosyamakineonaylayan.set_StyleController(this.layoutControl24);
			this.dosyamakineonaylayan.TabIndex = 4;
			this.dosyamakinebelgeno.set_EnterMoveNextControl(true);
			this.dosyamakinebelgeno.Location = new Point(299, 34);
			this.dosyamakinebelgeno.Name = "dosyamakinebelgeno";
			this.dosyamakinebelgeno.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamakinebelgeno.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamakinebelgeno.Size = new Size(88, 22);
			this.dosyamakinebelgeno.set_StyleController(this.layoutControl24);
			this.dosyamakinebelgeno.TabIndex = 3;
			this.dosyamakinemodel.set_EnterMoveNextControl(true);
			this.dosyamakinemodel.Location = new Point(207, 34);
			this.dosyamakinemodel.Name = "dosyamakinemodel";
			this.dosyamakinemodel.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamakinemodel.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamakinemodel.Size = new Size(88, 22);
			this.dosyamakinemodel.set_StyleController(this.layoutControl24);
			this.dosyamakinemodel.TabIndex = 2;
			this.dosyamakineuret.set_EnterMoveNextControl(true);
			this.dosyamakineuret.Location = new Point(115, 34);
			this.dosyamakineuret.Name = "dosyamakineuret";
			this.dosyamakineuret.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyamakineuret.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyamakineuret.Size = new Size(88, 22);
			this.dosyamakineuret.set_StyleController(this.layoutControl24);
			this.dosyamakineuret.TabIndex = 1;
			this.layoutControlGroup24.set_CustomizationFormText("layoutControlGroup23");
			this.layoutControlGroup24.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup24.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem363,
				this.layoutControlItem364,
				this.layoutControlItem365,
				this.layoutControlItem366,
				this.layoutControlItem367,
				this.layoutControlItem368,
				this.layoutControlItem369,
				this.layoutControlItem370,
				this.layoutControlItem371,
				this.layoutControlItem372,
				this.layoutControlItem373,
				this.layoutControlItem374,
				this.layoutControlItem375,
				this.layoutControlItem376,
				this.layoutControlItem377,
				this.layoutControlItem378,
				this.layoutControlItem379,
				this.layoutControlItem380
			});
			this.layoutControlGroup24.set_Location(new Point(0, 0));
			this.layoutControlGroup24.set_Name("layoutControlGroup23");
			this.layoutControlGroup24.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup24.set_Size(new Size(829, 90));
			this.layoutControlGroup24.set_TextVisible(false);
			this.layoutControlItem363.set_Control(this.dosyamakineuret);
			this.layoutControlItem363.set_CustomizationFormText("MARKA");
			this.layoutControlItem363.set_Location(new Point(107, 26));
			this.layoutControlItem363.set_MaxSize(new Size(0, 26));
			this.layoutControlItem363.set_MinSize(new Size(54, 26));
			this.layoutControlItem363.set_Name("layoutControlItem345");
			this.layoutControlItem363.set_Size(new Size(92, 26));
			this.layoutControlItem363.set_SizeConstraintsType(2);
			this.layoutControlItem363.set_Text("MARKA");
			this.layoutControlItem363.set_TextLocation(3);
			this.layoutControlItem363.set_TextSize(new Size(0, 0));
			this.layoutControlItem363.set_TextVisible(false);
			this.layoutControlItem364.set_Control(this.dosyamakinemodel);
			this.layoutControlItem364.set_CustomizationFormText("MODEL");
			this.layoutControlItem364.set_Location(new Point(199, 26));
			this.layoutControlItem364.set_MaxSize(new Size(0, 26));
			this.layoutControlItem364.set_MinSize(new Size(54, 26));
			this.layoutControlItem364.set_Name("layoutControlItem346");
			this.layoutControlItem364.set_Size(new Size(92, 26));
			this.layoutControlItem364.set_SizeConstraintsType(2);
			this.layoutControlItem364.set_Text("MODEL");
			this.layoutControlItem364.set_TextLocation(3);
			this.layoutControlItem364.set_TextSize(new Size(0, 0));
			this.layoutControlItem364.set_TextVisible(false);
			this.layoutControlItem365.set_Control(this.dosyamakinebelgeno);
			this.layoutControlItem365.set_CustomizationFormText("SERİ NO");
			this.layoutControlItem365.set_Location(new Point(291, 26));
			this.layoutControlItem365.set_MaxSize(new Size(0, 26));
			this.layoutControlItem365.set_MinSize(new Size(54, 26));
			this.layoutControlItem365.set_Name("layoutControlItem347");
			this.layoutControlItem365.set_Size(new Size(92, 26));
			this.layoutControlItem365.set_SizeConstraintsType(2);
			this.layoutControlItem365.set_Text("SERİ NO");
			this.layoutControlItem365.set_TextLocation(3);
			this.layoutControlItem365.set_TextSize(new Size(0, 0));
			this.layoutControlItem365.set_TextVisible(false);
			this.layoutControlItem366.set_Control(this.dosyamakineonaylayan);
			this.layoutControlItem366.set_CustomizationFormText("T");
			this.layoutControlItem366.set_Location(new Point(383, 26));
			this.layoutControlItem366.set_MaxSize(new Size(0, 26));
			this.layoutControlItem366.set_MinSize(new Size(54, 26));
			this.layoutControlItem366.set_Name("layoutControlItem348");
			this.layoutControlItem366.set_Size(new Size(92, 26));
			this.layoutControlItem366.set_SizeConstraintsType(2);
			this.layoutControlItem366.set_Text("T");
			this.layoutControlItem366.set_TextLocation(3);
			this.layoutControlItem366.set_TextSize(new Size(0, 0));
			this.layoutControlItem366.set_TextVisible(false);
			this.layoutControlItem367.set_Control(this.dosyamakineurserno);
			this.layoutControlItem367.set_CustomizationFormText("layoutControlItem349");
			this.layoutControlItem367.set_Location(new Point(475, 26));
			this.layoutControlItem367.set_MaxSize(new Size(0, 26));
			this.layoutControlItem367.set_MinSize(new Size(54, 26));
			this.layoutControlItem367.set_Name("layoutControlItem349");
			this.layoutControlItem367.set_Size(new Size(342, 26));
			this.layoutControlItem367.set_SizeConstraintsType(2);
			this.layoutControlItem367.set_TextLocation(3);
			this.layoutControlItem367.set_TextSize(new Size(0, 0));
			this.layoutControlItem367.set_TextVisible(false);
			this.layoutControlItem368.set_Control(this.dosyalblmalz);
			this.layoutControlItem368.set_CustomizationFormText("layoutControlItem350");
			this.layoutControlItem368.set_Location(new Point(0, 0));
			this.layoutControlItem368.set_MaxSize(new Size(160, 26));
			this.layoutControlItem368.set_MinSize(new Size(40, 26));
			this.layoutControlItem368.set_Name("layoutControlItem350");
			this.layoutControlItem368.set_Size(new Size(107, 26));
			this.layoutControlItem368.set_SizeConstraintsType(2);
			this.layoutControlItem368.set_TextSize(new Size(0, 0));
			this.layoutControlItem368.set_TextVisible(false);
			this.layoutControlItem369.set_Control(this.dosyalbluret);
			this.layoutControlItem369.set_CustomizationFormText("layoutControlItem351");
			this.layoutControlItem369.set_Location(new Point(107, 0));
			this.layoutControlItem369.set_MaxSize(new Size(93, 26));
			this.layoutControlItem369.set_MinSize(new Size(1, 26));
			this.layoutControlItem369.set_Name("layoutControlItem351");
			this.layoutControlItem369.set_Size(new Size(92, 26));
			this.layoutControlItem369.set_SizeConstraintsType(2);
			this.layoutControlItem369.set_TextSize(new Size(0, 0));
			this.layoutControlItem369.set_TextVisible(false);
			this.layoutControlItem370.set_Control(this.dosyalblmakine);
			this.layoutControlItem370.set_CustomizationFormText("layoutControlItem352");
			this.layoutControlItem370.set_Location(new Point(0, 26));
			this.layoutControlItem370.set_MaxSize(new Size(0, 26));
			this.layoutControlItem370.set_MinSize(new Size(1, 26));
			this.layoutControlItem370.set_Name("layoutControlItem352");
			this.layoutControlItem370.set_Size(new Size(107, 26));
			this.layoutControlItem370.set_SizeConstraintsType(2);
			this.layoutControlItem370.set_TextSize(new Size(0, 0));
			this.layoutControlItem370.set_TextVisible(false);
			this.layoutControlItem371.set_Control(this.dosyalblmodel);
			this.layoutControlItem371.set_CustomizationFormText("layoutControlItem353");
			this.layoutControlItem371.set_Location(new Point(199, 0));
			this.layoutControlItem371.set_MaxSize(new Size(93, 26));
			this.layoutControlItem371.set_MinSize(new Size(1, 26));
			this.layoutControlItem371.set_Name("layoutControlItem353");
			this.layoutControlItem371.set_Size(new Size(92, 26));
			this.layoutControlItem371.set_SizeConstraintsType(2);
			this.layoutControlItem371.set_TextSize(new Size(0, 0));
			this.layoutControlItem371.set_TextVisible(false);
			this.layoutControlItem372.set_Control(this.dosyalblbelgeno);
			this.layoutControlItem372.set_CustomizationFormText("layoutControlItem354");
			this.layoutControlItem372.set_Location(new Point(291, 0));
			this.layoutControlItem372.set_MaxSize(new Size(93, 26));
			this.layoutControlItem372.set_MinSize(new Size(1, 26));
			this.layoutControlItem372.set_Name("layoutControlItem354");
			this.layoutControlItem372.set_Size(new Size(92, 26));
			this.layoutControlItem372.set_SizeConstraintsType(2);
			this.layoutControlItem372.set_TextSize(new Size(0, 0));
			this.layoutControlItem372.set_TextVisible(false);
			this.layoutControlItem373.set_Control(this.dosyalblonaylayan);
			this.layoutControlItem373.set_CustomizationFormText("layoutControlItem355");
			this.layoutControlItem373.set_Location(new Point(383, 0));
			this.layoutControlItem373.set_MaxSize(new Size(93, 26));
			this.layoutControlItem373.set_MinSize(new Size(1, 26));
			this.layoutControlItem373.set_Name("layoutControlItem355");
			this.layoutControlItem373.set_Size(new Size(92, 26));
			this.layoutControlItem373.set_SizeConstraintsType(2);
			this.layoutControlItem373.set_TextSize(new Size(0, 0));
			this.layoutControlItem373.set_TextVisible(false);
			this.layoutControlItem374.set_Control(this.dosyalblserino);
			this.layoutControlItem374.set_CustomizationFormText("layoutControlItem356");
			this.layoutControlItem374.set_Location(new Point(475, 0));
			this.layoutControlItem374.set_MaxSize(new Size(0, 26));
			this.layoutControlItem374.set_MinSize(new Size(1, 26));
			this.layoutControlItem374.set_Name("layoutControlItem356");
			this.layoutControlItem374.set_Size(new Size(342, 26));
			this.layoutControlItem374.set_SizeConstraintsType(2);
			this.layoutControlItem374.set_TextSize(new Size(0, 0));
			this.layoutControlItem374.set_TextVisible(false);
			this.layoutControlItem375.set_Control(this.dosyalblmotor);
			this.layoutControlItem375.set_CustomizationFormText("layoutControlItem357");
			this.layoutControlItem375.set_Location(new Point(0, 52));
			this.layoutControlItem375.set_MaxSize(new Size(0, 26));
			this.layoutControlItem375.set_MinSize(new Size(1, 26));
			this.layoutControlItem375.set_Name("layoutControlItem357");
			this.layoutControlItem375.set_Size(new Size(107, 26));
			this.layoutControlItem375.set_SizeConstraintsType(2);
			this.layoutControlItem375.set_TextSize(new Size(0, 0));
			this.layoutControlItem375.set_TextVisible(false);
			this.layoutControlItem376.set_Control(this.dosyamotoruretici);
			this.layoutControlItem376.set_CustomizationFormText("layoutControlItem358");
			this.layoutControlItem376.set_Location(new Point(107, 52));
			this.layoutControlItem376.set_MaxSize(new Size(0, 26));
			this.layoutControlItem376.set_MinSize(new Size(54, 26));
			this.layoutControlItem376.set_Name("layoutControlItem358");
			this.layoutControlItem376.set_Size(new Size(92, 26));
			this.layoutControlItem376.set_SizeConstraintsType(2);
			this.layoutControlItem376.set_TextSize(new Size(0, 0));
			this.layoutControlItem376.set_TextVisible(false);
			this.layoutControlItem377.set_Control(this.dosyamotormodel);
			this.layoutControlItem377.set_CustomizationFormText("layoutControlItem359");
			this.layoutControlItem377.set_Location(new Point(199, 52));
			this.layoutControlItem377.set_MaxSize(new Size(0, 26));
			this.layoutControlItem377.set_MinSize(new Size(54, 26));
			this.layoutControlItem377.set_Name("layoutControlItem359");
			this.layoutControlItem377.set_Size(new Size(92, 26));
			this.layoutControlItem377.set_SizeConstraintsType(2);
			this.layoutControlItem377.set_TextSize(new Size(0, 0));
			this.layoutControlItem377.set_TextVisible(false);
			this.layoutControlItem378.set_Control(this.dosyamotorbelgeno);
			this.layoutControlItem378.set_CustomizationFormText("layoutControlItem360");
			this.layoutControlItem378.set_Location(new Point(291, 52));
			this.layoutControlItem378.set_MaxSize(new Size(0, 26));
			this.layoutControlItem378.set_MinSize(new Size(54, 26));
			this.layoutControlItem378.set_Name("layoutControlItem360");
			this.layoutControlItem378.set_Size(new Size(92, 26));
			this.layoutControlItem378.set_SizeConstraintsType(2);
			this.layoutControlItem378.set_TextSize(new Size(0, 0));
			this.layoutControlItem378.set_TextVisible(false);
			this.layoutControlItem379.set_Control(this.dosyamotoronaylayan);
			this.layoutControlItem379.set_CustomizationFormText("layoutControlItem361");
			this.layoutControlItem379.set_Location(new Point(383, 52));
			this.layoutControlItem379.set_MaxSize(new Size(0, 26));
			this.layoutControlItem379.set_MinSize(new Size(54, 26));
			this.layoutControlItem379.set_Name("layoutControlItem361");
			this.layoutControlItem379.set_Size(new Size(92, 26));
			this.layoutControlItem379.set_SizeConstraintsType(2);
			this.layoutControlItem379.set_TextSize(new Size(0, 0));
			this.layoutControlItem379.set_TextVisible(false);
			this.layoutControlItem380.set_Control(this.dosyamotorserino);
			this.layoutControlItem380.set_CustomizationFormText("layoutControlItem362");
			this.layoutControlItem380.set_Location(new Point(475, 52));
			this.layoutControlItem380.set_MaxSize(new Size(0, 26));
			this.layoutControlItem380.set_MinSize(new Size(54, 26));
			this.layoutControlItem380.set_Name("layoutControlItem362");
			this.layoutControlItem380.set_Size(new Size(342, 26));
			this.layoutControlItem380.set_SizeConstraintsType(2);
			this.layoutControlItem380.set_TextSize(new Size(0, 0));
			this.layoutControlItem380.set_TextVisible(false);
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
			this.layoutControl6.Location = new Point(312, 0);
			this.layoutControl6.Name = "layoutControl6";
			this.layoutControl6.get_OptionsCustomizationForm().set_DesignTimeCustomizationFormPositionAndSize(new Rectangle?(new Rectangle(0, -8, 1382, 784)));
			this.layoutControl6.Padding = new Padding(5);
			this.layoutControl6.set_Root(this.layoutControlGroup10);
			this.layoutControl6.Size = new Size(833, 257);
			this.layoutControl6.TabIndex = 2;
			this.layoutControl6.Text = "layoutControl6";
			this.dosyakapikilit.set_EnterMoveNextControl(true);
			this.dosyakapikilit.Location = new Point(107, 24);
			this.dosyakapikilit.Name = "dosyakapikilit";
			this.dosyakapikilit.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f));
			this.dosyakapikilit.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyakapikilit.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyakapikilit.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyakapikilit.get_Properties().set_ShowAddNewButton(true);
			this.dosyakapikilit.get_Properties().set_View(this.gridView1);
			this.dosyakapikilit.get_Properties().add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.dosyakapikilit.Size = new Size(391, 22);
			this.dosyakapikilit.set_StyleController(this.layoutControl6);
			this.dosyakapikilit.TabIndex = 1;
			this.gridView1.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn64,
				this.gridColumn73,
				this.gridColumn74,
				this.gridColumn75,
				this.gridColumn76,
				this.gridColumn77,
				this.gridColumn78
			});
			this.gridView1.set_FocusRectStyle(1);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.gridView1.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn64.set_Caption("gridColumn64");
			this.gridColumn64.set_FieldName("guid");
			this.gridColumn64.set_Name("gridColumn64");
			this.gridColumn73.set_Caption("gridColumn73");
			this.gridColumn73.set_FieldName("uretici");
			this.gridColumn73.set_Name("gridColumn73");
			this.gridColumn74.set_Caption("gridColumn74");
			this.gridColumn74.set_FieldName("model");
			this.gridColumn74.set_Name("gridColumn74");
			this.gridColumn75.set_Caption("MARKA VE MODEL");
			this.gridColumn75.set_FieldName("MARKA_MODEL");
			this.gridColumn75.set_Name("gridColumn75");
			this.gridColumn75.set_Visible(true);
			this.gridColumn75.set_VisibleIndex(0);
			this.gridColumn76.set_Caption("gridColumn76");
			this.gridColumn76.set_FieldName("serino");
			this.gridColumn76.set_Name("gridColumn76");
			this.gridColumn77.set_Caption("gridColumn77");
			this.gridColumn77.set_FieldName("belgeveren");
			this.gridColumn77.set_Name("gridColumn77");
			this.gridColumn78.set_Caption("gridColumn78");
			this.gridColumn78.set_FieldName("nobo");
			this.gridColumn78.set_Name("gridColumn78");
			this.dosyalblsertf.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblsertf.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblsertf.Location = new Point(673, 3);
			this.dosyalblsertf.Name = "dosyalblsertf";
			this.dosyalblsertf.Size = new Size(157, 17);
			this.dosyalblsertf.set_StyleController(this.layoutControl6);
			this.dosyalblsertf.TabIndex = 153;
			this.dosyalblsertf.Text = "SERTİFİKA";
			this.dosyalblurserno.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblurserno.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyalblurserno.Location = new Point(502, 3);
			this.dosyalblurserno.Name = "dosyalblurserno";
			this.dosyalblurserno.Size = new Size(167, 17);
			this.dosyalblurserno.set_StyleController(this.layoutControl6);
			this.dosyalblurserno.TabIndex = 152;
			this.dosyalblurserno.Text = "ÜR. SERİ NO";
			this.dosyaslblertfsec.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyaslblertfsec.get_Appearance().get_TextOptions().set_HAlignment(2);
			this.dosyaslblertfsec.Location = new Point(3, 3);
			this.dosyaslblertfsec.Name = "dosyaslblertfsec";
			this.dosyaslblertfsec.Size = new Size(495, 17);
			this.dosyaslblertfsec.set_StyleController(this.layoutControl6);
			this.dosyaslblertfsec.TabIndex = 151;
			this.dosyaslblertfsec.Text = "SERTİFİKA SEÇİNİZ";
			this.dosyapanosn.set_EnterMoveNextControl(true);
			this.dosyapanosn.Location = new Point(502, 154);
			this.dosyapanosn.Name = "dosyapanosn";
			this.dosyapanosn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyapanosn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyapanosn.Size = new Size(167, 22);
			this.dosyapanosn.set_StyleController(this.layoutControl6);
			this.dosyapanosn.TabIndex = 12;
			this.dosyapanogor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyapanogor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyapanogor.Location = new Point(676, 154);
			this.dosyapanogor.Name = "dosyapanogor";
			this.dosyapanogor.Size = new Size(151, 22);
			this.dosyapanogor.set_StyleController(this.layoutControl6);
			this.dosyapanogor.TabIndex = 999;
			this.dosyapanogor.Text = "GÖR";
			this.dosyapanogor.Click += new EventHandler(this.dosyapano_click);
			this.dosyapano.set_EnterMoveNextControl(true);
			this.dosyapano.Location = new Point(107, 154);
			this.dosyapano.Name = "dosyapano";
			this.dosyapano.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyapano.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyapano.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyapano.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyapano.get_Properties().set_View(this.searchLookUpEdit6View);
			this.dosyapano.Size = new Size(391, 22);
			this.dosyapano.set_StyleController(this.layoutControl6);
			this.dosyapano.TabIndex = 11;
			this.dosyapano.add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.searchLookUpEdit6View.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn31,
				this.gridColumn32,
				this.gridColumn33,
				this.gridColumn34,
				this.gridColumn35,
				this.gridColumn36
			});
			this.searchLookUpEdit6View.set_FocusRectStyle(1);
			this.searchLookUpEdit6View.set_Name("searchLookUpEdit6View");
			this.searchLookUpEdit6View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit6View.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn31.set_Caption("gridColumn31");
			this.gridColumn31.set_FieldName("guid");
			this.gridColumn31.set_Name("gridColumn31");
			this.gridColumn32.set_Caption("gridColumn32");
			this.gridColumn32.set_FieldName("uretici");
			this.gridColumn32.set_Name("gridColumn32");
			this.gridColumn33.set_Caption("gridColumn33");
			this.gridColumn33.set_FieldName("model");
			this.gridColumn33.set_Name("gridColumn33");
			this.gridColumn34.set_Caption("MARKA VE MODEL");
			this.gridColumn34.set_FieldName("MARKA_MODEL");
			this.gridColumn34.set_Name("gridColumn34");
			this.gridColumn34.set_Visible(true);
			this.gridColumn34.set_VisibleIndex(0);
			this.gridColumn35.set_Caption("gridColumn35");
			this.gridColumn35.set_FieldName("serino");
			this.gridColumn35.set_Name("gridColumn35");
			this.gridColumn36.set_Caption("gridColumn36");
			this.gridColumn36.set_FieldName("belgeveren");
			this.gridColumn36.set_Name("gridColumn36");
			this.dosyapistonvalfisn.set_EnterMoveNextControl(true);
			this.dosyapistonvalfisn.Location = new Point(502, 232);
			this.dosyapistonvalfisn.Name = "dosyapistonvalfisn";
			this.dosyapistonvalfisn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyapistonvalfisn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyapistonvalfisn.Size = new Size(167, 22);
			this.dosyapistonvalfisn.set_StyleController(this.layoutControl6);
			this.dosyapistonvalfisn.TabIndex = 18;
			this.dosyaa3ekipmansn.set_EnterMoveNextControl(true);
			this.dosyaa3ekipmansn.Location = new Point(502, 206);
			this.dosyaa3ekipmansn.Name = "dosyaa3ekipmansn";
			this.dosyaa3ekipmansn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyaa3ekipmansn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyaa3ekipmansn.Size = new Size(167, 22);
			this.dosyaa3ekipmansn.set_StyleController(this.layoutControl6);
			this.dosyaa3ekipmansn.TabIndex = 16;
			this.dosyaregulatorsn.set_EnterMoveNextControl(true);
			this.dosyaregulatorsn.Location = new Point(502, 180);
			this.dosyaregulatorsn.Name = "dosyaregulatorsn";
			this.dosyaregulatorsn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyaregulatorsn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyaregulatorsn.Size = new Size(167, 22);
			this.dosyaregulatorsn.set_StyleController(this.layoutControl6);
			this.dosyaregulatorsn.TabIndex = 14;
			this.dosyakumandakartisn.set_EnterMoveNextControl(true);
			this.dosyakumandakartisn.Location = new Point(502, 128);
			this.dosyakumandakartisn.Name = "dosyakumandakartisn";
			this.dosyakumandakartisn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyakumandakartisn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyakumandakartisn.Size = new Size(167, 22);
			this.dosyakumandakartisn.set_StyleController(this.layoutControl6);
			this.dosyakumandakartisn.TabIndex = 10;
			this.dosyakabintamponsn.set_EnterMoveNextControl(true);
			this.dosyakabintamponsn.Location = new Point(502, 102);
			this.dosyakabintamponsn.Name = "dosyakabintamponsn";
			this.dosyakabintamponsn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyakabintamponsn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyakabintamponsn.Size = new Size(167, 22);
			this.dosyakabintamponsn.set_StyleController(this.layoutControl6);
			this.dosyakabintamponsn.TabIndex = 8;
			this.dosyaagrtamponsn.set_EnterMoveNextControl(true);
			this.dosyaagrtamponsn.Location = new Point(502, 76);
			this.dosyaagrtamponsn.Name = "dosyaagrtamponsn";
			this.dosyaagrtamponsn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyaagrtamponsn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyaagrtamponsn.Size = new Size(167, 22);
			this.dosyaagrtamponsn.set_StyleController(this.layoutControl6);
			this.dosyaagrtamponsn.TabIndex = 6;
			this.dosyafrenbloksn.set_EnterMoveNextControl(true);
			this.dosyafrenbloksn.Location = new Point(502, 50);
			this.dosyafrenbloksn.Name = "dosyafrenbloksn";
			this.dosyafrenbloksn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyafrenbloksn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyafrenbloksn.Size = new Size(167, 22);
			this.dosyafrenbloksn.set_StyleController(this.layoutControl6);
			this.dosyafrenbloksn.TabIndex = 4;
			this.dosyakapikilitsn.set_EnterMoveNextControl(true);
			this.dosyakapikilitsn.Location = new Point(502, 24);
			this.dosyakapikilitsn.Name = "dosyakapikilitsn";
			this.dosyakapikilitsn.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyakapikilitsn.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyakapikilitsn.Size = new Size(167, 22);
			this.dosyakapikilitsn.set_StyleController(this.layoutControl6);
			this.dosyakapikilitsn.TabIndex = 2;
			this.dosyapistonvalfi.set_EnterMoveNextControl(true);
			this.dosyapistonvalfi.Location = new Point(107, 232);
			this.dosyapistonvalfi.Name = "dosyapistonvalfi";
			this.dosyapistonvalfi.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyapistonvalfi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyapistonvalfi.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyapistonvalfi.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyapistonvalfi.get_Properties().set_View(this.searchLookUpEdit9View);
			this.dosyapistonvalfi.Size = new Size(391, 22);
			this.dosyapistonvalfi.set_StyleController(this.layoutControl6);
			this.dosyapistonvalfi.TabIndex = 17;
			this.dosyapistonvalfi.add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.searchLookUpEdit9View.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn49,
				this.gridColumn50,
				this.gridColumn51,
				this.gridColumn52,
				this.gridColumn53,
				this.gridColumn54
			});
			this.searchLookUpEdit9View.set_FocusRectStyle(1);
			this.searchLookUpEdit9View.set_Name("searchLookUpEdit9View");
			this.searchLookUpEdit9View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit9View.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn49.set_Caption("gridColumn49");
			this.gridColumn49.set_FieldName("guid");
			this.gridColumn49.set_Name("gridColumn49");
			this.gridColumn50.set_Caption("gridColumn50");
			this.gridColumn50.set_FieldName("uretici");
			this.gridColumn50.set_Name("gridColumn50");
			this.gridColumn51.set_Caption("gridColumn51");
			this.gridColumn51.set_FieldName("model");
			this.gridColumn51.set_Name("gridColumn51");
			this.gridColumn52.set_Caption("MARKA VE MODEL");
			this.gridColumn52.set_FieldName("MARKA_MODEL");
			this.gridColumn52.set_Name("gridColumn52");
			this.gridColumn52.set_Visible(true);
			this.gridColumn52.set_VisibleIndex(0);
			this.gridColumn53.set_Caption("gridColumn53");
			this.gridColumn53.set_FieldName("serino");
			this.gridColumn53.set_Name("gridColumn53");
			this.gridColumn54.set_Caption("gridColumn54");
			this.gridColumn54.set_FieldName("belgeveren");
			this.gridColumn54.set_Name("gridColumn54");
			this.dosyaa3ekipman.set_EnterMoveNextControl(true);
			this.dosyaa3ekipman.Location = new Point(107, 206);
			this.dosyaa3ekipman.Name = "dosyaa3ekipman";
			this.dosyaa3ekipman.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyaa3ekipman.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyaa3ekipman.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyaa3ekipman.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyaa3ekipman.get_Properties().set_View(this.searchLookUpEdit8View);
			this.dosyaa3ekipman.Size = new Size(391, 22);
			this.dosyaa3ekipman.set_StyleController(this.layoutControl6);
			this.dosyaa3ekipman.TabIndex = 15;
			this.dosyaa3ekipman.add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.searchLookUpEdit8View.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn43,
				this.gridColumn44,
				this.gridColumn45,
				this.gridColumn46,
				this.gridColumn47,
				this.gridColumn48
			});
			this.searchLookUpEdit8View.set_FocusRectStyle(1);
			this.searchLookUpEdit8View.set_Name("searchLookUpEdit8View");
			this.searchLookUpEdit8View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit8View.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn43.set_Caption("gridColumn43");
			this.gridColumn43.set_FieldName("guid");
			this.gridColumn43.set_Name("gridColumn43");
			this.gridColumn44.set_Caption("gridColumn44");
			this.gridColumn44.set_FieldName("uretici");
			this.gridColumn44.set_Name("gridColumn44");
			this.gridColumn45.set_Caption("gridColumn45");
			this.gridColumn45.set_FieldName("model");
			this.gridColumn45.set_Name("gridColumn45");
			this.gridColumn46.set_Caption("MARKA VE MODEL");
			this.gridColumn46.set_FieldName("MARKA_MODEL");
			this.gridColumn46.set_Name("gridColumn46");
			this.gridColumn46.set_Visible(true);
			this.gridColumn46.set_VisibleIndex(0);
			this.gridColumn47.set_Caption("gridColumn47");
			this.gridColumn47.set_FieldName("serino");
			this.gridColumn47.set_Name("gridColumn47");
			this.gridColumn48.set_Caption("gridColumn48");
			this.gridColumn48.set_FieldName("belgeveren");
			this.gridColumn48.set_Name("gridColumn48");
			this.dosyaregulator.Enabled = false;
			this.dosyaregulator.set_EnterMoveNextControl(true);
			this.dosyaregulator.Location = new Point(107, 180);
			this.dosyaregulator.Name = "dosyaregulator";
			this.dosyaregulator.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyaregulator.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyaregulator.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyaregulator.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyaregulator.get_Properties().set_View(this.searchLookUpEdit7View);
			this.dosyaregulator.Size = new Size(391, 22);
			this.dosyaregulator.set_StyleController(this.layoutControl6);
			this.dosyaregulator.TabIndex = 13;
			this.dosyaregulator.add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.dosyaregulator.add_EditValueChanged(new EventHandler(this.dosyaregulator_EditValueChanged));
			this.searchLookUpEdit7View.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn37,
				this.gridColumn38,
				this.gridColumn39,
				this.gridColumn40,
				this.gridColumn41,
				this.gridColumn42
			});
			this.searchLookUpEdit7View.set_FocusRectStyle(1);
			this.searchLookUpEdit7View.set_Name("searchLookUpEdit7View");
			this.searchLookUpEdit7View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit7View.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn37.set_Caption("gridColumn37");
			this.gridColumn37.set_FieldName("guid");
			this.gridColumn37.set_Name("gridColumn37");
			this.gridColumn38.set_Caption("gridColumn38");
			this.gridColumn38.set_FieldName("uretici");
			this.gridColumn38.set_Name("gridColumn38");
			this.gridColumn39.set_Caption("gridColumn39");
			this.gridColumn39.set_FieldName("model");
			this.gridColumn39.set_Name("gridColumn39");
			this.gridColumn40.set_Caption("MARKA VE MODEL");
			this.gridColumn40.set_FieldName("MARKA_MODEL");
			this.gridColumn40.set_Name("gridColumn40");
			this.gridColumn40.set_Visible(true);
			this.gridColumn40.set_VisibleIndex(0);
			this.gridColumn41.set_Caption("gridColumn41");
			this.gridColumn41.set_FieldName("serino");
			this.gridColumn41.set_Name("gridColumn41");
			this.gridColumn42.set_Caption("gridColumn42");
			this.gridColumn42.set_FieldName("belgeveren");
			this.gridColumn42.set_Name("gridColumn42");
			this.dosyakumandakarti.set_EnterMoveNextControl(true);
			this.dosyakumandakarti.Location = new Point(107, 128);
			this.dosyakumandakarti.Name = "dosyakumandakarti";
			this.dosyakumandakarti.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyakumandakarti.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyakumandakarti.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyakumandakarti.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyakumandakarti.get_Properties().set_View(this.searchLookUpEdit5View);
			this.dosyakumandakarti.Size = new Size(391, 22);
			this.dosyakumandakarti.set_StyleController(this.layoutControl6);
			this.dosyakumandakarti.TabIndex = 9;
			this.dosyakumandakarti.add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.searchLookUpEdit5View.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn25,
				this.gridColumn26,
				this.gridColumn27,
				this.gridColumn28,
				this.gridColumn29,
				this.gridColumn30
			});
			this.searchLookUpEdit5View.set_FocusRectStyle(1);
			this.searchLookUpEdit5View.set_Name("searchLookUpEdit5View");
			this.searchLookUpEdit5View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit5View.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn25.set_Caption("gridColumn25");
			this.gridColumn25.set_FieldName("guid");
			this.gridColumn25.set_Name("gridColumn25");
			this.gridColumn26.set_Caption("gridColumn26");
			this.gridColumn26.set_FieldName("uretici");
			this.gridColumn26.set_Name("gridColumn26");
			this.gridColumn27.set_Caption("gridColumn27");
			this.gridColumn27.set_FieldName("model");
			this.gridColumn27.set_Name("gridColumn27");
			this.gridColumn28.set_Caption("MARKA VE MODEL");
			this.gridColumn28.set_FieldName("MARKA_MODEL");
			this.gridColumn28.set_Name("gridColumn28");
			this.gridColumn28.set_Visible(true);
			this.gridColumn28.set_VisibleIndex(0);
			this.gridColumn29.set_Caption("gridColumn29");
			this.gridColumn29.set_FieldName("serino");
			this.gridColumn29.set_Name("gridColumn29");
			this.gridColumn30.set_Caption("gridColumn30");
			this.gridColumn30.set_FieldName("belgeveren");
			this.gridColumn30.set_Name("gridColumn30");
			this.dosyakabintampon.set_EnterMoveNextControl(true);
			this.dosyakabintampon.Location = new Point(107, 102);
			this.dosyakabintampon.Name = "dosyakabintampon";
			this.dosyakabintampon.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyakabintampon.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyakabintampon.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyakabintampon.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyakabintampon.get_Properties().set_View(this.searchLookUpEdit4View);
			this.dosyakabintampon.Size = new Size(391, 22);
			this.dosyakabintampon.set_StyleController(this.layoutControl6);
			this.dosyakabintampon.TabIndex = 7;
			this.dosyakabintampon.add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.searchLookUpEdit4View.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn19,
				this.gridColumn20,
				this.gridColumn21,
				this.gridColumn22,
				this.gridColumn23,
				this.gridColumn24
			});
			this.searchLookUpEdit4View.set_FocusRectStyle(1);
			this.searchLookUpEdit4View.set_Name("searchLookUpEdit4View");
			this.searchLookUpEdit4View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit4View.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn19.set_Caption("gridColumn19");
			this.gridColumn19.set_FieldName("guid");
			this.gridColumn19.set_Name("gridColumn19");
			this.gridColumn20.set_Caption("gridColumn20");
			this.gridColumn20.set_FieldName("uretici");
			this.gridColumn20.set_Name("gridColumn20");
			this.gridColumn21.set_Caption("gridColumn21");
			this.gridColumn21.set_FieldName("model");
			this.gridColumn21.set_Name("gridColumn21");
			this.gridColumn22.set_Caption("MARKA VE MODEL");
			this.gridColumn22.set_FieldName("MARKA_MODEL");
			this.gridColumn22.set_Name("gridColumn22");
			this.gridColumn22.set_Visible(true);
			this.gridColumn22.set_VisibleIndex(0);
			this.gridColumn23.set_Caption("gridColumn23");
			this.gridColumn23.set_FieldName("serino");
			this.gridColumn23.set_Name("gridColumn23");
			this.gridColumn24.set_Caption("gridColumn24");
			this.gridColumn24.set_FieldName("belgeveren");
			this.gridColumn24.set_Name("gridColumn24");
			this.dosyaagrtampon.set_EnterMoveNextControl(true);
			this.dosyaagrtampon.Location = new Point(107, 76);
			this.dosyaagrtampon.Name = "dosyaagrtampon";
			this.dosyaagrtampon.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyaagrtampon.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyaagrtampon.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyaagrtampon.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyaagrtampon.get_Properties().set_View(this.searchLookUpEdit3View);
			this.dosyaagrtampon.Size = new Size(391, 22);
			this.dosyaagrtampon.set_StyleController(this.layoutControl6);
			this.dosyaagrtampon.TabIndex = 5;
			this.dosyaagrtampon.add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.searchLookUpEdit3View.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn13,
				this.gridColumn14,
				this.gridColumn15,
				this.gridColumn16,
				this.gridColumn17,
				this.gridColumn18
			});
			this.searchLookUpEdit3View.set_FocusRectStyle(1);
			this.searchLookUpEdit3View.set_Name("searchLookUpEdit3View");
			this.searchLookUpEdit3View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit3View.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn13.set_Caption("gridColumn13");
			this.gridColumn13.set_FieldName("guid");
			this.gridColumn13.set_Name("gridColumn13");
			this.gridColumn14.set_Caption("gridColumn14");
			this.gridColumn14.set_FieldName("serino");
			this.gridColumn14.set_Name("gridColumn14");
			this.gridColumn15.set_Caption("gridColumn15");
			this.gridColumn15.set_FieldName("model");
			this.gridColumn15.set_Name("gridColumn15");
			this.gridColumn16.set_Caption("MARKA VE MODEL");
			this.gridColumn16.set_FieldName("MARKA_MODEL");
			this.gridColumn16.set_Name("gridColumn16");
			this.gridColumn16.set_Visible(true);
			this.gridColumn16.set_VisibleIndex(0);
			this.gridColumn17.set_Caption("gridColumn17");
			this.gridColumn17.set_FieldName("serino");
			this.gridColumn17.set_Name("gridColumn17");
			this.gridColumn18.set_Caption("gridColumn18");
			this.gridColumn18.set_FieldName("belgeveren");
			this.gridColumn18.set_Name("gridColumn18");
			this.dosyafrenblok.Enabled = false;
			this.dosyafrenblok.set_EnterMoveNextControl(true);
			this.dosyafrenblok.Location = new Point(107, 50);
			this.dosyafrenblok.Name = "dosyafrenblok";
			this.dosyafrenblok.get_Properties().get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.dosyafrenblok.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dosyafrenblok.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5),
				new EditorButton(4)
			});
			this.dosyafrenblok.get_Properties().set_NullText("SEÇİNİZ");
			this.dosyafrenblok.get_Properties().set_View(this.searchLookUpEdit2View);
			this.dosyafrenblok.Size = new Size(391, 22);
			this.dosyafrenblok.set_StyleController(this.layoutControl6);
			this.dosyafrenblok.TabIndex = 3;
			this.dosyafrenblok.add_ButtonClick(new ButtonPressedEventHandler(this.sertifikaekler));
			this.dosyafrenblok.add_EditValueChanged(new EventHandler(this.dosyafrenblok_EditValueChanged));
			this.searchLookUpEdit2View.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn10,
				this.gridColumn11,
				this.gridColumn12,
				this.gridColumn55,
				this.gridColumn56,
				this.gridColumn57
			});
			this.searchLookUpEdit2View.set_FocusRectStyle(1);
			this.searchLookUpEdit2View.set_Name("searchLookUpEdit2View");
			this.searchLookUpEdit2View.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.searchLookUpEdit2View.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn10.set_Caption("gridColumn7");
			this.gridColumn10.set_FieldName("guid");
			this.gridColumn10.set_Name("gridColumn10");
			this.gridColumn11.set_Caption("gridColumn8");
			this.gridColumn11.set_FieldName("uretici");
			this.gridColumn11.set_Name("gridColumn11");
			this.gridColumn12.set_Caption("gridColumn9");
			this.gridColumn12.set_FieldName("model");
			this.gridColumn12.set_Name("gridColumn12");
			this.gridColumn55.set_Caption("MARKA VE MODEL");
			this.gridColumn55.set_FieldName("MARKA_MODEL");
			this.gridColumn55.set_Name("gridColumn55");
			this.gridColumn55.set_Visible(true);
			this.gridColumn55.set_VisibleIndex(0);
			this.gridColumn56.set_Caption("gridColumn11");
			this.gridColumn56.set_FieldName("serino");
			this.gridColumn56.set_Name("gridColumn56");
			this.gridColumn57.set_Caption("gridColumn12");
			this.gridColumn57.set_FieldName("belgeveren");
			this.gridColumn57.set_Name("gridColumn57");
			this.dosyaa3ekipmangor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyaa3ekipmangor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyaa3ekipmangor.Location = new Point(676, 206);
			this.dosyaa3ekipmangor.Name = "dosyaa3ekipmangor";
			this.dosyaa3ekipmangor.Size = new Size(151, 22);
			this.dosyaa3ekipmangor.set_StyleController(this.layoutControl6);
			this.dosyaa3ekipmangor.TabIndex = 999;
			this.dosyaa3ekipmangor.Text = "GÖR";
			this.dosyaa3ekipmangor.Click += new EventHandler(this.dosyaa3ekipman_click);
			this.dosyapistonvalfigor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyapistonvalfigor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyapistonvalfigor.Location = new Point(676, 232);
			this.dosyapistonvalfigor.Name = "dosyapistonvalfigor";
			this.dosyapistonvalfigor.Size = new Size(151, 22);
			this.dosyapistonvalfigor.set_StyleController(this.layoutControl6);
			this.dosyapistonvalfigor.TabIndex = 999;
			this.dosyapistonvalfigor.Text = "GÖR";
			this.dosyapistonvalfigor.Click += new EventHandler(this.dosyapistonvalfi_click);
			this.dosyaregulatorgor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyaregulatorgor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyaregulatorgor.Location = new Point(676, 180);
			this.dosyaregulatorgor.Name = "dosyaregulatorgor";
			this.dosyaregulatorgor.Size = new Size(151, 22);
			this.dosyaregulatorgor.set_StyleController(this.layoutControl6);
			this.dosyaregulatorgor.TabIndex = 999;
			this.dosyaregulatorgor.Text = "GÖR";
			this.dosyaregulatorgor.Click += new EventHandler(this.dosyaregulator_click);
			this.dosyakumandakartigor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyakumandakartigor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyakumandakartigor.Location = new Point(676, 128);
			this.dosyakumandakartigor.Name = "dosyakumandakartigor";
			this.dosyakumandakartigor.Size = new Size(151, 22);
			this.dosyakumandakartigor.set_StyleController(this.layoutControl6);
			this.dosyakumandakartigor.TabIndex = 999;
			this.dosyakumandakartigor.Text = "GÖR";
			this.dosyakumandakartigor.Click += new EventHandler(this.dosyakumandakarti_click);
			this.dosyakabintampongor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyakabintampongor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyakabintampongor.Location = new Point(676, 102);
			this.dosyakabintampongor.Name = "dosyakabintampongor";
			this.dosyakabintampongor.Size = new Size(151, 22);
			this.dosyakabintampongor.set_StyleController(this.layoutControl6);
			this.dosyakabintampongor.TabIndex = 999;
			this.dosyakabintampongor.Text = "GÖR";
			this.dosyakabintampongor.Click += new EventHandler(this.dosyakabintampon_click);
			this.dosyaagrtampongor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyaagrtampongor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyaagrtampongor.Location = new Point(676, 76);
			this.dosyaagrtampongor.Name = "dosyaagrtampongor";
			this.dosyaagrtampongor.Size = new Size(151, 22);
			this.dosyaagrtampongor.set_StyleController(this.layoutControl6);
			this.dosyaagrtampongor.TabIndex = 999;
			this.dosyaagrtampongor.Text = "GÖR";
			this.dosyaagrtampongor.Click += new EventHandler(this.dosyaagrtampon_click);
			this.dosyafrenblokgor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyafrenblokgor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyafrenblokgor.Location = new Point(676, 50);
			this.dosyafrenblokgor.Name = "dosyafrenblokgor";
			this.dosyafrenblokgor.Size = new Size(151, 22);
			this.dosyafrenblokgor.set_StyleController(this.layoutControl6);
			this.dosyafrenblokgor.TabIndex = 999;
			this.dosyafrenblokgor.Text = "GÖR";
			this.dosyafrenblokgor.Click += new EventHandler(this.dosyafrenblok_click);
			this.dosyakapikilitgor.get_Appearance().set_Font(new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyakapikilitgor.get_Appearance().get_Options().set_UseFont(true);
			this.dosyakapikilitgor.Location = new Point(676, 24);
			this.dosyakapikilitgor.Name = "dosyakapikilitgor";
			this.dosyakapikilitgor.Size = new Size(151, 22);
			this.dosyakapikilitgor.set_StyleController(this.layoutControl6);
			this.dosyakapikilitgor.TabIndex = 999;
			this.dosyakapikilitgor.Text = "GÖR";
			this.dosyakapikilitgor.Click += new EventHandler(this.dosyakapikilitgor_Click);
			this.layoutControlGroup10.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup10.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup10.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem103,
				this.layoutControlItem104,
				this.layoutControlItem105,
				this.layoutControlItem106,
				this.layoutControlItem107,
				this.layoutControlItem108,
				this.layoutControlItem109,
				this.layoutControlItem110,
				this.dosyafrenbloklbl,
				this.dosyaagrtamponlbl,
				this.dosyakabintamponlbl,
				this.dosyakumandakartilbl,
				this.dosyaregulatorlbl,
				this.dosyaa3ekipmanlbl,
				this.dosyapistonvalfilbl,
				this.layoutControlItem127,
				this.layoutControlItem128,
				this.layoutControlItem129,
				this.layoutControlItem130,
				this.layoutControlItem131,
				this.layoutControlItem132,
				this.layoutControlItem133,
				this.layoutControlItem134,
				this.dosyapanolbl,
				this.layoutControlItem138,
				this.layoutControlItem139,
				this.layoutControlItem140,
				this.layoutControlItem141,
				this.layoutControlItem142,
				this.dosyakapikilitlbl
			});
			this.layoutControlGroup10.set_Location(new Point(0, 0));
			this.layoutControlGroup10.set_Name("layoutControlGroup1");
			this.layoutControlGroup10.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlGroup10.set_Size(new Size(833, 257));
			this.layoutControlGroup10.set_TextVisible(false);
			this.layoutControlItem103.set_Control(this.dosyakapikilitgor);
			this.layoutControlItem103.set_CustomizationFormText("layoutControlItem10");
			this.layoutControlItem103.set_Location(new Point(670, 21));
			this.layoutControlItem103.set_Name("layoutControlItem10");
			this.layoutControlItem103.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem103.set_Size(new Size(161, 26));
			this.layoutControlItem103.set_TextSize(new Size(0, 0));
			this.layoutControlItem103.set_TextVisible(false);
			this.layoutControlItem104.set_Control(this.dosyafrenblokgor);
			this.layoutControlItem104.set_CustomizationFormText("layoutControlItem11");
			this.layoutControlItem104.set_Location(new Point(670, 47));
			this.layoutControlItem104.set_Name("layoutControlItem11");
			this.layoutControlItem104.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem104.set_Size(new Size(161, 26));
			this.layoutControlItem104.set_TextSize(new Size(0, 0));
			this.layoutControlItem104.set_TextVisible(false);
			this.layoutControlItem105.set_Control(this.dosyaagrtampongor);
			this.layoutControlItem105.set_CustomizationFormText("layoutControlItem12");
			this.layoutControlItem105.set_Location(new Point(670, 73));
			this.layoutControlItem105.set_Name("layoutControlItem12");
			this.layoutControlItem105.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem105.set_Size(new Size(161, 26));
			this.layoutControlItem105.set_TextSize(new Size(0, 0));
			this.layoutControlItem105.set_TextVisible(false);
			this.layoutControlItem106.set_Control(this.dosyakabintampongor);
			this.layoutControlItem106.set_CustomizationFormText("layoutControlItem13");
			this.layoutControlItem106.set_Location(new Point(670, 99));
			this.layoutControlItem106.set_Name("layoutControlItem13");
			this.layoutControlItem106.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem106.set_Size(new Size(161, 26));
			this.layoutControlItem106.set_TextSize(new Size(0, 0));
			this.layoutControlItem106.set_TextVisible(false);
			this.layoutControlItem107.set_Control(this.dosyakumandakartigor);
			this.layoutControlItem107.set_CustomizationFormText("layoutControlItem14");
			this.layoutControlItem107.set_Location(new Point(670, 125));
			this.layoutControlItem107.set_Name("layoutControlItem14");
			this.layoutControlItem107.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem107.set_Size(new Size(161, 26));
			this.layoutControlItem107.set_TextSize(new Size(0, 0));
			this.layoutControlItem107.set_TextVisible(false);
			this.layoutControlItem108.set_Control(this.dosyaregulatorgor);
			this.layoutControlItem108.set_CustomizationFormText("layoutControlItem16");
			this.layoutControlItem108.set_Location(new Point(670, 177));
			this.layoutControlItem108.set_Name("layoutControlItem16");
			this.layoutControlItem108.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem108.set_Size(new Size(161, 26));
			this.layoutControlItem108.set_TextSize(new Size(0, 0));
			this.layoutControlItem108.set_TextVisible(false);
			this.layoutControlItem109.set_Control(this.dosyapistonvalfigor);
			this.layoutControlItem109.set_CustomizationFormText("layoutControlItem17");
			this.layoutControlItem109.set_Location(new Point(670, 229));
			this.layoutControlItem109.set_Name("layoutControlItem17");
			this.layoutControlItem109.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem109.set_Size(new Size(161, 26));
			this.layoutControlItem109.set_TextSize(new Size(0, 0));
			this.layoutControlItem109.set_TextVisible(false);
			this.layoutControlItem110.set_Control(this.dosyaa3ekipmangor);
			this.layoutControlItem110.set_CustomizationFormText("layoutControlItem38");
			this.layoutControlItem110.set_Location(new Point(670, 203));
			this.layoutControlItem110.set_Name("layoutControlItem38");
			this.layoutControlItem110.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem110.set_Size(new Size(161, 26));
			this.layoutControlItem110.set_TextSize(new Size(0, 0));
			this.layoutControlItem110.set_TextVisible(false);
			this.dosyafrenbloklbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyafrenbloklbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyafrenbloklbl.set_Control(this.dosyafrenblok);
			this.dosyafrenbloklbl.set_CustomizationFormText("FREN BLOĞU");
			this.dosyafrenbloklbl.set_Location(new Point(0, 47));
			this.dosyafrenbloklbl.set_Name("dosyafrenbloklbl");
			this.dosyafrenbloklbl.set_Size(new Size(499, 26));
			this.dosyafrenbloklbl.set_Text("Fren Bloğu : ");
			this.dosyafrenbloklbl.set_TextSize(new Size(101, 13));
			this.dosyaagrtamponlbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyaagrtamponlbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyaagrtamponlbl.set_Control(this.dosyaagrtampon);
			this.dosyaagrtamponlbl.set_CustomizationFormText("AĞIRLIK TAMPONU");
			this.dosyaagrtamponlbl.set_Location(new Point(0, 73));
			this.dosyaagrtamponlbl.set_Name("dosyaagrtamponlbl");
			this.dosyaagrtamponlbl.set_Size(new Size(499, 26));
			this.dosyaagrtamponlbl.set_Text("Ağırlık Tamponu : ");
			this.dosyaagrtamponlbl.set_TextSize(new Size(101, 13));
			this.dosyakabintamponlbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyakabintamponlbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyakabintamponlbl.set_Control(this.dosyakabintampon);
			this.dosyakabintamponlbl.set_CustomizationFormText("KABİN TAMPONU");
			this.dosyakabintamponlbl.set_Location(new Point(0, 99));
			this.dosyakabintamponlbl.set_Name("dosyakabintamponlbl");
			this.dosyakabintamponlbl.set_Size(new Size(499, 26));
			this.dosyakabintamponlbl.set_Text("Kabin Tamponu : ");
			this.dosyakabintamponlbl.set_TextSize(new Size(101, 13));
			this.dosyakumandakartilbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyakumandakartilbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyakumandakartilbl.set_Control(this.dosyakumandakarti);
			this.dosyakumandakartilbl.set_CustomizationFormText("KUMANDA KARTI");
			this.dosyakumandakartilbl.set_Location(new Point(0, 125));
			this.dosyakumandakartilbl.set_Name("dosyakumandakartilbl");
			this.dosyakumandakartilbl.set_Size(new Size(499, 26));
			this.dosyakumandakartilbl.set_Text("Kumanda Kartı : ");
			this.dosyakumandakartilbl.set_TextSize(new Size(101, 13));
			this.dosyaregulatorlbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyaregulatorlbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyaregulatorlbl.set_Control(this.dosyaregulator);
			this.dosyaregulatorlbl.set_CustomizationFormText("REGÜLATÖR");
			this.dosyaregulatorlbl.set_Location(new Point(0, 177));
			this.dosyaregulatorlbl.set_Name("dosyaregulatorlbl");
			this.dosyaregulatorlbl.set_Size(new Size(499, 26));
			this.dosyaregulatorlbl.set_Text("Regülatör : ");
			this.dosyaregulatorlbl.set_TextSize(new Size(101, 13));
			this.dosyaa3ekipmanlbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyaa3ekipmanlbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyaa3ekipmanlbl.set_Control(this.dosyaa3ekipman);
			this.dosyaa3ekipmanlbl.set_CustomizationFormText("A3 EKİPMANI");
			this.dosyaa3ekipmanlbl.set_Location(new Point(0, 203));
			this.dosyaa3ekipmanlbl.set_Name("dosyaa3ekipmanlbl");
			this.dosyaa3ekipmanlbl.set_Size(new Size(499, 26));
			this.dosyaa3ekipmanlbl.set_Text("A3 Ekipmanı : ");
			this.dosyaa3ekipmanlbl.set_TextSize(new Size(101, 13));
			this.dosyapistonvalfilbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyapistonvalfilbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyapistonvalfilbl.set_Control(this.dosyapistonvalfi);
			this.dosyapistonvalfilbl.set_CustomizationFormText("PİSTON VALFİ");
			this.dosyapistonvalfilbl.set_Location(new Point(0, 229));
			this.dosyapistonvalfilbl.set_Name("dosyapistonvalfilbl");
			this.dosyapistonvalfilbl.set_Size(new Size(499, 26));
			this.dosyapistonvalfilbl.set_Text("Piston Valfi : ");
			this.dosyapistonvalfilbl.set_TextSize(new Size(101, 13));
			this.layoutControlItem127.set_Control(this.dosyakapikilitsn);
			this.layoutControlItem127.set_CustomizationFormText("layoutControlItem52");
			this.layoutControlItem127.set_Location(new Point(499, 21));
			this.layoutControlItem127.set_Name("layoutControlItem52");
			this.layoutControlItem127.set_Size(new Size(171, 26));
			this.layoutControlItem127.set_TextSize(new Size(0, 0));
			this.layoutControlItem127.set_TextVisible(false);
			this.layoutControlItem128.set_Control(this.dosyafrenbloksn);
			this.layoutControlItem128.set_CustomizationFormText("layoutControlItem60");
			this.layoutControlItem128.set_Location(new Point(499, 47));
			this.layoutControlItem128.set_Name("layoutControlItem60");
			this.layoutControlItem128.set_Size(new Size(171, 26));
			this.layoutControlItem128.set_TextSize(new Size(0, 0));
			this.layoutControlItem128.set_TextVisible(false);
			this.layoutControlItem129.set_Control(this.dosyaagrtamponsn);
			this.layoutControlItem129.set_CustomizationFormText("layoutControlItem71");
			this.layoutControlItem129.set_Location(new Point(499, 73));
			this.layoutControlItem129.set_Name("layoutControlItem71");
			this.layoutControlItem129.set_Size(new Size(171, 26));
			this.layoutControlItem129.set_TextSize(new Size(0, 0));
			this.layoutControlItem129.set_TextVisible(false);
			this.layoutControlItem130.set_Control(this.dosyakabintamponsn);
			this.layoutControlItem130.set_CustomizationFormText("layoutControlItem78");
			this.layoutControlItem130.set_Location(new Point(499, 99));
			this.layoutControlItem130.set_Name("layoutControlItem78");
			this.layoutControlItem130.set_Size(new Size(171, 26));
			this.layoutControlItem130.set_TextSize(new Size(0, 0));
			this.layoutControlItem130.set_TextVisible(false);
			this.layoutControlItem131.set_Control(this.dosyakumandakartisn);
			this.layoutControlItem131.set_CustomizationFormText("layoutControlItem84");
			this.layoutControlItem131.set_Location(new Point(499, 125));
			this.layoutControlItem131.set_Name("layoutControlItem84");
			this.layoutControlItem131.set_Size(new Size(171, 26));
			this.layoutControlItem131.set_TextSize(new Size(0, 0));
			this.layoutControlItem131.set_TextVisible(false);
			this.layoutControlItem132.set_Control(this.dosyaregulatorsn);
			this.layoutControlItem132.set_CustomizationFormText("layoutControlItem85");
			this.layoutControlItem132.set_Location(new Point(499, 177));
			this.layoutControlItem132.set_Name("layoutControlItem85");
			this.layoutControlItem132.set_Size(new Size(171, 26));
			this.layoutControlItem132.set_TextSize(new Size(0, 0));
			this.layoutControlItem132.set_TextVisible(false);
			this.layoutControlItem133.set_Control(this.dosyaa3ekipmansn);
			this.layoutControlItem133.set_CustomizationFormText("layoutControlItem86");
			this.layoutControlItem133.set_Location(new Point(499, 203));
			this.layoutControlItem133.set_Name("layoutControlItem86");
			this.layoutControlItem133.set_Size(new Size(171, 26));
			this.layoutControlItem133.set_TextSize(new Size(0, 0));
			this.layoutControlItem133.set_TextVisible(false);
			this.layoutControlItem134.set_Control(this.dosyapistonvalfisn);
			this.layoutControlItem134.set_CustomizationFormText("layoutControlItem87");
			this.layoutControlItem134.set_Location(new Point(499, 229));
			this.layoutControlItem134.set_Name("layoutControlItem87");
			this.layoutControlItem134.set_Size(new Size(171, 26));
			this.layoutControlItem134.set_TextSize(new Size(0, 0));
			this.layoutControlItem134.set_TextVisible(false);
			this.dosyapanolbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyapanolbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyapanolbl.set_Control(this.dosyapano);
			this.dosyapanolbl.set_CustomizationFormText("PANO");
			this.dosyapanolbl.set_Location(new Point(0, 151));
			this.dosyapanolbl.set_Name("dosyapanolbl");
			this.dosyapanolbl.set_Size(new Size(499, 26));
			this.dosyapanolbl.set_Text("Pano : ");
			this.dosyapanolbl.set_TextSize(new Size(101, 13));
			this.layoutControlItem138.set_Control(this.dosyapanogor);
			this.layoutControlItem138.set_CustomizationFormText("layoutControlItem91");
			this.layoutControlItem138.set_Location(new Point(670, 151));
			this.layoutControlItem138.set_Name("layoutControlItem91");
			this.layoutControlItem138.set_Padding(new Padding(5, 5, 2, 2));
			this.layoutControlItem138.set_Size(new Size(161, 26));
			this.layoutControlItem138.set_TextSize(new Size(0, 0));
			this.layoutControlItem138.set_TextVisible(false);
			this.layoutControlItem139.set_Control(this.dosyapanosn);
			this.layoutControlItem139.set_CustomizationFormText("layoutControlItem92");
			this.layoutControlItem139.set_Location(new Point(499, 151));
			this.layoutControlItem139.set_Name("layoutControlItem92");
			this.layoutControlItem139.set_Size(new Size(171, 26));
			this.layoutControlItem139.set_TextSize(new Size(0, 0));
			this.layoutControlItem139.set_TextVisible(false);
			this.layoutControlItem140.set_Control(this.dosyaslblertfsec);
			this.layoutControlItem140.set_CustomizationFormText("layoutControlItem93");
			this.layoutControlItem140.set_Location(new Point(0, 0));
			this.layoutControlItem140.set_MinSize(new Size(1, 18));
			this.layoutControlItem140.set_Name("layoutControlItem93");
			this.layoutControlItem140.set_Size(new Size(499, 21));
			this.layoutControlItem140.set_SizeConstraintsType(2);
			this.layoutControlItem140.set_TextAlignMode(1);
			this.layoutControlItem140.set_TextSize(new Size(0, 0));
			this.layoutControlItem140.set_TextToControlDistance(0);
			this.layoutControlItem140.set_TextVisible(false);
			this.layoutControlItem141.set_Control(this.dosyalblurserno);
			this.layoutControlItem141.set_CustomizationFormText("layoutControlItem94");
			this.layoutControlItem141.set_Location(new Point(499, 0));
			this.layoutControlItem141.set_MinSize(new Size(1, 1));
			this.layoutControlItem141.set_Name("layoutControlItem94");
			this.layoutControlItem141.set_Size(new Size(171, 21));
			this.layoutControlItem141.set_SizeConstraintsType(2);
			this.layoutControlItem141.set_TextAlignMode(1);
			this.layoutControlItem141.set_TextSize(new Size(0, 0));
			this.layoutControlItem141.set_TextToControlDistance(0);
			this.layoutControlItem141.set_TextVisible(false);
			this.layoutControlItem142.set_Control(this.dosyalblsertf);
			this.layoutControlItem142.set_CustomizationFormText("layoutControlItem95");
			this.layoutControlItem142.set_Location(new Point(670, 0));
			this.layoutControlItem142.set_MinSize(new Size(1, 1));
			this.layoutControlItem142.set_Name("layoutControlItem95");
			this.layoutControlItem142.set_Size(new Size(161, 21));
			this.layoutControlItem142.set_SizeConstraintsType(2);
			this.layoutControlItem142.set_TextAlignMode(1);
			this.layoutControlItem142.set_TextSize(new Size(0, 0));
			this.layoutControlItem142.set_TextToControlDistance(0);
			this.layoutControlItem142.set_TextVisible(false);
			this.dosyakapikilitlbl.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyakapikilitlbl.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyakapikilitlbl.set_Control(this.dosyakapikilit);
			this.dosyakapikilitlbl.set_CustomizationFormText("KAPI KİLİDİ");
			this.dosyakapikilitlbl.set_Location(new Point(0, 21));
			this.dosyakapikilitlbl.set_Name("dosyakapikilitlbl");
			this.dosyakapikilitlbl.set_Size(new Size(499, 26));
			this.dosyakapikilitlbl.set_Text("Kapı Kilidi : ");
			this.dosyakapikilitlbl.set_TextSize(new Size(101, 13));
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
			this.layoutControl5.set_Root(this.layoutControlGroup9);
			this.layoutControl5.Size = new Size(312, 817);
			this.layoutControl5.TabIndex = 1;
			this.layoutControl5.Text = "layoutControl5";
			this.dosyaadres.Location = new Point(102, 247);
			this.dosyaadres.Name = "dosyaadres";
			this.dosyaadres.Size = new Size(203, 203);
			this.dosyaadres.TabIndex = 30;
			this.dosyaadres.Text = "";
			this.dosyaadres.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyamutaahhitvd.set_EnterMoveNextControl(true);
			this.dosyamutaahhitvd.Location = new Point(102, 790);
			this.dosyamutaahhitvd.Name = "dosyamutaahhitvd";
			this.dosyamutaahhitvd.Size = new Size(203, 20);
			this.dosyamutaahhitvd.set_StyleController(this.layoutControl5);
			this.dosyamutaahhitvd.TabIndex = 29;
			this.dosyamutaahhitvd.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyamutaahhitvn.set_EnterMoveNextControl(true);
			this.dosyamutaahhitvn.Location = new Point(102, 766);
			this.dosyamutaahhitvn.Name = "dosyamutaahhitvn";
			this.dosyamutaahhitvn.Size = new Size(203, 20);
			this.dosyamutaahhitvn.set_StyleController(this.layoutControl5);
			this.dosyamutaahhitvn.TabIndex = 28;
			this.dosyamutaahhitvn.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyamutaahhittc.set_EnterMoveNextControl(true);
			this.dosyamutaahhittc.Location = new Point(102, 742);
			this.dosyamutaahhittc.Name = "dosyamutaahhittc";
			this.dosyamutaahhittc.Size = new Size(203, 20);
			this.dosyamutaahhittc.set_StyleController(this.layoutControl5);
			this.dosyamutaahhittc.TabIndex = 27;
			this.dosyamutaahhittc.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyamutaahhit.set_EnterMoveNextControl(true);
			this.dosyamutaahhit.Location = new Point(102, 718);
			this.dosyamutaahhit.Name = "dosyamutaahhit";
			this.dosyamutaahhit.Size = new Size(203, 20);
			this.dosyamutaahhit.set_StyleController(this.layoutControl5);
			this.dosyamutaahhit.TabIndex = 26;
			this.dosyamutaahhit.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyabinasahipvd.set_EnterMoveNextControl(true);
			this.dosyabinasahipvd.Location = new Point(102, 694);
			this.dosyabinasahipvd.Name = "dosyabinasahipvd";
			this.dosyabinasahipvd.Size = new Size(203, 20);
			this.dosyabinasahipvd.set_StyleController(this.layoutControl5);
			this.dosyabinasahipvd.TabIndex = 25;
			this.dosyabinasahipvd.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyabinasahipvn.set_EnterMoveNextControl(true);
			this.dosyabinasahipvn.Location = new Point(102, 670);
			this.dosyabinasahipvn.Name = "dosyabinasahipvn";
			this.dosyabinasahipvn.Size = new Size(203, 20);
			this.dosyabinasahipvn.set_StyleController(this.layoutControl5);
			this.dosyabinasahipvn.TabIndex = 24;
			this.dosyabinasahipvn.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyabinasahiptc.set_EnterMoveNextControl(true);
			this.dosyabinasahiptc.Location = new Point(102, 646);
			this.dosyabinasahiptc.Name = "dosyabinasahiptc";
			this.dosyabinasahiptc.Size = new Size(203, 20);
			this.dosyabinasahiptc.set_StyleController(this.layoutControl5);
			this.dosyabinasahiptc.TabIndex = 23;
			this.dosyabinasahiptc.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyabinasahip.set_EnterMoveNextControl(true);
			this.dosyabinasahip.Location = new Point(102, 622);
			this.dosyabinasahip.Name = "dosyabinasahip";
			this.dosyabinasahip.Size = new Size(203, 20);
			this.dosyabinasahip.set_StyleController(this.layoutControl5);
			this.dosyabinasahip.TabIndex = 22;
			this.dosyabinasahip.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyaservistar.set_EnterMoveNextControl(true);
			this.dosyaservistar.Location = new Point(102, 598);
			this.dosyaservistar.Name = "dosyaservistar";
			this.dosyaservistar.Size = new Size(203, 20);
			this.dosyaservistar.set_StyleController(this.layoutControl5);
			this.dosyaservistar.TabIndex = 21;
			this.dosyaservistar.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyaasansorno.set_EnterMoveNextControl(true);
			this.dosyaasansorno.Location = new Point(102, 574);
			this.dosyaasansorno.Name = "dosyaasansorno";
			this.dosyaasansorno.Size = new Size(203, 20);
			this.dosyaasansorno.set_StyleController(this.layoutControl5);
			this.dosyaasansorno.TabIndex = 20;
			this.dosyasinif.set_EnterMoveNextControl(true);
			this.dosyasinif.Location = new Point(102, 550);
			this.dosyasinif.Name = "dosyasinif";
			this.dosyasinif.Size = new Size(203, 20);
			this.dosyasinif.set_StyleController(this.layoutControl5);
			this.dosyasinif.TabIndex = 19;
			this.dosyasinif.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyaparsel.set_EnterMoveNextControl(true);
			this.dosyaparsel.Location = new Point(102, 526);
			this.dosyaparsel.Name = "dosyaparsel";
			this.dosyaparsel.Size = new Size(203, 20);
			this.dosyaparsel.set_StyleController(this.layoutControl5);
			this.dosyaparsel.TabIndex = 18;
			this.dosyaada.set_EnterMoveNextControl(true);
			this.dosyaada.Location = new Point(102, 502);
			this.dosyaada.Name = "dosyaada";
			this.dosyaada.Size = new Size(203, 20);
			this.dosyaada.set_StyleController(this.layoutControl5);
			this.dosyaada.TabIndex = 17;
			this.dosyapafta.set_EnterMoveNextControl(true);
			this.dosyapafta.Location = new Point(102, 478);
			this.dosyapafta.Name = "dosyapafta";
			this.dosyapafta.Size = new Size(203, 20);
			this.dosyapafta.set_StyleController(this.layoutControl5);
			this.dosyapafta.TabIndex = 16;
			this.dosyabelediye.set_EnterMoveNextControl(true);
			this.dosyabelediye.Location = new Point(102, 454);
			this.dosyabelediye.Name = "dosyabelediye";
			this.dosyabelediye.Size = new Size(203, 20);
			this.dosyabelediye.set_StyleController(this.layoutControl5);
			this.dosyabelediye.TabIndex = 15;
			this.dosyabelediye.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyailce.set_EnterMoveNextControl(true);
			this.dosyailce.Location = new Point(102, 223);
			this.dosyailce.Name = "dosyailce";
			this.dosyailce.Size = new Size(203, 20);
			this.dosyailce.set_StyleController(this.layoutControl5);
			this.dosyailce.TabIndex = 13;
			this.dosyailce.TextChanged += new EventHandler(this.adresiolustur);
			this.dosyailce.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyail.set_EnterMoveNextControl(true);
			this.dosyail.Location = new Point(102, 199);
			this.dosyail.Name = "dosyail";
			this.dosyail.Size = new Size(203, 20);
			this.dosyail.set_StyleController(this.layoutControl5);
			this.dosyail.TabIndex = 12;
			this.dosyail.TextChanged += new EventHandler(this.adresiolustur);
			this.dosyail.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyablok.set_EnterMoveNextControl(true);
			this.dosyablok.Location = new Point(102, 175);
			this.dosyablok.Name = "dosyablok";
			this.dosyablok.Size = new Size(203, 20);
			this.dosyablok.set_StyleController(this.layoutControl5);
			this.dosyablok.TabIndex = 11;
			this.dosyablok.TextChanged += new EventHandler(this.adresiolustur);
			this.dosyablok.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyano.set_EnterMoveNextControl(true);
			this.dosyano.Location = new Point(102, 151);
			this.dosyano.Name = "dosyano";
			this.dosyano.Size = new Size(203, 20);
			this.dosyano.set_StyleController(this.layoutControl5);
			this.dosyano.TabIndex = 10;
			this.dosyano.TextChanged += new EventHandler(this.adresiolustur);
			this.dosyano.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyabulvar.set_EnterMoveNextControl(true);
			this.dosyabulvar.Location = new Point(102, 127);
			this.dosyabulvar.Name = "dosyabulvar";
			this.dosyabulvar.Size = new Size(203, 20);
			this.dosyabulvar.set_StyleController(this.layoutControl5);
			this.dosyabulvar.TabIndex = 9;
			this.dosyabulvar.TextChanged += new EventHandler(this.adresiolustur);
			this.dosyabulvar.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyacadde.set_EnterMoveNextControl(true);
			this.dosyacadde.Location = new Point(102, 103);
			this.dosyacadde.Name = "dosyacadde";
			this.dosyacadde.Size = new Size(203, 20);
			this.dosyacadde.set_StyleController(this.layoutControl5);
			this.dosyacadde.TabIndex = 8;
			this.dosyacadde.TextChanged += new EventHandler(this.adresiolustur);
			this.dosyacadde.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyasokak.set_EnterMoveNextControl(true);
			this.dosyasokak.Location = new Point(102, 79);
			this.dosyasokak.Name = "dosyasokak";
			this.dosyasokak.Size = new Size(203, 20);
			this.dosyasokak.set_StyleController(this.layoutControl5);
			this.dosyasokak.TabIndex = 7;
			this.dosyasokak.TextChanged += new EventHandler(this.adresiolustur);
			this.dosyasokak.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyamahalle.set_EnterMoveNextControl(true);
			this.dosyamahalle.Location = new Point(102, 55);
			this.dosyamahalle.Name = "dosyamahalle";
			this.dosyamahalle.Size = new Size(203, 20);
			this.dosyamahalle.set_StyleController(this.layoutControl5);
			this.dosyamahalle.TabIndex = 6;
			this.dosyamahalle.TextChanged += new EventHandler(this.adresiolustur);
			this.dosyamahalle.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyaasansorsahib.set_EnterMoveNextControl(true);
			this.dosyaasansorsahib.Location = new Point(102, 31);
			this.dosyaasansorsahib.Name = "dosyaasansorsahib";
			this.dosyaasansorsahib.Size = new Size(203, 20);
			this.dosyaasansorsahib.set_StyleController(this.layoutControl5);
			this.dosyaasansorsahib.TabIndex = 2;
			this.dosyaasansorsahib.KeyPress += new KeyPressEventHandler(this.buyutur);
			this.dosyabelgemodul.set_EnterMoveNextControl(true);
			this.dosyabelgemodul.Location = new Point(102, 7);
			this.dosyabelgemodul.Name = "dosyabelgemodul";
			this.dosyabelgemodul.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.dosyabelgemodul.get_Properties().get_Items().AddRange(new object[]
			{
				"SEÇİNİZ...",
				"95 / 16 / AT Ek ( MODÜL B – EK V (B BENDİ) + MODÜL E – EK XII )",
				"95 / 16 / AT Ek ( MODÜL H ANNEX XIII )",
				"95 / 16 / AT Ek ( X Modül G )"
			});
			this.dosyabelgemodul.Size = new Size(203, 20);
			this.dosyabelgemodul.set_StyleController(this.layoutControl5);
			this.dosyabelgemodul.TabIndex = 1;
			this.layoutControlGroup9.set_CustomizationFormText("layoutControlGroup9");
			this.layoutControlGroup9.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup9.set_GroupBordersVisible(false);
			this.layoutControlGroup9.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.dosyalblmodul,
				this.dosyalblno,
				this.dosyalblil,
				this.dosyalblilce,
				this.dosyalblbelediye,
				this.dosyalblpafta,
				this.dosyalblada,
				this.dosyalblparsel,
				this.dosyalblsinif,
				this.dosyalblasnno,
				this.dosyalblservistar,
				this.dosyalblbinasahip,
				this.dosyalblbinasahiptc,
				this.dosyalblbinasahipvn,
				this.dosyalblbinasahipvd,
				this.dosyalblmuteaahhit,
				this.dosyalblmuteaahhittc,
				this.dosyalblmuteaahhitvn,
				this.dosyalblmuteaahhitvd,
				this.dosyalblasansorsahip,
				this.dosyalblblok,
				this.dosyalblbulvar,
				this.dosyalblmahalle,
				this.dosyalblcadde,
				this.dosyalblsokak,
				this.dosyalbladres
			});
			this.layoutControlGroup9.set_Location(new Point(0, 0));
			this.layoutControlGroup9.set_Name("layoutControlGroup9");
			this.layoutControlGroup9.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup9.set_Size(new Size(312, 817));
			this.layoutControlGroup9.set_TextVisible(false);
			this.dosyalblmodul.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblmodul.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblmodul.set_Control(this.dosyabelgemodul);
			this.dosyalblmodul.set_CustomizationFormText("Belge Modülü : ");
			this.dosyalblmodul.set_Location(new Point(0, 0));
			this.dosyalblmodul.set_Name("dosyalblmodul");
			this.dosyalblmodul.set_Size(new Size(302, 24));
			this.dosyalblmodul.set_Text("Belge Modülü : ");
			this.dosyalblmodul.set_TextSize(new Size(92, 13));
			this.dosyalblno.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblno.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblno.set_Control(this.dosyano);
			this.dosyalblno.set_CustomizationFormText("No : ");
			this.dosyalblno.set_Location(new Point(0, 144));
			this.dosyalblno.set_Name("dosyalblno");
			this.dosyalblno.set_Size(new Size(302, 24));
			this.dosyalblno.set_Text("No : ");
			this.dosyalblno.set_TextSize(new Size(92, 13));
			this.dosyalblil.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblil.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblil.set_Control(this.dosyail);
			this.dosyalblil.set_CustomizationFormText("İl : ");
			this.dosyalblil.set_Location(new Point(0, 192));
			this.dosyalblil.set_Name("dosyalblil");
			this.dosyalblil.set_Size(new Size(302, 24));
			this.dosyalblil.set_Text("İl : ");
			this.dosyalblil.set_TextSize(new Size(92, 13));
			this.dosyalblilce.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblilce.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblilce.set_Control(this.dosyailce);
			this.dosyalblilce.set_CustomizationFormText("İlçe : ");
			this.dosyalblilce.set_Location(new Point(0, 216));
			this.dosyalblilce.set_Name("dosyalblilce");
			this.dosyalblilce.set_Size(new Size(302, 24));
			this.dosyalblilce.set_Text("İlçe : ");
			this.dosyalblilce.set_TextSize(new Size(92, 13));
			this.dosyalblbelediye.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblbelediye.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblbelediye.set_Control(this.dosyabelediye);
			this.dosyalblbelediye.set_CustomizationFormText("Belediye : ");
			this.dosyalblbelediye.set_Location(new Point(0, 447));
			this.dosyalblbelediye.set_Name("dosyalblbelediye");
			this.dosyalblbelediye.set_Size(new Size(302, 24));
			this.dosyalblbelediye.set_Text("Belediye : ");
			this.dosyalblbelediye.set_TextSize(new Size(92, 13));
			this.dosyalblpafta.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblpafta.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblpafta.set_Control(this.dosyapafta);
			this.dosyalblpafta.set_CustomizationFormText("Pafta : ");
			this.dosyalblpafta.set_Location(new Point(0, 471));
			this.dosyalblpafta.set_Name("dosyalblpafta");
			this.dosyalblpafta.set_Size(new Size(302, 24));
			this.dosyalblpafta.set_Text("Pafta : ");
			this.dosyalblpafta.set_TextSize(new Size(92, 13));
			this.dosyalblada.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblada.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblada.set_Control(this.dosyaada);
			this.dosyalblada.set_CustomizationFormText("Ada : ");
			this.dosyalblada.set_Location(new Point(0, 495));
			this.dosyalblada.set_Name("dosyalblada");
			this.dosyalblada.set_Size(new Size(302, 24));
			this.dosyalblada.set_Text("Ada : ");
			this.dosyalblada.set_TextSize(new Size(92, 13));
			this.dosyalblparsel.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblparsel.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblparsel.set_Control(this.dosyaparsel);
			this.dosyalblparsel.set_CustomizationFormText("Parsel : ");
			this.dosyalblparsel.set_Location(new Point(0, 519));
			this.dosyalblparsel.set_Name("dosyalblparsel");
			this.dosyalblparsel.set_Size(new Size(302, 24));
			this.dosyalblparsel.set_Text("Parsel : ");
			this.dosyalblparsel.set_TextSize(new Size(92, 13));
			this.dosyalblsinif.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblsinif.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblsinif.set_Control(this.dosyasinif);
			this.dosyalblsinif.set_CustomizationFormText("Sınıfı : ");
			this.dosyalblsinif.set_Location(new Point(0, 543));
			this.dosyalblsinif.set_Name("dosyalblsinif");
			this.dosyalblsinif.set_Size(new Size(302, 24));
			this.dosyalblsinif.set_Text("Sınıfı : ");
			this.dosyalblsinif.set_TextSize(new Size(92, 13));
			this.dosyalblasnno.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblasnno.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblasnno.set_Control(this.dosyaasansorno);
			this.dosyalblasnno.set_CustomizationFormText("Asansör No : ");
			this.dosyalblasnno.set_Location(new Point(0, 567));
			this.dosyalblasnno.set_Name("dosyalblasnno");
			this.dosyalblasnno.set_Size(new Size(302, 24));
			this.dosyalblasnno.set_Text("Asansör No : ");
			this.dosyalblasnno.set_TextSize(new Size(92, 13));
			this.dosyalblservistar.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblservistar.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblservistar.set_Control(this.dosyaservistar);
			this.dosyalblservistar.set_CustomizationFormText("Servis Tarihi : ");
			this.dosyalblservistar.set_Location(new Point(0, 591));
			this.dosyalblservistar.set_Name("dosyalblservistar");
			this.dosyalblservistar.set_Size(new Size(302, 24));
			this.dosyalblservistar.set_Text("Servis Tarihi : ");
			this.dosyalblservistar.set_TextSize(new Size(92, 13));
			this.dosyalblbinasahip.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblbinasahip.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblbinasahip.set_Control(this.dosyabinasahip);
			this.dosyalblbinasahip.set_CustomizationFormText("Bina Sahibi : ");
			this.dosyalblbinasahip.set_Location(new Point(0, 615));
			this.dosyalblbinasahip.set_Name("dosyalblbinasahip");
			this.dosyalblbinasahip.set_Size(new Size(302, 24));
			this.dosyalblbinasahip.set_Text("Bina Sahibi : ");
			this.dosyalblbinasahip.set_TextSize(new Size(92, 13));
			this.dosyalblbinasahiptc.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblbinasahiptc.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblbinasahiptc.set_Control(this.dosyabinasahiptc);
			this.dosyalblbinasahiptc.set_CustomizationFormText("Bina Sahibi TC : ");
			this.dosyalblbinasahiptc.set_Location(new Point(0, 639));
			this.dosyalblbinasahiptc.set_Name("dosyalblbinasahiptc");
			this.dosyalblbinasahiptc.set_Size(new Size(302, 24));
			this.dosyalblbinasahiptc.set_Text("Bina Sahibi TC : ");
			this.dosyalblbinasahiptc.set_TextSize(new Size(92, 13));
			this.dosyalblbinasahipvn.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblbinasahipvn.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblbinasahipvn.set_Control(this.dosyabinasahipvn);
			this.dosyalblbinasahipvn.set_CustomizationFormText("Bina Sahibi V.N : ");
			this.dosyalblbinasahipvn.set_Location(new Point(0, 663));
			this.dosyalblbinasahipvn.set_Name("dosyalblbinasahipvn");
			this.dosyalblbinasahipvn.set_Size(new Size(302, 24));
			this.dosyalblbinasahipvn.set_Text("Bina Sahibi V.N : ");
			this.dosyalblbinasahipvn.set_TextSize(new Size(92, 13));
			this.dosyalblbinasahipvd.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblbinasahipvd.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblbinasahipvd.set_Control(this.dosyabinasahipvd);
			this.dosyalblbinasahipvd.set_CustomizationFormText("Bina Sahibi V.D : ");
			this.dosyalblbinasahipvd.set_Location(new Point(0, 687));
			this.dosyalblbinasahipvd.set_Name("dosyalblbinasahipvd");
			this.dosyalblbinasahipvd.set_Size(new Size(302, 24));
			this.dosyalblbinasahipvd.set_Text("Bina Sahibi V.D : ");
			this.dosyalblbinasahipvd.set_TextSize(new Size(92, 13));
			this.dosyalblmuteaahhit.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblmuteaahhit.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblmuteaahhit.set_Control(this.dosyamutaahhit);
			this.dosyalblmuteaahhit.set_CustomizationFormText("Mütaahhit : ");
			this.dosyalblmuteaahhit.set_Location(new Point(0, 711));
			this.dosyalblmuteaahhit.set_Name("dosyalblmuteaahhit");
			this.dosyalblmuteaahhit.set_Size(new Size(302, 24));
			this.dosyalblmuteaahhit.set_Text("Mütaahhit : ");
			this.dosyalblmuteaahhit.set_TextSize(new Size(92, 13));
			this.dosyalblmuteaahhittc.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblmuteaahhittc.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblmuteaahhittc.set_Control(this.dosyamutaahhittc);
			this.dosyalblmuteaahhittc.set_CustomizationFormText("Mütaahhit TC : ");
			this.dosyalblmuteaahhittc.set_Location(new Point(0, 735));
			this.dosyalblmuteaahhittc.set_Name("dosyalblmuteaahhittc");
			this.dosyalblmuteaahhittc.set_Size(new Size(302, 24));
			this.dosyalblmuteaahhittc.set_Text("Mütaahhit TC : ");
			this.dosyalblmuteaahhittc.set_TextSize(new Size(92, 13));
			this.dosyalblmuteaahhitvn.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblmuteaahhitvn.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblmuteaahhitvn.set_Control(this.dosyamutaahhitvn);
			this.dosyalblmuteaahhitvn.set_CustomizationFormText("Mütaahhit V.N : ");
			this.dosyalblmuteaahhitvn.set_Location(new Point(0, 759));
			this.dosyalblmuteaahhitvn.set_Name("dosyalblmuteaahhitvn");
			this.dosyalblmuteaahhitvn.set_Size(new Size(302, 24));
			this.dosyalblmuteaahhitvn.set_Text("Mütaahhit V.N : ");
			this.dosyalblmuteaahhitvn.set_TextSize(new Size(92, 13));
			this.dosyalblmuteaahhitvd.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblmuteaahhitvd.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblmuteaahhitvd.set_Control(this.dosyamutaahhitvd);
			this.dosyalblmuteaahhitvd.set_CustomizationFormText("Mütaahhit V.D : ");
			this.dosyalblmuteaahhitvd.set_Location(new Point(0, 783));
			this.dosyalblmuteaahhitvd.set_Name("dosyalblmuteaahhitvd");
			this.dosyalblmuteaahhitvd.set_Size(new Size(302, 24));
			this.dosyalblmuteaahhitvd.set_Text("Mütaahhit V.D : ");
			this.dosyalblmuteaahhitvd.set_TextSize(new Size(92, 13));
			this.dosyalblasansorsahip.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblasansorsahip.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblasansorsahip.set_Control(this.dosyaasansorsahib);
			this.dosyalblasansorsahip.set_CustomizationFormText("Asansör Sahibi : ");
			this.dosyalblasansorsahip.set_Location(new Point(0, 24));
			this.dosyalblasansorsahip.set_Name("dosyalblasansorsahip");
			this.dosyalblasansorsahip.set_Size(new Size(302, 24));
			this.dosyalblasansorsahip.set_Text("Asansör Sahibi : ");
			this.dosyalblasansorsahip.set_TextSize(new Size(92, 13));
			this.dosyalblblok.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblblok.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblblok.set_Control(this.dosyablok);
			this.dosyalblblok.set_CustomizationFormText("Blok : ");
			this.dosyalblblok.set_Location(new Point(0, 168));
			this.dosyalblblok.set_Name("dosyalblblok");
			this.dosyalblblok.set_Size(new Size(302, 24));
			this.dosyalblblok.set_Text("Blok : ");
			this.dosyalblblok.set_TextSize(new Size(92, 13));
			this.dosyalblbulvar.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblbulvar.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblbulvar.set_Control(this.dosyabulvar);
			this.dosyalblbulvar.set_CustomizationFormText("Bulvar : ");
			this.dosyalblbulvar.set_Location(new Point(0, 120));
			this.dosyalblbulvar.set_Name("dosyalblbulvar");
			this.dosyalblbulvar.set_Size(new Size(302, 24));
			this.dosyalblbulvar.set_Text("Bulvar : ");
			this.dosyalblbulvar.set_TextSize(new Size(92, 13));
			this.dosyalblmahalle.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblmahalle.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblmahalle.set_Control(this.dosyamahalle);
			this.dosyalblmahalle.set_CustomizationFormText("Mahalle : ");
			this.dosyalblmahalle.set_Location(new Point(0, 48));
			this.dosyalblmahalle.set_Name("dosyalblmahalle");
			this.dosyalblmahalle.set_Size(new Size(302, 24));
			this.dosyalblmahalle.set_Text("Mahalle : ");
			this.dosyalblmahalle.set_TextSize(new Size(92, 13));
			this.dosyalblcadde.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblcadde.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblcadde.set_Control(this.dosyacadde);
			this.dosyalblcadde.set_CustomizationFormText("Cadde : ");
			this.dosyalblcadde.set_Location(new Point(0, 96));
			this.dosyalblcadde.set_Name("dosyalblcadde");
			this.dosyalblcadde.set_Size(new Size(302, 24));
			this.dosyalblcadde.set_Text("Cadde : ");
			this.dosyalblcadde.set_TextSize(new Size(92, 13));
			this.dosyalblsokak.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalblsokak.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalblsokak.set_Control(this.dosyasokak);
			this.dosyalblsokak.set_CustomizationFormText("Sokak : ");
			this.dosyalblsokak.set_Location(new Point(0, 72));
			this.dosyalblsokak.set_Name("dosyalblsokak");
			this.dosyalblsokak.set_Size(new Size(302, 24));
			this.dosyalblsokak.set_Text("Sokak : ");
			this.dosyalblsokak.set_TextSize(new Size(92, 13));
			this.dosyalbladres.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dosyalbladres.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.dosyalbladres.set_Control(this.dosyaadres);
			this.dosyalbladres.set_CustomizationFormText("Tam Adres : ");
			this.dosyalbladres.set_Location(new Point(0, 240));
			this.dosyalbladres.set_MinSize(new Size(109, 72));
			this.dosyalbladres.set_Name("dosyalbladres");
			this.dosyalbladres.set_Size(new Size(302, 207));
			this.dosyalbladres.set_SizeConstraintsType(2);
			this.dosyalbladres.set_Text("Tam Adres : ");
			this.dosyalbladres.set_TextSize(new Size(92, 13));
			this.backstageViewClientControl4.Controls.Add(this.layoutControl2);
			this.backstageViewClientControl4.Controls.Add(this.layoutControl1);
			this.backstageViewClientControl4.set_Location(new Point(153, 0));
			this.backstageViewClientControl4.Name = "backstageViewClientControl4";
			this.backstageViewClientControl4.set_Size(new Size(1157, 817));
			this.backstageViewClientControl4.TabIndex = 3;
			this.layoutControl2.Controls.Add(this.dileklemebuton);
			this.layoutControl2.Controls.Add(this.labeldilaciklama);
			this.layoutControl2.Controls.Add(this.gridcontroldiller);
			this.layoutControl2.Dock = DockStyle.Fill;
			this.layoutControl2.Location = new Point(0, 0);
			this.layoutControl2.Name = "layoutControl2";
			this.layoutControl2.set_Root(this.layoutControlGroup7);
			this.layoutControl2.Size = new Size(1157, 790);
			this.layoutControl2.TabIndex = 2;
			this.layoutControl2.Text = "layoutControl1";
			this.dileklemebuton.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.dileklemebuton.get_Appearance().get_Options().set_UseFont(true);
			this.dileklemebuton.Location = new Point(884, 7);
			this.dileklemebuton.Name = "dileklemebuton";
			this.dileklemebuton.Size = new Size(266, 46);
			this.dileklemebuton.set_StyleController(this.layoutControl2);
			this.dileklemebuton.TabIndex = 5;
			this.dileklemebuton.Text = "YENİ BİR DİL EKLE";
			this.dileklemebuton.Click += new EventHandler(this.dileklemebuton_Click);
			this.labeldilaciklama.get_Appearance().set_Font(new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeldilaciklama.get_Appearance().get_TextOptions().set_WordWrap(2);
			this.labeldilaciklama.set_AutoSizeMode(1);
			this.labeldilaciklama.Location = new Point(7, 7);
			this.labeldilaciklama.Name = "labeldilaciklama";
			this.labeldilaciklama.Size = new Size(873, 46);
			this.labeldilaciklama.set_StyleController(this.layoutControl2);
			this.labeldilaciklama.TabIndex = 4;
			this.labeldilaciklama.Text = "Sayın Kullanıcımız Yaptığınız Dil Değişiklikleri Siz Yazdığınız Anda Uygulanacaktır. Lütfen Değişiklik Yaparken Dikkat Ediniz.";
			this.gridcontroldiller.Location = new Point(7, 57);
			this.gridcontroldiller.set_MainView(this.gridviewdiller);
			this.gridcontroldiller.Name = "gridcontroldiller";
			this.gridcontroldiller.Size = new Size(1143, 726);
			this.gridcontroldiller.TabIndex = 0;
			this.gridcontroldiller.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridviewdiller
			});
			this.gridviewdiller.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridviewdiller.get_Appearance().get_HeaderPanel().set_ForeColor(Color.Red);
			this.gridviewdiller.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridviewdiller.get_Appearance().get_HeaderPanel().get_Options().set_UseForeColor(true);
			this.gridviewdiller.get_Appearance().get_HeaderPanel().get_Options().set_UseTextOptions(true);
			this.gridviewdiller.get_Appearance().get_HeaderPanel().get_TextOptions().set_HAlignment(2);
			this.gridviewdiller.get_Appearance().get_Row().set_Font(new Font("Tahoma", 12f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewdiller.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridviewdiller.set_GridControl(this.gridcontroldiller);
			this.gridviewdiller.set_Name("gridviewdiller");
			this.gridviewdiller.get_OptionsView().set_ShowAutoFilterRow(true);
			this.gridviewdiller.get_OptionsView().set_ShowGroupPanel(false);
			this.gridviewdiller.add_CellValueChanged(new CellValueChangedEventHandler(this.gridviewdiller_CellValueChanged));
			this.layoutControlGroup7.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup7.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup7.set_GroupBordersVisible(false);
			this.layoutControlGroup7.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2,
				this.layoutControlItem43
			});
			this.layoutControlGroup7.set_Location(new Point(0, 0));
			this.layoutControlGroup7.set_Name("layoutControlGroup1");
			this.layoutControlGroup7.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup7.set_Size(new Size(1157, 790));
			this.layoutControlGroup7.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.gridcontroldiller);
			this.layoutControlItem1.set_CustomizationFormText("layoutControlItem1");
			this.layoutControlItem1.set_Location(new Point(0, 50));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(1147, 730));
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem2.set_Control(this.labeldilaciklama);
			this.layoutControlItem2.set_CustomizationFormText("layoutControlItem2");
			this.layoutControlItem2.set_Location(new Point(0, 0));
			this.layoutControlItem2.set_MaxSize(new Size(0, 50));
			this.layoutControlItem2.set_MinSize(new Size(20, 50));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(877, 50));
			this.layoutControlItem2.set_SizeConstraintsType(2);
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			this.layoutControlItem43.set_Control(this.dileklemebuton);
			this.layoutControlItem43.set_CustomizationFormText("layoutControlItem3");
			this.layoutControlItem43.set_Location(new Point(877, 0));
			this.layoutControlItem43.set_MinSize(new Size(82, 26));
			this.layoutControlItem43.set_Name("layoutControlItem3");
			this.layoutControlItem43.set_Size(new Size(270, 50));
			this.layoutControlItem43.set_SizeConstraintsType(2);
			this.layoutControlItem43.set_TextSize(new Size(0, 0));
			this.layoutControlItem43.set_TextVisible(false);
			this.layoutControl1.Controls.Add(this.labelversionbilgi);
			this.layoutControl1.Controls.Add(this.labelversiyonyazi);
			this.layoutControl1.Controls.Add(this.dilsecimi);
			this.layoutControl1.Controls.Add(this.gorunumayar);
			this.layoutControl1.Dock = DockStyle.Bottom;
			this.layoutControl1.Location = new Point(0, 790);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup6);
			this.layoutControl1.Size = new Size(1157, 27);
			this.layoutControl1.TabIndex = 39;
			this.layoutControl1.Text = "layoutControl1";
			this.labelversionbilgi.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelversionbilgi.get_Appearance().set_ForeColor(Color.Maroon);
			this.labelversionbilgi.set_AutoSizeMode(1);
			this.labelversionbilgi.Location = new Point(1084, 2);
			this.labelversionbilgi.Name = "labelversionbilgi";
			this.labelversionbilgi.Size = new Size(71, 23);
			this.labelversionbilgi.set_StyleController(this.layoutControl1);
			this.labelversionbilgi.TabIndex = 13;
			this.labelversiyonyazi.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labelversiyonyazi.get_Appearance().get_TextOptions().set_HAlignment(3);
			this.labelversiyonyazi.set_AutoSizeMode(1);
			this.labelversiyonyazi.Location = new Point(962, 0);
			this.labelversiyonyazi.Name = "labelversiyonyazi";
			this.labelversiyonyazi.Size = new Size(120, 27);
			this.labelversiyonyazi.set_StyleController(this.layoutControl1);
			this.labelversiyonyazi.TabIndex = 12;
			this.labelversiyonyazi.Text = "Versiyon : ";
			this.dilsecimi.Location = new Point(173, 2);
			this.dilsecimi.Name = "dilsecimi";
			this.dilsecimi.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.dilsecimi.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.dilsecimi.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.dilsecimi.Size = new Size(199, 22);
			this.dilsecimi.set_StyleController(this.layoutControl1);
			this.dilsecimi.TabIndex = 11;
			this.dilsecimi.add_SelectedIndexChanged(new EventHandler(this.dilsecimi_SelectedIndexChanged));
			this.gorunumayar.Location = new Point(547, 2);
			this.gorunumayar.Name = "gorunumayar";
			this.gorunumayar.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.gorunumayar.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.gorunumayar.get_Properties().set_BorderStyle(6);
			this.gorunumayar.get_Properties().get_Buttons().AddRange(new EditorButton[]
			{
				new EditorButton(-5)
			});
			this.gorunumayar.get_Properties().get_Items().AddRange(new object[]
			{
				"Office 2010 Black",
				"Office 2010 Blue",
				"Office 2010 Silver",
				"VS2010",
				"DevExpress Style",
				"DevExpress Dark Style",
				"Metropolis",
				"Coffee",
				"Luquid Sky",
				"London Luquid Sky",
				"Seven Classic",
				"Valentine",
				"XMAS 2008 Blue",
				"Foggy"
			});
			this.gorunumayar.Size = new Size(363, 22);
			this.gorunumayar.set_StyleController(this.layoutControl1);
			this.gorunumayar.TabIndex = 6;
			this.gorunumayar.add_SelectedIndexChanged(new EventHandler(this.aryz_SelectedIndexChanged));
			this.layoutControlGroup6.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup6.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup6.set_GroupBordersVisible(false);
			this.layoutControlGroup6.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.labelgorunumayar,
				this.labeldilsecimi,
				this.layoutControlItem8,
				this.layoutControlItem10
			});
			this.layoutControlGroup6.set_Location(new Point(0, 0));
			this.layoutControlGroup6.set_Name("layoutControlGroup1");
			this.layoutControlGroup6.set_Padding(new Padding(0, 0, 0, 0));
			this.layoutControlGroup6.set_Size(new Size(1157, 27));
			this.layoutControlGroup6.set_TextVisible(false);
			this.labelgorunumayar.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.labelgorunumayar.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labelgorunumayar.set_Control(this.gorunumayar);
			this.labelgorunumayar.set_CustomizationFormText("Program Görünüm Ayarı : ");
			this.labelgorunumayar.set_Location(new Point(374, 0));
			this.labelgorunumayar.set_Name("labelgorunumayar");
			this.labelgorunumayar.set_Size(new Size(538, 27));
			this.labelgorunumayar.set_Text("Program Görünüm Ayarı : ");
			this.labelgorunumayar.set_TextSize(new Size(168, 16));
			this.labeldilsecimi.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold));
			this.labeldilsecimi.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labeldilsecimi.set_Control(this.dilsecimi);
			this.labeldilsecimi.set_CustomizationFormText("Dil Seçimi : ");
			this.labeldilsecimi.set_Location(new Point(0, 0));
			this.labeldilsecimi.set_Name("labeldilsecimi");
			this.labeldilsecimi.set_Size(new Size(374, 27));
			this.labeldilsecimi.set_Text("Dil Seçimi : ");
			this.labeldilsecimi.set_TextSize(new Size(168, 16));
			this.layoutControlItem8.set_Control(this.labelversiyonyazi);
			this.layoutControlItem8.set_CustomizationFormText("layoutControlItem1");
			this.layoutControlItem8.set_Location(new Point(912, 0));
			this.layoutControlItem8.set_MaxSize(new Size(170, 27));
			this.layoutControlItem8.set_MinSize(new Size(170, 27));
			this.layoutControlItem8.set_Name("layoutControlItem1");
			this.layoutControlItem8.set_Padding(new Padding(50, 0, 0, 0));
			this.layoutControlItem8.set_Size(new Size(170, 27));
			this.layoutControlItem8.set_SizeConstraintsType(2);
			this.layoutControlItem8.set_TextSize(new Size(0, 0));
			this.layoutControlItem8.set_TextVisible(false);
			this.layoutControlItem10.set_Control(this.labelversionbilgi);
			this.layoutControlItem10.set_CustomizationFormText("layoutControlItem3");
			this.layoutControlItem10.set_Location(new Point(1082, 0));
			this.layoutControlItem10.set_MaxSize(new Size(75, 27));
			this.layoutControlItem10.set_MinSize(new Size(75, 27));
			this.layoutControlItem10.set_Name("layoutControlItem3");
			this.layoutControlItem10.set_Size(new Size(75, 27));
			this.layoutControlItem10.set_SizeConstraintsType(2);
			this.layoutControlItem10.set_TextSize(new Size(0, 0));
			this.layoutControlItem10.set_TextVisible(false);
			this.backstageViewTabItem1.set_Caption("GENEL VERİLER");
			this.backstageViewTabItem1.set_ContentControl(this.backstageViewClientControl1);
			this.backstageViewTabItem1.set_Name("backstageViewTabItem1");
			this.backstageViewTabItem1.set_Selected(false);
			this.backstageViewTabItem2.set_Caption("KAPI BİLGİLERİ");
			this.backstageViewTabItem2.set_ContentControl(this.backstageViewClientControl2);
			this.backstageViewTabItem2.set_Name("backstageViewTabItem2");
			this.backstageViewTabItem2.set_Selected(true);
			this.backstageViewTabItem6.set_Caption("KUYU BİLGİLERİ");
			this.backstageViewTabItem6.set_ContentControl(this.backstageViewClientControl6);
			this.backstageViewTabItem6.set_Name("backstageViewTabItem6");
			this.backstageViewTabItem6.set_Selected(false);
			this.backstageViewTabItem3.get_Appearance().get_Options().set_UseTextOptions(true);
			this.backstageViewTabItem3.get_Appearance().get_TextOptions().set_HAlignment(1);
			this.backstageViewTabItem3.get_Appearance().get_TextOptions().set_WordWrap(2);
			this.backstageViewTabItem3.set_Caption("AĞIRLIK BİLGİLERİ");
			this.backstageViewTabItem3.set_ContentControl(this.backstageViewClientControl3);
			this.backstageViewTabItem3.set_Name("backstageViewTabItem3");
			this.backstageViewTabItem3.set_Selected(false);
			this.backstageViewTabItem5.set_Caption("DOSYA BİLGİLERİ");
			this.backstageViewTabItem5.set_ContentControl(this.backstageViewClientControl5);
			this.backstageViewTabItem5.set_Name("backstageViewTabItem5");
			this.backstageViewTabItem5.set_Selected(false);
			this.backstageViewTabItem4.set_Caption("AYARLAR");
			this.backstageViewTabItem4.set_ContentControl(this.backstageViewClientControl4);
			this.backstageViewTabItem4.set_Name("backstageViewTabItem4");
			this.backstageViewTabItem4.set_Selected(false);
			this.backstageViewButtonItem1.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.backstageViewButtonItem1.get_Appearance().set_ForeColor(Color.Red);
			this.backstageViewButtonItem1.get_Appearance().get_Options().set_UseFont(true);
			this.backstageViewButtonItem1.get_Appearance().get_Options().set_UseForeColor(true);
			this.backstageViewButtonItem1.set_Caption("ASANSÖR ÇİZ");
			this.backstageViewButtonItem1.set_Name("backstageViewButtonItem1");
			this.backstageViewButtonItem1.add_ItemClick(new BackstageViewItemEventHandler(this.backstageViewButtonItem1_ItemClick));
			this.defaultLookAndFeel1.get_LookAndFeel().set_SkinName("Office 2010 Silver");
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1310, 817);
			base.ControlBox = false;
			base.Controls.Add(this.backstageViewControl1);
			base.Name = "MainForm2";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ASCAD";
			base.FormClosing += new FormClosingEventHandler(this.MainForm2_FormClosing);
			base.Load += new EventHandler(this.MainForm2_Load);
			this.backstageViewControl1.EndInit();
			this.backstageViewControl1.ResumeLayout(false);
			this.backstageViewClientControl2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.kapitipi.get_Properties().EndInit();
			this.layoutControl7.EndInit();
			this.layoutControl7.ResumeLayout(false);
			((ISupportInitialize)this.kapiarkaimage).EndInit();
			((ISupportInitialize)this.kapionimage).EndInit();
			((ISupportInitialize)this.kapisagimage).EndInit();
			((ISupportInitialize)this.kapisolimage).EndInit();
			((ISupportInitialize)this.kapikabinimage).EndInit();
			this.layoutControlGroup2.EndInit();
			this.layoutControlItem26.EndInit();
			this.layoutControlItem29.EndInit();
			this.layoutControlItem31.EndInit();
			this.layoutControlItem33.EndInit();
			this.layoutControlItem34.EndInit();
			this.groupControl5.EndInit();
			this.groupControl5.ResumeLayout(false);
			this.kuyuyatext.get_Properties().EndInit();
			this.katatext.get_Properties().EndInit();
			this.kapisagcheck.get_Properties().EndInit();
			this.kapiarkacheck.get_Properties().EndInit();
			this.kapisolcheck.get_Properties().EndInit();
			this.labelkapitipsecimi.EndInit();
			this.labelkapitipsecimi.ResumeLayout(false);
			this.layoutControl8.EndInit();
			this.layoutControl8.ResumeLayout(false);
			this.acilmayon.get_Properties().EndInit();
			this.kapigen.get_Properties().EndInit();
			this.kapimmarmodel.get_Properties().EndInit();
			this.yangindayanim.get_Properties().EndInit();
			this.kapikaplama.get_Properties().EndInit();
			this.layoutControlGroup3.EndInit();
			this.labelkapigenisligi.EndInit();
			this.labelkapikaplamasi.EndInit();
			this.labelkapikaplamamarka.EndInit();
			this.labelyangindayanim.EndInit();
			this.layoutControlItem12.EndInit();
			this.otokaptippicture.get_Properties().EndInit();
			this.kapitippicture.get_Properties().EndInit();
			this.otokaptip.get_Properties().EndInit();
			this.backstageViewClientControl3.ResumeLayout(false);
			this.layoutControl3.EndInit();
			this.layoutControl3.ResumeLayout(false);
			this.dengekatsayisi.get_Properties().EndInit();
			this.karkasgrup.get_Properties().EndInit();
			this.karsiagrozgulkutle.get_Properties().EndInit();
			this.karsiagrbirimagirlik.get_Properties().EndInit();
			this.karkasagirlik.get_Properties().EndInit();
			this.arkaagirsayisi.get_Properties().EndInit();
			this.yanagirsayisi.get_Properties().EndInit();
			this.karsiagryukseklik.get_Properties().EndInit();
			this.karsiagrboy.get_Properties().EndInit();
			this.regulatormarka.get_Properties().EndInit();
			this.gridView3.EndInit();
			this.karsiagren.get_Properties().EndInit();
			this.karsiagrsecim.get_Properties().EndInit();
			this.karsiagrmodel.get_Properties().EndInit();
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
			this.dosyahortumserino.get_Properties().EndInit();
			this.dosyahortumonaylayan.get_Properties().EndInit();
			this.dosyahortumbelgeno.get_Properties().EndInit();
			this.dosyahortummodel.get_Properties().EndInit();
			this.dosyahortumuretici.get_Properties().EndInit();
			this.dosyadebiserino.get_Properties().EndInit();
			this.dosyadebionaylayan.get_Properties().EndInit();
			this.dosyadebibelgeno.get_Properties().EndInit();
			this.dosyadebimodel.get_Properties().EndInit();
			this.dosyadebiuret.get_Properties().EndInit();
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
			this.dosyamotorserino.get_Properties().EndInit();
			this.dosyamotoronaylayan.get_Properties().EndInit();
			this.dosyamotorbelgeno.get_Properties().EndInit();
			this.dosyamotormodel.get_Properties().EndInit();
			this.dosyamotoruretici.get_Properties().EndInit();
			this.dosyamakineurserno.get_Properties().EndInit();
			this.dosyamakineonaylayan.get_Properties().EndInit();
			this.dosyamakinebelgeno.get_Properties().EndInit();
			this.dosyamakinemodel.get_Properties().EndInit();
			this.dosyamakineuret.get_Properties().EndInit();
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
			this.dosyakapikilit.get_Properties().EndInit();
			this.gridView1.EndInit();
			this.dosyapanosn.get_Properties().EndInit();
			this.dosyapano.get_Properties().EndInit();
			this.searchLookUpEdit6View.EndInit();
			this.dosyapistonvalfisn.get_Properties().EndInit();
			this.dosyaa3ekipmansn.get_Properties().EndInit();
			this.dosyaregulatorsn.get_Properties().EndInit();
			this.dosyakumandakartisn.get_Properties().EndInit();
			this.dosyakabintamponsn.get_Properties().EndInit();
			this.dosyaagrtamponsn.get_Properties().EndInit();
			this.dosyafrenbloksn.get_Properties().EndInit();
			this.dosyakapikilitsn.get_Properties().EndInit();
			this.dosyapistonvalfi.get_Properties().EndInit();
			this.searchLookUpEdit9View.EndInit();
			this.dosyaa3ekipman.get_Properties().EndInit();
			this.searchLookUpEdit8View.EndInit();
			this.dosyaregulator.get_Properties().EndInit();
			this.searchLookUpEdit7View.EndInit();
			this.dosyakumandakarti.get_Properties().EndInit();
			this.searchLookUpEdit5View.EndInit();
			this.dosyakabintampon.get_Properties().EndInit();
			this.searchLookUpEdit4View.EndInit();
			this.dosyaagrtampon.get_Properties().EndInit();
			this.searchLookUpEdit3View.EndInit();
			this.dosyafrenblok.get_Properties().EndInit();
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
			this.dosyamutaahhitvd.get_Properties().EndInit();
			this.dosyamutaahhitvn.get_Properties().EndInit();
			this.dosyamutaahhittc.get_Properties().EndInit();
			this.dosyamutaahhit.get_Properties().EndInit();
			this.dosyabinasahipvd.get_Properties().EndInit();
			this.dosyabinasahipvn.get_Properties().EndInit();
			this.dosyabinasahiptc.get_Properties().EndInit();
			this.dosyabinasahip.get_Properties().EndInit();
			this.dosyaservistar.get_Properties().EndInit();
			this.dosyaasansorno.get_Properties().EndInit();
			this.dosyasinif.get_Properties().EndInit();
			this.dosyaparsel.get_Properties().EndInit();
			this.dosyaada.get_Properties().EndInit();
			this.dosyapafta.get_Properties().EndInit();
			this.dosyabelediye.get_Properties().EndInit();
			this.dosyailce.get_Properties().EndInit();
			this.dosyail.get_Properties().EndInit();
			this.dosyablok.get_Properties().EndInit();
			this.dosyano.get_Properties().EndInit();
			this.dosyabulvar.get_Properties().EndInit();
			this.dosyacadde.get_Properties().EndInit();
			this.dosyasokak.get_Properties().EndInit();
			this.dosyamahalle.get_Properties().EndInit();
			this.dosyaasansorsahib.get_Properties().EndInit();
			this.dosyabelgemodul.get_Properties().EndInit();
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
			this.dilsecimi.get_Properties().EndInit();
			this.gorunumayar.get_Properties().EndInit();
			this.layoutControlGroup6.EndInit();
			this.labelgorunumayar.EndInit();
			this.labeldilsecimi.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem10.EndInit();
			base.ResumeLayout(false);
		}
	}
}
