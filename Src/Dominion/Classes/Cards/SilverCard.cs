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
    class SilverCard : Card
    {
        //CONSTR
        public SilverCard(Player Owner)
            : base("Silver", 3, Owner)
        {
            this.LoadTexture("images/silver");
            owner = Owner;
        }

        public override void play()
        {
            owner.Coins += 2;
            owner.moveCard(this, owner.hand, owner.discard);
        }

        public void setOwner(Player p)
        {
            owner = p;
        }
    }
}
