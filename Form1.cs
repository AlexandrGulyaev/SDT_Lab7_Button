using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gulyaev_AG_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler(form1_MouseMove);
        }

        private void form1_MouseMove(object sender, MouseEventArgs e)
        {
            double length = Math.Sqrt(Math.Pow(e.X - button1.Location.X, 2) + Math.Pow(e.Y - button1.Location.Y, 2));

            if (length < 80)
            {
                double sin = (button1.Location.Y - e.Y) / length;
                double cos = (button1.Location.X - e.X) / length;
                if (sin >= 0.5)
                    button1.Location = new Point(button1.Location.X, button1.Location.Y + button1.Size.Width / 15);
                if (sin <= -0.5)
                    button1.Location = new Point(button1.Location.X, button1.Location.Y - button1.Size.Width / 15);
                if (cos >= 0.5)
                    button1.Location = new Point(button1.Location.X + button1.Size.Height / 15, button1.Location.Y);
                if (cos <= -0.5)
                    button1.Location = new Point(button1.Location.X - button1.Size.Height / 15, button1.Location.Y);
            }

            if (button1.Location.X < 0 || button1.Location.Y < 0 || button1.Location.X > this.Width - button1.Width || button1.Location.Y > this.Height - 2*button1.Height)
            {
                Random r = new Random();
                button1.Location = new Point(this.Size.Width / 2 + r.Next(-100, 100), this.Size.Height / 2 + r.Next(-100, 100));
            }
            this.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы смогли нажать на кнопку!", "Поздравляем!");
        }
    }
}
