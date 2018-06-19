using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LightHub.Constant.Enumeration;

namespace LightHub.Model
{
    public class User
    {
        private AuthenType authenType { get; set; }
        private string accessToken { get; set; }
        private string userName { get; set; }
        private string userPassword { get; set; }

        public User(string accessToken)
        {
            authenType = AuthenType.oathen;
            this.accessToken = accessToken;
        }

        public User(string userName, string userPassword)
        {
            authenType = AuthenType.basic;
            this.userName = userName;
            this.userPassword = userPassword;
        }

        public void UpdateAccessToken(string newToken)
        {
            accessToken = newToken;
        }

        public void UpdatePassword(string newName, string newPassword)
        {
            userName = newName;
            userPassword = newPassword;
        }

        public string GetAccessToken()
        {
            return accessToken;
        }
    }
}
