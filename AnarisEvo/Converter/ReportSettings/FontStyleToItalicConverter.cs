using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AnarisEvo.Converter.ReportSettings
{
    public class FontStyleToItalicConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            KeyValuePair<int, string> cat = (KeyValuePair<int, string>)value;
            bool tmp = System.Convert.ToBoolean(cat.Key);
            return System.Convert.ToBoolean(cat.Key);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
