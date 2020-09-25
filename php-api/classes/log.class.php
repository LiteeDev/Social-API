<?php
  use GeoIp2\Database\Reader;

  class Log Extends Utilites {

    /*
      Function: Login($userId, $status)
      Response: boolean (true|false)
    */

    public static function Login($userId, $status)
    {
      $Database = new DB();

      // Get IP;
      $IPAddress = Utilites::getIP();

      // Get Country;
      $CountryCode = Utilites::getCountry($IPAddress);

      // Get UserAgent;
      $UserAgent = Utilites::getAgent();

      // Store Data;
      $Log = $Database->PDO->prepare("INSERT INTO `tbl_loginlogs` VALUES(
        NULL,
        AES_ENCRYPT(:userID, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(:country, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(:ip_address, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(:useragent, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(:status, '" . DATABASE_SALT . "'),
        AES_ENCRYPT(UNIX_TIMESTAMP(), '" . DATABASE_SALT . "'))
        ");
      $Log->execute(array(
            ':userID' => $userId,
            ':country' => $CountryCode,
            ':ip_address' => $IPAddress,
            ':useragent' => $UserAgent,
            ':status' => $status,
      ));
      return true;

    }

  }


  class Utilites {

    /*
      Function: getIP()
      Response: string (IPv4 Address)
    */
    public static function getIP()
    {
      switch(true){
            case (!empty($_SERVER['HTTP_X_REAL_IP'])) : return $_SERVER['HTTP_X_REAL_IP'];
            case (!empty($_SERVER['HTTP_CLIENT_IP'])) : return $_SERVER['HTTP_CLIENT_IP'];
            case (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) : return $_SERVER['HTTP_X_FORWARDED_FOR'];
            default : return $_SERVER['REMOTE_ADDR'];
      }
    }

    /*
      Function: getCountry($ipv4)
      Response: string (COUNTRY_CODE)
    */
    public static function getCountry($ipv4)
    {
      $reader = new Reader($_SERVER['DOCUMENT_ROOT'] . '/classes/data/GeoLite2-City.mmdb');
      $record = $reader->city($ipv4);
      return "{$record->country->isoCode}";
    }

    /*
      Function: getAgent($ipv4)
      Response: string (USER_AGENT)
    */
    public static function getAgent()
    {
      if(!empty($_SERVER['HTTP_USER_AGENT']))
      {
        return $_SERVER['HTTP_USER_AGENT'];
      }
      else
      {
        return "client";
      }
    }

  }

?>
