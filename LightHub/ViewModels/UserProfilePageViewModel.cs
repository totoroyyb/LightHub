using LightHub.Formatter;
using LightHub.Model;
using Microsoft.Toolkit.Uwp;
using Octokit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LightHub.Model.IncrementalLoadSource;

namespace LightHub.ViewModels
{
    public class UserProfilePageViewModel : ViewModelBase
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

        private ObservableCollection<Activity> _allUserPerformedEvents = new ObservableCollection<Activity>();
        public ObservableCollection<Activity> allUserPerformedEvents
        {
            get { return _allUserPerformedEvents; }
            set { SetProperty(ref _allUserPerformedEvents, value); }
        }

        private ObservableCollection<Octokit.User> _allUserFollowers = new ObservableCollection<Octokit.User>();
        public ObservableCollection<Octokit.User> allUserFollowers
        {
            get { return _allUserFollowers; }
            set { SetProperty(ref _allUserFollowers, value); }
        }

        private ObservableCollection<Octokit.User> _allUserFollowings = new ObservableCollection<Octokit.User>();
        public ObservableCollection<Octokit.User> allUserFollowings
        {
            get { return _allUserFollowings; }
            set { SetProperty(ref _allUserFollowings, value); }
        }

        public async void LoadUserProfile(Octokit.User user = null)
        {
            if (user != null)
            {
                avatarStr = user.AvatarUrl;
                loginStr = user.Login;
                Octokit.User userProfile = await Core.GetUserProfile(user.Login);
                fullNameStr = userProfile.Name;
                bioStr = userProfile.Bio;
                webLinkStr = userProfile.Blog;
                emailLinkStr = userProfile.Email;
                formattedEmailStr = EmailUriFormatter.GetFormattedEmailStr(emailLinkStr);
                allUserPerformedEvents = new IncrementalLoadingCollection<UserPerformedActivitySource, Activity>();
            }
        }

        public void LoadAllUserPerformedEvents()
        {
            allUserPerformedEvents = new IncrementalLoadingCollection<UserPerformedActivitySource, Activity>();
        }
    }
}
