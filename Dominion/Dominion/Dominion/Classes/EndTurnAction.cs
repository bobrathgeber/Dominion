using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominion.Classes;

namespace Dominion.Classes
{
    class EndTurnAction : IButtonAction
    {
        private Player _player;

        public Player player
        {
            get { return _player; }
            set { _player = value; }
        }


        public void Execute()
        {
            _player.endTurn();
        }


    }
}
