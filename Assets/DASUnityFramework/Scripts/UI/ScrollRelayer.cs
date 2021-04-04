using UnityEngine;
using UnityEngine.EventSystems;

namespace DASUnityFramework.Scripts.UI
{
    public class ScrollRelayer : MonoBehaviour, IScrollHandler
    {
        public IScrollHandler scrollRelayTarget;
        
        protected virtual void Awake()
        {
            if(transform.parent)
                scrollRelayTarget = transform.parent.GetComponentInParent<IScrollHandler>();
        }
        
        public void OnScroll(PointerEventData eventData)
        {
            scrollRelayTarget?.OnScroll(eventData);
        }
    }
}