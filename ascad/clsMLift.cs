namespace ascad
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using ZwSoft.ZwCAD.Geometry;

    public class clsMLift
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Point3d <BasePoint>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<structDimblk> <DimBlkList>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<ConsParList> <DimGrup>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private structKatBilgileri <KatBilgileri>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<string> <KatKot>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string[] <KatRumuz>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string[] <KatYuk>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <LiftNum>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double <Olcek>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <Pan>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private structTahrik <Tahrik>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<ParamList> <VarGrup>k__BackingField;
        public List<vtLift> BlokGrup = new List<vtLift>();
        public string KesitKodu;

        public clsMLift()
        {
            this.BlokGrup = new List<vtLift>();
            this.VarGrup = new List<ParamList>();
            this.DimGrup = new List<ConsParList>();
            this.DimBlkList = new List<structDimblk>();
            this.KatKot = new List<string>();
        }

        public Point3d BasePoint { get; set; }

        public List<structDimblk> DimBlkList { get; set; }

        public List<ConsParList> DimGrup { get; set; }

        public structKatBilgileri KatBilgileri { get; set; }

        public List<string> KatKot { get; set; }

        public string[] KatRumuz { get; set; }

        public string[] KatYuk { get; set; }

        public int LiftNum { get; set; }

        public double Olcek { get; set; }

        public string Pan { get; set; }

        public structTahrik Tahrik { get; set; }

        public List<ParamList> VarGrup { get; set; }
    }
}

