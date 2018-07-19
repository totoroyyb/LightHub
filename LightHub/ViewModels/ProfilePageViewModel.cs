using LightHub.Model;
using LightHub.Formatter;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Octokit;
using Microsoft.Toolkit.Uwp;
using static LightHub.Model.IncrementalLoadSource;

namespace LightHub.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        private string _avatarStr;
        public string avatarStr
        {
            get { return _avatarStr; }
            set { SetProperty(ref _avatarStr, value); }
        }

        private string _fullNameStr;
        public string fullNameStr
        {
            get { return _fullNameStr; }
            set { SetProperty(ref _fullNameStr, value); }
        }

        private string _loginStr;
        public string loginStr
        {
            get { return _loginStr; }
            set { SetProperty(ref _loginStr, value); }
        }

        private string _bioStr;
        public string bioStr
        {
            get { return _bioStr; }
            set { SetProperty(ref _bioStr, value); }
        }

        private string _webLinkStr;
        public string webLinkStr
        {
            get { return _webLinkStr; }
            set { SetProperty(ref _webLinkStr, value); }
        }

        private string _emailLinkStr;
        public string emailLinkStr
        {
            get { return _emailLinkStr; }
            set { SetProperty(ref _emailLinkStr, value); }
        }

        private string _formattedEmailStr;
        public string formattedEmailStr
        {
            get { return _formattedEmailStr; }
            set { SetProperty(ref _formattedEmailStr, value); }
        }

        private ObservableCollection<Activity> _allCurrentUserPerformedEvents = new ObservableCollection<Activity>();
        public ObservableCollection<Activity> allCurrentUserPerformedEvents
        {
            get { return _allCurrentUserPerformedEvents; }
            set { SetProperty(ref _allCurrentUserPerformedEvents, value); }
        }

        private ObservableCollection<Octokit.User> _allCurrentUserFollowers = new ObservableCollection<Octokit.User>();
        public ObservableCollection<Octokit.User> allCurrentUserFollowers
        {
            get { return _allCurrentUserFollowers; }
            set { SetProperty(ref _allCurrentUserFollowers, value); }
        }

        private ObservableCollection<Octokit.User> _allCurrentUserFollowings = new ObservableCollection<Octokit.User>();
        public ObservableCollection<Octokit.User> allCurrentUserFollowings
        {
            get { return _allCurrentUserFollowings; }
            set { SetProperty(ref _allCurrentUserFollowings, value); }
        }

        public async Task LoadAllUserProfile()
        {
            var userProfile = await Core.GetUserProfile();
            avatarStr = userProfile.AvatarUrl;
            fullNameStr = userProfile.Name;
            loginStr = userProfile.Login;
            bioStr = userProfile.Bio;
            webLinkStr = userProfile.Blog;
            emailLinkStr = userProfile.Email;
            formattedEmailStr = EmailUriFormatter.GetFormattedEmailStr(emailLinkStr);
        }

        public void LoadAllCurrentUserPerformedEvents()
        {
            allCurrentUserPerformedEvents = new IncrementalLoadingCollection<CurrentUserActivitySource, Activity>();
        }

        public void LoadAllCurrentUserFollowers()
        {
            allCurrentUserFollowers = new IncrementalLoadingCollection<CurrentUserFollowers, Octokit.User>();
        }

        public void LoadAllCurrentUserFollowings()
        {
            allCurrentUserFollowings = new IncrementalLoadingCollection<CurrentUserFollowings, Octokit.User>();
        }
    }
}
