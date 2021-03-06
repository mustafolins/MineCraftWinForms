﻿using System;
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
    /// Cube data class used for keeping track of a vector and the placement of the point on the cube.
    /// </summary>
    [DebuggerDisplay("X={X}; Y={Y}; Z={Z}; Place={Place}")]
    public class CubeData : Vector, ICubeData
    {
        public Placement Place { get; set; }
        public Rotation Rot { get; set; }
        public Rotation GlobalRot { get; set; }

        public CubeData(Vector vector, Placement place)
        {
            Place = place;

            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;

            Rot = new Rotation();
            GlobalRot = new Rotation();
        }

        /// <summary>
        /// Gets the 2d location of this vector based on the views center.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Point Get2dLocation(Size size)
        {
            Point point = new Point();
            point = CalculateSlope(size, new Point { X = X + GlobalRot.Y + GlobalRot.Z / 2, Y = Y + GlobalRot.X + GlobalRot.Z / 2 });
            return new Point { X = point.X, Y = point.Y };
        }

        private Point CalculateSlope(Size size, Point point)
        {
            float width = size.Width * 0.5f, height = size.Height * 0.5f;

            var slope = (height - point.Y) / (width - point.X);

            var k = (Z / (Math.Sqrt((double)1 + slope * slope))) * (point.X < width ? -1 : 1);
            var offsetX = k * 1;
            var offsetY = k * slope;

            point = new Point { X = point.X + (int)Math.Round(offsetX), Y = point.Y + (int)Math.Round(offsetY) };
            return point;
        }

        public bool InFieldOfView(Size size)
        {
            var tempPoint = Get2dLocation(size);
            return tempPoint.X >= 0 && tempPoint.X < size.Width
                && tempPoint.Y >= 0 && tempPoint.Y < size.Height;
        }

        public int ActualDepth()
        {
            return Z + GlobalRot.Y;
        }

        public int ActualX()
        {
            return X + GlobalRot.Y + GlobalRot.Z / 2;
        }

        public int ActualY()
        {
            return Y + GlobalRot.X;
        }
    }
}
