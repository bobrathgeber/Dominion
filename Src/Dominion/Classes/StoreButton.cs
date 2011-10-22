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
        : Entity, IInputObserver, IClickable, IRenderable
    {
        private Card _card;
        private Store _store;
        private string _text;
        private Vector2 _textLocation;
        
        private Texture2D _image;
        private Rectangle _boundingBox;

        public StoreButton(Store store, Card card)
        {
            _card = card;
            _store = store;
            BoundingBox = new Rectangle();
            _image = card.Image;
        }

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

        public string CardName
        {
            get
            {
                return _card.Name;
            }
        }


        public void Click(Player p)
        {
            p.Buy(_card, _store);
        }



        public void Draw(SpriteBatch batch)
        {

            //if (_boundingBox.Contains(new Point(ms.X, ms.Y)))
            //{
            //    batch.Draw(_image, _boundingBox, Color.Silver);

            //}
            //else
            //{
                batch.Draw(_image, BoundingBox, Color.White);
            //}

        }

        public void Update(Controller controller)
        {
            if (controller.HasClicked(this))
                this.Click(controller.Player);               
        }
    }
}
