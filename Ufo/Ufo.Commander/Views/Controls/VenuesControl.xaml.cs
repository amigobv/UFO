using System.Windows;
using System.Windows.Controls;
using Ufo.BL;
using Ufo.Commander.ViewModel;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for VenuesView.xaml
    /// </summary>
    public partial class VenuesControl : UserControl
    {
        public VenuesViewModel ViewModel { get { return DataContext as VenuesViewModel; } }


        public VenuesControl()
        {
            InitializeComponent();
           // DataContext = new VenuesViewModel(ManagerFactory.GetManager());
        }


        private void CreateVenue(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.CurrentVenue = new VenueViewModel(BLFactory.GetManager());
            }

        }

        private void SavePressed(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null && vm.CurrentVenue != null)
            {
                vm.CurrentVenue.Validation();

                if (vm.CurrentVenue.IsValid ?? false)
                {
                    vm.CurrentVenue.SaveCommand.Execute(null);
                }
            }
        }
    }
}
