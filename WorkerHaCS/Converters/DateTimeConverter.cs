using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WorkerHaCS.Models;

namespace WorkerHaCS.Converters
{
    class DateTimeConverter : IValueConverter
    {
        DateTime _dateTime;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            _dateTime = (DateTime)value;

            using (DataContext db = new DataContext())
                return $"{_dateTime.ToShortDateString()}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return _dateTime;
        }
    }
}
