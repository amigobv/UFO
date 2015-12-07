using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.Model
{
    public class VenueModel
    {
        private Venue venue;

        #region ctor
        public VenueModel()
        {
            venue = new Venue();
        }

        public VenueModel(Venue venue)
        {
            this.venue = venue;
        }
        #endregion

        public Venue GetInstance()
        {
            return venue;
        }

        public string Label
        {
            get { return venue.Label; }
            set { venue.Label = value; }
        }

        public int Spectators
        {
            get { return venue.MaxSpectators; }
            set { venue.MaxSpectators = value; }
        }

        public Location Location
        {
            get { return venue.Location; }
            set { venue.Location = value; }
        }
    }
}
