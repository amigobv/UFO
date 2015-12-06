using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL.Exceptions
{
    class CategoryException : Exception
    {
        public CategoryException(string msg) : base(string.Format("Category error: {0}", msg))
        {
            // nothing to do
        }
    }
}
