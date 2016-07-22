using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.Domain
{
    [Serializable]
    public class Venue
    {
        #region properties
        public int Id { get; set; }
        public string Label { get; set; }
        public Location Location { get; set; }
        public int MaxSpectators { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Unique
        {
            get { return Location.Id + Id; }
            set { }
        }
        #endregion

        #region ctor
        public Venue(int id, string label, int maxSpectators, Location location, double latitude, double longitude)
        {
            Id = id;
            Label = label;
            Location = location;
            MaxSpectators = maxSpectators;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Venue()
        {
            Id = 0;
            Label = string.Empty;
            Location = null;
            MaxSpectators = 0;
            Latitude = 48.306368;
            Longitude = 14.286277;
        }

        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as Venue;

            if (o != null)
            {
                return Id == o.Id && 
                      Label.Equals(o.Label) &&
                      Location.Equals(o.Location) && 
                      MaxSpectators == o.MaxSpectators;
            }
            return false;
        }

        public override string ToString()
        {
            return "Venue: " + Label + "(" + Id + ") " + Location.ToString();
        }
    }
}
