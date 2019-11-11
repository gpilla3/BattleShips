<?php
	$con = mysqli_connect('localhost', 'root', '', 'unityaccess');

	//Check if that connection occured
	if(mysqli_connect_errno()){
		echo "1: Connection Failed"; //Error code #1 = connection failed
		exit();
	}

	$username = $_POST["name"];
	$newscore = $_POST["score"];

	//Check if name already exists
	$namecheckquery = "SELECT username, salt, hash, score FROM players WHERE username='" . $usernameclean. "';";
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //Error code #2 - name check query failed

	//Multiple users
	if(mysqli_num_rows($namecheck) > 1){
		echo "$usernameclean already exists!";
		exit();
	}

	$updatequery = "UPDATE players SET score = " . $newscore . "WHERE username = '" . $username . "';";
	mysqli_query($con, $updatequery) or die("8: Save Query Failed"); //Error code #7 - Update Query failed

	echo "0";

?>