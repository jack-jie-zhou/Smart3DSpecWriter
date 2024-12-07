
namespace Smart3DSpecWriter.PipeBranchTable
{
    public class PipeBranchRow
    {
        public double HeadSize { get; set; }
        public double BranchSize { get; set; }
        //public string AngleLow { get; set; }
        //public string AngleHigh { get; set; }
        //public string ShortCode { get; set; }
        //public string ShortCode2 { get; set; }
        //public string ShortCode3 { get; set; }

        public PipeBranchAngle Angle { get; set; }
        public PipeBranchShortCode ShortCode { get; set; }
        public string HeadUnitType { get; set; }
        public string BranchUnitType { get; set; }
    }
}
