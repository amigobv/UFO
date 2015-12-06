using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string msg) : base(string.Format("Registration error: {0}", msg))
        {
            // nothing to do
        }
    }
}
