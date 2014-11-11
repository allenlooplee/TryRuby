using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TryRuby.Models;

namespace TryRuby.Converters
{
    public class HorizontalAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var messageKind = (ReplMessageKind)value;
            switch (messageKind)
            {
                case ReplMessageKind.Sent:
                    return HorizontalAlignment.Right;
                case ReplMessageKind.Received:
                    return HorizontalAlignment.Left;
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
