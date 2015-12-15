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
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for VenuesView.xaml
    /// </summary>
    public partial class VenuesControl : UserControl
    {
        public VenuesViewModel ViewModel { get { return DataContext as VenuesViewModel; } }


        public VenuesControl()
        {
            InitializeComponent();
           // DataContext = new VenuesViewModel(ManagerFactory.GetManager());
        }


        private void CreateVenue(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.CurrentVenue = new VenueViewModel(ManagerFactory.GetManager());
            }

        }

        private void SavePressed(object sender, RoutedEventArgs e)
        {
            var vm = this.ViewModel;

            if (vm != null)
            {
                vm.Venues.Add(vm.CurrentVenue);
            }
        }

        private void Cancel(object o, RoutedEventArgs e)
        {

        }
    }
}
