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
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public Artist Artist { get; set; }
        public Venue Venue { get; set; }
        #endregion

        public Performance(int id, DateTime date, DateTime time, Artist artist, Venue venue)
        {
            Id = id;
            Date = date;
            Time = time;
            Artist = artist;
            Venue = venue;
        }

        public override string ToString()
        {
            return "Performance starting at " + Date.Date.ToString() + " - " + Time.TimeOfDay.ToString() + ": " + Artist.ToString();
        }
    }
}
