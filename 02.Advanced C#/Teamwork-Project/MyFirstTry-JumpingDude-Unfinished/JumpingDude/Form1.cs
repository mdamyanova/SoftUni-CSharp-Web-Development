using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumpingDude
{
    public partial class Form1 : Form
    {
        bool right;
        bool left;
        bool jump;
        int G = 30;
        int Force;
        int index = 0;

        public Form1()
        {
            InitializeComponent();
            player.Top = screen.Height - player.Height; //Sets the block start position
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            index++;

            //Gif replay
            if (right == true && index % 15 == 0)
            {
                player.Image = Image.FromFile("Running-mario.gif");
            }
            if (left == true && index % 15 == 0)
            {
                player.Image = Image.FromFile("Running-mario.gif");
            }
            //

            // Side Collision
            if (player.Right > block.Left && 
                player.Left < block.Right - player.Width && 
                player.Bottom < block.Bottom && 
                player.Bottom > block.Top)
            {
                right = false;
            }

            if (player.Left < block.Right && 
                player.Right > block.Left + player.Width && 
                player.Bottom < block.Bottom && 
                player.Bottom > block.Top)
            {
                left = false;
            }

            if (right == true)
            {
                player.Left += 3; //moving right
            }
            if (left == true)
            {
                player.Left -= 3; //moving left
            }
            if (jump == true)
            {
                //Falling (if the player has jumped before)
                player.Top -= Force;
                Force -= 1;
            }

            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height; //Stop falling at bottom
                if (jump == true)
                {
                   player.Image = Image.FromFile("Standing-mario.gif");
                }
                jump = false;

            }
            else
            {
                player.Top += 5; //Falling
            }

            //Top Collision
            if (player.Left + player.Width > block.Left && 
                player.Left + player.Width < block.Left + block.Width + player.Width &&
                player.Top + player.Height >= block.Top && 
                player.Top < block.Top)
            {
               
                jump = false;
                Force = 0;
                player.Top = block.Location.Y - player.Height;
            }

            //Head Collision
            if (player.Left + player.Width > block.Left && 
                player.Left + player.Width < block.Left + block.Width + player.Width && 
                player.Top - block.Bottom <= 10 && 
                player.Top - block.Top > -10)
            {
                Force = -1;
            }
            //Simple fall
            if (!(player.Left + player.Width > block.Left && 
                player.Left + player.Width < block.Left + block.Width + player.Width) && 
                player.Top + player.Height >= block.Top && 
                player.Top < block.Top)
            {
                jump = true;
            }

           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;          
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); //Escape -> Exit
            }
            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    Force = G;
                    player.Image = Image.FromFile("Jumping-mario.gif");
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
                player.Image = Image.FromFile("Standing-mario.gif");
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
                player.Image = Image.FromFile("Standing-mario.gif");
            }
        }
    }
}

