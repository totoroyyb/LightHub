﻿using LightHub.Constant;
using Octokit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightHub.Model
{
    public class UserAccounts
    {
        public static List<User> userAccountsList = new List<User>();

        public static void AddUserAccount(User user)
        {
            userAccountsList.Add(user);
        }

        public async static void LaunchUri(Uri oauthenUri)
        {
            var success = await Windows.System.Launcher.LaunchUriAsync(oauthenUri);

            if (success)
            {
                
            }
            else
            {
                // URI launch failed
            }
        }

        public static void CreateOauthenUri()
        {
            var request = new OauthLoginRequest(Const.clientId)
            {
                Scopes = { "user", "notifications" },
            };

            var oauthLoginUrl = Core.client.Oauth.GetGitHubLoginUrl(request);

            LaunchUri(oauthLoginUrl);
        }

        public async static Task<string> GenerateToken(string code)
        {
            var request = new OauthTokenRequest(Const.clientId, Const.clientSecret, code);
            var token = await Core.client.Oauth.CreateAccessToken(request);
            return token.AccessToken;
        }

        public static string GetTokenCodeStr(string fullStr)
        {
            string codeStr = "code=";
            return fullStr.Substring(fullStr.IndexOf(codeStr) + codeStr.Length);
        }
    }
}
