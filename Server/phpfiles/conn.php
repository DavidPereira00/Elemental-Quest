<?php
$db_name = "your db";
$mysql_username ="your username";
$mysql_password ="your password";
$server_name = "localhost";
$conn = mysqli_connect($server_name, $mysql_username, $mysql_password, $db_name);


if(!$conn){
	die ("Connection Failed ". mysqli_connect_error());
}
?>