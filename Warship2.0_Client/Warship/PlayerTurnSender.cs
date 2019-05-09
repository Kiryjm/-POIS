using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warship
{
    class PlayerTurnSender
    {
        private int yourTurn;

        public PlayerTurnSender()
        {
            yourTurn = 2;
        }

        public int YourTurn
        {
            get { return yourTurn; }
            set { yourTurn = value; }
        }
    }
}
