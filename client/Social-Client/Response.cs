using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Client
{
    public class Status
    {
        public bool result { get; set; }
        public string message { get; set; }
    }

    public class User
    {
        public string userId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string lastLogin { get; set; }
        public string created { get; set; }
        public bool Authed { get; set; }
        public string error { get; set; }
    }

    public class LGN
    {
        public string country { get; set; }
        public string ip_address { get; set; }
        public string useragent { get; set; }
        public string status { get; set; }
        public string timestamp { get; set; }
    }

    public class Friend
    {
        public string username { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    }

    public class Json
    {
        public List<LGN> Logs { get; set; }
        public List<Friend> FriendList { get; set; }
    }


}
