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

namespace ascad
{
	public class hesaplamalar : Form
	{
		private abc1 xx = new abc1();

		private Expression rr = new Expression("Kabinp + BeyanYuk");

		private DataTable num = new DataTable();

		private DataTable hesap = new DataTable();

		private IContainer components = null;

		private GridControl hesapgird;

		private GridView gridView1;

		private GridColumn gridColumn20;

		private GridColumn gridColumn21;

		private GridColumn gridColumn22;

		private GridColumn gridColumn23;

		private GridColumn gridColumn24;

		private GridColumn gridColumn25;

		private GridColumn gridColumn26;

		private GridColumn gridColumn27;

		private SimpleButton simpleButton5;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem2;

		public hesaplamalar()
		{
			this.InitializeComponent();
		}

		private void hesaplamalar_Load(object sender, EventArgs e)
		{
		}

		private void simpleButton5_Click(object sender, EventArgs e)
		{
			this.rr.get_Parameters().Clear();
			this.hesap = this.xx.dtta("select * from hesaplama", "");
			this.num = this.xx.dtta("select ParamName,ParamValue from Num1", "");
			for (int i = 0; i < this.hesap.Rows.Count; i++)
			{
				string text = this.hesap.Rows[i]["standatr"].ToString();
				bool flag = text == "GENEL";
				if (flag)
				{
					int num = 0;
					try
					{
						do
						{
							num++;
						}
						while (!string.Equals(this.num.Rows[num]["ParamName"].ToString(), this.hesap.Rows[i]["paramet"].ToString()));
						this.hesap.Rows[i]["formulsonuc"] = this.num.Rows[num]["ParamValue"].ToString();
						this.parekle(i);
					}
					catch (Exception ex)
					{
						MessageBox.Show(string.Concat(new object[]
						{
							ex.Message,
							" ",
							num,
							" ",
							this.hesap.Rows[i]["paramet"].ToString()
						}));
					}
				}
				else
				{
					bool flag2 = text == "GENELFRM";
					if (flag2)
					{
						Expression expression = new Expression(this.hesap.Rows[i]["formul"].ToString());
						expression.set_Parameters(this.rr.get_Parameters());
						expression.Evaluate();
						string text2 = expression.get_ParsedExpression().ToString();
						Dictionary<string, object> parameters = expression.get_Parameters();
						foreach (KeyValuePair<string, object> current in parameters)
						{
							text2 = text2.Replace("([" + current.Key + "])", current.Value.ToString());
						}
						this.hesap.Rows[i]["formuld"] = text2;
						this.hesap.Rows[i]["formulsonuc"] = expression.Evaluate().ToString();
						this.parekle(i);
					}
					else
					{
						bool flag3 = text.Contains("-");
						if (flag3)
						{
							string[] srg = text.Split(new char[]
							{
								'-'
							});
							string negeldi = string.Concat(new string[]
							{
								"select ",
								this.hesap.Rows[i]["paramet"].ToString(),
								" from ",
								srg[0],
								"master where ",
								srg[1],
								" = ",
								this.rr.get_Parameters().First((KeyValuePair<string, object> x) => string.Equals(x.Key, srg[0] + srg[1], StringComparison.OrdinalIgnoreCase)).Value.ToString()
							});
							this.hesap.Rows[i]["formulsonuc"] = this.xx.dtta(negeldi, "").Rows[0][0].ToString();
							this.parekle(i);
						}
						else
						{
							bool flag4 = text == "SORG";
							if (flag4)
							{
								Expression expression2 = new Expression("if (" + this.hesap.Rows[i]["formul"].ToString() + ", 'UY', 'UD')");
								expression2.set_Parameters(this.rr.get_Parameters());
								expression2.Evaluate();
								string text3 = expression2.get_ParsedExpression().ToString();
								Dictionary<string, object> parameters2 = expression2.get_Parameters();
								foreach (KeyValuePair<string, object> current2 in parameters2)
								{
									text3 = text3.Replace("([" + current2.Key + "])", current2.Value.ToString());
								}
								text3 = text3.Replace("if(", "");
								text3 = text3.Replace(", 'UY', 'UD')", "");
								this.hesap.Rows[i]["formuld"] = text3;
								this.hesap.Rows[i]["formulsonuc"] = expression2.Evaluate().ToString();
							}
						}
					}
				}
			}
			this.hesapgird.set_DataSource(this.hesap);
			this.gridView1.BestFitColumns();
		}

