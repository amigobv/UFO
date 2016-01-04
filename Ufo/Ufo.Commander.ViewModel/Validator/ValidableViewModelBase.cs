using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmValidation;
using System.ComponentModel;

namespace Ufo.Commander.ViewModel.Validator
{
    public abstract partial class ValidableViewModelBase : ViewModelBase, IValidatable
    {
        protected ValidationHelper Validator { get; private set; }
        private IDataErrorInfo DataErrorInfoAdapter { get; set; }

        public ValidableViewModelBase()
        {
            Validator = new ValidationHelper();
            DataErrorInfoAdapter = new DataErrorInfoAdapter(Validator);
            OnCreated();
        }

        Task<ValidationResult> IValidatable.Validate()
        {
            return Validator.ValidateAllAsync();
        }

        partial void OnCreated();
    }
}
