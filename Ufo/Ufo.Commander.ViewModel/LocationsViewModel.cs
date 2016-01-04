using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Commander.ViewModel.Basic;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class LocationsViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private ObservableCollection<LocationViewModel> locations;
        private LocationViewModel currentLocation;
        #endregion

        #region ctor
        public LocationsViewModel(IManager manager)
        {
            this.manager = manager;
            Locations = new ObservableCollection<LocationViewModel>();
            CurrentLocation = new LocationViewModel(new Location(), manager);
            CurrentLocation.NotifyUpdate += () => LoadLocations();
        }
        #endregion

        #region properties
        public LocationViewModel CurrentLocation
        {
            get { return currentLocation; }
            set
            {
                if (currentLocation != value)
                {
                    currentLocation = value;
                    RaisePropertyChangedEvent(nameof(CurrentLocation));
                }
            }
        }


        public ObservableCollection<LocationViewModel> Locations
        {
            get
            {
                //LoadLocations();
                return locations;
            }
            set
            {
                if (locations != value)
                {
                    locations = value;
                    RaisePropertyChangedEvent(nameof(Locations));
                }
            }
        }
        #endregion

        public void LoadLocations()
        {
            locations.Clear();
            var locationsList = manager.GetAllLocations();

            foreach (var location in locationsList)
                locations.Add(new LocationViewModel(location, manager));

            Locations = locations;
        }
    }
}
