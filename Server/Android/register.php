<?PHP
$host = ""; //put your host here
$user = ""; //in general is root
$password = ""; //use your password here
$dbname = ""; //your database
$conn = new mysqli($host, $user, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$check = mysql_query("SELECT * FROM Player WHERE `Username`='".$user."'");
$numrows = mysql_num_rows($check);
if ($numrows == 0)
{
	$pass = md5($pass);
	$ins = mysql_query("INSERT INTO  `Player` (`Username` , `Password` ) VALUES ('".$user."' , '".$pass."') ; ");
	if ($ins)
		die ("Succesfully Created User!");
	else
		die ("Error: " . mysql_error());
}
else
{
	die("User allready exists!");
}


?>