<?php
require "conn.php";
session_start();
$user_name = $_POST["user_name"];
$user_password = $_POST["password"];
$mysql_qry = "select Password,id from Player where Username = '".$user_name."' ";
$result = mysqli_query($conn, $mysql_qry);


if(mysqli_num_rows($result) > 0){
	while($row = mysqli_fetch_assoc($result)){
	if($row['Password'] == $user_password){
			$id = $row['id'];
			$_SESSION['id'] = $id;
			$_SESSION['nome'] = $user_name;
			echo "login success : " . $_SESSION['id'];
		}else{
			echo "password incorrect";
		}

	}
}	else{
	echo "user not found";
}
	

?>