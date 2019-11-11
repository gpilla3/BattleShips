<?php
	$con = mysqli_connect('localhost', 'root', '', 'unityaccess');

	//Check if that connection occured
	if(mysqli_connect_errno()){
		echo "Connection Failed"; //Error code #1 = connection failed
		exit();
	}

	$username = mysqli_real_escape_string($con, $_POST["name"]);
	$usernameclean = filter_var($username, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH);
	$password = $_POST["password"];

	if($username != $usernameclean){
		echo "Username contains invalid characters"; //Error code #7 - There are invalid characters in the username
		exit();
	}

	//Check if name already exists
	$namecheckquery = "SELECT username FROM players WHERE username='" . $username. "';";
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //Error code #2 - name check query failed

	//Multiple users
	if(mysqli_num_rows($namecheck) > 0){
		echo ("$usernameclean already exists!");
		exit();
	}

	//add user to the table
	$salt = "\$5\$rounds=2000\$" . "steamedhams" . $username . "\$ ";
	$hash = crypt($password, $salt);
	$insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username ."','" . $hash . "','" . $salt . "');";
	mysqli_query($con, $insertuserquery) or die("4: Insert player query failed"); //Error code #4 - insert query failed

	echo("0");
?>