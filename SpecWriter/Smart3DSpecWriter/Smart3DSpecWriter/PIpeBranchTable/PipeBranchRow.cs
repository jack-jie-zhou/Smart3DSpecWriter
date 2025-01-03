
namespace Smart3DSpecWriter.PipeBranchTable
{
    /// <summary>
    /// A row in branch table sheet
    /// </summary>
    public class PipeBranchRow
    {
        /// <summary>
        /// head size
        /// </summary>
        public double HeadSize { get; set; }
        /// <summary>
        /// branch size
        /// </summary>
        public double BranchSize { get; set; }
        //public string AngleLow { get; set; }
        //public string AngleHigh { get; set; }
        //public string ShortCode { get; set; }
        //public string ShortCode2 { get; set; }
        //public string ShortCode3 { get; set; }

        /// <summary>
        /// angle of the branch
        /// </summary>
        public PipeBranchAngle Angle { get; set; }
        /// <summary>
        /// short code of the branch
        /// </summary>
        public PipeBranchShortCode ShortCode { get; set; }
        /// <summary>
        /// head unit (in, mm)
        /// </summary>
        public string HeadUnitType { get; set; }
        /// <summary>
        /// branch unit (in, mm)
        /// </summary>
        public string BranchUnitType { get; set; }
    }
}
