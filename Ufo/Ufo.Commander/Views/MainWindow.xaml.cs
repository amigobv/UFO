using System;
using System.Collections.Generic;
using System.Configuration;
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
using Ufo.BL;
using Ufo.Commander.ViewModel;

namespace Ufo.Commander.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (Boolean.Parse(ConfigurationManager.AppSettings["Login"]))
            {
                var login = new UserLoginView();
                var loginVm = new UserLoginViewModel(ManagerFactory.GetManager());

                login.DataContext = loginVm;
                login.ShowDialog();

                // If login window didn't return true (login failed), exit application
                if (!login.DialogResult.GetValueOrDefault())
                {
                    Environment.Exit(0);
                }
            }

            InitializeComponent();
            DataContext = new MainViewModel(ManagerFactory.GetManager());
        }
    }
}
