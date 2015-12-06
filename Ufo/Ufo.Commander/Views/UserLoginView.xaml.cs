﻿using System;
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
using Ufo.Commander.ViewModel;

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
            this.DataContext = new UserLoginViewModel();
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Register(object sender, RoutedEventArgs e)
        {
            UserRegistrationView registerWindow = new UserRegistrationView();
            registerWindow.Show();
            this.Close();
        }
    }
}
