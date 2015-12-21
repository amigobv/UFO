using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Ufo.Commander.Converter
{
    public class CategoryToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as string;

            if (val == null)
                return new SolidColorBrush(Colors.White);

            var color = System.Drawing.Color.FromArgb(val.GetHashCode());

            return new SolidColorBrush(Color.FromArgb(color.A, color.B, color.G, color.B));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
