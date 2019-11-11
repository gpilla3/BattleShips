<?php
	$con = mysqli_connect('localhost', 'root', '', 'unityaccess');

	//Check if that connection occured
	if(mysqli_connect_errno()){
		echo "1: Connection Failed"; //Error code #1 = connection failed
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
	$namecheckquery = "SELECT username, salt, hash, score FROM players WHERE username='" . $usernameclean. "';";
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //Error code #2 - name check query failed

	//Multiple users
	if(mysqli_num_rows($namecheck) > 1){
		echo "$usernameclean already exists!";
		exit();
	}

	//User doesn't exists
	if(mysqli_num_rows($namecheck) == 0){
		echo ("$usernameclean doesn't exist!");
		exit();
	}

	//get login info from query
	$existinginfo = mysqli_fetch_assoc($namecheck);
	$salt = $existinginfo["salt"];
	$hash = $existinginfo["hash"];

	$loginhash = crypt($password, $salt);
	if($hash != $loginhash){
		echo "Incorrect Password"; //Error code #6 - password does not hash to match table
		exit();
	}

	echo "0\t" . $existinginfo["score"];

?>