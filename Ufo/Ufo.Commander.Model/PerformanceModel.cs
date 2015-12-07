using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.Model
{
    public class PerformanceModel
    {
        private Performance performance;

        #region ctor
        public PerformanceModel()
        {
            performance = new Performance();
        }

        public PerformanceModel(Performance performance)
        {
            this.performance = performance;
        }
        #endregion

        public Performance GetInstance()
        {
            return performance;
        }

        public DateTime Start
        {
            get { return performance.Start; }
            set { performance.Start = value; }
        }

        public Artist Artist
        {
            get { return performance.Artist; }
            set { performance.Artist = value; }
        }

        public Venue Venue
        {
            get { return performance.Venue; }
            set { performance.Venue = value; }
        }
    }
}
