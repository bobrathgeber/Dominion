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
        public new void Add(Card card)
        {
            var box = new Rectangle();
            box.X = ((this.Count * 140) + 20);
            box.Y = 600;
            box.Width = card.Image.Width;
            box.Height = card.Image.Height;
            card.position = box;
            card.Visible = true;

            base.Add(card);
        }
        public new void Remove(Card card)
        {
            var box = new Rectangle();
            box.X = 0;
            box.Y = 0;
            box.Width = card.Image.Width;
            box.Height = card.Image.Height;
            card.position = box;
            card.Visible = false;

            base.Remove(card);
        }
    }
}
