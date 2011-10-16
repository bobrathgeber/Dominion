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
        private Rectangle _boundingBox;
        private string _text;
        private Vector2 _textLocation;
        private SpriteFont _font;
        private Texture2D _image;

        public StoreButton(Store store, Card card, SpriteFont font)
        {
            _card = card;
            _store = store;
            _boundingBox = new Rectangle();
            _image = card.Image;
            _font = font;
        }

        public Rectangle BoundingBox { 
            get { 
                return _boundingBox; 
            }
        }

        public string CardName
        {
            get
            {
                return _card.Name;
            }
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

        public void Click(Player p)
        {
            p.Buy(_card, _store);
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Vector2 size = _font.MeasureString(_text);
                _textLocation = new Vector2();
                _textLocation.Y = _boundingBox.Y + ((_boundingBox.Height / 2) - (size.Y / 2)) + 10;
                _textLocation.X = _boundingBox.X + ((_boundingBox.Width / 5));
            }
        }

        public void Draw(SpriteBatch batch)
        {

            //if (_boundingBox.Contains(new Point(ms.X, ms.Y)))
            //{
            //    batch.Draw(_image, _boundingBox, Color.Silver);

            //}
            //else
            //{
                batch.Draw(_image, _boundingBox, Color.White);
            //}
            //if (_text != null)
            //{
            //    batch.DrawString(_font, _text, _textLocation, Color.White);
            //}
        }

        public void Update(Controller controller)
        {
            InteractionManager.ObserveAndTriggerClick(controller, this);
        }
    }
}
