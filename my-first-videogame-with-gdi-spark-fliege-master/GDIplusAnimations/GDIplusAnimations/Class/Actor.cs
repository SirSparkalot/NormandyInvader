using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDIplusAnimations
{
    class Actor
    {

        //Private Stats
        private static int playerMovement = 3;
        private int health;
        private bool action;

        //Private Location
        private int xLoc;
        private int yLoc;



        #region public
        //Public
        public int PlayerMovement
        {
            get
            {
                return playerMovement;
            }
            set
            {
                playerMovement = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public bool Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }


        //Location
        public int XLoc
        {
            get
            {
                return xLoc;
            }
            set
            {
                xLoc = value;
            }
        }
        public int YLoc
        {
            get
            {
                return yLoc;
            }
            set
            {
                yLoc = value;
            }
        }

        

        #endregion

        public Actor() { }

        public Actor(int health, bool action)
        {
            PlayerMovement = playerMovement;
            Health = health;
            Action = action;
        }

        public Actor(int health, bool action, int x, int y)
        {
            PlayerMovement = playerMovement;
            Health = health;
            Action = action;
            XLoc = x;
            YLoc = y;
        }
        

    }
}
