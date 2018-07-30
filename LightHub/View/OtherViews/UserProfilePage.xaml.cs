using Octokit;
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

namespace LightHub.View.OtherViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserProfilePage : Windows.UI.Xaml.Controls.Page
    {
        private ViewModels.UserProfilePageViewModel ViewModel { get; set; }
        private Octokit.User user { get; set; }

        public UserProfilePage()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) =>
            {
                ViewModel = DataContext as ViewModels.UserProfilePageViewModel;
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Octokit.User user = e.Parameter as Octokit.User;
            this.user = user;
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                ViewModel.LoadUserProfile(user);
            }
        }
    }
}
