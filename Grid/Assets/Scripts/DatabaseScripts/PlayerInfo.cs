using UnityEngine;
using UnityEngine.SceneManagement;

//Used to display information about the player such as how many questions they answered correctly
public class PlayerInfo : MonoBehaviour
{
    public TMPro.TextMeshProUGUI theplayerName;
    public TMPro.TextMeshProUGUI playerScore;

    private void Start()
    {
        //If the user is logged in display their information
        if (DBManager.LoggedIn)
        {
            theplayerName.SetText("Username: " + DBManager.username);
            playerScore.SetText("Questions Answered: " + DBManager.userScore);
        }
    }

    //Goes back to the Menu scene
    public void GoBack()
    {
        SceneManager.LoadScene(4);
    }
}
