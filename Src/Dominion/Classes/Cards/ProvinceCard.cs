﻿using System;
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
    class ProvinceCard : Card
    {
        //CONSTR
        public ProvinceCard()
            : base("Province", 0)
        {
            this.LoadTexture("images/province");
            _VP = 6;
        }

        public override void play(Player p)
        {

        }
    }
}
