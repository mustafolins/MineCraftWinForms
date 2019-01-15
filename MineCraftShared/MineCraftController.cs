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
    /// Controller for handling the game objects.
    /// </summary>
    public class MineCraftController
    {
        Random rand = new Random();

        public List<Cube> Cubes { get; set; }

        public Form View { get; set; }

        public MineCraftController(Form view)
        {
            View = view;
            //PlaceCubesRandomly(view, 50);

            Noise(50, 20);
        }

        private void Noise(int numOfCubes, int sideLength)
        {
            Cubes = new List<Cube>();
            for (int i = 0; i < View.Width / numOfCubes; i++)
            {
                for (int j = 0; j < View.Height / numOfCubes / rand.Next(1, 5); j++)
                {
                    for (int k = 0; k < View.Width / numOfCubes / rand.Next(1, 5); k++)
                    {
                        Cubes.Add(new Cube(new Vector(i * sideLength, View.Height - ((j * sideLength) + View.Height / 2), k * sideLength),
                                    Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)), sideLength, sideLength, sideLength)); 
                    }
                }
            }
        }

        /// <summary>
        /// Places the number of specified cubes randomly through out the view.
        /// </summary>
        /// <param name="numOfCubes"></param>
        private void PlaceCubesRandomly(int numOfCubes)
        {
            Cubes = new List<Cube>();
            for (int i = 0; i < numOfCubes; i++)
            {
                Cubes.Add(new Cube(new Vector(rand.Next(0, View.Width), rand.Next(0, View.Height), 0),
                    Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)), 20, 20, 20));
            }
        }

        /// <summary>
        /// Paints all of the game objects to the given view using the given graphics.
        /// </summary>
        /// <param name="size">Size to use in 2d calculations.</param>
        /// <param name="graphics">Graphics to use when painting objects.</param>
        public void Paint(Graphics graphics)
        {
            // todo: sorting not 100% fix this
            var tempList = (from cube in Cubes
                           orderby cube.ActualDepth(), cube.ActualX(), cube.ActualY()
                           select cube).ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i].InFieldOfView(View.Size))
                {
                    tempList[i].Paint(View.Size, graphics);
                }
            }
            //c.Paint(view, graphics);
        }

        /// <summary>
        /// Translate all objects by the given values.
        /// </summary>
        /// <param name="x">X axis translation.</param>
        /// <param name="y">Y axis translation.</param>
        /// <param name="z">Z axis translation.</param>
        public void Translate(int x, int y, int z = 0)
        {
            foreach (var cube in Cubes)
            {
                View.Invalidate(cube.GetRect(View.Size));
                cube.Translate(x, y, z);
                View.Invalidate(cube.GetRect(View.Size));
            }
        }

        public void Rotate(int x, int y, int z)
        {
            foreach (var cube in Cubes)
            {
                cube.Rotate(x, y, z);
            }
            View.Invalidate();
        }

        /// <summary>
        /// Translates game objects randomly.
        /// </summary>
        /// <param name="view">Form to be used in 2d calculations.</param>
        public void TranslateCubesRandomly()
        {
            for (int i = 0; i < Cubes.Count; i++)
            {
                View.Invalidate(Cubes[i].GetRect(View.Size));
                Cubes[i].Translate(rand.Next(-9, 10), rand.Next(-9, 10), rand.Next(-9, 10));
                View.Invalidate(Cubes[i].GetRect(View.Size));
            }
        }
    }
}
