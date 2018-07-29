using LightHub.Model;
using Microsoft.Toolkit.Uwp;
using Octokit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static LightHub.Model.IncrementalLoadSource;

namespace LightHub.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        private ObservableCollection<Activity> _allCurrentUserReceivedEvents;
        public ObservableCollection<Activity> allCurrentUserReceivedEvents
        {
            get { return _allCurrentUserReceivedEvents; }
            set { SetProperty(ref _allCurrentUserReceivedEvents, value); }
        }

        public ICommand toUserDetailCommand { get; set; }

        public NewsPageViewModel()
        {
            toUserDetailCommand = new NaviToUserDetail();
        }

        public void LoadAllCurrentUserReceivedEvents()
        {
            allCurrentUserReceivedEvents = new IncrementalLoadingCollection<CurrentUserReceivedActivitySource, Activity>();
        }
    }
}
