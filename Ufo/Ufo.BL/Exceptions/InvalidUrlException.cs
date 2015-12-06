using System;

namespace Ufo.BL.Exceptions
{
    public class InvalidUrlException : Exception
    {
        public InvalidUrlException(string msg) 
            : base(string.Format("Invalid URL \"{0}\".", msg))
        {
            // nothing to do
        }
    }
}
