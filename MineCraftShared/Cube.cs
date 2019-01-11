using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineCraftShared
{
    enum Side
    {
        FRONT, LEFT, RIGHT, TOP, BOTTOM, BACK
    }

    public class Cube : ICube
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        public int Scale { get; set; }

        /// <summary>
        /// Data Points
        /// </summary>
        public Data[] Points { get; set; }

        public Point Location { get; set; }
        public Rotation Rot { get; set; }
        public Color Color { get; set; }

        public Cube(Point point, Color color, int width, int height, int depth, int scale = 1)
        {
            Width = width;
            Height = height;
            Depth = depth;

            Scale = scale;

            Points = new Data[]
            {
                // todo: have some way of specifying depth with the points
                new Data{ Point = new Point(0, 0), Place = Placement.FTL },    // front top left
                new Data{ Point = new Point(Width, 0), Place = Placement.FTR },    // front top right
                new Data{ Point = new Point(0, Height), Place = Placement.FBL },    // front bottom left
                new Data{ Point = new Point(Width, Height), Place = Placement.FBR },    // front bottom right
                // second side
                new Data{ Point = new Point(0, 0), Place = Placement.BTL },    // bottom top left
                new Data{ Point = new Point(Width, 0), Place = Placement.BTR },    // bottom top right
                new Data{ Point = new Point(0, Height), Place = Placement.BBL },    // bottom bottom left
                new Data{ Point = new Point(Width, Height), Place = Placement.BBR }     // bottom bottom right
            };

            SetLocation(point.X, point.Y);
            Rot = new Rotation { X = 0, Y = 0, Z = 0 };

            Color = color;
            SetColor(Color);
        }

        private void SetLocation(int x, int y)
        {
            foreach (var point in Points)
            {
                point.Point = new Point { X = point.Point.X + x, Y = point.Point.Y + y };
            }
            Location = new Point { X = Location.X + x, Y = Location.Y + y };
        }

        public Rectangle GetRect()
        {
            var tempRect = new Rectangle(new Point(Location.X - 5, Location.Y - 5), new Size(Width + 10, Height + 10));
            return tempRect;
        }

        public void Translate(int x, int y)
        {
            SetLocation(x, y);
        }

        public void SetColor(Color color)
        {
            this.Color = color;
        }

        public void Paint(Graphics g)
        {
            // todo: find way of displaying all sides
            DrawSide(g, Side.FRONT);
            DrawSide(g, Side.BACK);
            DrawSide(g, Side.LEFT);
            DrawSide(g, Side.RIGHT);
        }

        private void DrawSide(Graphics g, Side side)
        {
            var points = new Point[4];
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
            g.FillPolygon(new SolidBrush(Color), points);
        }

        #region Get Sides

        private Point[] GetBackSide()
        {
            var points = new Point[]
            {
                Points.FirstOrDefault(d => d.Place == Placement.BTL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BTR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BBR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BBL).Point
            };
            return points;
        }

        private Point[] GetRightSide()
        {
            var points = new Point[]
            {
                Points.FirstOrDefault(d => d.Place == Placement.FTR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.FBR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BBR).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BTR).Point
            };
            return points;
        }

        private Point[] GetLeftSide()
        {
            var points = new Point[]
            {
                Points.FirstOrDefault(d => d.Place == Placement.FTL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.FBL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BBL).Point,
                Points.FirstOrDefault(d => d.Place == Placement.BTL).Point
            };
            return points;
        }

        private Point[] GetFrontSide()
        {
            var points = new Point[]
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
