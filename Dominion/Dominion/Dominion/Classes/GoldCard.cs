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
        private int cost;
        private int coins;

        //CONSTR
        public void initalize()
        {
            imagePath = "images/gold";
            cost = 6;
            coins = 3;
        }
    }
}

