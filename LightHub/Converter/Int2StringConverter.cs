using System;
using Windows.UI.Xaml.Data;

namespace LightHub.Converter
{
    public class Int2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int issuesNumber = (value is int) ? (int)value : -1;
            return (issuesNumber != -1) ? issuesNumber.ToString() : "Error on converting issue number";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
