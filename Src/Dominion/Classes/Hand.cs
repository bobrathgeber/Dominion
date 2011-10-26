using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Dominion.Classes
{
    public class Hand : List<Card>
    {
        private List<HandButton> _buttons;

        public Hand()
        {
            _buttons = new List<HandButton>();

            var max_hand_size = 5;
            for(var i = 0; i < max_hand_size; i++)
            {
                var box = new Rectangle();
                box.X = i * 140 + 20;
                box.Y = 600;
                box.Width = 132;
                box.Height = 200;

                var hb = new HandButton();
                hb.BoundingBox = box;

                Registry.GameEntities.Add(hb);
                _buttons.Add(hb);
            }
        }
        public new void Add(Card card)
        {
            var open_slot = _buttons.First(x => x.HasCard == false);
            open_slot.Card = card;
            base.Add(card);
        }
        public new void Remove(Card card)
        {
            var slot = _buttons.Find(x => x.Card == card);
            slot.RemoveCard();
            base.Remove(card);
        }
    }
}
