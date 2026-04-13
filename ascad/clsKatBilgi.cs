namespace ascad
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class clsKatBilgi
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<string> <KatKot>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<string> <KatYuk>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <KuyuDibi>k__BackingField;

        public clsKatBilgi()
        {
            this.KatYuk = new List<string>();
            this.KatKot = new List<string>();
        }

        public List<string> KatKot { get; set; }

        public List<string> KatYuk { get; set; }

        public string KuyuDibi { get; set; }
    }
}

