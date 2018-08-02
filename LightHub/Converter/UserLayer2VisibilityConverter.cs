using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LightHub.Converter
{
    public class UserLayer2VisibilityConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty hostLoginProperty = 
            DependencyProperty.Register(
                "hostLogin",
                typeof(string),
                typeof(UserLayer2VisibilityConverter),
                null
                );

        public string hostLogin
        {
            get { return (string)GetValue(hostLoginProperty); }
            set { SetValue(hostLoginProperty, value); }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string eventUserLogin = value as string;
            return (eventUserLogin == hostLogin) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
