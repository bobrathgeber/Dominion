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
        private int cost;
        private int actions;
        private int cards;

        //CONSTR
        public void intialize()
        {
            imagePath = "images/village";
            cost = 3;
            actions = 2;
            cards = 1;
        }
    }
}
