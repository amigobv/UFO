using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common.Domain
{
    public class Performance
    {
        #region properties
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public Artist Artist { get; set; }
        public Venue Venue { get; set; }
        #endregion

        public Performance(int id, DateTime start, Artist artist, Venue venue)
        {
            Id = id;
            Start = start;
            Artist = artist;
            Venue = venue;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as Performance;

            if (o != null)
            {
                return Id == o.Id && 
                       DateTime.Compare(Start, o.Start) == 0 &&
                       Artist.Equals(o.Artist) &&
                       Venue.Equals(o.Venue);
            }
            return false;
        }

        public override string ToString()
        {
            return "Performance starting at " + Start.TimeOfDay.ToString() + ": " + Artist.ToString() + "at " + Venue.ToString();
        }
    }
}
