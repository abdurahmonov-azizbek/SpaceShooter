using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SpaceY
{
    public partial class Form1 : Form
    {
        private PictureBox[] stars;
        private Random random;
        private int backgroundSpeed;
        private int playerSpeed;
        private PictureBox[] munitions;
        private int munitionSpeed;
        private WindowsMediaPlayer gameMedia;
        private WindowsMediaPlayer shootMedia;
        private PictureBox[] enemies;
        private int enemySpeed;
        private WindowsMediaPlayer explosion;
        private PictureBox[] enemiesMunition;
        private int enemiesMunitionSpeed;
        private int score;
        private int level;
        private int dificulty;
        private bool gameOver;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.backgroundSpeed = 4;
            this.random = new Random();
            this.stars = new PictureBox[15];
            this.playerSpeed = 4;
            this.munitionSpeed = 20;
            this.munitions = new PictureBox[3];
            this.gameMedia = new WindowsMediaPlayer();
            this.shootMedia = new WindowsMediaPlayer();
            this.gameMedia.URL = "./songs/GameSong.mp3";
            this.gameMedia.settings.setMode("loop", true);
            this.gameMedia.settings.volume = 5;
            this.shootMedia.URL = "./songs/shoot.mp3";
            this.shootMedia.settings.volume = 1;
            this.enemySpeed = 4;
            this.explosion = new WindowsMediaPlayer();
            this.explosion.URL = "./songs/boom.mp3";
            this.explosion.settings.volume = 20;
            this.enemiesMunitionSpeed = 4;
            this.enemiesMunition = new PictureBox[10];
            this.gameOver = false;
            this.score = 0;
            this.level = 0;
            this.dificulty = 9;

            Image enemy1 = Image.FromFile("./asserts/E1.png");
            Image enemy2 = Image.FromFile("./asserts/E2.png");
            Image enemy3 = Image.FromFile("./asserts/E3.png");
            Image boss1 = Image.FromFile("./asserts/Boss1.png");
            Image boss2 = Image.FromFile("./asserts/Boss2.png");

            this.enemies = new PictureBox[10];

            for (var i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 40, -50);
            }

            enemies[0].Image = boss1;
            enemies[1].Image = enemy2;
            enemies[2].Image = enemy3;
            enemies[3].Image = enemy3;
            enemies[4].Image = enemy1;
            enemies[5].Image = enemy3;
            enemies[6].Image = enemy2;
            enemies[7].Image = enemy3;
            enemies[8].Image = enemy2;
            enemies[9].Image = boss2;

            for (var i = 0; i < stars.Length; i++)
            {
                this.stars[i] = new PictureBox();
                this.stars[i].BorderStyle = BorderStyle.None;
                this.stars[i].Location = new Point(
                    x: this.random.Next(20, 500),
                    y: this.random.Next(-10, 400));

                var size = random.Next(2, 4);

                this.stars[i].Size = new Size(size, size);
                this.stars[i].BackColor = Color.White;

                this.Controls.Add(this.stars[i]);
            }

            var image = Image.FromFile("./asserts/munition.png");
            for (var i = 0; i < munitions.Length; i++)
            {
                this.munitions[i] = new PictureBox();
                this.munitions[i].Size = new Size(8, 8);
                this.munitions[i].Image = image;
                this.munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.munitions[i].BorderStyle = BorderStyle.None;

                this.Controls.Add(this.munitions[i]);
            }

            this.gameMedia.controls.play();

            for (var i = 0; i < enemiesMunition.Length; i++)
            {
                enemiesMunition[i] = new PictureBox();
                enemiesMunition[i].Size = new Size(2, 25);
                enemiesMunition[i].Visible = false;
                enemiesMunition[i].BackColor = Color.Yellow;
                int x = random.Next(0, 10);
                enemiesMunition[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesMunition[i]);
            }
        }

        private void MoveBackgroundTimer_Tick(object sender, EventArgs e)
        {
            var speed = this.random.Next(backgroundSpeed - 2, backgroundSpeed + 2);

            for (int i = 0; i < this.stars.Length; i++)
            {
                this.stars[i].Top += speed;

                if (this.stars[i].Top >= this.Height)
                {
                    this.stars[i].Top = -this.stars[i].Top;
                }
            }
        }

        private void RightMove_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 425)
            {
                Player.Left += playerSpeed;
            }
        }

        private void LeftMove_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void UpMove_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void DownMove_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 320)
            {
                Player.Top += playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.D:
                    RightMove.Start();
                    break;

                case Keys.A:
                case Keys.Left:
                    LeftMove.Start();
                    break;

                case Keys.W:
                case Keys.Up:
                    UpMove.Start();
                    break;

                case Keys.S:
                case Keys.Down:
                    DownMove.Start();
                    break;

                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightMove.Stop();
            LeftMove.Stop();
            UpMove.Stop();
            DownMove.Stop();

            if (!gameOver)
            {
                StarsTimers();
                label.Visible = false;
                gameMedia.controls.play();
            }
            else
            {
                StopTimers();
            }
        }

        private void StarsTimers()
        {
            MoveBackgroundTimer.Start();
            MoveEnemies.Start();
            MunitionMove.Start();
            EnemiesMunition.Start();
        }

        private void MunitionMove_Tick(object sender, EventArgs e)
        {
            this.shootMedia.controls.play();
            for (var i = 0; i < this.munitions.Length; i++)
            {
                if (this.munitions[i].Top > 0)
                {
                    this.munitions[i].Visible = true;
                    this.munitions[i].Top -= this.munitionSpeed;

                    Collision();
                }
                else
                {
                    this.munitions[i].Visible = false;
                    this.munitions[i].Location = new Point(
                        x: Player.Location.X + 15,
                        y: Player.Location.Y - i * 30);
                }
            }
        }

        private void MoveEnemies_Tick(object sender, EventArgs e)
        {
            MoveEnemiesBase(enemies, enemySpeed);
        }

        private void MoveEnemiesBase(PictureBox[] enemies, int enemySpeed)
        {
            for (var i = 0; i < enemies.Length; i++)
            {
                enemies[i].Visible = true;
                enemies[i].Top += enemySpeed;

                if (enemies[i].Top > this.Height)
                {
                    enemies[i].Location = new Point((i + 1) * 40, -200);
                }
            }
        }

        private void Collision()
        {
            for (var i = 0; i < this.enemies.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    munitions[1].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    munitions[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.controls.play();

                    if (!gameOver)
                    {
                        ScoreLbl.Visible = true;
                        LevelLbl.Visible = true;
                    }

                    score += 1;
                    var prefix = "SCORE: ";
                    var levelPrefix = "LEVEL: ";
                    ScoreLbl.Text = (score < 10) ? prefix + score.ToString() : prefix + score.ToString();


                    if (score % 10 == 0)
                    {
                        level += 1;
                        LevelLbl.Text = (level < 10) ? levelPrefix + level.ToString() : levelPrefix + level.ToString();

                        if (enemySpeed <= 10 && enemiesMunitionSpeed <= 10 && dificulty >= 0)
                        {
                            dificulty--;
                            enemySpeed++;
                            enemiesMunitionSpeed++;
                        }

                        if (level == 10)
                        {
                            GameOver("NICE DONE");
                        }
                    }

                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }

                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("GAME OVER!");
                }
            }
        }

        private void GameOver(string v)
        {
            StopTimers();
            label.Text = v;
            label.Location = new Point(80, 120);
            label.Visible = true;
            ReplayBtn.Visible = true;
            ExitBtn.Visible = true;
            gameOver = true;
            gameMedia.controls.stop();
        }

        private void StopTimers()
        {
            MoveBackgroundTimer.Stop();
            MoveEnemies.Stop();
            MunitionMove.Stop();
            EnemiesMunition.Stop();
        }

        private void EnemiesMunition_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < enemiesMunition.Length; i++)
            {
                if (enemiesMunition[i].Top < this.Height)
                {
                    enemiesMunition[i].Visible = true;
                    enemiesMunition[i].Top += enemiesMunitionSpeed;

                    CollisionWithEnemiesMunition();
                }
                else
                {
                    enemiesMunition[i].Visible = false;
                    int x = random.Next(0, 10);
                    enemiesMunition[i].Location = new Point(
                        x: enemies[x].Location.X + 18,
                        y: enemies[x].Location.Y + 30);
                }
            }
        }

        private void CollisionWithEnemiesMunition()
        {
            for (var i = 0; i < enemiesMunition.Length; i++)
            {
                if (enemiesMunition[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemiesMunition[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ReplayBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }
    }
}