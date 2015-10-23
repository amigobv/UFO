using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common.Domain
{
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
        #endregion

        public override string ToString()
        {
            return "Location: " + Label + "(" + Id + ")";
        }
    }
}
