using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominion.Classes
{
    /// <summary>
    /// This static class observs user interactions and triggers their events
    /// </summary>
    /// <remarks>
    /// For instance notice that the observer watches for the controller to click 'clickables'. When it
    /// sees this happen, it triggers the 'clickables' click event.
    /// 
    /// I'm not totally fond of this way of doing things, but I think it works.
    /// 
    /// All IInputObservers should delegate to this class to do the actual testing, which is really weak sauce. Take a look
    /// at the code in Button now. You'll see that this class is leveraged there.
    /// </remarks>
    public class InteractionManager
    {
        //public static void TriggerClick(Controller controller, IClickable clickable)
        //{
        //    clickable.Click(controller.Player);
        //}

        //public static void ObserveAndTriggerHover(Controller controller, IHoverable hoverable)
        //{

        //}
    }
}
