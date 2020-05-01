using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class Field : Form
    {
        int horVelocity = 0;
        int verVelocity = 0;
        int ballStep = 2;
        


        private PictureBox brick = null;
        private Timer mainTimer = null;
        private Point MouseDownLocation;

        public Field()
        {
            InitializeComponent();
            InitializeApp();
            
        }

        private void InitializeApp()
        {
            //this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            verVelocity = ballStep;
            horVelocity = ballStep;

            //Ball.BackColor = Color.Transparent;
            //Ball.SizeMode = PictureBoxSizeMode.StretchImage;
            //Ball.Image = Properties.Resources.DvD;
            

            this.KeyDown += new KeyEventHandler(App_KeyDown);

            UpdateBallStepLabel();
            InitializeMainTimer();
            BuildBricks(5, 10);
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = 20;
            mainTimer.Start();
        }        

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            MoveBall();
            BallBorderCollider();
            RacketCollision();
            BallBrickCollision();
        }

        private void MoveBall()
        {
            Ball.Top += verVelocity;
            Ball.Left += horVelocity;
        }

        private void BallBorderCollider()
        {
            if (Ball.Top + Ball.Height > ClientRectangle.Height) //collide with bottom border
            {
                verVelocity *= -1;
                //verVelocity = -ballStep;
                
            }
            else if (Ball.Top < 0) //collide with top border
            {
                verVelocity *= -1;
                // verVelocity = +ballStep;
            }
            else if (Ball.Left < 0) //collide with left border
            {
                horVelocity *= -1;
                //horVelocity = +ballStep;
            }
            else if(Ball.Left + Ball.Width > ClientRectangle.Width) //collide with right border
            {
                horVelocity *= -1;
                //horVelocity = -ballStep;
            }
        }

        
        private void App_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.X)
            {
                ballStep += 1;                                
                verVelocity = ballStep * (verVelocity/Math.Abs(verVelocity));
                horVelocity = ballStep * (horVelocity / Math.Abs(horVelocity));                                                                                                                  
                UpdateBallStepLabel();
            }
            else if(e.KeyCode == Keys.Z)
            {
                if(ballStep > 1)
                {
                    ballStep -= 1;
                    verVelocity = ballStep * (verVelocity / Math.Abs(verVelocity));
                    horVelocity = ballStep * (horVelocity / Math.Abs(horVelocity));
                    UpdateBallStepLabel();
                }                
            }                
        }

        private void UpdateBallStepLabel()
        {
            BallStepLabel.ForeColor = Color.White;
            BallStepLabel.Text = "Ball step: " + ballStep;
        }

        private void RacketCollision()
        {
            if (Ball.Bounds.IntersectsWith(Racket.Bounds))
            {
                verVelocity = -verVelocity;
            }
        }
        
        private void Racket_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void Racket_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Racket.Left = e.X + Racket.Left - MouseDownLocation.X;
                Racket.Top = e.Y + Racket.Top - MouseDownLocation.Y;
            }
        }

        private void BuildBricks(int rows, int cols)
        {
            int brickWidth = 60;
            int brickHeight = 20;
            int brickVerSpace = 5;
            int brickHorSpase = 10;

            for(int r = 1; r <= rows; r++)
            {
                for(int c = 1; c<= cols; c++)
                {
                    brick = new PictureBox();
                    brick.BackColor = Color.RosyBrown;
                    brick.Width = brickWidth;
                    brick.Height = brickHeight;
                    brick.Left = c * (brickWidth + brickHorSpase);
                    brick.Top = r * (brickHeight + brickVerSpace);
                    brick.Tag = "brick";
                    this.Controls.Add(brick);
                }
            }
        }

        private void BallBrickCollision()
        {
            foreach(Control cont in this.Controls)
            {
                if((string)cont.Tag == "brick")
                {
                    if (cont.Bounds.IntersectsWith(Ball.Bounds))
                    {
                        cont.Dispose();
                        verVelocity *= -1; //verVelocity = -verVelocity;

                    }
                }
            }
        }
    }   
}
