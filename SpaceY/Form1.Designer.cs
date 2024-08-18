namespace SpaceY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveBackgroundTimer = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.RightMove = new System.Windows.Forms.Timer(this.components);
            this.LeftMove = new System.Windows.Forms.Timer(this.components);
            this.UpMove = new System.Windows.Forms.Timer(this.components);
            this.DownMove = new System.Windows.Forms.Timer(this.components);
            this.MunitionMove = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemies = new System.Windows.Forms.Timer(this.components);
            this.EnemiesMunition = new System.Windows.Forms.Timer(this.components);
            this.ReplayBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.LevelLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBackgroundTimer
            // 
            this.MoveBackgroundTimer.Enabled = true;
            this.MoveBackgroundTimer.Interval = 10;
            this.MoveBackgroundTimer.Tick += new System.EventHandler(this.MoveBackgroundTimer_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(268, 391);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(50, 50);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // RightMove
            // 
            this.RightMove.Interval = 5;
            this.RightMove.Tick += new System.EventHandler(this.RightMove_Tick);
            // 
            // LeftMove
            // 
            this.LeftMove.Interval = 5;
            this.LeftMove.Tick += new System.EventHandler(this.LeftMove_Tick);
            // 
            // UpMove
            // 
            this.UpMove.Interval = 5;
            this.UpMove.Tick += new System.EventHandler(this.UpMove_Tick);
            // 
            // DownMove
            // 
            this.DownMove.Interval = 5;
            this.DownMove.Tick += new System.EventHandler(this.DownMove_Tick);
            // 
            // MunitionMove
            // 
            this.MunitionMove.Enabled = true;
            this.MunitionMove.Interval = 20;
            this.MunitionMove.Tick += new System.EventHandler(this.MunitionMove_Tick);
            // 
            // MoveEnemies
            // 
            this.MoveEnemies.Enabled = true;
            this.MoveEnemies.Tick += new System.EventHandler(this.MoveEnemies_Tick);
            // 
            // EnemiesMunition
            // 
            this.EnemiesMunition.Enabled = true;
            this.EnemiesMunition.Interval = 20;
            this.EnemiesMunition.Tick += new System.EventHandler(this.EnemiesMunition_Tick);
            // 
            // ReplayBtn
            // 
            this.ReplayBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReplayBtn.Location = new System.Drawing.Point(178, 262);
            this.ReplayBtn.Name = "ReplayBtn";
            this.ReplayBtn.Size = new System.Drawing.Size(220, 50);
            this.ReplayBtn.TabIndex = 1;
            this.ReplayBtn.Text = "Replay";
            this.ReplayBtn.UseVisualStyleBackColor = true;
            this.ReplayBtn.Visible = false;
            this.ReplayBtn.Click += new System.EventHandler(this.ReplayBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(178, 329);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(220, 47);
            this.ExitBtn.TabIndex = 2;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Visible = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.Control;
            this.label.Location = new System.Drawing.Point(166, 116);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(238, 69);
            this.label.TabIndex = 3;
            this.label.Text = "SPACE";
            this.label.Visible = false;
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ScoreLbl.Location = new System.Drawing.Point(12, 9);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(117, 29);
            this.ScoreLbl.TabIndex = 4;
            this.ScoreLbl.Text = "SCORE: ";
            this.ScoreLbl.Visible = false;
            // 
            // LevelLbl
            // 
            this.LevelLbl.AutoSize = true;
            this.LevelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LevelLbl.Location = new System.Drawing.Point(439, 9);
            this.LevelLbl.Name = "LevelLbl";
            this.LevelLbl.Size = new System.Drawing.Size(105, 29);
            this.LevelLbl.TabIndex = 5;
            this.LevelLbl.Text = "LEVEL: ";
            this.LevelLbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.LevelLbl);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.label);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.ReplayBtn);
            this.Controls.Add(this.Player);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.Text = "SpaceY";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MoveBackgroundTimer;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer RightMove;
        private System.Windows.Forms.Timer LeftMove;
        private System.Windows.Forms.Timer UpMove;
        private System.Windows.Forms.Timer DownMove;
        private System.Windows.Forms.Timer MunitionMove;
        private System.Windows.Forms.Timer MoveEnemies;
        private System.Windows.Forms.Timer EnemiesMunition;
        private System.Windows.Forms.Button ReplayBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label ScoreLbl;
        private System.Windows.Forms.Label LevelLbl;
    }
}

