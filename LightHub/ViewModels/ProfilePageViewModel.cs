using LightHub.Model;
using LightHub.Formatter;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Octokit;
using Microsoft.Toolkit.Uwp;
using static LightHub.Model.IncrementalLoadSource;
using System.Windows.Input;

namespace LightHub.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
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

        public ICommand toUserDetailCommand { get; set; }

        public ProfilePageViewModel()
        {
            toUserDetailCommand = new NaviToUserDetail();
        }

        public async Task LoadAllUserProfile()
        {
            userProfile = await Core.GetUserProfile();
            formattedEmailStr = EmailUriFormatter.GetFormattedEmailStr(userProfile.Email);
        }

        public void LoadAllCurrentUserPerformedEvents()
        {
            allCurrentUserPerformedEvents = new IncrementalLoadingCollection<CurrentUserPerformedActivitySource, Activity>();
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
