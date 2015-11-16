using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common.Domain
{
    public class Restriction
    {
        #region properties
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Venue Venue { get; set; }
        public Category Category { get; set; }
        #endregion

        #region ctor
        public Restriction(int id, DateTime start, DateTime end, Venue venue, Category category)
        {
            Id = id;
            Start = start;
            End = end;
            Venue = venue;
            Category = category;
        }
        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as Restriction;

            if (o != null)
            {
                return Id == o.Id &&
                       DateTime.Compare(Start, o.Start) == 0 &&
                       DateTime.Compare(End, o.End) == 0 &&
                       Category.Equals(o.Category) &&
                       Venue.Equals(o.Venue);
            }
            return false;
        }

        public override string ToString()
        {
            return "Restriction starting at " + Start.ToString() + " - " + End.ToString() + ": " + Venue.ToString();
        }
    }
}
