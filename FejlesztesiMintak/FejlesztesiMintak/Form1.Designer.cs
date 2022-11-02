
namespace FejlesztesiMintak
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
            this.btn_car = new System.Windows.Forms.Button();
            this.btn_ball = new System.Windows.Forms.Button();
            this.btn_present = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lbl_comingNext = new System.Windows.Forms.Label();
            this.btn_color_present_1 = new System.Windows.Forms.Button();
            this.btn_color_ball_1 = new System.Windows.Forms.Button();
            this.btn_color_present_2 = new System.Windows.Forms.Button();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_car
            // 
            this.btn_car.BackColor = System.Drawing.Color.White;
            this.btn_car.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_car.Location = new System.Drawing.Point(12, 12);
            this.btn_car.Name = "btn_car";
            this.btn_car.Size = new System.Drawing.Size(88, 43);
            this.btn_car.TabIndex = 0;
            this.btn_car.Text = "CAR";
            this.btn_car.UseVisualStyleBackColor = false;
            this.btn_car.Click += new System.EventHandler(this.btn_car_Click);
            // 
            // btn_ball
            // 
            this.btn_ball.BackColor = System.Drawing.Color.White;
            this.btn_ball.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_ball.Location = new System.Drawing.Point(133, 12);
            this.btn_ball.Name = "btn_ball";
            this.btn_ball.Size = new System.Drawing.Size(88, 43);
            this.btn_ball.TabIndex = 1;
            this.btn_ball.Text = "BALL";
            this.btn_ball.UseVisualStyleBackColor = false;
            this.btn_ball.Click += new System.EventHandler(this.btn_ball_Click);
            // 
            // btn_present
            // 
            this.btn_present.BackColor = System.Drawing.Color.White;
            this.btn_present.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_present.Location = new System.Drawing.Point(248, 12);
            this.btn_present.Name = "btn_present";
            this.btn_present.Size = new System.Drawing.Size(88, 43);
            this.btn_present.TabIndex = 2;
            this.btn_present.Text = "PRESENT";
            this.btn_present.UseVisualStyleBackColor = false;
            this.btn_present.Click += new System.EventHandler(this.btn_present_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Location = new System.Drawing.Point(1, 150);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(787, 80);
            this.mainPanel.TabIndex = 3;
            // 
            // lbl_comingNext
            // 
            this.lbl_comingNext.AutoSize = true;
            this.lbl_comingNext.Location = new System.Drawing.Point(458, 12);
            this.lbl_comingNext.Name = "lbl_comingNext";
            this.lbl_comingNext.Size = new System.Drawing.Size(91, 17);
            this.lbl_comingNext.TabIndex = 4;
            this.lbl_comingNext.Text = "Coming Next:";
            // 
            // btn_color_present_1
            // 
            this.btn_color_present_1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_color_present_1.Location = new System.Drawing.Point(248, 61);
            this.btn_color_present_1.Name = "btn_color_present_1";
            this.btn_color_present_1.Size = new System.Drawing.Size(40, 23);
            this.btn_color_present_1.TabIndex = 5;
            this.btn_color_present_1.UseVisualStyleBackColor = false;
            this.btn_color_present_1.Click += new System.EventHandler(this.btn_color);
            // 
            // btn_color_ball_1
            // 
            this.btn_color_ball_1.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_color_ball_1.Location = new System.Drawing.Point(133, 61);
            this.btn_color_ball_1.Name = "btn_color_ball_1";
            this.btn_color_ball_1.Size = new System.Drawing.Size(40, 23);
            this.btn_color_ball_1.TabIndex = 6;
            this.btn_color_ball_1.UseVisualStyleBackColor = false;
            this.btn_color_ball_1.Click += new System.EventHandler(this.btn_color);
            // 
            // btn_color_present_2
            // 
            this.btn_color_present_2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_color_present_2.Location = new System.Drawing.Point(296, 61);
            this.btn_color_present_2.Name = "btn_color_present_2";
            this.btn_color_present_2.Size = new System.Drawing.Size(40, 23);
            this.btn_color_present_2.TabIndex = 7;
            this.btn_color_present_2.UseVisualStyleBackColor = false;
            this.btn_color_present_2.Click += new System.EventHandler(this.btn_color);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 256);
            this.Controls.Add(this.btn_color_present_2);
            this.Controls.Add(this.btn_color_ball_1);
            this.Controls.Add(this.btn_color_present_1);
            this.Controls.Add(this.lbl_comingNext);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.btn_present);
            this.Controls.Add(this.btn_ball);
            this.Controls.Add(this.btn_car);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_car;
        private System.Windows.Forms.Button btn_ball;
        private System.Windows.Forms.Button btn_present;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lbl_comingNext;
        private System.Windows.Forms.Button btn_color_present_1;
        private System.Windows.Forms.Button btn_color_ball_1;
        private System.Windows.Forms.Button btn_color_present_2;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
    }
}

