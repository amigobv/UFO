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

namespace Ufo.Commander.Views
{
    /// <summary>
    /// Interaction logic for LocationsView.xaml
    /// </summary>
    public partial class LocationsView : Window
    {
        public LocationsViewModel ViewModel { get { return DataContext as LocationsViewModel; } }

        public LocationsView()
        {
            InitializeComponent();
            DataContext = new LocationsViewModel(ManagerFactory.GetManager());
        }

        private void CreateLocation(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.CurrentLocation = new LocationEditViewModel(ManagerFactory.GetManager());
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
