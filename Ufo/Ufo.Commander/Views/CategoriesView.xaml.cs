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
using Ufo.BL;
using Ufo.Commander.ViewModel;

namespace Ufo.Commander.Views
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : Window
    {
        public CategoriesViewModel ViewModel { get { return DataContext as CategoriesViewModel; } }

        public CategoriesView()
        {
            InitializeComponent();
            DataContext = new CategoriesViewModel(ManagerFactory.GetManager());
        }

        private void CreateCategory(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.CurrentCategory = new CategoryEditViewModel(ManagerFactory.GetManager());
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
