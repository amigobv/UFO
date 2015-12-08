using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class LocationsViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private ObservableCollection<LocationEditViewModel> locations;
        private LocationEditViewModel currentLocation;
        #endregion

        #region ctor
        public LocationsViewModel(IManager manager)
        {
            this.manager = manager;
            Locations = new ObservableCollection<LocationEditViewModel>();
            CurrentLocation = new LocationEditViewModel(new Location(), manager);
            LoadLocations();
        }
        #endregion

        #region properties
        public LocationEditViewModel CurrentLocation
        {
            get { return currentLocation; }
            set
            {
                if (currentLocation != value)
                currentLocation = value;
                {
                    currentLocation = value;
                    RaisePropertyChangedEvent(nameof(CurrentLocation));
                }
            }
        }


        public ObservableCollection<LocationEditViewModel> Locations
        {
            get { return locations; }
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
            Locations.Clear();
            var locationsList = manager.GetAllLocations();

            foreach (var location in locationsList)
                Locations.Add(new LocationEditViewModel(location, manager));
        }
    }
}
