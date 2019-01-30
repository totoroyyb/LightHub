using LightHub.Constant;
using LightHub.Model;
using LightHub.View.SubViews;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LightHub
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string uriStr;
        

        public MainPage()
        {
            this.InitializeComponent();
            //TitleBarManager.InitTitleBar(AppTitle);
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
                        MainFrame.Navigate(typeof(NewsPage));
                        //sender.Header = "Activity";
                        break;

                    case Const.NaviNotif:
                        //sender.Header = "Notification";
                        break;

                    case Const.NaviTrend:
                        //sender.Header = "Trend";
                        break;

                    case Const.NaviIssue:
                        //sender.Header = "Issue";
                        break;

                    case Const.NaviProfile:
                        MainFrame.Navigate(typeof(ProfilePage));
                        //sender.Header = "My Profile";
                        break;

                    case Const.NaviMyRepos:
                        //sender.Header = "My Repositories";
                        break;

                    case Const.NaviMyStarred:
                        //sender.Header = "My Starred";
                        break;

                    case Const.NaviBookmarks:
                        //sender.Header = "My Bookmark";
                        break;
                }

            }
        }
    }
}
