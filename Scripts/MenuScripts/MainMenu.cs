using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//This is used to manage the main menu
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    
    //Display the player's username once they logged in.
    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            if(playerName != null)
            {
                playerName.SetText("Welcome " + DBManager.username);
            }
        }
    }

    //Loads the next scene once start is clicked
    public void StartGame()
    {
        SceneManager.LoadScene(5);
    }

    public void playerInfo()
    {
        SceneManager.LoadScene(3);
    }

    //If the exit button gets clicked
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit(); //Closes the application
    }
}
