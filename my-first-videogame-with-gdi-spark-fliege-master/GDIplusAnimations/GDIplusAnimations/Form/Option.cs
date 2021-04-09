using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace GDIplusAnimations
{
    public partial class Option : Form
    {   
        //Import Libary to change Volume
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        //Class
        GameSetting Main = new GameSetting();

           

        public Option()
        {
            InitializeComponent();

            cbxDifficulty.SelectedIndex = GameSetting.Gamemode;
            cbxPlayerHealth.SelectedIndex = GameSetting.Playerhealth;
            cbxEnemyHeallth.SelectedIndex = GameSetting.Enemyhealth;
            cbxProtection.SelectedIndex = GameSetting.Protection;
            cbxCheat.SelectedIndex = GameSetting.Cheat;

            lbxSkin.SelectedIndex = GameSetting.Skin;
        }

        protected override void OnClosed(EventArgs e)
        {
           
                base.OnClosed(e);

                Environment.Exit(1);
            

        }

        //Volume
        private void tbrVolum_Scroll(object sender, EventArgs e)
        {
            // Calculate the volume that's being set. BTW: this is a trackbar!
            int NewVolume = ((ushort.MaxValue / 10) * tbrVolum.Value);
            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }

        //Button BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            Owner.Visible = true;
            Owner.BringToFront();
            this.Visible = false;

        }



        #region Gamemode

        private void cbxPlayerHealth_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameSetting.Playerhealth = cbxPlayerHealth.SelectedIndex;           
            
        }

        private void cbxEnemyHealth_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameSetting.Enemyhealth = cbxPlayerHealth.SelectedIndex + 1;
        }

        private void cbxCheat_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameSetting.Cheat = cbxCheat.SelectedIndex;
        }

        private void cbxProtection_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameSetting.Protection = cbxProtection.SelectedIndex;
        }
        
        private void cbxDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                     

            switch (cbxDifficulty.SelectedIndex)
            { 
                //Easy
                case 0:
                    GameSetting.Playerhealth = 6;
                    GameSetting.Enemyhealth = 0;
                    GameSetting.Protection = 3;                    
                    break;
                    //Medium
                case 1:
                    GameSetting.Playerhealth = 4;
                    GameSetting.Enemyhealth = 1;
                    GameSetting.Protection = 2;
                    break;
                    //Hard
                case 2:
                    GameSetting.Playerhealth = 2;
                    GameSetting.Enemyhealth = 2;
                    GameSetting.Protection = 1;
                    break;
                    //Hardcore
                case 3:
                    GameSetting.Playerhealth = 0;
                    GameSetting.Enemyhealth = 3;
                    GameSetting.Protection = 0;
                    break;
                    //casual
                case 4:
                    GameSetting.Playerhealth = 2;
                    GameSetting.Enemyhealth = 0;
                    GameSetting.Protection = 3;
                    break;

                    
            }

            cbxEnemyHeallth.SelectedIndex = GameSetting.Enemyhealth;
            cbxPlayerHealth.SelectedIndex = GameSetting.Playerhealth;
            cbxProtection.SelectedIndex = GameSetting.Protection;            
        }

        #endregion

        #region Skin selection

        private void gbxSkin_Enter(object sender, EventArgs e)
        {

        }

        private void lbxSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameSetting.Skin = lbxSkin.SelectedIndex;
            ShowSkin();
        }

        private void ShowSkin()
        {
            switch (GameSetting.Skin)
            {
                case 0:

                    pbxPlayerChar.Image = Properties.Resources.spaceship;
                    pbxPlayerPrj.Image = Properties.Resources.Projektil_Gegner;
                    pbxEnemyChar.Image = Properties.Resources.Enemy;
                    pbxEnemyPrj.Image = Properties.Resources.Projektil_Gegner;

                    break;

                case 1:

                    pbxPlayerChar.Image = Properties.Resources.Panzer;
                    pbxPlayerPrj.Image = Properties.Resources.Player_projektil;
                    pbxEnemyChar.Image = Properties.Resources.Allies_Plane;
                    pbxEnemyPrj.Image = Properties.Resources.Bomb;

                    break;
            }            
        }

        #endregion
    }
}
