using System;
using System.Collections.Generic;

namespace ascad
{
	public class vtGroup : vtLift
	{
		public List<vtLift> vtMyLift = new List<vtLift>();

		protected vtLift _AgirlikBlok
		{
			get;
			set;
		}

		protected vtLift _AgrUstBlok
		{
			get;
			set;
		}

		protected vtLift _AgrRayBlok
		{
			get;
			set;
		}

		protected vtLift _KabinBlok
		{
			get;
			set;
		}

		protected vtLift _KabinRayBlok
		{
			get;
			set;
		}

		protected vtLift _KapiBlok
		{
			get;
			set;
		}

		protected vtLift _KuyuBlok
		{
			get;
			set;
		}

		protected vtLift _SinirBlok
		{
			get;
			set;
		}

		protected vtLift _AgrUstKasnak
		{
			get;
			set;
		}

		protected vtLift _KabinAltKasnakBlok
		{
			get;
			set;
		}

		protected vtLift _EmniyetKorkulukBlok
		{
			get;
			set;
		}

		protected vtLift _HASemerBlok
		{
			get;
			set;
		}

		protected vtLift _HAEksenBlok
		{
			get;
			set;
		}

		protected vtLift _CaprazBlok
		{
			get;
			set;
		}

		public vtLift CaprazBlok
		{
			get
			{
				return this._CaprazBlok;
			}
			set
			{
				this._CaprazBlok = value;
				this.vtMyLift.Add(this._CaprazBlok);
			}
		}

		public vtLift HASemerBlok
		{
			get
			{
				return this._HASemerBlok;
			}
			set
			{
				this._HASemerBlok = value;
				this.vtMyLift.Add(this._HASemerBlok);
			}
		}

		public vtLift HAEksenBlok
		{
			get
			{
				return this._HAEksenBlok;
			}
			set
			{
				this._HAEksenBlok = value;
				this.vtMyLift.Add(this._HAEksenBlok);
			}
		}

		public vtLift AgirlikBlok
		{
			get
			{
				return this._AgirlikBlok;
			}
			set
			{
				this._AgirlikBlok = value;
				this.vtMyLift.Add(this._AgirlikBlok);
			}
		}

		public vtLift AgrUstKasnak
		{
			get
			{
				return this._AgrUstKasnak;
			}
			set
			{
				this._AgrUstKasnak = value;
				this.vtMyLift.Add(this._AgrUstKasnak);
			}
		}

		public vtLift KabinAltKasnakBlok
		{
			get
			{
				return this._KabinAltKasnakBlok;
			}
			set
			{
				this._KabinAltKasnakBlok = value;
				this.vtMyLift.Add(this._KabinAltKasnakBlok);
			}
		}

		public vtLift AgrUstBlok
		{
			get
			{
				return this._AgrUstBlok;
			}
			set
			{
				this._AgrUstBlok = value;
				this.vtMyLift.Add(this._AgrUstBlok);
			}
		}

		public vtLift AgrRayBlok
		{
			get
			{
				return this._AgrRayBlok;
			}
			set
			{
				this._AgrRayBlok = value;
				this.vtMyLift.Add(this._AgrRayBlok);
			}
		}

		public vtLift KabinBlok
		{
			get
			{
				return this._KabinBlok;
			}
			set
			{
				this._KabinBlok = value;
				this.vtMyLift.Add(this._KabinBlok);
			}
		}

		public vtLift KabinRayBlok
		{
			get
			{
				return this._KabinRayBlok;
			}
			set
			{
				this._KabinRayBlok = value;
				this.vtMyLift.Add(this._KabinRayBlok);
			}
		}

		public vtLift KapiBlok
		{
			get
			{
				return this._KapiBlok;
			}
			set
			{
				this._KapiBlok = value;
				this.vtMyLift.Add(this._KapiBlok);
			}
		}

		public vtLift KuyuBlok
		{
			get
			{
				return this._KuyuBlok;
			}
			set
			{
				this._KuyuBlok = value;
				this.vtMyLift.Add(this._KuyuBlok);
			}
		}

		public vtLift SinirBlok
		{
			get
			{
				return this._SinirBlok;
			}
			set
			{
				this._SinirBlok = value;
				this.vtMyLift.Add(this._SinirBlok);
			}
		}

		public vtLift EmniyetKorkulukBlok
		{
			get
			{
				return this._EmniyetKorkulukBlok;
			}
			set
			{
				this._EmniyetKorkulukBlok = value;
				this.vtMyLift.Add(this._EmniyetKorkulukBlok);
			}
		}

		public vtGroup()
		{
			this.vtMyLift = new List<vtLift>();
		}
	}
}
