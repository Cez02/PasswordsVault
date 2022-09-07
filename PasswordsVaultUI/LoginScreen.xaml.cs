using PasswordsVaultUI.HelperClasses;
using PasswordsVaultUI.HelperClasses.Exceptions;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordsVaultUI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Page
    {
        MainWindow _mainWindow;

        public LoginScreen()
        {
            InitializeComponent();
        }

        public LoginScreen SetMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            return this;
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataLoader = new DataLoader(MasterKey.Password);

                _mainWindow.SetDataLoader(dataLoader);
                _mainWindow.ChangeToMainScreen();
            }
            catch (FailedDecryptionException ex)
            {
                MessageBox.Show(ex.Message, "Failed to login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("You must first register to login.", "Failed to login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NewUserButtonClick(object sender, RoutedEventArgs e)
        {
            var promptBox = new NewUserPrompt().SetLoginScreen(this);
            promptBox.Show();
            IsEnabled = false;
        }

        public void CreateNewUser(string username, string masterKey) {
            var newDataLoader = new DataLoader(masterKey, username);

            _mainWindow.SetDataLoader(newDataLoader);
            _mainWindow.ChangeToMainScreen();
        }
    }
}
