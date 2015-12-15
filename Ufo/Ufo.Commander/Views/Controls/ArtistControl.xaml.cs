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
using Ufo.Commander.ViewModel;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for ArtistEditView.xaml
    /// </summary>
    public partial class ArtistControl : UserControl
    {
        public ArtistViewModel ViewModel
        {
            get
            {
                return this.DataContext as ArtistViewModel;
            }
        }

        public ArtistControl()
        {
            InitializeComponent();
        }

        private void BrowsePicture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseVideo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
