using System;
using System.Collections.Generic;

namespace PasswordsVaultUI.HelperClasses.Passwords
{
    [Serializable]
    public class PasswordHolders
    {
        public string Username { get; private set; }
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
    }
}
