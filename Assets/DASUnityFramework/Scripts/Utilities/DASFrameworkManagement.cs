using UnityEngine;

namespace DASUnityFramework.Scripts.Utilities
{
    public static class DASFrameworkManagement
    {
        public static bool IsDASFrameworkProject => Application.productName == "DAS Unity Framework";
    }
}