using UnityEngine;

namespace DASUnityFramework.Scripts.Utilities
{
    public static class InputUtilities
    {
        /// <summary>
        /// Returns true if any of the keys in "codes" are currently down
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static bool AnyKey(params KeyCode[] codes)
        {
            foreach (KeyCode code in codes)
            {
                if (Input.GetKey(code))
                    return true;
            }

            return false;
        }
    }
}