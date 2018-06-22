using LightHub.Constant;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHub.Model
{
    public class Core
    {
        public static GitHubClient client = new GitHubClient(new ProductHeaderValue(Const.productHeader));
        public static Octokit.User userProfile;
        public static IReadOnlyList<Activity> events;

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
            userProfile = await Core.client.User.Current();
            return userProfile;
        }

        public async static Task<IReadOnlyList<Activity>> GetEvents()
        {
            events = await Core.client.Activity.Events.GetAllUserReceivedPublic(userProfile.Login);
            return events;
        }
    }
}
