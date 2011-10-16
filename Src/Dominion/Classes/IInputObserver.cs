using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominion.Classes
{
    /// <summary>
    /// Classes that implement this interface watch controller input
    /// </summary>
    public interface IInputObserver
    {
        void Update(Controller controller);
    }
}
