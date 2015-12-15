using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ufo.Commander.Converter
{
    public class ListCountToSelectedIndex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listCount = 0;
            int.TryParse(value.ToString(), out listCount);
            if (listCount == 0)
            {
                //no items, make selected index - 1
                return -1;
            }
            //has items, make selected index the first one in the list
            return 0; ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
