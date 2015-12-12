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

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for ArtistsView.xaml
    /// </summary>
    public partial class ArtistsControl : UserControl
    {
        public ArtistsViewModel ViewModel { get { return DataContext as ArtistsViewModel; } }

        public ArtistsControl()
        {
            InitializeComponent();
        }

        private void CreateArtist(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.CurrentArtist = new ArtistEditViewModel(ManagerFactory.GetManager());
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
