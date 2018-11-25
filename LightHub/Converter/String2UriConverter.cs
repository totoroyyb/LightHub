using System;
using Windows.UI.Xaml.Data;

namespace LightHub.Converter
{
    public class String2UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string && !string.IsNullOrEmpty((string)value))
            {
                if (value.ToString().Contains("mailto:") || value.ToString().Contains("https://") || value.ToString().Contains("http://"))
                {
                    return new Uri((string)value);
                }
                else
                {
                    return new Uri("http://" + (string)value);
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
