using PasswordsVaultUI.HelperClasses;
using System;
using System.Windows;

namespace PasswordsVaultUI
{
    /// <summary>
    /// Interaction logic for NewUserPrompt.xaml
    /// </summary>
    public partial class NewUserPrompt : Window
    {
        private LoginScreen _loginScreen;

        public NewUserPrompt()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }

        public NewUserPrompt SetLoginScreen(LoginScreen loginScreen)
        {
            _loginScreen = loginScreen;
            return this;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _loginScreen.IsEnabled = true;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            _loginScreen.IsEnabled = true;
            Close();
            _loginScreen.CreateNewUser(newUsername.Text, newMasterkey.Password);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _loginScreen.IsEnabled = true;
            Close();
        }
    }
}
