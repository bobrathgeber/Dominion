using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dominion.Classes
{
    public interface IClickable
    {
        void Click(Player p);
        Rectangle BoundingBox { get; }
    }
}
