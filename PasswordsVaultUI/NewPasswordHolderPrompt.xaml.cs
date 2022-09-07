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
    /// Interaction logic for NewPasswordHolderPrompt.xaml
    /// </summary>
    public partial class NewPasswordHolderPrompt : Window
    {
        MainScreen _mainScreen;

        public NewPasswordHolderPrompt()
        {
            InitializeComponent();
        }

        public NewPasswordHolderPrompt SetMainScreen(MainScreen mainScreen)
        {
            _mainScreen = mainScreen;
            return this;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            _mainScreen.IsEnabled = true;
            _mainScreen.AddNewHolder(newHolderName.Text);
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _mainScreen.IsEnabled = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainScreen.IsEnabled = true;
        }
    }
}
