﻿using System;
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

            var max_hand_size = 50;
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
            CondenseHand();
        }
        public new void Remove(Card card)
        {
            var slot = _buttons.Find(x => x.Card == card);
            slot.RemoveCard();
            base.Remove(card);
            CondenseHand();
        }

        public void CondenseHand()
        {
            var tempHand = new List<Card>();
            foreach (HandButton b in _buttons)
            {              if (b.HasCard)
                {
                    var tempCard = b.Card;
                    b.RemoveCard();
                    var open_slot = _buttons.First(x => x.HasCard == false);
                    open_slot.Card = tempCard;
                }                               
            }

            if (base.Count > 5)
            {
                var xAdjustment = base.Count*7;
                for (var i = 0; i < base.Count; i++)
                {
                    _buttons[i].Location(i * (140-xAdjustment) + 20, 600);
                }
            }
            else
            {
                for (var i = 0; i < base.Count; i++)
                {
                    _buttons[i].Location(i * 140 + 20, 600);
                }
            }
        }
    }
}
