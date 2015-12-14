using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ufo.Views.Controls.Schedule.Layout
{
  /// <summary>
  /// A Grid panel that creates its own rows and columns based on the
  /// Grid.Row and Grid.Column values assigned to its children.
  /// </summary>
  class MatrixGrid : Grid
  {
    #region Fields

    readonly Dictionary<DependencyObject, MatrixGridChildMonitor> childToMonitorMap;
    readonly MatrixGridChildConverter converter;

    #endregion

    #region Ctor

    public MatrixGrid()
    {
      childToMonitorMap = new Dictionary<DependencyObject, MatrixGridChildMonitor>();
      converter = new MatrixGridChildConverter(this);
    }

    #endregion

    #region Override

    protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
    {
      base.OnVisualChildrenChanged(visualAdded, visualRemoved);

      if (visualAdded != null)
        this.StartMonitoringChildElement(visualAdded);
      else
        this.StopMonitoringChildElement(visualRemoved);
    }

    #endregion

    #region Inspect Row/Column Index

    internal void InspectRowIndex(int index)
    {
      base.Dispatcher.BeginInvoke(new Action(delegate
          {
            while (base.RowDefinitions.Count - 1 < index)
            {
              base.RowDefinitions.Add(new RowDefinition());

              if (base.RowDefinitions.Count == 1)
              {
                base.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Auto);
              }
            }
          }));
    }

    internal void InspectColumnIndex(int index)
    {
      base.Dispatcher.BeginInvoke(new Action(delegate
          {
            while (base.ColumnDefinitions.Count - 1 < index)
            {
              base.ColumnDefinitions.Add(new ColumnDefinition());

              if (base.ColumnDefinitions.Count == 1)
              {
                base.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Auto);
              }
            }
          }));
    }

    #endregion

    #region Private Methods

    private Binding CreateMonitorBinding(DependencyObject childElement, DependencyProperty property)
    {
      return new Binding
      {
        Converter = converter,
        ConverterParameter = property,
        Mode = BindingMode.OneWay,
        Path = new PropertyPath(property),
        Source = childElement
      };
    }

    private void StartMonitoringChildElement(DependencyObject childElement)
    {
      MatrixGridChildMonitor monitor = new MatrixGridChildMonitor();

      BindingOperations.SetBinding(
          monitor,
          MatrixGridChildMonitor.GridRowProperty,
          this.CreateMonitorBinding(childElement, Grid.RowProperty));

      BindingOperations.SetBinding(
          monitor,
          MatrixGridChildMonitor.GridColumnProperty,
          this.CreateMonitorBinding(childElement, Grid.ColumnProperty));

      childToMonitorMap.Add(childElement, monitor);
    }

    private void StopMonitoringChildElement(DependencyObject childElement)
    {
      if (childToMonitorMap.ContainsKey(childElement))
      {
        MatrixGridChildMonitor monitor = childToMonitorMap[childElement];
        BindingOperations.ClearAllBindings(monitor);
        childToMonitorMap.Remove(childElement);
      }
    }

    #endregion

  }
}