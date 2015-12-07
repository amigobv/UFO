using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.Model
{
    public class LocationModel
    {
        private Location location;

        #region ctor
        public LocationModel()
        {
            location = new Location();
        }

        public LocationModel(Location location)
        {
            this.location = location;
        }
        #endregion

        public Location GetInstance()
        {
            return location;
        }

        public string Label
        {
            get { return location.Label; }
            set { location.Label = value; }
        }

    }
}
