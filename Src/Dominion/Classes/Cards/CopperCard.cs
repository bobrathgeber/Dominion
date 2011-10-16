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
    class CopperCard : Card
    {
        //CONSTR
        public CopperCard(Player Owner)
            : base("Copper", 0, Owner)
        {
            this.LoadTexture("images/copper");
            owner = Owner;
        }

        public override Card Copy(Player o)
        {
            CopperCard c = new CopperCard(o);
            return c;
        }

        public override void play()
        {
            owner.Coins +=1;
            owner.moveCard(this, owner.hand, owner.discard);
            Console.Write("done");
        }
    }
}
