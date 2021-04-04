using System;
using UnityEngine;

namespace DASUnityFramework.Scripts
{
    /// <summary>
    /// This class is designed to handle the moderately frequent case in which an object is not supposed to handle its own OnMouse events.
    /// This is common when coding simple, generic, and interactible objects. Examples include UI handles, model variants, and AttachmentPoints.
    ///
    /// Additionally, this becomes necessary if a single object contains multiple mesh objects.
    ///
    /// USAGE EXAMPLE:
    /// You want mouse events on a tank to act the same, no matter whether they're on the turret, treads, or body.
    /// You'd create a script called Tank, put it on the root object. Then, put each mesh as a child of this one.
    ///
    ///
    /// Hierarchy:
    ///    Tank
    ///         Body
    ///         Treads
    ///         Turret
    ///
    /// On each of body, treads, and turret, you would put this script. Then in the tank's awake or initialization function,
    /// you would set each relavent mouse event action on each of the three MouseEventRelayer's in it's children.
    /// 
    /// </summary>
    public class MouseEventRelayer : MonoBehaviour
    {
        public Action<MouseEventRelayer> mouseEnter;
        public Action<MouseEventRelayer> mouseDrag;
        public Action<MouseEventRelayer> mouseDown;
        public Action<MouseEventRelayer> mouseOver;
        public Action<MouseEventRelayer> mouseExit;
        public Action<MouseEventRelayer> mouseUp;
        public Action<MouseEventRelayer> mouseUpAsButton;


        private void Update()
        {
            //This is here so the enabled/disabled checkbox appears in the inspector.
        }

        #region EventRelays

        public void OnMouseEnter()
        {
            if (enabled)
                mouseEnter?.Invoke(this);
        }

        public void OnMouseDrag()
        {
            if (enabled)
                mouseDrag?.Invoke(this);
        }

        public void OnMouseOver()
        {
            if (enabled)
                mouseOver?.Invoke(this);
        }

        public void OnMouseDown()
        {
            if (enabled)
                mouseDown?.Invoke(this);
        }

        public void OnMouseExit()
        {
            if (enabled)
                mouseExit?.Invoke(this);
        }

        public void OnMouseUp()
        {
            if (enabled)
                mouseUp?.Invoke(this);
        }

        public void OnMouseUpAsButton()
        {
            if (enabled)
                mouseUpAsButton?.Invoke(this);
        }

        #endregion
    }
}