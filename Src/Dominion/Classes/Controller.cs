using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominion.Classes
{
    class Controller
    {
        private SmartMouse _sm;

        public Controller(Player p)
        {
            _sm = new SmartMouse();
            Player = p;
        }

        public void UpdateState()
        {
            _sm.Update();
        }

        public Player Player { get; private set; }

        public Boolean HasClicked(IClickable clickable)
        {
            return _sm.Clicked && _sm.Inside(clickable.BoundingBox);
        }
    }
}
