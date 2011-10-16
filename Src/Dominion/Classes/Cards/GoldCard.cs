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
        public GoldCard(Player Owner)
            : base("Gold", 6, Owner)
        {
            this.LoadTexture("images/gold");
            owner = Owner;
        }

        public override Card Copy(Player o)
        {
            GoldCard c = new GoldCard(o);
            return c;
        }

        public override void play()
        {
            owner.Coins += 3;
            owner.moveCard(this, owner.hand, owner.discard);
        }

        public void setOwner(Player p)
        {
            owner = p;
        }
    }
}

