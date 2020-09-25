# Social - API

Sometimes it's useful to have different levels of headings to structure your documents. Start lines with a `#` to create headings. Multiple `##` in a row denote smaller heading sizes.

Link: https://social.api.cryptx.me/v1/

### /v1/login/client [POST] [Desktop API Call]

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

Error Responses:
1. invalid api call parameters: login/client
2. invalid api key for api call
3. API call failed: malicous string
4. Login failed: Invalid username
5. Login failed: Invalid username or password


### /v1/register/client [POST] [Desktop API Call]

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

Error Responses:
1. Register failed: username/email already exists
2. Register failed: Invalid email format
3. API call failed: malicous string
4. Login failed: Invalid username
5. invalid api call parameters: register/client


