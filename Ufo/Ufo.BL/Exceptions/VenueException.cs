using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL.Exceptions
{
    public class VenueException : Exception
    {
        public VenueException(string msg) : base(string.Format("Venue error: {0}", msg))
        {
            // nothing to do
        }
    }
}
