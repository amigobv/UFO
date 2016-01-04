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
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for VenueControl.xaml
    /// </summary>
    public partial class VenueControl : UserControl
    {
        private VenueViewModel ViewModel
        {
            get { return DataContext as VenueViewModel; }
            set { DataContext = value; }
        }

        public VenueControl()
        {
            InitializeComponent();
        }

        private void LocationsLoaded(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel;

            if (vm == null)
                return;
        }

        private void DropDownOpened(object sender, EventArgs e)
        {
            var vm = ViewModel;

            if (vm != null)
            {
                // do a dummy read to update alll locations
                var locations = vm.Locations;
            }
            
        }
    }
}
