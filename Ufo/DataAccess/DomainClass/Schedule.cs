using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DomainClass
{
    class Schedule : IDomain
    {
        #region properties
        public int Id { get; set; }
        public DateTime Day { get; set; }
        #endregion

        public Schedule(int id, DateTime day)
        {
            Id = id;
            Day = day;
        }

        public override string ToString()
        {
            return "Schedule for " + Day.Date;
        }
    }
}
