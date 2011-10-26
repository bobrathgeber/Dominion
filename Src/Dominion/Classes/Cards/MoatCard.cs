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
    class MoatCard : Card
    {

        //CONSTR
        public MoatCard()
            : base("Moat", 2)
        {
            this.LoadTexture("images/moat");
        }

        public override void play(Player p)
        {
            if (p.Actions > 0)
            {
                p.Actions -= 1;
                p.pickupCard(2);
                p.moveCard(this, p.hand, p.discard);
            }
        }
    }
}
