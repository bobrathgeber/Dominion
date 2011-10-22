using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dominion.Classes
{
    public class HandButton
        : Entity, IInputObserver, IClickable, IRenderable
    {
        // fields
        private Card _card;
        private Texture2D _image;
        private Rectangle _boundingBox;
        private Boolean _highlight;
        private Boolean _selected;

        // properties
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
        public Boolean Visible
        {
            get
            {
                return HasCard;
            }
        }
        public Boolean HasCard
        {
            get
            {
                return _card != null;
            }
        }
        public Card Card
        {
            get
            {
                return _card;
            }
            set
            {
                _image = (value != null) ? value.Image : null;
                _card = value;
            }
        }

        // ctor
        public HandButton()
        {
            _selected = false;
            _highlight = false;
            BoundingBox = new Rectangle();
        }

        // methods
        public void RemoveCard()
        {
            Card = null;
        }
        public void Click(Player p)
        {
            p.Play(_card);
        }

        public void Location(int x, int y)
        {
            _boundingBox.X = x;
            _boundingBox.Y = y;
        }

        public void Scale(int w, int h)
        {
            _boundingBox.Width = w;
            _boundingBox.Height = h;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_highlight)
            {
                spriteBatch.Draw(_card.Image, BoundingBox, Color.Silver);
            }
            else if (_selected)
            {
                spriteBatch.Draw(_card.Image, BoundingBox, Color.Red);
            }
            else if (Visible)
            {
                spriteBatch.Draw(_card.Image, BoundingBox, Color.White);
            }

        }
        public void Click()
        {
            throw new NotImplementedException();
        }

        public void Update(Controller controller)
        {
            //throw new NotImplementedException();
        }
    }
}
