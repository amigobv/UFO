using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Commander.ViewModel.Basic;

namespace Ufo.Commander.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region private members
        private LocationsViewModel locationVm;
        private CategoriesViewModel categoryVm;
        private VenuesViewModel venueVm;
        private ArtistsViewModel artistVm;
        private ScheduleViewModel scheduleVm;
        #endregion

        #region ctor
        public MainViewModel(IManager manager)
        {
            locationVm = new LocationsViewModel(manager);
            categoryVm = new CategoriesViewModel(manager);
            venueVm = new VenuesViewModel(manager);
            artistVm = new ArtistsViewModel(manager);
            scheduleVm = new ScheduleViewModel(manager);
        }

        #endregion

        #region properties
        public LocationsViewModel Locations
        {
            get { return locationVm; }
            set
            {
                if (locationVm != value)
                {
                    locationVm = value;
                    RaisePropertyChangedEvent(nameof(Locations));
                }
            }
        }

        public CategoriesViewModel Categories
        {
            get { return categoryVm; }
            set
            {
                if (categoryVm != value)
                {
                    categoryVm = value;
                    RaisePropertyChangedEvent(nameof(Categories));
                }
            }
        }

        public VenuesViewModel Venues
        {
            get { return venueVm; }
            set
            {
                if (venueVm != value)
                {
                    venueVm = value;
                    RaisePropertyChangedEvent(nameof(Venues));
                }
            }
        }

        public ArtistsViewModel Artists
        {
            get { return artistVm; }
            set
            {
                if (artistVm != value)
                {
                    artistVm = value;
                    RaisePropertyChangedEvent(nameof(Artists));
                }
            }
        }

        
        public ScheduleViewModel Schedule
        {
            get { return scheduleVm; }
            set
            {
                if (scheduleVm != value)
                {
                    scheduleVm = value;
                    RaisePropertyChangedEvent(nameof(Schedule));
                }
            }
        }
        #endregion
    }
}
