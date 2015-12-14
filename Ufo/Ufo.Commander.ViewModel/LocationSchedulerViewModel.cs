using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class LocationSchedulerViewModel : SchedulerViewModel<VenueEditViewModel, DateTime>
    {
        #region fields
        private IManager manager;
        private Location location;

        readonly DateTime[] hours = new DateTime[]
        {
          new DateTime(2016, 7, 22, 15, 0, 0),
          new DateTime(2016, 7, 22, 16, 0, 0),
          new DateTime(2016, 7, 22, 17, 0, 0),
          new DateTime(2016, 7, 22, 18, 0, 0),
          new DateTime(2016, 7, 22, 19, 0, 0),
          new DateTime(2016, 7, 22, 20, 0, 0),
          new DateTime(2016, 7, 22, 21, 0, 0),
          new DateTime(2016, 7, 22, 22, 0, 0)
        };

        private VenueEditViewModel[] venues;
        private Dictionary<TimeSpan, Dictionary<int, PerformanceViewModel>> performances;
        #endregion

        #region Ctor

        public LocationSchedulerViewModel(IManager manager)
        {
            this.manager = manager;
            this.location = new Location();
            LoadVenues();
        }

        public LocationSchedulerViewModel(Location location, IManager manager)
        {
            this.manager = manager;
            this.location = location;
            LoadVenues();
        }

        #endregion

        #region Override

        protected override object GetCellValue(VenueEditViewModel rowHeader, DateTime columnHeader)
        {
            return null;
        }

        protected override IEnumerable<DateTime> GetColumnHeaders()
        {
            return Hours;
        }

        protected override IEnumerable<VenueEditViewModel> GetRowHeaders()
        {
            return Venues;
        }

        #endregion

        #region private helpers
        private void LoadVenues()
        {
            var listVenues = manager.GetVenuesByLocation(location.Id);
            var idx = 0;
            venues = new VenueEditViewModel[listVenues.Count];

            foreach(var venue in listVenues)
            {
                venues[idx++] = new VenueEditViewModel(venue, manager);
            }
        }
        #endregion

        #region properties
        public DateTime[] Hours
        {
            get { return hours; }
        }

        public IEnumerable<VenueEditViewModel> Venues
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
