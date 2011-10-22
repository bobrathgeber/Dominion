using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dominion.Classes
{
    public class HandButton
        : IInputObserver, IClickable, IRenderable
    {
        private Card _card;
        private Texture2D _image;

        private Rectangle _boundingBox;
        public Rectangle BoundingBox
        {
            get
            {
                return _boundingBox;
            }
            set
            {
                _boundingBox = value;
            }
        }

        public HandButton(Card card)
        {
            _card = card;
            BoundingBox = new Rectangle();
            _image = card.Image;
        }

        public void Click(Player p)
        {
            p.Play(_card);
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            throw new NotImplementedException();
        }

        public void Update(Controller controller)
        {
            throw new NotImplementedException();
        }
    }
}
