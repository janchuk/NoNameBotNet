<?php

$host = '127.0.0.1';
$port = 2107;
$message = "<SFSC>coucou<EOC>";
echo "Envoie du message \"".$message."\" au zombie";
// create socket
$socket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP) or die("Could not create socket\n");
// connect to server
$result = socket_connect($socket, $host, $port) or die ("Could not connect to server\n");
//Send data
socket_write($socket, $message, strlen($message)) or die("Could not send data to server\n");


while ($out = socket_read($socket, 2048)) {
    echo $out;
}
?>