# Social - API

Sometimes it's useful to have different levels of headings to structure your documents. Start lines with a `#` to create headings. Multiple `##` in a row denote smaller heading sizes.

### /API/Login [POST]

Fields | Data
------------ | -------------
username | Client Login Username
password | Client Login Password
auth_key1 | MD5(date(d-m-yyyy))
client | MD5("client//web")

Success Response:

```json
{
  "result": [{
    "status": "true",
    "loginAttempt": time(),
    "user": {
      "username": username,
      "email": email,
      "hwid": hwid,
      "lastLogin": "2015-05-22T14:56:28.000Z"
    }
  }]
}
```
