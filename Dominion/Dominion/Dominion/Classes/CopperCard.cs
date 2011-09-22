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
        private int cost;
        private int coins;

        //CONSTR
        public void Initialize ()
        {
            imagePath = "images/copper";
            cost = 0;
            coins = 1;
        }
    }
}
