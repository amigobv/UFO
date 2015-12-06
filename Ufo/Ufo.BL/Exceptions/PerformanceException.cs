using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL.Exceptions
{
    public class PerformanceException : Exception
    {
        public PerformanceException(string msg) : base(string.Format("Performance error: {0}", msg))
        {
            // nothing to do
        }
    }
}
