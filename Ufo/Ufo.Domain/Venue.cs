using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.Domain
{
    public class Venue
    {
        #region properties
        public int Id { get; set; }
        public string Label { get; set; }
        public Location Location { get; set; }
        public int MaxSpectators { get; set; }
        #endregion

        #region ctor
        public Venue(int id, string label, int maxSpectators, Location location)
        {
            Id = id;
            Label = label;
            Location = location;
            MaxSpectators = maxSpectators;
        }

        public Venue()
        {
            Id = 0;
            Label = string.Empty;
            Location = null;
            MaxSpectators = 0;
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
