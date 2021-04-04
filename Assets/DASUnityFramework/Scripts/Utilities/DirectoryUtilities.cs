using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace DASUnityFramework.Scripts.Utilities
{
    public static class DirectoryUtilities
    {
        public static string UnityAssetsFolder => Application.dataPath;
        public static string UnityProjectFolder => Path.GetFullPath(Path.Combine(UnityAssetsFolder, "../"));
        public static string OutsideUnityProjectFolder => Path.GetFullPath(Path.Combine(UnityProjectFolder, "../"));
        public static string DASUnityFrameworkFolder => Path.Combine(UnityAssetsFolder, "DASUnityFramework");
        public static string RPGSuiteUnityFrameworkFolder => Path.Combine(UnityAssetsFolder, "RPGSuiteUnityFramework");
        
        
        public static void ReplaceDirectory( string sourceDir, string destinationDir, HashSet<string> pathsToExclude = null)
        {
            if (Directory.Exists(destinationDir))
            {
                Directory.Delete(destinationDir, true);
                Debug.Log("Deleted directory: " + destinationDir);
            }

            CopyDirectory(sourceDir, destinationDir, pathsToExclude);
        }

        public static void CopyDirectory(string sourceDir, string destinationDir, HashSet<string> pathsToExclude = null)
        {
            
            if (pathsToExclude == null)
                pathsToExclude = new HashSet<string>();
           
            
            // Create subdirectory structure in destination    
            foreach (string dir in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(Path.Combine(destinationDir, dir.Substring(sourceDir.Length + 1)));
            }

            foreach (string fileName in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
            {
                if(pathsToExclude.Any(p=> fileName.Contains(p)) == false)
                    File.Copy(fileName, Path.Combine(destinationDir, fileName.Substring(sourceDir.Length + 1)), true);
            }

            Debug.Log("Copied " + sourceDir + " to " + destinationDir);
        }
    }
}