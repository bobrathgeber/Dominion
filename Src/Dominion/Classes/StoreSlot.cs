using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dominion.Classes
{
    public class StoreSlot : Entity, IRenderable, IInputObserver, IClickable
    {
        private Label _label;
        private List<Card> _cards;
        private Rectangle _boundingBox;
        private Boolean _highlight;
        private Boolean _selected;

        public Boolean Enabled { get; set; }
        public string Name { get; set; }
        public int Row { get; set; }

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
        public Boolean Visible { get { return HasCards; } }
        public Boolean HasCards { get { return _cards.Count > 0; } }

        public StoreSlot()
        {
            _label = new Label();
            _cards = new List<Card>();
            _boundingBox = new Rectangle();
            Registry.GameEntities.Add(_label);
            Enabled = true;
        }

        public void AddCard(Card card)
        {
            if (_cards.Count == 0)
            {
                // this is the first card, set the name
                this.Name = card.Name;
            }

            _cards.Add(card);
            UpdateLabel();
        }

        public Card RemoveTopCard()
        {
            var c = _cards[0];
            _cards.RemoveAt(0);
            UpdateLabel();

            if (_cards.Count == 0)
            {
                // that was the last card, reset the name
                this.Name = string.Empty;
            }
            return c;
        }

        public void UpdateLabel()
        {
            _label.Text = _cards.Count.ToString();
            _label.BoundingBox = (new Vector2(BoundingBox.X + BoundingBox.Width / 2 - _label.GetSize().X / 2, BoundingBox.Y + 100));
        }

        public void Draw(SpriteBatch batch)
        {
            if (HasCards == false) 
                return; // don't draw

            var texture = _cards[0].Image;

            if (_highlight)
            {
                batch.Draw(texture, BoundingBox, Color.Silver);
            }
            else if (_selected)
            {
                batch.Draw(texture, BoundingBox, Color.Red);
            }
            else if (Visible)
            {
                batch.Draw(texture, BoundingBox, Color.White);
            }
        }

        public Card TopCard()
        {
            return _cards.Last();
        }


        public void Update(Controller controller)
        {
            if (controller.HasClicked(this))
            {
                controller.Player.BuyCard(TopCard());
            }
        }
    }
}
