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
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views
{
    /// <summary>
    /// Interaction logic for AddArtistView.xaml
    /// </summary>
    public partial class AddArtistView : Window
    {
        public AddArtistView()
        {
            InitializeComponent();
            DataContext = new ArtistViewModel(ManagerFactory.GetManager());
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
