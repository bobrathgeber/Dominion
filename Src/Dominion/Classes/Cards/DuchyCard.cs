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
    class DuchyCard : Card
    {
        //CONSTR
        public DuchyCard(Player Owner)
            : base("Duchy", 5, Owner)
        {
            this.LoadTexture("images/duchy");
            _VP = 3;
            owner = Owner;
        }

        public override Card Copy(Player o)
        {
            DuchyCard c = new DuchyCard(o);
            return c;
        }

        public override void play()
        {

        }
    }
}
