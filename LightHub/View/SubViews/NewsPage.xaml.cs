using LightHub.Model;
using LightHub.View.OtherViews;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LightHub.View.SubViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsPage : Page
    {
        private ViewModels.NewsPageViewModel ViewModel { get; set; }

        public NewsPage()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) =>
            {
                ViewModel = DataContext as ViewModels.NewsPageViewModel;
            };
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegisterHandler();
            if (!Core.isUserProfileValid())
            {
                ViewModel.userProfile = await Core.GetUserProfile();
            }
            ViewModel.LoadAllCurrentUserReceivedEvents();
        } 

        private void RegisterHandler()
        {
            NaviToUserDetail.OnNaviToUserDetailReady += NaviToUserDetail_OnNaviToUserDetailReady;
        }

        private void DeregisterHandler()
        {
            NaviToUserDetail.OnNaviToUserDetailReady -= NaviToUserDetail_OnNaviToUserDetailReady;
        }

        private void NaviToUserDetail_OnNaviToUserDetailReady(object sender, EventArgs e)
        {
            Frame.Navigate(typeof(UserProfilePage), sender);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            DeregisterHandler();
        }
    }
}
