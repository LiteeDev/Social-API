<?php

  class Client {

    public static function checkFriendRequest($userId, $friendId)
    {
      $Database = new DB();
      $checkFriendRequest = $Database->PDO->prepare("SELECT COUNT(*) FROM `tbl_friends` WHERE AES_DECRYPT(userID, '" . DATABASE_SALT . "') = :userID AND AES_DECRYPT(friendId, '" . DATABASE_SALT . "') = :friendId");
      $checkFriendRequest->execute(array(
          ':userID' => $userId,
          ':friendId' => $friendId
      ));
      //die($checkUsername->fetchColumn(0));
      if ($checkFriendRequest->fetchColumn(0) == 0) {
          return false;
      } else {
          return true;
      }
    }

    public static function sendFriendRequest($userId, $friendId)
    {

      /*
        Friends SQL:
        ID,
        userID,
        friendID,
        status, // 1 == friends, 0 == pending, 2 == blocked
        requestTime,

      */

      $Database = new DB();
      $Insert     = $Database->PDO->prepare("INSERT INTO `tbl_friends` VALUES(
        NULL,
        AES_ENCRYPT(:userID, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(:friendID, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(:status, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(UNIX_TIMESTAMP(), '" . DATABASE_SALT . "'))
       ");
      $Insert->execute(array(
            ':userID' => $userId,
            ':friendID' => $friendId,
            ':status' => 0,
        ));
      return true;
    }

    public static function getAccount($accountId)
    {
      $Database         = new DB();
      $User = $Database->PDO->query("SELECT ID AS ID,
      AES_DECRYPT(username, '" . DATABASE_SALT . "') AS username,
      AES_DECRYPT(email, '" . DATABASE_SALT . "') AS email,
      AES_DECRYPT(role, '" . DATABASE_SALT . "') AS role,
      AES_DECRYPT(lastLogin, '" . DATABASE_SALT . "') AS lastLogin,
      AES_DECRYPT(created, '" . DATABASE_SALT . "') AS created FROM `tbl_users` WHERE `ID` = '$accountId'");
      while ($UserInfo = $User->fetch(PDO::FETCH_ASSOC)) {
          $encodedId = Encryption::encryptURI($UserInfo['ID'], USER_SALT);
          $UserInfo['userId'] = $encodedId;
          $UserInfo['Authed'] = true;
          return $UserInfo;
      }
    }

    public static function Friends($userId)
    {
        $Database         = new DB();
        $LogArray['FriendList'] = array();
        $Friends = $Database->PDO->query("SELECT ID AS ID,
        AES_DECRYPT(userID, '" . DATABASE_SALT . "') AS userID,
        AES_DECRYPT(friendID, '" . DATABASE_SALT . "') AS friendID,
        AES_DECRYPT(status, '" . DATABASE_SALT . "') AS status,
        AES_DECRYPT(requestTime, '" . DATABASE_SALT . "') AS requestTime FROM `tbl_friends` WHERE `userID` = AES_ENCRYPT('$userId', '" . DATABASE_SALT . "')");
        while ($Friend = $Friends->fetch(PDO::FETCH_ASSOC)) {

            $AccountInfo = Client::getAccount($Friend['friendID']);

            if($Friend['status'] == 0)
            {
              $status = "Waiting for your response";
            }
            elseif($Friend['status'] == 1)
            {
              $status = "Friends";
            }

            $Data = array(
              "username" => $AccountInfo['username'],
              "email" => $AccountInfo['email'],
              "status" => $status,
            );

            array_push($LogArray['FriendList'], $Data);
        }

        $FriendsFrom = $Database->PDO->query("SELECT ID AS ID,
        AES_DECRYPT(userID, '" . DATABASE_SALT . "') AS userID,
        AES_DECRYPT(friendID, '" . DATABASE_SALT . "') AS friendID,
        AES_DECRYPT(status, '" . DATABASE_SALT . "') AS status,
        AES_DECRYPT(requestTime, '" . DATABASE_SALT . "') AS requestTime FROM `tbl_friends` WHERE `friendID` = AES_ENCRYPT('$userId', '" . DATABASE_SALT . "')");
        while ($Friend = $FriendsFrom->fetch(PDO::FETCH_ASSOC)) {

            $AccountInfo = Client::getAccount($Friend['userID']);

            if($Friend['status'] == 0)
            {
              $status = "Pending Friends Request";
            }
            elseif($Friend['status'] == 1)
            {
              $status = "Friends";
            }

            $Data = array(
              "username" => $AccountInfo['username'],
              "email" => $AccountInfo['email'],
              "status" => $status,
            );

            array_push($LogArray['FriendList'], $Data);
        }
        return $LogArray;
    }

  }

?>
