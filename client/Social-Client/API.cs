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
            //System.Windows.Forms.MessageBox.Show(API.API_LINK + "auth/register/client");
            string base64username = Utilities.Base64UrlEncode(username);
            string base64password = Utilities.Base64UrlEncode(password);
            string HWID = Utilities.Base64UrlEncode(Utilities.getHWID());
            Request Login = new Request(
                    API.API_LINK + "auth/login/client",
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
                  API.API_LINK + "auth/register/client",
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

        /*
           Function: LoginHistory(DataGridView dataBox):
           Response: none; Auto updates DataGridView.
       */
        public static void LoginHistory(DataGridView dataBox)
        {
            string HWID = Utilities.Base64UrlEncode(Utilities.getHWID());
            Request History = new Request(
                  API.API_LINK + "account/loginhistory/client",
                  "POST",
                  "userId=" + API.User.userId + "&hwid=" + HWID
            );
            Json myDeserializedClass = JsonConvert.DeserializeObject<Json>(History.GetResponse());
            dataBox.DataSource = myDeserializedClass.Logs;
        }

        /*
            Function: AddFriend(DataGridView dataBox):
            Response: none; Auto updates DataGridView.
        */
        public static Boolean AddFriend(string friendId)
        {
            //System.Windows.Forms.MessageBox.Show(API.API_LINK + "auth/register/client");
            string base64friendId = Utilities.Base64UrlEncode(friendId);
            string base64userId = Utilities.Base64UrlEncode(API.User.userId);
            string HWID = Utilities.Base64UrlEncode(Utilities.getHWID());
            Request Login = new Request(
                    API.API_LINK + "friends/add/client",
                    "POST",
                    "friendId=" + base64friendId + "&userId=" + base64userId + "&hwid=" + HWID
             );
            Status Status = JsonConvert.DeserializeObject<Status>(Login.GetResponse());
            if (Status.result)
            {
                MessageBox.Show("Friend Failed: " + Status.message);
                return true;
            }
            else
            {
                MessageBox.Show("Friend Failed: " + Status.message);
                return false;
            }
        }

        /*
           Function: LoginHistory(DataGridView dataBox):
           Response: none; Auto updates DataGridView.
       */
        public static void Friends(DataGridView dataBox)
        {
            MessageBox.Show("friends call was prompted");
            string base64userid = Utilities.Base64UrlEncode(API.User.userId);
            string HWID = Utilities.Base64UrlEncode(Utilities.getHWID());
            Request FriendsList = new Request(
                  API.API_LINK + "friends/list/client",
                  "POST",
                  "userId=" + base64userid + "&hwid=" + HWID
            );
            //MessageBox.Show(FriendsList.GetResponse().ToString());
            Json myDeserializedClass = JsonConvert.DeserializeObject<Json>(FriendsList.GetResponse());
            dataBox.DataSource = myDeserializedClass.FriendList;
        }
    }
}
