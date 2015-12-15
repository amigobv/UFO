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
        private IManager manager;
        private ObservableCollection<PerformanceSchedulerViewModel> scheduleFirstDay;
        private ObservableCollection<PerformanceSchedulerViewModel> scheduleSecondDay;
        private ObservableCollection<PerformanceSchedulerViewModel> scheduleThirdDay;
        #endregion

        #region ctor
        public ScheduleViewModel(IManager manager)
        {
            this.manager = manager;
            scheduleFirstDay = new ObservableCollection<PerformanceSchedulerViewModel>();
            scheduleSecondDay = new ObservableCollection<PerformanceSchedulerViewModel>();
            scheduleThirdDay = new ObservableCollection<PerformanceSchedulerViewModel>();
            LoadScheduleForDayOne();
            LoadScheduleForDayTwo();
            LoadScheduleForDayThree();
        }
        #endregion

        #region private methods
        private void LoadScheduleForDayOne()
        {
            ScheduleFirstDay.Clear();
            var locations = manager.GetAllLocations();

            foreach(var location in locations)
            {
                ScheduleFirstDay.Add(new PerformanceSchedulerViewModel(new DateTime(2016, 07, 22), location, manager));
            }
        }

        private void LoadScheduleForDayTwo()
        {
            ScheduleSecondDay.Clear();
            var locations = manager.GetAllLocations();

            foreach (var location in locations)
            {
                ScheduleSecondDay.Add(new PerformanceSchedulerViewModel(new DateTime(2016, 07, 23), location, manager));
            }
        }

        private void LoadScheduleForDayThree()
        {
            ScheduleThirdDay.Clear();
            var locations = manager.GetAllLocations();

            foreach (var location in locations)
            {
                ScheduleThirdDay.Add(new PerformanceSchedulerViewModel(new DateTime(2016, 07, 24), location, manager));
            }
        }

        private Task LoadScheduleForDayOneAsync()
        {
            return Task.Run(() => LoadScheduleForDayOne());
        }

        private Task LoadScheduleForDayTwoAsync()
        {
            return Task.Run(() => LoadScheduleForDayTwo());
        }

        private Task LoadScheduleForDayThreeAsync()
        {
            return Task.Run(() => LoadScheduleForDayOne());
        }

        private async void LoadAsync()
        {
            await LoadScheduleForDayOneAsync();
            await LoadScheduleForDayTwoAsync();
            await LoadScheduleForDayThreeAsync();
        }
        #endregion

        #region properties
        public ObservableCollection<PerformanceSchedulerViewModel> ScheduleFirstDay
        {
            get { return scheduleFirstDay; }
            set
            {
                if (scheduleFirstDay != value)
                {
                    scheduleFirstDay = value;
                    RaisePropertyChangedEvent(nameof(ScheduleFirstDay));
                }
            }
        }

        public ObservableCollection<PerformanceSchedulerViewModel> ScheduleSecondDay
        {
            get { return scheduleSecondDay; }
            set
            {
                if (scheduleSecondDay != value)
                {
                    scheduleSecondDay = value;
                    RaisePropertyChangedEvent(nameof(ScheduleSecondDay));
                }
            }
        }

        public ObservableCollection<PerformanceSchedulerViewModel> ScheduleThirdDay
        {
            get { return scheduleThirdDay; }
            set
            {
                if (scheduleThirdDay != value)
                {
                    scheduleThirdDay = value;
                    RaisePropertyChangedEvent(nameof(ScheduleThirdDay));
                }
            }
        }
        #endregion

    }
}
