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
    public class VenuesViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private ObservableCollection<VenueEditViewModel> venues;
        private VenueEditViewModel currentVenue;
        #endregion

        #region ctor
        public VenuesViewModel(IManager manager)
        {
            this.manager = manager;
            Venues = new ObservableCollection<VenueEditViewModel>();
            CurrentVenue = new VenueEditViewModel(new Venue(), manager);
            LoadVenues();
        }

        #endregion

        #region properties
        public ObservableCollection<VenueEditViewModel> Venues
        {
            get { return venues; }
            set
            {
                if (venues != value)
                {
                    venues = value;
                    RaisePropertyChangedEvent(nameof(Venues));
                }
            }
        }

        public VenueEditViewModel CurrentVenue
        {
            get { return currentVenue; }
            set
            {
                if (currentVenue != value)
                {
                    currentVenue = value;
                    RaisePropertyChangedEvent(nameof(CurrentVenue));
                }
            }
        }
        #endregion

        public void LoadVenues()
        {
            Venues.Clear();
            var venuesList = manager.GetAllVenues();

            foreach (var venue in venuesList)
                Venues.Add(new VenueEditViewModel(venue, manager));
        }
    }
}
