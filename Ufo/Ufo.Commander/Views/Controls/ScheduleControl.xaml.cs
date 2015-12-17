using System.Windows;
using System.Windows.Controls;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleControl : UserControl
    {
        private ScheduleViewModel ViewModel { get { return DataContext as ScheduleViewModel; } }

        public ScheduleControl()
        {
            InitializeComponent();
            //DataContext = new ScheduleViewModel(ManagerFactory.GetManager());
        }
    }
}
