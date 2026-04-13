namespace ascad
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using ZwSoft.ZwCAD.ApplicationServices;
    using ZwSoft.ZwCAD.Colors;
    using ZwSoft.ZwCAD.DatabaseServices;
    using ZwSoft.ZwCAD.EditorInput;
    using ZwSoft.ZwCAD.Geometry;
    using ZwSoft.ZwCAD.Runtime;
    using ZwSoft.ZwCAD.Windows;

    public class ascad
    {
        private static short _colorIndex = 0;
        public int AsansorSayisi = 1;
        private ascadcabin ascar = new ascadcabin();
        private asnhesapfrm fr1 = new asnhesapfrm();
        private ascadform mn2 = new ascadform();
        public ascadpalet myPalette = new ascadpalet();
        public PaletteSet myPaletteSet;
        private paramman prman = new paramman();
        private abc1 xx = new abc1();

        [CommandMethod("AddBlockTest")]
        public void AddBlockTest()
        {
            Point3d insertPoint = new Point3d(0.0, 0.0, 0.0);
            Database db = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = db.get_TransactionManager().StartTransaction())
            {
                string[] collection = new string[] { "#SAHİP#", "#MAHALLE", "#İL#", "#CADDE#" };
                string[] textArray2 = new string[] { "Value #1", "Value #2", "Value #3", "Value #4" };
                this.InsertBlock2(db, transaction, insertPoint, "en81-1", new List<string>(collection), new List<string>(textArray2), null, null, null);
                transaction.Commit();
            }
        }

        private static void AddRegAppTableRecord(string regAppName)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Editor editor = document.get_Editor();
            Database database = document.get_Database();
            Transaction transaction = document.get_TransactionManager().StartTransaction();
            using (transaction)
            {
                RegAppTable table = transaction.GetObject(database.get_RegAppTableId(), 0, false);
                if (!table.Has(regAppName))
                {
                    table.UpgradeOpen();
                    RegAppTableRecord record = new RegAppTableRecord();
                    record.set_Name(regAppName);
                    table.Add(record);
                    transaction.AddNewlyCreatedDBObject(record, true);
                }
                transaction.Commit();
            }
        }

        [CommandMethod("ADDXDATA")]
        public static void AddXdata()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            Transaction transaction = database.get_TransactionManager().StartTransaction();
            using (transaction)
            {
                Entity entity = transaction.GetObject(Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetEntity("Pick entity ").get_ObjectId(), 1);
                RegAppTable table = transaction.GetObject(database.get_RegAppTableId(), 0);
                if (!table.Has("ADS"))
                {
                    table.UpgradeOpen();
                    RegAppTableRecord record = new RegAppTableRecord();
                    record.set_Name("ADS");
                    table.Add(record);
                    transaction.AddNewlyCreatedDBObject(record, true);
                }
                TypedValue[] valueArray1 = new TypedValue[] { new TypedValue(0x3e9, "ADS"), new TypedValue(0x42e, 100) };
                entity.set_XData(new ResultBuffer(valueArray1));
                transaction.Commit();
            }
        }

        [CommandMethod("AppendAttribute")]
        public void AppendAttribute()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Editor editor = document.get_Editor();
            Database database = document.get_Database();
            PromptEntityOptions options = new PromptEntityOptions("\nSelect attribute to add");
            options.SetRejectMessage("\nNot an AttributeDefinition");
            options.AddAllowedClass(typeof(AttributeDefinition), true);
            PromptEntityResult entity = editor.GetEntity(options);
            if (entity.get_Status() == 0x13ec)
            {
                ObjectId id = entity.get_ObjectId();
                options = new PromptEntityOptions("\nSelect block to append attribute");
                options.SetRejectMessage("\nNot a BlockReference");
                options.AddAllowedClass(typeof(BlockReference), true);
                entity = editor.GetEntity(options);
                if (entity.get_Status() == 0x13ec)
                {
                    ObjectId id2 = entity.get_ObjectId();
                    Transaction transaction = database.get_TransactionManager().StartTransaction();
                    try
                    {
                        AttributeDefinition definition = transaction.GetObject(id, 1);
                        BlockReference reference = transaction.GetObject(id2, 0);
                        BlockTableRecord record = transaction.GetObject(reference.get_BlockTableRecord(), 1);
                        AttributeDefinition definition2 = (AttributeDefinition) definition.Clone();
                        definition2.TransformBy(reference.get_BlockTransform().Inverse());
                        ObjectId id3 = record.AppendEntity(definition2);
                        transaction.AddNewlyCreatedDBObject(definition2, true);
                        ObjectIdCollection blockReferenceIds = record.GetBlockReferenceIds(true, true);
                        foreach (ObjectId id4 in blockReferenceIds)
                        {
                            reference = transaction.GetObject(id4, 1);
                            AttributeReference reference2 = new AttributeReference();
                            reference2.SetAttributeFromBlock(definition2, reference.get_BlockTransform());
                            reference2.set_TextString(definition.get_TextString());
                            reference.get_AttributeCollection().AppendAttribute(reference2);
                            transaction.AddNewlyCreatedDBObject(reference2, true);
                        }
                        definition.Erase();
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        object[] objArray1 = new object[] { exception.Message, exception.StackTrace };
                        editor.WriteMessage("\nError: {0}\n{1}", objArray1);
                    }
                    finally
                    {
                        if (transaction != null)
                        {
                            transaction.Dispose();
                        }
                    }
                }
            }
        }

        private static void ApplyAttibutes(Database acDB, Transaction acTrans, BlockReference acBlkRef, List<string> listTags, List<string> listValues)
        {
            BlockTableRecord record = acTrans.GetObject(acBlkRef.get_BlockTableRecord(), 0);
            foreach (ObjectId id in record)
            {
                Entity entity = acTrans.GetObject(id, 0);
                if (entity is AttributeDefinition)
                {
                    AttributeDefinition definition = entity;
                    AttributeReference reference = new AttributeReference();
                    reference.SetAttributeFromBlock(definition, acBlkRef.get_BlockTransform());
                    acBlkRef.get_AttributeCollection().AppendAttribute(reference);
                    acTrans.AddNewlyCreatedDBObject(reference, true);
                    if (listTags.Contains(definition.get_Tag()))
                    {
                        int index = listTags.IndexOf(definition.get_Tag().ToUpper());
                        if (index >= 0)
                        {
                            reference.set_TextString(listValues[index]);
                            reference.AdjustAlignment(acDB);
                        }
                    }
                }
            }
        }

        [CommandMethod("ARKA")]
        public void ARKA()
        {
            this.DALL();
            this.xx.SetNumValue("YonKodu", "ARKA", "1");
        }

        public void AsansorEkle()
        {
            this.DALL();
            PromptKeywordOptions options = new PromptKeywordOptions("\nKesiti Sec :");
            options.set_AllowNone(false);
            options.get_Keywords().Add("KK");
            options.get_Keywords().Add("KD");
            options.get_Keywords().Add("MD");
            options.get_Keywords().Add("TK-AA");
            options.get_Keywords().Add("TK-BB");
            options.get_Keywords().Add("TTK-AA");
            options.get_Keywords().Add("TTK-BB");
            PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(options);
            if (keywords.get_Status() == 0x13ec)
            {
                string kesitKodu = keywords.get_StringResult();
                if (string.IsNullOrEmpty(this.GetParamValue("LN")))
                {
                    this.NewParam("LN", "2");
                }
                else
                {
                    this.chParamVal("LN", "2");
                }
                this.LD(kesitKodu, false, new Point3d());
            }
        }

        [CommandMethod("AsCad")]
        public void AsCad()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            clsCompleteLift lift = new clsCompleteLift();
            vtGroup group = new vtGroup();
            Giris giris = new Giris();
            clsMainLift item = new clsMainLift {
                LiftNum = 1,
                KuyuGen = 0x898,
                KuyuDer = 0x9c4,
                TahrikYonu = "SAG"
            };
            List<structAnaTip> list = new List<structAnaTip>();
            List<structTahrikTip> list2 = new List<structTahrikTip>();
            List<structTahrikYon> list3 = new List<structTahrikYon>();
            structAnaTip anaTip = new structAnaTip();
            structTahrikTip tahrikTip = new structTahrikTip();
            structTahrikYon yon = new structTahrikYon();
            list = this.ReadAnaTip();
            PromptKeywordOptions options = new PromptKeywordOptions("\nTahrik Cinsini Se\x00e7iniz :");
            options.set_AllowNone(false);
            foreach (structAnaTip tip3 in list)
            {
                options.get_Keywords().Add(tip3.TipAdi);
            }
            PromptResult keywords = editor.GetKeywords(options);
            if (keywords.get_Status() != 0x13ec)
            {
                item.AnaTahrik = "Elektrikli";
            }
            item.AnaTahrik = keywords.get_StringResult();
            foreach (structAnaTip tip4 in list)
            {
                if (tip4.TipAdi == keywords.get_StringResult())
                {
                    anaTip.TipAdi = tip4.TipAdi;
                    anaTip.TipKodu = tip4.TipKodu;
                }
            }
            list2 = this.ReadTahrikTip(anaTip);
            PromptKeywordOptions options2 = new PromptKeywordOptions("\nTahrik Tipini Se\x00e7iniz :");
            options2.set_AllowNone(false);
            foreach (structTahrikTip tip5 in list2)
            {
                options2.get_Keywords().Add(tip5.TipAdi);
            }
            PromptResult result2 = editor.GetKeywords(options2);
            if (result2.get_Status() != 0x13ec)
            {
                item.TahrikTipi = "DirekAski";
            }
            item.TahrikTipi = result2.get_StringResult();
            foreach (structTahrikTip tip6 in list2)
            {
                if (tip6.TipAdi == result2.get_StringResult())
                {
                    tahrikTip.TipAdi = tip6.TipAdi;
                    tahrikTip.TipKodu = tip6.TipKodu;
                    tahrikTip.TahrikKodu = tip6.TahrikKodu;
                    tahrikTip.TipIndex = tip6.TipIndex;
                }
            }
            list3 = this.ReadTahrikYon(anaTip);
            PromptKeywordOptions options3 = new PromptKeywordOptions("\nTahrik Y\x00f6n\x00fcn\x00fc Se\x00e7iniz :");
            options3.set_AllowNone(false);
            foreach (structTahrikYon yon2 in list3)
            {
                options3.get_Keywords().Add(yon2.TipAdi);
            }
            PromptResult result3 = editor.GetKeywords(options3);
            if (result3.get_Status() != 0x13ec)
            {
                item.TahrikTipi = "SOL";
            }
            item.TahrikYonu = result3.get_StringResult();
            foreach (structTahrikYon yon3 in list3)
            {
                if (yon3.TipAdi == result3.get_StringResult())
                {
                    yon.TipAdi = yon3.TipAdi;
                    yon.TipKodu = yon3.TipKodu;
                    yon.YonKodu = yon3.YonKodu;
                }
            }
            tahrikTip.YonKodu = yon.YonKodu;
            string liftNumber = Convert.ToString(item.LiftNum);
            string str2 = tahrikTip.TipKodu + "-" + tahrikTip.TahrikKodu + "-BLK";
            string[] textArray1 = new string[] { tahrikTip.TipKodu, "-", tahrikTip.TahrikKodu, "-", yon.YonKodu, "-PARAM" };
            string str3 = string.Concat(textArray1);
            str3 = tahrikTip.TipKodu + "-PARAM";
            string[] textArray2 = new string[] { tahrikTip.TipKodu, "-", tahrikTip.TahrikKodu, "-", yon.YonKodu, "-VAR" };
            string str4 = string.Concat(textArray2);
            string[] textArray3 = new string[] { tahrikTip.TipKodu, "-", tahrikTip.TahrikKodu, "-", yon.YonKodu, "-DIM" };
            string str5 = string.Concat(textArray3);
            structTablist tablist = new structTablist {
                TipKodu = tahrikTip.TipKodu,
                TahrikKodu = tahrikTip.TahrikKodu,
                YonKodu = yon.YonKodu
            };
            item.Tablist = tablist;
            this.xx.oleupdate("update TabList set TabValue='" + tahrikTip.TipKodu + "' where TabName='TipKodu'", "");
            this.xx.oleupdate("update TabList set TabValue='" + tahrikTip.TahrikKodu + "' where TabName='TahrikKodu'", "");
            this.xx.oleupdate("update TabList set TabValue='" + tahrikTip.YonKodu + "' where TabName='YonKodu'", "");
            switch (tahrikTip.TipKodu)
            {
                case "EA":
                    group.KabinBlok = this.ReadData("Kabin", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.KabinRayBlok = this.ReadData("KabinRay", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.KapiBlok = this.ReadData("Kapi", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.KuyuBlok = this.ReadData("Kuyu", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.SinirBlok = this.ReadData("KabinBase", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.AgirlikBlok = this.ReadData("AgrButun", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.AgrUstBlok = this.ReadData("AgrUst", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.AgrRayBlok = this.ReadData("AgrRay", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    switch (tahrikTip.TahrikKodu)
                    {
                        case "MDDUZ":
                            group.AgrUstKasnak = this.ReadData("AgrUstKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                            group.KabinAltKasnakBlok = this.ReadData("KabinAltKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                            break;

                        case "MDCAP":
                            group.AgrUstKasnak = this.ReadData("AgrUstKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                            group.CaprazBlok = this.ReadData("Capraz", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                            break;
                    }
                    switch (tahrikTip.YonKodu)
                    {
                        case "SOL":
                        case "SAG":
                        {
                            this.xx.oleupdate("update Num1 set ParamValue='KuyuDer-KabinYEksen-100' where ParamName='KabinDer'", "");
                            this.xx.oleupdate("update Num1 set ParamValue='KuyuGen-(AgrDuv+AgrGen+AgrU+70+200)-((KRX+KabinRayUcu)*2)' where ParamName='KabinGen'", "");
                            this.xx.oleupdate("update Num1 set ParamValue='(KabinDer/2)+KizakKalin' where ParamName='RK'", "");
                            string tahrikKodu = tahrikTip.TahrikKodu;
                            if (tahrikKodu == "DA")
                            {
                                this.xx.oleupdate("update Num1 set ParamValue='KabinRayYEksen' where ParamName='AgrYEksen'", "");
                            }
                            else if (tahrikKodu == "MDDUZ")
                            {
                                this.xx.oleupdate("update Num1 set ParamValue='KabinYEksen+(KabinDer/2)+(SapKas/2)' where ParamName='AgrYEksen'", "");
                                break;
                            }
                            break;
                        }
                    }
                    break;

                case "HA":
                    group.KabinBlok = this.ReadData("Kabin", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.KapiBlok = this.ReadData("Kapi", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.KuyuBlok = this.ReadData("Kuyu", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.SinirBlok = this.ReadData("KabinBase", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.HASemerBlok = this.ReadData("HidrolikSemer", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.HAEksenBlok = this.ReadData("HidrolikEksen", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    break;
            }
            item.BasePoint = new Point3d(0.0, 0.0, 0.0);
            item.BlokGrup = group;
            item.VarGrup = this.ReadVarGrup(tahrikTip, Convert.ToString(item.LiftNum));
            if (tahrikTip.TipKodu == "EA")
            {
                item.DimGrup = this.ReadDimGrup(tahrikTip, Convert.ToString(item.LiftNum));
            }
            lift.Lift.Add(item);
            string param = this.GetParam(item.VarGrup, "KuyuDer");
        }

        [CommandMethod("hesa3")]
        public void asnhesap()
        {
            this.fr1.ShowDialog();
            if (this.fr1.hesapiklendi)
            {
                this.denemerep(this.fr1.gelen, this.fr1.donen, this.fr1.hesaplamavekagit);
            }
        }

        [CommandMethod("AttachingExternalReference")]
        public void AttachingExternalReference(string FileName, Point3d insPt, double BlkScale)
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                string str = @"c:\asnproje\" + FileName + ".dwg";
                ObjectId id = database.AttachXref(str, FileName);
                if (!id.get_IsNull())
                {
                    using (BlockReference reference = new BlockReference(insPt, id))
                    {
                        reference.set_ScaleFactors(new Scale3d(BlkScale));
                        (transaction.GetObject(database.get_CurrentSpaceId(), 1) as BlockTableRecord).AppendEntity(reference);
                        transaction.AddNewlyCreatedDBObject(reference, true);
                    }
                }
                transaction.Commit();
            }
        }

        private void beyanqbul(string liftnumber)
        {
            decimal num = new decimal();
            decimal num2 = new decimal();
            num2 = Convert.ToDecimal(this.prman.GetParamValFRM("L" + liftnumber + "KabinGen", "KK"));
            num = Convert.ToDecimal(this.prman.GetParamValFRM("L" + liftnumber + "KabinDer", "KK"));
            double num4 = Convert.ToDouble(decimal.Round((num2 * num) / 1000000M, 2));
            if ((this.myPaletteSet != null) && this.myPalette.Visible)
            {
                this.myPalette.kabinderx.Text = num.ToString();
                this.myPalette.kabingenx.Text = num2.ToString();
            }
            if ((0.49 <= num4) && (num4 <= 0.58))
            {
                this.xx.SetNumValue("BeyanYuk", "180", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "3", liftnumber);
            }
            if ((0.6 <= num4) && (num4 <= 0.7))
            {
                this.xx.SetNumValue("BeyanYuk", "225", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "3", liftnumber);
            }
            if ((0.79 <= num4) && (num4 <= 0.9))
            {
                this.xx.SetNumValue("BeyanYuk", "300", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "4", liftnumber);
            }
            if ((0.9 <= num4) && (num4 <= 0.98))
            {
                this.xx.SetNumValue("BeyanYuk", "320", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "5", liftnumber);
            }
            if ((0.98 <= num4) && (num4 <= 1.1))
            {
                this.xx.SetNumValue("BeyanYuk", "375", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "5", liftnumber);
            }
            if ((1.1 <= num4) && (num4 <= 1.17))
            {
                this.xx.SetNumValue("BeyanYuk", "400", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "5", liftnumber);
            }
            if ((1.17 <= num4) && (num4 <= 1.3))
            {
                this.xx.SetNumValue("BeyanYuk", "450", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "6", liftnumber);
            }
            if ((1.31 <= num4) && (num4 <= 1.45))
            {
                this.xx.SetNumValue("BeyanYuk", "525", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "7", liftnumber);
            }
            if ((1.45 <= num4) && (num4 <= 1.6))
            {
                this.xx.SetNumValue("BeyanYuk", "600", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "8", liftnumber);
            }
            if ((1.6 <= num4) && (num4 <= 1.66))
            {
                this.xx.SetNumValue("BeyanYuk", "630", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "8", liftnumber);
            }
            if ((1.59 <= num4) && (num4 <= 1.75))
            {
                this.xx.SetNumValue("BeyanYuk", "675", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "9", liftnumber);
            }
            if ((1.73 <= num4) && (num4 <= 1.9))
            {
                this.xx.SetNumValue("BeyanYuk", "750", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "10", liftnumber);
            }
            if ((1.9 <= num4) && (num4 <= 2.0))
            {
                this.xx.SetNumValue("BeyanYuk", "800", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "10", liftnumber);
            }
            if ((1.87 <= num4) && (num4 <= 2.05))
            {
                this.xx.SetNumValue("BeyanYuk", "825", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "11", liftnumber);
            }
            if ((2.01 <= num4) && (num4 <= 2.2))
            {
                this.xx.SetNumValue("BeyanYuk", "900", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "12", liftnumber);
            }
            if ((2.15 <= num4) && (num4 <= 2.35))
            {
                this.xx.SetNumValue("BeyanYuk", " 975", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "13", liftnumber);
            }
            if ((2.35 <= num4) && (num4 <= 2.4))
            {
                this.xx.SetNumValue("BeyanYuk", "1000", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "13", liftnumber);
            }
            if ((2.29 <= num4) && (num4 <= 2.5))
            {
                this.xx.SetNumValue("BeyanYuk", "1050", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "14", liftnumber);
            }
            if ((2.43 <= num4) && (num4 <= 2.65))
            {
                this.xx.SetNumValue("BeyanYuk", "1125", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "15", liftnumber);
            }
            if ((2.57 <= num4) && (num4 <= 2.8))
            {
                this.xx.SetNumValue("BeyanYuk", "1200", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "16", liftnumber);
            }
            if ((2.8 <= num4) && (num4 <= 2.9))
            {
                this.xx.SetNumValue("BeyanYuk", "1250", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "16", liftnumber);
            }
            if ((2.71 <= num4) && (num4 <= 2.95))
            {
                this.xx.SetNumValue("BeyanYuk", "1275", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "17", liftnumber);
            }
            if ((2.85 <= num4) && (num4 <= 3.1))
            {
                this.xx.SetNumValue("BeyanYuk", "1350", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "18", liftnumber);
            }
            if ((2.99 <= num4) && (num4 <= 3.25))
            {
                this.xx.SetNumValue("BeyanYuk", "1425", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "19", liftnumber);
            }
            if ((3.13 <= num4) && (num4 <= 3.4))
            {
                this.xx.SetNumValue("BeyanYuk", "1500", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "20", liftnumber);
            }
            if ((3.24 <= num4) && (num4 <= 3.45))
            {
                this.xx.SetNumValue("BeyanYuk", "1575", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "21", liftnumber);
            }
            if ((3.36 <= num4) && (num4 <= 3.56))
            {
                this.xx.SetNumValue("BeyanYuk", "1600", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "22", liftnumber);
            }
            if ((3.36 <= num4) && (num4 <= 3.68))
            {
                this.xx.SetNumValue("BeyanYuk", "1650", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "22", liftnumber);
            }
            if ((3.47 <= num4) && (num4 <= 3.8))
            {
                this.xx.SetNumValue("BeyanYuk", "1725", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "23", liftnumber);
            }
            if ((3.59 <= num4) && (num4 <= 3.92))
            {
                this.xx.SetNumValue("BeyanYuk", "1800", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "24", liftnumber);
            }
            if ((3.7 <= num4) && (num4 <= 4.04))
            {
                this.xx.SetNumValue("BeyanYuk", "1875", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "25", liftnumber);
            }
            if ((3.82 <= num4) && (num4 <= 4.16))
            {
                this.xx.SetNumValue("BeyanYuk", "1950", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "26", liftnumber);
            }
            if ((3.87 <= num4) && (num4 <= 4.2))
            {
                this.xx.SetNumValue("BeyanYuk", "2000", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "26", liftnumber);
            }
            if ((3.93 <= num4) && (num4 <= 4.32))
            {
                this.xx.SetNumValue("BeyanYuk", "2025", liftnumber);
                this.xx.SetNumValue("BeyanKisi", "27", liftnumber);
            }
        }

        [CommandMethod("Capraz")]
        public void Capraz()
        {
            Entity vtEnt = null;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database dbE = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (dbE)
                    {
                        using (Transaction transaction = dbE.get_TransactionManager().StartTransaction())
                        {
                            vtEnt = FObject("Capraz", "1", "KK");
                            if (vtEnt != null)
                            {
                                this.SetDynamicValue(dbE, transaction, vtEnt, "dynRotAng", (double) 0.78539816339744828);
                            }
                            double num = Math.Asin(0.5);
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void ChObj(int LiftNum, string BlockXData)
        {
            vtLift lift = new vtLift();
            lift = this.dtta(BlockXData, Convert.ToString(LiftNum));
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            PromptKeywordOptions options = new PromptKeywordOptions("\nYeni Blok Adını Se\x00e7iniz :");
            options.set_AllowNone(false);
            foreach (BlkPar par in lift.BlkList)
            {
                options.get_Keywords().Add(par.BlkName);
            }
            PromptResult keywords = editor.GetKeywords(options);
            if (keywords.get_Status() == 0x13ec)
            {
                this.xx.UpExcelBlockName(BlockXData, keywords.get_StringResult(), Convert.ToString(LiftNum));
                this.DALL();
                this.AsCad();
            }
        }

        public void chParamVal(string vtParName, string newName)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
        }

        public void ChTag(ObjectId brId, string attName, string newValue)
        {
            Database database = HostApplicationServices.get_WorkingDatabase();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockReference reference = transaction.GetObject(brId, 1);
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(reference.get_BlockTableRecord(), 1);
                foreach (ObjectId id in reference.get_AttributeCollection())
                {
                    AttributeReference reference2 = transaction.GetObject(id, 0) as AttributeReference;
                    if ((reference2 != null) && reference2.get_Tag().Equals(attName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        reference2.UpgradeOpen();
                        reference2.set_TextString(newValue);
                    }
                }
                transaction.Commit();
            }
        }

        [CommandMethod("ClearUnrefedBlocks")]
        public void ClearUnrefedBlocks()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Editor editor = document.get_Editor();
            Database database = document.get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 1) as BlockTable;
                foreach (ObjectId id in table)
                {
                    BlockTableRecord record = transaction.GetObject(id, 1) as BlockTableRecord;
                    if ((record.GetBlockReferenceIds(false, false).get_Count() == 0) && !record.get_IsLayout())
                    {
                        record.Erase();
                    }
                }
                transaction.Commit();
            }
        }

        [CommandMethod("CreateAndAssignALayer")]
        public static void CreateAndAssignALayer()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                string str = "Center";
                if (!table.Has(str))
                {
                    using (LayerTableRecord record2 = new LayerTableRecord())
                    {
                        record2.set_Color(Color.FromColorIndex(0xc3, 3));
                        record2.set_Name(str);
                        table.UpgradeOpen();
                        table.Add(record2);
                        transaction.AddNewlyCreatedDBObject(record2, true);
                    }
                }
                BlockTable table2 = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(table2.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
                using (Circle circle = new Circle())
                {
                    circle.set_Center(new Point3d(2.0, 2.0, 0.0));
                    circle.set_Radius(1.0);
                    circle.set_Layer(str);
                    record.AppendEntity(circle);
                    transaction.AddNewlyCreatedDBObject(circle, true);
                }
                transaction.Commit();
            }
        }

        [CommandMethod("CL")]
        public void CreateLayer()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            Transaction transaction = database.get_TransactionManager().StartTransaction();
            using (transaction)
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0);
                PromptStringOptions options = new PromptStringOptions("\nEnter new layer name: ");
                options.set_AllowSpaces(true);
                string str = "";
                do
                {
                    PromptResult result = editor.GetString(options);
                    if (result.get_Status() != 0x13ec)
                    {
                        return;
                    }
                    try
                    {
                        SymbolUtilityServices.ValidateSymbolName(result.get_StringResult(), false);
                        if (table.Has(result.get_StringResult()))
                        {
                            editor.WriteMessage("\nA layer with this name already exists.");
                        }
                        else
                        {
                            str = result.get_StringResult();
                        }
                    }
                    catch
                    {
                        editor.WriteMessage("\nInvalid layer name.");
                    }
                }
                while (str == "");
                LayerTableRecord record = new LayerTableRecord();
                record.set_Name(str);
                record.set_Color(Color.FromColorIndex(0xc3, _colorIndex));
                table.UpgradeOpen();
                ObjectId id = table.Add(record);
                transaction.AddNewlyCreatedDBObject(record, true);
                database.set_Clayer(id);
                transaction.Commit();
                object[] objArray1 = new object[2];
                objArray1[0] = str;
                _colorIndex = (short) (_colorIndex + 1);
                objArray1[1] = _colorIndex;
                editor.WriteMessage("\nCreated layer named \"{0}\" with a color index of {1}.", objArray1);
            }
        }

        [CommandMethod("DA")]
        public void DA()
        {
            this.DALL();
            this.xx.SetNumValue("TahrikKodu", "DA", "1");
        }

        [CommandMethod("DALL")]
        public void DALL()
        {
            this.DelAllObject();
        }

        [CommandMethod("DD")]
        public void DD()
        {
            string paramna = null;
            string str2 = null;
            string liftNumber = null;
            string str4 = null;
            string str5 = null;
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Editor editor = document.get_Editor();
            string str6 = "I";
            string kesitKODU = "KK";
            string str8 = null;
            TypedValue[] valueArray = new TypedValue[] { new TypedValue(0x3e9, str6) };
            PromptEntityOptions options = new PromptEntityOptions("\nSelect entity: ");
            PromptEntityResult result = editor.GetEntity(options);
            if (result.get_Status() == 0x13ec)
            {
                Transaction transaction = document.get_TransactionManager().StartTransaction();
                using (transaction)
                {
                    DBObject obj2 = transaction.GetObject(result.get_ObjectId(), 0);
                    str8 = obj2.get_ObjectId().get_ObjectClass().get_DxfName();
                    string gelen = "";
                    ResultBuffer buffer = obj2.get_XData();
                    int num2 = 0;
                    ResultBufferEnumerator enumerator = buffer.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TypedValue value2 = enumerator.get_Current();
                        if (value2.get_Value().GetType().FullName == "System.String")
                        {
                            if (((string) value2.get_Value()) == "I")
                            {
                                kesitKODU = "KK";
                                str6 = "I";
                            }
                            if (((string) value2.get_Value()) == "MD")
                            {
                                kesitKODU = "MD";
                                str6 = "MD";
                            }
                        }
                    }
                    ResultBuffer xDataForApplication = obj2.GetXDataForApplication(str6);
                    if (xDataForApplication == null)
                    {
                        editor.WriteMessage("\nEntity does not have XData attached.");
                    }
                    else
                    {
                        num2 = 0;
                        ResultBufferEnumerator enumerator2 = xDataForApplication.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            TypedValue value3 = enumerator2.get_Current();
                            num2++;
                            switch (num2)
                            {
                                case 3:
                                    liftNumber = (string) value3.get_Value();
                                    break;

                                case 2:
                                    if (obj2.get_ObjectId().get_ObjectClass().get_DxfName() == "DIMENSION")
                                    {
                                        Dimension dimension = obj2;
                                        str5 = Convert.ToString((int) dimension.get_Measurement());
                                        olcudeis olcudeis = new olcudeis {
                                            OldValue = str5
                                        };
                                        olcudeis.ShowDialog();
                                        str2 = olcudeis.NewValue.Replace("-", "");
                                    }
                                    else if (obj2.get_ObjectId().get_ObjectClass().get_DxfName() == "INSERT")
                                    {
                                        gelen = (string) value3.get_Value();
                                        if ((this.myPaletteSet != null) && this.myPalette.Visible)
                                        {
                                            this.myPalette.objedefiner(gelen);
                                        }
                                    }
                                    paramna = (string) value3.get_Value();
                                    break;
                            }
                        }
                        xDataForApplication.Dispose();
                    }
                }
            }
            if (paramna != null)
            {
                str4 = paramna;
                switch (str2)
                {
                    case null:
                    case "":
                        return;
                }
                int num = Convert.ToInt32(str2) - Convert.ToInt32(str5);
                if (num != 0)
                {
                    structTahrik tahrik = this.ReadTahrikData(liftNumber);
                    char[] separator = new char[] { Convert.ToChar(",") };
                    string[] strArray = paramna.Split(separator);
                    for (int i = 1; i <= strArray.Length; i++)
                    {
                        string str9;
                        if (strArray[i - 1].IndexOf("#") == -1)
                        {
                            paramna = "L" + liftNumber + strArray[i - 1];
                            str9 = Convert.ToString((int) (Convert.ToInt32(Convert.ToDouble(this.prman.GetParamValFRM(paramna, kesitKODU))) + num));
                            this.prman.chParamVal(paramna, str9);
                            this.xx.upexcel(strArray[i - 1], str9, liftNumber, tahrik);
                        }
                        else
                        {
                            char[] chArray2 = new char[] { Convert.ToChar("#") };
                            string[] strArray2 = strArray[i - 1].Split(chArray2);
                            paramna = "L" + liftNumber + strArray2[0];
                            str9 = Convert.ToString((double) (Convert.ToInt32(Convert.ToDouble(this.prman.GetParamValFRM(paramna, kesitKODU))) + (num * Convert.ToDouble(strArray2[1].Replace(".", ",")))));
                            this.prman.chParamVal(paramna, str9);
                            this.xx.upexcel(strArray2[0], str9, liftNumber, tahrik);
                        }
                    }
                    Entity entity = null;
                    clsMLift mainLift = new clsMLift();
                    this.ReadAllData(liftNumber, kesitKODU).LiftNum = Convert.ToInt32(liftNumber);
                    entity = FObject("Kabin", liftNumber, "KK");
                    if (entity != null)
                    {
                        mainLift = null;
                        mainLift = this.ReadAllData(liftNumber, "KK");
                        mainLift.KesitKodu = "KK";
                        mainLift.LiftNum = Convert.ToInt32(liftNumber);
                        Transaction transaction3 = document.get_TransactionManager().StartTransaction();
                        using (transaction3)
                        {
                            mainLift.BasePoint = transaction3.GetObject(entity.get_ObjectId(), 0).get_Position();
                            transaction3.Commit();
                        }
                        this.LiftDraw2(mainLift, false);
                    }
                    entity = FObject("BUTUNKUYU", "1", "KD");
                    if (entity != null)
                    {
                        mainLift = null;
                        mainLift = this.ReadAllData(liftNumber, "KD");
                        mainLift.KesitKodu = "KD";
                        mainLift.LiftNum = Convert.ToInt32(liftNumber);
                        Transaction transaction5 = document.get_TransactionManager().StartTransaction();
                        using (transaction5)
                        {
                            mainLift.BasePoint = transaction5.GetObject(entity.get_ObjectId(), 0).get_Position();
                            transaction5.Commit();
                        }
                        this.LiftDraw2(mainLift, false);
                    }
                    entity = FObject("TK-AA", "1", "TK-AA");
                    if (entity != null)
                    {
                        mainLift = null;
                        mainLift = this.ReadAllData(liftNumber, "TK-AA");
                        mainLift.KesitKodu = "TK-AA";
                        mainLift.LiftNum = Convert.ToInt32(liftNumber);
                        Transaction transaction7 = document.get_TransactionManager().StartTransaction();
                        using (transaction7)
                        {
                            mainLift.BasePoint = transaction7.GetObject(entity.get_ObjectId(), 0).get_Position();
                            transaction7.Commit();
                        }
                        this.LiftDraw2(mainLift, false);
                    }
                    entity = FObject("TK-BB", "1", "TK-BB");
                    if (entity != null)
                    {
                        mainLift = null;
                        mainLift = this.ReadAllData(liftNumber, "TK-BB");
                        mainLift.KesitKodu = "TK-BB";
                        mainLift.LiftNum = Convert.ToInt32(liftNumber);
                        Transaction transaction9 = document.get_TransactionManager().StartTransaction();
                        using (transaction9)
                        {
                            mainLift.BasePoint = transaction9.GetObject(entity.get_ObjectId(), 0).get_Position();
                            transaction9.Commit();
                        }
                        this.LiftDraw2(mainLift, false);
                    }
                    entity = null;
                    entity = FObject("MDEksenYan", "1", "MD");
                    if (entity == null)
                    {
                        entity = FObject("MDEksenSag", "1", "MD");
                    }
                    if (entity == null)
                    {
                        entity = FObject("MDEksenArka", "1", "MD");
                    }
                    if (entity != null)
                    {
                        mainLift = null;
                        mainLift = this.ReadAllData(liftNumber, "MD");
                        mainLift.KesitKodu = "MD";
                        mainLift.LiftNum = Convert.ToInt32(liftNumber);
                        Transaction transaction11 = document.get_TransactionManager().StartTransaction();
                        using (transaction11)
                        {
                            mainLift.BasePoint = transaction11.GetObject(entity.get_ObjectId(), 0).get_Position();
                            transaction11.Commit();
                        }
                        this.LiftDraw2(mainLift, false);
                    }
                    Application.SetSystemVariable("DIMLFAC", 1.0);
                    entity = null;
                }
            }
        }

        private double DegreeToRadian(double angle) => 
            ((3.1415926535897931 * angle) / 180.0);

        public void DelAllObject()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = HostApplicationServices.get_WorkingDatabase();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                foreach (ObjectId id in record)
                {
                    Entity entity = transaction.GetObject(id, 1, false, true);
                    entity.UpgradeOpen();
                    entity.Erase();
                }
                transaction.Commit();
            }
        }

        public void DeleteParam(string vtParName)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
        }

        public void denemerep(ArrayList gelen, ArrayList donen, string hesaptip = "Hesap811-90")
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database db = document.get_Database();
            Editor editor = document.get_Editor();
            string str = "";
            Entity entity = null;
            Point3d insertPoint = new Point3d();
            Func<ObjectId, DBText> <>9__1;
            using (Transaction tr = db.get_TransactionManager().StartTransaction())
            {
                entity = FObject("Check", "1", "0");
                if (entity != null)
                {
                    BlockReference reference2 = tr.GetObject(entity.get_ObjectId(), 0);
                    insertPoint = new Point3d(reference2.get_Position().get_X(), -100.0, 0.0);
                }
                else
                {
                    insertPoint = new Point3d(0.0, 0.0, 0.0);
                }
                BlockReference reference = null;
                reference = this.InsertBlock(db, tr, insertPoint, hesaptip, 1.0, null, null, null);
                reference.ExplodeToOwnerSpace();
                reference.Erase();
                for (int i = 0; i < gelen.Count; i++)
                {
                    document.get_TransactionManager().EnableGraphicsFlush(true);
                    BlockTable table = tr.GetObject(db.get_BlockTableId(), 0);
                    table.UpgradeOpen();
                    string textPattern = gelen[i].ToString();
                    BlockTableRecord source = tr.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 1);
                    source.UpgradeOpen();
                    List<DBText> list = (from txt in (from id in source.Cast<ObjectId>()
                        where id.get_ObjectClass().get_DxfName().ToUpper() == "TEXT"
                        select id).Select<ObjectId, DBText>((Func<ObjectId, DBText>) (<>9__1 ?? (<>9__1 = id => (DBText) tr.GetObject(id, 0))))
                        where Regex.IsMatch(txt.get_TextString(), textPattern, RegexOptions.IgnoreCase)
                        select txt).ToList<DBText>();
                    for (int j = 0; j < list.Count; j++)
                    {
                        try
                        {
                            BlockTableRecord record2 = tr.GetObject(list[j].get_ObjectId(), 1) as BlockTableRecord;
                            str = list[j].get_TextString();
                            string str2 = str.Replace(gelen[i].ToString(), donen[i].ToString());
                            if (list[j].get_ObjectId().get_ObjectClass().IsDerivedFrom(RXObject.GetClass(typeof(DBText))))
                            {
                                DBText text = tr.GetObject(list[j].get_ObjectId(), 0) as DBText;
                                if (text.get_TextString() == str)
                                {
                                    text.UpgradeOpen();
                                    text.set_TextString(str2);
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Debug.WriteLine(exception.ToString() + "----> " + str);
                        }
                    }
                }
                tr.get_TransactionManager().QueueForGraphicsFlush();
                document.get_TransactionManager().FlushGraphics();
                editor.Regen();
                tr.Commit();
            }
        }

        [CommandMethod("DetachBadXrefs")]
        public void detachXREFs()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = database.get_BlockTableId().GetObject(0);
                foreach (ObjectId id2 in table)
                {
                    BlockTableRecord record = id2.GetObject(0);
                    if (record.get_IsFromExternalReference())
                    {
                        database.DetachXref(id2);
                    }
                }
                transaction.Commit();
            }
        }

        [CommandMethod("detayaa")]
        public void detayaa()
        {
            this.DALL();
            if (!this.prman.Created)
            {
                this.prman.aadd = this;
                this.prman.destandcrash();
            }
            this.LD("TK-AA", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        [CommandMethod("detaybb")]
        public void detaybb()
        {
            this.DALL();
            if (!this.prman.Created)
            {
                this.prman.aadd = this;
                this.prman.destandcrash();
            }
            this.LD("TK-BB", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        [CommandMethod("detaykd")]
        public void detaykd()
        {
            this.DALL();
            if (!this.prman.Created)
            {
                this.prman.aadd = this;
                this.prman.destandcrash();
            }
            this.LD("KD", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        [CommandMethod("detaykk")]
        public void detaykk()
        {
            this.DALL();
            if (!this.prman.Created)
            {
                this.prman.aadd = this;
                this.prman.destandcrash();
            }
            this.LD("KK", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        [CommandMethod("detaymd")]
        public void detaymd()
        {
            this.DALL();
            if (!this.prman.Created)
            {
                this.prman.aadd = this;
                this.prman.destandcrash();
            }
            this.LD("MD", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        public void dimdene(string KesitKodu = "KK", string LiftNumber = "1")
        {
            Entity vtEnt = null;
            Entity entity2 = null;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database dbE = document.get_Database();
                    DBObjectCollection objects = new DBObjectCollection();
                    Entity entity3 = null;
                    AlignedDimension dimension = null;
                    Point3d pointd = new Point3d();
                    Point3d pointd2 = new Point3d();
                    Point3d pointd3 = new Point3d();
                    using (dbE)
                    {
                        using (Transaction transaction = dbE.get_TransactionManager().StartTransaction())
                        {
                            vtEnt = FObject("DIMDYN", LiftNumber, KesitKodu);
                            if (vtEnt != null)
                            {
                                DynamicBlockReferencePropertyCollection propertys = transaction.GetObject(vtEnt.get_ObjectId(), 0).get_DynamicBlockReferencePropertyCollection();
                                foreach (DynamicBlockReferenceProperty property in propertys)
                                {
                                    entity2 = null;
                                    string str = property.get_PropertyName();
                                    if (((((str == "Origin") || (str.LastIndexOf("P1X") != -1)) || ((str.LastIndexOf("P1Y") != -1) || (str.LastIndexOf("P2X") != -1))) || ((str.LastIndexOf("P2Y") != -1) || (str.LastIndexOf("XLX") != -1))) || (str.LastIndexOf("XLY") != -1))
                                    {
                                        entity2 = null;
                                    }
                                    else
                                    {
                                        entity2 = FObjectDIM(str, LiftNumber, KesitKodu);
                                    }
                                    if (entity2 != null)
                                    {
                                        entity3 = transaction.GetObject(entity2.get_ObjectId(), 1, false, true);
                                        entity3.UpgradeOpen();
                                        dimension = entity3;
                                        pointd = new Point3d(Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P1X")), Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P1Y")), 0.0);
                                        pointd2 = new Point3d(Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P2X")), Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P2Y")), 0.0);
                                        pointd3 = new Point3d();
                                        dimension.set_Dimscale(Convert.ToDouble(Application.GetSystemVariable("DIMSCALE")));
                                        dimension.set_Dimlfac(Convert.ToDouble(Application.GetSystemVariable("DIMLFAC")));
                                        dimension.set_XLine1Point(pointd);
                                        dimension.set_XLine2Point(pointd2);
                                        if (pointd.get_X() == pointd2.get_X())
                                        {
                                            if (pointd.get_Y() > pointd2.get_Y())
                                            {
                                                pointd3 = new Point3d(Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLX")), pointd.get_Y() - Math.Abs((double) ((pointd2.get_Y() - pointd.get_Y()) / 2.0)), 0.0);
                                            }
                                            else
                                            {
                                                pointd3 = new Point3d(Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLX")), pointd.get_Y() + Math.Abs((double) ((pointd2.get_Y() - pointd.get_Y()) / 2.0)), 0.0);
                                            }
                                        }
                                        else if (pointd.get_X() > pointd2.get_X())
                                        {
                                            pointd3 = new Point3d(pointd.get_X() - Math.Abs((double) ((pointd2.get_X() - pointd.get_X()) / 2.0)), Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLY")), 0.0);
                                        }
                                        else
                                        {
                                            pointd3 = new Point3d(pointd.get_X() + Math.Abs((double) ((pointd2.get_X() - pointd.get_X()) / 2.0)), Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLY")), 0.0);
                                        }
                                        dimension.set_TextPosition(pointd3);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void dimdene2(string LiftNumber, string KesitKodu, Point3d BasePoint, bool OldNew)
        {
            Entity vtEnt = null;
            Entity entity2 = null;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database dbE = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    Entity entity3 = null;
                    AlignedDimension dimension = null;
                    Point3d pointd = new Point3d();
                    Point3d pointd2 = new Point3d();
                    Point3d pointd3 = new Point3d();
                    using (document.LockDocument())
                    {
                        using (Transaction transaction = dbE.get_TransactionManager().StartTransaction())
                        {
                            vtEnt = FObject("DIMDYN" + KesitKodu, LiftNumber, KesitKodu);
                            if (vtEnt != null)
                            {
                                DynamicBlockReferencePropertyCollection propertys = transaction.GetObject(vtEnt.get_ObjectId(), 0).get_DynamicBlockReferencePropertyCollection();
                                foreach (DynamicBlockReferenceProperty property in propertys)
                                {
                                    entity2 = null;
                                    string str = property.get_PropertyName().Trim();
                                    if (((((str != "Origin") && (str.LastIndexOf("P1X") == -1)) && ((str.LastIndexOf("P1Y") == -1) && (str.LastIndexOf("P2X") == -1))) && ((str.LastIndexOf("P2Y") == -1) && (str.LastIndexOf("XLX") == -1))) && (str.LastIndexOf("XLY") == -1))
                                    {
                                        entity2 = FObjectDIM(str, LiftNumber.Trim(), KesitKodu.Trim());
                                        if (entity2 != null)
                                        {
                                            entity3 = transaction.GetObject(entity2.get_ObjectId(), 0, false, true);
                                            dimension = entity3;
                                            pointd = new Point3d(BasePoint.get_X() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P1X")), BasePoint.get_Y() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P1Y")), 0.0);
                                            pointd2 = new Point3d(BasePoint.get_X() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P2X")), BasePoint.get_Y() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P2Y")), 0.0);
                                            pointd3 = new Point3d();
                                            dimension.UpgradeOpen();
                                            dimension.set_XLine1Point(pointd);
                                            dimension.set_XLine2Point(pointd2);
                                            if (OldNew)
                                            {
                                                dimension.set_Dimscale(Convert.ToDouble(Application.GetSystemVariable("DIMSCALE")));
                                                dimension.set_Dimlfac(Convert.ToDouble(Application.GetSystemVariable("DIMLFAC")));
                                            }
                                            if (dimension.get_Measurement() == 0.0)
                                            {
                                                dimension.Erase();
                                            }
                                            else
                                            {
                                                if (pointd.get_X() == pointd2.get_X())
                                                {
                                                    if (pointd.get_Y() > pointd2.get_Y())
                                                    {
                                                        double introduced29 = pointd2.get_Y();
                                                        pointd3 = new Point3d(Convert.ToDouble((double) (BasePoint.get_X() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLX")))), introduced29 + Math.Abs((double) ((pointd2.get_Y() - pointd.get_Y()) / 2.0)), 0.0);
                                                    }
                                                    else
                                                    {
                                                        pointd3 = new Point3d(Convert.ToDouble((double) (BasePoint.get_X() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLX")))), pointd.get_Y() + ((pointd2.get_Y() - pointd.get_Y()) / 2.0), 0.0);
                                                    }
                                                }
                                                else if (pointd.get_X() > pointd2.get_X())
                                                {
                                                    double introduced30 = pointd2.get_X();
                                                    pointd3 = new Point3d(introduced30 + Math.Abs((double) ((pointd2.get_X() - pointd.get_X()) / 2.0)), BasePoint.get_Y() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLY")), 0.0);
                                                }
                                                else
                                                {
                                                    pointd3 = new Point3d(pointd.get_X() + Math.Abs((double) ((pointd2.get_X() - pointd.get_X()) / 2.0)), BasePoint.get_Y() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLY")), 0.0);
                                                }
                                                dimension.set_TextPosition(pointd3);
                                                dimension.RecomputeDimensionBlock(true);
                                                entity2 = null;
                                            }
                                        }
                                    }
                                }
                            }
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(LiftNumber + "-" + KesitKodu + "-> CATCH HATA ->" + exception.ToString());
            }
        }

        [CommandMethod("dimdene")]
        public void dimdene2x()
        {
            Point3d pointd = new Point3d(0.0, 0.0, 0.0);
            string str = "1";
            string str2 = "KK";
            Entity vtEnt = null;
            Entity entity2 = null;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database dbE = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    Entity entity3 = null;
                    AlignedDimension dimension = null;
                    Point3d pointd2 = new Point3d();
                    Point3d pointd3 = new Point3d();
                    Point3d pointd4 = new Point3d();
                    using (dbE)
                    {
                        using (Transaction transaction = document.get_TransactionManager().StartTransaction())
                        {
                            vtEnt = FObject("DIMDYN", str, str2);
                            if (vtEnt != null)
                            {
                                DynamicBlockReferencePropertyCollection propertys = transaction.GetObject(vtEnt.get_ObjectId(), 0).get_DynamicBlockReferencePropertyCollection();
                                foreach (DynamicBlockReferenceProperty property in propertys)
                                {
                                    entity2 = null;
                                    string str3 = property.get_PropertyName().Trim();
                                    if (((((str3 != "Origin") && (str3.LastIndexOf("P1X") == -1)) && ((str3.LastIndexOf("P1Y") == -1) && (str3.LastIndexOf("P2X") == -1))) && ((str3.LastIndexOf("P2Y") == -1) && (str3.LastIndexOf("XLX") == -1))) && (str3.LastIndexOf("XLY") == -1))
                                    {
                                        entity2 = FObjectDIM(str3, str, str2);
                                        if (entity2 != null)
                                        {
                                            entity3 = transaction.GetObject(entity2.get_ObjectId(), 0, false, true);
                                            dimension = entity3;
                                            pointd2 = new Point3d(pointd.get_X() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P1X")), pointd.get_Y() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P1Y")), 0.0);
                                            pointd3 = new Point3d(pointd.get_X() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P2X")), pointd.get_Y() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "P2Y")), 0.0);
                                            pointd4 = new Point3d();
                                            dimension.UpgradeOpen();
                                            dimension.set_XLine1Point(pointd2);
                                            dimension.set_XLine2Point(pointd3);
                                            dimension.set_Dimscale(Convert.ToDouble(Application.GetSystemVariable("DIMSCALE")));
                                            dimension.set_Dimlfac(Convert.ToDouble(Application.GetSystemVariable("DIMLFAC")));
                                            if (pointd2.get_X() == pointd3.get_X())
                                            {
                                                if (pointd2.get_Y() > pointd3.get_Y())
                                                {
                                                    double introduced30 = Convert.ToDouble((double) (pointd.get_X() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLX"))));
                                                    pointd4 = new Point3d(introduced30, (pointd.get_Y() + pointd2.get_Y()) - Math.Abs((double) ((pointd3.get_Y() - pointd2.get_Y()) / 2.0)), 0.0);
                                                }
                                                else
                                                {
                                                    double introduced31 = Convert.ToDouble((double) (pointd.get_X() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLX"))));
                                                    pointd4 = new Point3d(introduced31, (pointd.get_Y() + pointd2.get_Y()) + Math.Abs((double) ((pointd3.get_Y() - pointd2.get_Y()) / 2.0)), 0.0);
                                                }
                                            }
                                            else if (pointd2.get_X() > pointd3.get_X())
                                            {
                                                pointd4 = new Point3d((pointd.get_X() + pointd2.get_X()) - Math.Abs((double) ((pointd3.get_X() - pointd2.get_X()) / 2.0)), pointd.get_Y() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLY")), 0.0);
                                            }
                                            else
                                            {
                                                pointd4 = new Point3d((pointd.get_X() + pointd2.get_X()) + Math.Abs((double) ((pointd3.get_X() - pointd2.get_X()) / 2.0)), pointd.get_Y() + Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, property.get_PropertyName() + "XLY")), 0.0);
                                            }
                                            dimension.set_TextPosition(pointd4);
                                            entity2 = null;
                                        }
                                    }
                                }
                            }
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private string Donennumdeger(string paramname, DataTable gelendata)
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

        private vtLift dtta(string blockadi, string LiftNumber)
        {
            vtLift lift = new vtLift {
                BlkName = blockadi
            };
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select [id],[bmblockname],[BlkInsName],[XData] from [mainblocks$] where [bmblockname]='" + blockadi + "'", "");
                    lift.BlkInsName = table.Rows[0]["BlkInsName"].ToString();
                    lift.XData = table.Rows[0]["XData"].ToString();
                    DataTable table2 = new DataTable();
                    table2 = this.xx.dtta("select [ison],[BlkName],[BlkString] from [BlkPar$] where [ison]=" + table.Rows[0]["id"].ToString(), "");
                    if (table2.Rows.Count > 0)
                    {
                        for (int i = 0; i < table2.Rows.Count; i++)
                        {
                            BlkPar item = new BlkPar {
                                BlkName = table2.Rows[i]["BlkName"].ToString(),
                                BlkString = table2.Rows[i]["BlkString"].ToString()
                            };
                            lift.BlkList.Add(item);
                        }
                        DataTable table3 = new DataTable();
                        table3 = this.xx.dtta("select [ParamName],[ParamValue] from Paramlist where [ison]=" + table2.Rows[0]["ison"].ToString(), "");
                        if (table3.Rows.Count <= 0)
                        {
                            return lift;
                        }
                        for (int j = 0; j < table3.Rows.Count; j++)
                        {
                            List<ParamList> list = new List<ParamList>();
                            ParamList list2 = new ParamList {
                                ParamName = table3.Rows[j]["ParamName"].ToString(),
                                ParamValue = table3.Rows[j]["ParamValue"].ToString(),
                                plRename = true
                            };
                            lift.BlkParamList.Add(list2);
                        }
                    }
                    return lift;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return lift;
        }

        [CommandMethod("EA")]
        public void EA()
        {
            this.DALL();
            this.xx.SetNumValue("TipKodu", "EA", "1");
        }

        private static void EditBlockTag(string blockName, string attName, string newValue)
        {
            Database database = HostApplicationServices.get_WorkingDatabase();
            Editor editor = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                if (table != null)
                {
                    BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                    if (record != null)
                    {
                        foreach (ObjectId id in record)
                        {
                            BlockReference reference = transaction.GetObject(id, 0) as BlockReference;
                            if ((reference != null) && reference.get_Name().Equals(blockName, StringComparison.CurrentCultureIgnoreCase))
                            {
                                foreach (ObjectId id2 in reference.get_AttributeCollection())
                                {
                                    AttributeReference reference2 = transaction.GetObject(id2, 0) as AttributeReference;
                                    if ((reference2 != null) && reference2.get_Tag().Equals(attName, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        reference2.UpgradeOpen();
                                        reference2.set_TextString(newValue);
                                    }
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
        }

        [CommandMethod("blockattdeis2")]
        public void EditBlockTag2()
        {
            string str = "A";
            string str2 = "ONSPRDCTN";
            Database database = HostApplicationServices.get_WorkingDatabase();
            ObjectId id = FObject("Kabin", "1", "0").get_ObjectId();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockReference reference = transaction.GetObject(id, 1);
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(reference.get_BlockTableRecord(), 1);
                foreach (ObjectId id2 in reference.get_AttributeCollection())
                {
                    AttributeReference reference2 = transaction.GetObject(id2, 0) as AttributeReference;
                    if ((reference2 != null) && reference2.get_Tag().Equals(str, StringComparison.CurrentCultureIgnoreCase))
                    {
                        reference2.UpgradeOpen();
                        reference2.set_TextString(str2);
                    }
                }
                transaction.Commit();
            }
        }

        [CommandMethod("EAEK")]
        public void ElkAnsEkle()
        {
            this.prman.aadd = this;
            this.prman.asnadedi = 2;
            this.prman.destandcrash();
            this.mn2.AsansorSayisi = 2;
            this.mn2.AsansorTipi = "EA";
            this.mn2.FormMyData = this.LiftDataOku("2");
            this.mn2.ShowDialog();
            this.LiftDataYaz(this.mn2.FormMyData, "2");
            this.DALL();
            this.prman.aadd = this;
            this.prman.asnadedi = 2;
            this.prman.destandcrash();
            this.LD("KK", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        [CommandMethod("EraseLayer")]
        public static void EraseLayer()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                string str = "ABC";
                if (table.Has(str))
                {
                    ObjectIdCollection ids = new ObjectIdCollection();
                    ids.Add(table.get_Item(str));
                    database.Purge(ids);
                    if (ids.get_Count() > 0)
                    {
                        LayerTableRecord record = transaction.GetObject(ids.get_Item(0), 1) as LayerTableRecord;
                        try
                        {
                            record.Erase(true);
                            transaction.Commit();
                        }
                        catch (Exception exception)
                        {
                            Application.ShowAlertDialog("Error:\n" + exception.Message);
                        }
                    }
                }
            }
        }

        public bool ExplodeBlockByNameCommand(string blockToExplode)
        {
            bool flag = true;
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Editor editor = document.get_Editor();
            Database database = document.get_Database();
            TransactionManager manager = document.get_TransactionManager();
            using (Transaction transaction = manager.StartTransaction())
            {
                try
                {
                    try
                    {
                        BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0);
                        object[] objArray1 = new object[] { blockToExplode };
                        editor.WriteMessage("\nProcessing {0}", objArray1);
                        if (table.Has(blockToExplode))
                        {
                            ObjectId id = table.get_Item(blockToExplode);
                            ObjectIdCollection blockReferenceIds = transaction.GetObject(id, 0).GetBlockReferenceIds(true, true);
                            foreach (ObjectId id2 in blockReferenceIds)
                            {
                                DBObjectCollection objects = new DBObjectCollection();
                                Entity entity = transaction.GetObject(id2, 0);
                                entity.Explode(objects);
                                object[] objArray2 = new object[] { blockToExplode };
                                editor.WriteMessage("\nExploded an Instance of {0}", objArray2);
                                entity.UpgradeOpen();
                                entity.Erase();
                                BlockTableRecord record2 = transaction.GetObject(database.get_CurrentSpaceId(), 1);
                                foreach (DBObject obj2 in objects)
                                {
                                    Entity entity2 = obj2;
                                    record2.AppendEntity(entity2);
                                    transaction.AddNewlyCreatedDBObject(entity2, true);
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        editor.WriteMessage("\nSomething went wrong");
                        flag = false;
                    }
                }
                finally
                {
                }
                editor.WriteMessage("\n");
                transaction.Dispose();
                manager.Dispose();
            }
            return flag;
        }

        [CommandMethod("explodeRef")]
        public static void explodeRef(BlockReference blockRef)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                DBObjectCollection objects = new DBObjectCollection();
                blockRef.Explode(objects);
                BlockTableRecord record = transaction.GetObject(database.get_CurrentSpaceId(), 1);
                foreach (DBObject obj2 in objects)
                {
                    if (obj2 is Entity)
                    {
                        record.AppendEntity((Entity) obj2);
                        transaction.AddNewlyCreatedDBObject(obj2, true);
                    }
                }
                transaction.Commit();
            }
        }

        [CommandMethod("FindMyLayer")]
        public static void FindMyLayer()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                if (!table.Has("MyLayer"))
                {
                    document.get_Editor().WriteMessage("\n'MyLayer' does not exist");
                }
                else
                {
                    document.get_Editor().WriteMessage("\n'MyLayer' exists");
                }
            }
        }

        public static Entity FObject(string xdata1, string xdata2, string xdata3)
        {
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                Database database = HostApplicationServices.get_WorkingDatabase();
                using (database)
                {
                    using (Transaction transaction = database.get_TransactionManager().StartTransaction())
                    {
                        BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                        BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                        foreach (ObjectId id in record)
                        {
                            Entity entity2 = transaction.GetObject(id, 0);
                            if (entity2.get_ObjectId().get_ObjectClass().get_DxfName() == "INSERT")
                            {
                                ResultBuffer xDataForApplication = entity2.GetXDataForApplication("I");
                                if (xDataForApplication != null)
                                {
                                    TypedValue[] valueArray = xDataForApplication.AsArray();
                                    if ((((valueArray[0].get_Value().ToString() == "I") && (valueArray[1].get_Value().ToString() == xdata1)) && (valueArray[2].get_Value().ToString() == xdata2)) && (valueArray[3].get_Value().ToString() == xdata3))
                                    {
                                        return entity2;
                                    }
                                    xDataForApplication.Dispose();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
            return null;
        }

        public static Entity FObjectDIM(string xdata1, string xdata2, string xdata3)
        {
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                Database database = HostApplicationServices.get_WorkingDatabase();
                using (database)
                {
                    using (Transaction transaction = database.get_TransactionManager().StartTransaction())
                    {
                        BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                        BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                        foreach (ObjectId id in record)
                        {
                            Entity entity2 = transaction.GetObject(id, 0);
                            if (entity2.get_ObjectId().get_ObjectClass().get_DxfName() == "DIMENSION")
                            {
                                ResultBuffer xDataForApplication = entity2.GetXDataForApplication("DIM");
                                if (xDataForApplication != null)
                                {
                                    TypedValue[] source = xDataForApplication.AsArray();
                                    if ((source.Count<TypedValue>() == 4) && ((((source[0].get_Value().ToString() == "DIM") && (source[1].get_Value().ToString() == xdata1)) && (source[2].get_Value().ToString() == xdata2)) && (source[3].get_Value().ToString() == xdata3)))
                                    {
                                        return entity2;
                                    }
                                    xDataForApplication.Dispose();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
            return null;
        }

        [CommandMethod("FreezeLayer")]
        public static void FreezeLayer()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                string str = "ABC";
                if (!table.Has(str))
                {
                    using (LayerTableRecord record = new LayerTableRecord())
                    {
                        record.set_Name(str);
                        table.UpgradeOpen();
                        table.Add(record);
                        transaction.AddNewlyCreatedDBObject(record, true);
                        record.set_IsFrozen(true);
                    }
                }
                else
                {
                    (transaction.GetObject(table.get_Item(str), 1) as LayerTableRecord).set_IsFrozen(true);
                }
                transaction.Commit();
            }
        }

        [CommandMethod("HAMDDegerSet")]
        public void funcHAMDDegerSet()
        {
            string liftNumber = "1";
            PromptKeywordOptions options = new PromptKeywordOptions("\nTAHRİK Y\x00d6N\x00dcN\x00dc SE\x00c7İN :");
            options.set_AllowNone(false);
            options.get_Keywords().Add("SOL");
            options.get_Keywords().Add("SAG");
            options.get_Keywords().Add("ARKA");
            PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(options);
            if (keywords.get_Status() == 0x13ec)
            {
                PromptKeywordOptions options2 = new PromptKeywordOptions("\nMAKİNE DAİRESİ YERİNİ SE\x00c7İN :");
                options2.set_AllowNone(false);
                options2.get_Keywords().Add("SOL");
                options2.get_Keywords().Add("SAG");
                PromptResult result2 = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(options2);
                if (result2.get_Status() == 0x13ec)
                {
                    this.HAMDDegerSet(result2.get_StringResult(), keywords.get_StringResult(), "3000", "KuyuDer", liftNumber);
                }
            }
        }

        public void gecikme(int saniye)
        {
            saniye = (saniye + Convert.ToInt32(DateTime.Now.Second)) % 60;
            while (saniye != DateTime.Now.Second)
            {
            }
        }

        public string GetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, string propname)
        {
            BlockReference reference = tr.GetObject(vtEnt.get_ObjectId(), 0);
            if (reference != null)
            {
                DynamicBlockReferencePropertyCollection propertys = reference.get_DynamicBlockReferencePropertyCollection();
                foreach (DynamicBlockReferenceProperty property in propertys)
                {
                    if (property.get_PropertyName() == propname)
                    {
                        return Convert.ToString(property.get_Value());
                    }
                }
            }
            return "0";
        }

        private string GetGirisValue(string ParamName, string LiftNumber)
        {
            string str = null;
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select ParamName,ParamValue from `Giris" + LiftNumber + "` where ParamName='" + ParamName + "'", "");
                    if (table.Rows.Count > 0)
                    {
                        str = table.Rows[0]["ParamValue"].ToString();
                    }
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return str;
        }

        public clsMainLift GetLiftData(int LiftNumber)
        {
            clsMainLift lift = new clsMainLift();
            structTablist tablist = new structTablist();
            vtGroup group = new vtGroup();
            string liftNumber = Convert.ToString(LiftNumber);
            structTahrikTip tahrikTip = new structTahrikTip();
            if (LiftNumber == 1)
            {
                tahrikTip.TipKodu = "EA";
                tahrikTip.TahrikKodu = "DA";
                tahrikTip.YonKodu = "SAG";
            }
            if (LiftNumber == 2)
            {
                tahrikTip.TipKodu = "EA";
                tahrikTip.TahrikKodu = "DA";
                tahrikTip.YonKodu = "SOL";
            }
            lift.LiftNum = LiftNumber;
            tablist.TipKodu = tahrikTip.TipKodu;
            tablist.TahrikKodu = tahrikTip.TahrikKodu;
            tablist.YonKodu = tahrikTip.YonKodu;
            lift.Tablist = tablist;
            lift.TahrikYonu = tahrikTip.YonKodu;
            switch (tahrikTip.TipKodu)
            {
                case "EA":
                    group.KabinBlok = this.ReadData("Kabin", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.KabinRayBlok = this.ReadData("KabinRay", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.KapiBlok = this.ReadData("Kapi", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.SinirBlok = this.ReadData("KabinBase", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.AgirlikBlok = this.ReadData("AgrButun", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.AgrUstBlok = this.ReadData("AgrUst", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.AgrRayBlok = this.ReadData("AgrRay", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    switch (tahrikTip.TahrikKodu)
                    {
                        case "MDDUZ":
                            group.AgrUstKasnak = this.ReadData("AgrUstKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                            group.KabinAltKasnakBlok = this.ReadData("KabinAltKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                            break;

                        case "MDCAP":
                            group.AgrUstKasnak = this.ReadData("AgrUstKasnak", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                            group.CaprazBlok = this.ReadData("Capraz", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                            break;
                    }
                    switch (tahrikTip.YonKodu)
                    {
                        case "SOL":
                        case "SAG":
                        {
                            string tahrikKodu = tahrikTip.TahrikKodu;
                            if ((tahrikKodu == "DA") || (tahrikKodu == "MDDUZ"))
                            {
                            }
                            break;
                        }
                    }
                    break;

                case "HA":
                    group.KabinBlok = this.ReadData("Kabin", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.KapiBlok = this.ReadData("Kapi", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.HASemerBlok = this.ReadData("HidrolikSemer", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    group.HAEksenBlok = this.ReadData("HidrolikEksen", liftNumber, tahrikTip.TipKodu, tahrikTip.TahrikKodu, tahrikTip.YonKodu);
                    break;
            }
            lift.BasePoint = new Point3d(0.0, 0.0, 0.0);
            lift.BlokGrup = group;
            lift.VarGrup = this.ReadVarGrup(tahrikTip, Convert.ToString(lift.LiftNum));
            lift.DimGrup = this.ReadDimGrup(tahrikTip, Convert.ToString(lift.LiftNum));
            return lift;
        }

        public string GetNumValue(string ParamName, string LiftNumber)
        {
            string str = null;
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select ParamName,ParamValue from `Num" + LiftNumber + "` where ParamName='" + ParamName + "'", "");
                    if (table.Rows.Count > 0)
                    {
                        str = table.Rows[0]["ParamValue"].ToString();
                    }
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return str;
        }

        public string GetParam(List<ParamList> vtParamList, string FindParamName)
        {
            foreach (ParamList list in vtParamList)
            {
                if (list.ParamName == FindParamName)
                {
                    return list.ParamValue;
                }
            }
            return null;
        }

        public string GetParamValue(string vtParName)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            return "";
        }

        [CommandMethod("GetStringFromUser")]
        public static void GetStringFromUser()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            srthepler srthepler = new srthepler();
            PromptStringOptions options = new PromptStringOptions("\nEnter your name : ");
            options.set_AllowSpaces(true);
            PromptResult result = document.get_Editor().GetString(options);
            new PromptStringOptions("\nCompany Name : ").set_AllowSpaces(true);
            PromptResult result2 = document.get_Editor().GetString(options);
            if (result.get_StringResult() == "8920747942")
            {
                if (srthepler.intirnetvarmi())
                {
                    srthepler.scroleupdate("insert into ascad2017scr (sno,uuid,crid,sonktar,ok,FirmaAdi) values ('','" + srthepler.getuuid() + "','999',now(),'1','" + result2.get_StringResult() + "')", "");
                }
                else
                {
                    Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage("Internet not connected...");
                }
            }
            else
            {
                Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage("False value");
            }
        }

        private string GetTabValue(string TabName)
        {
            string str = null;
            List<structTahrikYon> list = new List<structTahrikYon>();
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select [TabName],[TabValue] from `TabList` where [TabName]='" + TabName + "'", "");
                    if (table.Rows.Count > 0)
                    {
                        str = table.Rows[0]["TabValue"].ToString();
                    }
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return str;
        }

        [CommandMethod("GXD")]
        public void GetXData()
        {
            this.DD();
        }

        [CommandMethod("GetXData")]
        public static void GetXData(Entity obj)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Editor editor = document.get_Editor();
            PromptEntityOptions options = new PromptEntityOptions("\nSelect entity: ");
            PromptEntityResult entity = editor.GetEntity(options);
            Transaction transaction = document.get_TransactionManager().StartTransaction();
            using (transaction)
            {
                DBObject obj2 = transaction.GetObject(entity.get_ObjectId(), 0);
                ResultBuffer buffer = obj.get_XData();
                if (buffer != null)
                {
                    TypedValue[] valueArray = buffer.AsArray();
                    buffer.Dispose();
                }
            }
        }

        [CommandMethod("HA")]
        public void HA()
        {
            this.DALL();
            this.xx.SetNumValue("TipKodu", "HA", "1");
            this.xx.SetNumValue("TahrikKodu", "DA", "1");
        }

        public void HAMDDegerSet(string MakYerSec, string TahrikYonSec, string HAMDGen, string HAMDDer, string LiftNumber)
        {
            switch (MakYerSec)
            {
                case "SOL":
                {
                    this.xx.SetNumValue("HAMDFlip", "1", LiftNumber);
                    this.xx.SetNumValue("HAMDX", "0", LiftNumber);
                    this.xx.SetNumValue("HAMDY", "0", LiftNumber);
                    this.xx.SetNumValue("HAMDDer", HAMDDer, LiftNumber);
                    this.xx.SetNumValue("HAMDGen", HAMDGen, LiftNumber);
                    string str2 = TahrikYonSec;
                    if (str2 != "SOL")
                    {
                        if (str2 == "SAG")
                        {
                            this.xx.SetNumValue("HUniteFlip", "0", LiftNumber);
                            this.xx.SetNumValue("MDHidrolikX", "0", LiftNumber);
                            this.xx.SetNumValue("MDHidrolikY", "HidrolikY", LiftNumber);
                            this.xx.SetNumValue("PistonDuvar", "PistonDuvI", LiftNumber);
                            break;
                        }
                        if (str2 == "ARKA")
                        {
                            this.xx.SetNumValue("HUniteFlip", "0", LiftNumber);
                            this.xx.SetNumValue("MDHidrolikX", "0", LiftNumber);
                            this.xx.SetNumValue("MDHidrolikY", "MDArkaY", LiftNumber);
                            this.xx.SetNumValue("PistonDuvar", "HidrolikX", LiftNumber);
                            break;
                        }
                    }
                    else
                    {
                        this.xx.SetNumValue("HUniteFlip", "0", LiftNumber);
                        this.xx.SetNumValue("MDHidrolikX", "0", LiftNumber);
                        this.xx.SetNumValue("MDHidrolikY", "HidrolikY", LiftNumber);
                        this.xx.SetNumValue("PistonDuvar", "PistonMer", LiftNumber);
                    }
                    break;
                }
                case "SAG":
                {
                    this.xx.SetNumValue("HAMDFlip", "0", LiftNumber);
                    this.xx.SetNumValue("HAMDX", "KuyuGen+DuvarKal", LiftNumber);
                    this.xx.SetNumValue("HAMDY", "0", LiftNumber);
                    this.xx.SetNumValue("HAMDDer", HAMDDer, LiftNumber);
                    this.xx.SetNumValue("HAMDGen", HAMDGen, LiftNumber);
                    string str3 = TahrikYonSec;
                    if (str3 != "SOL")
                    {
                        if (str3 == "SAG")
                        {
                            this.xx.SetNumValue("HUniteFlip", "1", LiftNumber);
                            this.xx.SetNumValue("MDHidrolikX", "KuyuGen", LiftNumber);
                            this.xx.SetNumValue("MDHidrolikY", "HidrolikY", LiftNumber);
                            this.xx.SetNumValue("PistonDuvar", "PistonMer", LiftNumber);
                            break;
                        }
                        if (str3 == "ARKA")
                        {
                            this.xx.SetNumValue("HUniteFlip", "1", LiftNumber);
                            this.xx.SetNumValue("MDHidrolikX", "KuyuGen", LiftNumber);
                            this.xx.SetNumValue("MDHidrolikY", "MDArkaY", LiftNumber);
                            this.xx.SetNumValue("PistonDuvar", "PistonDuvII", LiftNumber);
                            break;
                        }
                    }
                    else
                    {
                        this.xx.SetNumValue("HUniteFlip", "1", LiftNumber);
                        this.xx.SetNumValue("MDHidrolikX", "KuyuGen", LiftNumber);
                        this.xx.SetNumValue("MDHidrolikY", "HidrolikY", LiftNumber);
                        this.xx.SetNumValue("PistonDuvar", "PistonDuvI", LiftNumber);
                    }
                    break;
                }
            }
        }

        [CommandMethod("HY")]
        public void HY()
        {
            this.DALL();
            this.xx.SetNumValue("TahrikKodu", "HY", "1");
        }

        [CommandMethod("InsertBlock")]
        public void InsertBlock()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Editor().get_Document().get_Database();
            Transaction transaction = database.get_TransactionManager().StartTransaction();
            DocumentLock @lock = document.LockDocument();
            using (transaction)
            {
                using (@lock)
                {
                    BlockTableRecord record = transaction.GetObject(database.get_CurrentSpaceId(), 1);
                    BlockTableRecord record2 = new BlockTableRecord();
                    BlockTable table = transaction.GetObject(database.get_BlockTableId(), 1);
                    record2.set_Name("KuyuKabin");
                    record2.set_PathName(@"c:\asnproje\wblock.dwg");
                    table.Add(record2);
                    BlockReference reference = new BlockReference(new Point3d(0.0, 0.0, 0.0), record2.get_ObjectId());
                    record.AppendEntity(reference);
                    transaction.AddNewlyCreatedDBObject(record2, true);
                    transaction.AddNewlyCreatedDBObject(reference, true);
                    transaction.Commit();
                    transaction.Dispose();
                }
            }
        }

        public void InsertBlock(string FileName)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Editor().get_Document().get_Database();
            Transaction transaction = database.get_TransactionManager().StartTransaction();
            DocumentLock @lock = document.LockDocument();
            using (transaction)
            {
                using (@lock)
                {
                    BlockTableRecord record = transaction.GetObject(database.get_CurrentSpaceId(), 1);
                    BlockTableRecord record2 = new BlockTableRecord();
                    BlockTable table = transaction.GetObject(database.get_BlockTableId(), 1);
                    record2.set_Name(FileName);
                    record2.set_PathName(@"c:\asnproje\" + FileName + ".dwg");
                    table.Add(record2);
                    BlockReference reference = new BlockReference(new Point3d(0.0, 0.0, 0.0), record2.get_ObjectId());
                    record.AppendEntity(reference);
                    transaction.AddNewlyCreatedDBObject(record2, true);
                    transaction.AddNewlyCreatedDBObject(reference, true);
                    transaction.Commit();
                    transaction.Dispose();
                }
            }
        }

        private BlockReference InsertBlock(Database db, Transaction tr, Point3d insertPoint, string blockName, double BlkScale, string xData1 = null, string xData2 = null, string xData3 = null)
        {
            ObjectId id = ObjectId.get_Null();
            BlockTable table = tr.GetObject(db.get_BlockTableId(), 0) as BlockTable;
            BlockTableRecord record = tr.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
            BlockReference acBlkRef = new BlockReference(insertPoint, table.get_Item(blockName));
            acBlkRef.set_ScaleFactors(new Scale3d(BlkScale));
            id = record.AppendEntity(acBlkRef);
            tr.AddNewlyCreatedDBObject(acBlkRef, true);
            string[] collection = new string[] { "TAG1", "TAG2", "TAG3", "TAG4" };
            string[] textArray2 = new string[] { "Value #1", "Value #2", "Value #3", "Value #4" };
            ApplyAttibutes(db, tr, acBlkRef, new List<string>(collection), new List<string>(textArray2));
            if (xData1 > null)
            {
                SetXData(acBlkRef, xData1, xData2, xData3);
            }
            return acBlkRef;
        }

        private BlockReference InsertBlock(Database db, Transaction tr, Point3d insertPoint, string blockName, bool isUpdateProeprty, string xData1 = null, string xData2 = null, string xData3 = null, double Scale = 1.0)
        {
            ObjectId id = ObjectId.get_Null();
            BlockTable table = tr.GetObject(db.get_BlockTableId(), 0) as BlockTable;
            if (!table.Has(blockName))
            {
                Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage("\n" + blockName + " BLOK BULUNAMADI..");
                return null;
            }
            BlockTableRecord record = tr.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
            BlockReference bref = new BlockReference(insertPoint, table.get_Item(blockName));
            bref.set_ScaleFactors(new Scale3d(Scale));
            id = record.AppendEntity(bref);
            tr.AddNewlyCreatedDBObject(bref, true);
            BlockTableRecord record2 = tr.GetObject(bref.get_BlockTableRecord(), 0);
            if (record2.get_HasAttributeDefinitions())
            {
                foreach (ObjectId id2 in record2)
                {
                    Entity entity = tr.GetObject(id2, 0);
                    if (entity is AttributeDefinition)
                    {
                        AttributeDefinition definition = entity;
                        AttributeReference reference3 = new AttributeReference();
                        reference3.SetAttributeFromBlock(definition, bref.get_BlockTransform());
                        bref.get_AttributeCollection().AppendAttribute(reference3);
                        tr.AddNewlyCreatedDBObject(reference3, true);
                        reference3.set_TextString(definition.get_Tag());
                    }
                }
            }
            if (xData1 > null)
            {
                SetXData(bref, xData1, xData2, xData3);
            }
            return bref;
        }

        public BlockReference InsertBlock2(Database db, Transaction tr, Point3d insertPoint, string blockName, List<string> Gelen, List<string> Donen, string xData1 = null, string xData2 = null, string xData3 = null)
        {
            ObjectId id = ObjectId.get_Null();
            BlockTable table = tr.GetObject(db.get_BlockTableId(), 0) as BlockTable;
            BlockTableRecord record = tr.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
            BlockReference acBlkRef = new BlockReference(insertPoint, table.get_Item(blockName));
            id = record.AppendEntity(acBlkRef);
            tr.AddNewlyCreatedDBObject(acBlkRef, true);
            ApplyAttibutes(db, tr, acBlkRef, Gelen, Donen);
            if (xData1 > null)
            {
                SetXData(acBlkRef, xData1, xData2, xData3);
            }
            return acBlkRef;
        }

        [CommandMethod("IterateLayers")]
        public static void IterateLayers()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                foreach (ObjectId id in table)
                {
                    LayerTableRecord record = transaction.GetObject(id, 0) as LayerTableRecord;
                    document.get_Editor().WriteMessage("\n" + record.get_Name());
                }
            }
        }

        [CommandMethod("kabqphes")]
        public void kabqphes()
        {
            new tsestandart { 
                kabingenstr = this.prman.GetParamValFRM("L1KabinGen", "KK"),
                kabinderstr = this.prman.GetParamValFRM("L1KabinDer", "KK")
            }.Show();
        }

        [CommandMethod("KapiDegerSet")]
        public void KapiDegerSet()
        {
            myData liftData = new myData();
            liftData = this.LiftDataOku("1");
            liftData.KapiTip = "2TEL";
            liftData.Mentese = "SOL";
            PromptKeywordOptions options = new PromptKeywordOptions("\nKAPI TİPİNİ SE\x00c7İN :");
            options.set_AllowNone(false);
            options.get_Keywords().Add("TO-2TEL");
            options.get_Keywords().Add("TO-3TEL");
            options.get_Keywords().Add("TO-2MER");
            options.get_Keywords().Add("TO-4MER");
            options.get_Keywords().Add("YK-KRMK");
            options.get_Keywords().Add("CK-KPYK");
            options.get_Keywords().Add("YO-2TEL");
            options.get_Keywords().Add("YO-3TEL");
            options.get_Keywords().Add("YO-2MER");
            options.get_Keywords().Add("YO-4MER");
            options.get_Keywords().Add("CK-4MER");
            options.get_Keywords().Add("CK-2MER");
            PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(options);
            if (keywords.get_Status() == 0x13ec)
            {
                liftData.KapiTip = keywords.get_StringResult();
                PromptKeywordOptions options2 = new PromptKeywordOptions("\nKAPI TİPİNİ SE\x00c7İN :");
                options2.set_AllowNone(false);
                options2.get_Keywords().Add("SOL");
                options2.get_Keywords().Add("SAG");
                PromptResult result2 = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(options2);
                if (result2.get_Status() == 0x13ec)
                {
                    liftData.Mentese = result2.get_StringResult();
                    liftData = this.KapiDegerSet(liftData);
                    this.LiftDataYaz(liftData, "1");
                }
            }
        }

        public myData KapiDegerSet(myData LiftData)
        {
            decimal num6;
            decimal num = Convert.ToDecimal(LiftData.ToplamKalin);
            decimal num2 = Convert.ToDecimal(LiftData.OtoKabinEsik);
            decimal num3 = Convert.ToDecimal(LiftData.KizakKalin);
            decimal num4 = Convert.ToDecimal(LiftData.KasaDer);
            if (LiftData.Mentese == "SAG")
            {
                LiftData.MerdivenX = "0";
                LiftData.MerdivenFlip = "0";
                LiftData.KapiFlip = "1";
                LiftData.ButonX = "KapiXSOL+(KapiGen/2)+250";
            }
            else
            {
                LiftData.MerdivenX = "KuyuGen";
                LiftData.MerdivenFlip = "1";
                LiftData.KapiFlip = "0";
                LiftData.ButonX = "KapiXSOL-(KapiGen/2)-250";
            }
            string kapiTip = LiftData.KapiTip;
            uint num5 = <PrivateImplementationDetails>.ComputeStringHash(kapiTip);
            if (num5 <= 0x96b2daf9)
            {
                if (num5 <= 0x5773ff9c)
                {
                    switch (num5)
                    {
                        case 0xc33fd0b:
                            if (kapiTip == "YO-2TEL")
                            {
                                if (LiftData.Mentese == "SOL")
                                {
                                    LiftData.SagGirX = "20";
                                    LiftData.SagGirY = "45";
                                    LiftData.SolGirX = "0";
                                    LiftData.SolGirY = "0";
                                    num6 = num3 + num2;
                                    LiftData.SagKasa = num6.ToString();
                                    LiftData.SolKasa = num2.ToString();
                                }
                                else
                                {
                                    LiftData.SagGirX = "0";
                                    LiftData.SagGirY = "0";
                                    LiftData.SolGirX = "20";
                                    LiftData.SolGirY = "45";
                                    num6 = num3 + num2;
                                    LiftData.SolKasa = num6.ToString();
                                    LiftData.SagKasa = num2.ToString();
                                }
                                LiftData.DKapiYEksen = Convert.ToString((decimal) (num - num2));
                                LiftData.KabinYEksen = num.ToString();
                                LiftData.BlkInsName = "YO-2TEL";
                                return LiftData;
                            }
                            return LiftData;

                        case 0x3c531c95:
                            if (kapiTip == "YK-KRMK")
                            {
                                LiftData.SagGirX = "0";
                                LiftData.SagGirY = "0";
                                LiftData.SolGirX = "0";
                                LiftData.SolGirY = "0";
                                LiftData.SolKasa = Convert.ToString(num2);
                                LiftData.SagKasa = Convert.ToString(num2);
                                LiftData.KizakKalin = "0";
                                if (LiftData.Mentese == "SOL")
                                {
                                    LiftData.DKapiYEksen = Convert.ToString((decimal) (num - num2));
                                }
                                LiftData.KabinYEksen = num.ToString();
                                LiftData.BlkInsName = "YK-KRMK";
                                this.xx.oleupdate("UPDATE BLK SET BlkInsName='YOKRM-BB' WHERE id='252'", "");
                                return LiftData;
                            }
                            return LiftData;

                        case 0x5773ff9c:
                            if (kapiTip == "CK-2MER")
                            {
                                LiftData.SagGirX = "0";
                                LiftData.SagGirY = "0";
                                LiftData.SolGirX = "0";
                                LiftData.SolGirY = "0";
                                LiftData.SolKasa = Convert.ToString(num2);
                                LiftData.SagKasa = Convert.ToString(num2);
                                LiftData.DKapiYEksen = Convert.ToString((decimal) (num - num2));
                                LiftData.KabinYEksen = num.ToString();
                                LiftData.BlkInsName = "CK-2MER";
                                return LiftData;
                            }
                            return LiftData;
                    }
                    return LiftData;
                }
                switch (num5)
                {
                    case 0x80c3acbc:
                        if (kapiTip == "YO-4MER")
                        {
                            LiftData.SagGirX = "0";
                            LiftData.SagGirY = "0";
                            LiftData.SolGirX = "0";
                            LiftData.SolGirY = "0";
                            LiftData.SolKasa = Convert.ToString(num2);
                            LiftData.SagKasa = Convert.ToString(num2);
                            LiftData.DKapiYEksen = Convert.ToString((decimal) (num - num2));
                            LiftData.KabinYEksen = num.ToString();
                            LiftData.BlkInsName = "YO-4MER";
                            return LiftData;
                        }
                        return LiftData;

                    case 0x847a8c1d:
                        if (kapiTip == "TO-3TEL")
                        {
                            if (LiftData.Mentese == "SOL")
                            {
                                LiftData.SagGirX = "20";
                                LiftData.SagGirY = "45";
                                LiftData.SolGirX = "0";
                                LiftData.SolGirY = "0";
                                LiftData.SagKasa = Convert.ToString((decimal) (num3 + num2));
                                LiftData.SolKasa = num2.ToString();
                            }
                            else
                            {
                                LiftData.SagGirX = "0";
                                LiftData.SagGirY = "0";
                                LiftData.SolGirX = "20";
                                LiftData.SolGirY = "45";
                                LiftData.SagKasa = num2.ToString();
                                LiftData.SolKasa = Convert.ToString((decimal) (num3 + num2));
                            }
                            this.xx.oleupdate("UPDATE BLK SET BlkInsName='3TEL-BB' WHERE id='252'", "");
                            LiftData.EsikKalin = num2.ToString();
                            LiftData.KabinYEksen = num.ToString();
                            LiftData.DKapiYEksen = Convert.ToString((decimal) (((num - num2) - (2M * num3)) - 30M));
                            LiftData.BlkInsName = "TO-3TEL";
                            return LiftData;
                        }
                        return LiftData;

                    case 0x96b2daf9:
                        if (kapiTip == "CK-KPYK")
                        {
                            LiftData.SagGirX = "0";
                            LiftData.SagGirY = "0";
                            LiftData.SolGirX = "0";
                            LiftData.SolGirY = "0";
                            LiftData.SolKasa = Convert.ToString(num2);
                            LiftData.SagKasa = Convert.ToString(num2);
                            LiftData.DKapiYEksen = Convert.ToString((decimal) (num - num2));
                            LiftData.KabinYEksen = num.ToString();
                            LiftData.BlkInsName = "YO-CIFT";
                            return LiftData;
                        }
                        return LiftData;
                }
                return LiftData;
            }
            if (num5 <= 0xbdb9eb4e)
            {
                switch (num5)
                {
                    case 0x9bcb53cc:
                        if (kapiTip == "TO-2TEL")
                        {
                            if (LiftData.Mentese == "SOL")
                            {
                                LiftData.SagGirX = "20";
                                LiftData.SagGirY = "45";
                                LiftData.SolGirX = "0";
                                LiftData.SolGirY = "0";
                                LiftData.SagKasa = Convert.ToString((decimal) (num3 + num2));
                                LiftData.SolKasa = num2.ToString();
                            }
                            else
                            {
                                LiftData.SagGirX = "0";
                                LiftData.SagGirY = "0";
                                LiftData.SolGirX = "20";
                                LiftData.SolGirY = "45";
                                LiftData.SagKasa = num2.ToString();
                                LiftData.SolKasa = Convert.ToString((decimal) (num3 + num2));
                            }
                            LiftData.EsikKalin = num2.ToString();
                            LiftData.DKapiYEksen = Convert.ToString((decimal) (((num - num2) - (2M * num3)) - 30M));
                            LiftData.KabinYEksen = num.ToString();
                            LiftData.BlkInsName = "TO-2TEL";
                            LiftData.KapiH = "2300";
                            this.xx.oleupdate("UPDATE BLK SET BlkInsName='2TEL-BB' WHERE id='252'", "");
                            return LiftData;
                        }
                        return LiftData;

                    case 0xac06ccf7:
                        if (kapiTip == "TO-4MER")
                        {
                            LiftData.SagGirX = "0";
                            LiftData.SagGirY = "0";
                            LiftData.SolGirX = "0";
                            LiftData.SolGirY = "0";
                            LiftData.SagKasa = num2.ToString();
                            LiftData.SolKasa = num2.ToString();
                            LiftData.EsikKalin = num2.ToString();
                            LiftData.DKapiYEksen = Convert.ToString((decimal) (((num - num2) - (2M * num3)) - 30M));
                            LiftData.KabinYEksen = num.ToString();
                            LiftData.BlkInsName = "TO-4MER";
                            this.xx.oleupdate("UPDATE BLK SET BlkInsName='2TEL-BB' WHERE id='252'", "");
                            return LiftData;
                        }
                        return LiftData;

                    case 0xbdb9eb4e:
                        if (kapiTip == "CK-4MER")
                        {
                            LiftData.SagGirX = "0";
                            LiftData.SagGirY = "0";
                            LiftData.SolGirX = "0";
                            LiftData.SolGirY = "0";
                            LiftData.SolKasa = Convert.ToString(num2);
                            LiftData.SagKasa = Convert.ToString(num2);
                            LiftData.DKapiYEksen = Convert.ToString((decimal) (num - num2));
                            LiftData.KabinYEksen = num.ToString();
                            LiftData.BlkInsName = "CK-4MER";
                            return LiftData;
                        }
                        return LiftData;
                }
                return LiftData;
            }
            switch (num5)
            {
                case 0xc45019aa:
                    if (kapiTip == "YO-3TEL")
                    {
                        if (LiftData.Mentese == "SOL")
                        {
                            LiftData.SagGirX = "20";
                            LiftData.SagGirY = "45";
                            LiftData.SolGirX = "0";
                            LiftData.SolGirY = "0";
                            num6 = num3 + num2;
                            LiftData.SagKasa = num6.ToString();
                            LiftData.SolKasa = num2.ToString();
                        }
                        else
                        {
                            LiftData.SagGirX = "0";
                            LiftData.SagGirY = "0";
                            LiftData.SolGirX = "20";
                            LiftData.SolGirY = "45";
                            LiftData.SolKasa = (num3 + num2).ToString();
                            LiftData.SagKasa = num2.ToString();
                        }
                        LiftData.DKapiYEksen = Convert.ToString((decimal) (num - num2));
                        LiftData.KabinYEksen = num.ToString();
                        LiftData.BlkInsName = "YO-3TEL";
                        return LiftData;
                    }
                    return LiftData;

                case 0xe5cc63ee:
                    if (kapiTip == "YO-2MER")
                    {
                        LiftData.SagGirX = "0";
                        LiftData.SagGirY = "0";
                        LiftData.SolGirX = "0";
                        LiftData.SolGirY = "0";
                        LiftData.SolKasa = Convert.ToString(num2);
                        LiftData.SagKasa = Convert.ToString(num2);
                        LiftData.DKapiYEksen = Convert.ToString((decimal) (num - num2));
                        LiftData.KabinYEksen = num.ToString();
                        LiftData.BlkInsName = "YO-2MER";
                        return LiftData;
                    }
                    return LiftData;

                case 0xe6332595:
                    if (kapiTip == "TO-2MER")
                    {
                        LiftData.SagGirX = "0";
                        LiftData.SagGirY = "0";
                        LiftData.SolGirX = "0";
                        LiftData.SolGirY = "0";
                        LiftData.SagKasa = num2.ToString();
                        LiftData.SolKasa = num2.ToString();
                        LiftData.EsikKalin = num2.ToString();
                        LiftData.DKapiYEksen = Convert.ToString((decimal) (((num - num2) - (2M * num3)) - 30M));
                        LiftData.KabinYEksen = num.ToString();
                        LiftData.BlkInsName = "TO-2MER";
                        LiftData.KapiH = "2300";
                        this.xx.oleupdate("UPDATE BLK SET BlkInsName='2MER-BB' WHERE id='252'", "");
                        return LiftData;
                    }
                    return LiftData;
            }
            return LiftData;
        }

        [CommandMethod("KK")]
        public void KK()
        {
            Application.SetSystemVariable("USERI1", 10);
            Application.SetSystemVariable("DIMSCALE", 3.0);
            Application.SetSystemVariable("DIMLFAC", 10.0);
            Point3d myBase = new Point3d();
            this.LD("KK", false, myBase);
            myBase = new Point3d();
            this.LD("KD", false, myBase);
            Application.SetSystemVariable("USERI1", 20);
            Application.SetSystemVariable("DIMLFAC", 20.0);
            myBase = new Point3d();
            this.LD("TK-AA", false, myBase);
            myBase = new Point3d();
            this.LD("TK-BB", false, myBase);
            this.LD("MD", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 0.0);
            Application.SetSystemVariable("USERI1", 0);
        }

        [CommandMethod("KVV")]
        public void KKK()
        {
            waitenform waitenform = new waitenform();
            waitenform.Show();
            this.prman.aadd = this;
            this.prman.destandcrash();
            waitenform.Close();
        }

        [CommandMethod("KKNew")]
        public void KKNew()
        {
            Point3d myBase = new Point3d(100.0, 100.0, 0.0);
            this.LD("KK", true, myBase);
        }

        public void KuyuCiz(int LN, int ToplamKuyuGen, int KuyuDer, List<int> KuyuGenList, int AraBolme, string KesitKodu, clsMLift MainLift)
        {
            Entity vtEnt = null;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database db = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (db)
                    {
                        using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                        {
                            double olcek = MainLift.Olcek;
                            if (olcek == 0.0)
                            {
                                olcek = 1.0;
                            }
                            if (((KesitKodu == "KK") || (KesitKodu == "KD")) && (MainLift.Pan == "0"))
                            {
                                BlockReference reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "ButunKuyu", false, "BUTUNKUYU", "1", MainLift.KesitKodu, 1.0 / olcek);
                                vtEnt = FObject("BUTUNKUYU", "1", MainLift.KesitKodu);
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (ToplamKuyuGen * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuDer", (double) (KuyuDer * (1.0 / olcek)));
                                    if (olcek > 1.0)
                                    {
                                        if (KesitKodu == "KK")
                                        {
                                            this.ChTag(vtEnt.get_ObjectId(), "KUYU", "KUYU YATAY KESİTİ \x00d6:1/" + this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
                                        }
                                        else
                                        {
                                            this.ChTag(vtEnt.get_ObjectId(), "KUYU", "KUYU DİBİ YATAY KESİTİ \x00d6:1/" + this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
                                        }
                                    }
                                    else if (KesitKodu == "KK")
                                    {
                                        this.ChTag(vtEnt.get_ObjectId(), "KUYU", "KUYU YATAY KESİTİ");
                                    }
                                    else
                                    {
                                        this.ChTag(vtEnt.get_ObjectId(), "KUYU", "KUYU DİBİ YATAY KESİTİ");
                                    }
                                }
                                if (LN > 1)
                                {
                                    reference = this.InsertBlock(db, transaction, new Point3d(0.0, 0.0, 0.0), "AraBolme", false, "AraBolme", "1", "0", 1.0);
                                    vtEnt = FObject("AraBolme", "1", "0");
                                    if (vtEnt != null)
                                    {
                                        this.SetDynamicValue(db, transaction, vtEnt, "AraBolmeX", (double) (((double) KuyuGenList[1]) * (1.0 / olcek)));
                                        this.SetDynamicValue(db, transaction, vtEnt, "AraBolmeH", (double) (KuyuDer * (1.0 / olcek)));
                                        this.SetDynamicValue(db, transaction, vtEnt, "AraBolmeGen", (double) (AraBolme * (1.0 / olcek)));
                                    }
                                }
                            }
                            if (((KesitKodu == "KK") || (KesitKodu == "KD")) && (MainLift.Pan == "1"))
                            {
                                Point3d insertPoint = new Point3d(0.0, 0.0, 0.0);
                                BlockReference reference2 = this.InsertBlock(db, transaction, insertPoint, "PanKuyu", false, "BUTUNKUYU", "1", null, 1.0);
                                vtEnt = FObject("BUTUNKUYU", "1", "0");
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (ToplamKuyuGen * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuDer", (double) (KuyuDer * (1.0 / olcek)));
                                    if (KesitKodu == "KK")
                                    {
                                        if (olcek > 1.0)
                                        {
                                            this.ChTag(vtEnt.get_ObjectId(), "KUYU", "KUYU YATAY KESİTİ \x00d6:1/" + this.GetNumValue("KKOLCEK", "1"));
                                        }
                                        else
                                        {
                                            this.ChTag(vtEnt.get_ObjectId(), "KUYU", "KUYU YATAY KESİTİ");
                                        }
                                    }
                                    else if (olcek > 1.0)
                                    {
                                        this.ChTag(vtEnt.get_ObjectId(), "KUYU", "KUYU ALTI YATAY KESİTİ \x00d6:1/" + this.GetNumValue("KDOLCEK", "1"));
                                    }
                                    else
                                    {
                                        this.ChTag(vtEnt.get_ObjectId(), "KUYU", "KUYU ALTI YATAY KESİTİ");
                                    }
                                }
                            }
                            if (KesitKodu == "MDD")
                            {
                                Point3d pointd2 = new Point3d(0.0, 0.0, 0.0);
                                BlockReference reference3 = this.InsertBlock(db, transaction, pointd2, "MD", false, "BUTUNKUYU", "1", null, 1.0);
                                vtEnt = FObject("BUTUNKUYU", "1", "0");
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (ToplamKuyuGen * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuDer", (double) (KuyuDer * (1.0 / olcek)));
                                    if (olcek > 1.0)
                                    {
                                        this.ChTag(vtEnt.get_ObjectId(), "KUYU", "MAKİNE DAİRESİ \x00dcST G\x00d6R\x00dcN\x00dcŞ \x00d6:1/" + this.GetNumValue("MDOLCEK", "1"));
                                    }
                                    else
                                    {
                                        this.ChTag(vtEnt.get_ObjectId(), "KUYU", "MAKİNE DAİRESİ \x00dcST G\x00d6R\x00dcN\x00dcŞ");
                                    }
                                }
                            }
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        public void KuyuCiz2(clsMainLift MainLift)
        {
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database db = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (db)
                    {
                        using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                        {
                            BlockReference reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "Kuyu", false, "KUYU", "1", null, 1.0);
                            reference.ExplodeToOwnerSpace();
                            reference.Erase();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        [CommandMethod("KuyuKabin1")]
        public void KuyuKabin1()
        {
            Application.SetSystemVariable("USERI1", 1);
            Application.SetSystemVariable("DIMSCALE", 40.0);
            Application.SetSystemVariable("DIMLFAC", 1.0);
            this.LD("KK", false, new Point3d());
        }

        [CommandMethod("KuyuKabinOlcekli")]
        public void KuyuKabinOlcekli()
        {
            this.LD("KK", true, new Point3d());
            Point3d myBase = new Point3d(0.0, 500.0, 0.0);
            this.LD("KD", true, myBase);
        }

        public void LayerOff(string sLayerName)
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                if (!table.Has(sLayerName))
                {
                    using (LayerTableRecord record = new LayerTableRecord())
                    {
                        record.set_Name(sLayerName);
                        table.UpgradeOpen();
                        table.Add(record);
                        transaction.AddNewlyCreatedDBObject(record, true);
                        record.set_IsOff(true);
                    }
                }
                else
                {
                    (transaction.GetObject(table.get_Item(sLayerName), 1) as LayerTableRecord).set_IsOff(true);
                }
                transaction.Commit();
            }
        }

        public static void LayerOff(Document acDoc, Transaction acTrans, string sLayerName)
        {
            Database database = acDoc.get_Database();
            LayerTable table = acTrans.GetObject(database.get_LayerTableId(), 0) as LayerTable;
            if (!table.Has(sLayerName))
            {
                using (LayerTableRecord record = new LayerTableRecord())
                {
                    record.set_Name(sLayerName);
                    table.UpgradeOpen();
                    table.Add(record);
                    acTrans.AddNewlyCreatedDBObject(record, true);
                    record.set_IsOff(true);
                }
            }
            else
            {
                (acTrans.GetObject(table.get_Item(sLayerName), 1) as LayerTableRecord).set_IsOff(true);
            }
        }

        public static void LayerOn(string sLayerName)
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                if (table.Has(sLayerName))
                {
                    (transaction.GetObject(table.get_Item(sLayerName), 1) as LayerTableRecord).set_IsOff(false);
                }
                transaction.Commit();
            }
        }

        public static void LayerOn(Document acDoc, Transaction acTrans, string sLayerName)
        {
            Database database = acDoc.get_Database();
            LayerTable table = acTrans.GetObject(database.get_LayerTableId(), 0) as LayerTable;
            if (table.Has(sLayerName))
            {
                (acTrans.GetObject(table.get_Item(sLayerName), 1) as LayerTableRecord).set_IsOff(false);
            }
        }

        [CommandMethod("LD")]
        public void LD()
        {
            PromptKeywordOptions options = new PromptKeywordOptions("\nKesiti Sec :");
            options.set_AllowNone(false);
            options.get_Keywords().Add("KK");
            options.get_Keywords().Add("KD");
            options.get_Keywords().Add("MD");
            options.get_Keywords().Add("TK-AA");
            options.get_Keywords().Add("TK-BB");
            options.get_Keywords().Add("TTK-AA");
            options.get_Keywords().Add("TTK-BB");
            PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(options);
            if (keywords.get_Status() == 0x13ec)
            {
                string kesitKodu = keywords.get_StringResult();
                this.LD(kesitKodu, false, new Point3d());
            }
        }

        public void LD(string KesitKodu, bool ScaleNow = false, Point3d MyBase = new Point3d())
        {
            int asnadedi;
            int num4;
            int num2 = 0;
            int num3 = 0;
            try
            {
                num4 = Convert.ToInt32(this.GetNumValue("AraBolme", "1"));
            }
            catch (Exception)
            {
                num4 = 100;
            }
            int num5 = 200;
            clsMLift mainLift = new clsMLift();
            List<ParamList> list = new List<ParamList>();
            List<int> kuyuGenList = new List<int> { 0 };
            mainLift = this.ReadAllData("1", KesitKodu);
            mainLift.BasePoint = MyBase;
            if (ScaleNow)
            {
                mainLift.Olcek = Convert.ToDouble(this.GetNumValue(mainLift.KesitKodu + "OLCEK", "1"));
                if (mainLift.Olcek == 0.0)
                {
                    mainLift.Olcek = 1.0;
                }
                Application.SetSystemVariable("DIMLFAC", Convert.ToDouble(this.GetNumValue(mainLift.KesitKodu + "OLCEK", "1")));
                Application.SetSystemVariable("DIMSCALE", 40.0 / mainLift.Olcek);
            }
            else
            {
                mainLift.Olcek = 1.0;
                Application.SetSystemVariable("DIMSCALE", 40.0 / mainLift.Olcek);
                Application.SetSystemVariable("DIMLFAC", 1.0);
            }
            if (string.IsNullOrEmpty(this.prman.GetParamValFRM("LN", "KK")))
            {
                asnadedi = 1;
            }
            else
            {
                asnadedi = Convert.ToInt32(this.prman.GetParamValFRM("LN", "KK"));
                switch (asnadedi)
                {
                    case 1:
                        asnadedi = 2;
                        break;

                    case 0:
                        asnadedi = 1;
                        break;
                }
            }
            asnadedi = this.prman.asnadedi;
            for (int i = 0; i < asnadedi; i++)
            {
                if (i == 1)
                {
                    this.xx.upexcel("KuyuDer", Convert.ToString(num3), Convert.ToString((int) (i + 1)));
                }
                list = this.ReadVarGrup(Convert.ToString((int) (i + 1)));
                foreach (ParamList list3 in list)
                {
                    if (list3.ParamName == "KuyuGen")
                    {
                        num2 = (num2 + Convert.ToInt32(list3.ParamValue)) + (num4 * i);
                        kuyuGenList.Add(Convert.ToInt32(list3.ParamValue));
                    }
                    if ((list3.ParamName == "KuyuDer") && (num3 == 0))
                    {
                        num3 = Convert.ToInt32(list3.ParamValue);
                    }
                }
            }
            this.xx.upexcel("ToplamKuyuGen", Convert.ToString(num2), "1");
            if (asnadedi > 1)
            {
                this.LayerOff("SOLDUBEL");
                this.LayerOff("SAGDUBEL");
            }
            if ((KesitKodu == "KK") || (KesitKodu == "KD"))
            {
                if (mainLift.Tahrik.YonKodu == "ARKA")
                {
                    LayerOn("SOLDUBEL");
                    LayerOn("SAGDUBEL");
                }
                if (mainLift.Tahrik.YonKodu == "SOL")
                {
                    this.LayerOff("SOLDUBEL");
                    LayerOn("SAGDUBEL");
                }
                if (mainLift.Tahrik.YonKodu == "SAG")
                {
                    LayerOn("SOLDUBEL");
                    this.LayerOff("SAGDUBEL");
                }
                if (this.GetNumValue("chkKabinSusp", "1") == "1")
                {
                    LayerOn("KabinSusp");
                }
                else
                {
                    this.LayerOff("KabinSusp");
                }
                if (mainLift.Tahrik.TahrikKodu == "MDCAP")
                {
                    this.LayerOff("11");
                    LayerOn("12");
                }
                else
                {
                    this.LayerOff("12");
                    LayerOn("11");
                }
                if (mainLift.Tahrik.TahrikKodu == "DA")
                {
                    LayerOn("HD");
                }
                else
                {
                    this.LayerOff("HD");
                }
            }
            if ((((KesitKodu == "TK-AA") || (KesitKodu == "TK-BB")) || (KesitKodu == "TTK-AA")) || (KesitKodu == "TTK-BB"))
            {
                decimal num8 = new decimal();
                decimal num9 = new decimal();
                decimal num10 = new decimal();
                char[] separator = new char[] { Convert.ToChar("#") };
                mainLift.KatRumuz = this.GetNumValue("KatRumuz", "1").Split(separator);
                char[] chArray2 = new char[] { Convert.ToChar("#") };
                string[] strArray = this.GetNumValue("KatYukListe", "1").Split(chArray2);
                mainLift.KatYuk = strArray;
                for (int k = 0; k < (strArray.Length - 1); k++)
                {
                    num8 += Convert.ToDecimal(strArray[k]);
                }
                this.xx.SetNumValue("SeyirMesafesi", Convert.ToString(num8), "1");
                num9 = (((num8 + Convert.ToDecimal(strArray[strArray.Length - 1])) + Convert.ToDecimal(this.GetNumValue("MDaireH", "1"))) + Convert.ToDecimal(this.GetNumValue("KuyuDibi", "1"))) - Convert.ToDecimal(this.GetNumValue("DuvarKal", "1"));
                this.xx.SetNumValue("KuyuMesafesi", Convert.ToString(num9), "1");
                this.xx.SetNumValue("ToplamYuk", Convert.ToString(num9), "1");
                num10 = (Convert.ToDecimal(this.GetNumValue("SonDurakKot", "1")) + Convert.ToDecimal(strArray[strArray.Length - 1])) + Convert.ToDecimal(this.GetNumValue("MDaireH", "1"));
                this.xx.SetNumValue("MDKot", Convert.ToString(num10), "1");
            }
            switch (KesitKodu)
            {
                case "TK-AA":
                    this.TKAAKuyuCiz(mainLift, num2);
                    break;

                case "TK-BB":
                    this.TKBBKuyuCiz(mainLift, num3);
                    break;

                case "TTK-AA":
                    this.TTKKuyuCiz(mainLift, num2, KesitKodu);
                    break;

                case "TTK-BB":
                    this.TTKKuyuCiz(mainLift, num2, KesitKodu);
                    break;

                default:
                    if (KesitKodu == "KD")
                    {
                    }
                    this.KuyuCiz(asnadedi, num2, num3, kuyuGenList, num4, KesitKodu, mainLift);
                    break;
            }
            for (int j = 0; j < asnadedi; j++)
            {
                if (j == 1)
                {
                    mainLift = this.ReadAllData("2", KesitKodu);
                }
                if (ScaleNow)
                {
                    mainLift.Olcek = Convert.ToDouble(this.GetNumValue(mainLift.KesitKodu + "OLCEK", "1"));
                    if (mainLift.Olcek == 0.0)
                    {
                        mainLift.Olcek = 1.0;
                    }
                }
                else
                {
                    mainLift.Olcek = 1.0;
                }
                mainLift.BasePoint = MyBase;
                if (j == 1)
                {
                    mainLift.BasePoint = new Point3d(MyBase.get_X() + (((double) (kuyuGenList[1] + num4)) * (1.0 / mainLift.Olcek)), MyBase.get_Y(), 0.0);
                }
                mainLift.LiftNum = j + 1;
                if ((mainLift.LiftNum != 2) || (mainLift.KesitKodu != "TK-BB"))
                {
                    this.LiftDraw2(mainLift, true);
                    if (j != 0)
                    {
                        string yonKodu = mainLift.Tahrik.YonKodu;
                        if (((yonKodu == "ARKA") || (yonKodu == "SAG")) || (yonKodu == "SOL"))
                        {
                        }
                    }
                    if (((j + 1) != 0) && ((j + 1) < asnadedi))
                    {
                        string str4 = mainLift.Tahrik.YonKodu;
                        if (((str4 == "SAG") || (str4 == "ARKA")) || (str4 == "SOL"))
                        {
                        }
                    }
                    else
                    {
                        this.chParamVal("DimSagKac" + Convert.ToString(mainLift.LiftNum), Convert.ToString((int) ((kuyuGenList[j + 1] + num5) + 100)));
                    }
                    if ((KesitKodu == "MD") && (j == 0))
                    {
                        try
                        {
                            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                            if (document == null)
                            {
                                return;
                            }
                            Database db = document.get_Database();
                            using (db)
                            {
                                using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                                {
                                    this.InsertBlock(db, transaction, new Point3d(mainLift.BasePoint.get_X() + (0.0 * (1.0 / mainLift.Olcek)), mainLift.BasePoint.get_Y() - (2000.0 * (1.0 / mainLift.Olcek)), 0.0), "Kumanda", true, "", "", "", 1.0 / mainLift.Olcek);
                                    this.InsertBlock(db, transaction, new Point3d(mainLift.BasePoint.get_X() + (1000.0 * (1.0 / mainLift.Olcek)), mainLift.BasePoint.get_Y() - (2000.0 * (1.0 / mainLift.Olcek)), 0.0), "Kuvvet", true, "", "", "", 1.0 / mainLift.Olcek);
                                    this.InsertBlock(db, transaction, new Point3d(mainLift.BasePoint.get_X() + (1500.0 * (1.0 / mainLift.Olcek)), mainLift.BasePoint.get_Y() - (2000.0 * (1.0 / mainLift.Olcek)), 0.0), "MDKapi", true, "", "", "", 1.0 / mainLift.Olcek);
                                    this.InsertBlock(db, transaction, new Point3d(mainLift.BasePoint.get_X() + (2000.0 * (1.0 / mainLift.Olcek)), mainLift.BasePoint.get_Y() - (2000.0 * (1.0 / mainLift.Olcek)), 0.0), "Pencere", true, "", "", "", 1.0 / mainLift.Olcek);
                                    this.InsertBlock(db, transaction, new Point3d(mainLift.BasePoint.get_X() + (2500.0 * (1.0 / mainLift.Olcek)), mainLift.BasePoint.get_Y() - (2000.0 * (1.0 / mainLift.Olcek)), 0.0), "Baca", true, "", "", "", 1.0 / mainLift.Olcek);
                                    this.InsertBlock(db, transaction, new Point3d(mainLift.BasePoint.get_X() + (3000.0 * (1.0 / mainLift.Olcek)), mainLift.BasePoint.get_Y() - (2000.0 * (1.0 / mainLift.Olcek)), 0.0), "MDMerdiven", true, "", "", "", 1.0 / mainLift.Olcek);
                                    transaction.Commit();
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        public myData LiftDataOku(string LiftNumber)
        {
            myData data = new myData();
            DataTable gelendata = this.xx.dtta("select ParamName,ParamValue from Num" + LiftNumber, "");
            DataTable table2 = this.xx.dtta("select ParamName,ParamValue from Num1", "");
            data.KapiTip = this.GetGirisValue("KapiTip", LiftNumber);
            data.Mentese = this.GetGirisValue("Mentese", LiftNumber);
            data.BlkInsName = this.GetGirisValue("BlkInsName", LiftNumber);
            data.KuyuGen = this.Donennumdeger("KuyuGen", gelendata);
            data.KuyuDer = this.Donennumdeger("KuyuDer", gelendata);
            data.DuvarKal = this.Donennumdeger("DuvarKal", gelendata);
            data.AgrGen = this.Donennumdeger("AgrGen", gelendata);
            data.AgrU = this.Donennumdeger("AgrU", gelendata);
            data.AgrDuv = this.Donennumdeger("AgrDuv", gelendata);
            data.AgrUz = this.Donennumdeger("AgrUz", gelendata);
            data.KabinRayUcu = this.Donennumdeger("KabinRayUcu", gelendata);
            data.AgirRayUcu = this.Donennumdeger("AgirRayUcu", gelendata);
            data.RK = this.Donennumdeger("RK", gelendata);
            data.SagKac = this.Donennumdeger("SagKac", gelendata);
            data.SagGirX = this.Donennumdeger("SagGirX", gelendata);
            data.SagGirY = this.Donennumdeger("SagGirY", gelendata);
            data.SolGirX = this.Donennumdeger("SolGirX", gelendata);
            data.SolGirY = this.Donennumdeger("SolGirY", gelendata);
            data.SolKasa = this.Donennumdeger("SolKasa", gelendata);
            data.SagKasa = this.Donennumdeger("SagKasa", gelendata);
            data.KapiFlip = this.Donennumdeger("KapiFlip", gelendata);
            data.AgrKasnakX = this.Donennumdeger("AgrKasnakX", gelendata);
            data.AgrKasnakY = this.Donennumdeger("AgrKasnakY", gelendata);
            data.TahrikKas = this.Donennumdeger("TahrikKas", gelendata);
            data.SapKas = this.Donennumdeger("SapKas", gelendata);
            data.AgrKasGen = this.Donennumdeger("AgrKasGen", gelendata);
            data.MDSapKas = this.Donennumdeger("MDSapKas", gelendata);
            data.MDTahrikKas = this.Donennumdeger("MDTahrikKas", gelendata);
            data.KapiYEksen = this.Donennumdeger("KapiYEksen", gelendata);
            data.KabinYEksen = this.Donennumdeger("KabinYEksen", gelendata);
            data.KKapiYEksen = this.Donennumdeger("KKapiYEksen", gelendata);
            data.DKapiYEksen = this.Donennumdeger("DKapiYEksen", gelendata);
            data.DKapiYEksen = this.Donennumdeger("EsikKalin", gelendata);
            data.KasaGen = this.Donennumdeger("KasaGen", gelendata);
            data.KasaDer = this.Donennumdeger("KasaDer", gelendata);
            data.KizakKalin = this.Donennumdeger("KizakKalin", gelendata);
            data.HidrolikGen = this.Donennumdeger("HidrolikGen", gelendata);
            data.PistonMer = this.Donennumdeger("PistonMer", gelendata);
            data.PistonKab = this.Donennumdeger("PistonKab", gelendata);
            data.HRA = this.Donennumdeger("HRA", gelendata);
            data.KabinHidrolikFark = this.Donennumdeger("KabinHidrolikFark", gelendata);
            data.SagKonsolLIM = this.Donennumdeger("SagKonsolLIM", gelendata);
            data.KabArkaDuvLIM = this.Donennumdeger("KabArkaDuvLIM", gelendata);
            data.AgrKabin = this.Donennumdeger("AgrKabin", gelendata);
            data.KabinDuvar = this.Donennumdeger("KabinDuvar", gelendata);
            data.SagRayDuv = this.Donennumdeger("SagRayDuv", gelendata);
            data.KabinRayFark = this.Donennumdeger("KabinRayFark", gelendata);
            data.AASol = this.Donennumdeger("AASol", gelendata);
            data.AASag = this.Donennumdeger("AASag", gelendata);
            data.BBSol = this.Donennumdeger("BBSol", gelendata);
            data.BBSag = this.Donennumdeger("BBSag", gelendata);
            data.MDaireH = this.Donennumdeger("MDaireH", gelendata);
            data.KapiGen = this.Donennumdeger("KapiGen", gelendata);
            data.AgrAnarayFark = this.Donennumdeger("AgrAnarayFark", gelendata);
            data.KabinAgrEksenFark = this.Donennumdeger("KabinAgrEksenFark", gelendata);
            data.SolKonsol = this.Donennumdeger("SolKonsol", gelendata);
            data.SagKonsol = this.Donennumdeger("SagKonsol", gelendata);
            data.KabinYanDuv = this.Donennumdeger("KabinYanDuv", gelendata);
            data.RayTavan = this.Donennumdeger("RayTavan", gelendata);
            data.KuyuDibi = this.Donennumdeger("KuyuDibi", table2);
            data.IlkKat = this.Donennumdeger("IlkKat", table2);
            data.SonKat = this.Donennumdeger("SonKat", table2);
            data.KuyuKafa = this.Donennumdeger("KuyuKafa", table2);
            data.DurakSayi = this.Donennumdeger("DurakSayi", table2);
            data.IlkDurakNo = this.Donennumdeger("IlkDurakNo", table2);
            data.SeyirMesafesi = this.Donennumdeger("SeyirMesafesi", table2);
            data.KuyuMesafesi = this.Donennumdeger("KuyuMesafesi", table2);
            data.IlkDurakKot = this.Donennumdeger("IlkDurakKot", table2);
            data.SonDurakKot = this.Donennumdeger("SonDurakKot", table2);
            data.MDKot = this.Donennumdeger("MDKot", table2);
            data.TopKuyuKafa = this.Donennumdeger("TopKuyuKafa", table2);
            data.CalisYuksek = this.Donennumdeger("CalisYuksek", table2);
            data.KRX = this.Donennumdeger("KRX", gelendata);
            data.KRY = this.Donennumdeger("KRY", gelendata);
            data.KRZ = this.Donennumdeger("KRZ", gelendata);
            data.ARX = this.Donennumdeger("ARX", gelendata);
            data.ARY = this.Donennumdeger("ARY", gelendata);
            data.ARZ = this.Donennumdeger("ARZ", gelendata);
            data.KapiH = this.Donennumdeger("KapiH", gelendata);
            data.BeyanYuk = this.Donennumdeger("BeyanYuk", gelendata);
            data.KabinP = this.Donennumdeger("KabinP", gelendata);
            data.TahrikKodu = this.Donennumdeger("TahrikKodu", gelendata);
            data.YonKodu = this.Donennumdeger("YonKodu", gelendata);
            data.TipKodu = this.Donennumdeger("TipKodu", gelendata);
            data.KatYukListe = this.Donennumdeger("KatYukListe", table2);
            data.TopKuyuKafa = this.Donennumdeger("TopKuyuKafa", table2);
            data.AraKatSTR = this.Donennumdeger("AraKatSTR", table2);
            data.KatRumuz = this.Donennumdeger("KatRumuz", table2);
            data.MdTabTavan = this.Donennumdeger("MdTabTavan", table2);
            data.AgrGir = this.Donennumdeger("AgrGir", gelendata);
            data.AydinMesafe = this.Donennumdeger("AydinMesafe", table2);
            data.KonsolMesafe = this.Donennumdeger("KonsolMesafe", table2);
            data.OtoKabinEsik = this.Donennumdeger("OtoKabinEsik", gelendata);
            data.ToplamKalin = this.Donennumdeger("ToplamKalin", gelendata);
            data.SagRayDuv = this.Donennumdeger("SagRayDuv", gelendata);
            return data;
        }

        public void LiftDataYaz(myData LiftData, string LiftNumber)
        {
            this.xx.SetGirisValue("KapiTip", LiftData.KapiTip, LiftNumber);
            this.xx.SetGirisValue("Mentese", LiftData.Mentese, LiftNumber);
            this.xx.SetGirisValue("BlkInsName", LiftData.KapiTip, LiftNumber);
            if (LiftData.Mentese == "SAG")
            {
                LiftData.KapiFlip = "1";
            }
            else
            {
                LiftData.KapiFlip = "0";
            }
            if (LiftData.KapiTip > null)
            {
                this.xx.SetNumValue("KapiTip", LiftData.KapiTip, LiftNumber);
            }
            if (LiftData.TipKodu > null)
            {
                this.xx.SetNumValue("TipKodu", LiftData.TipKodu, LiftNumber);
            }
            if (LiftData.TahrikKodu > null)
            {
                this.xx.SetNumValue("TahrikKodu", LiftData.TahrikKodu, LiftNumber);
            }
            if (LiftData.OtoKabinEsik > null)
            {
                this.xx.SetNumValue("OtoKabinEsik", LiftData.OtoKabinEsik, LiftNumber);
            }
            if (LiftData.ToplamKalin > null)
            {
                this.xx.SetNumValue("ToplamKalin", LiftData.ToplamKalin, LiftNumber);
            }
            if (LiftData.KuyuGen > null)
            {
                this.xx.SetNumValue("KuyuGen", LiftData.KuyuGen, LiftNumber);
            }
            if (LiftData.KuyuDer > null)
            {
                this.xx.SetNumValue("KuyuDer", LiftData.KuyuDer, LiftNumber);
            }
            if (LiftData.DuvarKal > null)
            {
                this.xx.SetNumValue("DuvarKal", LiftData.DuvarKal, LiftNumber);
            }
            if (LiftData.AgrGen > null)
            {
                this.xx.SetNumValue("AgrGen", LiftData.AgrGen, LiftNumber);
            }
            if (LiftData.AgrDuv > null)
            {
                this.xx.SetNumValue("AgrDuv", LiftData.AgrDuv, LiftNumber);
            }
            if (LiftData.AgrU > null)
            {
                this.xx.SetNumValue("AgrU", LiftData.AgrU, LiftNumber);
            }
            if (LiftData.AgrUz > null)
            {
                this.xx.SetNumValue("AgrUz", LiftData.AgrUz, LiftNumber);
            }
            if (LiftData.KabinRayUcu > null)
            {
                this.xx.SetNumValue("KabinRayUcu", LiftData.KabinRayUcu, LiftNumber);
            }
            if (LiftData.AgirRayUcu > null)
            {
                this.xx.SetNumValue("AgirRayUcu", LiftData.AgirRayUcu, LiftNumber);
            }
            if (LiftData.RK > null)
            {
                this.xx.SetNumValue("RK", LiftData.RK, LiftNumber);
            }
            if (!string.IsNullOrEmpty(LiftData.SagKac))
            {
                this.xx.SetNumValue("SagKac", LiftData.SagKac, LiftNumber);
            }
            if (LiftData.SagGirX > null)
            {
                this.xx.SetNumValue("SagGirX", LiftData.SagGirX, LiftNumber);
            }
            if (LiftData.SagGirY > null)
            {
                this.xx.SetNumValue("SagGirY", LiftData.SagGirY, LiftNumber);
            }
            if (LiftData.SolGirX > null)
            {
                this.xx.SetNumValue("SolGirX", LiftData.SolGirX, LiftNumber);
            }
            if (LiftData.SolGirY > null)
            {
                this.xx.SetNumValue("SolGirY", LiftData.SolGirY, LiftNumber);
            }
            if (LiftData.SolKasa > null)
            {
                this.xx.SetNumValue("SolKasa", LiftData.SolKasa, LiftNumber);
            }
            if (LiftData.SagKasa > null)
            {
                this.xx.SetNumValue("SagKasa", LiftData.SagKasa, LiftNumber);
            }
            if (LiftData.KapiFlip > null)
            {
                this.xx.SetNumValue("KapiFlip", LiftData.KapiFlip, LiftNumber);
            }
            if (LiftData.KizakKalin > null)
            {
                this.xx.SetNumValue("KizakKalin", LiftData.KizakKalin, LiftNumber);
            }
            if (LiftData.KasaGen > null)
            {
                this.xx.SetNumValue("KasaGen", LiftData.KasaGen, LiftNumber);
            }
            if (LiftData.KasaDer > null)
            {
                this.xx.SetNumValue("KasaDer", LiftData.KasaDer, LiftNumber);
            }
            if (LiftData.AgrKasnakX > null)
            {
                this.xx.SetNumValue("AgrKasnakX", LiftData.AgrKasnakX, LiftNumber);
            }
            if (LiftData.AgrKasnakY > null)
            {
                this.xx.SetNumValue("AgrKasnakY", LiftData.AgrKasnakY, LiftNumber);
            }
            if (LiftData.TahrikKas > null)
            {
                this.xx.SetNumValue("TahrikKas", LiftData.TahrikKas, LiftNumber);
            }
            if (LiftData.SapKas > null)
            {
                this.xx.SetNumValue("SapKas", LiftData.SapKas, LiftNumber);
            }
            if (LiftData.AgrKasGen > null)
            {
                this.xx.SetNumValue("AgrKasGen", LiftData.AgrKasGen, LiftNumber);
            }
            if (LiftData.MDSapKas > null)
            {
                this.xx.SetNumValue("MDSapKas", LiftData.MDSapKas, LiftNumber);
            }
            if (LiftData.MDTahrikKas > null)
            {
                this.xx.SetNumValue("MDTahrikKas", LiftData.MDTahrikKas, LiftNumber);
            }
            if (LiftData.KapiYEksen > null)
            {
                this.xx.SetNumValue("KapiYEksen", LiftData.KapiYEksen, LiftNumber);
            }
            if (LiftData.KabinYEksen > null)
            {
                this.xx.SetNumValue("KabinYEksen", LiftData.KabinYEksen, LiftNumber);
            }
            if (LiftData.KKapiYEksen > null)
            {
                this.xx.SetNumValue("KKapiYEksen", LiftData.KKapiYEksen, LiftNumber);
            }
            if (LiftData.DKapiYEksen > null)
            {
                this.xx.SetNumValue("DKapiYEksen", LiftData.DKapiYEksen, LiftNumber);
            }
            if (LiftData.HidrolikGen > null)
            {
                this.xx.SetNumValue("HidrolikGen", LiftData.HidrolikGen, LiftNumber);
            }
            if (LiftData.PistonMer > null)
            {
                this.xx.SetNumValue("PistonMer", LiftData.PistonMer, LiftNumber);
            }
            if (LiftData.PistonKab > null)
            {
                this.xx.SetNumValue("PistonKab", LiftData.PistonKab, LiftNumber);
            }
            if (LiftData.HRA > null)
            {
                this.xx.SetNumValue("HRA", LiftData.HRA, LiftNumber);
            }
            if (LiftData.KabinHidrolikFark > null)
            {
                this.xx.SetNumValue("KabinHidrolikFark", LiftData.KabinHidrolikFark, LiftNumber);
            }
            if (LiftData.SagKonsolLIM > null)
            {
                this.xx.SetNumValue("SagKonsolLIM", LiftData.SagKonsolLIM, LiftNumber);
            }
            if (LiftData.KabArkaDuvLIM > null)
            {
                this.xx.SetNumValue("KabArkaDuvLIM", LiftData.KabArkaDuvLIM, LiftNumber);
            }
            if (LiftData.AgrKabin > null)
            {
                this.xx.SetNumValue("AgrKabin", LiftData.AgrKabin, LiftNumber);
            }
            if (LiftData.KabinDuvar > null)
            {
                this.xx.SetNumValue("KabinDuvar", LiftData.KabinDuvar, LiftNumber);
            }
            if (LiftData.SagRayDuv > null)
            {
                this.xx.SetNumValue("SagRayDuv", LiftData.SagRayDuv, LiftNumber);
            }
            if (LiftData.KabinRayFark > null)
            {
                this.xx.SetNumValue("KabinRayFark", LiftData.KabinRayFark, LiftNumber);
            }
            if (LiftData.AASol > null)
            {
                this.xx.SetNumValue("AASol", LiftData.AASol, LiftNumber);
            }
            if (LiftData.AASag > null)
            {
                this.xx.SetNumValue("AASag", LiftData.AASag, LiftNumber);
            }
            if (LiftData.BBSol > null)
            {
                this.xx.SetNumValue("BBSol", LiftData.BBSol, LiftNumber);
            }
            if (LiftData.BBSag > null)
            {
                this.xx.SetNumValue("BBSag", LiftData.BBSag, LiftNumber);
            }
            if (LiftData.MDaireH > null)
            {
                this.xx.SetNumValue("MDaireH", LiftData.MDaireH, LiftNumber);
            }
            if (LiftData.KapiGen > null)
            {
                this.xx.SetNumValue("KapiGen", LiftData.KapiGen, LiftNumber);
            }
            if (LiftData.AgrAnarayFark > null)
            {
                this.xx.SetNumValue("AgrAnarayFark", LiftData.AgrAnarayFark, LiftNumber);
            }
            if (LiftData.KabinAgrEksenFark > null)
            {
                this.xx.SetNumValue("KabinAgrEksenFark", LiftData.KabinAgrEksenFark, LiftNumber);
            }
            if (LiftData.SolKonsol > null)
            {
                this.xx.SetNumValue("SolKonsol", LiftData.SolKonsol, LiftNumber);
            }
            if (LiftData.SagKonsol > null)
            {
                this.xx.SetNumValue("SagKonsol", LiftData.SagKonsol, LiftNumber);
            }
            if (LiftData.KabinYanDuv > null)
            {
                this.xx.SetNumValue("KabinYanDuv", LiftData.KabinYanDuv, LiftNumber);
            }
            if (LiftData.RayTavan > null)
            {
                this.xx.SetNumValue("RayTavan", LiftData.RayTavan, LiftNumber);
            }
            if (LiftData.KuyuDibi > null)
            {
                this.xx.SetNumValue("KuyuDibi", LiftData.KuyuDibi, "1");
            }
            if (LiftData.IlkKat > null)
            {
                this.xx.SetNumValue("IlkKat", LiftData.IlkKat, "1");
            }
            if (LiftData.SonKat > null)
            {
                this.xx.SetNumValue("SonKat", LiftData.SonKat, "1");
            }
            if (LiftData.KuyuKafa > null)
            {
                this.xx.SetNumValue("KuyuKafa", LiftData.KuyuKafa, "1");
            }
            if (LiftData.DurakSayi > null)
            {
                this.xx.SetNumValue("DurakSayi", LiftData.DurakSayi, "1");
            }
            if (LiftData.IlkDurakNo > null)
            {
                this.xx.SetNumValue("IlkDurakNo", LiftData.IlkDurakNo, "1");
            }
            if (LiftData.SeyirMesafesi > null)
            {
                this.xx.SetNumValue("SeyirMesafesi", LiftData.SeyirMesafesi, "1");
            }
            if (LiftData.KuyuMesafesi > null)
            {
                this.xx.SetNumValue("KuyuMesafesi", LiftData.KuyuMesafesi, "1");
            }
            if (LiftData.IlkDurakKot > null)
            {
                this.xx.SetNumValue("IlkDurakKot", LiftData.IlkDurakKot, "1");
            }
            if (LiftData.SonDurakKot > null)
            {
                this.xx.SetNumValue("SonDurakKot", LiftData.SonDurakKot, "1");
            }
            if (LiftData.MDKot > null)
            {
                this.xx.SetNumValue("MDKot", LiftData.MDKot, "1");
            }
            if (LiftData.CalisYuksek > null)
            {
                this.xx.SetNumValue("CalisYuksek", LiftData.CalisYuksek, "1");
            }
            if (LiftData.KRX > null)
            {
                this.xx.SetNumValue("KRX", LiftData.KRX, LiftNumber);
            }
            if (LiftData.KRY > null)
            {
                this.xx.SetNumValue("KRY", LiftData.KRY, LiftNumber);
            }
            if (LiftData.KRZ > null)
            {
                this.xx.SetNumValue("KRZ", LiftData.KRZ, LiftNumber);
            }
            if (LiftData.ARX > null)
            {
                this.xx.SetNumValue("ARX", LiftData.ARX, LiftNumber);
            }
            if (LiftData.ARY > null)
            {
                this.xx.SetNumValue("ARY", LiftData.ARY, LiftNumber);
            }
            if (LiftData.ARZ > null)
            {
                this.xx.SetNumValue("ARZ", LiftData.ARZ, LiftNumber);
            }
            if (LiftData.KapiH > null)
            {
                this.xx.SetNumValue("KapiH", LiftData.KapiH, LiftNumber);
            }
            if (LiftData.BeyanYuk > null)
            {
                this.xx.SetNumValue("BeyanYuk", LiftData.BeyanYuk, LiftNumber);
            }
            if (LiftData.KabinP > null)
            {
                this.xx.SetNumValue("KabinP", LiftData.KabinP, LiftNumber);
            }
            if (LiftData.TipKodu > null)
            {
                this.xx.SetNumValue("TipKodu", LiftData.TipKodu, LiftNumber);
            }
            if (LiftData.TahrikKodu > null)
            {
                this.xx.SetNumValue("TahrikKodu", LiftData.TahrikKodu, LiftNumber);
            }
            if (LiftData.YonKodu > null)
            {
                this.xx.SetNumValue("YonKodu", LiftData.YonKodu, LiftNumber);
            }
            if (LiftData.KatYukListe > null)
            {
                this.xx.SetNumValue("KatYukListe", LiftData.KatYukListe, "1");
            }
            if (LiftData.TopKuyuKafa > null)
            {
                this.xx.SetNumValue("TopKuyuKafa", LiftData.TopKuyuKafa, "1");
            }
            if (LiftData.AraKatSTR > null)
            {
                this.xx.SetNumValue("AraKatSTR", LiftData.AraKatSTR, "1");
            }
            if (LiftData.KatRumuz > null)
            {
                this.xx.SetNumValue("KatRumuz", LiftData.KatRumuz, "1");
            }
            if (LiftData.MdTabTavan > null)
            {
                this.xx.SetNumValue("MdTabTavan", LiftData.MdTabTavan, "1");
            }
            if (LiftData.AgrGir > null)
            {
                this.xx.SetNumValue("AgrGir", LiftData.AgrGir, "1");
            }
            if (LiftData.KonsolMesafe > null)
            {
                this.xx.SetNumValue("KonsolMesafe", LiftData.KonsolMesafe, "1");
            }
            if (LiftData.AydinMesafe > null)
            {
                this.xx.SetNumValue("AydinMesafe", LiftData.AydinMesafe, "1");
            }
            if (LiftData.MerdivenX > null)
            {
                this.xx.SetNumValue("MerdivenX", LiftData.MerdivenX, LiftNumber);
            }
            if (LiftData.MerdivenFlip > null)
            {
                this.xx.SetNumValue("MerdivenFlip", LiftData.MerdivenFlip, LiftNumber);
            }
            if (LiftData.ButonX > null)
            {
                this.xx.SetNumValue("ButonX", LiftData.ButonX, LiftNumber);
            }
            if (LiftData.KabinRayStr > null)
            {
                this.xx.SetNumValue("KabinRayStr", LiftData.KabinRayStr, LiftNumber);
            }
            if (LiftData.AgrRayStr > null)
            {
                this.xx.SetNumValue("AgrRayStr", LiftData.AgrRayStr, LiftNumber);
            }
            this.KapiDegerSet(LiftData);
        }

        [CommandMethod("LiftDraw")]
        public void LiftDraw(clsMLift MainLift)
        {
            string str = "PL" + Convert.ToString(MainLift.LiftNum);
            string newValue = "L" + Convert.ToString(MainLift.LiftNum);
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database db = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (db)
                    {
                        using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                        {
                            foreach (vtLift lift in MainLift.BlokGrup)
                            {
                                this.InsertBlock(db, transaction, MainLift.BasePoint, lift.BlkInsName, false, lift.XData, Convert.ToString(MainLift.LiftNum), null, 1.0);
                            }
                            Point3d insertPoint = new Point3d(0.0, 0.0, 0.0);
                            foreach (structDimblk dimblk in MainLift.DimBlkList)
                            {
                                BlockReference reference = null;
                                reference = this.InsertBlock(db, transaction, insertPoint, dimblk.DimBlk, false, "DIMBLK", "LN", null, 1.0);
                                reference.ExplodeToOwnerSpace();
                                reference.Erase();
                                this.vtCHXdata(MainLift.LiftNum);
                                this.chParamVal("DimAnaX" + Convert.ToString(MainLift.LiftNum), Convert.ToString(MainLift.BasePoint.get_X()));
                            }
                            foreach (ConsParList list in MainLift.DimGrup)
                            {
                                this.RenameParam(list.ConsName, str + list.ConsName);
                            }
                            foreach (ParamList list2 in MainLift.VarGrup)
                            {
                                this.NewParam(list2.ParamName, "1");
                            }
                            foreach (ParamList list3 in MainLift.VarGrup)
                            {
                                this.chParamVal(list3.ParamName, list3.ParamValue);
                            }
                            foreach (vtLift lift2 in MainLift.BlokGrup)
                            {
                                foreach (ParamList list4 in lift2.BlkParamList)
                                {
                                    if ((list4.ParamName != null) || (list4.ParamValue > null))
                                    {
                                        string vtParName = newValue + list4.ParamName;
                                        this.NewParam(vtParName, list4.ParamValue);
                                    }
                                }
                            }
                            foreach (ConsParList list5 in MainLift.DimGrup)
                            {
                                string newName = list5.ConsValue.ToString();
                                while (newName.IndexOf("LLNUM") != -1)
                                {
                                    newName = newName.Replace("LLNUM", newValue);
                                }
                                this.chParamVal(str + list5.ConsName, newName);
                            }
                            foreach (ParamList list6 in MainLift.VarGrup)
                            {
                                this.RenameParam(list6.ParamName, newValue + list6.ParamName);
                            }
                            transaction.Commit();
                        }
                    }
                    Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("DIMREGEN ", true, false, false);
                    Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("REGENALL ", true, false, false);
                    Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("CONSTRAINTBAR\nALL\n\nHIDE\n", true, false, false);
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        public void LiftDraw2(clsMLift MainLift, bool OldNew = true)
        {
            string lLNum = "PL" + Convert.ToString(MainLift.LiftNum);
            string str2 = "L" + Convert.ToString(MainLift.LiftNum);
            if (!OldNew)
            {
                MainLift.Olcek = Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
            }
            double scale = 0.0;
            if ((MainLift.Olcek == 1.0) || (MainLift.Olcek == 0.0))
            {
                scale = 1.0;
                Application.SetSystemVariable("DIMSCALE", 40.0);
                Application.SetSystemVariable("DIMLFAC", 1.0);
            }
            else
            {
                scale = 1.0 / Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
                Application.SetSystemVariable("DIMLFAC", Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1")));
            }
            Scale3d scaled = new Scale3d();
            this.prman.aadd = this;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database db = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (db)
                    {
                        Entity entity;
                        if (OldNew)
                        {
                            using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                            {
                                structDimblk dimblk;
                                foreach (vtLift lift in MainLift.BlokGrup)
                                {
                                    if (((MainLift.KesitKodu != "MD") || (MainLift.LiftNum != 2)) || (lift.XData != "MDaire"))
                                    {
                                        this.InsertBlock(db, transaction, MainLift.BasePoint, lift.BlkInsName, false, lift.XData, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu, scale);
                                    }
                                }
                                if ((MainLift.KesitKodu == "KK") || (MainLift.KesitKodu == "KD"))
                                {
                                    BlockReference reference = null;
                                    dimblk = MainLift.DimBlkList[0];
                                    reference = this.InsertBlock(db, transaction, MainLift.BasePoint, dimblk.DimBlk, false, "DIMBLK", "LN", MainLift.KesitKodu, 1.0);
                                    reference.ExplodeToOwnerSpace();
                                    reference.Erase();
                                    this.vtCHXdataDIM(MainLift.LiftNum, MainLift.KesitKodu);
                                    this.vtCHXdata(MainLift.LiftNum);
                                }
                                if ((MainLift.LiftNum == 1) && ((MainLift.Tahrik.TahrikKodu == "EA") || (MainLift.KesitKodu == "MD")))
                                {
                                    BlockReference reference2 = null;
                                    dimblk = MainLift.DimBlkList[0];
                                    reference2 = this.InsertBlock(db, transaction, MainLift.BasePoint, dimblk.DimBlk, false, "DIMBLKMD", "LN", MainLift.KesitKodu, 1.0);
                                    reference2.ExplodeToOwnerSpace();
                                    reference2.Erase();
                                    this.vtCHXdataDIM(MainLift.LiftNum, MainLift.KesitKodu);
                                    this.vtCHXdata(MainLift.LiftNum);
                                }
                                transaction.Commit();
                            }
                        }
                        foreach (vtLift lift2 in MainLift.BlokGrup)
                        {
                            using (Transaction transaction2 = db.get_TransactionManager().StartTransaction())
                            {
                                entity = FObject(lift2.XData, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    BlockReference reference3 = transaction2.GetObject(entity.get_ObjectId(), 0);
                                    reference3.UpgradeOpen();
                                    reference3.set_Position(MainLift.BasePoint);
                                    scaled = reference3.get_ScaleFactors();
                                    this.SetDynamicValue(db, transaction2, entity, lift2, str2, scaled.get_X(), MainLift.KesitKodu);
                                }
                                transaction2.Commit();
                            }
                        }
                        if (((MainLift.KesitKodu == "KK") || (MainLift.KesitKodu == "KD")) || ((MainLift.Tahrik.TipKodu == "EA") && (MainLift.KesitKodu == "MD")))
                        {
                            entity = FObject("DIMDYN" + MainLift.KesitKodu, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                            if (entity != null)
                            {
                                using (Transaction transaction3 = db.get_TransactionManager().StartTransaction())
                                {
                                    BlockReference reference4 = transaction3.GetObject(entity.get_ObjectId(), 0);
                                    reference4.UpgradeOpen();
                                    reference4.set_Position(MainLift.BasePoint);
                                    scaled = reference4.get_ScaleFactors();
                                    this.SetDynamicValue(db, transaction3, entity, MainLift, lLNum, scaled.get_X(), MainLift.KesitKodu);
                                    transaction3.Commit();
                                }
                            }
                            this.dimdene2(Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu, MainLift.BasePoint, OldNew);
                            if ((MainLift.Tahrik.TahrikKodu == "MDCAP") || (MainLift.Tahrik.TahrikKodu == "SD"))
                            {
                                entity = FObject("Capraz", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    using (Transaction transaction4 = db.get_TransactionManager().StartTransaction())
                                    {
                                        double num2 = Convert.ToDouble(this.prman.GetParamValFRM(str2 + "AKenar", MainLift.KesitKodu));
                                        double num3 = Convert.ToDouble(this.prman.GetParamValFRM(str2 + "BKenar", MainLift.KesitKodu));
                                        double num4 = Math.Sqrt((num2 * num2) + (num3 * num3));
                                        double d = num2 / num4;
                                        if (MainLift.Tahrik.YonKodu == "SAG")
                                        {
                                            this.SetDynamicValue(db, transaction4, entity, "dynRotAng", Math.Asin(d));
                                        }
                                        else
                                        {
                                            this.SetDynamicValue(db, transaction4, entity, "dynRotAng", (double) (3.1415926535897931 - Math.Asin(Math.Abs(d))));
                                        }
                                        BlockReference reference5 = transaction4.GetObject(entity.get_ObjectId(), 0);
                                        reference5.UpgradeOpen();
                                        reference5.set_Position(MainLift.BasePoint);
                                        scaled = reference5.get_ScaleFactors();
                                        this.SetDynamicValue(db, transaction4, entity, "Distance1", (double) (Convert.ToInt32(num4) * scaled.get_X()));
                                        transaction4.Commit();
                                    }
                                }
                            }
                            if (((MainLift.KesitKodu == "KK") || (MainLift.KesitKodu == "KD")) && (MainLift.Tahrik.TipKodu == "EA"))
                            {
                                entity = FObject("RegUst", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    using (Transaction transaction5 = db.get_TransactionManager().StartTransaction())
                                    {
                                        switch (this.GetNumValue("RegYer", Convert.ToString(MainLift.LiftNum)))
                                        {
                                            case "1":
                                                this.SetDynamicValue(db, transaction5, entity, "dynRegFlipX", (double) 1.0);
                                                this.SetDynamicValue(db, transaction5, entity, "dynRegFlipY", (double) 1.0);
                                                break;

                                            case "2":
                                                this.SetDynamicValue(db, transaction5, entity, "dynRegFlipX", (double) 0.0);
                                                this.SetDynamicValue(db, transaction5, entity, "dynRegFlipY", (double) 1.0);
                                                break;

                                            case "3":
                                                this.SetDynamicValue(db, transaction5, entity, "dynRegFlipX", (double) 0.0);
                                                this.SetDynamicValue(db, transaction5, entity, "dynRegFlipY", (double) 0.0);
                                                break;

                                            case "4":
                                                this.SetDynamicValue(db, transaction5, entity, "dynRegFlipX", (double) 1.0);
                                                this.SetDynamicValue(db, transaction5, entity, "dynRegFlipY", (double) 0.0);
                                                break;
                                        }
                                        transaction5.Commit();
                                    }
                                }
                            }
                            if (MainLift.KesitKodu == "MD")
                            {
                                entity = FObject("MDEksenYan", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity == null)
                                {
                                    entity = FObject("MDEksenSag", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                }
                                if (entity == null)
                                {
                                    entity = FObject("MDEksenArka", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                }
                                if (entity != null)
                                {
                                    double num6 = (2.0 * Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum)))) + (1.5 * Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum))));
                                    num6 = (num6 + 300.0) + 100.0;
                                    num6 += Convert.ToDouble(this.GetNumValue("FMakine", Convert.ToString(MainLift.LiftNum)));
                                    num6 *= 9.81;
                                    this.ChTag(entity.get_ObjectId(), "TAGPS", $"PS {num6:0}N");
                                }
                                entity = FObject("MDaire", "1", MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    this.ChTag(entity.get_ObjectId(), "KUYU", "MAKINE DAIRESI KESITI O:1/" + this.GetNumValue("MDOLCEK", "1"));
                                }
                            }
                            if (MainLift.KesitKodu == "KD")
                            {
                                double num7;
                                entity = FObject("KotSembolUst", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    this.ChTag(entity.get_ObjectId(), "KOT", this.GetNumValue("KuyuDibi", Convert.ToString(MainLift.LiftNum)));
                                }
                                entity = FObject("KabinRay", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    num7 = Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
                                    num7 = 39.24 * num7;
                                    this.ChTag(entity.get_ObjectId(), "TAGP1", $"{num7:0}N");
                                    num7 = Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
                                    num7 = (19.62 * num7) / 2.0;
                                    this.ChTag(entity.get_ObjectId(), "TAGPR1", $"{num7:0}N" + " - " + this.GetNumValue("KabinRayStr", Convert.ToString(MainLift.LiftNum)));
                                    this.ChTag(entity.get_ObjectId(), "TAGPR2", $"{num7:0}N");
                                }
                                entity = FObject("AgrRay", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    num7 = (0.5 * Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum)))) + Convert.ToDouble(this.GetNumValue("KabinAgir", Convert.ToString(MainLift.LiftNum)));
                                    num7 = 39.24 * num7;
                                    this.ChTag(entity.get_ObjectId(), "TAGP2", $"P2 {num7:0}N" + " - " + this.GetNumValue("AgrRayStr", Convert.ToString(MainLift.LiftNum)));
                                }
                            }
                            if (MainLift.KesitKodu == "KK")
                            {
                                entity = FObject("Kabin", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    this.ChTag(entity.get_ObjectId(), "KABINALAN", "KABiN:" + $"{((Convert.ToDecimal(this.prman.GetParamValFRM(str2 + "KabinGen", MainLift.KesitKodu)) * Convert.ToDecimal(this.prman.GetParamValFRM(str2 + "KabinDer", MainLift.KesitKodu))) / 1000000M):0.##}" + "m2");
                                    this.beyanqbul(Convert.ToString(MainLift.LiftNum));
                                }
                                entity = FObject("AgrRay", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    this.ChTag(entity.get_ObjectId(), "TAGP2", " ");
                                }
                            }
                            if (((MainLift.KesitKodu == "KK") || (MainLift.KesitKodu == "KD")) && (MainLift.Tahrik.TipKodu == "HA"))
                            {
                                entity = FObject("HidrolikSemer", Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                                if (entity != null)
                                {
                                    using (Transaction transaction6 = db.get_TransactionManager().StartTransaction())
                                    {
                                        if (MainLift.Tahrik.YonKodu == "SOL")
                                        {
                                            this.SetDynamicValue(db, transaction6, entity, "Angle1", (double) 0.0);
                                        }
                                        if (MainLift.Tahrik.YonKodu == "SAG")
                                        {
                                            this.SetDynamicValue(db, transaction6, entity, "Angle1", (double) 3.14159265);
                                        }
                                        if (MainLift.Tahrik.YonKodu == "ARKA")
                                        {
                                            this.SetDynamicValue(db, transaction6, entity, "Angle1", (double) 4.7123889750000005);
                                        }
                                        transaction6.Commit();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        [CommandMethod("LN")]
        public void LN()
        {
            if (this.GetParamValue("LN") == null)
            {
                this.NewParam("LN", "1");
            }
        }

        [CommandMethod("LockLayer")]
        public static void LockLayer()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                string str = "ABC";
                if (!table.Has(str))
                {
                    using (LayerTableRecord record = new LayerTableRecord())
                    {
                        record.set_Name(str);
                        table.UpgradeOpen();
                        table.Add(record);
                        transaction.AddNewlyCreatedDBObject(record, true);
                        record.set_IsLocked(true);
                    }
                }
                else
                {
                    (transaction.GetObject(table.get_Item(str), 1) as LayerTableRecord).set_IsLocked(true);
                }
                transaction.Commit();
            }
        }

        [CommandMethod("MDDUZ")]
        public void MD()
        {
            this.DALL();
            this.xx.SetNumValue("TahrikKodu", "MDDUZ", "1");
        }

        [CommandMethod("MDCAP")]
        public void MDCAP()
        {
            this.DALL();
            this.xx.SetNumValue("TahrikKodu", "MDCAP", "1");
        }

        public void MDCiz(int ToplamKuyuGen, int KuyuDer)
        {
            Entity vtEnt = null;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database db = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (db)
                    {
                        using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                        {
                            Point3d insertPoint = new Point3d(0.0, 0.0, 0.0);
                            BlockReference reference = this.InsertBlock(db, transaction, insertPoint, "MD", false, "MD", "1", "0", 1.0);
                            vtEnt = FObject("MD", "1", "0");
                            if (vtEnt != null)
                            {
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) ToplamKuyuGen);
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuDer", (double) KuyuDer);
                                this.SetDynamicValue(db, transaction, vtEnt, "dynAASol", Convert.ToDouble(this.GetNumValue("AASol", "1")));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynBBSol", Convert.ToDouble(this.GetNumValue("BBSol", "1")));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynAASag", Convert.ToDouble(this.GetNumValue("AASag", "1")));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynBBSag", Convert.ToDouble(this.GetNumValue("BBSag", "1")));
                                this.ChTag(vtEnt.get_ObjectId(), "KUYU", "MAKINE DAIRESI KESITI O:1/" + this.GetNumValue("MDOLCEK", "1"));
                            }
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        public void MoveLiftBlock(double ValueFark)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = HostApplicationServices.get_WorkingDatabase();
            string str = "I";
            string str2 = "2";
            TypedValue[] valueArray = new TypedValue[] { new TypedValue(0x3e9, str) };
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                foreach (ObjectId id in record)
                {
                    Entity entity = transaction.GetObject(id, 1, false, true);
                    ResultBuffer xDataForApplication = entity.GetXDataForApplication(str);
                    if (xDataForApplication != null)
                    {
                        foreach (TypedValue value2 in xDataForApplication.AsArray())
                        {
                            if (((value2.get_TypeCode() == 0x3e8) && (((string) value2.get_Value()) == str2)) && (entity.get_ObjectId().get_ObjectClass().get_DxfName() == "INSERT"))
                            {
                                DBObject obj2 = transaction.GetObject(entity.get_ObjectId(), 0);
                                if (obj2 is BlockReference)
                                {
                                    BlockReference reference = obj2 as BlockReference;
                                    reference.set_Position(new Point3d(reference.get_Position().get_X() + ValueFark, 0.0, 0.0));
                                }
                            }
                        }
                    }
                }
                transaction.Commit();
            }
        }

        public void NewParam(string vtParName, string newValue)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
        }

        [CommandMethod("WNOD")]
        public void nodayaz()
        {
            string str = "";
            DataTable table = this.xx.dtta("select * from Num1", "");
            for (int i = 0; i < table.Rows.Count; i++)
            {
            }
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            try
            {
                using (Transaction transaction = database.get_TransactionManager().StartTransaction())
                {
                    DBDictionary dictionary = transaction.GetObject(database.get_NamedObjectsDictionaryId(), 1);
                    Xrecord xrecord = new Xrecord();
                    TypedValue[] valueArray1 = new TypedValue[] { new TypedValue(1, str) };
                    xrecord.set_Data(new ResultBuffer(valueArray1));
                    dictionary.SetAt("ASCADDATA", xrecord);
                    transaction.AddNewlyCreatedDBObject(xrecord, true);
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                database.Dispose();
            }
        }

        [CommandMethod("nodoku")]
        public void nodoku()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            try
            {
                using (Transaction transaction = database.get_TransactionManager().StartTransaction())
                {
                    DBDictionary dictionary = transaction.GetObject(database.get_NamedObjectsDictionaryId(), 1);
                    Xrecord xrecord = new Xrecord();
                    ObjectId at = dictionary.GetAt("ASCADDATA");
                    Xrecord xrecord2 = transaction.GetObject(at, 0);
                    ResultBufferEnumerator enumerator = xrecord2.get_Data().GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TypedValue value2 = enumerator.get_Current();
                        Debug.Print("===== OUR DATA: " + value2.get_TypeCode().ToString() + ". " + value2.get_Value().ToString());
                    }
                }
            }
            catch
            {
            }
        }

        [CommandMethod("ANTETINFO")]
        public void palette()
        {
            if (this.myPaletteSet == null)
            {
                this.myPaletteSet = new PaletteSet("As-CAD", Guid.NewGuid());
                this.myPalette.AscadDLL = this;
                this.myPaletteSet.Add("As-CAD", this.myPalette);
                this.myPalette.kabinderx.Text = this.prman.GetParamValFRM("L1KabinGen", "KK");
                this.myPalette.kabingenx.Text = this.prman.GetParamValFRM("L1KabinDer", "KK");
            }
            this.myPaletteSet.set_Visible(true);
        }

        [CommandMethod("PDrawing")]
        public void PDrawing()
        {
            clsMLift mainLift = new clsMLift();
            mainLift = this.ReadAllData("1", "KK");
            mainLift.LiftNum = Convert.ToInt32("1");
            this.PDrawing(mainLift);
        }

        public void PDrawing(clsMLift MainLift)
        {
            Entity vtEnt = null;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database dbE = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (dbE)
                    {
                        using (Transaction transaction = dbE.get_TransactionManager().StartTransaction())
                        {
                            string str2 = "PL" + Convert.ToString(MainLift.LiftNum);
                            string str3 = "L" + Convert.ToString(MainLift.LiftNum);
                            foreach (vtLift lift in MainLift.BlokGrup)
                            {
                                vtEnt = FObject(lift.XData, Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt != null)
                                {
                                    foreach (ParamList list in lift.BlkParamList)
                                    {
                                        double num = Convert.ToDouble(this.GetParamValue(str3 + list.ParamName));
                                        this.SetDynamicValue(dbE, transaction, vtEnt, list.ParamName, Math.Abs(num));
                                    }
                                }
                            }
                            if ((MainLift.Tahrik.TahrikKodu == "MDCAP") || (MainLift.Tahrik.TahrikKodu == "SD"))
                            {
                                vtEnt = FObject("Capraz", Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt != null)
                                {
                                    double num2 = Convert.ToDouble(this.GetParamValue(str3 + "AKenar"));
                                    double num3 = Convert.ToDouble(this.GetParamValue(str3 + "BKenar"));
                                    double num4 = Math.Sqrt((num2 * num2) + (num3 * num3));
                                    double d = num2 / num4;
                                    if (MainLift.Tahrik.YonKodu == "SAG")
                                    {
                                        this.SetDynamicValue(dbE, transaction, vtEnt, "dynRotAng", Math.Asin(d));
                                    }
                                    else
                                    {
                                        this.SetDynamicValue(dbE, transaction, vtEnt, "dynRotAng", (double) (3.1415926535897931 - Math.Asin(Math.Abs(d))));
                                    }
                                    this.SetDynamicValue(dbE, transaction, vtEnt, "Distance1", (double) Convert.ToInt32(num4));
                                }
                            }
                            if (((MainLift.KesitKodu == "KK") || (MainLift.KesitKodu == "KD")) && (MainLift.Tahrik.TipKodu == "EA"))
                            {
                                vtEnt = FObject("RegUst", Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt != null)
                                {
                                    string numValue = this.GetNumValue("RegYer", Convert.ToString(MainLift.LiftNum));
                                    if (numValue != "1")
                                    {
                                        if (numValue == "2")
                                        {
                                            goto Label_038B;
                                        }
                                        if (numValue == "3")
                                        {
                                            goto Label_03C1;
                                        }
                                        if (numValue == "4")
                                        {
                                            goto Label_03F7;
                                        }
                                    }
                                    else
                                    {
                                        this.SetDynamicValue(dbE, transaction, vtEnt, "dynRegFlipX", (double) 1.0);
                                        this.SetDynamicValue(dbE, transaction, vtEnt, "dynRegFlipY", (double) 1.0);
                                    }
                                }
                            }
                            goto Label_0431;
                        Label_038B:
                            this.SetDynamicValue(dbE, transaction, vtEnt, "dynRegFlipX", (double) 0.0);
                            this.SetDynamicValue(dbE, transaction, vtEnt, "dynRegFlipY", (double) 1.0);
                            goto Label_0431;
                        Label_03C1:
                            this.SetDynamicValue(dbE, transaction, vtEnt, "dynRegFlipX", (double) 0.0);
                            this.SetDynamicValue(dbE, transaction, vtEnt, "dynRegFlipY", (double) 0.0);
                            goto Label_0431;
                        Label_03F7:
                            this.SetDynamicValue(dbE, transaction, vtEnt, "dynRegFlipX", (double) 1.0);
                            this.SetDynamicValue(dbE, transaction, vtEnt, "dynRegFlipY", (double) 0.0);
                        Label_0431:
                            if (MainLift.KesitKodu == "MD")
                            {
                                vtEnt = FObject("MDEksenYan", Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt == null)
                                {
                                    vtEnt = FObject("MDEksenSag", Convert.ToString(MainLift.LiftNum), "0");
                                }
                                if (vtEnt == null)
                                {
                                    vtEnt = FObject("MDEksenArka", Convert.ToString(MainLift.LiftNum), "0");
                                }
                                if (vtEnt != null)
                                {
                                    double num6 = (2.0 * Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum)))) + (1.5 * Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum))));
                                    num6 = (num6 + 300.0) + 100.0;
                                    num6 += Convert.ToDouble(this.GetNumValue("FMakine", Convert.ToString(MainLift.LiftNum)));
                                    num6 *= 9.81;
                                    this.ChTag(vtEnt.get_ObjectId(), "TAGPS", $"PS {num6:0}N");
                                }
                                vtEnt = FObject("MDaire", "1", "0");
                                if (vtEnt != null)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "KUYU", "MAKINE DAIRESI KESITI O:1/" + this.GetNumValue("MDOLCEK", "1"));
                                }
                            }
                            if (MainLift.KesitKodu == "KD")
                            {
                                double num7;
                                this.beyanqbul(Convert.ToString(MainLift.LiftNum));
                                vtEnt = FObject("KotSembolUst", Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt != null)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "KOT", "-1500");
                                }
                                vtEnt = FObject("KabinRay", Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt != null)
                                {
                                    num7 = Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
                                    num7 = 39.24 * num7;
                                    this.ChTag(vtEnt.get_ObjectId(), "TAGP1", $"{num7:0}N");
                                    num7 = Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum))) + Convert.ToDouble(this.GetNumValue("KabinP", Convert.ToString(MainLift.LiftNum)));
                                    num7 = (19.62 * num7) / 2.0;
                                    this.ChTag(vtEnt.get_ObjectId(), "TAGPR1", $"{num7:0}N" + " - " + this.GetNumValue("KabinRayStr", Convert.ToString(MainLift.LiftNum)));
                                    this.ChTag(vtEnt.get_ObjectId(), "TAGPR2", $"{num7:0}N");
                                }
                                vtEnt = FObject("AgrRay", Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt != null)
                                {
                                    num7 = (0.5 * Convert.ToDouble(this.GetNumValue("BeyanYuk", Convert.ToString(MainLift.LiftNum)))) + Convert.ToDouble(this.GetNumValue("KabinAgir", Convert.ToString(MainLift.LiftNum)));
                                    num7 = 39.24 * num7;
                                    this.ChTag(vtEnt.get_ObjectId(), "TAGP2", $"P2 {num7:0}N" + " - " + this.GetNumValue("AgrRayStr", Convert.ToString(MainLift.LiftNum)));
                                }
                            }
                            if (MainLift.KesitKodu == "KK")
                            {
                                vtEnt = FObject("Kabin", Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt != null)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "KABINALAN", "KABiN:" + $"{((Convert.ToDecimal(this.GetParamValue(str3 + "KabinGen")) * Convert.ToDecimal(this.GetParamValue(str3 + "KabinDer"))) / 1000000M):0.##}" + "m2");
                                }
                                vtEnt = FObject("AgrRay", Convert.ToString(MainLift.LiftNum), "0");
                                if (vtEnt != null)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "TAGP2", " ");
                                }
                            }
                            string myvalue = "EmKork";
                            vtEnt = FObject("KabinBase", Convert.ToString(MainLift.LiftNum), "0");
                            if (vtEnt != null)
                            {
                                if (Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, "dynSolKD")) > 300.0)
                                {
                                    myvalue = myvalue + "1";
                                }
                                else
                                {
                                    myvalue = myvalue + "0";
                                }
                                if (Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, "dynArkaKD")) > 300.0)
                                {
                                    myvalue = myvalue + "1";
                                }
                                else
                                {
                                    myvalue = myvalue + "0";
                                }
                                if (Convert.ToDouble(this.GetDynamicValue(dbE, transaction, vtEnt, "dynSagKD")) > 300.0)
                                {
                                    myvalue = myvalue + "1";
                                }
                                else
                                {
                                    myvalue = myvalue + "0";
                                }
                            }
                            vtEnt = FObject("EmniyetKorkuluk", Convert.ToString(MainLift.LiftNum), "0");
                            if (vtEnt != null)
                            {
                                this.SetDynamicValue(dbE, transaction, vtEnt, "Visibility1", myvalue);
                            }
                            Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("DIMREGEN ", true, false, false);
                            Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("REGENALL ", true, false, false);
                            Application.get_DocumentManager().get_MdiActiveDocument().SendStringToExecute("CONSTRAINTBAR\nALL\n\nHIDE\n", true, false, false);
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        [CommandMethod("ProjeAc")]
        public void ProjeAc()
        {
            if (!Directory.Exists(@"c:\SZG\Proje"))
            {
                Directory.CreateDirectory(@"c:\SZG\Proje");
            }
            if (!Directory.Exists(@"c:\asnproje"))
            {
                Directory.CreateDirectory(@"c:\asnproje");
            }
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Proje Dosyası|*.prj",
                InitialDirectory = @"c:\SZG\Proje",
                OverwritePrompt = false,
                CreatePrompt = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(dialog.FileName);
                string str = info.Name.Substring(0, info.Name.Length - 4);
                if (Directory.Exists(@"c:\asnproje\" + str))
                {
                    Directory.CreateDirectory(@"c:\asnproje\" + str);
                    if (File.Exists(@"c:\asnproje\KuyuKabin.dwg"))
                    {
                        File.Delete(@"c:\asnproje\KuyuKabin.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\KuyuDibi.dwg"))
                    {
                        File.Delete(@"c:\asnproje\KuyuDibi.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\MakDaire.dwg"))
                    {
                        File.Delete(@"c:\asnproje\MakDaire.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\TKAA.dwg"))
                    {
                        File.Delete(@"c:\asnproje\TKAA.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\TKBB.dwg"))
                    {
                        File.Delete(@"c:\asnproje\TKBB.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\TUMTKAA.dwg"))
                    {
                        File.Delete(@"c:\asnproje\TUMTKAA.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\TUMTKBB.dwg"))
                    {
                        File.Delete(@"c:\asnproje\TUMTKBB.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\" + str + @"\KuyuKabin.dwg"))
                    {
                        File.Copy(@"c:\asnproje\" + str + @"\KuyuKabin.dwg", @"c:\asnproje\KuyuKabin.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\" + str + @"\KuyuDibi.dwg"))
                    {
                        File.Copy(@"c:\asnproje\" + str + @"\KuyuDibi.dwg", @"c:\asnproje\KuyuDibi.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\" + str + @"\MakDaire.dwg"))
                    {
                        File.Copy(@"c:\asnproje\" + str + @"\MakDaire.dwg", @"c:\asnproje\MakDaire.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\" + str + @"\TKAA.dwg"))
                    {
                        File.Copy(@"c:\asnproje\" + str + @"\TKAA.dwg", @"c:\asnproje\TKAA.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\" + str + @"\TKBB.dwg"))
                    {
                        File.Copy(@"c:\asnproje\" + str + @"\TKBB.dwg", @"c:\asnproje\TKBB.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\" + str + @"\TUMTKAA.dwg"))
                    {
                        File.Copy(@"c:\asnproje\" + str + @"\TUMTKAA.dwg", @"c:\asnproje\TUMTKAA.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\" + str + @"\TUMTKBB.dwg"))
                    {
                        File.Copy(@"c:\asnproje\" + str + @"\TUMTKBB.dwg", @"c:\asnproje\TUMTKBB.dwg");
                    }
                    string[] textArray1 = new string[] { @"c:\asnproje\", str, @"\", str, ".dwg" };
                    if (File.Exists(string.Concat(textArray1)))
                    {
                        File.Copy(@"c:\asnproje\" + str + @"\" + str + ".dwg", @"c:\asnproje\" + str + ".dwg");
                    }
                    string str2 = @"c:\asnproje\" + str + ".dwg";
                    Application.get_DocumentManager().Open(str2, false);
                }
            }
        }

        [CommandMethod("ProjeKaydet")]
        public void ProjeKaydet()
        {
            if (!Directory.Exists(@"c:\SZG\Proje"))
            {
                Directory.CreateDirectory(@"c:\SZG\Proje");
            }
            if (!Directory.Exists(@"c:\asnproje"))
            {
                Directory.CreateDirectory(@"c:\asnproje");
            }
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Proje Dosyası|*.prj",
                InitialDirectory = @"c:\SZG\Proje",
                OverwritePrompt = true,
                CreatePrompt = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dialog.FileName);
                writer.WriteLine(dialog.FileName);
                writer.Close();
                Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage("Girilen dosya adı: " + dialog.FileName);
                FileInfo info = new FileInfo(dialog.FileName);
                string str = info.Name.Substring(0, info.Name.Length - 4);
                if (!Directory.Exists(@"c:\asnproje\" + str))
                {
                    Directory.CreateDirectory(@"c:\asnproje\" + str);
                    if (File.Exists(@"c:\asnproje\KuyuKabin.dwg"))
                    {
                        File.Move(@"c:\asnproje\KuyuKabin.dwg", @"c:\asnproje\" + str + @"\KuyuKabin.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\KuyuDibi.dwg"))
                    {
                        File.Move(@"c:\asnproje\KuyuDibi.dwg", @"c:\asnproje\" + str + @"\KuyuDibi.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\MakDaire.dwg"))
                    {
                        File.Move(@"c:\asnproje\MakDaire.dwg", @"c:\asnproje\" + str + @"\MakDaire.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\TKAA.dwg"))
                    {
                        File.Move(@"c:\asnproje\TKAA.dwg", @"c:\asnproje\" + str + @"\TKAA.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\TKBB.dwg"))
                    {
                        File.Move(@"c:\asnproje\TKBB.dwg", @"c:\asnproje\" + str + @"\TKBB.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\TUMTKAA.dwg"))
                    {
                        File.Move(@"c:\asnproje\TUMTKAA.dwg", @"c:\asnproje\" + str + @"\TUMTKAA.dwg");
                    }
                    if (File.Exists(@"c:\asnproje\TUMTKBB.dwg"))
                    {
                        File.Move(@"c:\asnproje\TUMTKBB.dwg", @"c:\asnproje\" + str + @"\TUMTKBB.dwg");
                    }
                    Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                    string[] textArray1 = new string[] { @"c:\asnproje\", str, @"\", str, ".dwg" };
                    string str2 = string.Concat(textArray1);
                    document.get_Database().SaveAs(str2, true, 0x1f, document.get_Database().get_SecurityParameters());
                    Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().WriteMessage(str + " PROJESİ KAYDEDİLDİ..");
                }
            }
        }

        [CommandMethod("ProjeSil")]
        public void ProjeSil()
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Proje Dosyası|*.prj",
                InitialDirectory = @"c:\SZG\Proje",
                OverwritePrompt = false,
                CreatePrompt = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(dialog.FileName);
                File.Delete(dialog.FileName);
                string str = info.Name.Substring(0, info.Name.Length - 4);
                if (Directory.Exists(@"c:\asnproje\" + str))
                {
                    Directory.Delete(@"c:\asnproje\" + str, true);
                }
            }
        }

        [CommandMethod("Q")]
        public void QGetXData()
        {
            this.DD();
        }

        private double RadianToDegree(double angle) => 
            (angle * 57.295779513082323);

        [CommandMethod("RAMD")]
        public void RAMD()
        {
            this.DALL();
            this.xx.SetNumValue("TahrikKodu", "RAMD", "1");
        }

        [CommandMethod("RD")]
        public void RD()
        {
            clsMLift lift = new clsMLift();
            string kesitKodu = "KK";
            lift = this.ReadAllData("1", kesitKodu);
        }

        public clsMLift ReadAllData(string LiftNumber, string KesitKodu)
        {
            clsMLift lift = new clsMLift {
                KesitKodu = KesitKodu
            };
            structKatBilgileri bilgileri = new structKatBilgileri {
                DurakSayi = "5",
                IlkDurakNo = "0",
                KuyuMesafesi = "15.000",
                SeyirMesafesi = "10.250"
            };
            lift.KatBilgileri = bilgileri;
            lift.Pan = this.GetNumValue("Pan", LiftNumber);
            structTahrik tahrik = new structTahrik();
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            try
            {
                try
                {
                    ParamList list4;
                    tahrik.TipKodu = this.GetNumValue("TipKodu", LiftNumber);
                    tahrik.TahrikKodu = this.GetNumValue("TahrikKodu", LiftNumber);
                    tahrik.YonKodu = this.GetNumValue("YonKodu", LiftNumber);
                    if (tahrik.YonKodu == "ARKA")
                    {
                        lift.Pan = "0";
                    }
                    lift.Tahrik = tahrik;
                    DataTable table3 = new DataTable();
                    table3 = this.xx.dtta("select id,bmblockname,BlkInsName,XData from `BLK` WHERE (TipKodu LIKE '%" + tahrik.TipKodu + "%' or TipKodu='TEMEL') and (TahrikKodu LIKE'%" + tahrik.TahrikKodu + "%' or TahrikKodu='TEMEL')  and (YonKodu LIKE '%" + tahrik.YonKodu + "%' or YonKodu='TEMEL') and KesitKodu='" + lift.KesitKodu + "' ORDER BY sno", "");
                    if (table3.Rows.Count > 0)
                    {
                        for (int i = 0; i < table3.Rows.Count; i++)
                        {
                            vtLift item = new vtLift {
                                BlkName = table3.Rows[i]["bmblockname"].ToString(),
                                BlkInsName = table3.Rows[i]["BlkInsName"].ToString()
                            };
                            if ((tahrik.TahrikKodu != "HY") || ((item.BlkInsName != "HSSol") && (item.BlkInsName != "HidrolikEksen")))
                            {
                                if (((KesitKodu == "KK") && (lift.Pan == "1")) && (item.BlkInsName == "Kabin1-DYN"))
                                {
                                    item.BlkInsName = "KabinPan";
                                    vtLift lift3 = new vtLift {
                                        BlkName = "PanBLK",
                                        BlkInsName = "PanBLK",
                                        XData = "PanBLK"
                                    };
                                    ParamList list = new ParamList {
                                        ParamName = "dynPanX",
                                        ParamValue = "KabinXEksen",
                                        plRename = true
                                    };
                                    lift3.BlkParamList.Add(list);
                                    list.ParamName = "dynPanY";
                                    list.ParamValue = "KabinYEksen+KabinDer";
                                    list.plRename = true;
                                    lift3.BlkParamList.Add(list);
                                    list.ParamName = "dynPanKabinGen";
                                    list.ParamValue = "KabinGen";
                                    list.plRename = true;
                                    lift3.BlkParamList.Add(list);
                                    lift.BlokGrup.Add(lift3);
                                }
                                item.XData = table3.Rows[i]["XData"].ToString();
                                if (item.BlkInsName.IndexOf("COMP:") != -1)
                                {
                                    char[] separator = new char[] { Convert.ToChar(":") };
                                    string[] strArray = item.BlkInsName.Split(separator);
                                    strArray[1] = strArray[1].Replace("%", LiftNumber);
                                    table2 = this.xx.dtta("select ParamName,ParamValue from `" + strArray[1] + "` where ParamName='BlkInsName'", "");
                                    if (table2.Rows.Count > 0)
                                    {
                                        item.BlkInsName = table2.Rows[0]["ParamValue"].ToString();
                                    }
                                }
                                DataTable table8 = new DataTable();
                                table8 = this.xx.dtta("select ison,ParamName,ParamValue from `PARAM` where ison='" + table3.Rows[i]["id"].ToString() + "'", "");
                                if (table8.Rows.Count > 0)
                                {
                                    for (int j = 0; j < table8.Rows.Count; j++)
                                    {
                                        List<ParamList> list2 = new List<ParamList>();
                                        list4 = new ParamList {
                                            ParamName = table8.Rows[j]["ParamName"].ToString(),
                                            ParamValue = table8.Rows[j]["ParamValue"].ToString(),
                                            plRename = true
                                        };
                                        ParamList list3 = list4;
                                        item.BlkParamList.Add(list3);
                                    }
                                }
                                lift.BlokGrup.Add(item);
                            }
                        }
                    }
                    DataTable table4 = new DataTable();
                    table4 = this.xx.dtta("select ParamName,ParamValue from `Num" + LiftNumber + "` where (TipKodu LIKE '%" + tahrik.TipKodu + "%' or TipKodu='TEMEL') and (TahrikKodu LIKE '%" + tahrik.TahrikKodu + "%' or TahrikKodu='TEMEL')  and (YonKodu LIKE '%" + tahrik.YonKodu + "%' or YonKodu='TEMEL')", "");
                    if (table4.Rows.Count > 0)
                    {
                        for (int k = 0; k < table4.Rows.Count; k++)
                        {
                            ParamList list5 = new ParamList {
                                ParamName = table4.Rows[k]["ParamName"].ToString()
                            };
                            if ((list5.ParamName == "KabinRayFark") || (list5.ParamName == "KabinAgrEksenFark"))
                            {
                                list5.ParamValue = table4.Rows[k]["ParamValue"].ToString();
                            }
                            else
                            {
                                list5.ParamValue = table4.Rows[k]["ParamValue"].ToString().Replace("-", "");
                            }
                            list5.plRename = true;
                            lift.VarGrup.Add(list5);
                        }
                    }
                    DataTable table5 = new DataTable();
                    table5 = this.xx.dtta("select ParamName,ParamValue from `VAR` where TipKodu LIKE '%" + lift.Tahrik.TipKodu + "%' and (TahrikKodu='TEMEL' or TahrikKodu LIKE '%" + lift.Tahrik.TahrikKodu + "%') and (YonKodu='TEMEL' or YonKodu LIKE '%" + lift.Tahrik.YonKodu + "%')", "");
                    if (table5.Rows.Count > 0)
                    {
                        for (int m = 0; m < table5.Rows.Count; m++)
                        {
                            list4 = new ParamList {
                                ParamName = table5.Rows[m]["ParamName"].ToString(),
                                ParamValue = table5.Rows[m]["ParamValue"].ToString(),
                                plRename = true
                            };
                            ParamList list6 = list4;
                            lift.VarGrup.Add(list6);
                            if (tahrik.TahrikKodu == "SD")
                            {
                            }
                        }
                    }
                    DataTable table6 = new DataTable();
                    table6 = this.xx.dtta("select ParamName,ParamValue from `DIM` where TipKodu LIKE '%" + lift.Tahrik.TipKodu + "%' and (TahrikKodu='TEMEL' or TahrikKodu LIKE '%" + lift.Tahrik.TahrikKodu + "%') and (YonKodu='TEMEL' or YonKodu LIKE '%" + lift.Tahrik.YonKodu + "%') and KesitKodu LIKE '%" + lift.KesitKodu + "%'", "");
                    if (table6.Rows.Count > 0)
                    {
                        for (int n = 0; n < table6.Rows.Count; n++)
                        {
                            ConsParList list7 = new ConsParList {
                                ConsName = table6.Rows[n]["ParamName"].ToString(),
                                ConsValue = table6.Rows[n]["ParamValue"].ToString()
                            };
                            if ((tahrik.TahrikKodu == "HY") && (list7.ConsName == "consAgrSag"))
                            {
                                list7.ConsValue = "KabinYEksen+(KabinDer/2)+HYFARK";
                            }
                            if ((tahrik.TahrikKodu == "HY") && (list7.ConsName == "consAgrSol"))
                            {
                                list7.ConsValue = "KuyuDer-(KabinYEksen+(KabinDer/2)+HYFARK+HRA)";
                            }
                            lift.DimGrup.Add(list7);
                        }
                    }
                    DataTable table7 = new DataTable();
                    table7 = this.xx.dtta("select DimBlk,SolKac,SagKac from `DimBlok` where TipKodu='" + lift.Tahrik.TipKodu + "' and (TahrikKodu='TEMEL' or TahrikKodu LIKE '%" + lift.Tahrik.TahrikKodu + "%') and (YonKodu='TEMEL' or YonKodu='" + lift.Tahrik.YonKodu + "') and KesitKodu='" + lift.KesitKodu + "'", "");
                    if (table7.Rows.Count > 0)
                    {
                        for (int num6 = 0; num6 < table7.Rows.Count; num6++)
                        {
                            structDimblk dimblk = new structDimblk {
                                DimBlk = table7.Rows[num6]["DimBlk"].ToString(),
                                SolKac = table7.Rows[num6]["SolKac"].ToString(),
                                SagKac = table7.Rows[num6]["SagKac"].ToString()
                            };
                            lift.DimBlkList.Add(dimblk);
                        }
                    }
                    return lift;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return lift;
        }

        private List<structAnaTip> ReadAnaTip()
        {
            List<structAnaTip> list = new List<structAnaTip>();
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select [TipKodu],[TipAdi] from [AnaTip$]", "");
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            structAnaTip item = new structAnaTip {
                                TipKodu = table.Rows[i]["TipKodu"].ToString(),
                                TipAdi = table.Rows[i]["TipAdi"].ToString()
                            };
                            list.Add(item);
                        }
                    }
                    return list;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return list;
        }

        private vtLift ReadData(string blockadi, string LiftNumber, string TipKodu, string TahrikKodu, string YonKodu)
        {
            vtLift lift = new vtLift {
                BlkName = blockadi
            };
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select id,bmblockname,BlkInsName,XData from `BLK` where bmblockname='" + blockadi + "' and TipKodu='" + TipKodu + "' and (TahrikKodu='" + TahrikKodu + "' or TahrikKodu='TEMEL') and (YonKodu='" + YonKodu + "' or YonKodu='TEMEL') and KesitKodu='KK'", "");
                    lift.BlkInsName = table.Rows[0]["BlkInsName"].ToString();
                    lift.XData = table.Rows[0]["XData"].ToString();
                    DataTable table2 = new DataTable();
                    table2 = this.xx.dtta("select ison,BlkName,BlkString from BlkPar where ison=" + table.Rows[0]["id"].ToString(), "");
                    if (table2.Rows.Count > 0)
                    {
                        for (int i = 0; i < table2.Rows.Count; i++)
                        {
                            BlkPar item = new BlkPar {
                                BlkName = table2.Rows[i]["BlkName"].ToString(),
                                BlkString = table2.Rows[i]["BlkString"].ToString()
                            };
                            lift.BlkList.Add(item);
                        }
                        DataTable table3 = new DataTable();
                        table3 = this.xx.dtta("select [ParamName],[ParamValue] from `PARAM` where [ison]=" + table2.Rows[0]["ison"].ToString(), "");
                        if (table3.Rows.Count <= 0)
                        {
                            return lift;
                        }
                        for (int j = 0; j < table3.Rows.Count; j++)
                        {
                            List<ParamList> list = new List<ParamList>();
                            ParamList list2 = new ParamList {
                                ParamName = table3.Rows[j]["ParamName"].ToString(),
                                ParamValue = table3.Rows[j]["ParamValue"].ToString(),
                                plRename = true
                            };
                            lift.BlkParamList.Add(list2);
                        }
                    }
                    return lift;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return lift;
        }

        private vtLift ReadData2(string blockadi, string LiftNumber, string BlkTab, string ParamTab)
        {
            vtLift lift = new vtLift {
                BlkName = blockadi
            };
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select id,bmblockname,BlkInsName,XData from `" + BlkTab + "` where bmblockname='" + blockadi + "'", "");
                    lift.BlkInsName = table.Rows[0]["BlkInsName"].ToString();
                    lift.XData = table.Rows[0]["XData"].ToString();
                    DataTable table2 = new DataTable();
                    table2 = this.xx.dtta("select ison,BlkName,BlkString from BlkPar where ison=" + table.Rows[0]["id"].ToString(), "");
                    if (table2.Rows.Count > 0)
                    {
                        for (int i = 0; i < table2.Rows.Count; i++)
                        {
                            BlkPar item = new BlkPar {
                                BlkName = table2.Rows[i]["BlkName"].ToString(),
                                BlkString = table2.Rows[i]["BlkString"].ToString()
                            };
                            lift.BlkList.Add(item);
                        }
                        DataTable table3 = new DataTable();
                        table3 = this.xx.dtta("select [ParamName],[ParamValue] from `" + ParamTab + "` where [ison]=" + table2.Rows[0]["ison"].ToString(), "");
                        if (table3.Rows.Count <= 0)
                        {
                            return lift;
                        }
                        for (int j = 0; j < table3.Rows.Count; j++)
                        {
                            List<ParamList> list = new List<ParamList>();
                            ParamList list2 = new ParamList {
                                ParamName = table3.Rows[j]["ParamName"].ToString(),
                                ParamValue = table3.Rows[j]["ParamValue"].ToString(),
                                plRename = true
                            };
                            lift.BlkParamList.Add(list2);
                        }
                    }
                    return lift;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return lift;
        }

        private List<ConsParList> ReadDimGrup(structTahrikTip TahrikTip, string LiftNumber)
        {
            List<ConsParList> list = new List<ConsParList>();
            vtLift lift = new vtLift();
            string str = "KabinBase";
            lift.BlkName = str;
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select [id],[bmblockname],[BlkInsName],[XData] from [mainblocks$] where [bmblockname]='" + str + "'", "");
                    lift.BlkInsName = table.Rows[0]["BlkInsName"].ToString();
                    lift.XData = table.Rows[0]["XData"].ToString();
                    DataTable table2 = new DataTable();
                    table2 = this.xx.dtta("select [ison],[BlkName],[BlkString] from [BlkPar$] where [ison]=" + table.Rows[0]["id"].ToString(), "");
                    if (table2.Rows.Count > 0)
                    {
                        for (int i = 0; i < table2.Rows.Count; i++)
                        {
                            BlkPar item = new BlkPar {
                                BlkName = table2.Rows[i]["BlkName"].ToString(),
                                BlkString = table2.Rows[i]["BlkString"].ToString()
                            };
                            lift.BlkList.Add(item);
                        }
                        DataTable table3 = new DataTable();
                        table3 = this.xx.dtta("select [ParamName],[ParamValue] from [Paramlist$] where [ison]=" + table2.Rows[0]["ison"].ToString(), "");
                        if (table3.Rows.Count > 0)
                        {
                            for (int j = 0; j < table3.Rows.Count; j++)
                            {
                                List<ParamList> list2 = new List<ParamList>();
                                ParamList list3 = new ParamList {
                                    ParamName = table3.Rows[j]["ParamName"].ToString(),
                                    ParamValue = table3.Rows[j]["ParamValue"].ToString(),
                                    plRename = true
                                };
                                lift.BlkParamList.Add(list3);
                            }
                        }
                        DataTable table4 = new DataTable();
                        table4 = this.xx.dtta("select [ParamName],[ParamValue] from `DIM` where TipKodu='" + TahrikTip.TipKodu + "' and (TahrikKodu='TEMEL' or TahrikKodu='" + TahrikTip.TahrikKodu + "') and (YonKodu='TEMEL' or YonKodu='" + TahrikTip.YonKodu + "') and [ison]=" + table2.Rows[0]["ison"].ToString(), "");
                        if (table4.Rows.Count > 0)
                        {
                            for (int k = 0; k < table4.Rows.Count; k++)
                            {
                                ConsParList list5 = new ConsParList {
                                    ConsName = table4.Rows[k]["ParamName"].ToString(),
                                    ConsValue = table4.Rows[k]["ParamValue"].ToString()
                                };
                                list.Add(list5);
                            }
                        }
                    }
                    return list;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return list;
        }

        public structTahrik ReadTahrikData(string LiftNumber) => 
            new structTahrik { 
                TipKodu = this.GetNumValue("TipKodu", LiftNumber),
                TahrikKodu = this.GetNumValue("TahrikKodu", LiftNumber),
                YonKodu = this.GetNumValue("YonKodu", LiftNumber)
            };

        private List<structTahrikTip> ReadTahrikTip(structAnaTip AnaTip)
        {
            List<structTahrikTip> list = new List<structTahrikTip>();
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select [TipKodu],[TipAdi],[TahrikKodu],[TipIndex] from [TahrikTip$] where [TipKodu]='" + AnaTip.TipKodu + "'", "");
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            structTahrikTip item = new structTahrikTip {
                                TipKodu = table.Rows[i]["TipKodu"].ToString(),
                                TipAdi = table.Rows[i]["TipAdi"].ToString(),
                                TahrikKodu = table.Rows[i]["TahrikKodu"].ToString(),
                                TipIndex = table.Rows[i]["TipIndex"].ToString()
                            };
                            list.Add(item);
                        }
                    }
                    return list;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return list;
        }

        private List<structTahrikYon> ReadTahrikYon(structAnaTip AnaTip)
        {
            List<structTahrikYon> list = new List<structTahrikYon>();
            DataTable table = new DataTable();
            try
            {
                try
                {
                    table = this.xx.dtta("select [TipKodu],[TipAdi],[TahrikYonKodu] from [TahrikYon$] where [TipKodu]='" + AnaTip.TipKodu + "'", "");
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            structTahrikYon item = new structTahrikYon {
                                TipKodu = table.Rows[i]["TipKodu"].ToString(),
                                TipAdi = table.Rows[i]["TipAdi"].ToString(),
                                YonKodu = table.Rows[i]["TahrikYonKodu"].ToString()
                            };
                            list.Add(item);
                        }
                    }
                    return list;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return list;
        }

        private List<ParamList> ReadVarGrup(string LiftNumber)
        {
            DataTable table = new DataTable();
            List<ParamList> list = new List<ParamList>();
            vtLift lift = new vtLift();
            string str = "KabinBase";
            lift.BlkName = str;
            DataTable table2 = new DataTable();
            try
            {
                try
                {
                    table2 = this.xx.dtta("select [id],[bmblockname],[BlkInsName],[XData] from [mainblocks$] where [bmblockname]='" + str + "'", "");
                    lift.BlkInsName = table2.Rows[0]["BlkInsName"].ToString();
                    lift.XData = table2.Rows[0]["XData"].ToString();
                    DataTable table3 = new DataTable();
                    table3 = this.xx.dtta("select [ison],[BlkName],[BlkString] from [BlkPar$] where [ison]=" + table2.Rows[0]["id"].ToString(), "");
                    if (table3.Rows.Count > 0)
                    {
                        for (int i = 0; i < table3.Rows.Count; i++)
                        {
                            BlkPar item = new BlkPar {
                                BlkName = table3.Rows[i]["BlkName"].ToString(),
                                BlkString = table3.Rows[i]["BlkString"].ToString()
                            };
                            lift.BlkList.Add(item);
                        }
                        table = this.xx.dtta("select [ParamName],[ParamValue] from `Num" + LiftNumber + "` where [ison]=" + table3.Rows[0]["ison"].ToString(), "");
                        if (table.Rows.Count <= 0)
                        {
                            return list;
                        }
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            ParamList list2 = new ParamList {
                                ParamName = table.Rows[j]["ParamName"].ToString(),
                                ParamValue = table.Rows[j]["ParamValue"].ToString(),
                                plRename = true
                            };
                            list.Add(list2);
                        }
                    }
                    return list;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return list;
        }

        private List<ParamList> ReadVarGrup(structTahrikTip TahrikTip, string LiftNumber)
        {
            DataTable table = new DataTable();
            List<ParamList> list = new List<ParamList>();
            vtLift lift = new vtLift();
            string str = "KabinBase";
            lift.BlkName = str;
            DataTable table2 = new DataTable();
            try
            {
                try
                {
                    table2 = this.xx.dtta("select [id],[bmblockname],[BlkInsName],[XData] from [mainblocks$] where [bmblockname]='" + str + "'", "");
                    lift.BlkInsName = table2.Rows[0]["BlkInsName"].ToString();
                    lift.XData = table2.Rows[0]["XData"].ToString();
                    DataTable table3 = new DataTable();
                    table3 = this.xx.dtta("select [ison],[BlkName],[BlkString] from [BlkPar$] where [ison]=" + table2.Rows[0]["id"].ToString(), "");
                    if (table3.Rows.Count > 0)
                    {
                        ParamList list4;
                        for (int i = 0; i < table3.Rows.Count; i++)
                        {
                            BlkPar item = new BlkPar {
                                BlkName = table3.Rows[i]["BlkName"].ToString(),
                                BlkString = table3.Rows[i]["BlkString"].ToString()
                            };
                            lift.BlkList.Add(item);
                        }
                        DataTable table4 = new DataTable();
                        table4 = this.xx.dtta("select [ParamName],[ParamValue] from `Paramlist` where [ison]=" + table3.Rows[0]["ison"].ToString(), "");
                        if (table4.Rows.Count > 0)
                        {
                            for (int j = 0; j < table4.Rows.Count; j++)
                            {
                                List<ParamList> list2 = new List<ParamList>();
                                list4 = new ParamList {
                                    ParamName = table4.Rows[j]["ParamName"].ToString(),
                                    ParamValue = table4.Rows[j]["ParamValue"].ToString(),
                                    plRename = true
                                };
                                ParamList list3 = list4;
                                lift.BlkParamList.Add(list3);
                            }
                        }
                        table = this.xx.dtta("select [ParamName],[ParamValue] from `Num" + LiftNumber + "` where [ison]=" + table3.Rows[0]["ison"].ToString(), "");
                        if (table.Rows.Count > 0)
                        {
                            for (int k = 0; k < table.Rows.Count; k++)
                            {
                                list4 = new ParamList {
                                    ParamName = table.Rows[k]["ParamName"].ToString(),
                                    ParamValue = table.Rows[k]["ParamValue"].ToString(),
                                    plRename = true
                                };
                                ParamList list5 = list4;
                                list.Add(list5);
                            }
                        }
                        DataTable table5 = new DataTable();
                        table5 = this.xx.dtta("select [ParamName],[ParamValue] from `VAR` where TipKodu='" + TahrikTip.TipKodu + "' and (TahrikKodu='TEMEL' or TahrikKodu='" + TahrikTip.TahrikKodu + "') and (YonKodu='TEMEL' or YonKodu='" + TahrikTip.YonKodu + "') and [ison]=" + table3.Rows[0]["ison"].ToString(), "");
                        if (table5.Rows.Count > 0)
                        {
                            for (int m = 0; m < table5.Rows.Count; m++)
                            {
                                list4 = new ParamList {
                                    ParamName = table5.Rows[m]["ParamName"].ToString(),
                                    ParamValue = table5.Rows[m]["ParamValue"].ToString(),
                                    plRename = true
                                };
                                ParamList list6 = list4;
                                list.Add(list6);
                            }
                        }
                    }
                    return list;
                }
                catch (Exception)
                {
                }
            }
            finally
            {
            }
            return list;
        }

        public void RefreshDrawing(clsMLift MainLift)
        {
            Entity vtEnt = null;
            this.prman.aadd = this;
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database dbE = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    string lLNum = "PL" + Convert.ToString(MainLift.LiftNum);
                    string str3 = "L" + Convert.ToString(MainLift.LiftNum);
                    double olcek = MainLift.Olcek;
                    if ((olcek == 1.0) || (olcek == 0.0))
                    {
                        olcek = 1.0;
                        Application.SetSystemVariable("DIMSCALE", 40.0);
                        Application.SetSystemVariable("DIMLFAC", 1.0);
                    }
                    else
                    {
                        olcek = 1.0 / Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1"));
                        Application.SetSystemVariable("DIMLFAC", Convert.ToDouble(this.GetNumValue(MainLift.KesitKodu + "OLCEK", "1")));
                    }
                    Scale3d scaled = new Scale3d();
                    foreach (vtLift lift in MainLift.BlokGrup)
                    {
                        using (Transaction transaction = dbE.get_TransactionManager().StartTransaction())
                        {
                            vtEnt = FObject(lift.XData, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                            if (vtEnt != null)
                            {
                                BlockReference reference = transaction.GetObject(vtEnt.get_ObjectId(), 0);
                                reference.UpgradeOpen();
                                reference.set_Position(MainLift.BasePoint);
                                scaled = reference.get_ScaleFactors();
                                this.SetDynamicValue(dbE, transaction, vtEnt, lift, str3, scaled.get_X(), MainLift.KesitKodu);
                            }
                            transaction.Commit();
                        }
                    }
                    if ((MainLift.KesitKodu == "KK") || (MainLift.KesitKodu == "KD"))
                    {
                        vtEnt = FObject("DIMDYN" + MainLift.KesitKodu, Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu);
                        if (vtEnt != null)
                        {
                            using (Transaction transaction2 = dbE.get_TransactionManager().StartTransaction())
                            {
                                BlockReference reference2 = transaction2.GetObject(vtEnt.get_ObjectId(), 0);
                                reference2.UpgradeOpen();
                                reference2.set_Position(MainLift.BasePoint);
                                this.SetDynamicValue(dbE, transaction2, vtEnt, MainLift, lLNum, reference2.get_ScaleFactors().get_X(), MainLift.KesitKodu);
                                transaction2.Commit();
                            }
                        }
                        this.dimdene2(Convert.ToString(MainLift.LiftNum), MainLift.KesitKodu, MainLift.BasePoint, false);
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        public bool RegOk()
        {
            srthepler srthepler = new srthepler();
            if (srthepler.intirnetvarmi())
            {
                if (srthepler.scrdtta("select * from ascad2017scr where uuid='" + srthepler.getuuid() + "'", "").Rows.Count > 0)
                {
                    scrt scrt = srthepler.datdataoko();
                    return true;
                }
                return false;
            }
            return false;
        }

        [CommandMethod("REMXDATA")]
        public static void RemoveXdata()
        {
            Transaction transaction = Application.get_DocumentManager().get_MdiActiveDocument().get_Database().get_TransactionManager().StartTransaction();
            using (transaction)
            {
                Editor editor = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor();
                try
                {
                    Entity entity = transaction.GetObject(editor.GetEntity("Pick entity ").get_ObjectId(), 0);
                    ResultBuffer xDataForApplication = entity.GetXDataForApplication("ADS");
                    if (xDataForApplication != null)
                    {
                        entity.UpgradeOpen();
                        TypedValue[] valueArray1 = new TypedValue[] { new TypedValue(0x3e9, "ADS") };
                        entity.set_XData(new ResultBuffer(valueArray1));
                        xDataForApplication.Dispose();
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Abort();
                }
            }
        }

        public void RenameParam(string vtParName, string newName)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
        }

        [CommandMethod("SAG")]
        public void SAG()
        {
            this.DALL();
            this.xx.SetNumValue("YonKodu", "SAG", "1");
        }

        [CommandMethod("sase")]
        public void sase()
        {
            Entity vtEnt = null;
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            if (document != null)
            {
                Database db = document.get_Database();
                Editor editor = document.get_Editor();
                DBObjectCollection objects = new DBObjectCollection();
                using (db)
                {
                    using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                    {
                        this.InsertBlock(db, transaction, new Point3d(0.0, 0.0, 0.0), "SASEYAN", true, "sase", "1", "0", 1.0);
                        vtEnt = FObject("sase", "1", "0");
                        if (vtEnt != null)
                        {
                            this.SetDynamicValue(db, transaction, vtEnt, "dynTahKas", (double) 250.0);
                            this.SetDynamicValue(db, transaction, vtEnt, "dynSapKas", (double) 200.0);
                            this.SetDynamicValue(db, transaction, vtEnt, "dynTahKas1", (double) 500.0);
                            this.SetDynamicValue(db, transaction, vtEnt, "dynSapKas1", (double) 400.0);
                            this.SetDynamicValue(db, transaction, vtEnt, "dynDD1", (double) 0.0);
                            this.SetDynamicValue(db, transaction, vtEnt, "dynDD2", (double) 0.0);
                        }
                        transaction.Commit();
                    }
                }
            }
        }

        [CommandMethod("SD")]
        public void SD()
        {
            this.DALL();
            this.xx.SetNumValue("TahrikKodu", "SD", "1");
        }

        [CommandMethod("OnsCaprazEkransec")]
        public static void SelectObjectsByCrossingWindow()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                Editor editor = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor();
                PromptSelectionResult result = editor.SelectCrossingWindow(new Point3d(-1000.0, -1000.0, 0.0), new Point3d(3000.0, 3000.0, 0.0));
                if (result.get_Status() == 0x13ec)
                {
                    DBDictionary dictionary = transaction.GetObject(database.get_GroupDictionaryId(), 0);
                    string str = "KKGROUP";
                    try
                    {
                        SymbolUtilityServices.ValidateSymbolName(str, false);
                        if (dictionary.Contains(str))
                        {
                            str = str + "uu";
                        }
                        else
                        {
                            str = str;
                        }
                    }
                    catch
                    {
                        editor.WriteMessage("\nInvalid group name.");
                    }
                    Group group = new Group("Test group", true);
                    dictionary.UpgradeOpen();
                    ObjectId id = dictionary.SetAt(str, group);
                    transaction.AddNewlyCreatedDBObject(group, true);
                    BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0);
                    ObjectIdCollection ids = new ObjectIdCollection();
                    SelectionSet set = result.get_Value();
                    foreach (SelectedObject obj2 in set)
                    {
                        if (obj2 > null)
                        {
                            ids.Add(obj2.get_ObjectId());
                        }
                    }
                    editor.WriteMessage("obje sayısı" + set.get_Count());
                    group.Append(ids);
                }
                transaction.Commit();
            }
        }

        [CommandMethod("setdy")]
        public void setdy()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            if (document != null)
            {
                Database database = document.get_Database();
                Editor editor = document.get_Editor();
                using (database)
                {
                    using (Transaction transaction = database.get_TransactionManager().StartTransaction())
                    {
                        PromptEntityOptions options = new PromptEntityOptions("\nSelect entity: ");
                        BlockReference reference = transaction.GetObject(editor.GetEntity(options).get_ObjectId(), 0);
                        reference.UpgradeOpen();
                        if (reference != null)
                        {
                            DynamicBlockReferencePropertyCollection propertys = reference.get_DynamicBlockReferencePropertyCollection();
                            foreach (DynamicBlockReferenceProperty property in propertys)
                            {
                                if (!property.get_ReadOnly() && (property.get_PropertyName() == "dynKapiFlip"))
                                {
                                    if (property.get_PropertyTypeCode() == 3)
                                    {
                                        object[] allowedValues = property.GetAllowedValues();
                                        for (int i = 0; i < allowedValues.Length; i++)
                                        {
                                        }
                                        property.set_Value(1);
                                    }
                                    else
                                    {
                                        property.set_Value(900);
                                    }
                                }
                            }
                            transaction.Commit();
                        }
                    }
                }
            }
        }

        private void SetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, string propname, double myvalue)
        {
            BlockReference reference = tr.GetObject(vtEnt.get_ObjectId(), 0);
            reference.UpgradeOpen();
            if (reference != null)
            {
                DynamicBlockReferencePropertyCollection propertys = reference.get_DynamicBlockReferencePropertyCollection();
                foreach (DynamicBlockReferenceProperty property in propertys)
                {
                    if (!property.get_ReadOnly() && (property.get_PropertyName() == propname))
                    {
                        switch (property.get_PropertyTypeCode())
                        {
                            case 40:
                                property.set_Value(myvalue);
                                break;

                            case 70:
                                property.set_Value((short) myvalue);
                                break;
                        }
                        break;
                    }
                }
            }
        }

        private void SetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, string propname, string myvalue)
        {
            BlockReference reference = tr.GetObject(vtEnt.get_ObjectId(), 0);
            if (reference != null)
            {
                DynamicBlockReferencePropertyCollection propertys = reference.get_DynamicBlockReferencePropertyCollection();
                foreach (DynamicBlockReferenceProperty property in propertys)
                {
                    if (!property.get_ReadOnly() && (property.get_PropertyName() == propname))
                    {
                        property.set_Value(myvalue);
                    }
                }
            }
        }

        private void SetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, clsMLift DimGrup, string LLNum, double Scale = 1.0, string KesitKODU = "KK")
        {
            BlockReference reference = tr.GetObject(vtEnt.get_ObjectId(), 0);
            reference.UpgradeOpen();
            if (reference != null)
            {
                DynamicBlockReferencePropertyCollection propertys = reference.get_DynamicBlockReferencePropertyCollection();
                foreach (DynamicBlockReferenceProperty property in propertys)
                {
                    if (!property.get_ReadOnly())
                    {
                        foreach (ConsParList list in DimGrup.DimGrup)
                        {
                            if (property.get_PropertyName() == list.ConsName)
                            {
                                double num = Convert.ToDouble(this.prman.GetParamValFRM(LLNum + list.ConsName, KesitKODU));
                                switch (property.get_PropertyTypeCode())
                                {
                                    case 40:
                                        property.set_Value(num * Scale);
                                        break;

                                    case 70:
                                        property.set_Value((short) num);
                                        break;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void SetDynamicValue(Database dbE, Transaction tr, Entity vtEnt, vtLift BlokGrup, string LLNum, double Scale = 1.0, string KesitKODU = "KK")
        {
            BlockReference reference = tr.GetObject(vtEnt.get_ObjectId(), 0);
            reference.UpgradeOpen();
            if (reference != null)
            {
                DynamicBlockReferencePropertyCollection propertys = reference.get_DynamicBlockReferencePropertyCollection();
                foreach (DynamicBlockReferenceProperty property in propertys)
                {
                    if (!property.get_ReadOnly())
                    {
                        foreach (ParamList list in BlokGrup.BlkParamList)
                        {
                            if (property.get_PropertyName() == list.ParamName)
                            {
                                double num = Convert.ToDouble(this.prman.GetParamValFRM(LLNum + list.ParamName, KesitKODU));
                                switch (property.get_PropertyTypeCode())
                                {
                                    case 40:
                                        num *= Scale;
                                        property.set_Value(num);
                                        break;

                                    case 70:
                                        property.set_Value((short) num);
                                        break;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        [CommandMethod("SetLayerColor")]
        public static void SetLayerColor()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                string[] strArray = new string[] { "ACIRed", "TrueBlue", "ColorBookYellow" };
                Color[] colorArray = new Color[] { Color.FromColorIndex(0xc3, 1), Color.FromRgb(0x17, 0x36, 0xe8), Color.FromNames("PANTONE Yellow 0131 C", "PANTONE(R) pastel coated") };
                int index = 0;
                foreach (string str in strArray)
                {
                    if (!table.Has(str))
                    {
                        using (LayerTableRecord record = new LayerTableRecord())
                        {
                            record.set_Name(str);
                            if (!table.get_IsWriteEnabled())
                            {
                                table.UpgradeOpen();
                            }
                            table.Add(record);
                            transaction.AddNewlyCreatedDBObject(record, true);
                            record.set_Color(colorArray[index]);
                        }
                    }
                    else
                    {
                        (transaction.GetObject(table.get_Item(str), 1) as LayerTableRecord).set_Color(colorArray[index]);
                    }
                    index++;
                }
                transaction.Commit();
            }
        }

        [CommandMethod("SetLayerCurrent")]
        public static void SetLayerCurrent()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                string str = "Center";
                if (table.Has(str))
                {
                    database.set_Clayer(table.get_Item(str));
                    transaction.Commit();
                }
            }
        }

        [CommandMethod("SetLayerLinetype")]
        public static void SetLayerLinetype()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                string str = "ABC";
                if (!table.Has(str))
                {
                    using (LayerTableRecord record = new LayerTableRecord())
                    {
                        record.set_Name(str);
                        table.UpgradeOpen();
                        table.Add(record);
                        transaction.AddNewlyCreatedDBObject(record, true);
                        LinetypeTable table2 = transaction.GetObject(database.get_LinetypeTableId(), 0) as LinetypeTable;
                        if (table2.Has("Center"))
                        {
                            record.UpgradeOpen();
                            record.set_LinetypeObjectId(table2.get_Item("Center"));
                        }
                    }
                }
                else
                {
                    LayerTableRecord record2 = transaction.GetObject(table.get_Item(str), 0) as LayerTableRecord;
                    LinetypeTable table3 = transaction.GetObject(database.get_LinetypeTableId(), 0) as LinetypeTable;
                    if (table3.Has("Center"))
                    {
                        record2.UpgradeOpen();
                        record2.set_LinetypeObjectId(table3.get_Item("Center"));
                    }
                }
                transaction.Commit();
            }
        }

        public static void SetXData(Entity bref, string xData1, string xData2, string xData3)
        {
            Transaction transaction = Application.get_DocumentManager().get_MdiActiveDocument().get_TransactionManager().StartTransaction();
            using (transaction)
            {
                AddRegAppTableRecord("I");
                TypedValue[] valueArray1 = new TypedValue[] { new TypedValue(0x3e9, "I"), new TypedValue(0x3e8, xData1), new TypedValue(0x3e8, xData2), new TypedValue(0x3e8, xData3) };
                ResultBuffer buffer = new ResultBuffer(valueArray1);
                bref.set_XData(buffer);
                buffer.Dispose();
                transaction.Commit();
            }
        }

        [CommandMethod("shfrm")]
        public void shwpar()
        {
            this.prman.WindowState = FormWindowState.Normal;
            this.prman.Show();
        }

        [CommandMethod("SobjOnSCR")]
        public static void SobjOnSCR()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            using (Transaction transaction = document.get_Database().get_TransactionManager().StartTransaction())
            {
                Entity entity = transaction.GetObject(document.get_Editor().GetEntity("D\x00dcZELTİLECEK NESNEYİ SE\x00c7İNİZ...").get_ObjectId(), 1) as Entity;
                if (entity != null)
                {
                    if (entity.get_ObjectId().get_ObjectClass().get_DxfName() == "DIMENSION")
                    {
                        AlignedDimension dimension = entity;
                    }
                    transaction.Commit();
                }
            }
        }

        [CommandMethod("SOL")]
        public void SOL()
        {
            this.DALL();
            this.xx.SetNumValue("YonKodu", "SOL", "1");
        }

        public void TKAAKuyuCiz(clsMLift MainLift, int ToplamKuyuGen)
        {
            Entity vtEnt = null;
            structTahrik tahrik = new structTahrik();
            tahrik = this.ReadTahrikData("1");
            double olcek = MainLift.Olcek;
            if (olcek == 0.0)
            {
                olcek = 1.0;
            }
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database db = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (db)
                    {
                        using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                        {
                            BlockReference reference = null;
                            reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "TK-AA", false, "TK-AA", "1", MainLift.KesitKodu, 1.0 / olcek);
                            vtEnt = FObject("TK-AA", "1", MainLift.KesitKodu);
                            if (vtEnt != null)
                            {
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (ToplamKuyuGen * (1.0 / olcek)));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuDibi", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))) * (1.0 / olcek)));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynIlkKat", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("IlkKat", "1"))) * (1.0 / olcek)));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynSonKat", (double) (Math.Abs(Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Length - 1])) * (1.0 / olcek)));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuKafa", (double) (Math.Abs(Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1")))) * (1.0 / olcek)));
                                this.ChTag(vtEnt.get_ObjectId(), "SEYIRDIM", "SEYİR MESAFESİ = " + this.GetNumValue("SeyirMesafesi", "1") + " mm");
                                this.ChTag(vtEnt.get_ObjectId(), "KUYUDIM", "KUYU MESAFESİ = " + this.GetNumValue("KuyuMesafesi", "1") + " mm");
                                this.ChTag(vtEnt.get_ObjectId(), "KESITADI", "T\x00dcM KUYU AA KESİTİ \x00d6:1/" + this.GetNumValue("TK-AAOLCEK", "1"));
                            }
                            if ((tahrik.TipKodu == "EA") && (((tahrik.TahrikKodu == "DA") || (tahrik.TahrikKodu == "YA")) || (tahrik.TahrikKodu == "SD")))
                            {
                                reference = null;
                                reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "TK-AA-MD", false, "TK-AA-MD", "1", MainLift.KesitKodu, 1.0 / olcek);
                                vtEnt = FObject("TK-AA-MD", "1", MainLift.KesitKodu);
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (ToplamKuyuGen * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynMDH", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))) * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynCalisYuksek", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("CalisYuksek", "1"))) * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynAASOL", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("AASOL", "1"))) * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynAASAG", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("AASAG", "1"))) * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynMDY", (double) (((((Math.Abs(Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))) + Math.Abs(Convert.ToDouble(this.GetNumValue("IlkKat", "1")))) + Math.Abs(Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Length - 1]))) + Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1")))) + Convert.ToDouble(0x60e)) * (1.0 / olcek)));
                                }
                            }
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        [CommandMethod("TKBB")]
        public void TKBB()
        {
            Application.SetSystemVariable("USERI1", 20);
            Application.SetSystemVariable("DIMLFAC", 20.0);
            this.LD("TK-BB", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        public void TKBBKuyuCiz(clsMLift MainLift, int KuyuDer)
        {
            Entity vtEnt = null;
            structTahrik tahrik = new structTahrik();
            tahrik = this.ReadTahrikData("1");
            double olcek = MainLift.Olcek;
            if (olcek == 0.0)
            {
                olcek = 1.0;
            }
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database db = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (db)
                    {
                        using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                        {
                            BlockReference reference = null;
                            reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "TK-BB", false, "TK-BB", "1", MainLift.KesitKodu, 1.0 / olcek);
                            vtEnt = FObject("TK-BB", "1", MainLift.KesitKodu);
                            if (vtEnt != null)
                            {
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuDer", (double) (KuyuDer * (1.0 / olcek)));
                                double myvalue = Math.Abs(Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))) * (1.0 / olcek);
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuDibi", myvalue);
                                this.SetDynamicValue(db, transaction, vtEnt, "dynIlkKat", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("IlkKat", "1"))) * (1.0 / olcek)));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynSonKat", (double) (Math.Abs(Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Length - 1])) * (1.0 / olcek)));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuKafa", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))) * (1.0 / olcek)));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKapiH", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("KapiH", "1"))) * (1.0 / olcek)));
                                this.ChTag(vtEnt.get_ObjectId(), "ILKDURAKNO", MainLift.KatRumuz[0] + ".KAT");
                                this.ChTag(vtEnt.get_ObjectId(), "ARAKATLARNO", this.GetNumValue("AraKatSTR", "1"));
                                this.ChTag(vtEnt.get_ObjectId(), "SONDURAKNO", MainLift.KatRumuz[MainLift.KatRumuz.Length - 1] + ".KAT");
                                this.ChTag(vtEnt.get_ObjectId(), "ILKDURAKKOT", this.GetNumValue("IlkDurakKot", "1"));
                                this.ChTag(vtEnt.get_ObjectId(), "SONDURAKKOT", this.GetNumValue("SonDurakKot", "1"));
                                this.ChTag(vtEnt.get_ObjectId(), "MDKOT", this.GetNumValue("MDKot", "1"));
                                this.ChTag(vtEnt.get_ObjectId(), "KESITADI", "T\x00dcM KUYU BB KESİTİ \x00d6:1/" + this.GetNumValue("TK-BBOLCEK", "1"));
                            }
                            if ((tahrik.TipKodu == "EA") && (((tahrik.TahrikKodu == "DA") || (tahrik.TahrikKodu == "YA")) || (tahrik.TahrikKodu == "SD")))
                            {
                                reference = null;
                                reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "TK-AA-MD", false, "TK-AA-MD", "1", MainLift.KesitKodu, 1.0 / olcek);
                                vtEnt = FObject("TK-AA-MD", "1", MainLift.KesitKodu);
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (KuyuDer * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynMDH", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1"))) * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynCalisYuksek", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("CalisYuksek", "1"))) * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynAASOL", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("BBSOL", "1"))) * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynAASAG", (double) (Math.Abs(Convert.ToDouble(this.GetNumValue("BBSAG", "1"))) * (1.0 / olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynMDY", (double) (((((Math.Abs(Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))) + Math.Abs(Convert.ToDouble(this.GetNumValue("IlkKat", "1")))) + Math.Abs(Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Length - 1]))) + Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1")))) + Convert.ToDouble(0x60e)) * (1.0 / olcek)));
                                }
                            }
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        public void TTKKuyuCiz(clsMLift MainLift, int ToplamKuyuGen, string KesitKodu)
        {
            Entity vtEnt = null;
            structTahrik tahrik = new structTahrik();
            tahrik = this.ReadTahrikData("1");
            decimal num = new decimal();
            decimal num2 = new decimal();
            decimal num3 = new decimal();
            decimal num4 = new decimal();
            decimal num5 = new decimal();
            double num7 = Convert.ToDouble(this.GetNumValue("KuyuDer", "1"));
            num4 = Convert.ToDecimal(this.GetNumValue("KuyuDibi", "1"));
            num2 = Convert.ToDecimal(this.GetNumValue("SeyirMesafesi", "1"));
            num = Convert.ToDecimal(this.GetNumValue("KuyuMesafesi", "1"));
            num5 = ((num + 200M) - Convert.ToDecimal(this.GetNumValue("MDaireH", "1"))) - Convert.ToDecimal(MainLift.KatYuk[MainLift.KatYuk.Count<string>() - 1]);
            decimal num6 = Convert.ToDecimal(this.GetNumValue("IlkDurakKot", "1"));
            this.xx.SetNumValue("IlkKat", MainLift.KatYuk[0], "1");
            this.xx.SetNumValue("SonKat", MainLift.KatYuk[MainLift.KatYuk.Count<string>() - 1], "1");
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document != null)
                {
                    Database db = document.get_Database();
                    Editor editor = document.get_Editor();
                    DBObjectCollection objects = new DBObjectCollection();
                    using (db)
                    {
                        using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                        {
                            Point3d pointd = new Point3d(0.0, 0.0, 0.0);
                            BlockReference reference = null;
                            reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "TTK", false, MainLift.KesitKodu, "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                            vtEnt = FObject(MainLift.KesitKodu, "1", MainLift.KesitKodu);
                            if (vtEnt != null)
                            {
                                if (KesitKodu == "TTK-AA")
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (ToplamKuyuGen * (1.0 / MainLift.Olcek)));
                                }
                                else
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (num7 * (1.0 / MainLift.Olcek)));
                                    this.ChTag(vtEnt.get_ObjectId(), "ILKDURAKNO", MainLift.KatRumuz[0] + ".KAT");
                                    this.ChTag(vtEnt.get_ObjectId(), "SONDURAKNO", MainLift.KatRumuz[MainLift.KatRumuz.Length - 1] + ".KAT");
                                    this.ChTag(vtEnt.get_ObjectId(), "ILKDURAKKOT", this.GetNumValue("IlkDurakKot", "1"));
                                    this.ChTag(vtEnt.get_ObjectId(), "SONDURAKKOT", this.GetNumValue("SonDurakKot", "1"));
                                    this.ChTag(vtEnt.get_ObjectId(), "MDKOT", this.GetNumValue("MDKot", "1"));
                                }
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuDibi", (double) ((1.0 / MainLift.Olcek) * Convert.ToDouble(this.GetNumValue("KuyuDibi", "1"))));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynIlkKat", (double) ((1.0 / MainLift.Olcek) * Convert.ToDouble(MainLift.KatYuk[0])));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynSonKat", (double) ((1.0 / MainLift.Olcek) * Convert.ToDouble(MainLift.KatYuk[MainLift.KatYuk.Count<string>() - 1])));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuKafa", (double) ((1.0 / MainLift.Olcek) * (Convert.ToDouble(this.GetNumValue("MDaireH", "1")) - 200.0)));
                                this.SetDynamicValue(db, transaction, vtEnt, "dynToplamYuk", (double) ((1.0 / MainLift.Olcek) * Convert.ToDouble(num)));
                                this.ChTag(vtEnt.get_ObjectId(), "SEYIRDIM", "SEYİR MESAFESİ = " + Convert.ToString(num2) + " mm");
                                this.ChTag(vtEnt.get_ObjectId(), "KUYUDIM", "KUYU MESAFESİ = " + Convert.ToString(num) + " mm");
                                if (KesitKodu == "TTK-AA")
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "KESITADI", "T\x00dcM KUYU AA KESİTİ \x00d6:1/" + this.GetNumValue("TKKOLCEK", "1"));
                                }
                                else
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "KESITADI", "T\x00dcM KUYU BB KESİTİ \x00d6:1/" + this.GetNumValue("TKKOLCEK", "1"));
                                }
                            }
                            if (MainLift.KatYuk.Count<string>() >= 3)
                            {
                                num3 = num4 + Convert.ToDecimal(MainLift.KatYuk[0]);
                                for (int i = 0; i < (MainLift.KatYuk.Count<string>() - 2); i++)
                                {
                                    reference = null;
                                    if (KesitKodu == "TTK-AA")
                                    {
                                        reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "KatCik", false, "KatCik" + Convert.ToString(i), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                        vtEnt = FObject("KatCik" + Convert.ToString(i), "1", MainLift.KesitKodu);
                                    }
                                    else
                                    {
                                        reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "KatCikBB", false, "KatCik" + Convert.ToString(i), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                        vtEnt = FObject("KatCik" + Convert.ToString(i), "1", MainLift.KesitKodu);
                                        this.ChTag(vtEnt.get_ObjectId(), "DURAKNO", MainLift.KatRumuz[i + 1] + ".KAT");
                                        num6 += Convert.ToDecimal(MainLift.KatYuk[i]);
                                        this.ChTag(vtEnt.get_ObjectId(), "DURAKKOT", Convert.ToString(num6));
                                    }
                                    if (vtEnt != null)
                                    {
                                        if (KesitKodu == "TTK-AA")
                                        {
                                            this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (ToplamKuyuGen * (1.0 / MainLift.Olcek)));
                                        }
                                        else
                                        {
                                            this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (num7 * (1.0 / MainLift.Olcek)));
                                        }
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynKatYuk", (double) ((1.0 / MainLift.Olcek) * Convert.ToDouble(Convert.ToDecimal(MainLift.KatYuk[i + 1]))));
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynKatYukY", (double) (Convert.ToDouble(num3) * (1.0 / MainLift.Olcek)));
                                        num3 += Convert.ToDecimal(MainLift.KatYuk[i + 1]);
                                        num3 *= (decimal) (1.0 / MainLift.Olcek);
                                    }
                                }
                            }
                            if (KesitKodu == "TTK-AA")
                            {
                                int num9 = 0;
                                int num10 = Convert.ToInt32(this.GetNumValue("KonsolMesafe", "1"));
                                int num11 = Convert.ToInt32(this.GetNumValue("AydinMesafe", "1"));
                                double num12 = 500.0;
                                num9 = (int) Math.Ceiling((double) (((float) (num - 500M)) / ((float) num10)));
                                num9--;
                                for (int j = 0; j < num9; j++)
                                {
                                    reference = null;
                                    reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "RayTespit", false, "RayTespit" + Convert.ToString((int) (j + 1)), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                    vtEnt = FObject("RayTespit" + Convert.ToString((int) (j + 1)), "1", MainLift.KesitKodu);
                                    if (vtEnt != null)
                                    {
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitX", (double) ((ToplamKuyuGen + 3000.0) * (1.0 / MainLift.Olcek)));
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitY", (double) (num12 * (1.0 / MainLift.Olcek)));
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynKonsolAra", (double) (Convert.ToDouble(num10) * (1.0 / MainLift.Olcek)));
                                        this.ChTag(vtEnt.get_ObjectId(), "KONSOLNO", Convert.ToString((int) (j + 1)));
                                    }
                                    num12 += num10;
                                }
                                reference = null;
                                reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "RayTespit", false, "RayTespit0", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                vtEnt = FObject("RayTespit0", "1", MainLift.KesitKodu);
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitX", (double) ((ToplamKuyuGen + 3000.0) * (1.0 / MainLift.Olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitY", (double) (num12 * (1.0 / MainLift.Olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKonsolAra", (double) ((1.0 / MainLift.Olcek) * Convert.ToDouble((double) (((double) num) - num12))));
                                    this.ChTag(vtEnt.get_ObjectId(), "KONSOLNO", Convert.ToString((int) (num9 + 1)));
                                }
                                num9 = (int) Math.Ceiling((double) ((float) (num / 5000M)));
                                num12 = 0.0;
                                num9--;
                                for (int k = 0; k < num9; k++)
                                {
                                    reference = null;
                                    reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "RayTespit", false, "RayEkyer" + Convert.ToString((int) (k + 1)), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                    vtEnt = FObject("RayEkyer" + Convert.ToString((int) (k + 1)), "1", MainLift.KesitKodu);
                                    if (vtEnt != null)
                                    {
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitX", (double) ((ToplamKuyuGen + 4000.0) * (1.0 / MainLift.Olcek)));
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitY", (double) (num12 * (1.0 / MainLift.Olcek)));
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynKonsolAra", (double) (Convert.ToDouble(0x1388) * (1.0 / MainLift.Olcek)));
                                        this.ChTag(vtEnt.get_ObjectId(), "KONSOLNO", Convert.ToString((int) (k + 1)));
                                    }
                                    num12 += 5000.0;
                                }
                                reference = null;
                                reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "RayTespit", false, "RayEkyer0", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                vtEnt = FObject("RayEkyer0", "1", MainLift.KesitKodu);
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitX", (double) ((ToplamKuyuGen + 4000.0) * (1.0 / MainLift.Olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitY", (double) (num12 * (1.0 / MainLift.Olcek)));
                                    if (((double) num) < num12)
                                    {
                                        num12 -= 5000.0;
                                    }
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKonsolAra", Convert.ToDouble((double) (((1.0 / MainLift.Olcek) * ((double) num)) - num12)));
                                    this.ChTag(vtEnt.get_ObjectId(), "KONSOLNO", Convert.ToString((int) (num9 + 1)));
                                }
                                num12 = 500.0;
                                num9 = (int) Math.Ceiling((double) (((float) (num - 1000M)) / ((float) num11)));
                                num9--;
                                for (int m = 0; m < num9; m++)
                                {
                                    reference = null;
                                    reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "RayTespit", false, "Aydinlatma" + Convert.ToString((int) (m + 1)), "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                    vtEnt = FObject("Aydinlatma" + Convert.ToString((int) (m + 1)), "1", MainLift.KesitKodu);
                                    if (vtEnt != null)
                                    {
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitX", (double) ((ToplamKuyuGen + 5000.0) * (1.0 / MainLift.Olcek)));
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitY", (double) (num12 * (1.0 / MainLift.Olcek)));
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynKonsolAra", (double) (Convert.ToDouble(num11) * (1.0 / MainLift.Olcek)));
                                        this.ChTag(vtEnt.get_ObjectId(), "KONSOLNO", Convert.ToString((int) (m + 1)));
                                    }
                                    num12 += num11;
                                }
                                reference = null;
                                reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "RayTespit", false, "Aydinlatma0", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                vtEnt = FObject("Aydinlatma0", "1", MainLift.KesitKodu);
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitX", (double) ((ToplamKuyuGen + 5000.0) * (1.0 / MainLift.Olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitY", (double) (num12 * (1.0 / MainLift.Olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKonsolAra", (double) (Convert.ToDouble((double) ((((double) num) - 500.0) - num12)) * (1.0 / MainLift.Olcek)));
                                    this.ChTag(vtEnt.get_ObjectId(), "KONSOLNO", Convert.ToString((int) (num9 + 1)));
                                }
                                reference = null;
                                reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "RayTespit", false, "AydinlatmaSon", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                vtEnt = FObject("AydinlatmaSon", "1", MainLift.KesitKodu);
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitX", (double) ((ToplamKuyuGen + 5000.0) * (1.0 / MainLift.Olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynRayTespitY", (double) (((double) (num - 500M)) * (1.0 / MainLift.Olcek)));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynKonsolAra", (double) (Convert.ToDouble((double) 500.0) * (1.0 / MainLift.Olcek)));
                                    this.ChTag(vtEnt.get_ObjectId(), "KONSOLNO", Convert.ToString((int) (num9 + 2)));
                                }
                            }
                            if ((tahrik.TipKodu == "EA") && (((tahrik.TahrikKodu == "DA") || (tahrik.TahrikKodu == "YA")) || (tahrik.TahrikKodu == "SD")))
                            {
                                reference = null;
                                reference = this.InsertBlock(db, transaction, MainLift.BasePoint, "TK-AA-MD", false, "TK-AA-MD", "1", MainLift.KesitKodu, 1.0 / MainLift.Olcek);
                                vtEnt = FObject("TK-AA-MD", "1", MainLift.KesitKodu);
                                if (vtEnt != null)
                                {
                                    if (KesitKodu == "TTK-AA")
                                    {
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (ToplamKuyuGen * (1.0 / MainLift.Olcek)));
                                    }
                                    else
                                    {
                                        this.SetDynamicValue(db, transaction, vtEnt, "dynKuyuGen", (double) (num7 * (1.0 / MainLift.Olcek)));
                                    }
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynMDH", (double) ((1.0 / MainLift.Olcek) * Math.Abs(Convert.ToDouble(this.GetNumValue("MDaireH", "1")))));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynCalisYuksek", (double) ((1.0 / MainLift.Olcek) * Math.Abs(Convert.ToDouble(this.GetNumValue("CalisYuksek", "1")))));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynAASOL", (double) ((1.0 / MainLift.Olcek) * Math.Abs(Convert.ToDouble(this.GetNumValue("AASOL", "1")))));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynAASAG", (double) ((1.0 / MainLift.Olcek) * Math.Abs(Convert.ToDouble(this.GetNumValue("AASAG", "1")))));
                                    this.SetDynamicValue(db, transaction, vtEnt, "dynMDY", (double) ((1.0 / MainLift.Olcek) * Math.Abs(Convert.ToDouble(num))));
                                }
                            }
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            catch (Exception)
            {
            }
        }

        [CommandMethod("TumProje")]
        public void TumProje()
        {
            if (!this.prman.Created)
            {
                this.prman.aadd = this;
                this.prman.destandcrash();
            }
            structTahrik tahrik = new structTahrik();
            tahrik = this.ReadTahrikData("1");
            this.DALL();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            double num8 = 1.0 / Convert.ToDouble(this.GetNumValue("KKOLCEK", "1"));
            double num9 = 1.0 / Convert.ToDouble(this.GetNumValue("KDOLCEK", "1"));
            double num10 = 1.0 / Convert.ToDouble(this.GetNumValue("MDOLCEK", "1"));
            double num11 = 1.0 / Convert.ToDouble(this.GetNumValue("TK-AAOLCEK", "1"));
            double num12 = 1.0 / Convert.ToDouble(this.GetNumValue("TKKOLCEK", "1"));
            num = Convert.ToInt32(this.GetNumValue("ToplamKuyuGen", "1"));
            num2 = Convert.ToInt32(this.GetNumValue("KuyuDer", "1"));
            num3 = Convert.ToInt32(this.GetNumValue("DuvarKal", "1"));
            int num13 = Convert.ToInt32(this.GetNumValue("KuyuDibi", "1"));
            int num14 = (Convert.ToInt32(this.GetNumValue("SonKat", "1")) + Convert.ToInt32(this.GetNumValue("KuyuKafa", "1"))) - 200;
            int num15 = Convert.ToInt32(this.GetNumValue("KabinTamponAra", "1"));
            int num16 = Convert.ToInt32(this.GetNumValue("KabinStrok", "1"));
            int num17 = Convert.ToInt32(this.GetNumValue("AgrTamponAra", "1"));
            int num18 = Convert.ToInt32(this.GetNumValue("AgrStrok", "1"));
            int num19 = Convert.ToInt32(this.GetNumValue("KAltPaten", "1"));
            int num20 = Convert.ToInt32(this.GetNumValue("KUstPaten", "1"));
            int num21 = Convert.ToInt32(this.GetNumValue("BeyanHiz", "1"));
            num4 = Convert.ToInt32(this.GetNumValue("AASol", "1"));
            num5 = Convert.ToInt32(this.GetNumValue("AASag", "1"));
            num6 = Convert.ToInt32(this.GetNumValue("BBSol", "1"));
            num7 = Convert.ToInt32(this.GetNumValue("BBSag", "1"));
            double num22 = 0.0;
            double num23 = (num9 * num2) + 150.0;
            double num26 = 150.0;
            double num24 = ((-1.0 * num10) * (num + num5)) - num26;
            double num25 = (num10 * num6) + 50.0;
            double num27 = 0.0;
            double num28 = 0.0;
            double num29 = 0.0;
            double num30 = 0.0;
            double num31 = 0.0;
            double num32 = 0.0;
            double num33 = 0.0;
            num32 = num8 * (((num + num4) + num5) + (2 * num3));
            num33 = num8 * ((num2 + num7) + num3);
            num31 = num8 * (num + (4 * num3));
            if (((tahrik.TahrikKodu == "DA") || (tahrik.TahrikKodu == "YA")) && (tahrik.TipKodu == "EA"))
            {
                num27 = (((((-1.0 * num10) * ((num + num4) + num5)) + ((-1.0 * num12) * (num + num7))) - 150.0) - (num12 * (num + num7))) - 400.0;
                num28 = (((-1.0 * num10) * ((num + num4) + num5)) + ((-1.0 * num12) * (num + num7))) - 300.0;
                if (num4 == 0)
                {
                    num29 = (num8 * ((num + num4) + 700)) + 50.0;
                }
                else
                {
                    num29 = num8 * ((num + num4) + 700);
                }
                num30 = (num29 + (num11 * ((num + num5) + num6))) + (num11 * 2000.0);
            }
            if ((tahrik.TahrikKodu == "MDDUZ") || (tahrik.TahrikKodu == "MDCAP"))
            {
                num27 = ((-1.0 * num12) * (num + num2)) - 550.0;
                num28 = ((-1.0 * num12) * num2) - 200.0;
                num29 = (num11 * num) + 200.0;
                num30 = (num29 + (num11 * num)) + (num11 * 4000.0);
            }
            if (tahrik.TipKodu == "HA")
            {
                if (this.GetNumValue("HAMDFlip", "1") == "1")
                {
                    num27 = (((-1.0 * num12) * (num + num2)) - 650.0) - (num10 * Convert.ToInt32(this.GetNumValue("HAMDGen", "1")));
                    num28 = (((-1.0 * num12) * num2) - 200.0) - (num10 * Convert.ToInt32(this.GetNumValue("HAMDGen", "1")));
                    num29 = (num8 * num) + 200.0;
                    num30 = (num29 + (num11 * num)) + (num11 * 3000.0);
                }
                else
                {
                    num27 = ((-1.0 * num12) * (num + num2)) - 650.0;
                    num28 = ((-1.0 * num12) * num2) - 200.0;
                    num29 = ((num8 * num) + 200.0) + (num9 * Convert.ToInt32(this.GetNumValue("HAMDGen", "1")));
                    num30 = (num29 + (num8 * num)) + (num11 * 3000.0);
                }
            }
            double num34 = 0.0;
            double num35 = 0.0;
            double num36 = 0.0;
            string blockName = "DiyagramDA";
            if (((tahrik.TahrikKodu == "DA") || (tahrik.TahrikKodu == "YA")) && (tahrik.TipKodu == "EA"))
            {
                num34 = (num24 - (num4 * num10)) - 250.0;
                num35 = 350.0;
                blockName = "DiyagramDA";
                num36 = num34;
            }
            if ((tahrik.TahrikKodu == "MDDUZ") || (tahrik.TahrikKodu == "MDCAP"))
            {
                num34 = num22 - 250.0;
                num35 = 350.0;
                blockName = "DiyagramMD";
                num36 = num34;
            }
            double num37 = 0.0;
            if (((tahrik.TahrikKodu == "DA") || (tahrik.TahrikKodu == "YA")) && (tahrik.TipKodu == "EA"))
            {
                num37 = num30 + (num11 * ((num2 + num7) + (2 * num3)));
            }
            if (((tahrik.TahrikKodu == "MDDUZ") || (tahrik.TahrikKodu == "MDCAP")) && (tahrik.TipKodu == "EA"))
            {
                num37 = num30 + (num11 * (num2 + (2 * num3)));
            }
            if (tahrik.TipKodu == "HA")
            {
                num37 = (num30 + (num11 * num2)) + 100.0;
            }
            double num38 = 0.0;
            if (tahrik.TahrikKodu == "MDCAP")
            {
                num38 = ((((num8 * num) + (num11 * (num + num2))) + 500.0) + 100.0) + 400.0;
                num38 = num37 + 200.0;
            }
            if (tahrik.TahrikKodu == "MDDUZ")
            {
                num38 = ((((num8 * num) + (num11 * (num + num2))) + 500.0) + 100.0) + 400.0;
                num38 = num37 + 200.0;
            }
            if (((tahrik.TahrikKodu == "DA") || (tahrik.TahrikKodu == "YA")) && (tahrik.TipKodu == "EA"))
            {
                num38 = ((num8 * num) + (num11 * (((((num + num2) + num4) + num5) + num6) + num7))) + 350.0;
                num38 = (num37 + (0.1 * Convert.ToDouble(this.GetNumValue("KapiGen", "1")))) + 300.0;
            }
            double num39 = 0.0;
            if (tahrik.TipKodu == "HA")
            {
                num39 = (num37 + (0.1 * Convert.ToDouble(this.GetNumValue("KapiGen", "1")))) + 300.0;
            }
            this.LD("KK", true, new Point3d(num22, 0.0, 0.0));
            this.LD("KD", true, new Point3d(0.0, num23, 0.0));
            if (((tahrik.TahrikKodu != "MDDUZ") && (tahrik.TahrikKodu != "MDCAP")) && (tahrik.TipKodu != "HA"))
            {
                this.LD("MD", true, new Point3d(num24, num25, 0.0));
            }
            this.LD("TK-AA", true, new Point3d(num29, -50.0, 0.0));
            this.LD("TK-BB", true, new Point3d(num30, -50.0, 0.0));
            Application.SetSystemVariable("DIMLFAC", 0.0);
            try
            {
                Document document = Application.get_DocumentManager().get_MdiActiveDocument();
                if (document == null)
                {
                    return;
                }
                Database db = document.get_Database();
                Editor editor = document.get_Editor();
                DBObjectCollection objects = new DBObjectCollection();
                Entity vtEnt = null;
                string numValue = this.GetNumValue("KapiTip", "1");
                string str3 = this.GetNumValue("Mentese", "1");
                BlockReference reference = null;
                using (db)
                {
                    using (Transaction transaction = db.get_TransactionManager().StartTransaction())
                    {
                        if (tahrik.TipKodu == "EA")
                        {
                            reference = null;
                            reference = this.InsertBlock(db, transaction, new Point3d(num34, num35, 0.0), blockName, 0.5, blockName, "1", "0");
                            reference = null;
                            this.InsertBlock(db, transaction, new Point3d(num36, -100.0, 0.0), "HesapBase", 1.0, "HesapBase", "1", "0");
                            reference = this.InsertBlock(db, transaction, new Point3d(num36, 0.0, 0.0), "Check", 0.5, "Check", "1", "0");
                            vtEnt = FObject("Check", "1", "0");
                            if (vtEnt != null)
                            {
                                double num40 = ((num13 - 750) - num15) - num16;
                                if (num40 > 100.0)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "15733B1", Convert.ToString(num40) + " > 100  EN81-1 5.7.3.3.b");
                                }
                                else
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "15733B1", Convert.ToString(num40) + " < 100  EN81-1 5.7.3.3.b");
                                }
                                num40 = ((num13 - num19) - num15) - num16;
                                if (num40 > 500.0)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "15733B2", Convert.ToString(num40) + " > 500  EN81-1 5.7.3.3.b");
                                }
                                else
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "15733B2", Convert.ToString(num40) + " < 500  EN81-1 5.7.3.3.b");
                                }
                                double num41 = ((num14 - num20) - num17) - num18;
                                num40 = 1000.0 * (0.1 + ((0.035 * num21) * num21));
                                if (num41 > num40)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "15711A", Convert.ToString(num41) + " > " + Convert.ToString(num40) + " EN81-1 5.7.1.1.a");
                                }
                                else
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "15711A", Convert.ToString(num41) + " < " + Convert.ToString(num40) + " EN81-1 5.7.1.1.a");
                                }
                                num41 = (((num14 - num20) - num17) - num18) + 600;
                                num40 = 1000.0 * (1.0 + ((0.035 * num21) * num21));
                                if (num41 > num40)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "15711B", Convert.ToString(num41) + " > " + Convert.ToString(num40) + " EN81-1 5.7.1.1.b");
                                }
                                else
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "15711B", Convert.ToString(num41) + " < " + Convert.ToString(num40) + " EN81-1 5.7.1.1.b");
                                }
                                num41 = ((num14 - (num20 + 100)) - num17) - num18;
                                num40 = 1000.0 * (0.1 + ((0.035 * num21) * num21));
                                if (num41 > num40)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "5711C2", Convert.ToString(num41) + " > " + Convert.ToString(num40) + " EN81-1 5.7.1.1.c.2");
                                }
                                else
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "5711C2", Convert.ToString(num41) + " < " + Convert.ToString(num40) + " EN81-1 5.7.1.1.c.2");
                                }
                                num41 = ((num14 - num20) - num17) - num18;
                                num40 = 1000.0 * (0.3 + ((0.035 * num21) * num21));
                                if (num41 > num40)
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "5711C1", Convert.ToString(num41) + " > " + Convert.ToString(num40) + " EN81-1 5.7.1.1.c.1");
                                }
                                else
                                {
                                    this.ChTag(vtEnt.get_ObjectId(), "5711C1", Convert.ToString(num41) + " < " + Convert.ToString(num40) + " EN81-1 5.7.1.1.c.1");
                                }
                            }
                        }
                        transaction.Commit();
                        using (Transaction transaction2 = db.get_TransactionManager().StartTransaction())
                        {
                            reference = null;
                            switch (numValue)
                            {
                                case "YO-CIFT":
                                case "CK-4MER":
                                case "CK-2MER":
                                    numValue = "YOCIFT";
                                    break;
                            }
                            if ((((numValue == "YK-KRMK") || (numValue == "YO-2TEL")) || ((numValue == "YO-3TEL") || (numValue == "YO-2MER"))) || (numValue == "YO-4MER"))
                            {
                                numValue = "YO";
                            }
                            if ((tahrik.TahrikKodu == "DA") && (tahrik.TipKodu == "EA"))
                            {
                                reference = this.InsertBlock(db, transaction2, new Point3d(num37, 0.0, 0.0), "KD-" + numValue, 0.1, "KDETAY", "1", "0");
                            }
                            if (((tahrik.TahrikKodu == "MDDUZ") || (tahrik.TahrikKodu == "MDCAP")) && (tahrik.TipKodu == "EA"))
                            {
                                reference = this.InsertBlock(db, transaction2, new Point3d(num37, 0.0, 0.0), "KD-MD-" + numValue, 0.05, "KDETAY", "1", "0");
                            }
                            if (tahrik.TipKodu == "HA")
                            {
                                reference = this.InsertBlock(db, transaction2, new Point3d(num37, 0.0, 0.0), "KD-" + numValue, 0.1, "KDETAY", "1", "0");
                            }
                            vtEnt = FObject("KDETAY", "1", "0");
                            if (vtEnt != null)
                            {
                                if ((tahrik.TahrikKodu == "MDDUZ") || (tahrik.TahrikKodu == "MDCAP"))
                                {
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynKapiGen", (double) (0.05 * Convert.ToDouble(this.GetNumValue("KapiGen", "1"))));
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynKasaGen", (double) (0.05 * Convert.ToDouble(this.GetNumValue("KasaGen", "1"))));
                                }
                                else
                                {
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynKapiGen", (double) (0.1 * Convert.ToDouble(this.GetNumValue("KapiGen", "1"))));
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynKasaGen", (double) (0.1 * Convert.ToDouble(this.GetNumValue("KasaGen", "1"))));
                                }
                                if (str3 == "SAG")
                                {
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynKapiFlip", (double) 1.0);
                                }
                            }
                            reference = null;
                            if (tahrik.TahrikKodu == "MDCAP")
                            {
                                reference = this.InsertBlock(db, transaction2, new Point3d(num38, 0.0, 0.0), "SUSPMDCAP", 0.1, "SUSP", "1", "0");
                                vtEnt = FObject("SUSP", "1", "0");
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynAgrRA", (double) (0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1AgrRA", "KK"))));
                                }
                            }
                            if (tahrik.TahrikKodu == "MDDUZ")
                            {
                                reference = this.InsertBlock(db, transaction2, new Point3d(num38, 0.0, 0.0), "SUSPMD", 0.1, "SUSP", "1", "0");
                                vtEnt = FObject("SUSP", "1", "0");
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynAgrRA", (double) (0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1AgrRA", "KK"))));
                                }
                            }
                            if ((tahrik.TahrikKodu == "DA") && (tahrik.TipKodu == "EA"))
                            {
                                reference = this.InsertBlock(db, transaction2, new Point3d(num38, 0.0, 0.0), "SUSPDA", 0.1, "SUSP", "1", "0");
                                vtEnt = FObject("SUSP", "1", "0");
                                this.ChTag(vtEnt.get_ObjectId(), "AGRADET", "HESAPLANAN AĞIRLIK ADEDİ :");
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynKabinRA", (double) (0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1KabinRA", "KK"))));
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynAgrRA", (double) (0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1AgrRA", "KK"))));
                                    this.SetDynamicValue(db, transaction2, vtEnt, "AgrUzAdet", (double) 250.0);
                                }
                            }
                            reference = null;
                            if (tahrik.TipKodu == "HA")
                            {
                                reference = this.InsertBlock(db, transaction2, new Point3d(num39, 0.0, 0.0), "LKarkas", 0.1, "LKarkas", "1", "0");
                                vtEnt = FObject("LKarkas", "1", "0");
                                if (vtEnt != null)
                                {
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynHRA", (double) (0.1 * Convert.ToDouble(this.prman.GetParamValFRM("L1HRA", "KK"))));
                                    this.SetDynamicValue(db, transaction2, vtEnt, "dynPistonKab", (double) (0.1 * ((0.75 * Convert.ToDouble(this.prman.GetParamValFRM("L1KabinGen", "KK"))) + Convert.ToDouble(this.prman.GetParamValFRM("L1PistonKab", "KK")))));
                                }
                            }
                            transaction2.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Application.SetSystemVariable("DIMLFAC", 1.0);
            }
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        public void TumProje2()
        {
            this.LD("KK", false, new Point3d());
        }

        [CommandMethod("TurnLayerOff")]
        public static void TurnLayerOff()
        {
            Database database = Application.get_DocumentManager().get_MdiActiveDocument().get_Database();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                LayerTable table = transaction.GetObject(database.get_LayerTableId(), 0) as LayerTable;
                string str = "ABC";
                if (!table.Has(str))
                {
                    using (LayerTableRecord record2 = new LayerTableRecord())
                    {
                        record2.set_Name(str);
                        table.UpgradeOpen();
                        table.Add(record2);
                        transaction.AddNewlyCreatedDBObject(record2, true);
                        record2.set_IsOff(true);
                    }
                }
                else
                {
                    (transaction.GetObject(table.get_Item(str), 1) as LayerTableRecord).set_IsOff(true);
                }
                BlockTable table2 = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(table2.get_Item(BlockTableRecord.ModelSpace), 1) as BlockTableRecord;
                using (Circle circle = new Circle())
                {
                    circle.set_Center(new Point3d(2.0, 2.0, 0.0));
                    circle.set_Radius(1.0);
                    circle.set_Layer(str);
                    record.AppendEntity(circle);
                    transaction.AddNewlyCreatedDBObject(circle, true);
                }
                transaction.Commit();
            }
        }

        [CommandMethod("TurnLayerOn")]
        public static void TurnLayerOn()
        {
            LayerOn("SOLDUBEL");
        }

        [CommandMethod("UA")]
        public void UpdateAttribute()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database db = document.get_Database();
            Editor editor = document.get_Editor();
            PromptResult result = editor.GetString("\nEnter name of block to search for: ");
            if (result.get_Status() == 0x13ec)
            {
                string blockName = result.get_StringResult().ToUpper();
                result = editor.GetString("\nEnter tag of attribute to update: ");
                if (result.get_Status() == 0x13ec)
                {
                    string attbName = result.get_StringResult().ToUpper();
                    result = editor.GetString("\nEnter new value for attribute: ");
                    if (result.get_Status() == 0x13ec)
                    {
                        string attbValue = result.get_StringResult();
                        this.UpdateAttributesInDatabase(db, blockName, attbName, attbValue);
                    }
                }
            }
        }

        private int UpdateAttributesInBlock(ObjectId btrId, string blockName, string attbName, string attbValue)
        {
            int num = 0;
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            Transaction transaction = document.get_TransactionManager().StartTransaction();
            using (transaction)
            {
                BlockTableRecord record = transaction.GetObject(btrId, 0);
                foreach (ObjectId id in record)
                {
                    Entity entity = transaction.GetObject(id, 0) as Entity;
                    if (entity != null)
                    {
                        BlockReference reference = entity as BlockReference;
                        if (reference != null)
                        {
                            BlockTableRecord record2 = transaction.GetObject(reference.get_BlockTableRecord(), 0);
                            if (record2.get_Name().ToUpper() == blockName)
                            {
                                foreach (ObjectId id2 in reference.get_AttributeCollection())
                                {
                                    AttributeReference reference2 = transaction.GetObject(id2, 0) as AttributeReference;
                                    if ((reference2 != null) && (reference2.get_Tag().ToUpper() == attbName))
                                    {
                                        reference2.UpgradeOpen();
                                        reference2.set_TextString(attbValue);
                                        reference2.DowngradeOpen();
                                        num++;
                                    }
                                }
                            }
                            num += this.UpdateAttributesInBlock(reference.get_BlockTableRecord(), blockName, attbName, attbValue);
                        }
                    }
                }
                transaction.Commit();
            }
            return num;
        }

        private void UpdateAttributesInDatabase(Database db, string blockName, string attbName, string attbValue)
        {
            ObjectId id;
            ObjectId id2;
            Editor editor = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor();
            Transaction transaction = db.get_TransactionManager().StartTransaction();
            using (transaction)
            {
                BlockTable table = transaction.GetObject(db.get_BlockTableId(), 0);
                id = table.get_Item(BlockTableRecord.ModelSpace);
                id2 = table.get_Item(BlockTableRecord.PaperSpace);
                transaction.Commit();
            }
            int num = this.UpdateAttributesInBlock(id, blockName, attbName, attbValue);
            int num2 = this.UpdateAttributesInBlock(id2, blockName, attbName, attbValue);
            editor.Regen();
            editor.WriteMessage("\nProcessing file: " + db.get_Filename());
            object[] objArray1 = new object[] { num, (num == 1) ? "" : "s", attbName };
            editor.WriteMessage("\nUpdated {0} instance{1} of attribute {2} in the modelspace.", objArray1);
            object[] objArray2 = new object[] { num2, (num2 == 1) ? "" : "s", attbName };
            editor.WriteMessage("\nUpdated {0} instance{1} of attribute {2} in the default paperspace.", objArray2);
        }

        private void vtCHXdata(int LiftNumber)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = HostApplicationServices.get_WorkingDatabase();
            string str = "I";
            string str2 = "MD";
            string str3 = "LN";
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                foreach (ObjectId id in record)
                {
                    Entity entity = transaction.GetObject(id, 1, false, true);
                    ResultBuffer xDataForApplication = entity.GetXDataForApplication(str);
                    if (xDataForApplication == null)
                    {
                        xDataForApplication = entity.GetXDataForApplication(str2);
                    }
                    if (xDataForApplication != null)
                    {
                        TypedValue[] valueArray = xDataForApplication.AsArray();
                        for (int i = 0; i < valueArray.Length; i++)
                        {
                            TypedValue value2 = valueArray[i];
                            if ((value2.get_TypeCode() == 0x3e8) && (((string) value2.get_Value()) == str3))
                            {
                                valueArray[i] = new TypedValue(0x3e8, Convert.ToString(LiftNumber));
                            }
                        }
                        xDataForApplication = new ResultBuffer(valueArray);
                        entity.set_XData(xDataForApplication);
                    }
                }
                transaction.Commit();
            }
        }

        private void vtCHXdataDIM(int LiftNumber, string KesitKodu)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = HostApplicationServices.get_WorkingDatabase();
            string str = "DIM";
            string str2 = "MD";
            string str3 = "LN";
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                foreach (ObjectId id in record)
                {
                    Entity entity = transaction.GetObject(id, 1, false, true);
                    ResultBuffer xDataForApplication = entity.GetXDataForApplication(str);
                    if (xDataForApplication == null)
                    {
                        xDataForApplication = entity.GetXDataForApplication(str2);
                    }
                    if (xDataForApplication != null)
                    {
                        TypedValue[] valueArray = xDataForApplication.AsArray();
                        for (int i = 0; i < valueArray.Length; i++)
                        {
                            TypedValue value2 = valueArray[i];
                            if ((value2.get_TypeCode() == 0x3e8) && (((string) value2.get_Value()) == str3))
                            {
                                valueArray[i] = new TypedValue(0x3e8, Convert.ToString(LiftNumber));
                            }
                            if ((value2.get_TypeCode() == 0x3e8) && (((string) value2.get_Value()) == "KESKOD"))
                            {
                                valueArray[i] = new TypedValue(0x3e8, KesitKodu);
                            }
                        }
                        xDataForApplication = new ResultBuffer(valueArray);
                        entity.set_XData(xDataForApplication);
                    }
                }
                transaction.Commit();
            }
        }

        [CommandMethod("wblockEntity")]
        public void wblockEntity()
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            ObjectIdCollection ids = new ObjectIdCollection();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                foreach (ObjectId id in record)
                {
                    ids.Add(id);
                }
                transaction.Commit();
            }
            using (Database database2 = new Database(true, false))
            {
                database.Wblock(database2, ids, Point3d.get_Origin(), 2);
                if (Directory.Exists(@"C:\asnproje"))
                {
                    string str = @"C:\asnproje\wblock.dwg";
                    database2.SaveAs(str, 0x1f);
                }
                else
                {
                    Directory.CreateDirectory(@"C:\asnproje");
                    string str2 = @"C:\asnproje\wblock.dwg";
                    database2.SaveAs(str2, 0x1f);
                }
            }
        }

        public void wblockEntity(string FileName)
        {
            Document document = Application.get_DocumentManager().get_MdiActiveDocument();
            Database database = document.get_Database();
            Editor editor = document.get_Editor();
            ObjectIdCollection ids = new ObjectIdCollection();
            using (Transaction transaction = database.get_TransactionManager().StartTransaction())
            {
                BlockTable table = transaction.GetObject(database.get_BlockTableId(), 0) as BlockTable;
                BlockTableRecord record = transaction.GetObject(table.get_Item(BlockTableRecord.ModelSpace), 0) as BlockTableRecord;
                foreach (ObjectId id in record)
                {
                    ids.Add(id);
                }
                transaction.Commit();
            }
            using (Database database2 = new Database(true, false))
            {
                if (Directory.Exists(@"c:\asnproje"))
                {
                    database.Wblock(database2, ids, Point3d.get_Origin(), 2);
                    FileName = @"c:\asnproje\" + FileName + ".dwg";
                    database2.SaveAs(FileName, 0x1f);
                }
                else
                {
                    Directory.CreateDirectory(@"c:\asnproje");
                    database.Wblock(database2, ids, Point3d.get_Origin(), 2);
                    FileName = @"c:\asnproje\" + FileName + ".dwg";
                    database2.SaveAs(FileName, 0x1f);
                }
            }
        }

        [CommandMethod("YA")]
        public void YA()
        {
            this.DALL();
            this.xx.SetNumValue("TahrikKodu", "YA", "1");
        }

        [CommandMethod("LDEA")]
        public void YeniAsansorELK()
        {
            this.mn2.AsansorSayisi = 1;
            this.mn2.AsansorTipi = "EA";
            this.mn2.FormMyData = this.LiftDataOku("1");
            this.mn2.FormMyData.AASag = "1000";
            this.mn2.FormMyData.AASol = "1000";
            this.mn2.FormMyData.BBSag = "1000";
            this.mn2.FormMyData.BBSol = "1000";
            this.mn2.FormMyData.AgrDuv = "50";
            this.mn2.FormMyData.AgrGen = "150";
            this.mn2.FormMyData.AgrKabin = "120";
            this.mn2.FormMyData.KabinAgrEksenFark = "0";
            this.mn2.FormMyData.KabinDuvar = "100";
            this.mn2.FormMyData.KabinRayFark = "100";
            this.mn2.FormMyData.KabinRayUcu = "30";
            this.mn2.FormMyData.AgirRayUcu = "30";
            this.mn2.FormMyData.KabinYanDuv = "100";
            this.mn2.FormMyData.RayTavan = "100";
            this.mn2.FormMyData.SagKac = "100";
            this.xx.SetRayFark("1");
            this.mn2.ShowDialog();
            this.KapiDegerSet(this.mn2.FormMyData);
            this.LiftDataYaz(this.mn2.FormMyData, "1");
            if (!this.prman.Created)
            {
                this.prman.aadd = this;
                this.prman.asnadedi = 1;
                this.prman.destandcrash();
            }
            this.DALL();
            this.LD("KK", false, new Point3d());
        }

        [CommandMethod("LDHA")]
        public void YeniAsansorHA()
        {
            this.xx.SetNumValue("TipKodu", "HA", "1");
            this.xx.SetNumValue("TahrikKodu", "DA", "1");
            if (string.IsNullOrEmpty(this.GetParamValue("LN")))
            {
                this.NewParam("LN", "1");
            }
            else
            {
                this.chParamVal("LN", "1");
            }
            this.mn2.AsansorSayisi = 1;
            this.mn2.AsansorTipi = "HA";
            this.mn2.FormMyData = this.LiftDataOku("1");
            this.mn2.FormMyData.TipKodu = "HA";
            this.mn2.FormMyData.TahrikKodu = "DA";
            this.mn2.FormMyData.PistonKab = "250";
            this.mn2.FormMyData.PistonMer = "250";
            this.mn2.FormMyData.KabinYanDuv = "100";
            this.mn2.FormMyData.KabinRayFark = "100";
            this.mn2.FormMyData.HRA = "800";
            this.mn2.FormMyData.KabinYanDuv = "150";
            this.mn2.ShowDialog();
            this.KapiDegerSet(this.mn2.FormMyData);
            this.LiftDataYaz(this.mn2.FormMyData, "1");
            this.HAMDDegerSet(this.mn2.FormMyData.MakYon, this.mn2.FormMyData.YonKodu, this.mn2.FormMyData.HAMDGen, this.mn2.FormMyData.HAMDDer, "1");
            if (!this.prman.Created)
            {
                this.prman.aadd = this;
                this.prman.asnadedi = 1;
                this.prman.destandcrash();
            }
            this.DALL();
            this.LD("KK", false, new Point3d());
            Application.SetSystemVariable("DIMLFAC", 1.0);
        }

        public void YeniProje()
        {
            PromptKeywordOptions options = new PromptKeywordOptions("\nKesiti Sec :");
            options.set_AllowNone(false);
            options.get_Keywords().Add("KK");
            options.get_Keywords().Add("KD");
            options.get_Keywords().Add("MD");
            options.get_Keywords().Add("TK-AA");
            options.get_Keywords().Add("TK-BB");
            options.get_Keywords().Add("TTK-AA");
            options.get_Keywords().Add("TTK-BB");
            PromptResult keywords = Application.get_DocumentManager().get_MdiActiveDocument().get_Editor().GetKeywords(options);
            if (keywords.get_Status() == 0x13ec)
            {
                string kesitKodu = keywords.get_StringResult();
                if (string.IsNullOrEmpty(this.GetParamValue("LN")))
                {
                    this.NewParam("LN", "1");
                }
                else
                {
                    this.chParamVal("LN", "1");
                }
                this.LD(kesitKodu, false, new Point3d());
            }
        }

        public void zoomExtent()
        {
            object target = Application.get_ZcadApplication();
            target.GetType().InvokeMember("ZoomExtents", BindingFlags.InvokeMethod, null, target, null);
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ascad.ascad.<>c <>9 = new ascad.ascad.<>c();
            public static Func<ObjectId, bool> <>9__163_0;

            internal bool <denemerep>b__163_0(ObjectId id) => 
                (id.get_ObjectClass().get_DxfName().ToUpper() == "TEXT");
        }
    }
}

