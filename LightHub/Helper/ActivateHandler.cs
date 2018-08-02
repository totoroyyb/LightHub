using LightHub.Constant;
using LightHub.Model;
using System.Threading.Tasks;

namespace LightHub.Helper
{
    public class ActivateHandler
    {
        //Return 0 means generate and store the access token successfully
        //Return -1 means somethings go wrong
        public async static Task<int> HandleUriLaunch(string uriStr)
        {
            string strWithoutPrefix = uriStr.Remove(0, Const.callBackPrefix.Length);
            if (!string.IsNullOrEmpty(strWithoutPrefix))
            {
                int index = strWithoutPrefix.IndexOf('/');
                if (index > 0)
                {
                    string commandStr = strWithoutPrefix.Remove(index);
                    if (!string.IsNullOrEmpty(commandStr))
                    {
                        await RunUriLanuchCommandAsync(commandStr, strWithoutPrefix);
                        return 0;
                    }
                }
            }
            return -1;
        }

        private static async Task RunUriLanuchCommandAsync(string commandStr, string strWithoutPrefix)
        {
            switch (commandStr)
            {
                case Const.loginCommand:
                    string token = await UserAccounts.GenerateToken(UserAccounts.GetTokenCodeStr(strWithoutPrefix));
                    UserAccounts.userAccountsList.Add(new User(token));

                    Settings.WriteUserAccountsSetting();
                    break;
            }
        }
    }
}
