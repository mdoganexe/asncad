namespace ascad
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraLayout;
    using NCalc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class hesaplamalar : Form
    {
        private IContainer components = null;
        private GridColumn gridColumn20;
        private GridColumn gridColumn21;
        private GridColumn gridColumn22;
        private GridColumn gridColumn23;
        private GridColumn gridColumn24;
        private GridColumn gridColumn25;
        private GridColumn gridColumn26;
        private GridColumn gridColumn27;
        private GridView gridView1;
        private DataTable hesap = new DataTable();
        private GridControl hesapgird;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private DataTable num = new DataTable();
        private Expression rr = new Expression("Kabinp + BeyanYuk");
        private SimpleButton simpleButton5;
        private abc1 xx = new abc1();

        public hesaplamalar()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void hesaplamalar_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            GridFormatRule rule = new GridFormatRule();
            FormatConditionRuleExpression expression = new FormatConditionRuleExpression();
            this.hesapgird = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn20 = new GridColumn();
            this.gridColumn21 = new GridColumn();
            this.gridColumn22 = new GridColumn();
            this.gridColumn23 = new GridColumn();
            this.gridColumn24 = new GridColumn();
            this.gridColumn25 = new GridColumn();
            this.gridColumn26 = new GridColumn();
            this.gridColumn27 = new GridColumn();
            this.simpleButton5 = new SimpleButton();
            this.layoutControl1 = new LayoutControl();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.hesapgird.BeginInit();
            this.gridView1.BeginInit();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem2.BeginInit();
            base.SuspendLayout();
            this.hesapgird.Location = new Point(12, 0x27);
            this.hesapgird.MainView = this.gridView1;
            this.hesapgird.Name = "hesapgird";
            this.hesapgird.Size = new Size(0x43e, 0x22f);
            this.hesapgird.TabIndex = 0x3f9;
            BaseView[] views = new BaseView[] { this.gridView1 };
            this.hesapgird.ViewCollection.AddRange(views);
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
            this.gridView1.Appearance.HeaderPanel.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
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
            GridColumn[] columns = new GridColumn[] { this.gridColumn20, this.gridColumn21, this.gridColumn22, this.gridColumn23, this.gridColumn24, this.gridColumn25, this.gridColumn26, this.gridColumn27 };
            this.gridView1.Columns.AddRange(columns);
            rule.ApplyToRow = true;
            rule.Name = "Format0";
            expression.Appearance.BackColor = Color.Red;
            expression.Appearance.Font = new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            expression.Appearance.Options.UseBackColor = true;
            expression.Appearance.Options.UseFont = true;
            expression.Expression = "[formulsonuc] = 'UD'";
            rule.Rule = expression;
            this.gridView1.FormatRules.Add(rule);
            this.gridView1.GridControl = this.hesapgird;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn20.Caption = "SNO";
            this.gridColumn20.FieldName = "sno";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            this.gridColumn20.Width = 0x2f;
            this.gridColumn21.Caption = "PARAMETRE";
            this.gridColumn21.FieldName = "paramet";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 1;
            this.gridColumn21.Width = 0x59;
            this.gridColumn22.Caption = "STANDART";
            this.gridColumn22.FieldName = "standatr";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 2;
            this.gridColumn22.Width = 0x59;
            this.gridColumn23.Caption = "A\x00c7IKLAMA";
            this.gridColumn23.FieldName = "aciklama";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 3;
            this.gridColumn23.Width = 0x7d;
            this.gridColumn24.Caption = "FORM\x00dcL";
            this.gridColumn24.FieldName = "formul";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 4;
            this.gridColumn24.Width = 0x53;
            this.gridColumn25.Caption = "FORM\x00dcL DEĞ.";
            this.gridColumn25.FieldName = "formuld";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 5;
            this.gridColumn25.Width = 0x53;
            this.gridColumn26.Caption = "FORMUL SONUC";
            this.gridColumn26.FieldName = "formulsonuc";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 6;
            this.gridColumn26.Width = 0x53;
            this.gridColumn27.Caption = "BİRİM";
            this.gridColumn27.FieldName = "birim";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 7;
            this.gridColumn27.Width = 0x53;
            this.simpleButton5.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.Location = new Point(12, 12);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new Size(0x43e, 0x17);
            this.simpleButton5.StyleController = this.layoutControl1;
            this.simpleButton5.TabIndex = 0x3f8;
            this.simpleButton5.Text = "HESAPLAMALARI YAP";
            this.simpleButton5.Click += new EventHandler(this.simpleButton5_Click);
            this.layoutControl1.Controls.Add(this.hesapgird);
            this.layoutControl1.Controls.Add(this.simpleButton5);
            this.layoutControl1.Dock = DockStyle.Fill;
            this.layoutControl1.Location = new Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x456, 610);
            this.layoutControl1.TabIndex = 0x3fa;
            this.layoutControl1.Text = "layoutControl1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            BaseLayoutItem[] items = new BaseLayoutItem[] { this.layoutControlItem1, this.layoutControlItem2 };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new Size(0x456, 610);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.Control = this.simpleButton5;
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x442, 0x1b);
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem2.Control = this.hesapgird;
            this.layoutControlItem2.Location = new Point(0, 0x1b);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x442, 0x233);
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x456, 610);
            base.Controls.Add(this.layoutControl1);
            base.Name = "hesaplamalar";
            this.Text = "hesaplamalar";
            base.Load += new EventHandler(this.hesaplamalar_Load);
            this.hesapgird.EndInit();
            this.gridView1.EndInit();
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem2.EndInit();
            base.ResumeLayout(false);
        }

        private void parekle(int ro)
        {
            if (this.hesap.Rows[ro]["vty"].ToString() == "d")
            {
                this.rr.Parameters.Add(this.hesap.Rows[ro]["paramet"].ToString(), Convert.ToDecimal(this.hesap.Rows[ro]["formulsonuc"]));
            }
            else if (this.hesap.Rows[ro]["vty"].ToString() == "s")
            {
                this.rr.Parameters.Add(this.hesap.Rows[ro]["paramet"].ToString(), Convert.ToString(this.hesap.Rows[ro]["formulsonuc"]));
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.rr.Parameters.Clear();
            this.hesap = this.xx.dtta("select * from hesaplama", "");
            this.num = this.xx.dtta("select ParamName,ParamValue from Num1", "");
            for (int i = 0; i < this.hesap.Rows.Count; i++)
            {
                string str = this.hesap.Rows[i]["standatr"].ToString();
                if (str == "GENEL")
                {
                    int num2 = 0;
                    try
                    {
                        do
                        {
                            num2++;
                        }
                        while (!string.Equals(this.num.Rows[num2]["ParamName"].ToString(), this.hesap.Rows[i]["paramet"].ToString()));
                        this.hesap.Rows[i]["formulsonuc"] = this.num.Rows[num2]["ParamValue"].ToString();
                        this.parekle(i);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(string.Concat(new object[] { exception.Message, " ", num2, " ", this.hesap.Rows[i]["paramet"].ToString() }));
                    }
                }
                else if (str == "GENELFRM")
                {
                    Expression expression = new Expression(this.hesap.Rows[i]["formul"].ToString()) {
                        Parameters = this.rr.Parameters
                    };
                    expression.Evaluate();
                    string str2 = expression.ParsedExpression.ToString();
                    Dictionary<string, object> parameters = expression.Parameters;
                    foreach (KeyValuePair<string, object> pair in parameters)
                    {
                        string oldValue = "([" + pair.Key + "])";
                        str2 = str2.Replace(oldValue, pair.Value.ToString());
                    }
                    this.hesap.Rows[i]["formuld"] = str2;
                    this.hesap.Rows[i]["formulsonuc"] = expression.Evaluate().ToString();
                    this.parekle(i);
                }
                else if (str.Contains("-"))
                {
                    char[] separator = new char[] { '-' };
                    string[] srg = str.Split(separator);
                    string[] textArray1 = new string[] { "select ", this.hesap.Rows[i]["paramet"].ToString(), " from ", srg[0], "master where ", srg[1], " = ", this.rr.Parameters.First<KeyValuePair<string, object>>(x => string.Equals(x.Key, srg[0] + srg[1], StringComparison.OrdinalIgnoreCase)).Value.ToString() };
                    string negeldi = string.Concat(textArray1);
                    this.hesap.Rows[i]["formulsonuc"] = this.xx.dtta(negeldi, "").Rows[0][0].ToString();
                    this.parekle(i);
                }
                else if (str == "SORG")
                {
                    Expression expression2 = new Expression("if (" + this.hesap.Rows[i]["formul"].ToString() + ", 'UY', 'UD')") {
                        Parameters = this.rr.Parameters
                    };
                    expression2.Evaluate();
                    string str4 = expression2.ParsedExpression.ToString();
                    Dictionary<string, object> dictionary2 = expression2.Parameters;
                    foreach (KeyValuePair<string, object> pair3 in dictionary2)
                    {
                        string introduced28 = "([" + pair3.Key + "])";
                        str4 = str4.Replace(introduced28, pair3.Value.ToString());
                    }
                    str4 = str4.Replace("if(", "").Replace(", 'UY', 'UD')", "");
                    this.hesap.Rows[i]["formuld"] = str4;
                    this.hesap.Rows[i]["formulsonuc"] = expression2.Evaluate().ToString();
                }
            }
            this.hesapgird.DataSource = this.hesap;
            this.gridView1.BestFitColumns();
        }
    }
}

