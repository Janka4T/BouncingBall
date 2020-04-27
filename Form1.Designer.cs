namespace BouncingBall
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ball = new System.Windows.Forms.PictureBox();
            this.BallStepLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            this.SuspendLayout();
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Orange;
            this.Ball.Location = new System.Drawing.Point(368, 93);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(114, 98);
            this.Ball.TabIndex = 0;
            this.Ball.TabStop = false;
            // 
            // BallStepLabel
            // 
            this.BallStepLabel.AutoSize = true;
            this.BallStepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BallStepLabel.Location = new System.Drawing.Point(12, 9);
            this.BallStepLabel.Name = "BallStepLabel";
            this.BallStepLabel.Size = new System.Drawing.Size(93, 32);
            this.BallStepLabel.TabIndex = 1;
            this.BallStepLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BallStepLabel);
            this.Controls.Add(this.Ball);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.Label BallStepLabel;
    }
}

