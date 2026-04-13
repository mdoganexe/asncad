namespace ascad
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using ZwSoft.ZwCAD.Geometry;

    public class clsMainLift : clsCompleteLift
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <AnaTahrik>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Point3d <BasePoint>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private vtGroup <BlokGrup>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<ConsParList> <DimGrup>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Giris <Giris1>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <KuyuDer>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <KuyuGen>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int <LiftNum>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private structTablist <Tablist>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <TahrikTipi>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <TahrikYonu>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<ParamList> <VarGrup>k__BackingField;

        public clsMainLift()
        {
            this.VarGrup = new List<ParamList>();
            this.DimGrup = new List<ConsParList>();
            this.BasePoint = new Point3d();
        }

        public clsMainLift(int LiftNum, int KuyuGen, int KuyuDer, string TahrikYonu)
        {
            this.VarGrup = new List<ParamList>();
            this.DimGrup = new List<ConsParList>();
            this.LiftNum = LiftNum;
            this.KuyuGen = KuyuGen;
            this.KuyuDer = KuyuDer;
            this.TahrikYonu = TahrikYonu;
        }

        ~clsMainLift()
        {
            this.BasePoint = new Point3d();
        }

        public string AnaTahrik { get; set; }

        public Point3d BasePoint { get; set; }

        public vtGroup BlokGrup { get; set; }

        public List<ConsParList> DimGrup { get; set; }

        public Giris Giris1 { get; set; }

        public int KuyuDer { get; set; }

        public int KuyuGen { get; set; }

        public int LiftNum { get; set; }

        public structTablist Tablist { get; set; }

        public string TahrikTipi { get; set; }

        public string TahrikYonu { get; set; }

        public List<ParamList> VarGrup { get; set; }
    }
}

