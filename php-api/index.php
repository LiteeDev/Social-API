<?php

  /* Loader Class */
  require_once 'classes/loader.php';


  $Router->with('/v1', function($request) use ($Router)
  {

      /* Login */
      $Router->respond('POST', '/login/[:method]', function($request, $response)
      {
        // Desktop Authentication
        if($request->method == 'client')
        {
          if(isset($_POST['username']) && isset($_POST['password']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
          {
            // Decode Base64
            $decodedUsername = Encryption::base64urldecode($_POST['username']);
            $decodedPassword = Encryption::base64urldecode($_POST['password']);
            $decodedHWID =     Encryption::base64urldecode($_POST['hwid']);
            $auth_key_correct = md5(date("d-m-Y"));

                if($auth_key_correct == strtolower($_SERVER['HTTP_AUTHKEY']))
              {
                // Validate string;
                if(!API::SafeString($decodedUsername) && !API::SafeString($decodedPassword) && !API::SafeString($decodedHWID))
                {
                  if(API::checkUsername($decodedUsername))
                  {
                    if(API::Login($decodedUsername, $decodedPassword))
                    {
                      // Get User Information.
                      $User = API::User($decodedUsername);
                      API::updateLastLogin($User['ID']);
                      echo json_encode($User);
                    }
                    else {
                      echo json_encode(array("result" => false, "error" => "Login failed: Invalid username or password"));
                    }
                  }
                  else {
                    echo json_encode(array("result" => false, "error" => "Login failed: Invalid username"));
                  }
                }
                else {
                  echo json_encode(array("result" => false, "error" => "API call failed: malicous string"));
                }
              }
            else
            {
              echo json_encode(array("result" => false, "error" => "invalid api key for api call"));
            }
          }
          else{
            echo json_encode(array("result" => false, "error" => "invalid api call parameters: login/client"));
          }
        }


        // Website Authentication
        elseif($request->method == 'web')
        {
          echo json_encode(array("result" => false, "error" => "web"));
        }


        // No Method Found
        else
        {
          echo json_encode(array("result" => false, "error" => "method was not found"));
        }
      });


      /* Register */
      $Router->respond('POST', '/register/[:method]', function($request, $response)
      {

        // Desktop Authentication
        if($request->method == 'client')
        {
          if(isset($_POST['username']) && isset($_POST['email']) && isset($_POST['password']) && isset($_POST['hwid']) && isset($_SERVER['HTTP_AUTHKEY']))
          {
            // Validate string;
            $decodedUsername = Encryption::base64urldecode($_POST['username']);
            $decodedEmail = Encryption::base64urldecode($_POST['email']);
            $decodedPassword = Encryption::base64urldecode($_POST['password']);
            $decodedHWID =     Encryption::base64urldecode($_POST['hwid']);
            $auth_key_correct = md5(date("d-m-Y"));

              if($auth_key_correct == strtolower($_SERVER['HTTP_AUTHKEY']))
              {
                  //die($_POST['email']);
                  if(!API::SafeString($decodedUsername) && !API::SafeString($decodedEmail) && !API::SafeString($decodedPassword) && !API::SafeString($decodedHWID))
                  {
                    // Validate Email
                    if (filter_var($decodedEmail, FILTER_VALIDATE_EMAIL) )
                    {
                      //die(API::checkUsername($_POST['username']));
                      if(!API::checkUsername($decodedUsername) && !API::checkEmail($decodedEmail))
                      {
                        if(API::Register($decodedUsername, $decodedEmail, $decodedPassword ))
                        {
                          // Get User Information.
                          die(json_encode(array("result" => true, "message" => "account created")));
                        }
                      }
                      else {
                        die(json_encode(array("result" => false, "message" => "Register failed: username/email already exists")));
                      }
                    }
                    else {
                      die(json_encode(array("result" => false, "message" => "Login failed: Invalid email format")));
                    }
                  }
                  else {
                    die(json_encode(array("result" => false, "message" => "API call failed: malicous string")));
                  }
              }
              else {
                die(json_encode(array("result" => false, "message" => "invalid api key for api call")));
              }
          }
          else{
            die(json_encode(array("result" => false, "message" => "invalid api call parameters: login/client")));
          }
        }


        // Website Authentication
        elseif($request->method == 'web')
        {
          echo json_encode(array("result" => false, "error" => "web"));
        }


        // No Method Found
        else
        {
          echo json_encode(array("result" => false, "error" => "method was not found"));
        }


      });


});

  /* Error Handler */
  $Router->onHttpError(function ($code, $router) {
      switch ($code) {
          case 404:
              $router->response()->body(
                  'This page does not exist'
              );
              break;
          case 405:
              $router->response()->body(
                  'You can\'t do that!'
              );
              break;
          default:
              $router->response()->body(
                  'Oh no, a bad error happened that caused a '. $code
              );
      }
  });

  /* Dispatch Code */
  $Router->dispatch();

?>
