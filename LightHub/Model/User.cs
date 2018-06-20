using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LightHub.Constant.Enumeration;
using Newtonsoft.Json;

namespace LightHub.Model
{
    
    public class User
    {
        public AuthenType authenType { get; set; }
        public string accessToken { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

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
    }
}
