using System;
using Windows.UI.Xaml.Data;

namespace LightHub.Converter
{
    public class ShaTrimConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string orginalStr = value as string;
            return orginalStr?.Substring(0, 7);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
