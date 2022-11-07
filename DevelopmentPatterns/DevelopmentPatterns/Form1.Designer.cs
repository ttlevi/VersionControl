﻿namespace DevelopmentPatterns
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnCar = new System.Windows.Forms.Button();
            this.btnBall = new System.Windows.Forms.Button();
            this.btnBallColor = new System.Windows.Forms.Button();
            this.btnPresent = new System.Windows.Forms.Button();
            this.btnBoxColor = new System.Windows.Forms.Button();
            this.btnRibColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Location = new System.Drawing.Point(13, 169);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(775, 269);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coming next:";
            // 
            // btnCar
            // 
            this.btnCar.Location = new System.Drawing.Point(13, 12);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(93, 23);
            this.btnCar.TabIndex = 2;
            this.btnCar.Text = "CAR";
            this.btnCar.UseVisualStyleBackColor = true;
            this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // btnBall
            // 
            this.btnBall.Location = new System.Drawing.Point(112, 12);
            this.btnBall.Name = "btnBall";
            this.btnBall.Size = new System.Drawing.Size(93, 23);
            this.btnBall.TabIndex = 3;
            this.btnBall.Text = "BALL";
            this.btnBall.UseVisualStyleBackColor = true;
            this.btnBall.Click += new System.EventHandler(this.btnBall_Click);
            // 
            // btnBallColor
            // 
            this.btnBallColor.BackColor = System.Drawing.Color.Blue;
            this.btnBallColor.Location = new System.Drawing.Point(112, 41);
            this.btnBallColor.Name = "btnBallColor";
            this.btnBallColor.Size = new System.Drawing.Size(93, 23);
            this.btnBallColor.TabIndex = 4;
            this.btnBallColor.UseVisualStyleBackColor = false;
            this.btnBallColor.Click += new System.EventHandler(this.btnBallColor_Click);
            // 
            // btnPresent
            // 
            this.btnPresent.Location = new System.Drawing.Point(211, 13);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Size = new System.Drawing.Size(93, 23);
            this.btnPresent.TabIndex = 5;
            this.btnPresent.Text = "PRESENT";
            this.btnPresent.UseVisualStyleBackColor = true;
            this.btnPresent.Click += new System.EventHandler(this.btnPresent_Click);
            // 
            // btnBoxColor
            // 
            this.btnBoxColor.BackColor = System.Drawing.Color.Red;
            this.btnBoxColor.Location = new System.Drawing.Point(211, 41);
            this.btnBoxColor.Name = "btnBoxColor";
            this.btnBoxColor.Size = new System.Drawing.Size(93, 23);
            this.btnBoxColor.TabIndex = 6;
            this.btnBoxColor.UseVisualStyleBackColor = false;
            this.btnBoxColor.Click += new System.EventHandler(this.btnBallColor_Click);
            // 
            // btnRibColor
            // 
            this.btnRibColor.BackColor = System.Drawing.Color.Yellow;
            this.btnRibColor.Location = new System.Drawing.Point(211, 70);
            this.btnRibColor.Name = "btnRibColor";
            this.btnRibColor.Size = new System.Drawing.Size(93, 23);
            this.btnRibColor.TabIndex = 7;
            this.btnRibColor.UseVisualStyleBackColor = false;
            this.btnRibColor.Click += new System.EventHandler(this.btnBallColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRibColor);
            this.Controls.Add(this.btnBoxColor);
            this.Controls.Add(this.btnPresent);
            this.Controls.Add(this.btnBallColor);
            this.Controls.Add(this.btnBall);
            this.Controls.Add(this.btnCar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCar;
        private System.Windows.Forms.Button btnBall;
        private System.Windows.Forms.Button btnBallColor;
        private System.Windows.Forms.Button btnPresent;
        private System.Windows.Forms.Button btnBoxColor;
        private System.Windows.Forms.Button btnRibColor;
    }
}

