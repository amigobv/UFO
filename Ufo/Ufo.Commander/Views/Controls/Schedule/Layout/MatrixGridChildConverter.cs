using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ufo.Views.Controls.Schedule.Layout
{
  /// <summary>
  /// The value converter applied to bindings against properties of 
  /// MatrixGridChildMonitor that informs a MatrixGrid of the Grid.Row
  /// and Grid.Column settings applied to its child elements.
  /// </summary>
  class MatrixGridChildConverter : IValueConverter
  {
    #region Fields

    readonly MatrixGrid matrixGrid;

    #endregion

    #region Ctor

    public MatrixGridChildConverter(MatrixGrid matrixGrid)
    {
      this.matrixGrid = matrixGrid;
    }

    #endregion

    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is int)
      {
        int index = (int)value;

        if (parameter == Grid.RowProperty)
        {
          matrixGrid.InspectRowIndex(index);
        }
        else
        {
          matrixGrid.InspectColumnIndex(index);
        }
      }

      return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotSupportedException();
    }

    #endregion
  }
}