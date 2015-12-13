using MvvmValidation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.Commander.Model;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class ArtistEditViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private Artist artist;
        private ObservableCollection<Category> categories;
        private bool? isValid;
        private string validationErrorsString;
        #endregion

        #region ctor
        public ArtistEditViewModel(IManager manager)
        {
            this.artist = new Artist();
            this.manager = manager;
            Categories = manager.GetAllCategories();
            SaveCommand = new RelayCommand(o => manager.UpdateArtist(artist));
            RemoveCommand = new RelayCommand(o => manager.RemoveArtist(artist), o => false);

            ValidateCommand = new RelayCommand(Validate);
        }

        public ArtistEditViewModel(Artist artist, IManager manager)
        {
            this.artist = artist;
            this.manager = manager;
            Categories = manager.GetAllCategories();
            SaveCommand = new RelayCommand(o => manager.UpdateArtist(artist));
            RemoveCommand = new RelayCommand(o => manager.RemoveArtist(artist), o => false);
        }

        #endregion

        #region properties
        public string Name
        {
            get { return artist.Name; }
            set
            {
                if (artist.Name != value)
                {
                    artist.Name = value;
                    RaisePropertyChangedEvent(nameof(Name));
                    Validator.Validate(() => Name);
                }
            }
        }

        public string Country
        {
            get { return artist.Country; }
            set
            {
                if (artist.Country != value)
                {
                    artist.Country = value;
                    RaisePropertyChangedEvent(nameof(Country));
                    Validator.Validate(() => Country);
                }
            }
        }

        public string Email
        {
            get { return artist.Email; }
            set
            {
                if (artist.Email != value)
                {
                    artist.Email = value;
                    RaisePropertyChangedEvent(nameof(Email));
                    Validator.Validate(() => Email);
                }   
            }
        }

        public string Description
        {
            get { return artist.Description; }
            set
            {
                if (artist.Description != value)
                {
                    artist.Description = value;
                    RaisePropertyChangedEvent(nameof(Description));
                    Validator.Validate(() => Description);
                }
            }
        }

        public string Homepage
        {
            get { return artist.Homepage; }
            set
            {
                if (artist.Homepage != value)
                {
                    artist.Homepage = value;
                    RaisePropertyChangedEvent(nameof(Homepage));
                    Validator.Validate(() => Homepage);
                }
            }
        }

        public string Picture
        {
            get { return artist.PictureUrl; }
            set
            {
                if (artist.PictureUrl != value)
                {
                    artist.PictureUrl = value;
                    RaisePropertyChangedEvent(nameof(Picture));
                }
            }
        }

        public string Video
        {
            get { return artist.VideoUrl; }
            set
            {
                if (artist.VideoUrl != value)
                {
                    artist.VideoUrl = value;
                    RaisePropertyChangedEvent(nameof(Video));
                }
            }
        }

        public Category Category
        {
            get { return artist.Category; }
            set
            {
                if (artist.Category != value)
                {
                    artist.Category = value;
                    RaisePropertyChangedEvent(nameof(Category));
                    Validator.Validate(() => Category);
                }
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand ValidateCommand { get; set; }

        public bool? IsValid
        {
            get { return isValid; }
            private set
            {
                isValid = value;
                RaisePropertyChangedEvent(nameof(IsValid));
            }
        }

        public string ValidationErrorsString
        {
            get { return validationErrorsString; }
            private set
            {
                validationErrorsString = value;
                RaisePropertyChangedEvent(nameof(ValidationErrorsString));
            }
        }
        #endregion

        private void Validate(object o)
        {
            var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

            Validator.ValidateAllAsync().ContinueWith(r => OnValidateAllCompleted(r.Result), uiThread);
        }

        private void OnValidateAllCompleted(ValidationResult validationResult)
        {
            UpdateValidationSummary(validationResult);
        }

        private void UpdateValidationSummary(ValidationResult validationResult)
        {
            IsValid = validationResult.IsValid;
            ValidationErrorsString = validationResult.ToString();
        }


    }
}
