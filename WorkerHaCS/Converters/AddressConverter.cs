using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WorkerHaCS.Models;

namespace WorkerHaCS.Converters
{
    class AddressConverter : IValueConverter
    {
        int id;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            id = (int)value;

            using (DataContext db = new DataContext())
            {
                var HouseInformationStreetId = db.HouseInformation.Find(id).StreetId;
                return $" ул. {db.Street.Find(HouseInformationStreetId).Name}, дом {db.HouseInformation.Find(id).HouseNumber}";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return id;
        }
    }
}
