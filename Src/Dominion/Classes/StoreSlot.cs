using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dominion.Classes
{
    public class StoreSlot
    {
        private Label _label;
        private List<Card> _cards;
        private Rectangle _boundingBox;

        public string Name { get; set; }
        public int Row { get; set; }

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
        public Boolean HasCards { get { return _cards.Count > 0; } }

        public StoreSlot()
        {
            _label = new Label();
            _cards = new List<Card>();
            _boundingBox = new Rectangle();
            ServiceLocator.GameEntities.Add(_label);
        }

        public void AddCard(Card card)
        {
            if (_cards.Count == 0)
            {
                // this is the first card, set the name
                this.Name = card.Name;
            }

            card.position = BoundingBox;
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
                this.Name = "";
            }
            return c;
        }

        public void UpdateLabel()
        {
            _label.Text = _cards.Count.ToString();
            _label.BoundingBox = (new Vector2(BoundingBox.X + BoundingBox.Width / 2 - _label.GetSize().X / 2, BoundingBox.Y + 100));
        }
    }
}
