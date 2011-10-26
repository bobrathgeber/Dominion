using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;

namespace Dominion.Classes
{
    class MarketCard : Card
    {
        //CONSTR
        public MarketCard()
            : base("Market", 5)
        {
            this.LoadTexture("images/market");
        }

        public override void play(Player p)
        {
            if (p.Actions > 0)
            {
                p.Buys += 1;
                p.Coins += 1;
                p.pickupCard(1);
                p.moveCard(this, p.hand, p.discard);
            }
        }
    }
}
