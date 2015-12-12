using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Commander.Model;

namespace Ufo.Commander.ViewModel
{
    public class TimeViewModel : ViewModelBase
    {
        #region private members
        private TimeModel time;
        #endregion

        #region ctor
        public TimeViewModel()
        {
            this.time = new TimeModel();
        }

        public TimeViewModel(TimeModel time)
        {
            this.time = time;
        }
        #endregion


        public void Increment()
        {
            time.IncrementHour();
        }

        public void Decrement()
        {
            time.DecrementHour();
        }

        #region properties
        public int Hour
        {
            get { return time.Hour; }
            set
            {
                if (time.Hour != value)
                {
                    time.Hour = value;
                    RaisePropertyChangedEvent(nameof(Hour));
                }
            }
        }

        public int Minute
        {
            get { return time.Minute; }
            set
            {
                if (time.Minute != value)
                {
                    time.Minute = value;
                    RaisePropertyChangedEvent(nameof(Minute));
                }
            }
        }

        public string Time
        {
            get { return time.Time; }
        }
        #endregion
    }
}
