
//Stores information about the user that is logged in
public static class DBManager{

    public static string username;
    public static int userScore;

    //Used to verify if the user is logged in or not
    public static bool LoggedIn { get { return username != null; } }

    //Logs the user out
    public static void Logout() { username = null; }
}
