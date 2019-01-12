using System.Drawing;

namespace MineCraftShared
{
    public interface ICubeData
    {
        Vector Point { get; set; }
        Placement Place { get; set; }
    }

    /// <summary>
    /// The place of the point.  Structured by 
    /// First letter being (F)irst/(B)ack
    /// Second letter being (T)op/(B)ottom
    /// Third letter being (L)eft/(R)ight
    /// </summary>
    public enum Placement
    {
        FTL, FTR, FBL, FBR, BTL, BTR, BBL, BBR
    }
}