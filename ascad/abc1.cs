namespace ascad
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization.Formatters.Binary;

    public class abc1 : IDisposable
    {
        public void crmayarac()
        {
            new Ayarlar().ShowDialog();
        }

        public string crmdatabasead()
        {
            string databasead = "";
            try
            {
                FileStream serializationStream = new FileStream(@".\firms.dat", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                abc1.bagbilgi bagbilgi = (abc1.bagbilgi) formatter.Deserialize(serializationStream);
                serializationStream.Close();
                databasead = bagbilgi.databasead;
            }
            catch (Exception)
            {
            }
            return databasead;
        }

        public string crmdosyolu()
        {
            string dosyayol = "";
            try
            {
                FileStream serializationStream = new FileStream(@".\firms.dat", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                abc1.bagbilgi bagbilgi = (abc1.bagbilgi) formatter.Deserialize(serializationStream);
                serializationStream.Close();
                dosyayol = bagbilgi.dosyayol;
            }
            catch (Exception)
            {
            }
            return dosyayol;
        }

        public string crmdtbase()
        {
            string str = "";
            try
            {
                str = "Server=78.188.177.111;Database=szgbakdeneme;uid=szgcrm;Pwd=Qwrdobj!865;default command timeout=120;CharSet=utf8;";
            }
            catch (Exception)
            {
            }
            return str;
        }

        public DataTable crmdtta(string negeldi, string acikla)
        {
            negeldi = negeldi.Replace("[", "'");
            negeldi = negeldi.Replace("]", "'");
            negeldi = negeldi.Replace("Date()", "curdate()");
            DataTable dataTable = new DataTable();
            MySqlConnection connection = new MySqlConnection(this.crmdtbase());
            try
            {
                new MySqlDataAdapter(negeldi, connection).Fill(dataTable);
            }
            catch (Exception exception)
            {
                if ((exception.Message == "Unable to connect to any of the specified MySQL hosts.") && File.Exists(@"C:\SZG\Server\bin\mysqld-nt.exe"))
                {
                    Process.Start(@"C:\SZG\Server\bin\mysqld-nt.exe");
                }
                return dataTable;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public bool crmoleupdate(string komut, string isinacikla)
        {
            bool flag = false;
            komut = komut.Replace("delete * ", "delete ");
            MySqlConnection connection = new MySqlConnection(this.crmdtbase());
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
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public string crmserverad()
        {
            string icbag = "";
            try
            {
                FileStream serializationStream = new FileStream(@".\firms.dat", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                abc1.bagbilgi bagbilgi = (abc1.bagbilgi) formatter.Deserialize(serializationStream);
                serializationStream.Close();
                icbag = bagbilgi.icbag;
            }
            catch (Exception)
            {
            }
            return icbag;
        }

        public void crmyardimci(string vidid)
        {
            new yardimvideo { videone = vidid }.Show();
        }

        public string dcyap(string gel)
        {
            string str = string.Empty;
            char[] chArray = gel.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == Convert.ToChar("."))
                {
                    str = str + ".";
                }
                else if (chArray[i] == Convert.ToChar(","))
                {
                    str = str + ".";
                }
                else
                {
                    str = str + chArray[i].ToString();
                }
            }
            return str;
        }

        public string dilci(int no, DataTable datasi)
        {
            string str = "";
            str = datasi.Select("number=" + no)[0][0].ToString();
            if (datasi.Select("number=" + no)[0][0].ToString() == "")
            {
                str = "Boş - Null";
            }
            return str;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string dtbase()
        {
            string str = "";
            try
            {
                str = "Server=localhost;Database=ascad;uid=szgcrm;Pwd=Qwrdobj!865;";
            }
            catch (Exception)
            {
            }
            return str;
        }

        public DataTable dtta(string negeldi, string acikla)
        {
            negeldi = negeldi.Replace("[", "");
            negeldi = negeldi.Replace("]", "");
            negeldi = negeldi.Replace("$", "");
            DataTable dataTable = new DataTable();
            MySqlConnection connection = new MySqlConnection(this.dtbase());
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

        public string hucredeupdate(string komutbas, string kolontipi, string kolonadi, string deger, string gotu)
        {
            string str = "";
            if ((kolontipi == "System.Boolean") || (kolontipi == "System.UInt64"))
            {
                string[] textArray1 = new string[] { komutbas, kolonadi, "=", deger, gotu };
                str = string.Concat(textArray1);
            }
            if (kolontipi == "System.String")
            {
                string[] textArray2 = new string[] { komutbas, kolonadi, "='", deger, "'", gotu };
                str = string.Concat(textArray2);
            }
            if (kolontipi == "System.DateTime")
            {
                string[] textArray3 = new string[] { komutbas, kolonadi, "=", this.tarihsaatyap(Convert.ToDateTime(deger)), gotu };
                str = string.Concat(textArray3);
            }
            if (kolontipi == "System.Int32")
            {
                string[] textArray4 = new string[] { komutbas, kolonadi, "=", deger, gotu };
                str = string.Concat(textArray4);
            }
            if ((kolontipi == "System.Decimal") || (kolontipi == "System.Double"))
            {
                string[] textArray5 = new string[] { komutbas, kolonadi, "=", this.dcyap(deger), gotu };
                str = string.Concat(textArray5);
            }
            return str;
        }

        public bool oleupdate(string komut, string isinacikla)
        {
            bool flag = false;
            komut = komut.Replace("delete * ", "delete ");
            komut = komut.Replace("[", "");
            komut = komut.Replace("]", "");
            komut = komut.Replace("$", "");
            MySqlConnection connection = new MySqlConnection(this.dtbase());
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

        public void SetGirisValue(string ParamName, string ParamValue, string LiftNumber)
        {
            MySqlConnection connection = new MySqlConnection(this.dtbase());
            try
            {
                string[] textArray1 = new string[] { "update Giris", LiftNumber, " set ParamValue='", ParamValue, "' where ParamName='", ParamName, "'" };
                MySqlCommand command = new MySqlCommand(string.Concat(textArray1), connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            connection.Close();
        }

        public void SetNumValue(string ParamName, string ParamValue, string LiftNumber)
        {
            MySqlConnection connection = new MySqlConnection(this.dtbase());
            try
            {
                string[] textArray1 = new string[] { "update Num", LiftNumber, " set ParamValue='", ParamValue, "' where ParamName='", ParamName, "'" };
                MySqlCommand command = new MySqlCommand(string.Concat(textArray1), connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            connection.Close();
        }

        public void SetRayFark(string LiftNumber)
        {
            MySqlConnection connection = new MySqlConnection(this.dtbase());
            try
            {
                connection.Open();
                new MySqlCommand("update Num" + LiftNumber + " set ParamValue='100' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='DA'", connection).ExecuteNonQuery();
                new MySqlCommand("update Num" + LiftNumber + " set ParamValue='200' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='MDDUZ'", connection).ExecuteNonQuery();
                new MySqlCommand("update Num" + LiftNumber + " set ParamValue='0' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='MDCAP'", connection).ExecuteNonQuery();
                new MySqlCommand("update Num" + LiftNumber + " set ParamValue='-200' where ParamName='KabinAgrEksenFark' and TipKodu='EA' and TahrikKodu='MDCAP'", connection).ExecuteNonQuery();
                new MySqlCommand("update Num" + LiftNumber + " set ParamValue='100' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='YA'", connection).ExecuteNonQuery();
                new MySqlCommand("update Num" + LiftNumber + " set ParamValue='0' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='SD'", connection).ExecuteNonQuery();
                new MySqlCommand("update Num" + LiftNumber + " set ParamValue='0' where ParamName='KabinRayFark' and TipKodu='EA' and TahrikKodu='RAMD'", connection).ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            connection.Close();
        }

        public string tarihsaatyap(DateTime tar)
        {
            string[] textArray1 = new string[] { "'", tar.Year.ToString(), "/", tar.Month.ToString(), "/", tar.Day.ToString(), " ", tar.Hour.ToString(), ":", tar.Minute.ToString(), ":", tar.Second.ToString(), "'" };
            return string.Concat(textArray1);
        }

        public string tarihyap(DateTime tar)
        {
            string[] textArray1 = new string[] { "'", tar.Year.ToString(), "/", tar.Month.ToString(), "/", tar.Day.ToString(), "'" };
            return string.Concat(textArray1);
        }

        public string tekstringveri(string komut)
        {
            string str = "";
            MySqlConnection connection = new MySqlConnection(this.dtbase());
            try
            {
                MySqlCommand command = new MySqlCommand(komut, connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        str = reader[0].ToString();
                    }
                }
                return str;
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return str;
        }

        public string turlestir(string gelen)
        {
            string str = "";
            str = gelen.ToUpper();
            char[] chArray = new char[] { 'Ş', 'İ', '\x00dc', 'Ğ', '\x00d6', '\x00c7' };
            char[] chArray2 = new char[] { 'S', 'I', 'U', 'G', 'O', 'C' };
            for (int i = 0; i < chArray.Length; i++)
            {
                str = str.Replace(chArray[i], chArray2[i]);
            }
            return str.Replace(" ", "_");
        }

        public void upexcel(string nedegisecek, string deger, string LiftNumber)
        {
            MySqlConnection connection = new MySqlConnection(this.dtbase());
            try
            {
                string[] textArray1 = new string[] { "update Num", LiftNumber, " set ParamValue='", deger, "' where ParamName='", nedegisecek, "'" };
                MySqlCommand command = new MySqlCommand(string.Concat(textArray1), connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            connection.Close();
        }

        public void upexcel(string nedegisecek, string deger, string LiftNumber, structTahrik Tahrik)
        {
            MySqlConnection connection = new MySqlConnection(this.dtbase());
            try
            {
                string[] textArray1 = new string[] { "update Num", LiftNumber, " set ParamValue='", deger, "' where ParamName='", nedegisecek, "' and (TipKodu='", Tahrik.TipKodu, "' or TipKodu='TEMEL') and (TahrikKodu='", Tahrik.TahrikKodu, "' or TahrikKodu='TEMEL')  and (YonKodu='", Tahrik.YonKodu, "' or YonKodu='TEMEL')" };
                MySqlCommand command = new MySqlCommand(string.Concat(textArray1), connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            connection.Close();
        }

        public void UpExcelBlockName(string nedegisecek, string deger, string LiftNumber)
        {
            MySqlConnection connection = new MySqlConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\ASCADDB.xls;Extended Properties=Excel 8.0");
            try
            {
                string[] textArray1 = new string[] { "update mainblocks set BlkInsName='", deger, "' where bmblockname='", nedegisecek, "'" };
                MySqlCommand command = new MySqlCommand(string.Concat(textArray1), connection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            connection.Close();
        }

        [Serializable]
        public class bagbilgi
        {
            [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string <databasead>k__BackingField;
            [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string <disbag>k__BackingField;
            [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string <dosyayol>k__BackingField;
            [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string <dtblocation>k__BackingField;
            [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string <dtbusrad>k__BackingField;
            [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string <dtbusrpwd>k__BackingField;
            [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string <icbag>k__BackingField;

            public string databasead { get; set; }

            public string disbag { get; set; }

            public string dosyayol { get; set; }

            public string dtblocation { get; set; }

            public string dtbusrad { get; set; }

            public string dtbusrpwd { get; set; }

            public string icbag { get; set; }
        }
    }
}

