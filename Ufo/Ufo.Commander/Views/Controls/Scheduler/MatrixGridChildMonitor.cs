using System.Windows;

namespace Ufo.Views.Controls.Scheduler
{
  /// <summary>
  /// Exposes two dependency properties which are bound to in
  /// order to know when the visual children of a MatrixGrid are
  /// given new values for the Grid.Row and Grid.Column properties.
  /// </summary>
  class MatrixGridChildMonitor : DependencyObject
  {
    #region dependency properties

    #region gridRow

    public int GridRow
    {
      get { return (int)GetValue(GridRowProperty); }
      set { SetValue(GridRowProperty, value); }
    }

    public static readonly DependencyProperty GridRowProperty =
        DependencyProperty.Register(
        "GridRow",
        typeof(int),
        typeof(MatrixGridChildMonitor),
        new UIPropertyMetadata(0));

    #endregion

    #region gridColumn

    public int GridColumn
    {
      get { return (int)GetValue(GridColumnProperty); }
      set { SetValue(GridColumnProperty, value); }
    }

    public static readonly DependencyProperty GridColumnProperty =
        DependencyProperty.Register(
        "GridColumn",
        typeof(int),
        typeof(MatrixGridChildMonitor),
        new UIPropertyMetadata(0));

    #endregion

    #endregion
  }
}