using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Dominion.Classes
{
    interface IDrawable
    {
        void Draw(SpriteBatch batch);
    }
}
