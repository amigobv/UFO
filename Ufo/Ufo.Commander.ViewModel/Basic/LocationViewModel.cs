﻿using MvvmValidation;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel.Basic
{
    public class LocationViewModel : ValidableViewModelBase
    {
        #region private members
        private IManager manager;
        private Location location;
        private string validationErrorsString;
        private bool? isValid;
        #endregion

        #region ctor
        public LocationViewModel(IManager manager)
        {
            this.manager = manager;
            this.location = new Location();
            SaveCommand = new RelayCommand(o => manager.UpdateLocation(location));
            ConfigureValidation();
        }

        public LocationViewModel(Location location, IManager manager)
        {
            this.manager = manager;

            if (location == null)
                this.location = new Location();
            else
                this.location = location;
            SaveCommand = new RelayCommand(o => manager.UpdateLocation(location));
            ConfigureValidation();
        }
        #endregion

        private void ConfigureValidation()
        {
            Validator.AddRule(() => Identifier,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Identifier), "Short name is required!")
                              );

            Validator.AddRule(() => Identifier,
                              () => RuleResult.Assert(Identifier.Length < 5, "Short name it too long!"));

            Validator.AddRule(() => Identifier,
                              () => RuleResult.Assert(!manager.LocationExists(new Location(Identifier, "")), "This location already exists!"));
            Validator.ResultChanged += OnValidationResultChanged;
        }

        #region properties
        public string Identifier
        {
            get { return location.Id; }
            set
            {
                if (location.Id != value)
                {
                    location.Id = value;
                    RaisePropertyChangedEvent(nameof(Identifier)); 
                }
                Validator.ValidateAsync(() => Identifier);
            }
        }

        public string Name
        {
            get { return location.Label; }
            set
            {
                if (location.Label != value)
                {
                    location.Label = value;
                    RaisePropertyChangedEvent(nameof(Name));
                }
            }
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
            var location = obj as LocationViewModel;

            if (location == null)
                return false;


            return location.Equals(this.location);
        }
    }
}
