using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ascad
{
	public class tsestandart : Form
	{
		private abc1 xx = new abc1();

		public string kabingenstr;

		public string kabinderstr;

		private IContainer components = null;

		private LayoutControl layoutControl1;

		private LayoutControlGroup layoutControlGroup1;

		private GridControl gridcontroltsecizelge;

		private GridView gridviewtsecizelge;

		private GridColumn gridColumn1;

		private GridColumn gridColumn2;

		private GridColumn gridColumn3;

		private GridColumn gridColumn4;

		private GridColumn gridColumn5;

		private TextEdit kabinalan;

		private LayoutControlItem labeltsekabingen;

		private LayoutControlItem labeltsekabinder;

		private LayoutControlItem labeltsekabinalan;

		private LayoutControlItem layoutControlItem5;

		private LabelControl labeltsem2;

		private LabelControl labeltsemm2;

		private LabelControl labeltsemm;

		private LayoutControlItem layoutControlItem6;

		private LabelControl labeltsecizelge8;

		private LabelControl labeltsecizelge6;

		private LayoutControlItem layoutControlItem1;

		private LayoutControlItem layoutControlItem3;

		private LayoutControlItem layoutControlItem4;

		private LayoutControlItem layoutControlItem7;

		private Label label1;

		private LayoutControlItem layoutControlItem8;

		private SimpleButton simpleButton1;

		private LayoutControlItem layoutControlItem2;

		private TextEdit kabinder;

		private TextEdit kabingen;

		public tsestandart()
		{
			this.InitializeComponent();
		}

		private void tsestandart_Load(object sender, EventArgs e)
		{
			try
			{
				decimal num = 0m;
				decimal d = 0m;
				decimal d2 = 0m;
				d2 = Convert.ToDecimal(this.kabingenstr);
				d = Convert.ToDecimal(this.kabinderstr);
				num = decimal.Round(d2 * d / 1000000m, 2);
				this.kabinalan.Text = string.Format("{0:#.00#}", num);
				this.gridcontroltsecizelge.set_DataSource(this.xx.dtta("select *  from cizelge", ""));
				this.gridviewtsecizelge.get_FormatRules().Clear();
				GridFormatRule gridFormatRule = new GridFormatRule();
				FormatConditionRuleExpression formatConditionRuleExpression = new FormatConditionRuleExpression();
				formatConditionRuleExpression.get_Appearance().set_BackColor(Color.FromArgb(128, 255, 128));
				gridFormatRule.set_ApplyToRow(true);
				string text = num.ToString().Replace(",", ".");
				formatConditionRuleExpression.set_Expression(string.Concat(new string[]
				{
					"[cizelge8] <=",
					text,
					" And ",
					text,
					" <= [cizelge6]"
				}));
				gridFormatRule.set_Rule(formatConditionRuleExpression);
				this.gridviewtsecizelge.get_FormatRules().Add(gridFormatRule);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			this.kabingen.Text = this.kabingenstr;
			this.kabinder.Text = this.kabinderstr;
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			try
			{
				decimal num = 0m;
				decimal d = 0m;
				decimal d2 = 0m;
				bool flag = this.kabingen.Text != "" && this.kabinder.Text != "";
				if (flag)
				{
					d2 = Convert.ToDecimal(this.kabingen.Text);
					d = Convert.ToDecimal(this.kabinder.Text);
					num = decimal.Round(d2 * d / 1000000m, 2);
					this.kabinalan.Text = string.Format("{0:#.00#}", num);
				}
				this.gridviewtsecizelge.get_FormatRules().Clear();
				GridFormatRule gridFormatRule = new GridFormatRule();
				FormatConditionRuleExpression formatConditionRuleExpression = new FormatConditionRuleExpression();
				formatConditionRuleExpression.get_Appearance().set_BackColor(Color.FromArgb(128, 255, 128));
				gridFormatRule.set_ApplyToRow(true);
				string text = num.ToString().Replace(",", ".");
				formatConditionRuleExpression.set_Expression(string.Concat(new string[]
				{
					"[cizelge8] <=",
					text,
					" And ",
					text,
					" <= [cizelge6]"
				}));
				gridFormatRule.set_Rule(formatConditionRuleExpression);
				this.gridviewtsecizelge.get_FormatRules().Add(gridFormatRule);
			}
			catch (Exception)
			{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(tsestandart));
			this.gridColumn4 = new GridColumn();
			this.gridColumn3 = new GridColumn();
			this.gridColumn5 = new GridColumn();
			this.layoutControl1 = new LayoutControl();
			this.simpleButton1 = new SimpleButton();
			this.label1 = new Label();
			this.labeltsecizelge6 = new LabelControl();
			this.labeltsem2 = new LabelControl();
			this.labeltsemm2 = new LabelControl();
			this.labeltsecizelge8 = new LabelControl();
			this.labeltsemm = new LabelControl();
			this.gridcontroltsecizelge = new GridControl();
			this.gridviewtsecizelge = new GridView();
			this.gridColumn1 = new GridColumn();
			this.gridColumn2 = new GridColumn();
			this.kabinalan = new TextEdit();
			this.kabinder = new TextEdit();
			this.kabingen = new TextEdit();
			this.layoutControlGroup1 = new LayoutControlGroup();
			this.labeltsekabingen = new LayoutControlItem();
			this.layoutControlItem5 = new LayoutControlItem();
			this.layoutControlItem6 = new LayoutControlItem();
			this.layoutControlItem1 = new LayoutControlItem();
			this.layoutControlItem3 = new LayoutControlItem();
			this.labeltsekabinder = new LayoutControlItem();
			this.layoutControlItem4 = new LayoutControlItem();
			this.labeltsekabinalan = new LayoutControlItem();
			this.layoutControlItem7 = new LayoutControlItem();
			this.layoutControlItem8 = new LayoutControlItem();
			this.layoutControlItem2 = new LayoutControlItem();
			this.layoutControl1.BeginInit();
			this.layoutControl1.SuspendLayout();
			this.gridcontroltsecizelge.BeginInit();
			this.gridviewtsecizelge.BeginInit();
			this.kabinalan.get_Properties().BeginInit();
			this.kabinder.get_Properties().BeginInit();
			this.kabingen.get_Properties().BeginInit();
			this.layoutControlGroup1.BeginInit();
			this.labeltsekabingen.BeginInit();
			this.layoutControlItem5.BeginInit();
			this.layoutControlItem6.BeginInit();
			this.layoutControlItem1.BeginInit();
			this.layoutControlItem3.BeginInit();
			this.labeltsekabinder.BeginInit();
			this.layoutControlItem4.BeginInit();
			this.labeltsekabinalan.BeginInit();
			this.layoutControlItem7.BeginInit();
			this.layoutControlItem8.BeginInit();
			this.layoutControlItem2.BeginInit();
			base.SuspendLayout();
			this.gridColumn4.get_AppearanceCell().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridColumn4.get_AppearanceCell().get_Options().set_UseFont(true);
			this.gridColumn4.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn4.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn4.get_AppearanceHeader().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.gridColumn4.get_AppearanceHeader().set_ForeColor(Color.Maroon);
			this.gridColumn4.get_AppearanceHeader().get_Options().set_UseFont(true);
			this.gridColumn4.get_AppearanceHeader().get_Options().set_UseForeColor(true);
			this.gridColumn4.get_AppearanceHeader().get_Options().set_UseTextOptions(true);
			this.gridColumn4.get_AppearanceHeader().get_TextOptions().set_HAlignment(2);
			this.gridColumn4.set_Caption("Çizelge 6");
			this.gridColumn4.get_DisplayFormat().set_FormatString("N2");
			this.gridColumn4.get_DisplayFormat().set_FormatType(1);
			this.gridColumn4.set_FieldName("cizelge6");
			this.gridColumn4.set_Name("gridColumn4");
			this.gridColumn4.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn4.set_UnboundType(2);
			this.gridColumn4.set_Visible(true);
			this.gridColumn4.set_VisibleIndex(3);
			this.gridColumn4.set_Width(155);
			this.gridColumn3.get_AppearanceCell().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridColumn3.get_AppearanceCell().get_Options().set_UseFont(true);
			this.gridColumn3.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn3.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn3.get_AppearanceHeader().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.gridColumn3.get_AppearanceHeader().set_ForeColor(Color.Maroon);
			this.gridColumn3.get_AppearanceHeader().get_Options().set_UseFont(true);
			this.gridColumn3.get_AppearanceHeader().get_Options().set_UseForeColor(true);
			this.gridColumn3.get_AppearanceHeader().get_Options().set_UseTextOptions(true);
			this.gridColumn3.get_AppearanceHeader().get_TextOptions().set_HAlignment(2);
			this.gridColumn3.set_Caption("Çizelge 8");
			this.gridColumn3.get_DisplayFormat().set_FormatString("N2");
			this.gridColumn3.get_DisplayFormat().set_FormatType(1);
			this.gridColumn3.set_FieldName("cizelge8");
			this.gridColumn3.set_Name("gridColumn3");
			this.gridColumn3.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn3.set_UnboundType(2);
			this.gridColumn3.set_Visible(true);
			this.gridColumn3.set_VisibleIndex(2);
			this.gridColumn3.set_Width(216);
			this.gridColumn5.get_AppearanceCell().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridColumn5.get_AppearanceCell().get_Options().set_UseFont(true);
			this.gridColumn5.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn5.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn5.get_AppearanceHeader().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.gridColumn5.get_AppearanceHeader().set_ForeColor(Color.Maroon);
			this.gridColumn5.get_AppearanceHeader().get_Options().set_UseFont(true);
			this.gridColumn5.get_AppearanceHeader().get_Options().set_UseForeColor(true);
			this.gridColumn5.get_AppearanceHeader().get_Options().set_UseTextOptions(true);
			this.gridColumn5.get_AppearanceHeader().get_TextOptions().set_HAlignment(2);
			this.gridColumn5.set_Caption("Çizelge 7");
			this.gridColumn5.get_DisplayFormat().set_FormatString("N2");
			this.gridColumn5.get_DisplayFormat().set_FormatType(1);
			this.gridColumn5.set_FieldName("cizelge7");
			this.gridColumn5.set_Name("gridColumn5");
			this.gridColumn5.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn5.set_UnboundType(2);
			this.gridColumn5.set_Width(147);
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.label1);
			this.layoutControl1.Controls.Add(this.labeltsecizelge6);
			this.layoutControl1.Controls.Add(this.labeltsem2);
			this.layoutControl1.Controls.Add(this.labeltsemm2);
			this.layoutControl1.Controls.Add(this.labeltsecizelge8);
			this.layoutControl1.Controls.Add(this.labeltsemm);
			this.layoutControl1.Controls.Add(this.gridcontroltsecizelge);
			this.layoutControl1.Controls.Add(this.kabinalan);
			this.layoutControl1.Controls.Add(this.kabinder);
			this.layoutControl1.Controls.Add(this.kabingen);
			this.layoutControl1.Dock = DockStyle.Fill;
			this.layoutControl1.Location = new Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.set_Root(this.layoutControlGroup1);
			this.layoutControl1.Size = new Size(722, 553);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			this.simpleButton1.Location = new Point(616, 7);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(99, 22);
			this.simpleButton1.set_StyleController(this.layoutControl1);
			this.simpleButton1.TabIndex = 19;
			this.simpleButton1.Text = "YENİDEN HESAPLA";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.label1.FlatStyle = FlatStyle.System;
			this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162);
			this.label1.Location = new Point(7, 508);
			this.label1.Name = "label1";
			this.label1.Size = new Size(708, 20);
			this.label1.TabIndex = 18;
			this.label1.Text = componentResourceManager.GetString("label1.Text");
			this.labeltsecizelge6.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeltsecizelge6.get_Appearance().get_TextOptions().set_WordWrap(2);
			this.labeltsecizelge6.set_AutoSizeMode(1);
			this.labeltsecizelge6.Location = new Point(7, 490);
			this.labeltsecizelge6.Name = "labeltsecizelge6";
			this.labeltsecizelge6.Size = new Size(708, 14);
			this.labeltsecizelge6.set_StyleController(this.layoutControl1);
			this.labeltsecizelge6.TabIndex = 15;
			this.labeltsecizelge6.Text = "Çizelge 6 : Beyan yükü ve kabinin azami kullanılabilir (net) alanı belirtir (2500 kg sonrasında, her bir ilave 100 kg için 0,16 m2 eklenir.)";
			this.labeltsem2.get_Appearance().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeltsem2.set_AutoSizeMode(1);
			this.labeltsem2.Location = new Point(591, 7);
			this.labeltsem2.Name = "labeltsem2";
			this.labeltsem2.Size = new Size(21, 13);
			this.labeltsem2.set_StyleController(this.layoutControl1);
			this.labeltsem2.TabIndex = 11;
			this.labeltsem2.Text = "m2";
			this.labeltsemm2.get_Appearance().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeltsemm2.set_AutoSizeMode(1);
			this.labeltsemm2.Location = new Point(183, 7);
			this.labeltsemm2.Name = "labeltsemm2";
			this.labeltsemm2.Size = new Size(30, 13);
			this.labeltsemm2.set_StyleController(this.layoutControl1);
			this.labeltsemm2.TabIndex = 10;
			this.labeltsemm2.Text = "mm";
			this.labeltsecizelge8.get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeltsecizelge8.get_Appearance().get_TextOptions().set_WordWrap(2);
			this.labeltsecizelge8.set_AutoSizeMode(1);
			this.labeltsecizelge8.Location = new Point(7, 532);
			this.labeltsecizelge8.Name = "labeltsecizelge8";
			this.labeltsecizelge8.Size = new Size(708, 14);
			this.labeltsecizelge8.set_StyleController(this.layoutControl1);
			this.labeltsecizelge8.TabIndex = 16;
			this.labeltsecizelge8.Text = "Çizelge 8 : İnsan sayıları ve kabinin asgari kullanılabilir alanı (20 insandan sonra, her bir insan için 0,115 m2 ilave edilir.)";
			this.labeltsemm.get_Appearance().set_Font(new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeltsemm.set_AutoSizeMode(1);
			this.labeltsemm.Location = new Point(405, 7);
			this.labeltsemm.Name = "labeltsemm";
			this.labeltsemm.Size = new Size(26, 20);
			this.labeltsemm.set_StyleController(this.layoutControl1);
			this.labeltsemm.TabIndex = 9;
			this.labeltsemm.Text = "mm";
			this.gridcontroltsecizelge.Location = new Point(7, 43);
			this.gridcontroltsecizelge.set_MainView(this.gridviewtsecizelge);
			this.gridcontroltsecizelge.Name = "gridcontroltsecizelge";
			this.gridcontroltsecizelge.Size = new Size(708, 443);
			this.gridcontroltsecizelge.TabIndex = 8;
			this.gridcontroltsecizelge.get_ViewCollection().AddRange(new BaseView[]
			{
				this.gridviewtsecizelge
			});
			this.gridviewtsecizelge.get_Appearance().get_ColumnFilterButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_ColumnFilterButton().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_ColumnFilterButtonActive().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_ColumnFilterButtonActive().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_CustomizationFormHint().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_CustomizationFormHint().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_DetailTip().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_DetailTip().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_EvenRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_EvenRow().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_FilterCloseButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_FilterCloseButton().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_FilterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_FilterPanel().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_FooterPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_FooterPanel().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_GroupButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_GroupButton().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_GroupFooter().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_GroupFooter().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_GroupPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_GroupPanel().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_GroupRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_GroupRow().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_HeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_HeaderPanel().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_OddRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_OddRow().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_Preview().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_Preview().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_Row().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_Row().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_RowSeparator().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_RowSeparator().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_TopNewRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_TopNewRow().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Appearance().get_ViewCaption().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridviewtsecizelge.get_Appearance().get_ViewCaption().get_Options().set_UseFont(true);
			this.gridviewtsecizelge.get_Columns().AddRange(new GridColumn[]
			{
				this.gridColumn1,
				this.gridColumn2,
				this.gridColumn3,
				this.gridColumn4,
				this.gridColumn5
			});
			this.gridviewtsecizelge.set_GridControl(this.gridcontroltsecizelge);
			this.gridviewtsecizelge.set_Name("gridviewtsecizelge");
			this.gridviewtsecizelge.get_OptionsSelection().set_EnableAppearanceFocusedCell(false);
			this.gridviewtsecizelge.get_OptionsSelection().set_EnableAppearanceFocusedRow(false);
			this.gridviewtsecizelge.get_OptionsView().set_ShowGroupPanel(false);
			this.gridviewtsecizelge.get_OptionsView().set_ShowIndicator(false);
			this.gridColumn1.get_AppearanceCell().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridColumn1.get_AppearanceCell().get_Options().set_UseFont(true);
			this.gridColumn1.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn1.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn1.get_AppearanceHeader().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.gridColumn1.get_AppearanceHeader().set_ForeColor(Color.Maroon);
			this.gridColumn1.get_AppearanceHeader().get_Options().set_UseFont(true);
			this.gridColumn1.get_AppearanceHeader().get_Options().set_UseForeColor(true);
			this.gridColumn1.get_AppearanceHeader().get_Options().set_UseTextOptions(true);
			this.gridColumn1.get_AppearanceHeader().get_TextOptions().set_HAlignment(2);
			this.gridColumn1.set_Caption("Kişi Sayısı");
			this.gridColumn1.set_FieldName("kisisay");
			this.gridColumn1.set_Name("gridColumn1");
			this.gridColumn1.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn1.set_Visible(true);
			this.gridColumn1.set_VisibleIndex(0);
			this.gridColumn1.set_Width(92);
			this.gridColumn2.get_AppearanceCell().set_Font(new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.gridColumn2.get_AppearanceCell().get_Options().set_UseFont(true);
			this.gridColumn2.get_AppearanceCell().get_Options().set_UseTextOptions(true);
			this.gridColumn2.get_AppearanceCell().get_TextOptions().set_HAlignment(2);
			this.gridColumn2.get_AppearanceHeader().set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
			this.gridColumn2.get_AppearanceHeader().set_ForeColor(Color.Maroon);
			this.gridColumn2.get_AppearanceHeader().get_Options().set_UseFont(true);
			this.gridColumn2.get_AppearanceHeader().get_Options().set_UseForeColor(true);
			this.gridColumn2.get_AppearanceHeader().get_Options().set_UseTextOptions(true);
			this.gridColumn2.get_AppearanceHeader().get_TextOptions().set_HAlignment(2);
			this.gridColumn2.set_Caption("Beyan Yükü");
			this.gridColumn2.set_FieldName("beyanyuk");
			this.gridColumn2.set_Name("gridColumn2");
			this.gridColumn2.get_OptionsColumn().set_AllowEdit(false);
			this.gridColumn2.set_Visible(true);
			this.gridColumn2.set_VisibleIndex(1);
			this.gridColumn2.set_Width(96);
			this.kabinalan.Location = new Point(537, 7);
			this.kabinalan.Name = "kabinalan";
			this.kabinalan.get_Properties().get_Appearance().set_BackColor(SystemColors.Control);
			this.kabinalan.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kabinalan.get_Properties().get_Appearance().get_Options().set_UseBackColor(true);
			this.kabinalan.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kabinalan.get_Properties().get_Appearance().get_Options().set_UseTextOptions(true);
			this.kabinalan.get_Properties().get_Appearance().get_TextOptions().set_HAlignment(2);
			this.kabinalan.get_Properties().set_BorderStyle(0);
			this.kabinalan.get_Properties().set_ReadOnly(true);
			this.kabinalan.Size = new Size(50, 18);
			this.kabinalan.set_StyleController(this.layoutControl1);
			this.kabinalan.TabIndex = 6;
			this.kabinder.set_EnterMoveNextControl(true);
			this.kabinder.Location = new Point(319, 7);
			this.kabinder.Name = "kabinder";
			this.kabinder.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kabinder.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kabinder.Size = new Size(82, 20);
			this.kabinder.set_StyleController(this.layoutControl1);
			this.kabinder.TabIndex = 5;
			this.kabingen.set_EnterMoveNextControl(true);
			this.kabingen.Location = new Point(109, 7);
			this.kabingen.Name = "kabingen";
			this.kabingen.get_Properties().get_Appearance().set_Font(new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kabingen.get_Properties().get_Appearance().get_Options().set_UseFont(true);
			this.kabingen.Size = new Size(70, 20);
			this.kabingen.set_StyleController(this.layoutControl1);
			this.kabingen.TabIndex = 4;
			this.layoutControlGroup1.set_CustomizationFormText("layoutControlGroup1");
			this.layoutControlGroup1.set_EnableIndentsWithoutBorders(0);
			this.layoutControlGroup1.set_GroupBordersVisible(false);
			this.layoutControlGroup1.get_Items().AddRange(new BaseLayoutItem[]
			{
				this.labeltsekabingen,
				this.layoutControlItem5,
				this.layoutControlItem6,
				this.layoutControlItem1,
				this.layoutControlItem3,
				this.labeltsekabinder,
				this.layoutControlItem4,
				this.labeltsekabinalan,
				this.layoutControlItem7,
				this.layoutControlItem8,
				this.layoutControlItem2
			});
			this.layoutControlGroup1.set_Location(new Point(0, 0));
			this.layoutControlGroup1.set_Name("layoutControlGroup1");
			this.layoutControlGroup1.set_Padding(new Padding(5, 5, 5, 5));
			this.layoutControlGroup1.set_Size(new Size(722, 553));
			this.layoutControlGroup1.set_TextVisible(false);
			this.labeltsekabingen.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeltsekabingen.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labeltsekabingen.set_Control(this.kabingen);
			this.labeltsekabingen.set_CustomizationFormText("Kabin Genişliği : ");
			this.labeltsekabingen.set_Location(new Point(0, 0));
			this.labeltsekabingen.set_Name("labeltsekabingen");
			this.labeltsekabingen.set_Size(new Size(176, 26));
			this.labeltsekabingen.set_Text("Kabin Genişliği : ");
			this.labeltsekabingen.set_TextSize(new Size(99, 14));
			this.layoutControlItem5.set_Control(this.gridcontroltsecizelge);
			this.layoutControlItem5.set_CustomizationFormText("layoutControlItem5");
			this.layoutControlItem5.set_Location(new Point(0, 26));
			this.layoutControlItem5.set_Name("layoutControlItem5");
			this.layoutControlItem5.set_Size(new Size(712, 457));
			this.layoutControlItem5.set_Spacing(new Padding(0, 0, 10, 0));
			this.layoutControlItem5.set_TextSize(new Size(0, 0));
			this.layoutControlItem5.set_TextVisible(false);
			this.layoutControlItem6.set_Control(this.labeltsemm);
			this.layoutControlItem6.set_CustomizationFormText("layoutControlItem6");
			this.layoutControlItem6.set_Location(new Point(398, 0));
			this.layoutControlItem6.set_MaxSize(new Size(0, 24));
			this.layoutControlItem6.set_MinSize(new Size(15, 24));
			this.layoutControlItem6.set_Name("layoutControlItem6");
			this.layoutControlItem6.set_Size(new Size(30, 26));
			this.layoutControlItem6.set_SizeConstraintsType(2);
			this.layoutControlItem6.set_TextSize(new Size(0, 0));
			this.layoutControlItem6.set_TextVisible(false);
			this.layoutControlItem1.set_Control(this.labeltsecizelge6);
			this.layoutControlItem1.set_Location(new Point(0, 483));
			this.layoutControlItem1.set_Name("layoutControlItem1");
			this.layoutControlItem1.set_Size(new Size(712, 18));
			this.layoutControlItem1.set_TextSize(new Size(0, 0));
			this.layoutControlItem1.set_TextVisible(false);
			this.layoutControlItem3.set_Control(this.labeltsecizelge8);
			this.layoutControlItem3.set_Location(new Point(0, 525));
			this.layoutControlItem3.set_Name("layoutControlItem3");
			this.layoutControlItem3.set_Size(new Size(712, 18));
			this.layoutControlItem3.set_TextSize(new Size(0, 0));
			this.layoutControlItem3.set_TextVisible(false);
			this.labeltsekabinder.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeltsekabinder.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labeltsekabinder.set_Control(this.kabinder);
			this.labeltsekabinder.set_CustomizationFormText("Kabin Derinliği : ");
			this.labeltsekabinder.set_Location(new Point(210, 0));
			this.labeltsekabinder.set_Name("labeltsekabinder");
			this.labeltsekabinder.set_Size(new Size(188, 26));
			this.labeltsekabinder.set_Text("Kabin Derinliği : ");
			this.labeltsekabinder.set_TextSize(new Size(99, 14));
			this.layoutControlItem4.set_Control(this.labeltsemm2);
			this.layoutControlItem4.set_Location(new Point(176, 0));
			this.layoutControlItem4.set_Name("layoutControlItem4");
			this.layoutControlItem4.set_Size(new Size(34, 26));
			this.layoutControlItem4.set_TextSize(new Size(0, 0));
			this.layoutControlItem4.set_TextVisible(false);
			this.labeltsekabinalan.get_AppearanceItemCaption().set_Font(new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.labeltsekabinalan.get_AppearanceItemCaption().get_Options().set_UseFont(true);
			this.labeltsekabinalan.set_Control(this.kabinalan);
			this.labeltsekabinalan.set_CustomizationFormText("Kabin Alanı : ");
			this.labeltsekabinalan.set_Location(new Point(428, 0));
			this.labeltsekabinalan.set_Name("labeltsekabinalan");
			this.labeltsekabinalan.set_Size(new Size(156, 26));
			this.labeltsekabinalan.set_Text("Kabin Alanı : ");
			this.labeltsekabinalan.set_TextSize(new Size(99, 14));
			this.layoutControlItem7.set_Control(this.labeltsem2);
			this.layoutControlItem7.set_Location(new Point(584, 0));
			this.layoutControlItem7.set_Name("layoutControlItem7");
			this.layoutControlItem7.set_Size(new Size(25, 26));
			this.layoutControlItem7.set_TextSize(new Size(0, 0));
			this.layoutControlItem7.set_TextVisible(false);
			this.layoutControlItem8.set_Control(this.label1);
			this.layoutControlItem8.set_Location(new Point(0, 501));
			this.layoutControlItem8.set_Name("layoutControlItem8");
			this.layoutControlItem8.set_Size(new Size(712, 24));
			this.layoutControlItem8.set_TextSize(new Size(0, 0));
			this.layoutControlItem8.set_TextVisible(false);
			this.layoutControlItem2.set_Control(this.simpleButton1);
			this.layoutControlItem2.set_Location(new Point(609, 0));
			this.layoutControlItem2.set_Name("layoutControlItem2");
			this.layoutControlItem2.set_Size(new Size(103, 26));
			this.layoutControlItem2.set_TextSize(new Size(0, 0));
			this.layoutControlItem2.set_TextVisible(false);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(722, 553);
			base.Controls.Add(this.layoutControl1);
			this.MinimumSize = new Size(738, 533);
			base.Name = "tsestandart";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "TSE STANDARTLARI";
			base.Load += new EventHandler(this.tsestandart_Load);
			this.layoutControl1.EndInit();
			this.layoutControl1.ResumeLayout(false);
			this.gridcontroltsecizelge.EndInit();
			this.gridviewtsecizelge.EndInit();
			this.kabinalan.get_Properties().EndInit();
			this.kabinder.get_Properties().EndInit();
			this.kabingen.get_Properties().EndInit();
			this.layoutControlGroup1.EndInit();
			this.labeltsekabingen.EndInit();
			this.layoutControlItem5.EndInit();
			this.layoutControlItem6.EndInit();
			this.layoutControlItem1.EndInit();
			this.layoutControlItem3.EndInit();
			this.labeltsekabinder.EndInit();
			this.layoutControlItem4.EndInit();
			this.labeltsekabinalan.EndInit();
			this.layoutControlItem7.EndInit();
			this.layoutControlItem8.EndInit();
			this.layoutControlItem2.EndInit();
			base.ResumeLayout(false);
		}
	}
}
