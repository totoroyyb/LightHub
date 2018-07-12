using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHub.Constant
{
    public class Const
    {
        #region General Constant String
        public const string productHeader = "LightHub";
        public const string clientId = "eb76d235c90a9ab2bee8";
        public const string clientSecret = "285e5945b0b0a3529b32f930fcc8bb6a55c38773";
        public const string callBackPrefix = "lighthub://";
        #endregion

        public const string loginCommand = "login";

        #region Settings File Name
        public const string userAccountsSettingName = "UserAccountsData";
        #endregion

        #region Navigation Constant String
        public const string NaviActivity = "activity";
        public const string NaviNotif = "notification";
        public const string NaviTrend = "trending";
        public const string NaviIssue = "issue";
        public const string NaviProfile = "profile";
        public const string NaviMyRepos = "myrepos";
        public const string NaviMyStarred = "mystarred";
        public const string NaviBookmarks = "bookmarks";
        #endregion

        #region Activity Type String
        public const string pushEvent = "PushEvent";
        public const string watchEvent = "WatchEvent";
        #endregion

    }
}
