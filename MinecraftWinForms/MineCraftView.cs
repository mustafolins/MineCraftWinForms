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
            // use this style settings for reduced flicker
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            MineCraftController = new MineCraftController(this);
        }

        private void MineCraftView_Paint(object sender, PaintEventArgs e)
        {
            MineCraftController.Paint(e.Graphics);
        }

        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            //TranslateCubesRandomly();
            if (ProcessControls())
                Update();
        }

        private bool ProcessControls()
        {
            bool processed = true;
            var distance = 5;
            switch (Key)
            {
                case Keys.Left:
                case Keys.A:
                    MineCraftController.Translate(-distance, 0);
                    break;
                case Keys.Up:
                case Keys.W:
                    MineCraftController.Translate(0, -distance);
                    break;
                case Keys.Down:
                case Keys.S:
                    MineCraftController.Translate(0, distance);
                    break;
                case Keys.Right:
                case Keys.D:
                    MineCraftController.Translate(distance, 0);
                    break;
                case Keys.E:
                    MineCraftController.Translate(0, 0, distance);
                    break;
                case Keys.Q:
                    MineCraftController.Translate(0, 0, -distance);
                    break;
                case Keys.NumPad4:
                    MineCraftController.Rotate(0, distance, 0);
                    break;
                case Keys.NumPad6:
                    MineCraftController.Rotate(0, -distance, 0);
                    break;
                case Keys.NumPad8:
                    MineCraftController.Rotate(distance, 0, 0);
                    break;
                case Keys.NumPad2:
                    MineCraftController.Rotate(-distance, 0, 0);
                    break;
                default:
                    return false;
            }
            return processed;
        }

        private void MineCraftView_KeyDown(object sender, KeyEventArgs e)
        {
            Key = e.KeyCode;
        }

        private void MineCraftView_KeyUp(object sender, KeyEventArgs e)
        {
            Key = Keys.None;
        }

        private void Invalidater_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
