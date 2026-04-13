namespace ascad
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class clsCompleteLift
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <AraBolme>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <AsansorSayisi>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<clsMainLift> <Lift>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <ToplamKuyuDerinlik>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <ToplamKuyuGenislik>k__BackingField;

        public clsCompleteLift()
        {
            this.Lift = new List<clsMainLift>();
        }

        public int AraBolme { get; set; }

        public int AsansorSayisi { get; set; }

        public List<clsMainLift> Lift { get; set; }

        public int ToplamKuyuDerinlik { get; set; }

        public int ToplamKuyuGenislik { get; set; }
    }
}

