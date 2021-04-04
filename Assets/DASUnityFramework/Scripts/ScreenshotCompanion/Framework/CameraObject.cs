using System;
using UnityEngine;

namespace DASUnityFramework.Scripts.ScreenshotCompanion.Framework
{
    [Serializable]
    public class CameraObject
    {
        public GameObject cam;
        [HideInInspector] public bool deleteQuestion = false;
        public KeyCode hotkey = KeyCode.None;
    }
}