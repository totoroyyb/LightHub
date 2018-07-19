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
        public const string issuesEvent = "IssuesEvent";
        public const string issueCommentEvent = "IssueCommentEvent";
        public const string createEvent = "CreateEvent";
        public const string releaseEvent = "ReleaseEvent";
        public const string forkEvent = "ForkEvent";
        #endregion

        #region Issues Event Type String
        public const string assigned = "assigned";
        public const string unassigned = "unassigned";
        public const string labeled = "labeled";
        public const string unlabeled = "unlabeled";
        public const string opened = "opened";
        public const string edited = "edited";
        public const string milestoned = "milestoned";
        public const string demilestoned = "demilestoned";
        public const string closed = "closed";
        public const string reopened = "reopened";
        public const string created = "created";
        public const string deleted = "deleted";
        #endregion
    }
}