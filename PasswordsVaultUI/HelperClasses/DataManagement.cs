using PasswordsVaultUI.HelperClasses.Exceptions;
using PasswordsVaultUI.HelperClasses.Passwords;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PasswordsVaultUI.HelperClasses
{
    public class DataLoader
    {
        public static DataLoader Instance { get; private set; }
        public PasswordHolders PassHolder { get; private set; }

        string _key;
        static string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PasswordVault\\vault.dat");

        public void EnsureDirectoryExists()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PasswordVault");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        public DataLoader(string key)
        {
            EnsureDirectoryExists();

            _key = key;

            if (File.Exists(fileName))
            {
                var fileData = File.ReadAllText(fileName);

                try
                {
                    var decrypted = EncryptionHelperClass.DecryptString(key, fileData);

                    PassHolder = JsonConvert.DeserializeObject<PasswordHolders>(decrypted);

                    Console.WriteLine($"Checking: {PassHolder.GetTags().Length}");

                    PassHolder.EnsureDictionaryNotNull();
                }
                catch
                {
                    throw new FailedDecryptionException("Decryption failed with given key.");
                }
            }
            else
            {
                throw new FailedLoginMissingFileException("User shouldn't be able to login without created data file.");
            }
        }

        public DataLoader(string key, string username)
        {
            EnsureDirectoryExists();

            _key = key;

            PassHolder = new PasswordHolders(username);

            SaveData();
        }

        public void SaveData()
        {
            var fileData = EncryptionHelperClass.EncryptString(_key, JsonConvert.SerializeObject(PassHolder));
            //fileData = JsonSerializer.Serialize(PassHolder);
            var fileDataTest = JsonConvert.SerializeObject(PassHolder);
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PasswordVault\\vault2.dat"), fileDataTest);
            File.WriteAllText(fileName, fileData);
        }

        public static bool CheckIfUserSet()
        {
            return File.Exists(fileName);
        }
    }
}
