using LightHub.Constant;
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

        public async static Task<IReadOnlyList<Activity>> GetAllCurrentUserPerformedEvents()
        {
            allCurrentUserPerformedEvents = await client.Activity.Events.GetAllUserPerformed(userProfile.Login);
            return allCurrentUserPerformedEvents;
        }

        public async static Task<IReadOnlyList<Activity>> GetAllUserPerformedEvents(string userLogin)
        {
            allUserPerformedEvents = await client.Activity.Events.GetAllUserPerformed(userLogin);
            return allUserPerformedEvents;
        }
    }
}
