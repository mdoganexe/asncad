namespace ascad
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class vtLift
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <BlkInsName>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<BlkPar> <BlkList>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <BlkName>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<ParamList> <BlkParamList>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <ParaName>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <XData>k__BackingField;

        public vtLift()
        {
            this.BlkList = new List<BlkPar>();
            this.BlkParamList = new List<ParamList>();
        }

        public string BlkInsName { get; set; }

        public List<BlkPar> BlkList { get; set; }

        public string BlkName { get; set; }

        public List<ParamList> BlkParamList { get; set; }

        public string ParaName { get; set; }

        public string XData { get; set; }
    }
}

