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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ufo.BL;
using Ufo.Commander.ViewModel;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for TableControl.xaml
    /// </summary>
    public partial class TableControl : UserControl
    {
        private PerformanceSchedulerViewModel ViewModel { get { return DataContext as PerformanceSchedulerViewModel; } }

        public TableControl()
        {
            InitializeComponent();
        }

        private void OnMouseDown_Create(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ViewModel == null)
                return;

            var src = e.Source as Border;

            if (src == null)
                return;

            var cellItem = src.DataContext as SchedulerCellItem;

            if (cellItem == null)
                return;

            var column = cellItem.GridColumn - 1;
            var row = cellItem.GridRow - 1;

            var hour = ViewModel.GetColumnHeaders().ElementAt(column);
            var venue = ViewModel.GetRowHeaders().ElementAt(row);

            var window = new AddPerformanceView();
            var manager = ManagerFactory.GetManager();
            var performance = new PerformanceViewModel(venue, new ArtistViewModel(manager), hour, manager);

            window.DataContext = performance;
            window.Height = 350;
            window.Width = 400;
            window.ShowDialog();
            window.Close();

            return;
        }

        private void OnMouseDown_Change(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ViewModel == null)
                return;

            var src = e.Source as TextBlock;

            if (src == null)
                return;

            var cellItem = src.DataContext as SchedulerCellItem;

            if (cellItem == null)
                return;

            var column = cellItem.GridColumn - 1;
            var row = cellItem.GridRow - 1;

            var hour = ViewModel.GetColumnHeaders().ElementAt(column);
            var venue = ViewModel.GetRowHeaders().ElementAt(row);
            var performance = (PerformanceViewModel)ViewModel.GetCellValue(venue, hour);

            if (performance == null)
                return;

            var window = new AddPerformanceView();
            var manager = ManagerFactory.GetManager();

            window.DataContext = performance;
            window.Height = 350;
            window.Width = 400;

            window.ShowDialog();
            window.Close();

            return;
        }
    }
}
