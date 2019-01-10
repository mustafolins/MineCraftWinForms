using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineCraftShared
{
    public class Object3d : IMatrix
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int Depth { get; set; }

        public int Scale { get; set; }

        public Data[,,] Data { get; set; }

        public Point Location { get; set; }

        public Object3d(int width, int length, int depth, int scale = 1)
        {
            Width = width;
            Length = length;
            Depth = depth;

            Scale = scale;

            Location = new Point { X = 50, Y = 50 };

            Data = new Data[width, length, depth];
            SetSolidColor(Color.Black);
        }

        public Rectangle GetRect()
        {
            var tempRect = new Rectangle(new Point(Location.X - 5, Location.Y - 5), new Size(Width + 10, Length + 10));
            return tempRect;
        }

        public void Translate(int x, int y)
        {
            Location = new Point(Location.X + x, Location.Y + y);
        }

        public void SetSolidColor(Color color)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    for (int k = 0; k < Depth; k++)
                    {
                        Data[i, j, k] = new Data { Color = color };
                    }
                }
            }
        }

        public void Paint(Graphics g)
        {
            //for (int i = 0; i < Width; i++)
            //{
            //    for (int j = 0; j < Length; j++)
            //    {
            //        for (int k = 0; k < Depth; k++)
            //        {
            //            // todo: maybe not do it one pixel at a time?
            //            g.DrawEllipse(new Pen(Data[i, j, k].Color), Location.X + i, Location.Y + j, 1 / Scale, 1 / Scale);
            //        }
            //    }
            //}
            g.DrawRectangle(new Pen(Data[0, 0, 0].Color), Location.X, Location.Y, Width / Scale, Length / Scale);
        }
    }
}
