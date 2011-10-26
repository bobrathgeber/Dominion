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
    class SmithyCard : Card
    {
        //CONSTR
        public SmithyCard()
            : base("Smithy", 4)
        {
            this.LoadTexture("images/smithy");
        }

        public override void play(Player p)
        {
            if (p.Actions > 0)
            {
                p.Actions -= 1;
                p.pickupCard(3);
                p.moveCard(this, p.hand, p.discard);
            }
        }
    }
}
