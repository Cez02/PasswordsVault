using System;
using System.Collections.Generic;

namespace PasswordsVaultUI.HelperClasses.Passwords
{
    [Serializable]
    public class PasswordHolders
    {
        Dictionary<string, string> _passwordEntries;

        public PasswordHolders()
        {
            _passwordEntries = new Dictionary<string, string>();
        }

        public PasswordHolders(Dictionary<string, string> passwordEntries)
        {
            _passwordEntries = passwordEntries;
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
