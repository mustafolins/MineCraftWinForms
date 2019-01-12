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

        public Keys Key { get; set; }
        public MineCraftController MineCraftController { get; set; }

        private void MineCraftView_Load(object sender, EventArgs e)
        {
            MineCraftController = new MineCraftController(this);
        }

        private void MineCraftView_Paint(object sender, PaintEventArgs e)
        {
            MineCraftController.Paint(this, e.Graphics);
        }

        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            //TranslateCubesRandomly();
            TranslateCube();
        }

        private void TranslateCube()
        {
            switch (Key)
            {
                case Keys.Left:
                case Keys.A:
                    MineCraftController.Translate(this, -5, 0);
                    break;
                case Keys.Up:
                case Keys.W:
                    MineCraftController.Translate(this, 0, -5);
                    break;
                case Keys.Down:
                case Keys.S:
                    MineCraftController.Translate(this, 0, 5);
                    break;
                case Keys.Right:
                case Keys.D:
                    MineCraftController.Translate(this, 5, 0);
                    break;
                case Keys.E:
                    MineCraftController.Translate(this, 0, 0, 5);
                    break;
                case Keys.Q:
                    MineCraftController.Translate(this, 0, 0, -5);
                    break;
                default:
                    break;
            }
        }

        private void MineCraftView_KeyDown(object sender, KeyEventArgs e)
        {
            Key = e.KeyCode;
        }

        private void MineCraftView_KeyUp(object sender, KeyEventArgs e)
        {
            Key = Keys.None;
        }
    }
}
