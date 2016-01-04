using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.BL
{
    public class BLFactory
    {
        private static ManagerImpl manager;
        private static ViewerImpl viewer;

        public static ManagerImpl GetManager()
        {
            if (manager == null)
                manager = new ManagerImpl();

            return manager;
        }

        

        public static ViewerImpl GetViewer()
        {
            if (viewer == null)
                viewer = new ViewerImpl();

            return viewer;
        }
    }
}
