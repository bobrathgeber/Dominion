using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dominion.Classes
{
    public class HandButton
        : IInputObserver, IClickable, IRenderable
    {
        private Card _card;

        public HandButton(Card card)
        {
            _card = card;
            BoundingBox = new Rectangle();
        }

        public void Click(Player p)
        {
            p.Play(_card);
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public Rectangle BoundingBox
        {
            get;
            set;
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            throw new NotImplementedException();
        }
    }
}
