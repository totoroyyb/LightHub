using LightHub.Model;
using LightHub.View.OtherViews;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
                await Core.GetUserProfile();
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
