using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShot
{
    public partial class Form1 : Form
    {
        bool moveup, movedown, moveright, moveleft;
        string bulldirection = "up";
        double health = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int kills = 0;
        List<PictureBox> zombiesList = new List<PictureBox>();
        bool end = false;
        Random rnd = new Random();
        SoundPlayer play;
        public Form1()
        {
            InitializeComponent();
            try
            {
                if (Database.Complex.Contains("Easy"))
                {
                    zombieSpeed = 2;
                }
                else if (Database.Complex.Contains("Hard"))
                {
                    zombieSpeed = 4;
                }
            }
            catch (Exception ex) { }
            zombiesList.Clear();
            zombiesList.Add(pictureBox1);
            zombiesList.Add(pictureBox2);
            zombiesList.Add(pictureBox3);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            play = new SoundPlayer("dr.wav");
            play.Play();
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
                DialogResult rez = MessageBox.Show($"Убийств:{kills}", "Game over", MessageBoxButtons.RetryCancel);
                if (rez == DialogResult.Retry)
                {
                    RestartGame();
                }
                else
                {
                    play.Stop();
                    Application.Exit();
                }
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
                if (control is PictureBox && (string)control.Tag == "hp")
                {
                    if (((PictureBox)control).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove((PictureBox)control);
                        ((PictureBox)control).Dispose();
                        double temp = health + 20;
                        if (temp < 100)
                            health += 20;
                        else
                            health = 100;
                        temp = 0;
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
                if (control is PictureBox && (string)control.Tag == "zombie")
                {
                    if (control.Bounds.IntersectsWith(player.Bounds))
                    {
                        health -= 1;
                    }
                    if (control.Left > player.Left)
                    {
                        control.Left -= zombieSpeed;
                        ((PictureBox)control).Image = Properties.Resources.zleft1;
                    }
                    if (control.Top > player.Top)
                    {
                        control.Top -= zombieSpeed;
                        ((PictureBox)control).Image = Properties.Resources.zup1;
                    }
                    if (control.Left < player.Left)
                    {
                        control.Left += zombieSpeed;
                        ((PictureBox)control).Image = Properties.Resources.zright1;
                    }
                    if (control.Top < player.Top)
                    {
                        control.Top += zombieSpeed;
                        ((PictureBox)control).Image = Properties.Resources.zdown1;
                    }
                }

                foreach (Control control1 in this.Controls)
                {
                    if (control1 is PictureBox && (string)control1.Tag == "bullet" && control is PictureBox && (string)control.Tag == "zombie")
                    {
                        if (control.Bounds.IntersectsWith(control1.Bounds))
                        {
                            kills++;
                            this.Controls.Remove(control1);
                            ((PictureBox)control1).Dispose();
                            this.Controls.Remove(control);
                            zombiesList.Remove(((PictureBox)control));
                            MakeZombie();
                            if (kills % 10 == 0) DropHealth();
                        }
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
            if (e.KeyCode == Keys.Space && ammo > 0)
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
            ammo.Left = rnd.Next(0, this.Width - 50);
            ammo.Top = rnd.Next(0, this.Height - 50);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        private void DropHealth()
        {
            PictureBox hp = new PictureBox();
            hp.Image = Properties.Resources.hp;
            hp.SizeMode = PictureBoxSizeMode.AutoSize;
            hp.Left = rnd.Next(0, this.Width - 50);
            hp.Top = rnd.Next(0, this.Height - 50);
            hp.Tag = "hp";
            this.Controls.Add(hp);
            hp.BringToFront();
            player.BringToFront();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            play.Stop();
            Application.Exit();
        }

        public void MakeZombie()
        {
            PictureBox zombie = new PictureBox();
            zombie.Image = Properties.Resources.zdown1;
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombie.Left = rnd.Next(0, this.Width);
            zombie.Top = rnd.Next(0, this.Height);
            zombie.Tag = "zombie";
            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            player.BringToFront();
        }
        private void Shoot(string direct)
        {
            Bullet bullet = new Bullet();
            bullet.parentform = this;
            bullet.Direction = direct;
            bullet.bulletleft = player.Left + (player.Width / 2);
            bullet.bullettop = player.Top + (player.Height / 2);
            bullet.makeBullet(this);
        }
        private void RestartGame()
        {
            player.Image = Properties.Resources.up;

            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }

            zombiesList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeZombie();
            }

            moveup = false;
            movedown = false;
            moveleft = false;
            moveright = false;
            end = false;

            zombieSpeed = 3;
            health = 100;
            kills = 0;
            ammo = 10;

            timer1.Start();
        }
    }
}
