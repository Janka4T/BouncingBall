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
    public partial class Form1 : Form
    {
        int horVelocity = 0;
        int verVelocity = 0;
        int ballStep = 3;

        Timer mainTimer = null;

        public Form1()
        {
            InitializeComponent();
            InitializeApp();
            
        }

        private void InitializeApp()
        {
            verVelocity = ballStep;
            horVelocity = ballStep;
            InitializeMainTimer();
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
                verVelocity = -ballStep;
                
            }
            else if (Ball.Top < 0) //collide with top border
            {
                verVelocity = +ballStep;
            }
            else if (Ball.Left < 0) //collide with left border
            {
                horVelocity = +ballStep;
            }
            else if(Ball.Left + Ball.Width > ClientRectangle.Width) //collide with right border
            {
                horVelocity = -ballStep;
            }
        }
    }
}
