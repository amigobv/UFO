using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class DayViewModel : ViewModelBase
    {
        
        #region private members
        private IManager manager;
        private ObservableCollection<PerformanceViewModel> schedule;
        #endregion

        #region ctor
        public DayViewModel(IManager manager)
        {
            this.manager = manager;
            schedule = new ObservableCollection<PerformanceViewModel>();
            LoadPerformanceBy();
        }

        public DayViewModel(Venue venue, IManager manager)
        {
            this.manager = manager;
            schedule = new ObservableCollection<PerformanceViewModel>();
            LoadPerformanceBy(venue);
        }

        public DayViewModel(Artist artist, IManager manager)
        {
            this.manager = manager;
            schedule = new ObservableCollection<PerformanceViewModel>();
            LoadPerformanceBy(artist);
        }

        public DayViewModel(DateTime day, IManager manager)
        {
            this.manager = manager;
            schedule = new ObservableCollection<PerformanceViewModel>();
            LoadPerformanceBy(day);
        }
        #endregion

        public void LoadPerformanceBy(Venue venue)
        {
            Performances.Clear();
            var listPerformances = manager.GetPerformanceByVenue(venue);

            foreach (var performance in listPerformances)
                Performances.Add(new PerformanceViewModel(performance, manager));
        }

        public void LoadPerformanceBy(Artist artist)
        {
            Performances.Clear();
            var listPerformances = manager.GetPerformanceByArtist(artist);

            foreach (var performance in listPerformances)
                Performances.Add(new PerformanceViewModel(performance, manager));
        }

        public void LoadPerformanceBy(DateTime day)
        {
            Performances.Clear();
            var listPerformances = manager.GetPerformanceByDay(day);

            foreach (var performance in listPerformances)
                Performances.Add(new PerformanceViewModel(performance, manager));
        }

        public void LoadPerformanceBy()
        {
            Performances.Clear();
            var listPerformances = manager.GetAllPerformances();

            foreach (var performance in listPerformances)
                Performances.Add(new PerformanceViewModel(performance, manager));


        }

        #region properties
        public ObservableCollection<PerformanceViewModel> PerformancesByVenue
        {
            get { return schedule; }
            set
            {
                if (schedule != value)
                {
                    schedule = value;
                    RaisePropertyChangedEvent(nameof(PerformancesByVenue));
                }
            }
        }

        public ObservableCollection<PerformanceViewModel> PerformancesByArtist
        {
            get { return schedule; }
            set
            {
                if (schedule != value)
                {
                    schedule = value;
                    RaisePropertyChangedEvent(nameof(PerformancesByArtist));
                }
            }
        }

        public ObservableCollection<PerformanceViewModel> PerformancesByDay
        {
            get { return schedule; }
            set
            {
                if (schedule != value)
                {
                    schedule = value;
                    RaisePropertyChangedEvent(nameof(PerformancesByDay));
                }
            }
        }

        public ObservableCollection<PerformanceViewModel> Performances
        {
            get { return schedule; }
            set
            {
                if (schedule != value)
                {
                    schedule = value;
                    RaisePropertyChangedEvent(nameof(Performances));
                }
            }
        }

        public ObservableCollection<PerformanceViewModel> Schedule
        {
            get { return schedule; }
            set
            {
                if (schedule != value)
                {
                    schedule = value;
                    RaisePropertyChangedEvent(nameof(Schedule));
                }
            }
        }
        #endregion
    }
}
