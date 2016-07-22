using MvvmValidation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Commander.ViewModel.Validator;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel.Basic
{
    public class ArtistViewModel : ValidableViewModelBase
    {
        #region events
        public Action NotifyUpdate;
        public Action NotifyDelete;
        #endregion 

        #region private members
        private IManager manager;
        private Artist artist;
        private CategoryViewModel category;
        private IList<CategoryViewModel> categories;
        private string validationErrorsString;
        private bool? isValid;
        #endregion

        #region ctor
        public ArtistViewModel(IManager manager)
        {
            this.artist = new Artist();
            this.manager = manager;
            category = new CategoryViewModel(manager);
            categories = new List<CategoryViewModel>();
            this.SaveCommand = new RelayCommand(o => UpdateArtist());
            this.RemoveCommand = new RelayCommand(o => DeleteArtist());
            ConfigureValidation();
        }

        public ArtistViewModel(Artist artist, IManager manager)
        {
            this.artist = artist;
            this.manager = manager;
            category = new CategoryViewModel(artist.Category, manager);
            categories = new List<CategoryViewModel>();
            this.SaveCommand = new RelayCommand(o => UpdateArtist());
            this.RemoveCommand = new RelayCommand(o => DeleteArtist());
            ConfigureValidation();
        }

        private void UpdateArtist()
        {
            manager.UpdateArtist(artist);

            // notify observers
            if (NotifyUpdate != null)
            {
                NotifyUpdate();
            }
        }

        private void DeleteArtist()
        {
            manager.RemoveArtist(artist);

            // notify observers
            if (NotifyDelete != null)
            {
                NotifyDelete();
            }
        }
        #endregion

        private void ConfigureValidation()
        {
            Validator.AddRule(() => Name,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Name), "Name is required!")
                              );

            Validator.AddRule(() => Name,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Name) && Name.Length > 2, "Name too short!")
                              );

            Validator.AddRule(() => Country,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Country), "Country is required!"));

            Validator.AddRule(() => Email,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Email), "Email is required!"));

            Validator.AddRule(() => Email,
                              () => RuleResult.Assert(Email.Contains("@"), "Wrong Email format! Domain is missing (e.g. @google.com)"));

            Validator.AddRule(() => Email,
                              () => RuleResult.Assert(Email.Contains("."), "Wrong Email format! Domain is missing. (e.g. @google.com)"));

            Validator.AddRule(() => Category,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Category.Name), "Category is required!"));


            Validator.ResultChanged += OnValidationResultChanged;
        }

        public void Validation()
        {
            Validator.ValidateAsync(() => Category);
            UpdateValidationSummary(Validator.ValidateAll());
        }

        #region properties
        public int Id
        {
            get { return artist.Id; }
            set
            {
                if (artist.Id != value)
                {
                    artist.Id = value;
                    RaisePropertyChangedEvent(nameof(Id));
                }
            }
        }

        public string Name
        {
            get { return artist.Name; }
            set
            {
                if (artist.Name != value)
                {
                    artist.Name = value;
                    RaisePropertyChangedEvent(nameof(Name));
                }
                Validator.ValidateAsync(() => Name);
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
                }
                Validator.ValidateAsync(() => Country);
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
                }
                Validator.ValidateAsync(() => Email);
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

        public string CategoryName
        {
            get { return artist.Category == null ? "" : artist.Category.Label; }
        }

        public CategoryViewModel Category
        {
            get { return category; }
            set
            {
                if (value != null && category != value)
                {
                    category = value;
                    CategoryVmToCategory(category);
                    RaisePropertyChangedEvent(nameof(Category));
                    Validator.ValidateAsync(() => Category);
                }
            }
        }

        public IList<CategoryViewModel> Categories
        {
            get
            { 
                LoadCategories();
                return categories;
            }
            set
            {
                if (categories != value)
                {
                    categories = value;
                    RaisePropertyChangedEvent(nameof(Categories));
                }
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand ValidateCommand { get; set; }
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
            if (!IsValid.GetValueOrDefault(true))
            {
                ValidationResult validationResult = Validator.GetResult();
                UpdateValidationSummary(validationResult);
            }
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
            var artist = obj as ArtistViewModel;

            if (artist == null)
                return false;


            return artist.artist.Equals(this.artist);
        }

        private void LoadCategories()
        {
            categories.Clear();
            var listCategories = manager.GetAllCategories();

            foreach (var category in listCategories)
                categories.Add(new CategoryViewModel(category, manager));
        }

        private void CategoryVmToCategory(CategoryViewModel vm)
        {
            if (vm == null)
                return;

            artist.Category = new Category()
            {
                Id = vm.Identifier,
                Label = vm.Name
            };
        }
    }
}
