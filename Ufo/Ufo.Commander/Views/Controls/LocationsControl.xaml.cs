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
using Ufo.BL;
using Ufo.Commander.ViewModel;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for LocationsView.xaml
    /// </summary>
    public partial class LocationsControl : UserControl
    {
        public LocationsViewModel ViewModel { get { return DataContext as LocationsViewModel; } }

        public LocationsControl()
        {
            InitializeComponent();
           // DataContext = new LocationsViewModel(ManagerFactory.GetManager());
        }

        private void CreateLocation(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.CurrentLocation = new LocationViewModel(ManagerFactory.GetManager());
            }

        }

        private void SavePressed(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.Locations.Add(vm.CurrentLocation);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
