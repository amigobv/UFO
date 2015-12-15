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
    public class VenuesViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private ObservableCollection<VenueViewModel> venues;
        private VenueViewModel currentVenue;
        #endregion

        #region ctor
        public VenuesViewModel(IManager manager)
        {
            this.manager = manager;
            Venues = new ObservableCollection<VenueViewModel>();
            CurrentVenue = new VenueViewModel(new Venue(), manager);
        }

        #endregion

        #region properties
        public ObservableCollection<VenueViewModel> Venues
        {
            get
            {
                LoadVenues();
                return venues;
            }
            set
            {
                if (venues != value)
                {
                    venues = value;
                    RaisePropertyChangedEvent(nameof(Venues));
                }
            }
        }

        public VenueViewModel CurrentVenue
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
            venues.Clear();
            var venuesList = manager.GetAllVenues();

            foreach (var venue in venuesList)
                venues.Add(new VenueViewModel(venue, manager));
        }
    }
}
