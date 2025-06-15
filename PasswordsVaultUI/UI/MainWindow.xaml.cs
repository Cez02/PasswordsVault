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
using PasswordsVaultUI.HelperClasses;

namespace PasswordsVaultUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataLoader dataLoader { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            Main.Content = new LoginScreen().SetMainWindow(this);
        }

        public void SetDataLoader(DataLoader newDataLoader)
        {
            dataLoader = newDataLoader;
        }

        public string[] GetHolderTags() => dataLoader.PassHolder.GetTags();

        public void ChangeToMainScreen()
        {
            Main.Content = new MainScreen().SetMainWindow(this).SetupPasswordHolders();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataLoader != null)
            {
                //Console.WriteLine("Saving");
                //dataLoader.SaveData();
            }
        }
    }
}
