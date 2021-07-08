<?PHP

$host = ""; //put your host here
$user = ""; //in general is root
$password = ""; //use your password here
$dbname = ""; //your database
$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
	

$check = mysql_query("SELECT * FROM Player WHERE `Username`='".$user."'");
$numrows = mysql_num_rows($check);
if ($numrows == 0)
{
	die ("Username does not exist \n");
}
else
{
	$pass = md5($pass);
	while($row = mysql_fetch_assoc($check))
	{
		if ($pass == $row['Password'])
			die("login-SUCCESS");
		else
			die("Password does not match \n");
	}
}

?>