using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineCraftShared
{
    /// <summary>
    /// Cube data class used for keeping track of a vector and the placement of the point on the cube.
    /// </summary>
    [DebuggerDisplay("X={Point.X}; Y={Point.Y}; Z={Point.Z}; Place={Place}")]
    public class CubeData : ICubeData
    {
        public Vector Point { get; set; }
        public Placement Place { get; set; }
    }
}
