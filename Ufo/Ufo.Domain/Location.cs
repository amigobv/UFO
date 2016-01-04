using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.Domain
{
    [Serializable]
    public class Location
    {
        #region properties
        public string Label { get; set; }
        public string Id { get; set; }
        #endregion

        #region ctor
        public Location(string id, string label)
        {
            Id = id;
            Label = label;
        }

        public Location()
        {
            Id = string.Empty;
            Label = string.Empty;
        }
        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as Location;

            if (o != null)
            {
                return Id.Equals(o.Id) && Label.Equals(o.Label);
            }
            return false;
        }

        public override string ToString()
        {
            return "Location: " + Label + "(" + Id + ")";
        }
    }
}
