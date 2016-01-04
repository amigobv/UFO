using System;
using System.Windows;
using Ufo.BL;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views
{
    /// <summary>
    /// Interaction logic for UserLoginView.xaml
    /// </summary>
    public partial class UserLoginView : Window
    {
        public UserLoginViewModel ViewModel
        {
            get
            {
                return this.DataContext as UserLoginViewModel;
            }
        }

        public UserLoginView()
        {
            InitializeComponent();
            this.DataContext = new UserLoginViewModel(BLFactory.GetManager());
        }

        public void Login(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel;
            if (vm == null)
            {
                //TODO log
                return;
            }

            vm.Validation();

            if (vm.IsValid ?? false)
            {
                try
                {
                    ViewModel.Password = txtPassword.Password;
                    ViewModel.Login();

                    if (ViewModel.IsLoginSuccessful)
                    {
                        DialogResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    DialogResult = false;
                }
            }
        }

        public void Register(object sender, RoutedEventArgs e)
        {
            var registerWindow = new UserRegistrationView();
            registerWindow.ShowDialog();

            DialogResult = registerWindow.DialogResult.GetValueOrDefault();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
