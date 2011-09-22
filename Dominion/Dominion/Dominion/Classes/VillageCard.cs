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
            : base("VillageCard", 3)
        {
            this.LoadTexturue("images/village");
            actions = 2;
            cards = 1;
        }
    }
}
