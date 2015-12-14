using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class ScheduleViewModel: ViewModelBase
    {
        #region private members
        private IManager manager;
        private ObservableCollection<LocationSchedulerViewModel> tables;
        #endregion

        #region ctor
        public ScheduleViewModel(IManager manager)
        {
            this.manager = manager;
            tables = new ObservableCollection<LocationSchedulerViewModel>();
            LoadLocations();
        }
        #endregion

        private void LoadLocations()
        {
            Tables.Clear();
            var locations = manager.GetAllLocations();

            foreach(var location in locations)
            {
                Tables.Add(new LocationSchedulerViewModel(location, manager));
            }
        }

        #region properties
        public ObservableCollection<LocationSchedulerViewModel> Tables
        {
            get { return tables; }
            set
            {
                if (tables != value)
                {
                    tables = value;
                    RaisePropertyChangedEvent(nameof(Tables));
                }
            }
        }
        #endregion

    }
}
