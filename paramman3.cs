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

namespace ascad
{
	public class paramman3 : Form
	{
		public ascad aadd;

		private abc1 xx = new abc1();

		private string hangideger = "";

		private List<EditorRow> lstedi = new List<EditorRow>();

		private DataTable grdtab = new DataTable();

		private IContainer components = null;

		private VGridControl kkgrid;

		private VGridControl kdgrid;

		private VGridControl tkbbgrid;

		private VGridControl mdgrid;

		private VGridControl tkaagrid;

		private VGridControl ttkbbgrid;

		private VGridControl ttkaagrid;

		private SimpleButton simpleButton1;

		private SimpleButton simpleButton2;

		public paramman3()
		{
			this.InitializeComponent();
		}

		public void destandcrash()
		{
			DataTable dataTable = new DataTable();
			dataTable.Rows.Clear();
			bool flag = dataTable.Columns.Count < 1;
			if (flag)
			{
				dataTable.Columns.Add("a", typeof(string));
				DataRow dataRow = dataTable.NewRow();
				dataRow["a"] = "ARA BURADAN";
				dataTable.Rows.Add(dataRow);
			}
			else
			{
				DataRow dataRow2 = dataTable.NewRow();
				dataRow2["a"] = 1;
				dataTable.Rows.Add(dataRow2);
			}
			this.kkgrid.Dispose();
			this.kdgrid.Dispose();
			this.mdgrid.Dispose();
			this.tkaagrid.Dispose();
			this.tkbbgrid.Dispose();
			this.ttkaagrid.Dispose();
			this.ttkbbgrid.Dispose();
			this.InitializeComponent();
			this.kkgrid.set_DataSource(dataTable);
			this.mdgrid.set_DataSource(dataTable);
			this.kdgrid.set_DataSource(dataTable);
			this.tkaagrid.set_DataSource(dataTable);
			this.tkbbgrid.set_DataSource(dataTable);
			this.ttkaagrid.set_DataSource(dataTable);
			this.ttkbbgrid.set_DataSource(dataTable);
			this.bt("KK");
			this.bt("KD");
			this.bt("MD");
			this.bt("TK-AA");
			this.bt("TK-BB");
			this.bt("TTK-AA");
			this.bt("TTK-BB");
		}

		private void bt(string KesitKODU)
		{
			clsMLift clsMLift = null;
			clsMLift = this.aadd.ReadAllData("1", KesitKODU);
			string str = "PL1";
			string str2 = "L1";
			foreach (ConsParList current in clsMLift.DimGrup)
			{
				this.NewParam(str + current.ConsName, current.ConsValue, KesitKODU);
			}
			foreach (ParamList current2 in clsMLift.VarGrup)
			{
				this.NewParam(current2.ParamName, "1", KesitKODU);
			}
			foreach (ParamList current3 in clsMLift.VarGrup)
			{
				try
				{
					this.chParamVal(current3.ParamName, current3.ParamValue, KesitKODU);
				}
				catch (Exception)
				{
				}
			}
			foreach (vtLift current4 in clsMLift.BlokGrup)
			{
				foreach (ParamList current5 in current4.BlkParamList)
				{
					bool flag = current5.ParamName != null || current5.ParamValue != null;
					if (flag)
					{
						this.NewParam(str2 + current5.ParamName, current5.ParamValue, KesitKODU);
					}
				}
			}
			foreach (ParamList current6 in clsMLift.VarGrup)
			{
				this.RenameParam(current6.ParamName, str2 + current6.ParamName, KesitKODU);
			}
		}

		private void vGridControl1_UnboundExpressionEditorCreated(object sender, UnboundExpressionEditorEventArgs e)
		{
			this.hangideger = e.get_Properties().get_Caption();
			e.get_ExpressionEditorForm().FormClosing += new FormClosingEventHandler(this.ExpressionEditorForm_FormClosing);
		}

		private void ExpressionEditorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			UnboundColumnExpressionEditorForm unboundColumnExpressionEditorForm = (UnboundColumnExpressionEditorForm)sender;
		}

		private void editedlist()
		{
			EditorRow editorRow = new EditorRow("fieldname");
			editorRow.get_Properties().set_Caption("başlık");
			editorRow.set_Name("x" + 12);
			editorRow.get_Properties().set_FieldName(this.xx.turlestir("fielname"));
			editorRow.get_Properties().set_UnboundType(6);
			editorRow.get_Properties().set_UnboundExpression("expression");
			editorRow.get_Properties().set_ShowUnboundExpressionMenu(true);
			this.kkgrid.get_Rows().Add(editorRow);
		}

