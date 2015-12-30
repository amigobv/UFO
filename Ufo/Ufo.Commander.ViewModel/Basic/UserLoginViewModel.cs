using MvvmValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel.Basic
{
    public class UserLoginViewModel: ValidableViewModelBase
    {
        #region Private Members
        private User user;
        private IManager manager;
        private string validationErrorsString;
        private bool? isValid;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginViewModel"/> class.
        /// </summary>
        public UserLoginViewModel(IManager manager)
        {
            this.user = new User();
            this.manager = manager;
            ConfigureValidation();
        }

        public UserLoginViewModel(User user, IManager manager)
        {
            this.user = user;
            this.manager = manager;
            ConfigureValidation();
        }
        #endregion

        private void ConfigureValidation()
        {
            Validator.AddRule(() => Username,
                              () => RuleResult.Assert(!string.IsNullOrEmpty(Username), "Username is required!")
                              );

            Validator.ResultChanged += OnValidationResultChanged;
        }

        public void Validation()
        {
            Validate();
        }

        #region Properties
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username
        {
            get { return user.Username; }

            set
            {
                if (user.Username != value)
                {
                    user.Username = value;
                    RaisePropertyChangedEvent("Username");
                }

                Validator.ValidateAsync(() => Username);
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return user.Password; }

            set
            {
                if (user.Password != value)
                {
                    user.Password = manager.HashPassword(value);
                    RaisePropertyChangedEvent("Password");
                }
            }
        }

        public bool IsLoginSuccessful
        {
            get { return manager.GetActiveUser() != null; }
        }
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

        private void Validate()
        {
            var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

            Validator.ValidateAllAsync().ContinueWith(r => OnValidateAllCompleted(r.Result), uiThread);
        }

        private void OnValidateAllCompleted(ValidationResult validationResult)
        {
            UpdateValidationSummary(validationResult);
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

        #region Methods
        /// <summary>
        /// Logins this instance.
        /// </summary>
        public void Login()
        {
            try
            {
                manager.Login(user);
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
