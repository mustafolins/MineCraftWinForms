using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineCraftShared
{
    /// <summary>
    /// Enum used for specifying a cube's side.
    /// </summary>
    enum Side
    {
        FRONT, LEFT, RIGHT, TOP, BOTTOM, BACK
    }

    /// <summary>
    /// Class for creating/drawing a cube.
    /// </summary>
    public class Cube : ICube
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        public int Scale { get; set; }

        /// <summary>
        /// Data Points
        /// </summary>
        public CubeData[] Points { get; set; }

        public Point Location { get; set; }
        public Rotation Rot { get; set; }
        public Color Color { get; set; }

        public Cube(Point point, Color color, int width, int height, int depth, int scale = 1)
        {
            Width = width;
            Height = height;
            Depth = depth;

            Scale = scale;

            Points = new CubeData[]
            {
                new CubeData{ Point = new Vector(0, 0, 0), Place = Placement.FTL },    // front top left
                new CubeData{ Point = new Vector(Width, 0, 0), Place = Placement.FTR },    // front top right
                new CubeData{ Point = new Vector(0, Height, 0), Place = Placement.FBL },    // front bottom left
                new CubeData{ Point = new Vector(Width, Height, 0), Place = Placement.FBR },    // front bottom right
                // second side
                new CubeData{ Point = new Vector(0, 0, Depth), Place = Placement.BTL },    // back top left
                new CubeData{ Point = new Vector(Width, 0, Depth), Place = Placement.BTR },    // back top right
                new CubeData{ Point = new Vector(0, Height, Depth), Place = Placement.BBL },    // back bottom left
                new CubeData{ Point = new Vector(Width, Height, Depth), Place = Placement.BBR }     // back bottom right
            };

            SetLocation(point.X, point.Y, 0);
            Rot = new Rotation { X = 0, Y = 0, Z = 0 };

            Color = color;
            SetColor(Color);
        }

        /// <summary>
        /// Sets the location of the cube by incrementing all of the cube's points.
        /// </summary>
        /// <param name="x">X axis incrementation.</param>
        /// <param name="y">Y axis incrementation.</param>
        /// <param name="z">Z axis incrementation.</param>
        private void SetLocation(int x, int y, int z)
        {
            foreach (var dataPoint in Points)
            {
                dataPoint.Point = new Vector { X = dataPoint.Point.X + x, Y = dataPoint.Point.Y + y, Z = dataPoint.Point.Z + z };
            }
            Location = new Point { X = Location.X + x, Y = Location.Y + y };
        }

        /// <summary>
        /// Translates the cube by the give 3d coordinates.
        /// </summary>
        /// <param name="x">X axis translation.</param>
        /// <param name="y">Y axis translation.</param>
        /// <param name="z">Z axis translation.</param>
        public void Translate(int x, int y, int z = 0)
        {
            SetLocation(x, y, z);
        }

        /// <summary>
        /// Translates the cube by the given 3d point.
        /// </summary>
        /// <param name="point">The Point3d to translate the object by (used like a vector).</param>
        public void Translate(Vector point)
        {
            SetLocation(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// Gets the Rectangle of the cube of which is being used in paint calls.
        /// </summary>
        /// <param name="view"></param>
        /// <returns>The Rectangle containing the cube.</returns>
        public Rectangle GetRect(Form view)
        {
            var minPointX = Points.Min(p => p.Point.Get2dLocation(view).X);
            var minPointY = Points.Min(p => p.Point.Get2dLocation(view).Y);
            var maxPointX = Points.Max(p => p.Point.Get2dLocation(view).X);
            var maxPointY = Points.Max(p => p.Point.Get2dLocation(view).Y);
            var tempRect = new Rectangle(new Point(minPointX - 5, minPointY - 5),
                new Size(maxPointX - minPointX + 15, maxPointY - minPointY + 15));
            return tempRect;
        }

        /// <summary>
        /// Sets the color of the cube.
        /// </summary>
        /// <param name="color">The color to be used.</param>
        public void SetColor(Color color)
        {
            Color = color;
        }

        /// <summary>
        /// Paints the cube with all of it's sides.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="g"></param>
        public void Paint(Form view, Graphics g)
        {
            // todo: find way of displaying all sides
            // todo: find a way to draw sides in the correct order
            DrawSide(view, g, Side.FRONT);
            DrawSide(view, g, Side.BACK);
            DrawSide(view, g, Side.LEFT);
            DrawSide(view, g, Side.RIGHT);
        }

        /// <summary>
        /// Draws the given side.
        /// </summary>
        /// <param name="view">Form to draw use in 2d location calculations.</param>
        /// <param name="g">Graphics object to draw/fill with.</param>
        /// <param name="side">The side to get the points for drawing/filling from.</param>
        private void DrawSide(Form view, Graphics g, Side side)
        {
            var points = new Vector[4];
            switch (side)
            {
                case Side.FRONT:
                    points = GetFrontSide();
                    break;
                case Side.LEFT:
                    points = GetLeftSide();
                    break;
                case Side.RIGHT:
                    points = GetRightSide();
                    break;
                case Side.TOP:
                    break;
                case Side.BOTTOM:
                    break;
                case Side.BACK:
                    points = GetBackSide();
                    break;
                default:
                    break;
            }
            try
            {
                // draw outline
                g.DrawPolygon(new Pen(Color.FromArgb(Math.Abs(Color.R - 30), Math.Abs(Color.G - 30), Math.Abs(Color.B - 30))),
                                                    (from point in points
                                                     select point.Get2dLocation(view)).ToArray());
                // fill polygon
                g.FillPolygon(new SolidBrush(Color), (from point in points
                                                      select point.Get2dLocation(view)).ToArray());
            }
            catch (OverflowException of)
            {
                // todo: find out why this is happening
            }
        }

        #region Get Sides

        private Vector[] GetBackSide()
        {
            var points = new Vector[]
            {
                Points.FirstOrDefault(d => d.Place == Placement.BTL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BTR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BBR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BBL).Point
            };
            return points;
        }

        private Vector[] GetRightSide()
        {
            var points = new Vector[]
            {
                Points.FirstOrDefault(d => d.Place == Placement.FTR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.FBR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BBR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BTR).Point
            };
            return points;
        }

        private Vector[] GetLeftSide()
        {
            var points = new Vector[]
            {
                Points.FirstOrDefault(d => d.Place == Placement.FTL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.FBL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BBL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BTL).Point
            };
            return points;
        }

        private Vector[] GetFrontSide()
        {
            var points = new Vector[]
            {
                Points.FirstOrDefault(d => d.Place == Placement.FTL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.FTR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.FBR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.FBL).Point
            };
            return points;
        }

        #endregion Get Sides
    }
}
