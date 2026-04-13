namespace ascad
{
    using DevExpress.Data;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Design;
    using DevExpress.XtraVerticalGrid;
    using DevExpress.XtraVerticalGrid.Events;
    using DevExpress.XtraVerticalGrid.Rows;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class paramman : Form
    {
        public ascad.ascad aadd;
        public int asnadedi = 1;
        private IContainer components = null;
        private DataTable grdtab = new DataTable();
        private string hangideger = "";
        private VGridControl kdgrid;
        private VGridControl kdgrid2;
        private VGridControl kkgrid;
        private VGridControl kkgrid2;
        private List<EditorRow> lstedi = new List<EditorRow>();
        private List<EditorRow> lstedi2 = new List<EditorRow>();
        private VGridControl mdgrid;
        private VGridControl mdgrid2;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private VGridControl tkaagrid;
        private VGridControl tkaagrid2;
        private VGridControl tkbbgrid;
        private VGridControl tkbbgrid2;
        private VGridControl ttkaagrid;
        private VGridControl ttkaagrid2;
        private VGridControl ttkbbgrid;
        private VGridControl ttkbbgrid2;
        private abc1 xx = new abc1();

        public paramman()
        {
            this.InitializeComponent();
        }

        public void araformda(string gelen)
        {
            for (int i = 0; i < this.lstedi.Count; i++)
            {
                this.lstedi[i].Visible = false;
                if (this.lstedi[i].Properties.Value > null)
                {
                    if (this.lstedi[i].Properties.Caption.Contains(gelen))
                    {
                        this.lstedi[i].Visible = true;
                    }
                    if (this.lstedi[i].Properties.Value.ToString().Contains(gelen))
                    {
                        this.lstedi[i].Visible = true;
                    }
                    if (this.lstedi[i].Properties.UnboundExpression.Contains(gelen))
                    {
                        this.lstedi[i].Visible = true;
                    }
                }
                else
                {
                    Debug.WriteLine("NULL DEGER ROW ===>" + this.lstedi[i].Properties.Caption);
                }
            }
        }

        private void bt(string KesitKODU)
        {
            clsMLift lift = null;
            lift = this.aadd.ReadAllData("1", KesitKODU);
            string str = "PL1";
            string str2 = "L1";
            foreach (ConsParList list in lift.DimGrup)
            {
                string vtParName = str + list.ConsName;
                this.NewParam(vtParName, list.ConsValue, KesitKODU);
            }
            foreach (ParamList list2 in lift.VarGrup)
            {
                this.NewParam(list2.ParamName, "1", KesitKODU);
            }
            foreach (ParamList list3 in lift.VarGrup)
            {
                try
                {
                    this.chParamVal(list3.ParamName, list3.ParamValue, KesitKODU);
                }
                catch (Exception)
                {
                }
            }
            foreach (vtLift lift2 in lift.BlokGrup)
            {
                foreach (ParamList list4 in lift2.BlkParamList)
                {
                    if ((list4.ParamName != null) || (list4.ParamValue > null))
                    {
                        string introduced18 = str2 + list4.ParamName;
                        this.NewParam(introduced18, list4.ParamValue, KesitKODU);
                    }
                }
            }
            foreach (ParamList list5 in lift.VarGrup)
            {
                this.RenameParam(list5.ParamName, str2 + list5.ParamName, KesitKODU);
            }
        }

        private void bt2(string KesitKODU)
        {
            clsMLift lift = null;
            lift = this.aadd.ReadAllData("2", KesitKODU);
            string str = "PL2";
            string str2 = "L2";
            foreach (ConsParList list in lift.DimGrup)
            {
                string vtParName = str + list.ConsName;
                this.NewParam2(vtParName, list.ConsValue, KesitKODU);
            }
            foreach (ParamList list2 in lift.VarGrup)
            {
                this.NewParam2(list2.ParamName, "2", KesitKODU);
            }
            foreach (ParamList list3 in lift.VarGrup)
            {
                try
                {
                    this.chParamVal2(list3.ParamName, list3.ParamValue, KesitKODU);
                }
                catch (Exception)
                {
                }
            }
            foreach (vtLift lift2 in lift.BlokGrup)
            {
                foreach (ParamList list4 in lift2.BlkParamList)
                {
                    if ((list4.ParamName != null) || (list4.ParamValue > null))
                    {
                        string introduced18 = str2 + list4.ParamName;
                        this.NewParam2(introduced18, list4.ParamValue, KesitKODU);
                    }
                }
            }
            foreach (ParamList list5 in lift.VarGrup)
            {
                this.RenameParam2(list5.ParamName, str2 + list5.ParamName, KesitKODU);
            }
        }

        public void chParamVal(string vtParName, string newName)
        {
            if (vtParName.StartsWith("PL2") || vtParName.StartsWith("L2"))
            {
                if (this.ifrowvar(vtParName, "KK"))
                {
                    this.kkgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "KD"))
                {
                    this.kdgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "MD"))
                {
                    this.mdgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "TK-AA"))
                {
                    this.tkaagrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "TK-BB"))
                {
                    this.tkbbgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "TTK-AA"))
                {
                    this.ttkaagrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "TTK-BB"))
                {
                    this.ttkbbgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                }
            }
            else
            {
                if (this.ifrowvar(vtParName, "KK"))
                {
                    this.kkgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "KD"))
                {
                    this.kdgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "MD"))
                {
                    this.mdgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "TK-AA"))
                {
                    this.tkaagrid.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "TK-BB"))
                {
                    this.tkbbgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "TTK-AA"))
                {
                    this.ttkaagrid.Rows[vtParName].Properties.UnboundExpression = newName;
                }
                if (this.ifrowvar(vtParName, "TTK-BB"))
                {
                    this.ttkbbgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                }
            }
        }

        public void chParamVal(string vtParName, string newName, string KesitKODU)
        {
            try
            {
                if (this.ifrowvar(vtParName, KesitKODU))
                {
                    if (KesitKODU == "KK")
                    {
                        this.kkgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "KD")
                    {
                        this.kdgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "MD")
                    {
                        this.mdgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "TK-AA")
                    {
                        this.tkaagrid.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "TK-BB")
                    {
                        this.tkbbgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "TTK-AA")
                    {
                        this.ttkaagrid.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "TTK-BB")
                    {
                        this.ttkbbgrid.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else
                    {
                        Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
                    }
                }
                else
                {
                    Debug.WriteLine("ch paramvar VAR -> " + vtParName);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ch paramvar -> CATCH" + vtParName + " " + exception.ToString());
            }
        }

        public void chParamVal2(string vtParName, string newName, string KesitKODU)
        {
            try
            {
                if (this.ifrowvar2(vtParName, KesitKODU))
                {
                    if (KesitKODU == "KK")
                    {
                        this.kkgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "KD")
                    {
                        this.kdgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "MD")
                    {
                        this.mdgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "TK-AA")
                    {
                        this.tkaagrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "TK-BB")
                    {
                        this.tkbbgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "TTK-AA")
                    {
                        this.ttkaagrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else if (KesitKODU == "TTK-BB")
                    {
                        this.ttkbbgrid2.Rows[vtParName].Properties.UnboundExpression = newName;
                    }
                    else
                    {
                        Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
                    }
                }
                else
                {
                    Debug.WriteLine("ch paramvar VAR -> " + vtParName);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ch paramvar -> CATCH" + vtParName + " " + exception.ToString());
            }
        }

        public void destandcrash()
        {
            DataTable table = new DataTable();
            table.Rows.Clear();
            if (table.Columns.Count < 1)
            {
                table.Columns.Add("a", typeof(string));
                DataRow row = table.NewRow();
                row["a"] = "ARA BURADAN";
                table.Rows.Add(row);
            }
            else
            {
                DataRow row2 = table.NewRow();
                row2["a"] = "ARA BURADAN";
                table.Rows.Add(row2);
            }
            this.kkgrid.Dispose();
            this.kdgrid.Dispose();
            this.mdgrid.Dispose();
            this.tkaagrid.Dispose();
            this.tkbbgrid.Dispose();
            this.ttkaagrid.Dispose();
            this.ttkbbgrid.Dispose();
            this.kkgrid2.Dispose();
            this.kdgrid2.Dispose();
            this.mdgrid2.Dispose();
            this.tkaagrid2.Dispose();
            this.tkbbgrid2.Dispose();
            this.ttkaagrid2.Dispose();
            this.ttkbbgrid.Dispose();
            this.InitializeComponent();
            this.kkgrid.DataSource = table;
            this.mdgrid.DataSource = table;
            this.kdgrid.DataSource = table;
            this.tkaagrid.DataSource = table;
            this.tkbbgrid.DataSource = table;
            this.ttkaagrid.DataSource = table;
            this.ttkbbgrid.DataSource = table;
            this.kkgrid2.DataSource = table;
            this.mdgrid2.DataSource = table;
            this.kdgrid2.DataSource = table;
            this.tkaagrid2.DataSource = table;
            this.tkbbgrid2.DataSource = table;
            this.ttkaagrid2.DataSource = table;
            this.ttkbbgrid.DataSource = table;
            this.lstedi.Clear();
            this.bt("KK");
            this.bt("KD");
            this.bt("MD");
            this.bt("TK-AA");
            this.bt("TK-BB");
            this.bt("TTK-AA");
            this.bt("TTK-BB");
            if (this.asnadedi > 1)
            {
                this.bt2("KK");
                this.bt2("KD");
                this.bt2("MD");
                this.bt2("TK-AA");
                this.bt2("TK-BB");
                this.bt2("TTK-AA");
                this.bt2("TTK-BB");
                for (int i = 0; i < this.lstedi2.Count; i++)
                {
                    try
                    {
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine("ROW EKLENEMDİ NEDENİ" + exception.ToString());
                    }
                }
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

        private void editedlist()
        {
            EditorRow row = new EditorRow("fieldname") {
                Properties = { 
                    Caption = "başlık",
                    FieldName = this.xx.turlestir("fielname"),
                    UnboundType = UnboundColumnType.Object,
                    UnboundExpression = "expression",
                    ShowUnboundExpressionMenu = true
                },
                Name = "x" + 12
            };
            this.kkgrid.Rows.Add(row);
        }

        private void ExpressionEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnboundColumnExpressionEditorForm form = (UnboundColumnExpressionEditorForm) sender;
        }

        public string GetParamValFRM(string paramna, string KesitKODU)
        {
            string str = "0";
            try
            {
                if (this.ifrowvar(paramna, KesitKODU))
                {
                    if (KesitKODU == "KK")
                    {
                        if (paramna.StartsWith("PL2") || paramna.StartsWith("L2"))
                        {
                            return this.kkgrid2.GetCellValue(this.kkgrid2.Rows[paramna], 0).ToString();
                        }
                        return this.kkgrid.GetCellValue(this.kkgrid.Rows[paramna], 0).ToString();
                    }
                    if (KesitKODU == "KD")
                    {
                        if (paramna.StartsWith("PL2") || paramna.StartsWith("L2"))
                        {
                            return this.kdgrid2.GetCellValue(this.kdgrid2.Rows[paramna], 0).ToString();
                        }
                        return this.kdgrid.GetCellValue(this.kdgrid.Rows[paramna], 0).ToString();
                    }
                    if (KesitKODU == "MD")
                    {
                        if (paramna.StartsWith("PL2") || paramna.StartsWith("L2"))
                        {
                            return this.mdgrid2.GetCellValue(this.mdgrid2.Rows[paramna], 0).ToString();
                        }
                        return this.mdgrid.GetCellValue(this.mdgrid.Rows[paramna], 0).ToString();
                    }
                    if (KesitKODU == "TK-AA")
                    {
                        if (paramna.StartsWith("PL2") || paramna.StartsWith("L2"))
                        {
                            return this.tkaagrid2.GetCellValue(this.tkaagrid2.Rows[paramna], 0).ToString();
                        }
                        return this.tkaagrid.GetCellValue(this.tkaagrid.Rows[paramna], 0).ToString();
                    }
                    if (KesitKODU == "TK-BB")
                    {
                        if (paramna.StartsWith("PL2") || paramna.StartsWith("L2"))
                        {
                            return this.tkbbgrid2.GetCellValue(this.tkbbgrid2.Rows[paramna], 0).ToString();
                        }
                        return this.tkbbgrid.GetCellValue(this.tkbbgrid.Rows[paramna], 0).ToString();
                    }
                    if (KesitKODU == "TTK-AA")
                    {
                        if (paramna.StartsWith("PL2") || paramna.StartsWith("L2"))
                        {
                            return this.ttkaagrid2.GetCellValue(this.ttkaagrid2.Rows[paramna], 0).ToString();
                        }
                        return this.ttkaagrid.GetCellValue(this.ttkaagrid.Rows[paramna], 0).ToString();
                    }
                    if (KesitKODU == "TTK-BB")
                    {
                        if (paramna.StartsWith("PL2") || paramna.StartsWith("L2"))
                        {
                            return this.ttkbbgrid2.GetCellValue(this.ttkbbgrid2.Rows[paramna], 0).ToString();
                        }
                        return this.ttkbbgrid.GetCellValue(this.ttkbbgrid.Rows[paramna], 0).ToString();
                    }
                    Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
                    return str;
                }
                Debug.WriteLine("ROW YOK -> " + paramna);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ROW YOK -> CATCH" + exception.ToString());
            }
            return str;
        }

        private void InitializeComponent()
        {
            this.kkgrid = new VGridControl();
            this.kdgrid = new VGridControl();
            this.mdgrid = new VGridControl();
            this.tkaagrid = new VGridControl();
            this.tkbbgrid = new VGridControl();
            this.ttkaagrid = new VGridControl();
            this.ttkbbgrid = new VGridControl();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.kkgrid2 = new VGridControl();
            this.mdgrid2 = new VGridControl();
            this.ttkaagrid2 = new VGridControl();
            this.tkbbgrid2 = new VGridControl();
            this.kdgrid2 = new VGridControl();
            this.tkaagrid2 = new VGridControl();
            this.ttkbbgrid2 = new VGridControl();
            this.kkgrid.BeginInit();
            this.kdgrid.BeginInit();
            this.mdgrid.BeginInit();
            this.tkaagrid.BeginInit();
            this.tkbbgrid.BeginInit();
            this.ttkaagrid.BeginInit();
            this.ttkbbgrid.BeginInit();
            this.kkgrid2.BeginInit();
            this.mdgrid2.BeginInit();
            this.ttkaagrid2.BeginInit();
            this.tkbbgrid2.BeginInit();
            this.kdgrid2.BeginInit();
            this.tkaagrid2.BeginInit();
            this.ttkbbgrid2.BeginInit();
            base.SuspendLayout();
            this.kkgrid.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.BandBorder.Options.UseFont = true;
            this.kkgrid.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.Category.Options.UseFont = true;
            this.kkgrid.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.kkgrid.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.kkgrid.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.DisabledRow.Options.UseFont = true;
            this.kkgrid.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.Empty.Options.UseFont = true;
            this.kkgrid.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.ExpandButton.Options.UseFont = true;
            this.kkgrid.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.FixedLine.Options.UseFont = true;
            this.kkgrid.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.FocusedCell.Options.UseFont = true;
            this.kkgrid.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.FocusedRecord.Options.UseFont = true;
            this.kkgrid.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.FocusedRow.Options.UseFont = true;
            this.kkgrid.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.kkgrid.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.HorzLine.Options.UseFont = true;
            this.kkgrid.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.kkgrid.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.ModifiedRow.Options.UseFont = true;
            this.kkgrid.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.PressedRow.Options.UseFont = true;
            this.kkgrid.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.kkgrid.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.kkgrid.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.RecordValue.Options.UseFont = true;
            this.kkgrid.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.kkgrid.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.SelectedCell.Options.UseFont = true;
            this.kkgrid.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.SelectedRecord.Options.UseFont = true;
            this.kkgrid.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.SelectedRow.Options.UseFont = true;
            this.kkgrid.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid.Appearance.VertLine.Options.UseFont = true;
            this.kkgrid.Dock = DockStyle.Left;
            this.kkgrid.FindPanelVisible = true;
            this.kkgrid.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.kkgrid.Location = new Point(0, 0);
            this.kkgrid.Name = "kkgrid";
            this.kkgrid.OptionsFind.FindNullPrompt = "kuyu kabin";
            this.kkgrid.OptionsMenu.EnableContextMenu = true;
            this.kkgrid.Size = new Size(0x18c, 0x2e7);
            this.kkgrid.TabIndex = 0;
            this.kkgrid.Click += new EventHandler(this.vGridControl1_MouseClick);
            this.kdgrid.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.BandBorder.Options.UseFont = true;
            this.kdgrid.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.Category.Options.UseFont = true;
            this.kdgrid.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.kdgrid.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.kdgrid.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.DisabledRow.Options.UseFont = true;
            this.kdgrid.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.Empty.Options.UseFont = true;
            this.kdgrid.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.ExpandButton.Options.UseFont = true;
            this.kdgrid.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.FixedLine.Options.UseFont = true;
            this.kdgrid.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.FocusedCell.Options.UseFont = true;
            this.kdgrid.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.FocusedRecord.Options.UseFont = true;
            this.kdgrid.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.FocusedRow.Options.UseFont = true;
            this.kdgrid.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.kdgrid.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.HorzLine.Options.UseFont = true;
            this.kdgrid.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.kdgrid.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.ModifiedRow.Options.UseFont = true;
            this.kdgrid.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.PressedRow.Options.UseFont = true;
            this.kdgrid.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.kdgrid.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.kdgrid.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.RecordValue.Options.UseFont = true;
            this.kdgrid.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.kdgrid.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.SelectedCell.Options.UseFont = true;
            this.kdgrid.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.SelectedRecord.Options.UseFont = true;
            this.kdgrid.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.SelectedRow.Options.UseFont = true;
            this.kdgrid.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid.Appearance.VertLine.Options.UseFont = true;
            this.kdgrid.FindPanelVisible = true;
            this.kdgrid.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.kdgrid.Location = new Point(0x377, 0x84);
            this.kdgrid.Name = "kdgrid";
            this.kdgrid.OptionsFind.FindNullPrompt = "kuyu dibi kesditi";
            this.kdgrid.OptionsMenu.EnableContextMenu = true;
            this.kdgrid.Size = new Size(180, 200);
            this.kdgrid.TabIndex = 2;
            this.mdgrid.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.BandBorder.Options.UseFont = true;
            this.mdgrid.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.Category.Options.UseFont = true;
            this.mdgrid.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.mdgrid.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.mdgrid.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.DisabledRow.Options.UseFont = true;
            this.mdgrid.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.Empty.Options.UseFont = true;
            this.mdgrid.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.ExpandButton.Options.UseFont = true;
            this.mdgrid.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.FixedLine.Options.UseFont = true;
            this.mdgrid.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.FocusedCell.Options.UseFont = true;
            this.mdgrid.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.FocusedRecord.Options.UseFont = true;
            this.mdgrid.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.FocusedRow.Options.UseFont = true;
            this.mdgrid.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.mdgrid.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.HorzLine.Options.UseFont = true;
            this.mdgrid.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.mdgrid.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.ModifiedRow.Options.UseFont = true;
            this.mdgrid.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.PressedRow.Options.UseFont = true;
            this.mdgrid.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.mdgrid.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.mdgrid.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.RecordValue.Options.UseFont = true;
            this.mdgrid.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.mdgrid.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.SelectedCell.Options.UseFont = true;
            this.mdgrid.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.SelectedRecord.Options.UseFont = true;
            this.mdgrid.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.SelectedRow.Options.UseFont = true;
            this.mdgrid.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid.Appearance.VertLine.Options.UseFont = true;
            this.mdgrid.FindPanelVisible = true;
            this.mdgrid.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.mdgrid.Location = new Point(0x503, 0x151);
            this.mdgrid.Name = "mdgrid";
            this.mdgrid.OptionsFind.FindNullPrompt = "mak daire kesiti";
            this.mdgrid.OptionsMenu.EnableContextMenu = true;
            this.mdgrid.Size = new Size(0xb0, 200);
            this.mdgrid.TabIndex = 3;
            this.tkaagrid.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.BandBorder.Options.UseFont = true;
            this.tkaagrid.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.Category.Options.UseFont = true;
            this.tkaagrid.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.tkaagrid.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.tkaagrid.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.DisabledRow.Options.UseFont = true;
            this.tkaagrid.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.Empty.Options.UseFont = true;
            this.tkaagrid.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.ExpandButton.Options.UseFont = true;
            this.tkaagrid.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.FixedLine.Options.UseFont = true;
            this.tkaagrid.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.FocusedCell.Options.UseFont = true;
            this.tkaagrid.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.FocusedRecord.Options.UseFont = true;
            this.tkaagrid.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.FocusedRow.Options.UseFont = true;
            this.tkaagrid.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.tkaagrid.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.HorzLine.Options.UseFont = true;
            this.tkaagrid.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.tkaagrid.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.ModifiedRow.Options.UseFont = true;
            this.tkaagrid.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.PressedRow.Options.UseFont = true;
            this.tkaagrid.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.tkaagrid.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.tkaagrid.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.RecordValue.Options.UseFont = true;
            this.tkaagrid.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.tkaagrid.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.SelectedCell.Options.UseFont = true;
            this.tkaagrid.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.SelectedRecord.Options.UseFont = true;
            this.tkaagrid.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.SelectedRow.Options.UseFont = true;
            this.tkaagrid.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid.Appearance.VertLine.Options.UseFont = true;
            this.tkaagrid.FindPanelVisible = true;
            this.tkaagrid.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.tkaagrid.Location = new Point(0x43d, 0x151);
            this.tkaagrid.Name = "tkaagrid";
            this.tkaagrid.OptionsFind.FindNullPrompt = "tkaa";
            this.tkaagrid.OptionsMenu.EnableContextMenu = true;
            this.tkaagrid.Size = new Size(180, 200);
            this.tkaagrid.TabIndex = 4;
            this.tkbbgrid.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.BandBorder.Options.UseFont = true;
            this.tkbbgrid.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.Category.Options.UseFont = true;
            this.tkbbgrid.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.tkbbgrid.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.tkbbgrid.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.DisabledRow.Options.UseFont = true;
            this.tkbbgrid.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.Empty.Options.UseFont = true;
            this.tkbbgrid.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.ExpandButton.Options.UseFont = true;
            this.tkbbgrid.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.FixedLine.Options.UseFont = true;
            this.tkbbgrid.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.FocusedCell.Options.UseFont = true;
            this.tkbbgrid.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.FocusedRecord.Options.UseFont = true;
            this.tkbbgrid.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.FocusedRow.Options.UseFont = true;
            this.tkbbgrid.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.tkbbgrid.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.HorzLine.Options.UseFont = true;
            this.tkbbgrid.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.tkbbgrid.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.ModifiedRow.Options.UseFont = true;
            this.tkbbgrid.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.PressedRow.Options.UseFont = true;
            this.tkbbgrid.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.tkbbgrid.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.tkbbgrid.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.RecordValue.Options.UseFont = true;
            this.tkbbgrid.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.tkbbgrid.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.SelectedCell.Options.UseFont = true;
            this.tkbbgrid.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.SelectedRecord.Options.UseFont = true;
            this.tkbbgrid.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.SelectedRow.Options.UseFont = true;
            this.tkbbgrid.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid.Appearance.VertLine.Options.UseFont = true;
            this.tkbbgrid.FindPanelVisible = true;
            this.tkbbgrid.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.tkbbgrid.Location = new Point(0x443, 0x84);
            this.tkbbgrid.Name = "tkbbgrid";
            this.tkbbgrid.OptionsFind.FindNullPrompt = "tkbbgrid kes";
            this.tkbbgrid.OptionsMenu.EnableContextMenu = true;
            this.tkbbgrid.Size = new Size(180, 200);
            this.tkbbgrid.TabIndex = 5;
            this.ttkaagrid.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.BandBorder.Options.UseFont = true;
            this.ttkaagrid.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.Category.Options.UseFont = true;
            this.ttkaagrid.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.ttkaagrid.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.ttkaagrid.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.DisabledRow.Options.UseFont = true;
            this.ttkaagrid.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.Empty.Options.UseFont = true;
            this.ttkaagrid.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.ExpandButton.Options.UseFont = true;
            this.ttkaagrid.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.FixedLine.Options.UseFont = true;
            this.ttkaagrid.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.FocusedCell.Options.UseFont = true;
            this.ttkaagrid.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.FocusedRecord.Options.UseFont = true;
            this.ttkaagrid.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.FocusedRow.Options.UseFont = true;
            this.ttkaagrid.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.ttkaagrid.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.HorzLine.Options.UseFont = true;
            this.ttkaagrid.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.ttkaagrid.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.ModifiedRow.Options.UseFont = true;
            this.ttkaagrid.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.PressedRow.Options.UseFont = true;
            this.ttkaagrid.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.ttkaagrid.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.ttkaagrid.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.RecordValue.Options.UseFont = true;
            this.ttkaagrid.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.ttkaagrid.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.SelectedCell.Options.UseFont = true;
            this.ttkaagrid.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.SelectedRecord.Options.UseFont = true;
            this.ttkaagrid.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.SelectedRow.Options.UseFont = true;
            this.ttkaagrid.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid.Appearance.VertLine.Options.UseFont = true;
            this.ttkaagrid.FindPanelVisible = true;
            this.ttkaagrid.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.ttkaagrid.Location = new Point(0x377, 0x152);
            this.ttkaagrid.Name = "ttkaagrid";
            this.ttkaagrid.OptionsMenu.EnableContextMenu = true;
            this.ttkaagrid.Size = new Size(180, 200);
            this.ttkaagrid.TabIndex = 6;
            this.ttkbbgrid.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.BandBorder.Options.UseFont = true;
            this.ttkbbgrid.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.Category.Options.UseFont = true;
            this.ttkbbgrid.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.ttkbbgrid.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.ttkbbgrid.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.DisabledRow.Options.UseFont = true;
            this.ttkbbgrid.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.Empty.Options.UseFont = true;
            this.ttkbbgrid.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.ExpandButton.Options.UseFont = true;
            this.ttkbbgrid.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.FixedLine.Options.UseFont = true;
            this.ttkbbgrid.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.FocusedCell.Options.UseFont = true;
            this.ttkbbgrid.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.FocusedRecord.Options.UseFont = true;
            this.ttkbbgrid.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.FocusedRow.Options.UseFont = true;
            this.ttkbbgrid.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.ttkbbgrid.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.HorzLine.Options.UseFont = true;
            this.ttkbbgrid.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.ttkbbgrid.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.ModifiedRow.Options.UseFont = true;
            this.ttkbbgrid.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.PressedRow.Options.UseFont = true;
            this.ttkbbgrid.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.ttkbbgrid.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.ttkbbgrid.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.RecordValue.Options.UseFont = true;
            this.ttkbbgrid.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.ttkbbgrid.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.SelectedCell.Options.UseFont = true;
            this.ttkbbgrid.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.SelectedRecord.Options.UseFont = true;
            this.ttkbbgrid.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.SelectedRow.Options.UseFont = true;
            this.ttkbbgrid.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid.Appearance.VertLine.Options.UseFont = true;
            this.ttkbbgrid.FindPanelVisible = true;
            this.ttkbbgrid.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.ttkbbgrid.Location = new Point(0x5b9, 0x152);
            this.ttkbbgrid.Name = "ttkbbgrid";
            this.ttkbbgrid.OptionsFind.FindNullPrompt = "ttkbb uzun kesit";
            this.ttkbbgrid.OptionsMenu.EnableContextMenu = true;
            this.ttkbbgrid.Size = new Size(170, 200);
            this.ttkbbgrid.TabIndex = 7;
            this.simpleButton1.Location = new Point(0x192, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x97, 0x17);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "ARAMA YAPMAK İ\x00c7İN BAS";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(0x193, 0x2a);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(150, 0x17);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "T\x00dcM SATIRLAR";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.kkgrid2.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.BandBorder.Options.UseFont = true;
            this.kkgrid2.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.Category.Options.UseFont = true;
            this.kkgrid2.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.kkgrid2.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.kkgrid2.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.DisabledRow.Options.UseFont = true;
            this.kkgrid2.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.Empty.Options.UseFont = true;
            this.kkgrid2.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.ExpandButton.Options.UseFont = true;
            this.kkgrid2.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.FixedLine.Options.UseFont = true;
            this.kkgrid2.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.FocusedCell.Options.UseFont = true;
            this.kkgrid2.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.FocusedRecord.Options.UseFont = true;
            this.kkgrid2.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.FocusedRow.Options.UseFont = true;
            this.kkgrid2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.kkgrid2.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.HorzLine.Options.UseFont = true;
            this.kkgrid2.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.kkgrid2.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.ModifiedRow.Options.UseFont = true;
            this.kkgrid2.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.PressedRow.Options.UseFont = true;
            this.kkgrid2.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.kkgrid2.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.kkgrid2.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.RecordValue.Options.UseFont = true;
            this.kkgrid2.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.kkgrid2.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.SelectedCell.Options.UseFont = true;
            this.kkgrid2.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.SelectedRecord.Options.UseFont = true;
            this.kkgrid2.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.SelectedRow.Options.UseFont = true;
            this.kkgrid2.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kkgrid2.Appearance.VertLine.Options.UseFont = true;
            this.kkgrid2.FindPanelVisible = true;
            this.kkgrid2.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.kkgrid2.Location = new Point(0x22f, 0);
            this.kkgrid2.Name = "kkgrid2";
            this.kkgrid2.OptionsFind.FindNullPrompt = "kuyu kabin";
            this.kkgrid2.OptionsMenu.EnableContextMenu = true;
            this.kkgrid2.Size = new Size(0x129, 0x2e7);
            this.kkgrid2.TabIndex = 12;
            this.kkgrid2.Click += new EventHandler(this.kkgrid2_Click);
            this.mdgrid2.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.BandBorder.Options.UseFont = true;
            this.mdgrid2.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.Category.Options.UseFont = true;
            this.mdgrid2.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.mdgrid2.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.mdgrid2.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.DisabledRow.Options.UseFont = true;
            this.mdgrid2.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.Empty.Options.UseFont = true;
            this.mdgrid2.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.ExpandButton.Options.UseFont = true;
            this.mdgrid2.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.FixedLine.Options.UseFont = true;
            this.mdgrid2.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.FocusedCell.Options.UseFont = true;
            this.mdgrid2.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.FocusedRecord.Options.UseFont = true;
            this.mdgrid2.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.FocusedRow.Options.UseFont = true;
            this.mdgrid2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.mdgrid2.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.HorzLine.Options.UseFont = true;
            this.mdgrid2.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.mdgrid2.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.ModifiedRow.Options.UseFont = true;
            this.mdgrid2.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.PressedRow.Options.UseFont = true;
            this.mdgrid2.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.mdgrid2.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.mdgrid2.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.RecordValue.Options.UseFont = true;
            this.mdgrid2.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.mdgrid2.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.SelectedCell.Options.UseFont = true;
            this.mdgrid2.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.SelectedRecord.Options.UseFont = true;
            this.mdgrid2.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.SelectedRow.Options.UseFont = true;
            this.mdgrid2.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.mdgrid2.Appearance.VertLine.Options.UseFont = true;
            this.mdgrid2.FindPanelVisible = true;
            this.mdgrid2.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.mdgrid2.Location = new Point(0x503, 0x21f);
            this.mdgrid2.Name = "mdgrid2";
            this.mdgrid2.OptionsFind.FindNullPrompt = "mak daire kesiti";
            this.mdgrid2.OptionsMenu.EnableContextMenu = true;
            this.mdgrid2.Size = new Size(180, 200);
            this.mdgrid2.TabIndex = 14;
            this.ttkaagrid2.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.BandBorder.Options.UseFont = true;
            this.ttkaagrid2.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.Category.Options.UseFont = true;
            this.ttkaagrid2.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.ttkaagrid2.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.ttkaagrid2.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.DisabledRow.Options.UseFont = true;
            this.ttkaagrid2.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.Empty.Options.UseFont = true;
            this.ttkaagrid2.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.ExpandButton.Options.UseFont = true;
            this.ttkaagrid2.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.FixedLine.Options.UseFont = true;
            this.ttkaagrid2.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.FocusedCell.Options.UseFont = true;
            this.ttkaagrid2.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.FocusedRecord.Options.UseFont = true;
            this.ttkaagrid2.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.FocusedRow.Options.UseFont = true;
            this.ttkaagrid2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.ttkaagrid2.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.HorzLine.Options.UseFont = true;
            this.ttkaagrid2.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.ttkaagrid2.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.ModifiedRow.Options.UseFont = true;
            this.ttkaagrid2.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.PressedRow.Options.UseFont = true;
            this.ttkaagrid2.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.ttkaagrid2.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.ttkaagrid2.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.RecordValue.Options.UseFont = true;
            this.ttkaagrid2.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.ttkaagrid2.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.SelectedCell.Options.UseFont = true;
            this.ttkaagrid2.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.SelectedRecord.Options.UseFont = true;
            this.ttkaagrid2.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.SelectedRow.Options.UseFont = true;
            this.ttkaagrid2.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkaagrid2.Appearance.VertLine.Options.UseFont = true;
            this.ttkaagrid2.FindPanelVisible = true;
            this.ttkaagrid2.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.ttkaagrid2.Location = new Point(0x377, 0x21f);
            this.ttkaagrid2.Name = "ttkaagrid2";
            this.ttkaagrid2.OptionsMenu.EnableContextMenu = true;
            this.ttkaagrid2.Size = new Size(180, 200);
            this.ttkaagrid2.TabIndex = 0x10;
            this.tkbbgrid2.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.BandBorder.Options.UseFont = true;
            this.tkbbgrid2.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.Category.Options.UseFont = true;
            this.tkbbgrid2.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.tkbbgrid2.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.tkbbgrid2.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.DisabledRow.Options.UseFont = true;
            this.tkbbgrid2.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.Empty.Options.UseFont = true;
            this.tkbbgrid2.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.ExpandButton.Options.UseFont = true;
            this.tkbbgrid2.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.FixedLine.Options.UseFont = true;
            this.tkbbgrid2.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.FocusedCell.Options.UseFont = true;
            this.tkbbgrid2.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.FocusedRecord.Options.UseFont = true;
            this.tkbbgrid2.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.FocusedRow.Options.UseFont = true;
            this.tkbbgrid2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.tkbbgrid2.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.HorzLine.Options.UseFont = true;
            this.tkbbgrid2.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.tkbbgrid2.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.ModifiedRow.Options.UseFont = true;
            this.tkbbgrid2.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.PressedRow.Options.UseFont = true;
            this.tkbbgrid2.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.tkbbgrid2.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.tkbbgrid2.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.RecordValue.Options.UseFont = true;
            this.tkbbgrid2.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.tkbbgrid2.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.SelectedCell.Options.UseFont = true;
            this.tkbbgrid2.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.SelectedRecord.Options.UseFont = true;
            this.tkbbgrid2.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.SelectedRow.Options.UseFont = true;
            this.tkbbgrid2.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkbbgrid2.Appearance.VertLine.Options.UseFont = true;
            this.tkbbgrid2.FindPanelVisible = true;
            this.tkbbgrid2.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.tkbbgrid2.Location = new Point(0x5b3, 0x84);
            this.tkbbgrid2.Name = "tkbbgrid2";
            this.tkbbgrid2.OptionsFind.FindNullPrompt = "tkbbgrid kes";
            this.tkbbgrid2.OptionsMenu.EnableContextMenu = true;
            this.tkbbgrid2.Size = new Size(180, 200);
            this.tkbbgrid2.TabIndex = 15;
            this.kdgrid2.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.BandBorder.Options.UseFont = true;
            this.kdgrid2.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.Category.Options.UseFont = true;
            this.kdgrid2.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.kdgrid2.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.kdgrid2.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.DisabledRow.Options.UseFont = true;
            this.kdgrid2.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.Empty.Options.UseFont = true;
            this.kdgrid2.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.ExpandButton.Options.UseFont = true;
            this.kdgrid2.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.FixedLine.Options.UseFont = true;
            this.kdgrid2.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.FocusedCell.Options.UseFont = true;
            this.kdgrid2.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.FocusedRecord.Options.UseFont = true;
            this.kdgrid2.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.FocusedRow.Options.UseFont = true;
            this.kdgrid2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.kdgrid2.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.HorzLine.Options.UseFont = true;
            this.kdgrid2.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.kdgrid2.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.ModifiedRow.Options.UseFont = true;
            this.kdgrid2.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.PressedRow.Options.UseFont = true;
            this.kdgrid2.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.kdgrid2.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.kdgrid2.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.RecordValue.Options.UseFont = true;
            this.kdgrid2.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.kdgrid2.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.SelectedCell.Options.UseFont = true;
            this.kdgrid2.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.SelectedRecord.Options.UseFont = true;
            this.kdgrid2.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.SelectedRow.Options.UseFont = true;
            this.kdgrid2.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.kdgrid2.Appearance.VertLine.Options.UseFont = true;
            this.kdgrid2.FindPanelVisible = true;
            this.kdgrid2.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.kdgrid2.Location = new Point(0x4fd, 0x84);
            this.kdgrid2.Name = "kdgrid2";
            this.kdgrid2.OptionsFind.FindNullPrompt = "kuyu dibi kesditi";
            this.kdgrid2.OptionsMenu.EnableContextMenu = true;
            this.kdgrid2.Size = new Size(180, 200);
            this.kdgrid2.TabIndex = 13;
            this.tkaagrid2.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.BandBorder.Options.UseFont = true;
            this.tkaagrid2.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.Category.Options.UseFont = true;
            this.tkaagrid2.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.tkaagrid2.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.tkaagrid2.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.DisabledRow.Options.UseFont = true;
            this.tkaagrid2.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.Empty.Options.UseFont = true;
            this.tkaagrid2.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.ExpandButton.Options.UseFont = true;
            this.tkaagrid2.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.FixedLine.Options.UseFont = true;
            this.tkaagrid2.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.FocusedCell.Options.UseFont = true;
            this.tkaagrid2.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.FocusedRecord.Options.UseFont = true;
            this.tkaagrid2.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.FocusedRow.Options.UseFont = true;
            this.tkaagrid2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.tkaagrid2.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.HorzLine.Options.UseFont = true;
            this.tkaagrid2.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.tkaagrid2.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.ModifiedRow.Options.UseFont = true;
            this.tkaagrid2.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.PressedRow.Options.UseFont = true;
            this.tkaagrid2.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.tkaagrid2.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.tkaagrid2.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.RecordValue.Options.UseFont = true;
            this.tkaagrid2.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.tkaagrid2.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.SelectedCell.Options.UseFont = true;
            this.tkaagrid2.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.SelectedRecord.Options.UseFont = true;
            this.tkaagrid2.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.SelectedRow.Options.UseFont = true;
            this.tkaagrid2.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.tkaagrid2.Appearance.VertLine.Options.UseFont = true;
            this.tkaagrid2.FindPanelVisible = true;
            this.tkaagrid2.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.tkaagrid2.Location = new Point(0x43d, 0x21f);
            this.tkaagrid2.Name = "tkaagrid2";
            this.tkaagrid2.OptionsFind.FindNullPrompt = "tkaa";
            this.tkaagrid2.OptionsMenu.EnableContextMenu = true;
            this.tkaagrid2.Size = new Size(180, 200);
            this.tkaagrid2.TabIndex = 0x11;
            this.ttkbbgrid2.Appearance.BandBorder.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.BandBorder.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.Category.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.Category.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.CategoryExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.CategoryExpandButton.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.DisabledRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.DisabledRecordValue.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.DisabledRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.DisabledRow.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.Empty.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.Empty.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.ExpandButton.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.ExpandButton.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.FixedLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.FixedLine.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.FocusedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.FocusedCell.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.FocusedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.FocusedRecord.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.FocusedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.FocusedRow.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.HideSelectionRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.HorzLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.HorzLine.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.ModifiedRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.ModifiedRecordValue.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.ModifiedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.ModifiedRow.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.PressedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.PressedRow.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.ReadOnlyRecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.ReadOnlyRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.ReadOnlyRow.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.RecordValue.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.RecordValue.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.RowHeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.SelectedCell.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.SelectedCell.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.SelectedRecord.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.SelectedRecord.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.SelectedRow.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.SelectedRow.Options.UseFont = true;
            this.ttkbbgrid2.Appearance.VertLine.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.ttkbbgrid2.Appearance.VertLine.Options.UseFont = true;
            this.ttkbbgrid2.FindPanelVisible = true;
            this.ttkbbgrid2.LayoutStyle = LayoutViewStyle.SingleRecordView;
            this.ttkbbgrid2.Location = new Point(0x5bd, 0x220);
            this.ttkbbgrid2.Name = "ttkbbgrid2";
            this.ttkbbgrid2.OptionsFind.FindNullPrompt = "ttkbb uzun kesit";
            this.ttkbbgrid2.OptionsMenu.EnableContextMenu = true;
            this.ttkbbgrid2.Size = new Size(170, 0xbf);
            this.ttkbbgrid2.TabIndex = 0x12;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x66f, 0x2e7);
            base.Controls.Add(this.ttkbbgrid2);
            base.Controls.Add(this.tkaagrid2);
            base.Controls.Add(this.mdgrid2);
            base.Controls.Add(this.ttkaagrid2);
            base.Controls.Add(this.tkbbgrid2);
            base.Controls.Add(this.kdgrid2);
            base.Controls.Add(this.kkgrid2);
            base.Controls.Add(this.simpleButton2);
            base.Controls.Add(this.simpleButton1);
            base.Controls.Add(this.mdgrid);
            base.Controls.Add(this.ttkbbgrid);
            base.Controls.Add(this.tkaagrid);
            base.Controls.Add(this.ttkaagrid);
            base.Controls.Add(this.tkbbgrid);
            base.Controls.Add(this.kkgrid);
            base.Controls.Add(this.kdgrid);
            base.Name = "paramman";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "paramman";
            base.WindowState = FormWindowState.Minimized;
            base.Load += new EventHandler(this.paramman_Load);
            this.kkgrid.EndInit();
            this.kdgrid.EndInit();
            this.mdgrid.EndInit();
            this.tkaagrid.EndInit();
            this.tkbbgrid.EndInit();
            this.ttkaagrid.EndInit();
            this.ttkbbgrid.EndInit();
            this.kkgrid2.EndInit();
            this.mdgrid2.EndInit();
            this.ttkaagrid2.EndInit();
            this.tkbbgrid2.EndInit();
            this.kdgrid2.EndInit();
            this.tkaagrid2.EndInit();
            this.ttkbbgrid2.EndInit();
            base.ResumeLayout(false);
        }

        private bool ifrowvar(string rownam, string KesitKODU)
        {
            bool flag = false;
            if (rownam.StartsWith("PL2") || rownam.StartsWith("L2"))
            {
                if (KesitKODU == "KK")
                {
                    for (int i = 0; i < this.kkgrid2.Rows.Count; i++)
                    {
                        if (this.kkgrid2.Rows[i].Name == rownam)
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                if (KesitKODU == "KD")
                {
                    for (int j = 0; j < this.kdgrid2.Rows.Count; j++)
                    {
                        if (this.kdgrid2.Rows[j].Name == rownam)
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                if (KesitKODU == "MD")
                {
                    for (int k = 0; k < this.mdgrid2.Rows.Count; k++)
                    {
                        if (this.mdgrid2.Rows[k].Name == rownam)
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                if (KesitKODU == "TK-AA")
                {
                    for (int m = 0; m < this.tkaagrid2.Rows.Count; m++)
                    {
                        if (this.tkaagrid2.Rows[m].Name == rownam)
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                if (KesitKODU == "TK-BB")
                {
                    for (int n = 0; n < this.tkbbgrid2.Rows.Count; n++)
                    {
                        if (this.tkbbgrid2.Rows[n].Name == rownam)
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                if (KesitKODU == "TTK-AA")
                {
                    for (int num6 = 0; num6 < this.ttkaagrid2.Rows.Count; num6++)
                    {
                        if (this.ttkaagrid2.Rows[num6].Name == rownam)
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                if (KesitKODU == "TTK-BB")
                {
                    for (int num7 = 0; num7 < this.ttkbbgrid2.Rows.Count; num7++)
                    {
                        if (this.ttkbbgrid2.Rows[num7].Name == rownam)
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
                return flag;
            }
            if (KesitKODU == "KK")
            {
                for (int num8 = 0; num8 < this.kkgrid.Rows.Count; num8++)
                {
                    if (this.kkgrid.Rows[num8].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "KD")
            {
                for (int num9 = 0; num9 < this.kdgrid.Rows.Count; num9++)
                {
                    if (this.kdgrid.Rows[num9].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "MD")
            {
                for (int num10 = 0; num10 < this.mdgrid.Rows.Count; num10++)
                {
                    if (this.mdgrid.Rows[num10].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "TK-AA")
            {
                for (int num11 = 0; num11 < this.tkaagrid.Rows.Count; num11++)
                {
                    if (this.tkaagrid.Rows[num11].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "TK-BB")
            {
                for (int num12 = 0; num12 < this.tkbbgrid.Rows.Count; num12++)
                {
                    if (this.tkbbgrid.Rows[num12].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "TTK-AA")
            {
                for (int num13 = 0; num13 < this.ttkaagrid.Rows.Count; num13++)
                {
                    if (this.ttkaagrid.Rows[num13].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "TTK-BB")
            {
                for (int num14 = 0; num14 < this.ttkbbgrid.Rows.Count; num14++)
                {
                    if (this.ttkbbgrid.Rows[num14].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
            return flag;
        }

        private bool ifrowvar2(string rownam, string KesitKODU)
        {
            bool flag = false;
            if (KesitKODU == "KK")
            {
                for (int i = 0; i < this.kkgrid2.Rows.Count; i++)
                {
                    if (this.kkgrid2.Rows[i].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "KD")
            {
                for (int j = 0; j < this.kdgrid2.Rows.Count; j++)
                {
                    if (this.kdgrid2.Rows[j].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "MD")
            {
                for (int k = 0; k < this.mdgrid2.Rows.Count; k++)
                {
                    if (this.mdgrid2.Rows[k].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "TK-AA")
            {
                for (int m = 0; m < this.tkaagrid2.Rows.Count; m++)
                {
                    if (this.tkaagrid2.Rows[m].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "TK-BB")
            {
                for (int n = 0; n < this.tkbbgrid2.Rows.Count; n++)
                {
                    if (this.tkbbgrid2.Rows[n].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "TTK-AA")
            {
                for (int num6 = 0; num6 < this.ttkaagrid2.Rows.Count; num6++)
                {
                    if (this.ttkaagrid2.Rows[num6].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            if (KesitKODU == "TTK-BB")
            {
                for (int num7 = 0; num7 < this.ttkbbgrid2.Rows.Count; num7++)
                {
                    if (this.ttkbbgrid2.Rows[num7].Name == rownam)
                    {
                        return true;
                    }
                }
                return flag;
            }
            Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
            return flag;
        }

        private void kkgrid2_Click(object sender, EventArgs e)
        {
        }

        public void NewParam(string vtParName, string newValue, string KesitKODU)
        {
            try
            {
                if (!this.ifrowvar(vtParName, KesitKODU))
                {
                    EditorRow row = new EditorRow(vtParName) {
                        Properties = { 
                            Caption = vtParName,
                            UnboundType = UnboundColumnType.Integer,
                            UnboundExpression = newValue,
                            ShowUnboundExpressionMenu = true
                        },
                        Name = vtParName
                    };
                    if (KesitKODU == "KK")
                    {
                        this.kkgrid.Rows.Add(row);
                        this.lstedi.Add(row);
                    }
                    else if (KesitKODU == "KD")
                    {
                        this.kdgrid.Rows.Add(row);
                    }
                    else if (KesitKODU == "MD")
                    {
                        this.mdgrid.Rows.Add(row);
                    }
                    else if (KesitKODU == "TK-AA")
                    {
                        this.tkaagrid.Rows.Add(row);
                    }
                    else if (KesitKODU == "TK-BB")
                    {
                        this.tkbbgrid.Rows.Add(row);
                    }
                    else if (KesitKODU == "TTK-AA")
                    {
                        this.ttkaagrid.Rows.Add(row);
                    }
                    else if (KesitKODU == "TTK-BB")
                    {
                        this.ttkbbgrid.Rows.Add(row);
                    }
                    else
                    {
                        Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
                    }
                }
                else
                {
                    Debug.WriteLine("ROW VAR -> " + vtParName);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ROW VAR -> CATCH" + vtParName + " " + exception.ToString());
            }
        }

        public void NewParam2(string vtParName, string newValue, string KesitKODU)
        {
            try
            {
                if (!this.ifrowvar2(vtParName, KesitKODU))
                {
                    EditorRow row = new EditorRow(vtParName) {
                        Properties = { 
                            Caption = vtParName,
                            UnboundType = UnboundColumnType.Object,
                            UnboundExpression = newValue,
                            ShowUnboundExpressionMenu = true
                        },
                        Name = vtParName
                    };
                    if (KesitKODU == "KK")
                    {
                        this.kkgrid2.Rows.Add(row);
                        this.lstedi2.Add(row);
                    }
                    else if (KesitKODU == "KD")
                    {
                        this.kdgrid2.Rows.Add(row);
                    }
                    else if (KesitKODU == "MD")
                    {
                        this.mdgrid2.Rows.Add(row);
                    }
                    else if (KesitKODU == "TK-AA")
                    {
                        this.tkaagrid2.Rows.Add(row);
                    }
                    else if (KesitKODU == "TK-BB")
                    {
                        this.tkbbgrid2.Rows.Add(row);
                    }
                    else if (KesitKODU == "TTK-AA")
                    {
                        this.ttkaagrid2.Rows.Add(row);
                    }
                    else if (KesitKODU == "TTK-BB")
                    {
                        this.ttkbbgrid2.Rows.Add(row);
                    }
                    else
                    {
                        Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
                    }
                }
                else
                {
                    Debug.WriteLine("ROW2 VAR2 -> " + vtParName);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ROW2 VAR2 -> CATCH" + vtParName + " " + exception.ToString());
            }
        }

        private void paramman_Load(object sender, EventArgs e)
        {
        }

        public void RenameParam(string vtParName, string newName, string KesitKODU)
        {
            try
            {
                if (this.ifrowvar(vtParName, KesitKODU))
                {
                    if (KesitKODU == "KK")
                    {
                        this.kkgrid.Rows[vtParName].Properties.Caption = newName;
                        this.kkgrid.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "KD")
                    {
                        this.kdgrid.Rows[vtParName].Properties.Caption = newName;
                        this.kdgrid.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "MD")
                    {
                        this.mdgrid.Rows[vtParName].Properties.Caption = newName;
                        this.mdgrid.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "TK-AA")
                    {
                        this.tkaagrid.Rows[vtParName].Properties.Caption = newName;
                        this.tkaagrid.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "TK-BB")
                    {
                        this.tkbbgrid.Rows[vtParName].Properties.Caption = newName;
                        this.tkbbgrid.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "TTK-AA")
                    {
                        this.ttkaagrid.Rows[vtParName].Properties.Caption = newName;
                        this.ttkaagrid.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "TTK-BB")
                    {
                        this.ttkbbgrid.Rows[vtParName].Properties.Caption = newName;
                        this.ttkbbgrid.Rows[vtParName].Name = newName;
                    }
                    else
                    {
                        Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("RENAME KISMI ->" + vtParName + " - " + newName + exception.ToString());
            }
        }

        public void RenameParam2(string vtParName, string newName, string KesitKODU)
        {
            try
            {
                if (this.ifrowvar2(vtParName, KesitKODU))
                {
                    if (KesitKODU == "KK")
                    {
                        this.kkgrid2.Rows[vtParName].Properties.Caption = newName;
                        this.kkgrid2.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "KD")
                    {
                        this.kdgrid2.Rows[vtParName].Properties.Caption = newName;
                        this.kdgrid2.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "MD")
                    {
                        this.mdgrid2.Rows[vtParName].Properties.Caption = newName;
                        this.mdgrid2.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "TK-AA")
                    {
                        this.tkaagrid2.Rows[vtParName].Properties.Caption = newName;
                        this.tkaagrid2.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "TK-BB")
                    {
                        this.tkbbgrid2.Rows[vtParName].Properties.Caption = newName;
                        this.tkbbgrid2.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "TTK-AA")
                    {
                        this.ttkaagrid2.Rows[vtParName].Properties.Caption = newName;
                        this.ttkaagrid2.Rows[vtParName].Name = newName;
                    }
                    else if (KesitKODU == "TTK-BB")
                    {
                        this.ttkbbgrid2.Rows[vtParName].Properties.Caption = newName;
                        this.ttkbbgrid2.Rows[vtParName].Name = newName;
                    }
                    else
                    {
                        Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("RENAME KISMI ->" + vtParName + " - " + newName + exception.ToString());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.araformda(this.kkgrid.GetCellValue(this.kkgrid.Rows[0], 0).ToString());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lstedi.Count; i++)
            {
                this.lstedi[i].Visible = true;
            }
        }

        private void vGridControl1_MouseClick(object sender, EventArgs e)
        {
            try
            {
                if (e > null)
                {
                    MouseEventArgs args = e as MouseEventArgs;
                    VGridHitInfo info = this.kkgrid.CalcHitInfo(args.Location);
                    if (info.HitInfoType == HitInfoTypeEnum.HeaderCell)
                    {
                        MessageBox.Show(info.Row.Name);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void vGridControl1_UnboundExpressionEditorCreated(object sender, UnboundExpressionEditorEventArgs e)
        {
            this.hangideger = e.Properties.Caption;
            e.ExpressionEditorForm.FormClosing += new FormClosingEventHandler(this.ExpressionEditorForm_FormClosing);
        }
    }
}

