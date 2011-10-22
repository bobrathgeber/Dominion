using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dominion.Classes
{
    class StoreButton
        : Entity
    {
        private Card _card;
        private Store _store;
        
        private Texture2D _image;
        private Rectangle _boundingBox;

        public StoreButton(Store store, Card card)
        {
            _card = card;
            _store = store;
        }

        public void Click(Player p)
        {
            p.Buy(_card, _store);
        }

        public void Update(Controller controller)
        {
       //     if (controller.HasClicked(this))
       //         this.Click(controller.Player);               
        }
    }
}
