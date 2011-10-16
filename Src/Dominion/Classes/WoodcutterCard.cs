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
    class WoodcutterCard : Card
    {
        //CONSTR
        public WoodcutterCard(Player Owner)
            : base("Woodcutter", 3, Owner)
        {
            this.LoadTexture("images/woodcutter");
        }

        public override Card Copy(Player o)
        {
            WoodcutterCard c = new WoodcutterCard(o);
            return c;
        }

        public override void play()
        {
            if (owner.Actions > 0)
            {
                owner.Actions -= 1;
                owner.Buys += 1;
                owner.Coins += 2;
                owner.moveCard(this, owner.hand, owner.discard);
            }
        }
    }
}
