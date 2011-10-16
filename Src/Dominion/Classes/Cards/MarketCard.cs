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
        public MarketCard(Player Owner)
            : base("Market", 5, Owner)
        {
            this.LoadTexture("images/market");
        }

        public override void play()
        {
            if (owner.Actions > 0)
            {
                owner.Buys += 1;
                owner.Coins += 1;
                owner.pickupCard(1);
                owner.moveCard(this, owner.hand, owner.discard);
            }
        }
    }
}
