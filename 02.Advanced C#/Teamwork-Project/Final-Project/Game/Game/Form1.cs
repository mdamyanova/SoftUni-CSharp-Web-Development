using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Game : Form
    {
        System.Media.SoundPlayer backgroundSound = new System.Media.SoundPlayer();     
        System.Media.SoundPlayer win = new System.Media.SoundPlayer();
        System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer();

        bool right;
        bool left;
        bool jump;
        int G = 20;
        int Force;
        int platformSpeed1 = 0;
        int platformSpeed2 = 0;
        int points = 1;
        bool check0 = true;
        bool check1 = false;
        bool check2 = true;
        bool check3 = false;
        bool check4 = true;
        bool check_guy1 = false;
        bool check_catched = false;
        bool check_win = false;
        bool glitch = false;

        protected override CreateParams CreateParams // this activates DB and removes flickering and tearing!
        {
            get
            {
                // Activate double buffering at the form level.  All child controls will be double buffered as well.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        } 

        public Game()
        {

            InitializeComponent();
            backgroundSound.SoundLocation = "BackgroundSound.wav";
            win.SoundLocation = "GettingTheStar.wav";
            gameOver.SoundLocation = "GameOver.wav";
            backgroundSound.Play();
            score.Text = "Score = " + points;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //player textures
            if (left == false && right == false && jump == false) { player.Image = Image.FromFile("stand.png"); } //standing 
            if (left == true && jump == true) { player.Image = Image.FromFile("jumpleft.png"); } //jumping to the left side
            if (right == true && jump == true) { player.Image = Image.FromFile("jumpright.png"); } //jumping to the right side
            if (left == true && jump == false && glitch == false) { player.Image = Image.FromFile("walkleft.gif"); glitch = true; } //moving to the left side
            if (right == true && jump == false && glitch == false) { player.Image = Image.FromFile("walkright.gif"); glitch = true; } //moving to the right side
            if (left == false && right == false && jump == true) { player.Image = Image.FromFile("jumpright.png"); } //jumping on one place

            if (check_catched == true) //game over (when in contact with badGuy
            {
                timer1.Stop();
                backgroundSound.Stop();
                gameOver.Play();
                GameOver.Visible = true;
                player.Enabled = false;
                bad_guy.Enabled = false;

            }

            if (check_win == true)
            {
                backgroundSound.Stop();
                win.Play();
                System.Threading.Thread.Sleep(900);
                player.Top = screen.Height - player.Height;
                points++;
                score.Text = "Score = " + points;
                if (platformSpeed1 < 6) { platformSpeed1++; }
                if (points < 12) { platformSpeed2++; }
                check_win = false;
                backgroundSound.Play();
            }


            if (right == true) //player moving right
            {
                player.Left += 6;
            }

            if (left == true) //player moving left
            {
                player.Left -= 6;
            }

            if (jump == true) //falling (if player jumped)
            {
                player.Top -= Force;
                Force -= 1;
            }

            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height; // does not fall tru bottom!
                jump = false;
            }

            else
            {
                player.Top += 5; // just falling/gravity
            }

            // player side (window) collision
            if (player.Right > screen.Right) //right wall
            {
                player.Left = screen.Width - player.Width;
                right = false;
            }

            if (player.Left < screen.Left) //left wall
            {
                player.Left = screen.Left;
                left = false;
            }
            //

            // here we give collision to every block
            physics(block0);
            physics(block1);
            physics(block2);
            physics(block3);
            physics(block4);
            
            //block0 movement and wall collision
            if (block0.Right > screen.Right)
            { 
                block0.Left = screen.Width - block0.Width;
                check0 = false;
            }
            if (block0.Left < screen.Left) 
            { 
                block0.Left = screen.Left; 
                check0 = true; 
            }
            if (check0 == true) 
            { 
                block0.Left += 2; 
                if (player.Bottom == block0.Top) 
                { 
                    player.Left += 2; 
                    bad_guy.Left += 2; 
                } 
            }
            else 
            { 
                block0.Left -= 2; 
                if (player.Bottom == block0.Top) 
                { 
                    player.Left -= 2; 
                    bad_guy.Left -= 2; 
                } 
            }

            //block1 movement and wall collision
            if (block1.Right > screen.Right) 
            { 
                block1.Left = screen.Width - block1.Width; 
                check1 = false; 
            }

            if (block1.Left < screen.Left) 
            { 
                block1.Left = screen.Left; 
                check1 = true; 
            }

            if (check1 == true) 
            { 
                block1.Left += (2 + platformSpeed1); 
                if (player.Bottom == block1.Top) 
                { 
                    player.Left += (2 + platformSpeed1); 
                } 
            }

            else 
            { 
                block1.Left -= (2 + platformSpeed1); 
                if (player.Bottom == block1.Top) 
                { 
                    player.Left -= (2 + platformSpeed1); 
                } 
            }
            
            //block2 movement and wall collision
            if (block2.Right > screen.Right) 
            { 
                block2.Left = screen.Width - block2.Width; 
                check2 = false; 
            }

            if (block2.Left < screen.Left) 
            { 
                block2.Left = screen.Left; 
                check2 = true; 
            }

            if (check2 == true) 
            { 
                block2.Left += (3 + platformSpeed2); 
                if (player.Bottom == block2.Top) 
                { 
                    player.Left += (3 + platformSpeed2);
                }
            }

            else 
            { 
                block2.Left -= (3 + platformSpeed2); 
                if (player.Bottom == block2.Top) 
                { 
                    player.Left -= (3 + platformSpeed2); 
                } 
            }

            //block3 movement and wall collision
            if (block3.Right > screen.Right) 
            { 
                block3.Left = screen.Width - block3.Width; 
                check3 = false; 
            }

            if (block3.Left < screen.Left) 
            { 
                block3.Left = screen.Left; 
                check3 = true; 
            }

            if (check3 == true) 
            { 
                block3.Left += (4 + platformSpeed1); 
                if (player.Bottom == block3.Top) 
                { 
                    player.Left += (4 + platformSpeed1); 
                } 
            }

            else 
            { 
                block3.Left -= (4 + platformSpeed1); 
                if (player.Bottom == block3.Top) 
                { 
                    player.Left -= (4 + platformSpeed1); 
                } 
            }

            //block4 movement and wall collision
            if (block4.Right > screen.Right) 
            { 
                block4.Left = screen.Width - block4.Width; 
                check4 = false; 
            }

            if (block4.Left < screen.Left) 
            { 
                block4.Left = screen.Left; 
                check4 = true; 
            }

            if (check4 == true) 
            { 
                block4.Left += (5 + platformSpeed2); 
                if (player.Bottom == block4.Top) 
                { 
                    player.Left += (5 + platformSpeed2); 
                } 
            }

            else 
            { 
                block4.Left -= (5 + platformSpeed2); 
                if (player.Bottom == block4.Top) 
                { 
                    player.Left -= (5 + platformSpeed2); 
                } 
            }

            //bad_guy movement and wall collision
            if (bad_guy.Right > block0.Right) 
            { 
                bad_guy.Left = block0.Right - bad_guy.Width; 
                check_guy1 = false; 
                bad_guy.Image = Image.FromFile("bigbadleft.gif"); 
            }
            if (bad_guy.Left < block0.Left) 
            { 
                bad_guy.Left = block0.Left; 
                check_guy1 = true; 
                bad_guy.Image = Image.FromFile("bigbadright.gif"); 
            }

            if (check_guy1 == true) { bad_guy.Left += 4; }

            else { bad_guy.Left -= 4; }

            //collision with bad_guy (game over)
            if (player.Right > bad_guy.Left && player.Left < bad_guy.Right - player.Width && player.Bottom < bad_guy.Bottom && player.Bottom > bad_guy.Top)
            {
                check_catched = true;
            }

            if (player.Left < bad_guy.Right && player.Right > bad_guy.Left + player.Width && player.Bottom < bad_guy.Bottom && player.Bottom > bad_guy.Top)
            {

                check_catched = true;
            }
            
            //collision with star (win)
            if (player.Right > Star.Left && player.Left < Star.Right - player.Width && player.Bottom < Star.Bottom && player.Bottom > Star.Top)
            {
                check_win = true;
            }

            if (player.Left < Star.Right && player.Right > Star.Left + player.Width && player.Bottom < Star.Bottom && player.Bottom > Star.Top)
            {

                check_win = true;
            }
        }

        public void physics(System.Windows.Forms.PictureBox block)
        {
            // top collision 
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = false;
                Force = 0;
                player.Top = block.Location.Y - player.Height;
            }

            // simple fall
            if (!(player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width) && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = true;
            }

            //bottom collision
            if (player.Left + player.Width - 1 > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top - block.Bottom <= 10 && player.Top - block.Top > -10)
            {
                Force = -1;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = true; }

            if (e.KeyCode == Keys.Left) { left = true; }

            if (e.KeyCode == Keys.Escape) { this.Close(); }

            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    Force = G;
                }
            }

            if (e.KeyCode == Keys.Enter) { Application.Restart(); }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false; glitch = false; }

            if (e.KeyCode == Keys.Left) { left = false; glitch = false; }

            if (e.KeyCode == Keys.Space) { glitch = false; }
        }
    }
}

