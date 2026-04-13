using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Management;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ascad
{
	public class srthepler
	{
		private string datyeri = "c:\\SZG\\adat.dat";

		private string kuruumta = "01.01.2018";

		public scrt datayaz(scrt gelen)
		{
			FileStream fileStream = new FileStream(this.datyeri, FileMode.OpenOrCreate, FileAccess.Write);
			try
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(fileStream, gelen);
				fileStream.Close();
			}
			catch (Exception)
			{
			}
			finally
			{
				fileStream.Close();
			}
			return gelen;
		}

		public bool checkfirmkey()
		{
			bool result = false;
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\ZWSOFT\\ZWCAD\\2017\\en-US\\Applications\\ascad", true);
				bool flag = registryKey.GetValue("FIMCODE") == null;
				if (flag)
				{
					registryKey.SetValue("FIRMCODE", this.learnfirmkey());
					registryKey.SetValue("NOCONNECTNET", "0");
					registryKey.SetValue("INSTALDATE", this.kuruumta);
					registryKey.SetValue("LASTDATE", Convert.ToDateTime(this.kuruumta).AddYears(1).ToShortDateString());
					registryKey.SetValue("CHEKEDNETDATE", DateTime.Now.ToShortDateString());
				}
				else
				{
					registryKey.SetValue("CHEKEDNETDATE", DateTime.Now.ToShortDateString());
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		public int learnfirmkey()
		{
			int result = 15708;
			DataTable dataTable = this.scrdtta(string.Concat(new string[]
			{
				"select carid,kurtar from programpc where  prgid=5 and uuid='",
				this.getuuid(),
				"' and pcadi='",
				Environment.MachineName,
				"'"
			}), "");
			bool flag = dataTable.Rows.Count > 1;
			if (flag)
			{
				this.scroleupdate(string.Concat(new string[]
				{
					"insert into problempc(prgid,uuid,pcadi) values(5,'",
					this.getuuid(),
					"','",
					Environment.MachineName,
					"');insert into programpc(prgid,uuid,pcadi,carid) values(5,'",
					this.getuuid(),
					"','",
					Environment.MachineName,
					"',15708);"
				}), "");
			}
			else
			{
				bool flag2 = dataTable.Rows.Count == 1;
				if (flag2)
				{
					result = Convert.ToInt32(dataTable.Rows[0][0].ToString());
					this.kuruumta = dataTable.Rows[0][1].ToString();
				}
				else
				{
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						this.scroleupdate(string.Concat(new string[]
						{
							"insert into problempc(prgid,uuid,pcadi) values(5,'",
							this.getuuid(),
							"','",
							Environment.MachineName,
							"');insert into programpc(prgid,uuid,pcadi,carid) values(5,'",
							this.getuuid(),
							"','",
							Environment.MachineName,
							"',15708);"
						}), "");
					}
				}
			}
			return result;
		}

		public static DateTime GetWindowsInstallationDateTime(string computerName)
		{
			RegistryKey registryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computerName);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", false);
			bool flag = registryKey != null;
			DateTime result;
			if (flag)
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
				long num = Convert.ToInt64(registryKey.GetValue("InstallDate").ToString());
				DateTime dateTime2 = dateTime.AddSeconds((double)num);
				result = dateTime2;
			}
			else
			{
				result = DateTime.MinValue;
			}
			return result;
		}

		public string getuuid()
		{
			string result = "";
			try
			{
				ObjectQuery query = new ObjectQuery("SELECT UUID FROM Win32_ComputerSystemProduct");
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						result = managementObject["UUID"].ToString();
					}
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		public scrt datdataoko()
		{
			scrt scrt = new scrt();
			FileStream fileStream = new FileStream(this.datyeri, FileMode.OpenOrCreate, FileAccess.Read);
			try
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(fileStream, scrt);
				fileStream.Close();
			}
			catch (Exception)
			{
			}
			finally
			{
				fileStream.Close();
			}
			return scrt;
		}

		public bool intirnetvarmi()
		{
			bool result = false;
			try
			{
				TcpClient tcpClient = new TcpClient("www.google.com", 80);
				tcpClient.Close();
				result = true;
				result = this.scroleupdate("select * from programlar", "");
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public string sqlreplace(string gelen)
		{
			gelen = gelen.Replace("\\", "\\\\");
			gelen = gelen.Replace("\"", "\\\"");
			gelen = gelen.Replace("'", "\\'");
			return gelen;
		}

		public string GeneratePassword(int len)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random();
			while (0 < len--)
			{
				stringBuilder.Append("1234567890"[random.Next("1234567890".Length)]);
			}
			return stringBuilder.ToString();
		}

		public string telduzenle(string gelen)
		{
			string text = "";
			char[] array = gelen.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = array[i] == ' ';
				if (!flag)
				{
					bool flag2 = array[i] == '0' || array[i] == '1' || array[i] == '2' || array[i] == '3' || array[i] == '4' || array[i] == '5' || array[i] == '6' || array[i] == '7' || array[i] == '8' || array[i] == '9';
					if (flag2)
					{
						text += array[i].ToString();
					}
				}
			}
			bool flag3 = text.StartsWith("90");
			if (!flag3)
			{
				bool flag4 = text.StartsWith("0");
				if (flag4)
				{
					text = "9" + text;
				}
				else
				{
					text = "90" + text;
				}
			}
			bool flag5 = text.Length == 12;
			if (!flag5)
			{
				bool flag6 = text.Length > 12;
				if (flag6)
				{
					text = text.Substring(0, 12);
				}
			}
			return text;
		}

		public bool scroleupdate(string komut, string isinacikla)
		{
			bool result = false;
			komut = komut.Replace("delete * ", "delete ");
			MySqlConnection mySqlConnection = new MySqlConnection(this.scrdtbase());
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
			catch (Exception)
			{
			}
			finally
			{
				mySqlConnection.Close();
			}
			return result;
		}

		public DataTable scrdtta(string negeldi, string acikla)
		{
			DataTable dataTable = new DataTable();
			MySqlConnection mySqlConnection = new MySqlConnection(this.scrdtbase());
			try
			{
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(negeldi, mySqlConnection);
				mySqlDataAdapter.Fill(dataTable);
			}
			catch (Exception)
			{
			}
			finally
			{
				mySqlConnection.Close();
			}
			return dataTable;
		}

		private string scrdtbase()
		{
			string result = "";
			try
			{
				result = "Server=78.188.177.111;Database=SZG;uid=szgcrm;Pwd=Qwrdobj!865;default command timeout=120";
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
