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
        private ObservableCollection<LocationViewModel> locations;
        #endregion

        #region ctor
        public VenueViewModel(IManager manager)
        {
            this.manager = manager;
            this.venue = new Venue();
            locations = new ObservableCollection<LocationViewModel>();
            SaveCommand = new RelayCommand(o => manager.UpdateVenue(venue));
            RemoveCommand = new RelayCommand(o => manager.RemoveVenue(venue));
        }

        public VenueViewModel(Venue venue, IManager manager)
        {
            this.manager = manager;
            this.venue = venue;
            locations = new ObservableCollection<LocationViewModel>();
            SaveCommand = new RelayCommand(o => manager.UpdateVenue(venue));
            RemoveCommand = new RelayCommand(o => manager.RemoveVenue(venue));
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

        public Location Location
        {
            get { return venue.Location; }
            set
            {
                if (venue.Location != value)
                {
                    venue.Location = value;
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
        public ICommand RemoveCommand { get; set; }
        #endregion

        private void LoadLocations()
        {
            locations.Clear();
            //TODO: only the artists that are aloud should be returned
            var locationList = manager.GetAllLocations();

            foreach (var location in locationList)
                locations.Add(new LocationViewModel(location, manager));
        }
    }
}
