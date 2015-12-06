using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string msg) : base(string.Format("Invalid user: {0}", msg))
        {
            // nothing to do
        }
    }
}
