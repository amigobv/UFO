using System;
using System.Windows;
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
            //this.DataContext = new UserLoginViewModel(ManagerFactory.GetManager());
        }

        public void Login(object sender, RoutedEventArgs e)
        {
            if (ViewModel == null)
            {
                //TODO log
                return;
            }

            try
            {
                ViewModel.Password = txtPassword.Password;
                ViewModel.Login();

                if (ViewModel.IsLoginSuccessful)
                {
                    DialogResult = true;
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult = false;
                Close();
            }
        }

        public void Register(object sender, RoutedEventArgs e)
        {
            var registerWindow = new UserRegistrationView();
            registerWindow.ShowDialog();

            DialogResult = registerWindow.DialogResult.GetValueOrDefault();
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
