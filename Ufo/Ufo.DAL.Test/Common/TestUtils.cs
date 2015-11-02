using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Ufo.DAL.Test.Common
{
    public static class TestUtils
    {
        public static string ConnString
        {
            get { return ConfigurationManager.ConnectionStrings["UfoDb"].ConnectionString; }
        }

        

    }
}
