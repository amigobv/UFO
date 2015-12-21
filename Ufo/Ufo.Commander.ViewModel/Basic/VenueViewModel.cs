using System.Collections.ObjectModel;
using MvvmValidation;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;
using System.Linq;

namespace Ufo.Commander.ViewModel.Basic
{
    public class VenueViewModel : ValidableViewModelBase
    {
        #region private members
        private IManager manager;
        private Venue venue;
        private LocationViewModel location;
        private ObservableCollection<LocationViewModel> locations;
        private string validationErrorsString;
        private bool? isValid;
        #endregion

        #region ctor
        public VenueViewModel(IManager manager)
        {
            this.manager = manager;
            this.venue = new Venue();
            location = new LocationViewModel(manager);
            locations = new ObservableCollection<LocationViewModel>();
            SaveCommand = new RelayCommand(o => manager.UpdateVenue(venue));
            ConfigureValidation();
        }

        public VenueViewModel(Venue venue, IManager manager)
        {
            this.manager = manager;
            this.venue = venue;
            location = new LocationViewModel(venue.Location, manager);
            locations = new ObservableCollection<LocationViewModel>();
            SaveCommand = new RelayCommand(o => manager.UpdateVenue(venue));
            ConfigureValidation();
        }
        #endregion

        private void ConfigureValidation()
        {
            Validator.AddRule(() => Name,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Name), "Short name is required!")
                              );

            Validator.ResultChanged += OnValidationResultChanged;
        }

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
                Validator.ValidateAsync(() => Name);
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

        #region validation
        public string ValidationErrorsString
        {
            get { return validationErrorsString; }
            private set
            {
                validationErrorsString = value;
                RaisePropertyChangedEvent(nameof(ValidationErrorsString));
            }
        }

        public bool? IsValid
        {
            get { return isValid; }
            private set
            {
                isValid = value;
                RaisePropertyChangedEvent(nameof(IsValid));
            }
        }

        private void OnValidationResultChanged(object sender, ValidationResultChangedEventArgs e)
        {
            // Get current state of the validation
            ValidationResult validationResult = Validator.GetResult();
            UpdateValidationSummary(validationResult);
        }

        private void UpdateValidationSummary(ValidationResult validationResult)
        {
            IsValid = validationResult.IsValid;
            ValidationErrorsString = validationResult.ToString();
        }
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
            if (vm == null)
                return; 

            venue.Location = new Location()
            {
                Id = vm.Identifier,
                Label = vm.Name
            };
        }
    }
}
