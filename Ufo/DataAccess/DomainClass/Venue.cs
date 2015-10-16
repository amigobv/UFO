using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DomainClass
{
    class Venue : IDomain
    {
        #region properties
        public int Id { get; set; }
        public string Label { get; set; }
        public string Identifier { get; set; }
        public string Location { get; set; }
        public bool IsFireSafe { get; set; }
        public int MaxSpectators { get; set; }
        #endregion

        public Venue(int id, string label, string identifier, string location, bool isFireSafe, int maxSpectators)
        {
            Id = id;
            Label = label;
            Identifier = identifier;
            Location = location;
            IsFireSafe = isFireSafe;
            MaxSpectators = maxSpectators;
        }

        public override string ToString()
        {
            return "Venue: " + Label + "(" + Identifier + ") " + Location;
        }
    }
}