		private void paramman_Load(object sender, EventArgs e)
		{
		}

		private bool ifrowvar(string rownam, string KesitKODU)
		{
			bool flag = false;
			bool flag2 = KesitKODU == "KK";
			bool result;
			if (flag2)
			{
				for (int i = 0; i < this.kkgrid.get_Rows().get_Count(); i++)
				{
					bool flag3 = this.kkgrid.get_Rows().get_Item(i).get_Name() == rownam;
					if (flag3)
					{
						result = true;
						return result;
					}
				}
			}
			else
			{
				bool flag4 = KesitKODU == "KD";
				if (flag4)
				{
					for (int j = 0; j < this.kdgrid.get_Rows().get_Count(); j++)
					{
						bool flag5 = this.kdgrid.get_Rows().get_Item(j).get_Name() == rownam;
						if (flag5)
						{
							result = true;
							return result;
						}
					}
				}
				else
				{
					bool flag6 = KesitKODU == "MD";
					if (flag6)
					{
						for (int k = 0; k < this.mdgrid.get_Rows().get_Count(); k++)
						{
							bool flag7 = this.mdgrid.get_Rows().get_Item(k).get_Name() == rownam;
							if (flag7)
							{
								result = true;
								return result;
							}
						}
					}
					else
					{
						bool flag8 = KesitKODU == "TK-AA";
						if (flag8)
						{
							for (int l = 0; l < this.tkaagrid.get_Rows().get_Count(); l++)
							{
								bool flag9 = this.tkaagrid.get_Rows().get_Item(l).get_Name() == rownam;
								if (flag9)
								{
									result = true;
									return result;
								}
							}
						}
						else
						{
							bool flag10 = KesitKODU == "TK-BB";
							if (flag10)
							{
								for (int m = 0; m < this.tkbbgrid.get_Rows().get_Count(); m++)
								{
									bool flag11 = this.tkbbgrid.get_Rows().get_Item(m).get_Name() == rownam;
									if (flag11)
									{
										result = true;
										return result;
									}
								}
							}
							else
							{
								bool flag12 = KesitKODU == "TTK-AA";
								if (flag12)
								{
									for (int n = 0; n < this.ttkaagrid.get_Rows().get_Count(); n++)
									{
										bool flag13 = this.ttkaagrid.get_Rows().get_Item(n).get_Name() == rownam;
										if (flag13)
										{
											result = true;
											return result;
										}
									}
								}
								else
								{
									bool flag14 = KesitKODU == "TTK-BB";
									if (flag14)
									{
										for (int num = 0; num < this.ttkbbgrid.get_Rows().get_Count(); num++)
										{
											bool flag15 = this.ttkbbgrid.get_Rows().get_Item(num).get_Name() == rownam;
											if (flag15)
											{
												result = true;
												return result;
											}
										}
									}
									else
									{
										Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
									}
								}
							}
						}
					}
				}
			}
			result = flag;
			return result;
		}

