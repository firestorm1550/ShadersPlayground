using System;
using System.IO;
using DASUnityFramework.Scripts.LoginManagement.AvoEx.AesEncryptor;
using UnityEngine;

namespace DASUnityFramework.Scripts.LoginManagement
{
    public static class CredentialsManager
    {
        const string kUsernameKey = "username";
        const string kCookieKey = "cookie";


        public static void StoreCurrentCredentials(string username, string password)
        {
            DeleteStoredCredentials();

            byte[] vector = AesEncryptor.GenerateIV();
            string encrypted = AesEncryptor.EncryptIV(password, vector);
            File.WriteAllBytes(Application.persistentDataPath + "/id", vector);

            PlayerPrefs.SetString(kUsernameKey, username);
            PlayerPrefs.SetString(kCookieKey, encrypted);
            PlayerPrefs.Save();
        }

        public static Tuple<string, string> GetStoredCredentials()
        {
            string password = "";
            string username = PlayerPrefs.GetString(kUsernameKey);
            string cookie = PlayerPrefs.GetString(kCookieKey);
            if (string.IsNullOrEmpty(username) == false && string.IsNullOrEmpty(cookie) == false)
            {
                byte[] vector = File.ReadAllBytes(Application.persistentDataPath + "/id");
                password = AesEncryptor.DecryptIV(cookie, vector);
            }

            return Tuple.Create(username, password);
        }

        public static void DeleteStoredCredentials()
        {
            File.Delete(Application.persistentDataPath + "/id");
            PlayerPrefs.SetString(kUsernameKey, string.Empty);
            PlayerPrefs.SetString(kCookieKey, string.Empty);
            PlayerPrefs.Save();
        }
    }
}
