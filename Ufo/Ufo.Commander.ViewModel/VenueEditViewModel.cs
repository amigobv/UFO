using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class VenueEditViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private Venue venue;
        private ObservableCollection<Location> locations;
        #endregion

        #region ctor
        public VenueEditViewModel(IManager manager)
        {
            this.manager = manager;
            this.venue = new Venue();
            this.locations = manager.GetAllLocations();
            SaveCommand = new RelayCommand(o => manager.UpdateVenue(venue));
            RemoveCommand = new RelayCommand(o => manager.RemoveVenue(venue));
        }

        public VenueEditViewModel(Venue venue, IManager manager)
        {
            this.manager = manager;
            this.venue = venue;
            this.locations = manager.GetAllLocations();
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

        public int Capacity
        {
            get { return venue.MaxSpectators; }
            set
            {
                if (venue.MaxSpectators != value)
                {
                    venue.MaxSpectators = value;
                    RaisePropertyChangedEvent(nameof(Capacity));
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


        public ObservableCollection<Location> Locations
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

        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        #endregion
    }
}
