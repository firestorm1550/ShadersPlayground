using UnityEngine;

namespace DASUnityFramework.Scripts.Layout3D
{
    [ExecuteAlways]
    public class LineLayout3D : MonoBehaviour
    {
        public float spacing = 3;
        public Vector3 direction = Vector3.right;
        
        
        public LayoutElement3D[] GetChildren() => GetComponentsInChildren<LayoutElement3D>();
        
        private void Update()
        {
            var children = GetChildren();
            for (int i = 0; i < children.Length; i++)
            {
                float offset = 0;
                Vector3 prevLocalPos = Vector3.zero;

                                
                if (i != 0)
                {
                    //half this one's width and half the previous one's width
                    offset = (children[i].GetSize(direction) / 2) + (children[i - 1].GetSize(direction) / 2) + spacing ;
                    prevLocalPos = children[i-1].transform.localPosition;
                }
                
                children[i].transform.localPosition = prevLocalPos + offset * direction;
            }
        }
    }
}