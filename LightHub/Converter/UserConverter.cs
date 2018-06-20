using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LightHub.Model;

namespace LightHub.Converter
{
    public class UserConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(LightHub.Model.User));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            int authenType = (int)jo["authenType"];
            if (authenType == 1)
            {
                return new User((string)jo["accessToken"]);
            }
            else
            {
                return new User((string)jo["userName"], (string)jo["userPassword"]);
            } 
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
