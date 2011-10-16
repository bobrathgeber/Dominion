using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominion.Classes;

namespace Dominion.Classes
{
    public class BuyCardAction : IButtonAction
    {
        private Player _player;
        private Store _store;
        private Card _card;

        public Player player
        {
            get { return _player; }
            set { _player = value; }
        }
        public Store store
        {
            get { return _store; }
            set { _store = value; }
        }

        public void Execute()
        {
            var newCard = _card;
            
            store.buyCard(_player, newCard);
        }

        public void setCard(Card c)
        {
            _card = c;
        }


    }
}
