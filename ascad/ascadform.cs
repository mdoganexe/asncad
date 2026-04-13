namespace ascad
{
    using ascad.Properties;
    using DevExpress.Data;
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
    using DevExpress.XtraVerticalGrid;
    using DevExpress.XtraVerticalGrid.Events;
    using DevExpress.XtraVerticalGrid.Rows;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Windows.Forms;

    public class ascadform : Form
    {
        private RadioButton agrarka;
        private ComboBoxEdit AgrRayStr;
        private RadioButton agrsag;
        private RadioButton agrsol;
        private ImageComboBoxEdit AgrTamponu;
        private TextEdit AraKatSTR;
        public int AsansorSayisi = 1;
        public string AsansorTipi = "EA";
        private ImageComboBoxEdit asnkapitipi;
        private GridControl ayargrid;
        private CheckEdit AydinlatmaBizde;
        private BackgroundWorker backgroundWorker1;
        private RadioButton baritagr;
        private CheckEdit BesPanoVar;
        private CategoryRow category;
        private CategoryRow category1;
        private CheckEdit checkEdit1;
        private IContainer components = null;
        private CheckEdit DengeZinciri;
        private RadioButton dokumagr;
        private TextEdit DurakSayi;
        private VGridControl firmabilgigrid;
        public myData FormMyData;
        private string FormOTOKapiTip = "";
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
        private GridColumn gridColumn12;
        private GridColumn gridColumn13;
        private GridColumn gridColumn79;
        private GridColumn gridColumn80;
        private GridColumn gridColumn81;
        private GridControl gridControl1;
        private GridView gridView1;
        private GridView gridView4;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private GroupControl groupControl3;
        private GroupControl groupControl6;
        private RadioButton ha11;
        private RadioButton ha21;
        private GroupControl HAMDControl;
        private TextEdit IlkDurakNo;
        private ImageList ımageList1;
        private ImageList ımageList2;
        private CheckEdit IskeleVar;
        private ComboBoxEdit KabinRayStr;
        private ImageComboBoxEdit KabinTamponu;
        private TextEdit KapiGen;
        private TextEdit KatH;
        private DataTable katlar = new DataTable();
        private string katrumuzlist = "";
        private string katyukdiyezlist = "";
        private TextEdit KuyuDer;
        private TextEdit KuyuDibi;
        private TextEdit KuyuGen;
        private LabelControl labelControl1;
        private LabelControl labelControl10;
        private LabelControl labelControl13;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl9;
        private LayoutControl layoutControl1;
        private LayoutControl layoutControl2;
        private LayoutControl layoutControl4;
        private LayoutControl layoutControl5;
        private LayoutControl layoutControl8;
        private LayoutControl layoutControl9;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlGroup layoutControlGroup2;
        private LayoutControlGroup layoutControlGroup4;
        private LayoutControlGroup layoutControlGroup5;
        private LayoutControlGroup layoutControlGroup8;
        private LayoutControlGroup layoutControlGroup9;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem11;
        private LayoutControlItem layoutControlItem111;
        private LayoutControlItem layoutControlItem113;
        private LayoutControlItem layoutControlItem114;
        private LayoutControlItem layoutControlItem115;
        private LayoutControlItem layoutControlItem12;
        private LayoutControlItem layoutControlItem125;
        private LayoutControlItem layoutControlItem13;
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
        private LayoutControlItem layoutControlItem27;
        private LayoutControlItem layoutControlItem28;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem36;
        private LayoutControlItem layoutControlItem37;
        private LayoutControlItem layoutControlItem38;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem40;
        private LayoutControlItem layoutControlItem41;
        private LayoutControlItem layoutControlItem42;
        private LayoutControlItem layoutControlItem43;
        private LayoutControlItem layoutControlItem44;
        private LayoutControlItem layoutControlItem45;
        private LayoutControlItem layoutControlItem46;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem62;
        private LayoutControlItem layoutControlItem64;
        private LayoutControlItem layoutControlItem65;
        private LayoutControlItem layoutControlItem66;
        private LayoutControlItem layoutControlItem68;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem layoutControlItem82;
        private LayoutControlItem layoutControlItem9;
        private RadioButton makli1_1;
        private RadioButton makli1_2;
        private RadioButton maksiz1_2alttan;
        private RadioButton maksizlkarkas;
        private RadioButton mdduz;
        private TextEdit MdTabTavan;
        private ImageComboBoxEdit Mentese;
        private MultiEditorRowProperties multiEditorRowProperties1;
        private MultiEditorRowProperties multiEditorRowProperties10;
        private MultiEditorRowProperties multiEditorRowProperties11;
        private MultiEditorRowProperties multiEditorRowProperties12;
        private MultiEditorRowProperties multiEditorRowProperties2;
        private MultiEditorRowProperties multiEditorRowProperties3;
        private MultiEditorRowProperties multiEditorRowProperties4;
        private MultiEditorRowProperties multiEditorRowProperties5;
        private MultiEditorRowProperties multiEditorRowProperties6;
        private MultiEditorRowProperties multiEditorRowProperties7;
        private MultiEditorRowProperties multiEditorRowProperties8;
        private MultiEditorRowProperties multiEditorRowProperties9;
        private ImageComboBoxEdit otokapitipi;
        private CheckBox panaromik;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private RadioButton radioHMSAG;
        private RadioButton radioHMSOL;
        private ImageComboBoxEdit RegYer;
        private EditorRow row;
        private EditorRow row1;
        private EditorRow row10;
        private EditorRow row11;
        private EditorRow row12;
        private EditorRow row13;
        private EditorRow row14;
        private EditorRow row15;
        private EditorRow row2;
        private MultiEditorRow row3;
        private MultiEditorRow row4;
        private MultiEditorRow row5;
        private MultiEditorRow row6;
        private EditorRow row7;
        private MultiEditorRow row8;
        private EditorRow row9;
        private CheckBox sankod;
        private TextEdit SapCap;
        private TextEdit SeyirMesafesi;
        private srthepler shelper = new srthepler();
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private SimpleButton simpleButton4;
        private TextEdit SonKat;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel5;
        private TextEdit TahCap;
        private TextEdit textEdit2;
        private TextEdit TopKuyuKafa;
        private TextEdit ToplamYuk;
        private TextEdit txtHAMDDer;
        private TextEdit txtHAMDGen;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;
        private abc1 xx = new abc1();

        public ascadform()
        {
            this.InitializeComponent();
        }

        private void AgrGen_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void agrray_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                new productinfo { urunne = "ray" }.ShowDialog();
            }
        }

        private void agrtaneagr_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void AgrUZ_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void ascadform_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtKontrols(this.KuyuGen, "2000", 0x1388, 0x3e8);
            this.txtKontrols(this.KuyuGen, "2000", 0x1388, 0x3e8);
            this.txtKontrols(this.KapiGen, "900", 0xa28, 400);
            this.FormMyData.KuyuDer = this.KuyuDer.Text;
            this.FormMyData.KuyuGen = this.KuyuGen.Text;
            this.FormMyData.KapiGen = this.KapiGen.Text;
            this.FormMyData.KapiTip = this.asnkapitipi.EditValue.ToString() + "-" + this.otokapitipi.EditValue.ToString();
            this.FormMyData.Mentese = this.Mentese.EditValue.ToString();
            if (this.AsansorTipi == "HA")
            {
                this.HAMDSet();
                this.FormMyData.HAMDGen = this.txtHAMDGen.Text;
                this.FormMyData.HAMDDer = this.txtHAMDDer.Text;
            }
            else
            {
                char[] separator = new char[] { '#' };
                string[] strArray = this.KabinTamponu.EditValue.ToString().Split(separator);
                this.xx.oleupdate("update BLK set BlkInsName='" + strArray[0] + "' where id=70", "");
                this.xx.oleupdate("update BLK set BlkInsName='" + strArray[1] + "' where id=73", "");
                this.xx.oleupdate("update BLK set BlkInsName='" + strArray[2] + "' where id=75", "");
                char[] chArray3 = new char[] { '#' };
                string[] strArray2 = this.AgrTamponu.EditValue.ToString().Split(chArray3);
                if ((this.FormMyData.YonKodu != "ARKA") && (((strArray2[0] == "YTampon1") || (strArray2[0] == "YTampon2")) || (strArray2[0] == "HTampon")))
                {
                    strArray2[0] = strArray2[0] + "-90";
                }
                this.xx.oleupdate("update BLK set BlkInsName='" + strArray2[0] + "' where id=71", "");
                this.xx.oleupdate("update BLK set BlkInsName='" + strArray2[1] + "' where id=72", "");
                this.xx.oleupdate("update BLK set BlkInsName='" + strArray2[2] + "' where id=74", "");
            }
            this.xx.SetNumValue("RegYer", this.RegYer.EditValue.ToString(), this.AsansorSayisi.ToString());
            this.xx.SetNumValue("KabinRayStr", this.KabinRayStr.Text, this.AsansorSayisi.ToString());
            this.xx.SetNumValue("AgrRayStr", this.AgrRayStr.Text, this.AsansorSayisi.ToString());
            char[] chArray = this.KabinRayStr.Text.ToCharArray();
            int index = 0;
            string str = "";
            string str2 = "";
            string str3 = "";
            char[] chArray2 = this.AgrRayStr.Text.ToCharArray();
            int num2 = 0;
            string str4 = "";
            string str5 = "";
            string str6 = "";
            do
            {
                str = str + chArray[index].ToString();
                index++;
            }
            while (char.IsDigit(chArray[index]));
            index++;
            this.FormMyData.KRX = str;
            do
            {
                str2 = str2 + chArray[index].ToString();
                index++;
            }
            while (char.IsDigit(chArray[index]));
            this.FormMyData.KRY = str2;
            index++;
            do
            {
                str3 = str3 + chArray[index].ToString();
                index++;
            }
            while (char.IsDigit(chArray[index]));
            this.FormMyData.KRZ = str3;
            do
            {
                str4 = str4 + chArray2[num2].ToString();
                num2++;
            }
            while (char.IsDigit(chArray2[num2]));
            num2++;
            this.FormMyData.ARX = str4;
            do
            {
                str5 = str5 + chArray2[num2].ToString();
                num2++;
            }
            while (char.IsDigit(chArray2[num2]));
            this.FormMyData.ARY = str5;
            num2++;
            do
            {
                str6 = str6 + chArray2[num2].ToString();
                num2++;
            }
            while (char.IsDigit(chArray2[num2]));
            this.FormMyData.ARZ = str6;
            this.FormMyData.DurakSayi = this.DurakSayi.Text;
            this.FormMyData.KuyuKafa = this.gridView4.GetRowCellValue(this.gridView4.RowCount - 1, "kath").ToString();
            this.FormMyData.KatRumuz = this.katrumuzlist.Substring(0, this.katrumuzlist.Length - 1);
            this.FormMyData.KatYukListe = this.katyukdiyezlist.Substring(0, this.katyukdiyezlist.Length - 1);
            this.FormMyData.AraKatSTR = this.AraKatSTR.Text;
            this.FormMyData.IlkDurakKot = this.gridView4.GetRowCellValue(1, "mimkot").ToString();
            this.FormMyData.SonDurakKot = this.gridView4.GetRowCellValue(this.gridView4.RowCount - 2, "mimkot").ToString();
            this.FormMyData.KuyuDibi = this.KuyuDibi.Text;
            this.FormMyData.IlkKat = this.gridView4.GetRowCellValue(1, "kath").ToString();
            this.FormMyData.SonKat = this.gridView4.GetRowCellValue(this.gridView4.RowCount - 2, "kath").ToString();
            this.FormMyData.MDaireH = this.gridView4.GetRowCellValue(this.gridView4.RowCount - 1, "kath").ToString();
            this.FormMyData.CalisYuksek = this.MdTabTavan.Text;
            this.FormMyData.KabinRayStr = this.KabinRayStr.Text;
            this.FormMyData.AgrRayStr = this.AgrRayStr.Text;
            this.FormMyData.MDTahrikKas = this.TahCap.Text;
            this.FormMyData.MDSapKas = this.SapCap.Text;
            this.FormMyData.TahrikKas = this.TahCap.Text;
            this.FormMyData.SapKas = this.SapCap.Text;
            this.xx.SetNumValue("MDTahrikKas", this.TahCap.Text, this.AsansorSayisi.ToString());
            this.xx.SetNumValue("MDSapKas", this.SapCap.Text, this.AsansorSayisi.ToString());
            this.xx.SetNumValue("TahrikKas", this.TahCap.Text, this.AsansorSayisi.ToString());
            this.xx.SetNumValue("SapKas", this.SapCap.Text, this.AsansorSayisi.ToString());
            if (this.panaromik.Checked)
            {
                this.FormMyData.Pan = "1";
            }
            else
            {
                this.FormMyData.Pan = "0";
            }
            if (this.sankod.Checked)
            {
                this.xx.SetNumValue("TahrikKodu", "SD", "1");
            }
            else
            {
                this.xx.SetNumValue("TahrikKodu", "SD", "0");
            }
            this.FormMyData.MdTabTavan = this.MdTabTavan.Text;
            this.xx.SetNumValue("RegYer", this.RegYer.EditValue.ToString(), this.AsansorSayisi.ToString());
            if (this.agrarka.Checked)
            {
                this.FormMyData.YonKodu = "ARKA";
            }
            else if (this.agrsag.Checked)
            {
                this.FormMyData.YonKodu = "SAG";
            }
            else if (this.agrsol.Checked)
            {
                this.FormMyData.YonKodu = "SOL";
            }
            else
            {
                this.FormMyData.YonKodu = "SOL";
            }
            this.xx.SetNumValue("KabinTamponu", this.KabinTamponu.EditValue.ToString(), this.AsansorSayisi.ToString());
            this.xx.SetNumValue("AgrTamponu", this.AgrTamponu.EditValue.ToString(), this.AsansorSayisi.ToString());
            if (this.FormMyData.TipKodu == "MDDUZ")
            {
                this.FormMyData.KabinRayFark = "250";
            }
            else
            {
                this.FormMyData.KabinRayFark = "100";
            }
        }

        private void ascadform_Load(object sender, EventArgs e)
        {
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            if (this.katlar.Columns.Count == 0)
            {
                this.katlar.Columns.Add("ktno", typeof(string));
                this.katlar.Columns.Add("krumz", typeof(string));
                this.katlar.Columns.Add("kath", typeof(int));
                this.katlar.Columns.Add("mimkot", typeof(string));
            }
            this.datalarload();
            if (this.AsansorTipi == "HA")
            {
                this.panel1.Visible = false;
                this.panel2.Location = this.panel1.Location;
                this.panel2.Size = this.panel1.Size;
                this.panel2.Visible = true;
                this.ha21.Checked = true;
            }
            else
            {
                this.ha11.Checked = false;
                this.ha21.Checked = false;
            }
            this.gridControl1.DataSource = this.katlar;
            this.backgroundWorker1.RunWorkerAsync();
            this.katnolar();
            this.ayargrid.DataSource = this.xx.dtta("select * from Num" + this.AsansorSayisi + " where Comment='FRM1'", "");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.xx.oleupdate("Create schema IF NOT EXISTS ascad;Create schema IF NOT EXISTS stats;CREATE TABLE IF NOT EXISTS stats.firmabilgi(`id` int(11) NOT NULL auto_increment,  `ad` varchar(255) default NULL,  `adres` varchar(255) default NULL,  `tel` varchar(255) default NULL,  `fax` varchar(255) default NULL,  `mail` varchar(255) default NULL,  `yetkili` varchar(255) default NULL,  `marka` varchar(255) default NULL,  `onkurulusad` varchar(255) default NULL,  `onkurulusno` varchar(255) default NULL,  `santar` varchar(255) default NULL,  `sanno` varchar(255) default NULL,  `hybtar` varchar(255) default NULL,  `hybno` varchar(255) default NULL,  `mmad` varchar(255) default NULL,  `mmoda` varchar(255) default NULL,  `mmbel` varchar(255) default NULL,  `mmsmm` varchar(255) default NULL,  `emad` varchar(255) default NULL,  `emoda` varchar(255) default NULL,  `embel` varchar(255) default NULL,  `emsmm` varchar(255) default NULL,  `dil` varchar(255) default NULL,`VergiDair` varchar(255) default NULL  ,`VergiNo` varchar(255) default NULL , PRIMARY KEY(`id`)) ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;", "");
            if (this.xx.dtta("select * from stats.firmabilgi where ID=1", "").Rows.Count == 0)
            {
                this.xx.oleupdate("insert into stats.firmabilgi(ad,adres,tel,fax,mail,marka,VergiDair,VergiNo) values(' ',' ',' ',' ',' ',' ',' ',' ')", "");
            }
            this.firmabilgigrid.DataSource = this.xx.dtta("select * from stats.firmabilgi where id=1", "");
            if (this.shelper.intirnetvarmi())
            {
                int num = 100;
                string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                DataTable table = this.shelper.scrdtta("select versiyonno from ascadwhtisnew order by versiyonno desc limit 1", "");
                try
                {
                    num = Convert.ToInt32(table.Rows[0][0]);
                    char[] chArray = FileVersionInfo.GetVersionInfo(directoryName + @"\ascad.dll").FileVersion.ToCharArray();
                    if ((Convert.ToInt32(Convert.ToString(chArray[6].ToString() + chArray[7].ToString() + chArray[8].ToString())) < num) && (MessageBox.Show("ASCAD YENİ S\x00dcR\x00dcM YAYINLADI", "YENİ S\x00dcR\x00dcM BİLGİLENDİRME", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        if (System.IO.File.Exists(directoryName + @"\ascadupdate.exe"))
                        {
                            Process.Start(directoryName + @"\ascadupdate.exe");
                        }
                        else
                        {
                            try
                            {
                                new WebClient().DownloadFileAsync(new Uri("http://www.as-cad.net//ascadupdate.exe"), directoryName + @"\ascadupdate.exe");
                                new WebClient().DownloadFileAsync(new Uri("http://www.as-cad.net//DevExpress.Srt.v16.1.dll"), directoryName + @"\bin\DevExpress.Srt.v16.1.dll");
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void baritagr_CheckedChanged(object sender, EventArgs e)
        {
            if (this.baritagr.Checked)
            {
                this.FormMyData.AgrGir = "60";
            }
            else
            {
                this.FormMyData.AgrGir = "0";
            }
        }

        private void datalarload()
        {
            DataTable table = this.xx.dtta("select distinct(model) from raymaster order by sno", "");
            DataTable gelendata = this.xx.dtta("select ParamName,ParamValue from Num" + this.AsansorSayisi, "");
            int count = gelendata.Rows.Count;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                this.KabinRayStr.Properties.Items.Add(table.Rows[i][0].ToString());
                this.AgrRayStr.Properties.Items.Add(table.Rows[i][0].ToString());
            }
            this.KuyuGen.Text = this.donennumdeger(gelendata, "KuyuGen");
            this.KuyuDer.Text = this.donennumdeger(gelendata, "KuyuDer");
            this.KabinRayStr.Text = this.donennumdeger(gelendata, "KabinRayStr");
            this.AgrRayStr.Text = this.donennumdeger(gelendata, "AgrRayStr");
            this.asnkapitipi.EditValue = this.donennumdeger(gelendata, "KapiTip").ToString().Substring(0, 2);
            this.otokapitipi.EditValue = this.donennumdeger(gelendata, "KapiTip").ToString().Substring(3);
            this.Mentese.EditValue = this.donennumdeger(gelendata, "Mentese").ToString();
            this.TahCap.Text = this.donennumdeger(gelendata, "TahCap");
            this.SapCap.Text = this.donennumdeger(gelendata, "SapCap");
            this.RegYer.EditValue = this.donennumdeger(gelendata, "RegYer");
            this.KabinTamponu.EditValue = this.donennumdeger(gelendata, "KabinTamponu");
            this.AgrTamponu.EditValue = this.donennumdeger(gelendata, "AgrTamponu");
            this.panaromik.Checked = Convert.ToBoolean(Convert.ToInt32(this.donennumdeger(gelendata, "Pan")));
            this.sankod.Checked = Convert.ToBoolean(Convert.ToInt32(this.donennumdeger(gelendata, "SD")));
            this.DurakSayi.Text = this.donennumdeger(gelendata, "DurakSayi");
            this.IlkDurakNo.Text = this.donennumdeger(gelendata, "IlkDurakNo");
            foreach (Control control in this.layoutControl4.Controls)
            {
                if (!string.IsNullOrEmpty(control.Name))
                {
                    try
                    {
                        int num3 = 0;
                        do
                        {
                            if ((((control.GetType().ToString() != "DevExpress.XtraEditors.LabelControl") || (control.GetType().ToString() != "DevExpress.XtraEditors.GroupControl")) || (control.GetType().ToString() != "DevExpress.XtraEditors.SimpleButton")) || (control.GetType().ToString() != "System.Windows.Forms.RadioButton"))
                            {
                                num3++;
                            }
                        }
                        while (!string.Equals(gelendata.Rows[num3]["ParamName"].ToString(), control.Name) && (num3 < count));
                        if (control.Name == "DengeZinciri")
                        {
                            this.DengeZinciri.EditValue = Convert.ToBoolean(Convert.ToInt32(gelendata.Rows[num3]["ParamValue"].ToString()));
                        }
                        else if (control.Name == "IskeleVar")
                        {
                            this.IskeleVar.EditValue = Convert.ToBoolean(Convert.ToInt32(gelendata.Rows[num3]["ParamValue"].ToString()));
                        }
                        else
                        {
                            control.Text = gelendata.Rows[num3]["ParamValue"].ToString();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            this.tipayarla();
            if ((this.mdduz.Checked || this.maksiz1_2alttan.Checked) || this.maksizlkarkas.Checked)
            {
                this.TahCap.Text = this.FormMyData.MDTahrikKas;
                this.SapCap.Text = this.FormMyData.MDSapKas;
            }
            else
            {
                this.TahCap.Text = this.FormMyData.TahrikKas;
                this.SapCap.Text = this.FormMyData.SapKas;
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

        private string donennumdeger(DataTable gelendata, string paramname)
        {
            for (int i = 0; i < gelendata.Rows.Count; i++)
            {
                if (gelendata.Rows[i]["ParamName"].ToString() == paramname)
                {
                    return gelendata.Rows[i]["ParamValue"].ToString();
                }
            }
            return "0";
        }

        private void grhes2()
        {
            int num = 0;
            ArrayList list = new ArrayList();
            int num2 = 0;
            if (Convert.ToInt32(this.IlkDurakNo.Text) < 0)
            {
                for (int i = 1; i < (this.katlar.Rows.Count - 1); i++)
                {
                    if (Convert.ToInt32(this.gridView4.GetRowCellValue(i, "ktno").ToString()) < 0)
                    {
                        num2 -= Convert.ToInt32(this.gridView4.GetRowCellValue(i, "kath").ToString());
                        list.Add(num2);
                    }
                }
                list.Reverse();
                for (int j = 0; j < list.Count; j++)
                {
                    this.gridView4.SetRowCellValue(j + 1, "mimkot", list[j]);
                }
                this.gridView4.SetRowCellValue(0, "mimkot", num2 - Convert.ToInt32(this.KuyuDibi.Text));
                for (int k = 1; k < this.katlar.Rows.Count; k++)
                {
                    try
                    {
                        if (Convert.ToInt32(this.gridView4.GetRowCellValue(k, "ktno").ToString()) == 0)
                        {
                            this.gridView4.SetRowCellValue(k, "mimkot", 0);
                        }
                        else if (Convert.ToInt32(this.gridView4.GetRowCellValue(k, "ktno").ToString()) > 0)
                        {
                            num += Convert.ToInt32(this.gridView4.GetRowCellValue(k, "kath").ToString());
                            this.gridView4.SetRowCellValue(k, "mimkot", num);
                        }
                    }
                    catch (Exception)
                    {
                        num += Convert.ToInt32(this.gridView4.GetRowCellValue(k, "kath").ToString());
                        this.gridView4.SetRowCellValue(k, "mimkot", num);
                    }
                }
            }
            else
            {
                this.gridView4.SetRowCellValue(0, "mimkot", "-" + this.FormMyData.KuyuDibi);
                for (int m = 1; m < this.katlar.Rows.Count; m++)
                {
                    if (m == 1)
                    {
                        this.gridView4.SetRowCellValue(m, "mimkot", 0);
                    }
                    else
                    {
                        num += Convert.ToInt32(this.gridView4.GetRowCellValue(m - 1, "kath").ToString());
                        this.gridView4.SetRowCellValue(m, "mimkot", num);
                    }
                }
            }
        }

        private void gridkatHhesapla()
        {
            int num = 0;
            ArrayList list = new ArrayList();
            int num2 = 0;
            if (Convert.ToInt32(this.IlkDurakNo.Text) < 0)
            {
                for (int i = 1; i < (this.katlar.Rows.Count - 1); i++)
                {
                    if (Convert.ToInt32(this.katlar.Rows[i]["ktno"].ToString()) < 0)
                    {
                        num2 -= Convert.ToInt32(this.gridView4.GetRowCellValue(i, "kath").ToString());
                        list.Add(num2);
                    }
                }
                list.Reverse();
                for (int j = 0; j < list.Count; j++)
                {
                    this.katlar.Rows[j + 1]["mimkot"] = list[j];
                }
                this.katlar.Rows[0]["mimkot"] = num2 - Convert.ToInt32(this.KuyuDibi.Text);
                for (int k = 1; k < this.katlar.Rows.Count; k++)
                {
                    try
                    {
                        if (k == (this.katlar.Rows.Count - 1))
                        {
                            num = (num + Convert.ToInt32(this.katlar.Rows[k - 1]["kath"])) + Convert.ToInt32(this.katlar.Rows[k]["kath"]);
                            this.katlar.Rows[k]["mimkot"] = num;
                        }
                        else if (Convert.ToInt32(this.katlar.Rows[k]["ktno"].ToString()) == 0)
                        {
                            this.katlar.Rows[k]["mimkot"] = 0;
                        }
                        else if ((Convert.ToInt32(this.katlar.Rows[k]["ktno"].ToString()) > 0) && (k < (this.katlar.Rows.Count - 1)))
                        {
                            num += Convert.ToInt32(this.katlar.Rows[k - 1]["kath"].ToString());
                            this.katlar.Rows[k]["mimkot"] = num;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                this.katlar.Rows[0]["mimkot"] = Convert.ToInt32(this.FormMyData.KuyuDibi) * -1;
                for (int m = 1; m < this.katlar.Rows.Count; m++)
                {
                    if (m == 1)
                    {
                        this.katlar.Rows[m]["mimkot"] = 0;
                    }
                    else if (m == (this.katlar.Rows.Count - 1))
                    {
                        num = (num + Convert.ToInt32(this.katlar.Rows[m - 1]["kath"])) + Convert.ToInt32(this.katlar.Rows[m]["kath"]);
                        this.katlar.Rows[m]["mimkot"] = num;
                    }
                    else
                    {
                        num += Convert.ToInt32(this.katlar.Rows[m - 1]["kath"]);
                        this.katlar.Rows[m]["mimkot"] = num;
                    }
                }
            }
            this.gridControl1.DataSource = this.katlar;
            this.katlarclosing();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.xx.oleupdate(string.Concat(new object[] { "update Num", this.AsansorSayisi, " set ", e.Column.FieldName, " ='", e.Value.ToString(), "' where ParamName='", this.gridView1.GetRowCellValue(e.RowHandle, "ParamName").ToString(), "'" }), "");
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if ((e.Column.FieldName == "kath") || (e.Column.FieldName == "krumz"))
            {
                this.grhes2();
                this.katlarclosing();
            }
        }

        private void HAMDSet()
        {
            if (this.radioHMSAG.Checked)
            {
                this.FormMyData.MakYon = "SAG";
            }
            else
            {
                this.FormMyData.MakYon = "SOL";
            }
            if (this.agrarka.Checked)
            {
            }
            if (this.agrsol.Checked)
            {
            }
            if (this.agrsag.Checked)
            {
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ascadform));
            this.maksizlkarkas = new RadioButton();
            this.maksiz1_2alttan = new RadioButton();
            this.makli1_1 = new RadioButton();
            this.makli1_2 = new RadioButton();
            this.agrarka = new RadioButton();
            this.agrsol = new RadioButton();
            this.agrsag = new RadioButton();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.mdduz = new RadioButton();
            this.groupControl3 = new GroupControl();
            this.layoutControl9 = new LayoutControl();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.panaromik = new CheckBox();
            this.sankod = new CheckBox();
            this.layoutControlGroup9 = new LayoutControlGroup();
            this.layoutControlItem5 = new LayoutControlItem();
            this.layoutControl5 = new LayoutControl();
            this.baritagr = new RadioButton();
            this.dokumagr = new RadioButton();
            this.layoutControlGroup5 = new LayoutControlGroup();
            this.layoutControlItem45 = new LayoutControlItem();
            this.layoutControlItem46 = new LayoutControlItem();
            this.layoutControl1 = new LayoutControl();
            this.AgrTamponu = new ImageComboBoxEdit();
            this.ımageList1 = new ImageList(this.components);
            this.KabinTamponu = new ImageComboBoxEdit();
            this.labelControl9 = new LabelControl();
            this.AgrRayStr = new ComboBoxEdit();
            this.KuyuDer = new TextEdit();
            this.labelControl10 = new LabelControl();
            this.KabinRayStr = new ComboBoxEdit();
            this.KuyuGen = new TextEdit();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem111 = new LayoutControlItem();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.layoutControlItem114 = new LayoutControlItem();
            this.layoutControlItem113 = new LayoutControlItem();
            this.layoutControlItem115 = new LayoutControlItem();
            this.layoutControlItem10 = new LayoutControlItem();
            this.layoutControlItem15 = new LayoutControlItem();
            this.layoutControl2 = new LayoutControl();
            this.labelControl3 = new LabelControl();
            this.checkEdit1 = new CheckEdit();
            this.textEdit2 = new TextEdit();
            this.RegYer = new ImageComboBoxEdit();
            this.Mentese = new ImageComboBoxEdit();
            this.KapiGen = new TextEdit();
            this.otokapitipi = new ImageComboBoxEdit();
            this.asnkapitipi = new ImageComboBoxEdit();
            this.labelControl4 = new LabelControl();
            this.labelControl13 = new LabelControl();
            this.TahCap = new TextEdit();
            this.SapCap = new TextEdit();
            this.labelControl1 = new LabelControl();
            this.layoutControlGroup2 = new LayoutControlGroup();
            this.layoutControlItem11 = new LayoutControlItem();
            this.layoutControlItem22 = new LayoutControlItem();
            this.layoutControlItem27 = new LayoutControlItem();
            this.layoutControlItem28 = new LayoutControlItem();
            this.layoutControlItem4 = new LayoutControlItem();
            this.layoutControlItem3 = new LayoutControlItem();
            this.layoutControlItem9 = new LayoutControlItem();
            this.layoutControlItem8 = new LayoutControlItem();
            this.layoutControlItem6 = new LayoutControlItem();
            this.layoutControlItem7 = new LayoutControlItem();
            this.layoutControlItem12 = new LayoutControlItem();
            this.layoutControlItem13 = new LayoutControlItem();
            this.layoutControlItem14 = new LayoutControlItem();
            this.groupControl6 = new GroupControl();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.tableLayoutPanel5 = new TableLayoutPanel();
            this.HAMDControl = new GroupControl();
            this.layoutControl8 = new LayoutControl();
            this.txtHAMDDer = new TextEdit();
            this.radioHMSOL = new RadioButton();
            this.txtHAMDGen = new TextEdit();
            this.radioHMSAG = new RadioButton();
            this.layoutControlGroup8 = new LayoutControlGroup();
            this.layoutControlItem62 = new LayoutControlItem();
            this.layoutControlItem64 = new LayoutControlItem();
            this.layoutControlItem65 = new LayoutControlItem();
            this.layoutControlItem66 = new LayoutControlItem();
            this.ha11 = new RadioButton();
            this.ha21 = new RadioButton();
            this.layoutControl4 = new LayoutControl();
            this.IskeleVar = new CheckEdit();
            this.DengeZinciri = new CheckEdit();
            this.ToplamYuk = new TextEdit();
            this.SeyirMesafesi = new TextEdit();
            this.pictureBox2 = new PictureBox();
            this.simpleButton4 = new SimpleButton();
            this.simpleButton3 = new SimpleButton();
            this.gridControl1 = new GridControl();
            this.gridView4 = new GridView();
            this.gridColumn10 = new GridColumn();
            this.gridColumn11 = new GridColumn();
            this.gridColumn12 = new GridColumn();
            this.gridColumn13 = new GridColumn();
            this.simpleButton2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.MdTabTavan = new TextEdit();
            this.SonKat = new TextEdit();
            this.AraKatSTR = new TextEdit();
            this.TopKuyuKafa = new TextEdit();
            this.KuyuDibi = new TextEdit();
            this.DurakSayi = new TextEdit();
            this.KatH = new TextEdit();
            this.IlkDurakNo = new TextEdit();
            this.layoutControlGroup4 = new LayoutControlGroup();
            this.layoutControlItem36 = new LayoutControlItem();
            this.layoutControlItem37 = new LayoutControlItem();
            this.layoutControlItem38 = new LayoutControlItem();
            this.layoutControlItem42 = new LayoutControlItem();
            this.layoutControlItem43 = new LayoutControlItem();
            this.layoutControlItem44 = new LayoutControlItem();
            this.layoutControlItem68 = new LayoutControlItem();
            this.layoutControlItem82 = new LayoutControlItem();
            this.layoutControlItem125 = new LayoutControlItem();
            this.layoutControlItem40 = new LayoutControlItem();
            this.layoutControlItem41 = new LayoutControlItem();
            this.BesPanoVar = new CheckEdit();
            this.AydinlatmaBizde = new CheckEdit();
            this.groupControl1 = new GroupControl();
            this.firmabilgigrid = new VGridControl();
            this.row = new EditorRow();
            this.row1 = new EditorRow();
            this.row2 = new EditorRow();
            this.row4 = new MultiEditorRow();
            this.multiEditorRowProperties5 = new MultiEditorRowProperties();
            this.multiEditorRowProperties6 = new MultiEditorRowProperties();
            this.row3 = new MultiEditorRow();
            this.multiEditorRowProperties1 = new MultiEditorRowProperties();
            this.multiEditorRowProperties2 = new MultiEditorRowProperties();
            this.multiEditorRowProperties3 = new MultiEditorRowProperties();
            this.multiEditorRowProperties4 = new MultiEditorRowProperties();
            this.row5 = new MultiEditorRow();
            this.multiEditorRowProperties7 = new MultiEditorRowProperties();
            this.multiEditorRowProperties8 = new MultiEditorRowProperties();
            this.row8 = new MultiEditorRow();
            this.multiEditorRowProperties9 = new MultiEditorRowProperties();
            this.multiEditorRowProperties10 = new MultiEditorRowProperties();
            this.row6 = new MultiEditorRow();
            this.multiEditorRowProperties11 = new MultiEditorRowProperties();
            this.multiEditorRowProperties12 = new MultiEditorRowProperties();
            this.category = new CategoryRow();
            this.row7 = new EditorRow();
            this.row9 = new EditorRow();
            this.row10 = new EditorRow();
            this.row11 = new EditorRow();
            this.category1 = new CategoryRow();
            this.row12 = new EditorRow();
            this.row13 = new EditorRow();
            this.row14 = new EditorRow();
            this.row15 = new EditorRow();
            this.backgroundWorker1 = new BackgroundWorker();
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage1 = new XtraTabPage();
            this.groupControl2 = new GroupControl();
            this.xtraTabPage2 = new XtraTabPage();
            this.xtraTabPage3 = new XtraTabPage();
            this.ayargrid = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn79 = new GridColumn();
            this.gridColumn80 = new GridColumn();
            this.gridColumn81 = new GridColumn();
            this.xtraTabPage4 = new XtraTabPage();
            this.labelControl2 = new LabelControl();
            this.ımageList2 = new ImageList(this.components);
            this.layoutControlItem16 = new LayoutControlItem();
            this.layoutControlItem17 = new LayoutControlItem();
            this.layoutControlItem18 = new LayoutControlItem();
            this.layoutControlItem19 = new LayoutControlItem();
            this.layoutControlItem20 = new LayoutControlItem();
            this.layoutControlItem21 = new LayoutControlItem();
            this.layoutControlItem23 = new LayoutControlItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupControl3.BeginInit();
            this.groupControl3.SuspendLayout();
            this.layoutControl9.BeginInit();
            this.layoutControl9.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.layoutControlGroup9.BeginInit();
            this.layoutControlItem5.BeginInit();
            this.layoutControl5.BeginInit();
            this.layoutControl5.SuspendLayout();
            this.layoutControlGroup5.BeginInit();
            this.layoutControlItem45.BeginInit();
            this.layoutControlItem46.BeginInit();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            this.AgrTamponu.Properties.BeginInit();
            this.KabinTamponu.Properties.BeginInit();
            this.AgrRayStr.Properties.BeginInit();
            this.KuyuDer.Properties.BeginInit();
            this.KabinRayStr.Properties.BeginInit();
            this.KuyuGen.Properties.BeginInit();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem111.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem2.BeginInit();
            this.layoutControlItem114.BeginInit();
            this.layoutControlItem113.BeginInit();
            this.layoutControlItem115.BeginInit();
            this.layoutControlItem10.BeginInit();
            this.layoutControlItem15.BeginInit();
            this.layoutControl2.BeginInit();
            this.layoutControl2.SuspendLayout();
            this.checkEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.RegYer.Properties.BeginInit();
            this.Mentese.Properties.BeginInit();
            this.KapiGen.Properties.BeginInit();
            this.otokapitipi.Properties.BeginInit();
            this.asnkapitipi.Properties.BeginInit();
            this.TahCap.Properties.BeginInit();
            this.SapCap.Properties.BeginInit();
            this.layoutControlGroup2.BeginInit();
            this.layoutControlItem11.BeginInit();
            this.layoutControlItem22.BeginInit();
            this.layoutControlItem27.BeginInit();
            this.layoutControlItem28.BeginInit();
            this.layoutControlItem4.BeginInit();
            this.layoutControlItem3.BeginInit();
            this.layoutControlItem9.BeginInit();
            this.layoutControlItem8.BeginInit();
            this.layoutControlItem6.BeginInit();
            this.layoutControlItem7.BeginInit();
            this.layoutControlItem12.BeginInit();
            this.layoutControlItem13.BeginInit();
            this.layoutControlItem14.BeginInit();
            this.groupControl6.BeginInit();
            this.groupControl6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.HAMDControl.BeginInit();
            this.HAMDControl.SuspendLayout();
            this.layoutControl8.BeginInit();
            this.layoutControl8.SuspendLayout();
            this.txtHAMDDer.Properties.BeginInit();
            this.txtHAMDGen.Properties.BeginInit();
            this.layoutControlGroup8.BeginInit();
            this.layoutControlItem62.BeginInit();
            this.layoutControlItem64.BeginInit();
            this.layoutControlItem65.BeginInit();
            this.layoutControlItem66.BeginInit();
            this.layoutControl4.BeginInit();
            this.layoutControl4.SuspendLayout();
            this.IskeleVar.Properties.BeginInit();
            this.DengeZinciri.Properties.BeginInit();
            this.ToplamYuk.Properties.BeginInit();
            this.SeyirMesafesi.Properties.BeginInit();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            this.gridControl1.BeginInit();
            this.gridView4.BeginInit();
            this.MdTabTavan.Properties.BeginInit();
            this.SonKat.Properties.BeginInit();
            this.AraKatSTR.Properties.BeginInit();
            this.TopKuyuKafa.Properties.BeginInit();
            this.KuyuDibi.Properties.BeginInit();
            this.DurakSayi.Properties.BeginInit();
            this.KatH.Properties.BeginInit();
            this.IlkDurakNo.Properties.BeginInit();
            this.layoutControlGroup4.BeginInit();
            this.layoutControlItem36.BeginInit();
            this.layoutControlItem37.BeginInit();
            this.layoutControlItem38.BeginInit();
            this.layoutControlItem42.BeginInit();
            this.layoutControlItem43.BeginInit();
            this.layoutControlItem44.BeginInit();
            this.layoutControlItem68.BeginInit();
            this.layoutControlItem82.BeginInit();
            this.layoutControlItem125.BeginInit();
            this.layoutControlItem40.BeginInit();
            this.layoutControlItem41.BeginInit();
            this.BesPanoVar.Properties.BeginInit();
            this.AydinlatmaBizde.Properties.BeginInit();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.firmabilgigrid.BeginInit();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupControl2.BeginInit();
            this.groupControl2.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.ayargrid.BeginInit();
            this.gridView1.BeginInit();
            this.xtraTabPage4.SuspendLayout();
            this.layoutControlItem16.BeginInit();
            this.layoutControlItem17.BeginInit();
            this.layoutControlItem18.BeginInit();
            this.layoutControlItem19.BeginInit();
            this.layoutControlItem20.BeginInit();
            this.layoutControlItem21.BeginInit();
            this.layoutControlItem23.BeginInit();
            base.SuspendLayout();
            this.maksizlkarkas.AccessibleDescription = "maksiz3";
            this.maksizlkarkas.BackColor = SystemColors.Control;
            this.maksizlkarkas.Dock = DockStyle.Fill;
            this.maksizlkarkas.Enabled = false;
            this.maksizlkarkas.FlatAppearance.BorderColor = Color.CadetBlue;
            this.maksizlkarkas.FlatAppearance.BorderSize = 2;
            this.maksizlkarkas.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
            this.maksizlkarkas.Image = Resources.l_karkas1;
            this.maksizlkarkas.ImageAlign = ContentAlignment.MiddleLeft;
            this.maksizlkarkas.Location = new Point(3, 0x163);
            this.maksizlkarkas.Name = "maksizlkarkas";
            this.maksizlkarkas.Size = new Size(0xed, 0x52);
            this.maksizlkarkas.TabIndex = 3;
            this.maksizlkarkas.Text = "MRL L Karkas";
            this.maksizlkarkas.TextAlign = ContentAlignment.MiddleRight;
            this.maksizlkarkas.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.maksizlkarkas.UseVisualStyleBackColor = false;
            this.maksizlkarkas.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.maksiz1_2alttan.AccessibleDescription = "maksiz2";
            this.maksiz1_2alttan.Dock = DockStyle.Fill;
            this.maksiz1_2alttan.FlatAppearance.BorderColor = Color.CadetBlue;
            this.maksiz1_2alttan.FlatAppearance.BorderSize = 2;
            this.maksiz1_2alttan.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.maksiz1_2alttan.Image = (Image) manager.GetObject("maksiz1_2alttan.Image");
            this.maksiz1_2alttan.ImageAlign = ContentAlignment.MiddleLeft;
            this.maksiz1_2alttan.Location = new Point(3, 0xb3);
            this.maksiz1_2alttan.Name = "maksiz1_2alttan";
            this.maksiz1_2alttan.Size = new Size(0xed, 0x52);
            this.maksiz1_2alttan.TabIndex = 3;
            this.maksiz1_2alttan.Text = "MRL \x00c7APRAZ PALANGA";
            this.maksiz1_2alttan.TextAlign = ContentAlignment.BottomCenter;
            this.maksiz1_2alttan.TextImageRelation = TextImageRelation.ImageAboveText;
            this.maksiz1_2alttan.UseVisualStyleBackColor = true;
            this.maksiz1_2alttan.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.makli1_1.AccessibleDescription = "mak1";
            this.makli1_1.Dock = DockStyle.Fill;
            this.makli1_1.FlatAppearance.BorderColor = Color.CadetBlue;
            this.makli1_1.FlatAppearance.BorderSize = 2;
            this.makli1_1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.makli1_1.Image = Resources.makdaireli1_1;
            this.makli1_1.ImageAlign = ContentAlignment.MiddleLeft;
            this.makli1_1.Location = new Point(3, 3);
            this.makli1_1.Name = "makli1_1";
            this.makli1_1.Size = new Size(0xed, 0x52);
            this.makli1_1.TabIndex = 2;
            this.makli1_1.Text = "1/1 DİREK ASKI";
            this.makli1_1.TextAlign = ContentAlignment.MiddleRight;
            this.makli1_1.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.makli1_1.UseVisualStyleBackColor = true;
            this.makli1_1.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.makli1_2.AccessibleDescription = "mak2";
            this.makli1_2.Dock = DockStyle.Fill;
            this.makli1_2.FlatAppearance.BorderColor = Color.CadetBlue;
            this.makli1_2.FlatAppearance.BorderSize = 2;
            this.makli1_2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.makli1_2.Image = Resources.makdaireli1_2;
            this.makli1_2.ImageAlign = ContentAlignment.MiddleLeft;
            this.makli1_2.Location = new Point(3, 0x5b);
            this.makli1_2.Name = "makli1_2";
            this.makli1_2.Size = new Size(0xed, 0x52);
            this.makli1_2.TabIndex = 3;
            this.makli1_2.Text = "1/2 ENDİREK ASKI";
            this.makli1_2.TextAlign = ContentAlignment.MiddleRight;
            this.makli1_2.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.makli1_2.UseVisualStyleBackColor = true;
            this.makli1_2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.agrarka.AccessibleDescription = "agrarka";
            this.agrarka.Dock = DockStyle.Fill;
            this.agrarka.FlatAppearance.BorderColor = Color.CadetBlue;
            this.agrarka.FlatAppearance.BorderSize = 2;
            this.agrarka.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.agrarka.Image = (Image) manager.GetObject("agrarka.Image");
            this.agrarka.Location = new Point(3, 3);
            this.agrarka.Name = "agrarka";
            this.agrarka.Size = new Size(0x8d, 0x69);
            this.agrarka.TabIndex = 3;
            this.agrarka.Text = "ARKA";
            this.agrarka.TextAlign = ContentAlignment.TopCenter;
            this.agrarka.TextImageRelation = TextImageRelation.TextAboveImage;
            this.agrarka.UseVisualStyleBackColor = true;
            this.agrsol.AccessibleDescription = "agrsol";
            this.agrsol.Dock = DockStyle.Fill;
            this.agrsol.FlatAppearance.BorderColor = Color.CadetBlue;
            this.agrsol.FlatAppearance.BorderSize = 2;
            this.agrsol.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.agrsol.Image = (Image) manager.GetObject("agrsol.Image");
            this.agrsol.Location = new Point(0x129, 3);
            this.agrsol.Name = "agrsol";
            this.agrsol.Size = new Size(0x8d, 0x69);
            this.agrsol.TabIndex = 2;
            this.agrsol.Text = "SOL";
            this.agrsol.TextAlign = ContentAlignment.TopCenter;
            this.agrsol.TextImageRelation = TextImageRelation.TextAboveImage;
            this.agrsol.UseVisualStyleBackColor = true;
            this.agrsag.AccessibleDescription = "agrsag";
            this.agrsag.Dock = DockStyle.Fill;
            this.agrsag.FlatAppearance.BorderColor = Color.CadetBlue;
            this.agrsag.FlatAppearance.BorderSize = 2;
            this.agrsag.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.agrsag.Image = (Image) manager.GetObject("agrsag.Image");
            this.agrsag.Location = new Point(150, 3);
            this.agrsag.Name = "agrsag";
            this.agrsag.Size = new Size(0x8d, 0x69);
            this.agrsag.TabIndex = 3;
            this.agrsag.Text = "SAĞ";
            this.agrsag.TextAlign = ContentAlignment.TopCenter;
            this.agrsag.TextImageRelation = TextImageRelation.TextAboveImage;
            this.agrsag.UseVisualStyleBackColor = true;
            this.tableLayoutPanel1.BackColor = SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.Controls.Add(this.mdduz, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.maksizlkarkas, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.maksiz1_2alttan, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.makli1_2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.makli1_1, 0, 0);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel1.Size = new Size(0xf3, 440);
            this.tableLayoutPanel1.TabIndex = 0;
            this.mdduz.AccessibleDescription = "maksiz2";
            this.mdduz.Dock = DockStyle.Fill;
            this.mdduz.FlatAppearance.BorderColor = Color.CadetBlue;
            this.mdduz.FlatAppearance.BorderSize = 2;
            this.mdduz.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.mdduz.Image = (Image) manager.GetObject("mdduz.Image");
            this.mdduz.ImageAlign = ContentAlignment.MiddleLeft;
            this.mdduz.Location = new Point(3, 0x10b);
            this.mdduz.Name = "mdduz";
            this.mdduz.Size = new Size(0xed, 0x52);
            this.mdduz.TabIndex = 15;
            this.mdduz.Text = "MRL RAYLAR \x00d6NDE";
            this.mdduz.TextAlign = ContentAlignment.BottomCenter;
            this.mdduz.TextImageRelation = TextImageRelation.ImageAboveText;
            this.mdduz.UseVisualStyleBackColor = true;
            this.mdduz.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.groupControl3.AppearanceCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.groupControl3.AppearanceCaption.ForeColor = Color.FromArgb(0xc0, 0, 0);
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl3.Controls.Add(this.layoutControl9);
            this.groupControl3.Location = new Point(0xf9, 0x12e);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new Size(0x2ea, 140);
            this.groupControl3.TabIndex = 0x10;
            this.groupControl3.Text = "TAHRİK Y\x00d6N\x00dc";
            this.layoutControl9.Controls.Add(this.tableLayoutPanel2);
            this.layoutControl9.Dock = DockStyle.Fill;
            this.layoutControl9.Location = new Point(2, 0x17);
            this.layoutControl9.Name = "layoutControl9";
            this.layoutControl9.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(0x3f7, 0x1d, 0x296, 0x1b3);
            this.layoutControl9.Root = this.layoutControlGroup9;
            this.layoutControl9.Size = new Size(0x2e6, 0x73);
            this.layoutControl9.TabIndex = 0;
            this.layoutControl9.Text = "layoutControl9";
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            this.tableLayoutPanel2.Controls.Add(this.agrarka, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.agrsag, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.agrsol, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panaromik, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.sankod, 4, 0);
            this.tableLayoutPanel2.Location = new Point(2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel2.Size = new Size(0x2e2, 0x6f);
            this.tableLayoutPanel2.TabIndex = 4;
            this.panaromik.Dock = DockStyle.Fill;
            this.panaromik.Enabled = false;
            this.panaromik.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.panaromik.Image = (Image) manager.GetObject("panaromik.Image");
            this.panaromik.ImageAlign = ContentAlignment.BottomCenter;
            this.panaromik.Location = new Point(0x1bc, 3);
            this.panaromik.MinimumSize = new Size(0, 100);
            this.panaromik.Name = "panaromik";
            this.panaromik.Size = new Size(0x8d, 0x69);
            this.panaromik.TabIndex = 0x3eb;
            this.panaromik.Text = "PANOROMİK";
            this.panaromik.TextAlign = ContentAlignment.TopCenter;
            this.panaromik.UseVisualStyleBackColor = true;
            this.panaromik.CheckedChanged += new EventHandler(this.panaromik_CheckedChanged);
            this.sankod.Dock = DockStyle.Fill;
            this.sankod.Enabled = false;
            this.sankod.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.sankod.Image = (Image) manager.GetObject("sankod.Image");
            this.sankod.ImageAlign = ContentAlignment.BottomCenter;
            this.sankod.Location = new Point(0x24f, 3);
            this.sankod.MinimumSize = new Size(0, 100);
            this.sankod.Name = "sankod";
            this.sankod.Size = new Size(0x90, 0x69);
            this.sankod.TabIndex = 0x3ec;
            this.sankod.Text = "\x00c7ER\x00c7EVESİZ AĞIRLIK";
            this.sankod.TextAlign = ContentAlignment.TopCenter;
            this.sankod.UseVisualStyleBackColor = true;
            this.sankod.CheckedChanged += new EventHandler(this.sankod_CheckedChanged);
            this.layoutControlGroup9.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup9.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem5 };
            this.layoutControlGroup9.Items.AddRange(items);
            this.layoutControlGroup9.Location = new Point(0, 0);
            this.layoutControlGroup9.Name = "Root";
            this.layoutControlGroup9.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup9.Size = new Size(0x2e6, 0x73);
            this.layoutControlGroup9.TextVisible = false;
            this.layoutControlItem5.Control = this.tableLayoutPanel2;
            this.layoutControlItem5.Location = new Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new Size(0x2e6, 0x73);
            this.layoutControlItem5.TextSize = new Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            this.layoutControl5.Controls.Add(this.baritagr);
            this.layoutControl5.Controls.Add(this.dokumagr);
            this.layoutControl5.Dock = DockStyle.Fill;
            this.layoutControl5.Location = new Point(2, 0x17);
            this.layoutControl5.Name = "layoutControl5";
            this.layoutControl5.Root = this.layoutControlGroup5;
            this.layoutControl5.Size = new Size(0x10b, 0x75);
            this.layoutControl5.TabIndex = 0x10;
            this.layoutControl5.Text = "layoutControl5";
            this.baritagr.AccessibleDescription = "mak2";
            this.baritagr.FlatAppearance.BorderColor = Color.CadetBlue;
            this.baritagr.FlatAppearance.BorderSize = 2;
            this.baritagr.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.baritagr.Image = (Image) manager.GetObject("baritagr.Image");
            this.baritagr.ImageAlign = ContentAlignment.MiddleLeft;
            this.baritagr.Location = new Point(7, 7);
            this.baritagr.Name = "baritagr";
            this.baritagr.Size = new Size(0xfd, 0x24);
            this.baritagr.TabIndex = 14;
            this.baritagr.Text = "BARİT AĞIRLIK";
            this.baritagr.TextAlign = ContentAlignment.MiddleRight;
            this.baritagr.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.baritagr.UseVisualStyleBackColor = true;
            this.baritagr.CheckedChanged += new EventHandler(this.baritagr_CheckedChanged);
            this.dokumagr.AccessibleDescription = "mak2";
            this.dokumagr.FlatAppearance.BorderColor = Color.CadetBlue;
            this.dokumagr.FlatAppearance.BorderSize = 2;
            this.dokumagr.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.dokumagr.Image = (Image) manager.GetObject("dokumagr.Image");
            this.dokumagr.ImageAlign = ContentAlignment.MiddleLeft;
            this.dokumagr.Location = new Point(7, 0x2f);
            this.dokumagr.Name = "dokumagr";
            this.dokumagr.Size = new Size(0xfd, 0x24);
            this.dokumagr.TabIndex = 15;
            this.dokumagr.Text = "D\x00d6K\x00dcM AĞIRLIK";
            this.dokumagr.TextAlign = ContentAlignment.MiddleRight;
            this.dokumagr.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.dokumagr.UseVisualStyleBackColor = true;
            this.dokumagr.CheckedChanged += new EventHandler(this.baritagr_CheckedChanged);
            this.layoutControlGroup5.CustomizationFormText = "layoutControlGroup5";
            this.layoutControlGroup5.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup5.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray2 = new BaseLayoutItem[] { this.layoutControlItem45, this.layoutControlItem46 };
            this.layoutControlGroup5.Items.AddRange(itemArray2);
            this.layoutControlGroup5.Location = new Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup5.Size = new Size(0x10b, 0x75);
            this.layoutControlGroup5.TextVisible = false;
            this.layoutControlItem45.Control = this.baritagr;
            this.layoutControlItem45.CustomizationFormText = "layoutControlItem45";
            this.layoutControlItem45.Location = new Point(0, 0);
            this.layoutControlItem45.MaxSize = new Size(0, 40);
            this.layoutControlItem45.MinSize = new Size(0x18, 40);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new Size(0x101, 40);
            this.layoutControlItem45.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem45.TextSize = new Size(0, 0);
            this.layoutControlItem45.TextVisible = false;
            this.layoutControlItem46.Control = this.dokumagr;
            this.layoutControlItem46.CustomizationFormText = "layoutControlItem46";
            this.layoutControlItem46.Location = new Point(0, 40);
            this.layoutControlItem46.MaxSize = new Size(0, 40);
            this.layoutControlItem46.MinSize = new Size(0x18, 40);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new Size(0x101, 0x43);
            this.layoutControlItem46.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem46.TextSize = new Size(0, 0);
            this.layoutControlItem46.TextVisible = false;
            this.layoutControl1.Controls.Add(this.DurakSayi);
            this.layoutControl1.Controls.Add(this.ToplamYuk);
            this.layoutControl1.Controls.Add(this.simpleButton3);
            this.layoutControl1.Controls.Add(this.simpleButton4);
            this.layoutControl1.Controls.Add(this.IlkDurakNo);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.AgrTamponu);
            this.layoutControl1.Controls.Add(this.KabinTamponu);
            this.layoutControl1.Controls.Add(this.labelControl9);
            this.layoutControl1.Controls.Add(this.AgrRayStr);
            this.layoutControl1.Controls.Add(this.KuyuDer);
            this.layoutControl1.Controls.Add(this.labelControl10);
            this.layoutControl1.Controls.Add(this.KabinRayStr);
            this.layoutControl1.Controls.Add(this.KuyuGen);
            this.layoutControl1.Dock = DockStyle.Fill;
            this.layoutControl1.Location = new Point(2, 0x17);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x169, 0x10c);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.AgrTamponu.EnterMoveNextControl = true;
            this.AgrTamponu.Location = new Point(0x8d, 0x90);
            this.AgrTamponu.Name = "AgrTamponu";
            this.AgrTamponu.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.AgrTamponu.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttons = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.AgrTamponu.Properties.Buttons.AddRange(buttons);
            ImageComboBoxItem[] itemArray3 = new ImageComboBoxItem[] { new ImageComboBoxItem("TEKLİ TAMPON", "YTampon1#AAYTampon1#AAYTampon1", -1), new ImageComboBoxItem("2 Lİ TAMPON", "YTampon2#AAYTampon2#AAYTampon1", -1), new ImageComboBoxItem("4 L\x00dc TAMPON", "YTampon4#AAYTampon2#AAYTampon2", -1), new ImageComboBoxItem("POLİ\x00dcRETAN TAMPON", "KSTampon#KSTampon1#KSTampon1", -1), new ImageComboBoxItem("HİDROİLK TAMPON", "HTampon#HTampon1#HTampon2", -1) };
            this.AgrTamponu.Properties.Items.AddRange(itemArray3);
            this.AgrTamponu.Properties.LargeImages = this.ımageList1;
            this.AgrTamponu.Size = new Size(0xda, 0x22);
            this.AgrTamponu.StyleController = this.layoutControl1;
            this.AgrTamponu.TabIndex = 0x3ee;
            this.ımageList1.ImageStream = (ImageListStreamer) manager.GetObject("ımageList1.ImageStream");
            this.ımageList1.TransparentColor = Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "2pm.png");
            this.ımageList1.Images.SetKeyName(1, "2pt.png");
            this.ımageList1.Images.SetKeyName(2, "3pt.png");
            this.ımageList1.Images.SetKeyName(3, "4pm.png");
            this.ımageList1.Images.SetKeyName(4, "6pm.png");
            this.ımageList1.Images.SetKeyName(5, "cift.png");
            this.ımageList1.Images.SetKeyName(6, "ciftkrm.png");
            this.ımageList1.Images.SetKeyName(7, "ciftoto.png");
            this.ımageList1.Images.SetKeyName(8, "to.png");
            this.ımageList1.Images.SetKeyName(9, "yo.png");
            this.ımageList1.Images.SetKeyName(10, "yokrm.png");
            this.ımageList1.Images.SetKeyName(11, "2Pem.png");
            this.ımageList1.Images.SetKeyName(12, "sol.png");
            this.ımageList1.Images.SetKeyName(13, "mer.png");
            this.ımageList1.Images.SetKeyName(14, "sag.png");
            this.ımageList1.Images.SetKeyName(15, "reg1.png");
            this.ımageList1.Images.SetKeyName(0x10, "reg2.png");
            this.ımageList1.Images.SetKeyName(0x11, "reg3.png");
            this.ımageList1.Images.SetKeyName(0x12, "reg4.png");
            this.KabinTamponu.EnterMoveNextControl = true;
            this.KabinTamponu.Location = new Point(0x8d, 0x6a);
            this.KabinTamponu.Name = "KabinTamponu";
            this.KabinTamponu.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KabinTamponu.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray2 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.KabinTamponu.Properties.Buttons.AddRange(buttonArray2);
            ImageComboBoxItem[] itemArray4 = new ImageComboBoxItem[] { new ImageComboBoxItem("TEKLİ TAMPON", "YTampon1#AAYTampon1#AAYTampon1", -1), new ImageComboBoxItem("2 Lİ TAMPON", "YTampon2#AAYTampon2#AAYTampon1", -1), new ImageComboBoxItem("4 L\x00dc TAMPON", "YTampon4#AAYTampon2#AAYTampon2", -1), new ImageComboBoxItem("POLİ\x00dcRETAN TAMPON", "KSTampon#KSTampon1#KSTampon1", -1), new ImageComboBoxItem("HİDROİLK TAMPON", "HTampon#HTampon1#HTampon2", -1) };
            this.KabinTamponu.Properties.Items.AddRange(itemArray4);
            this.KabinTamponu.Properties.LargeImages = this.ımageList1;
            this.KabinTamponu.Size = new Size(0xda, 0x22);
            this.KabinTamponu.StyleController = this.layoutControl1;
            this.KabinTamponu.TabIndex = 0x3ed;
            this.labelControl9.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl9.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelControl9.Location = new Point(0x142, 0x1c);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new Size(0x25, 14);
            this.labelControl9.StyleController = this.layoutControl1;
            this.labelControl9.TabIndex = 10;
            this.labelControl9.Text = "mm";
            this.AgrRayStr.EnterMoveNextControl = true;
            this.AgrRayStr.Location = new Point(0x8d, 80);
            this.AgrRayStr.Name = "AgrRayStr";
            this.AgrRayStr.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.AgrRayStr.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray3 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.AgrRayStr.Properties.Buttons.AddRange(buttonArray3);
            this.AgrRayStr.Properties.ButtonClick += new ButtonPressedEventHandler(this.agrray_Properties_ButtonClick);
            this.AgrRayStr.Size = new Size(0xda, 0x16);
            this.AgrRayStr.StyleController = this.layoutControl1;
            this.AgrRayStr.TabIndex = 0x43;
            this.KuyuDer.EditValue = "2000";
            this.KuyuDer.EnterMoveNextControl = true;
            this.KuyuDer.Location = new Point(0x8d, 0x1c);
            this.KuyuDer.Name = "KuyuDer";
            this.KuyuDer.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.KuyuDer.Properties.Appearance.Options.UseFont = true;
            this.KuyuDer.Properties.Appearance.Options.UseTextOptions = true;
            this.KuyuDer.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.KuyuDer.Size = new Size(0xb1, 0x16);
            this.KuyuDer.StyleController = this.layoutControl1;
            this.KuyuDer.TabIndex = 5;
            this.labelControl10.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl10.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelControl10.Location = new Point(0x142, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new Size(0x25, 14);
            this.labelControl10.StyleController = this.layoutControl1;
            this.labelControl10.TabIndex = 11;
            this.labelControl10.Text = "mm";
            this.KabinRayStr.EnterMoveNextControl = true;
            this.KabinRayStr.Location = new Point(0x8d, 0x36);
            this.KabinRayStr.Name = "KabinRayStr";
            this.KabinRayStr.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KabinRayStr.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray4 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus) };
            this.KabinRayStr.Properties.Buttons.AddRange(buttonArray4);
            this.KabinRayStr.Properties.ButtonClick += new ButtonPressedEventHandler(this.kabinray_Properties_ButtonClick);
            this.KabinRayStr.Size = new Size(0xda, 0x16);
            this.KabinRayStr.StyleController = this.layoutControl1;
            this.KabinRayStr.TabIndex = 0x42;
            this.KuyuGen.EditValue = "1800";
            this.KuyuGen.EnterMoveNextControl = true;
            this.KuyuGen.Location = new Point(0x8d, 2);
            this.KuyuGen.Name = "KuyuGen";
            this.KuyuGen.Properties.Appearance.Font = new Font("Tahoma", 10f);
            this.KuyuGen.Properties.Appearance.Options.UseFont = true;
            this.KuyuGen.Properties.Appearance.Options.UseTextOptions = true;
            this.KuyuGen.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.KuyuGen.Properties.DisplayFormat.FormatString = "N";
            this.KuyuGen.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.KuyuGen.Properties.EditFormat.FormatString = "N";
            this.KuyuGen.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.KuyuGen.Size = new Size(0xb1, 0x16);
            this.KuyuGen.StyleController = this.layoutControl1;
            this.KuyuGen.TabIndex = 4;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray5 = new BaseLayoutItem[] { this.layoutControlItem111, this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem114, this.layoutControlItem113, this.layoutControlItem115, this.layoutControlItem10, this.layoutControlItem15, this.layoutControlItem16, this.layoutControlItem17, this.layoutControlItem18, this.layoutControlItem19, this.layoutControlItem20, this.layoutControlItem21, this.layoutControlItem23 };
            this.layoutControlGroup1.Items.AddRange(itemArray5);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new Size(0x169, 0x10c);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem111.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem111.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem111.Control = this.KabinRayStr;
            this.layoutControlItem111.Location = new Point(0, 0x34);
            this.layoutControlItem111.Name = "layoutControlItem111";
            this.layoutControlItem111.Size = new Size(0x169, 0x1a);
            this.layoutControlItem111.Text = "KABİN RAYI";
            this.layoutControlItem111.TextSize = new Size(0x88, 0x10);
            this.layoutControlItem1.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.AgrRayStr;
            this.layoutControlItem1.Location = new Point(0, 0x4e);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x169, 0x1a);
            this.layoutControlItem1.Text = "AĞIRLIK RAYI";
            this.layoutControlItem1.TextSize = new Size(0x88, 0x10);
            this.layoutControlItem2.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.KuyuGen;
            this.layoutControlItem2.Location = new Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(320, 0x1a);
            this.layoutControlItem2.Text = "KUYU GENİŞLİĞİ";
            this.layoutControlItem2.TextSize = new Size(0x88, 0x10);
            this.layoutControlItem114.Control = this.labelControl10;
            this.layoutControlItem114.Location = new Point(320, 0);
            this.layoutControlItem114.Name = "layoutControlItem114";
            this.layoutControlItem114.Size = new Size(0x29, 0x1a);
            this.layoutControlItem114.TextSize = new Size(0, 0);
            this.layoutControlItem114.TextVisible = false;
            this.layoutControlItem113.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem113.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem113.Control = this.KuyuDer;
            this.layoutControlItem113.Location = new Point(0, 0x1a);
            this.layoutControlItem113.Name = "layoutControlItem113";
            this.layoutControlItem113.Size = new Size(320, 0x1a);
            this.layoutControlItem113.Text = "KUYU DERİNLİĞİ";
            this.layoutControlItem113.TextSize = new Size(0x88, 0x10);
            this.layoutControlItem115.Control = this.labelControl9;
            this.layoutControlItem115.Location = new Point(320, 0x1a);
            this.layoutControlItem115.Name = "layoutControlItem115";
            this.layoutControlItem115.Size = new Size(0x29, 0x1a);
            this.layoutControlItem115.TextSize = new Size(0, 0);
            this.layoutControlItem115.TextVisible = false;
            this.layoutControlItem10.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.Control = this.KabinTamponu;
            this.layoutControlItem10.Location = new Point(0, 0x68);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new Size(0x169, 0x26);
            this.layoutControlItem10.Text = "KABİN TAMPONU";
            this.layoutControlItem10.TextSize = new Size(0x88, 0x10);
            this.layoutControlItem15.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem15.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem15.Control = this.AgrTamponu;
            this.layoutControlItem15.Location = new Point(0, 0x8e);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new Size(0x169, 0x26);
            this.layoutControlItem15.Text = "AĞIRLIK TAMPONU";
            this.layoutControlItem15.TextSize = new Size(0x88, 0x10);
            this.layoutControl2.Controls.Add(this.labelControl3);
            this.layoutControl2.Controls.Add(this.checkEdit1);
            this.layoutControl2.Controls.Add(this.textEdit2);
            this.layoutControl2.Controls.Add(this.RegYer);
            this.layoutControl2.Controls.Add(this.Mentese);
            this.layoutControl2.Controls.Add(this.KapiGen);
            this.layoutControl2.Controls.Add(this.otokapitipi);
            this.layoutControl2.Controls.Add(this.asnkapitipi);
            this.layoutControl2.Controls.Add(this.labelControl4);
            this.layoutControl2.Controls.Add(this.labelControl13);
            this.layoutControl2.Controls.Add(this.TahCap);
            this.layoutControl2.Controls.Add(this.SapCap);
            this.layoutControl2.Controls.Add(this.labelControl1);
            this.layoutControl2.Dock = DockStyle.Fill;
            this.layoutControl2.Location = new Point(2, 0x17);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new Size(0x174, 0x10c);
            this.layoutControl2.TabIndex = 0x40;
            this.layoutControl2.Text = "layoutControl2";
            this.labelControl3.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl3.Location = new Point(0x149, 0x36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x16, 0x10);
            this.labelControl3.StyleController = this.layoutControl2;
            this.labelControl3.TabIndex = 0x3f1;
            this.labelControl3.Text = "mm";
            this.checkEdit1.Location = new Point(2, 0x36);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "AĞR KASNAĞI";
            this.checkEdit1.Size = new Size(0x83, 0x13);
            this.checkEdit1.StyleController = this.layoutControl2;
            this.checkEdit1.TabIndex = 0x3f0;
            this.textEdit2.EditValue = "400";
            this.textEdit2.Enabled = false;
            this.textEdit2.EnterMoveNextControl = true;
            this.textEdit2.Location = new Point(0x89, 0x36);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit2.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.textEdit2.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.textEdit2.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.textEdit2.Size = new Size(0xbc, 0x16);
            this.textEdit2.StyleController = this.layoutControl2;
            this.textEdit2.TabIndex = 0x3ef;
            this.RegYer.EnterMoveNextControl = true;
            this.RegYer.Location = new Point(0x84, 220);
            this.RegYer.Name = "RegYer";
            this.RegYer.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.RegYer.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray5 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.RegYer.Properties.Buttons.AddRange(buttonArray5);
            ImageComboBoxItem[] itemArray6 = new ImageComboBoxItem[] { new ImageComboBoxItem("SOL ARKA", "2", 0x10), new ImageComboBoxItem("SAĞ ARKA", "3", 0x11), new ImageComboBoxItem("SOL \x00d6N", "1", 15), new ImageComboBoxItem("SAĞ \x00d6N", "4", 0x12) };
            this.RegYer.Properties.Items.AddRange(itemArray6);
            this.RegYer.Properties.LargeImages = this.ımageList1;
            this.RegYer.Size = new Size(0xee, 0x22);
            this.RegYer.StyleController = this.layoutControl2;
            this.RegYer.TabIndex = 0x3ee;
            this.Mentese.EnterMoveNextControl = true;
            this.Mentese.Location = new Point(0x84, 0xb6);
            this.Mentese.Name = "Mentese";
            this.Mentese.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.Mentese.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray6 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.Mentese.Properties.Buttons.AddRange(buttonArray6);
            ImageComboBoxItem[] itemArray7 = new ImageComboBoxItem[] { new ImageComboBoxItem("SOL", "SOL", 12), new ImageComboBoxItem("SAĞ", "SAG", 14), new ImageComboBoxItem("MERKEZİ", "MRK", 13) };
            this.Mentese.Properties.Items.AddRange(itemArray7);
            this.Mentese.Properties.LargeImages = this.ımageList1;
            this.Mentese.Size = new Size(0xee, 0x22);
            this.Mentese.StyleController = this.layoutControl2;
            this.Mentese.TabIndex = 0x3ed;
            this.KapiGen.EditValue = "900";
            this.KapiGen.EnterMoveNextControl = true;
            this.KapiGen.Location = new Point(0x84, 80);
            this.KapiGen.Name = "KapiGen";
            this.KapiGen.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KapiGen.Properties.Appearance.Options.UseFont = true;
            this.KapiGen.Properties.Appearance.Options.UseTextOptions = true;
            this.KapiGen.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.KapiGen.Size = new Size(0xc1, 0x16);
            this.KapiGen.StyleController = this.layoutControl2;
            this.KapiGen.TabIndex = 0x3eb;
            this.otokapitipi.EnterMoveNextControl = true;
            this.otokapitipi.Location = new Point(0x84, 0x90);
            this.otokapitipi.Name = "otokapitipi";
            this.otokapitipi.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.otokapitipi.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray7 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.otokapitipi.Properties.Buttons.AddRange(buttonArray7);
            ImageComboBoxItem[] itemArray8 = new ImageComboBoxItem[] { new ImageComboBoxItem("2P TELESKOPİK", "2TEL", 1), new ImageComboBoxItem("3P TELESKOPİK", "3TEL", 2), new ImageComboBoxItem("2P MERKEZİ", "2MER", 0), new ImageComboBoxItem("4P MERKEZİ", "4MER", 11), new ImageComboBoxItem("6P MERKEZİ", "6MER", 4), new ImageComboBoxItem("KRAMER", "KRMK", 10), new ImageComboBoxItem("İ\x00c7 KAPISIZ", "KPYK", 5) };
            this.otokapitipi.Properties.Items.AddRange(itemArray8);
            this.otokapitipi.Properties.LargeImages = this.ımageList1;
            this.otokapitipi.Size = new Size(0xee, 0x22);
            this.otokapitipi.StyleController = this.layoutControl2;
            this.otokapitipi.TabIndex = 0x3ec;
            this.asnkapitipi.EnterMoveNextControl = true;
            this.asnkapitipi.Location = new Point(0x84, 0x6a);
            this.asnkapitipi.Name = "asnkapitipi";
            this.asnkapitipi.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.asnkapitipi.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttonArray8 = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.asnkapitipi.Properties.Buttons.AddRange(buttonArray8);
            ImageComboBoxItem[] itemArray9 = new ImageComboBoxItem[] { new ImageComboBoxItem("TAM OTOMATİK", "TO", 8), new ImageComboBoxItem("YARIM OTOMATİK", "YO", 9), new ImageComboBoxItem("Y.O. KRAMER KAPILI", "YK", 10), new ImageComboBoxItem("İ\x00c7 OTO DIŞ \x00c7İFT KAN", "CK", 7), new ImageComboBoxItem("İ\x00c7 KRAM DIŞ \x00c7İFT KAN", "CK", 6), new ImageComboBoxItem("\x00c7İFT KANAT \x00c7ARPMA", "CK", 5) };
            this.asnkapitipi.Properties.Items.AddRange(itemArray9);
            this.asnkapitipi.Properties.LargeImages = this.ımageList1;
            this.asnkapitipi.Size = new Size(0xee, 0x22);
            this.asnkapitipi.StyleController = this.layoutControl2;
            this.asnkapitipi.TabIndex = 0x3eb;
            this.labelControl4.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl4.Location = new Point(0x149, 0x1c);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x29, 0x10);
            this.labelControl4.StyleController = this.layoutControl2;
            this.labelControl4.TabIndex = 0x3e8;
            this.labelControl4.Text = "mm";
            this.labelControl13.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl13.Location = new Point(0x149, 2);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new Size(0x29, 0x10);
            this.labelControl13.StyleController = this.layoutControl2;
            this.labelControl13.TabIndex = 0x3e9;
            this.labelControl13.Text = "mm";
            this.TahCap.EditValue = "450";
            this.TahCap.EnterMoveNextControl = true;
            this.TahCap.Location = new Point(0x84, 2);
            this.TahCap.Name = "TahCap";
            this.TahCap.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.TahCap.Properties.Appearance.Options.UseFont = true;
            this.TahCap.Properties.Appearance.Options.UseTextOptions = true;
            this.TahCap.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.TahCap.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.TahCap.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.TahCap.Size = new Size(0xc1, 0x16);
            this.TahCap.StyleController = this.layoutControl2;
            this.TahCap.TabIndex = 7;
            this.SapCap.EditValue = "400";
            this.SapCap.EnterMoveNextControl = true;
            this.SapCap.Location = new Point(0x84, 0x1c);
            this.SapCap.Name = "SapCap";
            this.SapCap.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.SapCap.Properties.Appearance.Options.UseFont = true;
            this.SapCap.Properties.Appearance.Options.UseTextOptions = true;
            this.SapCap.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.SapCap.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.SapCap.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.SapCap.Size = new Size(0xc1, 0x16);
            this.SapCap.StyleController = this.layoutControl2;
            this.SapCap.TabIndex = 8;
            this.labelControl1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl1.Location = new Point(0x149, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x29, 0x10);
            this.labelControl1.StyleController = this.layoutControl2;
            this.labelControl1.TabIndex = 0x3e8;
            this.labelControl1.Text = "mm";
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray10 = new BaseLayoutItem[] { this.layoutControlItem11, this.layoutControlItem22, this.layoutControlItem27, this.layoutControlItem28, this.layoutControlItem4, this.layoutControlItem3, this.layoutControlItem9, this.layoutControlItem8, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem12, this.layoutControlItem13, this.layoutControlItem14 };
            this.layoutControlGroup2.Items.AddRange(itemArray10);
            this.layoutControlGroup2.Location = new Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new Size(0x174, 0x10c);
            this.layoutControlGroup2.TextVisible = false;
            this.layoutControlItem11.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem11.Control = this.TahCap;
            this.layoutControlItem11.CustomizationFormText = "MAK. KASNAK \x00c7API";
            this.layoutControlItem11.Location = new Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new Size(0x147, 0x1a);
            this.layoutControlItem11.Text = "MAK. KASNAK \x00c7API";
            this.layoutControlItem11.TextSize = new Size(0x7f, 0x10);
            this.layoutControlItem22.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem22.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem22.Control = this.SapCap;
            this.layoutControlItem22.CustomizationFormText = "SAP. KASNAK \x00c7API";
            this.layoutControlItem22.Location = new Point(0, 0x1a);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new Size(0x147, 0x1a);
            this.layoutControlItem22.Text = "SAP. KASNAK \x00c7API";
            this.layoutControlItem22.TextSize = new Size(0x7f, 0x10);
            this.layoutControlItem27.Control = this.labelControl13;
            this.layoutControlItem27.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem27.Location = new Point(0x147, 0);
            this.layoutControlItem27.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem27.MinSize = new Size(0x2d, 20);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem27.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem27.TextSize = new Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            this.layoutControlItem28.Control = this.labelControl4;
            this.layoutControlItem28.CustomizationFormText = "layoutControlItem28";
            this.layoutControlItem28.Location = new Point(0x147, 0x1a);
            this.layoutControlItem28.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem28.MinSize = new Size(0x2d, 20);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem28.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem28.TextSize = new Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            this.layoutControlItem4.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.otokapitipi;
            this.layoutControlItem4.Location = new Point(0, 0x8e);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0x174, 0x26);
            this.layoutControlItem4.Text = "OTO KAPI TİPİ";
            this.layoutControlItem4.TextSize = new Size(0x7f, 0x10);
            this.layoutControlItem3.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.asnkapitipi;
            this.layoutControlItem3.Location = new Point(0, 0x68);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x174, 0x26);
            this.layoutControlItem3.Text = "ASANS\x00d6R KAPI TİPİ";
            this.layoutControlItem3.TextSize = new Size(0x7f, 0x10);
            this.layoutControlItem9.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.Control = this.Mentese;
            this.layoutControlItem9.Location = new Point(0, 180);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new Size(0x174, 0x26);
            this.layoutControlItem9.Text = "A\x00c7ILMA Y\x00d6N\x00dc";
            this.layoutControlItem9.TextSize = new Size(0x7f, 0x10);
            this.layoutControlItem8.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.KapiGen;
            this.layoutControlItem8.Location = new Point(0, 0x4e);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new Size(0x147, 0x1a);
            this.layoutControlItem8.Text = "KAPI GENİŞLİĞİ";
            this.layoutControlItem8.TextSize = new Size(0x7f, 0x10);
            this.layoutControlItem6.Control = this.labelControl1;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem28";
            this.layoutControlItem6.Location = new Point(0x147, 0x4e);
            this.layoutControlItem6.MaxSize = new Size(0x2d, 20);
            this.layoutControlItem6.MinSize = new Size(0x2d, 20);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem6.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem28";
            this.layoutControlItem6.TextSize = new Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.layoutControlItem7.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.RegYer;
            this.layoutControlItem7.Location = new Point(0, 0xda);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x174, 50);
            this.layoutControlItem7.Text = "REG\x00dcLAT\x00d6R YERİ";
            this.layoutControlItem7.TextSize = new Size(0x7f, 0x10);
            this.layoutControlItem12.Control = this.textEdit2;
            this.layoutControlItem12.Location = new Point(0x87, 0x34);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new Size(0xc0, 0x1a);
            this.layoutControlItem12.Text = "Agırlık \x00dcst\x00fc Kasnak";
            this.layoutControlItem12.TextSize = new Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            this.layoutControlItem13.Control = this.checkEdit1;
            this.layoutControlItem13.Location = new Point(0, 0x34);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new Size(0x87, 0x1a);
            this.layoutControlItem13.TextSize = new Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            this.layoutControlItem14.Control = this.labelControl3;
            this.layoutControlItem14.Location = new Point(0x147, 0x34);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new Size(0x2d, 0x1a);
            this.layoutControlItem14.TextSize = new Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            this.groupControl6.AppearanceCaption.Font = new Font("Tahoma", 10f, FontStyle.Bold);
            this.groupControl6.AppearanceCaption.ForeColor = Color.FromArgb(0xc0, 0, 0);
            this.groupControl6.AppearanceCaption.Options.UseFont = true;
            this.groupControl6.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl6.Controls.Add(this.layoutControl1);
            this.groupControl6.Location = new Point(250, 3);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new Size(0x16d, 0x125);
            this.groupControl6.TabIndex = 20;
            this.groupControl6.Text = "KUYU VE RAY BİLGİLERİ";
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0xf3, 440);
            this.panel1.TabIndex = 0x3ea;
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            this.panel2.Location = new Point(2, 0x3d);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0xf6, 0x160);
            this.panel2.TabIndex = 0x3ea;
            this.panel2.Visible = false;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel5.Controls.Add(this.HAMDControl, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.ha11, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.ha21, 0, 1);
            this.tableLayoutPanel5.Dock = DockStyle.Fill;
            this.tableLayoutPanel5.Location = new Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            this.tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            this.tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            this.tableLayoutPanel5.Size = new Size(0xf6, 0x160);
            this.tableLayoutPanel5.TabIndex = 0;
            this.HAMDControl.AppearanceCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.HAMDControl.AppearanceCaption.Options.UseFont = true;
            this.HAMDControl.Controls.Add(this.layoutControl8);
            this.HAMDControl.Dock = DockStyle.Fill;
            this.HAMDControl.Location = new Point(3, 0xed);
            this.HAMDControl.Name = "HAMDControl";
            this.HAMDControl.Size = new Size(240, 0x70);
            this.HAMDControl.TabIndex = 20;
            this.HAMDControl.Text = "HİDROLİK MAKİNE DAİRESİ";
            this.layoutControl8.Controls.Add(this.txtHAMDDer);
            this.layoutControl8.Controls.Add(this.radioHMSOL);
            this.layoutControl8.Controls.Add(this.txtHAMDGen);
            this.layoutControl8.Controls.Add(this.radioHMSAG);
            this.layoutControl8.Dock = DockStyle.Fill;
            this.layoutControl8.Location = new Point(2, 0x17);
            this.layoutControl8.Name = "layoutControl8";
            this.layoutControl8.Root = this.layoutControlGroup8;
            this.layoutControl8.Size = new Size(0xec, 0x57);
            this.layoutControl8.TabIndex = 0;
            this.layoutControl8.Text = "layoutControl8";
            this.txtHAMDDer.EditValue = "3000";
            this.txtHAMDDer.EnterMoveNextControl = true;
            this.txtHAMDDer.Location = new Point(0x8d, 0x59);
            this.txtHAMDDer.Name = "txtHAMDDer";
            this.txtHAMDDer.Size = new Size(0x47, 20);
            this.txtHAMDDer.StyleController = this.layoutControl8;
            this.txtHAMDDer.TabIndex = 0x13;
            this.radioHMSOL.Location = new Point(7, 0x24);
            this.radioHMSOL.Name = "radioHMSOL";
            this.radioHMSOL.Size = new Size(0xcd, 0x19);
            this.radioHMSOL.TabIndex = 0x11;
            this.radioHMSOL.TabStop = true;
            this.radioHMSOL.Text = "SOL";
            this.radioHMSOL.UseVisualStyleBackColor = true;
            this.txtHAMDGen.EditValue = "3000";
            this.txtHAMDGen.EnterMoveNextControl = true;
            this.txtHAMDGen.Location = new Point(0x8d, 0x41);
            this.txtHAMDGen.Name = "txtHAMDGen";
            this.txtHAMDGen.Size = new Size(0x47, 20);
            this.txtHAMDGen.StyleController = this.layoutControl8;
            this.txtHAMDGen.TabIndex = 0x12;
            this.radioHMSAG.Location = new Point(7, 7);
            this.radioHMSAG.Name = "radioHMSAG";
            this.radioHMSAG.Size = new Size(0xcd, 0x19);
            this.radioHMSAG.TabIndex = 0x10;
            this.radioHMSAG.TabStop = true;
            this.radioHMSAG.Text = "SAĞ";
            this.radioHMSAG.UseVisualStyleBackColor = true;
            this.layoutControlGroup8.CustomizationFormText = "layoutControlGroup6";
            this.layoutControlGroup8.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup8.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray11 = new BaseLayoutItem[] { this.layoutControlItem62, this.layoutControlItem64, this.layoutControlItem65, this.layoutControlItem66 };
            this.layoutControlGroup8.Items.AddRange(itemArray11);
            this.layoutControlGroup8.Location = new Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup6";
            this.layoutControlGroup8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup8.Size = new Size(0xdb, 0x74);
            this.layoutControlGroup8.TextVisible = false;
            this.layoutControlItem62.Control = this.radioHMSAG;
            this.layoutControlItem62.CustomizationFormText = "layoutControlItem62";
            this.layoutControlItem62.Location = new Point(0, 0);
            this.layoutControlItem62.Name = "layoutControlItem62";
            this.layoutControlItem62.Size = new Size(0xd1, 0x1d);
            this.layoutControlItem62.TextSize = new Size(0, 0);
            this.layoutControlItem62.TextVisible = false;
            this.layoutControlItem64.Control = this.radioHMSOL;
            this.layoutControlItem64.CustomizationFormText = "layoutControlItem64";
            this.layoutControlItem64.Location = new Point(0, 0x1d);
            this.layoutControlItem64.Name = "layoutControlItem64";
            this.layoutControlItem64.Size = new Size(0xd1, 0x1d);
            this.layoutControlItem64.TextSize = new Size(0, 0);
            this.layoutControlItem64.TextVisible = false;
            this.layoutControlItem65.Control = this.txtHAMDGen;
            this.layoutControlItem65.CustomizationFormText = "MAKİNE DAİRESİ GENİŞLİK";
            this.layoutControlItem65.Location = new Point(0, 0x3a);
            this.layoutControlItem65.Name = "layoutControlItem65";
            this.layoutControlItem65.Size = new Size(0xd1, 0x18);
            this.layoutControlItem65.Text = "MAKİNE DAİRESİ GENİŞLİK";
            this.layoutControlItem65.TextSize = new Size(0x83, 13);
            this.layoutControlItem66.Control = this.txtHAMDDer;
            this.layoutControlItem66.CustomizationFormText = "MAKİNE DAİRESİ DERİNLİK";
            this.layoutControlItem66.Location = new Point(0, 0x52);
            this.layoutControlItem66.Name = "layoutControlItem66";
            this.layoutControlItem66.Size = new Size(0xd1, 0x18);
            this.layoutControlItem66.Text = "MAKİNE DAİRESİ DERİNLİK";
            this.layoutControlItem66.TextSize = new Size(0x83, 13);
            this.ha11.AccessibleDescription = "maksiz2";
            this.ha11.Dock = DockStyle.Fill;
            this.ha11.FlatAppearance.BorderColor = Color.CadetBlue;
            this.ha11.FlatAppearance.BorderSize = 2;
            this.ha11.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.ha11.Image = (Image) manager.GetObject("ha11.Image");
            this.ha11.ImageAlign = ContentAlignment.MiddleLeft;
            this.ha11.Location = new Point(3, 3);
            this.ha11.Name = "ha11";
            this.ha11.Size = new Size(240, 0x6f);
            this.ha11.TabIndex = 3;
            this.ha11.Text = "2/1 DİREK TAHRİK";
            this.ha11.TextAlign = ContentAlignment.BottomCenter;
            this.ha11.TextImageRelation = TextImageRelation.ImageAboveText;
            this.ha11.UseVisualStyleBackColor = true;
            this.ha11.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.ha21.AccessibleDescription = "maksiz2";
            this.ha21.Checked = true;
            this.ha21.Dock = DockStyle.Fill;
            this.ha21.FlatAppearance.BorderColor = Color.CadetBlue;
            this.ha21.FlatAppearance.BorderSize = 2;
            this.ha21.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.ha21.Image = (Image) manager.GetObject("ha21.Image");
            this.ha21.ImageAlign = ContentAlignment.MiddleLeft;
            this.ha21.Location = new Point(3, 120);
            this.ha21.Name = "ha21";
            this.ha21.Size = new Size(240, 0x6f);
            this.ha21.TabIndex = 15;
            this.ha21.TabStop = true;
            this.ha21.Text = "\x00c7APRAZ PİSTON Y\x00dcK";
            this.ha21.TextAlign = ContentAlignment.BottomCenter;
            this.ha21.TextImageRelation = TextImageRelation.ImageAboveText;
            this.ha21.UseVisualStyleBackColor = true;
            this.ha21.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.layoutControl4.Controls.Add(this.IskeleVar);
            this.layoutControl4.Controls.Add(this.DengeZinciri);
            this.layoutControl4.Controls.Add(this.SeyirMesafesi);
            this.layoutControl4.Controls.Add(this.pictureBox2);
            this.layoutControl4.Controls.Add(this.gridControl1);
            this.layoutControl4.Controls.Add(this.MdTabTavan);
            this.layoutControl4.Controls.Add(this.SonKat);
            this.layoutControl4.Controls.Add(this.AraKatSTR);
            this.layoutControl4.Controls.Add(this.TopKuyuKafa);
            this.layoutControl4.Controls.Add(this.KuyuDibi);
            this.layoutControl4.Controls.Add(this.KatH);
            this.layoutControl4.Location = new Point(3, 5);
            this.layoutControl4.Name = "layoutControl4";
            this.layoutControl4.Root = this.layoutControlGroup4;
            this.layoutControl4.Size = new Size(0x3dc, 0x1be);
            this.layoutControl4.TabIndex = 4;
            this.layoutControl4.Text = "layoutControl4";
            this.IskeleVar.Location = new Point(7, 0xd3);
            this.IskeleVar.Name = "IskeleVar";
            this.IskeleVar.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.IskeleVar.Properties.Appearance.Options.UseFont = true;
            this.IskeleVar.Properties.Caption = "İskele KullanımıX";
            this.IskeleVar.Size = new Size(0x161, 20);
            this.IskeleVar.StyleController = this.layoutControl4;
            this.IskeleVar.TabIndex = 0x3ec;
            this.DengeZinciri.Location = new Point(7, 0xbb);
            this.DengeZinciri.Name = "DengeZinciri";
            this.DengeZinciri.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.DengeZinciri.Properties.Appearance.Options.UseFont = true;
            this.DengeZinciri.Properties.Caption = "Denge Zinciri";
            this.DengeZinciri.Size = new Size(0x161, 20);
            this.DengeZinciri.StyleController = this.layoutControl4;
            this.DengeZinciri.TabIndex = 0x3eb;
            this.ToplamYuk.Location = new Point(0x8d, 0xec);
            this.ToplamYuk.Name = "ToplamYuk";
            this.ToplamYuk.Properties.Appearance.BackColor = SystemColors.Control;
            this.ToplamYuk.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.ToplamYuk.Properties.Appearance.Options.UseBackColor = true;
            this.ToplamYuk.Properties.Appearance.Options.UseFont = true;
            this.ToplamYuk.Properties.BorderStyle = BorderStyles.NoBorder;
            this.ToplamYuk.Size = new Size(0xda, 20);
            this.ToplamYuk.StyleController = this.layoutControl1;
            this.ToplamYuk.TabIndex = 0x3ea;
            this.SeyirMesafesi.Location = new Point(0xdb, 0x89);
            this.SeyirMesafesi.Name = "SeyirMesafesi";
            this.SeyirMesafesi.Properties.Appearance.BackColor = SystemColors.Control;
            this.SeyirMesafesi.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.SeyirMesafesi.Properties.Appearance.Options.UseBackColor = true;
            this.SeyirMesafesi.Properties.Appearance.Options.UseFont = true;
            this.SeyirMesafesi.Properties.BorderStyle = BorderStyles.NoBorder;
            this.SeyirMesafesi.Size = new Size(0x8d, 20);
            this.SeyirMesafesi.StyleController = this.layoutControl4;
            this.SeyirMesafesi.TabIndex = 14;
            this.pictureBox2.Image = (Image) manager.GetObject("pictureBox2.Image");
            this.pictureBox2.Location = new Point(0x2e5, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(240, 0x1b0);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.simpleButton4.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new Point(0xdf, 0xd1);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new Size(0x40, 0x17);
            this.simpleButton4.StyleController = this.layoutControl1;
            this.simpleButton4.TabIndex = 12;
            this.simpleButton4.Text = "   -   ";
            this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
            this.simpleButton3.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new Point(0x123, 0xd1);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(0x44, 0x17);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 12;
            this.simpleButton3.Text = "   +   ";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.gridControl1.Location = new Point(0x16c, 7);
            this.gridControl1.MainView = this.gridView4;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(0x175, 0x1b0);
            this.gridControl1.TabIndex = 4;
            BaseView[] views = new BaseView[] { this.gridView4 };
            this.gridControl1.ViewCollection.AddRange(views);
            this.gridView4.Appearance.ColumnFilterButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView4.Appearance.ColumnFilterButtonActive.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gridView4.Appearance.CustomizationFormHint.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gridView4.Appearance.DetailTip.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.DetailTip.Options.UseFont = true;
            this.gridView4.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.Empty.Options.UseFont = true;
            this.gridView4.Appearance.EvenRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.EvenRow.Options.UseFont = true;
            this.gridView4.Appearance.FilterCloseButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView4.Appearance.FilterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView4.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.FixedLine.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView4.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView4.Appearance.FooterPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView4.Appearance.GroupButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.GroupButton.Options.UseFont = true;
            this.gridView4.Appearance.GroupFooter.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView4.Appearance.GroupPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView4.Appearance.GroupRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.GroupRow.Options.UseFont = true;
            this.gridView4.Appearance.HeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView4.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.HorzLine.Options.UseFont = true;
            this.gridView4.Appearance.OddRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.OddRow.Options.UseFont = true;
            this.gridView4.Appearance.Preview.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.Preview.Options.UseFont = true;
            this.gridView4.Appearance.Row.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.Appearance.RowSeparator.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView4.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView4.Appearance.TopNewRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView4.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.VertLine.Options.UseFont = true;
            this.gridView4.Appearance.ViewCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.gridView4.Appearance.ViewCaption.Options.UseFont = true;
            GridColumn[] columns = new GridColumn[] { this.gridColumn10, this.gridColumn11, this.gridColumn12, this.gridColumn13 };
            this.gridView4.Columns.AddRange(columns);
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsCustomization.AllowGroup = false;
            this.gridView4.OptionsView.ShowFooter = true;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView4_CellValueChanged);
            this.gridColumn10.Caption = "KATNO";
            this.gridColumn10.FieldName = "ktno";
            this.gridColumn10.MaxWidth = 100;
            this.gridColumn10.MinWidth = 0x37;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 0x37;
            this.gridColumn11.Caption = "KatAdı";
            this.gridColumn11.FieldName = "krumz";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 0x3f;
            this.gridColumn12.Caption = "KatH";
            this.gridColumn12.FieldName = "kath";
            this.gridColumn12.MaxWidth = 70;
            this.gridColumn12.MinWidth = 50;
            this.gridColumn12.Name = "gridColumn12";
            GridSummaryItem[] itemArray12 = new GridSummaryItem[] { new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "kath", "{0:0.##}") };
            this.gridColumn12.Summary.AddRange(itemArray12);
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 50;
            this.gridColumn13.Caption = "Mimari Kot";
            this.gridColumn13.FieldName = "mimkot";
            this.gridColumn13.MaxWidth = 90;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            this.gridColumn13.Width = 70;
            this.simpleButton2.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new Point(0xdf, 0xb6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x40, 0x17);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 11;
            this.simpleButton2.Text = "   -   ";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new Point(0x123, 0xb6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x44, 0x17);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "   +   ";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.MdTabTavan.EditValue = "2100";
            this.MdTabTavan.EnterMoveNextControl = true;
            this.MdTabTavan.Location = new Point(0xdb, 0x3b);
            this.MdTabTavan.Name = "MdTabTavan";
            this.MdTabTavan.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.MdTabTavan.Properties.Appearance.Options.UseFont = true;
            this.MdTabTavan.Size = new Size(0x8d, 0x16);
            this.MdTabTavan.StyleController = this.layoutControl4;
            this.MdTabTavan.TabIndex = 7;
            this.SonKat.EditValue = "3000";
            this.SonKat.Enabled = false;
            this.SonKat.EnterMoveNextControl = true;
            this.SonKat.Location = new Point(0xdb, 0x21);
            this.SonKat.Name = "SonKat";
            this.SonKat.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.SonKat.Properties.Appearance.Options.UseFont = true;
            this.SonKat.Properties.DisplayFormat.FormatString = "n";
            this.SonKat.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.SonKat.Size = new Size(0x8d, 0x16);
            this.SonKat.StyleController = this.layoutControl4;
            this.SonKat.TabIndex = 6;
            this.AraKatSTR.EnterMoveNextControl = true;
            this.AraKatSTR.Location = new Point(0xdb, 0xa1);
            this.AraKatSTR.Name = "AraKatSTR";
            this.AraKatSTR.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.AraKatSTR.Properties.Appearance.Options.UseFont = true;
            this.AraKatSTR.Size = new Size(0x8d, 0x16);
            this.AraKatSTR.StyleController = this.layoutControl4;
            this.AraKatSTR.TabIndex = 9;
            this.TopKuyuKafa.EditValue = "3800";
            this.TopKuyuKafa.Enabled = false;
            this.TopKuyuKafa.EnterMoveNextControl = true;
            this.TopKuyuKafa.Location = new Point(0xdb, 0x55);
            this.TopKuyuKafa.Name = "TopKuyuKafa";
            this.TopKuyuKafa.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.TopKuyuKafa.Properties.Appearance.Options.UseFont = true;
            this.TopKuyuKafa.Size = new Size(0x8d, 0x16);
            this.TopKuyuKafa.StyleController = this.layoutControl4;
            this.TopKuyuKafa.TabIndex = 5;
            this.KuyuDibi.EditValue = "1500";
            this.KuyuDibi.EnterMoveNextControl = true;
            this.KuyuDibi.Location = new Point(0xdb, 0x6f);
            this.KuyuDibi.Name = "KuyuDibi";
            this.KuyuDibi.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KuyuDibi.Properties.Appearance.Options.UseFont = true;
            this.KuyuDibi.Size = new Size(0x8d, 0x16);
            this.KuyuDibi.StyleController = this.layoutControl4;
            this.KuyuDibi.TabIndex = 4;
            this.DurakSayi.EditValue = "1";
            this.DurakSayi.Enabled = false;
            this.DurakSayi.EnterMoveNextControl = true;
            this.DurakSayi.Location = new Point(0x8d, 0xb6);
            this.DurakSayi.Name = "DurakSayi";
            this.DurakSayi.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.DurakSayi.Properties.Appearance.Options.UseFont = true;
            this.DurakSayi.Properties.Appearance.Options.UseTextOptions = true;
            this.DurakSayi.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.DurakSayi.Size = new Size(0x4e, 0x16);
            this.DurakSayi.StyleController = this.layoutControl1;
            this.DurakSayi.TabIndex = 0;
            this.KatH.EditValue = "3000";
            this.KatH.Enabled = false;
            this.KatH.EnterMoveNextControl = true;
            this.KatH.Location = new Point(0xdb, 7);
            this.KatH.Name = "KatH";
            this.KatH.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.KatH.Properties.Appearance.Options.UseFont = true;
            this.KatH.Size = new Size(0x8d, 0x16);
            this.KatH.StyleController = this.layoutControl4;
            this.KatH.TabIndex = 2;
            this.IlkDurakNo.EditValue = "0";
            this.IlkDurakNo.Enabled = false;
            this.IlkDurakNo.EnterMoveNextControl = true;
            this.IlkDurakNo.Location = new Point(0x8d, 0xd1);
            this.IlkDurakNo.Name = "IlkDurakNo";
            this.IlkDurakNo.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.IlkDurakNo.Properties.Appearance.Options.UseFont = true;
            this.IlkDurakNo.Properties.Appearance.Options.UseTextOptions = true;
            this.IlkDurakNo.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.IlkDurakNo.Size = new Size(0x4e, 0x16);
            this.IlkDurakNo.StyleController = this.layoutControl1;
            this.IlkDurakNo.TabIndex = 1;
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
            this.layoutControlGroup4.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup4.GroupBordersVisible = false;
            BaseLayoutItem[] itemArray13 = new BaseLayoutItem[] { this.layoutControlItem36, this.layoutControlItem37, this.layoutControlItem38, this.layoutControlItem42, this.layoutControlItem43, this.layoutControlItem44, this.layoutControlItem68, this.layoutControlItem82, this.layoutControlItem125, this.layoutControlItem40, this.layoutControlItem41 };
            this.layoutControlGroup4.Items.AddRange(itemArray13);
            this.layoutControlGroup4.Location = new Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup4.Size = new Size(0x3dc, 0x1be);
            this.layoutControlGroup4.TextVisible = false;
            this.layoutControlItem36.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem36.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem36.Control = this.KatH;
            this.layoutControlItem36.CustomizationFormText = "ORT. KAT Y\x00dcK";
            this.layoutControlItem36.Location = new Point(0, 0);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new Size(0x165, 0x1a);
            this.layoutControlItem36.Text = "ORT. KAT Y\x00dcK - d";
            this.layoutControlItem36.TextSize = new Size(0xd1, 0x10);
            this.layoutControlItem37.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem37.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem37.Control = this.KuyuDibi;
            this.layoutControlItem37.CustomizationFormText = "KUYU DİBİ ";
            this.layoutControlItem37.Location = new Point(0, 0x68);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new Size(0x165, 0x1a);
            this.layoutControlItem37.Text = "KUYU DİBİ - a";
            this.layoutControlItem37.TextSize = new Size(0xd1, 0x10);
            this.layoutControlItem38.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem38.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem38.Control = this.TopKuyuKafa;
            this.layoutControlItem38.CustomizationFormText = "KUYU KAFASI";
            this.layoutControlItem38.Location = new Point(0, 0x4e);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new Size(0x165, 0x1a);
            this.layoutControlItem38.Text = "SON KAT ZEMİN-KUYU TAVANI - c";
            this.layoutControlItem38.TextSize = new Size(0xd1, 0x10);
            this.layoutControlItem42.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem42.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem42.Control = this.AraKatSTR;
            this.layoutControlItem42.CustomizationFormText = "ARAKATLAR YAZISI";
            this.layoutControlItem42.Location = new Point(0, 0x9a);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new Size(0x165, 0x1a);
            this.layoutControlItem42.Text = "ARAKATLAR YAZISI";
            this.layoutControlItem42.TextSize = new Size(0xd1, 0x10);
            this.layoutControlItem43.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem43.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem43.Control = this.SonKat;
            this.layoutControlItem43.CustomizationFormText = "SON KAT Y\x00dcK";
            this.layoutControlItem43.Location = new Point(0, 0x1a);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new Size(0x165, 0x1a);
            this.layoutControlItem43.Text = "SON KAT Y\x00dcK - b";
            this.layoutControlItem43.TextSize = new Size(0xd1, 0x10);
            this.layoutControlItem44.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem44.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem44.Control = this.MdTabTavan;
            this.layoutControlItem44.CustomizationFormText = "MAKİNE DAİRESİ \x00c7ALIŞMA Y\x00dcKSEKLİĞİ";
            this.layoutControlItem44.Location = new Point(0, 0x34);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new Size(0x165, 0x1a);
            this.layoutControlItem44.Text = "\x00c7ALIŞMA Y\x00dcKSEKLİĞİ - e";
            this.layoutControlItem44.TextSize = new Size(0xd1, 0x10);
            this.layoutControlItem68.Control = this.gridControl1;
            this.layoutControlItem68.CustomizationFormText = "layoutControlItem39";
            this.layoutControlItem68.Location = new Point(0x165, 0);
            this.layoutControlItem68.Name = "layoutControlItem39";
            this.layoutControlItem68.Size = new Size(0x179, 0x1b4);
            this.layoutControlItem68.TextSize = new Size(0, 0);
            this.layoutControlItem68.TextVisible = false;
            this.layoutControlItem82.Control = this.pictureBox2;
            this.layoutControlItem82.Location = new Point(0x2de, 0);
            this.layoutControlItem82.Name = "layoutControlItem82";
            this.layoutControlItem82.Size = new Size(0xf4, 0x1b4);
            this.layoutControlItem82.TextSize = new Size(0, 0);
            this.layoutControlItem82.TextVisible = false;
            this.layoutControlItem125.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem125.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem125.Control = this.SeyirMesafesi;
            this.layoutControlItem125.Location = new Point(0, 130);
            this.layoutControlItem125.Name = "layoutControlItem125";
            this.layoutControlItem125.Size = new Size(0x165, 0x18);
            this.layoutControlItem125.Text = "SEYİR MESAFESİ :";
            this.layoutControlItem125.TextSize = new Size(0xd1, 0x10);
            this.layoutControlItem40.Control = this.DengeZinciri;
            this.layoutControlItem40.Location = new Point(0, 180);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new Size(0x165, 0x18);
            this.layoutControlItem40.TextSize = new Size(0, 0);
            this.layoutControlItem40.TextVisible = false;
            this.layoutControlItem41.Control = this.IskeleVar;
            this.layoutControlItem41.Location = new Point(0, 0xcc);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new Size(0x165, 0xe8);
            this.layoutControlItem41.TextSize = new Size(0, 0);
            this.layoutControlItem41.TextVisible = false;
            this.BesPanoVar.Location = new Point(0x153, 0xc0);
            this.BesPanoVar.Name = "BesPanoVar";
            this.BesPanoVar.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.BesPanoVar.Properties.Appearance.Options.UseFont = true;
            this.BesPanoVar.Properties.Caption = "Besleme Panosu FİRMAMIZ Sorumluluğunda";
            this.BesPanoVar.Size = new Size(0x115, 20);
            this.BesPanoVar.TabIndex = 11;
            this.AydinlatmaBizde.Location = new Point(0x153, 0xa6);
            this.AydinlatmaBizde.Name = "AydinlatmaBizde";
            this.AydinlatmaBizde.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.AydinlatmaBizde.Properties.Appearance.Options.UseFont = true;
            this.AydinlatmaBizde.Properties.Caption = "Aydınlatma FİRMAMIZ Sorumluluğunda";
            this.AydinlatmaBizde.Size = new Size(0x115, 20);
            this.AydinlatmaBizde.TabIndex = 10;
            this.groupControl1.AppearanceCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.groupControl1.AppearanceCaption.ForeColor = Color.FromArgb(0xc0, 0x40, 0);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.layoutControl5);
            this.groupControl1.Location = new Point(0x151, 15);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x10f, 0x8e);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "AĞIRLIK TİPİ";
            this.firmabilgigrid.Appearance.BandBorder.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.BandBorder.Options.UseFont = true;
            this.firmabilgigrid.Appearance.Category.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.Category.Options.UseFont = true;
            this.firmabilgigrid.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.firmabilgigrid.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.firmabilgigrid.Appearance.DisabledRow.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.DisabledRow.Options.UseFont = true;
            this.firmabilgigrid.Appearance.Empty.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.Empty.Options.UseFont = true;
            this.firmabilgigrid.Appearance.ExpandButton.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.ExpandButton.Options.UseFont = true;
            this.firmabilgigrid.Appearance.FixedLine.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.FixedLine.Options.UseFont = true;
            this.firmabilgigrid.Appearance.FocusedCell.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.FocusedCell.Options.UseFont = true;
            this.firmabilgigrid.Appearance.FocusedRecord.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.FocusedRecord.Options.UseFont = true;
            this.firmabilgigrid.Appearance.FocusedRow.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.FocusedRow.Options.UseFont = true;
            this.firmabilgigrid.Appearance.HideSelectionRow.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.firmabilgigrid.Appearance.HorzLine.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.HorzLine.Options.UseFont = true;
            this.firmabilgigrid.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.firmabilgigrid.Appearance.ModifiedRow.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.ModifiedRow.Options.UseFont = true;
            this.firmabilgigrid.Appearance.PressedRow.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.PressedRow.Options.UseFont = true;
            this.firmabilgigrid.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.firmabilgigrid.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.firmabilgigrid.Appearance.RecordValue.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.RecordValue.Options.UseFont = true;
            this.firmabilgigrid.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 10f, FontStyle.Bold);
            this.firmabilgigrid.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.firmabilgigrid.Appearance.VertLine.Font = new Font("Tahoma", 10f);
            this.firmabilgigrid.Appearance.VertLine.Options.UseFont = true;
            this.firmabilgigrid.Cursor = Cursors.SizeNS;
            this.firmabilgigrid.Dock = DockStyle.Top;
            this.firmabilgigrid.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.firmabilgigrid.Location = new Point(0, 0);
            this.firmabilgigrid.Name = "firmabilgigrid";
            this.firmabilgigrid.RecordWidth = 110;
            this.firmabilgigrid.RowHeaderWidth = 90;
            BaseRow[] rows = new BaseRow[] { this.row, this.row1, this.row2, this.row4, this.row3, this.row5, this.row8, this.row6, this.category, this.category1 };
            this.firmabilgigrid.Rows.AddRange(rows);
            this.firmabilgigrid.Size = new Size(990, 0x160);
            this.firmabilgigrid.TabIndex = 0x3ea;
            this.firmabilgigrid.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.vGridControl1_CellValueChanged);
            this.row.Name = "row";
            this.row.Properties.Caption = "FİRMANIZIN ADI";
            this.row.Properties.FieldName = "ad";
            this.row.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row1.Name = "row1";
            this.row1.Properties.Caption = "ADRES";
            this.row1.Properties.FieldName = "adres";
            this.row1.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row2.Height = 0x12;
            this.row2.Name = "row2";
            this.row2.Properties.Caption = "MARKA";
            this.row2.Properties.FieldName = "marka";
            this.row2.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row4.Name = "row4";
            MultiEditorRowProperties[] props = new MultiEditorRowProperties[] { this.multiEditorRowProperties5, this.multiEditorRowProperties6 };
            this.row4.PropertiesCollection.AddRange(props);
            this.multiEditorRowProperties5.Caption = "VERGİ DAİRESİ";
            this.multiEditorRowProperties5.FieldName = "VergiDair";
            this.multiEditorRowProperties5.Padding = new System.Windows.Forms.Padding(0);
            this.multiEditorRowProperties6.Caption = "VERGİ NUMARASI";
            this.multiEditorRowProperties6.FieldName = "VergiNo";
            this.multiEditorRowProperties6.Padding = new System.Windows.Forms.Padding(0);
            this.row3.Name = "row3";
            MultiEditorRowProperties[] propertiesArray2 = new MultiEditorRowProperties[] { this.multiEditorRowProperties1, this.multiEditorRowProperties2, this.multiEditorRowProperties3, this.multiEditorRowProperties4 };
            this.row3.PropertiesCollection.AddRange(propertiesArray2);
            this.multiEditorRowProperties1.Caption = "YETKİLİ ADI";
            this.multiEditorRowProperties1.FieldName = "Yad";
            this.multiEditorRowProperties1.Padding = new System.Windows.Forms.Padding(0);
            this.multiEditorRowProperties1.Width = 100;
            this.multiEditorRowProperties2.Caption = "CEP";
            this.multiEditorRowProperties2.FieldName = "tel";
            this.multiEditorRowProperties2.Padding = new System.Windows.Forms.Padding(0);
            this.multiEditorRowProperties2.Width = 0x5e;
            this.multiEditorRowProperties3.Caption = "FAX";
            this.multiEditorRowProperties3.FieldName = "fax";
            this.multiEditorRowProperties3.Padding = new System.Windows.Forms.Padding(0);
            this.multiEditorRowProperties3.Width = 0x61;
            this.multiEditorRowProperties4.Caption = "EMAİL";
            this.multiEditorRowProperties4.FieldName = "email";
            this.multiEditorRowProperties4.Padding = new System.Windows.Forms.Padding(0);
            this.multiEditorRowProperties4.Width = 0x60;
            this.row5.Name = "row5";
            MultiEditorRowProperties[] propertiesArray3 = new MultiEditorRowProperties[] { this.multiEditorRowProperties7, this.multiEditorRowProperties8 };
            this.row5.PropertiesCollection.AddRange(propertiesArray3);
            this.multiEditorRowProperties7.Caption = "HYB BELGE TARİHİ";
            this.multiEditorRowProperties7.FieldName = "hybtar";
            this.multiEditorRowProperties7.Padding = new System.Windows.Forms.Padding(0);
            this.multiEditorRowProperties8.Caption = "HYB BELGE NO";
            this.multiEditorRowProperties8.FieldName = "hybno";
            this.multiEditorRowProperties8.Padding = new System.Windows.Forms.Padding(0);
            this.row8.Name = "row8";
            MultiEditorRowProperties[] propertiesArray4 = new MultiEditorRowProperties[] { this.multiEditorRowProperties9, this.multiEditorRowProperties10 };
            this.row8.PropertiesCollection.AddRange(propertiesArray4);
            this.multiEditorRowProperties9.Caption = "SANAYİ SİCİL BEL. TAR.";
            this.multiEditorRowProperties9.FieldName = "santar";
            this.multiEditorRowProperties9.Padding = new System.Windows.Forms.Padding(0);
            this.multiEditorRowProperties10.Caption = "SANAYİ SİCİL BELGE NO";
            this.multiEditorRowProperties10.FieldName = "sanno";
            this.multiEditorRowProperties10.Padding = new System.Windows.Forms.Padding(0);
            this.row6.Name = "row6";
            MultiEditorRowProperties[] propertiesArray5 = new MultiEditorRowProperties[] { this.multiEditorRowProperties11, this.multiEditorRowProperties12 };
            this.row6.PropertiesCollection.AddRange(propertiesArray5);
            this.multiEditorRowProperties11.Caption = "CE ALDIĞINIZ FİRMANIN ADI";
            this.multiEditorRowProperties11.FieldName = "onkurulusad";
            this.multiEditorRowProperties11.Padding = new System.Windows.Forms.Padding(0);
            this.multiEditorRowProperties12.Caption = "CE ALD. FİRMA NO";
            this.multiEditorRowProperties12.FieldName = "onkurulusno";
            this.multiEditorRowProperties12.Padding = new System.Windows.Forms.Padding(0);
            BaseRow[] rowArray2 = new BaseRow[] { this.row7, this.row9, this.row10, this.row11 };
            this.category.ChildRows.AddRange(rowArray2);
            this.category.Name = "category";
            this.category.Properties.Caption = "MAKİNE M\x00dcHENDİSİ BİLGİLERİ";
            this.category.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row7.Name = "row7";
            this.row7.Properties.Caption = "MAKİNE M\x00dcH.ADI SOYADI";
            this.row7.Properties.FieldName = "mmad";
            this.row7.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row9.Name = "row9";
            this.row9.Properties.Caption = "MAKİNE M\x00dcH. ODA NO";
            this.row9.Properties.FieldName = "mmoda";
            this.row9.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row10.Name = "row10";
            this.row10.Properties.Caption = "MAKİNE M\x00dcH. BELGE NO";
            this.row10.Properties.FieldName = "mmbel";
            this.row10.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row11.Name = "row11";
            this.row11.Properties.Caption = "MAKİNE M\x00dcH. SMM NO";
            this.row11.Properties.FieldName = "mmsmm";
            this.row11.Properties.Padding = new System.Windows.Forms.Padding(0);
            BaseRow[] rowArray3 = new BaseRow[] { this.row12, this.row13, this.row14, this.row15 };
            this.category1.ChildRows.AddRange(rowArray3);
            this.category1.Name = "category1";
            this.category1.Properties.Caption = "ELEKTİRİK M\x00dcHENDİSİ BİLGİLERİ";
            this.category1.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row12.Name = "row12";
            this.row12.Properties.Caption = "ELEKTİRİK M\x00dcHENDİSİ ADI SOYADI";
            this.row12.Properties.FieldName = "emad";
            this.row12.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row13.Name = "row13";
            this.row13.Properties.Caption = "ELEKTİRİK M\x00dcHENDİSİ ODA NO";
            this.row13.Properties.FieldName = "emoda";
            this.row13.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row14.Name = "row14";
            this.row14.Properties.Caption = "ELEKTİRİK M\x00dcHENDİSİ BELGE NO";
            this.row14.Properties.FieldName = "embel";
            this.row14.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.row15.Name = "row15";
            this.row15.Properties.Caption = "ELEKTİRİK M\x00dcHENDİSİ SMM NO";
            this.row15.Properties.FieldName = "emsmm";
            this.row15.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.xtraTabControl1.Appearance.Font = new Font("Tahoma", 10f);
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.Header.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.Dock = DockStyle.Fill;
            this.xtraTabControl1.Location = new Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new Size(0x3ec, 0x1d9);
            this.xtraTabControl1.TabIndex = 0x3ea;
            XtraTabPage[] pages = new XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3, this.xtraTabPage4 };
            this.xtraTabControl1.TabPages.AddRange(pages);
            this.xtraTabPage1.Appearance.PageClient.BackColor = SystemColors.ControlDark;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.groupControl2);
            this.xtraTabPage1.Controls.Add(this.groupControl3);
            this.xtraTabPage1.Controls.Add(this.groupControl6);
            this.xtraTabPage1.Controls.Add(this.panel1);
            this.xtraTabPage1.Controls.Add(this.panel2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new Size(0x3e6, 0x1ba);
            this.xtraTabPage1.Text = "GENEL VERİLER";
            this.groupControl2.AppearanceCaption.Font = new Font("Tahoma", 10f, FontStyle.Bold);
            this.groupControl2.AppearanceCaption.ForeColor = Color.FromArgb(0xc0, 0, 0);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.layoutControl2);
            this.groupControl2.Location = new Point(0x26b, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(0x178, 0x125);
            this.groupControl2.TabIndex = 0x3eb;
            this.groupControl2.Text = "ASANS\x00d6R GENEL BİLGİLERİ";
            this.xtraTabPage2.Controls.Add(this.layoutControl4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new Size(0x3e6, 0x1ba);
            this.xtraTabPage2.Text = "KAT BİLGİLERİ";
            this.xtraTabPage3.Controls.Add(this.ayargrid);
            this.xtraTabPage3.Controls.Add(this.groupControl1);
            this.xtraTabPage3.Controls.Add(this.AydinlatmaBizde);
            this.xtraTabPage3.Controls.Add(this.BesPanoVar);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new Size(0x3e6, 0x1ba);
            this.xtraTabPage3.Text = "AYARLAR";
            this.ayargrid.Dock = DockStyle.Left;
            this.ayargrid.Location = new Point(0, 0);
            this.ayargrid.MainView = this.gridView1;
            this.ayargrid.Name = "ayargrid";
            this.ayargrid.Size = new Size(0x14b, 0x1ba);
            this.ayargrid.TabIndex = 0x9e;
            BaseView[] viewArray2 = new BaseView[] { this.gridView1 };
            this.ayargrid.ViewCollection.AddRange(viewArray2);
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
            GridColumn[] columnArray2 = new GridColumn[] { this.gridColumn79, this.gridColumn80, this.gridColumn81 };
            this.gridView1.Columns.AddRange(columnArray2);
            this.gridView1.GridControl = this.ayargrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridColumn79.AppearanceCell.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.gridColumn79.AppearanceCell.Options.UseFont = true;
            this.gridColumn79.Caption = "gridColumn1";
            this.gridColumn79.FieldName = "formvisual";
            this.gridColumn79.Name = "gridColumn79";
            this.gridColumn79.OptionsColumn.AllowEdit = false;
            this.gridColumn79.Visible = true;
            this.gridColumn79.VisibleIndex = 0;
            this.gridColumn80.Caption = "gridColumn2";
            this.gridColumn80.FieldName = "ParamValue";
            this.gridColumn80.Name = "gridColumn80";
            this.gridColumn80.Visible = true;
            this.gridColumn80.VisibleIndex = 1;
            this.gridColumn81.Caption = "gridColumn3";
            this.gridColumn81.FieldName = "ParamName";
            this.gridColumn81.Name = "gridColumn81";
            this.xtraTabPage4.Controls.Add(this.labelControl2);
            this.xtraTabPage4.Controls.Add(this.firmabilgigrid);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new Size(990, 0x1ba);
            this.xtraTabPage4.Text = "LİSANS BİLGİLERİ";
            this.labelControl2.Location = new Point(11, 0x166);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x4a, 13);
            this.labelControl2.TabIndex = 0x3eb;
            this.labelControl2.Text = "LİSANS S\x00dcRESİ";
            this.ımageList2.ColorDepth = ColorDepth.Depth8Bit;
            this.ımageList2.ImageSize = new Size(0x10, 0x10);
            this.ımageList2.TransparentColor = Color.Transparent;
            this.layoutControlItem16.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem16.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem16.Control = this.DurakSayi;
            this.layoutControlItem16.Location = new Point(0, 180);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new Size(0xdd, 0x1b);
            this.layoutControlItem16.Text = "DURAK SAYISI";
            this.layoutControlItem16.TextSize = new Size(0x88, 0x10);
            this.layoutControlItem17.Control = this.simpleButton2;
            this.layoutControlItem17.Location = new Point(0xdd, 180);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new Size(0x44, 0x1b);
            this.layoutControlItem17.TextSize = new Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            this.layoutControlItem18.Control = this.simpleButton1;
            this.layoutControlItem18.Location = new Point(0x121, 180);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new Size(0x48, 0x1b);
            this.layoutControlItem18.TextSize = new Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            this.layoutControlItem19.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem19.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem19.Control = this.IlkDurakNo;
            this.layoutControlItem19.Location = new Point(0, 0xcf);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new Size(0xdd, 0x1b);
            this.layoutControlItem19.Text = "İLK DURAK NO";
            this.layoutControlItem19.TextSize = new Size(0x88, 0x10);
            this.layoutControlItem20.Control = this.simpleButton4;
            this.layoutControlItem20.Location = new Point(0xdd, 0xcf);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new Size(0x44, 0x1b);
            this.layoutControlItem20.TextSize = new Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            this.layoutControlItem21.Control = this.simpleButton3;
            this.layoutControlItem21.Location = new Point(0x121, 0xcf);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new Size(0x48, 0x1b);
            this.layoutControlItem21.TextSize = new Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            this.layoutControlItem23.AppearanceItemCaption.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem23.Control = this.ToplamYuk;
            this.layoutControlItem23.Location = new Point(0, 0xea);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new Size(0x169, 0x22);
            this.layoutControlItem23.Text = "TOPLAM KUYU BOYU :";
            this.layoutControlItem23.TextSize = new Size(0x88, 0x10);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3ec, 0x1d9);
            base.Controls.Add(this.xtraTabControl1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ascadform";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ASCAD FORM";
            base.FormClosing += new FormClosingEventHandler(this.ascadform_FormClosing);
            base.Load += new EventHandler(this.ascadform_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupControl3.EndInit();
            this.groupControl3.ResumeLayout(false);
            this.layoutControl9.EndInit();
            this.layoutControl9.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.layoutControlGroup9.EndInit();
            this.layoutControlItem5.EndInit();
            this.layoutControl5.EndInit();
            this.layoutControl5.ResumeLayout(false);
            this.layoutControlGroup5.EndInit();
            this.layoutControlItem45.EndInit();
            this.layoutControlItem46.EndInit();
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.AgrTamponu.Properties.EndInit();
            this.KabinTamponu.Properties.EndInit();
            this.AgrRayStr.Properties.EndInit();
            this.KuyuDer.Properties.EndInit();
            this.KabinRayStr.Properties.EndInit();
            this.KuyuGen.Properties.EndInit();
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem111.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem2.EndInit();
            this.layoutControlItem114.EndInit();
            this.layoutControlItem113.EndInit();
            this.layoutControlItem115.EndInit();
            this.layoutControlItem10.EndInit();
            this.layoutControlItem15.EndInit();
            this.layoutControl2.EndInit();
            this.layoutControl2.ResumeLayout(false);
            this.checkEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.RegYer.Properties.EndInit();
            this.Mentese.Properties.EndInit();
            this.KapiGen.Properties.EndInit();
            this.otokapitipi.Properties.EndInit();
            this.asnkapitipi.Properties.EndInit();
            this.TahCap.Properties.EndInit();
            this.SapCap.Properties.EndInit();
            this.layoutControlGroup2.EndInit();
            this.layoutControlItem11.EndInit();
            this.layoutControlItem22.EndInit();
            this.layoutControlItem27.EndInit();
            this.layoutControlItem28.EndInit();
            this.layoutControlItem4.EndInit();
            this.layoutControlItem3.EndInit();
            this.layoutControlItem9.EndInit();
            this.layoutControlItem8.EndInit();
            this.layoutControlItem6.EndInit();
            this.layoutControlItem7.EndInit();
            this.layoutControlItem12.EndInit();
            this.layoutControlItem13.EndInit();
            this.layoutControlItem14.EndInit();
            this.groupControl6.EndInit();
            this.groupControl6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.HAMDControl.EndInit();
            this.HAMDControl.ResumeLayout(false);
            this.layoutControl8.EndInit();
            this.layoutControl8.ResumeLayout(false);
            this.txtHAMDDer.Properties.EndInit();
            this.txtHAMDGen.Properties.EndInit();
            this.layoutControlGroup8.EndInit();
            this.layoutControlItem62.EndInit();
            this.layoutControlItem64.EndInit();
            this.layoutControlItem65.EndInit();
            this.layoutControlItem66.EndInit();
            this.layoutControl4.EndInit();
            this.layoutControl4.ResumeLayout(false);
            this.IskeleVar.Properties.EndInit();
            this.DengeZinciri.Properties.EndInit();
            this.ToplamYuk.Properties.EndInit();
            this.SeyirMesafesi.Properties.EndInit();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            this.gridControl1.EndInit();
            this.gridView4.EndInit();
            this.MdTabTavan.Properties.EndInit();
            this.SonKat.Properties.EndInit();
            this.AraKatSTR.Properties.EndInit();
            this.TopKuyuKafa.Properties.EndInit();
            this.KuyuDibi.Properties.EndInit();
            this.DurakSayi.Properties.EndInit();
            this.KatH.Properties.EndInit();
            this.IlkDurakNo.Properties.EndInit();
            this.layoutControlGroup4.EndInit();
            this.layoutControlItem36.EndInit();
            this.layoutControlItem37.EndInit();
            this.layoutControlItem38.EndInit();
            this.layoutControlItem42.EndInit();
            this.layoutControlItem43.EndInit();
            this.layoutControlItem44.EndInit();
            this.layoutControlItem68.EndInit();
            this.layoutControlItem82.EndInit();
            this.layoutControlItem125.EndInit();
            this.layoutControlItem40.EndInit();
            this.layoutControlItem41.EndInit();
            this.BesPanoVar.Properties.EndInit();
            this.AydinlatmaBizde.Properties.EndInit();
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.firmabilgigrid.EndInit();
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.groupControl2.EndInit();
            this.groupControl2.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.ayargrid.EndInit();
            this.gridView1.EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage4.PerformLayout();
            this.layoutControlItem16.EndInit();
            this.layoutControlItem17.EndInit();
            this.layoutControlItem18.EndInit();
            this.layoutControlItem19.EndInit();
            this.layoutControlItem20.EndInit();
            this.layoutControlItem21.EndInit();
            this.layoutControlItem23.EndInit();
            base.ResumeLayout(false);
        }

        private void kabinray_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                new productinfo { urunne = "ray" }.ShowDialog();
            }
        }

        private void katlarclosing()
        {
            this.katyukdiyezlist = "";
            this.katrumuzlist = "";
            int num = 0;
            for (int i = 1; i < this.gridView4.RowCount; i++)
            {
                num += Convert.ToInt32(this.gridView4.GetRowCellValue(i, "kath").ToString());
                if (i != (this.gridView4.RowCount - 1))
                {
                    this.katyukdiyezlist = this.katyukdiyezlist + this.gridView4.GetRowCellValue(i, "kath").ToString() + "#";
                }
                if (i < (this.gridView4.RowCount - 1))
                {
                    if (string.IsNullOrEmpty(this.gridView4.GetRowCellValue(i, "krumz").ToString()))
                    {
                        this.katrumuzlist = this.katrumuzlist + this.gridView4.GetRowCellValue(i, "ktno").ToString() + "#";
                    }
                    else
                    {
                        string[] textArray1 = new string[] { this.katrumuzlist, this.gridView4.GetRowCellValue(i, "ktno").ToString(), "(", this.gridView4.GetRowCellValue(i, "krumz").ToString(), ")#" };
                        this.katrumuzlist = string.Concat(textArray1);
                    }
                }
            }
            this.ToplamYuk.Text = (num + Convert.ToInt32(this.KuyuDibi.Text)).ToString();
            int num2 = 0;
            for (int j = 1; j < (this.gridView4.RowCount - 2); j++)
            {
                num2 += Convert.ToInt32(this.gridView4.GetRowCellValue(j, "kath").ToString());
            }
            this.SeyirMesafesi.Text = num2.ToString();
            string str = "";
            char[] separator = new char[] { '#' };
            string[] strArray = this.katrumuzlist.Substring(0, this.katrumuzlist.Length - 1).Split(separator);
            for (int k = 1; k < (strArray.Length - 1); k++)
            {
                str = str + strArray[k] + ".";
            }
            str = str + " KATLAR";
            this.AraKatSTR.Text = str;
        }

        private void katnolar()
        {
            int count = this.katlar.Rows.Count;
            if (count < (Convert.ToInt32(this.DurakSayi.Text) + 2))
            {
                for (int k = 0; k < ((Convert.ToInt32(this.DurakSayi.Text) + 2) - count); k++)
                {
                    this.katlar.Rows.Add(this.katlar.NewRow());
                }
            }
            else if (count > (Convert.ToInt32(this.DurakSayi.Text) + 2))
            {
                for (int m = 0; m < ((count - Convert.ToInt32(this.DurakSayi.Text)) - 2); m++)
                {
                    this.katlar.Rows[count - 3].Delete();
                }
            }
            this.katlar.Rows[0]["ktno"] = "KUYU DİBİ";
            for (int i = 1; i < (this.katlar.Rows.Count - 1); i++)
            {
                this.katlar.Rows[i]["ktno"] = ((Convert.ToInt32(this.IlkDurakNo.Text) + i) - 1).ToString();
            }
            int num2 = this.katlar.Rows.Count;
            this.katlar.Rows[num2 - 1]["ktno"] = "KUYU TAVANI";
            this.katlar.Rows[num2 - 1]["kath"] = Convert.ToInt32(this.TopKuyuKafa.Text) - Convert.ToInt32(this.KatH.Text);
            char[] separator = new char[] { '#' };
            string[] strArray = this.FormMyData.KatRumuz.Split(separator);
            char[] chArray2 = new char[] { '#' };
            string[] collection = this.FormMyData.KatYukListe.Split(chArray2);
            List<string> list = new List<string>(collection);
            int num3 = this.katlar.Rows.Count;
            this.katlar.Rows[0]["kath"] = Convert.ToInt32(this.KuyuDibi.Text);
            if ((collection.Length + 2) > num3)
            {
                for (int n = 0; n < ((collection.Length + 2) - num3); n++)
                {
                    list.RemoveAt(list.Count - 2);
                }
            }
            if ((collection.Length + 2) < num3)
            {
                for (int num9 = 0; num9 < ((num3 - collection.Length) - 2); num9++)
                {
                    list.Insert(list.Count - 1, this.KatH.Text);
                }
            }
            for (int j = 0; j < list.Count; j++)
            {
                try
                {
                    this.katlar.Rows[j + 1]["kath"] = Convert.ToInt32(list[j]);
                }
                catch (Exception)
                {
                    this.gridView4.SetRowCellValue(j + 1, "kath", Convert.ToInt32(this.KatH.Text));
                    this.katlar.Rows[j + 1]["kath"] = Convert.ToInt32(this.KatH.Text);
                }
                try
                {
                    if (((strArray.Length - 1) < j) && strArray[j].Contains<char>('('))
                    {
                        this.katlar.Rows[j + 1]["krumz"] = strArray[j].Substring(strArray[j].IndexOf('('));
                    }
                }
                catch (Exception)
                {
                    this.katlar.Rows[j + 1]["krumz"] = "";
                }
            }
            this.gridkatHhesapla();
        }

        private void panaromik_CheckedChanged(object sender, EventArgs e)
        {
            if (this.panaromik.Checked)
            {
                this.xx.SetNumValue("Pan", "1", "1");
                if (this.agrarka.Checked)
                {
                    MessageBox.Show("ARKADAN AĞIRLIKTA PANORAMİK YAPAMAZSINIZ");
                    this.agrarka.Enabled = false;
                    this.agrsol.Checked = true;
                }
            }
            else
            {
                this.xx.SetNumValue("Pan", "0", "1");
                this.agrarka.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.makli1_1.Checked && (this.AsansorTipi == "EA"))
            {
                this.FormMyData.TipKodu = "EA";
                this.FormMyData.TahrikKodu = "DA";
                this.ha11.Checked = false;
                this.ha21.Checked = false;
            }
            if (this.mdduz.Checked && (this.AsansorTipi == "EA"))
            {
                this.FormMyData.TipKodu = "EA";
                this.FormMyData.TahrikKodu = "MDDUZ";
                this.ha11.Checked = false;
                this.ha21.Checked = false;
            }
            if (this.maksiz1_2alttan.Checked && (this.AsansorTipi == "EA"))
            {
                this.FormMyData.TipKodu = "EA";
                this.FormMyData.TahrikKodu = "MDCAP";
                this.ha11.Checked = false;
                this.ha21.Checked = false;
            }
            if (this.makli1_2.Checked && (this.AsansorTipi == "EA"))
            {
                this.FormMyData.TipKodu = "EA";
                this.FormMyData.TahrikKodu = "YA";
                this.ha11.Checked = false;
                this.ha21.Checked = false;
            }
            if (this.ha11.Checked && (this.AsansorTipi == "HA"))
            {
                this.FormMyData.TipKodu = "HA";
                this.FormMyData.TahrikKodu = "DA";
            }
            if (this.ha21.Checked && (this.AsansorTipi == "HA"))
            {
                this.FormMyData.TipKodu = "HA";
                this.FormMyData.TahrikKodu = "HY";
            }
        }

        private void radioHMSAG_CheckedChanged(object sender, EventArgs e)
        {
            this.HAMDSet();
        }

        private void sankod_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sankod.Checked)
            {
                this.xx.SetNumValue("TahrikKodu", "SD", "1");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DurakSayi.Text = (Convert.ToInt32(this.DurakSayi.Text) + 1).ToString();
            this.katnolar();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DurakSayi.Text = (Convert.ToInt32(this.DurakSayi.Text) - 1).ToString();
            this.katnolar();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.IlkDurakNo.Text = (Convert.ToInt32(this.IlkDurakNo.Text) + 1).ToString();
            this.katnolar();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.IlkDurakNo.Text = (Convert.ToInt32(this.IlkDurakNo.Text) - 1).ToString();
            this.katnolar();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
        }

        private void tipayarla()
        {
            if (this.AsansorTipi == "HA")
            {
                this.panel1.Visible = false;
                this.panel2.Location = this.panel1.Location;
                this.panel2.Size = this.panel1.Size;
                this.panel2.Visible = true;
                this.ha11.Visible = true;
                this.ha11.Checked = true;
                this.HAMDControl.Visible = true;
                this.radioHMSAG.Checked = true;
            }
            else
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.ha11.Checked = false;
                this.ha21.Checked = false;
                this.HAMDControl.Visible = false;
            }
            if (this.AsansorTipi == "HA")
            {
                switch (this.FormMyData.TahrikKodu)
                {
                    case "DA":
                        this.ha11.Checked = true;
                        break;

                    case "HY":
                        this.ha21.Checked = true;
                        break;
                }
            }
            else
            {
                string tahrikKodu = this.FormMyData.TahrikKodu;
                switch (<PrivateImplementationDetails>.ComputeStringHash(tahrikKodu))
                {
                    case 0x2a606448:
                        if (tahrikKodu == "MDL")
                        {
                            this.makli1_2.Checked = true;
                            break;
                        }
                        break;

                    case 0x37ce7716:
                        if (tahrikKodu == "DA")
                        {
                            this.makli1_1.Checked = true;
                            break;
                        }
                        break;

                    case 0x1298f7c9:
                        if (tahrikKodu == "HA1")
                        {
                            this.ha11.Checked = true;
                            break;
                        }
                        break;

                    case 0x159929a4:
                        if (tahrikKodu == "MDCAP")
                        {
                            this.maksiz1_2alttan.Checked = true;
                            break;
                        }
                        break;

                    case 0x3c11634f:
                        if (tahrikKodu == "YA")
                        {
                            this.makli1_2.Checked = true;
                            break;
                        }
                        break;

                    case 0x5730a13f:
                        if (tahrikKodu == "MDDUZ")
                        {
                            this.mdduz.Checked = true;
                            break;
                        }
                        break;

                    case 0x5b028992:
                        if (tahrikKodu == "SD")
                        {
                            this.sankod.Checked = true;
                            break;
                        }
                        break;

                    case 0x7feb6a82:
                        if (tahrikKodu == "HA")
                        {
                            this.ha21.Checked = true;
                            break;
                        }
                        break;
                }
            }
            string yonKodu = this.FormMyData.YonKodu;
            if (yonKodu == "SAG")
            {
                this.agrsag.Checked = true;
            }
            else if (yonKodu == "SOL")
            {
                this.agrsol.Checked = true;
            }
            else if (yonKodu == "ARKA")
            {
                this.agrarka.Checked = true;
            }
            if (this.FormMyData.AgrGir == "0")
            {
                this.dokumagr.Checked = true;
            }
            else
            {
                this.baritagr.Checked = true;
            }
        }

        private void txtKontrols(TextEdit gt, string defauldeger, int buyukolmaz, int kucukolmaz)
        {
            if (string.IsNullOrEmpty(gt.Text) || string.IsNullOrEmpty(gt.EditValue.ToString()))
            {
                MessageBox.Show(gt.Name + " değerini boş g\x00f6nderiyorsunuz Varsayılan değere alındı :" + defauldeger);
                gt.EditValue = defauldeger;
            }
            if (Convert.ToInt32(gt.EditValue.ToString()) > buyukolmaz)
            {
                MessageBox.Show(string.Concat(new object[] { gt.Name, " değeri ", buyukolmaz, " b\x00fcy\x00fck olamaz Varsayılan değere alındı :", defauldeger }));
                gt.EditValue = defauldeger;
            }
            if (Convert.ToInt32(gt.EditValue.ToString()) < kucukolmaz)
            {
                MessageBox.Show(string.Concat(new object[] { gt.Name, " değeri ", kucukolmaz, " k\x00fc\x00e7\x00fck olamaz Varsayılan değere alındı :", defauldeger }));
                gt.EditValue = defauldeger;
            }
        }

        private void vGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            string komut = "";
            if (e.Row.XtraRowTypeID == 2)
            {
                MultiEditorRow row = (MultiEditorRow) e.Row;
                komut = this.xx.hucredeupdate("update stats.firmabilgi Set ", row.PropertiesCollection[e.CellIndex].RowType.ToString(), row.PropertiesCollection[e.CellIndex].FieldName, row.PropertiesCollection[e.CellIndex].Value.ToString(), " where id=1");
            }
            else
            {
                komut = this.xx.hucredeupdate("update stats.firmabilgi Set ", e.Row.Properties.RowType.ToString(), e.Row.Properties.FieldName, this.firmabilgigrid.GetCellValue(e.Row, 0).ToString(), " where id=1");
            }
            if (!this.xx.oleupdate(komut, ""))
            {
                MessageBox.Show("Başarısız");
            }
        }
    }
}

