<?php
$servername = "localhost";
$username ="your username";in general root
$password ="your password";
$dbname = "your db";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$sql = "UPDATE QuestsAPP SET Selected='Yes' WHERE Selected='NO' order by rand() limit 1";

if ($conn->query($sql) === TRUE) {
    echo "Record updated successfully";
} else {
    echo "Error updating record: " . $conn->error;
}

$conn->close();
?>