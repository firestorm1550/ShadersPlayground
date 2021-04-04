using System;
using System.IO;
using DASUnityFramework.Scripts.Utilities;
using UnityEditor;
using UnityEngine;

namespace DASUnityFramework.Editor
{
    public static partial class SyncBackToFramework
    {
        private static string DasUnityFrameworkPathFromRepos => Path.Combine("DASUnityFramework","Assets", "DASUnityFramework");

        public static void SyncLocalChanges(string sourcePath, string targetPathFromReposFolder)
        {
            
            if(Directory.Exists(sourcePath) == false)
                LogDirectoryDoesNotExist(sourcePath, true);
            
            string path1 = Path.Combine(DirectoryUtilities.OutsideUnityProjectFolder, targetPathFromReposFolder);
            if (Directory.Exists(path1))
            {
                DirectoryUtilities.CopyDirectory(sourcePath, path1);
                return;
            }

            string path2 = Path.GetFullPath(Path.Combine(DirectoryUtilities.OutsideUnityProjectFolder, "../", targetPathFromReposFolder));
            if (Directory.Exists(path2))
            {
                DirectoryUtilities.CopyDirectory(sourcePath, path2);
                return;
            }
            
            LogDirectoryDoesNotExist(path1);
            LogDirectoryDoesNotExist(path2);
        }
        
        
        [MenuItem("DAS Framework/Sync local changes to DAS Unity Framework")]
        private static void SyncLocalChangesToDASUF()
        {
            if(DASFrameworkManagement.IsDASFrameworkProject)
                throw new Exception("Can't copy from DAS Framework to itself");
            
            string localDASFrameworkFolder = DirectoryUtilities.DASUnityFrameworkFolder;
            SyncLocalChanges(localDASFrameworkFolder, DasUnityFrameworkPathFromRepos);
        }

        private static void LogDirectoryDoesNotExist(string path, bool throwException = false)
        {
            string message = "Directory: " + path + " does not exist";
            if(throwException)
                throw new DirectoryNotFoundException(message);
            else
                Debug.LogError(message);
        }
    }
}