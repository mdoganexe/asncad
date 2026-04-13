using System;

namespace ascad
{
	[Serializable]
	public class Giris
	{
		public int KapiGen
		{
			get;
			set;
		}

		public int AcilmaGenisligi
		{
			get;
			set;
		}

		public string IcKapiTip
		{
			get;
			set;
		}

		public string DisKapiTip
		{
			get;
			set;
		}

		public BlkPar DisKapiBlk
		{
			get;
			set;
		}

		public BlkPar IcKapiBlk
		{
			get;
			set;
		}

		public int KizakKalin
		{
			get;
			set;
		}

		public int KasaKalin
		{
			get;
			set;
		}

		public int ToplamKalin
		{
			get;
			set;
		}

		public int KapiArasi
		{
			get;
			set;
		}

		public int EsikGen
		{
			get;
			set;
		}

		public int EsikDer
		{
			get;
			set;
		}

		private void hes()
		{
			this.KapiArasi = this.EsikDer + this.EsikGen;
		}
	}
}
