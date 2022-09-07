using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            _loginScreen.CreateNewUser(newUsername.Text, newMasterkey.Text);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _loginScreen.IsEnabled = true;
            Close();
        }
    }
}
