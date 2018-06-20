using LightHub.Constant;
using LightHub.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHub.Model
{
    public class Settings
    {
        public static string Serialize2Json(List<User> userAccountsList)
        {
            return JsonConvert.SerializeObject(userAccountsList, Formatting.Indented);
        }

        public static T DeserializeFromJson<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr, new UserConverter());
        }

        public static void WriteSettings(string settingName, string jsonStr)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values[settingName] = jsonStr;
        }

        public static string ReadSettings(string settingName)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object value = localSettings.Values[settingName];
            if (value != null)
            {
                return (string)value;
            }
            return null;
        }

        public static void WriteUserAccountsSetting()
        {
            WriteSettings(Const.userAccountsSettingName, Serialize2Json(UserAccounts.userAccountsList));
        }

        public static void ReadUserAccountsSetting()
        {
            string jsonStr = ReadSettings(Const.userAccountsSettingName);
            if (jsonStr != null)
            {
                UserAccounts.userAccountsList = DeserializeFromJson<List<User>>(jsonStr);
            }
        }
    }
}
