using JetBrains.Annotations;
using MvvmValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.Commander.ViewModel
{
    public class DataErrorInfoAdapter : IDataErrorInfo
    {
        public DataErrorInfoAdapter([NotNull] ValidationHelper validator)
        {

            Contract.Requires(validator != null);
            Validator = validator;

        }
        public ValidationHelper Validator { get; set; }


        #region IDataErrorInfo Members

        public string this[string columnName]
        {
            get { return Validator.GetResult(columnName).ToString(); }
        }

        public string Error
        {
            get { return Validator.GetResult().ToString(); }
        }
        #endregion
    }
}
