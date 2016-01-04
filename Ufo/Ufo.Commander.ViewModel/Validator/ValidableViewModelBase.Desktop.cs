using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.Commander.ViewModel.Validator
{
    public partial class ValidableViewModelBase : IDataErrorInfo
    {
        partial void OnCreated()
        {
            HookUpValidationNotification();
        }

        public string this[string columnName]
        {
            get { return DataErrorInfoAdapter[columnName]; }
        }

        public string Error
        {
            get { return DataErrorInfoAdapter.Error; }
        }

        private void HookUpValidationNotification()
        {
            // Due to limitation of IDataErrorInfo, in WPF we need to explicitly indicated that something has changed
            // about the property in order for the framework to look for errors for the property.
            Validator.ResultChanged += (o, e) =>
            {
                var propertyName = e.Target as string;

                if (!string.IsNullOrEmpty(propertyName))
                {
                    RaisePropertyChangedEvent(propertyName);
                }
            };
        }
    }
}
