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
        
        public MineCraftController(Form view)
        {
            PlaceCubesRandomly(view, 50);
            // todo: add in perloin noise function for placing cubes
        }

        /// <summary>
        /// Places the number of specified cubes randomly through out the view.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="numOfCubes"></param>
        private void PlaceCubesRandomly(Form view, int numOfCubes)
        {
            Cubes = new List<Cube>();
            for (int i = 0; i < numOfCubes; i++)
            {
                Cubes.Add(new Cube(new Point(rand.Next(0, view.Width), rand.Next(0, view.Height)),
                    Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)), 20, 20, 20));
            }
        }

        /// <summary>
        /// Paints all of the game objects to the given view using the given graphics.
        /// </summary>
        /// <param name="view">Form to use in 2d calculations.</param>
        /// <param name="graphics">Graphics to use when painting objects.</param>
        public void Paint(Form view, Graphics graphics)
        {
            for (int i = 0; i < Cubes.Count; i++)
            {
                Cubes[i].Paint(view, graphics);
            }
            //c.Paint(view, graphics);
        }

        /// <summary>
        /// Translate all objects by the given values.
        /// </summary>
        /// <param name="view">Form to use in 2d calculations.</param>
        /// <param name="x">X axis translation.</param>
        /// <param name="y">Y axis translation.</param>
        /// <param name="z">Z axis translation.</param>
        public void Translate(Form view, int x, int y, int z = 0)
        {
            foreach (var cube in Cubes)
            {
                view.Invalidate(cube.GetRect(view));
                cube.Translate(x, y, z);
                view.Invalidate(cube.GetRect(view));
            }
            //view.Invalidate(c.GetRect(view));
            //c.Translate(x, y, z);
            //view.Invalidate(c.GetRect(view));
        }

        /// <summary>
        /// Translates game objects randomly.
        /// </summary>
        /// <param name="view">Form to be used in 2d calculations.</param>
        public void TranslateCubesRandomly(Form view)
        {
            for (int i = 0; i < Cubes.Count; i++)
            {
                view.Invalidate(Cubes[i].GetRect(view));
                Cubes[i].Translate(rand.Next(-9, 10), rand.Next(-9, 10), rand.Next(-9, 10));
                view.Invalidate(Cubes[i].GetRect(view));
            }
        }
    }
}
