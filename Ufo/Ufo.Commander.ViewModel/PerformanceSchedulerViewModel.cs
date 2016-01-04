using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Commander.ViewModel.Basic;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class PerformanceSchedulerViewModel : SchedulerViewModel<VenueViewModel, DateTime>
    {
        #region fields
        private IManager manager;
        private Location location;
        private DateTime day;

        readonly DateTime[] hours = new DateTime[]
        {
          new DateTime(2016, 7, 22, 16, 0, 0),
          new DateTime(2016, 7, 22, 17, 0, 0),
          new DateTime(2016, 7, 22, 18, 0, 0),
          new DateTime(2016, 7, 22, 19, 0, 0),
          new DateTime(2016, 7, 22, 20, 0, 0),
          new DateTime(2016, 7, 22, 21, 0, 0),
          new DateTime(2016, 7, 22, 22, 0, 0)
        };

        private VenueViewModel[] venues;
        private Dictionary<TimeSpan, Dictionary<string, PerformanceViewModel>> performanceDict;
        #endregion

        #region Ctor

        public PerformanceSchedulerViewModel(IManager manager)
        {
            this.manager = manager;
            this.location = new Location();
            LoadVenues();
            LoadPerformances();
        }

        public PerformanceSchedulerViewModel(DateTime day, Location location, IManager manager)
        {
            this.manager = manager;
            this.location = location;
            this.day = day;
            performanceDict = new Dictionary<TimeSpan, Dictionary<string, PerformanceViewModel>>();

            LoadVenues();
            LoadPerformances();
        }
        #endregion

        #region Override
        public override object GetCellValue(VenueViewModel rowHeader, DateTime columnHeader)
        {
            if (performanceDict.ContainsKey(columnHeader.TimeOfDay)) 
            {
                var dict = performanceDict[columnHeader.TimeOfDay];

                if (dict.ContainsKey(rowHeader.Id))
                {
                    return dict[rowHeader.Id];
                }
            }

            return null;
        }

        public override IEnumerable<DateTime> GetColumnHeaders()
        {
            return Hours;
        }

        public override IEnumerable<VenueViewModel> GetRowHeaders()
        {
            return Venues;
        }
        #endregion

        #region private helpers
        private void LoadVenues()
        {
            var listVenues = manager.GetVenuesByLocation(location.Id);
            var idx = 0;
            venues = new VenueViewModel[listVenues.Count];

            foreach(var venue in listVenues)
            {
                venues[idx++] = new VenueViewModel(venue, manager);
            }
        }

        private void LoadPerformances()
        {
            var listsPerformances = manager.GetPerformanceByDay(day);

            foreach(var performance in listsPerformances)
            {
                if (!performanceDict.ContainsKey(performance.Start.TimeOfDay))
                    performanceDict.Add(performance.Start.TimeOfDay, new Dictionary<string, PerformanceViewModel>());

                performanceDict[performance.Start.TimeOfDay].Add(BuildVenueIdString(performance.Venue), new PerformanceViewModel(performance, manager));
            }
        }

        private string BuildVenueIdString(Venue venue)
        {
            return string.Format("{0}{1}", venue.Location.Id, venue.Id);
        }
        #endregion

        #region properties
        public DateTime[] Hours
        {
            get { return hours; }
        }

        public IEnumerable<VenueViewModel> Venues
        {
            get { return venues; }
        }

        public string Location
        {
            get { return location.Label; }
        }
        #endregion
    }
}
