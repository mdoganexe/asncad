namespace ascad
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class Giris
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <AcilmaGenisligi>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BlkPar <DisKapiBlk>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <DisKapiTip>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <EsikDer>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <EsikGen>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BlkPar <IcKapiBlk>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <IcKapiTip>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <KapiArasi>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <KapiGen>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <KasaKalin>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <KizakKalin>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <ToplamKalin>k__BackingField;

        private void hes()
        {
            this.KapiArasi = this.EsikDer + this.EsikGen;
        }

        public int AcilmaGenisligi { get; set; }

        public BlkPar DisKapiBlk { get; set; }

        public string DisKapiTip { get; set; }

        public int EsikDer { get; set; }

        public int EsikGen { get; set; }

        public BlkPar IcKapiBlk { get; set; }

        public string IcKapiTip { get; set; }

        public int KapiArasi { get; set; }

        public int KapiGen { get; set; }

        public int KasaKalin { get; set; }

        public int KizakKalin { get; set; }

        public int ToplamKalin { get; set; }
    }
}

