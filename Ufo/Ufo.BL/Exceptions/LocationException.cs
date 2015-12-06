using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL.Exceptions
{
    public class LocationException : Exception
    {
        public LocationException(string msg) : base(string.Format("Location error: {0}", msg))
        {
            // nothing to do
        }
    }
}
