using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string msg) : base(string.Format("Login error: {0}", msg))
        {
            // nothing to do
        }
    }
}
