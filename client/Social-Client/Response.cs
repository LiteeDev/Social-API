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
        public string username { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string lastLogin { get; set; }
        public string created { get; set; }
        public bool Authed { get; set; }
        public string error { get; set; }
    }
}
