using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common.Domain
{
    public class Venue
    {
        #region properties
        public int Id { get; set; }
        public string Label { get; set; }
        public Location Location { get; set; }
        public int MaxSpectators { get; set; }
        #endregion

        public Venue(int id, string label, Location location, int maxSpectators)
        {
            Id = id;
            Label = label;
            Location = location;
            MaxSpectators = maxSpectators;
        }

        public override string ToString()
        {
            return "Venue: " + Label + "(" + Id + ") " + Location.ToString();
        }
    }
}
