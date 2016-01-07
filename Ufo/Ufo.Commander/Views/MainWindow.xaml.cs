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

            InitializeComponent();
            DataContext = vm;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tab = sender as TabControl;
            if (tab == null)
                return;

            var tabItem = tab.SelectedItem as TabItem;

            if (tabItem == null)
                return;

            if (tabItem.Header.Equals("Schedule"))
            {
                var content = tabItem.Content as ScheduleControl;

                if (content == null)
                    return;

                var vm = content.DataContext as ScheduleViewModel;

                if (vm == null)
                    return;

                if (content.DayOne.IsSelected)
                {
                    vm.LoadScheduleForDayOne();
                } else if (content.DayTwo.IsSelected)
                {
                    vm.LoadScheduleForDayTwo();
                } else if (content.DayThree.IsSelected)
                {
                    vm.LoadScheduleForDayThree();
                }
            }
        }
    }
}