		private void parekle(int ro)
		{
			bool flag = this.hesap.Rows[ro]["vty"].ToString() == "d";
			if (flag)
			{
				this.rr.get_Parameters().Add(this.hesap.Rows[ro]["paramet"].ToString(), Convert.ToDecimal(this.hesap.Rows[ro]["formulsonuc"]));
			}
			else
			{
				bool flag2 = this.hesap.Rows[ro]["vty"].ToString() == "s";
				if (flag2)
				{
					this.rr.get_Parameters().Add(this.hesap.Rows[ro]["paramet"].ToString(), Convert.ToString(this.hesap.Rows[ro]["formulsonuc"]));
				}
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
			GridFormatRule gridFormatRule = new GridFormatRule();
			FormatConditionRuleExpression formatConditionRuleExpression = new FormatConditionRuleExpression();
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
			this.hesapgird.Location = new Point(12, 39);
			this.hesapgird.set_MainView(this.gridView1);
			this.hesapgird.Name = "hesapgird";
			this.hesapgird.Size = new Size(1086, 559);
			this.hesapgird.TabIndex = 1017;
			this.hesapgird.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridView1
			});
			this.gridView1.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_Row().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridView1.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridView1.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridView1.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn20,
				this.gridColumn21,
				this.gridColumn22,
				this.gridColumn23,
				this.gridColumn24,
				this.gridColumn25,
				this.gridColumn26,
				this.gridColumn27
			});
			gridFormatRule.set_ApplyToRow(true);
			gridFormatRule.set_Name("Format0");
			formatConditionRuleExpression.get_Appearance().set_BackColor(Color.Red);
			formatConditionRuleExpression.get_Appearance().set_Font(new Font("Tahoma", 10.2f, FontStyle.Bold, GraphicsUnit.Point, 162));
			formatConditionRuleExpression.get_Appearance().get_Options().set_UseBackColor(true);
			formatConditionRuleExpression.get_Appearance().get_Options().set_UseFont(true);
			formatConditionRuleExpression.set_Expression("[formulsonuc] = 'UD'");
			gridFormatRule.set_Rule(formatConditionRuleExpression);
			this.gridView1.get_FormatRules().Add(gridFormatRule);
			this.gridView1.set_GridControl(this.hesapgird);
			this.gridView1.set_Name("gridView1");
			this.gridView1.get_OptionsView().set_ShowAutoFilterRow(true);
			this.gridView1.get_OptionsView().set_ShowGroupPanel(false);
			this.gridColumn20.set_Caption("SNO");
			this.gridColumn20.set_FieldName("sno");
			this.gridColumn20.set_Name("gridColumn20");
			this.gridColumn20.set_Visible(true);
			this.gridColumn20.set_VisibleIndex(0);
			this.gridColumn20.set_Width(47);
			this.gridColumn21.set_Caption("PARAMETRE");
			this.gridColumn21.set_FieldName("paramet");
			this.gridColumn21.set_Name("gridColumn21");
			this.gridColumn21.set_Visible(true);
			this.gridColumn21.set_VisibleIndex(1);
			this.gridColumn21.set_Width(89);
			this.gridColumn22.set_Caption("STANDART");
			this.gridColumn22.set_FieldName("standatr");
			this.gridColumn22.set_Name("gridColumn22");
			this.gridColumn22.set_Visible(true);
			this.gridColumn22.set_VisibleIndex(2);
			this.gridColumn22.set_Width(89);
			this.gridColumn23.set_Caption("AÇIKLAMA");
			this.gridColumn23.set_FieldName("aciklama");
			this.gridColumn23.set_Name("gridColumn23");
			this.gridColumn23.set_Visible(true);
			this.gridColumn23.set_VisibleIndex(3);
			this.gridColumn23.set_Width(125);
			this.gridColumn24.set_Caption("FORMÜL");
			this.gridColumn24.set_FieldName("formul");
			this.gridColumn24.set_Name("gridColumn24");
			this.gridColumn24.set_Visible(true);
			this.gridColumn24.set_VisibleIndex(4);
			this.gridColumn24.set_Width(83);
			this.gridColumn25.set_Caption("FORMÜL DEĞ.");
			this.gridColumn25.set_FieldName("formuld");
			this.gridColumn25.set_Name("gridColumn25");
			this.gridColumn25.set_Visible(true);
			this.gridColumn25.set_VisibleIndex(5);
			this.gridColumn25.set_Width(83);
			this.gridColumn26.set_Caption("FORMUL SONUC");
			this.gridColumn26.set_FieldName("formulsonuc");
			this.gridColumn26.set_Name("gridColumn26");
			this.gridColumn26.set_Visible(true);
			this.gridColumn26.set_VisibleIndex(6);
			this.gridColumn26.set_Width(83);
			this.gridColumn27.set_Caption("BİRİM");
			this.gridColumn27.set_FieldName("birim");
			this.gridColumn27.set_Name("gridColumn27");
			this.gridColumn27.set_Visible(true);
			this.gridColumn27.set_VisibleIndex(7);
			this.gridColumn27.set_Width(83);
			this.simpleButton5.get_Appearance().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.simpleButton5.get_Appearance().get_Options().set_UseFont(true);
			this.simpleButton5.Location = new Point(12, 12);
			this.simpleButton5.Name = "simpleButton5";
			this.simpleButton5.Size = new Size(1086, 23);
			this.simpleButton5.set_StyleController(this.layoutControl1);
			this.simpleButton5.TabIndex = 1016;
			this.simpleButton5.Text = "HESAPLAMALARI YAP";
			this.simpleButton5.Click += new EventHandler(this.simpleButton5_Click);
			this.layoutControl1.Controls.Add(this.hesapgird);
			this.layoutControl1.Controls.Add(this.simpleButton5);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(1110, 610);
			this.layoutControl1.TabIndex = 1018;
			this.layoutControl1.Text = "layoutControl1";
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.layoutControlItem1,
				this.layoutControlItem2
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Size(new Size(1110, 610));
			this.layoutControlGroup1.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.simpleButton5);
			this.layoutControlItem1.set_Location(new Point(0, 0));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(1090, 27));
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem2.set_Control(this.hesapgird);
			this.layoutControlItem2.set_Location(new Point(0, 27));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(1090, 563));
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1110, 610);
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
	}
}
