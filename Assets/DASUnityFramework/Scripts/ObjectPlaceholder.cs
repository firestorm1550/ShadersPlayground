using System;
using UnityEngine;

namespace DASUnityFramework.Scripts
{
    public class ObjectPlaceholder : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject);
        }
    }
}
