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
    /// Interaction logic for VenuesView.xaml
    /// </summary>
    public partial class VenuesView : Window
    {
        public VenuesViewModel ViewModel { get { return DataContext as VenuesViewModel; } }


        public VenuesView()
        {
            InitializeComponent();
            DataContext = new VenuesViewModel(ManagerFactory.GetManager());
        }


        private void CreateVenue(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.CurrentVenue = new VenueEditViewModel(ManagerFactory.GetManager());
            }

        }

        private void Cancel_Click(object o, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
