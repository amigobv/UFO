using System;
using System.Windows;
using Ufo.BL;
using Ufo.Commander.ViewModel.Basic;

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

            this.DataContext = new UserRegistrationViewModel(BLFactory.GetManager());
        }

        private void Register(object sender, RoutedEventArgs e)
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

                if (ViewModel.IsRegistrationSuccessful)
                    DialogResult = true;
                else
                    DialogResult = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult = false;
            }

            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
