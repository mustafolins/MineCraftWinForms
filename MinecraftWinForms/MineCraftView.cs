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

        Object3d o = new Object3d(10, 10, 10);

        private void MineCraftView_Paint(object sender, PaintEventArgs e)
        {
            o.Paint(e.Graphics);
        }

        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            TranslateObject3d(5, 2);
        }

        private void TranslateObject3d(int x, int y)
        {
            Invalidate(o.GetRect());
            o.Translate(x, y);
            Invalidate(o.GetRect());
        }
    }
}
