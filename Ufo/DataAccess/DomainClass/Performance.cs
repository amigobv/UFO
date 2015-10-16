using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DomainClass
{
    class Performance : IDomain
    {
        #region properties
        //TODO: change start and duration to time
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        #endregion

        public Performance(int id, DateTime start, TimeSpan duration, string description)
        {
            Id = id;
            Start = start;
            Duration = duration;
            Description = description;
        }

        public override string ToString()
        {
            return "Performance starting at " + Start.TimeOfDay + " duration " + Duration.ToString() + ": " + Description;
        }
    }
}
