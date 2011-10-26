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
    class GoldCard : Card
    {
        //CONSTR
        public GoldCard()
            : base("Gold", 6)
        {
            this.LoadTexture("images/gold");
        }

        public override void play(Player p)
        {
            p.Coins += 3;
            p.moveCard(this, p.hand, p.discard);
        }
    }
}

