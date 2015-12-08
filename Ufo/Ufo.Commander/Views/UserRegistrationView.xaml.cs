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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserRegistrationView : Window
    {
        private UserRegistrationViewModel ViewModel
        {
            get
            {
                return this.DataContext as UserRegistrationViewModel;
            }
        }

        public UserRegistrationView()
        {
            InitializeComponent();

            this.DataContext = new UserRegistrationViewModel(ManagerFactory.GetManager());
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            if (ViewModel == null)
            {
                //TODO log
                return;
            }

            try
            {
                ViewModel.Password = txtPassword.Password;
                ViewModel.Registrate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
