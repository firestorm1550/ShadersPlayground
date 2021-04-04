using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DASUnityFramework.Editor
{
    public class MiscTools
    {
        [MenuItem("Misc/How Many Objects Selected?")]
        static void PrintNumberOfObjectsSelected()
        {
            Debug.Log(Selection.objects.Length);
        }

        [MenuItem("Misc/Print Color Code For Selected Images")]
        static void PrintColorCodeForSelectedImages()
        {
            string output = "";
            
            GameObject[] objects = Selection.gameObjects;
            foreach (GameObject gameObject in objects)
            {
                Image image = gameObject.GetComponent<Image>();
                if (image)
                {
                    output += "new Color(" + image.color.r + "f, " + image.color.g + "f, " + image.color.b + "f)\n";
                }
            }
            Debug.Log(output);
        }
        
        [MenuItem("Misc/Append \" PLACEHOLDER\" to selected GameObjects' names")]
        static void AppendPLACEHOLDERToGameObjectNames()
        {
            string stringToAppend = " PLACEHOLDER";

            foreach (GameObject gameObject in Selection.gameObjects)
            {
                gameObject.name = gameObject.name + stringToAppend;
            }
        }
        
        [MenuItem("Misc/Append numbers to selected GameObjects' names")]
        static void AppendNumberToGameObjectNames()
        {
            for (var index = 0; index < Selection.gameObjects.Length; index++)
            {
                GameObject gameObject = Selection.gameObjects[index];
                gameObject.name = gameObject.name + index;
            }
        }
        
        
        
    }
}