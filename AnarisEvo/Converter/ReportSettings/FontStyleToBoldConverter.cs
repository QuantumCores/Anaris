using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AnarisEvo.Converter.ReportSettings
{
    public class FontStyleToBoldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int style = (int)value;
            bool tmp = (style == 0) ? false : true;
            return tmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool tmp = (bool)value;
            return (tmp) ? 1 : 0;
        }
    }
}
