using LightHub.Formatter;
using LightHub.Model;
using Microsoft.Toolkit.Uwp;
using Octokit;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static LightHub.Model.IncrementalLoadSource;

namespace LightHub.ViewModels
{
    public class UserProfilePageViewModel : ViewModelBase
    {
        private Octokit.User _userProfile;
        public Octokit.User userProfile
        {
            get { return _userProfile; }
            set { SetProperty(ref _userProfile, value); }
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

        public async Task LoadUserProfile(Octokit.User user = null)
        {
            if (user != null)
            {
                userProfile = user;
                userProfile = await Core.GetUserProfile(userProfile.Login); 
                formattedEmailStr = EmailUriFormatter.GetFormattedEmailStr(userProfile.Email);
                LoadAllUserPerformedEvents(userProfile.Login);
                LoadAllUserFollowers(userProfile.Login);
                LoadAllUserFollowings(userProfile.Login);
            }
        }

        private void LoadAllUserPerformedEvents(string login)
        {
            UserPerformedActivitySource source = new UserPerformedActivitySource(login);
            allUserPerformedEvents = new IncrementalLoadingCollection<UserPerformedActivitySource, Activity>(source);
        }

        private void LoadAllUserFollowers(string login)
        {
            UserFollowersSource source = new UserFollowersSource(login);
            allUserFollowers = new IncrementalLoadingCollection<UserFollowersSource, Octokit.User>(source);
        }

        private void LoadAllUserFollowings(string login)
        {
            UserFollowingsSource source = new UserFollowingsSource(login);
            allUserFollowings = new IncrementalLoadingCollection<UserFollowingsSource, Octokit.User>(source);
        }
    }
}
