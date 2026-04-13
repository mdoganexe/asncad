namespace ascad
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class vtGroup : vtLift
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_AgirlikBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_AgrRayBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_AgrUstBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_AgrUstKasnak>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_CaprazBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_EmniyetKorkulukBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_HAEksenBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_HASemerBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_KabinAltKasnakBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_KabinBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_KabinRayBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_KapiBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_KuyuBlok>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtLift <_SinirBlok>k__BackingField;
        public List<vtLift> vtMyLift = new List<vtLift>();

        public vtGroup()
        {
            this.vtMyLift = new List<vtLift>();
        }

        protected vtLift _AgirlikBlok { get; set; }

        protected vtLift _AgrRayBlok { get; set; }

        protected vtLift _AgrUstBlok { get; set; }

        protected vtLift _AgrUstKasnak { get; set; }

        protected vtLift _CaprazBlok { get; set; }

        protected vtLift _EmniyetKorkulukBlok { get; set; }

        protected vtLift _HAEksenBlok { get; set; }

        protected vtLift _HASemerBlok { get; set; }

        protected vtLift _KabinAltKasnakBlok { get; set; }

        protected vtLift _KabinBlok { get; set; }

        protected vtLift _KabinRayBlok { get; set; }

        protected vtLift _KapiBlok { get; set; }

        protected vtLift _KuyuBlok { get; set; }

        protected vtLift _SinirBlok { get; set; }

        public vtLift AgirlikBlok
        {
            get => 
                this._AgirlikBlok;
            set
            {
                this._AgirlikBlok = value;
                this.vtMyLift.Add(this._AgirlikBlok);
            }
        }

        public vtLift AgrRayBlok
        {
            get => 
                this._AgrRayBlok;
            set
            {
                this._AgrRayBlok = value;
                this.vtMyLift.Add(this._AgrRayBlok);
            }
        }

        public vtLift AgrUstBlok
        {
            get => 
                this._AgrUstBlok;
            set
            {
                this._AgrUstBlok = value;
                this.vtMyLift.Add(this._AgrUstBlok);
            }
        }

        public vtLift AgrUstKasnak
        {
            get => 
                this._AgrUstKasnak;
            set
            {
                this._AgrUstKasnak = value;
                this.vtMyLift.Add(this._AgrUstKasnak);
            }
        }

        public vtLift CaprazBlok
        {
            get => 
                this._CaprazBlok;
            set
            {
                this._CaprazBlok = value;
                this.vtMyLift.Add(this._CaprazBlok);
            }
        }

        public vtLift EmniyetKorkulukBlok
        {
            get => 
                this._EmniyetKorkulukBlok;
            set
            {
                this._EmniyetKorkulukBlok = value;
                this.vtMyLift.Add(this._EmniyetKorkulukBlok);
            }
        }

        public vtLift HAEksenBlok
        {
            get => 
                this._HAEksenBlok;
            set
            {
                this._HAEksenBlok = value;
                this.vtMyLift.Add(this._HAEksenBlok);
            }
        }

        public vtLift HASemerBlok
        {
            get => 
                this._HASemerBlok;
            set
            {
                this._HASemerBlok = value;
                this.vtMyLift.Add(this._HASemerBlok);
            }
        }

        public vtLift KabinAltKasnakBlok
        {
            get => 
                this._KabinAltKasnakBlok;
            set
            {
                this._KabinAltKasnakBlok = value;
                this.vtMyLift.Add(this._KabinAltKasnakBlok);
            }
        }

        public vtLift KabinBlok
        {
            get => 
                this._KabinBlok;
            set
            {
                this._KabinBlok = value;
                this.vtMyLift.Add(this._KabinBlok);
            }
        }

        public vtLift KabinRayBlok
        {
            get => 
                this._KabinRayBlok;
            set
            {
                this._KabinRayBlok = value;
                this.vtMyLift.Add(this._KabinRayBlok);
            }
        }

        public vtLift KapiBlok
        {
            get => 
                this._KapiBlok;
            set
            {
                this._KapiBlok = value;
                this.vtMyLift.Add(this._KapiBlok);
            }
        }

        public vtLift KuyuBlok
        {
            get => 
                this._KuyuBlok;
            set
            {
                this._KuyuBlok = value;
                this.vtMyLift.Add(this._KuyuBlok);
            }
        }

        public vtLift SinirBlok
        {
            get => 
                this._SinirBlok;
            set
            {
                this._SinirBlok = value;
                this.vtMyLift.Add(this._SinirBlok);
            }
        }
    }
}

