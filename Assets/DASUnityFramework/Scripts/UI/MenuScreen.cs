using UnityEngine;

namespace DASUnityFramework.Scripts.UI
{
    /// <summary>
    /// For usage documentation, see the MenuScreenManager.cs usage example
    /// </summary>
    [DisallowMultipleComponent]
    public class MenuScreen : MonoBehaviour
    {
        public Vector3 StartPosition { get; private set; }
        protected MenuScreenManager _manager;

        public void Initialize(MenuScreenManager menuScreenManager)
        {
            _manager = menuScreenManager;
            StartPosition = transform.position;
        }

        public void SetMeActive()
        {
            _manager.SetScreen(this);
        }
    }
}