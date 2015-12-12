using System.Windows;
using System.Windows.Controls;
using Ufo.Commander.ViewModel;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for TimePickerControl.xaml
    /// </summary>
    public partial class TimePickerControl : UserControl
    {
        public TimeViewModel ViewModel { get { return DataContext as TimeViewModel; } }

        public TimePickerControl()
        {
            InitializeComponent();
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel;

            if (vm != null)
            {
                vm.Increment();
            }
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel;

            if (vm != null)
            {
                vm.Decrement();
            }
        }
    }
}
