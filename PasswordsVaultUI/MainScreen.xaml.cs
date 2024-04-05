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
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {
        MainWindow _mainWindow;
        int oldEntryTagsIndex = -1;

        public MainScreen()
        {
            InitializeComponent();
        }

        public MainScreen SetupPasswordHolders()
        {
            var holderTags = _mainWindow.GetHolderTags();
            foreach (var v in holderTags)
                entryTags.Items.Add(v);
            entryTags.SelectedIndex = 0;

            return this;
        }

        public MainScreen SetMainWindow(MainWindow mainWindow) { 
            _mainWindow = mainWindow;
            return this;
        }

        public void AddNewHolder(string name)
        {
            entryTags.Items.Add(name);
            _mainWindow.dataLoader.PassHolder.AddEntry(name, "");
            entryTags.SelectedIndex = entryTags.Items.Count - 1;
        }

        private void createNewPassHolderButton_Click(object sender, RoutedEventArgs e)
        {
            var newPrompt = new NewPasswordHolderPrompt().SetMainScreen(this);
            newPrompt.Show();
            IsEnabled = false;
        }



        private void SelectionChangedEntryTags(object sender, SelectionChangedEventArgs e)
        {
            if(entryTags.SelectedValue == null)
            {
                nullEntryBlocker.Visibility = Visibility.Visible;
                oldEntryTagsIndex = -1;
                return;
            }
            if (oldEntryTagsIndex != entryTags.SelectedIndex)
            {
                nullEntryBlocker.Visibility = Visibility.Hidden;
                passwordHolderText.Text = $"Password information for {entryTags.SelectedValue}";
                passwordField.Text = "";
                oldEntryTagsIndex = entryTags.SelectedIndex;
            }
        }

        private void GetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            passwordField.Text = _mainWindow.dataLoader.PassHolder.GetPassword(entryTags.SelectedValue.ToString());
        }

        private void SetNewPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.dataLoader.PassHolder.ChangeEntry(entryTags.SelectedValue.ToString(), passwordField.Text);
            _mainWindow.dataLoader.SaveData();
        }

        private void RemoveTagButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.dataLoader.PassHolder.RemoveEntry(entryTags.SelectedValue.ToString());
            entryTags.Items.Remove(entryTags.SelectedValue);
            nullEntryBlocker.Visibility = Visibility.Visible;
            oldEntryTagsIndex = -1;
            _mainWindow.dataLoader.SaveData();
        }
    }
}
