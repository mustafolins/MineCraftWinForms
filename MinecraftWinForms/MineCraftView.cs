using MineCraftShared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftWinForms
{
    public partial class MineCraftView : Form
    {
        public MineCraftView()
        {
            InitializeComponent();
        }

        Cube[] cubes;
        Random rand = new Random();

        private void MineCraftView_Load(object sender, EventArgs e)
        {
            cubes = new Cube[10];
            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i] = new Cube(new Point(rand.Next(0, Width), rand.Next(0, Height)), 
                    Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)), 10, 10, 10); 
            }
        }

        private void MineCraftView_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i].Paint(e.Graphics); 
            }
        }

        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            TranslateCubesRandomly();
        }

        private void TranslateCubesRandomly()
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                Invalidate(cubes[i].GetRect());
                cubes[i].Translate(rand.Next(-9, 10), rand.Next(-9, 10));
                Invalidate(cubes[i].GetRect()); 
            }
        }
    }
}
