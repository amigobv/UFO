using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.Commander.ViewModel
{
    #region SchedulerBaseItem

    public abstract class SchedulerBaseItem
    {
        public int GridRow { get; internal set; }
        public int GridColumn { get; internal set; }
    }

    #endregion

    #region SchedulerCellItem

    public class SchedulerCellItem : SchedulerBaseItem
    {
        #region Properties

        public object Value { get; protected set; }

        #endregion

        #region Ctor

        public SchedulerCellItem()
        {

        }

        public SchedulerCellItem(object value)
        {
            this.Value = value;
        }

        #endregion
    }

    #endregion

    #region SchedulerColumnHeaderItem

    public class SchedulerColumnHeaderItem : SchedulerBaseItem
    {
        #region Properties

        public object Header { get; private set; }

        #endregion

        #region Ctor

        public SchedulerColumnHeaderItem(object header)
        {
            this.Header = header;
        }

        #endregion
    }

    #endregion

    #region SchedulerEmptyCellItem

    public class SchedulerEmptyCellItem : SchedulerCellItem
    {

        #region Ctor

        public SchedulerEmptyCellItem(object value)
        {
            this.Value = value;
        }

        #endregion
    }

    #endregion

    #region SchedulerEmptyHeaderItem

    public class SchedulerEmptyHeaderItem : SchedulerBaseItem
    {
    }

    #endregion

    #region SchedulerRowHeaderItem

    public class SchedulerRowHeaderItem : SchedulerBaseItem
    {
        #region Properties

        public object Header { get; private set; }

        #endregion

        #region Ctor

        public SchedulerRowHeaderItem(object header)
        {
            this.Header = header;
        }

        #endregion
    }

    #endregion

    public abstract class SchedulerViewModel<TRow, TColumn> : ViewModelBase
    {
        #region Fields

        ReadOnlyCollection<SchedulerBaseItem> items;

        #endregion

        #region Properties

        /// <summary>
        /// Returns a read-only collection of all cells in the matrix.
        /// </summary>
        public ReadOnlyCollection<SchedulerBaseItem> Items
        {
            get
            {
                if (items == null)
                {
                    items = new ReadOnlyCollection<SchedulerBaseItem>(this.Generate());
                }
                return items;
            }
        }

        #endregion

        #region Ctor

        protected SchedulerViewModel()
        {
        }

        #endregion

        #region Abstract Methods

        public abstract IEnumerable<TColumn> GetColumnHeaders();

        public abstract IEnumerable<TRow> GetRowHeaders();

        public abstract object GetCellValue(TRow rowHeader, TColumn columnHeader);

        #endregion

        #region Private Methods

        private List<SchedulerBaseItem> Generate()
        {
            List<SchedulerBaseItem> matrixItems = new List<SchedulerBaseItem>();

            List<TColumn> columnHeaders = this.GetColumnHeaders().ToList();
            List<TRow> rowHeaders = this.GetRowHeaders().ToList();

            this.CreateEmptyHeader(matrixItems);
            this.CreateColumnHeaders(matrixItems, columnHeaders);
            this.CreateRowHeaders(matrixItems, rowHeaders);
            this.CreateCells(matrixItems, rowHeaders, columnHeaders);

            return matrixItems;
        }

        void CreateEmptyHeader(List<SchedulerBaseItem> matrixItems)
        {
            matrixItems.Add(new SchedulerEmptyHeaderItem
            {
                GridRow = 0,
                GridColumn = 0
            });
        }

        private void CreateColumnHeaders(List<SchedulerBaseItem> matrixItems, List<TColumn> columnHeaders)
        {
            for (int columnNo = 1; columnNo <= columnHeaders.Count; ++columnNo)
            {
                matrixItems.Add(new SchedulerColumnHeaderItem(columnHeaders[columnNo - 1])
                {
                    GridRow = 0,
                    GridColumn = columnNo
                });
            }
        }

        private void CreateRowHeaders(List<SchedulerBaseItem> matrixItems, List<TRow> rowHeaders)
        {
            for (int rowNo = 1; rowNo <= rowHeaders.Count; ++rowNo)
            {
                matrixItems.Add(new SchedulerRowHeaderItem(rowHeaders[rowNo - 1])
                {
                    GridRow = rowNo,
                    GridColumn = 0
                });
            }
        }

        private void CreateCells(List<SchedulerBaseItem> matrixItems, List<TRow> rowHeaders, List<TColumn> columnHeaders)
        {
            for (int rowNo = 1; rowNo <= rowHeaders.Count; ++rowNo)
            {
                for (int columnNo = 1; columnNo <= columnHeaders.Count; ++columnNo)
                {
                    object cellValue = this.GetCellValue(rowHeaders[rowNo - 1], columnHeaders[columnNo - 1]);
                    if (cellValue == null)
                    {
                        matrixItems.Add(new SchedulerEmptyCellItem(null)
                        {
                            GridRow = rowNo,
                            GridColumn = columnNo
                        });
                    }
                    matrixItems.Add(new SchedulerCellItem(cellValue)
                    {
                        GridRow = rowNo,
                        GridColumn = columnNo
                    });
                }
            }
        }

        #endregion

    }
}
