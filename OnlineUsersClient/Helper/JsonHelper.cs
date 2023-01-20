using Newtonsoft.Json;
using OnlineUsersClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUsersClient.Helper
{
    public class JsonHelper
    {
        public static string GetJsonStringOfClass(Message msg)
        {
            var serialized = JsonConvert.SerializeObject(msg);
            return serialized;
        }
    }
}
