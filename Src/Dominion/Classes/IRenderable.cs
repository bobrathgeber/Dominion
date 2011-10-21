using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Dominion.Classes
{
    interface IRenderable
    {
        Rectangle BoundingBox { get; set; }
        void Draw(SpriteBatch batch);
    }
}
