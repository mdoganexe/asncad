using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;

namespace ascad
{
	public class yazilar
	{
		public string acklama
		{
			get;
			set;
		}

		public string nedurki
		{
			get;
			set;
		}

		public yazilar()
		{
		}

		private yazilar(string ackla, object nedur)
		{
			this.acklama = ackla;
			this.nedurki = (string)nedur;
		}

		public static void listele(IList List)
		{
			abc1 abc = new abc1();
			MySqlConnection mySqlConnection = new MySqlConnection(abc.dtbase());
			mySqlConnection.Open();
			MySqlCommand mySqlCommand = new MySqlCommand("select Acklama,Objesi from lejant", mySqlConnection);
			try
			{
				bool flag = mySqlCommand.get_Connection().State == ConnectionState.Closed;
				if (flag)
				{
					mySqlCommand.get_Connection().Open();
				}
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool hasRows = mySqlDataReader.HasRows;
				if (hasRows)
				{
					while (mySqlDataReader.Read())
					{
						List.Add(new yazilar(mySqlDataReader[0].ToString(), mySqlDataReader[1]));
					}
				}
				mySqlDataReader.Close();
			}
			catch (Exception)
			{
			}
			finally
			{
				mySqlConnection.Close();
			}
		}

		public override string ToString()
		{
			return this.acklama;
		}
	}
}
