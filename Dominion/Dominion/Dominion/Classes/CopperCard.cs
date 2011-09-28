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
        private int coins;
        Player owner;

        //CONSTR
        public CopperCard(Player o)
            : base("Copper", 1)
        {
            this.LoadTexturue("images/copper");

            coins = 1;
        }

        public override void play()
        {
            owner.Coins +=1;
            Console.Write("done");
        }
    }
}
