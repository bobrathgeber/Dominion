using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dominion.Classes
{
    class HandButton
     : IClickable
    {
        private Card _card;
        private Rectangle _position;

        public HandButton(Card card)
        {
            _card = card;
            _position = new Rectangle();
        }

        public void Click(Player p)
        {
            p.Play(_card);
        }

        public Rectangle Position
        {
            get
            {
                return _position;
            }
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public Rectangle BoundingBox
        {
            get { throw new NotImplementedException(); }
        }
    }
}
