using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PasswordsVaultUI.HelperClasses.Passwords
{
    public class PasswordHolders
    {
        [JsonProperty("Username")]
        public string Username { get; private set; }
        
        [JsonProperty("Entries")] 
        Dictionary<string, string> _passwordEntries;

        public PasswordHolders()
        {
            _passwordEntries = new Dictionary<string, string>();
        }

        public PasswordHolders(string username)
        {
            _passwordEntries = new Dictionary<string, string>();
            Username = username;
        }

        public void AddEntry(string tag, string passwordValue)
        {
            _passwordEntries[tag] = passwordValue;
        }

        public void ChangeEntry(string tag, string newPasswordValue)
        {
            _passwordEntries[tag] = newPasswordValue;
        }

        public string GetPassword(string tag)
        {
            return _passwordEntries[tag];
        }
        
        public void RemoveEntry(string tag)
        {
            _passwordEntries.Remove(tag);
        }

        public string[] GetTags()
        {
            var keys = _passwordEntries.Keys;
            return keys.ToArray();
        }

        public void EnsureDictionaryNotNull()
        {
            if (_passwordEntries == null) _passwordEntries = new Dictionary<string, string>();
        }
    }
}
