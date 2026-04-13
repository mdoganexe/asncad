namespace ascad
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraLayout;
    using DevExpress.XtraLayout.Utils;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class motor : Form
    {
        private ComboBoxEdit comboBox2;
        private IContainer components = null;
        private int dis = 0;
        private string dosyayolu = "";
        private string edit = "";
        private string editcik = "";
        private string extension = "";
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem11;
        private LayoutControlItem layoutControlItem12;
        private LayoutControlItem layoutControlItem13;
        private LayoutControlItem layoutControlItem14;
        private LayoutControlItem layoutControlItem15;
        private LayoutControlItem layoutControlItem16;
        private LayoutControlItem layoutControlItem17;
        private LayoutControlItem layoutControlItem18;
        private LayoutControlItem layoutControlItem19;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem21;
        private LayoutControlItem layoutControlItem23;
        private LayoutControlItem layoutControlItem24;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem layoutControlItem9;
        public makmot mkmt;
        private bool nonNumberEntered = false;
        private OpenFileDialog openFileDialog1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton4;
        private TextEdit textEdit10;
        private TextEdit textEdit11;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;
        private TextEdit textEdit5;
        private TextEdit textEdit6;
        private TextEdit textEdit7;
        private TextEdit textEdit8;
        private TextEdit textEdit9;
        private abc1 xx = new abc1();

        public motor()
        {
            this.InitializeComponent();
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.layoutControl1 = new LayoutControl();
            this.simpleButton2 = new SimpleButton();
            this.comboBox2 = new ComboBoxEdit();
            this.textEdit11 = new TextEdit();
            this.simpleButton4 = new SimpleButton();
            this.radioButton2 = new RadioButton();
            this.radioButton1 = new RadioButton();
            this.labelControl4 = new LabelControl();
            this.textEdit10 = new TextEdit();
            this.textEdit9 = new TextEdit();
            this.labelControl3 = new LabelControl();
            this.textEdit8 = new TextEdit();
            this.labelControl2 = new LabelControl();
            this.textEdit3 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.textEdit7 = new TextEdit();
            this.textEdit6 = new TextEdit();
            this.textEdit5 = new TextEdit();
            this.textEdit4 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.labelControl1 = new LabelControl();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem1 = new LayoutControlItem();
            this.layoutControlItem3 = new LayoutControlItem();
            this.layoutControlItem5 = new LayoutControlItem();
            this.layoutControlItem6 = new LayoutControlItem();
            this.layoutControlItem7 = new LayoutControlItem();
            this.layoutControlItem8 = new LayoutControlItem();
            this.layoutControlItem9 = new LayoutControlItem();
            this.layoutControlItem11 = new LayoutControlItem();
            this.layoutControlItem12 = new LayoutControlItem();
            this.layoutControlItem13 = new LayoutControlItem();
            this.layoutControlItem14 = new LayoutControlItem();
            this.layoutControlItem15 = new LayoutControlItem();
            this.layoutControlItem16 = new LayoutControlItem();
            this.layoutControlItem18 = new LayoutControlItem();
            this.layoutControlItem17 = new LayoutControlItem();
            this.layoutControlItem19 = new LayoutControlItem();
            this.layoutControlItem23 = new LayoutControlItem();
            this.layoutControlItem24 = new LayoutControlItem();
            this.layoutControlItem4 = new LayoutControlItem();
            this.layoutControlItem2 = new LayoutControlItem();
            this.layoutControlItem21 = new LayoutControlItem();
            this.openFileDialog1 = new OpenFileDialog();
            this.layoutControl1.BeginInit();
            this.layoutControl1.SuspendLayout();
            this.comboBox2.Properties.BeginInit();
            this.textEdit11.Properties.BeginInit();
            this.textEdit10.Properties.BeginInit();
            this.textEdit9.Properties.BeginInit();
            this.textEdit8.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit7.Properties.BeginInit();
            this.textEdit6.Properties.BeginInit();
            this.textEdit5.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.layoutControlItem3.BeginInit();
            this.layoutControlItem5.BeginInit();
            this.layoutControlItem6.BeginInit();
            this.layoutControlItem7.BeginInit();
            this.layoutControlItem8.BeginInit();
            this.layoutControlItem9.BeginInit();
            this.layoutControlItem11.BeginInit();
            this.layoutControlItem12.BeginInit();
            this.layoutControlItem13.BeginInit();
            this.layoutControlItem14.BeginInit();
            this.layoutControlItem15.BeginInit();
            this.layoutControlItem16.BeginInit();
            this.layoutControlItem18.BeginInit();
            this.layoutControlItem17.BeginInit();
            this.layoutControlItem19.BeginInit();
            this.layoutControlItem23.BeginInit();
            this.layoutControlItem24.BeginInit();
            this.layoutControlItem4.BeginInit();
            this.layoutControlItem2.BeginInit();
            this.layoutControlItem21.BeginInit();
            base.SuspendLayout();
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.comboBox2);
            this.layoutControl1.Controls.Add(this.textEdit11);
            this.layoutControl1.Controls.Add(this.simpleButton4);
            this.layoutControl1.Controls.Add(this.radioButton2);
            this.layoutControl1.Controls.Add(this.radioButton1);
            this.layoutControl1.Controls.Add(this.labelControl4);
            this.layoutControl1.Controls.Add(this.textEdit10);
            this.layoutControl1.Controls.Add(this.textEdit9);
            this.layoutControl1.Controls.Add(this.labelControl3);
            this.layoutControl1.Controls.Add(this.textEdit8);
            this.layoutControl1.Controls.Add(this.labelControl2);
            this.layoutControl1.Controls.Add(this.textEdit3);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.textEdit7);
            this.layoutControl1.Controls.Add(this.textEdit6);
            this.layoutControl1.Controls.Add(this.textEdit5);
            this.layoutControl1.Controls.Add(this.textEdit4);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Dock = DockStyle.Fill;
            this.layoutControl1.Location = new Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new Size(0x18e, 0x19b);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.simpleButton2.Appearance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new Point(0xfc, 0x22);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x8a, 0x16);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 0x18;
            this.simpleButton2.Text = "YOKSA EKLEYİNİZ";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.comboBox2.EnterMoveNextControl = true;
            this.comboBox2.Location = new Point(0x62, 0x22);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.comboBox2.Properties.Appearance.Options.UseFont = true;
            EditorButton[] buttons = new EditorButton[] { new EditorButton(ButtonPredefines.Combo) };
            this.comboBox2.Properties.Buttons.AddRange(buttons);
            this.comboBox2.Size = new Size(150, 0x16);
            this.comboBox2.StyleController = this.layoutControl1;
            this.comboBox2.TabIndex = 0x17;
            this.comboBox2.KeyPress += new KeyPressEventHandler(this.comboBox2_KeyPress);
            this.textEdit11.EditValue = "0";
            this.textEdit11.EnterMoveNextControl = true;
            this.textEdit11.Location = new Point(0x62, 0x126);
            this.textEdit11.Name = "textEdit11";
            this.textEdit11.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit11.Properties.Appearance.Options.UseFont = true;
            this.textEdit11.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit11.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit11.RightToLeft = RightToLeft.No;
            this.textEdit11.Size = new Size(150, 0x16);
            this.textEdit11.StyleController = this.layoutControl1;
            this.textEdit11.TabIndex = 0x16;
            this.textEdit11.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit11.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.simpleButton4.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new Point(8, 0x15a);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new Size(0x17e, 0x1a);
            this.simpleButton4.StyleController = this.layoutControl1;
            this.simpleButton4.TabIndex = 0x15;
            this.simpleButton4.Text = "TEKNİK RESİM EKLE";
            this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
            this.radioButton2.Location = new Point(110, 320);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(280, 0x16);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "DİŞLİSİZ";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton1.Location = new Point(8, 320);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x62, 0x16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "DİŞLİLİ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
            this.labelControl4.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.labelControl4.Location = new Point(0xfc, 0x10c);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x8a, 0x16);
            this.labelControl4.StyleController = this.layoutControl1;
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "kg";
            this.textEdit10.EditValue = "0";
            this.textEdit10.EnterMoveNextControl = true;
            this.textEdit10.Location = new Point(0x62, 0x10c);
            this.textEdit10.Name = "textEdit10";
            this.textEdit10.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit10.Properties.Appearance.Options.UseFont = true;
            this.textEdit10.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit10.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit10.RightToLeft = RightToLeft.No;
            this.textEdit10.Size = new Size(150, 0x16);
            this.textEdit10.StyleController = this.layoutControl1;
            this.textEdit10.TabIndex = 0x12;
            this.textEdit10.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit10.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.textEdit9.EditValue = "0";
            this.textEdit9.EnterMoveNextControl = true;
            this.textEdit9.Location = new Point(0x62, 0xf2);
            this.textEdit9.Name = "textEdit9";
            this.textEdit9.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit9.Properties.Appearance.Options.UseFont = true;
            this.textEdit9.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit9.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit9.RightToLeft = RightToLeft.No;
            this.textEdit9.Size = new Size(150, 0x16);
            this.textEdit9.StyleController = this.layoutControl1;
            this.textEdit9.TabIndex = 0x11;
            this.textEdit9.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit9.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.labelControl3.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.labelControl3.Location = new Point(0xfc, 0xa4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x8a, 0x16);
            this.labelControl3.StyleController = this.layoutControl1;
            this.labelControl3.TabIndex = 0x10;
            this.labelControl3.Text = "mm";
            this.textEdit8.EditValue = "0";
            this.textEdit8.EnterMoveNextControl = true;
            this.textEdit8.Location = new Point(0x62, 0xa4);
            this.textEdit8.Name = "textEdit8";
            this.textEdit8.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit8.Properties.Appearance.Options.UseFont = true;
            this.textEdit8.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit8.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit8.RightToLeft = RightToLeft.No;
            this.textEdit8.Size = new Size(150, 0x16);
            this.textEdit8.StyleController = this.layoutControl1;
            this.textEdit8.TabIndex = 15;
            this.textEdit8.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit8.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.labelControl2.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.labelControl2.Location = new Point(0xfc, 0x56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x8a, 0x16);
            this.labelControl2.StyleController = this.layoutControl1;
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "kg";
            this.textEdit3.EditValue = "0";
            this.textEdit3.EnterMoveNextControl = true;
            this.textEdit3.Location = new Point(0x62, 0x56);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit3.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit3.RightToLeft = RightToLeft.No;
            this.textEdit3.Size = new Size(150, 0x16);
            this.textEdit3.StyleController = this.layoutControl1;
            this.textEdit3.TabIndex = 13;
            this.textEdit3.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit3.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.simpleButton1.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new Point(8, 0x178);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x17e, 0x1a);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 12;
            this.simpleButton1.Text = "KAYDET";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.textEdit7.EditValue = "0";
            this.textEdit7.EnterMoveNextControl = true;
            this.textEdit7.Location = new Point(0x62, 0xd8);
            this.textEdit7.Name = "textEdit7";
            this.textEdit7.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit7.Properties.Appearance.Options.UseFont = true;
            this.textEdit7.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit7.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit7.RightToLeft = RightToLeft.No;
            this.textEdit7.Size = new Size(150, 0x16);
            this.textEdit7.StyleController = this.layoutControl1;
            this.textEdit7.TabIndex = 11;
            this.textEdit7.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit7.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.textEdit6.EditValue = "0";
            this.textEdit6.EnterMoveNextControl = true;
            this.textEdit6.Location = new Point(0x62, 190);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit6.Properties.Appearance.Options.UseFont = true;
            this.textEdit6.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit6.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit6.RightToLeft = RightToLeft.No;
            this.textEdit6.Size = new Size(150, 0x16);
            this.textEdit6.StyleController = this.layoutControl1;
            this.textEdit6.TabIndex = 10;
            this.textEdit6.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit6.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.textEdit5.EditValue = "0";
            this.textEdit5.EnterMoveNextControl = true;
            this.textEdit5.Location = new Point(0x62, 0x8a);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit5.Properties.Appearance.Options.UseFont = true;
            this.textEdit5.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit5.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit5.RightToLeft = RightToLeft.No;
            this.textEdit5.Size = new Size(150, 0x16);
            this.textEdit5.StyleController = this.layoutControl1;
            this.textEdit5.TabIndex = 9;
            this.textEdit5.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit5.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.textEdit4.EditValue = "0";
            this.textEdit4.EnterMoveNextControl = true;
            this.textEdit4.Location = new Point(0x62, 0x70);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit4.Properties.Appearance.Options.UseFont = true;
            this.textEdit4.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit4.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.textEdit4.RightToLeft = RightToLeft.No;
            this.textEdit4.Size = new Size(150, 0x16);
            this.textEdit4.StyleController = this.layoutControl1;
            this.textEdit4.TabIndex = 8;
            this.textEdit4.KeyDown += new KeyEventHandler(this.textEdit3_KeyDown);
            this.textEdit4.KeyPress += new KeyPressEventHandler(this.textEdit3_KeyPress);
            this.textEdit2.EnterMoveNextControl = true;
            this.textEdit2.Location = new Point(0x62, 60);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Size = new Size(150, 0x16);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 6;
            this.textEdit2.EditValueChanged += new EventHandler(this.textEdit2_EditValueChanged);
            this.labelControl1.Appearance.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl1.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.labelControl1.Location = new Point(8, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x17e, 0x16);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "YENİ MOTOR EKLE";
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            BaseLayoutItem[] items = new BaseLayoutItem[] { 
                this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem11, this.layoutControlItem12, this.layoutControlItem13, this.layoutControlItem14, this.layoutControlItem15, this.layoutControlItem16, this.layoutControlItem18, this.layoutControlItem17, this.layoutControlItem19,
                this.layoutControlItem23, this.layoutControlItem24, this.layoutControlItem4, this.layoutControlItem2
            };
            this.layoutControlGroup1.Items.AddRange(items);
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new Size(0x18e, 0x19b);
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.Control = this.labelControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem1.MinSize = new Size(1, 0x1a);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x182, 0x1a);
            this.layoutControlItem1.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem3.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.textEdit2;
            this.layoutControlItem3.CustomizationFormText = "MODEL :";
            this.layoutControlItem3.Location = new Point(0, 0x34);
            this.layoutControlItem3.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem3.MinSize = new Size(1, 0x1a);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new Size(0x182, 0x1a);
            this.layoutControlItem3.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "MODEL :";
            this.layoutControlItem3.TextSize = new Size(0x57, 13);
            this.layoutControlItem5.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.textEdit4;
            this.layoutControlItem5.CustomizationFormText = "HIZ :";
            this.layoutControlItem5.Location = new Point(0, 0x68);
            this.layoutControlItem5.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem5.MinSize = new Size(1, 0x1a);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new Size(0x182, 0x1a);
            this.layoutControlItem5.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "HIZ :";
            this.layoutControlItem5.TextSize = new Size(0x57, 13);
            this.layoutControlItem6.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.textEdit5;
            this.layoutControlItem6.CustomizationFormText = "MOTOR KW :";
            this.layoutControlItem6.Location = new Point(0, 130);
            this.layoutControlItem6.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem6.MinSize = new Size(1, 0x1a);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new Size(0x182, 0x1a);
            this.layoutControlItem6.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "MOTOR KW :";
            this.layoutControlItem6.TextSize = new Size(0x57, 13);
            this.layoutControlItem7.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.textEdit6;
            this.layoutControlItem7.CustomizationFormText = "KASNAK KANAL :";
            this.layoutControlItem7.Location = new Point(0, 0xb6);
            this.layoutControlItem7.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem7.MinSize = new Size(1, 0x1a);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new Size(0x182, 0x1a);
            this.layoutControlItem7.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "KASNAK KANAL :";
            this.layoutControlItem7.TextSize = new Size(0x57, 13);
            this.layoutControlItem8.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.textEdit7;
            this.layoutControlItem8.CustomizationFormText = "HALAT \x00c7API :";
            this.layoutControlItem8.Location = new Point(0, 0xd0);
            this.layoutControlItem8.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem8.MinSize = new Size(1, 0x1a);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new Size(0x182, 0x1a);
            this.layoutControlItem8.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "HALAT \x00c7API :";
            this.layoutControlItem8.TextSize = new Size(0x57, 13);
            this.layoutControlItem9.Control = this.simpleButton1;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new Point(0, 0x170);
            this.layoutControlItem9.MaxSize = new Size(0, 30);
            this.layoutControlItem9.MinSize = new Size(1, 30);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new Size(0x182, 0x1f);
            this.layoutControlItem9.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem11.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem11.Control = this.textEdit3;
            this.layoutControlItem11.CustomizationFormText = "KAPASİTE :";
            this.layoutControlItem11.Location = new Point(0, 0x4e);
            this.layoutControlItem11.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem11.MinSize = new Size(0x7c, 0x1a);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new Size(0xf4, 0x1a);
            this.layoutControlItem11.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem11.Text = "KAPASİTE :";
            this.layoutControlItem11.TextSize = new Size(0x57, 13);
            this.layoutControlItem12.Control = this.labelControl2;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new Point(0xf4, 0x4e);
            this.layoutControlItem12.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem12.MinSize = new Size(15, 0x11);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new Size(0x8e, 0x1a);
            this.layoutControlItem12.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem12.TextSize = new Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            this.layoutControlItem13.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem13.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem13.Control = this.textEdit8;
            this.layoutControlItem13.CustomizationFormText = "KASNAK \x00c7API :";
            this.layoutControlItem13.Location = new Point(0, 0x9c);
            this.layoutControlItem13.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem13.MinSize = new Size(0x90, 0x1a);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new Size(0xf4, 0x1a);
            this.layoutControlItem13.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem13.Text = "KASNAK \x00c7API :";
            this.layoutControlItem13.TextSize = new Size(0x57, 13);
            this.layoutControlItem14.Control = this.labelControl3;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new Point(0xf4, 0x9c);
            this.layoutControlItem14.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem14.MinSize = new Size(0x43, 0x11);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new Size(0x8e, 0x1a);
            this.layoutControlItem14.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem14.TextSize = new Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            this.layoutControlItem15.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem15.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem15.Control = this.textEdit9;
            this.layoutControlItem15.CustomizationFormText = "ASKİ :";
            this.layoutControlItem15.Location = new Point(0, 0xea);
            this.layoutControlItem15.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem15.MinSize = new Size(0x90, 0x1a);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new Size(0x182, 0x1a);
            this.layoutControlItem15.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem15.Text = "ASKİ :";
            this.layoutControlItem15.TextSize = new Size(0x57, 13);
            this.layoutControlItem16.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem16.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem16.Control = this.textEdit10;
            this.layoutControlItem16.CustomizationFormText = "MAKS. Y\x00dcK :";
            this.layoutControlItem16.Location = new Point(0, 260);
            this.layoutControlItem16.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem16.MinSize = new Size(0x90, 0x1a);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new Size(0xf4, 0x1a);
            this.layoutControlItem16.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem16.Text = "MAKS. Y\x00dcK :";
            this.layoutControlItem16.TextSize = new Size(0x57, 13);
            this.layoutControlItem18.Control = this.labelControl4;
            this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem18.Location = new Point(0xf4, 260);
            this.layoutControlItem18.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem18.MinSize = new Size(0x43, 0x11);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new Size(0x8e, 0x1a);
            this.layoutControlItem18.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem18.TextSize = new Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            this.layoutControlItem17.Control = this.radioButton1;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem17.Location = new Point(0, 0x138);
            this.layoutControlItem17.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem17.MinSize = new Size(0x18, 0x1a);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new Size(0x66, 0x1a);
            this.layoutControlItem17.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem17.TextSize = new Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            this.layoutControlItem19.Control = this.radioButton2;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
            this.layoutControlItem19.Location = new Point(0x66, 0x138);
            this.layoutControlItem19.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem19.MinSize = new Size(0x18, 0x1a);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new Size(0x11c, 0x1a);
            this.layoutControlItem19.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem19.TextSize = new Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            this.layoutControlItem23.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem23.Control = this.simpleButton4;
            this.layoutControlItem23.CustomizationFormText = "layoutControlItem23";
            this.layoutControlItem23.Location = new Point(0, 0x152);
            this.layoutControlItem23.MaxSize = new Size(0, 30);
            this.layoutControlItem23.MinSize = new Size(0x52, 30);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new Size(0x182, 30);
            this.layoutControlItem23.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem23.TextSize = new Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            this.layoutControlItem24.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem24.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem24.Control = this.textEdit11;
            this.layoutControlItem24.CustomizationFormText = "VERİM :";
            this.layoutControlItem24.Location = new Point(0, 0x11e);
            this.layoutControlItem24.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem24.MinSize = new Size(0x9c, 0x1a);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new Size(0x182, 0x1a);
            this.layoutControlItem24.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem24.Text = "VERİM :";
            this.layoutControlItem24.TextSize = new Size(0x57, 13);
            this.layoutControlItem4.AppearanceItemCaption.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xa2);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.comboBox2;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new Point(0, 0x1a);
            this.layoutControlItem4.MaxSize = new Size(0xf4, 0x1a);
            this.layoutControlItem4.MinSize = new Size(0x90, 0x18);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new Size(0xf4, 0x1a);
            this.layoutControlItem4.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "MARKA :";
            this.layoutControlItem4.TextSize = new Size(0x57, 13);
            this.layoutControlItem2.Control = this.simpleButton2;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new Point(0xf4, 0x1a);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new Size(0x8e, 0x1a);
            this.layoutControlItem2.TextSize = new Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem21.Control = this.labelControl1;
            this.layoutControlItem21.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem21.Location = new Point(0, 0);
            this.layoutControlItem21.MaxSize = new Size(0, 0x1a);
            this.layoutControlItem21.MinSize = new Size(1, 0x1a);
            this.layoutControlItem21.Name = "layoutControlItem1";
            this.layoutControlItem21.Size = new Size(0x13d, 0x1a);
            this.layoutControlItem21.SizeConstraintsType = SizeConstraintsType.Custom;
            this.layoutControlItem21.TextSize = new Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x18e, 0x19b);
            base.Controls.Add(this.layoutControl1);
            this.MaximumSize = new Size(0x19e, 450);
            this.MinimumSize = new Size(0x19e, 450);
            base.Name = "motor";
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Motor Se\x00e7me ve Ekleme Ekranı";
            base.Load += new EventHandler(this.motor_Load);
            this.layoutControl1.EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.comboBox2.Properties.EndInit();
            this.textEdit11.Properties.EndInit();
            this.textEdit10.Properties.EndInit();
            this.textEdit9.Properties.EndInit();
            this.textEdit8.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit7.Properties.EndInit();
            this.textEdit6.Properties.EndInit();
            this.textEdit5.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem1.EndInit();
            this.layoutControlItem3.EndInit();
            this.layoutControlItem5.EndInit();
            this.layoutControlItem6.EndInit();
            this.layoutControlItem7.EndInit();
            this.layoutControlItem8.EndInit();
            this.layoutControlItem9.EndInit();
            this.layoutControlItem11.EndInit();
            this.layoutControlItem12.EndInit();
            this.layoutControlItem13.EndInit();
            this.layoutControlItem14.EndInit();
            this.layoutControlItem15.EndInit();
            this.layoutControlItem16.EndInit();
            this.layoutControlItem18.EndInit();
            this.layoutControlItem17.EndInit();
            this.layoutControlItem19.EndInit();
            this.layoutControlItem23.EndInit();
            this.layoutControlItem24.EndInit();
            this.layoutControlItem4.EndInit();
            this.layoutControlItem2.EndInit();
            this.layoutControlItem21.EndInit();
            base.ResumeLayout(false);
        }

        private void motor_Load(object sender, EventArgs e)
        {
            this.yukle();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                base.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioButton1.Checked)
                {
                    this.dis = 1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioButton2.Checked)
                {
                    this.dis = 0;
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((this.comboBox2.SelectedIndex == -1) || (this.comboBox2.Text == ""))
            {
                MessageBox.Show("MARKAYI BOŞ GE\x00c7EMEZSİNİZ");
            }
            else if (this.textEdit2.Text == "")
            {
                MessageBox.Show("MODELİ BOŞ GE\x00c7EMEZSİNİZ");
            }
            else
            {
                string destFileName = "";
                if (Directory.Exists(@".\motor\" + this.comboBox2.Text))
                {
                    string[] textArray1 = new string[] { @".\motor\", this.comboBox2.Text, @"\", this.textEdit2.Text, this.extension };
                    destFileName = string.Concat(textArray1);
                }
                else
                {
                    Directory.CreateDirectory(@".\motor\" + this.comboBox2.Text);
                    string[] textArray2 = new string[] { @".\motor\", this.comboBox2.Text, @"\", this.textEdit2.Text, this.extension };
                    destFileName = string.Concat(textArray2);
                }
                string str3 = destFileName.Replace(@".\", @"\");
                this.xx.oleupdate(string.Concat(new object[] { 
                    "insert into motormakine1 (marka,model,hiz,motorkw,kasnakkanal,halatcap,kapasite,kasnakcap,aski,maksyuk,diskontrol,edit,verim,degisti) values ('", this.comboBox2.Text, "','", this.textEdit2.Text, "','", this.textEdit4.Text, "','", this.textEdit5.Text, "','", this.textEdit6.Text, "','", this.textEdit7.Text, "','", this.textEdit3.Text, "','", this.textEdit8.Text,
                    "','", this.textEdit9.Text, "','", this.textEdit10.Text, "','", this.dis, "','", str3, "','", this.textEdit11.Text, "',true)"
                }), "");
                if (this.dosyayolu != "")
                {
                    File.Copy(this.dosyayolu, destFileName);
                }
                MessageBox.Show("Motor Bilgileri Eklenmiştir");
                this.dosyayolu = "";
                this.mkmt.yeni();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            new ureticiekle { mtr = this }.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.edit == "")
                {
                    MessageBox.Show("Teknik Resim Bulunamadı");
                }
                else
                {
                    try
                    {
                        Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + this.edit);
                    }
                    catch
                    {
                        MessageBox.Show("Teknik Resim Bulunamadı");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                this.openFileDialog1.FileName = "Teknik Resim Se\x00e7iniz...";
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.dosyayolu = this.openFileDialog1.FileName;
                    this.extension = Path.GetExtension(this.openFileDialog1.FileName);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this.openFileDialog1.FileName = "Teknik Resim Se\x00e7iniz...";
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            this.textEdit2.Text = this.textEdit2.Text.ToUpper();
        }

        private void textEdit3_KeyDown(object sender, KeyEventArgs e)
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

        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.nonNumberEntered)
            {
                e.Handled = true;
            }
        }

        public void yukle()
        {
            try
            {
                this.comboBox2.Properties.Items.Clear();
                this.radioButton1.Checked = true;
                DataTable table = this.xx.dtta("select distinct(marka) from uretici", "");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    this.comboBox2.Properties.Items.Add(table.Rows[i][0].ToString());
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

