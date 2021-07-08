<?php
$db_name = "your db";
$mysql_username ="your username";
$mysql_password ="your password";
$server_name = "localhost";
$conn = mysqli_connect($server_name, $mysql_username, $mysql_password, $db_name);


if(!$conn){
	die ("Connection Failed ". mysqli_connect_error());
}

$user_name = $_POST["user_name"];
$user_password = $_POST["password"];
$user_email = $_POST["email"];



if(!$conn){
	die ("Connection Failed ". mysqli_connect_error());
}

$sql = "INSERT INTO Player (Username, Password, email) VALUES ('".$user_name."','".$user_password."','".$user_email."')";
$result = mysqli_query($conn, $sql);
if(!result) echo "there was an error";
else echo "Everything is ok.";
?>