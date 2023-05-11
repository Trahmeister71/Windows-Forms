using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShot
{
    public partial class Form1 : Form
    {
        bool moveup, movedown,moveright, moveleft;
        string bulldirection = "up";
        double health = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int kills = 0;
        bool end=false;
        Random rnd = new Random();   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (end) return;
            if (e.KeyCode == Keys.Left)
            {
                moveleft = true;
                bulldirection = "left";
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveright = true;
                bulldirection = "right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Down)
            {
                movedown = true;
                bulldirection = "down";
                player.Image = Properties.Resources.down;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveup = true;
                bulldirection = "up";
                player.Image = Properties.Resources.up;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (health > 1)
            {
                progressBar1.Value = Convert.ToInt32(health);
            }
            else
            {
                player.Image = Properties.Resources.dead;
                timer1.Stop();
                end = true;
            }
            label1.Text = "Ammo: " + ammo;
            label2.Text = "Kills: " + kills;
            if (health < 20)
            {
                progressBar1.ForeColor = System.Drawing.Color.Red;
            }
            if (moveleft && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (moveup && player.Top > 50)
            {
                player.Top -= speed;
            }
            if (moveright && player.Left + player.Width < this.Width)
            {
                player.Left += speed;
            }
            if (movedown && player.Top + player.Height < this.Height - 5)
            {
                player.Top += speed;
            }
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && (string)control.Tag == "ammo")
                {
                    if (((PictureBox)control).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove((PictureBox)control);
                        ((PictureBox)control).Dispose();
                        ammo += 5;
                    }
                }
                if (control is PictureBox && (string)control.Tag == "bullet")
                {
                    if (((PictureBox)control).Left < 0 || ((PictureBox)control).Left + ((PictureBox)control).Width > this.Width || ((PictureBox)control).Top < 50 || ((PictureBox)control).Top + ((PictureBox)control).Height > this.Height)
                    {
                        this.Controls.Remove((PictureBox)control);
                        ((PictureBox)control).Dispose();
                    }
                }

            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveright = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                movedown = false;

            }
            if (e.KeyCode == Keys.Up)
            {
                moveup = false;

            }
            if(e.KeyCode == Keys.Space && ammo >0)
            {
                ammo--;
                Shoot(bulldirection);
                if (ammo < 1) Ammo();
            }
            
            
            
        }
        private void Ammo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left= rnd.Next(0,this.Width);
            ammo.Top= rnd.Next(0,this.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        private void MakeZombie()
        {
            PictureBox zombie = new PictureBox();
            zombie.Image = Properties.Resources.zdown;
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombie.Left= rnd.Next(0,this.Width);
            zombie.Top= rnd.Next(0,this.Height);
            zombie.Tag = "zombie";
            this.Controls.Add(zombie);
            zombie.BringToFront();
        }
        private void Shoot(string direct)
        {
            Bullet bullet = new Bullet();
            bullet.parentform = this;
            bullet.Direction = direct;
            bullet.bulletleft = player.Left+ (player.Width/2);
            bullet.bullettop = player.Top+ (player.Height/2);
            bullet.makeBullet(this);
        }
    }
}
