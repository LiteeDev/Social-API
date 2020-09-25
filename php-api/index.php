<?php
/* Loader Class */
require_once 'classes/loader.php';

/*

  /account/update/:
    First Name
    Last Name,
    Email,

  /account/loginhistory/:
   json call back with all the loginhistory;

  Friends;
    Add;
    Delete;
    List;


*/

$Router->with('/v1', function ($request) use ($Router)
{

    /*
          Authentication Calls;
          Login:
          Register:
    */
    $Router->with('/auth', function ($request) use ($Router)
    {

        /* Login */
        $Router->respond('POST', '/login/[:method]', function ($request, $response)
        {
            // Desktop Authentication
            if ($request->method == 'client')
            {
                if (isset($_POST['username']) && isset($_POST['password']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
                {
                    // Decode Base64
                    $decodedUsername = Encryption::base64urldecode($_POST['username']);
                    $decodedPassword = Encryption::base64urldecode($_POST['password']);
                    $decodedHWID = Encryption::base64urldecode($_POST['hwid']);
                    $auth_key_correct = md5(date("d-m-Y"));

                    if ($auth_key_correct == strtolower($_SERVER['HTTP_AUTHKEY']))
                    {
                        // Validate string;
                        if (!API::SafeString($decodedUsername) && !API::SafeString($decodedPassword) && !API::SafeString($decodedHWID))
                        {
                            if (API::checkUsername($decodedUsername))
                            {
                                $User = API::User($decodedUsername);
                                $decodedUserId = Encryption::decryptURI($User['userId'], USER_SALT);
                                if (API::Login($decodedUsername, $decodedPassword))
                                {
                                    // Get User Information.
                                    Log::Login($decodedUserId, 1);
                                    API::updateLastLogin($decodedUserId);
                                    echo json_encode($User);
                                }
                                else
                                {
                                    Log::Login($decodedUserId, 0);
                                    echo json_encode(array(
                                        "result" => false,
                                        "error" => "Login failed: Invalid username or password"
                                    ));
                                }
                            }
                            else
                            {
                                echo json_encode(array(
                                    "result" => false,
                                    "error" => "Login failed: Invalid username"
                                ));
                            }
                        }
                        else
                        {
                            echo json_encode(array(
                                "result" => false,
                                "error" => "API call failed: malicous string"
                            ));
                        }
                    }
                    else
                    {
                        echo json_encode(array(
                            "result" => false,
                            "error" => "invalid api key for api call"
                        ));
                    }
                }
                else
                {
                    echo json_encode(array(
                        "result" => false,
                        "error" => "invalid api call parameters: login/client"
                    ));
                }
            }

            // Website Authentication
            elseif ($request->method == 'web')
            {
                echo json_encode(array(
                    "result" => false,
                    "error" => "web"
                ));
            }

            // No Method Found
            else
            {
                echo json_encode(array(
                    "result" => false,
                    "error" => "method was not found"
                ));
            }
        });

        /* Register */
        $Router->respond('POST', '/register/[:method]', function ($request, $response)
        {

            // Desktop Authentication
            if ($request->method == 'client')
            {
                if (isset($_POST['username']) && isset($_POST['email']) && isset($_POST['password']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
                {
                    // Validate string;
                    $decodedUsername = Encryption::base64urldecode($_POST['username']);
                    $decodedEmail = Encryption::base64urldecode($_POST['email']);
                    $decodedPassword = Encryption::base64urldecode($_POST['password']);
                    $decodedHWID = Encryption::base64urldecode($_POST['hwid']);
                    $auth_key_correct = md5(date("d-m-Y"));

                    if ($auth_key_correct == strtolower($_SERVER['HTTP_AUTHKEY']))
                    {
                        //die($_POST['email']);
                        if (!API::SafeString($decodedUsername) && !API::SafeString($decodedEmail) && !API::SafeString($decodedPassword) && !API::SafeString($decodedHWID))
                        {
                            // Validate Email
                            if (filter_var($decodedEmail, FILTER_VALIDATE_EMAIL))
                            {
                                //die(API::checkUsername($_POST['username']));
                                if (!API::checkUsername($decodedUsername) && !API::checkEmail($decodedEmail))
                                {
                                    if (API::Register($decodedUsername, $decodedEmail, $decodedPassword))
                                    {
                                        // Get User Information.
                                        die(json_encode(array(
                                            "result" => true,
                                            "message" => "account created"
                                        )));
                                    }
                                }
                                else
                                {
                                    die(json_encode(array(
                                        "result" => false,
                                        "message" => "Register failed: username/email already exists"
                                    )));
                                }
                            }
                            else
                            {
                                die(json_encode(array(
                                    "result" => false,
                                    "message" => "Register failed: Invalid email format"
                                )));
                            }
                        }
                        else
                        {
                            die(json_encode(array(
                                "result" => false,
                                "message" => "API call failed: malicous string"
                            )));
                        }
                    }
                    else
                    {
                        die(json_encode(array(
                            "result" => false,
                            "message" => "invalid api key for api call"
                        )));
                    }
                }
                else
                {
                    die(json_encode(array(
                        "result" => false,
                        "message" => "invalid api call parameters: register/client"
                    )));
                }
            }

            // Website Authentication
            elseif ($request->method == 'web')
            {
                echo json_encode(array(
                    "result" => false,
                    "error" => "web"
                ));
            }

            // No Method Found
            else
            {
                echo json_encode(array(
                    "result" => false,
                    "error" => "method was not found"
                ));
            }

        });

    });

    /*
          Account Calls;
          Update:
          LoginHistory:
    */
    $Router->with('/account', function ($request) use ($Router)
    {

        /* /account/update */
        $Router->respond('POST', '/update/[:method]', function ($request, $response)
        {

            // Desktop Authentication
            if ($request->method == 'client')
            {
                if (isset($_POST['userId']) && isset($_POST['username']) && isset($_POST['email']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
                {

                }
                else
                {
                    die(json_encode(array(
                        "result" => false,
                        "message" => "invalid api call parameters: register/client"
                    )));
                }
            }
            // No Method;
            else
            {
                die(json_encode(array(
                    "result" => false,
                    "message" => "no method found"
                )));
            }

        });

        /* /account/loginhistory */
        $Router->respond('POST', '/loginhistory/[:method]', function ($request, $response)
        {
            header('Content-Type: application/json');
            // Desktop Authentication
            if ($request->method == 'client')
            {
                if (isset($_POST['userId']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
                {
                    $auth_key_correct = md5(date("d-m-Y"));
                    $userId = $_POST['userId'];

                    if ($auth_key_correct == strtolower($_SERVER['HTTP_AUTHKEY']))
                    {

                        // Decode the userID;
                        $decodedUserId = Encryption::decryptURI($userId, USER_SALT);

                        // Check the userId;
                        if (is_numeric($decodedUserId) && API::checkUserID($decodedUserId))
                        {
                            die(json_encode(API::LoginHistory($decodedUserId) , JSON_PRETTY_PRINT));
                        }
                        else
                        {
                            die(json_encode(array(
                                "result" => false,
                                "message" => "invalid user id: please restart application"
                            )));
                        }

                    }
                    else
                    {
                        die(json_encode(array(
                            "result" => false,
                            "message" => "invalid api security key:"
                        )));
                    }
                }
                else
                {
                    die(json_encode(array(
                        "result" => false,
                        "message" => "invalid api call parameters: loginhistory/client"
                    )));
                }
            }
            // No Method;
            else
            {
                die(json_encode(array(
                    "result" => false,
                    "message" => "no method found"
                )));
            }

        });

    });


    /*
          Account Calls;
          Update:
          LoginHistory:
    */
    $Router->with('/friends', function ($request) use ($Router)
    {

        /* /friends/add */
        $Router->respond('POST', '/add/[:method]', function ($request, $response)
        {

            // Desktop Authentication
            if ($request->method == 'client')
            {
                if (isset($_POST['friendId']) && isset($_POST['userId']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
                {

                  $base64DecodedUserId = Encryption::base64urldecode($_POST['userId']);
                  $base64DecodedFriendId = Encryption::base64urldecode($_POST['friendId']);

                  $decodedUserId = Encryption::decryptURI($base64DecodedFriendId, USER_SALT);
                  $decodedFriendId = Encryption::decryptURI($base64DecodedUserId, USER_SALT);

                  if(
                    is_numeric($decodedUserId) && API::checkUserID($decodedUserId) &&
                    is_numeric($decodedFriendId) && API::checkUserID($decodedFriendId))
                    {

                      if($decodedFriendId != $decodedUserId)
                      {
                        // Check if they're pending requests against the same userId;
                        if(!Client::checkFriendRequest($decodedUserId, $decodedFriendId))
                        {
                          Client::sendFriendRequest($decodedUserId, $decodedFriendId);
                          die(json_encode(array(
                              "result" => true,
                              "message" => $decodedUserId . " _ ".  $decodedFriendId
                          )));
                        }
                        else{
                          die(json_encode(array(
                              "result" => false,
                              "message" => "pending request already exists"
                          )));
                        }
                      }
                      else {
                        die(json_encode(array(
                            "result" => false,
                            "message" => "friend & userid cannot match"
                        )));
                      }
                    }
                    else{
                      die(json_encode(array(
                          "result" => false,
                          "message" => "friend or userid was invalid"
                      )));
                    }

                }
                else
                {
                    die(json_encode(array(
                        "result" => false,
                        "message" => "invalid api call parameters: register/client"
                    )));
                }
            }
            // No Method;
            else
            {
                die(json_encode(array(
                    "result" => false,
                    "message" => "no method found"
                )));
            }

        });

        /* /friends/delete */
        $Router->respond('POST', '/delete/[:method]', function ($request, $response)
        {

            // Desktop Authentication
            if ($request->method == 'client')
            {
                if (isset($_POST['friendId']) && isset($_POST['userId']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
                {

                }
                else
                {
                    die(json_encode(array(
                        "result" => false,
                        "message" => "invalid api call parameters: register/client"
                    )));
                }
            }
            // No Method;
            else
            {
                die(json_encode(array(
                    "result" => false,
                    "message" => "no method found"
                )));
            }

        });

        /* /friends/list */
        $Router->respond('POST', '/list/[:method]', function ($request, $response)
        {
          header('Content-Type: application/json');
            // Desktop Authentication
            if ($request->method == 'client')
            {
                if (isset($_POST['userId']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
                {

                      $base64DecodedUserId = Encryption::base64urldecode($_POST['userId']);
                      $decodedUserId = Encryption::decryptURI($base64DecodedUserId, USER_SALT);
                      if(is_numeric($decodedUserId) && API::checkUserID($decodedUserId))
                      {

                          die(json_encode(Client::Friends($decodedUserId),  JSON_PRETTY_PRINT));
                      }
                      else {
                          die(json_encode(array(
                              "result" => false,
                              "message" => "invalid userID call."
                          )));
                      }

                }
                else
                {
                    die(json_encode(array(
                        "result" => false,
                        "message" => "invalid api call parameters: register/client"
                    )));
                }
            }
            // No Method;
            else
            {
                die(json_encode(array(
                    "result" => false,
                    "message" => "no method found"
                )));
            }

        });
    });

});

/* Error Handler */
$Router->onHttpError(function ($code, $router)
{
    switch ($code)
    {
        case 404:
            $router->response()
                ->body('This page does not exist');
        break;
        case 405:
            $router->response()
                ->body('You can\'t do that!');
        break;
        default:
            $router->response()
                ->body('Oh no, a bad error happened that caused a ' . $code);
    }
});

/* Dispatch Code */
$Router->dispatch();

?>
