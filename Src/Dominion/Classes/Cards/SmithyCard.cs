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
        public SmithyCard(Player Owner)
            : base("Smithy", 4, Owner)
        {
            this.LoadTexture("images/smithy");
        }

        public override void play()
        {
            if (owner.Actions > 0)
            {
                owner.Actions -= 1;
                owner.pickupCard(3);
                owner.moveCard(this, owner.hand, owner.discard);
            }
        }
    }
}
