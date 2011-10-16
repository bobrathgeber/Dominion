using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Dominion.Classes
{
    class SmartMouse
    {
        private MouseState _ms;
        private MouseState _msPrev;

        public SmartMouse()
        {
            _ms = Mouse.GetState();
            _msPrev = Mouse.GetState();
        }
        public Boolean Clicked { get; private set; }

        public void Update()
        {
            _ms = Mouse.GetState();

            if (_ms.LeftButton == ButtonState.Released && _msPrev.LeftButton == ButtonState.Pressed)
                Clicked = true;
            else
                Clicked = false;

            _msPrev = _ms;
        }

        public Boolean Inside(Rectangle boundingBox)
        {
            return boundingBox.Contains(new Point(_ms.X, _ms.Y));
        }
    }
}
