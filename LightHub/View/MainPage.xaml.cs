using LightHub.Constant;
using LightHub.Helper;
using LightHub.Model;
using LightHub.View.SubViews;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            TitleBarManager.InitTitleBar(AppTitle);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserAccounts.CreateOauthenUri();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tokenString = UserAccounts.userAccountsList[0].accessToken;
        }

        private void MainNaviView_SelectionChanged(Windows.UI.Xaml.Controls.NavigationView sender, Windows.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {

            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {
                    case Const.NaviActivity:
                        break;

                    case Const.NaviNotif:
                        break;

                    case Const.NaviTrend:
                        break;

                    case Const.NaviIssue:
                        break;

                    case Const.NaviProfile:
                        MainFrame.Navigate(typeof(ProfilePage));
                        break;

                    case Const.NaviMyRepos:
                        break;

                    case Const.NaviMyStarred:
                        break;

                    case Const.NaviBookmarks:
                        break;
                }

            }
        }
    }
}
