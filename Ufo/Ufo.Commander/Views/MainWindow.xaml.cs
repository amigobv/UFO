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
using Ufo.Commander.ViewModel.Basic;
using Ufo.Commander.Views.Controls;

namespace Ufo.Commander.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainViewModel vm = new MainViewModel(BLFactory.GetManager());
            vm.LoadDataAsync();

            if (Boolean.Parse(ConfigurationManager.AppSettings["Login"]))
            {
                var login = new UserLoginView();
                var loginVm = new UserLoginViewModel(BLFactory.GetManager());

                login.DataContext = loginVm;
                login.ShowDialog();
                login.Close();

                 // If login window didn't return true (login failed), exit application
                 if (!login.DialogResult.GetValueOrDefault())
                 {
                    Environment.Exit(0);
                 }
            }

            InitializeComponent();
            DataContext = vm;
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            //TabItem tabItem = sender as TabItem;
            //if (tabItem == null)
            //    return;

            //var schedule = tabItem.Content as ScheduleControl;

            //if (schedule == null)
            //    return;

            //var vm = this.DataContext as MainViewModel;

            //if (vm == null)
            //    return;

            //if (tabItem.Header.Equals("Schedule"))
            //{  
            //    //Call ICommand to refresh presenter
            //    vm.Schedule.RefreshCommand.Execute(null);
            //}
        }
    }
}
