using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GDIplusAnimations
{
    public partial class MainForm : Form
    {
        #region Variables of MainForm

        //Create List
        List<Actor> enemies;
        List<Actor> protection;
                

        //Use Static class settings
        GameSetting setting = new GameSetting();
        

        //Publiv Variables
        public int DestroyedEnemy = 0;
        public static int projektilSpeed = 20;
        public static int projektilESpeed = 15;
        public bool EnemyDirection = true;
        public bool PlayerStop = false;
        Random rndP = new Random();

        //SetBuffer
        //>>no buffer enabled<<


        //CreatePlayerActor
        Actor act0 = new Actor( GameSetting.Playerhealth + 1, true);
        //Projektil
        Actor act1 = new Actor( 1, false);
        Actor act2 = new Actor( 1, false);

        //Create Rectangle for IntersectWith
        Rectangle rectangleProtection;


        //Private Variables
        private Bitmap playerS;
        private Bitmap enemyS;
        private Bitmap playerProjectilS;
        private Bitmap enemyProjectilS;
        private Bitmap protectionS;
        private int enemySpeed = 1;


       

        #endregion

        protected override void OnClosed(EventArgs e)
        {
            if (!PlayerStop)
            {
                base.OnClosed(e);

                Environment.Exit(1);
            }
           
        }    


        public MainForm()
        {
            InitializeComponent();

            

            //List initialisierung
            enemies = new List<Actor>();
            protection = new List<Actor>();

            //Buffer for better performence
            this.DoubleBuffered = true;

            SetSkin();

            //Create Actors
            if (GameSetting.Playerhealth == 0)
            {
                GameSetting.Playerhealth = 1;
            }
            createPlayerActor();
            createProjektilActor();
            if(GameSetting.Enemyhealth == 0)
            {
                GameSetting.Enemyhealth = 1;
            }            
            createEnemyObjekt();
            if(GameSetting.Protection != 0)
            {
                createProtection();
            }
            if(GameSetting.Cheat == 1)
            {
                act0.PlayerMovement = 20;
                enemySpeed = 6;
                
            }
            else if(GameSetting.Cheat == 2)
            {
                projektilSpeed = 40;
                projektilESpeed = 40;
                act0.PlayerMovement = 6;

                tmr_EnemyProjectil.Interval = 400;                
            }
            

            this.BackColor = Color.Black;

            ChangeTimer();

            Sound();

            
        }

        private void SetSkin()
        {
            switch (GameSetting.Skin)
            {
                case 0:

                    playerS = Properties.Resources.spaceship;
                    playerProjectilS = Properties.Resources.Projektil_Gegner;
                    enemyS = Properties.Resources.Enemy;
                    enemyProjectilS = Properties.Resources.Projektil_Gegner;
                    protectionS = Properties.Resources.Asteroid;
                    break;

                case 1:

                    playerS = Properties.Resources.Panzer;
                    playerProjectilS = Properties.Resources.Player_projektil;
                    enemyS = Properties.Resources.Allies_Plane;
                    enemyProjectilS = Properties.Resources.Bomb;
                    protectionS = Properties.Resources.Bunker;

                    break;
            }
        }



        #region Sound/Effect
        SoundPlayer sndMain;
        SoundPlayer sndEnemyDeath;
        private void Sound()
        {
            Stream strMain = Properties.Resources.music_8bit_jammer;
            sndMain = new SoundPlayer(strMain);
            sndMain.Load();
            if (sndMain.IsLoadCompleted)
            {
                sndMain.PlayLooping();
            }
            else
            {
                MessageBox.Show("Sound error");
            }

        }
        
        private void PlaySoundEnemyDeath()
        {
            Stream strEnemyDeath = Properties.Resources.retro_damage_hurt_ouch_12;
            sndEnemyDeath = new SoundPlayer(strEnemyDeath);
            sndEnemyDeath.LoadAsync();
     //       sndEnemyDeath.Play();
            
            
        }

        #endregion

        #region Create Actors

        private void createProjektilActor()
        {
            act1.YLoc = -100;
            act1.XLoc = -100;
            act2.YLoc = -200;
            act2.XLoc = -200;
        }

        private void createPlayerActor()
        {
            act0.XLoc = this.ClientSize.Width / 2 - 25;
            act0.YLoc = this.ClientSize.Height - 75;                       
        }
        
        private void createEnemyObjekt()
        {
            //10 x / 4y           
            
                for (int x = 0; x <= 3; x++)
                {
                    for (int y = 0; y <= 9; y++)
                    {
                        Actor enemy = new Actor();

                          //X LOcation Start
                            enemy.YLoc = 50 * x + 10;
                            enemy.XLoc = this.ClientSize.Width / 11 * y + 50;
                            enemy.Health = GameSetting.Enemyhealth;          
                        
                        //Add new Enemy Location + Actor to List
                        enemies.Add(enemy);
                    }
                }
        }

        private void createProtection()
        {
            for (int i = 0; i <= 3; i++)
            {
                Actor prop = new Actor();

                prop.Health = GameSetting.Protection;
                prop.YLoc = this.ClientSize.Height/ 2 + this.ClientSize.Height / 5;
                prop.XLoc = this.ClientSize.Width / 4 * i + 50;

                protection.Add(prop);
            }
        }

        private void EnemyShot()
        {    
            //random Position
            
            int rndPos;

                rndPos = rndP.Next(0, 40);
            
            

                if (enemies[rndPos].Health != 0 && !act2.Action)
                {
                    act2.YLoc = enemies[rndPos].YLoc + 10;
                    act2.XLoc = enemies[rndPos].XLoc + 5;
                    act2.Action = true;

                 if(GameSetting.Cheat != 2)
                    {
                    tmr_EnemyProjectil.Interval = 4000;
                    }
                 else
                    {
                    tmr_EnemyProjectil.Interval = 400;
                    }
                    
                }
                else
                    {
                        tmr_EnemyProjectil.Interval = 100;
                    }
        }

        #endregion
                
        #region GameControl

        #region OnPiant
        /// <summary>
        /// This is the method to run when the timer is raised.
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            // Invalidate visual representation of the MainForm to raise OnPaint method.
            this.Invalidate();
        }

        /// <summary>
        /// This Method paints on top of the MainForm.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            Graphics graphics = e.Graphics;


            #region Text

            string drawStringH = "Playerhealth:";

            if (GameSetting.Cheat != 3)
            {
                drawStringH = drawStringH + act0.Health.ToString();                
            }
            else
            {
                drawStringH = drawStringH + " Invulnerable";
            }

            

            Brush Brush = new SolidBrush(Color.Blue);
            Font drawFont = new Font("MV Boli", 20);

            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;

            e.Graphics.DrawString(drawStringH, drawFont, Brush, 35 , this.ClientSize.Height - 50, stringFormat);

            string drawStringK = "Score: " + DestroyedEnemy.ToString();

            stringFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;

            e.Graphics.DrawString(drawStringK, drawFont, Brush, this.ClientSize.Width / 2 + 200, this.ClientSize.Height - 40, stringFormat);






            #endregion

            #region Player

            

            
            Point pointPlayer = new Point(act0.XLoc, act0.YLoc);
            graphics.DrawImage(playerS, pointPlayer);

            Rectangle rectanglePlayer = new Rectangle(act0.XLoc, act0.YLoc,32,32);
            playerS.Equals(rectanglePlayer);

            #endregion

            #region Projektil

            //Projektil from Player

            
            Point pointPP = new Point(act1.XLoc, act1.YLoc);
            graphics.DrawImage(playerProjectilS, pointPP);

            Rectangle rectangleProjektil = new Rectangle(act1.XLoc, act1.YLoc, 12, 12);
            playerProjectilS.Equals(rectangleProjektil);

            //Projektil from Enemy

            
            Point pointEP = new Point(act2.XLoc, act2.YLoc);
            graphics.DrawImage(enemyProjectilS, pointEP);

            Rectangle rectangleProjektilE = new Rectangle(act2.XLoc, act2.YLoc, 3, 15);
            enemyProjectilS.Equals(rectangleProjektilE);
            #endregion

            #region Protection

            foreach (Actor propt in protection)
            {
                if(propt.Health != 0)
                {

                    
                    Point pointPR = new Point(propt.XLoc, propt.YLoc);
                    graphics.DrawImage(protectionS, pointPR);

                    rectangleProtection = new Rectangle(propt.XLoc, propt.YLoc, 50, 50);
                    enemyProjectilS.Equals(rectangleProtection);

                    bool isHit = false;


                    //Does Projectile hit Protection?
                    if (rectangleProjektil.IntersectsWith(rectangleProtection))
                    {
                        isHit = true;
                        act1.YLoc = -100;
                    }
                    else if (rectangleProjektilE.IntersectsWith(rectangleProtection))
                    {
                        isHit = true;
                        act2.YLoc = 100 + act0.YLoc;
                    }

                    if (isHit)
                    {
                        isHit = false;
                        propt.Health--;                       
                    }
                }
                
            }

            #endregion

            #region Enemies

            Pen enemiesPen = new Pen(Color.IndianRed, 5);
            Brush enemiesBrush = new SolidBrush(Color.Red);

            

                // Draw Enemies _ Win/Lose Condition _ DestroyEnemy //
                foreach (Actor enemy in enemies)
                {
                if (enemy.Health != 0)
                {


                    Point pointEnemy = new Point(enemy.XLoc, enemy.YLoc);
                    graphics.DrawImage(enemyS, pointEnemy);

                    Rectangle rectEnemy = new Rectangle(enemy.XLoc, enemy.YLoc, 25, 25);
                    enemyS.Equals(rectEnemy);

                    #region HitBoxDetection

                    #region GameCondition
                    //Win\Lose Condition
                    if (enemy.Health == 0)
                    {

                        if (DestroyedEnemy == 40)
                        {                            
                            //Close this GameForm
                            EndGame();
                        }
                    }
                    else if (act0.Health <= 0 || enemy.YLoc > act0.YLoc)
                    {
                        //Close this GameForm
                        EndGame();
                    }
                    else
                    {


                        #endregion

                        //Enemy Detection with Projektil
                        if (rectangleProjektil.IntersectsWith(rectEnemy))
                        {
                            //Hit is registered
                            act1.YLoc = -100;
                            enemy.Health--;


                            //Kill Overlapping Enemy
                            if (enemy.Health == 0)
                            {
                                while (act1.Action)
                                {
                                    PlaySoundEnemyDeath();
                                    DestroyedEnemy++;
                                    act1.Action = false;
                                }
                                enemy.Health = 0;
                            }
                        }

                        //Player Detection with Projektil
                        else if (rectangleProjektilE.IntersectsWith(rectanglePlayer))
                        {

                            //Hit is registered
                            act2.YLoc = 1000;
                            while (act2.Action)
                            {
                                act2.Action = false;

                                if (GameSetting.Cheat != 3)
                                    act0.Health--;
                            }
                        }
                    }
                }
             #endregion
             }
            #endregion

        }



        private void EndGame()
        {
            try
            {
                //Close this Game completly
                ChangeTimer();
                GameSetting.IsGameRunning = false;
                PlayerStop = true;

                Owner.Visible = true;
                Owner.BringToFront();
                this.Visible = false;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());                
            }
            
            
        }

        #endregion

        #region Create PlayerAction to Projectil

        private void tmr_Projectiles_Tick(object sender, EventArgs e)
        {
            callbackProjektil();
            callbackProjektilE();
        }

        //PlayerProjektilMovement
        private void callbackProjektil()
        {
            if (act1.Action && act1.YLoc >= 0)
            {
                act1.YLoc = act1.YLoc - projektilSpeed;

                this.Invalidate();
            }
            else if (act1.YLoc <= 0)
            {
                act0.Action = true;
                act1.Action = false;
                act1.XLoc = 3000;
                act1.YLoc = 3000;
                

                this.Invalidate();
            }

        }

        //EnemyProjektilMovement
        private void callbackProjektilE()
        {
            if (act2.Action && act2.YLoc <= act0.YLoc + 45)
            {
                act2.YLoc = act2.YLoc + projektilESpeed;

                this.Invalidate();
            }
            else if (act2.YLoc >= act0.YLoc)
            {                
                act2.Action = false;
                act2.XLoc = 2000;
                act2.YLoc = 2000;               

                this.Invalidate();
            }

        }

        #endregion

       

        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #region Controler

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Game is Playing?
           
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    callbackPlayer(false);
                }
                else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    callbackPlayer(true);
                }
                else if (e.KeyCode == Keys.Space && act0.Action)
                {
                    act0.Action = false;
                    act1.Action = true;
                    act1.XLoc = act0.XLoc + 2;
                    act1.YLoc = act0.YLoc - 16;
                    callbackProjektil();
                }
                     

            if(e.KeyCode == Keys.Escape)
            {
                PlayerStop = true;
                Owner.Visible = true;
                Owner.BringToFront();
                this.Visible = false;
                ChangeTimer();               
            }
        }

        //timer
        public void ChangeTimer()
        {
            
            //Stop Game
            tmr_Enemy.Enabled = !tmr_Enemy.Enabled;
            tmr_EnemyProjectil.Enabled = !tmr_EnemyProjectil.Enabled;
            tmr_Projectiles.Enabled = !tmr_Projectiles.Enabled;
            tmr_MotherShip.Enabled = !tmr_MotherShip.Enabled;
            tmr_MoveEnemy.Enabled = !tmr_MoveEnemy.Enabled;
            
            this.Enabled = !this.Enabled;

            
        }


        private void callbackPlayer(bool vec)
        {
            if (vec && act0.XLoc <= 650) //Move right
            {
                act0.XLoc = act0.XLoc + act0.PlayerMovement; ;
            }
            else if (!vec && act0.XLoc >= 20) //Move left
            {
                act0.XLoc = act0.XLoc - act0.PlayerMovement; ;
            }
            else
            {
                //---
            }

            this.Invalidate();

        }

        private void callbackEnemyGoDown()
        {
            foreach (Actor act in enemies)
            {
                act.YLoc = act.YLoc + 10;
            }
        }

        private void callbackEnemy(bool vec)
        {
            foreach (Actor act in enemies)
            {
                switch (EnemyDirection)
                {
                    case true:

                        act.XLoc = act.XLoc + enemySpeed;                        

                        break;


                    case false:

                        act.XLoc = act.XLoc - enemySpeed;

                        break;
                }
                this.Invalidate();
                
            }//endForeach
        }

        #endregion

        #region callback


        private void tmr_Enemy_Tick(object sender, EventArgs e)
        {
            callbackEnemy(EnemyDirection);
            
        }

       
        public void InstanceRectangleIntersection(PaintEventArgs e)
        {
            

        }

        private void tmr_EnemyProjectil_Tick(object sender, EventArgs e)
        {
            EnemyShot();

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
        private void GetEnemyPosition()
        {
            foreach(Actor enemy in enemies)
            {
                switch (EnemyDirection)
                {
                    case true:

                        if(enemy.XLoc >= 
680)
                        {
                            EnemyDirection = !EnemyDirection;
                            callbackEnemyGoDown();
                        }
                        break;


                    case false:

                        if (enemy.XLoc <= 20)
                        {
                            EnemyDirection = !EnemyDirection;
                            callbackEnemyGoDown();
                        }
                        break;                        
                }
            }
        }

        private void tmr_MoveEnemy_Tick_1(object sender, EventArgs e)
        {
            //Where is the enemy?
            GetEnemyPosition();
        }
    }
    #endregion
}
#endregion