		public void RenameParam(string vtParName, string newName, string KesitKODU)
		{
			try
			{
				bool flag = this.ifrowvar(vtParName, KesitKODU);
				if (flag)
				{
					bool flag2 = KesitKODU == "KK";
					if (flag2)
					{
						this.kkgrid.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
						this.kkgrid.get_Rows().get_Item(vtParName).set_Name(newName);
					}
					else
					{
						bool flag3 = KesitKODU == "KD";
						if (flag3)
						{
							this.kdgrid.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
							this.kdgrid.get_Rows().get_Item(vtParName).set_Name(newName);
						}
						else
						{
							bool flag4 = KesitKODU == "MD";
							if (flag4)
							{
								this.mdgrid.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
								this.mdgrid.get_Rows().get_Item(vtParName).set_Name(newName);
							}
							else
							{
								bool flag5 = KesitKODU == "TK-AA";
								if (flag5)
								{
									this.tkaagrid.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
									this.tkaagrid.get_Rows().get_Item(vtParName).set_Name(newName);
								}
								else
								{
									bool flag6 = KesitKODU == "TK-BB";
									if (flag6)
									{
										this.tkbbgrid.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
										this.tkbbgrid.get_Rows().get_Item(vtParName).set_Name(newName);
									}
									else
									{
										bool flag7 = KesitKODU == "TTK-AA";
										if (flag7)
										{
											this.ttkaagrid.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
											this.ttkaagrid.get_Rows().get_Item(vtParName).set_Name(newName);
										}
										else
										{
											bool flag8 = KesitKODU == "TTK-BB";
											if (flag8)
											{
												this.ttkbbgrid.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
												this.ttkbbgrid.get_Rows().get_Item(vtParName).set_Name(newName);
											}
											else
											{
												Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(string.Concat(new string[]
				{
					"RENAME KISMI ->",
					vtParName,
					" - ",
					newName,
					ex.ToString()
				}));
			}
		}

		public void chParamVal(string vtParName, string newName, string KesitKODU)
		{
			try
			{
				bool flag = this.ifrowvar(vtParName, KesitKODU);
				if (flag)
				{
					bool flag2 = KesitKODU == "KK";
					if (flag2)
					{
						this.kkgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
					}
					else
					{
						bool flag3 = KesitKODU == "KD";
						if (flag3)
						{
							this.kdgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
						}
						else
						{
							bool flag4 = KesitKODU == "MD";
							if (flag4)
							{
								this.mdgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
							}
							else
							{
								bool flag5 = KesitKODU == "TK-AA";
								if (flag5)
								{
									this.tkaagrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
								}
								else
								{
									bool flag6 = KesitKODU == "TK-BB";
									if (flag6)
									{
										this.tkbbgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
									}
									else
									{
										bool flag7 = KesitKODU == "TTK-AA";
										if (flag7)
										{
											this.ttkaagrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
										}
										else
										{
											bool flag8 = KesitKODU == "TTK-BB";
											if (flag8)
											{
												this.ttkbbgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
											}
											else
											{
												Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					Debug.WriteLine("ch paramvar VAR -> " + vtParName);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("ch paramvar -> CATCH" + vtParName + " " + ex.ToString());
			}
		}

		public void chParamVal(string vtParName, string newName)
		{
			bool flag = this.ifrowvar(vtParName, "KK");
			if (flag)
			{
				this.kkgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
			}
			bool flag2 = this.ifrowvar(vtParName, "KD");
			if (flag2)
			{
				this.kdgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
			}
			bool flag3 = this.ifrowvar(vtParName, "MD");
			if (flag3)
			{
				this.mdgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
			}
			bool flag4 = this.ifrowvar(vtParName, "TK-AA");
			if (flag4)
			{
				this.tkaagrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
			}
			bool flag5 = this.ifrowvar(vtParName, "TK-BB");
			if (flag5)
			{
				this.tkbbgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
			}
			bool flag6 = this.ifrowvar(vtParName, "TTK-AA");
			if (flag6)
			{
				this.ttkaagrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
			}
			bool flag7 = this.ifrowvar(vtParName, "TTK-BB");
			if (flag7)
			{
				this.ttkbbgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
			}
		}

		public void NewParam(string vtParName, string newValue, string KesitKODU)
		{
			try
			{
				bool flag = !this.ifrowvar(vtParName, KesitKODU);
				if (flag)
				{
					EditorRow editorRow = new EditorRow(vtParName);
					editorRow.get_Properties().set_Caption(vtParName);
					editorRow.set_Name(vtParName);
					editorRow.get_Properties().set_UnboundType(6);
					editorRow.get_Properties().set_UnboundExpression(newValue);
					editorRow.get_Properties().set_ShowUnboundExpressionMenu(true);
					bool flag2 = KesitKODU == "KK";
					if (flag2)
					{
						this.kkgrid.get_Rows().Add(editorRow);
						this.lstedi.Add(editorRow);
					}
					else
					{
						bool flag3 = KesitKODU == "KD";
						if (flag3)
						{
							this.kdgrid.get_Rows().Add(editorRow);
						}
						else
						{
							bool flag4 = KesitKODU == "MD";
							if (flag4)
							{
								this.mdgrid.get_Rows().Add(editorRow);
							}
							else
							{
								bool flag5 = KesitKODU == "TK-AA";
								if (flag5)
								{
									this.tkaagrid.get_Rows().Add(editorRow);
								}
								else
								{
									bool flag6 = KesitKODU == "TK-BB";
									if (flag6)
									{
										this.tkbbgrid.get_Rows().Add(editorRow);
									}
									else
									{
										bool flag7 = KesitKODU == "TTK-AA";
										if (flag7)
										{
											this.ttkaagrid.get_Rows().Add(editorRow);
										}
										else
										{
											bool flag8 = KesitKODU == "TTK-BB";
											if (flag8)
											{
												this.ttkbbgrid.get_Rows().Add(editorRow);
											}
											else
											{
												Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					Debug.WriteLine("ROW VAR -> " + vtParName);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("ROW VAR -> CATCH" + vtParName + " " + ex.ToString());
			}
		}

		public string GetParamValFRM(string paramna, string KesitKODU)
		{
			string result = "0";
			try
			{
				bool flag = this.ifrowvar(paramna, KesitKODU);
				if (flag)
				{
					bool flag2 = KesitKODU == "KK";
					if (flag2)
					{
						result = this.kkgrid.GetCellValue(this.kkgrid.get_Rows().get_Item(paramna), 0).ToString();
					}
					else
					{
						bool flag3 = KesitKODU == "KD";
						if (flag3)
						{
							result = this.kdgrid.GetCellValue(this.kdgrid.get_Rows().get_Item(paramna), 0).ToString();
						}
						else
						{
							bool flag4 = KesitKODU == "MD";
							if (flag4)
							{
								result = this.mdgrid.GetCellValue(this.mdgrid.get_Rows().get_Item(paramna), 0).ToString();
							}
							else
							{
								bool flag5 = KesitKODU == "TK-AA";
								if (flag5)
								{
									result = this.tkaagrid.GetCellValue(this.tkaagrid.get_Rows().get_Item(paramna), 0).ToString();
								}
								else
								{
									bool flag6 = KesitKODU == "TK-BB";
									if (flag6)
									{
										result = this.tkbbgrid.GetCellValue(this.tkbbgrid.get_Rows().get_Item(paramna), 0).ToString();
									}
									else
									{
										bool flag7 = KesitKODU == "TTK-AA";
										if (flag7)
										{
											result = this.ttkaagrid.GetCellValue(this.ttkaagrid.get_Rows().get_Item(paramna), 0).ToString();
										}
										else
										{
											bool flag8 = KesitKODU == "TTK-BB";
											if (flag8)
											{
												result = this.ttkbbgrid.GetCellValue(this.ttkbbgrid.get_Rows().get_Item(paramna), 0).ToString();
											}
											else
											{
												Debug.WriteLine("KESİT KODU GELMEDİ PARAD ->" + KesitKODU);
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					Debug.WriteLine("ROW YOK -> " + paramna);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("ROW YOK -> CATCH" + ex.ToString());
			}
			return result;
		}

		private void vGridControl1_MouseClick(object sender, EventArgs e)
		{
			try
			{
				bool flag = e != null;
				if (flag)
				{
					MouseEventArgs mouseEventArgs = e as MouseEventArgs;
					VGridHitInfo vGridHitInfo = this.kkgrid.CalcHitInfo(mouseEventArgs.Location);
					bool flag2 = vGridHitInfo.HitInfoType == 3;
					if (flag2)
					{
						MessageBox.Show(vGridHitInfo.Row.get_Name());
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public void araformda(string gelen)
		{
			for (int i = 0; i < this.lstedi.Count; i++)
			{
				this.lstedi[i].set_Visible(false);
				bool flag = this.lstedi[i].get_Properties().get_Caption().Contains(gelen);
				if (flag)
				{
					this.lstedi[i].set_Visible(true);
				}
				bool flag2 = this.lstedi[i].get_Properties().get_Value().ToString().Contains(gelen);
				if (flag2)
				{
					this.lstedi[i].set_Visible(true);
				}
				bool flag3 = this.lstedi[i].get_Properties().get_UnboundExpression().Contains(gelen);
				if (flag3)
				{
					this.lstedi[i].set_Visible(true);
				}
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.lstedi.Count; i++)
			{
				this.lstedi[i].set_Visible(true);
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.araformda(this.kkgrid.GetCellValue(this.kkgrid.get_Rows().get_Item(0), 0).ToString());
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
			this.kkgrid = new VGridControl();
			this.kdgrid = new VGridControl();
			this.mdgrid = new VGridControl();
			this.tkaagrid = new VGridControl();
			this.tkbbgrid = new VGridControl();
			this.ttkaagrid = new VGridControl();
			this.ttkbbgrid = new VGridControl();
			this.simpleButton1 = new SimpleButton();
			this.simpleButton2 = new SimpleButton();
			this.kkgrid.BeginInit();
			this.kdgrid.BeginInit();
			this.mdgrid.BeginInit();
			this.tkaagrid.BeginInit();
			this.tkbbgrid.BeginInit();
			this.ttkaagrid.BeginInit();
			this.ttkbbgrid.BeginInit();
			base.SuspendLayout();
			this.kkgrid.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.kkgrid.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.kkgrid.Dock = DockStyle.Left;
			this.kkgrid.set_FindPanelVisible(true);
			this.kkgrid.set_LayoutStyle(1);
			this.kkgrid.Location = new Point(0, 0);
			this.kkgrid.Name = "kkgrid";
			this.kkgrid.get_OptionsFind().set_FindNullPrompt("kuyu kabin");
			this.kkgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.kkgrid.Size = new Size(396, 743);
			this.kkgrid.TabIndex = 0;
			this.kkgrid.Click += new EventHandler(this.vGridControl1_MouseClick);
			this.kdgrid.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.kdgrid.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.kdgrid.set_FindPanelVisible(true);
			this.kdgrid.set_LayoutStyle(1);
			this.kdgrid.Location = new Point(613, 12);
			this.kdgrid.Name = "kdgrid";
			this.kdgrid.get_OptionsFind().set_FindNullPrompt("kuyu dibi kesditi");
			this.kdgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.kdgrid.Size = new Size(168, 611);
			this.kdgrid.TabIndex = 2;
			this.mdgrid.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.mdgrid.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.mdgrid.set_FindPanelVisible(true);
			this.mdgrid.set_LayoutStyle(1);
			this.mdgrid.Location = new Point(1421, 0);
			this.mdgrid.Name = "mdgrid";
			this.mdgrid.get_OptionsFind().set_FindNullPrompt("mak daire kesiti");
			this.mdgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.mdgrid.Size = new Size(212, 743);
			this.mdgrid.TabIndex = 3;
			this.tkaagrid.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.tkaagrid.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.tkaagrid.set_FindPanelVisible(true);
			this.tkaagrid.set_LayoutStyle(1);
			this.tkaagrid.Location = new Point(1261, 12);
			this.tkaagrid.Name = "tkaagrid";
			this.tkaagrid.get_OptionsFind().set_FindNullPrompt("tkaa");
			this.tkaagrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.tkaagrid.Size = new Size(144, 611);
			this.tkaagrid.TabIndex = 4;
			this.tkbbgrid.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.tkbbgrid.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.tkbbgrid.set_FindPanelVisible(true);
			this.tkbbgrid.set_LayoutStyle(1);
			this.tkbbgrid.Location = new Point(798, 12);
			this.tkbbgrid.Name = "tkbbgrid";
			this.tkbbgrid.get_OptionsFind().set_FindNullPrompt("tkbbgrid kes");
			this.tkbbgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.tkbbgrid.Size = new Size(210, 611);
			this.tkbbgrid.TabIndex = 5;
			this.ttkaagrid.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.ttkaagrid.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.ttkaagrid.set_FindPanelVisible(true);
			this.ttkaagrid.set_LayoutStyle(1);
			this.ttkaagrid.Location = new Point(1045, 12);
			this.ttkaagrid.Name = "ttkaagrid";
			this.ttkaagrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.ttkaagrid.Size = new Size(200, 611);
			this.ttkaagrid.TabIndex = 6;
			this.ttkbbgrid.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.ttkbbgrid.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.ttkbbgrid.set_FindPanelVisible(true);
			this.ttkbbgrid.set_LayoutStyle(1);
			this.ttkbbgrid.Location = new Point(1442, 82);
			this.ttkbbgrid.Name = "ttkbbgrid";
			this.ttkbbgrid.get_OptionsFind().set_FindNullPrompt("ttkbb uzun kesit");
			this.ttkbbgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.ttkbbgrid.Size = new Size(80, 611);
			this.ttkbbgrid.TabIndex = 7;
			this.simpleButton1.Location = new Point(402, 12);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new Size(151, 23);
			this.simpleButton1.TabIndex = 8;
			this.simpleButton1.Text = "ARAMA YAPMAK İÇİN BAS";
			this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
			this.simpleButton2.Location = new Point(403, 42);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new Size(150, 23);
			this.simpleButton2.TabIndex = 9;
			this.simpleButton2.Text = "TÜM SATIRLAR";
			this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1423, 743);
			base.Controls.Add(this.simpleButton2);
			base.Controls.Add(this.simpleButton1);
			base.Controls.Add(this.mdgrid);
			base.Controls.Add(this.ttkbbgrid);
			base.Controls.Add(this.tkaagrid);
			base.Controls.Add(this.ttkaagrid);
			base.Controls.Add(this.tkbbgrid);
			base.Controls.Add(this.kkgrid);
			base.Controls.Add(this.kdgrid);
			base.Name = "paramman3";
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
			base.ResumeLayout(false);
		}
	}
}
