<?php
//these are the server details
//the username is root by default in case of xampp
//password is nothing by default
//and lastly we have the database named android. if your database name is different you have to change it 
$servername = "your host";
$username ="your username";
$password ="your password";
$database = "mydb";


//creating a new connection object using mysqli 
$conn = new mysqli($servername, $username, $password, $database);

//if there is some error connecting to the database
//with die we will stop the further execution by displaying a message causing the error 
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

//if everything is fine

//creating an array for storing the data 
$heroes = array(); 

//this is our sql query 
$sql = "SELECT  Einame FROM QuestsAPP Where Selected='Yes';";

//creating an statment with the query
$stmt = $conn->prepare($sql);

//executing that statment
$stmt->execute();

//binding results for that statment 
$stmt->bind_result( $name);

//looping through all the records
while($stmt->fetch()){
	
	//pushing fetched data in an array 
	$temp = 
		
		$name
	;
	
	//pushing the array inside the hero array 
	array_push($heroes, $temp);
}

//displaying the data in json format 
echo stripslashes($temp);
?>