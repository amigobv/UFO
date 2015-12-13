using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class ScheduleViewModel: ViewModelBase
    {
        #region private members
        private DateTime date;
        private Artist artist;
        private Venue venue;
        private DayViewModel dayVm;
        #endregion

        #region ctor
        public ScheduleViewModel(IManager manager)
        {
            date = new DateTime(2016, 07, 22, 16, 0, 0);
            dayVm = new DayViewModel(date, manager);
        }
        #endregion

        #region properties
        public DayViewModel DaySchedule
        {
            get { return dayVm; }
            set
            {
                if (dayVm != value)
                {
                    dayVm = value;
                    RaisePropertyChangedEvent(nameof(DaySchedule));
                }
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChangedEvent(nameof(Date));
                }
            }
        }

        public Artist Artist
        {
            get { return artist; }
            set
            {
                if (artist != value)
                {
                    artist = value;
                    RaisePropertyChangedEvent(nameof(Artist));
                }
            }
        }

        public Venue Venue
        {
            get { return venue; }
            set
            {
                if (venue != value)
                {
                    venue = value;
                    RaisePropertyChangedEvent(nameof(Venue));
                }
            }
        }
        #endregion

    }
}
