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
    }
}
