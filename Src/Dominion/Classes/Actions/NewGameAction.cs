using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominion.Classes;

namespace Dominion.Classes
{
    class NewGameAction : IButtonAction
    {        
        private Player _player;

        int numberOfPlayers;

        public NewGameAction(int n)
        {
            numberOfPlayers = n;
        }

        public void Execute()
        {
            
        }


    }
}
