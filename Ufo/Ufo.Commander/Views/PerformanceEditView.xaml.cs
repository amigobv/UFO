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
    /// Interaction logic for PerformanceEditView.xaml
    /// </summary>
    public partial class PerformanceEditView : Window
    {
        public PerformanceEditView()
        {
            InitializeComponent();
            DataContext = new PerformanceEditViewModel(ManagerFactory.GetManager());
        }
    }
}
