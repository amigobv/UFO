using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string msg) : base(string.Format("Data access exception: {0}", msg))
        {
            // nothing to do
        }
    }
}
