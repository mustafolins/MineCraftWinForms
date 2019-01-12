using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineCraftShared
{
    public class MineCraftController
    {
        Cube[] cubes;
        Random rand = new Random();

        Cube c = new Cube(new Point(300, 300), Color.Green, 10, 10, 10);

        public MineCraftController(Form view)
        {
            cubes = new Cube[10];
            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i] = new Cube(new Point(rand.Next(0, view.Width), rand.Next(0, view.Height)),
                    Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)), 10, 10, 10);
            }
        }

        public void Paint(Form view, Graphics graphics)
        {
            //for (int i = 0; i < cubes.Length; i++)
            //{
            //    cubes[i].Paint(this, graphics);
            //}
            c.Paint(view, graphics);
        }

        public void Translate(Form view, int x, int y, int z = 0)
        {
            view.Invalidate(c.GetRect(view));
            c.Translate(x, y, z);
            view.Invalidate(c.GetRect(view));
        }

        public void TranslateCubesRandomly(Form view)
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                view.Invalidate(cubes[i].GetRect(view));
                cubes[i].Translate(rand.Next(-9, 10), rand.Next(-9, 10), rand.Next(-9, 10));
                view.Invalidate(cubes[i].GetRect(view));
            }
        }
    }
}
