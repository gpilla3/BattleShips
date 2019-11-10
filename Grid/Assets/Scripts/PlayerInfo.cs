using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public TMPro.TextMeshProUGUI theplayerName;
    public TMPro.TextMeshProUGUI playerScore;

    private void Start()
    {
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
