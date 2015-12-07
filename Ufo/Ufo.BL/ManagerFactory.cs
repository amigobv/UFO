using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL
{
    public static class ManagerFactory
    {

        private static ManagerImpl manager;

        public static ManagerImpl GetManager()
        {
            if (manager == null)
                manager = new ManagerImpl();

            return manager;
        }
    }
}
