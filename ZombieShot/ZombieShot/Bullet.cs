using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShot
{
    internal class Bullet
    {
        public string Direction { get; set; }
        public int Speed = 20;
        PictureBox bullet = new PictureBox();
        Timer timer  = new Timer();
        public int bulletleft;
        public int bullettop;
        public Form parentform { get; set; }

        public void makeBullet(Form form)
        {
            bullet.BackColor = System.Drawing.Color.DarkRed;
            bullet.Size = new System.Drawing.Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletleft;
            bullet.Top = bullettop;
            form.Controls.Add(bullet);

            timer.Interval = Speed;
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();

        }
        public void timer_tick(object sender, EventArgs e)
        {
            if(Direction == "left")
            {
                bullet.Left -= Speed;
            }
            if (Direction == "right")
            {
                bullet.Left += Speed;
            }
            if (Direction == "down")
            {
                bullet.Top += Speed;
            }
            if (Direction == "up")
            {
                bullet.Top -= Speed;
            }

            if(bullet.Left < 16 || bullet.Left > parentform.Width -4 || bullet.Top <46|| bullet.Top> parentform.Height -4)
            {
                timer.Stop();
                timer.Dispose();
                bullet.Dispose();
                timer = null;
                bullet = null;
                
            }
        }

    }
}
