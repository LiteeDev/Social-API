<?php
  define("DATABASE_SALT", "uRZWYur02cotEUv2M7UHb4YuEf3Yt90A");

  class Encryption {
    function base64urlencode($input)
    {
        return strtr(base64_encode($input), '+/=', '._-');
    }

    function base64urldecode($input)
    {
        return base64_decode(strtr($input, '._-', '+/='));
    }
  }
?>
