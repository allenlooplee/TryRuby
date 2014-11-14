using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using TryRuby.Models;

namespace TryRuby.Converters
{
    public class ChatBubbleBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var accentBrush = (SolidColorBrush)App.Current.Resources["PhoneAccentBrush"];

            var messageKind = (ReplMessageKind)value;
            switch (messageKind)
            {
                case ReplMessageKind.Sent:
                    var accentColor = accentBrush.Color;
                    return new SolidColorBrush(
                        Color.FromArgb(
                            accentColor.A,
                            (byte)(accentColor.R / 2),
                            (byte)(accentColor.G / 2),
                            (byte)(accentColor.B / 2)));
                case ReplMessageKind.Received:
                    return accentBrush;
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
