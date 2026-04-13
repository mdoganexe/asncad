namespace ascad
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class yazilar
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <acklama>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <nedurki>k__BackingField;

        public yazilar()
        {
        }

        private yazilar(string ackla, object nedur)
        {
            this.acklama = ackla;
            this.nedurki = (string) nedur;
        }

        public static void listele(IList List)
        {
            abc1 abc = new abc1();
            MySqlConnection connection = new MySqlConnection(abc.dtbase());
            connection.Open();
            MySqlCommand command = new MySqlCommand("select Acklama,Objesi from lejant", connection);
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        List.Add(new yazilar(reader[0].ToString(), reader[1]));
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
        }

        public override string ToString() => 
            this.acklama;

        public string acklama { get; set; }

        public string nedurki { get; set; }
    }
}

