using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL
{
    public static class ManagerFactory
    {

        private static Manager manager;

        public static Manager GetManager()
        {
            if (manager == null)
                manager = new Manager();

            return manager;
        }
    }
}
