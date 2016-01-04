using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel.Basic
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
            ShareCommand = new RelayCommand(o => manager.NotifiyAllArtists());
            RefreshCommand = new RelayCommand(o =>
                {
                    LoadScheduleForDayOne();
                    LoadScheduleForDayTwo();
                    LoadScheduleForDayTwo();
                });

        }
        #endregion

        #region properties
        public ObservableCollection<PerformanceSchedulerViewModel> ScheduleFirstDay
        {
            get
            {
                return scheduleFirstDay;
            }
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
            get
            {
                return scheduleSecondDay;
            }
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
            get
            {
                return scheduleThirdDay;
            }
            set
            {
                if (scheduleThirdDay != value)
                {
                    scheduleThirdDay = value;
                    RaisePropertyChangedEvent(nameof(ScheduleThirdDay));
                }
            }
        }

        public ICommand ShareCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        #endregion

        public void LoadSchedule()
        {
            LoadScheduleForDayOne();
            LoadScheduleForDayTwo();
            LoadScheduleForDayThree();
        }

        #region private methods
        private void LoadScheduleForDayOne()
        {
            scheduleFirstDay.Clear();
            var locations = manager.GetAllLocations();

            foreach (var location in locations)
            {
                scheduleFirstDay.Add(new PerformanceSchedulerViewModel(new DateTime(2016, 07, 22), location, manager));
            }

            ScheduleFirstDay = scheduleFirstDay;
        }

        private void LoadScheduleForDayTwo()
        {
            scheduleSecondDay.Clear();
            var locations = manager.GetAllLocations();

            foreach (var location in locations)
            {
                scheduleSecondDay.Add(new PerformanceSchedulerViewModel(new DateTime(2016, 07, 23), location, manager));
            }

            ScheduleSecondDay = scheduleSecondDay;
        }

        private void LoadScheduleForDayThree()
        {
            scheduleThirdDay.Clear();
            var locations = manager.GetAllLocations();

            foreach (var location in locations)
            {
                scheduleThirdDay.Add(new PerformanceSchedulerViewModel(new DateTime(2016, 07, 24), location, manager));
            }

            ScheduleThirdDay = scheduleThirdDay;
        }
        #endregion
    }
}
