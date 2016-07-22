using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;
using Ufo.Commander.ViewModel.Validator;
using System.Collections.Generic;

namespace Ufo.Commander.ViewModel.Basic
{
    public class PerformanceViewModel : ValidableViewModelBase
    {
        private IManager manager;
        private ArtistViewModel artistVm;
        private VenueViewModel venueVm;
        private DateTime day;
        private Performance performance;
        private IList<ArtistViewModel> artists;
        private IList<VenueViewModel> venues;

        #region ctor
        public PerformanceViewModel(VenueViewModel venueVm, ArtistViewModel artistVm, DateTime day, IManager manager)
        {
            this.manager = manager;
            this.performance = new Performance();

            this.performance.Start = day;

            var artist = manager.GetArtistByName(artistVm.Name);
            if (artist != null && artist.Count > 0)
                this.performance.Artist = artist.ElementAt(0);
            else
                this.performance.Artist = new Artist();

            var venue = manager.GetVenueById(venueVm.Id);
            if (venue != null)
                this.performance.Venue = venue;

            this.venueVm = venueVm;
            this.artistVm = artistVm;
            this.day = day;
            this.artists = new List<ArtistViewModel>();
            this.venues = new List<VenueViewModel>();

            SaveCommand = new RelayCommand(o => manager.UpdatePerformance(performance));
            RemoveCommand = new RelayCommand(o => manager.RemovePerformance(performance));
        }

        public PerformanceViewModel(IManager manager)
        {
            this.manager = manager;
            this.performance = new Performance();
            this.venueVm = new VenueViewModel(manager);
            this.artistVm = new ArtistViewModel(manager);
            this.day = new DateTime(2000, 01, 01);
            this.artists = new List<ArtistViewModel>();
            this.venues = new List<VenueViewModel>();

            SaveCommand = new RelayCommand(o => manager.UpdatePerformance(performance));
            RemoveCommand = new RelayCommand(o => manager.RemovePerformance(performance));
        }

        public PerformanceViewModel(Performance performance, IManager manager)
        {
            this.manager = manager;
            this.performance = performance;
            this.venueVm = new VenueViewModel(performance.Venue, manager);
            this.artistVm = new ArtistViewModel(performance.Artist, (manager));
            this.day = new DateTime(performance.Start.Year, performance.Start.Month, performance.Start.Day,
                                    performance.Start.Hour, performance.Start.Minute, performance.Start.Second);
            this.artists = new List<ArtistViewModel>();
            this.venues = new List<VenueViewModel>();

            SaveCommand = new RelayCommand(o => manager.UpdatePerformance(performance));
            RemoveCommand = new RelayCommand(o => manager.RemovePerformance(performance));
        }
        #endregion

        #region properties
        public ArtistViewModel Artist
        {
            get { return artistVm; }
            set
            {
                if (artistVm != value)
                {
                    artistVm = value;
                    ArtistVmToArtist(artistVm);
                    RaisePropertyChangedEvent(nameof(Artist));
                }
                Validator.ValidateAsync(() => Artist);
            }
        }

        public VenueViewModel Venue
        {
            get { return venueVm; }
            set
            {
                if (venueVm != value)
                {
                    venueVm = value;
                    VenueVmToVenue(venueVm);
                    RaisePropertyChangedEvent(nameof(Venue));
                }
            }
        }

        public DateTime Day
        {
            get { return day; }
            set
            {
                if (day != value)
                {
                    day = value;
                    RaisePropertyChangedEvent(nameof(Day));
                }
            }
        }

        public IList<ArtistViewModel> Artists
        {
            get
            {
                LoadArtists();
                return artists;
            }
            set
            {
                if (artists != value)
                {
                    artists = value;
                    RaisePropertyChangedEvent(nameof(Artists));
                }
            }
        }

        public IList<VenueViewModel> Venues
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

        public string Time
        {
            get { return Day.ToString("HH:mm"); }
            set { }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        #endregion

        #region private helpers
        private void LoadVenues()
        {
            venues.Clear();
            var venuesList = manager.GetAllVenues();

            foreach (var venue in venuesList)
                venues.Add(new VenueViewModel(venue, manager));
        }

        private void LoadArtists()
        {
            artists.Clear();
            //TODO: only the artists that are aloud should be returned
            var artistsList = manager.GetAllArtists();

            artists.Add(new ArtistViewModel(manager));

            foreach (var artist in artistsList)
                artists.Add(new ArtistViewModel(artist, manager));
        }

        private void ArtistVmToArtist(ArtistViewModel vm)
        {
            performance.Artist = new Artist()
            {
                Id = vm.Id,
                Name = vm.Name,
                Country = vm.Country,
                Description = vm.Description,
                Email = vm.Email,
                Homepage = vm.Homepage,
                PictureUrl = vm.Picture,
                VideoUrl = vm.Video,
                Category = new Category(vm.Category.Identifier, vm.Category.Name)
            };
        }

        private void VenueVmToVenue(VenueViewModel vm)
        {
            int capacity;
            if (!int.TryParse(vm.Capacity, out capacity))
                capacity = 0;

            performance.Venue = new Venue()
            {
                Id = (int)Char.GetNumericValue(vm.Id[1]),
                Label = vm.Name,
                MaxSpectators = capacity,
                Location = new Location(vm.Location.Identifier, vm.Location.Name)
            };
        }
        #endregion

        #region public methods
        public bool IsValidArtist()
        {
            return manager.IsPerformanceValid(performance);
        }
        #endregion
    }
}
