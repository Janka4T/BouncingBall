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
        }

        private void MoveBall()
        {
            Ball.Top += verVelocity;
            Ball.Left += horVelocity;
        }
    }
}
