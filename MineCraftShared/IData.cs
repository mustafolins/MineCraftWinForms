using System.Drawing;

namespace MineCraftShared
{
    public interface IData
    {
        Point Point { get; set; }
        Placement Place { get; set; }
    }

    public enum Placement
    {
        FTL, FTR, FBL, FBR, BTL, BTR, BBL, BBR
    }
}