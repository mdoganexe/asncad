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
	public class paramman : Form
	{
		public ascad aadd;

		public int asnadedi = 1;

		private abc1 xx = new abc1();

		private string hangideger = "";

		private List<EditorRow> lstedi = new List<EditorRow>();

		private List<EditorRow> lstedi2 = new List<EditorRow>();

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

		private VGridControl mdgrid2;

		private VGridControl ttkaagrid2;

		private VGridControl tkbbgrid2;

		private VGridControl kdgrid2;

		private VGridControl tkaagrid2;

		private VGridControl kkgrid2;

		private VGridControl ttkbbgrid2;

		public paramman()
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
				dataRow2["a"] = "ARA BURADAN";
				dataTable.Rows.Add(dataRow2);
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
			this.kkgrid.set_DataSource(dataTable);
			this.mdgrid.set_DataSource(dataTable);
			this.kdgrid.set_DataSource(dataTable);
			this.tkaagrid.set_DataSource(dataTable);
			this.tkbbgrid.set_DataSource(dataTable);
			this.ttkaagrid.set_DataSource(dataTable);
			this.ttkbbgrid.set_DataSource(dataTable);
			this.kkgrid2.set_DataSource(dataTable);
			this.mdgrid2.set_DataSource(dataTable);
			this.kdgrid2.set_DataSource(dataTable);
			this.tkaagrid2.set_DataSource(dataTable);
			this.tkbbgrid2.set_DataSource(dataTable);
			this.ttkaagrid2.set_DataSource(dataTable);
			this.ttkbbgrid.set_DataSource(dataTable);
			this.lstedi.Clear();
			this.bt("KK");
			this.bt("KD");
			this.bt("MD");
			this.bt("TK-AA");
			this.bt("TK-BB");
			this.bt("TTK-AA");
			this.bt("TTK-BB");
			bool flag2 = this.asnadedi > 1;
			if (flag2)
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
					catch (Exception ex)
					{
						Debug.WriteLine("ROW EKLENEMDİ NEDENİ" + ex.ToString());
					}
				}
			}
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
			bool flag2 = rownam.StartsWith("PL2") || rownam.StartsWith("L2");
			bool result;
			if (flag2)
			{
				bool flag3 = KesitKODU == "KK";
				if (flag3)
				{
					for (int i = 0; i < this.kkgrid2.get_Rows().get_Count(); i++)
					{
						bool flag4 = this.kkgrid2.get_Rows().get_Item(i).get_Name() == rownam;
						if (flag4)
						{
							result = true;
							return result;
						}
					}
				}
				else
				{
					bool flag5 = KesitKODU == "KD";
					if (flag5)
					{
						for (int j = 0; j < this.kdgrid2.get_Rows().get_Count(); j++)
						{
							bool flag6 = this.kdgrid2.get_Rows().get_Item(j).get_Name() == rownam;
							if (flag6)
							{
								result = true;
								return result;
							}
						}
					}
					else
					{
						bool flag7 = KesitKODU == "MD";
						if (flag7)
						{
							for (int k = 0; k < this.mdgrid2.get_Rows().get_Count(); k++)
							{
								bool flag8 = this.mdgrid2.get_Rows().get_Item(k).get_Name() == rownam;
								if (flag8)
								{
									result = true;
									return result;
								}
							}
						}
						else
						{
							bool flag9 = KesitKODU == "TK-AA";
							if (flag9)
							{
								for (int l = 0; l < this.tkaagrid2.get_Rows().get_Count(); l++)
								{
									bool flag10 = this.tkaagrid2.get_Rows().get_Item(l).get_Name() == rownam;
									if (flag10)
									{
										result = true;
										return result;
									}
								}
							}
							else
							{
								bool flag11 = KesitKODU == "TK-BB";
								if (flag11)
								{
									for (int m = 0; m < this.tkbbgrid2.get_Rows().get_Count(); m++)
									{
										bool flag12 = this.tkbbgrid2.get_Rows().get_Item(m).get_Name() == rownam;
										if (flag12)
										{
											result = true;
											return result;
										}
									}
								}
								else
								{
									bool flag13 = KesitKODU == "TTK-AA";
									if (flag13)
									{
										for (int n = 0; n < this.ttkaagrid2.get_Rows().get_Count(); n++)
										{
											bool flag14 = this.ttkaagrid2.get_Rows().get_Item(n).get_Name() == rownam;
											if (flag14)
											{
												result = true;
												return result;
											}
										}
									}
									else
									{
										bool flag15 = KesitKODU == "TTK-BB";
										if (flag15)
										{
											for (int num = 0; num < this.ttkbbgrid2.get_Rows().get_Count(); num++)
											{
												bool flag16 = this.ttkbbgrid2.get_Rows().get_Item(num).get_Name() == rownam;
												if (flag16)
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
			}
			else
			{
				bool flag17 = KesitKODU == "KK";
				if (flag17)
				{
					for (int num2 = 0; num2 < this.kkgrid.get_Rows().get_Count(); num2++)
					{
						bool flag18 = this.kkgrid.get_Rows().get_Item(num2).get_Name() == rownam;
						if (flag18)
						{
							result = true;
							return result;
						}
					}
				}
				else
				{
					bool flag19 = KesitKODU == "KD";
					if (flag19)
					{
						for (int num3 = 0; num3 < this.kdgrid.get_Rows().get_Count(); num3++)
						{
							bool flag20 = this.kdgrid.get_Rows().get_Item(num3).get_Name() == rownam;
							if (flag20)
							{
								result = true;
								return result;
							}
						}
					}
					else
					{
						bool flag21 = KesitKODU == "MD";
						if (flag21)
						{
							for (int num4 = 0; num4 < this.mdgrid.get_Rows().get_Count(); num4++)
							{
								bool flag22 = this.mdgrid.get_Rows().get_Item(num4).get_Name() == rownam;
								if (flag22)
								{
									result = true;
									return result;
								}
							}
						}
						else
						{
							bool flag23 = KesitKODU == "TK-AA";
							if (flag23)
							{
								for (int num5 = 0; num5 < this.tkaagrid.get_Rows().get_Count(); num5++)
								{
									bool flag24 = this.tkaagrid.get_Rows().get_Item(num5).get_Name() == rownam;
									if (flag24)
									{
										result = true;
										return result;
									}
								}
							}
							else
							{
								bool flag25 = KesitKODU == "TK-BB";
								if (flag25)
								{
									for (int num6 = 0; num6 < this.tkbbgrid.get_Rows().get_Count(); num6++)
									{
										bool flag26 = this.tkbbgrid.get_Rows().get_Item(num6).get_Name() == rownam;
										if (flag26)
										{
											result = true;
											return result;
										}
									}
								}
								else
								{
									bool flag27 = KesitKODU == "TTK-AA";
									if (flag27)
									{
										for (int num7 = 0; num7 < this.ttkaagrid.get_Rows().get_Count(); num7++)
										{
											bool flag28 = this.ttkaagrid.get_Rows().get_Item(num7).get_Name() == rownam;
											if (flag28)
											{
												result = true;
												return result;
											}
										}
									}
									else
									{
										bool flag29 = KesitKODU == "TTK-BB";
										if (flag29)
										{
											for (int num8 = 0; num8 < this.ttkbbgrid.get_Rows().get_Count(); num8++)
											{
												bool flag30 = this.ttkbbgrid.get_Rows().get_Item(num8).get_Name() == rownam;
												if (flag30)
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
			bool flag = vtParName.StartsWith("PL2") || vtParName.StartsWith("L2");
			if (flag)
			{
				bool flag2 = this.ifrowvar(vtParName, "KK");
				if (flag2)
				{
					this.kkgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag3 = this.ifrowvar(vtParName, "KD");
				if (flag3)
				{
					this.kdgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag4 = this.ifrowvar(vtParName, "MD");
				if (flag4)
				{
					this.mdgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag5 = this.ifrowvar(vtParName, "TK-AA");
				if (flag5)
				{
					this.tkaagrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag6 = this.ifrowvar(vtParName, "TK-BB");
				if (flag6)
				{
					this.tkbbgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag7 = this.ifrowvar(vtParName, "TTK-AA");
				if (flag7)
				{
					this.ttkaagrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag8 = this.ifrowvar(vtParName, "TTK-BB");
				if (flag8)
				{
					this.ttkbbgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
			}
			else
			{
				bool flag9 = this.ifrowvar(vtParName, "KK");
				if (flag9)
				{
					this.kkgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag10 = this.ifrowvar(vtParName, "KD");
				if (flag10)
				{
					this.kdgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag11 = this.ifrowvar(vtParName, "MD");
				if (flag11)
				{
					this.mdgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag12 = this.ifrowvar(vtParName, "TK-AA");
				if (flag12)
				{
					this.tkaagrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag13 = this.ifrowvar(vtParName, "TK-BB");
				if (flag13)
				{
					this.tkbbgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag14 = this.ifrowvar(vtParName, "TTK-AA");
				if (flag14)
				{
					this.ttkaagrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
				bool flag15 = this.ifrowvar(vtParName, "TTK-BB");
				if (flag15)
				{
					this.ttkbbgrid.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
				}
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
					editorRow.get_Properties().set_UnboundType(1);
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
						bool flag3 = paramna.StartsWith("PL2") || paramna.StartsWith("L2");
						if (flag3)
						{
							result = this.kkgrid2.GetCellValue(this.kkgrid2.get_Rows().get_Item(paramna), 0).ToString();
						}
						else
						{
							result = this.kkgrid.GetCellValue(this.kkgrid.get_Rows().get_Item(paramna), 0).ToString();
						}
					}
					else
					{
						bool flag4 = KesitKODU == "KD";
						if (flag4)
						{
							bool flag5 = paramna.StartsWith("PL2") || paramna.StartsWith("L2");
							if (flag5)
							{
								result = this.kdgrid2.GetCellValue(this.kdgrid2.get_Rows().get_Item(paramna), 0).ToString();
							}
							else
							{
								result = this.kdgrid.GetCellValue(this.kdgrid.get_Rows().get_Item(paramna), 0).ToString();
							}
						}
						else
						{
							bool flag6 = KesitKODU == "MD";
							if (flag6)
							{
								bool flag7 = paramna.StartsWith("PL2") || paramna.StartsWith("L2");
								if (flag7)
								{
									result = this.mdgrid2.GetCellValue(this.mdgrid2.get_Rows().get_Item(paramna), 0).ToString();
								}
								else
								{
									result = this.mdgrid.GetCellValue(this.mdgrid.get_Rows().get_Item(paramna), 0).ToString();
								}
							}
							else
							{
								bool flag8 = KesitKODU == "TK-AA";
								if (flag8)
								{
									bool flag9 = paramna.StartsWith("PL2") || paramna.StartsWith("L2");
									if (flag9)
									{
										result = this.tkaagrid2.GetCellValue(this.tkaagrid2.get_Rows().get_Item(paramna), 0).ToString();
									}
									else
									{
										result = this.tkaagrid.GetCellValue(this.tkaagrid.get_Rows().get_Item(paramna), 0).ToString();
									}
								}
								else
								{
									bool flag10 = KesitKODU == "TK-BB";
									if (flag10)
									{
										bool flag11 = paramna.StartsWith("PL2") || paramna.StartsWith("L2");
										if (flag11)
										{
											result = this.tkbbgrid2.GetCellValue(this.tkbbgrid2.get_Rows().get_Item(paramna), 0).ToString();
										}
										else
										{
											result = this.tkbbgrid.GetCellValue(this.tkbbgrid.get_Rows().get_Item(paramna), 0).ToString();
										}
									}
									else
									{
										bool flag12 = KesitKODU == "TTK-AA";
										if (flag12)
										{
											bool flag13 = paramna.StartsWith("PL2") || paramna.StartsWith("L2");
											if (flag13)
											{
												result = this.ttkaagrid2.GetCellValue(this.ttkaagrid2.get_Rows().get_Item(paramna), 0).ToString();
											}
											else
											{
												result = this.ttkaagrid.GetCellValue(this.ttkaagrid.get_Rows().get_Item(paramna), 0).ToString();
											}
										}
										else
										{
											bool flag14 = KesitKODU == "TTK-BB";
											if (flag14)
											{
												bool flag15 = paramna.StartsWith("PL2") || paramna.StartsWith("L2");
												if (flag15)
												{
													result = this.ttkbbgrid2.GetCellValue(this.ttkbbgrid2.get_Rows().get_Item(paramna), 0).ToString();
												}
												else
												{
													result = this.ttkbbgrid.GetCellValue(this.ttkbbgrid.get_Rows().get_Item(paramna), 0).ToString();
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
				bool flag = this.lstedi[i].get_Properties().get_Value() != null;
				if (flag)
				{
					bool flag2 = this.lstedi[i].get_Properties().get_Caption().Contains(gelen);
					if (flag2)
					{
						this.lstedi[i].set_Visible(true);
					}
					bool flag3 = this.lstedi[i].get_Properties().get_Value().ToString().Contains(gelen);
					if (flag3)
					{
						this.lstedi[i].set_Visible(true);
					}
					bool flag4 = this.lstedi[i].get_Properties().get_UnboundExpression().Contains(gelen);
					if (flag4)
					{
						this.lstedi[i].set_Visible(true);
					}
				}
				else
				{
					Debug.WriteLine("NULL DEGER ROW ===>" + this.lstedi[i].get_Properties().get_Caption());
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

		private void bt2(string KesitKODU)
		{
			clsMLift clsMLift = null;
			clsMLift = this.aadd.ReadAllData("2", KesitKODU);
			string str = "PL2";
			string str2 = "L2";
			foreach (ConsParList current in clsMLift.DimGrup)
			{
				this.NewParam2(str + current.ConsName, current.ConsValue, KesitKODU);
			}
			foreach (ParamList current2 in clsMLift.VarGrup)
			{
				this.NewParam2(current2.ParamName, "2", KesitKODU);
			}
			foreach (ParamList current3 in clsMLift.VarGrup)
			{
				try
				{
					this.chParamVal2(current3.ParamName, current3.ParamValue, KesitKODU);
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
						this.NewParam2(str2 + current5.ParamName, current5.ParamValue, KesitKODU);
					}
				}
			}
			foreach (ParamList current6 in clsMLift.VarGrup)
			{
				this.RenameParam2(current6.ParamName, str2 + current6.ParamName, KesitKODU);
			}
		}

		private bool ifrowvar2(string rownam, string KesitKODU)
		{
			bool flag = false;
			bool flag2 = KesitKODU == "KK";
			bool result;
			if (flag2)
			{
				for (int i = 0; i < this.kkgrid2.get_Rows().get_Count(); i++)
				{
					bool flag3 = this.kkgrid2.get_Rows().get_Item(i).get_Name() == rownam;
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
					for (int j = 0; j < this.kdgrid2.get_Rows().get_Count(); j++)
					{
						bool flag5 = this.kdgrid2.get_Rows().get_Item(j).get_Name() == rownam;
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
						for (int k = 0; k < this.mdgrid2.get_Rows().get_Count(); k++)
						{
							bool flag7 = this.mdgrid2.get_Rows().get_Item(k).get_Name() == rownam;
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
							for (int l = 0; l < this.tkaagrid2.get_Rows().get_Count(); l++)
							{
								bool flag9 = this.tkaagrid2.get_Rows().get_Item(l).get_Name() == rownam;
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
								for (int m = 0; m < this.tkbbgrid2.get_Rows().get_Count(); m++)
								{
									bool flag11 = this.tkbbgrid2.get_Rows().get_Item(m).get_Name() == rownam;
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
									for (int n = 0; n < this.ttkaagrid2.get_Rows().get_Count(); n++)
									{
										bool flag13 = this.ttkaagrid2.get_Rows().get_Item(n).get_Name() == rownam;
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
										for (int num = 0; num < this.ttkbbgrid2.get_Rows().get_Count(); num++)
										{
											bool flag15 = this.ttkbbgrid2.get_Rows().get_Item(num).get_Name() == rownam;
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

		public void RenameParam2(string vtParName, string newName, string KesitKODU)
		{
			try
			{
				bool flag = this.ifrowvar2(vtParName, KesitKODU);
				if (flag)
				{
					bool flag2 = KesitKODU == "KK";
					if (flag2)
					{
						this.kkgrid2.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
						this.kkgrid2.get_Rows().get_Item(vtParName).set_Name(newName);
					}
					else
					{
						bool flag3 = KesitKODU == "KD";
						if (flag3)
						{
							this.kdgrid2.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
							this.kdgrid2.get_Rows().get_Item(vtParName).set_Name(newName);
						}
						else
						{
							bool flag4 = KesitKODU == "MD";
							if (flag4)
							{
								this.mdgrid2.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
								this.mdgrid2.get_Rows().get_Item(vtParName).set_Name(newName);
							}
							else
							{
								bool flag5 = KesitKODU == "TK-AA";
								if (flag5)
								{
									this.tkaagrid2.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
									this.tkaagrid2.get_Rows().get_Item(vtParName).set_Name(newName);
								}
								else
								{
									bool flag6 = KesitKODU == "TK-BB";
									if (flag6)
									{
										this.tkbbgrid2.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
										this.tkbbgrid2.get_Rows().get_Item(vtParName).set_Name(newName);
									}
									else
									{
										bool flag7 = KesitKODU == "TTK-AA";
										if (flag7)
										{
											this.ttkaagrid2.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
											this.ttkaagrid2.get_Rows().get_Item(vtParName).set_Name(newName);
										}
										else
										{
											bool flag8 = KesitKODU == "TTK-BB";
											if (flag8)
											{
												this.ttkbbgrid2.get_Rows().get_Item(vtParName).get_Properties().set_Caption(newName);
												this.ttkbbgrid2.get_Rows().get_Item(vtParName).set_Name(newName);
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

		public void chParamVal2(string vtParName, string newName, string KesitKODU)
		{
			try
			{
				bool flag = this.ifrowvar2(vtParName, KesitKODU);
				if (flag)
				{
					bool flag2 = KesitKODU == "KK";
					if (flag2)
					{
						this.kkgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
					}
					else
					{
						bool flag3 = KesitKODU == "KD";
						if (flag3)
						{
							this.kdgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
						}
						else
						{
							bool flag4 = KesitKODU == "MD";
							if (flag4)
							{
								this.mdgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
							}
							else
							{
								bool flag5 = KesitKODU == "TK-AA";
								if (flag5)
								{
									this.tkaagrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
								}
								else
								{
									bool flag6 = KesitKODU == "TK-BB";
									if (flag6)
									{
										this.tkbbgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
									}
									else
									{
										bool flag7 = KesitKODU == "TTK-AA";
										if (flag7)
										{
											this.ttkaagrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
										}
										else
										{
											bool flag8 = KesitKODU == "TTK-BB";
											if (flag8)
											{
												this.ttkbbgrid2.get_Rows().get_Item(vtParName).get_Properties().set_UnboundExpression(newName);
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

		public void NewParam2(string vtParName, string newValue, string KesitKODU)
		{
			try
			{
				bool flag = !this.ifrowvar2(vtParName, KesitKODU);
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
						this.kkgrid2.get_Rows().Add(editorRow);
						this.lstedi2.Add(editorRow);
					}
					else
					{
						bool flag3 = KesitKODU == "KD";
						if (flag3)
						{
							this.kdgrid2.get_Rows().Add(editorRow);
						}
						else
						{
							bool flag4 = KesitKODU == "MD";
							if (flag4)
							{
								this.mdgrid2.get_Rows().Add(editorRow);
							}
							else
							{
								bool flag5 = KesitKODU == "TK-AA";
								if (flag5)
								{
									this.tkaagrid2.get_Rows().Add(editorRow);
								}
								else
								{
									bool flag6 = KesitKODU == "TK-BB";
									if (flag6)
									{
										this.tkbbgrid2.get_Rows().Add(editorRow);
									}
									else
									{
										bool flag7 = KesitKODU == "TTK-AA";
										if (flag7)
										{
											this.ttkaagrid2.get_Rows().Add(editorRow);
										}
										else
										{
											bool flag8 = KesitKODU == "TTK-BB";
											if (flag8)
											{
												this.ttkbbgrid2.get_Rows().Add(editorRow);
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
					Debug.WriteLine("ROW2 VAR2 -> " + vtParName);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("ROW2 VAR2 -> CATCH" + vtParName + " " + ex.ToString());
			}
		}

		private void kkgrid2_Click(object sender, EventArgs e)
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
			this.kdgrid.Location = new Point(887, 132);
			this.kdgrid.Name = "kdgrid";
			this.kdgrid.get_OptionsFind().set_FindNullPrompt("kuyu dibi kesditi");
			this.kdgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.kdgrid.Size = new Size(180, 200);
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
			this.mdgrid.Location = new Point(1283, 337);
			this.mdgrid.Name = "mdgrid";
			this.mdgrid.get_OptionsFind().set_FindNullPrompt("mak daire kesiti");
			this.mdgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.mdgrid.Size = new Size(176, 200);
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
			this.tkaagrid.Location = new Point(1085, 337);
			this.tkaagrid.Name = "tkaagrid";
			this.tkaagrid.get_OptionsFind().set_FindNullPrompt("tkaa");
			this.tkaagrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.tkaagrid.Size = new Size(180, 200);
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
			this.tkbbgrid.Location = new Point(1091, 132);
			this.tkbbgrid.Name = "tkbbgrid";
			this.tkbbgrid.get_OptionsFind().set_FindNullPrompt("tkbbgrid kes");
			this.tkbbgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.tkbbgrid.Size = new Size(180, 200);
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
			this.ttkaagrid.Location = new Point(887, 338);
			this.ttkaagrid.Name = "ttkaagrid";
			this.ttkaagrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.ttkaagrid.Size = new Size(180, 200);
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
			this.ttkbbgrid.Location = new Point(1465, 338);
			this.ttkbbgrid.Name = "ttkbbgrid";
			this.ttkbbgrid.get_OptionsFind().set_FindNullPrompt("ttkbb uzun kesit");
			this.ttkbbgrid.get_OptionsMenu().set_EnableContextMenu(true);
			this.ttkbbgrid.Size = new Size(170, 200);
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
			this.kkgrid2.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.kkgrid2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kkgrid2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.kkgrid2.set_FindPanelVisible(true);
			this.kkgrid2.set_LayoutStyle(1);
			this.kkgrid2.Location = new Point(559, 0);
			this.kkgrid2.Name = "kkgrid2";
			this.kkgrid2.get_OptionsFind().set_FindNullPrompt("kuyu kabin");
			this.kkgrid2.get_OptionsMenu().set_EnableContextMenu(true);
			this.kkgrid2.Size = new Size(297, 743);
			this.kkgrid2.TabIndex = 12;
			this.kkgrid2.Click += new EventHandler(this.kkgrid2_Click);
			this.mdgrid2.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.mdgrid2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.mdgrid2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.mdgrid2.set_FindPanelVisible(true);
			this.mdgrid2.set_LayoutStyle(1);
			this.mdgrid2.Location = new Point(1283, 543);
			this.mdgrid2.Name = "mdgrid2";
			this.mdgrid2.get_OptionsFind().set_FindNullPrompt("mak daire kesiti");
			this.mdgrid2.get_OptionsMenu().set_EnableContextMenu(true);
			this.mdgrid2.Size = new Size(180, 200);
			this.mdgrid2.TabIndex = 14;
			this.ttkaagrid2.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.ttkaagrid2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkaagrid2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.ttkaagrid2.set_FindPanelVisible(true);
			this.ttkaagrid2.set_LayoutStyle(1);
			this.ttkaagrid2.Location = new Point(887, 543);
			this.ttkaagrid2.Name = "ttkaagrid2";
			this.ttkaagrid2.get_OptionsMenu().set_EnableContextMenu(true);
			this.ttkaagrid2.Size = new Size(180, 200);
			this.ttkaagrid2.TabIndex = 16;
			this.tkbbgrid2.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.tkbbgrid2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkbbgrid2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.tkbbgrid2.set_FindPanelVisible(true);
			this.tkbbgrid2.set_LayoutStyle(1);
			this.tkbbgrid2.Location = new Point(1459, 132);
			this.tkbbgrid2.Name = "tkbbgrid2";
			this.tkbbgrid2.get_OptionsFind().set_FindNullPrompt("tkbbgrid kes");
			this.tkbbgrid2.get_OptionsMenu().set_EnableContextMenu(true);
			this.tkbbgrid2.Size = new Size(180, 200);
			this.tkbbgrid2.TabIndex = 15;
			this.kdgrid2.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.kdgrid2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.kdgrid2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.kdgrid2.set_FindPanelVisible(true);
			this.kdgrid2.set_LayoutStyle(1);
			this.kdgrid2.Location = new Point(1277, 132);
			this.kdgrid2.Name = "kdgrid2";
			this.kdgrid2.get_OptionsFind().set_FindNullPrompt("kuyu dibi kesditi");
			this.kdgrid2.get_OptionsMenu().set_EnableContextMenu(true);
			this.kdgrid2.Size = new Size(180, 200);
			this.kdgrid2.TabIndex = 13;
			this.tkaagrid2.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.tkaagrid2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.tkaagrid2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.tkaagrid2.set_FindPanelVisible(true);
			this.tkaagrid2.set_LayoutStyle(1);
			this.tkaagrid2.Location = new Point(1085, 543);
			this.tkaagrid2.Name = "tkaagrid2";
			this.tkaagrid2.get_OptionsFind().set_FindNullPrompt("tkaa");
			this.tkaagrid2.get_OptionsMenu().set_EnableContextMenu(true);
			this.tkaagrid2.Size = new Size(180, 200);
			this.tkaagrid2.TabIndex = 17;
			this.ttkbbgrid2.get_Appearance().get_BandBorder().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_BandBorder().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_Category().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_Category().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_CategoryExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_CategoryExpandButton().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_DisabledRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_DisabledRecordValue().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_DisabledRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_DisabledRow().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_Empty().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_Empty().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_ExpandButton().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_ExpandButton().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_FixedLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_FixedLine().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_FocusedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_FocusedCell().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_FocusedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_FocusedRecord().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_FocusedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_FocusedRow().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_HideSelectionRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_HideSelectionRow().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_HorzLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_HorzLine().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_ModifiedRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_ModifiedRecordValue().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_ModifiedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_ModifiedRow().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_PressedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_PressedRow().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_ReadOnlyRecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_ReadOnlyRecordValue().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_ReadOnlyRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_ReadOnlyRow().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_RecordValue().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_RecordValue().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_RowHeaderPanel().set_Font(new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_RowHeaderPanel().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_SelectedCell().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_SelectedCell().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_SelectedRecord().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_SelectedRecord().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_SelectedRow().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_SelectedRow().get_Options().set_UseFont(true);
			this.ttkbbgrid2.get_Appearance().get_VertLine().set_Font(new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 162));
			this.ttkbbgrid2.get_Appearance().get_VertLine().get_Options().set_UseFont(true);
			this.ttkbbgrid2.set_FindPanelVisible(true);
			this.ttkbbgrid2.set_LayoutStyle(1);
			this.ttkbbgrid2.Location = new Point(1469, 544);
			this.ttkbbgrid2.Name = "ttkbbgrid2";
			this.ttkbbgrid2.get_OptionsFind().set_FindNullPrompt("ttkbb uzun kesit");
			this.ttkbbgrid2.get_OptionsMenu().set_EnableContextMenu(true);
			this.ttkbbgrid2.Size = new Size(170, 191);
			this.ttkbbgrid2.TabIndex = 18;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1647, 743);
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
	}
}
