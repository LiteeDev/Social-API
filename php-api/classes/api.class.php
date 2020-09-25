<?php

  class API {

    /*
      Function: checkUsername($username):
      Response: boolean (true|false)
    */
    public static function checkUsername($username)
    {
      $Database = new DB();
      $checkUsername = $Database->PDO->prepare("SELECT COUNT(*) FROM `tbl_users` WHERE AES_DECRYPT(username, '" . DATABASE_SALT . "') = :username");
      $checkUsername->execute(array(
          ':username' => $username
      ));
      //die($checkUsername->fetchColumn(0));
      if ($checkUsername->fetchColumn(0) == 0) {
          return false;
      } else {
          return true;
      }
    }


    /*
      Function: checkEmail($email):
      Response: boolean (true|false)
    */
    public static function checkEmail($email)
    {
      $Database = new DB();
      $checkEmail = $Database->PDO->prepare("SELECT COUNT(*) FROM `tbl_users` WHERE AES_DECRYPT(email, '" . DATABASE_SALT . "') = :email");
      $checkEmail->execute(array(
          ':email' => $username
      ));
      //die($checkUsername->fetchColumn(0));
      if ($checkEmail->fetchColumn(0) == 0) {
          return false;
      } else {
          return true;
      }
    }


    /*
      Function: Login($username, $password):
      Response: boolean (true|false)
    */
    public static function Login($username, $password)
    {
      $Database = new DB();
      $checkAuth = $Database->PDO->prepare("SELECT AES_DECRYPT(password, '" . DATABASE_SALT . "') FROM `tbl_users` WHERE `username` = AES_ENCRYPT(:username, '" . DATABASE_SALT . "')");
      $checkAuth->execute(array(
        ':username' => $username,
      ));
      $passwordHash = $checkAuth->fetchColumn(0);
      if (password_verify($password, $passwordHash)) {
        return true;
      } else {
        return false;
      }
    }


    /*
      Function: updateLastLogin($userId)
      Response: boolean (true|false)
    */
    public static function updateLastLogin($userId)
    {
      $Database = new DB();
      $updateLastLogin = $Database->PDO->prepare("UPDATE `tbl_users` SET `lastLogin` = AES_ENCRYPT(UNIX_TIMESTAMP(), '" . DATABASE_SALT . "') WHERE `ID` = :userId");
      $updateLastLogin->execute(array(
            ':userId' => $userId
      ));
      return true;
    }


    /*
      Function: Register($username, $email, $password):
      Response: boolean (true|false)
    */
    public static function Register($username, $email, $password)
    {
      $Database = new DB();
      $encryptedPassword = password_hash($password, PASSWORD_ARGON2ID);
      $MultiFactor = new MultiFactor();
      $secret = $MultiFactor->createSecret();
      $Insert     = $Database->PDO->prepare("INSERT INTO `tbl_users` VALUES(
        NULL,
        AES_ENCRYPT(:username, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(:password, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(:email, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(1, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(UNIX_TIMESTAMP(), '" . DATABASE_SALT . "'),
        AES_ENCRYPT(UNIX_TIMESTAMP(), '" . DATABASE_SALT . "'))
        ");
        $Insert->execute(array(
            ':username' => $username,
            ':password' => $encryptedPassword,
            ':email' => $email,
        ));
      return true;
    }

    /*
      Function: User($username):
      Response:
      array("result" => true, "data" => array(
        "username" => "test",
        "email" => "test@gmail.com",
        "hwid" => "hwid",
        "lastLogin" => time(),
      )
    */
    public static function User($username)
    {
        $Database         = new DB();
        $grabApplications = $Database->PDO->query("SELECT ID AS ID,
        AES_DECRYPT(username, '" . DATABASE_SALT . "') AS username,
        AES_DECRYPT(email, '" . DATABASE_SALT . "') AS email,
        AES_DECRYPT(role, '" . DATABASE_SALT . "') AS role,
        AES_DECRYPT(lastLogin, '" . DATABASE_SALT . "') AS lastLogin,
        AES_DECRYPT(created, '" . DATABASE_SALT . "') AS created FROM `tbl_users` WHERE `username` = AES_ENCRYPT('$username', '" . DATABASE_SALT . "')");
        while ($UserInfo = $grabApplications->fetch(PDO::FETCH_ASSOC)) {
            $UserInfo['Authed'] = true;
            return $UserInfo;
        }
    }


    /*
      Function: SafeString($string):
      Response: boolean (true|false)
    */
    public static function SafeString($response)
    {
      $upper_string = strtoupper($response);
      $parameters = array("<SCRIPT", "ALERT(", "<IFRAMW", ".CCS", ".JS", "<META", "<FRAME", "<EMBED", "<XML", "<IMG");
      foreach ($parameters as $parameter){
        if (strpos($upper_string,$parameter) !== false){
          return true;
        }
      }
    }


  }
?>
