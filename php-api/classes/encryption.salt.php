<?php

  define("DATABASE_SALT", "uRZWYur02cotEUv2M7UHb4YuEf3Yt90A");
  define("USER_SALT", "USER_BYPASS_ENCRYPTION");

  class Encryption {
    function base64urlencode($input)
    {
        return strtr(base64_encode($input), '+/=', '._-');
    }

    function base64urldecode($input)
    {
        return base64_decode(strtr($input, '._-', '+/='));
    }

    public static function encryptURI($id_value, $salt_key)
    {
      $openSsl = openssl_encrypt($id_value, "AES-256-ECB", $salt_key);
      return Encryption::base64urlencode($openSsl);
    }

    public static function decryptURI($id_value, $salt_key)
    {
      $base64Decode = Encryption::base64urldecode($id_value);
      return openssl_decrypt($base64Decode, "AES-256-ECB", $salt_key);
    }

  }
?>
