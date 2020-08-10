using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PastryShop.Converters
{
    public class RadioToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool original = (bool)value;
            if (parameter is string)
                return !(original ^ Boolean.Parse(parameter as string));
            else
                throw new NotImplementedException();

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string)
                return Boolean.Parse(parameter as string);
            else
                throw new NotImplementedException();
        }
    }
}
