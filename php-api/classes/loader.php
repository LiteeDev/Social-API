<?php

  /* Vendors Loader */
  require 'classes/vendor/autoload.php';
  $Router = new \Klein\Klein();

  require_once __DIR__ . '/smarty/SmartyBC.class.php';
  require_once __DIR__ . '/encryption.salt.php';
  require_once __DIR__ . '/database.class.php';
  require_once __DIR__ . '/multifactor.class.php';
  require_once __DIR__ . '/api.class.php';
  require_once __DIR__ . '/client.class.php';
  require_once __DIR__ . '/web.class.php';

?>
