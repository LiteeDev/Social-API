using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Social_Client
{
    class API
    {

        public static User User;
        public static string API_LINK = "http://social.api.cryptx.me/v1/";

        /*
            Function: Login($username, $password):
            Response: boolean (true|false)
        */
        public static Boolean Login(string username, string password)
        {
            string base64username = Utilities.Base64UrlEncode(username);
            string base64password = Utilities.Base64UrlEncode(password);
            string HWID = Utilities.Base64UrlEncode(Utilities.getHWID());
            Request Login = new Request(
                    API.API_LINK + "login/client",
                    "POST",
                    "username=" + base64username + "&password=" + base64password + "&hwid=" + HWID
             );
            User = JsonConvert.DeserializeObject<User>(Login.GetResponse());
            if (User.Authed)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Login Account Failed: " + User.error);
                return false;
            }
        }

        /*
            Function: Register($username, $email, $password):
            Response: boolean (true|false)
        */
        public static Boolean Register(string username, string email, string password)
        {
            string base64username = Utilities.Base64UrlEncode(username);
            string base64password = Utilities.Base64UrlEncode(password);
            string base64email = Utilities.Base64UrlEncode(email);
            string HWID = Utilities.Base64UrlEncode(Utilities.getHWID());
            Request Register = new Request(
                  API.API_LINK + "register/client",
                  "POST",
                  "username=" + base64username + "&password=" + base64password + "&email=" + base64email + "&hwid=" + HWID
            );
            Status Status = JsonConvert.DeserializeObject<Status>(Register.GetResponse());

            if (Status.result)
            {
                // TODO: Close this register form;
                MessageBox.Show("Account Created");
                return true;
            }
            else
            {
                MessageBox.Show("Create Account Failed: " + Status.message);
                return false;
            }
        }
    }
}
