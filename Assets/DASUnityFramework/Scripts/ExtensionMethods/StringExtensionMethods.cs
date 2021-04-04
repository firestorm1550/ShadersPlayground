using System.Collections.Generic;
using System.IO;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static int IntValue(this string str)
        {
            return int.Parse(str);
        }
        
        public static bool TryGetIntValue(this string str, out int value)
        {
            return int.TryParse(str, out value);
        }

        public static List<string> GetFilesRecursivelyInDirectory(this string directory)
        {
            List<string> files = new List<string>();
            foreach (string dir in Directory.EnumerateDirectories(directory))
            {
                files.AddRange(GetFilesRecursivelyInDirectory(dir));
            }

            files.AddRange(Directory.EnumerateFiles(directory));
            return files;
        }

        public static string CamelCaseToEnglishTitle(this string camel)
        {
            string title = "";

            for (int i = 0; i < camel.Length; i++)
            {
                if (i == 0)
                {
                    title += char.ToUpperInvariant(camel[i]);
                }
                else
                {
                    if (char.IsUpper(camel[i]))
                        title += " ";
                    title += camel[i];
                }

            }

            return title;
        }

        /// <summary>
        /// removes "(Clone)" from any string passed in
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Clean(this string s)
        {
            return s.Replace("(Clone)", "");

        }
    }
}