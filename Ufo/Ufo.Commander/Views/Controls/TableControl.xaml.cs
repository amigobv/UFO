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
using Ufo.Commander.ViewModel;

namespace Ufo.Commander.Views.Controls
{
    /// <summary>
    /// Interaction logic for TableControl.xaml
    /// </summary>
    public partial class TableControl : UserControl
    {
        private LocationSchedulerViewModel ViewModel { get { return DataContext as LocationSchedulerViewModel; } }
        LocationSchedulerViewModel vm;

        public TableControl()
        {
            InitializeComponent();
        }

        private void OnMouseDown_Create(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // create new instance
            var par = FindAncestorOrSelf<TabControl> (this);

            if (par != null)
            {
                var item = par.SelectedIndex;

            }
            


            return;
        }

        private void OnMouseDown_Change(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // create new instance
            return;
        }

        private DependencyObject GetParent(DependencyObject obj)
        {
            if (obj == null)
                return null;

            ContentElement ce = obj as ContentElement;
            if (ce != null)
            {
                DependencyObject parent = ContentOperations.GetParent(ce);
                if (parent != null)
                    return parent;

                FrameworkContentElement fce = ce as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }

            return VisualTreeHelper.GetParent(obj);
        }

        private T FindAncestorOrSelf<T>(DependencyObject obj) where T : DependencyObject
        {
            while (obj != null)
            {
                T objTest = obj as T;
                if (objTest != null)
                    return objTest;
                obj = GetParent(obj);
            }

            return null;
        }

    }
}
