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
    class VillageCard : Card
    {
        private int actions;
        private int cards;

        //CONSTR
        public VillageCard()
            : base("Village", 3)
        {
            this.LoadTexture("images/village");
            actions = 2;
            cards = 1;
        }

        public override void play(Player p)
        {
            if (p.Actions > 0)
            {
                p.Actions += 1;
                p.moveCard(this, p.hand, p.discard);
                p.pickupCard(1);
                
            }
        }
    }
}
