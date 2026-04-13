using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ascad
{
	public class abc1 : IDisposable
	{
		[Serializable]
		public class bagbilgi
		{
			public string icbag
			{
				get;
				set;
			}

			public string disbag
			{
				get;
				set;
			}

			public string databasead
			{
				get;
				set;
			}

			public string dtbusrad
			{
				get;
				set;
			}

			public string dtbusrpwd
			{
				get;
				set;
			}

			public string dosyayol
			{
				get;
				set;
			}

			public string dtblocation
			{
				get;
				set;
			}
		}

		public string dilci(int no, DataTable datasi)
		{
			string result = datasi.Select("number=" + no)[0][0].ToString();
			bool flag = datasi.Select("number=" + no)[0][0].ToString() == "";
			if (flag)
			{
				result = "Boş - Null";
			}
			return result;
		}

		public string dtbase()
		{
			string result = "";
			try
			{
				result = "Server=localhost;Database=ascad;uid=szgcrm;Pwd=Qwrdobj!865;";
			}
			catch (Exception)
			{
			}
			return result;
		}

		public string hucredeupdate(string komutbas, string kolontipi, string kolonadi, string deger, string gotu)
		{
			string result = "";
			bool flag = kolontipi == "System.Boolean" || kolontipi == "System.UInt64";
			if (flag)
			{
				result = string.Concat(new string[]
				{
					komutbas,
					kolonadi,
					"=",
					deger,
					gotu
				});
			}
			bool flag2 = kolontipi == "System.String";
			if (flag2)
			{
				result = string.Concat(new string[]
				{
					komutbas,
					kolonadi,
					"='",
					deger,
					"'",
					gotu
				});
			}
			bool flag3 = kolontipi == "System.DateTime";
			if (flag3)
			{
				result = string.Concat(new string[]
				{
					komutbas,
					kolonadi,
					"=",
					this.tarihsaatyap(Convert.ToDateTime(deger)),
					gotu
				});
			}
			bool flag4 = kolontipi == "System.Int32";
			if (flag4)
			{
				result = string.Concat(new string[]
				{
					komutbas,
					kolonadi,
					"=",
					deger,
					gotu
				});
			}
			bool flag5 = kolontipi == "System.Decimal" || kolontipi == "System.Double";
			if (flag5)
			{
				result = string.Concat(new string[]
				{
					komutbas,
					kolonadi,
					"=",
					this.dcyap(deger),
					gotu
				});
			}
			return result;
		}

		public string tarihyap(DateTime tar)
		{
			return string.Concat(new string[]
			{
				"'",
				tar.Year.ToString(),
				"/",
				tar.Month.ToString(),
				"/",
				tar.Day.ToString(),
				"'"
			});
		}

		public void UpExcelBlockName(string nedegisecek, string deger, string LiftNumber)
		{
			MySqlConnection mySqlConnection = new MySqlConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\\ASCADDB.xls;Extended Properties=Excel 8.0");
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(string.Concat(new string[]
				{
					"update mainblocks set BlkInsName='",
					deger,
					"' where bmblockname='",
					nedegisecek,
					"'"
				}), mySqlConnection);
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlConnection.Open();
				}
				mySqlCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
			}
			mySqlConnection.Close();
		}

		public void upexcel(string nedegisecek, string deger, string LiftNumber, structTahrik Tahrik)
		{
			MySqlConnection mySqlConnection = new MySqlConnection(this.dtbase());
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(string.Concat(new string[]
				{
					"update Num",
					LiftNumber,
					" set ParamValue='",
					deger,
					"' where ParamName='",
					nedegisecek,
					"' and (TipKodu='",
					Tahrik.TipKodu,
					"' or TipKodu='TEMEL') and (TahrikKodu='",
					Tahrik.TahrikKodu,
					"' or TahrikKodu='TEMEL')  and (YonKodu='",
					Tahrik.YonKodu,
					"' or YonKodu='TEMEL')"
				}), mySqlConnection);
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlConnection.Open();
				}
				mySqlCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
			}
			mySqlConnection.Close();
		}

		public void upexcel(string nedegisecek, string deger, string LiftNumber)
		{
			MySqlConnection mySqlConnection = new MySqlConnection(this.dtbase());
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(string.Concat(new string[]
				{
					"update Num",
					LiftNumber,
					" set ParamValue='",
					deger,
					"' where ParamName='",
					nedegisecek,
					"'"
				}), mySqlConnection);
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlConnection.Open();
				}
				mySqlCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
			}
			mySqlConnection.Close();
		}

		public void SetRayFark(string LiftNumber)
		{
			MySqlConnection mySqlConnection = new MySqlConnection(this.dtbase());
			try
			{
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand("update Num" + LiftNumber + " set ParamValue='100' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='DA'", mySqlConnection);
				mySqlCommand.ExecuteNonQuery();
				mySqlCommand = new MySqlCommand("update Num" + LiftNumber + " set ParamValue='200' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='MDDUZ'", mySqlConnection);
				mySqlCommand.ExecuteNonQuery();
				mySqlCommand = new MySqlCommand("update Num" + LiftNumber + " set ParamValue='0' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='MDCAP'", mySqlConnection);
				mySqlCommand.ExecuteNonQuery();
				mySqlCommand = new MySqlCommand("update Num" + LiftNumber + " set ParamValue='-200' where ParamName='KabinAgrEksenFark' and TipKodu='EA' and TahrikKodu='MDCAP'", mySqlConnection);
				mySqlCommand.ExecuteNonQuery();
				mySqlCommand = new MySqlCommand("update Num" + LiftNumber + " set ParamValue='100' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='YA'", mySqlConnection);
				mySqlCommand.ExecuteNonQuery();
				mySqlCommand = new MySqlCommand("update Num" + LiftNumber + " set ParamValue='0' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='SD'", mySqlConnection);
				mySqlCommand.ExecuteNonQuery();
				mySqlCommand = new MySqlCommand("update Num" + LiftNumber + " set ParamValue='0' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='RAMD'", mySqlConnection);
				mySqlCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
			}
			mySqlConnection.Close();
		}

		public void SetNumValue(string ParamName, string ParamValue, string LiftNumber)
		{
			MySqlConnection mySqlConnection = new MySqlConnection(this.dtbase());
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(string.Concat(new string[]
				{
					"update Num",
					LiftNumber,
					" set ParamValue='",
					ParamValue,
					"' where ParamName='",
					ParamName,
					"'"
				}), mySqlConnection);
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlConnection.Open();
				}
				mySqlCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
			}
			mySqlConnection.Close();
		}

		public void SetGirisValue(string ParamName, string ParamValue, string LiftNumber)
		{
			MySqlConnection mySqlConnection = new MySqlConnection(this.dtbase());
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(string.Concat(new string[]
				{
					"update Giris",
					LiftNumber,
					" set ParamValue='",
					ParamValue,
					"' where ParamName='",
					ParamName,
					"'"
				}), mySqlConnection);
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlConnection.Open();
				}
				mySqlCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
			}
			mySqlConnection.Close();
		}

		public string tarihsaatyap(DateTime tar)
		{
			return string.Concat(new string[]
			{
				"'",
				tar.Year.ToString(),
				"/",
				tar.Month.ToString(),
				"/",
				tar.Day.ToString(),
				" ",
				tar.Hour.ToString(),
				":",
				tar.Minute.ToString(),
				":",
				tar.Second.ToString(),
				"'"
			});
		}

		public string dcyap(string gel)
		{
			string text = string.Empty;
			char[] array = gel.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = array[i] == Convert.ToChar(".");
				if (flag)
				{
					text += ".";
				}
				else
				{
					bool flag2 = array[i] == Convert.ToChar(",");
					if (flag2)
					{
						text += ".";
					}
					else
					{
						text += array[i].ToString();
					}
				}
			}
			return text;
		}

		public string turlestir(string gelen)
		{
			string text = gelen.ToUpper();
			char[] array = new char[]
			{
				'Ş',
				'İ',
				'Ü',
				'Ğ',
				'Ö',
				'Ç'
			};
			char[] array2 = new char[]
			{
				'S',
				'I',
				'U',
				'G',
				'O',
				'C'
			};
			for (int i = 0; i < array.Length; i++)
			{
				text = text.Replace(array[i], array2[i]);
			}
			return text.Replace(" ", "_");
		}

		public string tekstringveri(string komut)
		{
			string result = "";
			MySqlConnection mySqlConnection = new MySqlConnection(this.dtbase());
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(komut, mySqlConnection);
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlConnection.Open();
				}
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool hasRows = mySqlDataReader.HasRows;
				if (hasRows)
				{
					while (mySqlDataReader.Read())
					{
						result = mySqlDataReader[0].ToString();
					}
				}
			}
			catch (Exception var_7_6E)
			{
			}
			finally
			{
				mySqlConnection.Close();
			}
			return result;
		}

		public bool oleupdate(string komut, string isinacikla)
		{
			bool result = false;
			komut = komut.Replace("delete * ", "delete ");
			komut = komut.Replace("[", "");
			komut = komut.Replace("]", "");
			komut = komut.Replace("$", "");
			MySqlConnection mySqlConnection = new MySqlConnection(this.dtbase());
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(komut, mySqlConnection);
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlConnection.Open();
				}
				mySqlCommand.ExecuteNonQuery();
				result = true;
			}
			catch (Exception var_4_87)
			{
			}
			finally
			{
				mySqlConnection.Close();
			}
			return result;
		}

		public DataTable dtta(string negeldi, string acikla)
		{
			negeldi = negeldi.Replace("[", "");
			negeldi = negeldi.Replace("]", "");
			negeldi = negeldi.Replace("$", "");
			DataTable dataTable = new DataTable();
			MySqlConnection mySqlConnection = new MySqlConnection(this.dtbase());
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(negeldi, mySqlConnection);
				mySqlDataAdapter.Fill(dataTable);
			}
			catch (Exception var_3_5D)
			{
			}
			finally
			{
				mySqlConnection.Close();
			}
			return dataTable;
		}

		public void crmyardimci(string vidid)
		{
			new yardimvideo
			{
				videone = vidid
			}.Show();
		}

		public void crmayarac()
		{
			Ayarlar ayarlar = new Ayarlar();
			ayarlar.ShowDialog();
		}

		public string crmdtbase()
		{
			string result = "";
			try
			{
				result = "Server=78.188.177.111;Database=szgbakdeneme;uid=szgcrm;Pwd=Qwrdobj!865;default command timeout=120;CharSet=utf8;";
			}
			catch (Exception)
			{
			}
			return result;
		}

		public string crmdosyolu()
		{
			string result = "";
			try
			{
				FileStream fileStream = new FileStream(".\\firms.dat", FileMode.OpenOrCreate, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				abc1.bagbilgi bagbilgi = (abc1.bagbilgi)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				result = bagbilgi.dosyayol;
			}
			catch (Exception)
			{
			}
			return result;
		}

		public string crmdatabasead()
		{
			string result = "";
			try
			{
				FileStream fileStream = new FileStream(".\\firms.dat", FileMode.OpenOrCreate, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				abc1.bagbilgi bagbilgi = (abc1.bagbilgi)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				result = bagbilgi.databasead;
			}
			catch (Exception)
			{
			}
			return result;
		}

		public string crmserverad()
		{
			string result = "";
			try
			{
				FileStream fileStream = new FileStream(".\\firms.dat", FileMode.OpenOrCreate, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				abc1.bagbilgi bagbilgi = (abc1.bagbilgi)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				result = bagbilgi.icbag;
			}
			catch (Exception)
			{
			}
			return result;
		}

		public bool crmoleupdate(string komut, string isinacikla)
		{
			bool result = false;
			komut = komut.Replace("delete * ", "delete ");
			MySqlConnection mySqlConnection = new MySqlConnection(this.crmdtbase());
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(komut, mySqlConnection);
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlConnection.Open();
				}
				mySqlCommand.ExecuteNonQuery();
				result = true;
			}
			catch (Exception var_4_51)
			{
				result = false;
			}
			finally
			{
				mySqlConnection.Close();
			}
			return result;
		}

		public DataTable crmdtta(string negeldi, string acikla)
		{
			negeldi = negeldi.Replace("[", "'");
			negeldi = negeldi.Replace("]", "'");
			negeldi = negeldi.Replace("Date()", "curdate()");
			DataTable dataTable = new DataTable();
			MySqlConnection mySqlConnection = new MySqlConnection(this.crmdtbase());
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(negeldi, mySqlConnection);
				mySqlDataAdapter.Fill(dataTable);
			}
			catch (Exception ex)
			{
				bool flag = ex.Message == "Unable to connect to any of the specified MySQL hosts.";
				if (flag)
				{
					bool flag2 = File.Exists("C:\\SZG\\Server\\bin\\mysqld-nt.exe");
					if (flag2)
					{
						Process.Start("C:\\SZG\\Server\\bin\\mysqld-nt.exe");
					}
				}
			}
			finally
			{
				mySqlConnection.Close();
			}
			return dataTable;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
