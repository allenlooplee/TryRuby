using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TryRuby.ViewModels;

namespace TryRuby.Converters
{
    public class HorizontalAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var messageKind = (MessageKind)value;
            switch (messageKind)
            {
                case MessageKind.Sent:
                    return HorizontalAlignment.Right;
                case MessageKind.Received:
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
