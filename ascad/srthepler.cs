namespace ascad
{
    using Microsoft.Win32;
    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.IO;
    using System.Management;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    public class srthepler
    {
        private string datyeri = @"c:\SZG\adat.dat";
        private string kuruumta = "01.01.2018";

        public bool checkfirmkey()
        {
            bool flag = false;
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\ZWSOFT\ZWCAD\2017\en-US\Applications\ascad", true);
                if (key.GetValue("FIMCODE") == null)
                {
                    key.SetValue("FIRMCODE", this.learnfirmkey());
                    key.SetValue("NOCONNECTNET", "0");
                    key.SetValue("INSTALDATE", this.kuruumta);
                    key.SetValue("LASTDATE", Convert.ToDateTime(this.kuruumta).AddYears(1).ToShortDateString());
                    key.SetValue("CHEKEDNETDATE", DateTime.Now.ToShortDateString());
                    return flag;
                }
                key.SetValue("CHEKEDNETDATE", DateTime.Now.ToShortDateString());
            }
            catch (Exception)
            {
            }
            return flag;
        }

        public scrt datayaz(scrt gelen)
        {
            scrt graph = gelen;
            FileStream serializationStream = new FileStream(this.datyeri, FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                new BinaryFormatter().Serialize(serializationStream, graph);
                serializationStream.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                serializationStream.Close();
            }
            return graph;
        }

        public scrt datdataoko()
        {
            scrt graph = new scrt();
            FileStream serializationStream = new FileStream(this.datyeri, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                new BinaryFormatter().Serialize(serializationStream, graph);
                serializationStream.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                serializationStream.Close();
            }
            return graph;
        }

        public string GeneratePassword(int len)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            while (0 < len--)
            {
                builder.Append("1234567890"[random.Next("1234567890".Length)]);
            }
            return builder.ToString();
        }

        public string getuuid()
        {
            string str = "";
            try
            {
                ObjectQuery query = new ObjectQuery("SELECT UUID FROM Win32_ComputerSystemProduct");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    str = obj2["UUID"].ToString();
                }
            }
            catch (Exception)
            {
            }
            return str;
        }

        public static DateTime GetWindowsInstallationDateTime(string computerName)
        {
            RegistryKey key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computerName).OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);
            if (key > null)
            {
                DateTime time = new DateTime(0x7b2, 1, 1, 0, 0, 0);
                long num = Convert.ToInt64(key.GetValue("InstallDate").ToString());
                return time.AddSeconds((double) num);
            }
            return DateTime.MinValue;
        }

        public bool intirnetvarmi()
        {
            bool flag = false;
            try
            {
                new TcpClient("www.google.com", 80).Close();
                flag = true;
                return this.scroleupdate("select * from programlar", "");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int learnfirmkey()
        {
            int num = 0x3d5c;
            DataTable table = this.scrdtta("select carid,kurtar from programpc where  prgid=5 and uuid='" + this.getuuid() + "' and pcadi='" + Environment.MachineName + "'", "");
            if (table.Rows.Count > 1)
            {
                this.scroleupdate("insert into problempc(prgid,uuid,pcadi) values(5,'" + this.getuuid() + "','" + Environment.MachineName + "');insert into programpc(prgid,uuid,pcadi,carid) values(5,'" + this.getuuid() + "','" + Environment.MachineName + "',15708);", "");
                return num;
            }
            if (table.Rows.Count == 1)
            {
                num = Convert.ToInt32(table.Rows[0][0].ToString());
                this.kuruumta = table.Rows[0][1].ToString();
                return num;
            }
            if (table.Rows.Count == 0)
            {
                this.scroleupdate("insert into problempc(prgid,uuid,pcadi) values(5,'" + this.getuuid() + "','" + Environment.MachineName + "');insert into programpc(prgid,uuid,pcadi,carid) values(5,'" + this.getuuid() + "','" + Environment.MachineName + "',15708);", "");
            }
            return num;
        }

        private string scrdtbase()
        {
            string str = "";
            try
            {
                str = "Server=78.188.177.111;Database=SZG;uid=szgcrm;Pwd=Qwrdobj!865;default command timeout=120";
            }
            catch (Exception)
            {
            }
            return str;
        }

        public DataTable scrdtta(string negeldi, string acikla)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection connection = new MySqlConnection(this.scrdtbase());
            try
            {
                new MySqlDataAdapter(negeldi, connection).Fill(dataTable);
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public bool scroleupdate(string komut, string isinacikla)
        {
            bool flag = false;
            komut = komut.Replace("delete * ", "delete ");
            MySqlConnection connection = new MySqlConnection(this.scrdtbase());
            try
            {
                MySqlCommand command = new MySqlCommand(komut, connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public string sqlreplace(string gelen)
        {
            gelen = gelen.Replace(@"\", @"\\");
            gelen = gelen.Replace("\"", "\\\"");
            gelen = gelen.Replace("'", @"\'");
            return gelen;
        }

        public string telduzenle(string gelen)
        {
            string str = "";
            char[] chArray = gelen.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if ((chArray[i] != ' ') && ((((((chArray[i] == '0') || (chArray[i] == '1')) || ((chArray[i] == '2') || (chArray[i] == '3'))) || (((chArray[i] == '4') || (chArray[i] == '5')) || ((chArray[i] == '6') || (chArray[i] == '7')))) || (chArray[i] == '8')) || (chArray[i] == '9')))
                {
                    str = str + chArray[i].ToString();
                }
            }
            if (!str.StartsWith("90"))
            {
                if (str.StartsWith("0"))
                {
                    str = "9" + str;
                }
                else
                {
                    str = "90" + str;
                }
            }
            if ((str.Length != 12) && (str.Length > 12))
            {
                str = str.Substring(0, 12);
            }
            return str;
        }
    }
}

