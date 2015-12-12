using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.Commander.Model
{
    public class TimeModel
    {
        #region private members
        private int hour;
        private int minute;
        #endregion

        #region ctor
        public TimeModel(int hour, int minute)
        {
            this.hour = hour;
            this.minute = minute;
        }

        public TimeModel()
        {
            hour = 0;
            minute = 0;
        }
        #endregion

        #region public methods
        public void IncrementMinute()
        {
            minute++;
            if (minute > 59)
                minute = 0;
        }

        public void IncrementHour()
        {
            hour++;
            if (hour > 23)
                hour = 0;
        }

        public void DecrementMinute()
        {
            minute--;
            if (minute < 0)
                minute = 59;
        }

        public void DecrementHour()
        {
            hour--;
            if (hour < 0)
                hour = 23;
        }
        #endregion

        #region properties
        public int Hour
        {
            get { return hour; }
            set
            {
                if (value > 23)
                    hour = 23;
                else if (value < 0)
                    hour = 0;
                else
                    hour = value;
            }
        }

        public int Minute
        {
            get { return minute; }
            set
            {
                if (value > 59)
                    minute = 59;
                else if (value < 0)
                    minute = 0;
                else
                    minute = value;
            }
        }

        public string Time
        {
            get { return string.Format("%02d:%02", hour, minute); }
        }
        #endregion
    }
}
