using PasswordsVaultUI.HelperClasses.Passwords;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasswordsVaultUI.HelperClasses
{
    public class DataLoader
    {
        public static DataLoader Instance { get; private set; }
        public PasswordHolders PassHolder { get; private set; }

        string _key;

        public DataLoader(string key)
        {
            _key = key;
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "vault.dat");

            if (File.Exists(fileName))
            {
                var fileData = File.ReadAllText(fileName);

                PassHolder = JsonSerializer.Deserialize<PasswordHolders>(
                    EncryptionHelperClass.DecryptString(key, fileData));
            }
            else
            {
                PassHolder = new PasswordHolders();
            }
        }

        public void SaveData()
        {
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "vault.dat");

            var fileData = EncryptionHelperClass.EncryptString(_key, JsonSerializer.Serialize(_passHolder));

            File.WriteAllText(fileName, fileData);
        }
    }
}
