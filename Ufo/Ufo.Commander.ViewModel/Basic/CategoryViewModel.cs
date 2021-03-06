﻿using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;
using MvvmValidation;
using System.Threading.Tasks;
using Ufo.Commander.ViewModel.Validator;
using System;

namespace Ufo.Commander.ViewModel.Basic
{
    public class CategoryViewModel : ValidableViewModelBase
    {
        #region events
        public Action NotifyUpdate;
        #endregion


        #region private members
        private Category category;
        private IManager manager;
        private string validationErrorsString;
        private bool? isValid;
        #endregion

        #region ctor
        public CategoryViewModel(IManager manager)
        {
            this.manager = manager;
            this.category = new Category();
            this.SaveCommand = new RelayCommand(o => UpdateCategory());
            ConfigureValidation();
        }

        public CategoryViewModel(Category category, IManager manager)
        {
            this.manager = manager;

            if (category == null)
                this.category = new Category();
            else
                this.category = category;
            this.SaveCommand = new RelayCommand(o => UpdateCategory());
            ConfigureValidation();
        }

        private void UpdateCategory()
        {
            manager.UpdateCategory(category);

            //notify observers
            if (NotifyUpdate != null)
            {
                NotifyUpdate();
            }
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
                              () => RuleResult.Assert(!manager.CategoryExists(new Category(Identifier, "")), "This category already exists!"));

            Validator.AddRule(() => Name,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Name), "Category name is required!"));

            Validator.ResultChanged += OnValidationResultChanged;
        }

        public void Validation()
        {
            UpdateValidationSummary(Validator.ValidateAll());
        }

        #region properties
        public string Name
        {
            get { return category.Label; }
            set
            {
                if (category.Label != value)
                {
                    category.Label = value;
                    RaisePropertyChangedEvent(nameof(Name));
                }
                Validator.ValidateAsync(() => Name);
            }
        }

        public string Identifier
        {
            get { return category.Id; }
            set
            {
                if (category.Id != value)
                {
                    category.Id = value;
                    RaisePropertyChangedEvent(nameof(Identifier));
                }
                Validator.ValidateAsync(() => Identifier);
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
            set
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
            var category = obj as CategoryViewModel;

            if (category == null)
                return false;


            return category.Equals(this.category);
        }
    }
}
