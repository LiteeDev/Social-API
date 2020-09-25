# Social - API

Sometimes it's useful to have different levels of headings to structure your documents. Start lines with a `#` to create headings. Multiple `##` in a row denote smaller heading sizes.

Link: https://social.api.cryptx.me/v1/

### /v1/auth/login/client [POST] [Desktop API Call]

Fields | Data
------------ | -------------
username | Client Login Username
password | Client Login Password
password | Client HWID 
auth_key | MD5(date(d-m-yyyy))

Success Response:

```json
{
	"ID": "17",
	"username": "LiteDev",
	"email": "office@litespeed.me",
	"role":"1",
	"lastLogin":"1601020013",
	"created":"1601018146",
	"Authed":true
}
```

```cs
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
```

Error Responses:
1. invalid api call parameters: login/client
2. invalid api key for api call
3. API call failed: malicous string
4. Login failed: Invalid username
5. Login failed: Invalid username or password


### /v1/auth/register/client [POST] [Desktop API Call]

Fields | Data
------------ | -------------
username | Client Register Username
password | Client Register Password
email | Client Register Email
hwid | Client HWID 
auth_key | MD5(date(d-m-yyyy))

Success Response:

```json
{
	"result": true,
	"message": "account created",
}
```

```cs
string base64username = Utilities.Base64UrlEncode(username);
string base64password = Utilities.Base64UrlEncode(password);
string base64email = Utilities.Base64UrlEncode(email);
string HWID = Utilities.Base64UrlEncode(Utilities.getHWID());
Request Register = new Request(
	API.API_LINK + "register/client", # URI
	"POST", # Request Type
	"username=" + base64username + "&password=" + base64password + "&email=" + base64email + "&hwid=" + HWID
);
Status Status = JsonConvert.DeserializeObject < Status > (Register.GetResponse());

if (Status.result) {
  // TODO: Close this register form;
  MessageBox.Show("Account Created");
  return true;
}
else {
  MessageBox.Show("Create Account Failed: " + Status.message);
  return false;
}
```

Error Responses:
1. Register failed: username/email already exists
2. Register failed: Invalid email format
3. API call failed: malicous string
4. Login failed: Invalid username
5. invalid api call parameters: register/client



### /v1/account/loginhistory/client [POST] [Desktop API Call]

Fields | Data
------------ | -------------
userId | API.User.userId
hwid | HWID Id;
auth_key | MD5(date(d-m-yyyy))

Success Response:

```json
[
    {
        "ID": "",
        "country": "GB",
        "ip_address": "88.110.236.183",
        "useragent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36",
        "status": "1",
        "timestamp": "1601026647"
    },
    {
        "ID": "",
        "country": "GB",
        "ip_address": "88.110.236.183",
        "useragent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36",
        "status": "1",
        "timestamp": "1601026698"
    },
    {
        "ID": "",
        "country": "GB",
        "ip_address": "88.110.236.183",
        "useragent": "client",
        "status": "1",
        "timestamp": "1601026884"
    }
]
```

Error Responses:
1. invalid user id: please restart application
2. invalid api security key:
3. invalid api call parameters: loginhistory/client



### Security Based Extras

Idea | POC | Completed
------------ | ------------- | -------------
User-Agent | A dynamic list of User-Agents that API can check and validate if this request was made by an Authorized Application | :no_smoking:
Auth-Key | A key which is dynamic of the date value ("d-m-yyyy") encoded with MD5 and sent with each HTTP Request | :chart:
Hardware Unique Identifer | A key which is  set by the value of the client using the Mobo, Hard Drive and CPU Serial encoded with MD5 and sent with each HTTP Request (Optional Option for each user) | :no_smoking:


