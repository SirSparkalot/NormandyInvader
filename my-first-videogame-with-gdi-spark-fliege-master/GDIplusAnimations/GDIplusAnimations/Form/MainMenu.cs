using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIplusAnimations
{
    public partial class MainMenu : Form
    {
        //Class
        GameSetting setting = new GameSetting();

        //Variables
        Actor actST = new Actor();  //<< String Title
        Actor actPL = new Actor();  //<< Plane leftside
        Actor actSP = new Actor();  //<< Spaceship rightside
        private static bool vecST;
        private static char chrBtn;        
        
        //Class Form
        MainForm main;
        Option opt;

        public MainMenu()
        {
            InitializeComponent();

            DoubleBuffered = true;

            //Clientsize
            actST.XLoc = this.ClientSize.Width / 2 - 140;
            actST.YLoc = this.ClientSize.Width / 2 - 140;

            actPL.XLoc = this.ClientSize.Width / 4 - 18;
            actPL.YLoc = 130;

            actSP.XLoc = this.ClientSize.Width / 4 + 200;
            actSP.YLoc = 130;
        }

        //Setting up Button.text
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            switch (GameSetting.IsGameRunning)
            {
                //Change MainMenu to "Pause" Menu
                case true:
                    
                    btnOption.Text = "Close";
                    btnPlay.Text = "Resume";                   

                    break;

                //Standard GameMenu
                case false:

                    btnOption.Text = "Option";
                    btnPlay.Text = "Play";

                    break;
            }
        }

        
        //Painting time >> Title and Planes
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            #region Text

            string drawString = "Space Invader";

            Brush Brush = new SolidBrush(Color.Blue);
            Font drawFont = new Font("MV Boli", 30);

            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;

            e.Graphics.DrawString(drawString, drawFont, Brush, actST.XLoc, actST.YLoc - 30, stringFormat);

            #endregion

            //---------------------------

            #region plane/spaceship

                     
            Bitmap enemyBild = new Bitmap(Properties.Resources.Allies_Plane);
            Point pointEnemy = new Point(actPL.XLoc, actPL.YLoc);
            graphics.DrawImage(enemyBild, pointEnemy);            


            Bitmap SPBild = new Bitmap(Properties.Resources.spaceship);
            Point pointSP = new Point(actSP.XLoc, actSP.YLoc);
            graphics.DrawImage(SPBild, pointSP);
            



            #endregion
        }
        

        #region Buttons

        //Play_Button
        private void btnPlay_Click(object sender, EventArgs e)
        {
            

            if (!GameSetting.IsGameRunning)
            {
                //Try to start Game
                try
                {
                    //Create MainForm and Open it
                    if (main == null)
                    {
                        main = new MainForm();              
                        
                    }
                    else
                    {
                        main = null;
                        main = new MainForm();
                    }

                    main.Owner = this;

                    main.Show();
                    Hide();

                                      
                    GameSetting.IsGameRunning = true;
                    
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
            else
            {
                //Try to Close Game
                try
                {
                    this.Visible = false;
                    main.Visible = true;
                    main.ChangeTimer();
                    main.PlayerStop = false;
                    
                    
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
                                 
            
        }

        //Exit_Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Option_Button
        private void btnOption_Click(object sender, EventArgs e)
        {
            if (!GameSetting.IsGameRunning)
            {

                //Create MainForm and Open it
                if (opt == null)
                {
                    opt = new Option();

                }

                opt.Owner = this;
                this.Visible = false;
                opt.Visible = true;

                
            }
            else
            {
                try
                {
                    if (main == null)
                    {
                       
                        Application.Restart();
                    }
                    else
                    {
                        main.Close();
                        
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
                finally
                {
                    
                    btnOption.Text = "Option";
                    btnPlay.Text = "Play";
                    GameSetting.IsGameRunning = false;
                }
              
            }
            
        }

        #endregion

        #region Timer
        //Interact immediately / only with Callback
        private void TmrMoveing_Tick(object sender, EventArgs e)
        {
            CallbackString();
        }
        private void tmr_MovePlane_Tick(object sender, EventArgs e)
        {
            CallbackPlane();
        }

        #endregion

        #region Callback >>For OnPaint<<

        //Move Plane/Spaceship to Overlapping Button with cursor
        private void CallbackPlane()
        {
            switch (chrBtn)
            {
                //BtnPlay
                case 'p':

                    if(actPL.YLoc != 130)
                    {
                        actPL.YLoc--;
                        actSP.YLoc--;
                    }

                    break;

                //BtnOption
                case 'o':

                    if (actPL.YLoc != 210)
                    {
                        if(actPL.YLoc <= 210)
                        {
                            actPL.YLoc++;
                            actSP.YLoc++;
                        }
                        else
                        {
                            actPL.YLoc--;
                            actSP.YLoc--;
                        }
                    }

                    break;

                //BtnExit
                case 'e':

                    if (actPL.YLoc != 310)
                    {
                        actPL.YLoc++;
                        actSP.YLoc++;
                    }

                    break;
            }
            this.Invalidate();
        }

        //Move Text
        private void CallbackString()
        {
            if (actST.XLoc >= this.ClientSize.Width / 2 - 170 && vecST)
                actST.XLoc--;

            else if (actST.XLoc <= this.ClientSize.Width / 2 - 110 && !vecST)
                actST.XLoc++;
            else
                vecST = !vecST;
            this.Invalidate();
        }

        #endregion

        #region ----
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Button Overlapping with cursor
        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            chrBtn = 'p';
        }

        private void btnOption_MouseEnter(object sender, EventArgs e)
        {
            chrBtn = 'o';
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            chrBtn = 'e';
        }
        #endregion
    }
}
