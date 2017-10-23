<?php
$hostname = 'localhost';
$username = 'root';
$password = '';
$dbname = 'blog';

$mysqli = new mysqli($hostname, $username, $password, $dbname);

if($mysqli->connect_errno){
    die("Error! Failed to connect to MySQL");
}

$mysqli->set_charset("utf8");
$query = $mysqli->prepare("INSERT INTO users (username, password, fullname) VALUES (?, ?, ?)");

$user_username = "Greta";
$user_password = md5("IchLiebeWurtschen");
$user_fullname = "Greta Berghoffen";

$query->bind_param("ssi", $username, $password, $user_fullname);
$query->execute();

if($query->affected_rows == 1){
    echo "User successfully created!";
} else {
    die("Inserting user failed.");
} ?>