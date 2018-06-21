using LightHub.Model;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LightHub
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Windows.UI.Xaml.Controls.Page
    {
        public static string uriStr;
        

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserAccounts.CreateOauthenUri();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tokenString = UserAccounts.userAccountsList[0].accessToken;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UserAccounts.SetClientCredential(UserAccounts.userAccountsList[0]);
            var repo = await UserAccounts.client.Repository.GetAllForCurrent();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UserAccounts.SetClientCredential(UserAccounts.userAccountsList[0]);
            var user = await UserAccounts.client.User.Current();
            var test = await UserAccounts.client.Activity.Feeds.GetFeeds();
            var test1 = await UserAccounts.client.Activity.Notifications.GetAllForCurrent();
        }
    }
}
