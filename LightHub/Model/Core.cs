using LightHub.Constant;
using LightHub.Helper;
using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightHub.Model
{
    public class Core
    {
        public static GitHubClient client = new GitHubClient(new ProductHeaderValue(Const.productHeader));
        private static Octokit.User userProfile;

        private static IReadOnlyList<Activity> allCurrentUserPerformedEvents;
        private static IReadOnlyList<Activity> allUserPerformedEvents;
        private static IReadOnlyList<Activity> allCurrentUserReceivedEvents;

        private static IReadOnlyList<Octokit.User> allCurrentUserFollowers;
        private static IReadOnlyList<Octokit.User> allCurrentUserFollowings;
        
        private static Feed allFeedsForCurrent;

        public static void SetClientCredential(User user)
        {
            client.Credentials = new Credentials(user.accessToken);
        }

        public static void SetClientCredentialPersonalToken()
        {
            client.Credentials = new Credentials("");
        }

        public async static Task<Octokit.User> GetUserProfile(string login = null)
        {
            if (login == null)
            {
                userProfile = await client.User.Current();
                return userProfile;
            }
            else
            {
                return await client.User.Get(login);
            }
            
        }

        public static Octokit.User RetrieveUserProfile()
        {
            return userProfile;
        }

        public static bool isUserProfileValid()
        {
            return (userProfile != null) ? true : false;
        }

        public async static Task<IReadOnlyList<Activity>> GetAllCurrentUserPerformedEvents(Pagination pagination = null)
        {
            if (pagination != null)
            {
                allCurrentUserPerformedEvents = await client.Activity.Events.GetAllUserPerformed(userProfile?.Login, pagination.apiOptions);
            }
            else
            {
                allCurrentUserPerformedEvents = await client.Activity.Events.GetAllUserPerformed(userProfile?.Login);
            }
            return allCurrentUserPerformedEvents;
        }

        public async static Task<IReadOnlyList<Activity>> GetAllUserPerformedEvents(string userLogin, Pagination pagination = null)
        {
            if (pagination != null)
            {
                allUserPerformedEvents = await client.Activity.Events.GetAllUserPerformed(userLogin, pagination.apiOptions);
            }
            else
            {
                allUserPerformedEvents = await client.Activity.Events.GetAllUserPerformed(userLogin);
            }
            return allUserPerformedEvents;
        }

        public async static Task<IReadOnlyList<Activity>> GetAllCurrentReceivedEvents(Pagination pagination = null)
        {
            if (pagination != null)
            {
                allCurrentUserReceivedEvents = await client.Activity.Events.GetAllUserReceived(userProfile?.Login, pagination.apiOptions);
            }
            else
            {
                allCurrentUserReceivedEvents = await client.Activity.Events.GetAllUserReceived(userProfile?.Login);
            }
            return allCurrentUserReceivedEvents;
        }

        public async static Task<IReadOnlyList<Octokit.User>> GetAllFollowersOfCurrent(Pagination pagination = null)
        {
            if (pagination != null)
            {
                allCurrentUserFollowers = await client.User.Followers.GetAllForCurrent(pagination.apiOptions);
            }
            else
            {
                allCurrentUserFollowers = await client.User.Followers.GetAllForCurrent();
            }
            return allCurrentUserFollowers;
        }

        public async static Task<IReadOnlyList<Octokit.User>> GetAllFollowingsOfCurrent(Pagination pagination = null)
        {
            if (pagination != null)
            {
                allCurrentUserFollowings = await client.User.Followers.GetAllFollowingForCurrent(pagination.apiOptions);
            }
            else
            {
                allCurrentUserFollowings = await client.User.Followers.GetAllFollowingForCurrent();
            }
            return allCurrentUserFollowings;
        }

        public async static Task<Feed> GetAllFeedsOfCurrent()
        {
            allFeedsForCurrent = await client.Activity.Feeds.GetFeeds();
            return allFeedsForCurrent;
        }
    }
}
