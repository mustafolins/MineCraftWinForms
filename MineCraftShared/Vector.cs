using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineCraftShared
{
    /// <summary>
    /// A representation of a vector.
    /// </summary>
    [DebuggerDisplay("X={X}; Y={Y}; Z={Z}")]
    public class Vector : IVector, IComparable
    {
        public Vector()
        {
        }

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public int CompareTo(object obj)
        {
            if (this < (Vector)obj) return -1;
            if (this == (Vector)obj) return 0;
            if (this > (Vector)obj) return 1;
            return 1;
        }

        public override bool Equals(object obj)
        {
            var d = obj as Vector;
            return d != null &&
                   X == d.X &&
                   Y == d.Y &&
                   Z == d.Z;
        }

        public override int GetHashCode()
        {
            var hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Vector d1, Vector d2)
        {
            return (d1.X + d1.Y + d1.Z) == (d2.X + d2.Y + d2.Z);
        }

        public static bool operator !=(Vector d1, Vector d2)
        {
            return !(d1 == d2);
        }

        public static bool operator <(Vector d1, Vector d2) => (d1.X + d1.Y + d1.Z) < (d2.X + d2.Y + d2.Z);
        public static bool operator >(Vector d1, Vector d2) => (d2.X + d2.Y + d2.Z) < (d1.X + d1.Y + d1.Z);
        public static bool operator <=(Vector d1, Vector d2) => (d1.X + d1.Y + d1.Z) <= (d2.X + d2.Y + d2.Z);
        public static bool operator >=(Vector d1, Vector d2) => (d2.X + d2.Y + d2.Z) <= (d1.X + d1.Y + d1.Z);
    }
}
