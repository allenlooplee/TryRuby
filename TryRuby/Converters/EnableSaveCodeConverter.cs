using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TryRuby.Models;

namespace TryRuby.Converters
{
    public class EnableSaveCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var messageKind = (ReplMessageKind)value;
            switch (messageKind)
            {
                case ReplMessageKind.Sent:
                    return true;
                case ReplMessageKind.Received:
                    return false;
                default:
                    throw new InvalidOperationException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
