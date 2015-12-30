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
using Ufo.BL;
using Ufo.Commander.ViewModel;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views
{
    /// <summary>
    /// Interaction logic for PerformanceControl.xaml
    /// </summary>
    public partial class AddPerformanceView : Window
    {
        public AddPerformanceView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var src = e.Source as Button;

            if (src == null)
                return;

            var vm = (PerformanceViewModel)src.DataContext;

            if (vm == null)
                return;

            var cbArtist = (ComboBox)this.FindName("cbArtist");

            if (cbArtist == null)
                return;

            var item = cbArtist.SelectedItem;
            vm.Artist = (ArtistViewModel)item;

            if (vm.IsValidArtist())
            {
                vm.SaveCommand.Execute(null);
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRemote_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
