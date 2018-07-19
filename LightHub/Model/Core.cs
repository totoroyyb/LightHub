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
        private static IReadOnlyList<Octokit.User> allCurrentUserFollowers;
        private static IReadOnlyList<Octokit.User> allCurrentUserFollowings;

        public static void SetClientCredential(User user)
        {
            client.Credentials = new Credentials(user.accessToken);
        }

        public static void SetClientCredentialPersonalToken()
        {
            client.Credentials = new Credentials("");
        }

        public async static Task<Octokit.User> GetUserProfile()
        {
            userProfile = await client.User.Current();
            return userProfile;
        }

        public async static Task<IReadOnlyList<Activity>> GetAllCurrentUserPerformedEvents(Pagination pagination = null)
        {
            if (pagination != null)
            {
                allCurrentUserPerformedEvents = await client.Activity.Events.GetAllUserPerformed(userProfile.Login, pagination.apiOptions);
            }
            else
            {
                allCurrentUserPerformedEvents = await client.Activity.Events.GetAllUserPerformed(userProfile.Login);
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
    }
}
