using LightHub.Model;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LightHub.Converter
{
    public class CurrentUser2VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string targetUserLogin = value as string;
            Octokit.User currentUserProfile = Core.RetrieveUserProfile();
            return (targetUserLogin == currentUserProfile?.Login) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
