using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel.Basic
{
    public class VenueViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private Venue venue;
        private LocationViewModel location;
        private ObservableCollection<LocationViewModel> locations;
        #endregion

        #region ctor
        public VenueViewModel(IManager manager)
        {
            this.manager = manager;
            this.venue = new Venue();
            location = new LocationViewModel(manager);
            locations = new ObservableCollection<LocationViewModel>();
            SaveCommand = new RelayCommand(o => manager.UpdateVenue(venue));
        }

        public VenueViewModel(Venue venue, IManager manager)
        {
            this.manager = manager;
            this.venue = venue;
            location = new LocationViewModel(venue.Location, manager);
            locations = new ObservableCollection<LocationViewModel>();
            SaveCommand = new RelayCommand(o => manager.UpdateVenue(venue));
        }
        #endregion

        #region properties
        public string Name
        {
            get { return venue.Label; }
            set
            {
                if (venue.Label != value)
                {
                    venue.Label = value;
                    RaisePropertyChangedEvent(nameof(Name));
                }
            }
        }

        public string Capacity
        {
            get
            {
                if (venue.MaxSpectators == 0)
                    return string.Empty;

                return venue.MaxSpectators.ToString();
            }

            set
            {
                var capacity = 0;

                if (int.TryParse(value, out capacity))
                {
                    if (venue.MaxSpectators != capacity)
                    {
                        venue.MaxSpectators = capacity;
                        RaisePropertyChangedEvent(nameof(Capacity));
                    }
                }

            }
        }

        public LocationViewModel Location
        {
            get { return location; }
            set
            {
                if (location != value)
                {
                    location = value;
                    LocationVmToLocation(location);
                    RaisePropertyChangedEvent(nameof(Location));
                }
            }
        }


        public ObservableCollection<LocationViewModel> Locations
        {
            get
            {
                LoadLocations();
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

        public string Id
        {
            get { return string.Format("{0}{1}", venue.Location.Id, venue.Id); }
        }

        public ICommand SaveCommand { get; set; }
        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var venue = obj as VenueViewModel;

            if (venue == null)
                return false;


            return venue.Equals(this.venue);
        }

        private void LoadLocations()
        {
            locations.Clear();
            //TODO: only the artists that are aloud should be returned
            var locationList = manager.GetAllLocations();

            foreach (var location in locationList)
                locations.Add(new LocationViewModel(location, manager));
        }

        private void LocationVmToLocation(LocationViewModel vm)
        {
            venue.Location = new Location()
            {
                Id = vm.Identifier,
                Label = vm.Name
            };
        }
    }
}
