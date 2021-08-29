using AnarisDLL.BLL.Category;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AnarisEvo.Converter.CategoryManager
{
    public class CategoryToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            KeyValuePair<int,string> cat  = (KeyValuePair<int, string>)value;
            bool tmp = System.Convert.ToBoolean(cat.Key);
            return System.Convert.ToBoolean(cat.Key);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
